---
title: Převod prezentací PowerPoint na video v Javě
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/java/convert-powerpoint-to-video/
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
- Java
- Aspose.Slides
description: "Zjistěte, jak převést prezentace PowerPoint na video v Javě. Objevte ukázkový kód a automatizační techniky, které zjednoduší váš pracovní postup."
---
## **Úvod**

Převodem vaší prezentace PowerPoint nebo OpenDocument na video získáte:

**Zvýšená přístupnost:** Všechna zařízení, bez ohledu na platformu, jsou standardně vybavena přehrávači videa, což uživatelům usnadňuje otevření nebo přehrání videí ve srovnání s tradičními prezentačními aplikacemi.

**Širší dosah:** Videa vám umožňují oslovit širší publikum a představit informace v poutavějším formátu. Průzkumy a statistiky ukazují, že lidé raději sledují a konzumují video obsah než jiné formy, což činí vaše sdělení účinnějším.

{{% alert color="primary" %}} 

Můžete si vyzkoušet náš [**Online převaděč PowerPoint na video**](https://products.aspose.app/slides/cs/conversion/ppt-to-word), protože se jedná o živou a účinnou implementaci popsaného postupu.

{{% /alert %}} 

## **Převod PowerPoint na video v Aspose.Slides**

V [Aspose.Slides 22.11](https://docs.aspose.com/slides/cs/java/aspose-slides-for-java-22-11-release-notes/), jsme implementovali podporu převodu prezentace na video. 

* Použijte **Aspose.Slides** k vygenerování sady snímků (z prezentačních slidů), které odpovídají určitému FPS (snímky za sekundu)
* Použijte utility třetí strany, jako je **ffmpeg** ([pro java](https://github.com/bramp/ffmpeg-cli-wrapper)), k vytvoření videa na základě snímků. 

### **Převod PowerPoint na video**

1. Přidejte toto do svého souboru POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Stáhněte ffmpeg [zde](https://ffmpeg.org/download.html).

4. Spusťte Java kód pro převod PowerPoint na video.

Ukázkový Java kód vám ukazuje, jak převést prezentaci (obsahující obrázek a dva animační efekty) na video:
```java
Presentation presentation = new Presentation();
try {
    // Přidá tvar se smajlíkem a poté jej animuje
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Nakonfigurujte složku binárek ffmpeg. Viz tato stránka: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Video efekty**

Můžete použít animace na objekty na slidech a použít přechody mezi slidey. 

{{% alert color="primary" %}} 

Můžete si přečíst tyto články: [Animace PowerPoint](https://docs.aspose.com/slides/cs/java/powerpoint-animation/), [Animace tvaru](https://docs.aspose.com/slides/cs/java/shape-animation/), a [Efekt tvaru](https://docs.aspose.com/slides/cs/java/shape-effect/).

{{% /alert %}} 

Animace a přechody dělají prezentace poutavějšími a zajímavějšími – a totéž platí i pro videa. Přidejme další slide a přechod do kódu předchozí prezentace:
```java
// Přidá tvar se smajlíkem a animuje jej

// ...

// Přidá nový snímek a animovaný přechod

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides také podporuje animaci textu. Animujeme tedy odstavce na objektech, které se objeví jeden po druhém (s prodlevou nastavenu na sekundu):
```java
Presentation presentation = new Presentation();
try {
    // Přidá text a animace
    IAutoShape autoShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300);
    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Aspose Slides for Java"));
    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("convert PowerPoint Presentation with text to video"));

    Paragraph para3 = new Paragraph();
    para3.getPortions().add(new Portion("paragraph by paragraph"));
    IParagraphCollection paragraphCollection = autoShape.getTextFrame().getParagraphs();
    paragraphCollection.add(para1);
    paragraphCollection.add(para2);
    paragraphCollection.add(para3);
    paragraphCollection.add(new Paragraph());

    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effect1 = mainSequence.addEffect(para1, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect2 = mainSequence.addEffect(para2, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect3 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
    IEffect effect4 = mainSequence.addEffect(para3, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);
    effect4.getTiming().setTriggerDelayTime(1f);

    final int fps = 33;
    ArrayList<String> frames = new ArrayList<String>();

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try
    {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, fps);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    String frame = String.format("frame_%04d.png", sender.getFrameIndex());
                    arguments.getFrame().save(frame, ImageFormat.Png);
                    frames.add(frame);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }

    // Nakonfigurujte složku binárek ffmpeg. Viz tato stránka: https://github.com/rosenbjerg/FFMpegCore#installation
    FFmpeg ffmpeg = new FFmpeg("path/to/ffmpeg");
    FFprobe ffprobe = new FFprobe("path/to/ffprobe");

    FFmpegBuilder builder = new FFmpegBuilder()
            .addExtraArgs("-start_number", "1")
            .setInput("frame_%04d.png")
            .addOutput("output.avi")
            .setVideoFrameRate(FFmpeg.FPS_24)
            .setFormat("avi")
            .done();

    FFmpegExecutor executor = new FFmpegExecutor(ffmpeg, ffprobe);
    executor.createJob(builder).run();
} catch (IOException e) {
    e.printStackTrace();
}
```

## **Třídy pro převod videa**

Aby vám Aspose.Slides umožnil provádět úlohy převodu PowerPoint na video, poskytuje třídy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationanimationsgenerator/) a [PresentationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationanimationsgenerator/) vám umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) prostřednictvím svého konstruktoru. Pokud předáte instanci prezentace, použije se `Presentation.SlideSize` a generuje animace, které používá [PresentationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationplayer/).

Když jsou animace generovány, pro každou následující animaci je vytvořena událost `NewAnimation`, která má parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/). Poslední představuje třídu, která reprezentuje přehrávač pro samostatnou animaci.

Pro práci s [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/), se používá vlastnost [Duration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (úplná doba animace) a metoda [SetTimePosition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-) . Každá pozice animace je nastavena v rozmezí *0 až doba*, a poté metoda `GetFrame` vrátí BufferedImage, který odpovídá stavu animace v daném okamžiku:
```java
Presentation presentation = new Presentation();
try {
    // Přidá tvar se smajlíkem a animuje jej
    IAutoShape smile = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500);
    ISequence mainSequence = presentation.getSlides().get_Item(0).getTimeline().getMainSequence();
    IEffect effectIn = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious);
    IEffect effectOut = mainSequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious);
    effectIn.getTiming().setDuration(2f);
    effectOut.setPresetClassType(EffectPresetClassType.Exit);

    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        animationsGenerator.setNewAnimation(animationPlayer ->
        {
            System.out.println(String.format("Animation total duration: %f", animationPlayer.getDuration()));
            animationPlayer.setTimePosition(0); // počáteční stav animace
            try {
                // bitmapa počátečního stavu animace
                animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
            animationPlayer.setTimePosition(animationPlayer.getDuration()); // konečný stav animace
            try {
                // poslední snímek animace
                animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aby se všechny animace v prezentaci přehrály najednou, používá se třída [PresentationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationplayer/). Tato třída v konstruktoru přijímá instanci [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationanimationsgenerator/), FPS pro efekty a poté volá událost `FrameTick` pro všechny animace, aby byly přehrány:
```java
Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                try {
                    arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            });
            animationsGenerator.run(presentation.getSlides());
        } finally {
            if (player != null) player.dispose();
        }
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Následně lze vygenerované snímky sestavit do videa. Viz sekce [Convert PowerPoint to Video](https://docs.aspose.com/slides/cs/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Podporované animace a efekty**

**Vstupní**:

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

**Emphasis**:

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

**Exit**:

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

**Motion Paths**:

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

Ano, Aspose.Slides umožňuje pracovat s [prezentacemi chráněnými heslem](/slides/cs/java/password-protected-presentation/). Při zpracování takových souborů musíte poskytnout správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

**Podporuje Aspose.Slides použití v cloudových řešeních?**

Ano, Aspose.Slides lze integrovat do cloudových aplikací a služeb. Knihovna je navržena tak, aby fungovala v serverových prostředích, zajišťuje vysoký výkon a škálovatelnost pro dávkové zpracování souborů.

**Existují při převodu omezení velikosti prezentací?**

Aspose.Slides je schopen zpracovávat prakticky jakékoli velikosti prezentací. Při práci s velmi velkými soubory mohou být vyžadovány další systémové prostředky a někdy se doporučuje prezentaci optimalizovat pro zlepšení výkonu.