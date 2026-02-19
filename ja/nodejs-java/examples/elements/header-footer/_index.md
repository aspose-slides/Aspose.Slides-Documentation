---
title: ヘッダーとフッター
type: docs
weight: 220
url: /ja/nodejs-java/examples/elements/header-footer/
keywords:
- コード例
- ヘッダー
- フッター
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用してスライドのヘッダーとフッターを制御します。PPT、PPTX、ODP で日付、スライド番号、カスタムテキストを追加する JavaScript の例。"
---
この記事では、**Aspose.Slides for Node.js via Java** を使用してフッターを追加し、日付と時刻のプレースホルダーを更新する方法を示します。

## **フッターの追加**

スライドのフッター領域にテキストを追加し、表示させます。

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **日付と時刻の更新**

スライド上の日付と時刻のプレースホルダーを変更します。

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```