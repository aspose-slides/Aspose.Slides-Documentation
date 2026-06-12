---
title: Kelola Hyperlink Presentasi di Java
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/java/manage-hyperlinks/
keywords:
- tambahkan URL
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
- Java
- Aspose.Slides
description: "Kelola hyperlink dengan mudah dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Java—tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Pendahuluan**

Hyperlink adalah referensi ke objek, data, atau lokasi dalam sesuatu. Berikut ini adalah hyperlink umum dalam Presentasi PowerPoint:

* Tautan ke situs web dalam teks, bentuk, atau media
* Tautan ke slide

Aspose.Slides untuk Java memungkinkan Anda melakukan banyak tugas yang melibatkan hyperlink dalam presentasi. 

{{% alert color="primary" %}} 
Anda mungkin ingin melihat Aspose sederhana, [pengedit PowerPoint daring gratis](https://products.aspose.app/slides/id/editor)
{{% /alert %}} 

## **Tambahkan Hyperlink URL**

### **Tambahkan Hyperlink URL ke Teks**

Kode Java ini menunjukkan cara menambahkan hyperlink situs web ke teks:

```java
Presentation presentation = new Presentation();
try {
	IAutoShape shape1 = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");
	
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (presentation != null) presentation.dispose();
}
```

### **Tambahkan Hyperlink URL ke Bentuk atau Bingkai**

Contoh kode Java ini menunjukkan cara menambahkan hyperlink situs web ke bentuk:

```java
Presentation pres = new Presentation();
try {
	IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

	shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	shape.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Tambahkan Hyperlink URL ke Media**

Aspose.Slides memungkinkan Anda menambahkan hyperlink ke file gambar, audio, dan video. 

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **gambar**:

```java
Presentation pres = new Presentation();
try {
	// Menambahkan gambar ke presentasi
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
	// Membuat bingkai gambar pada slide 1 berdasarkan gambar yang telah ditambahkan sebelumnya
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **file audio**:

```java
Presentation pres = new Presentation();
try {
	IAudio audio = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("audio.mp3")));
	IAudioFrame audioFrame = pres.getSlides().get_Item(0).getShapes().addAudioFrameEmbedded(10, 10, 100, 100, audio);

	audioFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	audioFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

Contoh kode ini menunjukkan cara menambahkan hyperlink ke **video**:

```java
Presentation pres = new Presentation();
try {
	IVideo video = pres.getVideos().addVideo(Files.readAllBytes(Paths.get("video.avi")));
	IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 100, 100, video);

	videoFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	videoFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

{{%  alert  title="Tip"  color="primary"  %}} 
Anda mungkin ingin melihat *[Kelola OLE](/slides/id/java/manage-ole/)*.
{{% /alert %}}

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Karena hyperlink memungkinkan Anda menambahkan referensi ke objek atau lokasi, Anda dapat menggunakannya untuk membuat daftar isi. 

Contoh kode ini menunjukkan cara membuat daftar isi dengan hyperlink:

```java
Presentation pres = new Presentation();
try {
	ISlide firstSlide = pres.getSlides().get_Item(0);
	ISlide secondSlide = pres.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

	IAutoShape contentTable = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
	contentTable.getFillFormat().setFillType(FillType.NoFill);
	contentTable.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
	contentTable.getTextFrame().getParagraphs().clear();

	Paragraph paragraph = new Paragraph();
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
	paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
	paragraph.setText("Title of slide 2 .......... ");

	Portion linkPortion = new Portion();
	linkPortion.setText("Page 2");
	linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

	paragraph.getPortions().add(linkPortion);
	contentTable.getTextFrame().getParagraphs().add(paragraph);

	pres.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Format Hyperlink**

### **Warna**

Dengan properti [ColorSource](https://reference.aspose.com/slides/id/java/com.aspose.slides/Hyperlink#setColorSource-int-) pada antarmuka [IHyperlink](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlink), Anda dapat mengatur warna untuk hyperlink dan juga mendapatkan informasi warna dari hyperlink. Fitur ini pertama kali diperkenalkan di PowerPoint 2019, sehingga perubahan yang melibatkan properti ini tidak berlaku pada versi PowerPoint yang lebih lama.

Contoh kode ini menunjukkan operasi di mana hyperlink dengan warna berbeda ditambahkan ke slide yang sama:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
	shape1.addTextFrame("This is a sample of colored hyperlink.");
	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
	portionFormat.getFillFormat().setFillType(FillType.Solid);
	portionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

	IAutoShape shape2 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
	shape2.addTextFrame("This is a sample of usual hyperlink.");
	shape2.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

	pres.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Hapus Hyperlink dari Presentasi**

### **Hapus Hyperlink dari Teks**

Kode Java ini menunjukkan cara menghapus hyperlink dari teks dalam slide presentasi:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		IAutoShape autoShape = (IAutoShape)shape;
		if (autoShape != null)
		{
			for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs())
			{
				for (IPortion portion : paragraph.getPortions())
				{
					portion.getPortionFormat().getHyperlinkManager().removeHyperlinkClick();
				}
			}
		}
	}

	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

### **Hapus Hyperlink dari Bentuk atau Bingkai**

Kode Java ini menunjukkan cara menghapus hyperlink dari bentuk dalam slide presentasi: 

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		shape.getHyperlinkManager().removeHyperlinkClick();
	}
	pres.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Hyperlink yang Dapat Diubah**

Kelas [Hyperlink](https://reference.aspose.com/slides/id/java/com.aspose.slides/Hyperlink) bersifat mutable. Dengan kelas ini, Anda dapat mengubah nilai properti berikut:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Potongan kode ini menunjukkan cara menambahkan hyperlink ke slide dan mengedit tooltip-nya kemudian:

```java
Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Properti yang Didukung di IHyperlinkQueries**

Anda dapat mengakses [IHyperlinkQueries](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlinkQueries) dari presentasi, slide, atau teks di mana hyperlink didefinisikan. 

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/id/java/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Kelas [IHyperlinkQueries](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlinkQueries) mendukung metode dan properti berikut: 

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/id/java/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

**Bagaimana saya dapat membuat navigasi internal tidak hanya ke slide, tetapi ke “bagian” atau slide pertama dari suatu bagian?**

Bagian di PowerPoint adalah kumpulan slide; navigasi secara teknis menargetkan slide tertentu. Untuk “menavigasi ke sebuah bagian”, Anda biasanya menautkan ke slide pertamanya.

**Apakah saya dapat menempelkan hyperlink pada elemen master slide sehingga berfungsi pada semua slide?**

Ya. Elemen master slide dan tata letak mendukung hyperlink. Tautan tersebut muncul pada slide turunan dan dapat diklik selama presentasi.

**Apakah hyperlink akan tetap dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?**

Di [PDF](/slides/id/java/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/java/convert-powerpoint-to-html/), ya—tautan biasanya dipertahankan. Saat mengekspor ke [gambar](/slides/id/java/convert-powerpoint-to-png/) dan [video](/slides/id/java/convert-powerpoint-to-video/), kemampuan klik tidak akan terbawa karena sifat format tersebut (frame raster/video tidak mendukung hyperlink).