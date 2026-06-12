---
title: Sesuaikan Bentuk Presentasi dalam JavaScript
linktitle: Bentuk Khusus
type: docs
weight: 20
url: /id/nodejs-java/custom-shape/
keywords:
- bentuk khusus
- tambahkan bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik edit
- tambahkan titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- Node.js
- JavaScript
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan JavaScript dan Aspose.Slides untuk Node.js: jalur geometri, sudut melengkung, bentuk komposit."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Ini menunjukkan cara bekerja dengan `GeometryPath` untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke bentuk.

Ini juga mendemonstrasikan cara membuat bentuk khusus dan komposit, membangun bentuk dengan sudut melengkung, menentukan apakah geometri bentuk tertutup, dan mengonversi antara `GeometryPath` dan `java.awt.Shape` untuk skenario penyesuaian geometri tambahan.

## **Ubah Bentuk Menggunakan Titik Edit**

Pertimbangkan sebuah persegi. Di PowerPoint, dengan menggunakan **edit points**, Anda dapat 

* memindahkan sudut persegi ke dalam atau ke luar
* menentukan kelengkungan untuk sudut atau titik
* menambahkan titik baru ke persegi
* memanipulasi titik-titik pada persegi, dll. 

Secara prinsip, Anda dapat melakukan tugas-tugas yang dijelaskan pada bentuk apa pun. Dengan menggunakan edit points, Anda dapat mengubah sebuah bentuk atau membuat bentuk baru dari bentuk yang sudah ada. 

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Sebelum Anda mulai mengedit bentuk PowerPoint melalui edit points, Anda mungkin ingin mempertimbangkan hal-hal berikut tentang bentuk:

* Sebuah bentuk (atau jalurnya) bisa tertutup atau terbuka.
* Ketika sebuah bentuk tertutup, tidak memiliki titik mulai atau akhir. Ketika sebuah bentuk terbuka, ia memiliki awal dan akhir. 
* Semua bentuk terdiri dari setidaknya 2 titik jangkar yang terhubung satu sama lain oleh garis
* Sebuah garis dapat lurus atau melengkung. Titik jangkar menentukan sifat garis. 
* Titik jangkar hadir sebagai titik sudut, titik lurus, atau titik halus:
  * Titik sudut adalah titik di mana 2 garis lurus bergabung membentuk sudut. 
  * Titik halus adalah titik di mana 2 pegangan berada pada satu garis lurus dan segmen garis bergabung dalam kurva halus. Dalam hal ini, semua pegangan dipisahkan dari titik jangkar dengan jarak yang sama. 
  * Titik lurus adalah titik di mana 2 pegangan berada pada satu garis lurus dan segmen garis tersebut bergabung dalam kurva halus. Dalam hal ini, pegangan tidak harus dipisahkan dari titik jangkar dengan jarak yang sama. 
* Dengan memindahkan atau mengedit titik jangkar (yang mengubah sudut garis), Anda dapat mengubah tampilan sebuah bentuk. 

Untuk mengedit bentuk PowerPoint melalui edit points, **Aspose.Slides** menyediakan kelas [**GeometryPath**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath) dan kelas [**GeometryPath**](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath).

* Instance [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath) mewakili jalur geometri dari objek [GeometryShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape).
* Untuk mengambil `GeometryPath` dari instance `GeometryShape`, Anda dapat menggunakan metode [GeometryShape.getGeometryPaths](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape#getGeometryPaths--).
* Untuk menetapkan `GeometryPath` pada sebuah bentuk, Anda dapat menggunakan metode berikut: [GeometryShape.setGeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape#setGeometryPath-aspose.slides.IGeometryPath-) untuk *bentuk padat* dan [GeometryShape.setGeometryPaths](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape#setGeometryPaths-aspose.slides.IGeometryPath:A-) untuk *bentuk komposit*.
* Untuk menambahkan segmen, Anda dapat menggunakan metode di bawah [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath).
* Dengan menggunakan metode [GeometryPath.setStroke](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath#setStroke-boolean-) dan [GeometryPath.setFillMode](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath#setFillMode-byte-), Anda dapat mengatur tampilan jalur geometri.
* Dengan menggunakan metode [GeometryPath.getPathData](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath#getPathData--), Anda dapat mengambil jalur geometri dari `GeometryShape` sebagai array segmen jalur.
* Untuk mengakses opsi penyesuaian geometri bentuk tambahan, Anda dapat mengonversi [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath) ke [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html)
* Gunakan metode [geometryPathToGraphicsPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeUtil#geometryPathToGraphicsPath-aspose.slides.IGeometryPath-) dan [graphicsPathToGeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (dari kelas [ShapeUtil](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeUtil)) untuk mengonversi [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath) ke [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) bolak‑balik.

## **Operasi Penyuntingan Sederhana**

Kode JavaScript ini menunjukkan cara

**Tambahkan garis** ke akhir jalur

```javascript
lineTo(point);
lineTo(x, y);
```
**Tambahkan garis** ke posisi tertentu pada jalur:

```javascript
lineTo(point, index);
lineTo(x, y, index);
```
**Tambahkan kurva Bezier kubik** di akhir jalur:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Tambahkan kurva Bezier kubik** ke posisi tertentu pada jalur:

```javascript
cubicBezierTo(point1, point2, point3);
cubicBezierTo(x1, y1, x2, y2, x3, y3);
```
**Tambahkan kurva Bezier kuadratik** di akhir jalur:

```javascript
quadraticBezierTo(point1, point2);
quadraticBezierTo(x1, y1, x2, y2);
```
**Tambahkan kurva Bezier kuadratik** ke posisi tertentu pada jalur:

```javascript
quadraticBezierTo(point1, point2, index);
quadraticBezierTo(x1, y1, x2, y2, index);
```
**Tambahkan busur yang diberikan** ke jalur:

```javascript
arcTo(width, heigth, startAngle, sweepAngle);
```
**Tutup gambar saat ini** dari jalur:

```javascript
closeFigure();
```
**Atur posisi untuk titik berikutnya**:

```javascript
moveTo(point);
moveTo(x, y);
```
**Hapus segmen jalur** pada indeks tertentu:

```javascript
removeAt(index);
```

## **Tambahkan Titik Kustom ke Bentuk**
1. Buat instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape) dan atur tipe [ShapeType.Rectangle](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeType).
2. Dapatkan instance dari kelas [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath) dari bentuk.
3. Tambahkan titik baru di antara dua titik atas pada jalur.
4. Tambahkan titik baru di antara dua titik bawah pada jalur.
5. Terapkan jalur ke bentuk.

Kode JavaScript ini menunjukkan cara menambahkan titik kustom ke sebuah bentuk:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath = shape.getGeometryPaths()[0];
    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example1_image](custom_shape_1.png)

## **Hapus Titik dari Bentuk**

1. Buat instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape) dan atur tipe [ShapeType.Heart](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeType).
2. Dapatkan instance dari kelas [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath) dari bentuk.
3. Hapus segmen untuk jalur.
4. Terapkan jalur ke bentuk.

Kode JavaScript ini menunjukkan cara menghapus titik dari sebuah bentuk:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Heart, 100, 100, 300, 300);
    var path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example2_image](custom_shape_2.png)

## **Buat Bentuk Kustom**

1. Hitung titik-titik untuk bentuk.
2. Buat instance dari kelas [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath).
3. Isi jalur dengan titik-titik.
4. Buat instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape).
5. Terapkan jalur ke bentuk.

Kode JavaScript ini menunjukkan cara membuat bentuk kustom:

```javascript
var points = java.newInstanceSync("java.util.ArrayList");
var R = 100;
var r = 50;
var step = 72;
for (var angle = -90; angle < 270; angle += step) {
    var radians = angle * (java.getStaticFieldValue("java.lang.Math", "PI") / 180.0);
    var x = R * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    var y = R * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
    radians = (java.getStaticFieldValue("java.lang.Math", "PI") * (angle + (step / 2))) / 180.0;
    x = r * java.callStaticMethodSync("java.lang.Math", "cos", radians);
    y = r * java.callStaticMethodSync("java.lang.Math", "sin", radians);
    points.add(java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(x + R), java.newFloat(y + R)));
}
var starPath = new aspose.slides.GeometryPath();
starPath.moveTo(points.get(0));
for (var i = 1; i < points.size(); i++) {
    starPath.lineTo(points.get(i));
}
starPath.closeFigure();
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, R * 2, R * 2);
    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example3_image](custom_shape_3.png)


## **Buat Bentuk Kustom Komposit**

  1. Buat instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape).
  2. Buat instance pertama dari kelas [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath).
  3. Buat instance kedua dari kelas [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath).
  4. Terapkan jalur ke bentuk.

Kode JavaScript ini menunjukkan cara membuat bentuk kustom komposit:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 200, 100);
    var geometryPath0 = new aspose.slides.GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight() / 3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();
    var geometryPath1 = new aspose.slides.GeometryPath();
    geometryPath1.moveTo(0, (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), (shape.getHeight() / 3) * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();
    shape.setGeometryPaths(java.newArray("com.aspose.slides.GeometryPath",[geometryPath0, geometryPath1]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example4_image](custom_shape_4.png)

## **Buat Bentuk Kustom dengan Sudut Melengkung**

Kode JavaScript ini menunjukkan cara membuat bentuk kustom dengan sudut melengkung (ke dalam);

```javascript
var shapeX = 20.0;
var shapeY = 20.0;
var shapeWidth = 300.0;
var shapeHeight = 200.0;
var leftTopSize = 50.0;
var rightTopSize = 20.0;
var rightBottomSize = 40.0;
var leftBottomSize = 10.0;
var pres = new aspose.slides.Presentation();
try {
    var childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
    var geometryPath = new aspose.slides.GeometryPath();
    var point1 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftTopSize, 0);
    var point2 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth - rightTopSize, 0);
    var point3 = java.newInstanceSync("com.aspose.slides.Point2DFloat", shapeWidth, shapeHeight - rightBottomSize);
    var point4 = java.newInstanceSync("com.aspose.slides.Point2DFloat", leftBottomSize, shapeHeight);
    var point5 = java.newInstanceSync("com.aspose.slides.Point2DFloat", 0, leftTopSize);
    geometryPath.moveTo(point1);
    geometryPath.lineTo(point2);
    geometryPath.arcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.lineTo(point3);
    geometryPath.arcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.lineTo(point4);
    geometryPath.arcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.lineTo(point5);
    geometryPath.arcTo(leftTopSize, leftTopSize, 90, -90);
    geometryPath.closeFigure();
    childShape.setGeometryPath(geometryPath);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Temukan Apakah Geometri Bentuk Tertutup**

Bentuk tertutup didefinisikan sebagai bentuk di mana semua sisinya terhubung, membentuk satu batas tanpa celah. Bentuk semacam itu dapat berupa bentuk geometris sederhana atau kontur khusus yang kompleks. Contoh kode berikut menunjukkan cara memeriksa apakah geometri bentuk tertutup:

```java
function isGeometryClosed(geometryShape) 
{
    let isClosed = null;

    geometryShape.getGeometryPaths().forEach(geometryPath => {
        const pathData = geometryPath.getPathData();
        const dataLength = pathData.length;

        if (dataLength === 0) return;

        const lastSegment = pathData[dataLength - 1];
        isClosed = lastSegment.getPathCommand() === aspose.slides.PathCommandType.Close;

        if (!isClosed) return false;
    });

    return isClosed === true;
}
```

## **Konversi GeometryPath ke java.awt.Shape** 

1. Buat instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryShape).
2. Buat instance dari kelas [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html).
3. Konversi instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ke instance [GeometryPath](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/GeometryPath) menggunakan [ShapeUtil](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/ShapeUtil).
4. Terapkan jalur ke bentuk.

Kode JavaScript ini—implementasi dari langkah‑langkah di atas—menunjukkan proses konversi **GeometryPath** ke **GraphicsPath**:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Buat bentuk baru
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 300, 100);
    // Dapatkan jalur geometri dari bentuk
    var originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(aspose.slides.PathFillModeType.None);
    // Buat jalur grafik baru dengan teks
    var graphicsPath;
    var font = java.newInstanceSync("java.awt.Font", "Arial", java.getStaticFieldValue("java.awt.Font", "PLAIN"), 40);
    var text = "Text in shape";
    var img = java.newInstanceSync("BufferedImage", 100, 100, java.getStaticFieldValue("BufferedImage", "TYPE_INT_ARGB"));
    var g2 = img.createGraphics();
    try {
        var glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20.0, -glyphVector.getVisualBounds().getY() + 10);
    } finally {
        g2.dispose();
    }
    // Konversi jalur grafik ke jalur geometri
    var textPath = aspose.slides.ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(aspose.slides.PathFillModeType.Normal);
    // Atur kombinasi jalur geometri baru dan jalur geometri asli ke bentuk
    shape.setGeometryPaths(java.newArray("com.aspose.slides.IGeometryPath", [originalPath, textPath]));
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isi dan kontur setelah mengganti geometri?**

Gaya tetap berada pada bentuk; hanya kontur yang berubah. Isi dan kontur secara otomatis diterapkan ke geometri baru.

**Bagaimana cara memutar sebuah bentuk kustom bersama geometri secara tepat?**

Gunakan metode [setRotation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/shape/setrotation/) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Apakah saya dapat mengonversi bentuk kustom menjadi gambar untuk "mengunci" hasilnya?**

Ya. Ekspor area [slide](/slides/id/nodejs-java/convert-powerpoint-to-png/) yang diperlukan atau [shape](/slides/id/nodejs-java/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan selanjutnya dengan geometri yang kompleks.