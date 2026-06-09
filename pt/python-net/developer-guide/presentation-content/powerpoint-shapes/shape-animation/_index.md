---
title: Aplicar animações de forma em apresentações com Python
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
description: "Descubra como criar e personalizar animações de forma em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET. Destaque-se!"
---
## **Introdução**

Animações são efeitos visuais que podem ser aplicados a textos, imagens, formas ou [charts](/slides/pt/python-net/animated-charts/). Elas dão vida às apresentações ou aos seus componentes. 

## **Por que usar animações em apresentações?**

Usando animações, você pode 

* controlar o fluxo de informações
* enfatizar pontos importantes
* aumentar o interesse ou a participação do seu público
* tornar o conteúdo mais fácil de ler, assimilar ou processar
* chamar a atenção dos leitores ou espectadores para partes importantes em uma apresentação

O PowerPoint oferece muitas opções e ferramentas para animações e efeitos de animação nas categorias de **entrada**, **saída**, **ênfase** e **caminhos de movimento**. 

## **Animações no Aspose.Slides**

* Aspose.Slides fornece as classes e tipos necessários para trabalhar com animações no namespace [Aspose.Slides.Animation](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/), 
* Aspose.Slides oferece mais de **150 efeitos de animação** na enumeração [EffectType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effecttype/). Esses efeitos são essencialmente os mesmos (ou equivalentes) usados no PowerPoint.

## **Aplicar animação a TextBox**

Aspose.Slides para Python via .NET permite aplicar animação ao texto em uma forma. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iautoshape/). 
4. Adicione texto ao `IAutoShape.TextFrame`.
5. Recupere a sequência principal de efeitos.
6. Adicione um efeito de animação ao [IAutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iautoshape/). 
7. Defina a propriedade `TextAnimation.BuildType` para o valor da enumeração `BuildType`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código Python mostra como aplicar o efeito `Fade` ao AutoShape e definir a animação de texto para o valor *By 1st Level Paragraphs*:

```python
import aspose.slides as slides

# Instancia uma classe de apresentação que representa um arquivo de apresentação.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # Adiciona uma nova AutoShape com texto
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # Obtém a sequência principal do slide.
    sequence = sld.timeline.main_sequence

    # Adiciona o efeito de animação Fade à forma
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # Anima o texto da forma por parágrafos de primeiro nível
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # Salva o arquivo PPTX no disco
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

Além de aplicar animações ao texto, você também pode aplicar animações a um único [Paragraph](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iparagraph/). Veja [**Animated Text**](/slides/pt/python-net/animated-text/).

{{% /alert %}} 

## **Aplicar animação a PictureFrame**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através de seu índice.
3. Adicione ou obtenha um [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/) no slide. 
4. Recupere a sequência principal de efeitos.
5. Adicione um efeito de animação ao [PictureFrame](https://reference.aspose.com/slides/pt/python-net/aspose.slides/pictureframe/).
6. Grave a apresentação no disco como um arquivo PPTX.

Este código Python mostra como aplicar o efeito `Fly` a um frame de imagem:

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# Instancia uma classe de apresentação que representa um arquivo de apresentação.
with slides.Presentation() as pres:
    # Carrega a imagem a ser adicionada na coleção de imagens da apresentação
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # Adiciona um frame de imagem ao slide
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # Obtém a sequência principal do slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Adiciona o efeito de animação Fly da esquerda ao frame de imagem
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # Salva o arquivo PPTX no disco
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Aplicar animação a Shape**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através de seu índice.
3. Adicione um `rectangle` [IAutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iautoshape/). 
4. Adicione um `Bevel` [IAutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/iautoshape/) (quando este objeto for clicado, a animação será reproduzida).
5. Crie uma sequência de efeitos na forma de chanfro.
6. Crie um `UserPath` personalizado.
7. Adicione comandos para mover ao `UserPath`.
8. Grave a apresentação no disco como um arquivo PPTX.

Este código Python mostra como aplicar o efeito `PathFootball` (caminho de futebol) a uma forma:

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# Instancia uma classe Presentation que representa um arquivo PPTX
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # Cria o efeito PathFootball para a forma existente do zero.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # Adiciona o efeito de animação PathFootBall.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # Cria algum tipo de "botão".
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # Cria uma sequência de efeitos para o botão.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # Cria um caminho de usuário personalizado. Nosso objeto será movido somente após o botão ser clicado.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # Adiciona comandos para mover já que o caminho criado está vazio.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # Grava o arquivo PPTX no disco
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Obter os efeitos de animação aplicados à Shape**

Os exemplos a seguir mostram como usar o método `get_effects_by_shape` da classe [Sequence](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/) para obter todos os efeitos de animação aplicados a uma forma.

**Exemplo 1: Obter efeitos de animação aplicados a uma shape em um slide normal**

Anteriormente, você aprendeu como adicionar efeitos de animação a formas em apresentações do PowerPoint. O código de exemplo a seguir mostra como obter os efeitos aplicados à primeira forma no primeiro slide normal da apresentação `AnimExample_out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # Obtém a sequência principal de animação do slide.
    sequence = first_slide.timeline.main_sequence

    # Obtém a primeira forma no primeiro slide.
    shape = first_slide.shapes[0]

    # Obtém os efeitos de animação aplicados à forma.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**Exemplo 2: Obter todos os efeitos de animação, incluindo os herdados de placeholders**

Se uma forma em um slide normal possui placeholders que estão no slide de layout e/ou slide mestre, e efeitos de animação foram adicionados a esses placeholders, então todos os efeitos da forma serão reproduzidos durante a apresentação, incluindo os herdados dos placeholders.

Suponha que temos um arquivo de apresentação PowerPoint `sample.pptx` com um slide contendo apenas uma forma de rodapé com o texto "Made with Aspose.Slides" e o efeito **Random Bars** foi aplicado à forma.

![Efeito de animação de forma no slide](slide-shape-animation.png)

Vamos também supor que o efeito **Split** foi aplicado ao placeholder de rodapé no slide de **layout**.

![Efeito de animação de forma no layout](layout-shape-animation.png)

E finalmente, o efeito **Fly In** foi aplicado ao placeholder de rodapé no slide **mestre**.

![Efeito de animação de forma no mestre](master-shape-animation.png)

O código de exemplo a seguir mostra como usar o método `get_base_placeholder` da classe [Shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/) para acessar os placeholders de forma e obter os efeitos de animação aplicados à forma de rodapé, incluindo os herdados dos placeholders localizados nos slides de layout e mestre.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtém os efeitos de animação da forma no slide normal.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # Obtém os efeitos de animação do placeholder no slide de layout.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # Obtém os efeitos de animação do placeholder no slide mestre.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **Alterar propriedades de tempo do efeito de animação**

Aspose.Slides para Python via .NET permite alterar as propriedades de temporização de um efeito de animação.

Este é o painel de temporização de animação no Microsoft PowerPoint:

![Painel de temporização de animação](shape-animation.png)

Estas são as correspondências entre o temporizador do PowerPoint e as propriedades `Effect.Timing`:

- A lista suspensa **Start** do PowerPoint Timing corresponde à propriedade [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effecttriggertype/). 
- O **Duration** do PowerPoint Timing corresponde à propriedade `Effect.Timing.Duration`. A duração de uma animação (em segundos) é o tempo total que a animação leva para concluir um ciclo. 
- O **Delay** do PowerPoint Timing corresponde à propriedade `Effect.Timing.TriggerDelayTime`. 

É assim que você altera as propriedades de temporização do efeito:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.
2. Defina novos valores para as propriedades `Effect.Timing` necessárias. 
3. Salve o arquivo PPTX modificado.

```python
import aspose.slides as slides

# Instancia uma classe de apresentação que representa um arquivo de apresentação.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # Obtém a sequência principal do slide.
    sequence = pres.slides[0].timeline.main_sequence

    # Obtém o primeiro efeito da sequência principal.
    effect = sequence[0]

    # Altera o TriggerType do efeito para iniciar ao clicar
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # Altera a Duração do efeito
    effect.timing.duration = 3

    # Altera o TriggerDelayTime do efeito
    effect.timing.trigger_delay_time = 0.5

    # Salva o arquivo PPTX no disco
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **Som do efeito de animação**

Aspose.Slides fornece estas propriedades para permitir que você trabalhe com sons em efeitos de animação: 

- `sound`
- `stop_previous_sound`

### **Adicionar som ao efeito de animação**

Este código Python mostra como adicionar um som ao efeito de animação e pará‑lo quando o próximo efeito começar:

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # Adiciona áudio à coleção de áudios da apresentação
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # Obtém a sequência principal do slide.
    sequence = first_slide.timeline.main_sequence

    # Obtém o primeiro efeito da sequência principal
    first_effect = sequence[0]

    # Verifica se o efeito tem "No Sound"
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # Adiciona som ao primeiro efeito
        first_effect.sound = effect_sound

    # Obtém a primeira sequência interativa do slide.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # Define o sinalizador "Stop previous sound" do efeito
    interactive_sequence[0].stop_previous_sound = True

    # Grava o arquivo PPTX no disco
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **Extrair som do efeito de animação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha a referência de um slide através de seu índice. 
3. Recupere a sequência principal de efeitos. 
4. Extraia o `sound` incorporado a cada efeito de animação. 

Este código Python mostra como extrair o som incorporado em um efeito de animação:

```python
import aspose.slides as slides

# Instancia uma classe de apresentação que representa um arquivo de apresentação.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # Obtém a sequência principal do slide.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # Extrai o som do efeito em array de bytes
        audio = effect.sound.binary_data
```

## **Após a animação**

Aspose.Slides para .NET permite alterar a propriedade After animation de um efeito de animação.

Este é o painel de efeito de animação e o menu estendido no Microsoft PowerPoint:

![Painel de efeito de animação](shape-after-animation.png)

A lista suspensa **After animation** do PowerPoint Effect corresponde a estas propriedades: 

- Propriedade `after_animation_type` que descreve o tipo de After animation :
  * PowerPoint **More Colors** corresponde ao tipo [COLOR](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** corresponde ao tipo [DO_NOT_DIM](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/) (tipo padrão de after animation);
  * PowerPoint **Hide After Animation** corresponde ao tipo [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** corresponde ao tipo [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/);
- Propriedade `after_animation_color` que define um formato de cor de after animation. Esta propriedade funciona em conjunto com o tipo [COLOR](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/afteranimationtype/). Se você alterar o tipo para outro, a cor de after animation será limpa.

```python
import aspose.slides as slides

# Instancia uma classe de apresentação que representa um arquivo de apresentação
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtém o primeiro efeito da sequência principal
    first_effect = first_slide.timeline.main_sequence[0]

    # Altera o tipo de after animation para Color
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # Define a cor de dim do after animation
    first_effect.after_animation_color.color = Color.alice_blue

    # Grava o arquivo PPTX no disco
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **Animar Texto**

Aspose.Slides fornece estas propriedades para permitir que você trabalhe com o bloco *Animate text* de um efeito de animação:

- `animate_text_type` que descreve o tipo de animação de texto do efeito. O texto da forma pode ser animado:
  - Tudo de uma vez ([ALL_AT_ONCE](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/animatetexttype/) tipo)
  - Por palavra ([BY_WORD](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/animatetexttype/) tipo)
  - Por letra ([BY_LETTER](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/animatetexttype/) tipo)
- `delay_between_text_parts` define um atraso entre as partes do texto animado (palavras ou letras). Um valor positivo especifica a porcentagem da duração do efeito. Um valor negativo especifica o atraso em segundos.

É assim que você altera as propriedades de animar texto do efeito:

1. [Aplicar](#apply-animation-to-shape) ou obter o efeito de animação.
2. Defina a propriedade `build_type` para o valor [AS_ONE_OBJECT](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/buildtype/) para desativar o modo de animação *By Paragraphs*.
3. Defina novos valores para as propriedades `animate_text_type` e `delay_between_text_parts`.
4. Salve o arquivo PPTX modificado.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # Obtém o primeiro efeito da sequência principal
    first_effect = first_slide.timeline.main_sequence[0]

    # Altera o tipo de animação de texto do efeito para "As One Object"
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # Altera o tipo de animar texto do efeito para "By word"
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # Define o atraso entre palavras para 20% da duração do efeito
    first_effect.delay_between_text_parts = 20

    # Grava o arquivo PPTX no disco
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **Perguntas frequentes**

**Como posso garantir que as animações sejam preservadas ao publicar a apresentação na web?**

[Export to HTML5](/slides/pt/python-net/export-to-html5/) e habilite as [options](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/html5options/) responsáveis por animações de [shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/html5options/animate_shapes/) e [transition](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/html5options/animate_transitions/). HTML simples não reproduz animações de slides, enquanto HTML5 reproduz.

**Como a mudança da ordem Z (ordem das camadas) das formas afeta a animação?**

A ordem de animação e a ordem de desenho são independentes: um efeito controla o tempo e o tipo de aparição/desaparecimento, enquanto a [z-order](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shape/z_order_position/) determina o que cobre o que. O resultado visível é definido pela combinação de ambos. (Este é o comportamento geral do PowerPoint; o modelo de efeitos‑e‑formas do Aspose.Slides segue a mesma lógica.)

**Existem limitações ao converter animações para vídeo para certos efeitos?**

Em geral, [animations are supported](/slides/pt/python-net/convert-powerpoint-to-video/), mas casos raros ou efeitos específicos podem ser renderizados de forma diferente. Recomenda‑se testar com os efeitos que você usa e com a versão da biblioteca.