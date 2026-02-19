---
title: VBA マクロ
type: docs
weight: 150
url: /ja/nodejs-java/examples/elements/vba-macro/
keywords:
- コード例
- VBA
- マクロ
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用してプレゼンテーションを自動化します。PPT、PPTX、ODP で VBA マクロを作成、インポート、保護する明確な JavaScript サンプルを提供します。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用してVBAマクロを追加、アクセス、削除する方法を示します。

## **VBAマクロを追加**

VBAプロジェクトとシンプルなマクロモジュールを含むプレゼンテーションを作成します。

```js
function addVbaMacro() {
    let presentation = new aspose.slides.Presentation();
    try {
        presentation.setVbaProject(new aspose.slides.VbaProject());

        let module = presentation.getVbaProject().getModules().addEmptyModule("Module");
        module.setSourceCode("Sub Test()\n MsgBox \"Hi\" \nEnd Sub");

        presentation.save("vba_macro.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```

## **VBAマクロにアクセス**

VBAプロジェクトから最初のモジュールを取得します。

```js
function accessVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // プレゼンテーションに少なくとも1つのVBAモジュールがあると想定しています。
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);
    } finally {
        presentation.dispose();
    }
}
```

## **VBAマクロを削除**

VBAプロジェクトからモジュールを削除します。

```js
function removeVbaMacro() {
    let presentation = new aspose.slides.Presentation("vba_macro.pptm");
    try {
        // プレゼンテーションに少なくとも1つのVBAモジュールがあると想定しています。
        let firstModule = presentation.getVbaProject().getModules().get_Item(0);

        presentation.getVbaProject().getModules().remove(firstModule);

        presentation.save("vba_macro_removed.pptm", aspose.slides.SaveFormat.Pptm);
    } finally {
        presentation.dispose();
    }
}
```