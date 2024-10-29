---
title: Copier un Paragraphe et une Portion dans PPTX
type: docs
weight: 80
url: /fr/python-net/copying-paragraph-and-portion-in-pptx/
---

{{% alert color="primary" %}} 

Pour formater le texte de présentation, nous devons le formater au niveau du **Paragraphe** et de la **Portion**. Il existe certaines propriétés de texte qui peuvent être définies au niveau du Paragraphe et d'autres qui sont définies au niveau de la Portion. S'il y a un paragraphe ou une portion dans le texte que nous devons copier dans de nouveaux paragraphes ou portions ajoutés, nous devons copier toutes les propriétés du paragraphe ou de la portion respective dans le nouveau paragraphe ou la nouvelle portion ajoutée.

{{% /alert %}} 
## **Copier un Paragraphe**
Les propriétés du **Paragraphe** peuvent être accédées dans l'instance **ParagraphFormat** de la classe **Paragraph**. Nous devons copier toutes les propriétés du paragraphe source dans le paragraphe cible. Dans l'exemple suivant, la méthode **CopyParagraph** est partagée et prend le paragraphe à copier comme argument. Elle copie toutes les propriétés du paragraphe source dans un paragraphe temporaire et renvoie le même. Le paragraphe cible reçoit les valeurs copiées.

```py
import aspose.slides as slides

#Définition de la Fonction 
def copy_paragraph(par):
    temp = slides.Paragraph()
    # utilisez CreateParagraphFormatData !!!
    paraData = par.create_paragraph_format_effective() 
    # utilisez ParagraphFormat pour définir les valeurs
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


## **Copier une Portion**
Les propriétés de la **Portion** peuvent être accédées dans l'instance **PortionFormat** de la classe **Portion**. Nous devons copier toutes les propriétés de la portion source dans la portion cible. Dans l'exemple suivant, la méthode **CopyPortion** est partagée et prend la portion à copier comme argument. Elle copie toutes les propriétés de la portion source dans une portion temporaire et renvoie la même. La portion cible reçoit les valeurs copiées.

```py
import aspose.slides as slides

#Définition de la Fonction  
def copy_portion(por):
    temp = slides.Portion()

    #utilisez CreatePortionFormatData!!!
    portData = por.create_portion_format_effective()

    # utilisez PortionFormat pour définir les valeurs
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