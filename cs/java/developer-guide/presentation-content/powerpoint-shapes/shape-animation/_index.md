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
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint s Aspose.Slides pro Javu. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](https://docs.aspose.com/slides/cs/java/animated-charts/). Oživují prezentace nebo jejich součásti. 

## **Proč používat animace v prezentacích?**

Používáním animací můžete 

* řídit tok informací
* zdůraznit důležité body
* zvýšit zájem či zapojení publika
* usnadnit čtení, vstřebání nebo zpracování obsahu
* upoutat pozornost čtenářů či diváků na důležité části v prezentaci

PowerPoint nabízí mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**. 

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy potřebné pro práci s animacemi v namespace `Aspose.Slides.Animation`,
* Aspose.Slides nabízí více než **150 animačních efektů** v enumeraci [EffectType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) jako efekty používané v PowerPointu.

## **Použití animace na TextBoxu**

Aspose.Slides pro Java umožňuje použít animaci na text ve tvaru. 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape). 
4. Přidejte text do [IAutoShape.TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt na [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape). 
7. Nastavte vlastnost `TextAnimation.BuildType` na hodnotu z enumerace `BuildType`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento Java kód ukazuje, jak použít efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```java
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

    // Přidá efekt animace Fade k tvaru
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

Kromě aplikace animací na text můžete také aplikovat animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph). Viz [**Animated Text**](/slides/cs/java/animated-text/).

{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe) na snímku. 
4. Získejte hlavní sekvenci efektů.
5. Přidejte animační efekt na [PictureFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pictureframe).
6. Uložte prezentaci na disk jako soubor PPTX.

Tento Java kód ukazuje, jak použít efekt `Fly` na picture frame:

```java
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation();
try {
    // Načte obrázek, který bude přidán do kolekce obrázků v prezentaci
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

    // Přidá animační efekt Fly zleva k rámečku obrázku
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Uloží soubor PPTX na disk
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použití animace na tvar**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape). 
4. Přidejte `Bevel` [IAutoShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iautoshape) (když je tento objekt kliknut, spustí se animace).
5. Vytvořte sekvenci efektů na tvaru Bevel.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro pohyb k `UserPath`.
8. Uložte prezentaci na disk jako soubor PPTX.

Tento Java kód ukazuje, jak použít efekt `PathFootball` (path football) na tvar:

```java
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

    // Vytvoří jakýsi "tlačítko".
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

Následující příklady ukazují, jak použít metodu `getEffectsByShape` z rozhraní [ISequence](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar na normálním snímku**

Dříve jste se naučili, jak přidávat animační efekty na tvary v prezentacích PowerPoint. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním normálním snímku v prezentaci `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Získá hlavní sekvenci animací snímku.
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

Pokud má tvar na normálním snímku zástupné objekty, které jsou na rozložení snímku a/nebo na hlavním snímku, a byly k těmto zástupným objektům přidány animační efekty, potom budou během prezentace přehrány všechny efekty tvaru, včetně těch zděděných ze zástupných objektů.

Řekněme, že máme soubor prezentace PowerPoint `sample.pptx` s jedním snímkem obsahujícím pouze tvar zápatí s textem „Made with Aspose.Slides“ a na tvar je aplikován efekt **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Předpokládejme také, že efekt **Split** je aplikován na zástupný objekt zápatí na **rozložení** snímku.

![Layout shape animation effect](layout-shape-animation.png)

A nakonec je efekt **Fly In** aplikován na zástupný objekt zápatí na **hlavním** snímku.

![Master shape animation effect](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `getBasePlaceholder` z rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) k přístupu k zástupným objektům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných ze zástupných objektů umístěných na rozložení a hlavním snímku.

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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Změna časových vlastností animačního efektu**

Aspose.Slides pro Java umožňuje měnit časové vlastnosti animačního efektu.

Toto je panel Animation Timing v Microsoft PowerPoint:

![example1_image](shape-animation.png)

Tyto jsou odpovídající položky mezi PowerPoint Timing a vlastnostmi [Effect.Timing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IEffect#getTiming--):

- Rozbalovací seznam **Start** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITiming#getTriggerType--). 
- Rozbalovací seznam **Duration** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITiming#getDuration--). Délka animace (v sekundách) je celkový čas potřebný k dokončení jednoho cyklu animace. 
- Rozbalovací seznam **Delay** v PowerPoint Timing odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Takto změníte vlastnosti Effect Timing:

1. [Použijte](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IEffect#getTiming--) , které potřebujete. 
3. Uložte upravený soubor PPTX.

```java
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Získá hlavní sekvenci snímku.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Získá první efekt hlavní sekvence.
    IEffect effect = sequence.get_Item(0);

    // Změní TriggerType efektu na spuštění po kliknutí
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Změní Duration efektu
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

Aspose.Slides poskytuje následující vlastnosti, které umožňují pracovat se zvuky v animačních efektech: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Přidání zvuku animačního efektu**

Tento Java kód ukazuje, jak přidat zvuk animačního efektu a zastavit ho, když začne další efekt:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Přidá audio do kolekce audia prezentace
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá hlavní sekvenci snímku.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = sequence.get_Item(0);

    // Kontroluje, zda efekt nemá žádný zvuk
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

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) .
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte vložený [setSound(IAudio value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) ke každému animačnímu efektu. 

Tento Java kód ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```java
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

Aspose.Slides pro Java umožňuje měnit vlastnost After animation animačního efektu.

![example1_image](shape-after-animation.png)

Rozbalovací seznam **After animation** v PowerPointu odpovídá těmto vlastnostem: 

- vlastnost [setAfterAnimationType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) , která popisuje typ After animation :
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#DoNotDim) (výchozí typ po animaci);
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- vlastnost [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) , která určuje formát barvy po animaci. Tato vlastnost spolupracuje s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/java/com.aspose.slides/afteranimationtype/#Color). Pokud typ změníte na jiný, barva po animaci bude vymazána.

Tento Java kód ukazuje, jak změnit efekt po animaci:

```java
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Změní typ po animaci na Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Nastaví barvu po animaci
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Zapíše soubor PPTX na disk
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animovat text**

Aspose.Slides poskytuje následující vlastnosti, které umožňují pracovat s blokem *Animate text* animačního efektu:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) který popisuje typ animace textu efektu. Text tvaru může být animován:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/java/com.aspose.slides/animatetexttype/#AllAtOnce) typ)
  - Po slově ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/java/com.aspose.slides/animatetexttype/#ByWord) typ)
  - Po písmeni ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/animatetexttype/#ByLetter) typ)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) nastavuje prodlevu mezi částmi animovaného textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu. Záporná hodnota udává prodlevu v sekundách.

Takto můžete změnit vlastnosti Effect Animate text:

1. [Použijte](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte vlastnost [setBuildType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextanimation/#setBuildType-int-) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/buildtype/#AsOneObject), aby se vypnul režim animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Uložte upravený soubor PPTX.

```java
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Získá první efekt hlavní sekvence
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Změní typ animace textu efektu na "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Změní typ animace textu efektu na "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Nastaví prodlevu mezi slovy na 20% trvání efektu
    firstEffect.setDelayBetweenTextParts(20f);

    // Zapíše soubor PPTX na disk
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Jak mohu zajistit, že animace budou zachovány při publikování prezentace na web?**

[Export to HTML5](/slides/cs/java/export-to-html5/) a povolte [možnosti](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/) zodpovědné za animace [shape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) a [transition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). Běžné HTML nepřehrává animace snímků, zatímco HTML5 ano.

**Jak změna z-řazení (pořadí vrstev) tvarů ovlivňuje animaci?**

Animace a pořadí kreslení jsou nezávislé: efekt řídí časování a typ zobrazování/skrývání, zatímco [z-order](https://reference.aspose.com/slides/cs/java/com.aspose.slides/shape/#getZOrderPosition--) určuje, co co zakrývá. Viditelný výsledek je definován jejich kombinací. (Jedná se o obecné chování PowerPointu; model efektů a tvarů Aspose.Slides následuje stejnou logiku.)

**Existují omezení při konverzi animací do videa pro určité efekty?**

Obecně jsou [animace podporovány](/slides/cs/java/convert-powerpoint-to-video/), ale ve vzácných případech nebo u specifických efektů může dojít k odlišnému vykreslení. Doporučujeme otestovat použité efekty a verzi knihovny.