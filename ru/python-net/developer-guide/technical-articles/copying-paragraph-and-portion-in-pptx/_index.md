---
title: Копирование абзаца и доли в PPTX
type: docs
weight: 80
url: /python-net/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Для форматирования текста презентации нам необходимо форматировать его на уровне **абзаца** и **доли**. Существуют некоторые свойства текста, которые могут быть установлены на уровне абзаца, а некоторые – на уровне доли. Если в тексте есть абзац или доля, которые мы хотим скопировать в новые добавленные абзацы или доли, нам необходимо скопировать все свойства соответствующего абзаца или доли в новый добавленный абзац или долю.

{{% /alert %}} 
## **Копирование абзаца**
Свойства **абзаца** можно получить из экземпляра **ParagraphFormat** класса **Paragraph**. Нам нужно скопировать все свойства исходного абзаца в целевой абзац. В следующем примере представлен метод **CopyParagraph**, который принимает абзац для копирования в качестве аргумента. Он копирует все свойства исходного абзаца во временный абзац и возвращает тот же. Целевой абзац получает скопированные значения.

```py
import aspose.slides as slides

# Определение функции 
def copy_paragraph(par):
    temp = slides.Paragraph()
    # используйте CreateParagraphFormatData !!!
    paraData = par.create_paragraph_format_effective() 
    # используйте ParagraphFormat для установки значений
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


## **Копирование доли**
Свойства **доли** можно получить из экземпляра **PortionFormat** класса **Portion**. Нам нужно скопировать все свойства исходной доли в целевую долю. В следующем примере представлен метод **CopyPortion**, который принимает долю для копирования в качестве аргумента. Он копирует все свойства исходной доли во временную долю и возвращает тот же. Целевая доля получает скопированные значения.

```py
import aspose.slides as slides

# Определение функции  
def copy_portion(por):
    temp = slides.Portion()

    # используйте CreatePortionFormatData!!!
    portData = por.create_portion_format_effective()

    # используйте PortionFormat для установки значений
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