---
title: تغيير حجم صفحة الملاحظات والاتجاه في JavaScript
linktitle: حجم صفحة الملاحظات
type: docs
weight: 10
url: /ar/nodejs-java/notes-size/
keywords:
- حجم صفحة الملاحظات
- اتجاه الملاحظات
- ملاحظات أفقية
- ملاحظات رأسية
- حجم النشرة
- PowerPoint
- عرض تقديمي
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "قراءة وتغيير أبعاد صفحة الملاحظات في Aspose.Slides لـ Node.js عبر Java، وتبديل الاتجاه، والتحقق من الأحجام المحفوظة، وتصدير الملاحظات أو النشرات إلى PDF والصور."
---
## **نظرة عامة**

استخدم [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getnotessize/) للوصول إلى إعدادات صفحة الملاحظات في العرض التقديمي. تُعيد كائنًا من نوع [NotesSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notessize/) whose [setSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notessize/setsize/) method sets the page dimensions. على الرغم من أنه لا يمكن استبدال كائن الإعدادات نفسه، يمكنك تعيين أبعاد جديدة عبر هذه الطريقة.

العرض والارتفاع محددان بـ **النقاط**، حيث يوجد 72 نقطة لكل بوصة. على سبيل المثال، 900 × 600 نقطة يساوي 12.5 × 8⅓ بوصة. تُطبق هذه الإعدادات على العرض التقديمي كله، وليس على ملاحظات شريحة فردية.

| الإعداد | الغرض |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getnotessize/) | يتحكم في أبعاد صفحة الملاحظات وأبعاد الصفحة المستخدمة لتصدير النشرة. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getslidesize/) | يتحكم في أبعاد شرائح العرض التقديمي العادية عبر [SlideSize](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slidesize/). |

تغيير أي من الإعدادين لا يغيّر الآخر تلقائيًا. تغيير اتجاه صفحة الملاحظات لا يدور الشرائح العادية أيضًا. راجع [حجم الشريحة](/slides/ar/nodejs-java/slide-size/) لتغيير حجم الشرائح العادية.

تستخدم الأمثلة أدناه ملف `sample.pptx` موجود. لتصدير الأمثلة، استخدم عرضًا تقديميًا يحتوي على شريحة واحدة على الأقل مع ملاحظات المتحدث. يمكن تشغيل كل مثال بشكل مستقل.

## **قراءة حجم صفحة الملاحظات واتجاهها**

اقرأ عرض وارتفاع الصفحة وقارنهما لتحديد الاتجاه: الصفحة الأعرض هي أفقية، والصفحة الأطول هي رأسية، والأبعاد المتساوية تصف صفحة مربعة. يطبع هذا المثال الأبعاد الفعلية بالنقاط، دون افتراض حجم ورق قياسي.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();
    let orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    console.log("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    console.log("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **التبديل إلى الوضع الأفقي دون تغيير حجم الورق**

لتغيير الاتجاه فقط، قم بتبديل العرض والارتفاع الحاليين. هذا يحافظ على أطوال الجانبين، بما في ذلك تلك الخاصة بحجم ورق مخصص. الشرط أدناه يمنع تحويل صفحة أفقية بالفعل إلى وضع عمودي ويترك الصفحة المربعة دون تعديل.

```javascript
const slides = require("aspose.slides.via.java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        let width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

للاتجاه العمودي، استخدم نفس التعيين عندما تكون `size.getWidth() > size.getHeight()`. لا تستبدل أبعاد A4 أو Letter إلا إذا رغبت أيضًا في تغيير حجم الورق.

## **تعيين والتحقق من حجم صفحة ملاحظات مخصص**

قم بتعيين كلا البعدين معًا، ثم استخدم [Presentation.save](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/save/) لحفظ العرض التقديمي. يحدد هذا المثال صفحة أفقية بحجم 900 × 600 نقطة، ويحفظها كملف PPTX، ثم يفتح الملف المحفوظ مرة أخرى للتحقق من القيم المُستدامة. يسمح المقارنة بحد تحمل 0.01 نقطة للقيم العائمة؛ وهذا ليس ضمانًا للدقة في كل تنسيق ملف.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let expectedSize = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", slides.SaveFormat.Pptx);

    let reopened = new slides.Presentation("custom-notes.pptx");
    try {
        let actualSize = reopened.getNotesSize().getSize();
        let widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        let heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        let preserved = widthMatches && heightMatches;

        console.log("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        console.log("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

النتيجة المتوقعة هي `900 x 600 نقطة` و `Size preserved: true`. يتحقق فحص عرض تقديمي مفتوح حديثًا من الملف المحفوظ، بدلاً من مجرد الإعدادات في الذاكرة.

## **تصدير الملاحظات والنشرات**

تحدد أبعاد الصفحة المنطقة المتاحة لتصاميم الملاحظات أو النشرات. لا تقوم بتمكين هذه التصاميم بمفردها: يجب أيضًا ضبط خيارات التصدير. يستمر تصدير الشرائح العادية في استخدام أبعاد الشريحة.

### **تصدير الملاحظات إلى PDF و PNG**

عيّن [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notescommentslayoutingoptions/) إلى [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions) لتضمين الملاحظات في ملف PDF. يصرّف هذا المثال أيضًا الشريحة الأولى مع الملاحظات إلى PNG باستخدام [Slide.getImage](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/slide/#getImage) و [RenderingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/renderingoptions/).

يحتفظ وضع [BottomTruncated](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notespositions/) بالملاحظات على صفحة واحدة؛ يمكن قطع الملاحظات التي لا تتناسب. يستخدم الـ PDF صفحات بحجم 900 × 600 نقطة. عند مقياس الصورة 1 × 1 المستخدم أدناه، يكون PNG بحجم 900 × 600 بكسل. النقاط تصف هندسة الصفحة؛ البكسلات تصف المخرجات النقطية، التي تعتمد أبعادها أيضًا على مقياس العرض.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.NotesCommentsLayoutingOptions();
    layout.setNotesPosition(slides.NotesPositions.BottomTruncated);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", slides.SaveFormat.Pdf, pdfOptions);

    let renderingOptions = new slides.RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    let image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

لتصدير PDF مع ملاحظات طويلة، يسمح وضع [BottomFull](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/notespositions/) بصفحات إضافية حسب الحاجة. لا تستخدم هذا الوضع مع استدعاء الصورة لشريحة واحدة أعلاه، لأنه لا يدعمه. بعد تغيير الحجم، افحص الناتج لتحديد ما إذا كانت الملاحظات مقصوفة ومكان كائنات notes-master الموجودة؛ تغيير أبعاد الصفحة وحده لا يجب أن يُعتبر ضمانًا بأن جميع المحتويات ستتناسب. راجع [Convert PowerPoint to PDF with Notes](/slides/ar/nodejs-java/convert-powerpoint-to-pdf-with-notes/) للمزيد عن تصدير الملاحظات.

### **تصدير النشرات إلى PDF**

استخدم [HandoutLayoutingOptions](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handoutlayoutingoptions/) لعرض عدة صور مصغرة للشرائح على صفحة واحدة. يحدد المثال التالي صفحة بحجم 900 × 600 نقطة ويستخدم [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/handouttype/) لترتيب ما يصل إلى أربع شرائح لكل صفحة. يحدد الإعداد الأفقي ترتيب الشرائح؛ ويأتي اتجاه الصفحة من عرضه وارتفاعه.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new slides.Presentation("sample.pptx");
try {
    let size = java.newInstanceSync("java.awt.Dimension", 900, 600);
    presentation.getNotesSize().setSize(size);

    let layout = new slides.HandoutLayoutingOptions();
    layout.setHandout(slides.HandoutType.Handouts4Horizontal);

    let pdfOptions = new slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

تغيير حجم الصفحة يغيّر المنطقة المتاحة لشبكة النشرة دون تغيير أبعاد الشرائح المصدرية. للحصول على صور النشرات، استخدم [Presentation.getImages](https://reference.aspose.com/slides/ar/nodejs-java/aspose.slides/presentation/getimages/) مع تخطيط النشرة، بدلاً من طريقة صورة شريحة فردية. في Aspose.Slides، يستخدم تصيير النشرة على مستوى العرض التقديمي أبعاد صفحة الملاحظات، بينما لا ينتج استدعاء صورة شريحة فردية صفحة النشرة. راجع [Handout Mode](/slides/ar/nodejs-java/convert-powerpoint-in-handout-mode/) لخيار التخطيط.

## **حجم الصفحة في المشاهدين، التصدير والطباعة**

احتفظ بحجم العرض التقديمي المخزن، وحجم الصفحة المصدّر، وحجم الورق المطبوع كأمور منفصلة:

- **Presentation viewers:** يمكن للعارض عرض أو طباعة الملاحظات باستخدام قواعد التخطيط الخاصة به. إذا حفظ تطبيق آخر الملف، أعد فتحه وتحقق من الأبعاد مرة أخرى؛ قد تقوم عملية تحويل الصيغة في ذلك التطبيق بتطبيعها.
- **Export formats:** تستخدم أمثلة PDF للملاحظات والنشرات أعلاه أبعاد الصفحة المُكوّنة. تستخدم الصور النقطية أبعاد بكسل صحيحة ومقياس عرض، لذا قد تُقَرّب القيم الكسرية للنقطة في ناتج الصورة. لا يُطبق تصدير الشرائح العادية حجم صفحة الملاحظات.
- **Printer drivers:** يمكن لاختيار الورق، والدوران التلقائي، وإعدادات الملاءمة للصفحة أن تغير المخرجات الفعلية دون تغيير الأبعاد المخزنة في العرض التقديمي أو PDF. للحصول على حجم ورق معين، طابق إعدادات الطابعة وتفحص معاينة الطباعة.

## **الأسئلة الشائعة**

**هل يمكنني ضبط حجم الملاحظات لشريحة واحدة فقط؟**

حجم صفحة الملاحظات هو إعداد على مستوى العرض التقديمي. يمكن للشرائح الفردية أن تحتوي على محتوى ملاحظات مختلف، لكن هذه الخاصية لا توفر حجم صفحة منفصل لكل شريحة.

**لماذا لم يغيّر تغيير اتجاه الملاحظات الشرائح الخاصة بي؟**

صفحات الملاحظات والشرائح العادية لها أبعاد مستقلة. استخدم إعدادات حجم الشريحة العادية عندما تريد تغيير حجم الشرائح نفسها.

**لماذا يكون للنتيجة المحفوظة أو المطبوعة حجم مختلف؟**

ابدأ بإعادة فتح العرض التقديمي المحفوظ وقارن أبعاد الملاحظات. إذا تغيرت، تحقق مما إذا كان حفظ أو تحويل الملف في تطبيق آخر قد غيّر إعدادات الصفحة. إذا لم يحدث ذلك، فافحص تخطيط التصدير، ومقياس الصورة، وإعدادات المشاهد، واختيار ورق الطابعة.