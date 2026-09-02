---
title: JavaScript でプレゼンテーションからシェイプの効果的なプロパティを取得する
linktitle: 効果的なプロパティ
type: docs
weight: 50
url: /ja/nodejs-java/shape-effective-properties/
keywords:
- シェイプ プロパティ
- カメラ プロパティ
- ライト リグ
- ベベル シェイプ
- テキスト フレーム
- テキスト スタイル
- フォント 高さ
- 塗りつぶし 書式
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java を使用して、PowerPoint プレゼンテーションでシェイプのローカル、継承、効果的な書式設定を区別する方法を学びます。"
---
## **ローカル、継承、効果的なプロパティの理解**

PowerPoint の書式設定は複数の場所から取得されます。オブジェクトに直接格納されている値は **ローカル値** と呼ばれます。ローカル値が設定されていない場合、PowerPoint は段落の既定、テキストスタイル、レイアウトまたはマスタースライド、テーマ、プレゼンテーション レベルの既定といった親の書式設定元を参照します。これらの値は **継承値** です。階層全体が解決された後に残る値が **効果的な値** であり、オブジェクトの描画に使用されます。

たとえば、テキストの一部がフォント高さを独自に定義していない場合、そのローカル [getFontHeight](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getFontHeight) 値は `NaN` となり、これは「ここでは設定されていない」ことを意味します。その部分は段落やプレゼンテーションの既定テキストスタイル、あるいは他の適用可能なソースから高さを継承できます。[getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getEffective) を PortionFormat に対して呼び出すと、最終的に解決された高さが返されます。

2 種類の書式データは目的に応じて使い分けます。

- 値がどこで定義されているかを制御したい場合は、[PortionFormat](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/) のようなローカル書式オブジェクトを読み取ったり変更したりします。
- 継承やテーマの適用後の最終的な描画結果が必要な場合は、[PortionFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getEffective) が返す **効果的なデータ** を読み取ります。効果的なデータは読み取り専用です。

サンプルを実行する前に、[Aspose.Slides for Node.js via Java](/slides/ja/nodejs-java/installation/) をインストールしてください。

## **ローカル、継承、効果的な値の比較**

以下の完全なサンプルはシェイプを作成し、プレゼンテーション、段落、部分レベルでフォント高さを設定します。各ステップでそれぞれのレベルで定義された値と、同じテキスト部分に対する効果的な結果を出力します。また、書式変更後に効果的なデータを再取得する必要がある理由も示しています。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function formatLocalValue(value) {
    return Number.isNaN(value) ? "<not set>" : value.toString();
}

function printFontHeights(caption, presentation, paragraph, portion) {
    const presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
    const paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
    const localValue = portion.getPortionFormat().getFontHeight();

    // 前の変更の後に効果的なデータを読み取ります。
    const effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

    console.log(caption);
    console.log("  Presentation default: " + formatLocalValue(presentationValue));
    console.log("  Paragraph default:    " + formatLocalValue(paragraphValue));
    console.log("  Portion local:        " + formatLocalValue(localValue));
    console.log("  Portion effective:    " + effectiveValue);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 80, false);
    const textFrame = shape.addTextFrame("Effective formatting");
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    // 2 つの異なるレベルで継承値を定義します。
    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

    // 部分のローカル値が両方の継承値を上書きします。
    portion.getPortionFormat().setFontHeight(36);
    printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

    // 継承値を変更しても、既存のローカル値は上書きされません。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
    printFontHeights("The local value still has priority", presentation, paragraph, portion);

    // ローカル値をクリアします。部分は再び段落から継承されます。
    portion.getPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The local value is cleared", presentation, paragraph, portion);

    // 段落の値をクリアします。プレゼンテーションのデフォルトが結果を提供します。
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(java.newFloat(Number.NaN));
    printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

    presentation.save("effective-properties.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

この例では、優先順位は「部分のローカル書式」→「段落書式」→「プレゼンテーションの既定」の順です。他のオブジェクトでも継承チェーンは異なる場合がありますが、原則は同じです：より具体的な明示的値が優先され、[getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getEffective) が最終結果を返します。

## **効果的なテキストプロパティの取得**

テキストの書式設定は複数のオブジェクトに分割されます：

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textframeformat/#getEffective) は余白、アンカリング、オートフィット、縦方向テキストなどのテキストフレームプロパティを解決します。
- [TextStyle.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/textstyle/#getEffective) は各テキストスタイルレベルの段落書式を解決します。
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/paragraphformat/#getEffective) は配置、インデント、箇条書きなどの段落プロパティを解決します。
- [PortionFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/portionformat/#getEffective) はフォント高さ、フォント名、色、太字、斜体などの文字プロパティを解決します。

次のサンプルでは、`text-formatting.pptx` に少なくとも 1 つのスライドと、空でないテキストフレームを持つ [AutoShape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/autoshape/) が必要です。AutoShape はシェイプコレクション内の任意の位置に配置でき、コードは適切なオブジェクトを検索して使用前に検証します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function hasNonEmptyText(shape) {
    if (shape.getTextFrame() == null) {
        return false;
    }
    if (shape.getTextFrame().getParagraphs().getCount() === 0) {
        return false;
    }
    return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
}

function findAutoShapeWithText(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const candidate = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(candidate, "com.aspose.slides.AutoShape") && hasNonEmptyText(candidate)) {
            return candidate;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("text-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
    if (shape == null) {
        throw new Error("The first slide must contain an AutoShape with non-empty text.");
    }

    const textFrame = shape.getTextFrame();
    const paragraph = textFrame.getParagraphs().get_Item(0);
    const portion = paragraph.getPortions().get_Item(0);

    const textFrameEffective = textFrame.getTextFrameFormat().getEffective();
    const paragraphEffective = paragraph.getParagraphFormat().getEffective();
    const portionEffective = portion.getPortionFormat().getEffective();

    console.log("Text frame margins:");
    console.log("  Left: " + textFrameEffective.getMarginLeft());
    console.log("  Top: " + textFrameEffective.getMarginTop());
    console.log("  Right: " + textFrameEffective.getMarginRight());
    console.log("  Bottom: " + textFrameEffective.getMarginBottom());
    console.log("Paragraph alignment: " + paragraphEffective.getAlignment());
    console.log("Font height: " + portionEffective.getFontHeight());
    console.log("Bold: " + portionEffective.getFontBold());

    const effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
    for (let level = 0; level < 9; level++) {
        const levelEffective = effectiveTextStyle.getLevel(level);
        console.log("Level " + level + " indent: " + levelEffective.getIndent());
    }
} finally {
    presentation.dispose();
}
```

## **効果的な3Dプロパティの取得**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getEffective) は、解決されたすべての 3D 設定をまとめた 1 つの効果的データオブジェクトを返します。その [getCamera](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getCamera)、[getLightRig](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getLightRig)、[getBevelTop](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getBevelTop)、[getBevelBottom](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/threedformat/#getBevelBottom) メソッドは、対応する効果的データを公開します。これらの設定をまとめて読むことで、シェイプの最終的な 3D 外観を把握しやすくなります。

この例では、`shape-3d.pptx` の最初のスライドに少なくとも 1 つのシェイプが必要です。出力にデフォルト以外の値を含めたい場合は、そのシェイプに 3D カメラ、照明、またはベベル設定を適用してください。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("shape-3d.pptx");
try {
    if (presentation.getSlides().size() === 0 || presentation.getSlides().get_Item(0).getShapes().size() === 0) {
        throw new Error("The first slide must contain a shape.");
    }

    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const threeDEffective = shape.getThreeDFormat().getEffective();

    console.log("Camera:");
    console.log("  Type: " + threeDEffective.getCamera().getCameraType());
    console.log("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
    console.log("  Zoom: " + threeDEffective.getCamera().getZoom());

    console.log("Light rig:");
    console.log("  Type: " + threeDEffective.getLightRig().getLightType());
    console.log("  Direction: " + threeDEffective.getLightRig().getDirection());

    console.log("Top bevel:");
    console.log("  Type: " + threeDEffective.getBevelTop().getBevelType());
    console.log("  Width: " + threeDEffective.getBevelTop().getWidth());
    console.log("  Height: " + threeDEffective.getBevelTop().getHeight());
} finally {
    presentation.dispose();
}
```

## **効果的なテーブル書式設定の取得**

テーブルの書式設定はテーブルスタイルと、テーブル全体、列、行、個別セルに適用された書式から取得されます。明示的に定義された塗りつぶしが競合する場合の優先順位は、セル → 行 → 列 → テーブル全体です。セルの効果的書式は、そのセルを描画する際に使用される最終書式です。

この例では、`table-formatting.pptx` の最初のスライドに少なくとも 1 つのテーブルが必要です。そのテーブルは少なくとも 1 行 1 列を持たなければなりません。コードは `getShapes().get_Item(0)` がテーブルであると仮定せず、[Table](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/table/) を検索します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

function findTable(slide) {
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.Table")) {
            return shape;
        }
    }
    return null;
}

const presentation = new aspose.slides.Presentation("table-formatting.pptx");
try {
    if (presentation.getSlides().size() === 0) {
        throw new Error("The presentation contains no slides.");
    }

    const table = findTable(presentation.getSlides().get_Item(0));
    if (table == null) {
        throw new Error("The first slide must contain a table.");
    }
    if (table.getRows().size() === 0 || table.getColumns().size() === 0) {
        throw new Error("The table must contain at least one cell.");
    }

    const tableEffective = table.getTableFormat().getEffective();
    const rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    const columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    const cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    console.log("Table fill: " + tableEffective.getFillFormat().getFillType());
    console.log("Row fill: " + rowEffective.getFillFormat().getFillType());
    console.log("Column fill: " + columnEffective.getFillFormat().getFillType());
    console.log("Final cell fill: " + cellEffective.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

色が必要で塗りつぶしタイプだけでなく具体的な色が欲しい場合は、まず効果的な [getFillType](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/#getFillType) を確認し、次にそのタイプに対応するメソッド（例: ソリッド塗りつぶしの場合は [getSolidFillColor](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fillformat/#getSolidFillColor)）を呼び出します。

## **変更後に効果的なデータを再読込む**

効果的データは解決された時点の書式階層を表します。階層に関与できる要素を変更した場合は、`getEffective` を再度呼び出してください。対象となるものは次のとおりです。

- オブジェクトのローカル書式
- 段落またはテキストフレームの既定
- テーブルスタイル、テーブル、列、行、セルの書式
- レイアウトまたはマスタースライドの書式
- テーマデータまたはプレゼンテーション レベルの既定
- スライドに割り当てられたレイアウトまたはマスター

効果的データオブジェクトを永続的なスナップショットとして保持しないでください。Aspose.Slides は内部で一部の効果的データをキャッシュし、後続の `getEffective` 呼び出しでデータが更新されることがあります。変更前後の値を比較したい場合は、フォント高さ、色、配置、ベベル幅など必要なスカラ値を自分の変数にコピーしてから変更を加えてください。

値を変更するには、該当するローカル書式オブジェクトを更新し、`getEffective` を呼び出して結果を確認します。効果的データオブジェクト自体は読み取り専用です。

## **FAQ**

**効果的な値を提供したレベルをどのように判断できますか？**

効果的データは最終値のみを保持し、元のレベルは含みません。最も具体的なレベルから外側へ向かって該当するローカルオブジェクトを調べます。テキストの場合は、部分 → 段落 → テキストフレーム → レイアウト → マスター → テーマ → プレゼンテーション の順です。`NaN` や `null` といった未定義値は、検索が次のレベルへ続くことを示します。

**どのレベルもプロパティを定義していない場合はどうなりますか？**

Aspose.Slides は適切な PowerPoint またはライブラリの既定値を解決します。その解決済みの値が効果的データに含まれ、ローカルオブジェクトが明示的に定義していなくても表示されます。

**効果的な値がローカル値と同じになることはなぜですか？**

ローカル値が継承計算で勝ち抜いたためです。対象オブジェクトでプロパティが明示的に設定されており、より具体的な規則が上書きしなかった場合にこのようになります。

**ローカルデータと効果的データはどちらを使うべきですか？**

ローカルデータは特定の書式レベルを検査または編集する際に使用します。効果的データは継承、テーマ規則、適用スタイルがすべて解決された後の最終的な外観が必要なときに使用します。**[ローカル、継承、効果的な値の比較例]**（#compare-local-inherited-and-effective-values）では、同じワークフローで両方を示しています。