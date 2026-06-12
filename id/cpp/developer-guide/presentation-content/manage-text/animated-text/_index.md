---
title: Animasi Teks PowerPoint dalam C++
linktitle: Teks Beranimasi
type: docs
weight: 60
url: /id/cpp/animated-text/
keywords:
- teks beranimasi
- animasi teks
- paragraf beranimasi
- animasi paragraf
- efek animasi
- PowerPoint
- OpenDocument
- presentasi
- C++
- Aspose.Slides
description: "Buat teks beranimasi yang dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk C++, dengan contoh kode C++ yang mudah diikuti dan dioptimalkan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan teks beranimasi di Aspose.Slides dengan menerapkan efek animasi pada paragraf individual dan mengambil efek yang sudah ditetapkan pada paragraf dalam bingkai teks. Fokusnya pada metode API yang digunakan untuk menambahkan animasi tingkat paragraf dan memeriksa efek animasi paragraf yang sudah ada dalam sebuah presentasi.

## **Menambahkan Efek Animasi ke Paragraf**

Kami menambahkan metode [**AddEffect()**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.sequence#a255eb5aaf90861b01980047bc06ead4f) ke kelas [**Sequence**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.sequence) dan [**ISequence**](https://reference.aspose.com/slides/id/cpp/class/aspose.slides.animation.i_sequence). Metode ini memungkinkan Anda menambahkan efek animasi ke satu paragraf. Kode contoh berikut menunjukkan cara menambahkan efek animasi ke satu paragraf:

```cpp
String dataDir = GetDataPath();
auto presentation = System::MakeObject<Presentation>(dataDir + u"Presentation1.pptx");

// pilih paragraf untuk menambahkan efek
auto autoShape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto paragraph = autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0);

// tambahkan efek animasi Fly ke paragraf yang dipilih
auto sequence = presentation->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto effect = sequence->AddEffect(paragraph, EffectType::Fly, EffectSubtype::Left, EffectTriggerType::OnClick);

presentation->Save(dataDir + u"AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
```

## **Mendapatkan Efek Animasi untuk Paragraf**

Anda mungkin ingin mengetahui efek animasi yang ditambahkan ke sebuah paragraf; misalnya, dalam satu skenario, Anda ingin mendapatkan efek animasi pada paragraf karena Anda berencana menerapkan efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides untuk C++ memungkinkan Anda memperoleh semua efek animasi yang diterapkan pada paragraf yang terdapat dalam bingkai teks (shape). Kode contoh berikut menunjukkan cara mendapatkan efek animasi dalam sebuah paragraf:

```cpp
String dataDir = GetDataPath();
auto pres = System::MakeObject<Presentation>(dataDir + u"Test.pptx");

auto sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();
auto autoShape = System::ExplicitCast<IAutoShape>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(1));

for (auto paragraph : autoShape->get_TextFrame()->get_Paragraphs())
{
	auto effects = sequence->GetEffectsByParagraph(paragraph);

	if (effects->get_Length() > 0)
	{
		Console::WriteLine(String(u"Paragraph \"") + paragraph->get_Text() + u"\" has " + ObjectExt::ToString(effects[0]->get_Type()) + u" effect.");
	}
}
```

## **FAQ**

**Bagaimana animasi teks berbeda dari transisi slide, dan dapatkah keduanya digabungkan?**

Animasi teks mengontrol perilaku objek seiring waktu pada sebuah slide, sementara [transisi](/slides/id/cpp/slide-transition/) mengontrol cara pergantian slide. Kedua hal ini bersifat independen dan dapat digunakan bersama; urutan pemutaran diatur oleh timeline animasi dan pengaturan transisi.

**Apakah animasi teks dipertahankan saat mengekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, sehingga Anda hanya melihat satu keadaan slide tanpa gerakan. Untuk mempertahankan gerakan, gunakan ekspor [video](/slides/id/cpp/convert-powerpoint-to-video/) atau [HTML](/slides/id/cpp/export-to-html5/).

**Apakah animasi teks berfungsi di tata letak dan master slide?**

Efek yang diterapkan pada objek tata letak/master diwariskan ke slide, tetapi timing dan interaksinya dengan animasi tingkat slide tergantung pada urutan akhir pada slide.