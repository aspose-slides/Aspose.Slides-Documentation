---
title: "Aspose.Slides for Java 15.4.0'da Genel API ve Geriye Yönelik Uyumsuz Değişiklikler"
linktitle: "Aspose.Slides Java 15.4.0 için"
type: docs
weight: 120
url: /tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
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
description: "Aspose.Slides for Java'da genel API güncellemelerini ve kırgın değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizin sorunsuz bir şekilde taşınmasını sağlayın."
---
{{% alert color="primary" %}} 
Bu sayfada, Aspose.Slides for Java 15.4.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) sınıflar, yöntemler, özellikler ve benzeri, yeni kısıtlamalar ve diğer [değişiklikler](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) listelenir.
{{% /alert %}} 
## **Public API Değişiklikleri**
### **Enum OrganizationChartLayoutType eklendi**
com.aspose.slides.OrganizationChartLayoutType enum, bir organizasyon şemasındaki alt düğümlerin biçimlendirme türünü temsil eder.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() eklendi**
com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts yöntemi, madde işaretleri etkin olduğunda (PowerPoint'in paragraf madde işaretleri/numaralandırmasını etkinleştirdiğinde yaptığı gibi) etkili paragraf girintisi ve Sol Kenar Boşluğu için varsayılan sıfır olmayan kaydırmaları ayarlar. Madde işaretleri devre dışı bırakıldığında ise paragraf girintisi ve Sol Kenar Boşluğunu sıfırlar (PowerPoint'in madde işaretlerini/numaralandırmasını devre dışı bıraktığında yaptığı gibi).
### **Method IConnector.reroute() eklendi**
com.aspose.slides.IConnector.reroute() yöntemi, bağlayıcıyı bağladığı şekiller arasındaki olabilecek en kısa yolu alacak şekilde yönlendirir. Bunu yapmak için reroute() yöntemi, StartShapeConnectionSiteIndex ve EndShapeConnectionSiteIndex değerlerini değiştirebilir.
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
### **Method IPresentation.getSlideById(long) eklendi**
Aspose.Slides.IPresentation.getSlideById(int) yöntemi, slayt kimliğine göre bir Slide, MasterSlide veya LayoutSlide döndürür.
``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() eklendi**
com.aspose.slides.ISmartArt.getNodes() yöntemi, SmartArt nesnesindeki kök düğümlerin koleksiyonunu döndürür.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // ikinci kök düğümü seç

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) eklendi**
com.aspose.slides.ISmartArt.setLayout(int) özelliği için yöntem eklendi. Mevcut bir diyagramın düzen tipini değiştirmeye olanak tanır.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() eklendi**
com.aspose.slides.ISmartArtNode.isHidden() yöntemi, bu düğüm veri modelinde gizli bir düğümse true döndürür.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //true döner

if(hidden) {

    // bazı işlemler veya bildirimler

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArt.isReversed(), setReserved() eklendi**
com.aspose.slides.ISmartArt.IsReversed özelliği, diyagramın (soldan‑sağa) LTR veya (sağdan‑sola) RTL yönündeki durumunu almayı veya ayarlamayı sağlar; diyagram ters çevirmeyi destekliyorsa.
``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) eklendi**
com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() ve setOrganizationChartLayout(int) yöntemleri, mevcut düğümle ilişkili organizasyon şeması tipini almayı veya ayarlamayı sağlar.
``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() eklendi**
com.aspose.slides.getConnectionSiteCount() özelliği, şekil üzerindeki bağlantı noktalarının sayısını döndürür.
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
### **Küçük Değişiklikler**
Bu, küçük API değişikliklerinin listesidir:

|Enum com.aspose.slides.BevelColorMode |silindi, kullanılmayan enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |silindi, kullanılmayan özellik |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |eklendi |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |silindi |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |eski olduğu için silindi |