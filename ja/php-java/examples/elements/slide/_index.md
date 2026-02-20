---
title: スライド
type: docs
weight: 10
url: /ja/php-java/examples/elements/slide/
keywords:
- スライド
- スライドの追加
- スライドへのアクセス
- スライドインデックス
- スライドのクローン
- スライドの並び替え
- スライドの削除
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用した PHP でのスライド管理: 作成、クローン、並び替え、非表示、背景とサイズの設定、トランジションの適用、PowerPoint および OpenDocument へのエクスポート。"
---
この記事では、**Aspose.Slides for PHP via Java** を使用してスライドを操作する方法を示す一連の例を提供します。`Presentation` クラスを使用してスライドの追加、アクセス、クローン、並べ替え、削除の方法を学びます。

以下の各例には簡単な説明と、PHP のコードスニペットが続きます。

## **スライドの追加**

新しいスライドを追加するには、まずレイアウトを選択する必要があります。この例では `Blank` レイアウトを使用し、プレゼンテーションに空のスライドを追加します。

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // 各スライドはレイアウトに基づいており、レイアウト自体はマスタースライドに基づいています。
        // 新しいスライドを作成するには Blank レイアウトを使用します。
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // 選択したレイアウトを使用して新しい空のスライドを追加します。
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip:** 各スライドレイアウトはマスター スライドから派生しており、全体的なデザインとプレースホルダー構造を定義します。以下の画像は、PowerPoint でマスター スライドとそれに関連するレイアウトがどのように整理されているかを示しています。

![マスターとレイアウトの関係](master-layout-slide.png)

## **インデックスでスライドにアクセス**

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // インデックスでスライドにアクセスします。
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **スライドのクローン作成**

この例では、既存のスライドをクローンする方法を示します。クローンされたスライドは自動的にスライドコレクションの末尾に追加されます。

```php
function cloneSlide() {
    // デフォルトでは、プレゼンテーションには空のスライドが1枚含まれています。
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // 最初のスライドをクローンします。クローンはプレゼンテーションの末尾に追加されます。
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // クローンされたスライドのインデックスは 1 です（プレゼンテーションの2枚目のスライド）。
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **スライドの並び替え**

スライドを新しいインデックスに移動させることで順序を変更できます。この例では、スライドを最初の位置に移動します。

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // スライドを最初の位置に移動します（他のスライドは下にシフトします）。
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **スライドの削除**

スライドを削除するには、対象を参照して `remove` を呼び出すだけです。この例では、インデックスと参照の両方でスライドを削除します。

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // インデックスでスライドを削除します。
        $presentation->getSlides()->removeAt(0);

        // 参照でスライドを削除します。
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```