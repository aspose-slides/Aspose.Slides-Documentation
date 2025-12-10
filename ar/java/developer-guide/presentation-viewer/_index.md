---
title: إنشاء عارض عروض تقديمية في Java
linktitle: عارض العروض التقديمية
type: docs
weight: 50
url: /ar/java/presentation-viewer/
keywords:
- عرض العرض التقديمي
- عارض العروض التقديمية
- إنشاء عارض عروض تقديمية
- عرض PPT
- عرض PPTX
- عرض ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء عارض عروض تقديمية مخصص في Java باستخدام Aspose.Slides. عرض ملفات PowerPoint و OpenDocument بسهولة دون الحاجة إلى Microsoft PowerPoint."
---

Aspose.Slides for Java تُستخدم لإنشاء ملفات العروض التقديمية التي تحتوي على شرائح. يمكن عرض هذه الشرائح بفتح العروض في Microsoft PowerPoint، على سبيل المثال. ومع ذلك، قد يحتاج المطورون أحيانًا إلى عرض الشرائح كصور في عارض الصور المفضل لديهم أو إنشاء عارض عروض تقديمية خاص بهم. في مثل هذه الحالات، تتيح لك Aspose.Slides تصدير شريحة فردية كصورة. يصف هذا المقال كيفية القيام بذلك.

## **إنشاء صورة SVG من شريحة**

لإنشاء صورة SVG من شريحة عرض باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة حسب الفهرس.
1. فتح تدفق ملف.
1. حفظ الشريحة كصورة SVG إلى تدفق الملف.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream);
svgStream.close();

presentation.dispose();
```


## **إنشاء SVG بمعرف شكل مخصص**

يمكن استخدام Aspose.Slides لإنشاء [SVG](https://docs.fileformat.com/page-description-language/svg/) من شريحة بمعرف شكل مخصص. للقيام بذلك، استخدم طريقة `setId` من [ISvgShape](https://reference.aspose.com/slides/java/com.aspose.slides/isvgshape/). يمكن استخدام `CustomSvgShapeFormattingController` لتعيين معرف الشكل.
```java
int slideIndex = 0;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

SVGOptions svgOptions = new SVGOptions();
svgOptions.setShapeFormattingController(new CustomSvgShapeFormattingController());

FileOutputStream svgStream = new FileOutputStream("output.svg");
slide.writeAsSvg(svgStream, svgOptions);
svgStream.close();

presentation.dispose();
```

```java
class CustomSvgShapeFormattingController implements ISvgShapeFormattingController {
    private int m_shapeIndex;

    public CustomSvgShapeFormattingController() {
        m_shapeIndex = 0;
    }

    public CustomSvgShapeFormattingController(int shapeStartIndex) {
        m_shapeIndex = shapeStartIndex;
    }

    public void formatShape(ISvgShape svgShape, IShape shape) {
        svgShape.setId(String.format("shape-%d", m_shapeIndex++));
    }
}
```


## **إنشاء صورة مصغرة للشريحة**

تساعدك Aspose.Slides على إنشاء صور مصغرة للشرائح. لإنشاء صورة مصغرة لشريحة باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة حسب الفهرس.
1. الحصول على الصورة المصغرة للشريحة المرجعية بمقاس مُحدد.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب.
```java
int slideIndex = 0;
float scaleX = 1;
float scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(scaleX, scaleY);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **إنشاء صورة مصغرة للشريحة بأبعاد مُحددة من قبل المستخدم**

لإنشاء صورة مصغرة للشريحة بأبعاد يحددها المستخدم، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة حسب الفهرس.
1. الحصول على الصورة المصغرة للشريحة المرجعية بالأبعاد المحددة.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب.
```java
int slideIndex = 0;
Dimension slideSize = new Dimension(1200, 800);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(slideSize);
image.save("output.jpg", ImageFormat.Jpeg);
image.dispose();

presentation.dispose();
```


## **إنشاء صورة مصغرة للشريحة مع ملاحظات المتحدث**

لإنشاء صورة مصغرة لشريحة مع ملاحظات المتحدث باستخدام Aspose.Slides، يرجى اتباع الخطوات أدناه:

1. إنشاء مثال من فئة [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/).
1. استخدام طريقة `RenderingOptions.setSlidesLayoutOptions` لتحديد موضع ملاحظات المتحدث.
1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. الحصول على مرجع الشريحة حسب الفهرس.
1. الحصول على الصورة المصغرة للشريحة المرجعية باستخدام خيارات العرض.
1. حفظ الصورة المصغرة بأي تنسيق صورة مرغوب.
```java
int slideIndex = 0;

NotesCommentsLayoutingOptions layoutingOptions = new NotesCommentsLayoutingOptions();
layoutingOptions.setNotesPosition(NotesPositions.BottomTruncated);

RenderingOptions renderingOptions = new RenderingOptions();
renderingOptions.setSlidesLayoutOptions(layoutingOptions);

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(slideIndex);

IImage image = slide.getImage(renderingOptions);
image.save("output.png", ImageFormat.Png);
image.dispose();

presentation.dispose();
```


## **مثال حي**

يمكنك تجربة تطبيق [**Aspose.Slides Viewer**](https://products.aspose.app/slides/viewer/) المجاني لمعرفة ما يمكنك تنفيذه باستخدام Aspose.Slides API:

![Online PowerPoint Viewer](online-PowerPoint-viewer.png)

## **الأسئلة الشائعة**

**هل يمكنني تضمين عارض عروض تقديمية في تطبيق ويب؟**

نعم. يمكنك استخدام Aspose.Slides على الخادم لتوليد الشرائح كصور أو HTML وعرضها في المتصفح. يمكن تنفيذ ميزات التنقل والتكبير باستخدام JavaScript لتجربة تفاعلية.

**ما هي أفضل طريقة لعرض الشرائح داخل عارض مخصص؟**

النهج الموصى به هو توليد كل شريحة كصورة (مثل PNG أو SVG) أو تحويلها إلى HTML باستخدام Aspose.Slides، ثم عرض الناتج داخل صندوق صورة (للتطبيقات المكتبية) أو حاوية HTML (للويب).

**كيف يمكنني التعامل مع عروض تقديمية كبيرة تحتوي على العديد من الشرائح؟**

لعروض كبيرة، ضع في اعتبارك التحميل الكسول أو التوليد عند الطلب للشرائح. يعني هذا توليد محتوى الشريحة فقط عندما ينتقل المستخدم إليها، مما يقلل من استهلاك الذاكرة ووقت التحميل.