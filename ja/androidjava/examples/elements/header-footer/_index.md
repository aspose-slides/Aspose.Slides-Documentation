---
title: ヘッダーとフッター
type: docs
weight: 220
url: /ja/androidjava/examples/elements/header-footer/
keywords:
- コード例
- ヘッダー
- フッター
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用してスライドのヘッダーとフッターを制御します。PPT、PPTX、ODP で日付、スライド番号、カスタムテキストを Java のサンプルで追加できます。"
---
この記事では、**Aspose.Slides for Android via Java** を使用して、フッターを追加し、日付と時刻のプレースホルダーを更新する方法を示します。

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