---
title: Ubah Ukuran Bentuk pada Slide Presentasi
type: docs
weight: 100
url: /id/cpp/re-sizing-shapes-on-slide/
keywords:
- ubah ukuran bentuk
- ubah ukuran bentuk
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Dengan mudah mengubah ukuran bentuk pada slide PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++ — otomatisasikan penyesuaian tata letak slide dan tingkatkan produktivitas."
---
## **Ikhtisar**

Salah satu pertanyaan paling umum dari pelanggan Aspose.Slides untuk C++ adalah cara mengubah ukuran bentuk sehingga, ketika ukuran slide berubah, data tidak terpotong. Artikel teknis singkat ini menunjukkan cara melakukannya.

## **Ubah Ukuran Bentuk**

Untuk mencegah bentuk menjadi tidak selaras ketika ukuran slide berubah, perbarui posisi dan dimensi setiap bentuk agar sesuai dengan tata letak slide yang baru.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Muat file presentasi.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Dapatkan ukuran slide asli.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ubah ukuran slide tanpa menskalakan bentuk yang ada.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Dapatkan ukuran slide baru.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Ubah ukuran dan posisikan kembali bentuk pada setiap slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skala ukuran bentuk.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala posisi bentuk.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Jika sebuah slide berisi tabel, kode di atas tidak akan berfungsi dengan benar. Dalam hal ini, setiap sel dalam tabel harus diubah ukurannya.
{{% /alert %}} 

Gunakan kode berikut pada sisi Anda untuk mengubah ukuran slide yang berisi tabel. Untuk tabel, mengatur lebar atau tinggi merupakan kasus khusus: Anda harus menyesuaikan tinggi baris dan lebar kolom secara individual untuk mengubah ukuran keseluruhan tabel.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Dapatkan ukuran slide asli.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Ubah ukuran slide tanpa menskalakan bentuk yang ada.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Dapatkan ukuran slide baru.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Skala ukuran bentuk.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala posisi bentuk.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Skala ukuran bentuk.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Skala posisi bentuk.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skala ukuran bentuk.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skala posisi bentuk.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

### Mengapa bentuk menjadi terdistorsi atau terpotong setelah mengubah ukuran slide?

Saat mengubah ukuran slide, bentuk mempertahankan posisi dan ukuran aslinya kecuali skala diubah secara eksplisit. Hal ini dapat menyebabkan konten terpotong atau bentuk menjadi tidak selaras.

### Apakah kode yang disediakan berfungsi untuk semua jenis bentuk?

Contoh dasar berfungsi untuk sebagian besar jenis bentuk (kotak teks, gambar, diagram, dll.). Namun, untuk tabel, Anda harus menangani baris dan kolom secara terpisah, karena tinggi dan lebar tabel ditentukan oleh dimensi sel individu.

### Bagaimana cara mengubah ukuran tabel saat mengubah ukuran slide?

Anda perlu mengulang semua baris dan kolom tabel serta mengubah tinggi dan lebar mereka secara proporsional, seperti yang ditunjukkan pada contoh kode kedua.

### Apakah pengubahan ukuran ini akan berfungsi untuk master slide dan layout slide?

Ya, tetapi Anda juga harus mengulang melalui [Master](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_masters/) dan [Layout slide](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/get_layoutslides/) serta menerapkan logika skala yang sama pada bentuk mereka untuk memastikan konsistensi di seluruh presentasi.

### Bisakah saya mengubah orientasi slide (potret/lanskap) bersamaan dengan mengubah ukuran?

Ya. Anda dapat menggunakan [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/id/cpp/aspose.slides/islidesize/set_orientation/) untuk mengubah orientasi. Pastikan Anda menetapkan logika skala secara tepat untuk mempertahankan tata letak.

### Apakah ada batasan ukuran slide yang dapat saya tetapkan?

Aspose.Slides mendukung ukuran khusus, tetapi ukuran yang sangat besar dapat memengaruhi kinerja atau kompatibilitas dengan beberapa versi PowerPoint.

### Bagaimana saya dapat mencegah bentuk dengan rasio aspek tetap menjadi terdistorsi?

Anda dapat memeriksa metode `get_AspectRatioLocked` pada bentuk sebelum melakukan scaling. Jika terkunci, sesuaikan lebar atau tinggi secara proporsional daripada menskalakan keduanya secara terpisah.