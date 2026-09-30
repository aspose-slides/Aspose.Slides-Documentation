---
title: Beheer presentatietabellen in Java
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/java/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- tabel benaderen
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor Java. Ontdek eenvoudige code-voorbeelden om uw tabelwerkstroom te vereenvoudigen."
---
## **Inleiding**

Tabellen in PowerPoint organiseren informatie in rijen en kolommen, waardoor het makkelijker is om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/java/com.aspose.slides/table/) klasse, [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) klasse, [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) interface, en andere types om tabellen in presentaties te maken, bij te werken en te beheren.

## **Maak een tabel vanaf nul**

Maak een tabel door zijn positie, kolombreedtes en rijhoogtes op te geven. Na toevoegen aan een dia kunt u celranden opmaken, cellen samenvoegen en tekst invoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia via de index.
3. Definieer een array met kolombreedtes in punten.
4. Definieer een array met rijhoogtes in punten.
5. Voeg een [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) methode.
6. Iterate door elke [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) om opmaak toe te passen op de boven-, onder-, recht- en linker randen.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Toegang tot de samengevoegde cel via zijn [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) methode.
9. Stel de tekst in de samengevoegde cel in.
10. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder maakt een tabel met drie kolommen en vijf rijen op (100, 50) punten. Het past rode randen toe met een breedte van 5 punten, voegt de eerste twee cellen in de eerste rij samen, en slaat het resultaat op als `table.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 0), false);
    table.get_Item(0, 0).getTextFrame().setText("Merged Cells");

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nummering in een standaardtabel**

In een standaardtabel zijn celindexen nulgebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft index (0, 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de bovenstaande 4 × 4 tabel, met kolombreedtes en rijhoogtes van 70 punten en rode celranden met een breedte van 5 punten. De coördinaten illustreren celindexen; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
    {
        for (ICell cell : row)
        {
            ICellFormat cellFormat = cell.getCellFormat();
            cellFormat.getBorderTop().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderTop().setWidth(5);

            cellFormat.getBorderBottom().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderBottom().setWidth(5);

            cellFormat.getBorderLeft().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderLeft().setWidth(5);

            cellFormat.getBorderRight().getFillFormat().setFillType(FillType.Solid);
            cellFormat.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED);
            cellFormat.getBorderRight().setWidth(5);
        }
    }

    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Toegang tot een bestaande tabel**

Tabellen worden opgeslagen in de vormverzameling van een dia. Itereer door de vormen om een tabel te vinden, gebruik vervolgens de [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) interface om zijn cellen te lezen of bij te werken.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia die de tabel bevat via de index.
3. Iterate door de [IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) objecten en stop wanneer een tabel wordt gevonden. Als de dia meerdere tabellen bevat, gebruik dan [getAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getAlternativeText--) om de gewenste te identificeren.
4. Werk de tekst in de doelcel bij.
5. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel in kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet ten minste één dia bevatten, en de eerste tabel op die dia moet ten minste één kolom en twee rijen hebben.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("UpdateExistingTable.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = null;

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof ITable) {
            table = (ITable) shape;
            break;
        }
    }

    if (table != null) {
        table.get_Item(0, 1).getTextFrame().setText("New");
        presentation.save("table1_out.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Om een rij in een bestaande tabel te herschalen en te begrijpen waarom de werkelijke hoogte de gevraagde minimum kan overschrijden, zie [Rijhoogte regelen](/slides/nl/java/manage-rows-and-columns/#control-row-height).

## **Zoek de cel die een tekstkader bezit**

Wanneer generieke tekstverwerkingscode een [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) van een tabel ontvangt, gebruik dan de [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) methode om de eigenaar [ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) op te halen. Voor een tekstkader van een tabelcel retourneert [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) de eigenaar en retourneert [ITextFrame.getParentShape](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentShape--) `null`, hoewel de tabel zelf een vorm is.

De celcoördinaten zijn beschikbaar via de alleen‑lezen [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) en [ICell.getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) methoden. [ITextFrame.getParentCell](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getParentCell--) biedt ook alleen‑lezen navigatie: het retourneert de eigenaar maar verandert de eigendom niet. Controleer altijd of de geretourneerde cel `null` is voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabelcel‑ en vorm‑eigenaars identificeert, inclusief vormen die gekoppeld zijn aan SmartArt‑knopen, zie [Zoeken en vervangen van tekst](/slides/nl/java/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

U kunt de verticale verankering en tekstrichting van individuele tabelcellen regelen. Het voorbeeld in deze sectie centreert tekst binnen de eerste cel en roteert deze met 270 graden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia via de index.
3. Voeg een [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) object toe aan de dia.
4. Toegang tot een [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) object van de tabel.
5. Toegang tot de eerste [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) en stel de tekst en kleur in.
6. Stel de verticale verankering en tekstrichting van de cel in met [setTextAnchorType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextAnchorType-byte-) en [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een 4 × 4 tabel met kolombreedtes van 120 punten en rijhoogtes van 100 punten. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de overige cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 120, 120, 120, 120 };
    double[] rowHeights = { 100, 100, 100, 100 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 0).getTextFrame().setText("10");
    table.get_Item(2, 0).getTextFrame().setText("20");
    table.get_Item(3, 0).getTextFrame().setText("30");

    ITextFrame textFrame = table.get_Item(0, 0).getTextFrame();
    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);

    IPortion portion = paragraph.getPortions().get_Item(0);
    portion.setText("Text here");
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ICell cell = table.get_Item(0, 0);
    cell.setTextAnchorType(TextAnchorType.Center);
    cell.setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tekstopmaak instellen op tabelniveau**

Gebruik [setTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren gedeelte‑, alinea‑ en tekstkader‑opmaak, zodat u deze eigenschappen kunt instellen zonder te itereren door individuele cellen.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia via de index.
3. Toegang tot een [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) object van de dia.
4. Stel de lettergrootte in met [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) voor de tekst.
5. Stel alinea‑uitlijning en de rechter marge in met [setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Stel de tekstrichting in met [setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `table.pptx`, die ten minste één dia moet bevatten met een tabel als eerste vorm. Het stelt de lettergrootte in op 25 punten, uitlijnt alinea's rechts met een rechter marge van 20 punten, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(25);
    table.setTextFormat(portionFormat);

    ParagraphFormat paragraphFormat = new ParagraphFormat();
    paragraphFormat.setAlignment(TextAlignment.Right);
    paragraphFormat.setMarginRight(20);
    table.setTextFormat(paragraphFormat);

    TextFrameFormat textFrameFormat = new TextFrameFormat();
    textFrameFormat.setTextVerticalType(TextVerticalType.Vertical);
    table.setTextFormat(textFrameFormat);

    presentation.save("result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabelstijleigenschappen ophalen**

Gebruik [getStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#getStylePreset--) om de voorgedefinieerde stijl van een tabel te lezen en [setStylePreset](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#setStylePreset-int-) om deze toe te wijzen. Dit voorbeeld past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/java/com.aspose.slides/tablestylepreset/) toe op één tabel, drukt de preset‑waarde af, en wijst dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 100, 150 };
    double[] rowHeights = { 5, 5, 5 };
    ITable table = slide.getShapes().addTable(10, 10, columnWidths, rowHeights);
    table.setStylePreset(TableStylePreset.DarkStyle1);

    int stylePreset = table.getStylePreset();
    System.out.println("Table style preset: " + stylePreset);

    ITable anotherTable = slide.getShapes().addTable(10, 100, columnWidths, rowHeights);
    anotherTable.setStylePreset(stylePreset);

    presentation.save("table-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Verhoudingsvergrendeling van een tabel**

De beeldverhouding van een tabel is de verhouding tussen breedte en hoogte. Gebruik [setAspectRatioLocked](https://reference.aspose.com/slides/java/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) om deze verhouding voor een tabel te vergrendelen.

Het voorbeeld hieronder opent `pres.pptx`, die ten minste één dia moet bevatten met een tabel als eerste vorm. Het drukt de huidige vergrendelingsstatus af, schakelt de vergrendeling van de beeldverhouding in, drukt de bijgewerkte status (`true`) af, en slaat het resultaat op als `pres-out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ITable table = (ITable) slide.getShapes().get_Item(0);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    table.getGraphicalObjectLock().setAspectRatioLocked(true);
    System.out.println("Lock aspect ratio set: " + table.getGraphicalObjectLock().getAspectRatioLocked());

    presentation.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik de leesrichting van rechts naar links (RTL) inschakelen voor een hele tabel en de tekst in de cellen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/table/#setRightToLeft-boolean-) methode, en alinea's hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Het gebruik van beide zorgt voor de juiste RTL‑volgorde en weergave binnen cellen.

**Hoe kan ik voorkomen dat gebruikers een tabel verplaatsen of de grootte wijzigen in het uiteindelijke bestand?**

Gebruik [vormvergrendelingen](/slides/nl/java/applying-protection-to-presentation/) om verplaatsen, schalen, selecteren, enz. uit te schakelen. Deze vergrendelingen zijn ook van toepassing op tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. U kunt een [afbeeldingsopvulling](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) instellen voor een cel; de afbeelding zal het celgebied bedekken volgens de gekozen modus (rekken of tegel).