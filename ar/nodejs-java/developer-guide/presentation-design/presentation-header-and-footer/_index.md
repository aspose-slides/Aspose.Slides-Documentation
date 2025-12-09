---
title: رأس وتذييل العرض التقديمي
type: docs
weight: 140
url: /ar/nodejs-java/presentation-header-and-footer/
keywords: "رأس وتذييل PowerPoint في JavaScript"
description: "رأس وتذييل PowerPoint في JavaScript"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/nodejs-java/) يوفر الدعم للعمل مع نص رؤوس وتذييلات الشرائح التي يتم صيانتها فعليًا على مستوى ماستر الشريحة.

{{% /alert %}} 

[Aspose.Slides for Node.js via Java](/slides/ar/nodejs-java/) توفر ميزة إدارة الرؤوس والتذييلات داخل شرائح العروض التقديمية. يتم إدارة هذه فعليًا على مستوى ماستر العرض.

## **إدارة الرأس والتذييل في العرض التقديمي**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
```javascript
// تحميل العرض التقديمي
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // تعيين التذييل
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // الوصول وتحديث الرأس
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // حفظ العرض التقديمي
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **إدارة الرأس والتذييل في شرائح النشرات والملاحظات**
تدعم Aspose.Slides for Node.js عبر Java الرؤوس والتذييلات في شرائح النشرات والملاحظات. يرجى اتباع الخطوات التالية:

- حمّل [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) يحتوي على فيديو.
- غيّر إعدادات الرأس والتذييل لماستر الملاحظات وجميع شرائح الملاحظات.
- اجعل شريحة ماستر الملاحظات وجميع عناصر التذييل الفرعية مرئية.
- اجعل شريحة ماستر الملاحظات وجميع عناصر التاريخ والوقت الفرعية مرئية.
- غيّر إعدادات الرأس والتذييل للشريحة الأولى للملاحظات فقط.
- اجعل عنصر رأس شريحة الملاحظات مرئيًا.
- عيّن النص إلى عنصر رأس شريحة الملاحظات.
- عيّن النص إلى عنصر التاريخ والوقت لشريحة الملاحظات.
- احفظ ملف العرض المعدل.

يوجد مقطع شفرة في المثال أدناه.
```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // تغيير إعدادات الرأس والتذييل للماستر الملاحظات وجميع شرائح الملاحظات
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتذييل الفرعية مرئية
        headerFooterManager.setFooterAndChildFootersVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للرأس الفرعية مرئية
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة لأرقام الشرائح الفرعية مرئية
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// اجعل شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتاريخ والوقت الفرعية مرئية
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// تعيين النص إلى شريحة الملاحظات الرئيسية وجميع العناصر النائبة للرأس الفرعية
        headerFooterManager.setFooterAndChildFootersText("Footer text");// تعيين النص إلى شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتذييل الفرعية
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// تعيين النص إلى شريحة الملاحظات الرئيسية وجميع العناصر النائبة للتاريخ والوقت الفرعية
    }
    // تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// اجعل عنصر الرأس في هذه الشريحة الملاحظات مرئيًا
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// اجعل عنصر التذييل في هذه الشريحة الملاحظات مرئيًا
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// اجعل عنصر رقم الشريحة في هذه الشريحة الملاحظات مرئيًا
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// اجعل عنصر التاريخ والوقت في هذه الشريحة الملاحظات مرئيًا
        headerFooterManager.setHeaderText("New header text");// تعيين النص إلى عنصر الرأس في شريحة الملاحظات
        headerFooterManager.setFooterText("New footer text");// تعيين النص إلى عنصر التذييل في شريحة الملاحظات
        headerFooterManager.setDateTimeText("New date and time text");// تعيين النص إلى عنصر التاريخ والوقت في شريحة الملاحظات
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **الأسئلة الشائعة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، يوجد "رأس" فقط للملاحظات والنشرات؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق ذلك مع نفس القيود: الرأس فقط للملاحظات/النشرات، وعلى الشرائح—التذييل/التاريخ والوقت/رقم الشريحة.

**ماذا لو لم يحتوي التصميم على منطقة تذييل—هل يمكنني "تفعيل" رؤيتها؟**

نعم. تحقق من الرؤية عبر مدير الرأس/التذييل وقم بتمكينه إذا لزم الأمر. تم تصميم مؤشرات وطرق API هذه للحالات التي يكون فيها العنصر النائب مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

حدد [رقم الشريحة الأول](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/setfirstslidenumber/); بعد ذلك يتم إعادة حساب جميع الأرقام. على سبيل المثال، يمكنك البدء بـ 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض التقديمي. أي إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، فستظهر أيضًا في تنسيق الإخراج إلى جانب باقي المحتوى.