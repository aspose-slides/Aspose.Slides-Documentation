---
title: Gerenciar Transições de Slide em Apresentações Usando Python
linktitle: Transição de Slide
type: docs
weight: 90
url: /pt/python-net/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição avançada de slide
- transição morph
- tipo de transição
- efeito de transição
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Aplique transições de slide, configure o avanço automático de slides e personalize Morph e outros efeitos de transição com Aspose.Slides for Python via .NET."
---
## **Visão geral**

As transições de slide controlam como os slides aparecem durante uma apresentação de slides. Com Aspose.Slides for Python via .NET, você pode escolher um efeito de transição para cada slide, configurar o avanço por clique do mouse ou temporizador e ajustar opções específicas de um efeito. Este artigo usa exemplos em Python para aplicar transições, definir durações exatas de transição, gerenciar o tempo dos slides e criar uma transição Morph entre dois slides. Os exemplos também mostram como salvar as configurações em um arquivo PPTX.

## **Adicionar transição de slide**

Para aplicar uma transição, carregue uma apresentação com a classe [Apresentação](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) e acesse a propriedade [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) do slide. Defina seu [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) para um valor da enumeração [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) e, em seguida, salve a apresentação.

O exemplo a seguir aplica uma transição Circle ao primeiro slide e uma transição Comb ao segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE
        presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

        presentation.save("slide-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

## **Transição Wheel**

A propriedade [spokes](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/spokes/) de [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/) controla o número de setores radiais que revelam o slide de destino. Defina o [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) do slide para WHEEL da enumeração [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) antes de acessar [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/) como [WheelTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/wheeltransition/).

Este exemplo cria duas pares idênticos de slides: um slide preto seguido de um slide com um retângulo dourado. Os slides de destino usam contagens de spokes de 1 e 8, com a mesma [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) e uma [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) explícita de 8.000 milissegundos para tornar a diferença fácil de observar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_width = presentation.slide_size.size.width
    slide_height = presentation.slide_size.size.height

    black_slide = presentation.slides[0]
    black_slide.shapes.clear()
    black_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    black_slide.background.fill_format.fill_type = slides.FillType.SOLID
    black_slide.background.fill_format.solid_fill_color.preset_color = slides.PresetColor.BLACK

    destination_slide = presentation.slides.add_clone(black_slide)
    rectangle = destination_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, slide_width, slide_height)
    rectangle.fill_format.fill_type = slides.FillType.SOLID
    rectangle.fill_format.solid_fill_color.preset_color = slides.PresetColor.GOLD
    rectangle.text_frame.text = "Wheel transition"

    presentation.slides.add_clone(black_slide)
    presentation.slides.add_clone(destination_slide)

    spoke_counts = [1, 8]
    for i, spoke_count in enumerate(spoke_counts):
        transition = presentation.slides[i * 2 + 1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.WHEEL
        wheel_transition = transition.value
        wheel_transition.spokes = spoke_count
        transition.speed = slides.slideshow.TransitionSpeed.SLOW
        transition.duration = 8000

    presentation.save("wheel-transitions.pptx", slides.export.SaveFormat.PPTX)
```

Abra a apresentação resultante no PowerPoint e execute a apresentação de slides. Avance do slide 1 para o slide 2, depois do slide 3 para o slide 4. Na reprodução do PowerPoint, a contagem verificada de spokes 1 revela o slide com uma varredura horária; a contagem verificada de 8 revela-o através de oito setores radiais simultaneamente. O conteúdo de destino e o tempo da transição são idênticos, portanto a diferença está no número de setores de revelação.

## **Adicionar transição avançada de slide**

Você pode configurar quanto tempo um slide permanece na tela e se um clique do mouse avança a apresentação. As seguintes propriedades controlam esse comportamento:

- [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) permite que o espectador avance clicando com o mouse.
- [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) habilita o avanço automático.
- [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) especifica o atraso antes do avanço automático, em milissegundos.

Habilite tanto o avanço por clique quanto o cronometrado para que o espectador avance com um clique ou aguarde o temporizador. Para usar apenas o temporizador, defina [advance_on_click](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_on_click/) como `False`. O atraso controla quando a apresentação avança; ele não define a duração do efeito visual da transição.

Este exemplo atribui efeitos diferentes aos três primeiros slides e habilita o avanço automático após 3, 5 e 7 segundos, respectivamente. Cliques do mouse também podem avançar esses slides. Use um arquivo `input.pptx` com pelo menos três slides.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 3:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.CIRCLE
        first_transition.advance_on_click = True
        first_transition.advance_after = True
        first_transition.advance_after_time = 3000

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.COMB
        second_transition.advance_on_click = True
        second_transition.advance_after = True
        second_transition.advance_after_time = 5000

        third_transition = presentation.slides[2].slide_show_transition
        third_transition.type = slides.slideshow.TransitionType.ZOOM
        third_transition.advance_on_click = True
        third_transition.advance_after = True
        third_transition.advance_after_time = 7000

        presentation.save("advanced-transitions.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least three slides.")
```

Para verificar se o avanço cronometrado está habilitado, leia [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/). Um atraso armazenado sozinho não indica que o temporizador está ativo.

O próximo exemplo abre o arquivo salvo acima, relata cada temporizador habilitado e desabilita o avanço automático para slides com atraso superior a dois segundos. Ele habilita cliques do mouse para esses slides e salva as configurações atualizadas.

```python
import aspose.slides as slides

with slides.Presentation("advanced-transitions.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition

        if transition.advance_after:
            print(f"Slide {slide.slide_number}: advance after {transition.advance_after_time} ms.")

            if transition.advance_after_time > 2000:
                transition.advance_after = False
                transition.advance_on_click = True

    presentation.save("adjusted-transitions.pptx", slides.export.SaveFormat.PPTX)
```

## **Controlar o tempo da transição com precisão**

Use [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) para especificar o comprimento exato de um efeito de transição em milissegundos. A propriedade [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) do slide expõe essas configurações por meio do [SlideShowTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/):

| Propriedade | Objetivo |
| --- | --- |
| [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) | Define a duração do próprio efeito de transição, em milissegundos. |
| [advance_after_time](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after_time/) | Define o atraso antes que o slide avance automaticamente, em milissegundos. Habilite [advance_after](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/advance_after/) para ativar esse temporizador. |
| [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) | Seleciona uma categoria de velocidade predefinida da enumeração [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/): SLOW, MEDIUM ou FAST. É usada quando uma duração exata não é especificada. |

[duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) controla apenas o efeito de transição; ele não determina quanto tempo o slide permanece visível. Configure o atraso de avanço automático separadamente. Quando nenhuma duração explícita é definida, Aspose.Slides determina a duração do efeito a partir do tipo de transição e do valor de [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/).

<!-- visual-explanation:slide-transition:start -->
[![Barras separadas identificam a duração da transição de 750 ms e a configuração de avanço automático de 5 000 ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*O exemplo compartilhado atribui a cada slide uma transição Fade de 750 ms e habilita separadamente o avanço automático em 5 000 ms. A duração da transição controla o efeito; o avanço controla quando deixar o slide. Estas barras são representações esquemáticas, não uma linha do tempo combinada medida.*
<!-- visual-explanation:slide-transition:end -->

### **Aplicar a mesma duração a cada slide**

Para manter um ritmo consistente, aplique o mesmo efeito e a mesma duração exata a todos os slides. Este exemplo carrega `input.pptx`, seleciona Fade da enumeração [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) e atribui a cada transição uma duração de 750 milissegundos. Ele habilita separadamente o avanço automático após 5 000 milissegundos e desabilita o avanço por clique do mouse, então salva o resultado como PPTX.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        transition.type = slides.slideshow.TransitionType.FADE
        transition.duration = 750

        # Configure o avanço automático independentemente da duração do efeito.
        transition.advance_after = True
        transition.advance_after_time = 5000
        transition.advance_on_click = False

    presentation.save("precise-transitions.pptx", slides.export.SaveFormat.PPTX)
```

### **Definir durações diferentes para slides individuais**

Slides diferentes podem usar durações de efeito distintas. Por exemplo, use uma transição breve para um slide de título e uma transição mais longa para a introdução de uma seção. Este exemplo define 500 milissegundos para o primeiro slide e 1 200 milissegundos para o segundo. Use um arquivo `input.pptx` com pelo menos dois slides.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    if len(presentation.slides) >= 2:
        first_transition = presentation.slides[0].slide_show_transition
        first_transition.type = slides.slideshow.TransitionType.FADE
        first_transition.duration = 500

        second_transition = presentation.slides[1].slide_show_transition
        second_transition.type = slides.slideshow.TransitionType.PUSH
        second_transition.duration = 1200

        presentation.save("individual-transition-durations.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("The input presentation must contain at least two slides.")
```

### **Coordinar transições com saída animada**

Ao preparar um [GIF animado](/slides/pt/python-net/convert-powerpoint-to-animated-gif/), uma [apresentação HTML5](/slides/pt/python-net/export-to-html5/) ou um [vídeo](/slides/pt/python-net/convert-powerpoint-to-video/), defina durações exatas de transição antes da exportação para corresponder ao ritmo desejado. Por exemplo, use um fade de 600 milissegundos entre cenas e ajuste separadamente o atraso de avanço de cada slide para permitir tempo para a narração ou conteúdo.

Para GIF e vídeo, coordene a taxa de quadros de saída com a duração do efeito: 600 milissegundos correspondem a 18 quadros a 30 quadros por segundo. No HTML5, habilite transições animadas nas configurações de exportação. Verifique os efeitos e opções de tempo suportados pelo formato escolhido e visualize a saída para confirmar a sincronização.

### **Ler a duração de uma transição existente**

Leia [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) antes de modificar a transição para determinar se um valor explícito está armazenado. Um valor de `-1` significa que nenhuma duração explícita está definida; um valor não negativo especifica a duração armazenada em milissegundos. O valor não definido não é a duração calculada de reprodução: Aspose.Slides usa o tipo de transição e o [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) para determinar essa duração. Definir um tipo de transição pode inicializar uma duração, portanto inspecione as configurações originais primeiro.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    for slide in presentation.slides:
        transition = slide.slide_show_transition
        duration = transition.duration

        if duration >= 0:
            print(f"Slide {slide.slide_number}: stored transition duration is {duration} ms.")
        else:
            print(f"Slide {slide.slide_number}: no explicit duration; timing depends on {transition.type} and {transition.speed}.")
```

## **Transição Morph**

A transição Morph anima mudanças entre objetos em slides consecutivos. Para criar um efeito Morph simples, clone um slide, mova ou redimensione um objeto no clone e aplique a transição Morph ao segundo slide. Isso fornece aos objetos correspondentes a animação entre seus estados original e modificado.

O exemplo a seguir cria um slide com um retângulo de texto, clona o slide e altera a posição e o tamanho do retângulo no clone. Em seguida, seleciona Morph da enumeração [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/) para o segundo slide. Abra o arquivo salvo em um visualizador de apresentações que suporte Morph para ver o efeito durante a apresentação de slides.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    rectangle = first_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    rectangle.text_frame.text = "Morph transition"

    second_slide = presentation.slides.add_clone(first_slide)
    moved_rectangle = second_slide.shapes[0]
    moved_rectangle.x += 100
    moved_rectangle.y += 50
    moved_rectangle.width -= 200
    moved_rectangle.height -= 10

    second_slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("morph-transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Tipos de transição Morph**

A enumeração [TransitionMorphType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) controla como o Morph corresponde e anima o conteúdo:

- [BY_OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) trata cada forma como um objeto único.
- [BY_WORD](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) anima texto correspondendo palavras, quando possível.
- [BY_CHAR](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionmorphtype/) anima texto correspondendo caracteres, quando possível.

Defina o [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) da transição para Morph antes de acessar seu [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/). O valor então fornece o objeto [MorphTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/), cuja propriedade [morph_type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/morphtransition/morph_type/) seleciona o modo de correspondência.

Este exemplo abre a apresentação criada na seção anterior e configura o segundo slide para usar animação Morph baseada em palavras.

```python
import aspose.slides as slides

with slides.Presentation("morph-transition.pptx") as presentation:
    if len(presentation.slides) >= 2:
        transition = presentation.slides[1].slide_show_transition
        transition.type = slides.slideshow.TransitionType.MORPH
        morph_transition = transition.value

        if isinstance(morph_transition, slides.slideshow.MorphTransition):
            morph_transition.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
            presentation.save("morph-by-word.pptx", slides.export.SaveFormat.PPTX)
        else:
            print("Morph transition options are unavailable.")
    else:
        print("The input presentation must contain at least two slides.")
```

## **Definir efeitos de transição**

Algumas transições expõem opções adicionais, como direção ou se o efeito começa a partir de uma tela preta. As opções disponíveis dependem do [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) de transição selecionado. Defina o tipo primeiro, depois use o objeto de transição apropriado obtido a partir do seu [value](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/value/).

O exemplo a seguir aplica uma transição Cut ao primeiro slide de `input.pptx`. Ele define [from_black](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/from_black/) por meio de [OptionalBlackTransition](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/optionalblacktransition/) para que a transição inicie a partir de uma tela preta.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    transition = presentation.slides[0].slide_show_transition
    transition.type = slides.slideshow.TransitionType.CUT
    cut_transition = transition.value

    if isinstance(cut_transition, slides.slideshow.OptionalBlackTransition):
        cut_transition.from_black = True
        presentation.save("cut-from-black.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Cut transition options are unavailable.")
```

## **FAQ**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Prefira [duration](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/duration/) quando precisar de uma duração exata do efeito em milissegundos. Use [speed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/speed/) quando uma categoria predefinida de [TransitionSpeed](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionspeed/) — SLOW, MEDIUM ou FAST — for suficiente e nenhuma duração explícita for definida. Essas configurações controlam o efeito de transição independentemente do atraso de avanço automático.

**Posso anexar áudio a uma transição e fazer o loop?**

Sim. Atribua áudio incorporado a [sound](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound/), defina [sound_mode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/) como START_SOUND da enumeração [TransitionSoundMode](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitionsoundmode/) e habilite [sound_loop](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/). O áudio será reproduzido em loop até o próximo evento de som na apresentação.

**Qual a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Percorra a coleção de [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/) da apresentação e defina o [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) da transição de cada slide para o mesmo valor. Defina quaisquer opções de tempo e efeito no mesmo laço para manter o comportamento consistente em todos os slides.

**Como posso verificar qual transição está atualmente definida em um slide?**

Leia a propriedade [type](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/slideshowtransition/type/) do [slide_show_transition](https://reference.aspose.com/slides/python-net/aspose.slides/slide/slide_show_transition/) do slide. Ela retorna um valor da enumeração [TransitionType](https://reference.aspose.com/slides/python-net/aspose.slides.slideshow/transitiontype/); NONE indica que nenhum efeito de transição está aplicado.