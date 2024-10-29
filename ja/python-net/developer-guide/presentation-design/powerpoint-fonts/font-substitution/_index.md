---
title: フォントの置き換え
type: docs
weight: 70
url: /ja/python-net/font-substitution/
keywords: "フォント, 置き換えフォント, PowerPointプレゼンテーション, Python, Aspose.Slides for Python via .NET"
description: "PythonでのPowerPointでのフォント置き換え"
---

Aspose.Slidesを使用すると、特定の条件（たとえば、フォントにアクセスできない場合）で何をすべきかを決定するフォントに関するルールを設定できます。手順は次のとおりです：

1. 関連するプレゼンテーションを読み込む。
2. 置き換えるフォントを読み込む。
3. 新しいフォントを読み込む。
4. 置き換えのルールを追加する。
5. ルールをプレゼンテーションのフォント置き換えルールコレクションに追加する。
6. 効果を観察するためにスライド画像を生成する。

このPythonコードはフォント置き換えプロセスを示しています：

```python
import aspose.slides as slides

# プレゼンテーションを読み込む
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # 置き換えられるソースフォントを読み込む
    sourceFont = slides.FontData("SomeRareFont")

    # 新しいフォントを読み込む
    destFont = slides.FontData("Arial")

    # フォント置き換えのためのフォントルールを追加する
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # ルールをフォント置き換えルールコレクションに追加する
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # フォントルールコレクションをルールリストに追加する
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    # SomeRareFontがアクセスできない場合、Arialフォントがその代わりに使用されます
    with presentation.slides[0].get_image(1, 1) as bmp:
        # 画像をJPEG形式でディスクに保存する
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="注意"  color="warning"   %}} 

[**フォント置き換え**](/slides/ja/python-net/font-replacement/)を参照することをお勧めします。 

{{% /alert %}}