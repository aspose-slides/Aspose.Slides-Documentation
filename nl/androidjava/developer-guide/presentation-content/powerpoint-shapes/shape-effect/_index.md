---
title: Shape‑effecten toepassen in presentaties op Android
linktitle: Vormeffect
type: docs
weight: 30
url: /nl/androidjava/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie‑effect
- gloeieffect
- zachtrandeffect
- effectformaat
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Transformeer uw PPT- en PPTX-bestanden met geavanceerde vormeffecten met Aspose.Slides voor Android via Java — maak binnen enkele seconden indrukwekkende, professionele dia’s."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/androidjava/shape-formatting/#gradient-fill) of contours. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Shape effect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meer effecten op een vorm toepassen.

Sommige combinaties van effecten zien er beter uit dan andere. Daarom biedt PowerPoint opties onder **Preset**. De Preset‑opties zijn combinaties van twee of meer effecten die bekend staan om hun goede uiterlijk. Op deze manier hoef je, door een preset te selecteren, geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de klasse [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) die je in staat stellen dezelfde effecten toe te passen op vormen in PowerPoint‑presentaties.

## **Een schaduweffect toepassen**

Aspose.Slides voor Android via Java ondersteunt buiten‑ en binnenschaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsradius aanpassen om overeen te komen met het ontwerp van je presentatie.

### **Een buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de achtergrond van de dia. De schaduw strekt zich uit buiten de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de dia verheven is. Pas de kleur, richting, afstand en vervagingsradius aan om overeen te komen met de verlichting en stijl van je sjabloon.

Deze Java‑code laat zien hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) op een rechthoek toepast:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Shadow effect](shadow_effect.png)

### **Een binnenste schaduw toepassen**

Wanneer je de visuele stijl van een sjabloon reproduceert, gebruik je een binnenste schaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verheven lijken, terwijl een binnenste schaduw de binnenkant van de randen schaduwt.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Grotere vervagingsradiuswaarden geven zachtere randen.

Dit Java‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenste schaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten en de vervagingsradius is 6 punten:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Om de binnenste schaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) aan op het effectformaat van de vorm.

## **Een reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Android via Java, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met simpele code, waardoor je het snel kunt toepassen op meerdere elementen voor een consistent ontwerp.

Deze Java‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) op een vorm toepast:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflection effect](reflection_effect.png)

## **Een gloeieffect toepassen**

Om een gloed‑effect op een vorm toe te passen in Aspose.Slides voor Android via Java, kun je een zachte, lichtgevende aura rond vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, opvallend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code en verbetert het algehele uiterlijk van je dia's.

Deze Java‑code laat zien hoe je het [gloed‑effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) op een vorm toepast:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glow effect](glow_effect.png)

## **Een zachtrand‑effect toepassen**

Om een zacht‑rand‑effect toe te passen in Aspose.Slides voor Android via Java, kun je een vloeiende, vervaagde overgang rond de randen van een vorm creëren. Dit effect geeft een subtielere en verfijndere uitstraling, perfect voor ontwerpen die een zachte, zachtere look nodig hebben. Je kunt eenvoudig parameters zoals radius aanpassen om het gewenste effect te bereiken voor verschillende vormen in je presentatie.

Deze Java‑code laat zien hoe je het [zacht‑rand‑effect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) op een vorm toepast:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Soft edges effect](soft_edges_effect.png)

## **Een vervagingseffect toepassen**

Gebruik vervaging van vormen om de vulling en contour van een vorm zachter te maken terwijl de vorm bewerkbaar blijft. Roep [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aan op het effectformaat van de vorm. De radius wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij grotere waarden een sterkere vervaging opleveren. Een radius van nul laat het uiterlijk onveranderd.

De [getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--) instelling bepaalt de zichtbare grenzen van het effect. Met `false` wordt de vervaging begrensd tot de oorspronkelijk getekende grenzen, inclusief de contour. Met `true` kan de vervaging zich buiten die grenzen uitstrekken. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De onderstaande vergelijking gebruikt doorweg dezelfde vulling, contour en vormafmetingen. De bovenste rij gebruikt `grow = false`; de onderste rij gebruikt `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Dit Java‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe en werkt deze vervolgens bij naar een vervaging van 15 punten door opnieuw [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aan te roepen. Het slaat beide vervaagde toestanden op, roept vervolgens [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) aan en slaat de vorm zonder vervaging op.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vervaging van vormen beïnvloedt zowel de vulling als de contour. Een zacht‑rand‑effect vervaagt de randen van de vorm, terwijl schaduwvervaging alleen de schaduw verzacht. Effecten voor afbeeldingstransformatie werken op de afbeeldingsinhoud; dit voorbeeld past vervaging direct toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **FAQ**

**Kan ik meerdere effecten toepassen op dezelfde vorm?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder auto‑shapes, diagrammen, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt toegepast op de gehele groep.