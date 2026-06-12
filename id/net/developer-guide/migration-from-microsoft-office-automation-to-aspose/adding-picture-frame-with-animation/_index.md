---
title: Menambahkan Bingkai Gambar dengan Animasi Menggunakan VSTO dan Aspose.Slides untuk .NET
linktitle: Bingkai Gambar dengan Animasi
type: docs
weight: 60
url: /id/net/adding-picture-frame-with-animation/
keywords:
- bingkai gambar
- menambahkan gambar
- menambahkan gambar
- gambar dengan animasi
- gambar dengan animasi
- migrasi
- VSTO
- otomasi Office
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Migrasikan otomasi Microsoft Office ke Aspose.Slides untuk .NET dan animasikan bingkai gambar dalam slide PowerPoint (PPT, PPTX) dengan kode C# yang bersih."
---
{{% alert color="primary" %}} 

Bingkai gambar diterapkan pada bentuk atau gambar di Microsoft PowerPoint untuk membingkai gambar dalam sebuah presentasi. Artikel ini menunjukkan cara membuat bingkai gambar dan menerapkan animasi padanya secara programatis menggunakan pertama [VSTO 2008](/slides/id/net/adding-picture-frame-with-animation/) dan kemudian [Aspose.Slides for .NET](/slides/id/net/adding-picture-frame-with-animation/). Pertama, kami menunjukkan cara menerapkan bingkai dan animasi menggunakan VSTO 2008. Kami kemudian menunjukkan cara melakukan langkah yang sama menggunakan Aspose.Slides for .NET.

{{% /alert %}} 
## **Menambahkan Bingkai Gambar dengan Animasi**
Contoh kode di bawah ini membuat presentasi dengan satu slide, menambahkan gambar dengan bingkai gambar, dan menerapkan animasi padanya.
### **Contoh VSTO 2008**
Menggunakan VSTO 2008, ikuti langkah-langkah berikut:

1. Buat presentasi.
1. Tambahkan slide kosong.
1. Tambahkan bentuk gambar ke slide.
1. Terapkan animasi pada gambar.
1. Simpan presentasi ke disk.

**Presentasi hasil output, dibuat dengan VSTO** 

![todo:image_alt_text](adding-picture-frame-with-animation_1.png)



```c#
//Membuat presentasi kosong
PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Menambahkan slide kosong
PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Menambahkan Bingkai Gambar
PowerPoint.Shape PicFrame = sld.Shapes.AddPicture(@"D:\Aspose Data\Desert.jpg",
Microsoft.Office.Core.MsoTriState.msoTriStateMixed,
Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Menerapkan animasi pada bingkai gambar
PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Menyimpan Presentasi
pres.SaveAs("d:\\ VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,
Microsoft.Office.Core.MsoTriState.msoFalse);
```


### **Contoh Aspose.Slides for .NET**
Menggunakan Aspose.Slides for .NET, lakukan langkah-langkah berikut:

1. Buat presentasi.
1. Akses slide pertama.
1. Tambahkan gambar ke koleksi gambar.
1. Tambahkan bentuk gambar ke slide.
1. Terapkan animasi pada gambar.
1. Simpan presentasi ke disk.

**Presentasi hasil output, dibuat dengan Aspose.Slides** 

![todo:image_alt_text](adding-picture-frame-with-animation_2.png)



```c#
// Membuat presentasi kosong
using (Presentation pres = new Presentation())
{
    // Mengakses slide pertama
    ISlide slide = pres.Slides[0];

    // Menambahkan gambar ke koleksi gambar presentasi
    IImage image = Images.FromFile("aspose.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Menambahkan bingkai gambar yang tinggi dan lebarnya cocok dengan tinggi dan lebar gambar
    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, ppImage.Width, ppImage.Height, ppImage);

    // Mendapatkan urutan animasi utama slide
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Menambahkan efek animasi Fly from Left ke bingkai gambar
    IEffect effect = sequence.AddEffect(pictureFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Menyimpan presentasi
    pres.Save("AsposeAnim.ppt", SaveFormat.Ppt);
}
```