---
title: .NET のプレゼンテーションでフォント置換を構成する
linktitle: フォント置換
type: docs
weight: 70
url: /ja/net/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォントの置き換え
- フォント置換
- 置換規則
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides で PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、フォント置換規則を構成し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに、利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーションコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認することができます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

フォントが利用可能だが専用の太字フォントがない場合は、[専用の太字フォントがないフォントの取り扱い](/slides/ja/net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) を参照してください。そのセクションでは、PDF エクスポート時に影響を受けたテキストをラスタライズする方法と、テキスト選択、検索、スケーリングへの影響について説明しています。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際に置換されるフォントを判定するには、[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

以下の C# の例は、プレゼンテーションのすべてのフォント置換を列挙します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **選択スライドのフォント置換の取得**

`int[] slides` 引数を指定した [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) のオーバーロードを使用すると、特定のスライドのレンダリングに必要な置換のみを確認できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ用に最小限のフォントパッケージを準備する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に有用です。

`slides` 配列は 1 から始まるスライドインデックスを含みます。`1` は最初のスライドを示します。これに対し、[Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) コレクションのインデクサは 0 基準であるため、同じスライドは `presentation.Slides[0]` でアクセスします。配列を作成する際はこの違いに注意し、オフバイワンエラーを防ぎましょう。

[Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) プロパティを介してオーバーロードを呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は、元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境と[外部でロードされたフォント](/slides/ja/net/custom-font/) を反映します。[IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) に保存された置換規則はレンダリング結果を変更しますが、結果オブジェクトには反映されません。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリやプリフライトレポートを作成する際は結果を重複除去してください。以下の例は、返されたすべての置換を報告し、その後ユニークなフォントマッピングのソート済みリストを作成します。

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

int[] selectedSlides = { 1, 3, 5 };
var substitutions = presentation.FontsManager.GetSubstitutions(selectedSlides).ToList();

Console.WriteLine("Substitutions for the selected slides:");
foreach (var substitution in substitutions)
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}

var preflightEntries = substitutions.Select(substitution => $"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
var uniquePreflightEntries = preflightEntries.Distinct(StringComparer.OrdinalIgnoreCase);
var sortedPreflightEntries = uniquePreflightEntries.OrderBy(entry => entry, StringComparer.OrdinalIgnoreCase).ToList();

Console.WriteLine("Deduplicated font preflight report:");
foreach (var entry in sortedPreflightEntries)
{
    Console.WriteLine(entry);
}
```

[IFontsManager](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作の範囲に応じて選択してください。

| オーバーロード | 使用シーン |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | プレゼンテーション全体の置換が必要な場合。 |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | 選択範囲、インクリメンタルチェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換規則の設定**

元のフォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには、次の手順を実行します。

1. プレゼンテーションをロードします。
2. 元フォントと置換フォントのフォント定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) 条件を使用して [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) を作成します。
4. [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) にルールを追加します。
5. コレクションを [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) プロパティに割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

以下の C# の例は、`SomeRareFont` が利用できない場合に `Arial` を置換フォントとして使用し、結果を検証するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides で利用可能である必要があります。

```csharp
using Aspose.Slides;

using var presentation = new Presentation("Fonts.pptx");

var sourceFont = new FontData("SomeRareFont");
var substituteFont = new FontData("Arial");
var substitutionRule = new FontSubstRule(sourceFont, substituteFont, FontSubstCondition.WhenInaccessible);

var substitutionRules = new FontSubstRuleCollection();
substitutionRules.Add(substitutionRule);
presentation.FontsManager.FontSubstRuleList = substitutionRules;

using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("slide.jpg", ImageFormat.Jpeg);
```

{{% alert color="info" title="Note" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[フォント置換](/slides/ja/net/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換規則は、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。規則で指定された利用可能なフォントに置き換えることができる場合、通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのためにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントへの置換規則は、この目的のために **Cambria Math** を置き換えることはできず、レンダリング時に依然として **Cambria Math** が必要であると報告される可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにします。OS にインストールするか、[外部フォント](/slides/ja/net/custom-font/) としてロードしてください。

この制限は数式のレイアウトに適用されます。上記の置換規則は通常のプレゼンテーションテキストには引き続き適用されます。

## **FAQ**

**Font Replacement と Font Substitution の違いは何ですか？**

[Font replacement](/slides/ja/net/font-replacement/) は、プレゼンテーション全体でフォントを意図的に別のフォントに変更します。フォント置換は、元のフォントが利用できないなど、設定された条件が満たされたときに、レンダリングされた出力用のフォントを選択します。

**置換規則はいつ適用されますか？**

これらの規則は、レンダリングおよび変換時の [font selection sequence](/slides/ja/net/font-selection-sequence/) に参加します。`WhenInaccessible` を使用した規則は、Aspose.Slides が元フォントにアクセスできない場合にのみ使用されます。

**フォントが欠落していて置換規則が設定されていない場合はどうなりますか？**

Aspose.Slides は、フォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果は実行環境で利用可能なフォントに依存します。

**外部フォントをロードして置換を回避できますか？**

はい。Aspose.Slides がレンダリングおよび変換時に使用できるように、[外部フォント](/slides/ja/net/custom-font/) をロードできます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で提供し、ライセンスを遵守する必要があります。

**Windows、Linux、macOS 間で置換結果が異なることがありますか？**

はい。インストールされているフォントやフォント検索場所は OS によって異なるため、あるマシンで利用できるフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同一のフォントファイルとバージョンを使用し、[必要な外部フォント](/slides/ja/net/custom-font/) をロードし、ライセンスが許可する場合は [フォントを埋め込む](/slides/ja/net/embedded-font/) ことが重要です。また、エクスポート前に [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) を呼び出して、予期しない置換を特定することもできます。