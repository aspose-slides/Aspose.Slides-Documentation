---
title: Vormen effect toepassen in presentaties met Java
linktitle: Vorm-effect
type: docs
weight: 30
url: /nl/java/shape-effect/
keywords:
- vormeffect
- schaduweffect
- reflectie-effect
- gloed-effect
- zacht-rand-effect
- effectformaat
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Transformeer je PPT- en PPTX-bestanden met geavanceerde vormeffecten met Aspose.Slides voor Java - maak in enkele seconden opvallende, professionele dia's."
---
## **Inleiding**

Hoewel effecten in PowerPoint kunnen worden gebruikt om een vorm te laten opvallen, verschillen ze van [vullingen](/slides/nl/java/shape-formatting/#gradient-fill) of contouren. Met PowerPoint‑effecten kun je overtuigende reflecties op een vorm creëren, de gloed van een vorm verspreiden, enz.

![Vorm-effect](shape-effect.png)

PowerPoint biedt zes effecten die op vormen kunnen worden toegepast. Je kunt één of meerdere effecten op een vorm gebruiken.

Sommige combinaties van effecten zien er beter uit dan andere. Om die reden biedt PowerPoint opties onder **Voorinstelling**. De Voorinstelling‑opties zijn combinaties van twee of meer effecten waarvan bekend is dat ze er goed uitzien. Op deze manier hoef je bij het selecteren van een voorinstelling geen tijd te verspillen aan het testen of combineren van verschillende effecten om een mooie combinatie te vinden.

Aspose.Slides biedt eigenschappen en methoden onder de [EffectFormat](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/)‑klasse die je in staat stellen dezelfde effecten op vormen in PowerPoint‑presentaties toe te passen.

## **Schaduweffect toepassen**

Aspose.Slides voor Java ondersteunt buitenste en binnenste schaduwen voor vormen. Je kunt hun kleur, richting, afstand en vervagingsstraal aanpassen zodat ze bij het ontwerp van je presentatie passen.

### **Buitenste schaduw toepassen**

Gebruik een buitenste schaduw om een kaart of paneel te laten opvallen tegen de slide‑achtergrond. De schaduw strekt zich uit voorbij de randen van de vorm, waardoor de indruk ontstaat dat de vorm boven de slide zweeft. Pas de kleur, richting, afstand en vervagingsstraal aan om overeen te komen met de verlichting en stijl van je sjabloon.

Deze Java‑code laat zien hoe je het [buitenste schaduweffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getOuterShadowEffect--) op een rechthoek toepast:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(new Color(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Schaduweffect](shadow_effect.png)

### **Binnenste schaduw toepassen**

Wanneer je de visuele stijl van een sjabloon wilt reproduceren, gebruik je een binnenste schaduw om een kaart of paneel een verzonken uiterlijk te geven. Een buitenste schaduw strekt zich buiten de vorm uit en laat deze verhoogd lijken, terwijl een binnenste schaduw de binnenkant van de randen donkerder maakt.

Roep [enableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#enableInnerShadowEffect--) aan en configureer vervolgens de schaduw die wordt geretourneerd door [getInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getInnerShadowEffect--). Grotere waarden voor de vervagingsstraal geven zachtere randen.

Dit Java‑voorbeeld maakt een lichtblauwe kaart met een donkergrijze binnenste schaduw en slaat deze op als een PPTX‑bestand. De schaduwrichting is 225 graden, de afstand is 7 punten, en de vervagingsstraal is 6 punten:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(new Color(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Lichtblauwe rechthoek met een binnenste schaduw](inner_shadow_effect.png)

Om de binnenste schaduw te verwijderen, roep je [disableInnerShadowEffect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#disableInnerShadowEffect--) aan op het effectformaat van de vorm.

## **Reflectie‑effect toepassen**

Om een reflectie‑effect toe te passen in Aspose.Slides voor Java, kun je een spiegelachtige reflectie aan vormen toevoegen en parameters zoals afstand, transparantie en grootte aanpassen. Dit effect verbetert de esthetiek van je presentaties door vormen een meer gepolijste en verfijnde uitstraling te geven. Het is eenvoudig te implementeren met eenvoudige code, waardoor snelle toepassing over meerdere elementen voor een consistent ontwerp mogelijk is.

Deze Java‑code laat zien hoe je het [reflectie‑effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getReflectionEffect--) op een vorm toepast:

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

![Reflectie‑effect](reflection_effect.png)

## **Gloed‑effect toepassen**

Om een gloed‑effect op een vorm toe te passen in Aspose.Slides voor Java, kun je een zachte, lumineuze aura rondom vormen toevoegen en eigenschappen zoals kleur en grootte aanpassen. Dit effect helpt vormen op te laten vallen en voegt een aantrekkelijk, in het oog springend visueel element toe aan je presentatie. Het is eenvoudig te implementeren met minimale code, waardoor het algehele uiterlijk van je dia’s wordt verbeterd.

Deze Java‑code laat zien hoe je het [gloed‑effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getGlowEffect--) op een vorm toepast:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Gloed‑effect](glow_effect.png)

## **Zachte randen toepassen**

Om een zacht‑rand‑effect toe te passen in Aspose.Slides voor Java, kun je een soepele, vervaagde overgang rond de randen van een vorm creëren. Dit effect voegt een subtielere en verfijndere uitstraling toe, perfect voor ontwerpen die een zachte, zachtere look nodig hebben. Je kunt eenvoudig parameters zoals de straal aanpassen om het gewenste effect te behalen op verschillende vormen in je presentatie.

Deze Java‑code laat zien hoe je het [zacht‑rand‑effect](https://reference.aspose.com/slides/java/com.aspose.slides/effectformat/#getSoftEdgeEffect--) op een vorm toepast:

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

![Zacht‑rand‑effect](soft_edges_effect.png)

## **Vervagingseffect toepassen**

Gebruik vorm‑vervaging om de vulling en contour van een vorm te verzachten terwijl de vorm bewerkbaar blijft. Roep [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aan op het effectformaat van de vorm. De straal wordt gemeten in punten (1/72 inch): gebruik een niet‑negatieve waarde, waarbij hogere waarden een sterkere vervaging opleveren. Een straal van nul laat het uiterlijk onveranderd.

De [getGrow](https://reference.aspose.com/slides/java/com.aspose.slides/iblur/#getGrow--)‑instelling bepaalt de zichtbare grenzen van het effect. Met `false` wordt de vervaging bijgesneden tot de oorspronkelijke geschilderde grenzen, inclusief de contour. Met `true` kan de vervaging verder reiken dan die grenzen. Geen van beide instellingen verandert de positie of afmetingen van de vorm.

De onderstaande vergelijking gebruikt telkens dezelfde vulling, contour en vormafmetingen. De bovenste rij gebruikt `grow = false`; de onderste rij gebruikt `grow = true`.

![Originele rechthoek vergeleken met vervagingsstraal van 5 en 15 punten, met grow uitgeschakeld en ingeschakeld](shape_blur_comparison.png)

Dit Java‑voorbeeld maakt een oranje rechthoek met een donkerblauwe contour, past een vervaging van 5 punten toe en werkt vervolgens bij naar een vervaging van 15 punten door opnieuw [setBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) aan te roepen. Het slaat beide vervaagde toestanden op, roept daarna [disableBlurEffect](https://reference.aspose.com/slides/java/com.aspose.slides/ieffectformat/#disableBlurEffect--) aan en slaat de vorm zonder vervaging op.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

Vorm‑vervaging beïnvloedt zowel de vulling als de contour tegelijk. Een zacht‑rand‑effect vervaagt de randen van de vorm, terwijl schaduw‑vervaging alleen de schaduw verzacht. Beeldtransformatie‑effecten werken op de beeldinhoud; dit voorbeeld past vervaging rechtstreeks toe op het effectformaat van de vorm zonder de vorm naar een afbeelding te converteren.

## **FAQ**

**Kan ik meerdere effecten op dezelfde vorm toepassen?**

Ja, je kunt verschillende effecten, zoals schaduw, reflectie en gloed, combineren op één vorm om een dynamischere uitstraling te creëren.

**Op welke vormen kan ik effecten toepassen?**

Je kunt effecten toepassen op diverse vormen, waaronder autotekenen, grafieken, tabellen, afbeeldingen, SmartArt‑objecten, OLE‑objecten en meer.

**Kan ik effecten toepassen op gegroepeerde vormen?**

Ja, je kunt effecten toepassen op gegroepeerde vormen. Het effect wordt dan op de gehele groep toegepast.