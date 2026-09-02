---
title: JavaScript でプレゼンテーションの描画ガイドを管理する
linktitle: 描画ガイド
type: docs
weight: 85
url: /ja/nodejs-java/drawing-guides/
keywords:
- 描画ガイド
- 水平ガイド
- 垂直ガイド
- 整列ガイド
- スライドビュー
- マスタースライド
- レイアウトスライド
- ノートマスタ
- ハンドアウトマスタ
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーションに水平および垂直の描画ガイドを追加、取得、クリアします。"
---
## **Overview**

描画ガイドは、PowerPoint でプレゼンテーションを編集する際に、形状を一貫して整列させるのに役立つ、調整可能な水平および垂直のラインです。アプリケーションがプレゼンテーションを生成し、後で手動で調整する場合に特に有用で、アプリケーションは、コンテンツを追加または移動する際に作者が従うべき同じ整列支援情報を保存できます。

描画ガイドはスライド コンテンツではなく、編集時の補助ツールです。スライドショーやレンダリングされた出力には表示されません。Aspose.Slides for Node.js via Java は、[DrawingGuidesCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguidescollection/) クラスを通じてこれらを公開します。ガイドは [DrawingGuide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguide/) で表され、方向、位置、色を持ちます。

位置は、対象のスライドまたはマスタの左上隅からポイント単位で測定されます。垂直ガイドは水平座標を使用し、通常は 0 からスライド幅までの範囲です。水平ガイドは垂直座標を使用し、通常は 0 からスライドの高さまでの範囲です。

## **Add Guides to the Slide View**

[CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) を使用して、通常のスライドを編集中に表示されるガイドを管理します。[DrawingGuidesCollection.add](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguidescollection/#add) を呼び出し、[Orientation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/orientation/) の値とポイント単位の位置を指定します。

次の例は、スライドの中心の右側に垂直ガイドを 1 本、下側に水平ガイドを 1 本追加します:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Access Drawing Guides**

[DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguidescollection/#getCount) および [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) メソッドで既存のガイドにアクセスできます。[DrawingGuide.getOrientation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguide/#getOrientation)、[DrawingGuide.getPosition](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguide/#getPosition)、[DrawingGuide.getColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguide/#getColor) メソッドは値を返し、対応する setter メソッドを使用して変更することもできます。

次の例は、上記で作成したプレゼンテーションからスライドビューのガイドを読み取ります:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Add Guides to Master and Layout Slides**

スライド マスタおよびそのレイアウト スライドそれぞれが独自の描画ガイド コレクションを持つことができます。マスタ スライドには [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) を、レイアウト スライドには [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) を使用します。

次の例は、最初のマスタ スライドに垂直ガイドを、最初のレイアウト スライドに水平ガイドを追加します:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Add Guides to Notes and Handout Masters**

ノート マスタ とハンドアウト マスタも描画ガイドをサポートします。[MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) と [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) を使用してそれらのコレクションにアクセスします。プレゼンテーションにこれらのマスタが含まれていない場合、`MasterNotesSlideManager.setDefaultMasterNotesSlide` または `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` がデフォルト マスタを作成し、返します。

次の例は、ノート マスタに水平ガイドを、ハンドアウト マスタに垂直ガイドを追加します:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Clear Drawing Guides**

特定のコレクションからすべてのガイドを削除するには、[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguidescollection/#clear) を呼び出します。1 つのコレクションをクリアしても、別のスコープに保存されているガイドには影響しません。

次の例は、欠落したマスタを作成せずに、スライドビューのガイドとスライド マスタ、レイアウト スライド、ノート マスタ、ハンドアウト マスタ上のすべてのガイドをクリアします:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**描画ガイドはスライドショーやエクスポートされた画像に表示されますか？**

いいえ。描画ガイドは編集時の整列補助ツールであり、プレゼンテーション コンテンツとしてレンダリングされません。

**個々の通常スライドに直接描画ガイドを追加できますか？**

通常スライドの編集ガイドは、プレゼンテーションのスライドビュー プロパティに保存されます。スライド マスタ、レイアウト スライド、ノート マスタ、ハンドアウト マスタ用の別個のガイド コレクションが用意されています。

**ガイドの位置単位は何ですか？**

位置はポイント単位で指定され、72 ポイントが 1 インチに相当します。垂直位置は左端から、水平位置は上端から測定されます。

**描画ガイドをクリアすると、図形が削除されたりスライド コンテンツが変更されたりしますか？**

いいえ。[DrawingGuidesCollection.clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/drawingguidescollection/#clear) メソッドは、選択されたコレクション内のガイドのみを削除します。図形やその他のスライド コンテンツは変更されません。