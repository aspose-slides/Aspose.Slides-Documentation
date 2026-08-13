---
title: API العامة والتغييرات غير المتوافقة مع الإصدارات السابقة في Aspose.Slides for Java 14.9.0
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- ترحيل
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استعرض تحديثات API العامة والتغييرات الجذرية في Aspose.Slides for Java لترحيل حلول عروض PowerPoint (PPT، PPTX) و ODP بسلاسة."
---
{{% alert color="info" %}} 

هذه الصفحة تسرد جميع الفئات، الأساليب، الخصائص وما إلى ذلك [المضافة](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)، وأية قيود جديدة وغيرها من [التغييرات](/slides/ar/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) التي تم إدخالها مع Aspose.Slides for Java 14.9.0 API.

{{% /alert %}} 
## **تغييرات API العامة**
### **تمت إضافة أساليب لاستبدال Image إلى PPImage, IPPImage**
الأساليب الجديدة المضافة:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // الطريقة الأولى
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // الطريقة الثانية
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **تمت إضافة أساليب لحفظ الشرائح مع الحفاظ على أرقام الصفحات**
تمت إضافة الأساليب التالية:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

تسمح هذه الأساليب بحفظ شرائح العرض المحددة إلى صيغ PDF و XPS و TIFF و HTML. يتيح مصفوفة 'slides' تحديد أرقام الصفحات بدءًا من 1.

``` java
// تم إضافة التحميل الزائد إلى IPresentation (قيم SaveFormat هي ثوابت int في Java):
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
    int[] slides = new int[] { 2, 3, 5 }; // مصفوفة مواضع الشرائح

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **تمت إضافة قيمة Enum SmartArtLayoutType.Custom**
هذا النوع من تخطيط SmartArt يمثل مخططًا بقالب مخصص. لا يمكن تحميل المخططات المخصصة إلا من ملف العرض ولا يمكن إنشاؤها عبر الطريقة ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **تمت إضافة الفئة SmartArtShape والواجهة ISmartArtShape**
تضيف الفئة Aspose.Slides.SmartArt.SmartArtShape (وواجهة Aspose.Slides.SmartArt.ISmartArtShape) إمكانية الوصول إلى الأشكال الفردية داخل مخطط SmartArt. يمكن استخدام SmartArtShape لتغيير FillFormat، LineFormat، إضافة روابط تشعبية، إلخ.

{{% alert color="info" %}} 

لا يدعم SmartArtShape خصائص IShape التالية: RawFrame, Frame, Rotation, X, Y, Width, Height وتطرح System.NotSupportedException عند محاولة الوصول إليها.

{{% /alert %}} 

مثال على الاستخدام:

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
### **تمت إضافة الفئة SmartArtShapeCollection، الواجهة ISmartArtShapeCollection والطريقة ISmartArtNode.getShapes()**
تضيف الفئة Aspose.Slides.SmartArt.SmartArtShapeCollection (وواجهة Aspose.Slides.SmartArt.ISmartArtShapeCollection) إمكانية الوصول إلى الأشكال الفردية داخل مخطط SmartArt. تحتوي المجموعة على الأشكال المرتبطة بـ SmartArtNode. تُرجِع الخاصية SmartArtNode.Shapes مجموعة جميع الأشكال المرتبطة بالعقدة.

{{% alert color="info" %}} 

اعتمادًا على SmartArtLayoutType يمكن مشاركة SmartArtShape واحد بين عدة عقد.

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