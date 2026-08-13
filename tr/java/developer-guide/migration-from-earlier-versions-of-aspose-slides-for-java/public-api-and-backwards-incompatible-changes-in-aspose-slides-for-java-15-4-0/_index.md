---
title: Aspose.Slides for Java 15.4.0'de Genel API ve Geriye Uyumsuz Değişiklikler
linktitle: Aspose.Slides for Java 15.4.0
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
description: "Aspose.Slides for Java'daki genel API güncellemelerini ve kırılabilir değişiklikleri inceleyerek PowerPoint PPT, PPTX ve ODP sunum çözümlerinizin sorunsuz bir şekilde geçişini sağlayın."
---
{{% alert color="info" %}} 

Bu sayfa, Aspose.Slides for Java 15.4.0 API'siyle tanıtılan tüm [eklenen](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) sınıfları, metodları, özellikleri ve benzeri öğeleri, yeni kısıtlamaları ve diğer [değişiklikleri](/slides/tr/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) listeler.

{{% /alert %}} 
## **Genel API Değişiklikleri**
### **Enum OrganizationChartLayoutType eklendi**
com.aspose.slides.OrganizationChartLayoutType enum, bir organizasyon şemasındaki alt düğümlerin biçimlendirme tipini temsil eder.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() eklendi**
com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts metodu, madde işaretleri etkin olduğunda (PowerPoint'in paragraf madde işaretlerini/numaralandırmasını etkinleştirdiğinde yaptığı gibi) etkili paragraf Girintisi ve Sol Kenar Boşluğu için varsayılan sıfır olmayan kaydırmaları ayarlar. Madde işaretleri devre dışı bırakıldığında ise sadece paragraf Girintisi ve Sol Kenar Boşluğu sıfırlanır (PowerPoint'in madde işaretlerini/numaralandırmasını devre dışı bıraktığında yaptığı gibi).
### **Method IConnector.reroute() eklendi**
com.aspose.slides.IConnector.reroute() metodu, bağlayıcıyı bağladığı şekiller arasındaki mümkün olan en kısa yolu alacak şekilde yeniden yönlendirir. Bunu yapmak için reroute() metodu StartShapeConnectionSiteIndex ve EndShapeConnectionSiteIndex değerlerini değiştirebilir.

``` java
import com.aspose.slides.*;


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
Aspose.Slides.IPresentation.getSlideById(long) metodu, slide kimliğine göre bir Slide, MasterSlide veya LayoutSlide döndürür.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() eklendi**
com.aspose.slides.ISmartArt.getNodes() metodu, SmartArt nesnesindeki kök düğümlerin koleksiyonunu döndürür.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // ikinci kök düğümü seç

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) eklendi**
com.aspose.slides.ISmartArt.setLayout(int) özelliği için metod eklendi. Mevcut bir diyagramın düzen tipini değiştirmeye olanak tanır.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() eklendi**
com.aspose.slides.ISmartArtNode.isHidden() metodu, bu düğüm veri modelinde gizli bir düğümse true döndürür.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //true döndürür

if(hidden) {

    //bazı eylemler veya bildirimler yap

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArt.isReversed(), setReversed() eklendi**
com.aspose.slides.ISmartArt.IsReversed özelliği, diyagram terslemeyi destekliyorsa SmartArt diyagramının (soldan sağa) LTR ya da (sağdan sola) RTL durumunu alıp ayarlamaya izin verir.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) eklendi**
com.aspose.slides.ISmartArtNode.getOrganizationChartLayout() ve setOrganizationChartLayout(int) metodları, mevcut düğümle ilişkili organizasyon şeması tipini alıp ayarlamaya izin verir.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Property IShape.getConnectionSiteCount() eklendi**
com.aspose.slides.getConnectionSiteCount() özelliği, şeklin üzerindeki bağlantı noktası sayısını döndürür.

``` java
import com.aspose.slides.*;


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

|Enum com.aspose.slides.BevelColorMode |silinmiş, kullanılmayan enum |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |silinmiş, kullanılmayan özellik |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |eklenmiş |
|IParagraphFormatEffectiveData'in ISlideComponent'ten kalıtımı <br>IThreeDFormat'in ISlideComponent'ten kalıtımı |silinmiş |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |silinmiş, artık kullanılmıyor |