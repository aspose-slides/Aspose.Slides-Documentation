---
title: JavaScript でプレゼンテーションからテキスト ポーションの境界を取得する
linktitle: ポーション境界
type: docs
weight: 47
url: /ja/nodejs-java/portion-bounds/
keywords:
- テキストポーション境界
- テキストポーション
- テキストパーツ
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Java を介して Node.js 用 Aspose.Slides を使用し、PowerPoint プレゼンテーション内のテキスト ポーションの境界を取得する方法を学びます。"
---
## **概要**

テキストのポーションは、段落内の特定のテキスト片を表し、その片を周囲のコンテンツとは独立して操作できるようにします。Aspose.Slides では、テキスト片の境界を取得したり、段落の一部だけに書式設定を適用したり、テキストの動作をより詳細に制御したりする必要がある場合にポーションを使用できます。

この記事では、[Portion.getRect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/getrect/) を使用してポーションのバウンディング矩形を取得する方法を示します。また、[Portion.getCoordinates](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/getcoordinates/) を使用してポーションの開始位置の座標を取得する方法も示します。さらに、単一テキスト片へのハイパーリンクの適用、ポーション・段落・テキストフレーム・テーマ継承を通じた書式設定の解決方法、指定フォントが利用できない場合の処理など、一般的なポーション関連シナリオについても取り上げています。

## **テキスト ポーションの境界取得**

[Portion.getRect](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/getrect/) を使用して、テキスト ポーションのバウンディング矩形を取得します。

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **テキスト ポーションの座標取得**

[Portion.getCoordinates](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/getcoordinates/) を使用して、テキスト ポーションの開始位置の座標を取得します。

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **よくある質問**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々のポーションに[ハイパーリンクを割り当てる](/slides/ja/nodejs-java/manage-hyperlinks/)ことができます。その片だけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか: ポーションが上書きするものと、段落やテキストフレームから取得するものは何ですか？**

ポーションレベルのプロパティが最も優先されます。プロパティが[Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/)で設定されていない場合、Aspose.Slides は[Paragraph](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraph/)から取得します。そこでも設定されていなければ、[TextFrame](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframe/)または[theme](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/theme/)のスタイルが使用されます。

**ポーションに指定したフォントが対象マシンまたはサーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/nodejs-java/font-selection-sequence/)が適用されます。テキストは再フローする可能性があり、メトリクス、ハイフネーション、幅が変わるため、正確な配置に影響します。

**ポーション固有のテキスト塗りつぶしの透明度やグラデーションを段落全体とは独立して設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portion/)レベルでのテキストカラー、塗りつぶし、透明度は隣接する片と異なる設定にできます。