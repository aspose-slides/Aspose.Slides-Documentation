---
title: البرمجة المتعددة في Aspose.Slides
type: docs
weight: 310
url: /ar/java/multithreading/
keywords:
- باوربوينت
- عرض تقديمي
- برمجة متعددة
- عمل متوازي
- تحويل الشرائح
- شرائح إلى صور
- جافا
- Aspose.Slides لجافا
---

## **مقدمة**

بينما من الممكن العمل بشكل متوازٍ مع العروض التقديمية (بخلاف التحليل/التحميل/الاستنساخ) وكل شيء يسير على ما يرام (معظم الأوقات)، هناك فرصة صغيرة قد تحصل فيها على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام مثيل واحد من [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) في بيئة متعددة الخيوط، لأنه قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من الآمن تحميل أو حفظ أو استنساخ مثيل من فئة [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) في عدة خيوط. مثل هذه العمليات **غير مدعومة**. إذا كنت بحاجة إلى تنفيذ مثل هذه المهام، يجب عليك توزيع العمليات باستخدام عدة عمليات مفردة الخيوط - ويجب على كل من هذه العمليات استخدام مثيل العرض التقديمي الخاص بها.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

لنقل إننا نريد تحويل جميع الشرائح من عرض تقديمي باوربوينت إلى صور PNG بشكل متوازي. نظرًا لأنه غير آمن استخدام مثيل واحد من `Presentation` في عدة خيوط، نقوم بتقسيم شرائح العرض التقديمي إلى عروض تقديمية منفصلة ونحوّل الشرائح إلى صور بشكل متوازي، باستخدام كل عرض تقديمي في خيط منفصل. يوضح مثال الشيفرة التالية كيفية القيام بذلك.

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
    // استخراج الشريحة i إلى عرض تقديمي منفصل.
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

// الانتظار حتى تكتمل جميع المهام.
CompletableFuture.allOf(conversionTasks.toArray(new CompletableFuture[0])).join();

presentation.dispose();
```