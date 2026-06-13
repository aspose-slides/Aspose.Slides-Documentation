---
title: بخش
type: docs
weight: 90
url: /fa/java/examples/elements/section/
keywords:
- مثال کد
- بخش
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید در Aspose.Slides for Java: ایجاد، تغییر نام، ترتیب‌دهنی و گروه‌بندی اسلایدها با مثال‌های Java برای PPT، PPTX و ODP."
---
مثال‌هایی برای مدیریت بخش‌های ارائه—افزودن، دسترسی، حذف و تغییر نام آن‌ها به صورت برنامه‌نویسی با استفاده از **Aspose.Slides for Java**.

## **افزودن بخش**

بخشی را ایجاد کنید که از اسلاید خاصی شروع می‌شود.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // اسلایدی را که شروع بخش را نشان می‌دهد مشخص کنید.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به بخش**

اطلاعات بخش را از یک ارائه بخوانید.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // دسترسی به یک بخش با اندیس.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **حذف بخش**

بخش اضافه‌شده پیشین را حذف کنید.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // حذف اولین بخش.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **تغییر نام بخش**

نام یک بخش موجود را تغییر دهید.

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