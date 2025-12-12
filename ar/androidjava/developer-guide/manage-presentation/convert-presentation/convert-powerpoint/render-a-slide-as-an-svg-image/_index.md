---
title: تحويل شرائح العرض التقديمي إلى صور SVG على Android
linktitle: شريحة إلى SVG
type: docs
weight: 50
url: /ar/androidjava/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint إلى SVG
- العرض التقديمي إلى SVG
- شريحة إلى SVG
- PPT إلى SVG
- PPTX إلى SVG
- حفظ PPT كـ SVG
- حفظ PPTX كـ SVG
- تصدير PPT إلى SVG
- تصدير PPTX إلى SVG
- عرض الشريحة
- تحويل الشريحة
- تصدير الشريحة
- صورة متجهة
- PowerPoint
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "تعلم كيفية تحويل شرائح PowerPoint إلى صور SVG باستخدام Aspose.Slides للأندرويد. رسومات عالية الجودة مع أمثلة شفرة Java بسيطة."
---

## **تنسيق SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومي قياسي يُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تلبي معايير عالية جداً في هذه الجوانب: القابلية للتوسع، التفاعل، الأداء، إمكانية الوصول، القابلية للبرمجة، وغيرها. لهذه الأسباب يُستخدم على نطاق واسع في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بتنسيق *كبير جداً*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG عددًا لا يُحصى من المرات دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.* يمكن لمعظم القارئات تفسير ملفات SVG. 
- **استخدام *أصغر أحجام ممكنة للصور***. عادةً ما تكون ملفات SVG أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، وخاصة تلك التي تستند إلى البت‌ماب (JPEG أو PNG).

## **تحويل شريحة إلى صورة SVG**

تتيح لك Aspose.Slides for Android عبر Java تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لإنشاء صور SVG:

1. إنشاء نسخة من فئة Presentation.
2. التكرار عبر جميع الشرائح في العرض التقديمي.
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileOutputStream.

{{% alert color="primary" %}} 
قد ترغب في تجربة تطبيقنا الويب [المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا فيه بتنفيذ وظيفة تحويل PPT إلى SVG باستخدام Aspose.Slides for Android عبر Java.
{{% /alert %}} 

يعرض لك هذا المثال البرمجي بلغة Java كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
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


## **الأسئلة المتكررة**

**لماذا قد يبدو SVG الناتج مختلفًا عبر المتصفحات؟**

يتم تنفيذ دعم ميزات SVG المحددة بطرق مختلفة من قبل محركات المتصفحات. تساعد معلمات [SVGOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/svgoptions/) على تخفيف عدم التوافق.

**هل يمكن تصدير ليس فقط الشرائح بل أيضًا الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) ، وهو أمر ملائم للأيقونات والرسوم التصويرية وإعادة استخدام الرسومات.

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.