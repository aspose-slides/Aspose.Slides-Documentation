---
title: Hantera SmartArt i PowerPoint-presentationer på Android
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt text
- layouttyp
- dold egenskap
- organisationsdiagram
- bildorganisationsdiagram
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig att bygga och redigera PowerPoint SmartArt med Aspose.Slides för Android med tydliga Java-kodexempel som snabbar upp bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint-diagram som består av noder, nodformer och en layout. Med Aspose.Slides för Android via Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, inspektera dolda noder, konfigurera organisationsdiagramlayouter och skapa bildorganisationdiagram.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [ISmartArt.getAllNodes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ismartart/#getAllNodes--), och läs sedan [ITextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) som returneras av [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Ändra layouttypen för ett SmartArt-objekt**

SmartArt-layouten styr hur noder ordnas och kopplas ihop. Följande exempel skapar ett SmartArt-objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, ändrar det till `BasicProcess` och sparar presentationen.

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

## **Kontrollera om en SmartArt-nod är dold**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ismartartnode/#isHidden--) anger om noden är dold i SmartArt-datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt-objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` och kontrollerar nodens dolda tillstånd.

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

## **Hämta eller ange organisationsdiagramlayouten**

För SmartArt-diagram som använder en organisationsdiagramlayout definierar [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) och [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) hur barnnoder placeras under en föräldranod. Till exempel kan du ange att barnnoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OrganizationChartLayoutType).

Följande exempel skapar ett organisationsdiagram och sätter layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

## **Skapa ett bild-organisationsdiagram**

Ett bild-organisationsdiagram är en SmartArt-layout avsedd för hierarkidiagram som innehåller bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` när du lägger till SmartArt-objektet på en bild.

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

## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL-språk?**

Ja. Metoden [ISmartArt.setReversed](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) ändrar diagramriktningen från vänster-till-höger till höger-till-vänster, eller tillbaka, när den valda SmartArt-layouten stöder omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/androidjava/shape-manipulations/) med [ShapeCollection.addClone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) eller [klona hela bilden](/slides/sv/androidjava/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/androidjava/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt-objekt på en bild om det finns flera?**

Ange ett utmärkande [Shape.getAlternativeText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getAlternativeText--) eller [Shape.getName](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/shape/#getName--) på SmartArt‑formen, sök efter det värdet i [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/baseslide/#getShapes--), och kontrollera sedan att den matchande formen är en [ISmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ismartart/).