---
title: 复制PPTX中的段落和部分
type: docs
weight: 80
url: /zh/python-net/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

为了格式化演示文稿文本，我们需要在**段落**和**部分**级别进行格式设置。一些文本属性可以在段落级别设置，而一些则在部分级别设置。如果文本中有段落或部分需要复制到新添加的段落或部分中，我们需要将相应段落或部分的所有属性复制到新添加的段落或部分中。

{{% /alert %}} 
## **复制段落**
**段落**的属性可以在**Pargraph**类的**ParagraphFormat**实例中访问。我们需要将源段落的所有属性复制到目标段落。在以下示例中，共享了**CopyParagraph**方法，该方法将要复制的段落作为参数传递。它将源段落的所有属性复制到一个临时段落并返回。目标段落获得复制的值。

```py
import aspose.slides as slides

#函数定义 
def copy_paragraph(par):
    temp = slides.Paragraph()
    # 使用CreateParagraphFormatData !!!
    paraData = par.create_paragraph_format_effective() 
    # 使用ParagraphFormat设置值
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


## **复制部分**
**部分**的属性可以在**Portion**类的**PortionFormat**实例中访问。我们需要将源部分的所有属性复制到目标部分。在以下示例中，共享了**CopyPortion**方法，该方法将要复制的部分作为参数传递。它将源部分的所有属性复制到一个临时部分并返回。目标部分获得复制的值。

```py
import aspose.slides as slides

#函数定义  
def copy_portion(por):
    temp = slides.Portion()

    #使用CreatePortionFormatData!!!
    portData = por.create_portion_format_effective()

    # 使用PortionFormat设置值
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