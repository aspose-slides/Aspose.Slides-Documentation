---
title: ActiveX
type: docs
weight: 200
url: /fa/androidjava/examples/elements/activex/
keywords:
- نمونه کد
- ActiveX
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "نمونه‌های ActiveX در Aspose.Slides برای Android را ببینید: افزودن، پیکربندی و کنترل اشیاء ActiveX در ارائه‌های PPT و PPTX با کد واضح Java."
---
این مقاله نشان می‌دهد که چگونه می‌توان کنترل‌های ActiveX را در یک ارائه با استفاده از **Aspose.Slides for Android via Java** اضافه، دسترسی، حذف و پیکربندی کرد.

## **Add an ActiveX Control**
یک کنترل ActiveX جدید درج کنید و به‌صورت اختیاری ویژگی‌های آن را تنظیم کنید.

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // افزودن یک کنترل ActiveX جدید.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // به‌صورت اختیاری برخی ویژگی‌ها را تنظیم کنید.
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **Access an ActiveX Control**
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

## **Remove an ActiveX Control**
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

## **Set ActiveX Properties**
یک کنترل اضافه کنید و چندین ویژگی ActiveX را پیکربندی کنید.

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // اضافه کردن یک کنترل Windows Media Player و پیکربندی ویژگی‌ها.
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```