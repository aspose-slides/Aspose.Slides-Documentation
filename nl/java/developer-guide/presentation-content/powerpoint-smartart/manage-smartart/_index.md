---
title: SmartArt beheren in PowerPoint-presentaties met Java
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/java/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organigram
- foto-organigram
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-SmartArt kunt bouwen en bewerken met Aspose.Slides voor Java aan de hand van duidelijke code-voorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint-diagram gemaakt uit knooppunten, knooppuntvormen en een lay-out. Met Aspose.Slides voor Java kunt u SmartArt maken, tekst uit de knooppunten lezen, de lay-out wijzigen, verborgen knooppunten inspecteren, lay-outs voor organigrammen configureren en foto‑organigrammen maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meerdere vormen bevatten. Om de zichtbare tekst te lezen, doorloopt u [ISmartArt.getAllNodes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ismartart/#getAllNodes--), vervolgens leest u het [ITextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/) dat wordt geretourneerd door [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lay-outtype wijzigen van een SmartArt‑object**

De SmartArt‑lay-out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het onderstaande voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ismartartnode/#isHidden--) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de gekozen lay-out ze niet weergeeft als zichtbare diagramonderdelen.

Het onderstaande voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle`‑waarde gebruikt en controleert de verborgen‑status van het knooppunt.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lay-out van organigram ophalen of instellen**

Voor SmartArt‑diagrammen die een organigram‑lay-out gebruiken, definiëren [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) en [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. U kunt bijvoorbeeld onderliggende knooppunten laten hangen aan de linker-, rechter‑ of beide zijden, afhankelijk van de gekozen [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OrganizationChartLayoutType).

Het onderstaande voorbeeld maakt een organigram en stelt de lay-out van het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`‑waarde.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een foto‑organigram maken**

Een foto‑organigram is een SmartArt‑lay-out die is ontworpen voor hiërarchiediagrammen met afbeeldings‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [ISmartArt.setReversed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ismartart/#setReversed-boolean-)‑methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of omgekeerd, wanneer de gekozen SmartArt‑lay-out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt [de SmartArt‑vorm klonen](/slides/nl/java/shape-manipulations/) met [ShapeCollection.addClone](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) of [de hele dia klonen](/slides/nl/java/clone-slides/) die de SmartArt bevat. Beide benaderingen behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeldweergave of web‑export?**

[Render de dia](/slides/nl/java/convert-powerpoint-to-png/) of de volledige presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere aanwezig zijn?**

Stel een onderscheidende [Shape.getAlternativeText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getAlternativeText--) of [Shape.getName](https://reference.aspose.com/slides/nl/java/com.aspose.slides/shape/#getName--)‑waarde in op de SmartArt‑vorm, zoek die waarde op in [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/java/com.aspose.slides/baseslide/#getShapes--), en controleer vervolgens of de gevonden vorm een [ISmartArt](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ismartart/) is.