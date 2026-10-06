---
title: SmartArt beheren in PowerPoint‑presentaties met Java
linktitle: SmartArt beheren
type: docs
weight: 10
url: /nl/java/manage-smartart/
keywords:
- SmartArt
- SmartArt-tekst
- lay‑outtype
- verborgen eigenschap
- organigram
- afbeeldings‑organigram
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint SmartArt kunt bouwen en bewerken met Aspose.Slides voor Java met duidelijke codevoorbeelden die het ontwerpen van dia’s en automatisering versnellen."
---
## **Overzicht**

SmartArt is een PowerPoint‑diagram dat bestaat uit knooppunten, knooppuntvormen en een lay‑out. Met Aspose.Slides for Java kun je SmartArt maken, tekst uit de knooppunten lezen, de lay‑out wijzigen, verborgen knooppunten inspecteren, lay‑outs voor organigrammen configureren en afbeelding‑organigrammen aanmaken.

## **Tekst ophalen uit een SmartArt‑object**

Een SmartArt‑knooppunt kan één of meer vormen bevatten. Om de tekst uit de knooppuntvormen te lezen, doorloop je [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--) en lees je vervolgens het [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) dat wordt geretourneerd door [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

Het voorbeeld vereist een presentatie met ten minste één dia en een SmartArt‑object als de eerste vorm op die dia. Het drukt elk beschikbaar tekstframe af naar de console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Lay‑outtype van een SmartArt‑object wijzigen**

De SmartArt‑lay‑out bepaalt hoe knooppunten worden gerangschikt en verbonden. Het volgende voorbeeld maakt een SmartArt‑object met de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/)‑waarde `BasicBlockList`, wijzigt deze naar de `BasicProcess`‑waarde en slaat de presentatie op. De positie en afmeting die aan [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) worden meegegeven, worden gemeten in punten. Gebruik [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) om de lay‑out te wijzigen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Controleren of een SmartArt‑knooppunt verborgen is**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) geeft aan of het knooppunt verborgen is in het SmartArt‑datamodel. Verborgen knooppunten kunnen in de structuur bestaan, zelfs wanneer de gekozen lay‑out ze niet als zichtbare diagram­elementen weergeeft.

Het volgende voorbeeld voegt een knooppunt toe aan een SmartArt‑object dat de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/)‑waarde `RadialCycle` gebruikt en controleert de verborgen status van het toegevoegde knooppunt. Het drukt een bericht af als het knooppunt verborgen is en slaat het diagram op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Organigramlay‑out ophalen of instellen**

Voor SmartArt‑diagrammen die een organigramlay‑out gebruiken, definiëren [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) en [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) hoe onderliggende knooppunten onder een bovenliggend knooppunt worden gerangschikt. Zo kun je bijvoorbeeld onderliggende knooppunten laten hangen aan de linker‑, rechter‑ of beide zijden, afhankelijk van de geselecteerde [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/).

Het volgende voorbeeld maakt een organigram en stelt de lay‑out voor het eerste knooppunt in op de [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/)‑waarde `LeftHanging`. De index `0` (nul‑gebaseerd) selecteert het eerste knooppunt op hoogste niveau; de onderliggende knooppunten gebruiken de gekozen rangschikking. De gewijzigde presentatie wordt vervolgens opgeslagen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Een afbeelding‑organigram maken**

Een afbeelding‑organigram is een SmartArt‑lay‑out ontworpen voor hiërarchische diagrammen met afbeeldings‑plaatsvervangers. Gebruik de [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/)‑waarde `PictureOrganizationChart` bij het toevoegen van het SmartArt‑object aan een dia. Dit voorbeeld slaat een diagram met afbeeldings‑plaatsvervangers op; het vult de plaatsvervangers niet met afbeeldingen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Legacy‑diagrammen omzetten naar groepen vormen**

Bij het moderniseren van een bestaande presentatie moet je mogelijk een organigram bijwerken dat oorspronkelijk is gemaakt in PowerPoint 97–2003. Aspose.Slides vertegenwoordigt deze legacy‑diagrammen als [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/)‑objecten. Gebruik [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) om een diagram om te zetten naar een groep van vormen, zodat je individuele visuele elementen kunt bewerken. Zie de [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) voor meer details.

De conversie voegt een nieuwe groep toe aan de vormverzameling zonder het oorspronkelijke diagram te verwijderen. Na een geslaagde conversie verwijder je het origineel met [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) om dubbele inhoud te voorkomen. Verzamel de legacy‑diagrammen in een lijst voordat je ze converteert, zodat het toevoegen en verwijderen van vormen de iteratie niet verstoort.

Het volgende voorbeeld opent een presentatie, doorzoekt elke dia, zet de diagrammen om naar groepen vormen en slaat de bijgewerkte presentatie op als PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De opgeslagen presentatie bevat bewerkbare groepen vormen ter vervanging van de geconverteerde legacy‑diagrammen, zonder dat er originele diagrammen meer naast staan. Open het PPTX‑bestand in PowerPoint om individuele elementen binnen elke groep te bewerken, zoals hun tekst, opvulling of positie.

## **FAQ**

**Ondersteunt SmartArt spiegelen of omkeren voor RTL-talen?**

Ja. De [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-)‑methode schakelt de diagramrichting van links‑naar‑rechts naar rechts‑naar‑links, of terug, wanneer de gekozen SmartArt‑lay‑out omkering ondersteunt.

**Hoe kan ik SmartArt kopiëren naar dezelfde dia of naar een andere presentatie met behoud van opmaak?**

Je kunt de SmartArt‑vorm [klonen](/slides/nl/java/shape-manipulations/) met [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) of de hele dia [klonen](/slides/nl/java/clone-slides/) die de SmartArt bevat. Beide methoden behouden grootte, positie en opmaak.

**Hoe render ik SmartArt naar een rasterafbeelding voor voorbeeld of webexport?**

[Render de dia](/slides/nl/java/convert-powerpoint-to-png/) of de volledige presentatie naar PNG of JPEG. SmartArt wordt gerenderd als onderdeel van de dia.

**Hoe kan ik een specifiek SmartArt‑object op een dia vinden als er meerdere zijn?**

Gebruik [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) of [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) om een onderscheidende alternatieve tekst of naam aan de SmartArt‑vorm toe te wijzen, zoek die waarde op in [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--), en controleer vervolgens of de gevonden vorm een [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/) is.