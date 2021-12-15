---
title: Copying Paragraph and Portion in PPTX
type: docs
weight: 80
url: /python-net/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

In order to format presentation text we need to format that on **Paragraph** and **Portion** level. There are some text properties that can be set on Paragraph level and some are set on Portion level. If there is a paragraph or portion in the text that we need to copy to newly added paragraphs or portions, we need to copy all properties of respective paragraph or portion to newly added paragraph or portion.

{{% /alert %}} 
## **Copying a Paragraph**
The properties of the **Paragraph** can be accessed in **ParagraphFormat** instance of **Pargraph** class. We need to copy all the properties of source paragraph to target paragraph. In the following example, the **CopyParagraph** method is shared that takes paragraph to be copied as an argument. It copies all the properties of source paragraph to a temporary paragraph and return the same. The target paragraph gets the copied values.

```py
import aspose.slides as slides

#Function Definition 
def copy_paragraph(par):
    temp = slides.Paragraph()
    # use CreateParagraphFormatData !!!
    paraData = par.create_paragraph_format_effective() 
    # use ParagraphFormat  to set values
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


## **Copying a Portion**
The properties of the **Portion** can be accessed in **PortionFormat** instance of **Portion** class. We need to copy all the properties of source portion to target portion . In the following example, the **CopyPortion** method is shared that takes portion to be copied as an argument. It copies all the properties of source portion to a temporary portion and return the same. The target portion gets the copied values.

```py
import aspose.slides as slides

#Function Definition  
def copy_portion(por):
    temp = slides.Portion()

    #use CreatePortionFormatData!!!
    portData = por.create_portion_format_effective()

    # use PortionFormat to set values
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
