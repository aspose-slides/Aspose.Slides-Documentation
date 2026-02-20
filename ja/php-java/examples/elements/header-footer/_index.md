---
title: ヘッダー フッター
type: docs
weight: 220
url: /ja/php-java/examples/elements/header-footer/
keywords:
- ヘッダー フッター
- ヘッダーとフッターを追加
- ヘッダーとフッターを更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用した PHP でヘッダーとフッターを制御します。日付/時刻、スライド番号、フッターテキストを追加または編集し、PPT、PPTX、ODP 全体でプレースホルダーの表示/非表示を切り替えます。"
---
**Aspose.Slides for PHP via Java** を使用して、フッターの追加と日時プレースホルダーの更新方法を示します。

## **フッターの追加**

スライドのフッター領域にテキストを追加し、表示できるようにします。

```php
function addHeaderFooter() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setFooterText("My footer");
        $slide->getHeaderFooterManager()->setFooterVisibility(true);

        $presentation->save("footer.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **日付と時刻の更新**

スライド上の日付と時刻のプレースホルダーを変更します。

```php
function updateDateTime() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getHeaderFooterManager()->setDateTimeText("01/01/2024");
        $slide->getHeaderFooterManager()->setDateTimeVisibility(true);

        $presentation->save("datetime.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```