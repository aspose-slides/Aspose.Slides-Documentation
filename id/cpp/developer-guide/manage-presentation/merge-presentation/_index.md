---
title: Menggabungkan Presentasi secara Efisien di C++
linktitle: Menggabungkan Presentasi
type: docs
weight: 40
url: /id/cpp/merge-presentation/
keywords:
- gabungkan PowerPoint
- gabungkan presentasi
- gabungkan slide
- gabungkan PPT
- gabungkan PPTX
- gabungkan ODP
- kombinasi PowerPoint
- kombinasi presentasi
- kombinasi slide
- kombinasi PPT
- kombinasi PPTX
- kombinasi ODP
- C++
- Aspose.Slides
description: "Gabungkan presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) dengan mudah menggunakan Aspose.Slides untuk C++, mempermudah alur kerja Anda."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda menggabungkan presentasi dengan menyalin slide dari satu presentasi ke presentasi lain. Artikel ini menjelaskan cara menggabungkan seluruh presentasi atau slide yang dipilih, menggunakan slide master atau tata letak tertentu selama penggabungan, menangani presentasi dengan ukuran slide yang berbeda, dan menambahkan slide yang digabungkan ke bagian presentasi. Artikel ini juga membahas catatan praktis terkait konten yang digabungkan, termasuk catatan pembicara, komentar, file sumber yang dilindungi kata sandi, dan penggunaan thread.

## **Penggabungan Presentasi**

Saat Anda menggabungkan satu presentasi ke presentasi lain, Anda pada dasarnya menggabungkan slide‑slide mereka menjadi satu presentasi tunggal.

{{% alert title="Info" color="info" %}}
Sebagian besar program presentasi (PowerPoint atau OpenOffice) tidak memiliki fungsi yang memungkinkan pengguna menggabungkan presentasi dengan cara tersebut. 

[**Aspose.Slides untuk C++**](https://products.aspose.com/slides/id/cpp/) memungkinkan Anda menggabungkan presentasi dengan berbagai cara. Anda dapat menggabungkan presentasi beserta semua bentuk, gaya, teks, pemformatan, komentar, animasi, dll. tanpa perlu khawatir kehilangan kualitas atau data. 

**Lihat juga**

[Duplikat Slide](https://docs.aspose.com/slides/id/cpp/clone-slides/)*.* 
{{% /alert %}}

### **Apa yang Dapat Digabungkan**

Dengan Aspose.Slides, Anda dapat menggabungkan  

* seluruh presentasi. Semua slide dari presentasi akan berada dalam satu presentasi  
* slide tertentu. Slide yang dipilih akan berada dalam satu presentasi  
* presentasi dalam satu format (PPT ke PPT, PPTX ke PPTX, dll) dan dalam format yang berbeda (PPT ke PPTX, PPTX ke ODP, dll) satu sama lain.  

{{% alert title="Note" color="warning" %}} 

Selain presentasi, Aspose.Slides memungkinkan Anda menggabungkan berkas lain:  

* [Gambar](https://products.aspose.com/slides/id/cpp/merger/image-to-image/), seperti [JPG ke JPG](https://products.aspose.com/slides/id/cpp/merger/jpg-to-jpg/) atau [PNG ke PNG](https://products.aspose.com/slides/id/cpp/merger/png-to-png/)  
* Dokumen, seperti [PDF ke PDF](https://products.aspose.com/slides/id/cpp/merger/pdf-to-pdf/) atau [HTML ke HTML](https://products.aspose.com/slides/id/cpp/merger/html-to-html/)  
* Dan dua berkas yang berbeda seperti [gambar ke PDF](https://products.aspose.com/slides/id/cpp/merger/image-to-pdf/) atau [JPG ke PDF](https://products.aspose.com/slides/id/cpp/merger/jpg-to-pdf/) atau [TIFF ke PDF](https://products.aspose.com/slides/id/cpp/merger/tiff-to-pdf/). 
{{% /alert %}}

### **Opsi Penggabungan**

Anda dapat menerapkan opsi yang menentukan apakah  

* setiap slide dalam presentasi hasil mempertahankan gaya unik  
* gaya tertentu digunakan untuk semua slide dalam presentasi hasil.  

Untuk menggabungkan presentasi, Aspose.Slides menyediakan metode [AddClone](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (dari antarmuka [ISlideCollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection)). Ada beberapa implementasi metode `AddClone` yang menentukan parameter proses penggabungan presentasi. Setiap objek Presentation memiliki koleksi [Slides](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), sehingga Anda dapat memanggil metode `AddClone` dari presentasi yang ingin Anda tambahkan slide. 

Metode `AddClone` mengembalikan objek `ISlide`, yang merupakan klon dari slide sumber. Slide dalam presentasi hasil hanyalah salinan slide dari sumber. Oleh karena itu, Anda dapat mengubah slide yang dihasilkan (misalnya, menerapkan gaya, opsi pemformatan, atau tata letak) tanpa khawatir presentasi sumber terpengaruh. 

## **Menggabungkan Presentasi** 

Aspose.Slides menyediakan metode [**AddClone (ISlide)**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) yang memungkinkan Anda menggabungkan slide sementara slide tetap mempertahankan tata letak dan gaya mereka (parameter default). 

Berikut ini contoh kode C++ yang menunjukkan cara menggabungkan presentasi:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Menggabungkan Presentasi dengan Slide Master**

Aspose.Slides menyediakan metode [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) yang memungkinkan Anda menggabungkan slide sambil menerapkan templat slide master. Dengan cara ini, bila diperlukan, Anda dapat mengubah gaya slide dalam presentasi hasil. 

Berikut contoh kode C++ yang mendemonstrasikan operasi tersebut:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Tata letak slide untuk slide master ditentukan secara otomatis. Ketika tata letak yang sesuai tidak dapat ditentukan, jika parameter boolean `allowCloneMissingLayout` dari metode `AddClone` diset ke true, tata letak slide sumber akan digunakan. Jika tidak, akan dilemparkan [PptxEditException](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d). 
{{% /alert %}}

Jika Anda ingin slide dalam presentasi hasil memiliki tata letak slide yang berbeda, gunakan metode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) saat menggabungkan. 

## **Menggabungkan Slide Tertentu dari Presentasi** 

Menggabungkan slide tertentu dari banyak presentasi berguna untuk membuat deck slide khusus. Aspose.Slides C++ memungkinkan Anda memilih dan mengimpor hanya slide yang Anda perlukan. API ini mempertahankan pemformatan, tata letak, dan desain slide asli. 

Kode C++ berikut membuat presentasi baru, menambahkan slide judul dari dua presentasi lain, dan menyimpan hasilnya ke berkas:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```
```cpp
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Dideklarasikan di kode di atas.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```

## **Menggabungkan Presentasi dengan Tata Letak Slide** 

Kode C++ ini menunjukkan cara menggabungkan slide dari presentasi sambil menerapkan tata letak slide pilihan Anda sehingga menghasilkan satu presentasi output:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Menggabungkan Presentasi dengan Ukuran Slide Berbeda** 

{{% alert title="Note" color="warning" %}} 
Anda tidak dapat menggabungkan presentasi dengan ukuran slide yang berbeda. 
{{% /alert %}} 

Untuk menggabungkan 2 presentasi dengan ukuran slide berbeda, Anda harus mengubah ukuran salah satu presentasi agar ukurannya cocok dengan presentasi yang lain. 

Contoh kode berikut mendemonstrasikan operasi tersebut:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Menggabungkan Slide ke Bagian Presentasi** 

Kode C++ ini menunjukkan cara menggabungkan slide tertentu ke sebuah bagian dalam presentasi:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Slide ditambahkan di akhir bagian tersebut. 

{{% alert title="Tip" color="info" %}} 
Aspose menyediakan aplikasi web [COLLAGE GRATIS](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan sebagainya. 
{{% /alert %}}

## **FAQ**

### Apakah catatan pembicara dipertahankan selama penggabungan?

Ya. Saat menyalin slide, Aspose.Slides membawa semua elemen slide, termasuk catatan, pemformatan, dan animasi.

### Apakah komentar dan penulisnya dipindahkan?

Komentar, sebagai bagian dari konten slide, disalin bersama slide. Label penulis komentar dipertahankan sebagai objek komentar dalam presentasi hasil.

### Bagaimana jika presentasi sumber dilindungi kata sandi?

Presentasi harus [dibuka dengan kata sandi](/slides/id/cpp/password-protected-presentation/) melalui [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/); setelah dimuat, slide‑slide tersebut dapat disalin dengan aman ke file target yang tidak dilindungi (atau juga ke file yang dilindungi).

### Seberapa aman operasi penggabungan terhadap thread?

Jangan gunakan instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/cpp/multithreading/). Aturan yang disarankan adalah "satu dokumen — satu thread"; berkas yang berbeda dapat diproses secara paralel di thread terpisah.