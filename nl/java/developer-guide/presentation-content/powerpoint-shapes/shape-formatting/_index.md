---
title: PowerPoint-vormen opmaken in Java
linktitle: Vormopmaak
type: docs
weight: 20
url: /nl/java/shape-formatting/
keywords:
- vorm opmaken
- lijn opmaken
- schets effect
- schets vormlijn
- aansluitstijl opmaken
- verloopvulling
- patroonvulling
- afbeeldingsvulling
- textuurvulling
- effen kleurvulling
- vormtransparantie
- zwart-wit vormrendering
- grijswaarden vormrendering
- vorm roteren
- 3D schuine rand effect
- 3D rotatie effect
- opmaak resetten
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u PowerPoint-vormen in Java kunt opmaken met Aspose.Slides—stel vullings-, lijn- en effectstijlen in voor PPT- en PPTX-bestanden met precieze en volledige controle."
---
## **Introductie**

Formateer vormen in PowerPoint door hun omtreklijnen, vullingen en effecten aan te passen. Aspose.Slides voor Java stelt u in staat deze instellingen programmatisch te beheersen, inclusief transparantie, rotatie en 3D‑formattering.

![Opties voor vormopmaak in PowerPoint](format-shape-powerpoint.png)

Aspose.Slides voor Java biedt interfaces en methoden die u toestaan vormen te formatteren met dezelfde opties die beschikbaar zijn in PowerPoint.

## **Lijnen opmaken**

Gebruik [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) om de omtrek van een vorm te regelen. Dit voorbeeld maakt een niet‑gevulde rechthoek met een blauwe, gestippelde omtrek. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) selecteert een dik‑dun samengestelde lijn, terwijl [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) de breedte op 7 punten zet en [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) het stippatroon selecteert.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De opgemaakte lijnen in de presentatie](formatted-lines.png)

### **Stel aangepaste lijndiash-patronen in**

Gebruik [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) wanneer vooraf gedefinieerde lijnstijlen niet de gewenste stippelengtes en -gaten bieden, bijvoorbeeld voor merk‑omtreklijnen of technische diagrammen. Het toewijzen van een patroon verandert automatisch de lijn‑dash‑stijl naar [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Array‑items wisselen af tussen stippellengte en gatlengte, beginnend met een streep. Elke waarde is een veelvoud van de lijnbreedte: `{ 4, 2 }` bij een breedte van 3 punten levert een streep van 12 punten op gevolgd door een gat van 6 punten. Gebruik paren van eindige, niet‑negatieve waarden om volledige stippel‑en‑gat‑segmenten te definiëren. Het voorbeeld gebruikt positieve waarden zodat elke streep en elk gat zichtbaar blijft.

Dit voorbeeld maakt vijf blauwe lijnen met dezelfde lengte en platte kapjes. De eerste drie vergelijken patronen bij een breedte van 3 punten. De vierde herhaalt het eerste patroon met tweemaal de breedte, waardoor zowel de stippels als de gaten verdubbelen. De vijfde schakelt van een aangepast patroon naar een solide lijn.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Zet de laatste lijn terug naar een solide stijl.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Om terug te gaan naar een vooraf gedefinieerde gestippelde stijl, geef [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) door aan [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). De geselecteerde stijl bepaalt het uiterlijk van de lijn.

Het resultaat in PowerPoint, van boven naar beneden: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; en **Solid, 3 pt**.

![Drie aangepaste stippatronen, een bredere lijn met het eerste patroon, en een solide lijn in PowerPoint](custom-dash-patterns.png)

### **Stel lijnkapjes in**

Gebruik [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) om de uiteinden van een open lijn in te stellen. De [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/)‑klasse biedt drie expliciete kapstijlen:

- `Flat`: De lijn stopt op het eindpunt.
- `Round`: Een halfcirkelvormig kapje strekt zich uit voorbij het eindpunt met een halve lijnbreedte.
- `Square`: Een vierkant kapje strekt zich uit voorbij het eindpunt met een halve lijnbreedte.

De klasse bevat ook `NotDefined`, wat betekent dat er geen kapstijl expliciet is toegewezen.

Kapjes verschillen van pijlpuntjes, die symbolen aan de uiteinden toevoegen, en van aansluitingen, die hoeken tussen lijnsegmenten regelen. Dit voorbeeld schakelt pijlpuntjes uit via [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) en [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-) zodat alleen de kapvormen worden vergeleken.

Het volgende voorbeeld maakt drie verder identieke horizontale lijnen, 20 punten breed. Van boven naar beneden gebruiken ze platte, ronde en vierkante kapjes. Hun eindpunten hebben dezelfde horizontale coördinaten; de ronde en vierkante kapjes steken 10 punten uit voorbij elk eindpunt.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint, van boven naar beneden: **Flat**, **Round**, en **Square**.

![Platte, ronde en vierkante kapjes op identieke dikke lijnen in PowerPoint](line-caps.png)

## **Schets‑effecten toepassen op vormlijnen**

Een schets‑effect laat een vormlijn eruitzien alsof deze met de hand is getekend. Gebruik [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) om de lijninstellingen te benaderen, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) om de schetsinstellingen te benaderen, en [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) om een waarde uit de [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/)‑klasse te selecteren.

De volgende Java‑code toont hoe een [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/)‑effect toe te passen, de expliciet toegewezen waarde uit te lezen, en het effect te verwijderen met [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

De waarde die wordt geretourneerd door [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) vertegenwoordigt de instelling die rechtstreeks aan de vorm is toegewezen. Als de lijnformattering kan worden geërfd van een thema, de master‑dia of de indelingsdia, gebruik dan [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), benader [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), en lees [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). De effectieve waarde weerspiegelt de opmaak die daadwerkelijk wordt toegepast nadat overerving is opgehelderd. Dit voorbeeld vereist een bestaande presentatie met ten minste één vorm op de eerste dia en geeft beide waarden weer:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Opmaak van aansluitstijlen**

Hier zijn de drie opties voor het type aansluiting:

* Round
* Miter
* Bevel

De aansluitstijl bepaalt hoe twee omtreksegmenten elkaar ontmoeten op een hoek. Gebruik **Round** voor ronde hoeken, **Miter** voor scherpe hoeken, of **Bevel** voor afgevlakte hoeken.

![De aansluitstijl in de presentatie](join-style-powerpoint.png)

Dit voorbeeld maakt drie zwarte rechthoeken met blauwe omtrekken van 15 punten breed. Het gebruikt [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) om respectievelijk de miter‑, bevel‑ en round‑waarden van [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) in te stellen, om te vergelijken hoe de hoeken worden getekend.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Beperk miter‑aansluitingen bij scherpe hoeken**

Gebruik [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) in combinatie met [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) ingesteld op [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) om te beperken hoe ver een scherpe hoek mag uitsteken.

De limiet is een verhouding tussen de afstand van de binnen‑ en buitenhoek van de aansluiting en de lijnbreedte. Een waarde van `8` bijvoorbeeld staat een miter‑lengte toe tot acht keer de lijnbreedte; het is geen meting in punten. Als de hoek de limiet zou overschrijden, gebruikt PowerPoint een afgevlakte aansluiting op die hoek. Een grotere limiet maakt scherpere punten mogelijk. De instelling beïnvloedt alleen miter‑aansluitingen en heeft geen zichtbaar effect wanneer de hoek binnen beide limieten blijft.

Dit voorbeeld maakt twee identieke, niet‑gevulde driehoeken met omtrekken van 20 punten breed. De linkse driehoek gebruikt een limiet van `2`, de rechtse een limiet van `8`. Elke driehoek is 80 punten breed en 160 punten hoog, waardoor de bovenste hoek een verhouding van ongeveer `4.12` heeft tussen miter‑lengte en lijnbreedte. Daardoor maakt PowerPoint van de linkse top een afgevlakte punt en behoudt van de rechtse top een scherpe punt.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint: **Miter limit 2** aan de linkerkant en **miter limit 8** aan de rechterkant.

![Een afgevlakte top met miter‑limiet 2 en een puntige top met miter‑limiet 8 in PowerPoint](miter-limits.png)

## **Verloopvulling**

Een verloopvulling mengt kleuren over een vorm. Dit voorbeeld vult een ellips met een lineair verloop onder een hoek van 45 graden van rood naar paars via [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). De methode [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) plaatst de kleurstops op 0 en 1, het begin en einde van het verloop. Het wissen van de bestaande stops zorgt ervoor dat alleen deze twee kleuren worden gebruikt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De ellips met verloopvulling](gradient-fill.png)

Als een verloop er in een geëxporteerde afbeelding anders uitziet dan in PowerPoint, zie dan [Kies een verloop‑renderingsstijl](/slides/nl/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). U kunt een renderingsstijl selecteren zonder de opgeslagen verloopvulling in de presentatie te wijzigen.

### **Stel de lineaire verloophoek in**

Gebruik [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) om de oriëntatie van een [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/)‑vulling te regelen. De hoek wordt gemeten in graden en neemt met de klok mee toe: `0` loopt van links naar rechts, `90` van boven naar beneden, `180` van rechts naar links, en `270` van onder naar boven. Fractionele hoeken worden ondersteund. Eindige hoeken buiten `[0, 360)` worden genormaliseerd naar één omwenteling; bijvoorbeeld `-45` wordt `315` en `360` wordt `0`.

Dit voorbeeld maakt zes rechthoeken met identieke rode, groene en blauwe stops op posities `0`, `0.5` en `1`. Schalen is uitgeschakeld zodat de hoek onafhankelijk van de verhoudingen van de rechthoeken kan worden vergeleken. De hoeken, van links naar rechts, zijn `0`, `45` en `90` in de eerste rij, en `135`, `180` en `270` in de tweede rij.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint:

![Lineaire verlopen op 0, 45 en 90 graden in de bovenste rij, en 135, 180 en 270 graden in de onderste rij](linear-gradient-angles.png)

### **Schaal een lineair verloop met de vorm**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) accepteert een [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Stel deze expliciet in op `False` om de geometrische verloophoek te behouden wanneer de verhoudingen van de vorm wijzigen, of op `True` om het verloop mee te schalen met de breedte en hoogte van de vorm. Met inschakelde schaal kan de zichtbare hoek afwijken van de toegewezen hoek bij een niet‑vierkante vorm.

Het volgende voorbeeld gebruikt een hoek van `45` graden en dezelfde kleurstops als bij de hoeksvergelijking. De linkse kolom gebruikt `False`; de rechtse kolom gebruikt `True`. Elke kolom bevat een brede rechthoek boven een hoge rechthoek. Beide beginnen met dezelfde brede afmetingen; het wijzigen van de breedte en hoogte van de tweede rechthoek toont hoe de vulling reageert op het wijzigen van de grootte zonder de verloopinstellingen aan te passen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat in PowerPoint, met schaal uitgeschakeld links en ingeschakeld rechts:

![Brede en hoge rechthoeken met een 45‑graden verloop, vergelijking LinearGradientScaled False links met True rechts](linear-gradient-scaling.png)

Met schaal uitgeschakeld behouden de diagonale kleurbanden dezelfde oriëntatie in beide rechthoeken. Met schaal ingeschakeld rekken de banden zich uit volgens de verhoudingen van de vorm. Dit helpt een sjabloon‑verloop te reproduceren bij het aanpassen van een vorm naar een andere grootte. Op een vierkant verandert het inschakelen van schaal het uiterlijk van dit `45`‑graden verloop niet.

Zowel de hoek‑ als de schaalinstellingen gelden voor lineaire verlopen. Ze sturen geen [GradientShape.Radial of GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/)‑vullingen aan.

### **Combineer de hoek met de verlooprichting**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) selecteert een verloopstijl uit de [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/)‑klasse; het is geen vervanging voor een numerieke hoek. Voor een lineair verloop kunnen de hoekstijlen het gebied waarin de kleuren worden verdeeld wijzigen zonder de via [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) toegewezen hoek te wijzigen. Houd de richting ongewijzigd bij het vergelijken van hoeken of schalen.

Het volgende voorbeeld past dezelfde instellingen toe in omgekeerde volgorde. De twee rechthoeken hebben hetzelfde uiterlijk: de richting vóór of na de hoek toewijzen verandert het resultaat niet.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Patroonvulling**

Een patroonvulling past een ontwerp met twee kleuren toe, zoals stippen, strepen of geruite patronen. Dit voorbeeld gebruikt [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) om een traliewerkpatroon te selecteren. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) levert de lichtgrijze achtergrond, en [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) levert de gele patroonkleur.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rechthoek met patroonvulling](pattern-fill.png)

## **Afbeeldingsvulling**

Een afbeeldingsvulling gebruikt een afbeelding binnen een vorm. Dit voorbeeld vereist een lokale afbeelding en gebruikt [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-) om deze te laden in de afbeeldingsverzameling van de presentatie. Het instellen van [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) op de tegelmodus herhaalt de afbeelding binnen de rechthoek. De bronafbeelding die hier wordt gebruikt, staat hieronder weergegeven:

![De lotusafbeelding](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met afbeeldingsvulling](picture-fill.png)

### **Afbeelding tegel als textuur**

Als u een getegelde afbeelding als textuur wilt instellen en het tegelgedrag wilt aanpassen, kunt u de volgende methoden van de [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/)‑interface en de [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/)‑klasse gebruiken:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Stelt de afbeeldingsvulmodus in — ofwel `Tile` of `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Specificeert de uitlijning van de tegels binnen de vorm.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Bepaalt of de tegel horizontaal, verticaal of beide keren wordt gedraaid.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Stelt de horizontale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Stelt de verticale offset van de tegel (in punten) ten opzichte van de oorsprong van de vorm.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definieert de horizontale schaal van de tegel als een percentage.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definieert de verticale schaal van de tegel als een percentage.

Dit voorbeeld vereist een lokale afbeelding en configureert [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) om deze te herhalen op 50 % van de oorspronkelijke grootte. Offsets van −32 punten verschuiven de tegels horizontaal en verticaal; uitlijning rechtsonder en draaien in beide richtingen bepalen hoe de herhaalde textuur wordt gerangschikt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De tegelopties](tile-options.png)

## **Vulling met effen kleur**

Een effen vulling geeft een vorm een enkele, uniforme kleur. Dit voorbeeld gebruikt [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) om de effen vullingsmodus in te stellen en wijst geel toe via [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), waarna de rechthoek in een presentatie wordt opgeslagen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De vorm met effen kleurvulling](solid-color-fill.png)

## **Gebruik de dia‑achtergrond als vulling voor een vorm**

Gebruik [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) wanneer een vorm moet overeenkomen met de dia‑achtergrond, bijvoorbeeld in een presentatiesjabloon. Gebruik [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) om eerst [FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) toe te passen om eventuele expliciete vulling te verwijderen. Met deze combinatie gebruikt de vorm de dia‑achtergrond in plaats van de stijl‑vulling. Alleen het inschakelen van de vlag verwijdert geen bestaande expliciete vulling.

Dit verschilt van [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): een achtergrondvulling bedekt objecten achter de vorm met het overeenkomstige gebied van de dia‑achtergrond, terwijl geen vulling die objecten zichtbaar laat. Een verloop blijft uitgelijnd met de dia in plaats van opnieuw te beginnen binnen elke vorm.

Het volgende voorbeeld maakt een master‑achtergrond die door de dia wordt overgeërfd en plaatst een magenta band achter drie rechthoeken. De linkse rechthoek gebruikt de achtergrond, de middelste rechthoek heeft geen vulling, en de rechtse rechthoek schakelt van achtergrondvulling naar een expliciete oranje vulling.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Erf het verloop van de master.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

    // Voeg dit object eerst toe zodat het achter de rechthoeken verschijnt.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Schakel achtergrondvulling uit voordat een expliciete vulling wordt toegepast.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat, van links naar rechts: **background fill**, **no fill**, en **explicit fill**. De magenta band wordt verborgen door de linkse en rechtse rechthoeken maar blijft zichtbaar door de middelste rechthoek.

![Achtergrondvulling, geen vulling, en expliciete oranje vulling over een magenta band](background-fill.png)

Hetzelfde gedrag geldt voor een achtergrond die direct op de dia is gedefinieerd of die wordt geërfd van een indeling. De vorm gebruikt de opgeloste achtergrond van de dia; het voorbeeld laat zowel de dia‑ als de indelingsachtergronden ongedefinieerd zodat de master deze levert.

## **Transparantie instellen**

Voor een effen vulling bepaalt de alfa‑component van de kleur de dekking: 0 is volledig transparant en 255 is volledig ondoorzichtig. Dit voorbeeld gebruikt een alfa‑waarde van 128 voor een gele rechthoek, waardoor deze ongeveer 50 % transparant wordt zodat de onderliggende rechthoek zichtbaar blijft. De kleur wordt toegewezen via [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De transparante vorm](shape-transparency.png)

## **Vormen roteren**

Gebruik [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) om een vorm in het dia‑vlak te roteren. De hoek wordt gemeten in graden; dit voorbeeld roteert een rechthoek 5 graden met de klok mee en slaat de presentatie op.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![De rotatie van de vorm](shape-rotation.png)

## **3D‑schuine rand‑effecten toevoegen**

Gebruik [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) om een vorm diepte en schuine randen te geven. Dit voorbeeld maakt een groene ellips met een oranje omtrek, gebruikt [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) om de diepte op 4 punten in te stellen, en past via [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) een ronde bovenrand toe met een breedte en hoogte van 6 punten. Een front‑gerichte orthografische camera en drie‑punt verlichting maken de schuine rand zichtbaar.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het 3D‑schuine rand‑effect](3D-bevel-effect.png)

## **3D‑rotatie‑effecten toevoegen**

Het 3D‑beeld van een vorm wordt bestuurd door de camera‑instellingen. Dit voorbeeld gebruikt [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) met breedte‑graad, lengte‑graad en revolutiehoeken van respectievelijk 40, 35 en 20 graden. Het selecteert een isometrische camera via [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) en een gebalanceerde verlichting via [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), waarna de geformatteerde rechthoek wordt opgeslagen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het resultaat:

![Het 3D‑rotatie‑effect](3D-rotation-effect.png)

## **Zwart‑wit weergave voor vormen regelen**

De methode [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) geeft aan hoe een individuele vorm wordt weergegeven wanneer een presentatie in zwart‑wit modus wordt bekeken of verwerkt. De methode activeert niet zelf een zwart‑wit weergave en verandert de vulling, lijn of andere opmaak van de vorm niet in de normale kleermodus.

Gebruik een waarde uit de [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/)‑klasse om het gewenste gedrag te selecteren. Bijvoorbeeld, `Automatic` laat de weergave‑applicatie de conversie kiezen, `Gray` en `LightGray` gebruiken grijze kleuring, `BlackWhite` gebruikt alleen zwart en wit, `Black` en `White` forceren één kleur, `Color` behoudt de normale kleuring, en `Hidden` laat de vorm weg in zwart‑wit modus. `NotDefined` betekent dat er geen vorm‑specifieke modus is toegewezen.

Dit voorbeeld maakt een oranje rechthoek en gebruikt [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) om de modus op grijs in te stellen. De opgeslagen vorm behoudt haar oranje vulling voor normale kleermodus en vraagt grijze kleuring aan applicaties die zwart‑wit weergave‑instellingen respecteren:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

In de normale kleermodus behoudt de rechthoek haar oranje vulling. In een zwart‑wit weergave‑workflow gebruikt ze grijze kleuring omdat de modus is ingesteld op `Gray`. Hiermee kunt u een volledige‑kleur dia behouden terwijl u een afzonderlijk uiterlijk definieert voor afdrukken, voorvertonen of andere workflows die de zwart‑wit weergave‑instellingen van de presentatie respecteren.

## **Opmaak resetten**

Gebruik [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) om de positie, grootte en opmaak van dia‑plaatsvervangers te herstellen vanuit de overeenkomstige indelings‑plaatsvervangers. Dit voorbeeld vereist een bestaande presentatie met indelings‑gekoppelde plaatsvervangers en reset elke dia voordat deze wordt opgeslagen. Vormen zonder overeenkomstige indelings‑plaatsvervangers worden niet gereset.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Veelgestelde vragen**

**Heeft vormopmaak invloed op de uiteindelijke bestandsgrootte van de presentatie?**

Kleuren, lijnstijlen en effectinstellingen voegen over het algemeen weinig data toe vergeleken met ingebedde afbeeldingen en media. Afbeeldingsvullingen kunnen de bestandsgrootte vergroten omdat hun afbeeldingen in de presentatie worden opgeslagen.

**Hoe kan ik vormen op een dia detecteren die identieke opmaak delen zodat ik ze kan groeperen?**

Vergelijk de belangrijkste opmaak‑eigenschappen van elke vorm — vulling, lijn en effectinstellingen. Als alle overeenkomstige waarden overeenkomen, beschouw dan hun stijlen als identiek en groepeer die vormen logisch, wat later stijlbeheer vereenvoudigt.

**Kan ik een set aangepaste vormstijlen opslaan in een apart bestand voor hergebruik in andere presentaties?**

Ja. Bewaar voorbeeldvormen met de gewenste stijlen in een sjabloon‑diareeks of een .POTX‑sjabloonbestand. Bij het maken van een nieuwe presentatie opent u het sjabloon, kloont u de benodigde gestylede vormen, en past u hun opmaak toe waar nodig.