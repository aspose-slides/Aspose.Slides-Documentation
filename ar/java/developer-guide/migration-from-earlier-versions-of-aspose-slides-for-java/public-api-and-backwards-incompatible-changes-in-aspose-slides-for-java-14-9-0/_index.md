---
title: واجهة برمجة التطبيقات العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides لجافا 14.9.0
type: docs
weight: 80
url: /java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
---

{{% alert color="primary" %}} 

هذه الصفحة تسرد جميع [المضافات](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) من الفئات، الطرق، الخصائص وما إلى ذلك، وأي قيود جديدة وأي [تغييرات](/slides/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) تم تقديمها مع واجهة برمجة التطبيقات Aspose.Slides لجافا 14.9.0.

{{% /alert %}} 
## **تغييرات واجهة برمجة التطبيقات العامة**
### **إضافة طرق لاستبدال الصورة إلى PPImage، IPPImage**
تمت إضافة طرق جديدة:

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
### **إضافة طرق لحفظ الشرائح مع الحفاظ على أرقام الصفحات**
تمت إضافة الطرق التالية:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

هذه الطرق تسمح بحفظ الشرائح المحددة للعرض التقديمي في تنسيقات PDF، XPS، TIFF، HTML. مصفوفة 'slides' تتيح تحديد أرقام الصفحات، بدءًا من 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //مصفوفة لمواقع الشرائح

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **إضافة قيمة enum SmartArtLayoutType.Custom**
هذا النوع من تخطيط SmartArt يمثل مخططًا بقالب مخصص. يمكن تحميل المخططات المخصصة فقط من ملف العرض التقديمي ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **إضافة فئة SmartArtShape وواجهة ISmartArtShape**
تضيف فئة Aspose.Slides.SmartArt.SmartArtShape (ومقابلها Aspose.Slides.SmartArt.ISmartArtShape) الوصول إلى الأشكال الفردية داخل مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat، LineFormat، إضافة روابط إلخ.

{{% alert color="primary" %}} 

SmartArtShape لا تدعم خصائص IShape RawFrame، Frame، Rotation، X، Y، Width، Height وترمي System.NotSupportedException عند محاولة الوصول إليها.

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
تضيف فئة Aspose.Slides.SmartArt.SmartArtShapeCollection (ومقابلها Aspose.Slides.SmartArt.ISmartArtShapeCollection) الوصول إلى الأشكال الفردية داخل مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. تعيد خاصية SmartArtNode.Shapes مجموعات من جميع الأشكال المرتبطة بالعقدة.

{{% alert color="primary" %}} 

اعتمادًا على SmartArtLayoutType، يمكن مشاركة SmartArtShape واحدة بين عدة عقد.

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