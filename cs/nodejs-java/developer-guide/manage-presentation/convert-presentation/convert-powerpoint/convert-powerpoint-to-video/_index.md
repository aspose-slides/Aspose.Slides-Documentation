---
title: Převod PowerPoint prezentací na video v JavaScriptu
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/nodejs-java/convert-powerpoint-to-video/
keywords:
- převést PowerPoint
- převést prezentaci
- převést PPT
- převést PPTX
- PowerPoint na video
- prezentace na video
- PPT na video
- PPTX na video
- PowerPoint na MP4
- prezentace na MP4
- PPT na MP4
- PPTX na MP4
- uložit PPT jako MP4
- uložit PPTX jako MP4
- exportovat PPT do MP4
- exportovat PPTX do MP4
- konverze videa
- PowerPoint
- Node.js
- JavaScript
- Aspose.Slides
description: "Zjistěte, jak převést PowerPoint prezentace na video v JavaScriptu. Objevte ukázkový kód a automatizační techniky pro zefektivnění vašeho pracovního postupu."
---
## **Úvod**

Převodem vaší prezentace PowerPoint na video získáte 

* **Zvýšení dostupnosti:** Všechna zařízení (bez ohledu na platformu) jsou ve výchozím nastavení vybavena video přehrávači na rozdíl od aplikací pro otevírání prezentací, takže uživatelům je snazší otevřít nebo přehrát videa.
* **Větší dosah:** Pomocí videí můžete oslovit široké publikum a cílit na něj s informacemi, které by jinak mohly v prezentaci působit nudně. Většina průzkumů a statistik naznačuje, že lidé sledují a konzumují videa více než jiné formy obsahu a obecně takový obsah preferují.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet náš [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-word), protože jde o živou a efektivní implementaci zde popsaného procesu.
{{% /alert %}} 

## **Převod PowerPoint na video v Aspose.Slides**

Aspose.Slides podporuje převod prezentace na video.

* Použijte **Aspose.Slides** k vygenerování sady snímků (z prezentačních slidů), které odpovídají určitému FPS (snímky za sekundu)
* Použijte utilitu třetí strany jako **ffmpeg** ([pro java](https://github.com/bramp/ffmpeg-cli-wrapper)) k vytvoření videa na základě snímků. 

### **Převod PowerPoint na video**

1. Stáhněte ffmpeg [zde](https://ffmpeg.org/download.html).
2. Spusťte JavaScript kód pro převod PowerPoint na video.

Tento JavaScript kód ukazuje, jak převést prezentaci (obsahující obrázek a dva animační efekty) na video:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Přidá tvar úsměvu a pak jej animuje
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Nakonfigurujte složku binárek ffmpeg. Viz tato stránka: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Video efekty**

Můžete aplikovat animace na objekty na slidech a použít přechody mezi slidy. 

{{% alert color="primary" %}} 
Možná budete chtít zobrazit tyto články: [PowerPoint Animation](https://docs.aspose.com/slides/cs/nodejs-java/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cs/nodejs-java/shape-animation/), a [Shape Effect](https://docs.aspose.com/slides/cs/nodejs-java/shape-effect/).
{{% /alert %}} 

Animace a přechody činí prezentace poutavějšími a zajímavějšími – a totéž platí i pro videa. Přidejme další slide a přechod do kódu pro předchozí prezentaci:
```javascript
// Přidá tvar úsměvu a animuje jej
// ...
// Přidá nový snímek a animovaný přechod
var newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());
newSlide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
newSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
newSlide.getSlideShowTransition().setType(aspose.slides.TransitionType.Push);
```

Aspose.Slides také podporuje animaci textů. Animujeme tedy odstavce na objektech, které se objeví jeden po druhém (s prodlevou nastavenou na jednu sekundu):
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Přidá text a animace
    var autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 120, 300, 300);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Aspose Slides for Node.js via Java"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("convert PowerPoint Presentation with text to video"));
    var para3 = new aspose.slides.Paragraph();
    para3.getPortions().add(new aspose.slides.Portion("paragraph by paragraph"));
    var paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new aspose.slides.Paragraph());
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effect1 = mainSequence.addEffect(para1, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect2 = mainSequence.addEffect(para2, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect3 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    var effect4 = mainSequence.addEffect(para3, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    effect1.getTiming().setTriggerDelayTime(1.0);
    effect2.getTiming().setTriggerDelayTime(1.0);
    effect3.getTiming().setTriggerDelayTime(1.0);
    effect4.getTiming().setTriggerDelayTime(1.0);
    final var fps = 33;
    var frames = java.newInstanceSync("java.util.ArrayList");
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    var frame = java.callStaticMethodSync("java.lang.String", "format", "frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, aspose.slides.ImageFormat.Png);
                    frames.add(frame);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
    // Nakonfigurujte složku binárek ffmpeg. Viz tuto stránku: https://github.com/rosenbjerg/FFMpegCore#installation
    var ffmpeg = java.newInstanceSync("FFmpeg", "path/to/ffmpeg");
    var ffprobe = java.newInstanceSync("FFprobe", "path/to/ffprobe");
    var builder = java.newInstanceSync("FFmpegBuilder").addExtraArgs("-start_number", "1").setInput("frame_%04d.png").addOutput("output.avi").setVideoFrameRate(java.getStaticFieldValue("FFmpeg", "FPS_24")).setFormat("avi").done();
    var executor = java.newInstanceSync("FFmpegExecutor", ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (e) {console.log(e);
    console.log(e);
}
```

## **Třídy pro převod videa**

Aby vám umožnila provádět úlohy převodu PowerPoint na video, poskytuje Aspose.Slides třídy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationanimationsgenerator/) a [PresentationPlayer](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationanimationsgenerator/) vám umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) přes jeho konstruktor. Pokud předáte instanci prezentace, použije se `Presentation.getSlideSize` a generuje animace, které používá [PresentationPlayer](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationplayer/).

Když jsou animace generovány, pro každou následující animaci se vygeneruje událost `NewAnimation`, která má parametr přehrávače animace prezentace. Ten je třída představující přehrávač pro samostatnou animaci.

Pro práci s přehrávačem animace prezentace se používají metody `getDuration` (celková délka animace) a `setTimePosition`. Každá pozice animace je nastavena v rozmezí *0 až duration*, a poté metoda `getFrame` vrátí BufferedImage, který odpovídá stavu animace v daném okamžiku:
```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Přidá úsměvný tvar a animuje jej
    var smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.SmileyFace, 110, 20, 500, 500);
    var mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    var effectIn = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.TopLeft, aspose.slides.EffectTriggerType.AfterPrevious);
    var effectOut = mainSequence.addEffect(smile, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.BottomRight, aspose.slides.EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2.0);
    effectOut.setPresetClassType(aspose.slides.EffectPresetClassType.Exit);
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer -> {
            console.log(java.callStaticMethodSync("java.lang.String", "format", "Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0);// počáteční stav animace
            try {
                // bitmapa počátečního stavu animace
                animationPlayer.getFrame().save("firstFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration());// finální stav animace
            try {
                // poslední snímek animace
                animationPlayer.getFrame().save("lastFrame.png", aspose.slides.ImageFormat.Png);
            } catch (e) {console.log(e);
                throw java.newInstanceSync("java.lang.RuntimeException", e);
            }
        });
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Pro přehrání všech animací v prezentaci najednou se používá třída [PresentationPlayer](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationplayer/). Tato třída přijímá instanci [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationanimationsgenerator/) a FPS pro efekty v konstruktoru a poté volá událost `FrameTick` pro všechny animace, aby se přehrály:
```javascript
var presentation = new aspose.slides.Presentation("animated.pptx");
try {
    var animationsGenerator = new aspose.slides.PresentationAnimationsGenerator(presentation);
    try {
        var player = new aspose.slides.PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) -> {
                try {
                    arguments.getFrame().save(("frame_" + sender.getFrameIndex()) + ".png", aspose.slides.ImageFormat.Png);
                } catch (e) {console.log(e);
                    throw java.newInstanceSync("java.lang.RuntimeException", e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) {
                player.dispose();
            }
        }
    } finally {
        if (animationsGenerator != null) {
            animationsGenerator.dispose();
        }
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Poté lze vygenerované snímky sestavit do videa. Viz sekce [Convert PowerPoint to Video](https://docs.aspose.com/slides/cs/nodejs-java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Podporované animace a efekty**

**Vstup**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly In** | ![supported](v.png) | ![supported](v.png) |
| **Float In** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Wheel** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Grow & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Zdůraznění**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Color Pulse** | ![not supported](x.png) | ![supported](v.png) |
| **Teeter** | ![supported](v.png) | ![supported](v.png) |
| **Spin** | ![supported](v.png) | ![supported](v.png) |
| **Grow/Shrink** | ![not supported](x.png) | ![supported](v.png) |
| **Desaturate** | ![not supported](x.png) | ![supported](v.png) |
| **Darken** | ![not supported](x.png) | ![supported](v.png) |
| **Lighten** | ![not supported](x.png) | ![supported](v.png) |
| **Transparency** | ![not supported](x.png) | ![supported](v.png) |
| **Object Color** | ![not supported](x.png) | ![supported](v.png) |
| **Complementary Color** | ![not supported](x.png) | ![supported](v.png) |
| **Line Color** | ![not supported](x.png) | ![supported](v.png) |
| **Fill Color** | ![not supported](x.png) | ![supported](v.png) |

**Odchod**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![not supported](x.png) | ![supported](v.png) |
| **Fade** | ![supported](v.png) | ![supported](v.png) |
| **Fly Out** | ![supported](v.png) | ![supported](v.png) |
| **Float Out** | ![supported](v.png) | ![supported](v.png) |
| **Split** | ![supported](v.png) | ![supported](v.png) |
| **Wipe** | ![supported](v.png) | ![supported](v.png) |
| **Shape** | ![supported](v.png) | ![supported](v.png) |
| **Random Bars** | ![supported](v.png) | ![supported](v.png) |
| **Shrink & Turn** | ![not supported](x.png) | ![supported](v.png) |
| **Zoom** | ![supported](v.png) | ![supported](v.png) |
| **Swivel** | ![supported](v.png) | ![supported](v.png) |
| **Bounce** | ![supported](v.png) | ![supported](v.png) |

**Cesty pohybu**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Často kladené otázky**

**Je možné převést prezentace chráněné heslem?**

Ano, Aspose.Slides umožňuje pracovat s prezentacemi chráněnými heslem. Při zpracování takových souborů musíte zadat správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

**Podporuje Aspose.Slides použití v cloudových řešeních?**

Ano, Aspose.Slides lze integrovat do cloudových aplikací a služeb. Knihovna je navržena tak, aby fungovala v serverových prostředích, což zajišťuje vysoký výkon a škálovatelnost při hromadném zpracování souborů.

**Existují nějaká omezení velikosti prezentací při převodu?**

Aspose.Slides je schopna zpracovat prezentace téměř jakékoli velikosti. Při práci s velmi velkými soubory však může být potřeba více systémových zdrojů a někdy se doporučuje optimalizovat prezentaci pro zlepšení výkonu.