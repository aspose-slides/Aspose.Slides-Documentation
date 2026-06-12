---
title: Kelola Font dalam Presentasi di Android
linktitle: Kelola Font
type: docs
weight: 10
url: /id/androidjava/manage-fonts/
keywords:
- kelola font
- properti font
- paragraf
- pemformatan teks
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Kontrol font dalam Java dengan Aspose.Slides untuk Android: sematkan, ganti, dan muat font kustom untuk memastikan presentasi PPT, PPTX, dan ODP tetap jelas, aman merek, dan konsisten."
---
## **Gambaran Umum**

Aspose.Slides memungkinkan Anda mengelola properti font dalam teks presentasi langsung dari kode Anda. Anda dapat mengakses teks di slide melalui bentuk, kerangka teks, paragraf, dan bagian, lalu menerapkan pemformatan pada teks yang dipilih.

Artikel ini menjelaskan cara mengonfigurasi properti yang berhubungan dengan font untuk teks yang ada dalam presentasi, termasuk keluarga font, gaya tebal dan miring, perataan paragraf, serta warna font. Artikel ini juga menunjukkan cara membuat kotak teks, menambahkan teks ke dalamnya, dan mengatur properti font seperti keluarga font, tebal, miring, garis bawah, ukuran font, dan warna sebelum menyimpan hasilnya sebagai file PPTX.

## **Kelola Properti Terkait Font**
{{% alert color="primary" %}} 

Presentasi biasanya berisi teks dan gambar. Teks dapat diformat dengan berbagai cara, baik untuk menyoroti bagian dan kata tertentu maupun menyesuaikan dengan gaya perusahaan. Pemformatan teks membantu pengguna mengubah tampilan dan nuansa konten presentasi. Artikel ini menunjukkan cara menggunakan Aspose.Slides for Android via Java untuk mengonfigurasi properti font pada paragraf teks di slide.

{{% /alert %}} 

Untuk mengelola properti font sebuah paragraf menggunakan Aspose.Slides for Android via Java:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Akses shape [Placeholder](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/placeholder/) di slide dan lakukan typecast menjadi [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/).
1. Dapatkan [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/) dari [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) yang disediakan oleh [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/).
1. Ratakan paragraf.
1. Akses [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) teks dari [Paragraph](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/paragraph/).
1. Tentukan font menggunakan [FontData](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fontdata/) dan atur **Font** dari [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) teks sesuai.
   1. Atur font menjadi tebal.
   1. Atur font menjadi miring.
1. Atur warna font menggunakan [FillFormat](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/fillformat/) yang disediakan oleh objek [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/).
1. Simpan presentasi yang telah diubah ke file PPTX.

Implementasi langkah-langkah di atas diberikan di bawah ini. Ini mengambil presentasi tanpa hiasan dan memformat font pada salah satu slide. Tangkapan layar berikut menunjukkan file input dan bagaimana cuplikan kode mengubahnya. Kode mengubah font, warna, dan gaya font.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Gambar: Teks dalam file input**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Gambar: Teks yang sama dengan pemformatan yang diperbarui**|

```java
	// Membuat objek Presentation yang merepresentasikan file PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
		// Mengakses slide menggunakan posisinya
		ISlide slide = pres.getSlides().get_Item(0);

		// Mengakses placeholder pertama dan kedua di slide serta melakukan typecast menjadi AutoShape
		ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
		ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

		// Mengakses Paragraph pertama
		IParagraph para1 = tf1.getParagraphs().get_Item(0);
		IParagraph para2 = tf2.getParagraphs().get_Item(0);

		// Merapikan paragraf
		para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

		// Mengakses portion pertama
		IPortion port1 = para1.getPortions().get_Item(0);
		IPortion port2 = para2.getPortions().get_Item(0);

		// Mendefinisikan font baru
		FontData fd1 = new FontData("Elephant");
		FontData fd2 = new FontData("Castellar");

		// Menetapkan font baru ke portion
		port1.getPortionFormat().setLatinFont(fd1);
		port2.getPortionFormat().setLatinFont(fd2);

		// Mengatur font menjadi Bold
		port1.getPortionFormat().setFontBold(NullableBool.True);
		port2.getPortionFormat().setFontBold(NullableBool.True);

		// Mengatur font menjadi Italic
		port1.getPortionFormat().setFontItalic(NullableBool.True);
		port2.getPortionFormat().setFontItalic(NullableBool.True);

		// Mengatur warna font
		port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
		port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
		port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

		// Menyimpan PPTX ke disk
		pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Atur Properti Font Teks**
{{% alert color="primary" %}} 

Seperti disebutkan dalam **Kelola Properti Terkait Font**, sebuah [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) digunakan untuk menampung teks dengan gaya pemformatan serupa dalam sebuah paragraf. Artikel ini menunjukkan cara menggunakan Aspose.Slides for Android via Java untuk membuat kotak teks dengan beberapa teks dan kemudian menentukan font tertentu, serta berbagai properti lain dari kategori keluarga font.

{{% /alert %}} 

Untuk membuat kotak teks dan mengatur properti font teks di dalamnya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation).
1. Dapatkan referensi slide dengan menggunakan indeksnya.
1. Tambahkan [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/) dengan tipe **Rectangle** ke slide.
1. Hapus gaya isi yang terkait dengan [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/).
1. Akses [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/) dari [AutoShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/autoshape/).
1. Tambahkan beberapa teks ke [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/).
1. Akses objek [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/) yang terkait dengan [TextFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/textframe/).
1. Tentukan font yang akan digunakan untuk [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/).
1. Atur properti font lainnya seperti tebal, miring, garis bawah, warna, dan tinggi menggunakan properti yang relevan yang disediakan oleh objek [Portion](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/portion/).
1. Tulis presentasi yang telah diubah sebagai file PPTX.

Implementasi langkah-langkah di atas diberikan di bawah ini.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Gambar: Teks dengan beberapa properti font yang diatur oleh Aspose.Slides for Android via Java**|

```java
// Membuat objek Presentation yang merepresentasikan file PPTX
Presentation pres = new Presentation();
try {
	// Dapatkan slide pertama
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Tambahkan AutoShape dengan tipe Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Hapus semua gaya isi yang terkait dengan AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Akses TextFrame yang terkait dengan AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Akses Portion yang terkait dengan TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Atur Font untuk Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Atur properti Bold pada Font
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Atur properti Italic pada Font
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Atur properti Underline pada Font
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Atur Tinggi Font
	port.getPortionFormat().setFontHeight(25);
	
	// Atur warna Font
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Simpan presentasi ke disk
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```