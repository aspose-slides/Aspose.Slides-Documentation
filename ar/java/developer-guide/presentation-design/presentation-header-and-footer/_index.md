---
title: رأس وتذييل العرض
type: docs
weight: 140
url: /ar/java/presentation-header-and-footer/
keywords: "رأس وتذييل PowerPoint في Java"
description: "رأس وتذييل PowerPoint في Java"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/java/) توفر دعمًا للعمل مع نصوص رؤوس وتذييلات الشريحة التي يتم الحفاظ عليها على مستوى الشريحة الرئيسية.

{{% /alert %}} 

[Aspose.Slides for Java](/slides/ar/java/) توفر ميزة إدارة الرؤوس والتذييلات داخل الشرائح العرضية. يتم إدارة هذه في الواقع على مستوى العرض الرئيسي.

## **إدارة الرأس والتذييل في العرض**
يمكن إزالة ملاحظات شريحة معينة كما هو موضح في المثال أدناه:

```java
// تحميل العرض
Presentation pres = new Presentation("headerTest.pptx");
try {
    // تعيين التذييل
    pres.getHeaderFooterManager().setAllFootersText("نص التذييل الخاص بي");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // الوصول إلى الرأس وتحديثه
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
                ((IAutoShape)shape).getTextFrame().setText("مرحبًا هناك، رأس جديد");
            }
        }
    }
}
```

## **إدارة الرأس والتذييل في الشرائح الموزعة والملاحظات**
Aspose.Slides for Java تدعم الرأس والتذييل في الشرائح الموزعة وملاحظات الشرائح. يُرجى اتباع الخطوات أدناه:

- تحميل [عرض](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) يحتوي على فيديو.
- تغيير إعدادات الرأس والتذييل للعرض الرئيسي وجميع شرائح الملاحظات.
- جعل شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتذييل مرئية.
- جعل شريحة الملاحظات الرئيسية وجميع العناصر الفرعية لتاريخ ووقت التذييل مرئية.
- تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط.
- جعل عنصر الرأس في شريحة الملاحظات مرئيًا.
- تعيين نص لعنصر الرأس في شريحة الملاحظات.
- تعيين نص لعنصر التاريخ والوقت في شريحة الملاحظات.
- كتابة ملف العرض المعدل.

تم تقديم مقتطف الكود في المثال أدناه.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // تغيير إعدادات الرأس والتذييل للعرض الرئيسي وجميع شرائح الملاحظات
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتذييل مرئية
        headerFooterManager.setFooterAndChildFootersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للرأس مرئية
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر الفرعية لرقم الشريحة مرئية
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // جعل شريحة الملاحظات الرئيسية وجميع العناصر الفرعية لتاريخ ووقت التذييل مرئية

        headerFooterManager.setHeaderAndChildHeadersText("نص الرأس"); // تعيين نص لشريحة الملاحظات الرئيسية وجميع العناصر الفرعية للرأس
        headerFooterManager.setFooterAndChildFootersText("نص التذييل"); // تعيين نص لشريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتذييل
        headerFooterManager.setDateTimeAndChildDateTimesText("نص التاريخ والوقت"); // تعيين نص لشريحة الملاحظات الرئيسية وجميع العناصر الفرعية لتاريخ ووقت التذييل
    }

    // تغيير إعدادات الرأس والتذييل لشريحة الملاحظات الأولى فقط
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // جعل عنصر الرأس في شريحة الملاحظات مرئيًا

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // جعل عنصر التذييل في شريحة الملاحظات مرئيًا

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // جعل عنصر رقم الشريحة في شريحة الملاحظات مرئيًا

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // جعل عنصر التاريخ والوقت في شريحة الملاحظات مرئيًا

        headerFooterManager.setHeaderText("نص الرأس الجديد"); // تعيين نص لعنصر الرأس في شريحة الملاحظات
        headerFooterManager.setFooterText("نص التذييل الجديد"); // تعيين نص لعنصر التذييل في شريحة الملاحظات
        headerFooterManager.setDateTimeText("نص التاريخ والوقت الجديد"); // تعيين نص لعنصر التاريخ والوقت في شريحة الملاحظات
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```