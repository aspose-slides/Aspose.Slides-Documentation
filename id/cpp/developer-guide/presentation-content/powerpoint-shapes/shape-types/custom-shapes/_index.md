---
title: Sesuaikan Bentuk Presentasi di C++
linktitle: Bentuk Kustom
type: docs
weight: 20
url: /id/cpp/custom-shape/
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
- C++
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk C++: jalur geometri, sudut melengkung, bentuk komposit."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik edit dan jalur geometris. Artikel ini memperlihatkan cara bekerja dengan `GeometryPath` dan `IGeometryPath` untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

## **Ubah Bentuk Menggunakan Titik Edit**

Pertimbangkan sebuah persegi. Di PowerPoint, menggunakan **titik edit**, Anda dapat

* memindahkan sudut persegi ke dalam atau ke luar
* menentukan kelengkungan untuk sebuah sudut atau titik
* menambahkan titik baru ke persegi
* memanipulasi titik pada persegi, dll.

Intinya, Anda dapat melakukan tugas yang dijelaskan pada bentuk apa pun. Dengan titik edit, Anda dapat mengubah bentuk atau membuat bentuk baru dari bentuk yang ada. 

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Sebelum Anda mulai mengedit bentuk PowerPoint melalui titik edit, Anda mungkin ingin mempertimbangkan poin-poin berikut tentang bentuk:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Ketika sebuah bentuk tertutup, ia tidak memiliki titik awal atau akhir. Ketika sebuah bentuk terbuka, ia memiliki awal dan akhir. 
* Semua bentuk terdiri dari setidaknya 2 titik jangkar yang terhubung satu sama lain oleh garis
* Sebuah garis dapat lurus atau melengkung. Titik jangkar menentukan sifat garis. 
* Titik jangkar ada sebagai titik sudut, titik lurus, atau titik halus:
  * Titik sudut adalah titik di mana 2 garis lurus bertemu pada sebuah sudut. 
  * Titik halus adalah titik di mana 2 pegangan berada pada satu garis lurus dan segmen garis bergabung dalam kurva halus. Dalam hal ini, semua pegangan dipisahkan dari titik jangkar dengan jarak yang sama. 
  * Titik lurus adalah titik di mana 2 pegangan berada pada satu garis lurus dan segmen garis tersebut bergabung dalam kurva halus. Dalam hal ini, pegangan tidak harus dipisahkan dari titik jangkar dengan jarak yang sama. 
* Dengan memindahkan atau menyunting titik jangkar (yang mengubah sudut garis), Anda dapat mengubah tampilan sebuah bentuk. 

Untuk mengedit bentuk PowerPoint melalui titik edit, **Aspose.Slides** menyediakan kelas [**GeometryPath**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path) dan antarmuka [**IGeometryPath**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_path).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path) mewakili jalur geometri dari objek [IGeometryShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_shape).
* Untuk mengambil `GeometryPath` dari instance `IGeometryShape`, Anda dapat menggunakan metode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_shape#a91c25d805702d632c17db86ca3b279c1).
* Untuk mengatur `GeometryPath` untuk sebuah bentuk, Anda dapat menggunakan metode ini: [IGeometryShape::SetGeometryPath()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_shape#a350a80e5544519f5f840318f13ad7986) untuk *bentuk solid* dan [IGeometryShape::SetGeometryPaths()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_shape#a4b3837a4e393693b3ceaa0928181b750) untuk *bentuk komposit*.
* Untuk menambahkan segmen, Anda dapat menggunakan metode di bawah [IGeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_path). 
* Dengan menggunakan metode [IGeometryPath::set_Stroke()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_path#aa819370fbd22ef49387672b8fe2ed147) dan [IGeometryPath::set_FillMode()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_path#adf7a4e1a1a28b52a97bff0d5cad6f3d7), Anda dapat mengatur tampilan untuk jalur geometri.
* Dengan menggunakan metode [IGeometryPath::get_PathData()](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_geometry_path#a9b1e40e8db9d4dd95fa4784e95d73fca), Anda dapat mengambil jalur geometri dari `GeometryShape` sebagai array segmen jalur. 
* Untuk mengakses opsi kustomisasi geometri bentuk tambahan, Anda dapat mengonversi [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path) menjadi [GraphicsPath](https://reference.aspose.com/slides/id/cpp/class/system.drawing.drawing2_d.graphics_path)
* Gunakan metode [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) dan [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.util.shape_util#ab319f6b9578de90a4863c883690f7daf) (dari kelas [ShapeUtil](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.util.shape_util)) untuk mengonversi [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path) ke [GraphicsPath](https://reference.aspose.com/slides/id/cpp/class/system.drawing.drawing2_d.graphics_path) bolak-balik. 

## **Operasi Penyuntingan Sederhana**

Kode C++ ini menunjukkan cara Anda

**Tambahkan garis** ke akhir jalur

``` cpp
void LineTo(PointF point);
void LineTo(float x, float y);
```
**Tambahkan garis** ke posisi yang ditentukan pada jalur:

``` cpp    
void LineTo(PointF point, uint32_t index);
void LineTo(float x, float y, uint32_t index);
```
**Tambahkan kurva Bezier kubik** ke akhir jalur:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3);
```
**Tambahkan kurva Bezier kubik** ke posisi yang ditentukan pada jalur:

``` cpp
void CubicBezierTo(PointF point1, PointF point2, PointF point3, uint32_t index);
void CubicBezierTo(float x1, float y1, float x2, float y2, float x3, float y3, uint32_t index);
```
**Tambahkan kurva Bezier kuadratik** ke akhir jalur:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2);
void QuadraticBezierTo(float x1, float y1, float x2, float y2);
```
**Tambahkan kurva Bezier kuadratik** ke posisi yang ditentukan pada jalur:

``` cpp
void QuadraticBezierTo(PointF point1, PointF point2, uint32_t index);
void QuadraticBezierTo(float x1, float y1, float x2, float y2, uint32_t index);
```
**Tambahkan lengkungan tertentu** ke jalur:

``` cpp
void ArcTo(float width, float heigth, float startAngle, float sweepAngle);
```
**Tutup gambar saat ini** dari jalur:

``` cpp
void CloseFigure();
```
**Atur posisi untuk titik berikutnya**:

``` cpp
void MoveTo(PointF point);
void MoveTo(float x, float y);
```
**Hapus segmen jalur** pada indeks tertentu:

``` cpp
void RemoveAt(int32_t index);
```
## **Tambahkan Titik Kustom ke Bentuk**

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_shape) dan atur tipe [ShapeType.Rectangle](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5).
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path) dari bentuk.
3. Tambahkan titik baru di antara dua titik atas pada jalur.
4. Tambahkan titik baru di antara dua titik bawah pada jalur.
5. Terapkan jalur ke bentuk.

Kode C++ ini menunjukkan cara menambahkan titik kustom ke sebuah bentuk:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath = shape->GetGeometryPaths()->idx_get(0);

geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);
shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Hapus Titik dari Bentuk**

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_shape) dan atur tipe [ShapeType.Heart](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides#abe1c0baea327186bde49ad44636bb8c5). 
2. Dapatkan instance kelas [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path) dari bentuk.
3. Hapus segmen untuk jalur.
4. Terapkan jalur ke bentuk.

Kode C++ ini menunjukkan cara menghapus titik dari sebuah bentuk:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f));

SharedPtr<IGeometryPath> path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);
shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Buat Bentuk Kustom**

1. Hitung titik-titik untuk bentuk.
2. Buat instance kelas [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path). 
3. Isi jalur dengan titik-titik.
4. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_shape). 
5. Terapkan jalur ke bentuk.

Kode C++ ini menunjukkan cara membuat bentuk kustom:

``` cpp
SharedPtr<List<PointF>> points = System::MakeObject<List<PointF>>();

float R = 100.0f, r = 50.0f;
int32_t step = 72;

for (int32_t angle = -90; angle < 270; angle += step)
{
    double radians = angle * (Math::PI / 180.f);
    double x = outerRadius * Math::Cos(radians);
    double y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + step / 2) / 180.0;
    x = innerRadiusr * Math::Cos(radians);
    y = innerRadiusr * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

SharedPtr<GeometryPath> starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (int32_t i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, R * 2, R * 2));

shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)


## **Buat Bentuk Kustom Komposit**

  1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_shape).
  2. Buat instance pertama kelas [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path).
  3. Buat instance kedua kelas [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path).
  4. Terapkan jalur ke bentuk.

Kode C++ ini menunjukkan cara membuat bentuk kustom komposit:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f));

SharedPtr<IGeometryPath> geometryPath0 = System::MakeObject<GeometryPath>();
geometryPath0->MoveTo(0.0f, 0.0f);
geometryPath0->LineTo(shape->get_Width(), 0.0f);
geometryPath0->LineTo(shape->get_Width(), shape->get_Height() / 3);
geometryPath0->LineTo(0.0f, shape->get_Height() / 3);
geometryPath0->CloseFigure();

SharedPtr<IGeometryPath> geometryPath1 = System::MakeObject<GeometryPath>();
geometryPath1->MoveTo(0.0f, shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
geometryPath1->LineTo(shape->get_Width(), shape->get_Height());
geometryPath1->LineTo(0.0f, shape->get_Height());
geometryPath1->CloseFigure();

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ geometryPath0, geometryPath1 }));
```
![example4_image](custom_shape_4.png)

## **Buat Bentuk Kustom dengan Sudut Melengkung**

Kode C++ ini menunjukkan cara membuat bentuk kustom dengan sudut melengkung (ke dalam);

```cpp
float shapeX = 20.f;
float shapeY = 20.f;
float shapeWidth = 300.f;
float shapeHeight = 200.f;

float leftTopSize = 50.f;
float rightTopSize = 20.f;
float rightBottomSize = 40.f;
float leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();

auto childShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto geometryPath = System::MakeObject<GeometryPath>();

PointF point1(leftTopSize, 0.0f);
PointF point2(shapeWidth - rightTopSize, 0.0f);
PointF point3(shapeWidth, shapeHeight - rightBottomSize);
PointF point4(leftBottomSize, shapeHeight);
PointF point5(0.0f, leftTopSize);

geometryPath->MoveTo(point1);
geometryPath->LineTo(point2);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(point3);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(point4);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(point5);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);

geometryPath->CloseFigure();

childShape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Temukan Apakah Geometri Bentuk Tertutup**

Sebuah bentuk tertutup didefinisikan sebagai bentuk di mana semua sisinya terhubung, membentuk batas tunggal tanpa celah. Bentuk semacam itu dapat berupa bentuk geometris sederhana atau outline kustom yang kompleks. Contoh kode berikut menunjukkan cara memeriksa apakah geometri bentuk tertutup:

```cpp
bool IsGeometryClosed(SharedPtr<IGeometryShape> geometryShape)
{
    bool isClosed = false;

    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto dataLength = geometryPath->get_PathData()->get_Length();
        if (dataLength == 0)
            continue;

        auto lastSegment = geometryPath->get_PathData()[dataLength - 1];
        isClosed = lastSegment->get_PathCommand() == PathCommandType::Close;

        if (!isClosed)
            return false;
    }

    return isClosed;
}
```

## **Konversi GeometryPath ke GraphicsPath** 

1. Buat instance kelas [GeometryShape](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_shape).
2. Buat instance kelas [GraphicsPath](https://reference.aspose.com/slides/id/cpp/class/system.drawing.drawing2_d.graphics_path) dari namespace [System.Drawing.Drawing2D](https://reference.aspose.com/slides/id/cpp/namespace/system.drawing.drawing2_d).
3. Konversi instance [GraphicsPath](https://reference.aspose.com/slides/id/cpp/class/system.drawing.drawing2_d.graphics_path) ke instance [GeometryPath](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.geometry_path) menggunakan [ShapeUtil](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.util.shape_util).
4. Terapkan jalur ke bentuk.

Kode C++—implementasi langkah-langkah di atas—menunjukkan proses konversi **GeometryPath** ke **GraphicsPath**:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

SharedPtr<IShapeCollection> shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
SharedPtr<GeometryShape> shape = System::ExplicitCast<GeometryShape>(shapes->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 100.0f));

SharedPtr<IGeometryPath> originalPath = shape->GetGeometryPaths()->idx_get(0);
originalPath->set_FillMode(PathFillModeType::None);

SharedPtr<Drawing2D::GraphicsPath> graphicsPath = System::MakeObject<Drawing2D::GraphicsPath>();
graphicsPath->AddString(u"Text in shape", System::MakeObject<FontFamily>(u"Arial"), 1, 40.0f, PointF(10.0f, 10.0f), StringFormat::get_GenericDefault());

SharedPtr<IGeometryPath> textPath = ShapeUtil::GraphicsPathToGeometryPath(graphicsPath);
textPath->set_FillMode(PathFillModeType::Normal);

shape->SetGeometryPaths(System::MakeArray<SharedPtr<IGeometryPath>>({ originalPath, textPath }));
```
![example5_image](custom_shape_5.png)

## **FAQ**

**Apa yang akan terjadi pada isi dan garis tepi setelah mengganti geometri?**

Gaya tetap melekat pada bentuk; hanya kontur yang berubah. Isi dan garis tepi secara otomatis diterapkan pada geometri baru.

**Bagaimana cara memutar bentuk kustom dengan benar bersama geometri nya?**

Gunakan properti [rotation](https://reference.aspose.com/slides/id/cpp/aspose.slides/shape/set_rotation/) pada bentuk; geometri akan berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Apakah saya dapat mengonversi bentuk kustom menjadi gambar untuk “mengunci” hasilnya?**

Ya. Ekspor area [slide](/slides/id/cpp/convert-powerpoint-to-png/) yang diperlukan atau [bentuk](/slides/id/cpp/create-shape-thumbnails/) itu sendiri ke format raster; ini mempermudah pekerjaan selanjutnya dengan geometri yang kompleks.