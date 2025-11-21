---
title: تحويل شريحة إلى صورة SVG
type: docs
weight: 50
url: /ar/nodejs-java/render-a-slide-as-an-svg-image/
---

## **تنسيق SVG**

SVG—اختصار لـ Scalable Vector Graphics—هو نوع أو تنسيق رسومي قياسي يُستخدم لعرض الصور ثنائية الأبعاد. يخزن SVG الصور كمتجهات في XML مع تفاصيل تُحدد سلوكها أو مظهرها. 

SVG هو أحد القليل من تنسيقات الصور التي تلبي معايير عالية جدًا في هذه الجوانب: القابلية للتوسع، التفاعلية، الأداء، إمكانية الوصول، القابلية للبرمجة، وغيرها. لهذه الأسباب، يُستخدم عادةً في تطوير الويب. 

قد ترغب في استخدام ملفات SVG عندما تحتاج إلى

- **طباعة عرضك التقديمي بتنسيق *كبير جدًا*.** يمكن لصور SVG أن تتوسع إلى أي دقة أو مستوى. يمكنك تغيير حجم صور SVG مرات متعددة دون التضحية بالجودة.
- **استخدام المخططات والرسوم البيانية من شرائحك في *وسائط أو منصات مختلفة*.** معظم القُراء يمكنهم تفسير ملفات SVG. 
- **استخدام *أصغر أحجام ممكنة للصور*.** عادةً ما تكون ملفات SVG أصغر من مكافئاتها عالية الدقة في تنسيقات أخرى، خاصة تلك القائمة على البت ماب (JPEG أو PNG).

## **تصدير الشرائح كصور SVG**

Aspose.Slides for Node.js via Java يتيح لك تصدير الشرائح في عروضك التقديمية كصور SVG. اتبع الخطوات التالية لإنشاء صور SVG:

1. إنشاء مثيل من الفئة Presentation.  
2. التنقل عبر جميع الشرائح في العرض التقديمي.  
3. كتابة كل شريحة إلى ملف SVG خاص بها عبر FileOutputStream.  

{{% alert color="primary" %}} 

قد ترغب في تجربة [تطبيق الويب المجاني](https://products.aspose.app/slides/conversion/ppt-to-svg) الذي قمنا فيه بتنفيذ وظيفة تحويل PPT إلى SVG من Aspose.Slides for Node.js via Java.  

{{% /alert %}} 

هذا المثال البرمجي في JavaScript يوضح لك كيفية تحويل PPT إلى SVG باستخدام Aspose.Slides:
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    for (var index = 0; index < pres.getSlides().size(); index++) {
        var slide = pres.getSlides().get_Item(index);
        var fileStream = java.newInstanceSync("java.io.FileOutputStream", ("slide-" + index) + ".svg");
        try {
            slide.writeAsSvg(fileStream);
        } finally {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة المتكررة**

**لماذا قد يبدو SVG الناتج مختلفًا عبر المتصفحات؟**

يتم تنفيذ دعم ميزات SVG المحددة بطرق مختلفة من قبل محركات المتصفحات. تساعد معلمات [خيارات SVG](https://reference.aspose.com/slides/nodejs-java/aspose.slides/svgoptions/) على تسوية عدم التوافق.  

**هل من الممكن تصدير ليس فقط الشرائح ولكن أيضًا الأشكال الفردية إلى SVG؟**

نعم. يمكن حفظ أي [شكل كملف SVG منفصل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/)، وهو أمر ملائم للأيقونات، والرسوم التوضيحية، وإعادة استخدام الرسومات.  

**هل يمكن دمج عدة شرائح في SVG واحد (شريط/مستند)؟**

السيناريو القياسي هو شريحة واحدة → SVG واحد. دمج عدة شرائح في لوحة SVG واحدة هو خطوة معالجة لاحقة تُجرى على مستوى التطبيق.