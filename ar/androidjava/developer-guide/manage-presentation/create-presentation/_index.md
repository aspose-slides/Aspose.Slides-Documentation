---
title: إنشاء عروض تقديمية على Android
linktitle: إنشاء عرض تقديمي
type: docs
weight: 10
url: /ar/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "إنشاء عروض تقديمية باستخدام Java مع Aspose.Slides لنظام Android — إنتاج ملفات PPT و PPTX و ODP، الاستفادة من دعم OpenDocument، وحفظها برمجياً للحصول على نتائج موثوقة."
---
## **نظرة عامة**

توضح هذه المقالة كيفية إنشاء عرض تقديمي باستخدام Aspose.Slides لنظام Android عبر Java، وإضافة مربع نص إلى الشريحة الأولى، وحفظ النتيجة كملف في مساحة تخزين تطبيقك. لفتح عرض تقديمي موجود أو حفظه بتنسيق آخر، راجع [Open Presentation](/slides/ar/androidjava/open-presentation/) و[Save Presentation](/slides/ar/androidjava/save-presentation/). تغطي الأسئلة الشائعة القصيرة في النهاية أسئلة شائعة حول التنسيقات والقوالب وحجم الشرائح والوحدات واستخدام الذاكرة والبرمجة المتعددة الخيوط والترخيص والتوقيعات الرقمية ودعم VBA.

قبل البدء، أضف Aspose.Slides إلى مشروع Android الخاص بك من مستودع Maven الخاص بـ Aspose. راجع [Installation](/slides/ar/androidjava/install-aspose-slides-for-android-via-java/).

## **إنشاء عرض PowerPoint**

لإنشاء عرض تقديمي ووضع مربع نص على الشريحة الأولى، اتبع الخطوات التالية:

1. أنشئ مثيلاً من الفئة [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/). يحتوي العرض التقديمي الجديد بالفعل على شريحة فارغة واحدة.  
1. احصل على تلك الشريحة من [مجموعة الشرائح](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/islidecollection/) حسب فهرسها، 0.  
1. أضف مستطيلًا باستخدام طريقة [addAutoShape](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) من [مجموعة الأشكال](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/ishapecollection/) وحدد نص [إطار النص](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/) باستخدام طريقة [setText](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).  
1. احفظ العرض التقديمي كملف PPTX باستخدام طريقة [save](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) بصيغة [SaveFormat.Pptx](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/saveformat/).

يعمل الكود داخل `Activity`، على سبيل المثال في طريقة `onCreate` الخاصة به. يحفظ الملف في الدليل الذي تُرجعه طريقة [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()): مساحة التخزين الخاصة بتطبيقك، والتي يمكن الكتابة إليها دون طلب أي إذن.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

زاوية المستطيل العلوية اليسرى تبعد 50 نقطة عن حافة اليسار و50 نقطة عن حافة الأعلى للشفرة، وعرض المستطيل 400 نقطة وارتفاعه 100 نقطة. يحتوي الملف المحفوظ على شريحة واحدة بها ذلك المستطيل ونصه. بدون ترخيص، يضيف Aspose.Slides علامة مائية للتقييم إلى كل شريحة يتم حفظها؛ راجع [Licensing](/slides/ar/androidjava/licensing/).

لعرض الملف، افتح **Device Explorer** في Android Studio وابحث عن *hello.pptx* داخل *data/data/*، في مجلد *files* الخاص بتطبيقك. في تطبيق حقيقي، عالج العروض التقديمية على خيط خلفي للحفاظ على استجابة واجهة المستخدم.

## **الأسئلة الشائعة**

### ما الصيغ التي يمكنني حفظ عرض تقديمي جديد إليها؟

يمكنك الحفظ إلى [PPTX, PPT, and ODP](/slides/ar/androidjava/save-presentation/)، والتصدير إلى [PDF](/slides/ar/androidjava/convert-powerpoint-to-pdf/)، [XPS](/slides/ar/androidjava/convert-powerpoint-to-xps/)، [HTML](/slides/ar/androidjava/convert-powerpoint-to-html/)، [SVG](/slides/ar/androidjava/render-a-slide-as-an-svg-image/)، و[الصور](/slides/ar/androidjava/convert-powerpoint-to-png/)، وغيرها.

### هل يمكنني البدء من قالب (POTX/POTM) وحفظه كـ PPTX عادي؟

نعم. حمّل القالب واحفظه بالتنسيق المطلوب؛ تنسيقات POTX/POTM/PPTM وما شابهها [مدعومة](/slides/ar/androidjava/supported-file-formats/).

### كيف أتحكم في حجم الشريحة/نسبة العرض إلى الارتفاع عند إنشاء عرض تقديمي؟

حدد [حجم الشريحة](/slides/ar/androidjava/slide-size/) (بما في ذلك القوالب المسبقة مثل 4:3 و16:9 أو أبعاد مخصصة) واختر طريقة تكبير المحتوى.

### بأي وحدات تُقاس الأحجام والإحداثيات؟

بالنقطة: البوصة الواحدة تعادل 72 وحدة.

### كيف أتعامل مع عروض تقديمية ضخمة (مع العديد من ملفات الوسائط) لتقليل استهلاك الذاكرة؟

استخدم [استراتيجيات إدارة BLOB](/slides/ar/androidjava/manage-blob/)، وحدّ التخزين في الذاكرة عبر الاستفادة من الملفات المؤقتة، وفضّل سير العمل القائم على الملفات على التدفقات التي تُنفّذ بالكامل في الذاكرة.

### هل يمكنني إنشاء/حفظ عروض تقديمية بصورة متوازية؟

لا يمكنك التعامل مع نفس كائن [Presentation](https://reference.aspose.com/slides/ar/androidjava/com.aspose.slides/presentation/) من [عدة خيوط](/slides/ar/androidjava/multithreading/). شغّل مثيلات منفصلة ومعزولة لكل خيط أو عملية.

### كيف أزيل علامة التقييم والقيود؟

[طبق ترخيص](/slides/ar/androidjava/licensing/) مرة واحدة لكل عملية. يجب أن يظل ملف الترخيص XML غير معدل، ويجب مزامنة إعداد الترخيص إذا شاركت خيوط متعددة.

### هل يمكنني توقيع ملف PPTX الذي أنشئه رقميًا؟

نعم. [التوقيعات الرقمية](/slides/ar/androidjava/digital-signature-in-powerpoint/) (الإضافة والتحقق) مدعومة للعروض التقديمية.

### هل تدعم العروض التقديمية الماكرو (VBA)؟

نعم. يمكنك [إنشاء/تحرير مشاريع VBA](/slides/ar/androidjava/presentation-via-vba/) وحفظ ملفات تمكّن الماكرو مثل PPTM/PPSM.