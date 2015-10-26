/// <binding BeforeBuild='build' />
var gulp = require('gulp');
var merge = require('merge-stream');
var rimraf = require("rimraf");
var gutil = require('gulp-util');
var gulpIgnore = require('gulp-ignore');

gulp.task('swagger', function () {

	var swagger =
		gulp.src('./bower_components/swagger-ui/Dist/**/*')
		//.pipe(gulpIgnore.exclude('./bower_components/swagger-ui/Dist/index.html'))
		.pipe(gulp.dest('./wwwroot/'));

	var swagfile =
		gulp.src('swagger.json')
		.pipe(gulp.dest('./wwwroot/'));

	return merge(swagger, swagfile);
});

gulp.task('clean', function (cb){
	rimraf('./wwwroot/*', cb);
});

gulp.task('styles', function () {
	return gulp.src('./Front/Styles/*')
		.pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('scripts', function () {
	return gulp.src('./Front/Scripts/*')
		.pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task('bootstrap', function(){
	return gulp.src('./bower_components/bootstrap/dist/**/*')
		.pipe(gulp.dest('./wwwroot/'));
});
gulp.task('jquery', function () {
	return gulp.src('./bower_components/jquery/dist/**/*')
		.pipe(gulp.dest('./wwwroot/js/'));
});

gulp.task('watch', function () {
	gulp.watch('./Front/css/*', ['styles']);
	gulp.watch('./Front/js/*', ['scripts']);
});


gulp.task('build', ['clean', 'styles', 'scripts', 'bootstrap', 'jquery']);