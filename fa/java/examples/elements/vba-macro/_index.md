---
title: ماکرو VBA
type: docs
weight: 150
url: /fa/java/examples/elements/vba-macro/
keywords:
- مثال کد
- VBA
- ماکرو
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "با Aspose.Slides for Java، ارائه‌ها را خودکار کنید: ایجاد، اجرا، وارد کردن و ایمن‌سازی ماکروهای VBA در قالب‌های PPT، PPTX و ODP با مثال‌های واضح Java."
---
این مقاله نحوهٔ افزودن، دسترسی و حذف ماکروهای VBA را با استفاده از **Aspose.Slides for Java** نشان می‌دهد.

## **افزودن ماکرو VBA**

یک ارائه با پروژه VBA و یک ماژول ماکرو ساده ایجاد کنید.

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

## **دسترسی به ماکرو VBA**

اولین ماژول را از پروژه VBA بازیابی کنید.

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

## **حذف ماکرو VBA**

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