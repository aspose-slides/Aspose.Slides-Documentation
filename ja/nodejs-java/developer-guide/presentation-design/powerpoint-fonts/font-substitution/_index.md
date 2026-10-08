---
title: JavaScript を使用したプレゼンテーションのフォント置換の構成
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
- 置き換えルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションのレンダリングまたは変換時に、Node.js 用 Aspose.Slides でフォント置換ルールを構成し、置換されたフォントを検査します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーションコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

フォントが利用可能だが専用の太字フォントがない場合は、[専用の太字フォントがないフォントの処理](/slides/ja/nodejs-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) を参照してください。そのセクションでは、PDF エクスポート時に影響を受けたテキストをラスタライズする方法と、テキスト選択、検索、スケーリングへの影響について説明しています。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際に置換されるフォントを判断するには、[FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す[FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)オブジェクトを返します。

以下の JavaScript の例は、プレゼンテーションのすべてのフォント置換を一覧表示します。

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

## **選択スライドのフォント置換の取得**

特定のスライドのみをレンダリングするために必要な置換を確認するには、スライドインデックスの配列を指定して[FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) のオーバーロードを使用します。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ用に最小限のフォントパッケージを用意する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に便利です。

このオーバーロードは Java のプリミティブ型 `int[]` を期待します。`java.newArray("int", [...])` で作成してください。普通の JavaScript 配列は `Integer[]` に変換され、このオーバーロードには一致しません。

配列には 1 ベースのスライドインデックスが含まれます：`1` は最初のスライドを示します。これに対し、[Presentation.getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getslides/) コレクションアクセサは 0 ベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` としてアクセスします。配列作成時にこの違いに注意し、オフバイワンエラーを防いでください。

[Presentation.getFontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getfontsmanager/) を通じてオーバーロードを呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換後のフォント名を含む[FontSubstitutionInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstitutioninfo/)オブジェクトです。結果は現在のフォント環境、設定されたフォールバックルール、[FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)に保存された置換ルール、および[外部フォント](/slides/ja/nodejs-java/custom-font/)を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリやプリフライトレポートを作成する際は結果を重複除去してください。以下の例は返されたすべての置換を報告し、その後ユニークなフォントマッピングのソートリストを作成します。

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

[FontsManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/) クラスは両方のオーバーロードを提供します。レンダリング操作の範囲に応じて選択してください。

| Overload | Use it when |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) 引数なし | プレゼンテーション全体の置換が必要な場合。 |
| [getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) Java `int[]` のスライドインデックスを指定 | 選択範囲、段階的チェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換ルールの設定**

元フォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには:

1. プレゼンテーションを読み込みます。
2. 元フォントと置換フォントのフォント定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstcondition/) 条件を使用して[FontSubstRule](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrule/) を作成します。
4. ルールを[FontSubstRuleCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsubstrulecollection/)に追加します。
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/setfontsubstrulelist/) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

以下の JavaScript の例は、`SomeRareFont` が利用できない場合に `Arial` に置換し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides で利用可能である必要があります。

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
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[フォント置換](/slides/ja/nodejs-java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準のフォント選択プロセスの一部です。これらは、Aspose.Slides がアクセスできないフォントをルールで指定された利用可能なフォントに置き換えることができる通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式で **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのために正確にそのフォントが必要になることがあります。**STIX Two Math** などの別の数式フォントに置き換えるルールはこの目的で **Cambria Math** を置き換えることはできず、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

そのようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides で利用できるようにしてください。オペレーティングシステムにインストールするか、[外部フォント](/slides/ja/nodejs-java/custom-font/)としてロードします。

この制限は数式レイアウトに適用されます。上記で説明した置換ルールは通常のプレゼンテーションテキストにも引き続き適用されます。

## **よくある質問**

**フォント置換（replacement）とフォント置換（substitution）の違いは何ですか？**

[フォント置換](/slides/ja/nodejs-java/font-replacement/) はプレゼンテーション全体でフォントを別のフォントに意図的に変更します。フォント置換は、元のフォントが利用できないなど設定された条件が満たされたときに、レンダリングされた出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**

ルールはレンダリングおよび変換時の[フォント選択シーケンス](/slides/ja/nodejs-java/font-selection-sequence/)に参加します。`WhenInaccessible` を使用した場合、ルールは Aspose.Slides が元フォントにアクセスできないときのみ使用されます。

**フォントが欠落していて置換ルールが設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果は実行環境で利用できるフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**

はい。[外部フォントをロード](/slides/ja/nodejs-java/custom-font/) して、Aspose.Slides がレンダリングおよび変換時に使用できるようにできます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントの提供とライセンス遵守は利用者の責任です。

**置換結果は Windows、Linux、macOS 間で異なる可能性がありますか？**

はい。インストールされているフォントとフォント検索場所は OS によって異なるため、あるマシンで利用できるフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォントファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/nodejs-java/custom-font/)し、ライセンスが許可する場合は[フォントを埋め込む](/slides/ja/nodejs-java/embedded-font/)ことが推奨されます。また、エクスポート前に[FontsManager.getSubstitutions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsmanager/getsubstitutions/) を呼び出して予期しない置換を特定することもできます。