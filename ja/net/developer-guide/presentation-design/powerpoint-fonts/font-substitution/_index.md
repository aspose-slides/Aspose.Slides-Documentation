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
- フォント置換
- フォント置き換え
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "PowerPoint および OpenDocument のプレゼンテーションをレンダリングまたは変換する際に、.NET 用 Aspose.Slides でフォント置換ルールを構成し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により、Aspose.Slides は、プレゼンテーションがレンダリングまたは変換される際にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーションのコンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力の一貫性を保つことができます。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判定するには、[IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getsubstitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

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

## **選択されたスライドのフォント置換の取得**

`int[] slides` 引数を持つ [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getsubstitutions/) のオーバーロードを使用すると、特定のスライドをレンダリングするために必要な置換のみを確認できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーやコンテナ用に最小限のフォントパッケージを用意する場合、または無関係なスライドを処理せずにレンダリング差異を診断する場合に便利です。

`slides` 配列は 1 から始まるスライドインデックスを含みます：`1` は最初のスライドを示します。これに対し、[Presentation.Slides](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/slides/ja/) コレクションのインデクサは 0 から始まりますので、同じスライドは `presentation.Slides[0]` としてアクセスします。配列を作成する際はこの違いに注意し、オフバイワンエラーを防いでください。

[Presentation.FontsManager](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/fontsmanager/) プロパティを介してオーバーロードを呼び出します。これにより、選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は、元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、設定されたフォールバックルール、[IFontSubstRuleCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsubstrulecollection/) に格納された置換ルール、および [外部フォントのロード](/slides/ja/net/custom-font/) を反映します。

同じ置換は複数の選択スライドで必要になることがあります。フォントインベントリや事前チェックレポートを作成する際は、結果を重複除去してください。以下の例は、返されたすべての置換を報告し、ユニークなフォントマッピングのソート済みリストを作成します。

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

[IFontsManager](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/) インターフェイスは両方のオーバーロードを提供します。レンダリング操作の範囲に応じて選択してください：

| オーバーロード | 使用する状況 |
|---|---|
| [GetSubstitutions](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getsubstitutions/)（引数なし） | プレゼンテーション全体の置換が必要な場合。 |
| [GetSubstitutions](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getsubstitutions/)（`int[] slides`） | 選択範囲、インクリメンタルチェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換ルールの設定**

元のフォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには、次の手順を実行します。

1. プレゼンテーションをロードします。
2. 元フォントと置換フォントのフォント定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsubstcondition/) 条件を使用して [FontSubstRule](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsubstrule/) を作成します。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsubstrulecollection/) に追加します。
5. コレクションを [FontsManager.FontSubstRuleList](https://reference.aspose.com/slides/ja/net/aspose.slides/fontsmanager/fontsubstrulelist/) プロパティに割り当てます。
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
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[Font Replacement](/slides/ja/net/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。Aspose.Slides がアクセスできないフォントをルールで指定された利用可能なフォントに置換できる場合、通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides は数式のレイアウトを計算およびレンダリングするためにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントに置換するルールは、この目的のために **Cambria Math** を置き換えることはできず、レンダリング時に依然として **Cambria Math** が必要であると報告される可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。オペレーティングシステムにインストールするか、[外部フォント](/slides/ja/net/custom-font/)としてロードします。

この制限は数式のレイアウトに適用されます。上記で説明した置換ルールは通常のプレゼンテーションテキストには依然として適用されます。

## **よくある質問**

**フォント置換（Font Replacement）とフォント置換（Font Substitution）の違いは何ですか？**

[Font replacement](/slides/ja/net/font-replacement/) は、プレゼンテーション全体でフォントを意図的に別のフォントに変更します。フォント置換は、元のフォントが利用できないなど、設定された条件が満たされたときに、レンダリングされた出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**

これらのルールは、レンダリングおよび変換時の [フォント選択シーケンス](/slides/ja/net/font-selection-sequence/) に参加します。`WhenInaccessible` の場合、ルールは Aspose.Slides が元のフォントにアクセスできないときにのみ使用されます。

**フォントが見つからず、置換ルールが設定されていない場合はどうなりますか？**

Aspose.Slides は、フォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果は実行時環境で利用可能なフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**

はい。Aspose.Slides がレンダリングおよび変換時に使用できるように、[外部フォントをロード](/slides/ja/net/custom-font/) できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で提供し、ライセンスを遵守する必要があります。

**置換結果は Windows、Linux、macOS で異なる可能性がありますか？**

はい。インストールされているフォントやフォント検索場所は OS によって異なるため、あるマシンで利用可能なフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォントファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/net/custom-font/)し、ライセンスが許可する場合は [フォントを埋め込む](/slides/ja/net/embedded-font/)ことが推奨されます。また、エクスポート前に [IFontsManager.GetSubstitutions](https://reference.aspose.com/slides/ja/net/aspose.slides/ifontsmanager/getsubstitutions/) を呼び出して、予期しない置換を特定することもできます。