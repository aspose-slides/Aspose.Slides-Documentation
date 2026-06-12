---
title: Beheer rijen en kolommen in PowerPoint‑tabellen met Python
linktitle: Rijen en kolommen
type: docs
weight: 20
url: /nl/python-net/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkoptekst
- rij dupliceren
- kolom dupliceren
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak rij
- tekstopmaak kolom
- tabelstijl
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint en OpenDocument met Aspose.Slides voor Python via .NET en versnel bewerkings- en gegevensupdates van presentaties."
---
## **Overzicht**

Dit artikel laat zien hoe u rijen en kolommen in tabellen kunt beheren in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor Python. U leert hoe u rijen of kolommen kunt toevoegen, invoegen, dupliceren en verwijderen, de eerste rij als koptekst kunt markeren, de grootte en lay‑out kunt aanpassen, en tekst‑ en stijlopmaak op rijniveau of kolomniveau kunt toepassen. Elke taak wordt gedemonstreerd met compacte, zelfstandige code‑fragmenten op basis van de [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/)‑API, zodat u snel een tabel op een dia kunt vinden en de structuur kunt herstructureren naar uw ontwerp.

## **Eerste rij als koptekst instellen**

Markeer de eerste rij van de tabel als koptekst om kolomtitels duidelijk te onderscheiden van de gegevens. In Aspose.Slides voor Python schakelt u eenvoudig de *First Row*‑optie van de tabel in om de koptekstopmaak toe te passen die in de geselecteerde tabelstijl is gedefinieerd.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en laad de presentatie.
1. Toegang tot de dia via de index.
1. Doorloop alle [Shape](https://reference.aspose.com/slides/nl/python-net/aspose.slides/shape/)‑objecten om de betreffende tabel te vinden.
1. Stel de eerste rij van de tabel in als koptekst.

Deze Python‑code toont hoe u de eerste rij van een tabel als koptekst kunt instellen:

```python
import aspose.slides as slides

# Instantieer de Presentation‑klasse.
with slides.Presentation("table.pptx") as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Itereer door de shapes en verkrijg een referentie naar de tabel.
    for shape in slide.shapes:
        if type(shape) is slides.Table:
            table = shape
            break

    # Stel de eerste rij van de tabel in als koptekst.
    table.first_row = True
    
    # Sla de presentatie op schijf.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Een tabelrij of -kolom dupliceren**

Dupliceer een tabelrij of -kolom en voeg de kopie op de gewenste positie in de tabel in. Het duplicaat behoudt celinhoud, opmaak en afmetingen, zodat u lay‑outs snel en consistent kunt uitbreiden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en laad de presentatie.
1. Toegang tot de dia via de index.
1. Definieer een array met kolombreedtes.
1. Definieer een array met rijhoogtes.
1. Voeg een [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/) toe aan de dia met `add_table(x, y, column_widths, row_heights)`.
1. Dupliceer een tabelrij.
1. Dupliceer een tabelkolom.
1. Sla de gewijzigde presentatie op.

Deze Python‑code toont hoe u een rij en kolom van een PowerPoint‑tabel dupliceert:

```python
 import aspose.slides as slides

# Instantieer de Presentation‑klasse.
with slides.Presentation() as presentation:
    # Toegang tot de eerste dia.
    slide = presentation.slides[0]

    # Definieer kolombreedtes en rijhoogtes.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Voeg een tabel toe aan de dia.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Voeg tekst toe aan rij 1, kolom 1.
    table.rows[0][0].text_frame.text = "Row 1 Cell 1"

    # Voeg tekst toe aan rij 2, kolom 1.
    table.rows[1][0].text_frame.text = "Row 1 Cell 2"

    # Dupliceer rij 1 aan het einde van de tabel.
    table.rows.add_clone(table.rows[0], False)

    # Voeg tekst toe aan rij 1, kolom 2.
    table.rows[0][1].text_frame.text = "Row 2 Cell 1"

    # Voeg tekst toe aan rij 2, kolom 2.
    table.rows[1][1].text_frame.text = "Row 2 Cell 2"

    # Dupliceer rij 2 als de 4e rij van de tabel.
    table.rows.insert_clone(3,table.rows[1], False)

    # Dupliceer de eerste kolom aan het einde.
    table.columns.add_clone(table.columns[0], False)

    # Dupliceer de tweede kolom op index 3 (de 4e positie).
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Sla de presentatie op schijf.
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Een rij of kolom uit een tabel verwijderen**

Vereenvoudig een tabel door een rij of kolom op index te verwijderen met Aspose.Slides voor Python – de lay‑out past zich automatisch aan terwijl de opmaak van de overgebleven cellen behouden blijft. Handig om datagrids te verkleinen of tijdelijke aanduidingen te verwijderen zonder de tabel opnieuw op te bouwen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en laad de presentatie.
1. Toegang tot de dia via de index.
1. Definieer een array met kolombreedtes.
1. Definieer een array met rijhoogtes.
1. Voeg een ITable toe aan de dia met `add_table(x, y, column_widths, row_heights)`.
1. Verwijder de tabelrij.
1. Verwijder de tabelkolom.
1. Sla de gewijzigde presentatie op.

De volgende Python‑code laat zien hoe u een rij en kolom uit een tabel verwijdert:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    
    column_widths = [100, 50, 30]
    row_heights = [30, 50, 30]

    table = slide.shapes.add_table(100, 100, column_widths, row_heights)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)

    presentation.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstopmaak op tabelrij‑niveau instellen**

Pas consistente tekststijlen toe op een gehele tabelrij in één stap. Met Aspose.Slides voor Python kunt u lettertype, grootte, gewicht, kleur en uitlijning voor alle cellen in de rij tegelijk instellen, zodat koppen of datarijen uniform blijven.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en laad de presentatie.
1. Toegang tot de dia via de index.
1. Toegang tot het relevante [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/)‑object op de dia.
1. Stel de letterhoogte in voor de cellen van de eerste rij.
1. Stel de uitlijning en rechter marge in voor de cellen van de eerste rij.
1. Stel het verticale tekstype in voor de cellen van de tweede rij.
1. Sla de gewijzigde presentatie op.

Deze Python‑code demonstreert de bewerking.

```python
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Stel de letterhoogte in voor de cellen van de eerste rij.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.rows[0].set_text_format(portion_format)

    # Stel de tekstuitlijning en rechter marge van de cellen van de eerste rij in.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.rows[0].set_text_format(paragraph_format)

    # Stel het verticale teksttype in voor de cellen van de tweede rij.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.rows[1].set_text_format(text_frame_format)
    
    # Sla de presentatie op schijf.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tekstopmaak op tabelkolom‑niveau instellen**

Pas consistente tekststijlen toe op een gehele tabelkolom in één keer. Met Aspose.Slides voor Python kunt u lettertype, grootte, gewicht, kleur en uitlijning voor alle cellen in een kolom instellen om uniforme verticale banden voor koppen of gegevens te creëren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/)‑klasse en laad de presentatie.
1. Toegang tot de dia via de index.
1. Toegang tot het relevante [Table](https://reference.aspose.com/slides/nl/python-net/aspose.slides/table/)‑object op de dia.
1. Stel de letterhoogte in voor de cellen van de eerste kolom.
1. Stel de uitlijning en rechter marge in voor de cellen van de eerste kolom.
1. Stel het verticale tekstype in voor de cellen van de tweede kolom.
1. Sla de gewijzigde presentatie op.

De volgende Python‑code demonstreert de bewerking:

```python
import aspose.slides as slides

# Maak een instantie van de Presentation‑klasse.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Stel de letterhoogte in voor de cellen van de eerste kolom.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.columns[0].set_text_format(portion_format)

    # Stel de tekstuitlijning en rechter marge in voor de cellen van de eerste kolom.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.columns[0].set_text_format(paragraph_format)

    # Stel het verticale teksttype in voor de cellen van de tweede kolom.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.columns[1].set_text_format(text_frame_format)

    # Sla de presentatie op schijf.
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabel‑stijleigenschappen ophalen**

Aspose.Slides stelt u in staat om de stijleigenschappen van een tabel op te halen zodat u ze kunt hergebruiken voor een andere tabel of elders. De volgende Python‑code laat zien hoe u de stijl‑eigenschappen van een vooraf ingestelde tabelstijl ophaalt:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een reeds aangemaakte tabel?**

Ja. De tabel erft het thema van de dia/lay‑out/master, en u kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer uw gegevens eerst in het geheugen en vul vervolgens de tabelrijen in die volgorde opnieuw.

**Kan ik gestreepte kolommen hebben terwijl ik aangepaste kleuren voor specifieke cellen behoud?**

Ja. Schakel gestreepte kolommen in en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabelstijl.