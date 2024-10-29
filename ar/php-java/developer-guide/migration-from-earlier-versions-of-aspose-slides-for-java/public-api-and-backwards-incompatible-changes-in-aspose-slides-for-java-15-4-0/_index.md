---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع النسخ السابقة في Aspose.Slides لـ PHP عبر Java 15.4.0
type: docs
weight: 120
url: /ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [الإضافات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) من الفئات والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/ar/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 15.4.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **تم إضافة Enum OrganizationChartLayoutType**
تُمثل Enum com.aspose.slides.OrganizationChartLayoutType نوع التنسيق للعقد الفرعية في مخطط تنظيم.
### **تم إضافة الأسلوب IBulletFormat.applyDefaultParagraphIndentsShifts()**
الأسلوب com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts يحدد الانزلاقات الافتراضية غير الصفرية لتنسيق الفقرة الفعالة وMarginLeft عندما تكون الرمز النقطي مفعلًا (كما تفعل PowerPoint عند تفعيل رموز التعداد/الترقيم فيها). إذا كان الرمز النقطي معطلًا، فيجب فقط إعادة تعيين تنسيق الفقرة وMarginLeft (كما تفعل PowerPoint عند تعطيل رموز التعداد/الترقيم فيها).
### **تم إضافة الأسلوب IConnector.reroute()**
الأسلوب com.aspose.slides.IConnector.reroute() يعيد توجيه الموصل بحيث يأخذ أقصر مسار ممكن بين الأشكال التي يتصل بها. لتحقيق ذلك، قد يغير الأسلوب reroute() الفهرس StartShapeConnectionSiteIndex وEndShapeConnectionSiteIndex.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 300, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $connector->reroute();
  $input->save("output.pptx", SaveFormat::Pptx);
```
### **تم إضافة الأسلوب IPresentation.getSlideById(long)**
الأسلوب Aspose.Slides.IPresentation.getSlideById(int) يرجع شريحة، MasterSlide أو LayoutSlide حسب معرف الشريحة.

```php
  $presentation = new Presentation();
  $id = $presentation->getSlides()->get_Item(0)->getSlideId();
  $slide = $presentation->getSlideById($id);
```
### **تم إضافة الأسلوب ISmartArt.getNodes()**
الأسلوب com.aspose.slides.ISmartArt.getNodes() يرجع مجموعة من العقد الجذرية في كائن SmartArt.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::VerticalBulletList);
  $node = $smart->getNodes()->get_Item(1);// اختر العقدة الجذرية الثانية

  $node->getTextFrame()->setText("العقدة الجذرية الثانية");
  $pres->save("out.pptx", SaveFormat::Pptx);
```
### **تم إضافة الأسلوب ISmartArt.setLayout(int)**
تم إضافة الأسلوب الخاص com.aspose.slides.ISmartArt.setLayout(int). يسمح بتغيير نوع التخطيط لرسم بياني موجود.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $smart->setLayout(SmartArtLayoutType::BasicProcess);
  $pres->save("out.pptx", SaveFormat::Pptx);
```
### **تم إضافة الأسلوب ISmartArtNode.isHidden()**
الأسلوب com.aspose.slides.ISmartArtNode.isHidden() يرجع true إذا كانت هذه العقدة عقدة مخفية في نموذج البيانات.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
  $node = $smart->getAllNodes()->addNode();
  $hidden = $node->isHidden();// يرجع true

  if ($hidden) {
    # قم ببعض الإجراءات أو الإشعارات
  }
  $pres->Save("out.pptx", SaveFormat::Pptx);
```
### **تم إضافة الأساليب ISmartArt.isReversed()، setReserved()**
الخاصية com.aspose.slides.ISmartArt.IsReversed تتيح الحصول على حالة رسم تخطيط SmartArt فيما يتعلق بـ (من اليسار إلى اليمين) LTR أو (من اليمين إلى اليسار) RTL، إذا كان الرسم يدعم التراجع.

```php
  $presentation = new Presentation();
  $smart = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicProcess);
  $smart->setReversed(true);
  $presentation->save("out.pptx", SaveFormat::Pptx);
```
### **تم إضافة الأساليب ISmartArtNode.getOrganizationChartLayout()، setOrganizationChartLayout(int)**
الأساليب com.aspose.slides.ISmartArtNode.getOrganizationChartLayout()، setOrganizationChartLayout(int) تسمح بالحصول على نوع مخطط التنظيم المرتبط بالعقدة الحالية أو تعيينه.

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
  $smart->getNodes()->get_Item(0)->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);
  $pres->save("out.pptx", SaveFormat::Pptx);
```
### **تم إضافة الخاصية IShape.getConnectionSiteCount()**
الخاصية com.aspose.slides.getConnectionSiteCount() ترجع عدد مواقع الاتصال على الشكل.

```php
  $input = new Presentation();
  $shapes = $input->getSlides()->get_Item(0)->getShapes();
  $connector = $shapes->addConnector(ShapeType::BentConnector2, 0, 0, 10, 10);
  $ellipse = $shapes->addAutoShape(ShapeType::Ellipse, 0, 100, 100, 100);
  $rectangle = $shapes->addAutoShape(ShapeType::Rectangle, 100, 200, 100, 100);
  $connector->setStartShapeConnectedTo($ellipse);
  $connector->setEndShapeConnectedTo($rectangle);
  $wantedIndex = 6;
  if ($ellipse->getConnectionSiteCount() > $wantedIndex) {
    $connector->setStartShapeConnectionSiteIndex($wantedIndex);
  }
  $input->save("output.pptx", SaveFormat::Pptx);
```
### **تغييرات طفيفة**
هذه هي قائمة بالتغييرات الطفيفة في واجهة برمجة التطبيقات:

|Enum com.aspose.slides.BevelColorMode |تم حذفه، مجموعة غير مستخدمة |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |تم حذفه، خاصية غير مستخدمة |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |تم إضافته |
|وراثة IParagraphFormatEffectiveData من ISlideComponent <br>وراثة IThreeDFormat من ISlideComponent |تم حذفه |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |تم حذفه باعتباره قديمًا |