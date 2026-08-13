---
title: Aspose.Slides for Java 14.9.0'da Kamu API'sı ve Geriye Uyumsuz Değişiklikler
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
description: "Aspose.Slides for Java'daki kamu API güncellemelerini ve geriye uyumsuz değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 14.9.0 API'sı ile tanıtılan tüm [eklenmiş](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) sınıfları, yöntemleri, özellikleri vb., yeni kısıtlamaları ve diğer [değişiklikler](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) listeler.

{{% /alert %}} 
## **Kamu API Değişiklikleri**
### **PPImage, IPPImage İçin Görüntü Değiştirme Yöntemleri Eklendi**
Yeni eklenen yöntemler:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // İlk yöntem
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // İkinci yöntem
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Sayfa Numaralarını Koruyarak Slaytları Kaydetme Yöntemleri Eklendi**
Aşağıdaki yöntemler eklendi:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Bu yöntemler, belirtilen sunum slaytlarını PDF, XPS, TIFF, HTML formatlarında kaydetmeye olanak tanır. 'slides' dizisi, sayfa numaralarını 1'den başlayarak belirtmeye izin verir.

``` java
// IPresentation'a eklenen aşırı yüklemeler (SaveFormat değerleri Java'da int sabitleridir):
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
    int[] slides = new int[] { 2, 3, 5 }; // Slayt konumlarının dizisi

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **SmartArtLayoutType.Custom Enum Değeri Eklendi**
Bu SmartArt düzeni türü, özel şablonlu diyagramı temsil eder. Özel diyagramlar yalnızca sunum dosyasından yüklenebilir ve ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) yöntemiyle oluşturulamaz.
### **SmartArtShape Sınıfı ve ISmartArtShape Arayüzü Eklendi**
Aspose.Slides.SmartArt.SmartArtShape sınıfı (ve Aspose.Slides.SmartArt.ISmartArtShape arayüzü) SmartArt diyagramı içindeki bireysel şekillere erişim sağlar. SmartArtShape, FillFormat, LineFormat değiştirme, Hipermetin ekleme vb. için kullanılabilir.

{{% alert color="info" %}} 

SmartArtShape, IShape özellikleri RawFrame, Frame, Rotation, X, Y, Width, Height'ı desteklemez ve bunlara erişilmeye çalışıldığında System.NotSupportedException fırlatır.

{{% /alert %}} 

Kullanım örneği:

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
### **SmartArtShapeCollection sınıfı, ISmartArtShapeCollection arayüzü ve ISmartArtNode.getShapes() yöntemi eklendi**
Aspose.Slides.SmartArt.SmartArtShapeCollection sınıfı (ve Aspose.Slides.SmartArt.ISmartArtShapeCollection arayüzü) SmartArt diyagramı içindeki bireysel şekillere erişim sağlar. Koleksiyon, SmartArtNode ile ilişkili şekilleri içerir. SmartArtNode.Shapes özelliği, düğümle ilişkili tüm şekillerin koleksiyonunu döndürür.

{{% alert color="info" %}} 

SmartArtLayoutType'a bağlı olarak bir SmartArtShape birden fazla düğüm arasında paylaşılabilir.

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