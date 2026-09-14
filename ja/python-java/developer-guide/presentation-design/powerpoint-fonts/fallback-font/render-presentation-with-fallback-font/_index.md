---
title: Python と Java を使用したフォールバック フォントによるプレゼンテーションのレンダリング
linktitle: プレゼンテーションのレンダリング
type: docs
weight: 30
url: /ja/python-java/render-presentation-with-fallback-font/
keywords:
- フォールバック フォント
- PowerPoint のレンダリング
- プレゼンテーションのレンダリング
- スライドのレンダリング
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Python と Java を介した Aspose.Slides でフォールバック フォントを使用してプレゼンテーションをレンダリングします – PPT、PPTX、ODP 間でテキストの一貫性を保つためのステップバイステップ Python コードサンプルを提供します。"
---
## **概要**

Aspose.Slides では、フォールバック フォント ルールを使用してプレゼンテーションをレンダリングできます。この記事では、フォールバック フォント ルール コレクションを作成し、フォールバック フォントの削除または追加によってルールを変更し、[FontsManager.setFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) メソッドを使用してコレクションを割り当てる方法を示します。

フォールバック フォント ルール コレクションがプレゼンテーションの[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/)に割り当てられると、保存、レンダリング、変換などの操作中にルールが適用されます。この例では、スライドのサムネイルをレンダリングし、JPEG 画像として保存する際に設定されたルールを使用する方法を示します。

## **フォールバック フォント ルールを使用したスライドのレンダリング**

以下の例では次の手順を実行します。

1. [フォールバック フォント ルール コレクションを作成](/slides/ja/python-java/create-fallback-fonts-collection/)。
2. [削除](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/#remove) ルールからフォールバック フォントを削除し、[フォールバック フォントを追加](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontfallbackrule/#addFallBackFonts) して別のルールに適用します。
3. [getFontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getFontsManager) で取得したフォント マネージャーに対して [setFontFallBackRulesCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/#setFontFallBackRulesCollection) を使用してルール コレクションを割り当てます。
4. [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドを使用して、プレゼンテーションを同じ形式または別の形式で保存します。フォールバック フォント ルール コレクションが[FontsManager](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsmanager/)に割り当てられた後、保存、レンダリング、変換などの操作中にこれらのルールが適用されます。

```python
import jpype
import asposeslides

if not jpyle.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontFallBackRule, FontFallBackRulesCollection, ImageFormat, Presentation

# 新しいルール コレクションを作成します。
fallback_rules = FontFallBackRulesCollection()

# 複数のルールを作成します。
cyrillic_rule = FontFallBackRule(0x400, 0x4FF, "Times New Roman")
fallback_rules.add(cyrillic_rule)
arabic_rule = FontFallBackRule(0x600, 0x6FF, "Tahoma, Arial")
fallback_rules.add(arabic_rule)

for fallback_rule in fallback_rules:
    # ルールからフォールバック フォント "Tahoma" を削除しようとしています。
    fallback_rule.remove("Tahoma")

    # 指定された範囲のルールを更新します。
    if fallback_rule.getRangeEndIndex() >= 0x400 and fallback_rule.getRangeStartIndex() < 0x500:
        fallback_rule.addFallBackFonts("Verdana")

# 既存のルールを削除し、レンダリング用に少なくとも 1 つのルールを残します。
if fallback_rules.size() > 1:
    rule_to_remove = fallback_rules.get_Item(1)
    fallback_rules.remove(rule_to_remove)

presentation = Presentation("input.pptx")
try:
    # 用意したルール コレクションを割り当てます。
    presentation.getFontsManager().setFontFallBackRulesCollection(fallback_rules)

    # 設定されたルール コレクションを使用してサムネイルをレンダリングします。
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # 画像を JPEG 形式でディスクに保存します。
        slide_image.save("Slide_0.jpg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="注意" %}}
Python と Java を介して PPT および PPTX を JPG に変換する方法の詳細は、[Python と Java で PPT と PPTX を JPG に変換](/slides/ja/python-java/convert-powerpoint-to-jpg/) をご覧ください。
{{% /alert %}}