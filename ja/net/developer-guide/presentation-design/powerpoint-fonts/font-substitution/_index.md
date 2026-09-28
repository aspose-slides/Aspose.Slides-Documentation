---
title: ".NET でのプレゼンテーションにおけるフォント置換の構成"
linktitle: "フォント置換"
type: docs
weight: 70
url: /ja/net/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォントの置換
- フォント置換
- 置換規則
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides で PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、フォント置換規則を構成し、置換されたフォントを検査します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーションのコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング時に行う置換を確認することもできます。これにより、インストールされているフォントが異なる環境間でも出力の一貫性を保つことができます。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判断するには、[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

以下の C# の例は、プレゼンテーションのすべてのフォント置換を一覧表示します。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");

foreach (var substitution in presentation.FontsManager.GetSubstitutions())
{
    Console.WriteLine($"{substitution.OriginalFontName} -> {substitution.SubstitutedFontName}");
}
```

## **選択したスライドのフォント置換の取得**

特定のスライドのレンダリングに必要な置換のみを確認するには、`int[] slides` 引数を持つ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) のオーバーロードを使用します。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ用に最小限のフォントパッケージを作成する場合、または無関係なスライドを処理せずにレンダリングの違いを診断する場合に便利です。

`slides` 配列は 1 ベースのスライドインデックスを含みます: `1` は最初のスライドを示します。対照的に、[Presentation.Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) コレクションのインデクサは 0 ベースであるため、同じスライドは `presentation.Slides[0]` としてアクセスします。配列を作成する際はこの違いに注意し、オフバイワンエラーを防いでください。

[Presentation.FontsManager](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/) プロパティを介してオーバーロードを呼び出します。これは、選択したスライドのレンダリング中に決定された置換のみを返します。各結果は、元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/net/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境と [外部フォントのロード](/slides/ja/net/custom-font/) を反映します。[IFontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/ifontsubstrulecollection/) に保存された置換規則はレンダリング出力に影響しますが、結果には反映されません。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリや事前確認レポートを作成する際は、結果を重複除去してください。以下の例は、返されたすべての置換を報告し、次に一意のフォントマッピングのソート済みリストを作成します。

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

| オーバーロード | 使用する状況 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with no arguments | プレゼンテーション全体の置換が必要な場合 |
| [GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) with `int[] slides` | 選択範囲、インクリメンタルチェック、または部分エクスポートの置換が必要な場合 |

## **フォント置換規則の設定**

ソースフォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには、次の手順を実行します。

1. プレゼンテーションを読み込みます。  
2. 元フォントと置換フォントのフォント定義を作成します。  
3. [WhenInaccessible](https://reference.aspose.com/slides/net/aspose.slides/fontsubstcondition/) 条件を使用して [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) を作成します。  
4. その規則を [FontSubstRuleCollection](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrulecollection/) に追加します。  
5. コレクションを [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/net/aspose.slides/fontsmanager/fontsubstrulelist/) プロパティに割り当てます。  
6. プレゼンテーションをレンダリングまたは変換します。

以下の C# の例は、`SomeRareFont` が利用できない場合に `Arial` に置換し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides が利用できる必要があります。

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
プレゼンテーション全体で使用されるフォントを無条件に変更するには、[Font Replacement](/slides/ja/net/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換規則は、レンダリングおよび変換時に使用される標準のフォント選択プロセスの一部です。規則で指定された利用可能なフォントに置き換えることができる場合、通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウト計算とレンダリングのためにその正確なフォントが必要になることがあります。**STIX Two Math** などの別の数式フォントに置換する規則は、**Cambria Math** をこの目的で置き換えることはできず、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにします。オペレーティングシステムにインストールするか、[外部フォント](/slides/ja/net/custom-font/) としてロードしてください。

この制限は数式のレイアウトに適用されます。上記の置換規則は通常のプレゼンテーションテキストには引き続き適用されます。

## **よくある質問**

**フォント置換とフォント置換規則の違いは何ですか？**

[Font replacement](/slides/ja/net/font-replacement/) は、プレゼンテーション全体でフォントを意図的に別のフォントに変更します。フォント置換は、元のフォントが利用できないなど、設定された条件が満たされたときに、レンダリング出力用のフォントを選択します。

**置換規則はいつ適用されますか？**

これらの規則は、レンダリングおよび変換時の [フォント選択シーケンス](/slides/ja/net/font-selection-sequence/) に参加します。`WhenInaccessible` を使用した規則は、Aspose.Slides がソースフォントにアクセスできない場合にのみ適用されます。

**フォントが存在せず、置換規則が設定されていない場合はどうなりますか？**

Aspose.Slides は、フォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果は実行時環境にインストールされているフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**

はい。Aspose.Slides がレンダリングおよび変換時に使用できるよう、[外部フォントをロード](/slides/ja/net/custom-font/) できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で用意し、ライセンスに従って使用する責任があります。

**Windows、Linux、macOS 間で置換結果が異なることがありますか？**

はい。インストールされているフォントやフォント検索パスは OS によって異なるため、あるマシンで利用できるフォントでも、別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォントファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/net/custom-font/) し、ライセンスが許可する場合は [フォントを埋め込む](/slides/ja/net/embedded-font/) ことで、バッチ変換時のフォント選択を一貫させることができます。また、エクスポート前に [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/getsubstitutions/) を呼び出して予期しない置換を確認することもできます。