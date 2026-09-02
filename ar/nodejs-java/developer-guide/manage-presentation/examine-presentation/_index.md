---
title: استرجاع وتحديث معلومات العرض التقديمي في JavaScript
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
description: "استكشف الشرائح والبنية والبيانات الوصفية في عروض PowerPoint وOpenDocument باستخدام JavaScript للحصول على رؤى أسرع وتدقيق محتوى أذكى."
---
## **نظرة عامة**

يمكن لـ Aspose.Slides تحديد تنسيق العرض التقديمي وقراءة بيانات تعريف المستند دون إنشاء نموذج كائن عرض تقديمي كامل. فهذا مفيد عندما تحتاج إلى تصنيف الملفات، بناء جرد، أو فحص الخصائص قبل اتخاذ قرار بتحميل ومعالجة محتوى العرض التقديمي.

يُظهر هذا المقال عملية فحص خفيفة الوزن عبر [PresentationFactory](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/) و[PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/)، بالإضافة إلى تحديثات مستهدفة عبر [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/).

## **التحقق من تنسيق العرض التقديمي**

استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) لفحص ملف دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) . تُعيد طريقة [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/getloadformat/) التنسيق المكتشف، مثل PPTX أو PPT أو ODP.

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

عند معالجة عدد كبير من ملفات العروض التقديمية، قد تحتاج إلى جرد مضغوط للتحقق، الفهرسة، أو نظام إدارة المستندات. في هذا السياق، استخدم [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) للحصول على كائن [PresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/)، ثم استدعِ [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) لقراءة بيانات تعريف المستند. لا تُنشئ هذه الطريقة كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) ولا تتطلب التنقل عبر نموذج كائن العرض التقديمي الكامل.

الخصائص الموسعة التي تُظهرها [DocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/) تُوفر القيم التالية للجرد:

| الطريقة | قيمة الجرد |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getSlides) | إجمالي عدد الشرائح. |
| [getHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | عدد الشرائح المخفيّة. |
| [getNotes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getNotes) | عدد الشرائح التي تحتوي على ملاحظات. |
| [getParagraphs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | إجمالي عدد الفقرات، إذا كانت متوفرة. |
| [getWords](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getWords) | إجمالي عدد الكلمات. |
| [getMultimediaClips](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | إجمالي عدد مقاطع الصوت والفيديو. |

المثال التالي يقرأ هذه القيم دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) ويطبع جردًا مضغوطًا. كما يجمع بين [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) و[DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) لعرض مجموعات المحتوى مثل الخطوط، السمات، وعناوين الشرائح.

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

كل عنصر [HeadingPair](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/headingpair/) يوفر اسم المجموعة عبر [HeadingPair.getName](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/headingpair/#getName) وعدد العناصر في تلك المجموعة عبر [HeadingPair.getCount](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/headingpair/#getCount). تُعيد [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) مصفوفة مسطحة ومرتبة، لذا استهلك عدد العناوين المتتالية المحددة بكل زوج عنوان.

### **البيانات الوصفية المخزّنة وقيود التنسيق**

الخصائص التي تُعيدها [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) تعكس البيانات الوصفية المتوفرة في المستند الأصلي. لا تقوم Aspose.Slides بتحميل وتصفح نموذج كائن العرض التقديمي لإعادة حساب هذه القيم لهذه العملية. تُمثَّل الخصائص المفقودة بالقيم الافتراضية، وقد تكون القيم المخزّنة قديمة إذا لم تقم العملية التي حفظت الملف آخر مرة بتحديث خصائص المستند.

- **PPTX:** يوفر التنسيق خصائص مستند موسَّعة لعدد الشرائح، الملاحظات، الشرائح المخفيّة، الفقرات، الكلمات، والوسائط المتعددة، بالإضافة إلى أزواج العناوين وعناوين الأجزاء. يتوقف التوفر على الخصائص التي كتبها مُنتج المستند.
- **PPT:** يمكن للتنسيق الثنائي تخزين خصائص ملخص المستند المقابلة. إذا كانت الخاصية غائبة أو لم يُحدّثها مُنتج المستند، تُعيد Aspose.Slides القيمة المخزّنة أو الافتراضية بدلاً من حسابها من الشرائح.
- **ODP:** توفر بيانات تعريف OpenDocument إحصاءات عامة للمستند مثل عدد الصفحات، الفقرات، والكلمات، لكن هذه القيم لا تتطابق مع كل خاصية موسَّعة خاصة بـ PowerPoint. قد تكون بيانات الشرائح المخفيّة، ملاحظات الشرائح، الوسائط المتعددة، أزواج العناوين، وعناوين الأجزاء غير متوفرة، وقد تُعيد خصائص الجرد قيمًا افتراضية. لا تُعامل قيمة الصفر أو المصفوفة الفارغة كدليل قاطع على عدم وجود المحتوى المقابل.

استخدم نهج البيانات الوصفية الخفيفة للجرد والفحوصات الأولية.حمِّل العرض التقديمي وافحص نموذج كائنه الحي عندما يجب أن يعكس النتيجة التغييرات في الذاكرة أو عندما تحتاج إلى التحقق من المحتوى الفعلي للعرض التقديمي.

## **تحديث خصائص العرض التقديمي**

يمكن أيضًا تغيير الخصائص التي تُعيدها [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) دون إنشاء كائن [Presentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/) . طبّق التغييرات باستخدام [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/)، ثم اكتب العرض التقديمي المرتبط باستخدام [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

الصورة التالية تُظهر خصائص المستند الأصلية.

![خصائص المستند الأصلية للعرض التقديمي PowerPoint](input_properties.png)

المثال التالي يغيّر العنوان ووقت الحفظ الأخير ويكتب النتيجة إلى ملف جديد:

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

![خصائص المستند المغيّرة للعرض التقديمي PowerPoint](output_properties.png)

## **روابط مفيدة**

للتحقق من الأمان والإعدادات المتعلقة بالحماية، راجع المقالات التالية:

- [حماية العروض التقديمية بكلمة مرور](/slides/ar/nodejs-java/password-protected-presentation/)
- [حماية العروض التقديمية من الكتابة](/slides/ar/nodejs-java/write-protected-presentation/)

## **الأسئلة الشائعة**

**كيف يمكنني التحقق مما إذا كانت الخطوط مدمجة وأيها؟**

حمِّل العرض التقديمي واستخدم [Presentation.getFontsManager](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getfontsmanager/). استدعِ [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) للحصول على الخطوط المضمنة و[FontsManager.getFonts](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/fontsmanager/getfonts/) للحصول على الخطوط المستخدمة في العرض التقديمي. قارن النتيجتين لتحديد الخطوط المطلوبة للعرض ولكن غير المدمجة.

**كيف يمكنني بسرعة معرفة ما إذا كان الملف يحتوي على شرائح مخفيّة وعددها؟**

عندما تكون البيانات الوصفية المخزّنة كافية، اقرأ [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) عبر [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) و[PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). هذا مناسب لجرد خفيف الوزن. إذا تم تعديل العرض التقديمي في الذاكرة، قد تكون البيانات الوصفية المخزّنة مفقودة أو قديمة، أو إذا كنت تحتاج إلى التحقق من القيم الحية، استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslides/) وافحص طريقة [Slide.getHidden](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/gethidden/) لكل شريحة بدلاً من ذلك.

**هل يمكنني اكتشاف ما إذا كان حجم الشريحة المخصص واتجاهها مستخدمان، وما إذا كانا مختلفين عن الإعدادات الافتراضية؟**

نعم. حمِّل العرض التقديمي واستدعِ [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslidesize/). استخدم [SlideSize.getType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/gettype/)، [SlideSize.getSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/getsize/)، و[SlideSize.getOrientation](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/getorientation/) لمقارنة الإعدادات الحالية مع القالب المتوقع والأبعاد.

**هل هناك طريقة سريعة لرؤية ما إذا كانت المخططات تشير إلى مصادر بيانات خارجية؟**

نعم. حدد كل [Chart](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chart/) واستدعِ [ChartData.getDataSourceType](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). بالنسبة لدفتر عمل خارجي، استدعِ [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). نوع مصدر البيانات والمسار يحددان وجود إشارة خارجية، ولكن التحقق مما إذا كان الهدف متوفرًا يتطلب فحص موارد منفصل.

**كيف يمكنني تقييم “الشرائح الثقيلة” التي قد تبطئ العرض أو تصدير PDF؟**

لا توجد خاصية تعقيد واحدة. استعرض [Presentation.getSlides](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslides/) ومجموعة [BaseSlide.getShapes](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/baseslide/#getShapes) لكل شريحة. استخدم عدد الأشكال ووجود صور كبيرة، تأثيرات، حركات، أو وسائط متعددة كإشارات فحص، وقم بقياس عملية عرض أو تصدير تمثيلية قبل اعتبار الشريحة عنق زجاجة أداء مؤكد.