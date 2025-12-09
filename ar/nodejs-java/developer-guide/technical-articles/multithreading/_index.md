---
title: العمل المتعدد الخيوط في Aspose.Slides
type: docs
weight: 310
url: /ar/nodejs-java/multithreading/
keywords:
- باوربوينت
- عرض تقديمي
- متعدد الخيوط
- عمل متوازي
- تحويل الشرائح
- الشرائح إلى صور
- جافا سكريبت
- Aspose.Slides لـ Node.js عبر Java
---

## **المقدمة**

بينما يمكن العمل المتوازي مع العروض التقديمية (إضافة إلى التحليل/التحميل/النسخ) وعادةً ما تكون الأمور تسير بشكل جيد (في معظم الأحوال)، هناك احتمال صغير أن تحصل على نتائج غير صحيحة عند استخدام المكتبة في عدة خيوط.

نوصي بشدة بعدم استخدام كائن [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) واحد في بيئة متعددة الخيوط لأن ذلك قد يؤدي إلى أخطاء أو فشل غير متوقع يصعب اكتشافه.

ليس من **الآمن** تحميل أو حفظ أو/أو نسخ كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) في عدة خيوط. هذه العمليات **غير مدعومة**. إذا كنت بحاجة إلى تنفيذ مثل هذه المهام، عليك إجراء العمليات بشكل متوازي باستخدام عدة عمليات أحادية الخيط—ويجب أن تستخدم كل عملية مثيل عرض تقديمي خاص بها.

## **تحويل شرائح العرض التقديمي إلى صور بشكل متوازي**

لنفترض أننا نريد تحويل جميع الشرائح من عرض PowerPoint إلى صور PNG بشكل متوازي. بما أنه غير آمن استخدام كائن `Presentation` واحد في عدة خيوط، نقسم شرائح العرض إلى عروض تقديمية منفصلة ونحول الشرائح إلى صور بالتوازي، مع استخدام كل عرض في خيط منفصل. المثال التالي يوضح كيفية القيام بذلك.
```javascript
const inputFilePath = "sample.pptx";
const outputFilePathTemplate = "slide_%d.png";
const imageScale = 2;

(async () => {
    const presentation = new aspose.slides.Presentation(inputFilePath);
    const slideCount = presentation.getSlides().size();
    const slideSize = presentation.getSlideSize().getSize();
    const slideWidth = slideSize.getWidth();
    const slideHeight = slideSize.getHeight();

    const conversionTasks = Array.from({ length: slideCount }, async (_, slideIndex) => {
        // استخراج الشريحة i في عرض تقديمي منفصل.
        const slidePresentation = new aspose.slides.Presentation();
        slidePresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.DoNotScale);
        slidePresentation.getSlides().removeAt(0);
        slidePresentation.getSlides().addClone(presentation.getSlides().get_Item(slideIndex));

        try {
            const slide = slidePresentation.getSlides().get_Item(0);
            const image = slide.getImage(imageScale, imageScale);
            const imageFilePath = outputFilePathTemplate.replace("%d", slideIndex + 1);

            image.save(imageFilePath, aspose.slides.ImageFormat.Png);
            console.log(`Saved slide ${slideIndex + 1} to ${imageFilePath}`);
        } catch (error) {
            console.error(`Error processing slide ${slideIndex + 1}: ${error.message}`);
        } finally {
            slidePresentation.dispose();
        }
    });

    // انتظر حتى تكتمل جميع المهام.
    await Promise.all(conversionTasks);

    presentation.dispose();
})();
```


## **الأسئلة الشائعة**

**هل أحتاج لاستدعاء إعداد الترخيص في كل خيط؟**

لا. يكفي القيام بذلك مرة واحدة لكل عملية/نطاق تطبيق قبل بدء الخيوط. إذا كان [إعداد الترخيص](/slides/ar/nodejs-java/licensing/) قد يُستدعى بشكل متزامن (على سبيل المثال، أثناء التهيئة المتأخرة)، يجب مزامنة ذلك الاستدعاء لأن طريقة إعداد الترخيص نفسها غير آمنة للخيوط.

**هل يمكنني تمرير كائنات `Presentation` أو `Slide` بين الخيوط؟**

ليس من المستحسن تمرير كائنات العرض "الحية" بين الخيوط: استخدم مثيلات مستقلة لكل خيط أو أنشئ مسبقًا عروض تقديمية/حاويات شرائح منفصلة لكل خيط. هذا النهج يتماشى مع التوصية العامة بعدم مشاركة مثيل عرض تقديمي واحد عبر الخيوط.

**هل من الآمن تنفيذ التصدير إلى صيغ مختلفة (PDF, HTML, images) شريطة أن يكون لكل خيط مثيل `Presentation` خاص به؟**

نعم. مع مثيلات مستقلة ومسارات إخراج منفصلة، عادةً ما تتم هذه المهام بشكل متوازي بصورة صحيحة؛ تجنب أي كائنات عرض مشتركة وتدفقات I/O مشتركة.

**ماذا يجب أن أفعل بإعدادات الخطوط العامة (المجلدات، البدائل) في بيئة متعددة الخيوط؟**

قم بتهيئة جميع إعدادات الخطوط العامة قبل بدء الخيوط ولا تقم بتغييرها أثناء العمل المتوازي. هذا يزيل سباقات الوصول عند مشاركة موارد الخطوط.