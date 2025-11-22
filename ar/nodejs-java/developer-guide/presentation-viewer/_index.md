---
title: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/nodejs-java/presentation-viewer/
keywords:
- مشاهدة العرض التقديمي
- عارض العروض التقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- Node.js
- Java
- Aspose.Slides for Node.js via Java
description: "عارض عروض PowerPoint في JavaScript"
---

Aspose.Slides لـ Node.js عبر Java يُستخدم لإنشاء ملفات عروض تقديمية تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروض تقديمية خاص بهم. في هذه الحالات، يتيح Aspose.Slides تصدير شريحة فردية كصورة. يصف هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض تقديمي باستخدام Aspose.Slides، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على إشارة الشريحة عن طريق فهرسها.
3. فتح تدفق ملف.
4. حفظ الشريحة كصورة SVG إلى تدفق الملف.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **إنشاء SVG بمعرف شكل مخصص**

يمكن استخدام Aspose.Slides لتوليد [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرف شكل مخصص. للقيام بذلك، استخدم الطريقة `setId` من [SvgShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgshape/). يمكن استخدام `CustomSvgShapeFormattingController` لتعيين معرف الشكل.
```javascript
var slideIndex = 0;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var svgOptions = new aspose.slides.SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController(0));

var svgStream = java.newInstanceSync("java.io.FileOutputStream", "output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```javascript
class CustomSvgShapeFormattingController {
    constructor(shapeStartIndex = 0) {
        this.m_shapeIndex = shapeStartIndex;
    }

    formatShape(svgShape, shape) {
        svgShape.setId(`shape-${this.m_shapeIndex++}`);
    }
}
```


## **إنشاء صورة مصغرة للشريحة**

Aspose.Slides يساعدك على إنشاء صور مصغرة للشرائح. لتوليد صورة مصغرة لشريحة باستخدام Aspose.Slides، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على إشارة الشريحة عن طريق فهرسها.
3. الحصول على الصورة المصغرة للشريحة المرجعية بمقياس محدد.
4. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.
```javascript
const slideIndex = 0;
const scaleX = 1;
const scaleY = scaleX;

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **إنشاء صورة مصغرة للشريحة بأبعاد يحددها المستخدم**

لإنشاء صورة مصغرة للشريحة بأبعاد يحددها المستخدم، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
2. الحصول على إشارة الشريحة عن طريق فهرسها.
3. الحصول على الصورة المصغرة للشريحة المرجعية بالأبعاد المحددة.
4. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.
```javascript
var slideIndex = 0;
var slideSize = java.newInstanceSync("java.awt.Dimension", 1200, 800);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(slideSize);
image.save("output.jpg", aspose.slides.ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **إنشاء صورة مصغرة للشريحة مع ملاحظات المتحدث**

لتوليد صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، يرجى اتباع الخطوات التالية:

1. إنشاء مثيل من الفئة [RenderingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/renderingoptions/) .
2. استخدم طريقة `RenderingOptions.setSlidesLayoutOptions` لتعيين موضع ملاحظات المتحدث.
3. إنشاء مثيل من الفئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) .
4. الحصول على إشارة الشريحة عن طريق فهرسها.
5. الحصول على الصورة المصغرة للشريحة المرجعية مع خيارات العرض.
6. حفظ الصورة المصغرة بأي تنسيق صورة مطلوب.
```javascript
var slideIndex = 0;

var layoutingOptions = new aspose.slides.NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);

var renderingOptions = new aspose.slides.RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

var presentation = new aspose.slides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(slideIndex);

var image = slide.getImage(renderingOptions);
image.save("output.png", aspose.slides.ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **مثال حي**

يمكنك تجربة التطبيق المجاني [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) لمعرفة ما يمكنك تنفيذه باستخدام Aspose.Slides API:

![عارض PowerPoint على الإنترنت](online-PowerPoint-viewer.png)

## **الأسئلة المتكررة**

**هل يمكنني دمج عارض العروض التقديمية في تطبيق ويب Node.js؟**

نعم. يمكنك استخدام Aspose.Slides على جانب الخادم لتصيير الشرائح كصور أو HTML وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض مخصص؟**

النهج الموصى به هو تصيير كل شريحة كصورة (مثل PNG أو SVG) أو تحويلها إلى HTML باستخدام Aspose.Slides، ثم عرض الناتج داخل عنصر صورة (للتطبيقات المكتبية) أو داخل حاوية HTML (للويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

للعروض الكبيرة، يُنصح بالتحميل الكسول أو التصيير عند الطلب للشرائح. هذا يعني توليد محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.