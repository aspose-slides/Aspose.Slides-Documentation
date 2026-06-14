---
title: ActiveX
type: docs
weight: 200
url: /zh-hant/java/examples/elements/activex/
keywords:
- 程式碼範例
- ActiveX
- PowerPoint
- 簡報
- Java
- Aspose.Slides
description: "查看 Aspose.Slides for Java 的 ActiveX 範例：在 PPT 和 PPTX 簡報中插入、配置和控制 ActiveX 物件，並提供清晰的 Java 程式碼。"
---
本文示範如何在簡報中使用 **Aspose.Slides for Java** 新增、存取、移除和設定 ActiveX 控制項。

## **新增 ActiveX 控制項**

插入新的 ActiveX 控制項，並可選擇設定其屬性。

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 新增一個 ActiveX 控制項。
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // 可選地設定某些屬性。
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **存取 ActiveX 控制項**

讀取投影片上第一個 ActiveX 控制項的資訊。

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 存取第一個 ActiveX 控制項。
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **移除 ActiveX 控制項**

從投影片中刪除現有的 ActiveX 控制項。

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 移除第一個 ActiveX 控制項。
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **設定 ActiveX 屬性**

新增控制項並設定多個 ActiveX 屬性。

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 新增 Windows Media Player 控制項並設定屬性。
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```