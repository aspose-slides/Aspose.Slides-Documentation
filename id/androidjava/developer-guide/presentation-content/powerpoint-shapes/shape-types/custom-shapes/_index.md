---
title: Sesuaikan Bentuk Presentasi di Android
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/androidjava/custom-shape/
keywords:
- bentuk kustom
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
- Android
- Java
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk Android menggunakan Java: jalur geometri, sudut melengkung, bentuk gabungan."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Artikel ini menunjukkan cara bekerja dengan `GeometryPath` dan `IGeometryPath` untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Artikel ini juga mendemonstrasikan cara membuat bentuk khusus dan gabungan, membangun bentuk dengan sudut melengkung, menentukan apakah geometri bentuk tertutup, serta mengonversi antara `GeometryPath` dan `java.awt.Shape` untuk skenario penyesuaian geometri tambahan.

## **Mengubah Bentuk Menggunakan Titik Edit**
Bayangkan sebuah persegi. Di PowerPoint, menggunakan **titik edit**, Anda dapat

* memindahkan sudut persegi ke dalam atau ke luar
* menentukan kelengkungan untuk sebuah sudut atau titik
* menambahkan titik baru ke persegi
* memanipulasi titik pada persegi, dll.

Intinya, Anda dapat melakukan tugas‑tugas tersebut pada bentuk apa pun. Dengan titik edit, Anda dapat mengubah sebuah bentuk atau membuat bentuk baru dari bentuk yang sudah ada.

## **Tips Penyuntingan Bentuk**

![gambar_gambaran](custom_shape_0.png)

Sebelum mulai menyunting bentuk PowerPoint melalui titik edit, ada beberapa hal yang perlu dipertimbangkan tentang bentuk:

* Sebuah bentuk (atau jalurnya) dapat bersifat tertutup atau terbuka.
* Ketika sebuah bentuk tertutup, ia tidak memiliki titik mulai atau akhir. Ketika sebuah bentuk terbuka, ia memiliki titik awal dan akhir. 
* Semua bentuk terdiri dari setidaknya 2 titik jangkar yang dihubungkan satu sama lain oleh garis.
* Garis dapat lurus atau melengkung. Titik jangkar menentukan sifat garis. 
* Titik jangkar dapat berupa titik sudut, titik lurus, atau titik halus:
  * Titik sudut adalah titik di mana 2 garis lurus bertemu dengan sudut tertentu. 
  * Titik halus adalah titik di mana 2 pegangan berada pada satu garis lurus dan segmen‑segmen garis tersebut bergabung dalam lengkungan halus. Pada kasus ini, semua pegangan berada pada jarak yang sama dari titik jangkar. 
  * Titik lurus adalah titik di mana 2 pegangan berada pada satu garis lurus dan segmen‑segmen garis tersebut bergabung dalam lengkungan halus. Pada kasus ini, pegangan tidak harus berada pada jarak yang sama dari titik jangkar. 
* Dengan memindahkan atau menyunting titik jangkar (yang mengubah sudut garis), Anda dapat mengubah tampilan sebuah bentuk. 

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [**GeometryPath**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) dan antarmuka [**IGeometryPath**](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryPath).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) mewakili jalur geometri dari objek [IGeometryShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryShape).
* Untuk mengambil `GeometryPath` dari instance `IGeometryShape`, Anda dapat menggunakan metode [IGeometryShape.getGeometryPaths](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryShape#getGeometryPaths--) .
* Untuk menetapkan `GeometryPath` pada sebuah bentuk, Anda dapat menggunakan metode berikut: [IGeometryShape.setGeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryShape#setGeometryPath-com.aspose.slides.IGeometryPath-) untuk *bentuk padat* dan [IGeometryShape.setGeometryPaths](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryShape#setGeometryPaths-com.aspose.slides.IGeometryPath:A-) untuk *bentuk gabungan*.
* Untuk menambahkan segmen, Anda dapat menggunakan metode‑metode di bawah [IGeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryPath).
* Dengan metode [IGeometryPath.setStroke](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryPath#setStroke-boolean-) dan [IGeometryPath.setFillMode](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryPath#setFillMode-byte-), Anda dapat mengatur tampilan jalur geometri.
* Dengan metode [IGeometryPath.getPathData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IGeometryPath#getPathData--) , Anda dapat mengambil jalur geometri dari sebuah `GeometryShape` dalam bentuk array segmen jalur.
* Untuk mengakses opsi penyesuaian geometri bentuk tambahan, Anda dapat mengonversi [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) menjadi [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) .
* Gunakan metode [geometryPathToGraphicsPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeUtil#geometryPathToGraphicsPath-com.aspose.slides.IGeometryPath-) dan [graphicsPathToGeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeUtil#graphicsPathToGeometryPath-java.awt.Shape-) (dari kelas [ShapeUtil](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeUtil)) untuk mengonversi [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) ke [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) bolak‑balik.

## **Operasi Penyuntingan Sederhana**

Kode Java ini menunjukkan cara

**Menambahkan garis** ke akhir jalur

``` java
public void lineTo(java.awt.geom.Point2D.Float point);
public void lineTo(float x, float y);
```
**Menambahkan garis** ke posisi tertentu pada jalur:

``` java    
public void lineTo(java.awt.geom.Point2D.Float point, long index);
public void lineTo(float x, float y, long index);
```
**Menambahkan kurva Bezier kubik** di akhir jalur:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Menambahkan kurva Bezier kubik** ke posisi tertentu pada jalur:

``` java
public void cubicBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, java.awt.geom.Point2D.Float point3, long index);
public void cubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, long index);
```
**Menambahkan kurva Bezier kuadratik** di akhir jalur:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2);
public void quadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Menambahkan kurva Bezier kuadratik** ke posisi tertentu pada jalur:

``` java
public void quadraticBezierTo(java.awt.geom.Point2D.Float point1, java.awt.geom.Point2D.Float point2, long index);
public void quadraticBezierTo(float x1, float y1, float x2, float y2, long index);
```
**Menambahkan busur tertentu** ke jalur:

``` java
public void arcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Menutup gambar saat ini** pada jalur:

``` java
public void closeFigure();
```
**Menetapkan posisi untuk titik berikutnya**:

``` java
public void moveTo(java.awt.geom.Point2D.Float point);
public void moveTo(float x, float y);
```
**Menghapus segmen jalur** pada indeks tertentu:

``` java
public void removeAt(int index);
```

## **Menambahkan Titik Kustom ke Bentuk**
1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryShape) dan atur tipe [ShapeType.Rectangle](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeType) .
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) dari bentuk tersebut.
3. Tambahkan titik baru di antara dua titik atas pada jalur.
4. Tambahkan titik baru di antara dua titik bawah pada jalur.
5. Terapkan jalur ke bentuk.

Kode Java ini menunjukkan cara menambahkan titik kustom ke sebuah bentuk:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
    IGeometryPath geometryPath = shape.getGeometryPaths()[0];

    geometryPath.lineTo(100, 50, 1);
    geometryPath.lineTo(100, 50, 4);
    shape.setGeometryPath(geometryPath);
} finally {
    if (pres != null) pres.dispose();
}
```
![contoh1_gambar](custom_shape_1.png)

## **Menghapus Titik dari Bentuk**

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryShape) dan atur tipe [ShapeType.Heart](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeType) .
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) dari bentuk tersebut.
3. Hapus segmen untuk jalur.
4. Terapkan jalur ke bentuk.

Kode Java ini menunjukkan cara menghapus titik dari sebuah bentuk:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Heart, 100, 100, 300, 300);

    IGeometryPath path = shape.getGeometryPaths()[0];
    path.removeAt(2);
    shape.setGeometryPath(path);
} finally {
    if (pres != null) pres.dispose();
}
```
![contoh2_gambar](custom_shape_2.png)

## **Membuat Bentuk Kustom**

1. Hitung titik‑titik untuk bentuk.
2. Buat instance kelas [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) .
3. Isi jalur dengan titik‑titik tersebut.
4. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryShape) .
5. Terapkan jalur ke bentuk.

Kode Java ini menunjukkan cara membuat bentuk kustom:

``` java
List<Point2D.Float> points = new ArrayList<Point2D.Float>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.cos(radians);
    double y = R * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.cos(radians);
    y = r * Math.sin(radians);
    points.add(new Point2D.Float((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.moveTo(points.get(0));

for (int i = 1; i < points.size(); i++)
{
    starPath.lineTo(points.get(i));
}

starPath.closeFigure();

Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2);

    shape.setGeometryPath(starPath);
} finally {
    if (pres != null) pres.dispose();
}

```
![contoh3_gambar](custom_shape_3.png)


## **Membuat Bentuk Kustom Gabungan**

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryShape) .
2. Buat instance pertama dari kelas [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) .
3. Buat instance kedua dari kelas [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) .
4. Terapkan jalur‑jalur tersebut ke bentuk.

Kode Java ini menunjukkan cara membuat bentuk kustom gabungan:

``` java
Presentation pres = new Presentation();
try {
    GeometryShape shape = (GeometryShape) pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.moveTo(0, 0);
    geometryPath0.lineTo(shape.getWidth(), 0);
    geometryPath0.lineTo(shape.getWidth(), shape.getHeight()/3);
    geometryPath0.lineTo(0, shape.getHeight() / 3);
    geometryPath0.closeFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.moveTo(0, shape.getHeight()/3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight() / 3 * 2);
    geometryPath1.lineTo(shape.getWidth(), shape.getHeight());
    geometryPath1.lineTo(0, shape.getHeight());
    geometryPath1.closeFigure();

    shape.setGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
} finally {
    if (pres != null) pres.dispose();
}
```
![contoh4_gambar](custom_shape_4.png)

## **Membuat Bentuk Kustom dengan Sudut Melengkung**

Kode Java ini menunjukkan cara membuat bentuk kustom dengan sudut melengkung (ke dalam);

```java
float shapeX = 20f;
float shapeY = 20f;
float shapeWidth = 300f;
float shapeHeight = 200f;

float leftTopSize = 50f;
float rightTopSize = 20f;
float rightBottomSize = 40f;
float leftBottomSize = 10f;

Presentation pres = new Presentation();
try {
    IAutoShape childShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(
            ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    GeometryPath geometryPath = new GeometryPath();

    Point2D.Float point1 = new Point2D.Float(leftTopSize, 0);
    Point2D.Float point2 = new Point2D.Float(shapeWidth - rightTopSize, 0);
    Point2D.Float point3 = new Point2D.Float(shapeWidth, shapeHeight - rightBottomSize);
    Point2D.Float point4 = new Point2D.Float(leftBottomSize, shapeHeight);
    Point2D.Float point5 = new Point2D.Float(0, leftTopSize);

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

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres!= null) pres.dispose();
}
```

## **Menentukan Apakah Geometri Bentuk Tertutup**

Sebuah bentuk tertutup didefinisikan sebagai bentuk di mana semua sisinya terhubung, membentuk satu batas tanpa celah. Bentuk semacam itu dapat berupa bentuk geometris sederhana atau kontur kustom yang kompleks. Contoh kode berikut menunjukkan cara memeriksa apakah geometri sebuah bentuk tertutup:

```java
boolean isGeometryClosed(IGeometryShape geometryShape)
{
    Boolean isClosed = null;

    for (IGeometryPath geometryPath : geometryShape.getGeometryPaths()) {
        int dataLength = geometryPath.getPathData().length;
        if (dataLength == 0)
            continue;

        IPathSegment lastSegment = geometryPath.getPathData()[dataLength - 1];
        isClosed = lastSegment.getPathCommand() == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }

    return isClosed == true;
}
```

## **Mengonversi GeometryPath ke java.awt.Shape** 

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryShape) .
2. Buat instance kelas [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) .
3. Konversikan instance [java.awt.Shape](https://docs.oracle.com/javase/7/docs/api/java/awt/Shape.html) ke instance [GeometryPath](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/GeometryPath) menggunakan [ShapeUtil](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ShapeUtil) .
4. Terapkan jalur‑jalur tersebut ke bentuk.

Kode Java ini—implementasi dari langkah‑langkah di atas—menunjukkan proses konversi **GeometryPath** ke **GraphicsPath**:

``` java
Presentation pres = new Presentation();
try {
    // Buat bentuk baru
    GeometryShape shape = (GeometryShape)pres.getSlides().get_Item(0).
            getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

    // Dapatkan jalur geometri dari bentuk
    IGeometryPath originalPath = shape.getGeometryPaths()[0];
    originalPath.setFillMode(PathFillModeType.None);

    // Buat jalur grafik baru dengan teks
    Shape graphicsPath;
    Font font = new java.awt.Font("Arial", Font.PLAIN, 40);
    String text = "Text in shape";
    BufferedImage img = new BufferedImage(100, 100, BufferedImage.TYPE_INT_ARGB);
    Graphics2D g2 = img.createGraphics();

    try
    {
        GlyphVector glyphVector = font.createGlyphVector(g2.getFontRenderContext(), text);
        graphicsPath = glyphVector.getOutline(20f, ((float) -glyphVector.getVisualBounds().getY()) + 10);
    }
    finally {
        g2.dispose();
    }

    // Konversi jalur grafik ke jalur geometri
    IGeometryPath textPath = ShapeUtil.graphicsPathToGeometryPath(graphicsPath);
    textPath.setFillMode(PathFillModeType.Normal);

    // Atur kombinasi jalur geometri baru dan jalur geometri asal ke bentuk
    shape.setGeometryPaths(new IGeometryPath[] { originalPath, textPath });
} finally {
    if (pres != null) pres.dispose();
}
```
![contoh5_gambar](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isi dan garis tepi setelah mengganti geometri?**

Gaya tetap melekat pada bentuk; hanya kontur yang berubah. Isi dan garis tepi secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom bersama geometri­nya dengan benar?**

Gunakan metode [setRotation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/shape/#setRotation-float-) milik bentuk; geometri akan berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Apakah saya dapat mengonversi bentuk kustom menjadi gambar untuk “mengunci” hasilnya?**

Ya. Ekspor area [slide](/slides/id/androidjava/convert-powerpoint-to-png/) yang dibutuhkan atau [shape](/slides/id/androidjava/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan selanjutnya dengan geometri yang berat.