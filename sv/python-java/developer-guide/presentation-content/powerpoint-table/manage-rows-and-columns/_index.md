---
title: Hantera rader och kolumner i PowerPoint‑tabeller med Python
linktitle: Rader och kolumner
type: docs
weight: 20
url: /sv/python-java/manage-rows-and-columns/
keywords:
- tabellrad
- tabellkolumn
- första rad
- tabellrubrik
- klona rad
- klona kolumn
- kopiera rad
- kopiera kolumn
- ta bort rad
- ta bort kolumn
- radtextformatering
- kolumntextformatering
- tabellstil
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Hantera tabellrader och -kolumner i PowerPoint med Aspose.Slides för Python via Java och snabba upp redigering av presentationer samt datauppdateringar."
---
## **Introduktion**

Aspose.Slides för Python via Java låter dig hantera tabellstruktur och formatering i PowerPoint-presentationer via klassen [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) . Du kan ange en rubrikrad, klona eller ta bort rader och kolumner och tillämpa textformatering på en hel rad eller kolumn.

Den här artikeln förklarar dessa operationer med Python-exempel. Den visar också hur du hämtar en tabells stilförinställning så att du kan återanvända den. Index för rader och kolumner i en tabell är nollbaserade.

## **Kontroll av radhöjd**

Använd [Row.setMinimalHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#setMinimalHeight) för att ange en rads minimumhöjd i punkter. Det är en lägre gräns, inte en fast höjd. [Row.getHeight](https://reference.aspose.com/slides/python-java/aspose.slides/row/#getHeight) returnerar den faktiska höjden. Åtkomst till raden sker via [Table.getRows](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getRows).

Exemplet laddar [row-height-input.pptx](row-height-input.pptx), som har en tabell som den första formen på den första bilden. Dess första rad börjar vid 70 punkter. Cellerna använder 18‑punkts Arial‑text, radbrytning och 6‑punkts övre och nedre marginaler; den längre texten i den andra kolumnen radbryts till flera rader. Exemplet ökar minimum till 100 punkter, minskar det sedan till 20 punkter, skriver ut den faktiska höjden efter varje förändring och sparar båda resultaten.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("row-height-input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    row = table.getRows().get_Item(0)

    row.setMinimalHeight(100)
    print(f"Increased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx)

    row.setMinimalHeight(20)
    print(f"Decreased: minimum = {row.getMinimalHeight():.1f}, actual = {row.getHeight():.1f} pt")
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Med den medföljande presentationen lägger en ökning av minimum till extra utrymme i raden. En minskning tar bort det extra utrymmet, men den faktiska höjden förblir större än 20 punkter eftersom texten och cellmarginalerna behöver mer utrymme. Att bara minska minimum kan inte tvinga raden under det utrymme som dess innehåll kräver.

Flera faktorer påverkar den faktiska höjden:

- **Text och teckenstorlek:** längre text, explicita radbrytningar eller ett större teckensnitt kan kräva mer vertikalt utrymme.
- **Radbrytning och kolumnbredd:** med radbrytning aktiverad kan minskning av kolumnbredden med [Column.setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/column/#setWidth) skapa fler rader. En bredare kolumn kan minska det vertikala utrymmet som behövs.
- **Cellmarginaler:** [Cell.setMarginTop](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginTop) och [Cell.setMarginBottom](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginBottom) lägger till vertikalt utrymme. [Cell.setMarginLeft](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginLeft) och [Cell.setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#setMarginRight) minskar bredden som är tillgänglig för text och kan orsaka ytterligare radbrytning.

För den här tabellen utan sammanslagna celler bestämmer den cell som behöver mest vertikalt utrymme den innehållsdrivna lägre gränsen för hela raden. För att göra raden kortare kan du också behöva förkorta texten, minska teckenstorleken eller marginalerna, eller bredda en kolumn.

Bilderna nedan visar samma tabell i samma skala. I de illustrerade resultaten var de faktiska höjderna 70, 100 och 55.2 punkter: den sista raden förblev högre än sitt minimum på 20 punkter. Exakta textmått kan variera beroende på vilka teckensnitt som finns i din miljö. Hämta de sparade resultaten: [increased minimum](row-height-increased.pptx) och [decreased minimum](row-height-decreased.pptx).

| Original: minimum 70 pt, faktiskt 70 pt | Ökad: minimum 100 pt, faktiskt 100 pt | Minskad: minimum 20 pt, faktiskt 55.2 pt |
| --- | --- | --- |
| ![Originaltabell med en första rad på 70 punkter.](row-height-before.png) | ![Tabell efter att ha ökat första radens minimum till 100 punkter.](row-height-increased.png) | ![Tabell efter att ha minskat första radens minimum till 20 punkter; radbryten text håller raden högre än minimum.](row-height-decreased.png) |

## **Ställ in den första raden som en rubrik**

Använd metoden [setFirstRow](https://reference.aspose.com/slides/python-java/aspose.slides/table/#setFirstRow) för att markera den första raden för rubrikformatering. Dess utseende beror på den tabellstil som tillämpas på tabellen.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Åtkomst till den första bilden.
3. Åtkomst till tabellen som är lagrad som den första formen på bilden.
4. Aktivera rubrikformatering för dess första rad.
5. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden. Det aktiverar rubrikformatering för den första raden och sparar `First_row_header.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)
    table.setFirstRow(True)

    presentation.save("First_row_header.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klona en tabellrad eller kolumn**

Klona rader eller kolumner för att återanvända deras innehåll och formatering. Du kan lägga till en kopia i slutet av tabellen eller infoga den på en specifik position.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Åtkomst till den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) .
5. Klona de erforderliga raderna.
6. Klona de erforderliga kolumnerna.
7. Spara den ändrade presentationen.

Exemplet kräver `Test.pptx` med minst en bild. Det skapar en tabell med tre kolumner och fem rader, med dimensioner angivna i punkter. Det lägger till kopior av den första raden och kolumnen, och infogar sedan kopior av den andra raden och kolumnen på index 3 (den fjärde positionen). Den resulterande tabellen har sju rader och fem kolumner. Argumentet `False` inaktiverar kloning in i intilliggande sammanslagna rader eller kolumner; denna tabell har inga sammanslagna celler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("Test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([50, 50, 50])
    row_heights = jpype.JArray(jpype.JDouble)([50, 30, 30, 30, 30])
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1")
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2")
    table.getRows().addClone(table.getRows().get_Item(0), False)

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1")
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2")
    table.getRows().insertClone(3, table.getRows().get_Item(1), False)

    table.getColumns().addClone(table.getColumns().get_Item(0), False)
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), False)

    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ta bort en rad eller kolumn från en tabell**

Ta bort rader eller kolumner som inte längre behövs i en tabell. När ett objekt tas bort förskjuts indexen för de rader eller kolumner som följer efter.

1. Skapa en presentation med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Åtkomst till den första bilden.
3. Definiera kolumnbredder och radhöjder.
4. Lägg till en tabell med metoden [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) .
5. Ta bort den andra raden och den andra kolumnen.
6. Spara den ändrade presentationen.

Detta exempel skapar en tre‑på‑tre‑tabell och tar bort raden och kolumnen på index 1, vilket lämnar en två‑på‑två‑tabell i `TestTable_out.pptx`. Dimensionerna är i punkter. Argumentet `False` inaktiverar borttagning av intilliggande sammanslagna rader eller kolumner; denna tabell har inga sammanslagna celler.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 50, 30])
    row_heights = jpype.JArray(jpype.JDouble)([30, 50, 30])
    table = slide.getShapes().addTable(100, 100, column_widths, row_heights)

    table.getRows().removeAt(1, False)
    table.getColumns().removeAt(1, False)

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange textformatering på radnivå i tabellen**

Tillämpa textformatering på en hel rad för att hålla dess celler konsekventa. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Åtkomst till tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) för den första raden.
4. Använd [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) och [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) för den första raden.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) för den andra raden.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två rader. Det tillämpar 25‑punkts text, högerjustering och en 20‑punkts höger styckemarginal på den första raden, och sätter sedan vertikal text i den andra raden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getRows().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getRows().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getRows().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("row_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ange textformatering på kolumnnivå i tabellen**

Tillämpa textformatering på en hel kolumn för att hålla dess celler konsekventa. Du kan ange teckensegenskaper, styckeformatering och textriktning utan att formatera varje cell individuellt.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Åtkomst till tabellen på den första bilden.
3. Använd [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) för den första kolumnen.
4. Använd [setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) och [setMarginRight](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setMarginRight) för den första kolumnen.
5. Använd [setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) för den andra kolumnen.
6. Spara den ändrade presentationen.

Exemplet kräver `table.pptx` med en tabell som den första formen på den första bilden och minst två kolumner. Det tillämpar 25‑punkts text, högerjustering och en 20‑punkts höger styckemarginal på den första kolumnen, och sätter sedan vertikal text i den andra kolumnen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, PortionFormat, ParagraphFormat, TextFrameFormat, TextAlignment, TextVerticalType

presentation = Presentation("table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().get_Item(0)

    portion_format = PortionFormat()
    portion_format.setFontHeight(25)
    table.getColumns().get_Item(0).setTextFormat(portion_format)

    paragraph_format = ParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Right)
    paragraph_format.setMarginRight(20)
    table.getColumns().get_Item(0).setTextFormat(paragraph_format)

    text_frame_format = TextFrameFormat()
    text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
    table.getColumns().get_Item(1).setTextFormat(text_frame_format)

    presentation.save("column_formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hämta egenskaper för tabellstil**

Använd metoden [getStylePreset](https://reference.aspose.com/slides/python-java/aspose.slides/table/#getStylePreset) för att hämta den förinställning som tillämpats på en tabell och återanvända den på en annan tabell. Detta identifierar förinställningen snarare än enskilda cellformateringsöverskrivningar.

Exemplet skapar en tabell, tillämpar [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/python-java/aspose.slides/tablestylepreset/#DarkStyle1), och läser tillbaka förinställningen. Det skriver ut det heltalsvärde som motsvarar `DarkStyle1` och sparar tabellen i `table.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = jpype.JArray(jpype.JDouble)([100, 150])
    row_heights = jpype.JArray(jpype.JDouble)([5, 5, 5])
    table = slide.getShapes().addTable(10, 10, column_widths, row_heights)
    table.setStylePreset(TableStylePreset.DarkStyle1)

    style_preset = table.getStylePreset()
    print(style_preset)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kan jag tillämpa PowerPoint‑teman/‑stilar på en redan skapad tabell?**

Ja. Tabellen ärver bildens/layoutens/master‑tema, och du kan fortfarande åsidosätta fyllningar, kanter och textfärger ovanpå det temat.

**Kan jag sortera tabellrader som i Excel?**

Nej, Aspose.Slides‑tabeller har ingen inbyggd sortering eller filtrering. Sortera dina data i minnet först och fyll sedan tabellraderna på nytt i den ordningen.

**Kan jag ha bandade (randiga) kolumner samtidigt som jag behåller anpassade färger på specifika celler?**

Ja. Aktivera bandade kolumner och åsidosätt sedan specifika celler med lokal formatering; cellnivåformatering har företräde framför tabellstilen.