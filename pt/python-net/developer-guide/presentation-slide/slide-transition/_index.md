---
title: Gerenciar Transições de Slides em Apresentações Usando Python
linktitle: Transição de Slide
type: docs
weight: 90
url: /pt/python-net/slide-transition/
keywords:
- transição de slide
- adicionar transição de slide
- aplicar transição de slide
- transição de slide avançada
- transição morph
- tipo de transição
- efeito de transição
- Python
- Aspose.Slides
description: "Descubra como personalizar transições de slides no Aspose.Slides para Python via .NET, com orientação passo a passo para apresentações PowerPoint e OpenDocument."
---
## **Visão Geral**

Aspose.Slides for Python oferece controle total sobre as transições de slides, desde a seleção do tipo de transição até a configuração de temporização e gatilhos como parte de fluxos de trabalho automatizados de apresentação. Você pode definir os slides para avançar ao clicar e/ou após um atraso especificado e refinar o comportamento visual com efeitos como cortes a partir do preto ou entradas direcionais. A biblioteca também oferece suporte à transição Morph introduzida no PowerPoint 2019, incluindo modos que morph por objeto, palavra ou caractere para criar um movimento suave e coeso entre os slides.

## **Adicionar Transições de Slide**

Para facilitar a compreensão, este exemplo demonstra como usar Aspose.Slides for Python para gerenciar transições de slide simples. Os desenvolvedores podem aplicar diferentes efeitos de transição de slide aos slides e personalizar seu comportamento. Para criar uma transição de slide simples, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Aplique uma transição de slide usando um dos efeitos do enum [TransitionType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/transitiontype/).
1. Salve o arquivo de apresentação modificado.

```py
import aspose.slides as slides

# Instanciar a classe Presentation para carregar um arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    # Aplicar uma transição de círculo ao slide 1.
    presentation.slides[0].slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Aplicar uma transição de pente ao slide 2.
    presentation.slides[1].slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Salvar a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Adicionar Transições de Slide Avançadas**

Nesta seção, aplicamos um efeito de transição simples a um slide. Para tornar esse efeito mais controlado e refinado, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Aplique uma transição de slide usando um dos efeitos do enum [TransitionType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/transitiontype/).
1. Configure a transição para Avançar ao Clicar, após um período de tempo específico ou ambos.
1. Salve o arquivo de apresentação modificado.

Se **Advance On Click** estiver habilitado, o slide avança apenas quando o usuário clica. Se a propriedade **Advance After Time** estiver definida, o slide avança automaticamente após o intervalo especificado.

```py
import aspose.slides as slides

# Instanciar a classe Presentation para abrir um arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    slide0 = presentation.slides[0]

    # Aplicar uma transição de círculo ao slide 1.
    slide0.slide_show_transition.type = slides.slideshow.TransitionType.CIRCLE

    # Habilitar avançar ao clicar e definir um avanço automático de 3 segundos.
    slide0.slide_show_transition.advance_on_click = True
    slide0.slide_show_transition.advance_after_time = 3000

    slide1 = presentation.slides[1]

    # Aplicar uma transição de pente ao slide 2.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.COMB

    # Habilitar avançar ao clicar e definir um avanço automático de 5 segundos.
    slide1.slide_show_transition.advance_on_click = True
    slide1.slide_show_transition.advance_after_time = 5000

    slide2 = presentation.slides[2]

    # Aplicar uma transição de zoom ao slide 3.
    slide2.slide_show_transition.type = slides.slideshow.TransitionType.ZOOM

    # Habilitar avançar ao clicar e definir um avanço automático de 7 segundos.
    slide2.slide_show_transition.advance_on_click = True
    slide2.slide_show_transition.advance_after_time = 7000

    # Salvar a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Transição Morph**

Aspose.Slides for Python oferece suporte à [Morph transition](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/morphtransition/), que anima o movimento suave de um slide para o próximo. Esta seção explica como usar a transição Morph. Para usá‑la de forma eficaz, você precisa de dois slides com pelo menos um objeto em comum. A abordagem mais simples é duplicar um slide e então mover o objeto para uma posição diferente no segundo slide.

O trecho de código a seguir mostra como clonar um slide que contém texto e aplicar uma transição Morph ao segundo slide.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide0 = presentation.slides[0]

    auto_shape = slide0.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 400, 100)
    auto_shape.text_frame.text = "Morph Transition in PowerPoint Presentations"

    # Clonar o primeiro slide para criar um segundo slide com as mesmas formas para continuidade do Morph.
    slide1 = presentation.slides.add_clone(slide0)

    # Selecionar o mesmo retângulo no segundo slide e alterar sua posição e tamanho.
    shape = slide1.shapes[0]
    shape.x += 100
    shape.y += 50
    shape.width -= 200
    shape.height -= 10

    # Habilitar a transição Morph no segundo slide para animar as mudanças de forma suavemente.
    slide1.slide_show_transition.type = slides.slideshow.TransitionType.MORPH

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Tipos de Transição Morph**

O enum [TransitionMorphType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/transitionmorphtype/) representa os diferentes tipos de transições de slide Morph.

O trecho de código a seguir mostra como aplicar uma transição Morph a um slide e alterar o tipo de morph:

```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.slide_show_transition.type = slides.slideshow.TransitionType.MORPH
    slide.slide_show_transition.value.morph_type = slides.slideshow.TransitionMorphType.BY_WORD
    
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Efeitos de Transição**

Aspose.Slides for Python permite definir efeitos de transição como **From Black**, **From Left**, **From Right**, etc. Para configurar um efeito de transição, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Obtenha uma referência ao slide.
1. Defina o efeito de transição desejado.
1. Salve a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos vários efeitos de transição.

```py
import aspose.slides as slides

# Instanciar a classe Presentation para abrir um arquivo de apresentação.
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Aplicar uma transição Cut e habilitar From Black.
    slide.slide_show_transition.type = slides.slideshow.TransitionType.CUT
    slide.slide_show_transition.value.from_black = True

    # Salvar a apresentação no disco.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso controlar a velocidade de reprodução de uma transição de slide?**

Sim. Defina a [speed](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/slideshowtransition/speed/) da transição usando a configuração [TransitionSpeed](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/transitionspeed/) (por exemplo, slow/medium/fast).

**Posso anexar áudio a uma transição e fazer com que ele seja reproduzido em loop?**

Sim. Você pode incorporar um som para a transição e controlar o comportamento por meio de configurações como modo de som e looping (por exemplo, [sound](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/slideshowtransition/sound/), [sound_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/slideshowtransition/sound_mode/), [sound_loop](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/slideshowtransition/sound_loop/), além de metadados como [sound_is_built_in](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/slideshowtransition/sound_is_built_in/) e [sound_name](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/slideshowtransition/sound_name/)).

**Qual é a maneira mais rápida de aplicar a mesma transição a todos os slides?**

Configure o tipo de transição desejado nas configurações de transição de cada slide; as transições são armazenadas por slide, portanto aplicar o mesmo tipo a todos os slides produz um resultado consistente.

**Como posso verificar qual transição está atualmente definida em um slide?**

Inspecione as [transition settings](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/slide_show_transition/) do slide e leia seu [transition type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.slideshow/slideshowtransition/type/); esse valor indica exatamente qual efeito está aplicado.