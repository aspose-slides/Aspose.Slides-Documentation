---
title: Aplicar Animações de Forma em Apresentações Usando Python via Java
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/python-java/shape-animation/
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
- Python
- Java
- Aspose.Slides
description: "Aprenda como adicionar, inspecionar e personalizar animações de forma, temporização, sons, comportamento pós-animação e texto animado com Aspose.Slides para Python via Java."
---
## **Visão geral**

Aspose.Slides for Python via Java representa as animações de slides como efeitos em uma linha de tempo de slide. Um efeito tem uma forma de destino, um tipo e subtipo de animação, um disparador, configurações de tempo e propriedades opcionais como som ou comportamento pós-animação.

A linha de tempo contém dois tipos de sequências:

- A **sequência principal** reproduz à medida que o slide avança.
- Uma **sequência interativa** inicia quando sua forma de disparo é clicada.

Como caixas de texto, imagens, gráficos, tabelas e outros objetos de slide derivam de [Shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/), você usa o mesmo método [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect) para a maioria do conteúdo do slide. Os efeitos disponíveis são listados na classe [EffectType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effecttype/).

## **Adicionar animações de forma**

Para adicionar uma animação, obtenha a sequência principal do slide e chame [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect) com a forma de destino, o tipo de efeito, subtipo e disparador. Para um efeito que inicia quando outra forma é clicada, crie uma sequência interativa cujo disparador seja essa outra forma.

O exemplo a seguir cria ambos os tipos de animação e salva o resultado em `shape-animations.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    target_shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Click to animate this shape")

    main_sequence = slide.getTimeline().getMainSequence()
    entrance_effect = main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    entrance_effect.getTiming().setDuration(1.5)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    presentation.save("shape-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O disparador controla quando um efeito inicia:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effecttriggertype/#OnClick) aguarda um clique na sequência principal ou um clique na forma de disparo em uma sequência interativa.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effecttriggertype/#WithPrevious) inicia com o efeito anterior.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effecttriggertype/#AfterPrevious) inicia quando o efeito anterior termina.

Para animar uma imagem, gráfico ou outro tipo de forma, passe esse objeto para [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect) em vez de `target_shape`. Para opções de agrupamento específicas de gráficos, consulte [Animated Charts](/slides/pt/python-java/animated-charts/).

## **Ler animações de forma**

Use [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#getEffectsByShape) quando você souber a forma de destino. Para inspecionar cada efeito, enumere a sequência principal e cada sequência interativa. A enumeração evita assumir que uma sequência contém um efeito no índice `0`.

O exemplo a seguir cria uma forma com efeitos de sequência principal e interativa, obtém os efeitos que têm a forma como destino e então enumera cada sequência no slide.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, ShapeType

def print_sequence(label, sequence):
    print(f"  {label}: {sequence.getCount()} effect(s)")
    for effect in sequence:
        target_shape = effect.getTargetShape()
        target_name = "unknown" if target_shape is None else target_shape.getName()
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        trigger_name = EffectTriggerType.getName(EffectTriggerType.class_, effect.getTiming().getTriggerType())
        effect_description = f"{type_name} {subtype_name}; target: {target_name}; trigger: {trigger_name}"
        print(f"    {effect_description}")


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    target_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    target_shape.addTextFrame("Animated shape")

    main_sequence = slide.getTimeline().getMainSequence()
    main_sequence.addEffect(target_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    trigger_shape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40)
    trigger_shape.addTextFrame("Move")

    interactive_sequence = slide.getTimeline().getInteractiveSequences().add(trigger_shape)
    interactive_sequence.addEffect(target_shape, EffectType.PathFootball, EffectSubtype.None_, EffectTriggerType.OnClick)

    target_effects = main_sequence.getEffectsByShape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.getName()}.")
    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.getTimeline().getInteractiveSequences(), start=1):
        trigger_shape = sequence.getTriggerShape()
        trigger_name = "unknown" if trigger_shape is None else trigger_shape.getName()
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
finally:
    presentation.dispose()
```

Se você precisar apenas dos efeitos para uma forma, primeiro identifique a forma por nome, tipo de placeholder ou outra propriedade estável; então chame [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#getEffectsByShape). Não presuma que [ShapeCollection.get_Item](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#get_Item) no índice `0` seja sempre o objeto pretendido.

## **Trabalhar com efeitos de placeholder herdados**

Um placeholder em um slide normal pode herdar o comportamento de animação do placeholder correspondente em seu slide de layout e slide mestre. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getBasePlaceholder) retorna esse placeholder pai, ou `None` quando nenhum pai existe.

Na apresentação de exemplo a seguir, o rodapé tem **Random Bars** no slide normal, **Split** no slide de layout e **Fly In** no slide mestre.

![Efeito de animação de rodapé no slide normal](slide-shape-animation.png)

![Efeito de animação de placeholder de rodapé no slide de layout](layout-shape-animation.png)

![Efeito de animação de placeholder de rodapé no slide mestre](master-shape-animation.png)

O próximo exemplo usa uma hierarquia de placeholders de uma nova apresentação. Ele adiciona efeitos a um placeholder mestre, a um placeholder de layout e ao placeholder correspondente em um slide normal. Cada chamada a [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getBasePlaceholder) é verificada antes que a forma retornada seja usada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, SlideLayoutType

def find_placeholder_with_base(slide, expected_base=None):
    for shape in slide.getShapes():
        base_placeholder = shape.getBasePlaceholder()
        if base_placeholder is not None and (expected_base is None or base_placeholder == expected_base):
            return shape
    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")
    for effect in effects:
        type_name = EffectType.getName(EffectType.class_, effect.getType())
        subtype_name = EffectSubtype.getName(EffectSubtype.class_, effect.getSubtype())
        print(f"  {type_name} {subtype_name}")


presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)
    layout_placeholder = find_placeholder_with_base(layout_slide) if layout_slide is not None else None
    if layout_placeholder is None:
        print("The layout slide does not contain a placeholder linked to its master slide.")
    else:
        master_placeholder = layout_placeholder.getBasePlaceholder()
        layout_slide.getMasterSlide().getTimeline().getMainSequence().addEffect(master_placeholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick)
        layout_slide.getTimeline().getMainSequence().addEffect(layout_placeholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick)

        slide = presentation.getSlides().addEmptySlide(layout_slide)
        slide_placeholder = find_placeholder_with_base(slide, layout_placeholder)
        if slide_placeholder is None:
            print("The slide does not contain a placeholder linked to its layout slide.")
        else:
            slide.getTimeline().getMainSequence().addEffect(slide_placeholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick)
            slide_effects = slide.getTimeline().getMainSequence().getEffectsByShape(slide_placeholder)
            print_effects("Normal slide", slide_effects)

            base_layout_placeholder = slide_placeholder.getBasePlaceholder()
            if base_layout_placeholder is not None:
                layout_effects = layout_slide.getTimeline().getMainSequence().getEffectsByShape(base_layout_placeholder)
                print_effects("Layout slide", layout_effects)

                base_master_placeholder = base_layout_placeholder.getBasePlaceholder()
                if base_master_placeholder is not None:
                    master_effects = layout_slide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(base_master_placeholder)
                    print_effects("Master slide", master_effects)

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Alterar o tempo da animação**

A caixa de diálogo **Timing** do PowerPoint corresponde às propriedades de [Timing](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/).

![Caixa de diálogo Timing do PowerPoint para um efeito de animação](shape-animation.png)

- **Início** corresponde a [Timing.getTriggerType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getTriggerType).
- **Duração** corresponde a [Timing.getDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getDuration), em segundos.
- **Atraso** corresponde a [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getTriggerDelayTime), em segundos.
- **Repetir** corresponde a [Timing.getRepeatCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getRepeatUntilNextClick), ou [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Retroceder ao terminar a reprodução** corresponde a [Timing.getRewind](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getRewind).

Este exemplo independente adiciona um efeito, altera seu tempo por meio do objeto retornado por [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect), e salva o resultado. Manter a referência ao [Effect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/) retornado evita um índice de coleção desnecessário.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Timed animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick)
    effect.getTiming().setDuration(2.0)
    effect.getTiming().setTriggerDelayTime(0.5)
    effect.getTiming().setRepeatUntilNextClick(False)
    effect.getTiming().setRepeatUntilEndSlide(False)
    effect.getTiming().setRepeatCount(2.0)
    effect.getTiming().setRewind(True)

    presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Use intencionalmente um único modo de repetição. Combinar uma contagem de repetição com um sinalizador "até" pode produzir resultados confusos em diferentes visualizadores. Ao alterar os modos de repetição, defina [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#setRepeatUntilNextClick) e [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#setRepeatUntilEndSlide) antes de [Timing.setRepeatCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#setRepeatCount), pois definir qualquer um dos sinalizadores também altera o modo de repetição ativo.

## **Adicionar e extrair sons de animação**

Um efeito de animação pode referenciar áudio incorporado através de [Effect.getSound](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#setStopPreviousSound) indica que um efeito deve parar o áudio iniciado por um efeito anterior.

### **Adicionar um som a um efeito**

O exemplo a seguir espera um arquivo de áudio local chamado `animation-sound.wav`. Ele cria dois efeitos, incorpora esse arquivo como som para o primeiro efeito e configura o segundo efeito para parar o som. Ele usa os objetos retornados por [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect), portanto nenhum índice de sequência é necessário.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpage.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from pathlib import Path

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    first_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80)
    second_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80)
    first_shape.addTextFrame("Starts sound")
    second_shape.addTextFrame("Stops sound")

    sequence = slide.getTimeline().getMainSequence()
    first_effect = sequence.addEffect(first_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    second_effect = sequence.addEffect(second_shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)

    audio_data = Path("animation-sound.wav").read_bytes()
    effect_sound = presentation.getAudios().addAudio(jpype.JArray(jpype.JByte)(audio_data))
    first_effect.setSound(effect_sound)
    second_effect.setStopPreviousSound(True)

    presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Extrair sons incorporados de efeitos**

O exemplo a seguir espera uma apresentação local chamada `presentation-with-animation-sounds.pptx`. Ele verifica tanto as sequências principais quanto as interativas e grava cada som de efeito incorporado no diretório `extracted-animation-sounds`. A extensão é selecionada a partir do tipo MIME de áudio exposto por [Audio.getContentType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audio/#getContentType).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from pathlib import Path

def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else str(content_type).lower()
    if normalized_type == "audio/mpeg":
        return ".mp3"
    if normalized_type == "audio/mp4":
        return ".m4a"
    if normalized_type == "audio/ogg":
        return ".ogg"
    if normalized_type in ("audio/wav", "audio/x-wav"):
        return ".wav"
    return ".bin"


def save_sounds(sequence, output_directory, sound_index):
    for effect in sequence:
        sound = effect.getSound()
        if sound is None:
            continue
        extension = get_audio_extension(sound.getContentType())
        output_path = output_directory / f"effect-sound-{sound_index}{extension}"
        audio_data = bytes(sound.getBinaryData())
        output_path.write_bytes(audio_data)
        sound_index += 1
    return sound_index


input_path = Path("presentation-with-animation-sounds.pptx")
output_directory = Path("extracted-animation-sounds")
output_directory.mkdir(parents=True, exist_ok=True)

presentation = Presentation(str(input_path))
try:
    sound_index = 1
    for slide in presentation.getSlides():
        sound_index = save_sounds(slide.getTimeline().getMainSequence(), output_directory, sound_index)
        for sequence in slide.getTimeline().getInteractiveSequences():
            sound_index = save_sounds(sequence, output_directory, sound_index)
    print(f"Extracted {sound_index - 1} sound file(s) to {output_directory.resolve()}.")
finally:
    presentation.dispose()
```

Para objetos de áudio grandes, use [Audio.getStream](https://reference.aspose.com/slides/pt/python-java/aspose.slides/audio/#getStream) e copie o fluxo para um arquivo em vez de carregar o objeto inteiro em um array de bytes.

## **Definir comportamento pós-animação**

A opção **After animation** controla o que acontece com uma forma após seu efeito terminar.

![Caixa de diálogo Opções de efeito do PowerPoint mostrando configurações de After animation](shape-after-animation.png)

A classe [AfterAnimationType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/afteranimationtype/) suporta deixar a forma inalterada, mudar sua cor, ocultá‑la após a animação ou ocultá‑la no próximo clique. Quando o tipo for [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/python-java/aspose.slides/afteranimationtype/#Color), defina também [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getAfterAnimationColor).

Este exemplo independente cria um efeito, define seu comportamento pós-animação através do objeto de efeito retornado e salva o resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AfterAnimationType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80)
    shape.addTextFrame("Dim after animation")

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.setAfterAnimationType(AfterAnimationType.Color)
    effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY)

    presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Alterar o tipo de [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/python-java/aspose.slides/afteranimationtype/#Color) limpa a configuração de cor pós-animação.

## **Animar texto**

A animação de texto tem dois controles relacionados:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/textanimation/#getBuildType) controla se os parágrafos aparecem juntos ou por nível de parágrafo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getAnimateTextType) controla se o texto aparece de uma vez, por palavra ou por letra. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getDelayBetweenTextParts) define o atraso entre palavras ou letras. Um valor positivo é uma porcentagem da duração do efeito; um valor negativo é um atraso em segundos.

O exemplo independente a seguir anima as palavras em uma caixa de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/python-java/aspose.slides/buildtype/#AsOneObject) desativa a construção parágrafo a parágrafo para que a configuração de palavra se aplique a toda a caixa de texto.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AnimateTextType, BuildType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100)
    text_box.addTextFrame("Aspose.Slides animates this sentence word by word.")

    effect = slide.getTimeline().getMainSequence().addEffect(text_box, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getTextAnimation().setBuildType(BuildType.AsOneObject)
    effect.setAnimateTextType(AnimateTextType.ByWord)
    effect.setDelayBetweenTextParts(20.0)

    presentation.save("animated-text.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Para construir uma caixa de texto por parágrafo, defina [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pt/python-java/aspose.slides/buildtype/#ByLevelParagraphs1) (ou outro nível de parágrafo). Para direcionar um único parágrafo com seu próprio efeito, use a sobrecarga de [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect) que aceita um [Paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/paragraph/). Consulte [Animated Text](/slides/pt/python-java/animated-text/) para exemplos em nível de parágrafo.

## **Exportar e notas de compatibilidade**

- Salvar em PPT ou PPTX preserva o modelo de animação, mas a reprodução final é controlada pelo visualizador da apresentação.
- PDF e imagens estáticas não reproduzem animações. Use [HTML5 export](/slides/pt/python-java/export-to-html5/), GIF animado ou [video conversion](/slides/pt/python-java/convert-powerpoint-to-video/) quando a saída precisar mostrar movimento.
- Para HTML5, habilite [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/html5options/#setAnimateShapes) e, quando necessário, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/html5options/#setAnimateTransitions).
- A renderização de vídeo oferece suporte a muitos efeitos comuns de entrada, ênfase, saída e caminho de movimento, mas nem todos os efeitos do PowerPoint são suportados. Verifique as [supported animations and effects](/slides/pt/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) atuais e teste apresentações críticas com a versão alvo do Aspose.Slides.
- Efeitos personalizados avançados e efeitos importados de outros formatos de apresentação podem ser preservados no arquivo, mas renderizados de forma diferente no PowerPoint, HTML5 ou vídeo. Valide o resultado exportado em vez de confiar apenas no nome do efeito.

## **FAQ**

**Por que uma animação aparece no PowerPoint mas não em um PDF?**

PDF é um formato estático, portanto animações e transições de slide não são reproduzidas. Exporte para HTML5, GIF animado ou vídeo quando o movimento precisar ser preservado.

**Por que um efeito é reproduzido de forma diferente em um vídeo?**

A exportação para vídeo renderiza as animações em vez de armazenar o comportamento original do PowerPoint. Alguns efeitos avançados não são suportados ou são aproximados. Revise a tabela de efeitos suportados e teste a apresentação real antes do uso em produção.

**Mover uma forma para frente ou para trás altera sua ordem de animação?**

Não. A ordem Z da forma controla a sobreposição, enquanto a ordem da sequência e os disparadores controlam a reprodução da animação. Alterar a linha de tempo se precisar de uma ordem de reprodução diferente.