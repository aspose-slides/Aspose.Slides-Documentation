---
title: Beheer presentatietabellen op Android
linktitle: Beheer tabel
type: docs
weight: 10
url: /nl/androidjava/manage-table/
keywords:
- tabel toevoegen
- tabel maken
- toegang tot tabel
- beeldverhouding
- tekst uitlijnen
- tekstopmaak
- tabelstijl
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Maak & bewerk tabellen in PowerPoint-dia's met Aspose.Slides voor Android. Ontdek eenvoudige Java-codevoorbeelden om uw tabelworkflows te stroomlijnen."
---
## **Inleiding**

Tabellen in PowerPoint organiseren informatie in rijen en kolommen, waardoor het gemakkelijker wordt om waarden te lezen en te vergelijken.

Aspose.Slides biedt de [Table](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/) klasse, [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interface, [Cell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) klasse, [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) interface en andere typen om tabellen in presentaties te maken, bij te werken en te beheren.

## **Een tabel maken vanaf nul**

Maak een tabel door de positie, kolombreedtes en rijhoogtes op te geven. Nadat u de tabel aan een dia hebt toegevoegd, kunt u celranden opmaken, cellen samenvoegen en tekst invoegen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia op basis van de index.
3. Definieer een array met kolombreedtes in points.
4. Definieer een array met rijhoogtes in points.
5. Voeg een [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) object toe aan de dia via de [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---) methode.
6. Loop door elke [ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) om opmaak toe te passen op de boven-, onder-, rechter- en linkerrand.
7. Voeg de eerste twee cellen van de eerste rij van de tabel samen.
8. Benader de samengevoegde cel via zijn [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) methode.
9. Stel de tekst in de samengevoegde cel in.
10. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder maakt een tabel met drie kolommen en vijf rijen op (100, 50) points. Het past rode randen toe met een breedte van 5 points, voegt de eerste twee cellen in de eerste rij samen en slaat het resultaat op als `table.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

In een standaardtabel zijn cel‑indices nulgebaseerd en gebruiken ze de volgorde (kolom, rij). De eerste cel heeft index (0, 0).

Bijvoorbeeld, de cellen in een tabel met 4 kolommen en 4 rijen worden op deze manier genummerd:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dit voorbeeld maakt de hierboven geïllustreerde 4 × 4 tabel, met kolombreedtes en rijhoogtes van 70 points en rode celranden met een breedte van 5 points. De coördinaten illustreren cel‑indices; het voorbeeld laat de cellen leeg en slaat de tabel op als `StandardTables_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Tabellen worden opgeslagen in de vormverzameling van een dia. Loop door de vormen om een tabel te vinden, en gebruik vervolgens de [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interface om de cellen te lezen of bij te werken.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia die de tabel bevat op basis van de index.
3. Loop door de [IShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) objecten en stop wanneer een tabel wordt gevonden. Als de dia meerdere tabellen bevat, gebruik dan [getAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getAlternativeText--) om degene te identificeren die u nodig hebt.
4. Werk de tekst in de doelcel bij.
5. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `UpdateExistingTable.pptx` en vindt de eerste tabel op de eerste dia. Het stelt de cel in kolom 0, rij 1 in op `New` en slaat het resultaat op als `table1_out.pptx`. De invoer moet minstens één dia bevatten, en de eerste tabel op die dia moet minstens één kolom en twee rijen hebben.

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

Om een rij in een bestaande tabel te wijzigen en te begrijpen waarom de werkelijke hoogte hoger kan zijn dan het opgegeven minimum, zie [Control Row Height](/slides/nl/androidjava/manage-rows-and-columns/#control-row-height).

## **Zoek de cel die een tekstframe bezit**

Wanneer generieke tekstverwerkingscode een [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) van een tabel ontvangt, gebruik dan de [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) methode om de eigenaar‑[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/) op te halen. Voor een tabel‑cel‑tekstframe geeft [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) de eigenaar terug en geeft [ITextFrame.getParentShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentShape--) `null` terug, ook al is de tabel zelf een vorm.

De celcoördinaten zijn beschikbaar via de alleen‑lezen [ICell.getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) en [ICell.getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) methoden. [ITextFrame.getParentCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getParentCell--) biedt ook alleen‑lezen navigatie: het retourneert de eigenaar maar wijzigt de eigendom niet. Controleer altijd of de geretourneerde cel niet `null` is voordat u deze gebruikt.

Voor een volledig voorbeeld dat tabel‑cel‑ en vormeigenaars identificeert, inclusief vormen die bij SmartArt‑knooppunten horen, zie [Search and Replace Text](/slides/nl/androidjava/search-and-replace-text/).

## **Tekst uitlijnen in een tabel**

U kunt de verticale verankering en tekstrichting van individuele tabelcellen regelen. Het voorbeeld in deze sectie centreert de tekst in de eerste cel en draait deze 270 graden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia op basis van de index.
3. Voeg een [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) object toe aan de dia.
4. Benader een [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) object uit de tabel.
5. Benader de eerste [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) en stel de tekst en kleur in.
6. Stel de verticale verankering en tekstrichting van de cel in met [setTextAnchorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextAnchorType-byte-) en [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#setTextVerticalType-byte-).
7. Sla de gewijzigde presentatie op.

Dit voorbeeld maakt een 4 × 4 tabel met kolombreedtes van 120 points en rijhoogtes van 100 points. Het formatteert de tekst in cel (0, 0), voegt waarden toe aan de resterende cellen in de eerste rij, en slaat het resultaat op als `Vertical_Align_Text_out.pptx`.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Gebruik [setTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulktextformattable/#setTextFormat-com.aspose.slides.IPortionFormat-) om tekstopmaak toe te passen op alle cellen in een tabel. De overloads accepteren opmaak voor gedeelte, alinea en tekstframe, zodat u deze eigenschappen kunt instellen zonder door individuele cellen te itereren.

1. Laad de presentatie met de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) klasse.
2. Haal een referentie op naar de dia op basis van de index.
3. Benader een [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) object van de dia.
4. Stel de lettergrootte in met [setFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) voor de tekst.
5. Stel alinea‑uitlijning en de rechter‑marge in met [setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) en [setMarginRight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setMarginRight-float-).
6. Stel de tekstrichting in met [setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframeformat/#setTextVerticalType-byte-).
7. Sla de gewijzigde presentatie op.

Het voorbeeld hieronder opent `table.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het stelt de lettergrootte in op 25 points, rechts‑uitlijnt alinea’s met een rechter‑marge van 20 points, en maakt de tekst verticaal. De opgemaakte presentatie wordt opgeslagen als `result.pptx`.

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

Gebruik [getStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#getStylePreset--) om de vooraf ingestelde stijl van een tabel te lezen en [setStylePreset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#setStylePreset-int-) om deze toe te wijzen. Dit voorbeeld past [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tablestylepreset/) toe op één tabel, print de preset‑waarde, en wijst dezelfde preset toe aan een tweede tabel. Beide tabellen worden opgeslagen in `table-style.pptx`.

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

De beeldverhouding van een tabel is de verhouding tussen breedte en hoogte. Gebruik [setAspectRatioLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/#setAspectRatioLocked-boolean-) om deze verhouding voor een tabel te vergrendelen.

Het voorbeeld hieronder opent `pres.pptx`, die minstens één dia moet bevatten met een tabel als eerste vorm. Het print de huidige vergrendelingsstatus, schakelt de vergrendeling van de beeldverhouding in, print de bijgewerkte status (`true`), en slaat het resultaat op als `pres-out.pptx`.

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

**Kan ik de leesrichting van rechts‑naar‑links (RTL) voor een hele tabel en de tekst in de cellen inschakelen?**

Ja. De tabel biedt een [setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/table/#setRightToLeft-boolean-) methode, en alinea’s hebben [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphformat/#setRightToLeft-byte-). Door beide te gebruiken wordt de juiste RTL‑volgorde en weergave binnen cellen gegarandeerd.

**Hoe kan ik voorkomen dat gebruikers een tabel in het uiteindelijke bestand verplaatsen of de grootte wijzigen?**

Gebruik [shape locks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igraphicalobjectlock/) om verplaatsen, vergroten/verkleinen, selectie, enz. uit te schakelen. Deze vergrendelingen gelden ook voor tabellen.

**Wordt het invoegen van een afbeelding in een cel als achtergrond ondersteund?**

Ja. U kunt een [picture fill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) voor een cel instellen; de afbeelding zal het celgebied bedekken volgens de gekozen modus (uitrekken of tegel).