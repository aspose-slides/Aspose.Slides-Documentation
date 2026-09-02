---
title: Aplicar animações de forma em apresentações no Android
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/androidjava/shape-animation/
keywords:
- forma
- animação
- efeito
- forma animada
- texto animado
- adicionar animação
- obter animação
- extrair animação
- adicionar efeito
- obter efeito
- extrair efeito
- som do efeito
- aplicar animação
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a adicionar, inspecionar e personalizar animações de forma, temporização, sons, comportamento pós-animação e texto animado com Aspose.Slides para Android via Java."
---
## **Visão geral**

Aspose.Slides for Android via Java representa animações de slides como efeitos em uma linha do tempo do slide. Um efeito tem uma forma de destino, um tipo e subtipo de animação, um gatilho, configurações de temporização e propriedades opcionais, como som ou comportamento pós-animação.

A linha do tempo contém dois tipos de sequências:

- A **sequência principal** reproduz‑se à medida que o slide avança.  
- Uma **sequência interativa** inicia quando sua forma gatilho é clicada.

Como caixas de texto, imagens, gráficos, tabelas e outros objetos de slide implementam [IShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/), você usa o mesmo método [ISequence.addEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) para a maioria do conteúdo do slide. Os efeitos disponíveis estão listados na classe [EffectType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effecttype/).

## **Adicionar animações de forma**

Para adicionar uma animação, obtenha a sequência principal do slide e chame [ISequence.addEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) com a forma de destino, tipo de efeito, subtipo e gatilho. Para um efeito que inicia quando outra forma é clicada, crie uma sequência interativa cujo gatilho seja essa outra forma.

O exemplo a seguir cria ambos os tipos de animação e salva o resultado em `shape-animations.pptx`.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

O gatilho controla quando um efeito inicia:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effecttriggertype/#OnClick) aguarda um clique na sequência principal ou um clique na forma gatilho em uma sequência interativa.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) inicia junto ao efeito precedente.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) inicia quando o efeito precedente termina.

Para animar uma imagem, gráfico ou outro tipo de forma, passe esse objeto para [ISequence.addEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) em vez de `targetShape`. Para opções de agrupamento específicas de gráficos, veja [Animated Charts](/slides/pt/androidjava/animated-charts/).

## **Ler animações de forma**

Use [ISequence.getEffectsByShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) quando souber a forma de destino. Para inspecionar cada efeito, enumere a sequência principal e todas as sequências interativas. A enumeração evita assumir que uma sequência contém um efeito no índice `0`.

O exemplo a seguir cria uma forma com efeitos de sequência principal e interativa, obtém os efeitos que têm a forma como alvo e, em seguida, enumera todas as sequências do slide.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Se precisar apenas dos efeitos para uma forma, identifique a forma primeiro por nome, tipo de placeholder ou outra propriedade estável; então chame [ISequence.getEffectsByShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Não presuma que [IShapeCollection.get_Item](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) no índice `0` seja sempre o objeto desejado.

## **Trabalhar com efeitos herdados de placeholders**

Um placeholder em um slide normal pode herdar comportamento de animação do placeholder correspondente em seu slide de layout e no slide mestre. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) devolve esse placeholder pai, ou `null` quando não há pai.

Na apresentação de exemplo a seguir, o rodapé tem **Random Bars** no slide normal, **Split** no slide de layout e **Fly In** no slide mestre.

![Efeito de animação do rodapé no slide normal](slide-shape-animation.png)

![Efeito de animação do placeholder do rodapé no slide de layout](layout-shape-animation.png)

![Efeito de animação do placeholder do rodapé no slide mestre](master-shape-animation.png)

O próximo exemplo usa uma hierarquia de placeholders de uma nova apresentação. Ele adiciona efeitos a um placeholder mestre, a um placeholder de layout e ao placeholder correspondente em um slide normal. Cada chamada a [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) é verificada antes de usar a forma retornada.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Alterar a temporização da animação**

O diálogo **Timing** do PowerPoint corresponde às propriedades de [ITiming](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/).

![Diálogo Timing do PowerPoint para um efeito de animação](shape-animation.png)

- **Start** corresponde a [ITiming.getTriggerType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#getTriggerType--).  
- **Duration** corresponde a [ITiming.getDuration](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#getDuration--), em segundos.  
- **Delay** corresponde a [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), em segundos.  
- **Repeat** corresponde a [ITiming.getRepeatCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), ou [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).  
- **Rewind when done playing** corresponde a [ITiming.getRewind](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#getRewind--).

Este exemplo independente adiciona um efeito, altera sua temporização através do objeto retornado por [ISequence.addEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), e salva o resultado. Manter a referência ao [IEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ieffect/) retornado evita a necessidade de um índice de coleção desnecessário.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Use um modo de repetição intencionalmente. Combinar um contador de repetições com uma flag “until” pode gerar resultados confusos em diferentes visualizadores. Ao alterar os modos de repetição, defina [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) e [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) antes de [ITiming.setRepeatCount](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), pois definir qualquer uma das flags também altera o modo de repetição ativo.

## **Adicionar e extrair sons de animação**

Um efeito de animação pode referenciar áudio incorporado através de [IEffect.getSound](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) indica que o efeito deve interromper o áudio iniciado por um efeito anterior.

### **Adicionar som a um efeito**

O exemplo a seguir espera um arquivo de áudio local chamado `animation-sound.wav`. Ele cria dois efeitos, incorpora esse arquivo como som do primeiro efeito e configura o segundo efeito para interromper o som. Utiliza os objetos retornados por [ISequence.addEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), portanto não é necessário informar índice de sequência.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Extrair sons de efeito incorporados**

O exemplo a seguir espera uma apresentação local nomeada `presentation-with-animation-sounds.pptx`. Ele varre as sequências principal e interativa e grava cada som de efeito incorporado no diretório `extracted-animation-sounds`. A extensão é selecionada a partir do tipo MIME de áudio exposto por [IAudio.getContentType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iaudio/#getContentType--).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Para objetos de áudio grandes, use [IAudio.getStream](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iaudio/#getStream--) e copie o stream para um arquivo ao invés de carregar todo o objeto em um array de bytes.

## **Definir comportamento pós-animação**

A opção **After animation** controla o que acontece com uma forma após o término do seu efeito.

![Diálogo de opções de efeito do PowerPoint mostrando configurações de After animation](shape-after-animation.png)

A classe [AfterAnimationType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/) permite deixar a forma inalterada, mudar sua cor, ocultá‑la após a animação ou ocultá‑la no próximo clique. Quando o tipo for [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/#Color), defina também [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Este exemplo independente cria um efeito, define seu comportamento pós‑animação através do objeto de efeito retornado e salva o resultado.

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Alterar o tipo para algo diferente de [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/afteranimationtype/#Color) limpa a configuração de cor pós‑animação.

## **Animar texto**

A animação de texto possui dois controles relacionados:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/itextanimation/#getBuildType--) controla se os parágrafos aparecem juntos ou por nível de parágrafo.  
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) controla se o texto aparece de uma vez, por palavra ou por letra. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) define o atraso entre palavras ou letras. Um valor positivo é uma porcentagem da duração do efeito; um valor negativo é um atraso em segundos.

O exemplo independente a seguir anima as palavras em uma caixa de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/buildtype/#AsOneObject) desativa a construção parágrafo‑a‑parágrafo, de modo que a configuração de palavra se aplica a todo o quadro de texto.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Para construir uma caixa de texto por parágrafo, defina [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (ou outro nível de parágrafo). Para direcionar um único parágrafo com seu próprio efeito, use a sobrecarga de [ISequence.addEffect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) que aceita um [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/). Consulte [Animated Text](/slides/pt/androidjava/animated-text/) para exemplos ao nível de parágrafo.

## **Exportar e observações de compatibilidade**

- Salvar em PPT ou PPTX preserva o modelo de animação, mas a reprodução final é controlada pelo visualizador da apresentação.  
- PDF e imagens estáticas não reproduzem animações. Use [HTML5 export](/slides/pt/androidjava/export-to-html5/), GIF animado ou [conversão para vídeo](/slides/pt/androidjava/convert-powerpoint-to-video/) quando a saída precisar mostrar movimento.  
- Para HTML5, habilite [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) e, quando necessário, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).  
- A renderização de vídeo suporta muitos efeitos comuns de entrada, ênfase, saída e caminho de movimento, mas nem todo efeito do PowerPoint é suportado. Verifique a página atual de [animações e efeitos suportados](/slides/pt/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) e teste apresentações críticas com a versão do Aspose.Slides que você utiliza.  
- Efeitos personalizados avançados e efeitos importados de outros formatos de apresentação podem ser preservados no arquivo, mas renderizados de forma diferente no PowerPoint, HTML5 ou vídeo. Valide o resultado exportado em vez de confiar apenas no nome do efeito.

## **FAQ**

**Por que uma animação aparece no PowerPoint mas não em um PDF?**

PDF é um formato estático, portanto animações e transições de slide não são reproduzidas. Exporte para HTML5, GIF animado ou vídeo quando o movimento precisar ser mantido.

**Por que um efeito é reproduzido de forma diferente em um vídeo?**

A exportação para vídeo renderiza as animações em vez de armazenar o comportamento original do PowerPoint. Alguns efeitos avançados não são suportados ou são aproximados. Consulte a tabela de efeitos suportados e teste a apresentação real antes de usá‑la em produção.

**Mover uma forma para frente ou para trás altera a ordem da animação?**

Não. A ordem Z controla a sobreposição, enquanto a ordem da sequência e os gatilhos controlam a reprodução da animação. Alterar a linha do tempo é necessário se precisar de uma ordem de reprodução diferente.