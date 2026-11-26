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
- tambahkan titik
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
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometri. Artikel ini menunjukkan cara bekerja dengan [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dan [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke bentuk.

Artikel ini juga mendemonstrasikan cara membuat bentuk kustom dan komposit, membangun bentuk dengan sudut melengkung, menentukan apakah geometri bentuk tertutup, dan menggunakan konversi warisan antara [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dan [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) untuk skenario penyesuaian geometri tambahan.

## **Mengubah Bentuk Menggunakan Titik Edit**

Di PowerPoint, Anda dapat menggunakan **Edit Points** untuk memodifikasi sebuah persegi:

* Memindahkan sebuah sudut ke dalam atau ke luar.
* Menyesuaikan kelengkungan pada sebuah titik.
* Menambahkan titik baru.

Mengedit titik memungkinkan Anda memodifikasi kontur bentuk atau menggunakan bentuk yang ada sebagai dasar untuk bentuk baru.

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Saat menyunting bentuk PowerPoint, ingatlah konsep-konsep berikut:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Jalur bentuk terdiri dari titik jangkar yang dihubungkan oleh segmen.
* Sebuah segmen dapat lurus atau melengkung. Titik jangkar dan pegangan kontrol menentukan bentuknya.
* Titik jangkar dapat berupa titik sudut, titik lurus, atau titik halus:
  * Pada titik sudut, segmen yang berdekatan dapat bertemu dengan sudut.
  * Pada titik halus, dua pegangan kontrol sejajar dan berjarak sama dari titik jangkar.
  * Pada titik lurus, dua pegangan kontrol sejajar tetapi dapat memiliki jarak yang berbeda dari titik jangkar.
* Memindahkan titik jangkar atau menyesuaikan pegangan mereka mengubah kontur bentuk.

Untuk menyunting bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dan antarmuka [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) mewakili jalur geometri dari objek [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dari instance [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), Anda dapat menggunakan metode [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Untuk menetapkan [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) pada sebuah bentuk, Anda dapat menggunakan metode berikut: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) untuk bentuk dengan satu jalur dan [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) untuk bentuk dengan beberapa jalur.
* Untuk menambahkan segmen, Anda dapat menggunakan metode di bawah [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Dengan menggunakan properti [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) dan [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/), Anda dapat mengatur tampilan untuk jalur geometri.
* Dengan menggunakan properti [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/), Anda dapat mengambil jalur geometri dari sebuah [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) sebagai array segmen jalur.
* Pada versi lama yang mendukung metode konversi di bawah, Anda dapat mengkonversi [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) ke [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Gunakan metode [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) dan [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (dari kelas [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) untuk mengkonversi antara [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) dan [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Operasi Penyuntingan Sederhana**

Gunakan metode berikut untuk menyunting jalur geometri. Overload yang menerima indeks menyisipkan segmen pada posisi berbasis nol dalam array segmen jalur.

| Operasi | Method |
| --- | --- |
| Menambahkan atau menyisipkan garis lurus. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Menambahkan atau menyisipkan kurva Bézier kubik dengan dua titik kontrol dan titik akhir. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Menambahkan atau menyisipkan kurva Bézier kuadratik dengan satu titik kontrol dan titik akhir. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Menambahkan busur elips dengan dimensi dan sudut yang ditentukan dalam derajat. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Menutup figur saat ini dengan menghubungkan titik akhiriannya ke titik mulanya. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Menetapkan titik awal sebuah figur. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Menghapus segmen pada indeks berbasis nol. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Menambahkan Titik Kustom ke Bentuk**

Contoh ini menyisipkan dua titik ke dalam bentuk persegi panjang menggunakan [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) dan menerapkan jalur yang diedit dengan [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Koordinat bersifat lokal terhadap bentuk: kedua titik baru berada di tengahnya, 100 poin dari kiri dan 50 poin dari atas. Indeks segmen 1 dan 4 menempatkannya pada tepi atas dan bawah, menarik tepi tersebut ke dalam.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Menghapus Titik dari Bentuk**

Contoh ini mengubah kontur berbentuk hati dengan menghapus segmen pada indeks berbasis nol 2 menggunakan [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Menerapkan jalur yang dimodifikasi dengan [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) memperbarui kontur bentuk.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Membuat Bentuk Kustom**

Contoh ini membangun bintang lima sudut dengan [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Radius luar dan dalam yang bergantian masing-masing 100 dan 50 poin menentukan ujung dan lekuk; langkah 72 derajat menempatkan kelima ujung secara merata. Jalur ditutup dengan [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) dan diterapkan ke bentuk persegi panjang menggunakan [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), menggantikan kontur aslinya.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Membuat Bentuk Kustom Komposit**

Contoh ini mendefinisikan dua objek [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) tertutup untuk sepertiga atas dan bawah sebuah bentuk. Menerapkan kedua jalur dengan [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) menghasilkan satu bentuk komposit dengan celah di sepertiga tengahnya.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Membuat Bentuk Kustom dengan Sudut Melengkung**

Contoh ini menggabungkan segmen lurus dengan [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) untuk membuat bentuk dengan sudut melengkung ke dalam. Setiap ukuran sudut menentukan lebar dan tinggi busur dalam poin, dan ayunan -90 derajat menggambar seperempat elips berlawanan arah jarum jam. Jalur yang selesai diterapkan dengan [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), dan presentasi disimpan dalam format PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Menentukan Apakah Geometri Bentuk Tertutup**

Helper berikut memeriksa apakah setiap jalur geometri yang tidak kosong berakhir dengan segmen penutup. Ia membaca [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) dan membandingkan perintah segmen akhir [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) dengan [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Ia mengembalikan false bila tidak ada jalur yang tidak kosong. Pemeriksaan ini memeriksa perintah akhir setiap jalur; tidak memeriksa setiap subfigur dalam jalur. Contoh mencetak `True` untuk sebuah persegi panjang.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Memeriksa Perintah Jalur Geometri**

Unduh [contour.pptx](contour.pptx) dan letakkan di direktori kerja aplikasi. Slide pertama berisi sebuah bentuk dengan tepi atas lurus, kurva Bézier kubik, dan tepi penutup lurus. Gunakan [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) untuk membaca jalurnya. Setiap jalur mencantumkan segmennya dalam urutan menggambar di [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Setiap [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) segmen menentukan cara membaca [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

Bentuk berada pada (200, 100) poin pada slide. Titik yang dilaporkan bersifat lokal terhadap bentuk, dengan (0, 0) di sudut kiri atasnya, x meningkat ke kanan, dan y meningkat ke bawah. Segmen penutup kembali ke titik awal tanpa koordinat tambahan.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Bentuk PowerPoint dengan tepi atas lurus, tepi melengkung dari kanan atas ke kiri bawah, dan tepi kiri lurus](contour.png)

## **Mengekstrak dan Memeriksa Elemen Bentuk**

Gunakan [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) untuk memeriksa bentuk yang ada sebagai elemen yang berisi titik-titik jalur dan tipe titik. Cast setiap [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) yang dikembalikan ke [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) untuk membaca array [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) dan [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Representasi ini berguna untuk analisis kontur atau meneruskan geometri ke alat gambar kustom.

Contoh ini membuka sebuah presentasi, menemukan bentuk geometri pertama langsung pada slide pertama, dan mencetak segmen jalurnya. Gunakan presentasi yang berisi bentuk dengan segmen lurus dan melengkung untuk melihat kedua jenis output. Ini tidak mencari di dalam grup.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Pertahankan tipe segmen, mengecualikan flag.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Konsumsi kedua titik kontrol dan titik akhir.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Array berkorespondensi berdasarkan indeks: `points[i]` adalah sebuah titik dan `types[i]` menggambarkan perannya. Tipe `0` memulai sebuah figur, dan tipe `1` menggambar garis dari titik sebelumnya ke titik saat ini. Segmen Bézier kubik dimulai pada titik akhir sebelumnya dan menggunakan tiga entri tipe-`3` berurutan: dua titik kontrol diikuti oleh titik akhir baru. Loop mengonsumsi ketiga entri tersebut secara bersamaan dan memeriksa titik akhir untuk penutupan.

Tipe titik juga mengandung flag. Mask dengan `0x07` untuk mengidentifikasi tipe segmen, dan uji `0x80` secara terpisah untuk mendeteksi subpath tertutup. Misalnya, `129` (`0x81`) berarti titik akhir garis yang menutup subpath, dan `131` (`0x83`) berarti titik akhir Bézier yang menutup satu. Membandingkan nilai mentah hanya dengan `1` atau `3` akan melewatkan kasus ini. Flag lain, seperti dash (`0x10`) dan marker (`0x20`), tidak mengubah tipe dasar segmen.

**Koordinat dan transformasi.** Titik diukur dalam poin (1/72 inci), dengan X meningkat ke kanan dan Y meningkat ke bawah. Untuk bentuk yang tidak dikelompokkan, koordinat yang diekstrak sudah mencakup posisi [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) dan [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) serta mencerminkan lebar dan tinggi saat ini. Misalnya, persegi panjang tanpa rotasi pada `(100, 200)` dengan ukuran `120 × 80` memiliki batas kontur `(100, 200)`–`(220, 280)`. Jangan menambahkan posisi bentuk lagi. Kurangi X dan Y untuk mendapatkan koordinat relatif terhadap kerangka tidak berotasi.

Titik yang diekstrak tidak menerapkan [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) atau pembalikan horizontal dan vertikal pada bentuk. Untuk mereproduksi kontur yang ditampilkan, terapkan transformasi tersebut di sekitar pusat bentuk. Untuk bentuk yang dikelompokkan, juga perhitungkan pemetaan koordinat grup dan transformasinya; jangan mengasumsikan bahwa titik yang diekstrak adalah koordinat slide yang akhir atau menerapkan translasi atau skala dua kali jika sudah tercermin dalam kerangka anak.

**Pemeriksaan vs penyuntingan.** Array yang diekstrak menggambarkan kontur; mengubahnya tidak memperbarui bentuk asli. Pilih pendekatan ini ketika analisis atau kode gambar Anda memerlukan array titik/tipe. Gunakan [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) ketika Anda membutuhkan perintah geometri dalam sistem koordinat lokal bentuk atau ingin menyunting geometri tersebut. Terapkan jalur yang diedit melalui [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) atau [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Mengkonversi GeometryPath ke GraphicsPath (System.Drawing.Drawing2D)**

Contoh berikut memerlukan assembly Aspose.Slides for .NET lama yang mendukung [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), misalnya versi 25.10, serta lingkungan Windows dengan `System.Drawing.Common`. Metode konversi dihapus pada [versi 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Contoh ini menggabungkan kontur persegi panjang dengan teks yang dikonversi menjadi geometri. [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) pada kontur diatur untuk menonaktifkan isinya. Sebuah [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) menyimpan kontur teks, yang [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) konversi menjadi jalur geometri terisi. Menerapkan kedua jalur dengan [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) menghasilkan satu bentuk yang berisi persegi panjang dan teks. Untuk konversi ke arah sebaliknya, gunakan [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang terjadi pada isi dan kontur setelah mengganti geometri?**

Gaya tetap berada pada bentuk; hanya kontur yang berubah. Isi dan kontur secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom bersama geometri secara tepat?**

Gunakan properti [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Bisakah saya mengkonversi bentuk kustom menjadi gambar untuk "mengunci" hasilnya?**

Ya. Ekspor area [slide](/slides/id/net/convert-powerpoint-to-png/) yang diperlukan atau [shape](/slides/id/net/create-shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan pekerjaan selanjutnya dengan geometri yang kompleks.