---
title: Kelola Hyperlink Presentasi di .NET
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/net/manage-hyperlinks/
keywords:
- menambahkan URL
- menambahkan hyperlink
- membuat hyperlink
- memformat hyperlink
- menghapus hyperlink
- memperbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Kelola hyperlink dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk .NET secara mudah—tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Pendahuluan**

Hyperlink adalah referensi ke sebuah objek atau data atau sebuah tempat dalam sesuatu. Berikut ini adalah hyperlink umum dalam Presentasi PowerPoint:

* Tautan ke situs web di dalam teks, bentuk, atau media
* Tautan ke slide

Aspose.Slides untuk .NET memungkinkan Anda melakukan banyak tugas yang melibatkan hyperlink dalam presentasi. 

{{% alert color="primary" %}} 

Anda mungkin ingin melihat Aspose sederhana, [editor PowerPoint online gratis.](https://products.aspose.app/slides/id/editor)

{{% /alert %}} 

## **Menambahkan Hyperlink URL**

### **Menambahkan Hyperlink URL ke Teks**

Kode C# ini menunjukkan cara menambahkan hyperlink situs web ke teks:

```c#
using (Presentation presentation = new Presentation())
{
	IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.AddTextFrame("Aspose: File Format APIs");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
	shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;

	presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

### **Menambahkan Hyperlink URL ke Bentuk atau Bingkai**

Contoh kode ini dalam C# menunjukkan cara menambahkan hyperlink situs web ke sebuah bentuk:

```c#
using (Presentation pres = new Presentation())
{
    IShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);
    
    shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

### **Menambahkan Hyperlink URL ke Media**

Aspose.Slides memungkinkan Anda menambahkan hyperlink ke file gambar, audio, dan video. 

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **gambar**:

```c#
using (Presentation pres = new Presentation())
{
    // Menambahkan gambar ke presentasi
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    // Membuat bingkai gambar pada slide 1 berdasarkan gambar yang sebelumnya ditambahkan
    IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);

    pictureFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    pictureFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **file audio**:

```c#
using (Presentation pres = new Presentation())
{
    IAudio audio = pres.Audios.AddAudio(File.ReadAllBytes("audio.mp3"));
    IAudioFrame audioFrame = pres.Slides[0].Shapes.AddAudioFrameEmbedded(10, 10, 100, 100, audio);

    audioFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    audioFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **video**:

``` csharp
using (Presentation pres = new Presentation())
{
    IVideo video = pres.Videos.AddVideo(File.ReadAllBytes("video.avi"));
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 100, 100, video);

    videoFrame.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    videoFrame.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

{{%  alert  title="Tip"  color="primary"  %}} 

Anda mungkin ingin melihat *[Kelola OLE](https://docs.aspose.com/slides/id/net/manage-ole/)*.

{{% /alert %}}

## **Menggunakan Hyperlink untuk Membuat Daftar Isi**

Karena hyperlink memungkinkan Anda menambahkan referensi ke objek atau tempat, Anda dapat menggunakannya untuk membuat daftar isi. 

Contoh kode ini menunjukkan cara membuat daftar isi dengan hyperlink:

```c#
using (var presentation = new Presentation())
{
    var firstSlide = presentation.Slides[0];
    var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

    var contentTable = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    contentTable.FillFormat.FillType = FillType.NoFill;
    contentTable.LineFormat.FillFormat.FillType = FillType.NoFill;
    contentTable.TextFrame.Paragraphs.Clear();

    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    paragraph.Text = "Title of slide 2 .......... ";

    var linkPortion = new Portion();
    linkPortion.Text = "Page 2";
    linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

    paragraph.Portions.Add(linkPortion);
    contentTable.TextFrame.Paragraphs.Add(paragraph);

    presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
}
```

## **Memformat Hyperlink**

### **Warna**

Dengan properti [ColorSource](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/properties/colorsource) di antarmuka [IHyperlink](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink), Anda dapat mengatur warna untuk hyperlink dan juga mendapatkan informasi warna dari hyperlink. Fitur ini pertama kali diperkenalkan di PowerPoint 2019, sehingga perubahan yang melibatkan properti ini tidak berlaku untuk versi PowerPoint yang lebih lama.

Contoh kode ini mendemonstrasikan operasi di mana hyperlink dengan warna berbeda ditambahkan ke slide yang sama:

```c#
using (Presentation presentation = new Presentation())
{
    IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    shape1.AddTextFrame("This is a sample of colored hyperlink.");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

    IAutoShape shape2 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    shape2.AddTextFrame("This is a sample of usual hyperlink.");
    shape2.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

    presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
}
```
### **Suara**

Aspose.Slides menyediakan properti-properti ini agar Anda dapat menekankan hyperlink dengan suara:
- [IHyperlink.Sound](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/properties/sound) 
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/properties/stopsoundonclick)

#### **Menambahkan Suara pada Hyperlink**

Kode C# ini menunjukkan cara mengatur hyperlink yang memutar suara dan menghentikannya dengan hyperlink lain:

```c#
using (Presentation pres = new Presentation())
{
	// Menambahkan audio baru ke koleksi audio presentasi
	IAudio playSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Menambahkan bentuk baru dengan hyperlink ke slide berikutnya
	IShape firstShape = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
	firstShape.HyperlinkClick = Hyperlink.NextSlide;

	// Memeriksa hyperlink untuk "No Sound"
	if (!firstShape.HyperlinkClick.StopSoundOnClick && firstShape.HyperlinkClick.Sound == null)
	{
		// Mengatur hyperlink yang memutar suara
		firstShape.HyperlinkClick.Sound = playSound;
	}

	// Menambahkan slide kosong 
	ISlide secondSlide = pres.Slides.AddEmptySlide(firstSlide.LayoutSlide);

	// Menambahkan bentuk baru dengan hyperlink NoAction
	IShape secondShape = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
	secondShape.HyperlinkClick = Hyperlink.NoAction;

	// Mengatur flag hyperlink "Stop previous sound"
	secondShape.HyperlinkClick.StopSoundOnClick = true;

	pres.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
}
```

#### **Mengekstrak Suara Hyperlink**

Kode C# ini menunjukkan cara mengekstrak suara yang digunakan dalam sebuah hyperlink:

```c#
using (Presentation pres = new Presentation("hyperlink-sound.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Mendapatkan hyperlink bentuk pertama
	IHyperlink link = firstSlide.Shapes[0].HyperlinkClick;

	if (link.Sound != null)
	{
		// Mengekstrak suara hyperlink dalam array byte
		byte[] audioData = link.Sound.BinaryData;
	}
}
```

## **Menghapus Hyperlink dari Presentasi**

### **Menghapus Hyperlink dari Teks**

Kode C# ini menunjukkan cara menghapus hyperlink dari teks dalam slide presentasi:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ISlide slide = pres.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
            {
                foreach (IPortion portion in paragraph.Portions)
                {
                    portion.PortionFormat.HyperlinkManager.RemoveHyperlinkClick();
                }
            }
        }
    }
    
    pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
```

### **Menghapus Hyperlink dari Bentuk atau Bingkai**

Kode C# ini menunjukkan cara menghapus hyperlink dari sebuah bentuk dalam slide presentasi: 

``` csharp
using (Presentation pres = new Presentation("demo.pptx")) 
{ 
   ISlide slide = pres.Slides[0]; 
   foreach (IShape shape in slide.Shapes) 
     { 
       shape.HyperlinkManager.RemoveHyperlinkClick(); 
     } 
   pres.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx); 
}
```

## **Hyperlink yang Dapat Diubah**

Kelas [Hyperlink](https://reference.aspose.com/slides/id/net/aspose.slides/hyperlink) bersifat mutable. Dengan kelas ini, Anda dapat mengubah nilai properti-properti berikut:

- [IHyperlink.TargetFrame](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/properties/targetframe)
- [IHyperlink.Tooltip](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/properties/tooltip)
- [IHyperlink.History](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/properties/history)
- [IHyperlink.HighlightClick](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlink/properties/highlightclick)

Potongan kode ini menunjukkan cara menambahkan hyperlink ke slide dan mengedit tooltip-nya kemudian:

```c#
using (Presentation presentation = new Presentation())
{   
   IAutoShape shape1 = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);    
    
   shape1.AddTextFrame("Aspose: File Format APIs");
    
   shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick.Tooltip = "More than 70% Fortune 100 companies trust Aspose APIs";
    
    shape1.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FontHeight = 32;
    
 presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
}
```

## **Properti yang Didukung dalam IHyperlinkQueries**

Anda dapat mengakses IHyperlinkQueries dari presentasi, slide, atau teks tempat hyperlink didefinisikan. 

- [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/id/net/aspose.slides/ipresentation/properties/hyperlinkqueries)
- [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/id/net/aspose.slides/ibaseslide/properties/hyperlinkqueries)
- [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/id/net/aspose.slides/itextframe/properties/hyperlinkqueries)

Kelas IHyperlinkQueries mendukung metode dan properti berikut: 

- [IHyperlinkQueries.GetHyperlinkClicks();](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkclicks)
- [IHyperlinkQueries.GetHyperlinkMouseOvers();](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/methods/gethyperlinkmouseovers)
- [IHyperlinkQueries.GetAnyHyperlinks();](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/methods/getanyhyperlinks)
- [IHyperlinkQueries.RemoveAllHyperlinks();](https://reference.aspose.com/slides/id/net/aspose.slides/ihyperlinkqueries/methods/removeallhyperlinks)

## **FAQ**

**Bagaimana saya dapat membuat navigasi internal bukan hanya ke slide, tetapi ke "bagian" atau slide pertama dari sebuah bagian?**

Bagian dalam PowerPoint adalah pengelompokan slide; navigasi secara teknis menargetkan slide tertentu. Untuk "menavigasi ke sebuah bagian", Anda biasanya menautkan ke slide pertamanya.

**Apakah saya dapat menempelkan hyperlink ke elemen master slide sehingga berfungsi di semua slide?**

Ya. Elemen master slide dan layout mendukung hyperlink. Tautan tersebut muncul pada slide anak dan dapat diklik selama presentasi.

**Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Dalam [PDF](/slides/id/net/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/net/convert-powerpoint-to-html/), ya—tautan biasanya dipertahankan. Saat mengekspor ke [gambar](/slides/id/net/convert-powerpoint-to-png/) dan [video](/slides/id/net/convert-powerpoint-to-video/), kemampuan mengklik tidak akan terbawa karena sifat format tersebut (frame raster/video tidak mendukung hyperlink).