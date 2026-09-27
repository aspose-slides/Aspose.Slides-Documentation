---
title: إنشاء عروض تقديمية في جافا
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/java/create-presentation/
keywords:
- إنشاء عرض تقديمي
- عرض تقديمي جديد
- إنشاء PPT
- PPT جديد
- إنشاء PPTX
- PPTX جديد
- إنشاء ODP
- ODP جديد
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إنشاء عروض تقديمية في جافا باستخدام Aspose.Slides—إنشاء ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء عرض تقديمي في Aspose.Slides، إضافة شكل يحتوي على نص إلى الشريحة الأولى، وحفظ النتيجة كملف PPTX. لفتح عرض تقديمي موجود وحفظه بتنسيق آخر، راجع [Open Presentations](/slides/ar/java/open-presentation/) و[Save Presentations](/slides/ar/java/save-presentation/). تتضمن الأسئلة الشائعة القصيرة في النهاية إجابات على أسئلة شائعة حول الصيغ، القوالب، حجم الشريحة، الوحدات، استهلاك الذاكرة، الخيوط، الترخيص، التوقيعات الرقمية، ودعم VBA.

قبل البدء، أضف Aspose.Slides for Java إلى مشروعك من مستودع Maven الخاص بـ Aspose. راجع [Installation](/slides/ar/java/installation/) لإعداد Maven وما يحتاجه Linux إضافيًا.

## **إنشاء عرض تقديمي**

إنشاء ملف PowerPoint من الصفر في Aspose.Slides for Java يبدأ بإنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يوفر المُنشئ عرضًا تقديميًا فارغًا بشريحة واحدة جاهزة للأشكال، النص، المخططات أو أي محتوى آخر يحتاجه تطبيقك. بمجرد تعديل تلك الشريحة أو إضافة شُرُح جديدة، يمكنك حفظ النتيجة بتنسيق PPTX أو PPT القديم أو تنسيقات OpenDocument.

لإنشاء عرض تقديمي ووضع شكل نصي على شريحته الأولى، اتبع الخطوات التالية:

1. أنشئ كائنًا من الفئة [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/). يحتوي العرض الجديد على شريحة فارغة واحدة.
2. احصل على تلك الشريحة حسب فهرسها، 0، من المجموعة التي تُرجعها الدالة [getSlides](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#getSlides--).
3. أضف كائنًا من النوع [IAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/iautoshape/) من نوع `Cloud` باستخدام الدالة [addAutoShape](https://reference.aspose.com/slides/ar/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) ، واضبط النص باستخدام الدالة [setText](https://reference.aspose.com/slides/ar/java/com.aspose.slides/itextframe/#setText-java.lang.String-).
4. احفظ العرض التقديمي كملف PPTX باستخدام الدالة [save](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/#save-java.lang.String-int-).

البرنامج التالي مثال كامل. في مشروع Maven من [Installation](/slides/ar/java/installation/)، احفظه كملف *src/main/java/HelloSlides.java* وشغّله باستخدام الأمر `mvn compile exec:java`.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // إنشاء عرض تقديمي. يحتوي بالفعل على شريحة فارغة واحدة.
        Presentation presentation = new Presentation();
        try {
            // الحصول على الشريحة الأولى.
            ISlide slide = presentation.getSlides().get_Item(0);

            // إضافة شكل سحابة ووضع نص داخله.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // حفظ العرض التقديمي كملف PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

زاوية السحابة العلوية اليسرى تبعد 20 نقطة عن الحافة اليسرى و20 نقطة عن الحافة العلوية للشريحة، وعرض الشكل 200 نقطة وارتفاعه 80 نقطة. يحفظ البرنامج الملف *new_presentation.pptx* مع شريحة واحدة تحتوي على السحابة ونصها. بدون ترخيص، يضيف Aspose.Slides علامة مائية للتقييم إلى كل شريحة يتم حفظها؛ راجع [Licensing](/slides/ar/java/licensing/).

النتيجة:

![العرض التقديمي الجديد](new_presentation.png)

## **الأسئلة الشائعة**

### أي صيغ يمكنني حفظ عرض تقديمي جديد بها؟

يمكنك الحفظ بصيغ [PPTX, PPT, و ODP](/slides/ar/java/save-presentation/)، والتصدير إلى [PDF](/slides/ar/java/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/java/convert-powerpoint-to-xps/)، [HTML](/slides/ar/java/convert-powerpoint-to-html/)، [SVG](/slides/ar/java/render-a-slide-as-an-svg-image/)، و[الصور](/slides/ar/java/convert-powerpoint-to-png/)، وغيرها.

### هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟

نعم. حمّل القالب واحفظه بالتنسيق المطلوب؛ صيغ POTX/POTM/PPTM وغيرها [مدعومة](/slides/ar/java/supported-file-formats/).

### كيف أتحكم في حجم الشريحة/نسبة أبعادها عند إنشاء عرض تقديمي؟

حدد [حجم الشريحة](/slides/ar/java/slide-size/) (بما في ذلك القوالب المسبقة مثل 4:3 و16:9 أو أبعاد مخصصة) واختر طريقة تكبير المحتوى.

### بأي وحدات تُقاس الأحجام والإحداثيات؟

بالنقاط: 1 بوصة يساوي 72 نقطة.

### كيف أتعامل مع عروض تقديمية كبيرة جدًا (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟

استخدم [استراتيجيات إدارة BLOB](/slides/ar/java/manage-blob/)، وحدّ التخزين في الذاكرة بالاعتماد على الملفات المؤقتة، وفضّل سير عمل يعتمد على الملفات بدلاً من تدفقات الذاكرة بالكامل.

### هل يمكنني إنشاء/حفظ عروض تقديمية بشكل متوازي؟

لا يمكنك التعامل مع نفس كائن [Presentation](https://reference.aspose.com/slides/ar/java/com.aspose.slides/presentation/) من [عدة خيوط](/slides/ar/java/multithreading/). أنشئ كائنات منفصلة ومعزولة لكل خيط أو عملية.

### كيف أزيل علامة الماء التجريبية والقيود؟

[طبق ترخيص](/slides/ar/java/licensing/) مرة واحدة لكل عملية. يجب أن يبقى ملف XML للترخيص غير معدل، ويجب مزامنة إعداد الترخيص إذا كانت هناك عدة خيوط تعمل.

### هل يمكنني توقيع PPTX رقمياً؟

نعم. [التوقيعات الرقمية](/slides/ar/java/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعرض التقديمي.

### هل تدعم العروض التقديمية ماكروهات (VBA)؟

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/java/presentation-via-vba/) وحفظ ملفات مفعّلة للماكرو مثل PPTM/PPSM.