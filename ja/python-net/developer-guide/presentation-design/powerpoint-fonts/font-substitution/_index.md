---
title: Pythonでプレゼンテーションのフォント置換を構成する
linktitle: フォント置換
type: docs
weight: 70
url: /ja/python-net/font-substitution/
keywords:
- フォント
- 置換フォント
- フォント置換
- フォントの置き換え
- フォント置換
- 置換ルール
- 置換ルール
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "PowerPoint と OpenDocument のプレゼンテーションをレンダリングまたは変換する際に、.NET 経由で Python 用 Aspose.Slides のフォント置換ルールを構成し、置換されたフォントを確認します。"
---
## **概要**

フォント置換により、Aspose.Slides はプレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに利用可能なフォントを使用できます。置換はレンダリングされた出力に影響しますが、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間で出力を一貫させることができます。

フォントが利用可能だが専用の太字書体がない場合は、[専用の太字フォントがない場合のフォントの扱い](/slides/ja/python-net/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface)をご覧ください。このセクションでは、PDF エクスポート時に影響を受けたテキストをラスタライズする方法と、テキスト選択、検索、スケーリングへの影響について説明しています。

## **フォント置換の取得**

プレゼンテーションがレンダリングされる際にどのフォントが置換されるかを判断するには、[FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) メソッドを使用します。このメソッドは、元のフォント名と置換後のフォント名を示す [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) オブジェクトを返します。

以下の Python の例は、プレゼンテーションのすべてのフォント置換を一覧表示します。

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **選択したスライドのフォント置換の取得**

スライド インデックスのリストとともに [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) を使用すると、特定のスライドのレンダリングに必要な置換のみを確認できます。これは、プレゼンテーションの一部をレンダリングまたはエクスポートする場合や、大規模なプレゼンテーションを段階的にチェックする場合、利用できないフォントに依存するスライドを特定する場合、サーバーまたはコンテナ用に最小限のフォント パッケージを準備する場合、または無関係なスライドを処理せずにレンダリングの差異を診断する場合に便利です。

リストには 1 ベースのスライド インデックスが含まれます：`1` は最初のスライドを示します。対照的に、[Presentation.slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) コレクションは 0 ベースであるため、同じスライドは `presentation.slides[0]` としてアクセスされます。リストを作成する際はこの違いに留意し、オフバイワン エラーを防いでください。

メソッドは [Presentation.fonts_manager](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/fonts_manager/) プロパティ経由で呼び出します。選択したスライドのレンダリング中に決定された置換のみを返します。各結果は元のフォント名と置換後のフォント名を含む [FontSubstitutionInfo](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstitutioninfo/) オブジェクトです。結果は現在のフォント環境、構成されたフォールバック ルール、[IFontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/ifontsubstrulecollection/) に格納された置換ルール、および [externally loaded fonts](/slides/ja/python-net/custom-font/) を反映します。

同じ置換が複数の選択スライドで必要になることがあります。フォント インベントリや事前チェック レポートを作成する際は、結果の重複を除去してください。以下の例は、返されたすべての置換を報告し、ユニークなフォント マッピングのソート済みリストを作成します。

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    selected_slides = [1, 3, 5]
    substitutions = list(presentation.fonts_manager.get_substitutions(selected_slides))

    print("Substitutions for the selected slides:")
    for substitution in substitutions:
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")

    preflight_entries = [f"{substitution.original_font_name} -> {substitution.substituted_font_name}" for substitution in substitutions]
    unique_preflight_entries = {entry.casefold(): entry for entry in preflight_entries}
    sorted_preflight_entries = sorted(unique_preflight_entries.values(), key=str.casefold)

    print("Deduplicated font preflight report:")
    for entry in sorted_preflight_entries:
        print(entry)
```

[FontsManager](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/) クラスは、メソッドの両方の形式を提供します。レンダリング操作の範囲に応じていずれかを選択してください：

| メソッド呼び出し | 使用シーン |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) 引数なし | プレゼンテーション全体の置換が必要な場合。 |
| [get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) スライド インデックスのリストを指定 | 選択した範囲、インクリメンタル チェック、または部分エクスポートの置換が必要な場合。 |

## **フォント置換ルールの設定**

ソース フォントが利用できない場合に Aspose.Slides が使用すべきフォントを指定するには、以下の手順を実行します：

1. プレゼンテーションを読み込みます。
2. ソース フォントと置換フォントのフォント定義を作成します。
3. [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstcondition/) 条件を使用して [FontSubstRule](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrule/) を作成します。
4. ルールを [FontSubstRuleCollection](https://reference.aspose.com/slides/python-net/aspose.slides/fontsubstrulecollection/) に追加します。
5. コレクションを [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) プロパティに割り当てます。
6. プレゼンテーションをレンダリングまたは変換します。

以下の Python の例は、`SomeRareFont` が利用できない場合に `Arial` に置換し、結果を確認するために最初のスライドをレンダリングします。置換フォントは Aspose.Slides が利用できる必要があります。

```python
import aspose.slides as slides

with slides.Presentation("Fonts.pptx") as presentation:
    source_font = slides.FontData("SomeRareFont")
    substitute_font = slides.FontData("Arial")
    substitution_rule = slides.FontSubstRule(source_font, substitute_font, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    substitution_rules = slides.FontSubstRuleCollection()
    substitution_rules.add(substitution_rule)
    presentation.fonts_manager.font_subst_rule_list = substitution_rules

    with presentation.slides[0].get_image(1, 1) as image:
        image.save("slide.jpg", slides.ImageFormat.JPEG)
```

{{% alert color="info" title="Note" %}}
プレゼンテーション全体で使用されるフォントを無条件に変更する場合は、[Font Replacement](/slides/ja/python-net/font-replacement/) を参照してください。
{{% /alert %}}

## **数式フォントの制限**

フォント置換ルールは、レンダリングおよび変換時に使用される標準的なフォント選択プロセスの一部です。ルールで指定された利用可能なフォントにアクセスできないフォントを置換できる場合、通常のテキストに対して機能します。

Office Math の数式には追加の要件があります。数式が **Cambria Math** を使用している場合、Aspose.Slides はその正確なフォントが数式レイアウトの計算およびレンダリングに必要になることがあります。**STIX Two Math** のような別の数式フォントに置換するルールは、この目的で **Cambria Math** を置換できず、レンダリングは依然として **Cambria Math** が必要であると報告する可能性があります。

このようなプレゼンテーションをレンダリングまたは変換するには、**Cambria Math** を Aspose.Slides が利用できるようにしてください。オペレーティングシステムにインストールするか、[external font](/slides/ja/python-net/custom-font/) としてロードします。

この制限は数式レイアウトに適用されます。上記の置換ルールは通常のプレゼンテーション テキストには引き続き適用されます。

## **よくある質問**

**フォント置換（置き換え）とフォント置換（サブスティテューション）の違いは何ですか？**

[Font replacement](/slides/ja/python-net/font-replacement/) は、プレゼンテーション全体でフォントを意図的に別のフォントに変更します。フォント置換は、元のフォントが利用できないなど、設定された条件が満たされたときに、レンダリングされた出力用のフォントを選択します。

**置換ルールはいつ適用されますか？**

これらのルールは、レンダリングおよび変換中の [font selection sequence](/slides/ja/python-net/font-selection-sequence/) に参加します。`WHEN_INACCESSIBLE` を使用した場合、ルールは Aspose.Slides がソース フォントにアクセスできないときのみ使用されます。

**フォントが欠落しており、置換ルールが設定されていない場合はどうなりますか？**

Aspose.Slides はフォント選択プロセスに従って、最も近い利用可能なフォントを選択します。結果は実行環境で利用可能なフォントに依存します。

**置換を回避するために外部フォントをロードできますか？**

はい。Aspose.Slides がレンダリングおよび変換時に使用できるよう、[外部フォントをロード](/slides/ja/python-net/custom-font/) できます。

**Aspose はライブラリにフォントを同梱していますか？**

いいえ。フォントの提供とライセンス遵守はユーザーの責任です。

**置換結果は Windows、Linux、macOS で異なる可能性がありますか？**

はい。インストールされているフォントやフォント検索場所は OS により異なるため、あるマシンで利用可能なフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**

すべてのマシンまたはコンテナで同じフォント ファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/python-net/custom-font/)し、ライセンスが許可する場合は [フォントを埋め込む](/slides/ja/python-net/embedded-font/) ことが重要です。また、エクスポート前に [FontsManager.get_substitutions](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_substitutions/) を呼び出して予期しない置換を特定することもできます。