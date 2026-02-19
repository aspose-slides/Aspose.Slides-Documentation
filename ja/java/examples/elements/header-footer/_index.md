---
title: ヘッダー フッター
type: docs
weight: 220
url: /ja/java/examples/elements/header-footer/
keywords:
- コード例
- ヘッダー
- フッター
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java を使用してスライドのヘッダーとフッターを制御します。PPT、PPTX、ODP で日付、スライド番号、カスタムテキストを追加する Java のサンプルです。"
---
この記事では、**Aspose.Slides for Java** を使用してフッターの追加と日付と時刻のプレースホルダーの更新方法を示します。

## **フッターの追加**
スライドのフッター領域にテキストを追加し、表示できるようにします。

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **日付と時刻の更新**
スライド上の日付と時刻のプレースホルダーを変更します。

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```