---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لـ Java 14.9.0
type: docs
weight: 80
url: /ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [المضافات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) من الفئات والطرق والخصائص وما إلى ذلك، وأي قيود جديدة وأخرى [التغييرات](/slides/ar/androidjava/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) التي تم إدخالها مع واجهة برمجة التطبيقات Aspose.Slides لـ Java 14.9.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **طرق مضافة لاستبدال الصورة في PPImage و IPPImage**
تم إضافة الطرق الجديدة:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//الطريقة الأولى

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//الطريقة الثانية

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **طرق مضافة لحفظ الشرائح مع الحفاظ على أرقام الصفحات**
تم إضافة الطرق التالية:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

تسمح هذه الطرق بحفظ الشرائح المحددة من العرض التقديمي إلى PDF، XPS، TIFF، HTML. يسمح مصفوفة 'slides' بتحديد أرقام الصفحات، بدءًا من 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //مصفوفة مواقع الشرائح

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **إضافة قيمة تعداد SmartArtLayoutType.Custom**
يمثل هذا النوع من تخطيط SmartArt مخططًا بقالب مخصص. يمكن تحميل المخططات المخصصة فقط من ملف العرض التقديمي ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **إضافة فئة SmartArtShape وواجهة ISmartArtShape**
تضيف فئة Aspose.Slides.SmartArt.SmartArtShape (وواجهتها Aspose.Slides.SmartArt.ISmartArtShape) الوصول إلى الأشكال الفردية داخل مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat و LineFormat، وإضافة الروابط التشعبية، وما إلى ذلك.

{{% alert color="primary" %}} 

لا يدعم SmartArtShape خصائص IShape RawFrame و Frame و Rotation و X و Y و Width و Height ويتم إصدار System.NotSupportedException عند محاولة الوصول إليها.

{{% /alert %}} 

مثال على الاستخدام:

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
### **تمت إضافة فئة SmartArtShapeCollection وواجهة ISmartArtShapeCollection وطريقة ISmartArtNode.getShapes()**
تضيف فئة Aspose.Slides.SmartArt.SmartArtShapeCollection (وواجهتها Aspose.Slides.SmartArt.ISmartArtShapeCollection) الوصول إلى الأشكال الفردية داخل مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. يعيد خاصية SmartArtNode.Shapes مجموعات من جميع الأشكال المرتبطة بالعقدة.

{{% alert color="primary" %}} 

اعتمادًا على SmartArtLayoutType، يمكن مشاركة SmartArtShape واحد بين عدة عقد.

{{% /alert %}} 

﻿

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