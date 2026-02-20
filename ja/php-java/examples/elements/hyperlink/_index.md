---
title: ハイパーリンク
type: docs
weight: 130
url: /ja/php-java/examples/elements/hyperlink/
keywords:
- ハイパーリンク
- ハイパーリンクの追加
- ハイパーリンクへのアクセス
- ハイパーリンクの削除
- ハイパーリンクの更新
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用した PHP でハイパーリンクを追加、編集、削除します: テキスト、図形、スライド、URL、メールへのリンク; PPT、PPTX、ODP 用のターゲットとアクションを設定します。"
---
**Aspose.Slides for PHP via Java** を使用して、図形上のハイパーリンクの追加、アクセス、削除、更新を示します。

## **ハイパーリンクの追加**

外部ウェブサイトへリンクするハイパーリンクを持つ矩形シェイプを作成します。

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ハイパーリンクへのアクセス**

シェイプのテキスト部分からハイパーリンク情報を読み取ります。

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 最初のシェイプにハイパーリンクが含まれていると想定しています。
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **ハイパーリンクの削除**

シェイプのテキストからハイパーリンクをクリアします。

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 最初のシェイプにハイパーリンクが含まれていると想定しています。
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **ハイパーリンクの更新**

既存のハイパーリンクのターゲットを変更します。`HyperlinkManager` を使用して、既にハイパーリンクが含まれるテキストを変更し、PowerPoint がハイパーリンクを安全に更新する方法を模倣します。

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 最初のシェイプにハイパーリンクが含まれていると想定しています。
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        // 既存のテキスト内のハイパーリンクを変更する場合は、
        // HyperlinkManager を使用し、プロパティを直接設定しないでください。
        // これは、PowerPoint がハイパーリンクを安全に更新する方法を模倣しています。
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```