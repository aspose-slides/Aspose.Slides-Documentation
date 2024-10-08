---
title: Kopieren von Absatz und Portion in PPTX
type: docs
weight: 80
url: /de/python-net/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Um den Präsentationstext zu formatieren, müssen wir dies auf **Absatz**- und **Portion**-Ebene tun. Es gibt einige Textmerkmale, die auf Absatzebene festgelegt werden können, und einige, die auf Portionsebene festgelegt werden. Wenn es einen Absatz oder eine Portion im Text gibt, den wir in neu hinzugefügte Absätze oder Portionen kopieren müssen, müssen wir alle Eigenschaften des jeweiligen Absatzes oder der jeweiligen Portion in den neu hinzugefügten Absatz oder die neu hinzugefügte Portion kopieren.

{{% /alert %}} 
## **Kopieren eines Absatzes**
Die Eigenschaften des **Absatzes** können in der **ParagraphFormat**-Instanz der **Pargraph**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften des Quellabsatzes in den Zielabsatz kopieren. Im folgenden Beispiel wird die Methode **CopyParagraph** bereitgestellt, die den zu kopierenden Absatz als Argument übernimmt. Sie kopiert alle Eigenschaften des Quellabsatzes in einen temporären Absatz und gibt diesen zurück. Der Zielabsatz erhält die kopierten Werte.

```py
import aspose.slides as slides

#Funktionsdefinition 
def copy_paragraph(par):
    temp = slides.Paragraph()
    # Verwende CreateParagraphFormatData !!!
    paraData = par.create_paragraph_format_effective() 
    # Verwende ParagraphFormat, um Werte festzulegen
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


## **Kopieren einer Portion**
Die Eigenschaften der **Portion** können in der **PortionFormat**-Instanz der **Portion**-Klasse zugegriffen werden. Wir müssen alle Eigenschaften der Quellportion in die Zielportion kopieren. Im folgenden Beispiel wird die Methode **CopyPortion** bereitgestellt, die die zu kopierende Portion als Argument übernimmt. Sie kopiert alle Eigenschaften der Quellportion in eine temporäre Portion und gibt diese zurück. Die Zielportion erhält die kopierten Werte.

```py
import aspose.slides as slides

#Funktionsdefinition  
def copy_portion(por):
    temp = slides.Portion()

    #Verwende CreatePortionFormatData!!!
    portData = por.create_portion_format_effective()

    # Verwende PortionFormat, um Werte festzulegen
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