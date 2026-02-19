---
title: ActiveX
type: docs
weight: 200
url: /zh/androidjava/examples/elements/activex/
keywords:
- 代码示例
- ActiveX
- PowerPoint
- 演示文稿
- Android
- Java
- Aspose.Slides
description: "查看 Aspose.Slides for Android 的 ActiveX 示例：在 PPT 和 PPTX 演示文稿中插入、配置和控制 ActiveX 对象，使用清晰的 Java 代码。"
---
本文演示了如何在演示文稿中使用 **Aspose.Slides for Android via Java** 添加、访问、删除和配置 ActiveX 控件。

## **添加 ActiveX 控件**

插入一个新的 ActiveX 控件，并可选择设置其属性。

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 添加一个新的 ActiveX 控件。
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // 可选地设置一些属性。
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **访问 ActiveX 控件**

读取幻灯片上第一个 ActiveX 控件的信息。

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 访问第一个 ActiveX 控件。
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **删除 ActiveX 控件**

从幻灯片中删除已有的 ActiveX 控件。

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 删除第一个 ActiveX 控件。
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **设置 ActiveX 属性**

添加控件并配置多个 ActiveX 属性。

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 添加 Windows Media Player 控件并配置属性。
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```