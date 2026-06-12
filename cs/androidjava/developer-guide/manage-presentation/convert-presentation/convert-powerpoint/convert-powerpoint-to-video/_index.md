---
title: Převod PowerPoint prezentací na video v Androidu
linktitle: PowerPoint na video
type: docs
weight: 130
url: /cs/androidjava/convert-powerpoint-to-video/
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
- převod videa
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak převést PowerPoint prezentace na video v Javě. Objevte ukázkový kód a automatizační techniky pro zefektivnění vašeho pracovního postupu."
---
## **Úvod**

Převodem vaší PowerPoint prezentace na video získáte 

* **Zvýšení dostupnosti:** Všechna zařízení (bez ohledu na platformu) jsou ve výchozím nastavení vybavena video přehrávači na rozdíl od aplikací pro otevírání prezentací, takže uživatelům je snazší otevřít nebo přehrát videa.
* **Větší dosah:** Pomocí videí můžete oslovit široké publikum a cílit na ně s informacemi, které by v prezentaci mohly působit nudně. Většina průzkumů a statistik naznačuje, že lidé sledují a konzumují videa více než jiné typy obsahu a obecně upřednostňují právě takový obsah.

{{% alert color="primary" %}} 
Možná budete chtít vyzkoušet náš [**PowerPoint to Video Online Converter**](https://products.aspose.app/slides/cs/conversion/ppt-to-word), protože se jedná o živou a efektivní implementaci procesu popsaného zde.
{{% /alert %}} 

## **Převod PowerPoint na video v Aspose.Slides**

Aspose.Slides podporuje převod prezentace na video.

* Použijte **Aspose.Slides** k vygenerování sady snímků (z prezentačních slidů), které odpovídají určitému FPS (snímky za sekundu)
* Použijte nástroj třetí strany, jako je **ffmpeg** ([pro java](https://github.com/bramp/ffmpeg-cli-wrapper)), k vytvoření videa na základě snímků. 

### **Převod PowerPoint na video**

1. Add this to your POM file:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Stáhněte ffmpeg [zde](https://ffmpeg.org/download.html).

4. Spusťte Java kód pro převod PowerPoint na video.

Tento Java kód vám ukazuje, jak převést prezentaci (obsahující obrázek a dva animační efekty) na video:
```java
Presentation presentation = new Presentation();
try {
    // Přidá tvar úsměvu a pak jej animuje
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

    // Nastavte složku binárních souborů ffmpeg. Viz tato stránka: https://github.com/rosenbjerg/FFMpegCore#installation
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

Můžete aplikovat animace na objekty na slidech a použít přechody mezi slidey. 

{{% alert color="primary" %}} 
Možná budete chtít prostudovat tyto články: [PowerPoint Animation](https://docs.aspose.com/slides/cs/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cs/androidjava/shape-animation/), a [Shape Effect](https://docs.aspose.com/slides/cs/androidjava/shape-effect/).
{{% /alert %}} 

Animace a přechody činí prezentace poutavějšími a zajímavějšími – a totéž platí i pro videa. Přidejme další slide a přechod do kódu předchozí prezentace:
```java
// Přidá tvar úsměvu a animuje jej

// ...

// Přidá nový slide a animovaný přechod

ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

newSlide.getBackground().setType(BackgroundType.OwnBackground);

newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

newSlide.getSlideShowTransition().setType(TransitionType.Push);
```

Aspose.Slides také podporuje animaci pro texty. Animujeme tedy odstavce na objektech, které se objeví jeden po druhém (s prodlevou nastavenou na sekundu):
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

## **Třídy pro konverzi videa**

Aby vám umožnila provádět úkoly převodu PowerPoint na video, poskytuje Aspose.Slides třídy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationanimationsgenerator/) a [PresentationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationplayer/) .

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationanimationsgenerator/) vám umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) prostřednictvím svého konstruktoru. Pokud předáte instanci prezentace, použije se `Presentation.SlideSize` a vygeneruje animace, které používá [PresentationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationplayer/) .

Když jsou animace generovány, pro každou další animaci se vygeneruje událost `NewAnimation`, která má parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/). Ten představuje třídu, která reprezentuje přehrávač pro samostatnou animaci.

Pro práci s [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/) se používá vlastnost [Duration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (celková délka animace) a metoda [SetTimePosition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Každá pozice animace je nastavena v rozmezí *0 až duration* a metoda `GetFrame` vrátí BufferedImage, který odpovídá stavu animace v daném okamžiku:
```java
Presentation presentation = new Presentation();
try {
    // Přidá tvar úsměvu a animuje jej
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
                // bitmap počátečního stavu animace
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

Pro přehrání všech animací v prezentaci najednou se používá třída [PresentationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationplayer/). Tato třída v konstruktoru přijímá instanci [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationanimationsgenerator/) a FPS pro efekty a poté volá událost `FrameTick` pro všechny animace, aby byly přehrány:
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

Poté lze generované snímky zkompilovat do videa. Viz sekce [Convert PowerPoint to Video](https://docs.aspose.com/slides/cs/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

## **Podporované animace a efekty**

**Vstup**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Fade** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Fly In** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Float In** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Split** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Wipe** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shape** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Wheel** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Random Bars** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Grow & Turn** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Zoom** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Swivel** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Bounce** | ![podporováno](v.png) | ![podporováno](v.png) |

**Zdůraznění**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Color Pulse** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Teeter** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Spin** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Grow/Shrink** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Desaturate** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Darken** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Lighten** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Transparency** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Object Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Complementary Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Line Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Fill Color** | ![nepodporováno](x.png) | ![podporováno](v.png) |

**Odchod**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Fade** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Fly Out** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Float Out** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Split** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Wipe** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shape** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Random Bars** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shrink & Turn** | ![nepodporováno](x.png) | ![podporováno](v.png) |
| **Zoom** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Swivel** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Bounce** | ![podporováno](v.png) | ![podporováno](v.png) |

**Cesty pohybu**:

| Animation Type | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Arcs** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Turns** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Shapes** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Loops** | ![podporováno](v.png) | ![podporováno](v.png) |
| **Custom Path** | ![podporováno](v.png) | ![podporováno](v.png) |

## **Časté otázky**

**Je možné převádět prezentace chráněné heslem?**

Ano, Aspose.Slides umožňuje práci s [prezentacemi chráněnými heslem](/slides/cs/androidjava/password-protected-presentation/). Při zpracování takových souborů musíte zadat správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

**Podporuje Aspose.Slides použití v cloudových řešeních?**

Ano, Aspose.Slides lze integrovat do cloudových aplikací a služeb. Knihovna je navržena pro provoz v serverových prostředích, zajišťuje vysoký výkon a škálovatelnost pro hromadné zpracování souborů.

**Existují nějaká omezení velikosti prezentací při převodu?**

Aspose.Slides dokáže zpracovat prezentace téměř libovolné velikosti. Při práci s velmi velkými soubory však může být potřeba více systémových prostředků a někdy se doporučuje prezentaci optimalizovat pro zlepšení výkonu.