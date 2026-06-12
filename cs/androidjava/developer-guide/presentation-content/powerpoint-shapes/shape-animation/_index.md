---
title: Aplikace animací tvarů v prezentacích na Androidu
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
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint pomocí Aspose.Slides pro Android v Javě. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](https://docs.aspose.com/slides/cs/androidjava/animated-charts/). Dodávají život prezentacím nebo jejich částem.

## **Proč používat animace v prezentacích?**

* ovládat tok informací
* zdůraznit důležité body
* zvýšit zájem nebo zapojení publika
* usnadnit čtení nebo zpracování obsahu
* upoutat pozornost čtenářů či diváků na důležité části v prezentaci

PowerPoint poskytuje mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **ukončení**, **zdůraznění** a **cesty pohybu**.

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy potřebné pro práci s animacemi v namespace `Aspose.Slides.Animation`,
* Aspose.Slides poskytuje více než **150 animačních efektů** v enumeraci [EffectType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) efektům používaným v PowerPointu.

## **Použití animace na TextBox**

Aspose.Slides pro Android přes Java vám umožňuje použít animaci na text ve tvaru.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape).
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape).
7. Nastavte vlastnost `TextAnimation.BuildType` na hodnotu z enumerace `BuildType`.
8. Uložte prezentaci na disk jako soubor PPTX.

```java
// Instancuje třídu prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidá nový AutoShape s textem
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Získá hlavní sekvenci snímku.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Přidá efekt Fade animace k tvaru
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje text tvaru podle odstavců první úrovně
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Uloží soubor PPTX na disk
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Kromě použití animací na text můžete také použít animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph). Viz [**Animovaný Text**](/slides/cs/androidjava/animated-text/).

{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe) na snímku.
4. Získejte hlavní sekvenci efektů.
5. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pictureframe).
6. Uložte prezentaci na disk jako soubor PPTX.

```java
// Instancuje třídu prezentace, která představuje soubor prezentace.
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

    // Přidá efekt animace Fly zleva k rámečku obrázku
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uloží soubor PPTX na disk
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použití animace na tvar**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2. Získejte referenci na snímek podle jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape).
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iautoshape) (když je tento objekt kliknut, animace se spustí).
5. Vytvořte sekvenci efektů na tvaru Bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro pohyb k `UserPath`.
8. Uložte prezentaci na disk jako soubor PPTX.

```java
// Instancuje třídu Presentation, která představuje soubor PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Vytvoří efekt PathFootball pro existující tvar od nuly.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Přidá animační efekt PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Vytvoří nějaký druh "tlačítka".
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

     // Uloží soubor PPTX na disk
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

**Příklad 2: Získání všech animačních efektů, včetně těch zděděných z placeholderů**

Pokud má tvar na běžném snímku placeholdery, které jsou na snímku rozvržení a/nebo hlavním snímku, a na tyto placeholdery byly přidány animační efekty, pak budou během prezentace přehrány všechny efekty tvaru, včetně těch zděděných z placeholderů.

Předpokládejme, že máme soubor PowerPoint prezentace `sample.pptx` s jedním snímkem, který obsahuje pouze tvar zápatí s textem „Made with Aspose.Slides“ a na tvar je aplikován efekt **Random Bars**.

![Animace tvaru snímku](slide-shape-animation.png)

Předpokládejme také, že efekt **Split** je aplikován na placeholder zápatí na **layout** snímku.

![Animace tvaru layoutu](layout-shape-animation.png)

A nakonec je efekt **Fly In** aplikován na placeholder zápatí na **master** snímku.

![Animace tvaru masteru](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `getBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných z placeholderů umístěných na layoutu a master snímcích.

```java
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
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
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

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Změna časových vlastností animačního efektu**

Aspose.Slides pro Android přes Java vám umožňuje měnit časové vlastnosti animačního efektu.

![Panel časování animace](shape-animation.png)

Jedná se o odpovídající položky mezi časováním PowerPointu a vlastnostmi [Effect.Timing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IEffect#getTiming--):

- Rozbalovací seznam **Start** v časování PowerPointu odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITiming#getTriggerType--).
- Časování PowerPoint **Duration** odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITiming#getDuration--). Délka animace (v sekundách) je celkový čas potřebný k dokončení jednoho cyklu animace.
- Časování PowerPoint **Delay** odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--).

Takto změníte vlastnosti časování efektu:

1. [Použijte](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro požadované vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IEffect#getTiming--).
3. Uložte upravený soubor PPTX.

```java
// Instancuje třídu prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Získá první efekt hlavní sekvence.
    IEffect effect = sequence.get_Item(0);

    // Změní TriggerType efektu na spuštění kliknutím
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

Aspose.Slides poskytuje tyto vlastnosti, které umožňují pracovat se zvuky v animačních efektech: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Přidání zvuku animačního efektu**

Tento Java kód ukazuje, jak přidat zvuk animačního efektu a zastavit jej, když začne další efekt:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Přidá zvuk do kolekce audia prezentace
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

    // Nastaví příznak "Stop previous sound" pro efekt
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Uloží soubor PPTX na disk
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Extrahování zvuku animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/).
2. Získejte referenci na snímek podle jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte vložený [setSound(IAudio value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ke každému animačnímu efektu.

```java
// Instancuje třídu prezentace, která představuje soubor prezentace.
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

Aspose.Slides pro Android přes Java vám umožňuje změnit vlastnost After animation (po animaci) animačního efektu.

![Panel animačního efektu a rozšířené menu v Microsoft PowerPoint](shape-after-animation.png)

Rozbalovací seznam PowerPoint efektu **After animation** odpovídá těmto vlastnostem:

- Vlastnost [setAfterAnimationType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) , která popisuje typ After animation:
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (výchozí typ po animaci);
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Vlastnost [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) , která definuje formát barvy po animaci. Tato vlastnost funguje ve spojení s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/afteranimationtype/#Color). Pokud typ změníte na jiný, barva po animaci bude vymazána.

```java
// Instancuje třídu prezentace, která představuje soubor prezentace
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Změní typ after animation na Color
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

Aspose.Slides poskytuje tyto vlastnosti, které umožňují pracovat s blokem *Animate text* animačního efektu:

- Vlastnost [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) , která popisuje typ animace textu efektu. Text tvaru lze animovat:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) typ)
  - Poslovně ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/animatetexttype/#ByWord) typ)
  - Po písmenu ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/animatetexttype/#ByLetter) typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) nastavuje zpoždění mezi částmi animovaného textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu. Záporná hodnota udává zpoždění v sekundách.

Takto můžete změnit vlastnosti Animate text efektu:

1. [Použijte](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte vlastnost [setBuildType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/buildtype/#AsOneObject) , čímž vypnete režim animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Uložte upravený soubor PPTX.

```java
// Instancuje třídu prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
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

**Jak mohu zajistit, že animace jsou zachovány při publikování prezentace na web?**

[Export do HTML5](/slides/cs/androidjava/export-to-html5/) a povolte [možnosti](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/) odpovědné za animace [shape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [transition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Prostý HTML neumožňuje přehrávat animace snímků, zatímco HTML5 ano.

**Jak ovlivní změna pořadí z (z‑order) vrstev tvarů animaci?**

Animace a pořadí kreslení jsou nezávislé: efekt řídí časování a typ zobrazování/skrývání, zatímco [z-order](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/shape/#getZOrderPosition--) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Jedná se o obecné chování PowerPointu; model efektů a tvarů Aspose.Slides následuje stejnou logiku.)

**Existují omezení při převodu animací na video u některých efektů?**

Obecně jsou [animace podporovány](/slides/cs/androidjava/convert-powerpoint-to-video/), ale v ojedinělých případech nebo u specifických efektů může dojít k odlišnému vykreslení. Doporučuje se testovat s efekty, které používáte, a s konkrétní verzí knihovny.