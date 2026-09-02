---
title: Python を使用したプレゼンテーションのフォント置換の構成
linktitle: フォント置換
type: docs
weight: 70
url: /ja/python-net/font-substitution/
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
- Aspose.Slides
description: "PowerPoint および OpenDocument プレゼンテーションをレンダリングまたは変換する際に、.NET を介して Python 用 Aspose.Slides のフォント置換ルールを構成し、置換されたフォントを確認します。"
---
## **概要**

フォント置換を使用すると、プレゼンテーションのレンダリングまたは変換時にアクセスできないフォントの代わりに、使用可能なフォントを Aspose.Slides が使用できるようになります。置換はレンダリングされた出力にのみ影響し、プレゼンテーション コンテンツに割り当てられたフォントは変更されません。

特定のフォントが利用できない場合に使用するフォントを定義でき、Aspose.Slides がレンダリング中に行う置換を確認できます。これにより、インストールされているフォントが異なる環境間でも出力を一貫させることができます。

## **フォント置換の取得**

Use the [FontsManager.get_substitutions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_substitutions/) method to determine which fonts will be substituted when the presentation is rendered. The method returns [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsubstitutioninfo/) objects that identify the original and substituted font names.

The following Python example lists all font substitutions for a presentation:

```python
import aspose.slides as slides

with slides.Presentation("Presentation.pptx") as presentation:
    for substitution in presentation.fonts_manager.get_substitutions():
        print(f"{substitution.original_font_name} -> {substitution.substituted_font_name}")
```

## **選択スライドのフォント置換の取得**

Use [FontsManager.get_substitutions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes to inspect only the substitutions required to render specific slides. This is useful when you are rendering or exporting part of a presentation, checking a large presentation incrementally, locating slides that depend on unavailable fonts, preparing a minimal font package for a server or container, or diagnosing rendering differences without processing unrelated slides.

The list contains one-based slide indexes: `1` identifies the first slide. By contrast, the [Presentation.slides](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/slides/ja/) collection is zero-based, so that same slide is accessed as `presentation.slides[0]`. Keep this difference in mind when building the list to avoid off‑by‑one errors.

Call the method through the [Presentation.fonts_manager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/fonts_manager/) property. It returns only the substitutions determined while rendering the selected slides. Each result is a [FontSubstitutionInfo](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsubstitutioninfo/) object containing the original and substituted font names. The result reflects the current font environment, configured fallback rules, substitution rules stored in an [IFontSubstRuleCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/ifontsubstrulecollection/), and [externally loaded fonts](/slides/ja/python-net/custom-font/).

The same substitution can be required by more than one selected slide. Deduplicate the results when you create a font inventory or preflight report. The following example reports every returned substitution and then creates a sorted list of unique font mappings:

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

The [FontsManager](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/) class provides both forms of the method. Choose one according to the scope of the rendering operation:

| Method call | Use it when |
|---|---|
| [get_substitutions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_substitutions/) with no arguments | You need substitutions for the entire presentation. |
| [get_substitutions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_substitutions/) with a list of slide indexes | You need substitutions for a selected range, incremental check, or partial export. |

## **フォント置換ルールの設定**

To specify the font that Aspose.Slides should use when a source font is unavailable:

1. Load the presentation.  
2. Create font definitions for the source and substitute fonts.  
3. Create a [FontSubstRule](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsubstrule/) with the [WHEN_INACCESSIBLE](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsubstcondition/) condition.  
4. Add the rule to a [FontSubstRuleCollection](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsubstrulecollection/).  
5. Assign the collection to the [FontsManager.font_subst_rule_list](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/font_subst_rule_list/) property.  
6. Render or convert the presentation.

The following Python example substitutes `Arial` for `SomeRareFont` when `SomeRareFont` is unavailable, and then renders the first slide to verify the result. The substitute font must be available to Aspose.Slides.

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

## **数式フォントの制限事項**

Font substitution rules are part of the standard font selection process used during rendering and conversion. They work for regular text when Aspose.Slides can replace an inaccessible font with the available font specified by a rule.

Office Math equations have an additional requirement. If an equation uses **Cambria Math**, Aspose.Slides may need that exact font to calculate and render the equation layout. A rule that substitutes another math font, such as **STIX Two Math**, cannot replace **Cambria Math** for this purpose, and rendering may still report that **Cambria Math** is required.

To render or convert such a presentation, make **Cambria Math** available to Aspose.Slides. Install it in the operating system or load it as an [external font](/slides/ja/python-net/custom-font/).

This limitation applies to equation layout. The substitution rules described above still apply to regular presentation text.

## **よくある質問**

**フォント置換とフォント置換（replacement）の違いは何ですか？**  

[Font replacement](/slides/ja/python-net/font-replacement/) はプレゼンテーション全体でフォントを別のフォントに意図的に変更します。フォント置換は、元のフォントが利用できないなどの条件が満たされたときに、レンダリングされた出力用にフォントを選択します。

**置換ルールはいつ適用されますか？**  

ルールはレンダリングおよび変換時の[font selection sequence](/slides/ja/python-net/font-selection-sequence/)に参加します。`WHEN_INACCESSIBLE` の場合、ソースフォントにアクセスできないときのみルールが使用されます。

**フォントが欠落していて置換ルールが設定されていない場合、何が起こりますか？**  

Aspose.Slides はフォント選択プロセスに従って最も近い利用可能なフォントを選択します。結果はランタイム環境にインストールされているフォントに依存します。

**外部フォントをロードして置換を回避できますか？**  

はい。[外部フォントをロード](/slides/ja/python-net/custom-font/) すれば、レンダリングおよび変換時に Aspose.Slides がそれらを使用できます。

**Aspose はライブラリにフォントを同梱していますか？**  

いいえ。フォントの提供とライセンス遵守はユーザーの責任です。

**Windows、Linux、macOS 間で置換結果が異なることはありますか？**  

はい。各 OS のインストールフォント及びフォント検索パスが異なるため、あるマシンで利用できるフォントが別のマシンでは置換が必要になることがあります。

**バッチ変換でフォント選択を一貫させるにはどうすればよいですか？**  

すべてのマシンまたはコンテナで同一のフォントファイルとバージョンを使用し、[必要な外部フォントをロード](/slides/ja/python-net/custom-font/)し、ライセンスが許可する場合は[フォントを埋め込む](/slides/ja/python-net/embedded-font/)ことを推奨します。また、エクスポート前に [FontsManager.get_substitutions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/fontsmanager/get_substitutions/) を呼び出して予期しない置換を特定できます。