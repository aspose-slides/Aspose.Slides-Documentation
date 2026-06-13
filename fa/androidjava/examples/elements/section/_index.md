---
title: بخش
type: docs
weight: 90
url: /fa/androidjava/examples/elements/section/
keywords:
- مثال کد
- بخش
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید در Aspose.Slides برای Android: ایجاد، تغییر نام، ترتیب‌گذاری مجدد و گروه‌بندی اسلایدها با مثال‌های Java برای PPT، PPTX و ODP."
---
نمونه‌هایی برای مدیریت بخش‌های ارائه—اضافه کردن، دسترسی، حذف و تغییر نام آن‌ها به صورت برنامه‌نویسی با استفاده از **Aspose.Slides for Android via Java**.

## **افزودن یک بخش**

یک بخش را که از یک اسلاید خاص شروع می‌شود، ایجاد کنید.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // اسلایدی را که شروع بخش را مشخص می‌کند، مشخص کنید.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به یک بخش**

اطلاعات بخش را از یک ارائه بخوانید.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // دسترسی به بخش با ایندکس.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **حذف یک بخش**

یک بخش قبلاً اضافه‌شده را حذف کنید.

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

## **تغییر نام یک بخش**

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