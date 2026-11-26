---
title: Sesuaikan Bentuk Presentasi dalam C++
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
- titik penyuntingan
- tambahkan titik
- hapus titik
- operasi penyuntingan
- sudut melengkung
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Buat dan sesuaikan bentuk dalam presentasi PowerPoint dengan Aspose.Slides untuk C++: jalur geometri, sudut melengkung, bentuk gabungan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara menyesuaikan bentuk presentasi di Aspose.Slides dengan mengedit geometri bentuk melalui titik penyuntingan dan jalur geometri. Artikel ini menunjukkan cara bekerja dengan [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dan [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/) untuk memodifikasi bentuk yang ada, melakukan operasi penyuntingan jalur dasar, menambah atau menghapus titik, dan menerapkan geometri yang diperbarui kembali ke sebuah bentuk.

Artikel ini juga mendemonstrasikan cara membuat bentuk khusus dan gabungan, membangun bentuk dengan sudut melengkung, serta menentukan apakah geometri sebuah bentuk tertutup.

## **Ubah Bentuk Menggunakan Titik Penyuntingan**

Di PowerPoint, Anda dapat menggunakan **Edit Points** untuk memodifikasi sebuah persegi:

* Pindahkan sudut ke dalam atau ke luar.
* Sesuaikan kelengkungan pada sebuah titik.
* Tambahkan titik baru.

Mengedit titik memungkinkan Anda memodifikasi outline sebuah bentuk atau menggunakan bentuk yang ada sebagai dasar untuk bentuk baru.

## **Tips Penyuntingan Bentuk**

![overview_image](custom_shape_0.png)

Saat menyunting bentuk PowerPoint, ingatlah konsep-konsep berikut:

* Sebuah bentuk (atau jalurnya) dapat berupa tertutup atau terbuka.
* Jalur sebuah bentuk terdiri dari titik jangkar yang dihubungkan oleh segmen.
* Sebuah segmen dapat lurus atau melengkung. Titik jangkar dan pegangan kontrol menentukan bentuknya.
* Titik jangkar dapat berupa titik sudut, titik lurus, atau titik halus:
  * Pada titik sudut, segmen yang bersebelahan dapat bertemu dengan sudut.
  * Pada titik halus, dua pegangan kontrol berada dalam satu garis dan berjarak sama dari titik jangkar.
  * Pada titik lurus, dua pegangan kontrol berada dalam satu garis tetapi dapat memiliki jarak yang berbeda dari titik jangkar.
* Memindahkan titik jangkar atau menyesuaikan pegangan mereka mengubah outline bentuk.

Untuk menyunting bentuk PowerPoint melalui titik penyuntingan, **Aspose.Slides** menyediakan kelas [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dan antarmuka [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).

* Sebuah instance [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) merepresentasikan jalur geometri dari objek [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/).
* Untuk mengambil [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) dari instance [IGeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/), Anda dapat menggunakan metode [IGeometryShape::GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/).
* Untuk menetapkan [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) pada sebuah bentuk, Anda dapat menggunakan metode berikut: [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) untuk bentuk dengan satu jalur dan [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) untuk bentuk dengan banyak jalur.
* Untuk menambah segmen, Anda dapat menggunakan metode di bawah [IGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/).
* Dengan menggunakan metode [IGeometryPath::set_Stroke](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_stroke/) dan [IGeometryPath::set_FillMode](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/set_fillmode/), Anda dapat mengatur tampilan untuk sebuah jalur geometri.
* Dengan menggunakan metode [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/), Anda dapat mengambil jalur geometri dari sebuah [GeometryShape](https://reference.aspose.com/slides/cpp/aspose.slides/geometryshape/) sebagai array segmen jalur.

## **Operasi Penyuntingan Sederhana**

Gunakan metode berikut untuk menyunting sebuah jalur geometri. Overload yang menerima indeks menyisipkan segmen pada posisi berbasis nol dalam array segmen jalur.

| Operasi | Metode |
| --- | --- |
| Menambahkan atau menyisipkan garis lurus. | [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) |
| Menambahkan atau menyisipkan kurva Bézier kubik dengan dua titik kontrol dan satu titik akhir. | [GeometryPath::CubicBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/cubicbezierto/) |
| Menambahkan atau menyisipkan kurva Bézier kuadratik dengan satu titik kontrol dan satu titik akhir. | [GeometryPath::QuadraticBezierTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/quadraticbezierto/) |
| Menambahkan busur elips dengan dimensi dan sudut yang ditentukan dalam derajat. | [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) |
| Menutup gambar saat ini dengan menghubungkan titik akhir ke titik awalnya. | [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) |
| Menetapkan titik awal sebuah gambar. | [GeometryPath::MoveTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/moveto/) |
| Menghapus segmen pada indeks berbasis nol. | [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/) |

## **Tambahkan Titik Kustom ke Bentuk**

Contoh ini menyisipkan dua titik ke dalam bentuk persegi panjang menggunakan [GeometryPath::LineTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/lineto/) dan menerapkan jalur yang disunting dengan [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/). Koordinat tersebut bersifat lokal terhadap bentuk: kedua titik baru berada di tengahnya, 100 poin dari kiri dan 50 poin dari atas. Indeks segmen 1 dan 4 menempatkannya pada tepi atas dan bawah, menarik tepi tersebut ke dalam.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto geometryPath = shape->GetGeometryPaths()->idx_get(0);
geometryPath->LineTo(100.0f, 50.0f, 1);
geometryPath->LineTo(100.0f, 50.0f, 4);

shape->SetGeometryPath(geometryPath);
```

![example1_image](custom_shape_1.png)

## **Hapus Titik dari Bentuk**

Contoh ini mengubah outline berbentuk hati dengan menghapus segmen pada indeks berbasis nol 2 menggunakan [GeometryPath::RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/removeat/). Menerapkan jalur yang dimodifikasi dengan [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) memperbarui kontur bentuk.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Heart, 100.0f, 100.0f, 300.0f, 300.0f);

auto path = shape->GetGeometryPaths()->idx_get(0);
path->RemoveAt(2);

shape->SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Buat Bentuk Kustom**

Contoh ini membangun bintang lima titik menggunakan [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/). Radius luar dan dalam yang bergantian sebesar 100 dan 50 poin menentukan ujung dan lekukan; langkah 72 derajat menempatkan lima ujung secara merata. Jalur ditutup dengan [GeometryPath::CloseFigure](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/closefigure/) dan diterapkan ke bentuk persegi panjang menggunakan [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), menggantikan outline‑nya.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <drawing/point_f.h>
#include <system/collections/list.h>
#include <system/math.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::Drawing;

auto points = System::MakeObject<List<PointF>>();

auto outerRadius = 100.0f;
auto innerRadius = 50.0f;
auto angleStep = 72;

for (auto angle = -90; angle < 270; angle += angleStep)
{
    auto radians = angle * (Math::PI / 180.f);
    auto x = outerRadius * Math::Cos(radians);
    auto y = outerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math::PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math::Cos(radians);
    y = innerRadius * Math::Sin(radians);
    points->Add(PointF((float)x + outerRadius, (float)y + outerRadius));
}

auto starPath = System::MakeObject<GeometryPath>();
starPath->MoveTo(points->idx_get(0));

for (auto i = 1; i < points->get_Count(); i++)
{
    starPath->LineTo(points->idx_get(i));
}

starPath->CloseFigure();

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, outerRadius * 2, outerRadius * 2);
shape->SetGeometryPath(starPath);
```
![example3_image](custom_shape_3.png)

## **Buat Bentuk Kustom Gabungan**

Contoh ini mendefinisikan dua objek [GeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/) tertutup untuk sepertiga atas dan bawah sebuah bentuk. Menerapkan kedua jalur dengan [IGeometryShape::SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/) menciptakan satu bentuk gabungan dengan celah di sepertiga tengahnya.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 200.0f, 100.0f);

auto topPath = System::MakeObject<GeometryPath>();
topPath->MoveTo(0.0f, 0.0f);
topPath->LineTo(shape->get_Width(), 0.0f);
topPath->LineTo(shape->get_Width(), shape->get_Height() / 3);
topPath->LineTo(0.0f, shape->get_Height() / 3);
topPath->CloseFigure();

auto bottomPath = System::MakeObject<GeometryPath>();
bottomPath->MoveTo(shape->get_Height() / 3 * 2, 0.0f);
bottomPath->LineTo(shape->get_Width(), shape->get_Height() / 3 * 2);
bottomPath->LineTo(shape->get_Width(), shape->get_Height());
bottomPath->LineTo(0.0f, shape->get_Height());
bottomPath->CloseFigure();

auto paths = System::MakeArray<SharedPtr<IGeometryPath>>({ topPath, bottomPath });

shape->SetGeometryPaths(paths);
```
![example4_image](custom_shape_4.png)

## **Buat Bentuk Kustom dengan Sudut Melengkung**

Contoh ini menggabungkan segmen lurus dengan [GeometryPath::ArcTo](https://reference.aspose.com/slides/cpp/aspose.slides/geometrypath/arcto/) untuk membuat sebuah bentuk dengan sudut melengkung ke dalam. Setiap ukuran sudut menentukan lebar dan tinggi busur dalam poin, dan sapuan -90 derajat menggambar seperempat elips berlawanan arah jarum jam. Jalur yang selesai diterapkan dengan [IGeometryShape::SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/), dan presentasi disimpan dalam format PPTX.

```cpp
#include <DOM/GeometryPath.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto shapeX = 20.f;
auto shapeY = 20.f;
auto shapeWidth = 300.f;
auto shapeHeight = 200.f;

auto leftTopSize = 50.f;
auto rightTopSize = 20.f;
auto rightBottomSize = 40.f;
auto leftBottomSize = 10.f;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Custom, shapeX, shapeY, shapeWidth, shapeHeight);

auto topLeft = PointF(leftTopSize, 0.0f);
auto topRight = PointF(shapeWidth - rightTopSize, 0.0f);
auto rightBottom = PointF(shapeWidth, shapeHeight - rightBottomSize);
auto bottomLeft = PointF(leftBottomSize, shapeHeight);
auto leftTop = PointF(0.0f, leftTopSize);

auto geometryPath = System::MakeObject<GeometryPath>();
geometryPath->MoveTo(topLeft);
geometryPath->LineTo(topRight);
geometryPath->ArcTo(rightTopSize, rightTopSize, 180.0f, -90.0f);
geometryPath->LineTo(rightBottom);
geometryPath->ArcTo(rightBottomSize, rightBottomSize, -90.0f, -90.0f);
geometryPath->LineTo(bottomLeft);
geometryPath->ArcTo(leftBottomSize, leftBottomSize, 0.0f, -90.0f);
geometryPath->LineTo(leftTop);
geometryPath->ArcTo(leftTopSize, leftTopSize, 90.0f, -90.0f);
geometryPath->CloseFigure();

shape->SetGeometryPath(geometryPath);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Cari Tahu Apakah Geometri Bentuk Tertutup**

Penolong berikut memeriksa apakah setiap jalur geometri yang tidak kosong berakhir dengan segmen penutup. Ia membaca [IGeometryPath::get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) dan membandingkan perintah [IPathSegment::get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) akhir dengan [PathCommandType::Close](https://reference.aspose.com/slides/cpp/aspose.slides/pathcommandtype/). Ia mengembalikan false ketika tidak ada jalur yang tidak kosong. Pemeriksaan ini memeriksa perintah akhir tiap jalur; tidak memeriksa setiap subgambar di dalam jalur. Contoh ini mencetak `True` untuk sebuah persegi panjang.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IPathSegment.h>
#include <DOM/PathCommandType.h>

using namespace Aspose::Slides;
using namespace System;

auto isGeometryClosed = [](SharedPtr<IGeometryShape> geometryShape)
{
    auto hasNonemptyPath = false;
    for (auto&& geometryPath : geometryShape->GetGeometryPaths())
    {
        auto segments = geometryPath->get_PathData();
        if (segments->get_Length() == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        auto lastSegment = segments->idx_get(segments->get_Length() - 1);
        if (lastSegment->get_PathCommand() != PathCommandType::Close)
        {
            return false;
        }
    }
    return hasNonemptyPath;
};

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 200, 100);
Console::WriteLine(isGeometryClosed(shape));
```

## **Inspeksi Perintah Jalur Geometri**

Unduh [contour.pptx](contour.pptx) dan letakkan di direktori kerja aplikasi. Bentuk pertama pada slide pertama memiliki tepi atas lurus, sebuah kurva Bézier kubik, dan tepi penutup lurus. Gunakan [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) untuk membaca jalurnya. Untuk setiap jalur, [get_PathData](https://reference.aspose.com/slides/cpp/aspose.slides/igeometrypath/get_pathdata/) mengembalikan segmen dalam urutan gambar. Perintah yang dikembalikan oleh [get_PathCommand](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_pathcommand/) menentukan cara menafsirkan nilai yang dikembalikan oleh [get_SegmentData](https://reference.aspose.com/slides/cpp/aspose.slides/ipathsegment/get_segmentdata/).

```cpp
#include <DOM/IGeometryPath.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IPathSegment.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/PathCommandType.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enum.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"contour.pptx");

auto shape = ExplicitCast<IGeometryShape>(presentation->get_Slide(0)->get_Shape(0));
auto paths = shape->GetGeometryPaths();

for (auto i = 0; i < paths->get_Length(); ++i)
{
    auto segments = paths->idx_get(i)->get_PathData();
    for (auto j = 0; j < segments->get_Length(); ++j)
    {
        auto segment = segments->idx_get(j);
        auto command = segment->get_PathCommand();
        auto data = segment->get_SegmentData();
        String detail;
        switch (command)
        {
            case PathCommandType::MoveTo:
            case PathCommandType::LineTo:
                detail = String::Format(u"destination=({0}, {1})", data->idx_get(0), data->idx_get(1));
                break;
            case PathCommandType::CubicBezierTo:
                detail = String::Format(u"control1=({0}, {1}) control2=({2}, {3}) end=({4}, {5})", data);
                break;
            case PathCommandType::Close:
                detail = u"no coordinates";
                break;
            default:
            {
                auto values = MakeArray<String>(data->get_Length());
                for (auto k = 0; k < data->get_Length(); ++k)
                {
                    values->idx_set(k, String::Format(u"{0}", data->idx_get(k)));
                }
                detail = String::Format(u"raw=[{0}]", String::Join(u", ", values));
                break;
            }
        }
        Console::WriteLine(u"Path {0}, segment {1}: {2} {3}", i, j, Enum<PathCommandType>::GetName(command), detail);
    }
}
```

Bentuk berada pada (200, 100) poin di slide. Titik yang dilaporkan bersifat lokal terhadap bentuk, dengan (0, 0) di sudut kiri atasnya, x meningkat ke kanan, dan y meningkat ke bawah. Segmen penutup kembali ke titik awal tanpa koordinat tambahan.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```
![Bentuk PowerPoint dengan tepi atas lurus, tepi melengkung dari kanan atas ke kiri bawah, dan tepi kiri lurus](contour.png)

## **Ekstrak dan Inspeksi Elemen Bentuk**

Gunakan [IGeometryShape::CreateShapeElements](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/createshapeelements/) untuk menginspeksi sebuah bentuk yang ada sebagai elemen yang berisi titik jalur dan tipe titik. Cast setiap [IShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/ishapeelement/) yang dikembalikan ke [ShapeElement](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/) untuk membaca array yang dikembalikan oleh [get_PathPoints](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathpoints/) dan [get_PathTypes](https://reference.aspose.com/slides/cpp/aspose.slides/shapeelement/get_pathtypes/). Representasi ini berguna untuk analisis kontur atau mengirim geometri ke alat menggambar kustom.

Contoh membuka sebuah presentasi, menemukan bentuk geometri pertama langsung pada slide pertama, dan mencetak segmen jalurnya. Gunakan presentasi yang berisi bentuk dengan segmen lurus dan melengkung untuk melihat kedua jenis output. Tidak mencari di dalam grup.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IGeometryShape.h>
#include <DOM/IGeometryPath.h>
#include <DOM/ShapeType.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include <system/console.h>
#include <DOM/IShapeElement.h>
#include <DOM/ShapeElement.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);

SharedPtr<IGeometryShape> shape;
for (auto&& candidate : slide->get_Shapes())
{
    shape = AsCast<IGeometryShape>(candidate);
    if (shape != nullptr)
    {
        break;
    }
}
if (shape == nullptr)
{
    Console::WriteLine(u"No geometry shape found on the first slide.");
    return;
}

for (auto&& element : shape->CreateShapeElements())
{
    auto shapeElement = ExplicitCast<ShapeElement>(element);
    auto points = shapeElement->get_PathPoints();
    auto types = shapeElement->get_PathTypes();
    Console::WriteLine(u"Shape element:");

    for (auto i = 0; i < points->get_Length(); i++)
    {
        auto pointType = types[i] & 0x07; // Pertahankan tipe segmen, kecuali flag.
        switch (pointType)
        {
            case 0:
                Console::WriteLine(u"Start figure at {0}", points[i]);
                break;
            case 1:
                Console::WriteLine(u"Line to {0}", points[i]);
                break;
            case 3:
                Console::WriteLine(u"Cubic Bezier: controls {0}, {1}; end {2}", points[i], points[i + 1], points[i + 2]);
                i += 2; // Consume both control points and the endpoint.
                break;
        }
        if ((types[i] & 0x80) != 0)
        {
            Console::WriteLine(u"Close subpath back to its starting point.");
        }
    }
}
```

Array berkorespondensi berdasarkan indeks: `points[i]` adalah titik dan `types[i]` menjelaskan perannya. Tipe `0` memulai sebuah gambar, dan tipe `1` menggambar garis dari titik sebelumnya ke titik saat ini. Segmen Bézier kubik dimulai pada titik akhir sebelumnya dan menggunakan tiga entri tipe-`3` berurutan: dua titik kontrol diikuti titik akhir baru. Loop mengonsumsi tiga entri ini bersama‑sama dan memeriksa titik akhir untuk penutupan.

Jenis titik juga berisi flag. Mask dengan `0x07` untuk mengidentifikasi tipe segmen, dan uji `0x80` secara terpisah untuk mendeteksi subjalur tertutup. Misalnya, `129` (`0x81`) berarti titik akhir garis yang menutup subjalur, dan `131` (`0x83`) berarti titik akhir Bézier yang menutup satu. Membandingkan nilai mentah hanya dengan `1` atau `3` akan melewatkan kasus ini. Flag lain, seperti dash (`0x10`) dan marker (`0x20`), tidak mengubah tipe dasar segmen.

**Koordinat dan transformasi.** Titik diukur dalam poin (1/72 inci), dengan X meningkat ke kanan dan Y meningkat ke bawah. Untuk bentuk yang tidak tergabung, koordinat yang diekstrak sudah mencakup posisi yang dikembalikan oleh [get_X](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_x/) dan [get_Y](https://reference.aspose.com/slides/cpp/aspose.slides/shape/get_y/) serta mencerminkan lebar dan tinggi saat ini. Misalnya, sebuah persegi panjang yang tidak diputar pada `(100, 200)` dengan ukuran `120 × 80` memiliki batas kontur `(100, 200)`–`(220, 280)`. Jangan menambahkan posisi bentuk lagi. Kurangi X dan Y untuk mendapatkan koordinat relatif terhadap kerangka yang tidak diputar.

Titik yang diekstrak tidak menerapkan rotasi yang diatur melalui [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) atau pembalikan horizontal dan vertikal. Untuk mereproduksi kontur yang ditampilkan, terapkan transformasi tersebut di sekitar pusat bentuk. Untuk bentuk yang tergabung, juga perhitungkan pemetaan koordinat grup dan transformasinya; jangan mengasumsikan bahwa titik yang diekstrak adalah koordinat slide yang akhirnya dirender atau menerapkan translasi atau skala dua kali jika sudah tercermin dalam kerangka anak.

**Inspeksi vs penyuntingan.** Array yang diekstrak menggambarkan kontur; mengubahnya tidak memperbarui bentuk asli. Pilih pendekatan ini ketika analisis atau kode menggambar Anda membutuhkan array titik/tipe. Gunakan [GetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/getgeometrypaths/) ketika Anda memerlukan perintah geometri dalam sistem koordinat lokal bentuk atau ingin menyunting geometri tersebut. Terapkan jalur yang disunting melalui [SetGeometryPath](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypath/) atau [SetGeometryPaths](https://reference.aspose.com/slides/cpp/aspose.slides/igeometryshape/setgeometrypaths/).

## **Konversi GeometryPath ke GraphicsPath**

API publik Aspose.Slides untuk C++ saat ini tidak menyediakan konversi antara jalur geometri dan jalur grafis. Untuk menginspeksi kontur, gunakan elemen bentuk seperti yang dijelaskan di atas. Untuk menyunting bentuk, gunakan jalur geometri dan terapkan jalur yang diperbarui ke bentuk.

## **FAQ**

**Apa yang terjadi pada isi dan outline setelah mengganti geometri?**

Gaya tetap pada bentuk; hanya kontur yang berubah. Isi dan outline secara otomatis diterapkan ke geometri baru.

**Bagaimana cara memutar bentuk kustom secara tepat bersama geometri nya?**

Gunakan metode [set_Rotation](https://reference.aspose.com/slides/cpp/aspose.slides/shape/set_rotation/) pada bentuk; geometri berputar bersama bentuk karena terikat pada sistem koordinat bentuk itu sendiri.

**Bisakah saya mengonversi bentuk kustom menjadi gambar untuk "mengunci" hasilnya?**

Ya. Ekspor area [slide](/slides/id/cpp/convert-powerpoint-to-png/) yang diperlukan atau [bentuk](/slides/id/cpp/shape-thumbnails/) itu sendiri ke format raster; ini menyederhanakan penanganan lebih lanjut dengan geometri kompleks.