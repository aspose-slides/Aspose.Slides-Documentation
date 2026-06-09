---
title: Aspose.Slides for Java 14.5.0'da Genel API ve Geriye Uyumlu Olmayan Değişiklikler
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılma değişikliklerini inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizi sorunsuz bir şekilde taşıyın."
---
{{% alert color="primary" %}} 

Bu sayfa, Aspose.Slides for Java 14.5.0 API'siyle tanıtılan tüm [added](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) sınıfları, metodları, özellikleri vb., yeni [restrictions](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) ve diğer [changes](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) listeler.

{{% /alert %}} 
## **Genel API ve Geriye Uyumsuz Değişiklikler**
### **Eklenen Sınıflar ve Metodlar**
#### **Aspose.Slides.IPresentationInfo arabirimi ve PresentationInfo Sınıfları eklendi**
Sunum hakkında bilgi temsil eder.

Method Boolean isEncrypted() bir sunum şifreliyse True, aksi takdirde False döndürür.

Method LoadFormat getLoadFormat() sunum tipini döndürür.
#### **Aspose.Slides.IShape.isGrouped() Metodu eklendi**
Aspose.Slides.IShape.isGrouped() metodu, şeklin gruplanıp gruplanmadığını belirler.
#### **Aspose.Slides.IShape.getParentGroup() Metodu eklendi**
Aspose.Slides.IShape.getParentGroup() metodu, şekil gruplanmışsa üst GroupShape nesnesini döndürür. Aksi takdirde null döndürür.
#### **Aspose.Slides.IShapeCollection.addGroupShape() Metodu eklendi**
Aspose.Slides.IShapeCollection.addGroupShape() metodu yeni bir GroupShape oluşturur ve koleksiyonun sonuna ekler.

Yeni bir şekil GroupShape içine eklendiğinde GroupShape çerçeve boyutu ve konumu içeriğe göre ayarlanır.
#### **Aspose.Slides.IShapeCollection.clear() Metodu eklendi**
Aspose.Slides.IShapeCollection.clear() metodu, koleksiyondaki tüm şekilleri kaldırır.
#### **Aspose.Slides.IShapeCollection.insertGroupShape(int) Metodu eklendi**
Aspose.Slides.IShapeCollection.insertGroupShape(int) metodu yeni bir GroupShape oluşturur ve belirtilen indekste koleksiyona ekler.
GroupShape çerçeve boyutu ve konumu, yeni şekil GroupShape içine eklendiğinde içeriğe göre ayarlanır.
#### **IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream) Metodları eklendi**
Bu metodlar, tam sunum yüklemesi yapmadan bir sunum dosyası/akışı hakkında bilgi almayı sağlar.
#### **IPresentationFactory PresentationFactory.getInstance() Metodu eklendi**
Fabrika işlevselliğini örnek yaratmadan kullanmaya imkan tanır.
### **Kısıtlamalar**
#### **IShape.getFrame() için belirsiz değerlerin kullanımıyla ilgili kısıtlamalar eklendi**
IShape.setFrame(IShapeFrame) yöntemine belirsiz bir çerçeve atamaya çalışan kod, özellikle üst GroupShape birden fazla {{GroupShape}} içinde iç içe geçmişse, genel durumlarda mantıksızdır. Örneğin:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

veya

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Bu tür kodlar belirsiz durumlara yol açabilir. Bu yüzden IShape.Frame için belirsiz değerlerin kullanımıyla ilgili kısıtlamalar getirildi. x, y, width, height, flipH, flipV ve rotationAngle değerlerinin tanımlı (Float.NaN veya NullableBool.NotDefined olmamalı) olması gerekir. Yukarıdaki örnek kod artık ArgumentException hatası verir.
Bu, aşağıdaki kullanım durumlarına uygulanır:

``` java

 IShape shape = ...;

shape.setFrame(...); // tanımsız olamaz

IShapeCollection shapes = ...;

// x, y, width, height parametreleri Float.NaN olamaz:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}
```

Ancak IShape.getRawFrame() çerçevesi belirsiz olabilir. Bu, bir şeklin bir yer tutucuya bağlı olduğu durumlarda mantıklıdır. O zaman belirsiz şekil çerçeve değerleri üst yer tutucu şekilden devralınır. Eğer o şekil için bir üst yer tutucu yoksa, IShape.getRawFrame() üzerinden etkili çerçeve hesaplanırken varsayılan değerler kullanılır. Varsayılan değerler x, y, width, height, flipH, flipV ve rotationAngle için sırasıyla 0 ve NullableBool.False’tur. Örneğin:

``` java

 IShape shape = ...; // şekil yer tutucuya bağlıdır

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// şimdi şekil x, y, yükseklik, flipH, flipV değerlerini yer tutucudan devralır ve width=100 ve rotationAngle=0 değerlerini geçersiz kılar.

```
### **Değiştirilen Özellikler**
#### **Aspose.Slides.IShapeCollection.getParent() Metodunun Türü ve Adı Değiştirildi**
Aspose.Slides.IShapeCollection.Parent özelliğinin türü ISlideComponent’den yeni IGroupShape arabirimine değiştirildi. IGroupShape, ISlideComponent’in bir türevi olduğundan mevcut kodun uyarlanmasına gerek yoktur.

Aspose.Slides.IShapeCollection.getParent() metodunun adı getParent’dan getParentGroup() olarak değiştirildi.
#### **Aspose.Slides.IShapeFrame.getFlipH() ve .getFlipV() Metodlarının Türü Değiştirildi**
Aspose.Slides.IShapeFrame.getFlipH() metodunun türü bool’tan NullableBool’a değiştirildi.

IShape.getFrame() metodu, tüm özelliklerin tanımlı etkili değerlerine sahip IShapeFrame’in etkili örneğini döndürür.

IShape.getRawFrame() metodu, her özelliğin belirsiz olabileceği (özellikle FlipH veya FlipV’nin NullableBool.NotDefined olabileceği) bir IShapeFrame örneği döndürür.