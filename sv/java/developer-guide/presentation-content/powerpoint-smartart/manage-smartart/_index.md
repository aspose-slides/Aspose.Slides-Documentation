---
title: Hantera SmartArt i PowerPoint-presentationer med Java
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/java/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layout-typ
- dold egenskap
- organisationsdiagram
- bild-organisationsdiagram
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Lär dig att bygga och redigera PowerPoint‑SmartArt med Aspose.Slides för Java med tydliga kodexempel som påskyndar bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint‑diagram som består av noder, nodformer och en layout. Med Aspose.Slides for Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, inspektera dolda noder, konfigurera organisation‑diagramlayouter och skapa bild‑organisation‑diagram.

## **Hämta text från ett SmartArt‑objekt**

En SmartArt‑nod kan innehålla en eller flera former. För att läsa den synliga texten, iterera genom [ISmartArt.getAllNodes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ismartart/#getAllNodes--), och läs sedan den [ITextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/) som returneras av [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Ändra layouttyp för ett SmartArt‑objekt**

SmartArt‑layouten styr hur noder ordnas och kopplas ihop. Följande exempel skapar ett SmartArt‑objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtLayoutType)‑värdet `BasicBlockList`, ändrar det till `BasicProcess` och sparar presentationen.

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

## **Kontrollera om en SmartArt‑nod är dold**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ismartartnode/#isHidden--) visar om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramdelar.

Följande exempel lägger till en nod i ett SmartArt‑objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtLayoutType)‑värdet `RadialCycle` och kontrollerar nodens dolda tillstånd.

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

## **Hämta eller ange layout för organisationsdiagram**

För SmartArt‑diagram som använder en organisationsdiagramlayout definierar [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) och [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) hur underordnade noder placeras under en föräldranod. Du kan till exempel ställa in att underordnade noder hänger åt vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OrganizationChartLayoutType).

Följande exempel skapar ett organisationsdiagram och sätter layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/OrganizationChartLayoutType)‑värdet `LeftHanging`.

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

## **Skapa ett bild‑organisationsdiagram**

Ett bild‑organisationsdiagram är en SmartArt‑layout avsedd för hierarkiska diagram som innehåller bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtLayoutType)‑värdet `PictureOrganizationChart` när du lägger till SmartArt‑objektet på en bild.

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

**Stöder SmartArt spegling eller omvändning för RTL‑språk?**

Ja. Metoden [ISmartArt.setReversed](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ismartart/#setReversed-boolean-) växlar diagramriktningen från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stödjer omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt‑formen](/slides/sv/java/shape-manipulations/) med [ShapeCollection.addClone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) eller [klona hela bilden](/slides/sv/java/clone-slides/) som innehåller SmartArt. Båda metoderna bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/java/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur hittar jag ett specifikt SmartArt‑objekt på en bild om det finns flera?**

Ange ett tydligt [Shape.getAlternativeText](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getAlternativeText--)‑ eller [Shape.getName](https://reference.aspose.com/slides/sv/java/com.aspose.slides/shape/#getName--)‑värde på SmartArt‑formen, sök efter det värdet i [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/java/com.aspose.slides/baseslide/#getShapes--), och kontrollera sedan att den matchande formen är en [ISmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ismartart/).