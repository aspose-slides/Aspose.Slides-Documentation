---
title: Hantera SmartArt i PowerPoint-presentationer på Android
linktitle: Hantera SmartArt
type: docs
weight: 10
url: /sv/androidjava/manage-smartart/
keywords:
- SmartArt
- SmartArt-text
- layouttyp
- dold egenskap
- organisationsdiagram
- bildorganisationsdiagram
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Lär dig att skapa och redigera PowerPoint SmartArt med Aspose.Slides för Android med tydliga Java-kodexempel som snabbar upp bilddesign och automatisering."
---
## **Översikt**

SmartArt är ett PowerPoint-diagram bestående av noder, nodeformer och en layout. Med Aspose.Slides för Android via Java kan du skapa SmartArt, läsa text från dess noder, ändra dess layout, inspektera dolda noder, konfigurera organisationsdiagramlayouter och skapa bildorganisationsdiagram.

## **Hämta text från ett SmartArt-objekt**

En SmartArt-nod kan innehålla en eller flera former. För att läsa text från nodeformerna, iterera genom [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), och läs sedan den [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) som returneras av [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

Exemplet kräver en presentation med minst en bild och ett SmartArt-objekt som den första formen på den bilden. Det skriver ut varje tillgänglig textram till konsolen.

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

## **Ändra layouttyp för ett SmartArt-objekt**

SmartArt‑layouten styr hur noder arrangeras och kopplas samman. Följande exempel skapar ett SmartArt-objekt med [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, ändrar det till `BasicProcess` och sparar presentationen. Positionen och storleken som skickas till [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) mäts i punkter. Använd [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) för att ändra layouten.

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

## **Kontrollera om en SmartArt-nod är dold**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) anger om noden är dold i SmartArt‑datamodellen. Dolda noder kan finnas i strukturen även när den valda layouten inte visar dem som synliga diagramelement.

Följande exempel lägger till en nod i ett SmartArt-objekt som använder [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` och kontrollerar den tillagda nodens dolda status. Det skriver ut ett meddelande om noden är dold och sparar diagrammet.

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

## **Hämta eller ställ in organisationsdiagramlayouten**

För SmartArt-diagram som använder en organisationsdiagramlayout definierar [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) och [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) hur barnnoder arrangeras under en föräldranod. Till exempel kan du ställa in att barnnoder hänger från vänster, höger eller båda sidor, beroende på den valda [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

Följande exempel skapar ett organisationsdiagram och sätter layouten för den första noden till [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Det nollbaserade indexet `0` väljer den första top‑nivånoden; dess barnnoder använder den valda arrangemanget. Den modifierade presentationen sparas därefter.

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

## **Skapa ett bildorganisationsdiagram**

Ett bildorganisationsdiagram är en SmartArt‑layout avsedd för hierarkidiagram som inkluderar bildplatshållare. Använd [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` när du lägger till SmartArt‑objektet på en bild. Detta exempel sparar ett diagram med bildplatshållare; det fyller inte i platshållarna med bilder.

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

## **Konvertera äldre diagram till grupper av former**

När du moderniserar en befintlig presentation kan du behöva uppdatera ett organisationsdiagram som ursprungligen skapades i PowerPoint 97–2003. Aspose.Slides representerar dessa äldre diagram som [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/)‑objekt. Använd [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) för att konvertera ett diagram till en grupp av former så att du kan redigera enskilda visuella element. Se [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) för detaljer.

Konverteringen lägger till en ny grupp i shape‑samlingen utan att ta bort det ursprungliga diagrammet. Efter lyckad konvertering, ta bort originalet med [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) för att undvika dubbletter. Samla de äldre diagrammen i en lista innan du konverterar dem så att tillägg och borttagning av former inte stör iterationen.

Följande exempel öppnar en presentation, söker igenom varje bild, konverterar diagrammen till grupper av former och sparar den uppdaterade presentationen som PPTX.

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

Den sparade presentationen innehåller redigerbara grupper av former i stället för de konverterade äldre diagrammen, utan att de ursprungliga diagrammen finns kvar bredvid dem. Öppna PPTX‑filen i PowerPoint för att redigera enskilda element i varje grupp, exempelvis deras text, fyllning eller position.

## **Vanliga frågor**

**Stöder SmartArt spegling eller omvändning för RTL‑språk?**

Ja. Metoden [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) byter diagramriktning från vänster‑till‑höger till höger‑till‑vänster, eller tillbaka, när den valda SmartArt‑layouten stöder omvändning.

**Hur kan jag kopiera SmartArt till samma bild eller till en annan presentation samtidigt som formateringen bevaras?**

Du kan [klona SmartArt-formen](/slides/sv/androidjava/shape-manipulations/) med [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) eller [klona hela bilden](/slides/sv/androidjava/clone-slides/) som innehåller SmartArt. Båda tillvägagångssätten bevarar storlek, position och formatering.

**Hur renderar jag SmartArt till en rasterbild för förhandsgranskning eller webbexport?**

[Rendera bilden](/slides/sv/androidjava/convert-powerpoint-to-png/) eller hela presentationen till PNG eller JPEG. SmartArt renderas som en del av bilden.

**Hur kan jag hitta ett specifikt SmartArt-objekt på en bild om det finns flera?**

Använd [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) eller [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) för att tilldela en distinkt alternativ text eller namn till SmartArt‑formen, sök efter det värdet i [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--), och kontrollera sedan att den matchande formen är ett [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/).