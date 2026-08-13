---
title: Převod PowerPoint prezentací na video v Javě
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
- převod videa
- PowerPoint
- Java
- Aspose.Slides
description: "Zjistěte, jak převést PowerPoint prezentace na video v Javě. Objevte ukázkový kód a automatizační techniky pro zefektivnění vašeho pracovního postupu."
---
## **Úvod**

Převodem vaší PowerPoint nebo OpenDocument prezentace na video získáte:

**Zvýšená přístupnost:** Všechna zařízení, bez ohledu na platformu, jsou standardně vybavena video přehrávači, což usnadňuje uživatelům otevírat nebo přehrávat videa ve srovnání s tradičními prezentačními aplikacemi.

**Širší dosah:** Videa vám umožňují oslovit větší publikum a prezentovat informace atraktivnějším způsobem. Průzkumy a statistiky ukazují, že lidé raději sledují a konzumují video obsah než jiné formáty, což činí vaši zprávu účinnější.

{{% alert color="info" %}} 
Možná budete chtít vyzkoušet náš [**PowerPoint do Video online převaděč**](https://products.aspose.app/slides/cs/video), protože je to živá a efektivní implementace procesu popsaného zde.
{{% /alert %}} 

## **PowerPoint na Video převod v Aspose.Slides**

Ve [Aspose.Slides 22.11](https://docs.aspose.com/slides/cs/java/aspose-slides-for-java-22-11-release-notes/) jsme implementovali podporu převodu prezentace na video.

* Použijte **Aspose.Slides** k vygenerování sady snímků (z prezentačních slidů), které odpovídají určitému FPS (snímkům za sekundu)
* Použijte externí nástroj, jako je **ffmpeg** ([pro java](https://github.com/bramp/ffmpeg-cli-wrapper)), k vytvoření videa ze snímků. 

### **Převést PowerPoint na video**

1. Přidejte následující do svého souboru POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Stáhněte ffmpeg [zde](https://ffmpeg.org/download.html).

4. Spusťte Java kód pro převod PowerPointu na video.

Tento Java kód vám ukazuje, jak převést prezentaci (obsahující obrázek a dva animační efekty) na video:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Přidá tvar usmívající se a pak jej animuje
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

    // Nastavte složku binárek ffmpeg. Viz tato stránka: https://github.com/rosenbjerg/FFMpegCore#installation
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

Můžete použít animace na objekty na slidech a používat přechody mezi slidy. 

{{% alert color="info" %}} 
Možná budete chtít zobrazit tyto články: [Animace PowerPoint](https://docs.aspose.com/slides/cs/java/powerpoint-animation/), [Animace tvaru](https://docs.aspose.com/slides/cs/java/shape-animation/), a [Efekt tvaru](https://docs.aspose.com/slides/cs/java/shape-effect/).
{{% /alert %}} 

Animace a přechody činí slideshow atraktivnější a zajímavější — a totéž platí i pro videa. Přidejme další slide a přechod do kódu pro předchozí prezentaci:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    // Přidá tvar úsměvu a animuje jej

    // ...

    // Přidá nový slide a animovaný přechod

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides také podporuje animaci textu. Takže animujeme odstavce na objektech, které se objeví jeden po druhém (se zpožděním nastaveným na jednu sekundu):
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

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

    effect1.getTiming().setTriggerDelayTime(1f);
    effect2.getTiming().setTriggerDelayTime(1f);
    effect3.getTiming().setTriggerDelayTime(1f);

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

Aby vám Aspose.Slides umožnil provádět úkoly převodu PowerPointu na video, poskytuje třídy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationanimationsgenerator/) a [PresentationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationanimationsgenerator/) vám umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) prostřednictvím jeho konstruktoru. Pokud předáte instanci prezentace, použije se `Presentation.SlideSize` a vygeneruje animace, které používá [PresentationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationplayer/).

Když jsou animace vygenerovány, pro každou následnou animaci je vytvořen událost `NewAnimation`, která má parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/). Ten představuje třídu, která reprezentuje přehrávač pro samostatnou animaci.

Pro práci s [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/) se používá vlastnost [Duration](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (celková délka animace) a metoda [SetTimePosition](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Každá pozice animace je nastavena v rozsahu *0 až duration* a poté metoda `getFrame` vrátí [IImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iimage/), který odpovídá stavu animace v daném okamžiku:
```java
import com.aspose.slides.*;

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
            // bitmapa počátečního stavu animace
            animationPlayer.getFrame().save("firstFrame.png", ImageFormat.Png);

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // konečný stav animace
            // poslední snímek animace
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // vygeneruje animace - toto vyvolá výše zpracované události
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Pro přehrání všech animací v prezentaci najednou se používá třída [PresentationPlayer](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationplayer/). Tato třída přijímá instanci [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationanimationsgenerator/) a FPS pro efekty ve svém konstruktoru a poté volá událost `FrameTick` pro všechny animace, aby byly přehrány:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("animated.pptx");
try {
    PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation);
    try {
        PresentationPlayer player = new PresentationPlayer(animationsGenerator, 33);
        try {
            player.setFrameTick((sender, arguments) ->
            {
                arguments.getFrame().save("frame_" + sender.getFrameIndex() + ".png", ImageFormat.Png);
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

Poté mohou být vygenerované snímky zkompilovány do videa. Viz sekce [Převést PowerPoint na video](https://docs.aspose.com/slides/cs/java/convert-powerpoint-to-video/#convert-powerpoint-to-video).

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

**Důraz**:

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

### Je možné převést prezentace chráněné heslem?

Ano, Aspose.Slides umožňuje pracovat s [prezentacemi chráněnými heslem](/slides/cs/java/password-protected-presentation/). Při zpracování takových souborů musíte poskytnout správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

### Podporuje Aspose.Slides použití v cloudových řešeních?

Ano, Aspose.Slides lze integrovat do cloudových aplikací a služeb. Knihovna je navržena tak, aby fungovala v serverových prostředích, což zajišťuje vysoký výkon a škálovatelnost při dávkovém zpracování souborů.

### Existují nějaká omezení velikosti prezentací během převodu?

Aspose.Slides je schopen zpracovat prezentace téměř jakékoli velikosti. Při práci s velmi velkými soubory však může být potřeba více systémových zdrojů a někdy se doporučuje optimalizovat prezentaci pro zlepšení výkonu.