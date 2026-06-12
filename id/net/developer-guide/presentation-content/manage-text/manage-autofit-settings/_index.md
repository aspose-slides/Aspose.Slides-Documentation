---
title: Meningkatkan Presentasi Anda dengan AutoFit di .NET
linktitle: Pengaturan Autofit
type: docs
weight: 30
url: /id/net/manage-autofit-settings/
keywords:
- kotak teks
- autofit
- tidak autofit
- menyesuaikan teks
- memperkecil teks
- membungkus teks
- mengubah ukuran bentuk
- PowerPoint
- presentasi
- C#
- .NET
- Aspose.Slides
description: "Pelajari cara mengelola pengaturan AutoFit di Aspose.Slides untuk .NET guna mengoptimalkan tampilan teks dalam presentasi PowerPoint dan OpenDocument serta meningkatkan keterbacaan konten."
---
## **Pendahuluan**

Secara default, ketika Anda menambahkan kotak teks, Microsoft PowerPoint menggunakan pengaturan **Resize shape to fit text** untuk kotak teks—ini secara otomatis mengubah ukuran kotak teks untuk memastikan teksnya selalu muat di dalamnya.

![Kotak teks di PowerPoint](textbox-in-powerpoint.png)

* Ketika teks dalam kotak teks menjadi lebih panjang atau lebih besar, PowerPoint secara otomatis memperbesar kotak teks—meningkatkan tinggiannya—untuk menampung lebih banyak teks.
* Ketika teks dalam kotak teks menjadi lebih pendek atau lebih kecil, PowerPoint secara otomatis memperkecil kotak teks—mengurangi tinggiannya—untuk menghilangkan ruang berlebih.

Di PowerPoint, ada empat parameter atau opsi penting yang mengendalikan perilaku autofit untuk kotak teks:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape**

![Opsi autofit di PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET menyediakan opsi serupa—properti di bawah kelas [TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat)—yang memungkinkan Anda mengontrol perilaku autofit untuk kotak teks dalam presentasi.

## **Resize a Shape to Fit Text**

Jika Anda menginginkan teks dalam sebuah kotak selalu muat ke dalam kotak tersebut setelah perubahan teks, Anda harus menggunakan opsi **Resize shape to fit text**. Untuk menentukan pengaturan ini, atur properti `AutofitType` dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat) menjadi `Shape`.

![Resize shape to fit text](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Jika teks menjadi lebih panjang atau lebih besar, kotak teks akan secara otomatis diubah ukurannya (tinggiannya ditambah) untuk memastikan semua teks muat di dalamnya. Jika teks menjadi lebih pendek, sebaliknya terjadi.

## **Do Not Autofit**

Jika Anda ingin kotak teks atau bentuk mempertahankan dimensinya apa pun perubahan pada teks yang dikandungnya, Anda harus menggunakan opsi **Do not Autofit**. Untuk menentukan pengaturan ini, atur properti `AutofitType` dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat) menjadi `None`.

![Pengaturan “Do not Autofit” di PowerPoint](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

Ketika teks menjadi terlalu panjang untuk kotaknya, teks akan meluber keluar.

## **Shrink Text on Overflow**

Jika teks menjadi terlalu panjang untuk kotaknya, melalui opsi **Shrink text on overflow**, Anda dapat menentukan bahwa ukuran dan spasi teks harus diperkecil agar muat di dalam kotaknya. Untuk menentukan pengaturan ini, atur properti `AutofitType` dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat) menjadi `Normal`.

![Pengaturan “Shrink text on overflow” di PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}
Saat opsi **Shrink text on overflow** digunakan, pengaturan hanya diterapkan ketika teks menjadi terlalu panjang untuk kotaknya.
{{% /alert %}}

## **Wrap Text**

Jika Anda ingin teks dalam sebuah bentuk dibungkus di dalam bentuk tersebut ketika teks melampaui batas bentuk (hanya lebar), Anda harus menggunakan parameter **Wrap text in shape**. Untuk menentukan pengaturan ini, atur properti `WrapText` dari kelas [TextFrameFormat](https://reference.aspose.com/slides/id/net/aspose.slides/textframeformat) menjadi `NullableBool.True`.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Catatan" color="warning" %}} 
Jika Anda mengatur properti `WrapText` menjadi `NullableBool.False` untuk sebuah bentuk, ketika teks di dalam bentuk menjadi lebih panjang daripada lebar bentuk, teks akan meluas melampaui batas bentuk dalam satu baris.
{{% /alert %}}

## **Tanya Jawab**

**Apakah margin internal frame teks memengaruhi AutoFit?**

Ya. Padding (margin internal) mengurangi area yang dapat digunakan untuk teks, sehingga AutoFit akan aktif lebih awal—memperkecil font atau mengubah ukuran bentuk lebih cepat. Periksa dan sesuaikan margin sebelum mengatur AutoFit.

**Bagaimana AutoFit berinteraksi dengan pemecahan baris manual dan lunak?**

Pemecahan baris paksa tetap ada, dan AutoFit menyesuaikan ukuran font serta spasi di sekitarnya. Menghapus pemecahan baris yang tidak diperlukan sering mengurangi seberapa agresif AutoFit harus memperkecil teks.

**Apakah mengubah font tema atau memicu substitusi font memengaruhi hasil AutoFit?**

Ya. Mengganti ke font dengan metrik glyph yang berbeda mengubah lebar/tinggi teks, yang dapat mengubah ukuran font akhir dan pembungkus baris. Setelah setiap perubahan atau substitusi font, periksa kembali slide.