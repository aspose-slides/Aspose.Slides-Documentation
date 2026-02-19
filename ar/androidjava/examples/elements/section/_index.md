---
title: القسم
type: docs
weight: 90
url: /ar/androidjava/examples/elements/section/
keywords:
- مثال على الكود
- قسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Android
- Java
- Aspose.Slides
description: "إدارة أقسام الشرائح في Aspose.Slides لنظام Android: إنشاء، إعادة تسمية، إعادة ترتيب، وتجميع الشرائح مع أمثلة Java لصيغة PPT وPPTX وODP."
---
أمثلة لإدارة أقسام العرض التقديمي—الإضافة، الوصول، الحذف وإعادة التسمية برمجيًا باستخدام **Aspose.Slides for Android via Java**.

## **إضافة قسم**

إنشاء قسم يبدأ من شريحة محددة.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // حدد الشريحة التي تمثل بداية القسم.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **الوصول إلى قسم**

قراءة معلومات القسم من عرض تقديمي.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // الوصول إلى قسم بحسب الفهرس.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **إزالة قسم**

حذف قسم أضيف مسبقًا.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // إزالة القسم الأول.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **إعادة تسمية قسم**

تغيير اسم قسم موجود.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```