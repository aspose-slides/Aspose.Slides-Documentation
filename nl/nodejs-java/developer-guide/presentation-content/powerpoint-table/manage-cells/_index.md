---
title: Beheer tabelcellen in presentaties met JavaScript
linktitle: Beheer cellen
type: docs
weight: 30
url: /nl/nodejs-java/manage-cells/
keywords:
- tabelcel
- cellen samenvoegen
- rand verwijderen
- cel splitsen
- afbeelding in cel
- achtergrondkleur
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer tabelcellen in PowerPoint met Aspose.Slides voor Node.js. Beheers het snel benaderen, wijzigen en stylen van cellen voor naadloze dia-automatisering."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om tabelcellen in PowerPoint‑presentaties te benaderen en te wijzigen. Dit artikel legt uit hoe u samengevoegde tabelcellen kunt identificeren, celranden kunt verwijderen, kunt werken met celnummering na het samenvoegen of splitsen van cellen, de achtergrondkleur van een cel kunt wijzigen, en een afbeelding binnen een tabelcel kunt toevoegen. De voorbeelden laten zien hoe u een presentatie maakt of opent, een tabel van een dia krijgt, celopmaak bijwerkt via cel‑eigenschappen, en de gewijzigde presentatie opslaat als een PPTX‑bestand.

## **Samengevoegde Tabelcellen Identificeren**
1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) class.
2. Haal de tabel op van de eerste dia. 
3. Itereer door de rijen en kolommen van de tabel om samengevoegde cellen te vinden.
4. Print een bericht wanneer samengevoegde cellen worden gevonden.

Deze JavaScript‑code laat zien hoe u samengevoegde tabelcellen in een presentatie kunt identificeren:

```javascript
var pres = new aspose.slides.Presentation("SomePresentationWithTable.pptx");
try {
    var table = pres.getSlides().get_Item(0).getShapes().get_Item(0);// ervan uitgaande dat Slide#0.Shape#0 een tabel is
    for (var i = 0; i < table.getRows().size(); i++) {
        for (var j = 0; j < table.getColumns().size(); j++) {
            var currentCell = table.getRows().get_Item(i).get_Item(j);
            if (currentCell.isMergedCell()) {
                console.log(java.callStaticMethodSync("java.lang.String", "format", "Cell %d;%d is a part of merged cell with RowSpan=%d and ColSpan=%d starting from Cell %d;%d.", i, j, currentCell.getRowSpan(), currentCell.getColSpan(), currentCell.getFirstRowIndex(), currentCell.getFirstColumnIndex()));
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Rand van Tabelcellen Verwijderen**
1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) class.
2. Haal een verwijzing naar een dia op via de index. 
3. Definieer een array van kolommen met breedte.
4. Definieer een array van rijen met hoogte.
5. Voeg een tabel toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-)‑methode.
6. Itereer door elke cel om de boven‑, onder‑, rechts‑ en linkerrand te wissen.
7. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Deze JavaScript‑code laat zien hoe u de randen van tabelcellen kunt verwijderen:

```javascript
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [50, 50, 50, 50]);
    var dblRows = java.newArray("double", [50, 30, 30, 30, 30]);
    // Voegt een tabelvorm toe aan de dia
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Stelt het randformaat in voor elke cel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        }
    }
    // Schrijft de PPTX naar schijf
    pres.save("table_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nummering in Samengevoegde Cellen**
Als we twee paren cellen (1, 1) x (2, 1) en (1, 2) x (2, 2) samenvoegen, wordt de resulterende tabel genummerd. Deze JavaScript‑code toont het proces:

```javascript
// Instantieert de Presentation‑klasse die een PPTX‑bestand voorstelt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Voegt een tabelvorm toe aan de dia
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Stelt het randformaat in voor elke cel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Voegt cellen samen (1, 1) x (2, 1)
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Voegt cellen samen (1, 2) x (2, 2)
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Vervolgens voegen we de cellen verder samen door (1, 1) en (1, 2) te combineren. Het resultaat is een tabel met een grote samengevoegde cel in het midden: 

```javascript
// Instancieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Voegt een tabelvorm toe aan de dia
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Stelt het randformaat in voor elke cel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Voegt cellen (1, 1) x (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Voegt cellen (1, 2) x (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Voegt cellen (1, 1) x (1, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(1, 2), true);
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("MergeCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nummering in Gesplitste Cel**
In vorige voorbeelden, toen tabelcellen werden samengevoegd, veranderde de nummering of het nummeringssysteem in andere cellen niet. 

Dit keer nemen we een normale tabel (een tabel zonder samengevoegde cellen) en proberen we cel (1,1) te splitsen om een speciale tabel te krijgen. Let op de nummering van deze tabel, die mogelijk vreemd lijkt. Dat is echter de manier waarop Microsoft PowerPoint tabelcellen nummert en Aspose.Slides doet hetzelfde.

Deze JavaScript‑code toont het beschreven proces:

```javascript
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var sld = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [70, 70, 70, 70]);
    var dblRows = java.newArray("double", [70, 70, 70, 70]);
    // Voegt een tabelvorm toe aan de dia
    var tbl = sld.getShapes().addTable(100, 50, dblCols, dblRows);
    // Stelt het randformaat in voor elke cel
    for (let i = 0; i < tbl.getRows().size(); i++) {
        const row = tbl.getRows().get_Item(i);
        for (let j = 0; j < row.size(); j++) {
            const cell = row.get_Item(j);
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderTop().setWidth(5);
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderBottom().setWidth(5);
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderLeft().setWidth(5);
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
            cell.getCellFormat().getBorderRight().setWidth(5);
        }
    }
    // Voegt cellen (1, 1) x (2, 1) samen
    tbl.mergeCells(tbl.get_Item(1, 1), tbl.get_Item(2, 1), false);
    // Voegt cellen (1, 2) x (2, 2) samen
    tbl.mergeCells(tbl.get_Item(1, 2), tbl.get_Item(2, 2), false);
    // Splits cel (1, 1)
    tbl.get_Item(1, 1).splitByWidth(tbl.get_Item(2, 1).getWidth() / 2);
    // Schrijft het PPTX‑bestand naar schijf
    pres.save("SplitCells_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Achtergrondkleur van Tabelcel Wijzigen**

Deze JavaScript‑code laat zien hoe u de achtergrondkleur van een tabelcel kunt wijzigen:

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [50, 50, 50, 50, 50]);
    // maak een nieuwe tabel
    var table = slide.getShapes().addTable(50, 50, dblCols, dblRows);
    // stel de achtergrondkleur in voor een cel
    var cell = table.get_Item(2, 3);
    cell.getCellFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    presentation.save("cell_background_color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Afbeelding Toevoegen Binnen Tabelcel**

1. Maak een instantie aan van de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation) class.
2. Haal een verwijzing naar een dia op via de index.
3. Definieer een array van kolommen met breedte.
4. Definieer een array van rijen met hoogte.
5. Voeg een tabel toe aan de dia via de [addTable](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/ShapeCollection#addTable-float-float-double:A-double:A-)‑methode.
6. Maak een `Images`‑object aan om het afbeeldingsbestand op te slaan.
7. Voeg de `IImage`‑afbeelding toe aan het `PPImage`‑object.
8. Stel de `FillFormat` van de tabelcel in op `Picture`.
9. Voeg de afbeelding toe aan de eerste cel van de tabel.
10. Sla de gewijzigde presentatie op als een PPTX‑bestand

Deze JavaScript‑code laat zien hoe u een afbeelding binnen een tabelcel kunt plaatsen bij het maken van een tabel:

```javascript
// Instantieert de Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
var pres = new aspose.slides.Presentation();
try {
    // Toegang tot de eerste dia
    var islide = pres.getSlides().get_Item(0);
    // Definieert kolommen met breedtes en rijen met hoogtes
    var dblCols = java.newArray("double", [150, 150, 150, 150]);
    var dblRows = java.newArray("double", [100, 100, 100, 100, 90]);
    // Voegt een tabelvorm toe aan de dia
    var tbl = islide.getShapes().addTable(50, 50, dblCols, dblRows);
    // Maak een PPImage‑object met het afbeeldingbestand
    var picture;
    var image = aspose.slides.Images.fromFile("image.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Voegt de afbeelding toe aan de eerste tabelcel
    var cellFormat = tbl.get_Item(0, 0).getCellFormat();
    cellFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    cellFormat.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
    cellFormat.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);
    // Slaat het PPTX‑bestand op naar schijf
    pres.save("Image_In_TableCell_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Kan ik verschillende lijndiktes en stijlen instellen voor verschillende zijden van één cel?**

Ja. De [top](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellformat/getbordertop/)/[bottom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellformat/getborderbottom/)/[left](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellformat/getborderleft/)/[right](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/cellformat/getborderright/)‑randen hebben afzonderlijke eigenschappen, zodat de dikte en stijl van elke zijde kan verschillen. Dit volgt logisch uit de per‑zijde randcontrole voor een cel die in het artikel wordt aangetoond.

**Wat gebeurt er met de afbeelding als ik de kolom-/rijgrootte wijzig nadat ik een afbeelding als achtergrond van de cel heb ingesteld?**

Het gedrag hangt af van de [fill mode](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillmode/) (stretch/tile). Bij stretch past de afbeelding zich aan de nieuwe cel aan; bij tile worden de tegels opnieuw berekend. Het artikel vermeldt de weergavemodi van afbeeldingen in een cel.

**Kan ik een hyperlink toewijzen aan de volledige inhoud van een cel?**

[Hyperlinks](/slides/nl/nodejs-java/manage-hyperlinks/) zijn ingesteld op tekstaanduidingsniveau (portion) binnen het tekstframe van de cel of op het niveau van de gehele tabel/vorm. In de praktijk kent u de link toe aan een gedeelte of aan alle tekst in de cel.

**Kan ik verschillende lettertypes binnen één cel instellen?**

Ja. Het tekstframe van een cel ondersteunt [portions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/portion/) (runs) met onafhankelijke opmaak — lettertypefamilie, stijl, grootte en kleur.