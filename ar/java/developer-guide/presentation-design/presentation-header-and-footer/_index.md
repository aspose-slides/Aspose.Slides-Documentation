---
title: إدارة رؤوس وتذييلات العرض التقديمي في Java
linktitle: الرأس والتذييل
type: docs
weight: 140
url: /ar/java/presentation-header-and-footer/
keywords:
- رأس
- نص الرأس
- تذييل
- نص التذييل
- ضبط الرأس
- ضبط التذييل
- نسخة مطبوعة
- ملاحظات
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "استخدم Aspose.Slides for Java لإضافة وتخصيص رؤوس وتذييلات في عروض PowerPoint وOpenDocument للحصول على مظهر احترافي."
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/java/) يوفر دعماً للعمل مع نص رؤوس وتذييلات الشرائح والتي تُحافظ عليها فعلياً على مستوى ماستر الشريحة.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/ar/java/) يقدم ميزة إدارة الرؤوس والتذييلات داخل شرائح العرض. تُدار هذه في الواقع على مستوى ماستر العرض.

## **إدارة الرؤوس والتذييلات في عرض تقديمي**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:
```java
// تحميل العرض التقديمي
Presentation pres = new Presentation("headerTest.pptx");
try {
    // ضبط التذييل
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // الوصول إلى وتحديث الرأس
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // حفظ العرض
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


## **إدارة الرؤوس والتذييلات في شرائح النسخة المطبوعة والملاحظات**
يدعم Aspose.Slides for Java الرؤوس والتذييلات في شرائح النسخة المطبوعة والملاحظات. يرجى اتباع الخطوات أدناه:

- حمّل [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) يحتوي على فيديو.
- غيّر إعدادات الرأس والتذييل لِماستر الملاحظات وجميع شرائح الملاحظات.
- اجعل موضع تذييل ماستر الملاحظات وجميع التذييلات الفرعية مرئية.
- اجعل موضع التاريخ والوقت في ماستر الملاحظات وجميع المواضع الفرعية مرئية.
- غيّر إعدادات الرأس والتذييل للشرحة الملاحظة الأولى فقط.
- اجعل موضع الرأس في شريحة الملاحظات مرئياً.
- ضع النص في موضع الرأس بشريحة الملاحظات.
- ضع النص في موضع التاريخ/الوقت بشريحة الملاحظات.
- احفظ ملف العرض المعدل.

مقتطف الكود موفر في المثال أدناه.
```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // تغيير إعدادات الرأس والتذييل لماستر الملاحظات وجميع شرائح الملاحظات
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر العنصر الفرعي للتذييل مرئية
        headerFooterManager.setFooterAndChildFootersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر العنصر الفرعي للرأس مرئية
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر العنصر الفرعي لرقم الشريحة مرئية
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع عناصر العنصر الفرعي للتاريخ والوقت مرئية

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // ضبط النص على شريحة الملاحظات الرئيسية وجميع عناصر العنصر الفرعي للرأس
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // ضبط النص على شريحة الملاحظات الرئيسية وجميع عناصر العنصر الفرعي للتذييل
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // ضبط النص على شريحة الملاحظات الرئيسية وجميع عناصر العنصر الفرعي للتاريخ والوقت
    }

    // تغيير إعدادات الرأس والتذييل لشرحة الملاحظات الأولى فقط
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // جعل موضع رأس شريحة الملاحظات هذه مرئياً

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // جعل موضع تذييل شريحة الملاحظات هذه مرئياً

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // جعل موضع رقم الشريحة في شريحة الملاحظات هذه مرئياً

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // جعل موضع التاريخ والوقت في شريحة الملاحظات هذه مرئياً

        headerFooterManager.setHeaderText("New header text"); // ضبط النص على عنصر رأس شريحة الملاحظات
        headerFooterManager.setFooterText("New footer text"); // ضبط النص على عنصر تذييل شريحة الملاحظات
        headerFooterManager.setDateTimeText("New date and time text"); // ضبط النص على عنصر التاريخ والوقت في شريحة الملاحظات
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **الأسئلة المتداولة**

**هل يمكنني إضافة "رأس" إلى الشرائح العادية؟**

في PowerPoint، لا يوجد "رأس" إلا في الملاحظات والنسخ المطبوعة؛ في الشرائح العادية، العناصر المدعومة هي التذييل، التاريخ/الوقت، ورقم الشريحة. في Aspose.Slides تتطابق هذه القيود: الرأس متاح فقط للملاحظات/النسخ المطبوعة، وعلى الشرائح—التذييل/التاريخ والوقت/رقم الشريحة.

**ماذا لو لم يحتوي التخطيط على مساحة تذييل—هل يمكنني "تفعيل" رؤيته؟**

نعم. تحقق من رؤية العنصر عبر مدير الرأس/التذييل وقم بتمكينه إذا لزم الأمر. تم تصميم مؤشرات API وهذه الطرق للتعامل مع الحالات التي يكون فيها العنصر المخصص مفقوداً أو مخفياً.

**كيف يمكن جعل رقم الشريحة يبدأ من قيمة غير 1؟**

اضبط [رقم الشريحة الأولى](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) للعرض؛ بعد ذلك، يُعاد حساب جميع الأرقام. على سبيل المثال، يمكنك البدء من 0 أو 10، وإخفاء الرقم في شريحة العنوان.

**ماذا يحدث للرؤوس/التذييلات عند التصدير إلى PDF/صور/HTML؟**

يتم عرضها كعناصر نصية عادية في العرض. أي إذا كانت العناصر مرئية على الشرائح/صفحات الملاحظات، فستظهر أيضاً في تنسيق الإخراج مع باقي المحتوى.