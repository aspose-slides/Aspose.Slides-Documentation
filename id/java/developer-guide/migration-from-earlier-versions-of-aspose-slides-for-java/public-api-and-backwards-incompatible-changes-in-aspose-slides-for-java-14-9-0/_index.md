---
title: API Publik dan Perubahan Tidak Kompatibel Mundur pada Aspose.Slides untuk Java 14.9.0
linktitle: Aspose.Slides untuk Java 14.9.0
type: docs
weight: 80
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- migrasi
- kode warisan
- kode modern
- pendekatan warisan
- pendekatan modern
- PowerPoint
- OpenDocument
- presentasi
- Java
- Aspose.Slides
description: "Tinjau pembaruan API publik dan perubahan yang memutuskan pada Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="primary" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), serta pembatasan baru dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) yang diperkenalkan dengan API Aspose.Slides untuk Java 14.9.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **Metode yang Ditambahkan untuk Mengganti Gambar menjadi PPImage, IPPImage**
Metode baru yang ditambahkan:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Cara pertama

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Cara kedua

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Metode yang Ditambahkan untuk Menyimpan Slide dengan Menjaga Nomor Halaman**
Metode berikut telah ditambahkan:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Metode-metode ini memungkinkan menyimpan slide presentasi tertentu ke dalam format PDF, XPS, TIFF, HTML. Array 'slides' memungkinkan menentukan nomor halaman, mulai dari 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Array posisi slide

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Menambahkan Nilai Enum SmartArtLayoutType.Custom**
Tipe tata letak SmartArt ini mewakili diagram dengan templat khusus. Diagram khusus hanya dapat dimuat dari file presentasi dan tidak dapat dibuat melalui metode ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Menambahkan Kelas SmartArtShape dan Antarmuka ISmartArtShape**
Kelas Aspose.Slides.SmartArt.SmartArtShape (dan antarmukanya Aspose.Slides.SmartArt.ISmartArtShape) menambahkan akses ke bentuk individual di dalam diagram SmartArt. SmartArtShape dapat digunakan untuk mengubah FillFormat, LineFormat, menambahkan Hyperlink, dll.

{{% alert color="primary" %}} 

SmartArtShape tidak mendukung properti IShape RawFrame, Frame, Rotation, X, Y, Width, Height dan akan mengeluarkan System.NotSupportedException ketika mencoba mengaksesnya.

{{% /alert %}} 

Contoh penggunaan:

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Menambahkan kelas SmartArtShapeCollection, antarmuka ISmartArtShapeCollection, dan metode ISmartArtNode.getShapes()**
Kelas Aspose.Slides.SmartArt.SmartArtShapeCollection (dan antarmukanya Aspose.Slides.SmartArt.ISmartArtShapeCollection) menambahkan akses ke bentuk individual di dalam diagram SmartArt. Koleksi berisi bentuk-bentuk yang terkait dengan SmartArtNode. Properti SmartArtNode.Shapes mengembalikan koleksi semua bentuk yang terkait dengan node tersebut.

{{% alert color="primary" %}} 

Bergantung pada SmartArtLayoutType, satu SmartArtShape dapat dibagikan di antara beberapa node.

{{% /alert %}} 

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```