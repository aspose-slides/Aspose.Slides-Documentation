---
title: レイアウトスライド
type: docs
weight: 20
url: /ja/nodejs-java/examples/elements/layout-slide/
keywords:
- コード例
- レイアウトスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js のマスターレイアウトスライド: スライドレイアウト、プレースホルダー、マスターを選択、適用、カスタマイズし、PPT、PPTX、ODP プレゼンテーションの例を示します。"
---
この記事では、Java 経由で Node.js 用 Aspose.Slides の **Layout Slides** の使用方法を示します。レイアウトスライドは、通常のスライドが継承するデザインと書式を定義します。レイアウトスライドを追加、アクセス、クローン作成、削除でき、未使用のレイアウトスライドをクリーンアップしてプレゼンテーションのサイズを削減できます。

## **レイアウトスライドの追加**

カスタムレイアウトスライドを作成して、再利用可能な書式を定義できます。

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // 空白のレイアウトタイプとカスタム名でレイアウトスライドを作成します。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **注 1:** レイアウトスライドは個々のスライドのテンプレートとして機能します。共通要素を一度定義すれば、複数のスライドで再利用できます。

> 💡 **注 2:** レイアウトスライドに図形やテキストを追加すると、そのレイアウトに基づくすべてのスライドでこの共有コンテンツが自動的に表示されます。  
> 以下のスクリーンショットは、同じレイアウトスライドからテキストボックスを継承した2枚のスライドを示しています。

![レイアウトコンテンツを継承するスライド](layout-slide-result.png)

## **レイアウトスライドへのアクセス**

レイアウトスライドはインデックスまたはレイアウトタイプ（例: `Blank`、`Title`、`SectionHeader` など）でアクセスできます。

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // インデックスでレイアウトスライドにアクセスします。
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // タイプでレイアウトスライドにアクセスします。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **レイアウトスライドの削除**

もはや不要な場合、特定のレイアウトスライドを削除できます。

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // タイプでレイアウトスライドを取得し、削除します。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **未使用レイアウトスライドの削除**

プレゼンテーションのサイズを削減するため、通常スライドで使用されていないレイアウトスライドを削除したい場合があります。

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // 自動的に、いずれのスライドからも参照されていないすべてのレイアウトスライドを削除します。
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **レイアウトスライドのクローン作成**

`addClone` メソッドを使用してレイアウトスライドを複製できます。

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // タイプで既存のレイアウトスライドを取得します。
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // レイアウトスライドコレクションの末尾にレイアウトスライドをクローンします。
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **概要:** レイアウトスライドは、スライド全体で一貫した書式を管理する強力なツールです。Aspose.Slides はレイアウトスライドの作成、管理、最適化を完全にコントロールできます。