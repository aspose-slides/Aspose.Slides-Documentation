---
title: JavaScript を使用したプレゼンテーションでのフォント置換の構成
linktitle: フォント置換
type: docs
weight: 70
url: /ja/nodejs-java/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォント置き換え
- フォント置換
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、Node.js 用 Aspose.Slides でフォント置換ルールを設定し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により Aspose.Slides は、プレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響し、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間で出力を一貫させることができます。

## **フォント置換の取得**

[FontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) メソッドを使用して、プレゼンテーションがレンダリングされる際に置換されるフォントを判断します。このメソッドは元のフォント名と置換フォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

以下の JavaScript の例は、プレゼンテーションのすべてのフォント置換を一覧表示します：

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var substitutions = presentation.getFontsManager().getSubstitutions().iterator();
    while (substitutions.hasNext()) {
        var substitution = substitutions.next();
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    }
} finally {
    presentation.dispose();
}
```

## **選択したスライドのフォント置換の取得**

[FontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) のオーバーロードにスライドインデックスの配列を渡すことで、特定のスライドのレンダリングに必要な置換のみを確認できます。これはプレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ向けに最小フォントパッケージを作成する場合、または関係ないスライドを処理せずにレンダリング差異を診断する場合に便利です。

オーバーロードは Java のプリミティブ `int[]` を受け取ります。`java.newArray("int", [...])` で作成します。純粋な JavaScript 配列は `Integer[]` に変換され、このオーバーロードに一致しません。

配列には 1 ベースのスライドインデックスが含まれます：`1` は最初のスライドを示します。対照的に、[Presentation.getSlides](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getslides/) コレクションアクセサはゼロベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` でアクセスされます。この違いを考慮して配列を作成し、オフバイワンエラーを防いでください。

[Presentation.getFontsManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/getfontsmanager/) を介してオーバーロードを呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換フォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、構成されたフォールバックルール、[FontSubstRuleCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsubstrulecollection/) に保存された置換ルール、そして [externally loaded fonts](/slides/ja/nodejs-java/custom-font/) を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリや事前チェックレポートを作成する際は結果を重複排除してください。以下の例は返されたすべての置換を報告し、ユニークなフォントマッピングのソートリストを作成します：

```javascript
var aspose = aspose || {};
const java = require("java");
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var selectedSlides = java.newArray("int", [1, 3, 5]);
    var substitutions = [];
    var substitutionIterator = presentation.getFontsManager().getSubstitutions(selectedSlides).iterator();
    while (substitutionIterator.hasNext()) {
        substitutions.push(substitutionIterator.next());
    }

    console.log("Substitutions for the selected slides:");
    substitutions.forEach(function (substitution) {
        console.log(substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
    });

    var preflightEntries = substitutions.map(function (substitution) {
        return substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName();
    });
    var sortedPreflightEntries = Array.from(new Set(preflightEntries)).sort(function (first, second) {
        return first.localeCompare(second, undefined, { sensitivity: "base" });
    });

    console.log("Deduplicated font preflight report:");
    sortedPreflightEntries.forEach(function (entry) {
        console.log(entry);
    });
} finally {
    presentation.dispose();
}
```

[FontsManager](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/) クラスは両方のオーバーロードを提供します。レンダリング操作の範囲に応じて選択してください：

| オーバーロード | 使用シーン |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)（引数なし） | プレゼンテーション全体の置換が必要なとき |
| [getSubstitutions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/)（スライドインデックスの Java `int[]`） | 選択範囲、段階的チェック、または部分エクスポートが必要なとき |

## **フォント置換ルールの設定**

ソースフォントが利用できないときに Aspose.Slides が使用すべきフォントを指定する手順：

1. プレゼンテーションを読み込みます。
2. ソースフォントと置換フォントの定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsubstcondition/) 条件を持つ [FontSubstRule](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsubstrule/) を作成します。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsubstrulecollection/) に追加します。
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

以下の JavaScript の例は、`SomeRareFont` が利用できないときに `Arial` に置換し、最初のスライドをレンダリングして結果を確認します。置換フォントは Aspose.Slides が利用できる必要があります。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    var substituteFont = new aspose.slides.FontData("Arial");
    var substitutionRule = new aspose.slides.FontSubstRule(sourceFont, substituteFont, aspose.slides.FontSubstCondition.WhenInaccessible);

    var substitutionRules = new aspose.slides.FontSubstRuleCollection();
    substitutionRules.add(substitutionRule);
    presentation.getFontsManager().setFontSubstRuleList(substitutionRules);

    var image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0);
    try {
        image.save("slide.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更するには、[Font Replacement](/slides/ja/nodejs-java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準のフォント選択プロセスの一部です。アクセスできないフォントをルールで指定した利用可能なフォントに置換できる場合、通常のテキストでは機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのためにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントへの置換ルールは **Cambria Math** を代替できず、レンダリング時に **Cambria Math** が必要であると報告される可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。OS にインストールするか、[external font](/slides/ja/nodejs-java/custom-font/) としてロードします。

この制限は数式レイアウトにのみ適用されます。上記の置換ルールは通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント置換（置き換え）の違いは何ですか？**

[Font replacement](/slides/ja/nodejs-java/font-replacement/) はプレゼンテーション全体でフォントを意図的に別のフォントに変更します。フォント置換は、元のフォントが利用できないなど条件が満たされたときにレンダリング出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**

ルールはレンダリングおよび変換時の [font selection sequence](/slides/ja/nodejs-java/font-selection-sequence/) に参加します。`WhenInaccessible` を使用した場合、Aspose.Slides がソースフォントにアクセスできないときだけルールが使用されます。

**フォントが欠落していて置換ルールが設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果はランタイム環境に存在するフォントに依存します。

**外部フォントをロードして置換を回避できますか？**

はい。[外部フォントをロード](/slides/ja/nodejs-java/custom-font/) すれば、Aspose.Slides はレンダリングおよび変換時にそれらを使用できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントの提供とライセンス遵守はユーザーの責任です。

**Windows、Linux、macOS 間で置換結果が異なることがありますか？**

はい。インストールされているフォントとフォント検索場所は OS ごとに異なるため、あるマシンで利用できるフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォントファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/nodejs-java/custom-font/) し、ライセンスが許可する場合は [embed fonts](/slides/ja/nodejs-java/embedded-font/) を行います。また、エクスポート前に [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) を呼び出して予期しない置換を確認できます。