---
title: ترويسة وتذييل العرض التقديمي
type: docs
weight: 140
url: /ar/androidjava/presentation-header-and-footer/
keywords: "ترويسة وتذييل PowerPoint في جافا"
description: "ترويسة وتذييل PowerPoint في جافا"
---

{{% alert color="primary" %}} 

[Aspose.Slides](/slides/ar/androidjava/) يوفر دعمًا للعمل مع نصوص ترويسة وتذييل الشرائح التي تُدار في الواقع على مستوى شريحة العرض الرئيسية.

{{% /alert %}} 

[Aspose.Slides for Android via Java](/slides/ar/androidjava/) يوفر ميزة إدارة الترويسات والتذييلات داخل شرائح العرض التقديمي. هذه في الواقع تُدار على مستوى العرض التقديمي الرئيسي.

## **إدارة الترويسة والتذييل في العرض التقديمي**
يمكن إزالة ملاحظات بعض الشرائح المحددة كما هو موضح في المثال أدناه:

```java
// تحميل العرض التقديمي
Presentation pres = new Presentation("headerTest.pptx");
try {
    // إعداد التذييل
    pres.getHeaderFooterManager().setAllFootersText("نص تذييل خاصتي");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // الوصول وتحديث الترويسة
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
// طريقة لتعيين نص الترويسة/التذييل
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("مرحبًا بك هنا، ترويسة جديدة");
            }
        }
    }
}
```

## **إدارة الترويسة والتذييل في شرائح الملاحظات والمساعدة**
يدعم Aspose.Slides for Android via Java الترويسة والتذييل في شرائح المساعدة والملاحظات. يرجى اتباع الخطوات أدناه:

- تحميل [عرض تقديمي](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) يحتوي على فيديو.
- تغيير إعدادات الترويسة والتذييل لرئيسية الملاحظات وجميع شرائح الملاحظات.
- جعل ترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتذييل مرئية.
- جعل ترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية لتاريخ ووقت مرئية.
- تغيير إعدادات الترويسة والتذييل لشريحة الملاحظات الأولى فقط.
- جعل عنصر ترويسة شريحة الملاحظات مرئيًا.
- تعيين النص لعنصر ترويسة شريحة الملاحظات.
- تعيين النص لعنصر تاريخ ووقت شريحة الملاحظات.
- كتابة ملف العرض التقديمي المعدل.

تم توفير مقتطف الكود في المثال أدناه.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // تغيير إعدادات الترويسة والتذييل لرئيسية الملاحظات وجميع شرائح الملاحظات
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // جعل ترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتذييل مرئية
        headerFooterManager.setFooterAndChildFootersVisibility(true); // جعل ترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للترويسة مرئية
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // جعل ترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية لرقم الشريحة مرئية
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // جعل ترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتاريخ والوقت مرئية

        headerFooterManager.setHeaderAndChildHeadersText("نص الترويسة"); // تعيين النص لترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للترويسة
        headerFooterManager.setFooterAndChildFootersText("نص التذييل"); // تعيين النص لترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتذييل
        headerFooterManager.setDateTimeAndChildDateTimesText("نص التاريخ والوقت"); // تعيين النص لترويسة شريحة الملاحظات الرئيسية وجميع العناصر الفرعية للتاريخ والوقت
    }

    // تغيير إعدادات الترويسة والتذييل لشريحة الملاحظات الأولى فقط
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // جعل عنصر ترويسة هذه الشريحة مرئيًا

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // جعل عنصر تذييل هذه الشريحة مرئيًا

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // جعل عنصر رقم الشريحة لهذه الشريحة مرئيًا

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // جعل عنصر تاريخ ووقت هذه الشريحة مرئيًا

        headerFooterManager.setHeaderText("نص ترويسة جديدة"); // تعيين النص لعنصر ترويسة شريحة الملاحظات
        headerFooterManager.setFooterText("نص تذييل جديد"); // تعيين النص لعنصر تذييل شريحة الملاحظات
        headerFooterManager.setDateTimeText("نص جديد للتاريخ والوقت"); // تعيين النص لعنصر تاريخ ووقت شريحة الملاحظات
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```