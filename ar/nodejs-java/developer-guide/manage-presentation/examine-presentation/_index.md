---
title: استرجاع وتحديث معلومات العرض التقديمي باستخدام JavaScript
linktitle: معلومات العرض التقديمي
type: docs
weight: 30
url: /ar/nodejs-java/examine-presentation/
keywords:
- تنسيق العرض التقديمي
- خصائص العرض التقديمي
- خصائص المستند
- الحصول على الخصائص
- قراءة الخصائص
- تغيير الخصائص
- تعديل الخصائص
- تحديث الخصائص
- فحص PPTX
- فحص PPT
- فحص ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- Node.js
- JavaScript
- Aspose.Slides
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام JavaScript للحصول على رؤى أسرع وتدقيق محتوى أكثر ذكاءً."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد تنسيق العرض التقديمي وقراءة بيانات التعريف الخاصة بالمستند دون إنشاء نموذج كائن عرض تقديمي كامل. هذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل محتوى العرض ومعالجته.

توضح هذه المقالة الفحص الخفيف الوزن من خلال [PresentationFactory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/) و[PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/)، بالإضافة إلى التحديثات المستهدفة من خلال [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/).

## **التحقق من تنسيق العرض التقديمي**

إذا كان لديك عرض تقديمي محمَّل بالفعل، راجع [Determine the Original Presentation Format](/slides/ar/nodejs-java/detect-presentation-source-format/) للكشف بعد التحميل والقيود الخاصة بتدفقات PPT وPPS وPOT القديمة.

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) لفحص ملف دون إنشاء مثيل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) . تُبلغ طريقة [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/getloadformat/) عن التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **بناء جرد عرض تقديمي خفيف الوزن**

عند معالجة العديد من ملفات العروض التقديمية، قد تحتاج إلى جرد مدمج للتحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السيناريو، استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) للحصول على كائن [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/) ، ثم استدعِ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) لقراءة بيانات التعريف للمستند. لا ينشئ هذا الأسلوب مثيلًا لـ [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) ولا يتطلب التنقل عبر نموذج كائن العرض بالكامل.

تقدم الخصائص الموسعة التي تعرضها [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/) القيم التالية للجرد:

| الطريقة | قيمة الجرد |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getSlides) | الإجمالي الكلي للشرائح. |
| [getHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | عدد الشرائح المخفية. |
| [getNotes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getNotes) | عدد الشرائح التي تحتوي على ملاحظات. |
| [getParagraphs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | الإجمالي الكلي للفقرات، إذا كانت متاحة. |
| [getWords](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getWords) | الإجمالي الكلي للكلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | الإجمالي الكلي لمقاطع الصوت والفيديو. |

تقـرأ المثال التالي هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) ويطبع جردًا مدمجًا. كما يجمع بين [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) و[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

كل [HeadingPair](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/headingpair/) يوفر اسم المجموعة من خلال [HeadingPair.getName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/headingpair/#getName) وعدد العناصر في تلك المجموعة من خلال [HeadingPair.getCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/headingpair/#getCount). تُعيد [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) مصفوفة مسطحة مرتبة، لذا استهلك عدد العناوين المتتالية المحدد لكل زوج عنوان.

### **البيانات الوصفية المخزنة وقيود التنسيق**

تعكس خصائص الجرد التي تُعيدها [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) البيانات الوصفية المتاحة في المستند المصدر. لا تقوم Aspose.Slides بتحميل نموذج الكائنات وتعديله لإعادة حساب هذه القيم لهذا الاستدعاء. تمثل القيم المفقودة بالقيم الافتراضية، وقد تكون القيم المخزنة قديمة إذا لم تقم التطبيق الذي حفظ الملف آخر مرة بتحديث خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسعة لعدد الشرائح، الملاحظات، الشرائح المخفية، الفقرات، الكلمات، ومقاطع الوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. يعتمد التوفر على الخصائص التي كتبها منتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غير موجودة أو لم يتم تحديثها من قبل منتج المستند، تُعيد Aspose.Slides قيمتها المخزنة أو القيمة الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر بيانات تعريف OpenDocument إحصائيات عامة للمستند، مثل عدد الصفحات والفقرات والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسعة خاصة بـ PowerPoint. قد تكون بيانات تعريف الشرائح المخفية، شرائح الملاحظات، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متاحة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل القيمة الصفرية أو المصفوفة الفارغة كدليل حاسم على عدم وجود المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيفة للجرد والفحوصات الأولية. حمِّل العرض التقديمي وفحص نموذج الكائن الحي عندما يجب أن يعكس النتيجة التغييرات في الذاكرة أو عندما تحتاج إلى التحقق من محتوى العرض الفعلي.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُعيدها [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) دون إنشاء مثيل [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) . قم بتطبيق التغييرات باستخدام [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/)، ثم اكتب العرض المرتبط باستخدام [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

الصورة التالية تُظهر خصائص المستند الأصلية.

![Original document properties of the PowerPoint presentation](input_properties.png)

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

الصورة التالية تُظهر خصائص المستند المحدثة.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **روابط مفيدة**

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/nodejs-java/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/nodejs-java/write-protected-presentation/)

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مضمنة وأيها؟**

حمِّل العرض التقديمي واستخدم [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getfontsmanager/). استدعِ [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) للحصول على الخطوط المضمنة و[FontsManager.getFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getfonts/) للحصول على الخطوط المستخدمة في العرض. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض لكنها غير مضمنة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفية وعددها؟**

عند كفاية بيانات التعريف المخزنة، اقرأ [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) عبر [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) و[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). هذا مناسب لجرد خفيف الوزن. إذا تم تعديل العرض في الذاكرة، قد تكون البيانات المخزنة مفقودة أو قديمة، أو إذا كنت بحاجة للتحقق من القيم الحية، قم بالتكرار عبر [Presentation.getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslides/) وافحص طريقة [Slide.getHidden](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/gethidden/) لكل شريحة.

**هل يمكنني اكتشاف ما إذا كان حجم واتجاه الشريحة المخصص مستخدمًا، وما إذا كان يختلف عن الإعدادات الافتراضية؟**

نعم. حمِّل العرض التقديمي واستدعِ [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslidesize/). استخدم [SlideSize.getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/gettype/)، [SlideSize.getSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/getsize/)، و[SlideSize.getOrientation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/getorientation/) لمقارنة الإعدادات الحالية مع الإعدادات المسبقة والأبعاد المتوقعة.

**هل توجد طريقة سريعة لمعرفة ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. حدد كل [Chart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/) واستدعِ [ChartData.getDataSourceType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). لمصنف خارجي، استدعِ [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). نوع مصدر البيانات والمسار يحددان وجود إشارة خارجية، لكن التحقق من توفر الهدف يتطلب فحصًا منفصلًا للموارد.

**كيف يمكنني تقييم الشرائح 'الثقيلة' التي قد تبطئ عملية العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. تنقّب عبر [Presentation.getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslides/) ومجموعة [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getShapes) لكل شريحة. استخدم عدد الأشكال ووجود الصور الكبيرة أو التأثيرات أو الرسوم المتحركة أو الوسائط المتعددة كإشارات فرز، وقم بقياس عملية عرض أو تصدير تمثيلية قبل اعتبار الشريحة عبئًا مؤكدًا على الأداء.