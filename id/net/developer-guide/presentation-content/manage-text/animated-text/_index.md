---
title: Animasi Teks PowerPoint di .NET
linktitle: Teks Beranimasi
type: docs
weight: 60
url: /id/net/animated-text/
keywords:
- teks beranimasi
- animasi teks
- paragraf beranimasi
- animasi paragraf
- efek animasi
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Buat teks beranimasi yang dinamis dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk .NET, dengan contoh kode C# yang mudah diikuti dan dioptimalkan."
---
## **Ikhtisar**

Artikel ini menjelaskan cara bekerja dengan teks beranimasi di Aspose.Slides dengan menerapkan efek animasi pada paragraf‑paragraf individual dan mengambil efek yang sudah ditetapkan pada paragraf dalam sebuah bingkai teks. Fokusnya pada metode API yang digunakan untuk menambahkan animasi pada tingkat paragraf dan memeriksa efek animasi paragraf yang sudah ada dalam sebuah presentasi.

## **Menambahkan Efek Animasi ke Paragraf**

Kami menambahkan metode [**AddEffect()**](https://reference.aspose.com/slides/id/net/aspose.slides.animation/sequence/methods/addeffect/index) ke kelas [**Sequence**](https://reference.aspose.com/slides/id/net/aspose.slides.animation/sequence) dan [**ISequence**](https://reference.aspose.com/slides/id/net/aspose.slides.animation/isequence). Metode ini memungkinkan Anda menambahkan efek animasi ke satu paragraf. Kode contoh berikut menunjukkan cara menambahkan efek animasi ke satu paragraf:

```c#
using (Presentation presentation = new Presentation(dataDir + "Presentation1.pptx"))
{
    // pilih paragraf untuk menambahkan efek
    IAutoShape autoShape = (IAutoShape)presentation.Slides[0].Shapes[0];
    IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

    // tambahkan efek animasi Fly ke paragraf yang dipilih
    IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(paragraph, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);


    presentation.Save(dataDir + "AnimationEffectinParagraph.pptx", SaveFormat.Pptx);
}
```

## **Mendapatkan Efek Animasi untuk Paragraf**

Anda mungkin ingin mengetahui efek animasi yang ditambahkan pada sebuah paragraf—misalnya, dalam satu skenario, Anda ingin mengambil efek animasi pada paragraf karena berencana menerapkan efek tersebut ke paragraf atau bentuk lain.

Aspose.Slides untuk .NET memungkinkan Anda mendapatkan semua efek animasi yang diterapkan pada paragraf yang terdapat dalam sebuah bingkai teks (bentuk). Kode contoh berikut menunjukkan cara mendapatkan efek animasi dalam sebuah paragraf:

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	ISequence sequence = pres.Slides[0].Timeline.MainSequence;
	IAutoShape autoShape = (IAutoShape)pres.Slides[0].Shapes[1];

	foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
	{
		IEffect[] effects = sequence.GetEffectsByParagraph(paragraph);

		if (effects.Length > 0)
			Console.WriteLine("Paragraph \"" + paragraph.Text + "\" has " + effects[0].Type + " effect.");
	}
}
```

## **FAQ**

**Bagaimana animasi teks berbeda dari transisi slide, dan dapatkah keduanya digabungkan?**

Animasi teks mengontrol perilaku objek seiring waktu pada sebuah slide, sementara [transitions](/slides/id/net/slide-transition/) mengontrol cara slide berubah. Keduaannya bersifat independen dan dapat digunakan bersamaan; urutan pemutaran diatur oleh timeline animasi dan pengaturan transisi.

**Apakah animasi teks dipertahankan saat mengekspor ke PDF atau gambar?**

Tidak. PDF dan gambar raster bersifat statis, sehingga Anda hanya melihat satu keadaan slide tanpa gerakan. Untuk mempertahankan gerakan, gunakan ekspor [video](/slides/id/net/convert-powerpoint-to-video/) atau [HTML](/slides/id/net/export-to-html5/).

**Apakah animasi teks berfungsi pada tata letak dan master slide?**

Efek yang diterapkan pada objek tata letak/master diwariskan ke slide, namun timing dan interaksinya dengan animasi pada tingkat slide bergantung pada urutan akhir pada slide tersebut.