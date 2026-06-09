---
title: Aspose.Slides for Java 14.9.0'da Genel API ve Geriye Dönük Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- göç
- eski kod
- modern kod
- eski yaklaşım
- modern yaklaşım
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 
Bu sayfa, Aspose.Slides for Java 14.9.0 API'siyle tanıtılan tüm [eklenmiş](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) sınıfları, metodları, özellikleri ve benzerlerini, yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) listeler.
{{% /alert %}} 
## **Public API Changes**
### **PPImage, IPPImage İçin Görüntü Değiştirmeye Yönelik Eklenen Metodlar**
Yeni eklenen metodlar:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//İlk yol

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//İkinci yol

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Sayfa Numaralarını Koruyarak Slaytları Kaydetmeye Yönelik Eklenen Metodlar**
Aşağıdaki metodlar eklendi:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Bu metodlar, belirtilen sunum slaytlarını PDF, XPS, TIFF, HTML formatlarında kaydetmeye olanak tanır. 'slides' dizisi, 1'den başlayan sayfa numaralarını belirtmek için kullanılır.

``` java

 save(string fname, int[] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Slayt konumlarının dizisi

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **SmartArtLayoutType.Custom Enum Değeri Eklendi**
Bu SmartArt düzeni türü, özel şablonlu bir diyagramı temsil eder. Özel diyagramlar yalnızca sunum dosyasından yüklenebilir ve ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) metodu ile oluşturulamaz.
### **SmartArtShape Sınıfı ve ISmartArtShape Arayüzü Eklendi**
Aspose.Slides.SmartArt.SmartArtShape sınıfı (ve arayüzü Aspose.Slides.SmartArt.ISmartArtShape), SmartArt diyagramı içindeki bireysel şekillere erişim sağlar. SmartArtShape, FillFormat, LineFormat değiştirmek, köprü eklemek vb. için kullanılabilir.

{{% alert color="primary" %}} 
SmartArtShape, IShape özellikleri RawFrame, Frame, Rotation, X, Y, Width, Height'ı desteklemez ve bunlara erişilmeye çalışıldığında System.NotSupportedException fırlatır.
{{% /alert %}} 
Kullanım örneği:

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
### **SmartArtShapeCollection Sınıfı, ISmartArtShapeCollection Arayüzü ve ISmartArtNode.getShapes() Metodu Eklendi**
Aspose.Slides.SmartArt.SmartArtShapeCollection sınıfı (ve arayüzü Aspose.Slides.SmartArt.ISmartArtShapeCollection), SmartArt diyagramı içindeki bireysel şekillere erişim sağlar. Koleksiyon, SmartArtNode ile ilişkili şekilleri içerir. SmartArtNode.Shapes özelliği, düğümle ilişkili tüm şekillerin koleksiyonunu döndürür.

{{% alert color="primary" %}} 
SmartArtLayoutType'a bağlı olarak, bir SmartArtShape birden fazla düğüm arasında paylaşılabilir.
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