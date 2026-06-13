---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/androidjava/examples/elements/vba-macro/
keywords:
- مثال کد
- VBA
- ماکرو
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "پیشنهاد خودکار ارائه‌ها با Aspose.Slides برای Android: ایجاد، اجرا، وارد کردن و ایمن‌سازی ماکروهای VBA در فرمت‌های PPT، PPTX و ODP با استفاده از مثال‌های واضح Java."
---
این مقاله نشان می‌دهد چگونه می‌توان ماکروهای VBA را با استفاده از **Aspose.Slides for Android via Java** اضافه، دسترسی پیدا و حذف کرد.

## **افزودن یک ماکرو VBA**

یک ارائه با یک پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

```java
static void addVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به یک ماکرو VBA**

ماژول اول را از پروژه VBA بازیابی کنید.

```java
static void accessVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        IVbaModule firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **حذف یک ماکرو VBA**

یک ماژول را از پروژه VBA حذف کنید.

```java
static void removeVbaMacro() {
    Presentation presentation = new Presentation();
    try {
        presentation.setVbaProject(new VbaProject());

        IVbaModule module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.getVbaProject().getModules().remove(module);
    } finally {
        presentation.dispose();
    }
}
```