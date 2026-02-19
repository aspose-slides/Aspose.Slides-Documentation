---
title: ActiveX
type: docs
weight: 200
url: /ja/androidjava/examples/elements/activex/
keywords:
- コード例
- ActiveX
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android の ActiveX の例をご覧ください: PPT および PPTX プレゼンテーションで ActiveX オブジェクトを挿入、構成、制御するための明確な Java コードです。"
---
この記事では、**Aspose.Slides for Android via Java** を使用して、プレゼンテーション内の ActiveX コントロールの追加、アクセス、削除、および構成方法を示します。

## **ActiveX コントロールの追加**

新しい ActiveX コントロールを挿入し、必要に応じてそのプロパティを設定します。

```java
static void addActiveX() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // 新しい ActiveX コントロールを追加します。
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        // 必要に応じていくつかのプロパティを設定します。
        control.getProperties().add("Value", "Default text");

        presentation.save("add_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX コントロールへのアクセス**

スライド上の最初の ActiveX コントロールから情報を読み取ります。

```java
static void accessActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 最初の ActiveX コントロールにアクセスします。
            IControl control = slide.getControls().get_Item(0);

            System.out.println("Control Name: " + control.getName());
            System.out.println("Value: " + control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX コントロールの削除**

スライドから既存の ActiveX コントロールを削除します。

```java
public static void removeActiveX() {
    Presentation presentation = new Presentation("add_activex.pptm");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 最初の ActiveX コントロールを削除します。
            slide.getControls().removeAt(0);
        }

        presentation.save("removed_activex.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX プロパティの設定**

コントロールを追加し、複数の ActiveX プロパティを構成します。

```java
public static void setActiveXProperties() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Windows Media Player コントロールを追加し、プロパティを構成します。
        IControl control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 50, 50, 150, 50);
        control.getProperties().set_Item("Caption", "Click Me");
        control.getProperties().set_Item("Enabled", "true");

        presentation.save("set_activex_props.pptm", SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```