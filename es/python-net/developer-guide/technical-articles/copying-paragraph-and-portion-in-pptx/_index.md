---
title: Copiando Párrafo y Porción en PPTX
type: docs
weight: 80
url: /es/python-net/copiando-parrafo-y-porcion-en-pptx/
---

{{% alert color="primary" %}} 

Para formatear el texto de la presentación, necesitamos formatearlo a nivel de **Párrafo** y **Porción**. Hay algunas propiedades de texto que se pueden establecer a nivel de Párrafo y otras que se establecen a nivel de Porción. Si hay un párrafo o porción en el texto que necesitamos copiar a los párrafos o porciones recién agregados, debemos copiar todas las propiedades del párrafo o porción respectiva al nuevo párrafo o porción agregado.

{{% /alert %}} 
## **Copiando un Párrafo**
Las propiedades del **Párrafo** se pueden acceder en la instancia **ParagraphFormat** de la clase **Pargraph**. Necesitamos copiar todas las propiedades del párrafo fuente al párrafo objetivo. En el siguiente ejemplo, se comparte el método **CopyParagraph** que toma como argumento el párrafo a copiar. Copia todas las propiedades del párrafo fuente a un párrafo temporal y devuelve el mismo. El párrafo objetivo recibe los valores copiados.

```py
import aspose.slides as slides

#Definición de Función 
def copy_paragraph(par):
    temp = slides.Paragraph()
    # usa CreateParagraphFormatData !!!
    paraData = par.create_paragraph_format_effective() 
    # usa ParagraphFormat para establecer valores
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


## **Copiando una Porción**
Las propiedades de la **Porción** se pueden acceder en la instancia **PortionFormat** de la clase **Portion**. Necesitamos copiar todas las propiedades de la porción fuente a la porción objetivo. En el siguiente ejemplo, se comparte el método **CopyPortion** que toma como argumento la porción a copiar. Copia todas las propiedades de la porción fuente a una porción temporal y devuelve la misma. La porción objetivo obtiene los valores copiados.

```py
import aspose.slides as slides

#Definición de Función  
def copy_portion(por):
    temp = slides.Portion()

    #usa CreatePortionFormatData!!!
    portData = por.create_portion_format_effective()

    # usa PortionFormat para establecer valores
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