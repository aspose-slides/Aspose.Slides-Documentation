---
title: Použití animací tvarů v prezentacích pomocí Javy
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/java/shape-animation/
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
- Java
- Aspose.Slides
description: "Objevte, jak vytvořit a přizpůsobit animace tvarů v PowerPoint prezentacích s Aspose.Slides pro Javu. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](https://docs.aspose.com/slides/cs/java/animated-charts/). Dodávají prezentacím či jejich částem život. 

## **Proč používat animace v prezentacích?**

Pomocí animací můžete 

* ovládat tok informací
* zdůraznit důležité body
* zvýšit zájem či zapojení publika
* usnadnit čtení, vstřebání nebo zpracování obsahu
* upoutat pozornost čtenářů či diváků na důležité části v prezentaci

PowerPoint poskytuje mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**. 

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy potřebné pro práci s animacemi v namespace `Aspose.Slides.Animation`,
* Aspose.Slides poskytuje více než **150 animačních efektů** v enumeraci [EffectType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) jako ty používané v PowerPointu.

## **Použití animace na TextBox**

Aspose.Slides pro Java vám umožňuje aplikovat animaci na text ve tvaru. 

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape). 
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape). 
7. Nastavte vlastnost `TextAnimation.BuildType` na hodnotu z enumerace `BuildType`. 
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

    // Přidá animační efekt Fade k tvaru
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje text tvaru podle odstavců 1. úrovně
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Uloží soubor PPTX na disk
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Kromě aplikace animací na text můžete také aplikovat animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph). Viz [**Animated Text**](/slides/cs/java/animated-text/).

{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe) na snímku. 
4. Získejte hlavní sekvenci efektů.
5. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe).
6. Uložte prezentaci na disk jako soubor PPTX.

Tento Java kód ukazuje, jak aplikovat efekt `Fly` na obrázkový rámec:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation();
try {
    // Načte obrázek, který se přidá do kolekce obrázků prezentace
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Přidá obrázkový rámec na snímek
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Přidá animační efekt Fly from Left k obrázkovému rámci
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uloží soubor PPTX na disk
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použití animace na tvar**

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape). 
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape) (když je tento objekt kliknut, animace se přehraje).
5. Vytvořte sekvenci efektů na tvaru bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro přesun k `UserPath`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento Java kód ukazuje, jak aplikovat efekt `PathFootball` (cesta fotbal) na tvar:

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

    // Vytvoří určitou formu "tlačítka".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Vytvoří sekvenci efektů pro toto tlačítko.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Vytvoří vlastní uživatelskou cestu. Náš objekt se přesune až po kliknutí na tlačítko.
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

Následující příklady ukazují, jak použít metodu `getEffectsByShape` z rozhraní [ISequence](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar v normálním snímku**

Dříve jste se naučili, jak přidávat animační efekty do tvarů v prezentacích PowerPoint. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním normálním snímku v prezentaci `AnimExample_out.pptx`.

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

**Příklad 2: Získání všech animačních efektů, včetně těch zděděných ze zástupných objektů**

Pokud má tvar v normálním snímku zástupné objekty umístěné na snímku rozvržení a/nebo hlavním snímku a k těmto zástupným objektům byly přidány animační efekty, pak během prezentace budou přehrány všechny efekty tvaru, včetně těch zděděných ze zástupných objektů.

Předpokládejme, že máme soubor PowerPoint `sample.pptx` s jedním snímkem obsahujícím pouze tvar zápatí s textem „Made with Aspose.Slides“ a na tento tvar byl aplikován efekt **Random Bars**.

![Animace tvaru snímku](slide-shape-animation.png)

Předpokládejme také, že na snímku **layout** byl na zástupný objekt zápatí aplikován efekt **Split**.

![Animace tvaru rozvržení](layout-shape-animation.png)

A konečně, na snímku **master** byl na zástupný objekt zápatí aplikován efekt **Fly In**.

![Animace tvaru hlavního snímku](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `getBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) k přístupu k zástupným objektům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných ze zástupných objektů umístěných na snímcích layout a master.

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

Aspose.Slides pro Java vám umožňuje změnit časové vlastnosti animačního efektu.

![Panel časování animace](shape-animation.png)

Jedná se o odpovídající mapování mezi časováním v PowerPointu a vlastnostmi [Effect.Timing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IEffect#getTiming--):

- Rozbalovací seznam PowerPoint Timing **Start** odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITiming#getTriggerType--).
- PowerPoint Timing **Duration** odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITiming#getDuration--). Délka animace (v sekundách) je celkový čas, který animaci trvá k dokončení jednoho cyklu.
- PowerPoint Timing **Delay** odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITiming#getTriggerDelayTime--).

Takto můžete změnit vlastnosti časování efektu:

1. Použijte ([Apply](#apply-animation-to-shape)) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro požadované vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IEffect#getTiming--).
3. Uložte upravený soubor PPTX.

Tento Java kód demonstruje operaci:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Získá první efekt hlavní sekvence.
    IEffect effect = sequence.get_Item(0);

    // Změní TriggerType efektu na spuštění při kliknutí
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Změní délku trvání efektu
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

Aspose.Slides poskytuje tyto vlastnosti, které vám umožní pracovat se zvuky v animačních efektech: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Přidání zvuku animačního efektu**

Tento Java kód ukazuje, jak přidat zvuk animačního efektu a zastavit ho, když začne další efekt:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Přidá audio do kolekce audio v prezentaci
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = sequence.get_Item(0);

    // Zkontroluje, zda efekt nemá zvuk
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Přidá zvuk pro první efekt
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

1. Vytvořte instance třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte vložený [setSound(IAudio value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) každého animačního efektu. 

Tento Java kód ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
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

Aspose.Slides pro Java vám umožňuje změnit vlastnost After animation animačního efektu.

![Panel po animaci](shape-after-animation.png)

Rozbalovací seznam PowerPoint Effect **After animation** odpovídá těmto vlastnostem: 

- vlastnost [setAfterAnimationType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) popisuje typ po animaci:
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#DoNotDim) (výchozí typ po animaci);
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- vlastnost [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) určuje formát barvy po animaci. Tato vlastnost funguje v kombinaci s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#Color). Pokud typ změníte na jiný, barva po animaci bude vymazána.

Tento Java kód ukazuje, jak změnit efekt po animaci:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Změní typ po animaci na Barvu
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Nastaví barvu po animaci
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Uloží soubor PPTX na disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animovat text**

Aspose.Slides poskytuje tyto vlastnosti, které vám umožní pracovat s blokem *Animate text* animačního efektu:

- vlastnost [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) popisuje typ animace textu efektu. Text tvaru může být animován:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/java/com.aspose.slides/animatetexttype/#AllAtOnce) typ)
  - Po slove ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/java/com.aspose.slides/animatetexttype/#ByWord) typ)
  - Po písmenu ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/animatetexttype/#ByLetter) typ)
- vlastnost [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) nastavuje zpoždění mezi částmi animovaného textu (slovy nebo písmeny). Kladná hodnota určuje procento trvání efektu. Záporná hodnota určuje zpoždění v sekundách.

Takto můžete změnit vlastnosti animace textu:

1. Použijte ([Apply](#apply-animation-to-shape)) nebo získejte animační efekt.
2. Nastavte vlastnost [setBuildType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextanimation/#setBuildType-int-) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/buildtype/#AsOneObject), aby se vypnul režim animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Uložte upravený soubor PPTX.

Tento Java kód demonstruje operaci:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
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

    // Uloží soubor PPTX na disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

### Jak mohu zajistit, že animace budou zachovány při publikaci prezentace na web?

[Export to HTML5](/slides/cs/java/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/) zodpovědné za animace [shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [transition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Čisté HTML nepřehraje animace snímků, zatímco HTML5 ano.

### Jak ovlivňuje změna pořadí z-order (vrstvy) tvarů animaci?

Animace a pořadí kreslení jsou nezávislé: efekt řídí časování a typ zobrazování/skrývání, zatímco [z-order](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getZOrderPosition--) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Jedná se o obecné chování PowerPointu; model efektů a tvarů Aspose.Slides následuje stejnou logiku.)

### Existují omezení při převodu animací na video pro určité efekty?

Obecně jsou [animace podporovány](/slides/cs/java/convert-powerpoint-to-video/), ale v ojedinělých případech nebo u specifických efektů může dojít k odlišnému vykreslení. Doporučuje se testovat s efekty, které používáte, a s verzí knihovny.