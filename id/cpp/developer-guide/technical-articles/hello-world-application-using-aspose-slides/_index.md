---
title: Aplikasi Hello World menggunakan Aspose.Slides untuk C++
type: docs
weight: 80
url: /id/cpp/hello-world-application-using-aspose-slides/
keywords:
- halo dunia
- aplikasi
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Buat aplikasi C++ pertama Anda dengan Aspose.Slides, contoh Hello World sederhana yang mempersiapkan Anda untuk mengotomatisasi presentasi PPT, PPTX, dan ODP."
---
## **Ikhtisar**

Artikel ini menunjukkan cara membuat presentasi PowerPoint **Hello World** sederhana menggunakan Aspose.Slides. Contoh ini mendemonstrasikan cara membuat presentasi baru, mengakses slide pertama, menambahkan AutoShape persegi panjang pada posisi tertentu, menyisipkan bingkai teks yang berisi teks **Hello World**, dan menyesuaikan format bentuk serta teks.

Juga dijelaskan cara membuat teks terlihat dengan mengubah warnanya menjadi hitam, menyembunyikan batas bentuk dengan mengatur warna garis menjadi putih, menghapus isian bentuk, dan menyimpan presentasi sebagai file PPTX.

## **Langkah-langkah untuk Membuat Aplikasi Hello World**

Ikuti langkah-langkah di bawah ini untuk membuat aplikasi **Hello World** menggunakan Aspose.Slides untuk API C++:

- Buat instance kelas Presentation
- Dapatkan referensi slide pertama dalam presentasi yang dibuat saat instansiasi Presentation.
- Tambahkan AutoShape dengan ShapeType Rectangle pada posisi tertentu pada slide.
- Tambahkan TextFrame ke AutoShape yang berisi Hello World sebagai teks default
- Ubah Warna Teks menjadi Hitam karena secara default berwarna putih dan tidak terlihat pada slide dengan latar belakang putih
- Ubah Warna Garis bentuk menjadi putih untuk menyembunyikan batas bentuk
- Hapus Format Isi default pada bentuk
- Akhirnya, tulis presentasi ke format file yang diinginkan menggunakan objek Presentation

Implementasi langkah-langkah di atas ditunjukkan di bawah ini dalam contoh.

``` cpp
#include <DOM/Presentation.h>
#include <DOM/SlideCollection.h>
#include <DOM/Slide.h>
#include <DOM/ShapeCollection.h>
#include <DOM/AutoShape.h>
#include <DOM/Paragraph.h>
#include <DOM/ParagraphCollection.h>
#include <DOM/TextFrame.h>
#include <DOM/PortionCollection.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/ColorFormat.h>
#include <DOM/FillFormat.h>
#include <DOM/ShapeStyle.h>
#include <DOM/ShapeType.h>
#include <DOM/FillType.h>

#include <Export/SaveFormat.h>

#include <drawing/color.h>

using namespace Aspose;
using namespace Slides;
using namespace Export;

using namespace System;

int main(int argc, const char argv[])
{
    auto pres = System::MakeObject<Presentation>();

    // dapatkan slide pertama
    auto slide = pres->get_Slides()->idx_get(0);

    // tambahkan AutoShape tipe Persegi panjang
    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

    // tambahkan TextFrame ke Persegi panjang
    shape->AddTextFrame(u"Hello World");

    // ubah warna teks menjadi Hitam (yang secara default berwarna Putih)
    auto portionFillFormat = shape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_FillFormat();
    portionFillFormat->set_FillType(FillType::Solid);
    portionFillFormat->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());

    // ubah warna garis persegi panjang menjadi Putih
    shape->get_ShapeStyle()->get_LineColor()->set_Color(System::Drawing::Color::get_White());

    // hapus semua format isian pada bentuk
    shape->get_FillFormat()->set_FillType(FillType::NoFill);

    // simpan presentasi ke disk
    pres->Save(u"output.pptx", SaveFormat::Pptx);

    return 0;
}
```