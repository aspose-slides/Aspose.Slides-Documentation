---
title: Menggabungkan Presentasi secara Efisien di C++
linktitle: Gabungkan Presentasi
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
- menggabungkan PowerPoint
- menggabungkan presentasi
- menggabungkan slide
- menggabungkan PPT
- menggabungkan PPTX
- menggabungkan ODP
- C++
- Aspose.Slides
description: "Dengan mudah menggabungkan presentasi PowerPoint (PPT, PPTX) dan OpenDocument (ODP) menggunakan Aspose.Slides untuk C++, menyederhanakan alur kerja Anda."
---
## **Ikhtisar**

Aspose.Slides memungkinkan Anda menggabungkan presentasi dengan mengkloning slide dari satu presentasi ke presentasi lain. Artikel ini menjelaskan cara menggabungkan seluruh presentasi atau slide yang dipilih, menggunakan slide master atau tata letak tertentu selama penggabungan, menangani presentasi dengan ukuran slide yang berbeda, dan menambahkan slide yang digabung ke dalam bagian presentasi. Artikel ini juga mencakup catatan praktis terkait konten yang digabung, termasuk catatan pembicara, komentar, file sumber yang dilindungi kata sandi, dan penggunaan thread.

## **Penggabungan Presentasi**

Saat Anda menggabungkan satu presentasi ke presentasi lain, Anda secara efektif menggabungkan slide-slide mereka dalam satu presentasi untuk memperoleh satu file.

{{% alert title="Info" color="info" %}}

Sebagian besar program presentasi (PowerPoint atau OpenOffice) tidak memiliki fungsi yang memungkinkan pengguna menggabungkan presentasi dengan cara tersebut. 

[**Aspose.Slides untuk C++**](https://products.aspose.com/slides/id/cpp/) , bagaimanapun, memungkinkan Anda menggabungkan presentasi dengan cara yang berbeda. Anda dapat menggabungkan presentasi dengan semua bentuk, gaya, teks, pemformatan, komentar, animasi, dll tanpa harus khawatir tentang kehilangan kualitas atau data. 

**Lihat juga**

[Clone Slides](https://docs.aspose.com/slides/id/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Apa yang Dapat Digabungkan**

Dengan Aspose.Slides, Anda dapat menggabungkan 

* seluruh presentasi. Semua slide dari presentasi tersebut berakhir dalam satu presentasi
* slide tertentu. Slide yang dipilih berakhir dalam satu presentasi
* presentasi dalam satu format (PPT ke PPT, PPTX ke PPTX, dll) dan dalam format yang berbeda (PPT ke PPTX, PPTX ke ODP, dll) satu sama lain. 

{{% alert title="Note" color="warning" %}} 

Selain presentasi, Aspose.Slides memungkinkan Anda menggabungkan file lain:

* [Gambar](https://products.aspose.com/slides/id/cpp/merger/image-to-image/), seperti [JPG ke JPG](https://products.aspose.com/slides/id/cpp/merger/jpg-to-jpg/) atau [PNG ke PNG](https://products.aspose.com/slides/id/cpp/merger/png-to-png/)
* Dokumen, seperti [PDF ke PDF](https://products.aspose.com/slides/id/cpp/merger/pdf-to-pdf/) atau [HTML ke HTML](https://products.aspose.com/slides/id/cpp/merger/html-to-html/)
* Dan dua file berbeda seperti [gambar ke PDF](https://products.aspose.com/slides/id/cpp/merger/image-to-pdf/) atau [JPG ke PDF](https://products.aspose.com/slides/id/cpp/merger/jpg-to-pdf/) atau [TIFF ke PDF](https://products.aspose.com/slides/id/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Opsi Penggabungan**

Anda dapat menerapkan opsi yang menentukan apakah

* setiap slide dalam presentasi output mempertahankan gaya unik
* gaya tertentu digunakan untuk semua slide dalam presentasi output. 

Untuk menggabungkan presentasi, Aspose.Slides menyediakan metode [AddClone](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (dari antarmuka [ISlideCollection](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection)). Ada beberapa implementasi metode `AddClone` yang menentukan parameter proses penggabungan presentasi. Setiap objek Presentation memiliki koleksi [Slides](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c), sehingga Anda dapat memanggil metode `AddClone` dari presentasi yang ingin Anda gabungkan slide. 

Metode `AddClone` mengembalikan objek `ISlide`, yang merupakan klon dari slide sumber. Slide dalam presentasi output hanyalah salinan slide dari sumber. Oleh karena itu, Anda dapat mengubah slide hasil (misalnya, menerapkan gaya, opsi pemformatan, atau tata letak) tanpa khawatir presentasi sumber terpengaruh. 

## **Gabungkan Presentasi** 

Aspose.Slides menyediakan metode [**AddClone (ISlide)**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) yang memungkinkan Anda menggabungkan slide sementara slide mempertahankan tata letak dan gaya mereka (parameter default). 

Kode C++ ini menunjukkan cara menggabungkan presentasi:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Gabungkan Presentasi dengan Slide Master**

Aspose.Slides menyediakan metode [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) yang memungkinkan Anda menggabungkan slide sambil menerapkan templat slide master. Dengan cara ini, bila diperlukan, Anda dapat mengubah gaya slide dalam presentasi output. 

Kode C++ ini mendemonstrasikan operasi yang dijelaskan:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Tata letak slide untuk slide master ditentukan secara otomatis. Ketika tata letak yang tepat tidak dapat ditentukan, jika parameter boolean `allowCloneMissingLayout` pada metode `AddClone` disetel ke true, tata letak slide sumber yang akan digunakan. Jika tidak, [PptxEditException](https://reference.aspose.com/slides/id/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) akan dilemparkan. 

{{% /alert %}}

Jika Anda menginginkan slide dalam presentasi output memiliki tata letak slide yang berbeda, gunakan metode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) sebagai gantinya saat menggabungkan. 

## **Gabungkan Slide Tertentu dari Presentasi**

Menggabungkan slide tertentu dari beberapa presentasi berguna untuk membuat set slide khusus. Aspose.Slides C++ memungkinkan Anda memilih dan mengimpor hanya slide yang diperlukan. API mempertahankan pemformatan, tata letak, dan desain slide asli.

Kode C++ berikut membuat presentasi baru, menambahkan slide judul dari dua presentasi lain, dan menyimpan hasilnya ke file:

```cpp
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

## **Gabungkan Presentasi dengan Tata Letak Slide**

Kode C++ ini menunjukkan cara menggabungkan slide dari presentasi sambil menerapkan tata letak slide pilihan Anda sehingga menghasilkan satu presentasi output:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Gabungkan Presentasi dengan Ukuran Slide Berbeda**

{{% alert title="Note" color="warning" %}} 

Anda tidak dapat menggabungkan presentasi dengan ukuran slide yang berbeda. 

{{% /alert %}}

Untuk menggabungkan 2 presentasi dengan ukuran slide yang berbeda, Anda harus mengubah ukuran salah satu presentasi sehingga ukurannya cocok dengan presentasi lainnya. 

Contoh kode ini menunjukkan operasi yang dijelaskan:

```cpp
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

## **Gabungkan Slide ke Bagian Presentasi**

Kode C++ ini menunjukkan cara menggabungkan slide tertentu ke sebuah bagian dalam presentasi:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Slide ditambahkan di akhir bagian. 

{{% alert title="Tip" color="primary" %}}

Aspose menyediakan [aplikasi web Collage GRATIS](https://products.aspose.app/slides/id/collage). Dengan layanan online ini, Anda dapat menggabungkan gambar [JPG ke JPG](https://products.aspose.app/slides/id/collage/jpg) atau PNG ke PNG, membuat [grid foto](https://products.aspose.app/slides/id/collage/photo-grid), dan sebagainya. 

{{% /alert %}}

## **FAQ**

**Apakah catatan pembicara dipertahankan selama penggabungan?**

Ya. Saat mengkloning slide, Aspose.Slides membawa semua elemen slide, termasuk catatan, pemformatan, dan animasi.

**Apakah komentar dan penulisnya dipindahkan?**

Komentar, sebagai bagian dari konten slide, disalin bersama slide. Label penulis komentar dipertahankan sebagai objek komentar dalam presentasi yang dihasilkan.

**Bagaimana jika presentasi sumber dilindungi kata sandi?**

Presentasi harus [dibuka dengan kata sandi](/slides/id/cpp/password-protected-presentation/) melalui [LoadOptions::set_Password](https://reference.aspose.com/slides/id/cpp/aspose.slides/loadoptions/set_password/); setelah dimuat, slide tersebut dapat dengan aman diklon ke file target yang tidak dilindungi (atau juga yang dilindungi).

**Seberapa thread-safe operasi penggabungan?**

Jangan gunakan instance [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) yang sama dari [beberapa thread](/slides/id/cpp/multithreading/). Aturan yang disarankan adalah "satu dokumen — satu thread"; file yang berbeda dapat diproses secara paralel di thread terpisah.