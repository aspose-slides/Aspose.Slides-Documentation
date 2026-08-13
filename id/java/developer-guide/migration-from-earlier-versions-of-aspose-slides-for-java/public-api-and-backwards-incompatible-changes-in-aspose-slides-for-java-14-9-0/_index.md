---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 14.9.0
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
description: "Tinjau pembaruan API publik dan perubahan yang merusak di Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan lancar."
---
{{% alert color="info" %}} 

Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), pembatasan baru, dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) lain yang diperkenalkan dengan API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Perubahan API Publik**
### **Metode yang Ditambahkan untuk Mengganti Gambar menjadi PPImage, IPPImage**
Metode baru yang ditambahkan:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Cara pertama
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Cara kedua
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Metode yang Ditambahkan untuk Menyimpan Slide dengan Menjaga Nomor Halaman**
Metode-metode berikut telah ditambahkan:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Metode ini memungkinkan menyimpan slide presentasi tertentu ke format PDF, XPS, TIFF, HTML. Array `slides` memungkinkan menentukan nomor halaman, mulai dari 1.

``` java
// Overload yang ditambahkan ke IPresentation (nilai SaveFormat adalah konstanta int di Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Array posisi slide

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Menambahkan Nilai Enum SmartArtLayoutType.Custom**
Jenis tata letak SmartArt ini mewakili diagram dengan templat khusus. Diagram khusus hanya dapat dimuat dari file presentasi dan tidak dapat dibuat melalui metode `ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)`.

### **Menambahkan Kelas SmartArtShape dan Antarmuka ISmartArtShape**
Kelas `Aspose.Slides.SmartArt.SmartArtShape` (dan antarmukanya `Aspose.Slides.SmartArt.ISmartArtShape`) menyediakan akses ke bentuk individu di dalam diagram SmartArt. `SmartArtShape` dapat digunakan untuk mengubah `FillFormat`, `LineFormat`, menambahkan hyperlink, dll.

{{% alert color="info" %}} 

SmartArtShape tidak mendukung properti IShape `RawFrame`, `Frame`, `Rotation`, `X`, `Y`, `Width`, `Height` dan akan melempar `System.NotSupportedException` saat mencoba mengaksesnya.

{{% /alert %}} 

Contoh penggunaan:

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **Kelas SmartArtShapeCollection, Antarmuka ISmartArtShapeCollection, dan Metode ISmartArtNode.getShapes() telah ditambahkan**
Kelas `Aspose.Slides.SmartArt.SmartArtShapeCollection` (dan antarmukanya `Aspose.Slides.SmartArt.ISmartArtShapeCollection`) menyediakan akses ke bentuk individu di dalam diagram SmartArt. Koleksi berisi bentuk-bentuk yang terkait dengan `SmartArtNode`. Properti `SmartArtNode.Shapes` mengembalikan koleksi semua bentuk yang terkait dengan node tersebut.

{{% alert color="info" %}} 

Tergantung pada `SmartArtLayoutType`, satu `SmartArtShape` dapat dibagikan antara beberapa node.

{{% /alert %}} 

 

``` java
import com.aspose.slides.*;
import java.awt.Color;


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