---
title: تحويل شرائح العرض التقديمي إلى صور SVG على Android
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- عرض تقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- حفظ PPT كـ SVG
- حفظ PPTX كـ SVG
- تصدير PPT إلى SVG
- تصدير PPTX إلى SVG
- تصيير شريحة
- تحويل شريحة
- تصدير شريحة
- صورة متجهة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint إلى صور SVG باستخدام Aspose.Slides لأندرويد. رسومات عالية الجودة مع أمثلة شفرة Java بسيطة."
---

## **تنسيق SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تفي بمعايير عالية جدًا في هذه الجوانب: القابلية للتوسيع، التفاعل، الأداء، الوصولية، القابلية للبرمجة، وغيرها. لهذه الأسباب، يُستخدم على نطاق واسع في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بصيغة *كبيرة جدًا*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تعديل حجم صور SVG عدة مرات حسب الحاجة دون فقدان الجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.** يمكن لمعظم القارئات تفسير ملفات SVG. 
- **استخدام *أصغر حجم ممكن للصور***. ملفات SVG عادةً أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، خاصةً تلك التي تعتمد على البت ماب (JPEG أو PNG).

## **تحويل شريحة إلى صورة SVG**

Aspose.Slides for Android via Java يسمح لك بتصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لإنشاء صور SVG:

1. إنشاء مثال (instance) من الفئة Presentation.
2. التكرار عبر جميع الشرائح في العرض التقديمي.
3. كتابة كل شريحة إلى ملف SVG الخاص بها عبر FileOutputStream.

{{% alert color="primary" %}} 
قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا فيه بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides for Android via Java.
{{% /alert %}} 

هذا مثال الشيفرة في Java يوضح لك كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
``` java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);

        FileOutputStream fileStream = new FileOutputStream("slide-" + index + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة الشائعة**

**لماذا قد يظهر SVG الناتج بشكل مختلف عبر المتصفحات؟**

يدعم محركات المتصفحات ميزات SVG محددة بطرق مختلفة. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) على تقليل عدم التوافق.

**هل من الممكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)، وهو مفيد للأيقونات والرسوم التوضيحية وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في ملف SVG واحد (شريط/مستند)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة ما بعد المعالجة تُنفّذ على مستوى التطبيق.