---
title: التعدد الخيوطي في Aspose.Slides للـ Java
linktitle: التعدد الخيوطي
type: docs
weight: 310
url: /ar/java/multithreading/
keywords:
- التعدد الخيوطي
- خيوط متعددة
- عمل متوازي
- تحويل الشرائح
- الشرائح إلى صور
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "يُعزز التعدد الخيوطي في Aspose.Slides للـ Java معالجة PowerPoint و OpenDocument. اكتشف أفضل الممارسات لتدفقات عمل عرض تقديمي فعّالة."
---

## **مقدمة**

بينما يمكن القيام بعمل متوازي مع العروض التقديمية (بجانب التحليل/التحميل/الاستنساخ) وتعمل الأمور بشكل جيد (في معظم الأوقات)، هناك فرصة صغيرة للحصول على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة **ليس** باستخدام نسخة واحدة من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) في بيئة متعددة الخيوط لأن ذلك قد ينتج عنه أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو/أو استنساخ نسخة من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) في عدة خيوط. مثل هذه العمليات **ليس** مدعومة. إذا كنت بحاجة إلى أداء هذه المهام، عليك موازاة العمليات باستخدام عدة عمليات أحادية الخيط—ويجب على كل عملية من هذه العمليات استخدام نسخة العرض الخاصة بها.

## **تحويل شرائح العرض إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. نظرًا لأن استخدام نسخة `Presentation` واحدة في عدة خيوط غير آمن، نقسم شرائح العرض إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بشكل متوازي، باستخدام كل عرض في خيط منفصل. مثال الشيفرة التالي يوضح كيفية القيام بذلك.
```java
String inputFilePath = "sample.pptx";
String outputFilePathTemplate = "slide_%d.png";
final float imageScale = 2;

Presentation presentation = new Presentation(inputFilePath);

int slideCount = presentation.getSlides().size();
Dimension2D slideSize = presentation.getSlideSize().getSize();
float slideWidth = (float) slideSize.getWidth();
float slideHeight = (float) slideSize.getHeight();

List<CompletableFuture<Void>> conversionTasks = new ArrayList<>(slideCount);

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
    // استخراج الشريحة i في عرض تقديمي منفصل.
    Presentation slidePresentation = new Presentation();
    slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.DoNotScale);
    slidePresentation.getSlides().removeAt(0);
    slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

    // تحويل الشريحة إلى صورة في مهمة منفصلة.
    final int slideNumber = slideIndex + 1;
    conversionTasks.add(CompletableFuture.runAsync(() -> {
        IImage image = null;
        try {
            ISlide slide = slidePresentation.getSlides().get_Item(0);

            image = slide.getImage(imageScale, imageScale);
            String imageFilePath = String.format(outputFilePathTemplate, slideNumber);
            image.save(imageFilePath, ImageFormat.Png);
        } finally {
            if (image != null) image.dispose();
            slidePresentation.dispose();
        }
    }));
}

// انتظار اكتمال جميع المهام.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```


## **الأسئلة المتكررة**

**هل أحتاج إلى استدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية/نطاق تطبيق قبل بدء الخيوط. إذا كان من الممكن استدعاء [إعداد الترخيص](/slides/ar/java/licensing/) بشكل متزامن (على سبيل المثال، أثناء التهيئة المتأخرة)، فقم بمزامنة ذلك الاستدعاء لأن طريقة إعداد الترخيص نفسها ليست آمنة للملعددة الخيوط.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

ليس من المستحسن تمرير كائنات العرض “الحية” بين الخيوط: استخدم نسخ مستقلة لكل خيط أو أنشئ مسبقًا عروض تقديمية/حاويات شرائح منفصلة لكل خيط. هذا النهج يتماشى مع التوصية العامة بعدم مشاركة نسخة عرض واحدة عبر الخيوط.

**هل من الآمن موازاة تصدير إلى صيغ مختلفة (PDF، HTML، صور) بشرط أن يكون لكل خيط نسخة `Presentation` خاصة به؟**

نعم. مع النسخ المستقلة ومسارات الإخراج المنفصلة، عادةً ما يتم موازاة هذه المهام بشكل صحيح؛ تجنّب أي كائنات عرض مشتركة أو تدفقات I/O مشتركة.

**ماذا أفعل بإعدادات الخط العالمية (المجلدات، البدائل) في البرمجة المتعددة الخيوط؟**

قم بتهيئة جميع [إعدادات الخط](/slides/ar/java/powerpoint-fonts/) العالمية قبل بدء الخيوط ولا تقم بتغييرها أثناء العمل المتوازي. هذا يلغي سباقات الوصول إلى موارد الخط المشتركة.