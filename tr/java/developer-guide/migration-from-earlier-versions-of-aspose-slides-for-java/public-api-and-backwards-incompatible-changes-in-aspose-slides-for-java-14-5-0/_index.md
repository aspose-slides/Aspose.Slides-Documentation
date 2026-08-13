---
title: Aspose.Slides for Java 14.5.0'da Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 14.5.0
type: docs
weight: 40
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
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
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırılma değişikliklerini inceleyin ve PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="info" %}} 
Bu sayfa, Aspose.Slides for Java 14.5.0 API'siyle tanıtılan eklenmiş tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) sınıfları, yöntemleri, özellikleri ve benzeri, yeni [kısıtlamalar](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) ve diğer [değişiklikler](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) listeler.

{{% /alert %}} 
## **Public API ve Geriye Uyumsuz Değişiklikler**
### **Eklenen Sınıflar ve Yöntemler**
#### **Aspose.Slides.IPresentationInfo arabirimi ve PresentationInfo Sınıfları Eklendi**
Sunum hakkında bilgi temsil eder.

Method Boolean isEncrypted() gets True if a presentation is encrypted, otherwise gets False.

Method LoadFormat getLoadFormat() gets the presentation type.
#### **Aspose.Slides.IShape.isGrouped() Yöntemi Eklendi**
Aspose.Slides.IShape.isGrouped() yöntemi şeklin gruplandırılmış olup olmadığını belirler.
#### **Aspose.Slides.IShape.getParentGroup() Yöntemi Eklendi**
Aspose.Slides.IShape.getParentGroup() yöntemi şekil gruplandırılmışsa üst GroupShape nesnesini döndürür. Aksi takdirde null döndürür.
#### **Aspose.Slides.IShapeCollection.addGroupShape() Yöntemi Eklendi**
Aspose.Slides.IShapeCollection.addGroupShape() yöntemi yeni bir GroupShape oluşturur ve koleksiyonun sonuna ekler.

Yeni şekil GroupShape içine eklendiğinde GroupShape çerçeve boyutu ve konumu içeriğe uyacak şekilde ayarlanır.
#### **Aspose.Slides.IShapeCollection.clear() Yöntemi Eklendi**
Aspose.Slides.IShapeCollection.clear() yöntemi koleksiyondaki tüm şekilleri kaldırır.
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int) Yöntemi Eklendi**
Aspose.Slides.IShapeCollection.insertGroupShape(int) yöntemi yeni bir GroupShape oluşturur ve belirtilen indekste koleksiyona ekler.
GroupShape çerçeve boyutu ve konumu yeni şekil GroupShape içine eklendiğinde içeriğe uyacak şekilde ayarlanır.
#### **IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream) Yöntemleri Eklendi**
Bu yöntemler geliştiricilerin tam sunum yüklemesi yapmadan bir sunum dosyası/akışı hakkında bilgi almasını sağlar.
#### **IPresentationFactory PresentationFactory.getInstance() Yöntemi Eklendi**
Örneklendirme yapmadan fabrika işlevselliğini kullanmaya olanak tanır.
### **Kısıtlamalar**
#### **IShape.getFrame() için tanımsız değerlerin kullanılmasına kısıtlamalar getirildi**
IShape.setFrame(IShapeFrame) metoduna tanımsız bir çerçeve atamaya çalışan kod genel durumlarda mantıklı değildir (özellikle üst GroupShape birden çok {{GroupShape}} içinde iç içe olduğunda). Örneğin:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // ArgumentException hatası fırlatır: çerçeve değerleri tanımlı olmalıdır.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

veya

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // ArgumentException hatası fırlatır: x, y, genişlik ve yükseklik değerleri tanımlı olmalıdır.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Bu tür kodlar belirsiz durumlara yol açabilir. Bu nedenle IShape.Frame için tanımsız değerlerin kullanımı kısıtlanmıştır. x, y, width, height, flipH, flipV ve rotationAngle değerleri tanımlı olmalıdır (Float.NaN veya NullableBool.NotDefined olmamalı). Yukarıdaki örnek kod artık ArgumentException hatası fırlatır.
Bu aşağıdaki kullanım senaryolarına uygulanır:

``` java
// IShape.setFrame(IShapeFrame) metoduna gönderilen çerçeve tanımsız değerler içeremez.

// Aşağıdaki IShapeCollection metodlarının x, y, genişlik ve yükseklik parametreleri
// Float.NaN de olamaz:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Ancak IShape.getRawFrame() çerçevesi tanımsız olabilir. Bu, bir şeklin bir yer tutucuya bağlandığı durumlarda mantıklıdır. Bu durumda tanımsız şekil çerçeve değerleri üst yer tutucu şekilden devralınır. Eğer o şekil için üst bir yer tutucu yoksa IShape.getRawFrame() temel alınarak etkili çerçeve değerlendirilirken varsayılan değerler kullanılır. Varsayılan değerler x, y, width, height, flipH, flipV ve rotationAngle için sırasıyla 0 ve NullableBool.False'tur. Örneğin:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Şekil bir yer tutucuya bağlanmıştır.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Şimdi şekil, x, y, yükseklik, flipH ve flipV değerlerini yer tutucudan miras alır
    // ve genişlik = 100 ile rotationAngle = 0 değerlerini geçersiz kılar.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Değiştirilen Özellikler**
#### **Aspose.Slides.IShapeCollection.getParent() Yönteminin Tipi ve Adı Değiştirildi**
Aspose.Slides.IShapeCollection.Parent özelliğinin tipi ISlideComponent'ten yeni IGroupShape arabirimine değiştirildi. IGroupShape arabirimi ISlideComponent'in bir türevidir, bu nedenle mevcut kodun uyarlanmasına gerek yoktur.

Aspose.Slides.IShapeCollection.getParent() metodunun adı getParent'dan getParentGroup() olarak değiştirildi.
#### **Aspose.Slides.IShapeFrame.getFlipH() ve .getFlipV() Yöntemlerinin Tipi Değiştirildi**
Aspose.Slides.IShapeFrame.getFlipH() metodunun tipi bool'tan NullableBool'a değiştirildi.

IShape.getFrame() yöntemi, tüm özellikleri tanımlı etkili değerler içeren IShapeFrame'in etkili örneğini döndürür.

IShape.getRawFrame() yöntemi, her özelliğin tanımsız değer alabileceği (özellikle FlipH veya FlipV NullableBool.NotDefined olabilen) bir IShapeFrame örneği döndürür.