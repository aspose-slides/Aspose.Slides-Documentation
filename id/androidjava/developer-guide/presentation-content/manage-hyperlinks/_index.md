---
title: Kelola Hyperlink Presentasi di Android
linktitle: Kelola Hyperlink
type: docs
weight: 20
url: /id/androidjava/manage-hyperlinks/
keywords:
- tambahkan URL
- tambahkan hyperlink
- buat hyperlink
- format hyperlink
- hapus hyperlink
- perbarui hyperlink
- hyperlink teks
- hyperlink slide
- hyperlink bentuk
- hyperlink gambar
- hyperlink video
- hyperlink yang dapat diubah
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kelola hyperlink dengan mudah dalam presentasi PowerPoint dan OpenDocument menggunakan Aspose.Slides untuk Android via Java—tingkatkan interaktivitas dan alur kerja dalam hitungan menit."
---
## **Pendahuluan**

Hyperlink adalah referensi ke objek atau data atau tempat dalam sesuatu. Berikut ini adalah hyperlink umum dalam Presentasi PowerPoint:

* Tautan ke situs web di dalam teks, bentuk, atau media
* Tautan ke slide

Aspose.Slides untuk Android melalui Java memungkinkan Anda melakukan banyak tugas yang melibatkan hyperlink dalam presentasi.

{{% alert color="info" %}} 

Anda mungkin ingin mencoba Aspose sederhana, [editor PowerPoint daring gratis.](https://products.aspose.app/slides/id/editor)

{{% /alert %}} 

## **Tambahkan Hyperlink URL**

### **Tambahkan Hyperlink URL ke Teks**

Kode Java ini menunjukkan cara menambahkan hyperlink situs web ke teks:

```java
import com.aspose.slides.*;

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

Kode contoh ini dalam Java menunjukkan cara menambahkan hyperlink situs web ke bentuk:

```java
import com.aspose.slides.*;

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

Kode contoh ini menunjukkan cara menambahkan hyperlink ke **gambar**:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	// Menambahkan gambar ke presentasi
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	// Membuat bingkai gambar di slide 1 berdasarkan gambar yang sebelumnya ditambahkan
	IPictureFrame pictureFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pictureFrame.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	pictureFrame.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");

	pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

Kode contoh ini menunjukkan cara menambahkan hyperlink ke **file audio**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

Kode contoh ini menunjukkan cara menambahkan hyperlink ke **video**:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

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

{{%  alert  title="Tip"  color="info"  %}} 

Anda mungkin ingin melihat *[Kelola OLE](/slides/id/androidjava/manage-ole/)*.

{{% /alert %}}

## **Gunakan Hyperlink untuk Membuat Daftar Isi**

Karena hyperlink memungkinkan Anda menambahkan referensi ke objek atau tempat, Anda dapat menggunakannya untuk membuat daftar isi.

Kode contoh ini menunjukkan cara membuat daftar isi dengan hyperlink:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Dengan properti [ColorSource](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Hyperlink#setColorSource-int-) dalam antarmuka [IHyperlink](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlink), Anda dapat mengatur warna untuk hyperlink dan juga memperoleh informasi warna dari hyperlink. Fitur ini pertama kali diperkenalkan di PowerPoint 2019, sehingga perubahan yang melibatkan properti ini tidak berlaku untuk versi PowerPoint yang lebih lama.

Kode contoh ini menunjukkan operasi di mana hyperlink dengan warna berbeda ditambahkan ke slide yang sama:

```java
import com.aspose.slides.*;
import java.awt.Color;

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
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
	ISlide slide = pres.getSlides().get_Item(0);
	for (IShape shape : slide.getShapes())
	{
		if (shape instanceof IAutoShape)
		{
			IAutoShape autoShape = (IAutoShape)shape;
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
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
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

Kelas [Hyperlink](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Hyperlink) bersifat mutable. Dengan kelas ini, Anda dapat mengubah nilai properti berikut:

- [IHyperlink.setTargetFrame(String value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlink#setTargetFrame-java.lang.String-)
- [IHyperlink.setTooltip(String value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlink#setTooltip-java.lang.String-)
- [IHyperlink.setHistory(boolean value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlink#setHistory-boolean-)
- [IHyperlink.setHighlightClick(boolean value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlink#setHighlightClick-boolean-)
- [IHyperlink.setStopSoundOnClick(boolean value)](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlink#setStopSoundOnClick-boolean-)

Potongan kode ini menunjukkan cara menambahkan hyperlink ke slide dan mengedit tooltip-nya kemudian:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
	IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
	shape1.addTextFrame("Aspose: File Format APIs");

	IPortionFormat portionFormat = shape1.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat(); 
	portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
	portionFormat.getHyperlinkClick().setTooltip("More than 70% Fortune 100 companies trust Aspose APIs");
	portionFormat.setFontHeight(32);

	// Mengubah tooltip hyperlink yang sudah ditambahkan
	portionFormat.getHyperlinkClick().setTooltip("Aspose: the File Format APIs");

	pres.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Properti yang Didukung dalam IHyperlinkQueries**

Anda dapat mengakses [IHyperlinkQueries](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlinkQueries) dari sebuah presentasi, slide, atau teks tempat hyperlink didefinisikan.

- [IPresentation.getHyperlinkQueries()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IPresentation#getHyperlinkQueries--)
- [IBaseSlide.getHyperlinkQueries()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IBaseSlide#getHyperlinkQueries--)
- [ITextFrame.getHyperlinkQueries()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ITextFrame#getHyperlinkQueries--)

Kelas [IHyperlinkQueries](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlinkQueries) mendukung metode dan properti berikut:

- [IHyperlinkQueries.getHyperlinkClicks()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkClicks--)
- [IHyperlinkQueries.getHyperlinkMouseOvers()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlinkQueries#getHyperlinkMouseOvers--)
- [IHyperlinkQueries.getAnyHyperlinks()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlinkQueries#getAnyHyperlinks--)
- [IHyperlinkQueries.removeAllHyperlinks()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IHyperlinkQueries#removeAllHyperlinks--)

## **FAQ**

### Bagaimana cara membuat navigasi internal tidak hanya ke slide, tetapi ke "bagian" atau slide pertama dari sebuah bagian?

Bagian di PowerPoint merupakan pengelompokan slide; navigasi secara teknis menargetkan slide tertentu. Untuk "menavigasi ke sebuah bagian", Anda biasanya menautkan ke slide pertamanya.

### Bisakah saya menempelkan hyperlink pada elemen master slide sehingga berfungsi di semua slide?

Ya. Elemen master slide dan tata letak mendukung hyperlink. Tautan tersebut muncul pada slide turunan dan dapat diklik selama presentasi.

### Apakah hyperlink akan dipertahankan saat mengekspor ke PDF, HTML, gambar, atau video?

Dalam [PDF](/slides/id/androidjava/convert-powerpoint-to-pdf/) dan [HTML](/slides/id/androidjava/convert-powerpoint-to-html/), ya—tautan umumnya dipertahankan. Saat mengekspor ke [gambar](/slides/id/androidjava/convert-powerpoint-to-png/) dan [video](/slides/id/androidjava/convert-powerpoint-to-video/), kemampuan mengklik tidak akan terbawa karena sifat format tersebut (frame raster/video tidak mendukung hyperlink).