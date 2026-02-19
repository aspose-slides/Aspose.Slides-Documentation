---
title: القسم
type: docs
weight: 90
url: /ar/java/examples/elements/section/
keywords:
- مثال على الكود
- قسم
- PowerPoint
- OpenDocument
- عرض تقديمي
- Java
- Aspose.Slides
description: "إدارة أقسام الشرائح في Aspose.Slides for Java: إنشاء، إعادة تسمية، إعادة ترتيب، وتجميع الشرائح مع أمثلة Java لملفات PPT و PPTX و ODP."
---
أمثلة لإدارة أقسام العرض—إضافتها، الوصول إليها، حذفها وإعادة تسميتها برمجياً باستخدام **Aspose.Slides for Java**.

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

        // الوصول إلى قسم عن طريق الفهرس.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **حذف قسم**

حذف قسم تمت إضافته مسبقاً.

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

تغيير اسم القسم الموجود.

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