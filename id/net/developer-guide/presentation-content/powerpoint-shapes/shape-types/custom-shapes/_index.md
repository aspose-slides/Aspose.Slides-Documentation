---
title: Sesuaikan Bentuk Presentasi di .NET
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/net/custom-shape/
keywords:
- bentuk kustom
- tambahkan bentuk
- buat bentuk
- ubah bentuk
- geometri bentuk
- jalur geometri
- titik jalur
- titik edit
- tambah titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk .NET: jalur geometri, sudut melengkung, bentuk komposit."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Ini menunjukkan cara bekerja dengan `GeometryPath` dan `IGeometryPath` untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Ini juga memperagakan cara membuat bentuk khusus dan gabungan, membangun bentuk dengan sudut melengkung, menentukan apakah geometri sebuah bentuk tertutup, dan mengonversi antara `GeometryPath` dan `GraphicsPath` untuk skenario penyesuaian geometri tambahan.

## **Ubah Bentuk dengan Titik Edit**

Pertimbangkan sebuah persegi. Di PowerPoint, dengan menggunakan **titik edit**, Anda dapat

* memindahkan sudut persegi ke dalam atau ke luar
* menentukan kelengkungan untuk sudut atau titik
* menambahkan titik baru ke persegi
* memanipulasi titik pada persegi, dll.

Intinya, Anda dapat melakukan tugas-tugas yang dijelaskan pada bentuk apa pun. Dengan titik edit, Anda dapat mengubah sebuah bentuk atau membuat bentuk baru dari bentuk yang sudah ada.

## **Tip Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Sebelum Anda mulai menyunting bentuk PowerPoint melalui titik edit, Anda mungkin ingin mempertimbangkan hal-hal berikut tentang bentuk:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Semua bentuk terdiri dari setidaknya 2 titik jangkar yang terhubung satu sama lain oleh garis.
* Sebuah garis dapat lurus atau melengkung. Titik jangkar menentukan sifat garis.
* Titik jangkar ada sebagai titik sudut, titik lurus, atau titik halus:
  * Titik sudut adalah titik dimana 2 garis lurus bergabung dengan sudut tertentu.
  * Titik halus adalah titik dimana 2 pegangan berada pada satu garis lurus dan segmen garis bergabung dalam lengkungan halus. Dalam kasus ini, semua pegangan dipisahkan dari titik jangkar dengan jarak yang sama.
  * Titik lurus adalah titik dimana 2 pegangan berada pada satu garis lurus dan segmen garis tersebut bergabung dalam lengkungan halus. Dalam kasus ini, pegangan tidak harus dipisahkan dari titik jangkar dengan jarak yang sama.
* Dengan memindahkan atau menyunting titik jangkar (yang mengubah sudut garis), Anda dapat mengubah tampilan sebuah bentuk.

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [**GeometryPath**](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath) dan antarmuka [**IGeometryPath**](https://reference.aspose.com/slides/id/net/aspose.slides/igeometrypath).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath) mewakili jalur geometri dari objek [IGeometryShape](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape).
* Untuk mengambil `GeometryPath` dari instance `IGeometryShape`, Anda dapat menggunakan metode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/methods/getgeometrypaths).
* Untuk menetapkan `GeometryPath` pada sebuah bentuk, Anda dapat menggunakan metode berikut: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/methods/setgeometrypath) untuk *bentuk padat* dan [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/id/net/aspose.slides/igeometryshape/methods/setgeometrypaths) untuk *bentuk komposit*.
* Untuk menambahkan segmen, Anda dapat menggunakan metode di bawah [IGeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/igeometrypath).
* Dengan menggunakan properti [IGeometryPath.Stroke](https://reference.aspose.com/slides/id/net/aspose.slides/igeometrypath/properties/stroke) dan [IGeometryPath.FillMode](https://reference.aspose.com/slides/id/net/aspose.slides/igeometrypath/properties/fillmode), Anda dapat mengatur tampilan sebuah jalur geometri.
* Dengan menggunakan properti [IGeometryPath.PathData](https://reference.aspose.com/slides/id/net/aspose.slides/igeometrypath/properties/pathdata), Anda dapat mengambil jalur geometri dari `GeometryShape` sebagai array segmen jalur.
* Untuk mengakses opsi penyesuaian geometri bentuk tambahan, Anda dapat mengonversi [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath) ke [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
* Gunakan metode [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/id/net/aspose.slides.util/shapeutil/methods/geometrypathtographicspath) dan [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides.util/shapeutil/methods/graphicspathtogeometrypath) (dari kelas [ShapeUtil](https://reference.aspose.com/slides/id/net/aspose.slides.util/shapeutil)) untuk mengonversi [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath) ke [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0) bolak-balik.

## **Operasi Penyuntingan Sederhana**

Kode C# ini menunjukkan cara

**Menambahkan garis** ke akhir jalur

``` csharp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Menambahkan garis** ke posisi tertentu pada jalur:

``` csharp    
void LineTo(PointF point, uint index);
void LineTo(float x, float y, uint index);
```
**Menambahkan kurva Bezier kubik** di akhir jalur:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Menambahkan kurva Bezier kubik** ke posisi tertentu pada jalur:

``` csharp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint index);
```
**Menambahkan kurva Bezier kuadratik** di akhir jalur:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Menambahkan kurva Bezier kuadratik** ke posisi tertentu pada jalur:

``` csharp
void QuadraticBezierTo(PointF point1, PointF point2, uint index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint index);
```
**Menambahkan busur tertentu** ke jalur:

``` csharp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Menutup gambar saat ini** pada jalur:

``` csharp
void CloseFigure();
```
**Menetapkan posisi untuk titik berikutnya**:

``` csharp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Menghapus segmen jalur** pada indeks tertentu:

``` csharp
void RemoveAt(int index);
```

## **Menambahkan Titik Kustom ke Bentuk**

1. Buat sebuah instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/net/aspose.slides/geometryshape) dan atur tipe [ShapeType.Rectangle](https://reference.aspose.com/slides/id/net/aspose.slides/shapetype).
2. Dapatkan sebuah instance dari kelas [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath) dari bentuk tersebut.
3. Tambahkan titik baru di antara dua titik atas pada jalur.
4. Tambahkan titik baru di antara dua titik bawah pada jalur.
5. Terapkan jalur ke bentuk.

Kode C# ini menunjukkan cara menambahkan titik kustom ke sebuah bentuk:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;
    IGeometryPath geometryPath = shape.GetGeometryPaths()[0];

    geometryPath.LineTo(100, 50, 1);
    geometryPath.LineTo(100, 50, 4);
    shape.SetGeometryPath(geometryPath);
}
```

![example1_image](custom_shape_1.png)

## **Menghapus Titik dari Bentuk**

1. Buat sebuah instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/net/aspose.slides/geometryshape) dan atur tipe [ShapeType.Heart](https://reference.aspose.com/slides/id/net/aspose.slides/shapetype).
2. Dapatkan sebuah instance dari kelas [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath) dari bentuk tersebut.
3. Hapus segmen untuk jalur.
4. Terapkan jalur ke bentuk.

Kode C# ini menunjukkan cara menghapus titik dari sebuah bentuk:

``` csharp
using (Presentation pres = new Presentation())
{
	GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300) as GeometryShape;

	IGeometryPath path = shape.GetGeometryPaths()[0];
	path.RemoveAt(2);
	shape.SetGeometryPath(path);
}
```
![example2_image](custom_shape_2.png)

## **Membuat Bentuk Kustom**

1. Hitung titik-titik untuk bentuk tersebut.
2. Buat sebuah instance dari kelas [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath).
3. Isi jalur dengan titik-titik tersebut.
4. Buat sebuah instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/net/aspose.slides/geometryshape).
5. Terapkan jalur ke bentuk.

Kode C# ini menunjukkan cara membuat bentuk kustom:

``` csharp
List<PointF> points = new List<PointF>();

float R = 100, r = 50;
int step = 72;

for (int angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math.PI / 180f);
    double x = R * Math.Cos(radians);
    double y = R * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));

    radians = Math.PI * (angle + step / 2) / 180.0;
    x = r * Math.Cos(radians);
    y = r * Math.Sin(radians);
    points.Add(new PointF((float)x + R, (float)y + R));
}

GeometryPath starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (int i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, R * 2, R * 2) as GeometryShape;

    shape.SetGeometryPath(starPath);
}
```
![example3_image](custom_shape_3.png)

## **Membuat Bentuk Gabungan Kustom**

1. Buat sebuah instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/net/aspose.slides/geometryshape).
2. Buat instance pertama dari kelas [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath).
3. Buat instance kedua dari kelas [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath).
4. Terapkan jalur-jalur ke bentuk.

Kode C# ini menunjukkan cara membuat bentuk gabungan kustom:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100) as GeometryShape;

    GeometryPath geometryPath0 = new GeometryPath();
    geometryPath0.MoveTo(0, 0);
    geometryPath0.LineTo(shape.Width, 0);
    geometryPath0.LineTo(shape.Width, shape.Height/3);
    geometryPath0.LineTo(0, shape.Height / 3);
    geometryPath0.CloseFigure();

    GeometryPath geometryPath1 = new GeometryPath();
    geometryPath1.MoveTo(0, shape.Height/3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height / 3 * 2);
    geometryPath1.LineTo(shape.Width, shape.Height);
    geometryPath1.LineTo(0, shape.Height);
    geometryPath1.CloseFigure();

    shape.SetGeometryPaths(new GeometryPath[] { geometryPath0, geometryPath1});
}
```
![example4_image](custom_shape_4.png)

## **Membuat Bentuk Kustom dengan Sudut Melengkung**

Kode C# ini menunjukkan cara membuat bentuk kustom dengan sudut melengkung (ke dalam);

```c#
var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using (var presentation = new Presentation())
{
    var childShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);

    var geometryPath = new GeometryPath();

    var point1 = new PointF(leftTopSize, 0);
    var point2 = new PointF(shapeWidth - rightTopSize, 0);
    var point3 = new PointF(shapeWidth, shapeHeight - rightBottomSize);
    var point4 = new PointF(leftBottomSize, shapeHeight);
    var point5 = new PointF(0, leftTopSize);

    geometryPath.MoveTo(point1);
    geometryPath.LineTo(point2);
    geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
    geometryPath.LineTo(point3);
    geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
    geometryPath.LineTo(point4);
    geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
    geometryPath.LineTo(point5);
    geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);

    geometryPath.CloseFigure();

    childShape.SetGeometryPath(geometryPath);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

## **Menentukan Apakah Geometri Bentuk Tertutup**

Suatu bentuk tertutup didefinisikan sebagai bentuk di mana semua sisinya terhubung, membentuk satu batas tanpa celah. Bentuk semacam itu dapat berupa bentuk geometris sederhana atau kontur kustom yang kompleks. Contoh kode berikut menunjukkan cara memeriksa apakah geometri sebuah bentuk tertutup:

```cs
bool IsGeometryClosed(IGeometryShape geometryShape)
{
    bool? isClosed = null;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var dataLength = geometryPath.PathData.Length;
        if (dataLength == 0)
            continue;

        var lastSegment = geometryPath.PathData[dataLength - 1];
        isClosed = lastSegment.PathCommand == PathCommandType.Close;

        if (isClosed == false)
            return false;
    }
    
    return isClosed == true;
}
```

## **Mengonversi GeometryPath ke GraphicsPath (System.Drawing.Drawing2D)**

1. Buat sebuah instance dari kelas [GeometryShape](https://reference.aspose.com/slides/id/net/aspose.slides/geometryshape).
2. Buat sebuah instance dari kelas [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) pada namespace [System.Drawing.Drawing2D](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d?view=dotnet-plat-ext-5.0).
3. Konversi instance [GraphicsPath](https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath?view=dotnet-plat-ext-5.0) ke instance [GeometryPath](https://reference.aspose.com/slides/id/net/aspose.slides/geometrypath) menggunakan [ShapeUtil](https://reference.aspose.com/slides/id/net/aspose.slides.util/shapeutil).
4. Terapkan jalur ke bentuk.

Kode C# ini—implementasi dari langkah-langkah di atas—menunjukkan proses konversi **GeometryPath** ke **GraphicsPath**:

``` csharp
using (Presentation pres = new Presentation())
{
    GeometryShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100) as GeometryShape;

    IGeometryPath originalPath = shape.GetGeometryPaths()[0];
    originalPath.FillMode = PathFillModeType.None;

    GraphicsPath gPath = new GraphicsPath();

    gPath.AddString("Text in shape", new FontFamily("Arial"), 1, 40, new PointF(10, 10), StringFormat.GenericDefault);

    IGeometryPath textPath = ShapeUtil.GraphicsPathToGeometryPath(gPath);
    textPath.FillMode = PathFillModeType.Normal;

    shape.SetGeometryPaths(new[] {originalPath, textPath}) ;
}
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isi dan kontur setelah mengganti geometri?**

Gaya tetap pada bentuk; hanya kontur yang berubah. Isi dan kontur secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom beserta geometrinya dengan benar?**

Gunakan properti [rotation](https://reference.aspose.com/slides/id/net/aspose.slides/shape/rotation/) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk tersebut.

**Apakah saya dapat mengonversi bentuk kustom ke gambar untuk “mengunci” hasilnya?**

Ya. Ekspor area [slide](/slides/id/net/convert-powerpoint-to-png/) yang diperlukan atau [bentuk](/slides/id/net/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan selanjutnya dengan geometri yang kompleks.