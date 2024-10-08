---
title: عرض شريحة كصورة SVG
type: docs
weight: 50
url: /ar/androidjava/render-a-slide-as-an-svg-image/
---

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومات قياسي يستخدم لعرض الصور ثنائية الأبعاد. يقوم SVG بتخزين الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

يعتبر SVG واحدًا من القلائل التي تلبي معايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، الوصول، البرمجة، وغيرها. لهذا السبب، يتم استخدامه بشكل شائع في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة العرض التقديمي الخاص بك بتنسيق *كبير جداً*.** يمكن أن تتوسع صور SVG إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG عدة مرات حسب الحاجة دون التضحية بالجودة.
- **استخدام الرسوم البيانية والمخططات من الشرائح الخاصة بك في *وسائط أو منصات مختلفة*.* يمكن لمعظم القارئين تفسير ملفات SVG.
- **استخدام *أصغر حجم ممكن للصور***. عادة ما تكون ملفات SVG أصغر من نظيراتها عالية الدقة في صيغ أخرى، خاصة تلك الصيغ المعتمدة على خريطة البكسل (JPEG أو PNG).

تتيح لك Aspose.Slides لنظام Android عبر Java تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع هذه الخطوات لإنشاء صور SVG:

1. إنشاء مثيل من فئة Presentation.
2. التكرار عبر جميع الشرائح في العرض التقديمي.
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileOutputStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides لنظام Android عبر Java.

{{% /alert %}} 

هذا المثال البرمجي في Java يظهر لك كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:

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