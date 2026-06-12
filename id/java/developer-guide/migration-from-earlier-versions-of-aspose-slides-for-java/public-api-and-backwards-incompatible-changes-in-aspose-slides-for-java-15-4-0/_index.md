---
title: API Publik dan Perubahan Tidak Kompatibel Mundur di Aspose.Slides untuk Java 15.4.0
linktitle: Aspose.Slides untuk Java 15.4.0
type: docs
weight: 120
url: /id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
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
description: "Tinjau pembaruan API publik dan perubahan yang memutuskan dalam Aspose.Slides untuk Java untuk memigrasikan solusi presentasi PowerPoint PPT, PPTX, dan ODP Anda dengan mulus."
---
{{% alert color="primary" %}} 
Halaman ini mencantumkan semua kelas, metode, properti, dan sebagainya yang [ditambahkan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) serta semua pembatasan baru, dan [perubahan](/slides/id/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) yang diperkenalkan dengan API Aspose.Slides for Java 15.4.0.
{{% /alert %}} 
## **Perubahan API Publik**
### **Enum OrganizationChartLayoutType telah ditambahkan**
Enum com.aspose.slides.OrganizationChartLayoutType mewakili jenis format untuk node anak dalam diagram organisasi.
### **Metode IBulletFormat.applyDefaultParagraphIndentsShifts() telah ditambahkan**
Metode com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts menetapkan pergeseran default non-zero untuk Indent paragraf dan MarginLeft yang efektif ketika bullet diaktifkan (seperti yang dilakukan PowerPoint bila mengaktifkan bullet/penomoran paragraf). Jika bullet dinonaktifkan, maka hanya mengatur ulang Indent paragraf dan MarginLeft (seperti yang dilakukan PowerPoint bila menonaktifkan bullet/penomoran paragraf).
### **Metode IConnector.reroute() telah ditambahkan**
Metode com.aspose.slides.IConnector.reroute() mengarahkan ulang konektor sehingga mengambil jalur terpendek antara bentuk yang dihubungkannya. Untuk melakukan ini, metode reroute() dapat mengubah StartShapeConnectionSiteIndex dan EndShapeConnectionSiteIndex.
``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Metode IPresentation.getSlideById(long) telah ditambahkan**
Metode Aspose.Slides.IPresentation.getSlideById(int) mengembalikan Slide, MasterSlide, atau LayoutSlide berdasarkan Id slide.
``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Metode ISmartArt.getNodes() telah ditambahkan**
Metode com.aspose.slides.ISmartArt.getNodes() mengembalikan koleksi node akar dalam objek SmartArt.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // pilih node akar kedua

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metode ISmartArt.setLayout(int) telah ditambahkan**
Metode untuk properti com.aspose.slides.ISmartArt.setLayout(int) telah ditambahkan. Ini memungkinkan mengubah tipe tata letak diagram yang ada.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Metode ISmartArtNode.isHidden() telah ditambahkan**
Metode com.aspose.slides.ISmartArtNode.isHidden() mengembalikan true jika node ini adalah node tersembunyi dalam model data.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //mengembalikan true

if(hidden) {

    //lakukan beberapa aksi atau notifikasi

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Metode ISmartArt.isReversed() dan setReserved() telah ditambahkan**
Properti com.aspose.slides.ISmartArt.IsReversed memungkinkan mendapatkan atau mengatur keadaan diagram SmartArt terkait arah (kiri-ke-kanan) LTR atau (kanan-ke-kiri) RTL, jika diagram mendukung pembalikan.
``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Metode ISmartArtNode.getOrganizationChartLayout() dan setOrganizationChartLayout(int) telah ditambahkan**
Metode com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() dan setOrganizationChartLayout(int) memungkinkan mendapatkan atau mengatur tipe diagram organisasi yang terkait dengan node saat ini.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Properti IShape.getConnectionSiteCount() telah ditambahkan**
Properti com.aspose.slides.getConnectionSiteCount() mengembalikan jumlah situs koneksi pada shape.
``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **Perubahan Minor**
Berikut ini daftar perubahan API minor:

|Enum com.aspose.slides.BevelColorMode |dihapus, enum tidak digunakan |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |dihapus, properti tidak digunakan |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |ditambahkan |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |dihapus |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |dihapus karena usang |