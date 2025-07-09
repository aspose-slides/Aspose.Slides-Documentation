---
title: Python でプレゼンテーションの段落およびテキスト部分をコピーする
linktitle: テキストをコピー
type: docs
weight: 80
url: /ja/python-net/copying-paragraph-and-portion-in-pptx/
keywords:
- 段落をコピー
- 段落を複製
- テキストをコピー
- テキストを複製
- テキスト部分をコピー
- テキスト部分を複製
- PowerPoint
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python を使用して、PowerPoint および OpenDocument プレゼンテーション間で段落およびテキスト部分をコピーし、ワークフローを向上させる方法をご紹介します。"
---

{{% alert color="primary" %}} 

プレゼンテーションのテキストをフォーマットするためには、**段落**および**部分**レベルでフォーマットする必要があります。段落レベルで設定できるテキストプロパティと、部分レベルで設定できるテキストプロパティがあります。テキストに新しく追加された段落または部分にコピーする必要がある段落または部分がある場合、それぞれの段落または部分のすべてのプロパティを新しく追加された段落または部分にコピーする必要があります。

{{% /alert %}} 
## **段落のコピー**
**段落**のプロパティは、**段落**クラスの**ParagraphFormat**インスタンスでアクセスできます。ソース段落のすべてのプロパティをターゲット段落にコピーする必要があります。次の例では、コピーする段落を引数として受け取る**CopyParagraph**メソッドが共有されています。ソース段落のすべてのプロパティを一時的な段落にコピーし、同じものを返します。ターゲット段落はコピーされた値を取得します。

```py
import aspose.slides as slides

#関数定義 
def copy_paragraph(par):
    temp = slides.Paragraph()
    # CreateParagraphFormatDataを使用する !!!
    paraData = par.create_paragraph_format_effective() 
    # 値を設定するためにParagraphFormatを使用
    temp.paragraph_format.alignment = paraData.alignment
    temp.paragraph_format.default_tab_size = paraData.default_tab_size
    temp.paragraph_format.margin_left = paraData.margin_left
    temp.paragraph_format.margin_right = paraData.margin_right
    temp.paragraph_format.font_alignment = paraData.font_alignment
    temp.paragraph_format.indent = paraData.indent
    temp.paragraph_format.depth = paraData.depth
    temp.paragraph_format.space_after = paraData.space_after
    temp.paragraph_format.space_before = paraData.space_before
    temp.paragraph_format.space_within = paraData.space_within

    temp.paragraph_format.bullet.char = paraData.bullet.char
    temp.paragraph_format.bullet.height = paraData.bullet.height
    temp.paragraph_format.bullet.font = paraData.bullet.font
    temp.paragraph_format.bullet.numbered_bullet_style = paraData.bullet.numbered_bullet_style
    temp.paragraph_format.font_alignment = paraData.font_alignment

    return temp  
```


## **部分のコピー**
**部分**のプロパティは、**部分**クラスの**PortionFormat**インスタンスでアクセスできます。ソース部分のすべてのプロパティをターゲット部分にコピーする必要があります。次の例では、コピーする部分を引数として受け取る**CopyPortion**メソッドが共有されています。ソース部分のすべてのプロパティを一時的な部分にコピーし、同じものを返します。ターゲット部分はコピーされた値を取得します。

```py
import aspose.slides as slides

#関数定義  
def copy_portion(por):
    temp = slides.Portion()

    # CreatePortionFormatDataを使用する !!!
    portData = por.create_portion_format_effective()

    # 値を設定するためにPortionFormatを使用
    temp.portion_format.alternative_language_id = portData.alternative_language_id
    temp.portion_format.bookmark_id = portData.bookmark_id
    temp.portion_format.escapement = portData.escapement
    temp.portion_format.fill_format.fill_type = por.portion_format.fill_format.fill_type
    temp.portion_format.fill_format.solid_fill_color.color = portData.fill_format.solid_fill_color.color

    temp.portion_format.font_bold = portData.font_bold
    temp.portion_format.font_height = portData.font_height

    temp.portion_format.font_italic = portData.font_italic

    temp.portion_format.font_underline = portData.font_underline
    temp.portion_format.underline_fill_format.fill_type = portData.underline_fill_format.fill_type
    temp.portion_format.underline_fill_format.solid_fill_color.color = portData.underline_fill_format.solid_fill_color.color

    temp.portion_format.is_hard_underline_fill = portData.is_hard_underline_fill

    temp.portion_format.is_hard_underline_line = portData.is_hard_underline_line

    temp.portion_format.kumimoji = portData.kumimoji

    temp.portion_format.kerning_minimal_size = portData.kerning_minimal_size
    temp.portion_format.language_id = portData.language_id
    
    temp.portion_format.latin_font = portData.latin_font
    temp.portion_format.east_asian_font = portData.east_asian_font
    temp.portion_format.complex_script_font = portData.complex_script_font
    temp.portion_format.symbol_font = portData.symbol_font

    temp.portion_format.text_cap_type = portData.text_cap_type
    temp.portion_format.spacing = portData.spacing
    temp.portion_format.strikethrough_type = portData.strikethrough_type

    temp.portion_format.proof_disabled = portData.proof_disabled

    temp.portion_format.normalise_height = portData.normalise_height

    temp.portion_format.hyperlink_mouse_over = portData.hyperlink_mouse_over
    temp.portion_format.hyperlink_click = por.portion_format.hyperlink_click
    temp.portion_format.highlight_color.color = portData.highlight_color.color

    return temp
```