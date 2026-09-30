---
title: "Beheer rijen en kolommen in PowerPoint‑tabellen op Android"
linktitle: "Rijen en kolommen"
type: docs
weight: 20
url: /nl/androidjava/manage-rows-and-columns/
keywords:
- tabelrij
- tabelkolom
- eerste rij
- tabelkop
- rij klonen
- kolom klonen
- rij kopiëren
- kolom kopiëren
- rij verwijderen
- kolom verwijderen
- tekstopmaak van rij
- tekstopmaak van kolom
- tabelstijl
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer tabelrijen en -kolommen in PowerPoint met Aspose.Slides voor Android via Java en versnel het bewerken van presentaties en het bijwerken van gegevens."
---
## **Introductie**

Aspose.Slides for Android via Java stelt je in staat om de tabelstructuur en -opmaak in PowerPoint‑presentaties te beheren via de [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) class en [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interface. Je kunt een header‑rij aanwijzen, rijen en kolommen klonen of verwijderen, en tekstopmaak toepassen op een gehele rij of kolom.

Dit artikel legt deze bewerkingen uit met Java‑voorbeelden. Het laat ook zien hoe je de stijl‑preset van een tabel kunt ophalen zodat je deze kunt hergebruiken. Rij‑ en kolomindexen in tabellen beginnen bij nul.

## **Rijhoogte regelen**

Gebruik [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-) om de minimale hoogte van een rij in punten in te stellen. Het is een ondergrens, geen vaste hoogte. [IRow.getHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#getHeight--) retourneert de werkelijke hoogte. Toegang tot de rij krijg je via [ITable.getRows](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getRows--).

Het voorbeeld laadt [row-height-input.pptx](row-height-input.pptx), die een tabel bevat als de eerste vorm op de eerste dia. De eerste rij begint bij 70 punten. De cellen gebruiken 18‑punt Arial‑tekst, omloop, en 6‑punt marges boven en onder; de langere tekst in de tweede kolom omloopt over meerdere regels. Het voorbeeld verhoogt het minimum naar 100 punten, verlaagt het daarna naar 20 punten, print de werkelijke hoogte na elke wijziging, en slaat beide resultaten op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("row-height-input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    IRow row = table.getRows().get_Item(0);

    row.setMinimalHeight(100);
    System.out.printf("Increased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-increased.pptx", SaveFormat.Pptx);

    row.setMinimalHeight(20);
    System.out.printf("Decreased: minimum = %.1f, actual = %.1f pt%n", row.getMinimalHeight(), row.getHeight());
    presentation.save("row-height-decreased.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Met de meegeleverde presentatie voegt het verhogen van het minimum ruimte toe aan de rij. Het verlagen ervan verwijdert die extra ruimte, maar de werkelijke hoogte blijft groter dan 20 punten omdat de tekst en cel‑marges meer ruimte nodig hebben. Alleen het verlagen van het minimum kan de rij niet onder de door de inhoud vereiste ruimte dwingen.

Verschillende factoren beïnvloeden de werkelijke hoogte:

- **Tekst en lettergrootte:** langere tekst, expliciete regeleinden of een groter lettertype kunnen meer verticale ruimte vereisen.
- **Omloop en kolombreedte:** met ingeschakelde omloop kan het verkleinen van de kolombreedte met [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) meer regels veroorzaken. Een bredere kolom kan de benodigde verticale ruimte verminderen.
- **Cel‑marges:** [ICell.setMarginTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginTop-double-) en [ICell.setMarginBottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginBottom-double-) voegen verticale ruimte toe. [ICell.setMarginLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginLeft-double-) en [ICell.setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setMarginRight-double-) verkleinen de breedte die beschikbaar is voor tekst en kunnen extra omloop veroorzaken.

Voor deze tabel zonder samengevoegde cellen bepaalt de cel die de meeste verticale ruimte nodig heeft de inhoud‑gedreven ondergrens voor de hele rij. Om de rij korter te maken, moet je mogelijk de tekst inkorten, de lettergrootte of marges verkleinen, of een kolom breder maken.

De afbeeldingen hieronder tonen dezelfde tabel op dezelfde schaal. In de geïllustreerde resultaten waren de werkelijke hoogtes 70, 100 en 55,2 punten: de laatste rij bleef hoger dan het minimum van 20 punten. Exacte tekstmetingen kunnen verschillen afhankelijk van de letters die in jouw omgeving beschikbaar zijn. Download de opgeslagen resultaten: [verhoogd minimum](row-height-increased.pptx) en [verlaagd minimum](row-height-decreased.pptx).

| Origineel: minimum 70 pt, werkelijke 70 pt | Verhoogd: minimum 100 pt, werkelijke 100 pt | Verlaagd: minimum 20 pt, werkelijke 55,2 pt |
| --- | --- | --- |
| ![Originele tabel met een eerste rij van 70 punten.](row-height-before.png) | ![Tabel na het verhogen van het minimum van de eerste rij naar 100 punten.](row-height-increased.png) | ![Tabel na het verlagen van het minimum van de eerste rij naar 20 punten; omloop van tekst houdt de rij hoger dan het minimum.](row-height-decreased.png) |

## **Stel de eerste rij in als kop**

Gebruik de [setFirstRow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setFirstRow-boolean-)‑methode om de eerste rij te markeren voor header‑opmaak. Het uiterlijk hangt af van de tabel‑stijl die op de tabel is toegepast.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
2. Toegang tot de eerste dia.
3. Toegang tot de tabel die als eerste vorm op de dia is opgeslagen.
4. Schakel header‑opmaak in voor de eerste rij.
5. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als de eerste vorm op de eerste dia. Het schakelt header‑opmaak in voor de eerste rij en slaat `First_row_header.pptx` op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);
    table.setFirstRow(true);

    presentation.save("First_row_header.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kloon een tabelrij of -kolom**

Kloon rijen of kolommen om hun inhoud en opmaak opnieuw te gebruiken. Je kunt een kopie aan het einde van de tabel toevoegen of op een specifieke positie invoegen.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) method.
5. Kloon de benodigde rijen.
6. Kloon de benodigde kolommen.
7. Sla de aangepaste presentatie op.

Het voorbeeld vereist `Test.pptx` met ten minste één dia. Het maakt een tabel met drie kolommen en vijf rijen, met afmetingen opgegeven in punten. Het voegt kopieën van de eerste rij en kolom toe, en voegt vervolgens kopieën van de tweede rij en kolom in op index 3 (de vierde positie). De resulterende tabel heeft zeven rijen en vijf kolommen. Het argument `false` schakelt klonen in aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 50, 50, 50 };
    double[] rowHeights = new double[] { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(0, 0).getTextFrame().setText("Row 1 Cell 1");
    table.get_Item(1, 0).getTextFrame().setText("Row 1 Cell 2");
    table.getRows().addClone(table.getRows().get_Item(0), false);

    table.get_Item(0, 1).getTextFrame().setText("Row 2 Cell 1");
    table.get_Item(1, 1).getTextFrame().setText("Row 2 Cell 2");
    table.getRows().insertClone(3, table.getRows().get_Item(1), false);

    table.getColumns().addClone(table.getColumns().get_Item(0), false);
    table.getColumns().insertClone(3, table.getColumns().get_Item(1), false);

    presentation.save("table_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verwijder een rij of kolom uit een tabel**

Verwijder rijen of kolommen die niet meer nodig zijn in een tabel. Het verwijderen van een item verschuift de indexen van de rijen of kolommen die erop volgen.

1. Maak een presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
2. Toegang tot de eerste dia.
3. Definieer de kolombreedtes en rijhoogtes.
4. Voeg een tabel toe met de [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) method.
5. Verwijder de tweede rij en tweede kolom.
6. Sla de aangepaste presentatie op.

Dit voorbeeld maakt een drie‑bij‑drie tabel en verwijdert de rij en kolom op index 1, waardoor een twee‑bij‑twee tabel overblijft in `TestTable_out.pptx`. De afmetingen staan in punten. Het argument `false` schakelt het verwijderen van aangrenzende samengevoegde rijen of kolommen uit; deze tabel heeft geen samengevoegde cellen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 50, 30 };
    double[] rowHeights = new double[] { 30, 50, 30 };
    ITable table = slide.getShapes().addTable(100, 100, columnWidths, rowHeights);

    table.getRows().removeAt(1, false);
    table.getColumns().removeAt(1, false);

    presentation.save("TestTable_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekstopmaak instellen op rijniveau van de tabel**

Pas tekstopmaak toe op een volledige rij om de cellen consistent te houden. Je kunt lettertype‑eigenschappen, alinea‑opmaak en tekst‑richting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
2. Toegang tot de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) voor de eerste rij.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) voor de eerste rij.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) voor de tweede rij.
6. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als de eerste vorm op de eerste dia en ten minste twee rijen. Het past 25‑punt tekst, rechtsuitlijning en een 20‑punt rechter alinea‑marge toe op de eerste rij, en stelt daarna verticale tekst in op de tweede rij.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getRows().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getRows().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getRows().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("row_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekstopmaak instellen op kolomniveau van de tabel**

Pas tekstopmaak toe op een volledige kolom om de cellen consistent te houden. Je kunt lettertype‑eigenschappen, alinea‑opmaak en tekst‑richting instellen zonder elke cel afzonderlijk te formatteren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) class.
2. Toegang tot de tabel op de eerste dia.
3. Gebruik [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) voor de eerste kolom.
4. Gebruik [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-) voor de eerste kolom.
5. Gebruik [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-) voor de tweede kolom.
6. Sla de aangepaste presentatie op.

Het voorbeeld vereist `table.pptx` met een tabel als de eerste vorm op de eerste dia en ten minste twee kolommen. Het past 25‑punt tekst, rechtsuitlijning en een 20‑punt rechter alinea‑marge toe op de eerste kolom, en stelt daarna verticale tekst in op de tweede kolom.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable)slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.getColumns().get_Item(0).setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.getColumns().get_Item(0).setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.getColumns().get_Item(1).setTextFormat(textFrameFormat);

    presentation.save("column_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabelstijl‑eigenschappen ophalen**

Gebruik de [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--)‑methode om de preset die op een tabel is toegepast op te halen en opnieuw te gebruiken op een andere tabel. Dit identificeert de preset in plaats van individuele cel‑opmaak‑overschrijvingen.

Het voorbeeld maakt een tabel, past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/#DarkStyle1) toe, en leest de preset terug. Het print de gehele getalwaarde die overeenkomt met `DarkStyle1` en slaat de tabel op in `table.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = new double[] { 100, 150 };
    double[] rowHeights = new double[] { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println(stylePreset);

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik PowerPoint‑thema’s/stijlen toepassen op een tabel die al is gemaakt?**

Ja. De tabel erft het thema van de dia/lay‑out/master, en je kunt nog steeds vullingen, randen en tekstkleuren bovenop dat thema overschrijven.

**Kan ik tabelrijen sorteren zoals in Excel?**

Nee, Aspose.Slides‑tabellen hebben geen ingebouwde sortering of filters. Sorteer je gegevens eerst in het geheugen, en vul daarna de tabelrijen opnieuw in die volgorde.

**Kan ik geribbelde (gestreepte) kolommen hebben en tegelijkertijd aangepaste kleuren op specifieke cellen behouden?**

Ja. Schakel geribbelde kolommen in, en overschrijf vervolgens specifieke cellen met lokale opmaak; opmaak op celniveau heeft voorrang boven de tabel‑stijl.