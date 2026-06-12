---
title: SmartArt beheren in PowerPoint-presentaties op Android
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay-outtype
- verborgen eigenschap
- organisatieschema
- afbeeldings-organisatieschema
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint SmartArt kunt maken en bewerken met Aspose.Slides voor Android, met duidelijke Java-codevoorbeelden die het ontwerpen en automatiseren van dia's versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint‑diagram dat bestaat uit knooppunten, knooppunt‑vormen en een lay-out. Met Aspose.Slides for Android via Java kunt u SmartArt maken, tekst uit de knooppunten lezen, de lay-out wijzigen, verborgen knooppunten inspecteren, lay-outs voor organisatieschema’s configureren en picture‑organisatieschema’s maken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meerdere vormen bevatten. Om de zichtbare tekst te lezen, doorloopt u [ISmartArt.getAllNodes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartart/#getAllNodes--), en leest u vervolgens het [ITextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/) dat wordt geretourneerd door [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **De lay-outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay-out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`‑waarde, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op.

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

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartartnode/#isHidden--) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur aanwezig zijn, zelfs wanneer de geselecteerde lay-out ze niet als zichtbare diagramonderdelen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle`‑waarde gebruikt en controleert de verborgen‑status van het knooppunt.

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

## **De lay-out van een organisatieschema ophalen of instellen**

Voor SmartArt‑diagrammen die een organisatieschema‑lay-out gebruiken, definiëren [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) en [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. U kunt bijvoorbeeld onderliggende knooppunten laten hangen aan de linker‑, rechter‑ of beide kanten, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OrganizationChartLayoutType).

Het volgende voorbeeld maakt een organisatieschema en stelt de lay-out in voor het eerste knooppunt op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`‑waarde.

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

## **Een picture‑organisatieschema maken**

Een picture‑organisatieschema is een SmartArt‑lay-out die bedoeld is voor hiërarchische diagrammen met afbeeldings‑plaatsaanduidingen. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart`‑waarde bij het toevoegen van het SmartArt‑object aan een dia.

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

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL‑talen?**

Ja. De [ISmartArt.setReversed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of omgekeerd, wanneer de gekozen SmartArt‑lay-out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie terwijl de opmaak behouden blijft?**

U kunt de [SmartArt‑vorm klonen](/slides/nl/androidjava/shape-manipulations/) met [ShapeCollection.addClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) of de hele dia klonen [/slides/nl/androidjava/clone-slides/](https://reference.aspose.com/slides/nl/androidjava/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeld of webexport?**

[Render de dia](/slides/nl/androidjava/convert-powerpoint-to-png/) of de volledige presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere aanwezig zijn?**

Stel een kenmerkende [Shape.getAlternativeText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getAlternativeText--) of [Shape.getName](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/shape/#getName--)‑waarde in op de SmartArt‑vorm, zoek die waarde in [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/baseslide/#getShapes--), en controleer vervolgens of de gevonden vorm een [ISmartArt](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ismartart/) is.