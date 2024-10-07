---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ PHP عبر Java 14.9.0
type: docs
weight: 80
url: /php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

تقوم هذه الصفحة بإدراج جميع [المضاف](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) الفئات والأساليب والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/php-java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) التي تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لـ PHP عبر Java 14.9.0.

{{% /alert %}} 
## **تغييرات واجهة البرمجة العامة**
### **أساليب مضافة لاستبدال الصورة في PPImage، IPPImage**
تمت إضافة الأساليب الجديدة:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

```php
  $presentation = new Presentation("presentation.pptx");
  # الطريقة الأولى
  # ...
  $imageData = $presentation->getImages()->get_Item(0)->replaceImage($imageData);
  # الطريقة الثانية
  $presentation->getImages()->get_Item(1)->replaceImage($presentation->getImages()->get_Item(0));
  $presentation->save("presentation_out.pptx", SaveFormat::Pptx);

```
### **أساليب مضافة لحفظ الشرائح مع الحفاظ على أرقام الصفحات**
تمت إضافة الطرق التالية:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

تسمح هذه الأساليب بحفظ شرائح العرض المحددة إلى تنسيقات PDF و XPS و TIFF و HTML. يسمح مصفوفة 'slides' بتحديد أرقام الصفحات، بدءًا من 1.

```php
  save($string, $slides, SaveFormat);

```

```php
  $presentation = new Presentation($presentationFileName);
  $slides = array(2, 3, 5 );// مصفوفة مواقع الشرائح

  $presentation->save($outFileName, $slides, SaveFormat::Pdf);

```
### **إضافة قيمة枚举 SmartArtLayoutType::Custom**
يمثل هذا النوع من تخطيط SmartArt مخططًا بقالب مخصص. يمكن تحميل المخططات المخصصة فقط من ملف العرض ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType::Custom)
### **إضافة فئة SmartArtShape وواجهة ISmartArtShape**
تضيف فئة Aspose.Slides.SmartArt.SmartArtShape (ومقابلها Aspose.Slides.SmartArt.ISmartArtShape) الوصول إلى الأشكال الفردية داخل مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat وLineFormat وإضافة Hyperlinks وما إلى ذلك.

{{% alert color="primary" %}} 

SmartArtShape لا يدعم خصائص IShape RawFrame وFrame وRotation وX وY وWidth وHeight وتم طرح System.NotSupportedException عند محاولة الوصول إليها.

{{% /alert %}} 

مثال على الاستخدام:

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```
### **تمت إضافة فئة SmartArtShapeCollection، واجهة ISmartArtShapeCollection وطريقة ISmartArtNode.getShapes()**
تضيف فئة Aspose.Slides.SmartArt.SmartArtShapeCollection (ومقابلها Aspose.Slides.SmartArt.ISmartArtShapeCollection) الوصول إلى الأشكال الفردية داخل مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. تعيد خاصية SmartArtNode.Shapes مجموعات من جميع الأشكال المرتبطة بالعقدة.

{{% alert color="primary" %}} 

اعتمادًا على SmartArtLayoutType، يمكن مشاركة شكل SmartArt واحد بين عدة عقد.

{{% /alert %}} 

```php
  $pres = new Presentation();
  $smart = $pres->getSlides()->get_Item(0)->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
  $node = $smart->getAllNodes()->get_Item(0);
  foreach($node->getShapes() as $shape) {
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
  }
  $pres->save("out.pptx", SaveFormat::Pptx);

```