---
title: إدارة رؤوس وتذييلات العروض التقديمية على Android
linktitle: رأس & تذييل
type: docs
weight: 140
url: /ar/androidjava/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- تعيين رأس
- تعيين تذييل
- نشرة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "استخدم Aspose.Slides لأندرويد عبر Java لإضافة وتخصيص الرؤوس والتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

{{% alert color="primary" %}} 

يوفر [Aspose.Slides](/slides/ar/androidjava/) الدعم للعمل مع نص رؤوس وتذييلات الشرائح التي يتم الحفاظ عليها فعليًا على مستوى ماستر الشريحة.

{{% /alert %}} 

يوفر [Aspose.Slides for Android via Java](/slides/ar/androidjava/) ميزة إدارة الرؤوس والتذييلات داخل شرائح العرض. يتم إدارة هذه في الواقع على مستوى ماستر العرض.

## **إدارة الرؤوس والتذييلات في العرض التقديمي**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
```java
// تحميل العرض التقديمي
Presentation pres = new Presentation("headerTest.pptx");
try {
    // تعيين التذييل
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // الوصول إلى الرأس وتحديثه
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // حفظ العرض التقديمي
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
// طريقة لتعيين نص الرأس/التذييل
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```


## **إدارة الرؤوس والتذييلات في شرائح النشرات والملاحظات**
يدعم Aspose.Slides for Android عبر Java الرؤوس والتذييلات في شرائح النشرات والملاحظات. يرجى اتباع الخطوات التالية:

- تحميل [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على فيديو.
- تغيير إعدادات الرؤوس والتذييلات للماستر الخاص بالملاحظات وجميع شرائح الملاحظات.
- ضبط ظهور شريحة الملاحظات الرئيسية وجميع العنصر النائب للتذييل الفرعي.
- ضبط ظهور شريحة الملاحظات الرئيسية وجميع العنصر النائب للتاريخ والوقت الفرعي.
- تغيير إعدادات الرؤوس والتذييلات لشريحة الملاحظات الأولى فقط.
- ضبط ظهور عنصر النائب للرأس في شريحة الملاحظات.
- إدخال النص في عنصر النائب للرأس في شريحة الملاحظات.
- إدخال النص في عنصر النائب للتاريخ/الوقت في شريحة الملاحظات.
- كتابة ملف العرض التقديمي المعدل.

القطعة البرمجية مقدمة في المثال أدناه.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // تغيير إعدادات الرأس والتذييل لماستر الملاحظات وجميع شرائح الملاحظات
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // اجعل شريحة ماستر الملاحظات وجميع عناصر النائب للتذييل التابعة مرئية
        headerFooterManager.setFooterAndChildFootersVisibility(true); // اجعل شريحة ماستر الملاحظات وجميع عناصر النائب للرأس التابعة مرئية
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // اجعل شريحة ماستر الملاحظات وجميع عناصر النائب لرقم الشريحة التابعة مرئية
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // اجعل شريحة ماستر الملاحظات وجميع عناصر النائب للتاريخ والوقت التابعة مرئية

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ضع النص في شريحة ماستر الملاحظات وجميع عناصر النائب للرأس التابعة
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ضع النص في شريحة ماستر الملاحظات وجميع عناصر النائب للتذييل التابعة
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ضع النص في شريحة ماستر الملاحظات وجميع عناصر النائب للتاريخ والوقت التابعة
    }

    // تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // اجعل عنصر نائب الرأس لهذه الشريحة مرئياً

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // اجعل عنصر نائب التذييل لهذه الشريحة مرئياً

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // اجعل عنصر نائب رقم الشريحة لهذه الشريحة مرئياً

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // اجعل عنصر نائب التاريخ والوقت لهذه الشريحة مرئياً

        headerFooterManager.setHeaderText("New header text"); // ضع النص في عنصر نائب الرأس لشريحة الملاحظات
        headerFooterManager.setFooterText("New footer text"); // ضع النص في عنصر نائب التذييل لشريحة الملاحظات
        headerFooterManager.setDateTimeText("New date and time text"); // ضع النص في عنصر نائب التاريخ والوقت لشريحة الملاحظات
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، لا يوجد "رأس" إلا للملاحظات والنشرات؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides يتطابق ذلك مع نفس القيود: الرأس متاح فقط للملاحظات/النشرات، وعلى الشرائح—التذييل/التاريخ والوقت/رقم الشريحة.

**ماذا لو لم يحتوي التخطيط على منطقة تذييل—هل يمكنني "تفعيل" رؤيتها؟**

نعم. تحقق من الرؤية عبر مدير الرأس/التذييل وقم بتمكينه إذا لزم الأمر. تم تصميم مؤشرات و طرق API هذه للحالات التي يكون فيها العنصر النائب مفقودًا أو مخفيًا.

**كيف أجعل رقم الشريحة يبدأ من قيمة غير 1؟**

حدد [رقم الشريحة الأول](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) للعرض التقديمي؛ بعد ذلك يتم إعادة حساب جميع أرقام الشرائح. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم على شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صُور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض التقديمي. أي إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، فستظهر أيضًا في صيغة الإخراج إلى جانب باقي المحتوى.