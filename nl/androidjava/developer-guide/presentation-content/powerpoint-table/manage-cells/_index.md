---
title: Beheer tabelcellen in presentaties op Android
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/androidjava/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer PowerPoint‑tabelcellen op Android: identificeer samengevoegde cellen, verwijder randen, splits cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor Android via Java."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen, en een afbeelding binnen een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia krijgt, celopmaak bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

Aspose.Slides gebruikt nulgebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Identificeer een samengevoegde tabelcel**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een tabel is. Vervolgens doorloopt het alle rijen en kolommen en gebruikt [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) om cellen in samengevoegde gebieden te identificeren. Voor elke overeenkomst wordt de celcoördinaat in volgorde `row;column` afgedrukt, [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--), en de begencoördinaten van het gebied, [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) en [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation_with_table.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    int rowCount = table.getRows().size();
    for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
    {
        int columnCount = table.getColumns().size();
        for (int columnIndex = 0; columnIndex < columnCount; columnIndex++)
        {
            ICell cell = table.get_Item(columnIndex, rowIndex);
            if (cell.isMergedCell())
            {
                System.out.printf("Cell %d;%d belongs to a merged region with RowSpan=%d and ColSpan=%d starting at %d;%d.%n", rowIndex, columnIndex, cell.getRowSpan(), cell.getColSpan(), cell.getFirstRowIndex(), cell.getFirstColumnIndex());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Verwijder tabelcelranden**

Maak een [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) en voeg een tabel toe aan de eerste dia met [addTable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). De kolombreedtes, rijhoogtes en de tabelpositie worden opgegeven in punten. Het voorbeeld stelt alle vier cellranden in op [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/), waardoor ze onzichtbaar worden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 50, 50, 50, 50 };
    double[] rowHeights = { 50, 30, 30, 30, 30 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    for (IRow row : table.getRows())
        for (ICell cell : row)
        {
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill);
        }

    presentation.save("table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diagonale celranden toevoegen**

Gebruik [getBorderDiagonalDown](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalDown--) om een lijn te tekenen van de boven‑linkerhoek naar de onder‑rechter hoek, en [getBorderDiagonalUp](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icellformat/#getBorderDiagonalUp--) om een lijn te tekenen van de onder‑linkerhoek naar de boven‑rechter hoek. Een diagonale lijn kan een koptekst in een hoek markeren; beide diagonalen kunnen een X vormen om een cel als niet‑toepasbaar aan te geven.

Elke diagonale is een [ILineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/). In de [getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getFillFormat--) ervan, gebruik [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) om [FillType.Solid](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) te selecteren en kies een kleur via [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--). Stel de lijndikte in punten in met [setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-).

Het voorbeeld maakt drie cellen in één rij: een rode neerwaartse diagonale, een blauwe opwaartse diagonale, en beide diagonalen. Het laat de boven‑, onder‑, linkse en rechtse celranden ongewijzigd.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 210, 210, 210 };
    double[] rowHeights = { 160 };
    ITable table = slide.getShapes().addTable(45, 130, columnWidths, rowHeights);

    ILineFormat downwardBorder = table.get_Item(0, 0).getCellFormat().getBorderDiagonalDown();
    downwardBorder.getFillFormat().setFillType(FillType.Solid);
    downwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    downwardBorder.setWidth(3);

    ILineFormat upwardBorder = table.get_Item(1, 0).getCellFormat().getBorderDiagonalUp();
    upwardBorder.getFillFormat().setFillType(FillType.Solid);
    upwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    upwardBorder.setWidth(5);

    ILineFormat crossDownwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalDown();
    crossDownwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossDownwardBorder.getFillFormat().getSolidFillColor().setColor(Color.RED);
    crossDownwardBorder.setWidth(3);

    ILineFormat crossUpwardBorder = table.get_Item(2, 0).getCellFormat().getBorderDiagonalUp();
    crossUpwardBorder.getFillFormat().setFillType(FillType.Solid);
    crossUpwardBorder.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    crossUpwardBorder.setWidth(5);

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Een diagonale is een opmaak‑eigenschap, geen cel‑split. Elke cel behoudt één tekstframe, bereikbaar via [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--); de gebieden aan beide kanten van een diagonale kunnen niet onafhankelijk worden bewerkt.

De opgeslagen tabel, gerenderd in Microsoft PowerPoint:

![Drie tabelcellen met een rode diagonale van boven‑links naar beneden‑rechts, een blauwe diagonale van onder‑links naar boven‑rechts, en beide diagonalen vormden een X.](diagonal-cell-borders.png)

*Van links naar rechts: neerwaartse diagonale (rood, 3 pt), opwaartse diagonale (blauw, 5 pt), en beide diagonalen.*

## **Tabelcellen samenvoegen**

Gebruik [mergeCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Geef de cellen op in de boven‑linker- en onder‑rechter hoek van het bereik. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik kan omvatten; `false` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4‑tabel met kolommen en rijen van 70 punten, en voegt vervolgens de vier centrale cellen van `(1, 1)` tot en met `(2, 2)` samen. De resulterende cel bestrijkt twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruik de boven‑linker positie: `table.get_Item(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, dus de indexen van cellen buiten het bereik veranderen niet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), false);

    presentation.save("merged_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tabelcellen splitsen**

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van de cellen rechts ervan wijzigen. Aspose.Slides volgt het tabelrastermodel van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4‑tabel met kolommen en rijen van 70 punten en roept [splitByWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByWidth-double-) aan op cel `(1, 1)`. De helft van de breedte van 70 punten van de cel wordt gebruikt om twee even brede cellen te maken.

Na deze splitsing worden de twee helften benaderd als `table.get_Item(1, 1)` en `table.get_Item(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verschuiven naar kolommen 3 en 4, respectievelijk. Rij‑indexen blijven ongewijzigd. Gebruik deze aangepaste kolomindexen bij het benaderen van cellen na de splitsing.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 70, 70, 70, 70 };
    double[] rowHeights = { 70, 70, 70, 70 };
    ITable table = slide.getShapes().addTable(100, 50, columnWidths, rowHeights);

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2);

    presentation.save("split_cells.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

<!-- visual-explanation:manage-cells:start -->
[![An unmerged 70-point cell splits into two 35-point cells, adding a fifth grid column and shifting the indices to its right.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*De breedtesplitsing beïnvloedt cel (1, 1), met nulgebaseerde (column, row)‑indexen. Andere rijen behouden een cel die beide nieuwe kolomposities beslaat.*
<!-- visual-explanation:manage-cells:end -->

### **Gesplitste samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensvulling gereed te maken, gebruik [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) om langs een bestaande rijgrens te splitsen, of [splitByColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByColSpan-int-) om langs een kolomgrens te splitsen.

Het `index`‑argument telt rijen in het bovenste deel of kolommen in het linker deel van de splitsing; het is relatief ten opzichte van het samengevoegde gebied:

- Rij‑splitsing: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getRowSpan--).
- Kolom‑splitsing: `0 < index <` [getColSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getColSpan--).

Het voorbeeld gaat ervan uit dat een presentatie een tabel heeft als de eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Beginnend vanaf de lagere positie, gebruikt het [getFirstColumnIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstColumnIndex--) en [getFirstRowIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getFirstRowIndex--) om de oorsprong te vinden en controleert beide spans. `splitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale twee‑kolom‑samenvoeging, gebruik in plaats daarvan `splitByColSpan(1)`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("table_template.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);

    ICell selectedCell = table.get_Item(1, 3);
    int firstColumnIndex = selectedCell.getFirstColumnIndex();
    int firstRowIndex = selectedCell.getFirstRowIndex();
    ICell mergedCell = table.get_Item(firstColumnIndex, firstRowIndex);

    if (mergedCell.isMergedCell() && mergedCell.getRowSpan() == 2 && mergedCell.getColSpan() == 1)
    {
        mergedCell.splitByRowSpan(1);

        // Haal de resulterende cellen uit de tabel op na het splitsen.
        ICell upperCell = table.get_Item(firstColumnIndex, firstRowIndex);
        ICell lowerCell = table.get_Item(firstColumnIndex, firstRowIndex + 1);
        System.out.println("Upper cell merged: " + upperCell.isMergedCell());
        System.out.println("Lower cell merged: " + lowerCell.isMergedCell());

        upperCell.getTextFrame().setText("Product A");
        lowerCell.getTextFrame().setText("Product B");

        presentation.save("split_template.pptx", SaveFormat.Pptx);
    }
    else
    {
        System.out.println("Select a merged region spanning exactly two rows and one column.");
    }
} finally {
    presentation.dispose();
}
```

Het tabelraster en de omliggende cel‑indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [isMergedCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#isMergedCell--) geeft `false`. Grotere gebieden kunnen na één splitsing deels samengevoegd blijven.

De originele tekst en opmaak blijven behouden in de boven‑ (of linker) cel; de nieuwe cel is leeg maar erft de celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen in en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat aparte "Product A"‑ en "Product B"‑cellen met de sjabloon‑celopmaak behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cell/) voor details.

### **Een cel splitsen op een specifieke hoogte**

[splitByHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByHeight-double-) neemt de hoogte van het bovenste gedeelte in punten. [splitByRowSpan](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#splitByRowSpan-int-) neemt het aantal bestaande rasterrijen in het bovenste gedeelte. Om een 40‑punt cel te centreren in de rechterkolom, trek 40 af van de feitelijke hoogte van de cel en verdeel de resterende ruimte gelijkmatig boven en onder.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 160, 160 };
    double[] rowHeights = { 140 };

    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);
    table.get_Item(0, 0).getTextFrame().setText("Left");

    double height = table.get_Item(1, 0).getHeight();
    double margin = (height - 40) / 2;

    table.get_Item(1, 0).splitByHeight(margin);
    table.get_Item(1, 1).splitByHeight(40);
    table.get_Item(1, 1).getTextFrame().setText("Middle");

    presentation.save("split_by_height.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De eerste splitsing voegt een rasterrij toe en laat 90 punten onderin cel `(1, 1)` achter. De tweede splitsing verdeelt die cel in een middelste cel van 40 punten en een onderste cel van 50 punten. De rechterkolom heeft nu drie cellen met hoogtes van 50, 40 en 50 punten van boven naar beneden. De linkercel beslaat alle drie de rijen en behoudt haar oorspronkelijke hoogte van 140 punten.

![De linkercel beslaat de volledige tabelhoogte naast drie cellen met Midden in het centrum.](split-by-height.png)

## **De achtergrondkleur van de tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 punten en rijen van 50 punten. Het gebruikt [setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) om een effen vulling te selecteren en stelt de kleur die door [getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--) wordt geretourneerd in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 50, 50, 50, 50, 50 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    ICell cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid);
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een afbeelding in een tabelcel toevoegen**

Plaats de invoerafbeelding in de werkomgeving voordat u dit voorbeeld uitvoert. Het laadt de afbeelding met [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) en voegt deze toe aan de afbeeldingscollectie van de presentatie met [addImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Vervolgens wijst het de afbeelding toe aan de picture‑fill van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/) strekt de afbeelding uit om de cel te vullen, wat de beeldverhouding kan wijzigen. Kolombreedtes en rijhoogtes zijn in punten. De geladen afbeelding wordt verwijderd in een `finally`‑blok nadat deze aan de presentatie is toegevoegd.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    double[] columnWidths = { 150, 150, 150, 150 };
    double[] rowHeights = { 100, 100, 100, 100, 90 };
    ITable table = slide.getShapes().addTable(50, 50, columnWidths, rowHeights);

    IPPImage ppImage;
    IImage image = Images.fromFile("aspose_logo.jpg");
    try {
        ppImage = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderTop--)/[bottom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderBottom--)/[left](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderLeft--)/[right](https://reference.aspose.com/slides/androidjava/com.aspose.slides/cellformat/#getBorderRight--) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillmode/). Bij stretch wordt de afbeelding aangepast aan de nieuwe cel; bij tile worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/androidjava/manage-hyperlinks/) worden ingesteld op tekst‑ (portion‑) niveau binnen het tekstframe van de cel of op het niveau van de hele tabel/vorm. In de praktijk wijst u de link toe aan een portion of aan alle tekst in de cel.

**Kan ik verschillende lettertypen binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) (runs) met onafhankelijke opmaak — lettertypefamilie, stijl, grootte en kleur.