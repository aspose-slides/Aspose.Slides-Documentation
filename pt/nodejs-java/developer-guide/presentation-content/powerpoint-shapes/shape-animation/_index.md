---
title: Aplicar Animações de Formas em Apresentações Usando JavaScript
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Saiba como adicionar, inspecionar e personalizar animações de forma, temporização, sons, comportamento pós-animação e texto animado com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java representa animações de slide como efeitos em uma linha de tempo de slide. Um efeito tem uma forma de destino, um tipo e subtipo de animação, um gatilho, configurações de cronograma e propriedades opcionais, como som ou comportamento após a animação.

A linha de tempo contém dois tipos de sequências:

- A **sequência principal** reproduz-se à medida que o slide avança.
- Uma **sequência interativa** inicia‑se quando sua forma de gatilho é clicada.

Como caixas de texto, imagens, gráficos, tabelas e outros objetos de slide são objetos [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/), você usa o mesmo método [Sequence.addEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#addEffect) para a maior parte do conteúdo do slide. Os efeitos disponíveis estão listados na enumeração [EffectType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effecttype/).

## **Adicionar animações de forma**

Para adicionar uma animação, obtenha a sequência principal do slide e chame [Sequence.addEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#addEffect) com a forma de destino, tipo de efeito, subtipo e gatilho. Para um efeito que inicia quando outra forma é clicada, crie uma sequência interativa cujo gatilho seja essa outra forma.

O exemplo a seguir cria ambos os tipos de animação e salva o resultado em `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O gatilho controla quando um efeito inicia:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effecttriggertype/#OnClick) aguarda um clique na sequência principal ou um clique na forma de gatilho em uma sequência interativa.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) inicia com o efeito anterior.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) inicia quando o efeito anterior termina.

Para animar uma imagem, gráfico ou outro tipo de forma, passe esse objeto para [Sequence.addEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#addEffect) em vez de `targetShape`. Para opções de agrupamento específicas de gráficos, consulte [Animated Charts](/slides/pt/nodejs-java/animated-charts/).

## **Ler animações de forma**

Use [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#getEffectsByShape) quando souber a forma de destino. Para inspecionar cada efeito, enumere a sequência principal e todas as sequências interativas. A enumeração evita assumir que uma sequência contém um efeito no índice `0`.

O exemplo a seguir cria uma forma com efeitos de sequência principal e interativa, obtém os efeitos que têm a forma como destino e, então, enumera todas as sequências do slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Se precisar apenas dos efeitos de uma forma, identifique a forma por nome, tipo de placeholder ou outra propriedade estável; então chame [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Não presuma que [ShapeCollection.get_Item](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#get_Item) no índice `0` seja sempre o objeto desejado.

## **Trabalhar com efeitos de placeholder herdados**

Um placeholder em um slide normal pode herdar o comportamento de animação do placeholder correspondente no slide de layout e no slide mestre. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getBasePlaceholder) devolve esse placeholder pai, ou `null` quando nenhum pai existe.

Na apresentação de exemplo a seguir, o rodapé tem **Random Bars** no slide normal, **Split** no slide de layout e **Fly In** no slide mestre.

![Efeito de animação de rodapé no slide normal](slide-shape-animation.png)

![Efeito de animação de placeholder de rodapé no slide de layout](layout-shape-animation.png)

![Efeito de animação de placeholder de rodapé no slide mestre](master-shape-animation.png)

O próximo exemplo usa uma hierarquia de placeholders de uma nova apresentação. Ele adiciona efeitos a um placeholder mestre, a um placeholder de layout e ao placeholder correspondente em um slide normal. Cada chamada a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getBasePlaceholder) é verificada antes que a forma retornada seja usada.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alterar temporização da animação**

A caixa de diálogo **Timing** do PowerPoint corresponde às propriedades de [Timing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/).

![Caixa de diálogo de Temporização do PowerPoint para um efeito de animação](shape-animation.png)

- **Start** corresponde a [Timing.getTriggerType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** corresponde a [Timing.getDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getDuration), em segundos.
- **Delay** corresponde a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getTriggerDelayTime), em segundos.
- **Repeat** corresponde a [Timing.getRepeatCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) ou [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** corresponde a [Timing.getRewind](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getRewind).

Este exemplo independente adiciona um efeito, altera sua temporização através do objeto devolvido por [Sequence.addEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#addEffect) e salva o resultado. Manter a referência ao [Effect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/) devolvido evita um índice de coleção desnecessário.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Use um modo de repetição intencionalmente. Combinar uma contagem de repetições com uma flag “until” pode gerar resultados confusos em diferentes visualizadores. Ao mudar os modos de repetição, defina [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) e [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) antes de [Timing.setRepeatCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#setRepeatCount), pois definir qualquer flag também altera o modo de repetição ativo.

## **Adicionar e extrair sons de animação**

Um efeito de animação pode referenciar áudio incorporado através de [Effect.getSound](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#setStopPreviousSound) indica que o efeito deve parar o áudio iniciado por um efeito anterior.

### **Adicionar um som a um efeito**

O exemplo a seguir espera um arquivo de áudio local chamado `animation-sound.wav`. Ele cria dois efeitos, incorpora esse arquivo como som do primeiro efeito e configura o segundo efeito para parar o som. Usa os objetos devolvidos por [Sequence.addEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#addEffect), portanto nenhum índice de sequência é necessário.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Extrair sons de efeito incorporados**

O exemplo a seguir espera uma apresentação local chamada `presentation-with-animation-sounds.pptx`. Ele varre sequências principais e interativas e grava cada som de efeito incorporado no diretório `extracted-animation-sounds`. A extensão é selecionada a partir do tipo MIME de áudio exposto por [Audio.getContentType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Para objetos de áudio grandes, use [Audio.getStream](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/audio/#getStream) e copie o stream para um arquivo em vez de carregar todo o objeto em um array de bytes.

## **Definir comportamento após animação**

A opção **After animation** controla o que acontece com uma forma depois que seu efeito termina.

![Caixa de diálogo de Opções de Efeito do PowerPoint mostrando configurações de Após animação](shape-after-animation.png)

A enumeração [AfterAnimationType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/) oferece deixar a forma inalterada, mudar sua cor, ocultá‑la após a animação ou ocultá‑la no próximo clique. Quando o tipo é [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/#Color), defina também [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Este exemplo independente cria um efeito, define seu comportamento após a animação através do objeto de efeito devolvido e salva o resultado.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Alterar o tipo de [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/afteranimationtype/#Color) limpa a configuração de cor após a animação.

## **Animar texto**

A animação de texto possui dois controles relacionados:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textanimation/#getBuildType) controla se os parágrafos aparecem juntos ou por nível de parágrafo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getAnimateTextType) controla se o texto aparece tudo de uma vez, por palavra ou por letra. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) define o atraso entre palavras ou letras. Um valor positivo é uma porcentagem da duração do efeito; um valor negativo é um atraso em segundos.

O exemplo independente a seguir anima as palavras em uma caixa de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/buildtype/#AsOneObject) desativa a construção parágrafo a parágrafo para que a configuração de palavra se aplique a todo o quadro de texto.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Para construir uma caixa de texto por parágrafo, defina [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (ou outro nível de parágrafo). Para direcionar um único parágrafo com seu próprio efeito, use a sobrecarga de [Sequence.addEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#addEffect) que aceita um [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/). Consulte [Animated Text](/slides/pt/nodejs-java/animated-text/) para exemplos de nível de parágrafo.

## **Exportar e observações de compatibilidade**

- Salvar em PPT ou PPTX preserva o modelo de animação, mas a reprodução final é controlada pelo visualizador da apresentação.
- PDF e imagens estáticas não reproduzem animações. Use a [exportação para HTML5](/slides/pt/nodejs-java/export-to-html5/), GIF animado ou [conversão para vídeo](/slides/pt/nodejs-java/convert-powerpoint-to-video/) quando a saída precisar mostrar movimento.
- Para HTML5, habilite [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/#setAnimateShapes) e, quando necessário, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- A renderização de vídeo suporta muitos efeitos comuns de entrada, ênfase, saída e caminho de movimento, mas nem todo efeito do PowerPoint é suportado. Verifique a página atual de [animações e efeitos suportados](/slides/pt/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) e teste apresentações críticas com a versão do Aspose.Slides que você pretende usar.
- Efeitos personalizados avançados e efeitos importados de outros formatos de apresentação podem ser preservados no arquivo mas renderizados de forma diferente no PowerPoint, HTML5 ou vídeo. Valide o resultado exportado em vez de confiar apenas no nome do efeito.

## **FAQ**

**Por que uma animação aparece no PowerPoint mas não no PDF?**

PDF é um formato estático, portanto animações e transições de slide não são reproduzidas. Exporte para HTML5, GIF animado ou vídeo quando o movimento precisar ser preservado.

**Por que um efeito é reproduzido de forma diferente em um vídeo?**

A exportação para vídeo renderiza as animações em vez de armazenar o comportamento original do PowerPoint. Alguns efeitos avançados não são suportados ou são aproximados. Consulte a tabela de efeitos suportados e teste a apresentação real antes de usá‑la em produção.

**Mover uma forma para frente ou para trás altera a ordem da sua animação?**

Não. A ordem Z da forma controla a sobreposição, enquanto a ordem da sequência e os gatilhos controlam a reprodução da animação. Altere a linha de tempo se precisar de uma ordem de reprodução diferente.