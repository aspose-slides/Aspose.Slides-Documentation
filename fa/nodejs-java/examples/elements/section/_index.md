---
title: بخش
type: docs
weight: 90
url: /fa/nodejs-java/examples/elements/section/
keywords:
- نمونه کد
- بخش
- PowerPoint
- OpenDocument
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "مدیریت بخش‌های اسلاید در Aspose.Slides برای Node.js از طریق Java: ایجاد، تغییر نام، ترتیب‌دهی مجدد و گروه‌بندی اسلایدها با مثال‌های JavaScript برای PPT، PPTX و ODP."
---
نمونه‌هایی برای مدیریت بخش‌های ارائه — افزودن، دسترسی، حذف و تغییر نام آن‌ها به‌صورت برنامه‌نویسی با استفاده از **Aspose.Slides برای Node.js از طریق Java**.

## **افزودن بخش**

یک بخش ایجاد کنید که از یک اسلاید مشخص شروع می‌شود.

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // اسلایدی را که شروع بخش را نشان می‌دهد، مشخص کنید.
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به بخش**

اطلاعات بخش را از یک ارائه بخوانید.

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // دسترسی به یک بخش بر اساس اندیس.
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **حذف بخش**

یک بخش که قبلاً اضافه شده است را حذف کنید.

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // حذف اولین بخش.
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **تغییر نام بخش**

نام یک بخش موجود را تغییر دهید.

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```