---
title: Python を使用したプレゼンテーションにおけるフォント置換の設定（Java 経由）
linktitle: フォント置換
type: docs
weight: 70
url: /ja/python-java/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォントの置き換え
- フォント置換
- 置換ルール
- 置換規則
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、Java 経由で Python 用 Aspose.Slides のフォント置換ルールを設定し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力の一貫性を保つことができます。

フォントが利用可能だけれども専用の太字フォントがない場合は、[専用の太字フォントがないフォントの処理](/slides/ja/python-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface) を参照してください。このセクションでは、PDF エクスポート時に影響を受けたテキストをラスタライズする方法と、テキスト選択、検索、拡大縮小への影響について説明します。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判断するには、[FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を識別する [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

以下の Python の例は、プレゼンテーションのすべてのフォント置換を一覧表示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    for substitution in presentation.getFontsManager().getSubstitutions():
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")
finally:
    presentation.dispose()
```

## **選択したスライドのフォント置換の取得**

特定のスライドをレンダリングする際に必要な置換のみを確認するには、Java の整数配列引数を使用した [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) のオーバーロードを使用します。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合、大規模プレゼンテーションをインクリメンタルにチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーまたはコンテナ用に最小限のフォントパッケージを準備する場合、または関係のないスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 ベースのスライドインデックスを含みます: `1` は最初のスライドを示します。一方、[Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides) コレクションアクセサは 0 ベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` としてアクセスされます。配列を作成する際はこの違いに注意して、オフバイワンエラーを防いでください。

オーバーロードは [Presentation.getFontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getFontsManager) メソッドを通じて呼び出します。選択したスライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、構成されたフォールバック規則、[FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) に保存された置換規則、および[外部フォントの読み込み](/slides/ja/python-java/custom-font/) を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォントインベントリや事前チェックレポートを作成するときは結果を重複除去してください。以下の例は、返されたすべての置換を報告し、ユニークなフォントマッピングのソート済みリストを作成します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Presentation.pptx")
try:
    selected_slides = jpype.JArray(jpype.JInt)([1, 3, 5])
    substitutions = list(presentation.getFontsManager().getSubstitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}")

    unique_entries = {}
    for substitution in substitutions:
        entry = f"{substitution.getOriginalFontName()} -> {substitution.getSubstitutedFontName()}"
        unique_entries.setdefault(entry.casefold(), entry)

    print("Deduplicated font preflight report:")
    for key in sorted(unique_entries):
        print(unique_entries[key])
finally:
    presentation.dispose()
```

[FontsManager](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/) クラスは両方のオーバーロードを提供します。レンダリング操作のスコープに応じて選択してください。

| オーバーロード | 使用する状況 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) 引数なし | プレゼンテーション全体の代替が必要な場合。 |
| [getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) Java 整数配列付き | 選択した範囲、インクリメンタルチェック、または部分エクスポートの代替が必要な場合。 |

## **フォント置換ルールの設定**

ソースフォントが利用できないときに Aspose.Slides が使用すべきフォントを指定する手順:

1. プレゼンテーションを読み込みます。
2. 元フォントと置換フォントのフォント定義を作成します。
3. [WhenInaccessible](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) 条件で [FontSubstRule](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrule/) を作成します。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/python-java/aspose.slides/fontsubstrulecollection/) に追加します。
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) メソッドを使用してコレクションを割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

以下の Python の例は、`SomeRareFont` が利用できない場合に `Arial` を代わりに使用し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides が利用できる必要があります。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, FontSubstCondition, FontSubstRule, FontSubstRuleCollection, ImageFormat, Presentation

presentation = Presentation("Fonts.pptx")
try:
    source_font = FontData("SomeRareFont")
    substitute_font = FontData("Arial")
    substitution_rule = FontSubstRule(source_font, substitute_font, FontSubstCondition.WhenInaccessible)

    substitution_rules = FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.getFontsManager().setFontSubstRuleList(substitution_rules)

    image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        image.save("slide.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[フォント置換](/slides/ja/python-java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントに関する制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。アクセスできないフォントをルールで指定した利用可能なフォントに置き換えることができる通常のテキストには機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウトの計算とレンダリングにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントに置き換えるルールでは **Cambria Math** を代替できず、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

そのようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。OS にインストールするか、[外部フォント](/slides/ja/python-java/custom-font/) として読み込みます。

この制限は数式レイアウトにのみ適用されます。上記の置換ルールは通常のプレゼンテーションテキストには引き続き適用されます。

## **よくある質問**

**フォント置換とフォント代替の違いは何ですか？**

[Font replacement](/slides/ja/python-java/font-replacement/) はプレゼンテーション全体でフォントを別のフォントに意図的に変更します。フォント代替は、元のフォントが利用できないなどの条件が満たされたときに、レンダリング出力用にフォントを選択します。

**代替ルールはいつ適用されますか？**

代替ルールはレンダリングおよび変換時の[フォント選択シーケンス](/slides/ja/python-java/font-selection-sequence/)に参加します。`WhenInaccessible` を使用した場合、Aspose.Slides がソースフォントにアクセスできないときにのみルールが使用されます。

**フォントが欠落し、代替ルールが設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに基づいて最も近い利用可能なフォントを選択します。結果は実行環境にインストールされているフォントに依存します。

**代替を回避するために外部フォントを読み込めますか？**

はい。[外部フォントを読み込む](/slides/ja/python-java/custom-font/)ことで、Aspose.Slides がレンダリングおよび変換時にそれらを使用できるようにできます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントはご自身で提供し、ライセンスを遵守する必要があります。

**代替結果は Windows、Linux、macOS で異なる場合がありますか？**

はい。インストールされているフォントとフォント検索パスは OS ごとに異なるため、あるマシンで利用できるフォントが別のマシンでは代替が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォントファイルとバージョンを使用し、[必要な外部フォントを読み込む](/slides/ja/python-java/custom-font/)、およびライセンスが許可する場合は[フォントを埋め込む](/slides/ja/python-java/embedded-font/)ことを推奨します。また、エクスポート前に [FontsManager.getSubstitutions](https://reference.aspose.com/slides/python-java/aspose.slides/fontsmanager/#getSubstitutions) を呼び出して予期しない代替を特定することもできます。