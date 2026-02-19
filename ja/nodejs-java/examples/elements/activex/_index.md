---
title: ActiveX
type: docs
weight: 200
url: /ja/nodejs-java/examples/elements/activex/
keywords:
- コード例
- ActiveX
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js の ActiveX サンプルをご覧ください。PPT および PPTX プレゼンテーションで ActiveX オブジェクトを挿入、構成、制御する方法を、明確な JavaScript コードで示しています。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用して、プレゼンテーション内の ActiveX コントロールを追加、アクセス、削除、および構成する方法を示します。

## **ActiveX コントロールの追加**

スライドに新しい ActiveX コントロールを追加します。

```js
function addActiveX() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // 新しい ActiveX コントロールを追加します。
        let control = slide.getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 50, 50, 100, 50);

        presentation.save("activex.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX コントロールへのアクセス**

スライド上の最初の ActiveX コントロールから情報を取得します。

```js
function accessActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 最初の ActiveX コントロールにアクセスします。
            let control = slide.getControls().get_Item(0);

            console.log("Control Name:", control.getName());
            console.log("Value:", control.getProperties().get_Item("Value"));
        }
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX コントロールの削除**

スライドから既存の ActiveX コントロールを削除します。

```js
function removeActiveX() {
    let presentation = new aspose.slides.Presentation("activex.pptm");
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            // 最初の ActiveX コントロールを削除します。
            slide.getControls().removeAt(0);
        }

        presentation.save("activex_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **ActiveX プロパティの設定**

複数の ActiveX プロパティを構成します。

```js
function setActiveXProperties() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        if (slide.getControls().size() > 0) {
            let control = slide.getControls().get_Item(0);

            control.getProperties().set_Item("Caption", "Click Me");
            control.getProperties().set_Item("Enabled", "true");
        }

        presentation.save("activex_properties.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```