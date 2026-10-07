---
title: Beheer tabelcellen in presentaties met Java
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/java/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Beheer PowerPoint-tabelcellen in Java: identificeer samengevoegde cellen, verwijder randen, split cellen, en stel achtergrondkleuren en afbeeldingen in met Aspose.Slides voor Java."
---
## **Overzicht**

Aspose.Slides stelt u in staat om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, met celnummering kunt werken na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen en een afbeelding in een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie kunt maken of openen, een tabel van een dia kunt krijgen, celopmaak via cel‑eigenschappen kunt bijwerken en de aangepaste presentatie kunt opslaan als PPTX‑bestand.

Aspose.Slides gebruikt nul‑gebaseerde indexen om tabelcellen te benaderen in de volgorde `(column, row)`.

## **Een samengevoegde tabelcel identificeren**

Het voorbeeld opent een bestaande presentatie en benadert de eerste vorm op de eerste dia als een tabel. Er wordt aangenomen dat de dia en de vorm bestaan en dat de vorm een tabel is. Vervolgens wordt door alle rijen en kolommen gelopen en wordt [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) gebruikt om cellen in samengevoegde gebieden te identificeren. Voor elke overeenkomst wordt de celcoördinaat in `row;column`‑volgorde afgedrukt, evenals [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--), [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--) en de startcoördinaten van het gebied, [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) en [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--).

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

## **Randen van tabelcellen verwijderen**

Maak een [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) aan en voeg een tabel toe aan de eerste dia met [addTable](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addTable-float-float-double---double---). De kolombreedtes, rijhoogtes en de positie van de tabel worden gespecificeerd in points. Het voorbeeld stelt alle vier de celranden in op [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/), waardoor ze onzichtbaar worden.

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

## **Tabelcellen samenvoegen**

Gebruik [mergeCells](https://reference.aspose.com/slides/java/com.aspose.slides/itable/#mergeCells-com.aspose.slides.ICell-com.aspose.slides.ICell-boolean-) om een rechthoekig bereik van tabelcellen te combineren tot één cel. Geef de cellen op in de linkerboven‑ en rechteronderhoek van het bereik. Het laatste argument bepaalt of de samenvoeging cellen buiten het opgegeven bereik mag omvatten; `false` houdt de samenvoeging binnen dat bereik.

Het voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 points, en voegt vervolgens de vier centrale cellen samen van `(1, 1)` tot `(2, 2)`. De resulterende cel beslaat twee kolommen en twee rijen, terwijl het onderliggende raster van de tabel vier kolommen en vier rijen behoudt. Om de inhoud of opmaak van de samengevoegde cel te benaderen, gebruik je de positie linkerboven: `table.get_Item(1, 1)` in dit voorbeeld. De andere posities in het samengevoegde bereik blijven deel uitmaken van het tabelraster, zodat de indexen van cellen buiten het bereik niet veranderen.

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

Het samenvoegen van cellen in het vorige voorbeeld behoudt het raster van de tabel. Het splitsen van een cel kan een nieuwe rasterkolom introduceren en de kolomindexen van de cellen rechts ervan wijzigen. Aspose.Slides volgt het rastermodel voor tabellen van PowerPoint.

Dit voorbeeld maakt een 4‑bij‑4 tabel met kolommen en rijen van 70 points en roept [splitByWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByWidth-double-) aan op cel `(1, 1)`. De helft van de 70‑point breedte van de cel wordt doorgegeven om twee even brede cellen te maken.

Nadat deze splitsing is uitgevoerd, worden de twee helften benaderd als `table.get_Item(1, 1)` en `table.get_Item(2, 1)`. Het tabelraster heeft nu vijf kolommen: cellen die oorspronkelijk in kolommen 2 en 3 stonden, verplaatsen zich naar respectievelijk kolommen 3 en 4. De rij‑indexen blijven ongewijzigd. Gebruik deze bijgewerkte kolomindexen bij het benaderen van cellen na de splitsing.

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

### **Samengevoegde cellen splitsen op rij‑ of kolom‑span**

Om samengevoegde sjablooncellen voor gegevensvulling voor te bereiden, gebruik je [splitByRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByRowSpan-int-) om langs een bestaande rij‑grens te splitsen, of [splitByColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#splitByColSpan-int-) om langs een kolom‑grens te splitsen.

Het argument `index` telt rijen in het bovenste deel of kolommen in het linkerdeel van de splitsing; het is relatief ten opzichte van het samengevoegde gebied:

- Rij‑splitsing: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getRowSpan--).
- Kolom‑splitsing: `0 < index <` [getColSpan](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getColSpan--).

Het voorbeeld gaat ervan uit dat een presentatie een tabel heeft als de eerste vorm op de eerste dia, met `(1, 2)` en `(1, 3)` verticaal samengevoegd. Beginnend vanaf de onderste positie gebruikt het [getFirstColumnIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstColumnIndex--) en [getFirstRowIndex](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getFirstRowIndex--) om de oorsprong te lokaliseren en controleert beide spans. `splitByRowSpan(1)` scheidt vervolgens rijen 2 en 3 voor productnamen. Voor een horizontale samenvoeging van twee kolommen, gebruik `splitByColSpan(1)`.

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

Het tabelraster en de omringende cel‑indexen blijven ongewijzigd. Haal de resulterende cellen op via hun coördinaten; hier hebben beide een span van 1 en [isMergedCell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#isMergedCell--) geeft `false` terug. Grotere gebieden kunnen deels samengevoegd blijven na één splitsing.

De oorspronkelijke tekst en opmaak blijven in de bovenste (of linker) cel; de nieuwe cel is leeg maar erft de celopmaak zoals vulling, randen en marges. Vul de cellen na het splitsen en stel eventuele vereiste tekstopmaak expliciet in.

De opgeslagen presentatie bevat afzonderlijke “Product A”- en “Product B”-cellen met de cellopmaak van het sjabloon behouden. Zie de [Cell API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/cell/) voor details.

## **De achtergrondkleur van de tabelcel wijzigen**

Dit voorbeeld maakt een tabel met kolommen van 150 points en rijen van 50 points. Het gebruikt [setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) om een effen vulling te selecteren en stelt de kleur die door [getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--) wordt geretourneerd in op rood voor cel `(2, 3)`, in de derde kolom en vierde rij.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Plaats de invoerafbeelding in de werkdirectory voordat u dit voorbeeld uitvoert. Het laad de afbeelding met [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) en voegt deze toe aan de afbeeldingscollectie van de presentatie met [addImage](https://reference.aspose.com/slides/java/com.aspose.slides/iimagecollection/#addImage-com.aspose.slides.IImage-). Vervolgens wordt de afbeelding toegewezen aan de picture‑fill van cel `(0, 0)`, de eerste cel in de tabel.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) strekt de afbeelding uit om de cel te vullen, wat de beeldverhouding kan wijzigen. Kolombreedtes en rijhoogtes zijn in points. De geladen afbeelding wordt in een `finally`‑blok verwijderd nadat deze aan de presentatie is toegevoegd.

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

Ja. De [boven](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderTop--)/[onder](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderBottom--)/[links](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderLeft--)/[rechts](https://reference.aspose.com/slides/java/com.aspose.slides/cellformat/#getBorderRight--) randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen.

**Wat gebeurt er met de afbeelding als ik de kolom‑/rij‑grootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [vullingsmodus](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillmode/) (stretch/tile). Bij stretching past de afbeelding zich aan de nieuwe cel aan; bij tiling worden de tegels opnieuw berekend.

**Kan ik een hyperlink toewijzen aan alle inhoud van een cel?**

[Hyperlinks](/slides/nl/java/manage-hyperlinks/) worden ingesteld op tekst‑ (gedeelte) niveau binnen het tekstframe van de cel of op het niveau van de hele tabel/vorm. In de praktijk wijs je de link toe aan een gedeelte of aan alle tekst in de cel.

**Kan ik verschillende lettertypen instellen binnen één cel?**

Ja. Het tekstframe van een cel ondersteunt [gedeelten](https://reference.aspose.com/slides/java/com.aspose.slides/portion/) (runs) met onafhankelijke opmaak—lettertypefamilie, stijl, grootte en kleur.