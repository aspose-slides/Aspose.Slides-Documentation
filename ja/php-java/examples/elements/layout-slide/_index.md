---
title: レイアウト スライド
type: docs
weight: 20
url: /ja/php-java/examples/elements/layout-slide/
keywords:
- レイアウト スライド
- レイアウト スライドの追加
- レイアウト スライドへのアクセス
- レイアウト スライドの削除
- 未使用レイアウト スライド
- レイアウト スライドのクローン作成
- コード例
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP でレイアウト スライドを管理します。PPT、PPTX、ODP 用のプレゼンテーションでプレースホルダーやテーマを作成、適用、クローン作成、名前変更、カスタマイズできます。"
---
この記事では、Aspose.Slides for PHP via Java で **Layout Slides** を操作する方法を示します。レイアウト スライドは、通常のスライドが継承するデザインと書式設定を定義します。レイアウト スライドの追加、取得、クローン作成、削除、未使用スライドのクリーンアップが可能で、プレゼンテーションのサイズを削減できます。

## **レイアウト スライドの追加**

カスタム レイアウト スライドを作成して、再利用可能な書式設定を定義できます。たとえば、このレイアウトを使用するすべてのスライドに表示されるテキスト ボックスを追加することができます。

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // ブランクのレイアウト タイプとカスタム名でレイアウト スライドを作成します。
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** レイアウト スライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、複数のスライドで再利用できます。

> 💡 **Tip 2:** レイアウト スライドに図形やテキストを追加すると、そのレイアウトに基づくすべてのスライドで共有コンテンツが自動的に表示されます。  
> 下のスクリーンショットは、同じレイアウト スライドからテキスト ボックスを継承した 2 つのスライドを示しています。

![Slides Inheriting Layout Content](layout-slide-result.png)


## **レイアウト スライドへのアクセス**

レイアウト スライドはインデックスまたはレイアウト タイプ（例: `Blank`、`Title`、`SectionHeader` など）で取得できます。

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // インデックスでアクセスします。
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // レイアウト タイプでアクセスします。
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **レイアウト スライドの削除**

不要になった特定のレイアウト スライドを削除できます。

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // タイプでレイアウト スライドを取得し、削除します。
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **未使用レイアウト スライドの削除**

プレゼンテーションのサイズを削減するために、通常のスライドで使用されていないレイアウト スライドを削除したい場合があります。

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // 自動的に、どのスライドからも参照されていないすべてのレイアウト スライドを削除します。
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **レイアウト スライドのクローン作成**

`addClone` メソッドを使用してレイアウト スライドを複製できます。

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // タイプで既存のレイアウト スライドを取得します。
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // レイアウト スライド コレクションの末尾にレイアウト スライドをクローンします。
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Summary:** レイアウト スライドは、スライド全体で一貫した書式設定を管理する強力なツールです。Aspose.Slides は、レイアウト スライドの作成、管理、最適化に対して完全な制御を提供します。