---
title: Optimalkan Manajemen Gambar dalam Presentasi di Android
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/androidjava/image/
keywords:
- tambahkan gambar
- tambahkan foto
- tambahkan bitmap
- ganti gambar
- ganti foto
- dari web
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- tambahkan EMF
- tambahkan WMF
- tambahkan TIFF
- PowerPoint
- OpenDocument
- presentasi
- Android
- Java
- Aspose.Slides
description: "Permudah manajemen gambar di PowerPoint dan OpenDocument dengan Aspose.Slides untuk Android melalui Java, mengoptimalkan kinerja dan mengotomatiskan alur kerja Anda."
---
## **Pendahuluan**

Gambar membuat presentasi lebih menarik dan menyenangkan. Di Microsoft PowerPoint, Anda dapat menyisipkan gambar dari file, internet, atau lokasi lain ke dalam slide. Demikian pula, Aspose.Slides memungkinkan Anda menambahkan gambar ke slide dalam presentasi melalui berbagai prosedur. 

{{% alert  title="Tip" color="primary" %}} 

Aspose menyediakan konverter gratis—[JPEG to PowerPoint](https://products.aspose.app/slides/id/import/jpg-to-ppt) dan [PNG to PowerPoint](https://products.aspose.app/slides/id/import/png-to-ppt)—yang memungkinkan orang membuat presentasi dengan cepat dari gambar. 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

Jika Anda ingin menambahkan gambar sebagai objek bingkai—terutama jika Anda berencana menggunakan opsi pemformatan standar untuk mengubah ukurannya, menambahkan efek, dan sebagainya—lihat [Picture Frame](https://docs.aspose.com/slides/id/androidjava/picture-frame/).

{{% /alert %}} 

Aspose.Slides mendukung operasi dengan gambar dalam format populer berikut: JPEG, PNG, GIF, dan lainnya. 

## **Menambahkan Gambar yang Disimpan Secara Lokal ke Slide**

Anda dapat menambahkan satu atau beberapa gambar dari komputer Anda ke slide dalam sebuah presentasi. Kode contoh ini dalam Java menunjukkan cara menambahkan gambar ke slide:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
	slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Menambahkan Gambar dari Web ke Slide**

Jika gambar yang ingin Anda tambahkan ke slide tidak tersedia di komputer Anda, Anda dapat menambahkan gambar tersebut langsung dari web.

Kode contoh ini menunjukkan cara menambahkan gambar dari web ke slide dalam Java:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);

	URL imageUrl = new URL("[REPLACE WITH URL]");
	URLConnection connection = imageUrl.openConnection();
	InputStream inputStream = connection.getInputStream();

	ByteArrayOutputStream outputStream = new ByteArrayOutputStream();
	try {
		byte[] buffer = new byte[1024];
		int read;

		while ((read = inputStream.read(buffer, 0, buffer.length)) != -1)
			outputStream.write(buffer, 0, read);

		outputStream.flush();

		IPPImage image = pres.getImages().addImage(outputStream.toByteArray());
		slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
	} finally {
		if (inputStream != null) inputStream.close();
		outputStream.close();
	}

	pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Menambahkan Gambar ke Slide Master**

Slide master adalah slide utama yang menyimpan dan mengontrol informasi (tema, tata letak, dll.) tentang semua slide di bawahnya. Jadi, ketika Anda menambahkan gambar ke slide master, gambar tersebut muncul di setiap slide di bawah slide master tersebut. 

Kode contoh Java ini menunjukkan cara menambahkan gambar ke slide master:

```java
Presentation pres = new Presentation();
try {
	ISlide slide = pres.getSlides().get_Item(0);
	IMasterSlide masterSlide = slide.getLayoutSlide().getMasterSlide();

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
	masterSlide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

	pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Menambahkan Gambar sebagai Latar Belakang Slide**

Anda mungkin memutuskan untuk menggunakan gambar sebagai latar belakang untuk satu slide tertentu atau beberapa slide. Dalam hal ini, Anda harus melihat *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/id/androidjava/presentation-background/#setting-images-as-background-for-slides)*.

## **Menambahkan SVG ke Presentasi**
Anda dapat menambahkan atau menyisipkan gambar apa pun ke dalam presentasi dengan menggunakan metode [addPictureFrame](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) yang merupakan bagian dari antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection).

Untuk membuat objek gambar berdasarkan gambar SVG, Anda dapat melakukannya dengan cara berikut:

1. Buat objek SvgImage untuk menyisipkannya ke ImageShapeCollection
2. Buat objek PPImage dari ISvgImage
3. Buat objek PictureFrame menggunakan antarmuka IPPImage

Kode contoh ini menunjukkan cara menerapkan langkah-langkah di atas untuk menambahkan gambar SVG ke dalam presentasi:
```java 
// Instansiasi kelas Presentation yang mewakili file PPTX
Presentation pres = new Presentation();
try {
    String svgContent = new String(Files.readAllBytes(Paths.get("image.svg")));
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage ppImage = pres.getImages().addImage(svgImage);
    pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 
			ppImage.getWidth(), ppImage.getHeight(), ppImage);
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengonversi SVG menjadi Sekumpulan Bentuk**
Konversi SVG menjadi sekumpulan bentuk pada Aspose.Slides mirip dengan fungsi PowerPoint yang digunakan untuk bekerja dengan gambar SVG:

![PowerPoint Popup Menu](img_01_01.png)

Fungsi ini disediakan oleh salah satu overload dari metode [addGroupShape](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection#addGroupShape-com.aspose.slides.ISvgImage-float-float-float-float-) pada antarmuka [IShapeCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/IShapeCollection) yang menerima objek [ISvgImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/ISvgImage) sebagai argumen pertama.

Kode contoh ini menunjukkan cara menggunakan metode yang dijelaskan untuk mengonversi file SVG menjadi sekumpulan bentuk:

```java 
// Buat presentasi baru
IPresentation presentation = new Presentation();
try {
    // Baca konten file SVG
    byte[] svgContent = Files.readAllBytes(Paths.get("image.svg"));

    // Buat objek SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Dapatkan ukuran slide
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    // Konversi gambar SVG menjadi grup bentuk dan skala ke ukuran slide
    presentation.getSlides().get_Item(0).getShapes().
            addGroupShape(svgImage, 0f, 0f, (float)slideSize.getWidth(), (float)slideSize.getHeight());

    // Simpan presentasi dalam format PPTX
    presentation.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Menambahkan Gambar sebagai EMF ke Slide**
Aspose.Slides untuk Android melalui Java memungkinkan Anda menghasilkan gambar EMF dari lembar Excel dan menambahkan gambar tersebut sebagai EMF pada slide dengan Aspose.Cells. 

Kode contoh ini menunjukkan cara melakukan tugas yang dijelaskan:

```java 
Workbook book = new Workbook("chart.xlsx");
Worksheet sheet = book.getWorksheets().get(0);
ImageOrPrintOptions options = new ImageOrPrintOptions();
options.setHorizontalResolution(200);
options.setVerticalResolution(200);
options.setImageType(ImageType.EMF);

//Simpan workbook ke aliran
SheetRender sr = new SheetRender(sheet, options);
Presentation pres = new Presentation();
try {
    pres.getSlides().removeAt(0);
    
    String EmfSheetName = "";
    for (int j = 0; j < sr.getPageCount(); j++)
    {
    
        EmfSheetName = "test" + sheet.getName() + " Page" + (j + 1) + ".out.emf";
        sr.toImage(j, EmfSheetName);

        IPPImage picture;
        IImage image = Images.fromFile(EmfSheetName);
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
        ISlide slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().getByType(SlideLayoutType.Blank));
        IShape m = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0,
					(float)pres.getSlideSize().getSize().getWidth(), 
					(float)pres.getSlideSize().getSize().getHeight(), 
					picture);
    }
    
    pres.save("output.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Mengganti Gambar dalam Image Collection**

Aspose.Slides memungkinkan Anda mengganti gambar yang disimpan dalam koleksi gambar presentasi (termasuk yang digunakan oleh bentuk slide). Bagian ini menunjukkan beberapa pendekatan untuk memperbarui gambar dalam koleksi. API menyediakan metode sederhana untuk mengganti gambar menggunakan data byte mentah, instance [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) , atau gambar lain yang sudah ada dalam koleksi.

Ikuti langkah-langkah berikut:

1. Muat file presentasi yang berisi gambar menggunakan kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/presentation/).
1. Muat gambar baru dari file ke dalam array byte.
1. Ganti gambar target dengan gambar baru menggunakan array byte.
1. Pada pendekatan kedua, muat gambar ke dalam objek [IImage](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/iimage/) dan ganti gambar target dengan objek tersebut.
1. Pada pendekatan ketiga, ganti gambar target dengan gambar yang sudah ada dalam koleksi gambar presentasi.
1. Tuliskan presentasi yang telah dimodifikasi sebagai file PPTX.

```java
// Instansiasi kelas Presentation yang mewakili file presentasi.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Cara pertama.
    IImage imageData = Images.fromStream(new FileInputStream("image0.jpeg"));
    IPPImage oldImage = presentation.getImages().get_Item(0);
    oldImage.replaceImage(imageData);
    
    // Cara kedua.
    IImage newImage = Images.fromFile("image1.png");
    oldImage = presentation.getImages().get_Item(1);
    oldImage.replaceImage(newImage);
    newImage.dispose();
    
    // Cara ketiga.
    oldImage = presentation.getImages().get_Item(2);
    oldImage.replaceImage(presentation.getImages().get_Item(3));
    
    // Simpan presentasi ke file.
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}

Dengan menggunakan konverter GRATIS Aspose [Text to GIF](https://products.aspose.app/slides/id/text-to-gif), Anda dapat dengan mudah menganimasikan teks, membuat GIF dari teks, dll. 

{{% /alert %}}

## **FAQ**

**Apakah resolusi gambar asli tetap utuh setelah disisipkan?**

Ya. Piksel sumber tetap dipertahankan, namun tampilan akhir tergantung pada bagaimana [picture](/slides/id/androidjava/picture-frame/) diskalakan pada slide dan kompresi apa pun yang diterapkan saat menyimpan.

**Apa cara terbaik untuk mengganti logo yang sama di puluhan slide sekaligus?**

Letakkan logo pada slide master atau tata letak dan ganti di dalam koleksi gambar presentasi—perubahan akan menyebar ke semua elemen yang menggunakan sumber daya tersebut.

**Apakah SVG yang disisipkan dapat dikonversi menjadi bentuk yang dapat diedit?**

Ya. Anda dapat mengonversi SVG menjadi sekumpulan bentuk, setelah itu bagian-bagian individual menjadi dapat diedit dengan properti bentuk standar.

**Bagaimana cara mengatur gambar sebagai latar belakang untuk beberapa slide sekaligus?**

[Tetapkan gambar sebagai latar belakang](/slides/id/androidjava/presentation-background/) pada slide master atau tata letak yang relevan—setiap slide yang menggunakan master/tata letak tersebut akan mewarisi latar belakang.

**Bagaimana saya mencegah presentasi menjadi sangat besar karena banyak gambar?**

Gunakan kembali satu sumber gambar daripada duplikat, pilih resolusi yang wajar, terapkan kompresi saat menyimpan, dan letakkan grafik yang berulang pada master bila diperlukan.