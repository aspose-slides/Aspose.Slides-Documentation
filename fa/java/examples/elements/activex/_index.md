---
title: ActiveX
type: docs
weight: 200
url: /fa/java/examples/elements/activex/
keywords:
- مثال کد
- ActiveX
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "نمونه‌های ActiveX در Aspose.Slides برای Java را ببینید: افزودن، پیکربندی و کنترل اشیای ActiveX در ارائه‌های PPT و PPTX با کد واضح Java."
---
این مقاله نحوه افزودن، دسترسی، حذف و پیکربندی کنترل‌های ActiveX در یک ارائه با استفاده از **Aspose.Slides for Java** را نشان می‌دهد.

## **افزودن کنترل ActiveX**

یک کنترل ActiveX جدید اضافه کنید و در صورت نیاز ویژگی‌های آن را تنظیم کنید.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // یک کنترل ActiveX جدید اضافه کنید.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // در صورت نیاز برخی از ویژگی‌ها را تنظیم کنید.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **دسترسی به کنترل ActiveX**

اطلاعات اولین کنترل ActiveX روی اسلاید را بخوانید.

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // دسترسی به اولین کنترل ActiveX.
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **حذف کنترل ActiveX**

یک کنترل ActiveX موجود را از اسلاید حذف کنید.

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // حذف اولین کنترل ActiveX.
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **تنظیم ویژگی‌های ActiveX**

یک کنترل اضافه کنید و چندین ویژگی ActiveX را پیکربندی کنید.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // اضافه کردن کنترل Windows Media Player و پیکربندی ویژگی‌ها.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```