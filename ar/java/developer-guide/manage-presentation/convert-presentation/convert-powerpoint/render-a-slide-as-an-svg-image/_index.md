---
title: عرض شريحة كصورة SVG
type: docs
weight: 50
url: /java/render-a-slide-as-an-svg-image/
---

SVG—اختصار للرسومات المتجهة القابلة للتوسع—هو نوع أو تنسيق قياسي للرسومات يستخدم لرسم الصور الثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تحدد سلوكها أو مظهرها.

يعد SVG واحدًا من بين القليل من التنسيقات للصور التي تلبي معايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، الوصول، البرمجة، وغيرها. لهذه الأسباب، يتم استخدامه بشكل شائع في تطوير الويب.

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة العرض التقديمي الخاص بك في *تنسيق كبير جدًا*.** يمكن أن تتوسع صور SVG إلى أي دقة أو مستوى. يمكنك إعادة حجم صور SVG بقدر ما تحتاج دون التضحية بالجودة.
- **استخدام الرسوم البيانية والمخططات من شرائحك في *وسائط أو منصات مختلفة**.* يمكن لمعظم القراء تفسير ملفات SVG.
- **استخدام *أصغر أحجام ممكنة من الصور***. تكون ملفات SVG عمومًا أصغر من نظيراتها عالية الدقة في تنسيقات أخرى، خاصة تلك التنسيقات المعتمدة على البت (JPEG أو PNG).

تتيح لك Aspose.Slides لـ Java تصدير الشرائح في عروضك التقديمية كصور SVG. انتقل عبر هذه الخطوات لإنشاء صور SVG:

1. أنشئ مثيلًا من فئة Presentation.
2. قم بالتكرار عبر جميع الشرائح في العرض التقديمي.
3. اكتب كل شريحة في ملف SVG الخاص بها من خلال FileOutputStream.

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي نفذنا فيه وظيفة تحويل PPT إلى SVG من Aspose.Slides لـ Java.

{{% /alert %}} 

يوضح لك رمز المثال هذا في Java كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:

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