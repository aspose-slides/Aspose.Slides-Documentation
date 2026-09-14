---
title: "Python（Java 経由）を使用したプレゼンテーションのフォント置換の構成"
linktitle: "フォント置換"
type: docs
weight: 70
url: /ja/python-java/font-substitution/
keywords:
- フォント
- 代替フォント
- フォント置換
- フォント置換
- フォント置換
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "PowerPoint と OpenDocument のプレゼンテーションをレンダリングまたは変換する際に、Python（Java 経由）用 Aspose.Slides でフォント置換ルールを構成し、置換されたフォントを確認します。"
---
## **概要**

フォント置換では、プレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに、使用可能なフォントを Aspose.Slides が使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、レンダリング中に Aspose.Slides が行う置換を確認できます。これにより、インストールされているフォントが異なる環境でも出力を一貫させることができます。

## **フォント置換の取得**

[FontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getSubstitutions) メソッドを使用して、プレゼンテーションのレンダリング時に置換されるフォントを確認します。このメソッドは、元のフォント名と置換後のフォント名を特定する [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

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

## **選択スライドのフォント置換の取得**

[FontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getSubstitutions) の Java 整数配列引数オーバーロードを使用すると、特定のスライドのレンダリングに必要な置換のみを確認できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーまたはコンテナ用に最小限のフォント パッケージを準備する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に便利です。

`slides` 配列は 1 ベースのスライド インデックスを格納します: `1` は最初のスライドを示します。対照的に、[Presentation.getSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSlides) コレクション アクセッサは 0 ベースのインデックスを使用するため、同じスライドは `presentation.getSlides().get_Item(0)` として取得します。配列を作成する際はこの違いに注意し、オフバイワン エラーを防いでください。

オーバーロードは [Presentation.getFontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getFontsManager) メソッドから呼び出します。選択スライドのレンダリング中に決定された置換のみが返されます。各結果は元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、構成されたフォールバック ルール、[FontSubstRuleCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstrulecollection/) に格納された置換ルール、および [externally loaded fonts](/slides/ja/python-java/custom-font/) を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォント インベントリや事前チェック レポートを作成する際は結果を重複除去してください。以下の例は、返されたすべての置換を報告した後、ユニークなフォント マッピングのソート済みリストを作成します。

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

[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/) クラスは両方のオーバーロードを提供します。レンダリング操作の対象範囲に応じて選択してください。

| オーバーロード | 使用する状況 |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getSubstitutions)（引数なし） | プレゼンテーション全体の置換が必要なとき |
| [getSubstitutions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getSubstitutions)（Java 整数配列付き） | 選択範囲、段階的チェック、または部分エクスポートが必要なとき |

## **フォント置換ルールの設定**

ソース フォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定する手順:

1. プレゼンテーションをロードします。  
2. ソース フォントと置換フォントの定義を作成します。  
3. [WhenInaccessible](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstcondition/#WhenInaccessible) 条件で [FontSubstRule](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstrule/) を作成します。  
4. そのルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsubstrulecollection/) に追加します。  
5. [FontsManager.setFontSubstRuleList](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#setFontSubstRuleList) メソッドでコレクションを割り当てます。  
6. プレゼンテーションをレンダリングまたは変換します。

以下の Python の例は、`SomeRareFont` が利用できない場合に `Arial` を置換フォントとして使用し、最初のスライドをレンダリングして結果を確認します。置換フォントは Aspose.Slides が利用できる状態である必要があります。

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

{{% alert color="info" title="注意" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更したい場合は、[Font Replacement](/slides/ja/python-java/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換中に使用される標準的なフォント選択プロセスの一部です。利用できないフォントをルールで指定した利用可能なフォントに置き換えることで、通常のテキストには機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はレイアウトの計算とレンダリングにその正確なフォントが必要になることがあります。**STIX Two Math** のような別の数式フォントに置き換えるルールは **Cambria Math** の代替にはなりません。その結果、レンダリング時に **Cambria Math** が必要である旨が報告されることがあります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。OS にインストールするか、[external font](/slides/ja/python-java/custom-font/) としてロードします。

この制限は数式レイアウトにのみ適用されます。上記の置換ルールは通常のプレゼンテーション テキストには引き続き適用されます。

## **FAQ**

**フォント置換とフォント置き換えの違いは何ですか？**

[Font replacement](/slides/ja/python-java/font-replacement/) はプレゼンテーション全体で特定のフォントを別のフォントに意図的に変更します。フォント置換は、元のフォントが利用できないなどの条件が満たされたときに、レンダリングされた出力用にフォントを選択します。

**置換ルールはいつ適用されますか？**

ルールはレンダリングおよび変換時の[フォント選択シーケンス](/slides/ja/python-java/font-selection-sequence/)に参加します。`WhenInaccessible` の場合、Aspose.Slides がソース フォントにアクセスできないときにのみルールが使用されます。

**フォントが欠落していて置換ルールが設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果は実行環境にインストールされているフォントに依存します。

**外部フォントをロードして置換を回避できますか？**

はい。[外部フォントをロード](/slides/ja/python-java/custom-font/) すれば、レンダリングおよび変換時に Aspose.Slides がそれらを使用できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントの提供とライセンス遵守はユーザーの責任です。

**Windows、Linux、macOS で置換結果が異なることがありますか？**

はい。インストールされているフォントやフォント検索場所は OS ごとに異なるため、あるマシンで利用可能なフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォント ファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/python-java/custom-font/)し、ライセンスが許可する場合は[フォントを埋め込む](/slides/ja/python-java/embedded-font/) ことで一貫性を保てます。また、エクスポート前に [FontsManager.getSubstitutions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#getSubstitutions) を呼び出して予期しない置換を確認できます。