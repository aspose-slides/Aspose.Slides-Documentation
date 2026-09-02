---
title: Aplicar animações de formas em apresentações com Python
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/python-net/shape-animation/
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
- Aspose.Slides
description: "Aprenda como adicionar, inspecionar e personalizar animações de formas, temporização, sons, comportamento pós-animação e texto animado com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Aspose.Slides for Python via .NET representa animações de slides como efeitos em uma linha do tempo do slide. Um efeito tem uma forma de destino, um tipo e subtipo de animação, um gatilho, configurações de temporização e propriedades opcionais como som ou comportamento após a animação.

A linha do tempo contém dois tipos de sequências:

- A **sequência principal** reproduz à medida que o slide avança.
- Uma **sequência interativa** inicia quando sua forma de gatilho é clicada.

Como caixas de texto, imagens, gráficos, tabelas e outros objetos de slide implementam [IShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/ishape/), você usa o mesmo método [Sequence.add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/) para a maioria do conteúdo do slide. Os efeitos disponíveis estão listados na enumeração [EffectType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effecttype/).

## **Adicionar animações a formas**

Para adicionar uma animação, obtenha a sequência principal do slide e chame [Sequence.add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/) com a forma de destino, tipo de efeito, subtipo e gatilho. Para um efeito que inicia quando outra forma é clicada, crie uma sequência interativa cujo gatilho seja essa outra forma.

O exemplo a seguir cria ambos os tipos de animação e salva o resultado em `shape-animations.pptx`.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.ROUND_CORNER_RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Click to animate this shape"

    main_sequence = slide.timeline.main_sequence
    entrance_effect = main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    entrance_effect.timing.duration = 1.5

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    presentation.save("shape-animations.pptx", slides.export.SaveFormat.PPTX)
```

O gatilho controla quando um efeito começa:

- [EffectTriggerType.ON_CLICK](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effecttriggertype/) aguarda um clique na sequência principal ou um clique na forma de gatilho em uma sequência interativa.
- [EffectTriggerType.WITH_PREVIOUS](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effecttriggertype/) inicia com o efeito anterior.
- [EffectTriggerType.AFTER_PREVIOUS](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effecttriggertype/) inicia quando o efeito anterior termina.

Para animar uma imagem, gráfico ou outro tipo de forma, passe esse objeto para [Sequence.add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/) em vez de `target_shape`. Para opções de agrupamento específicas de gráficos, consulte [Animated Charts](/slides/pt/python-net/animated-charts/).

## **Ler animações de formas**

Use [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/get_effects_by_shape/) quando souber a forma de destino. Para inspecionar cada efeito, itere pela sequência principal e por cada sequência interativa. A iteração evita supor que uma sequência contenha um efeito no índice `0`.

O exemplo a seguir cria uma forma com efeitos de sequência principal e interativa, obtém os efeitos que têm a forma como alvo e então itera por todas as sequências no slide.

```python
import aspose.slides as slides


def print_sequence(label, sequence):
    print(f"  {label}: {sequence.count} effect(s)")

    for effect in sequence:
        target_name = "unknown" if effect.target_shape is None else effect.target_shape.name
        effect_description = f"{effect.type.name} {effect.subtype.name}; target: {target_name}; trigger: {effect.timing.trigger_type.name}"
        print(f"    {effect_description}")


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    target_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    target_shape.text_frame.text = "Animated shape"

    main_sequence = slide.timeline.main_sequence
    main_sequence.add_effect(target_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    trigger_shape = slide.shapes.add_auto_shape(slides.ShapeType.BEVEL, 20, 20, 100, 40)
    trigger_shape.text_frame.text = "Move"

    interactive_sequence = slide.timeline.interactive_sequences.add(trigger_shape)
    interactive_sequence.add_effect(target_shape, slides.animation.EffectType.PATH_FOOTBALL, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    target_effects = main_sequence.get_effects_by_shape(target_shape)
    print(f"The main sequence contains {len(target_effects)} effect(s) for {target_shape.name}.")

    print_sequence("Main sequence", main_sequence)

    for interactive_index, sequence in enumerate(slide.timeline.interactive_sequences, start=1):
        trigger_name = "unknown" if sequence.trigger_shape is None else sequence.trigger_shape.name
        sequence_label = f"Interactive sequence {interactive_index}, trigger: {trigger_name}"
        print_sequence(sequence_label, sequence)
```

Se você precisar apenas dos efeitos para uma forma, primeiro identifique a forma por nome, tipo de placeholder ou outra propriedade estável; então chame [Sequence.get_effects_by_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/get_effects_by_shape/). Não presuma que a forma no índice `0` seja sempre o objeto desejado.

## **Trabalhar com efeitos de placeholder herdados**

Um placeholder em um slide normal pode herdar o comportamento de animação do placeholder correspondente no slide de layout e no slide mestre. [Shape.get_base_placeholder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_base_placeholder/) devolve esse placeholder pai, ou `None` quando não há pai.

Na apresentação de exemplo a seguir, o rodapé possui **Random Bars** no slide normal, **Split** no slide de layout e **Fly In** no slide mestre.

![Efeito de animação do rodapé no slide normal](slide-shape-animation.png)

![Efeito de animação do placeholder de rodapé no slide de layout](layout-shape-animation.png)

![Efeito de animação do placeholder de rodapé no slide mestre](master-shape-animation.png)

O próximo exemplo constrói a hierarquia de placeholders. Ele adiciona efeitos a um placeholder mestre, a um placeholder de layout e ao placeholder correspondente em um slide normal. Cada chamada a [Shape.get_base_placeholder](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/get_base_placeholder/) é verificada antes que a forma retornada seja usada.

```python
import aspose.slides as slides


def find_placeholder_with_base(slide):
    for shape in slide.shapes:
        if shape.get_base_placeholder() is not None:
            return shape

    return None


def print_effects(source, effects):
    print(f"{source}: {len(effects)} effect(s)")

    for effect in effects:
        print(f"  {effect.type.name} {effect.subtype.name}")


with slides.Presentation() as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_placeholder = layout_slide.placeholder_manager.add_text_placeholder(100, 100, 400, 80)
    layout_slide.timeline.main_sequence.add_effect(layout_placeholder, slides.animation.EffectType.SPLIT, slides.animation.EffectSubtype.VERTICAL_IN, slides.animation.EffectTriggerType.ON_CLICK)

    master_placeholder = layout_placeholder.get_base_placeholder()
    if master_placeholder is not None:
        master_sequence = layout_slide.master_slide.timeline.main_sequence
        master_sequence.add_effect(master_placeholder, slides.animation.EffectType.FLY, slides.animation.EffectSubtype.BOTTOM, slides.animation.EffectTriggerType.ON_CLICK)

    slide = presentation.slides.add_empty_slide(layout_slide)
    slide_placeholder = find_placeholder_with_base(slide)

    if slide_placeholder is None:
        raise RuntimeError("The slide does not contain a placeholder linked to its layout slide.")

    slide.timeline.main_sequence.add_effect(slide_placeholder, slides.animation.EffectType.RANDOM_BARS, slides.animation.EffectSubtype.HORIZONTAL, slides.animation.EffectTriggerType.ON_CLICK)
    print_effects("Normal slide", slide.timeline.main_sequence.get_effects_by_shape(slide_placeholder))

    base_layout_placeholder = slide_placeholder.get_base_placeholder()
    if base_layout_placeholder is not None:
        print_effects("Layout slide", layout_slide.timeline.main_sequence.get_effects_by_shape(base_layout_placeholder))

        base_master_placeholder = base_layout_placeholder.get_base_placeholder()
        if base_master_placeholder is not None:
            print_effects("Master slide", layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(base_master_placeholder))

    presentation.save("placeholder-animations.pptx", slides.export.SaveFormat.PPTX)
```

## **Alterar a temporização da animação**

 a caixa de diálogo **Timing** do PowerPoint corresponde às propriedades de [Timing](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/).

![Caixa de diálogo Timing do PowerPoint para um efeito de animação](shape-animation.png)

- **Start** corresponde a [Timing.trigger_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/trigger_type/).
- **Duration** corresponde a [Timing.duration](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/duration/), em segundos.
- **Delay** corresponde a [Timing.trigger_delay_time](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/trigger_delay_time/), em segundos.
- **Repeat** corresponde a [Timing.repeat_count](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_count/), [Timing.repeat_until_next_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_until_next_click/), ou [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_until_end_slide/).
- **Rewind when done playing** corresponde a [Timing.rewind](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/rewind/).

Este exemplo independente adiciona um efeito, altera sua temporização através do objeto retornado por [Sequence.add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/) e salva o resultado. Manter a referência ao [Effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/) retornado evita um índice de coleção desnecessário.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Timed animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK
    effect.timing.duration = 2.0
    effect.timing.trigger_delay_time = 0.5
    effect.timing.repeat_until_next_click = False
    effect.timing.repeat_until_end_slide = False
    effect.timing.repeat_count = 2.0
    effect.timing.rewind = True

    presentation.save("shape-animation-timing.pptx", slides.export.SaveFormat.PPTX)
```

Use um modo de repetição intencionalmente. Combinar um contador de repetições com um sinalizador “until” pode produzir resultados confusos em diferentes visualizadores. Ao mudar os modos de repetição, defina [Timing.repeat_until_next_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_until_next_click/) e [Timing.repeat_until_end_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) antes de [Timing.repeat_count](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_count/), pois definir qualquer um dos sinalizadores também altera o modo de repetição ativo.

## **Adicionar e extrair sons de animação**

Um efeito de animação pode referenciar áudio incorporado através de [Effect.sound](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/sound/). [Effect.stop_previous_sound](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/stop_previous_sound/) instrui um efeito a interromper o áudio iniciado por um efeito anterior.

### **Adicionar um som a um efeito**

O exemplo a seguir espera um arquivo de áudio local chamado `animation-sound.wav`. Ele cria dois efeitos, incorpora esse arquivo como som do primeiro efeito e configura o segundo efeito para interromper o som. Usa os objetos retornados por [Sequence.add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/), portanto nenhum índice de sequência é necessário.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    first_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 100, 240, 80)
    second_shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 400, 100, 240, 80)
    first_shape.text_frame.text = "Starts sound"
    second_shape.text_frame.text = "Stops sound"

    sequence = slide.timeline.main_sequence
    first_effect = sequence.add_effect(first_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    second_effect = sequence.add_effect(second_shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    with open("animation-sound.wav", "rb") as audio_file:
        effect_sound = presentation.audios.add_audio(audio_file.read())

    first_effect.sound = effect_sound
    second_effect.stop_previous_sound = True

    presentation.save("shape-animation-sound.pptx", slides.export.SaveFormat.PPTX)
```

### **Extrair sons de efeitos incorporados**

O exemplo a seguir espera uma apresentação local chamada `presentation-with-animation-sounds.pptx`. Ele examina tanto as sequências principais quanto as interativas e grava cada som de efeito incorporado no diretório `extracted-animation-sounds`. A extensão é selecionada a partir do tipo MIME de áudio exposto por [Audio.content_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audio/content_type/).

```python
import os

import aspose.slides as slides


def get_audio_extension(content_type):
    normalized_type = "" if content_type is None else content_type.lower()

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
        if effect.sound is None:
            continue

        extension = get_audio_extension(effect.sound.content_type)
        output_path = os.path.join(output_directory, f"effect-sound-{sound_index}{extension}")
        with open(output_path, "wb") as output_file:
            output_file.write(bytes(effect.sound.binary_data))
        sound_index += 1

    return sound_index


input_path = "presentation-with-animation-sounds.pptx"
output_directory = "extracted-animation-sounds"

os.makedirs(output_directory, exist_ok=True)

with slides.Presentation(input_path) as presentation:
    sound_index = 1

    for slide in presentation.slides:
        sound_index = save_sounds(slide.timeline.main_sequence, output_directory, sound_index)

        for sequence in slide.timeline.interactive_sequences:
            sound_index = save_sounds(sequence, output_directory, sound_index)

print(f"Extracted {sound_index - 1} sound file(s) to {os.path.abspath(output_directory)}.")
```

Para objetos de áudio grandes, use [Audio.get_stream](https://reference.aspose.com/slides/pt/python-net/aspose.slides/audio/get_stream/) e copie o fluxo para um arquivo em vez de carregar todo o objeto em um array de bytes.

## **Definir comportamento após a animação**

A opção **After animation** controla o que acontece com uma forma após a conclusão do seu efeito.

![Caixa de diálogo de opções de efeito do PowerPoint mostrando configurações de After animation](shape-after-animation.png)

A enumeração [AfterAnimationType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/) oferece deixar a forma inalterada, mudar sua cor, ocultá‑la após a animação ou ocultá‑la no próximo clique. Quando o tipo é [AfterAnimationType.COLOR](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/), também defina [Effect.after_animation_color](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/after_animation_color/).

Este exemplo independente cria um efeito, define seu comportamento após a animação através do objeto de efeito retornado e salva o resultado.

```python
import aspose.pydrawing as draw
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 120, 100, 320, 80)
    shape.text_frame.text = "Dim after animation"

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.after_animation_type = slides.animation.AfterAnimationType.COLOR
    effect.after_animation_color.color = draw.Color.light_gray

    presentation.save("shape-animation-after-effect.pptx", slides.export.SaveFormat.PPTX)
```

Alterar o tipo para algo diferente de [AfterAnimationType.COLOR](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/) limpa a configuração de cor após a animação.

## **Animar texto**

A animação de texto possui dois controles relacionados:

- [TextAnimation.build_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/textanimation/build_type/) controla se os parágrafos aparecem juntos ou por nível de parágrafo.
- [Effect.animate_text_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/animate_text_type/) controla se o texto aparece tudo de uma vez, palavra a palavra ou letra a letra. [Effect.delay_between_text_parts](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/delay_between_text_parts/) define o atraso entre palavras ou letras. Um valor positivo é uma porcentagem da duração do efeito; um valor negativo é um atraso em segundos.

O exemplo independente a seguir anima as palavras em uma caixa de texto. [BuildType.AS_ONE_OBJECT](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/buildtype/) desabilita a construção parágrafo‑a‑parágrafo para que a configuração de palavra se aplique a todo o quadro de texto.

```python
import aspose.slides as slides


with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    text_box = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 80, 80, 560, 100)
    text_box.text_frame.text = "Aspose.Slides animates this sentence word by word."

    effect = slide.timeline.main_sequence.add_effect(text_box, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT
    effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD
    effect.delay_between_text_parts = 20.0

    presentation.save("animated-text.pptx", slides.export.SaveFormat.PPTX)
```

Para construir uma caixa de texto por parágrafo, defina [BuildType.BY_LEVEL_PARAGRAPHS1](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/buildtype/) (ou outro nível de parágrafo). Para direcionar um único parágrafo com seu próprio efeito, use a sobrecarga de [Sequence.add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/) que aceita um [IParagraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iparagraph/). Consulte [Animated Text](/slides/pt/python-net/animated-text/) para exemplos a nível de parágrafo.

## **Exportação e notas de compatibilidade**

- Salvar em PPT ou PPTX preserva o modelo de animação, mas a reprodução final é controlada pelo visualizador da apresentação.
- PDF e imagens estáticas não reproduzem animações. Use [exportação para HTML5](/slides/pt/python-net/export-to-html5/), GIF animado ou [conversão para vídeo](/slides/pt/python-net/convert-powerpoint-to-video/) quando a saída precisar mostrar movimento.
- Para HTML5, habilite [Html5Options.animate_shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/html5options/animate_shapes/) e, quando necessário, [Html5Options.animate_transitions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/html5options/animate_transitions/).
- A renderização de vídeo suporta muitos efeitos de entrada, ênfase, saída e caminho de movimento comuns, mas nem todo efeito do PowerPoint é suportado. Verifique a lista atual de [animações e efeitos suportados](/slides/pt/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) e teste apresentações críticas com a versão do Aspose.Slides que você utiliza.
- Efeitos personalizados avançados e efeitos importados de outros formatos de apresentação podem ser preservados no arquivo, mas renderizados de forma diferente no PowerPoint, HTML5 ou vídeo. Valide o resultado exportado em vez de confiar apenas no nome do efeito.

## **FAQ**

**Por que uma animação aparece no PowerPoint mas não no PDF?**

PDF é um formato estático, portanto animações e transições de slide não são reproduzidas. Exporte para HTML5, GIF animado ou vídeo quando for necessário preservar o movimento.

**Por que um efeito é reproduzido de maneira diferente em um vídeo?**

A exportação para vídeo renderiza as animações em vez de armazenar o comportamento original do PowerPoint. Alguns efeitos avançados não são suportados ou são aproximados. Consulte a tabela de efeitos suportados e teste a apresentação real antes de usá‑la em produção.

**Mover uma forma para a frente ou para trás altera a ordem da animação?**

Não. A ordem Z da forma controla a sobreposição, enquanto a ordem da sequência e os gatilhos controlam a reprodução da animação. Altere a linha do tempo se precisar de uma ordem de reprodução diferente.