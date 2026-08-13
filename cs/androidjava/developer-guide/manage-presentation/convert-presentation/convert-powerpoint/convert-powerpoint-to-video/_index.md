---
title: Převod prezentací PowerPoint na video na Androidu
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
- konverze videa
- PowerPoint
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak převést prezentace PowerPoint na video v Javě. Objevte ukázkový kód a automatizační techniky pro zefektivnění vašeho pracovního postupu."
---
## **Úvod**

Převodem vaší prezentace PowerPoint na video získáte  

* **Zvýšení dostupnosti:** Všechna zařízení (nezávisle na platformě) mají ve výchozím nastavení video přehrávače, na rozdíl od aplikací pro otevírání prezentací, takže uživatelům je snazší otevřít nebo přehrát videa.  
* **Větší dosah:** Pomocí videí můžete oslovit široké publikum a cílit na ně s informacemi, které by v prezentaci mohly působit nudně. Většina průzkumů a statistik naznačuje, že lidé sledují a konzumují videa více než jiné formy obsahu a obecně takový obsah upřednostňují.

## **Převod PowerPointu na video v Aspose.Slides**

Aspose.Slides podporuje převod prezentací na video.

* Použijte **Aspose.Slides** k vygenerování sady snímků (z prezentace) odpovídajících určitému FPS (snímky za sekundu)  
* Použijte externí nástroj jako **ffmpeg**([for java](https://github.com/bramp/ffmpeg-cli-wrapper)) k vytvoření videa na základě snímků. 

### **Převod PowerPointu na video**

1. Přidejte toto do svého souboru POM:
```xml
   <dependency>
     <groupId>net.bramp.ffmpeg</groupId>
     <artifactId>ffmpeg</artifactId>
     <version>0.7.0</version>
   </dependency>
```

2. Stáhněte ffmpeg [zde](https://ffmpeg.org/download.html).

3. Spusťte Java kód pro převod PowerPointu na video.

Tento Java kód ukazuje, jak převést prezentaci (obsahující obrázek a dva animační efekty) na video:
```java
import com.aspose.slides.*;
import java.io.IOException;
import java.util.ArrayList;

Presentation presentation = new Presentation();
try {
    // Přidá tvar s úsměvem a poté jej animuje
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

    // Nakonfigurujte složku binárek ffmpeg. Viz tato stránka: https://github.com/bramp/ffmpeg-cli-wrapper
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

Můžete aplikovat animace na objekty na snímcích a použít přechody mezi snímky. 

{{% alert color="info" %}} 
Možná budete chtít zobrazit tyto články: [PowerPoint Animation](https://docs.aspose.com/slides/cs/androidjava/powerpoint-animation/), [Shape Animation](https://docs.aspose.com/slides/cs/androidjava/shape-animation/), a [Shape Effect](https://docs.aspose.com/slides/cs/androidjava/shape-effect/).
{{% /alert %}} 

Animace a přechody činí prezentace zajímavějšími a poutavějšími — a totéž platí i pro videa. Přidejme další snímek a přechod do kódu pro předchozí prezentaci:
```java
import com.aspose.slides.*;
import java.awt.Color;

// Prezentace s animovaným tvarem úsměvu vytvořeným výše.
Presentation presentation = new Presentation();
try {
    // Přidá nový snímek a animovaný přechod

    ISlide newSlide = presentation.getSlides().addEmptySlide(presentation.getSlides().get_Item(0).getLayoutSlide());

    newSlide.getBackground().setType(BackgroundType.OwnBackground);

    newSlide.getBackground().getFillFormat().setFillType(FillType.Solid);

    newSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);

    newSlide.getSlideShowTransition().setType(TransitionType.Push);
} finally {
    if (presentation != null) presentation.dispose();
}
```

Aspose.Slides také podporuje animaci pro texty. Takže animujeme odstavce na objektech, které se objeví jeden po druhém (se zpožděním nastaveným na sekundu):
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

    // Nakonfigurujte složku binárek ffmpeg. Viz tato stránka: https://github.com/bramp/ffmpeg-cli-wrapper
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

Aby vám umožnil provádět úlohy převodu PowerPointu na video, poskytuje Aspose.Slides třídy [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationanimationsgenerator/) a [PresentationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationplayer/).

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationanimationsgenerator/) umožňuje nastavit velikost snímku pro video (které bude vytvořeno později) prostřednictvím svého konstruktoru. Pokud předáte instanci prezentace, použije se `Presentation.SlideSize` a vygeneruje animace, které používá PresentationPlayer.

Když jsou animace generovány, pro každou další animaci se vytvoří událost `NewAnimation`, která má parametr [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/). Tento poslední představuje třídu, která slouží jako přehrávač pro samostatnou animaci.

Pro práci s [IPresentationAnimationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/), se používá vlastnost [Duration](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/#getDuration--) (celková délka animace) a metoda [SetTimePosition](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentationanimationplayer/#setTimePosition-double-). Každá pozice animace je nastavena v rozmezí *0 až duration* a poté metoda `getFrame` vrátí [IImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iimage/), která odpovídá stavu animace v daném okamžiku:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Přidá tvar s úsměvem a animuje jej
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

            animationPlayer.setTimePosition(animationPlayer.getDuration()); // koncový stav animace
            // poslední snímek animace
            animationPlayer.getFrame().save("lastFrame.png", ImageFormat.Png);
        });

        // Vygeneruje animace. Vyšší zpětné volání se spustí pro každou z nich.
        animationsGenerator.run(presentation.getSlides());
    } finally {
        if (animationsGenerator != null) animationsGenerator.dispose();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

Pro simultánní přehrání všech animací v prezentaci se používá třída [PresentationPlayer](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationplayer/). Tato třída přijímá v konstruktoru instanci [PresentationAnimationsGenerator](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationanimationsgenerator/) a FPS pro efekty a poté volá událost `FrameTick` pro všechny animace, aby byly přehrány:
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

Pak lze vygenerované snímky zkompilovat do videa. Viz část [Convert PowerPoint to Video](https://docs.aspose.com/slides/cs/androidjava/convert-powerpoint-to-video/#convert-powerpoint-to-video).

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

**Cesty pohybu:**:

| Typ animace | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | ![supported](v.png) | ![supported](v.png) |
| **Arcs** | ![supported](v.png) | ![supported](v.png) |
| **Turns** | ![supported](v.png) | ![supported](v.png) |
| **Shapes** | ![supported](v.png) | ![supported](v.png) |
| **Loops** | ![supported](v.png) | ![supported](v.png) |
| **Custom Path** | ![supported](v.png) | ![supported](v.png) |

## **Často kladené otázky**

### Je možné převádět prezentace chráněné heslem?

Ano, Aspose.Slides umožňuje práci s [prezentacemi chráněnými heslem](/slides/cs/androidjava/password-protected-presentation/). Při zpracování takových souborů je nutné zadat správné heslo, aby knihovna mohla získat přístup k obsahu prezentace.

### Podporuje Aspose.Slides použití v cloudových řešeních?

Ano, Aspose.Slides lze integrovat do cloudových aplikací a služeb. Knihovna je navržena pro provoz v serverových prostředích, což zajišťuje vysoký výkon a škálovatelnost při hromadném zpracování souborů.

### Existují nějaká omezení velikosti prezentací při převodu?

Aspose.Slides dokáže zpracovat prezentace téměř jakékoli velikosti. Při práci s velmi velkými soubory však může být potřeba více systémových zdrojů a někdy se doporučuje prezentaci optimalizovat pro lepší výkon.