---
title: Menambahkan Bingkai Gambar dengan Animasi di VSTO dan Aspose.Slides
type: docs
weight: 20
url: /id/net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---
Contoh kode di bawah membuat presentasi dengan satu slide, menambahkan gambar dengan bingkai gambar, dan menerapkan animasi pada gambar tersebut.
## **VSTO**
Menggunakan VSTO, lakukan langkah-langkah berikut:

1. Buat presentasi.
1. Tambahkan slide kosong.
1. Tambahkan bentuk gambar ke slide.
1. Terapkan animasi pada gambar.
1. Simpan presentasi ke disk.

``` csharp

 //Membuat presentasi kosong

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Menambahkan slide kosong

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Menambahkan Bingkai Gambar

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Menerapkan animasi pada bingkai gambar

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Menyimpan Presentasi

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Menggunakan Aspose.Slides untuk .NET, lakukan langkah-langkah berikut:

1. Buat presentasi.
1. Akses slide pertama.
1. Tambahkan gambar ke koleksi gambar.
1. Tambahkan bentuk gambar ke slide.
1. Terapkan animasi pada gambar.
1. Simpan presentasi ke disk.

``` csharp

 //Membuat presentasi kosong

Presentation pres = new Presentation();

//Mengakses slide pertama

Slide slide = pres.GetSlideByPosition(1);

//Menambahkan objek gambar ke koleksi gambar pada presentasi

Picture pic = new Picture(pres, "pic.jpeg");

//Setelah objek gambar ditambahkan, gambar diberikan Id gambar yang unik

int picId = pres.Pictures.Add(pic);

//Menambahkan Bingkai Gambar

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Menerapkan animasi pada bingkai gambar

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Menyimpan Presentasi

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/src/master/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation/)