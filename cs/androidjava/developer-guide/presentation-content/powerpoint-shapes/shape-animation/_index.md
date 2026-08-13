---
title: Použití animací tvarů v prezentacích na Androidu
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/androidjava/shape-animation/
keywords:
- tvar
- animace
- efekt
- animovaný tvar
- animovaný text
- přidat animaci
- získat animaci
- extrahovat animaci
- přidat efekt
- získat efekt
- extrahovat efekt
- zvuk efektu
- aplikovat animaci
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint s Aspose.Slides pro Android pomocí Javy. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](https://docs.aspose.com/slides/cs/androidjava/animated-charts/). Dodávají prezentacím nebo jejich částem život.

## **Proč používat animace v prezentacích?**

Používáním animací můžete  

* ovládat tok informací  
* zdůraznit důležité body  
* zvýšit zájem nebo zapojení publika  
* usnadnit čtení, vstřebání nebo zpracování obsahu  
* upoutat pozornost čtenářů či diváků na důležité části v prezentaci  

PowerPoint poskytuje mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **ukončení**, **zdůraznění** a **cesty pohybu**.

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy, které potřebujete pro práci s animacemi v prostoru názvů `Aspose.Slides.Animation`,  
* Aspose.Slides poskytuje více než **150 animačních efektů** v enumeraci [EffectType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) efekty používané v PowerPointu.

## **Aplikace animace na TextBox**

Aspose.Slides pro Android přes Java vám umožňuje aplikovat animaci na text ve tvaru.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape).  
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Získejte hlavní sekvenci efektů.  
6. Přidejte animační efekt k [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape).  
7. Nastavte vlastnost `TextAnimation.BuildType` na hodnotu z výčtu `BuildType`.  
8. Uložte prezentaci na disk jako soubor PPTX.  

Tento Java kód ukazuje, jak aplikovat efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidá nový AutoShape s textem
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Získá hlavní sekvenci snímku.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Přidá efekt Fade k tvaru
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje text tvaru podle odstavců první úrovně
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Uloží soubor PPTX na disk
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Kromě aplikace animací na text můžete také aplikovat animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph). Viz [**Animated Text**](/slides/cs/androidjava/animated-text/).

{{% /alert %}} 

## **Aplikace animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe) na snímku.  
4. Získejte hlavní sekvenci efektů.  
5. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe).  
6. Uložte prezentaci na disk jako soubor PPTX.  

Tento Java kód ukazuje, jak aplikovat efekt `Fly` na rámeček obrázku:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation();
try {
    // Načte obrázek, který bude přidán do kolekce obrázků prezentace
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Přidá rámeček obrázku na snímek
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Přidá efekt Fly zleva k rámečku obrázku
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uloží soubor PPTX na disk
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Aplikace animace na tvar**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape).  
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape) (když je tento objekt kliknut, animace se spustí).  
5. Vytvořte sekvenci efektů na tvaru bevel.  
6. Vytvořte vlastní `UserPath`.  
7. Přidejte příkazy pro pohyb k `UserPath`.  
8. Uložte prezentaci na disk jako soubor PPTX.  

Tento Java kód ukazuje, jak aplikovat efekt `PathFootball` (cesta football) na tvar:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Vytvoří efekt PathFootball pro existující tvar od nuly.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Přidá animační efekt PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Vytvoří nějaký „tlačítko“.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Vytvoří sekvenci efektů pro toto tlačítko.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Vytvoří vlastní uživatelskou cestu. Náš objekt bude přesunut až po kliknutí na tlačítko.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Přidá příkazy pro pohyb, protože vytvořená cesta je prázdná.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Zapíše soubor PPTX na disk
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Získání animačních efektů aplikovaných na tvar**

Následující příklady ukazují, jak použít metodu `getEffectsByShape` z rozhraní [ISequence](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar na běžném snímku**

Dříve jste se naučili, jak přidávat animační efekty do tvarů v prezentacích PowerPoint. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním běžném snímku v prezentaci `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Získá hlavní animační sekvenci snímku.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Získá první tvar na prvním snímku.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Získá animační efekty aplikované na tvar.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Příklad 2: Získání všech animačních efektů, včetně těch děděných z placeholderů**

Pokud má tvar na běžném snímku placeholdery, které jsou na rozložení snímku a/nebo hlavním snímku, a na tyto placeholdery byly přidány animační efekty, pak budou během prezentace přehrány všechny efekty tvaru, včetně těch děděných z placeholderů.

Předpokládejme, že máme soubor PowerPoint prezentace `sample.pptx` s jedním snímkem obsahujícím jen tvar zápatí s textem „Made with Aspose.Slides“ a efekt **Random Bars** je aplikován na tento tvar.

![Slide shape animation effect](slide-shape-animation.png)

Také předpokládejme, že efekt **Split** je aplikován na placeholder zápatí na **rozložení** snímku.

![Layout shape animation effect](layout-shape-animation.png)

A nakonec je efekt **Fly In** aplikován na placeholder zápatí na **hlavním** snímku.

![Master shape animation effect](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `getBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch děděných z placeholderů umístěných na rozložení a hlavním snímku.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Změna časových vlastností animačního efektu**

Aspose.Slides pro Android přes Java vám umožňuje měnit časové vlastnosti animačního efektu.

This is the Animation Timing pane in Microsoft PowerPoint:

![example1_image](shape-animation.png)

Jedná se o odpovídající vztahy mezi časováním v PowerPointu a vlastnostmi [Effect.Timing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IEffect#getTiming--) properties:

- Rozbalovací seznam **Start** v časování PowerPointu odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITiming#getTriggerType--) .  
- Časování PowerPoint **Duration** odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITiming#getDuration--) . Délka animace (v sekundách) je celkový čas, který animace potřebuje k dokončení jednoho cyklu.  
- Časování PowerPoint **Delay** odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Takto změníte vlastnosti časování efektu:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.  
2. Nastavte nové hodnoty pro požadované vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IEffect#getTiming--) .  
3. Uložte upravený soubor PPTX.  

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation, která představuje soubor PPTX.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Získá první efekt hlavní sekvence.
    IEffect effect = sequence.get_Item(0);

    // Změní TriggerType efektu na spuštění při kliknutí
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Změní dobu trvání efektu
    effect.getTiming().setDuration(3f);

    // Změní TriggerDelayTime efektu
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Uloží soubor PPTX na disk
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje následující vlastnosti, které vám umožní pracovat se zvuky v animačních efektech: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Přidání zvuku animačního efektu**

Tento Java kód ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Přidá audio do kolekce audia v prezentaci
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = sequence.get_Item(0);

    // Kontroluje efekt na "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Přidá zvuk k prvnímu efektu
        firstEffect.setSound(effectSound);
    }

    // Získá první interaktivní sekvenci snímku.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Nastaví příznak efektu "Stop previous sound"
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Zapíše soubor PPTX na disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extrahování zvuku animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) .  
2. Získejte odkaz na snímek pomocí jeho indexu.  
3. Získejte hlavní sekvenci efektů.  
4. Extrahujte [setSound(IAudio value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) vložený do každého animačního efektu.  

Tento Java kód ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation, která představuje soubor prezentace.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Extrahuje zvuk efektu do pole bajtů
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Po animaci**

Aspose.Slides pro Android přes Java vám umožňuje měnit vlastnost After animation animačního efektu.

This is the Animation Effect pane and extended menu in Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Rozbalovací seznam PowerPoint **After animation** odpovídá těmto vlastnostem: 

- vlastnost [setAfterAnimationType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) , která popisuje typ After animation :
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#Color) ;  
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (výchozí typ after animation) ;  
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;  
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;  
- vlastnost [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) , která definuje formát barvy po animaci. Tato vlastnost funguje ve spojení s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#Color) . Pokud typ změníte na jiný, barva po animaci bude vymazána.  

Tento Java kód ukazuje, jak změnit efekt po animaci:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvoří instanci třídy Presentation, která představuje soubor prezentace
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Změní typ po animaci na Barvu
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Nastaví barvu ztlumení po animaci
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Zapíše soubor PPTX na disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animovat text**

Aspose.Slides poskytuje následující vlastnosti, které vám umožní pracovat s blokem *Animate text* animačního efektu:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) která popisuje typ animovaného textu efektu. Text tvaru může být animován:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) typ)  
  - Podle slova ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/animatetexttype/#ByWord) typ)  
  - Podle písmena ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/animatetexttype/#ByLetter) typ)  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) nastavuje zpoždění mezi částmi animovaného textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu. Záporná hodnota udává zpoždění v sekundách.  

Takto můžete změnit vlastnosti Effect Animate text:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.  
2. Nastavte vlastnost [setBuildType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/buildtype/#AsOneObject) pro vypnutí režimu animace *By Paragraphs*.  
3. Nastavte nové hodnoty pro vlastnosti [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) .  
4. Uložte upravený soubor PPTX.  

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation, která představuje soubor prezentace.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Změní typ textové animace efektu na "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Změní typ animace textu efektu na "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Nastaví zpoždění mezi slovy na 20% trvání efektu
    firstEffect.setDelayBetweenTextParts(20f);

    // Zapíše soubor PPTX na disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Jak zajistit, aby byly animace zachovány při publikování prezentace na web?

[Export to HTML5](/slides/cs/androidjava/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/) , které zajišťují animace [shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [transition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) . Obyčejné HTML nepřehrává animace snímků, zatímco HTML5 ano.

### Jak ovlivní změna z-order (pořadí vrstev) tvarů animaci?

Animace a pořadí kreslení jsou nezávislé: efekt řídí časování a typ objevování/zmizení, zatímco [z-order](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getZOrderPosition--) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Jedná se o obecné chování PowerPointu; model efektů a tvarů Aspose.Slides následuje stejnou logiku.)

### Existují omezení při konverzi animací do videa pro určité efekty?

Obecně jsou [animace podporovány](/slides/cs/androidjava/convert-powerpoint-to-video/), ale vzácné případy nebo specifické efekty mohou být vykresleny odlišně. Doporučuje se otestovat s efekty, které používáte, a s konkrétní verzí knihovny.