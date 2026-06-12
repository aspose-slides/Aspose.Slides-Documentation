---
title: Použití animací tvarů v prezentacích pomocí JavaScriptu
linktitle: Animace tvaru
type: docs
weight: 60
url: /cs/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Objevte, jak vytvářet a přizpůsobovat animace tvarů v prezentacích PowerPoint pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java. Vynikněte!"
---
## **Úvod**

Animace jsou vizuální efekty, které lze použít na texty, obrázky, tvary nebo [grafy](/slides/cs/nodejs-java/animated-charts/). Oživují prezentace nebo jejich součásti.

## **Proč používat animace v prezentacích?**

* řídit tok informací  
* zdůraznit důležité body  
* zvýšit zájem nebo zapojení publika  
* usnadnit čtení, vstřebání nebo zpracování obsahu  
* přitáhnout pozornost čtenářů nebo diváků k důležitým částem v prezentaci  

PowerPoint poskytuje mnoho možností a nástrojů pro animace a animační efekty v kategoriích **vstup**, **odchod**, **zdůraznění** a **cesty pohybu**.

## **Animace v Aspose.Slides**

* Aspose.Slides poskytuje třídy a typy potřebné pro práci s animacemi v namespace `Aspose.Slides.Animation`,
* Aspose.Slides poskytuje více než **150 animačních efektů** v enumeraci [EffectType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effecttype). Tyto efekty jsou v podstatě stejné (nebo ekvivalentní) jako efekty používané v PowerPointu.

## **Použití animace na TextBox**

Aspose.Slides pro Node.js přes Java vám umožňuje použít animaci na text ve tvaru.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape).
4. Přidejte text pomocí [AutoShape.addTextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Získejte hlavní sekvenci efektů.
6. Přidejte animační efekt k [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape).
7. Zavolejte metodu `TextAnimation.setBuildType` s hodnotou z enumerace `BuildType`.
8. Zapíšte prezentaci na disk jako soubor PPTX.

Tento JavaScript kód ukazuje, jak aplikovat efekt `Fade` na AutoShape a nastavit animaci textu na hodnotu *By 1st Level Paragraphs*:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Přidá nový AutoShape s textem
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Získá hlavní sekvenci snímku.
    var sequence = sld.getTimeline().getMainSequence();
    // Přidá efekt animace Fade k tvaru
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Animuje text tvaru podle odstavců první úrovně
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Uloží soubor PPTX na disk
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Kromě aplikace animací na text můžete také aplikovat animace na jednotlivý [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph). Viz [**Animated Text**](/slides/cs/nodejs-java/animated-text/).

{{% /alert %}} 

## **Použití animace na PictureFrame**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte nebo získejte [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe) na snímku.
4. Získejte hlavní sekvenci efektů.
5. Přidejte animační efekt k [PictureFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pictureframe).
6. Zapíšte prezentaci na disk jako soubor PPTX.

Tento JavaScript kód ukazuje, jak aplikovat efekt `Fly` na rámeček obrázku:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
var pres = new aspose.slides.Presentation();
try {
    // Načte obrázek, který bude přidán do kolekce obrázků prezentace
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Přidá rámeček obrázku na snímek
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Získá hlavní sekvenci snímku.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Přidá animační efekt Fly zleva k rámečku obrázku
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Uloží soubor PPTX na disk
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Použití animace na tvar**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte `rectangle` [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape).
4. Přidejte `Bevel` [AutoShape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/autoshape) (když je tento objekt kliknut, spustí se animace).
5. Vytvořte sekvenci efektů na tvaru `Bevel`.
6. Vytvořte vlastní `UserPath`.
7. Přidejte příkazy pro pohyb k `UserPath`.
8. Zapíšte prezentaci na disk jako soubor PPTX.

Tento JavaScript kód ukazuje, jak aplikovat efekt `PathFootball` (cesta football) na tvar:

```javascript
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Vytvoří efekt PathFootball pro existující tvar od začátku.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Přidá animační efekt PathFootball
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Vytvoří nějaký „tlačítko“.
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Vytvoří sekvenci efektů pro toto tlačítko.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Vytvoří vlastní uživatelskou cestu. Náš objekt bude přesunut až po kliknutí na tlačítko.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Přidá příkazy pro pohyb, protože vytvořená cesta je prázdná.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Zapíše soubor PPTX na disk
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Získání animačních efektů aplikovaných na tvar**

Následující příklady ukazují, jak použít metodu `getEffectsByShape` ze třídy [Sequence](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sequence/) k získání všech animačních efektů aplikovaných na tvar.

**Příklad 1: Získání animačních efektů aplikovaných na tvar na běžném snímku**

Dříve jste se naučili, jak přidávat animační efekty do tvarů v prezentacích PowerPoint. Následující ukázkový kód ukazuje, jak získat efekty aplikované na první tvar na prvním běžném snímku v prezentaci `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Získá hlavní animační sekvenci snímku.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Získá první tvar na prvním snímku.
    var shape = firstSlide.getShapes().get_Item(0);

    // Získá animační efekty aplikované na tvar.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Příklad 2: Získání všech animačních efektů, včetně těch zděděných z placeholderů**

Pokud má tvar na běžném snímku placeholdery, které jsou na snímku rozvržení a/nebo masteru, a na těchto placeholderách byly přidány animační efekty, pak budou během promítání přehrány všechny efekty tvaru, včetně těch zděděných z placeholderů.

Předpokládejme, že máme PowerPoint soubor `sample.pptx` s jedním snímkem obsahujícím pouze tvar zápatí s textem „Made with Aspose.Slides“ a na tento tvar byl aplikován efekt **Random Bars**.

![Animace tvaru na snímku](slide-shape-animation.png)

Předpokládejme také, že na placeholder zápatí na **rozvržení** byl aplikován efekt **Split**.

![Animace tvaru v rozvržení](layout-shape-animation.png)

A nakonec, na placeholder zápatí na **masteru** byl aplikován efekt **Fly In**.

![Animace tvaru v masteru](master-shape-animation.png)

Následující ukázkový kód ukazuje, jak použít metodu `getBasePlaceholder` ze třídy [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) k přístupu k placeholderům tvaru a získání animačních efektů aplikovaných na tvar zápatí, včetně těch zděděných z placeholderů umístěných na snímcích rozvržení a masteru.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Získá animační efekty tvaru na běžném snímku.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Získá animační efekty placeholderu na snímku rozvržení.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Získá animační efekty placeholderu na master snímku.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Letět, dole
Type: 134, subtype: 45            // Rozdělit, svisle dovnitř
Type: 126, subtype: 22            // Náhodné pruhy, horizontální
```

## **Změna časových vlastností animačního efektu**

Aspose.Slides pro Node.js přes Java vám umožňuje měnit časové vlastnosti animačního efektu.

Toto je panel časování animace v Microsoft PowerPoint:

![example1_image](shape-animation.png)

Tyto odpovídají mezi PowerPoint Timing a vlastnostmi [Effect.Timing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Effect#getTiming--):

- Rozbalovací seznam PowerPoint Timing **Start** odpovídá vlastnosti [Effect.Timing.TriggerType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Timing#getTriggerType--).
- PowerPoint Timing **Duration** odpovídá vlastnosti [Effect.Timing.Duration](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Timing#getDuration--). Délka animace (v sekundách) je celkový čas, který animace potřebuje k dokončení jednoho cyklu.
- PowerPoint Timing **Delay** odpovídá vlastnosti [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

Takto měníte časové vlastnosti efektu:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte nové hodnoty pro vlastnosti [Effect.Timing](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Effect#getTiming--) podle potřeby.
3. Uložte upravený PPTX soubor.

```javascript
    // Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
    var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
    try {
        // Získá hlavní sekvenci snímku.
        var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
        // Získá první efekt hlavní sekvence.
        var effect = sequence.get_Item(0);
        // Změní TriggerType efektu na spuštění při kliknutí
        effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
        // Změní trvání efektu
        effect.getTiming().setDuration(3.0);
        // Změní TriggerDelayTime efektu
        effect.getTiming().setTriggerDelayTime(0.5);
        // Uloží soubor PPTX na disk
        pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```

## **Zvuk animačního efektu**

Aspose.Slides poskytuje tyto vlastnosti, které vám umožní pracovat se zvuky v animačních efektech:

- metodu [setSound(IAudio value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- metodu [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Přidání zvuku animačního efektu**

Tento JavaScript kód ukazuje, jak přidat zvuk animačního efektu a zastavit ho, když začne další efekt:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Přidá audio do kolekce audia prezentace
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Získá hlavní sekvenci snímku.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Získá první efekt hlavní sekvence
    var firstEffect = sequence.get_Item(0);
    // Zkontroluje efekt na „No Sound“
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Přidá zvuk pro první efekt
        firstEffect.setSound(effectSound);
    }
    // Získá první interaktivní sekvenci snímku.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Nastaví příznak efektu „Stop previous sound“
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Zapíše soubor PPTX na disk
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Extrahování zvuku animačního efektu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/).
2. Získejte odkaz na snímek pomocí jeho indexu. 
3. Získejte hlavní sekvenci efektů. 
4. Extrahujte vložený [setSound(IAudio value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) ke každému animačnímu efektu.

Tento JavaScript kód ukazuje, jak extrahovat zvuk vložený do animačního efektu:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Získá hlavní sekvenci snímku.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Extrahuje zvuk efektu do pole bajtů
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Po animaci**

Aspose.Slides pro Node.js přes Java vám umožňuje měnit vlastnost After animation animačního efektu.

![example1_image](shape-after-animation.png)

Rozbalovací seznam PowerPoint Effect **After animation** odpovídá těmto vlastnostem:

- metodu [setAfterAnimationType(int value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) která popisuje typ po‑animace;
  * PowerPoint **More Colors** odpovídá typu [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** odpovídá typu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (výchozí typ po‑animace);
  * PowerPoint **Hide After Animation** odpovídá typu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** odpovídá typu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- metodu [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) která definuje formát barvy po‑animace. Tato metoda funguje ve spojení s typem [AfterAnimationType.Color](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/afteranimationtype/#Color). Pokud typ změníte na jiný, barva po‑animace bude vymazána.

Tento JavaScript kód ukazuje, jak změnit efekt po‑animace:

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Získá první efekt hlavní sekvence
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Změní typ po‑animace na Barvu
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Nastaví barvu po‑animace při ztlumení
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Zapíše soubor PPTX na disk
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Animovat text**

Aspose.Slides poskytuje tyto vlastnosti, které vám umožní pracovat s blokem *Animate text* animačního efektu:

- metodu [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) která popisuje typ animace textu. Text tvaru lze animovat:
  - Vše najednou ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce));
  - Po slovech ([AnimateTextType.ByWord](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/animatetexttype/#ByWord));
  - Po písmenech ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/animatetexttype/#ByLetter));
- metodu [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) nastavuje prodlevu mezi animovanými částmi textu (slovy nebo písmeny). Kladná hodnota udává procento trvání efektu, záporná hodnota udává prodlevu v sekundách.

Takto můžete změnit vlastnosti Effect Animate text:

1. [Apply](#apply-animation-to-shape) nebo získejte animační efekt.
2. Nastavte metodu [setBuildType(int value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) na hodnotu [BuildType.AsOneObject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/buildtype/#AsOneObject), abyste vypnuli režim animace *By Paragraphs*.
3. Nastavte nové hodnoty pro vlastnosti [setAnimateTextType(int value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) a [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. Uložte upravený PPTX soubor.

```javascript
// Vytvoří instanci třídy prezentace, která představuje soubor prezentace.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Získá první efekt hlavní sekvence
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Změní typ textové animace efektu na "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Změní typ animace textu efektu na "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Nastaví prodlevu mezi slovy na 20 % trvání efektu
    firstEffect.setDelayBetweenTextParts(20.0);
    // Zapíše soubor PPTX na disk
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Jak mohu zajistit, že animace zůstanou zachovány při publikování prezentace na web?**

[Export to HTML5](/slides/cs/nodejs-java/export-to-html5/) a povolte [options](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/) zodpovědné za [shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/setanimateshapes/) a [transition](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/html5options/setanimatetransitions/) animace. Čisté HTML nepřehrává animace snímků, zatímco HTML5 ano.

**Jak změna z‑pořadí (pořadí vrstev) tvarů ovlivňuje animaci?**

Animace a pořadí kreslení jsou nezávislé: efekt řídí časování a typ objevení/zmizení, zatímco [z-order](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/getzorderposition/) určuje, co co překrývá. Viditelný výsledek je definován jejich kombinací. (Toto je obecné chování PowerPointu; model Aspose.Slides pro efekty a tvary následuje stejnou logiku.)

**Existují omezení při konverzi animací do videa pro určité efekty?**

Obecně jsou [animace podporovány](/slides/cs/nodejs-java/convert-powerpoint-to-video/), ale v řadě vzácných případů nebo u specifických efektů může dojít k odlišnému vykreslení. Doporučuje se testovat s efekty, které používáte, a s verzí knihovny.