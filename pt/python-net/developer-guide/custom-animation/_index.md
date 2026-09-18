---
title: Criar e Modificar Comportamentos de Animação Personalizados em Python
linktitle: Animação Personalizada
type: docs
weight: 151
url: /pt/python-net/custom-animation/
keywords:
- animação personalizada
- comportamento de animação
- caminho de movimento
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Criar, inspecionar e modificar comportamentos de animação personalizados e caminhos de movimento editáveis em apresentações PowerPoint com Aspose.Slides para Python via .NET."
---
## **Visão geral**

Comportamentos de animação personalizados permitem controlar operações individuais dentro de um efeito de animação, como alterar uma cor, girar uma forma ou seguir um caminho de movimento editável. Este guia mostra como criar e combinar comportamentos, configurar seu tempo, inspecionar e modificar animações existentes e verificar se suas propriedades permanecem ao salvar e reabrir uma apresentação.

Para efeitos predefinidos e gatilhos de clique, veja [Animação de Forma](/slides/pt/python-net/shape-animation/).

## **Entender o Modelo de Animação**

Uma animação é organizada como **Timeline → Sequence → Effect → Behaviors**:

- O [timeline](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseslide/timeline/) do slide contém sua sequência principal e sequências interativas.
- Uma [Sequence](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/) contém efeitos, potencialmente direcionados a diferentes formas.
- Um [Effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/) identifica a forma alvo, preset, subtipo e tempo do efeito.
- [Effect.behaviors](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/behaviors/) contém as operações que implementam o efeito: mudar cor, mover, girar, definir uma propriedade etc.

## **Criar Comportamentos Individuais**

Chame [Sequence.add_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/sequence/add_effect/) para criar um efeito e acessar sua coleção de [behaviors](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/behaviors/). Um preset pode popular essa coleção automaticamente. Mantenha suas operações ao estender o preset, ou use [clear](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorcollection/clear/) ao substituí‑las deliberadamente.

[BehaviorFactory](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/) cria os oito tipos de comportamento ilustrados abaixo. Movimento é abordado em [Build a Motion Path](#build-a-motion-path). Cada exemplo de criação é um programa completo; exemplos de edição posteriores indicam qual arquivo de saída eles utilizam.

### **Rotação**

Use [create_rotation_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_rotation_effect/) para criar uma rotação. [by](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/rotationeffect/by/) especifica um ângulo relativo em graus; [from_address](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/rotationeffect/from_address/) e [to](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/rotationeffect/to/) especificam os pontos finais.

O exemplo inicia com um efeito Spin, substitui suas operações de preset por um comportamento de rotação e define uma duração de dois segundos para essa operação. Um ângulo relativo de 90 graus representa um quarto de volta a partir da orientação inicial da forma, portanto não é necessário especificar um ângulo inicial explícito.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.SPIN, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    rotation = factory.create_rotation_effect()
    rotation.by = 90
    rotation.timing.duration = 2

    effect.behaviors.add(rotation)

    presentation.save("rotation.pptx", slides.export.SaveFormat.PPTX)
```

`rotation.pptx` contém uma forma e um comportamento de rotação. A coleção, o tempo e os exemplos de edição de rotação abaixo utilizam esse arquivo.

### **Escala**

Use [create_scale_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_scale_effect/) com porcentagens X/Y: [from_address](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/scaleeffect/from_address/) e [to](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/scaleeffect/to/) descrevem o tamanho inicial e final, enquanto [by](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/scaleeffect/by/) descreve uma mudança relativa. Aqui, 100 significa o tamanho original.

O exemplo aumenta ambas as dimensões de 100 % para 125 % em dois segundos. Usar porcentagens horizontais e verticais iguais mantém as proporções da forma; porcentagens diferentes esticariam uma dimensão mais que a outra.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.GROW_SHRINK, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.from_address = draw.PointF(100, 100)
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    effect.behaviors.add(scale)

    presentation.save("scale.pptx", slides.export.SaveFormat.PPTX)
```

### **Cor**

Use [create_color_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_color_effect/) para mudar o preenchimento de azul para laranja. [from_address](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/coloreffect/from_address/) e [to](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/coloreffect/to/) são cores; [by](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/coloreffect/by/) é um deslocamento de cor. [Behavior.properties](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behavior/properties/) identifica o atributo animado.

O preenchimento sólido da forma é inicializado como azul, correspondendo à cor inicial da animação. Selecionar o atributo de cor de preenchimento informa ao comportamento qual parte da forma deve ser alterada; os pontos de cor por si só não identificam esse atributo. O efeito salvo descreve uma transição de dois segundos para laranja.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)
    shape.fill_format.fill_type = slides.FillType.SOLID
    shape.fill_format.solid_fill_color.color = draw.Color.blue

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.CHANGE_FILL_COLOR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    color = factory.create_color_effect()
    color.properties.add(slides.animation.BehaviorProperty.fill_color.value)
    color.from_address.color = draw.Color.blue
    color.to.color = draw.Color.orange
    color.timing.duration = 2

    effect.behaviors.add(color)

    presentation.save("color.pptx", slides.export.SaveFormat.PPTX)
```

### **Filtro**

Use [create_filter_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_filter_effect/) para selecionar um wipe. [type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/filtereffect/type/), [subtype](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/filtereffect/subtype/) e [reveal](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/filtereffect/reveal/) especificam o filtro, a direção e se a forma será revelada ou ocultada.

Este exemplo configura um wipe de dois segundos que revela a forma usando o subtipo de direção à direita. As configurações do filtro pertencem ao comportamento dentro do efeito, portanto são configuradas após a remoção das operações originais do preset.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.WIPE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    filter_behavior = factory.create_filter_effect()
    filter_behavior.type = slides.animation.FilterEffectType.WIPE
    filter_behavior.subtype = slides.animation.FilterEffectSubtype.RIGHT
    filter_behavior.reveal = slides.animation.FilterEffectRevealType.IN
    filter_behavior.timing.duration = 2

    effect.behaviors.add(filter_behavior)

    presentation.save("filter.pptx", slides.export.SaveFormat.PPTX)
```

### **Propriedade**

Use [create_property_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_property_effect/) para animar a opacidade. [from_address](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/propertyeffect/from_address/), [to](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/propertyeffect/to/) e [by](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/propertyeffect/by/) são strings interpretadas usando [value_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/propertyeffect/value_type/) e [calc_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/propertyeffect/calc_mode/). Escolha pontos finais ou um deslocamento relativo ao invés de definir todos os três indiscriminadamente.

Aqui, o atributo selecionado é opacidade, e as strings numéricas representam uma mudança de 25 % de opacidade para opacidade total. A interpolação linear descreve uma mudança gradual entre esses valores. Ao adaptar este exemplo para outro atributo, escolha um tipo de valor e valores de ponto final adequados ao atributo.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    property_behavior = factory.create_property_effect()
    property_behavior.properties.add(slides.animation.BehaviorProperty.style_opacity.value)
    property_behavior.value_type = slides.animation.PropertyValueType.NUMBER
    property_behavior.calc_mode = slides.animation.PropertyCalcModeType.LINEAR
    property_behavior.from_address = "0.25"
    property_behavior.to = "1"
    property_behavior.timing.duration = 2

    effect.behaviors.add(property_behavior)

    presentation.save("property.pptx", slides.export.SaveFormat.PPTX)
```

### **Definir**

Use [create_set_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_set_effect/) para atribuir visibilidade através de [to](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/seteffect/to/). Um comportamento de set não interpola entre pontos finais.

O exemplo seleciona o atributo de visibilidade e atribui a string `visible` quando o comportamento é executado. O retângulo já está visível nesta apresentação mínima, portanto a atribuição pode não gerar uma mudança visual óbvia por si só. Tal operação é útil como parte de um efeito maior que também controla quando a forma se torna oculta ou visível.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.APPEAR, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    set_behavior = factory.create_set_effect()
    set_behavior.properties.add(slides.animation.BehaviorProperty.style_visibility.value)
    set_behavior.to = "visible"

    effect.behaviors.add(set_behavior)

    presentation.save("set.pptx", slides.export.SaveFormat.PPTX)
```

### **Comando**

Use [create_command_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_command_effect/) e configure [type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/commandeffect/type/), [command_string](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/commandeffect/command_string/) e [shape_target](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/commandeffect/shape_target/). Coloque uma gravação WAV chamada `sample.wav` no diretório de trabalho. Este exemplo a incorpora com [add_audio_frame_embedded](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_audio_frame_embedded/) e associa um comando de reprodução ao quadro de áudio.

O quadro de áudio é tanto o alvo do efeito quanto o alvo do comando. Isso conecta a solicitação de reprodução à gravação incorporada; uma string de comando isolada não identifica qual objeto de mídia deve ser controlado. O efeito está configurado para iniciar com um clique durante a apresentação.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with open("sample.wav", "rb") as audio_stream:
        audio_frame = slide.shapes.add_audio_frame_embedded(100, 100, 40, 40, audio_stream)

    effect = slide.timeline.main_sequence.add_effect(audio_frame, slides.animation.EffectType.MEDIA_PLAY, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    command = factory.create_command_effect()
    command.type = slides.animation.CommandEffectType.CALL
    command.command_string = "play"
    command.shape_target = audio_frame

    effect.behaviors.add(command)

    presentation.save("command.pptx", slides.export.SaveFormat.PPTX)
```

Salvar armazena o comando em `command.pptx`; ele não reproduz a gravação. A reprodução requer um leitor de slides que suporte o comando e seu alvo de mídia.

## **Gerenciar a Coleção de Behaviors**

[BehaviorCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorcollection/) suporta [add](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorcollection/add/), [insert](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorcollection/insert/), [remove](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorcollection/remove/) e [remove_at](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorcollection/remove_at/). Este exemplo abre `rotation.pptx`, adiciona escalonamento, move‑o antes da rotação e remove a rotação. Remover e reinserir o mesmo objeto altera sua posição armazenada sem criar uma cópia.

A sequência de edições muda a coleção de rotação‑escala para escala‑rotação, depois para apenas escala. Os índices referem‑se à coleção atual, de modo que a remoção usa o novo índice da rotação após a reorganização. A enumeração final confirma qual comportamento será salvo.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    behaviors = effect.behaviors

    factory = slides.animation.BehaviorFactory()
    scale = factory.create_scale_effect()
    scale.to = draw.PointF(125, 125)
    scale.timing.duration = 2

    behaviors.add(scale)
    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.remove_at(1)

    for behavior in behaviors:
        print(type(behavior).__name__)

    presentation.save("collection-edited.pptx", slides.export.SaveFormat.PPTX)
```

A saída é `ScaleEffect`: apenas a escala permanece. A ordem da coleção não agenda comportamentos um após o outro por si só. Limpe a coleção somente ao substituir todas as suas operações.

## **Configurar o Tempo do Behavior**

[Behavior.timing](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behavior/timing/) expõe [Timing](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/), independentemente de [Effect.timing](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/timing/). O tempo do efeito agenda o efeito contido; o tempo do behavior descreve uma operação dentro dele.

### **Definir Duração, Atraso, Repetição e Aceleração**

Abra `rotation.pptx` e defina [duration](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/duration/) e [trigger_delay_time](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/trigger_delay_time/) em segundos, depois configure [repeat_count](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_count/). [accelerate](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/accelerate/) e [decelerate](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/decelerate/) são frações da duração; mantenha sua soma no máximo 1.

O arquivo de entrada é o criado no exemplo de rotação, onde o primeiro comportamento é conhecido como rotação. Este exemplo altera apenas o tempo desse comportamento; seu ângulo de 90 graus permanece intacto. Manter ângulo e tempo separados facilita ajustar o ritmo sem reconstruir a animação.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    rotation = effect.behaviors[0]
    rotation.timing.duration = 2
    rotation.timing.trigger_delay_time = 0.5
    rotation.timing.repeat_count = 3
    rotation.timing.accelerate = 0.2
    rotation.timing.decelerate = 0.2

    presentation.save("timing.pptx", slides.export.SaveFormat.PPTX)
```

O behavior usa duração de dois segundos, atraso de meio segundo e contagem de repetição 3. Os primeiros e últimos 20 % da duração são usados para aceleração e desaceleração.

Outras políticas de repetição incluem [repeat_duration](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_duration/), [repeat_until_end_slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_until_end_slide/) e [repeat_until_next_click](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/repeat_until_next_click/); escolha uma política ao invés de ativá‑las todas simultaneamente. [auto_reverse](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/timing/auto_reverse/) reproduz a animação ao contrário após a passagem direta. Aceleração e desaceleração aplicam‑se a mudanças contínuas, não a atribuições discretas ou comandos.

## **Criar um Caminho de Movimento**

Use [create_motion_effect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorfactory/create_motion_effect/) para criar movimento. Seus [from_address](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioneffect/from_address/), [to](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioneffect/to/) e [by](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioneffect/by/) descrevem coordenadas ou deslocamentos baseados em porcentagem. Para uma rota editável, crie um [MotionPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motionpath/) e atribua‑o a [MotionEffect.path](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioneffect/path/). [MotionPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motionpath/) armazena os comandos do caminho.

[MotionCommandPathType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioncommandpathtype/) seleciona a operação:

| Comando | Pontos | Significado |
| --- | --- | --- |
| MOVE_TO | Um | Define a posição inicial. |
| LINE_TO | Um | Move ao longo de um segmento reto até seu ponto final. |
| CURVE_TO | Três | Segue uma curva cúbica definida por dois pontos de controle e um ponto final. |
| CLOSE_LOOP | Nenhum | Retorna à posição inicial. |
| END | Nenhum | Finaliza o caminho. |

[MotionPathPointsType](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motionpathpointstype/) descreve características de edição de ponto, como cantos ou pontos suaves. Não substitui o tipo de comando. Use um tipo de ponto de curva para o exemplo de curva abaixo e um tipo de ponto de canto para os segmentos retos.

As coordenadas do caminho são normalizadas às dimensões do slide: um deslocamento X de 0,25 representa um quarto da largura do slide, não 0,25 pontos. Y positivo corre para baixo. Comandos absolutos especificam posições no sistema de coordenadas do caminho; comandos relativos especificam deslocamentos a partir da posição atual. Isso é separado de [origin](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioneffect/origin/), que seleciona a referência do caminho, e [path_edit_mode](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioneffect/path_edit_mode/), que controla como o caminho se move quando a forma é movida.

### **Criar um Caminho Reto**

Crie um comportamento de movimento com um ponto inicial, um segmento reto e um comando de fim. [MotionPath.add](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motionpath/add/) recebe o tipo de comando, seus pontos, o tipo de ponto e um sinalizador de coordenada relativa.

O comando inicial estabelece (0, 0), e a linha termina em (0,25, 0), dando ao trajeto um deslocamento horizontal de um quarto da largura do slide. O comando final não tem pontos de coordenada. Uma vez que o caminho é atribuído, adicionar o comportamento de movimento ao efeito conecta esse trajeto ao retângulo.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 100, 100, 160, 80)

    effect = slide.timeline.main_sequence.add_effect(shape, slides.animation.EffectType.PATH_RIGHT, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)
    effect.behaviors.clear()

    factory = slides.animation.BehaviorFactory()
    motion = factory.create_motion_effect()
    motion.origin = slides.animation.MotionOriginType.LAYOUT
    motion.timing.duration = 2

    path = slides.animation.MotionPath()
    path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0, 0)], slides.animation.MotionPathPointsType.AUTO, False)
    path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.25, 0)], slides.animation.MotionPathPointsType.CORNER, False)
    path.add(slides.animation.MotionCommandPathType.END, [], slides.animation.MotionPathPointsType.NONE, False)

    motion.path = path
    effect.behaviors.add(motion)

    presentation.save("motion.pptx", slides.export.SaveFormat.PPTX)
```

`motion.pptx` contém um comportamento de movimento com três comandos de caminho. Os exemplos de edição de arquivo a seguir usam essa estrutura conhecida.

### **Comparar Coordenadas Absolutas e Relativas**

Esses dois objetos de caminho descrevem o mesmo trajeto. O comando absoluto termina em (0,3, 0,1); o comando relativo adiciona (0,1, 0,1) à posição atual, (0,2, 0).

Ambos os caminhos iniciam na mesma posição. Para a linha relativa, some seus deslocamentos X e Y à posição atual para obter o ponto final; para a linha absoluta, leia o ponto final diretamente. Trocar o sinalizador sem converter as coordenadas descreve um trajeto diferente.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

absolute_path = slides.animation.MotionPath()
absolute_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
absolute_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.3, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)

relative_path = slides.animation.MotionPath()
relative_path.add(slides.animation.MotionCommandPathType.MOVE_TO, [draw.PointF(0.2, 0)], slides.animation.MotionPathPointsType.AUTO, False)
relative_path.add(slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.1, 0.1)], slides.animation.MotionPathPointsType.CORNER, True)
```

Atribua qualquer um dos caminhos a um comportamento de movimento para usá‑lo em uma apresentação. O argumento booleano final seleciona coordenadas relativas para esse comando.

### **Substituir uma Linha por uma Curva**

Abra `motion.pptx` e substitua seu comando de linha por uma curva cúbica. Forneça primeiro os dois pontos de controle, seguidos pelo ponto final.

A posição inicial é fornecida pelo comando anterior. Os dois primeiros pontos moldam a curva, enquanto o terceiro é seu destino; não são três destinos sucessivos. Atualizar simultaneamente o tipo de comando, o tipo de edição de ponto e a matriz de pontos mantém o segmento coerente com sua nova geometria.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path[1].command_type = slides.animation.MotionCommandPathType.CURVE_TO
    path[1].points_type = slides.animation.MotionPathPointsType.CURVE_SMOOTH
    path[1].points = [draw.PointF(0.1, 0), draw.PointF(0.2, 0.1), draw.PointF(0.3, 0.1)]

    presentation.save("curve.pptx", slides.export.SaveFormat.PPTX)
```

O caminho em `curve.pptx` ainda tem três comandos; seu comando do meio agora define uma curva.

## **Inspecionar e Editar um Caminho Salvo**

Cada [MotionCmdPath](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioncmdpath/) expõe [points](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioncmdpath/points/), [command_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioncmdpath/command_type/), [points_type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioncmdpath/points_type/) e [is_relative](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motioncmdpath/is_relative/). Os exemplos a seguir usam o caminho de três comandos conhecido em `motion.pptx`. Para entradas arbitrárias, localize o efeito desejado e verifique tipos de comando e contagem de pontos antes de editar por índice.

### **Ler Comandos e Coordenadas**

Leia o caminho sem modificá‑lo. Comandos de fim e de fechamento de loop não requerem pontos, portanto permita um array de pontos `None`.

A saída associa cada comando ao seu sinalizador de coordenada relativa antes de listar seus pontos. Isso permite distinguir um ponto final de um deslocamento antes de modificar o caminho. Uma curva listaria três pontos, enquanto a linha reta neste arquivo lista apenas um.

```python
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    for segment in motion.path:
        print(f"{segment.command_type}, relative: {segment.is_relative}")
        if segment.points is not None:
            for point in segment.points:
                print(f"X={point.x}, Y={point.y}")
```

O listamento contém um ponto inicial, uma linha absoluta terminando em (0,25, 0) e um comando de fim.

### **Alterar um Ponto Final**

Abra `motion.pptx` e substitua a matriz de pontos da linha para mover seu ponto final.

No arquivo de entrada, o índice 0 é o comando inicial e o índice 1 é a linha. Substituir o único ponto da linha altera seu destino sem mudar o tipo de comando, o tempo ou a posição na coleção. Como o comando usa coordenadas absolutas, o novo par especifica uma posição em vez de um deslocamento adicionado.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    motion = effect.behaviors[0]
    motion.path[1].points = [draw.PointF(0.4, 0.1)]

    presentation.save("motion-endpoint.pptx", slides.export.SaveFormat.PPTX)
```

A linha em `motion-endpoint.pptx` termina em (0,4, 0,1); o arquivo original permanece inalterado.

### **Substituir um Segmento**

Use [insert](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motionpath/insert/) e [remove_at](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/motionpath/remove_at/) para substituir a linha em `motion.pptx`. Inserir desloca a linha antiga para o índice 2.

Isso demonstra a substituição de um objeto de comando em vez de editar suas coordenadas existentes. Após a inserção, a coleção temporariamente contém o comando inicial, a nova linha, a linha antiga e o comando de fim. Remover o índice 2 descarta a linha antiga e mantém a nova rota no lugar.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("motion.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]
    motion = effect.behaviors[0]

    path = motion.path
    path.insert(1, slides.animation.MotionCommandPathType.LINE_TO, [draw.PointF(0.2, 0.1)], slides.animation.MotionPathPointsType.CORNER, False)
    path.remove_at(2)

    presentation.save("motion-edited.pptx", slides.export.SaveFormat.PPTX)
```

O caminho salvo ainda tem três comandos, com a nova linha terminando em (0,2, 0,1) e o comando de fim por último.

## **Modificar e Verificar um Behavior Existente**

Quando o índice do behavior é desconhecido, selecione‑o por tipo. Este exemplo abre `rotation.pptx`, encontra seu [RotationEffect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/rotationeffect/), altera o ângulo e verifica o valor salvo após reabertura.

A verificação de tipo permite que o laço ignore behaviors que não sejam rotações. A segunda carga lê o arquivo salvo em um objeto de apresentação separado, de modo que a comparação verifica os dados persistidos em vez do valor ainda mantido na memória. Este exemplo ainda supõe que o efeito conhecido seja o primeiro na sequência principal; selecionar um behavior por tipo não localiza o efeito correto em uma apresentação arbitrária.

```python
import aspose.slides as slides

with slides.Presentation("rotation.pptx") as presentation:
    effect = presentation.slides[0].timeline.main_sequence[0]

    for behavior in effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            behavior.by = 180

    presentation.save("rotation-edited.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("rotation-edited.pptx") as reopened:
    saved_effect = reopened.slides[0].timeline.main_sequence[0]

    for behavior in saved_effect.behaviors:
        if isinstance(behavior, slides.animation.RotationEffect):
            print(f"Rotation preserved: {abs(behavior.by - 180) < 0.001}")
```

A saída é `Rotation preserved: True`. Aplique o mesmo padrão de verificação de tipo a outros behaviors. Para uma verificação completa de preservação, compare a forma alvo, o efeito, os tipos e a ordem dos behaviors, o tempo e os comandos do caminho. Use uma tolerância numérica para valores de ponto flutuante. Para uma apresentação com layout de animação desconhecido, veja [Read Shape Animations](/slides/pt/python-net/shape-animation/#read-shape-animations) para percorrer sequências principais e interativas.

## **Ordem dos Behaviors, Presets e Reprodução**

A ordem em [BehaviorCollection](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behaviorcollection/) é a ordem armazenada das operações de um efeito. Não é uma playlist em que cada behavior aguarda automaticamente o anterior. O tempo e o efeito que o contém determinam o agendamento. Behaviors podem se sobrepor, e operações na mesma propriedade podem interagir através de [additive](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behavior/additive/) e [accumulate](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/behavior/accumulate/). Não use apenas a reordenação da coleção para agendar “mover, depois girar”; use tempos explícitos ou efeitos separados conforme descrito em [Animação de Forma](/slides/pt/python-net/shape-animation/).

O [type](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/type/) e [subtype](https://reference.aspose.com/slides/pt/python-net/aspose.slides.animation/effect/subtype/) do efeito descrevem seu preset. Eles não são uma descrição completa de uma árvore de behaviors editada. Escolha o preset e o subtipo antes de personalizar behaviors: mudar o preset pode reconstruir a coleção e descartar suas operações customizadas. Por exemplo, mudar um efeito Spin customizado para Fade pode substituir seu behavior de rotação por behaviors de set e filter. Inspecione a coleção novamente após mudar um preset ou subtipo. Limpar behaviors de preset também pode remover operações de visibilidade ou inicialização que o preset necessita. Os exemplos utilizam deliberadamente formas visíveis e substituem os behaviors; eles não recriam a implementação de cada preset.

## **Compatibilidade de Formatos**

Uma árvore de behaviors preservada não garante reprodução idêntica em todos os visualizadores ou renderizadores de exportação. Verifique os dados salvos e a saída renderizada separadamente.

| Formato ou saída | O que verificar |
| --- | --- |
| PPTX | Use como formato principal para estes exemplos. Reabra‑lo para verificar a árvore de behaviors editável e, em seguida, teste a reprodução na versão do PowerPoint pretendida. |
| PPT | A representação binária legada pode diferir do PPTX. Teste um ciclo separado de salvar‑reabrir e reprodução; não assuma suporte para todas as combinações personalizadas com base apenas no sucesso do PPTX. |
| PDF, PNG, JPEG e outras imagens estáticas de slide | Contêm uma representação estática do slide, não uma linha de tempo reproduzível nem um quadro final de animação garantido. |
| [HTML5](/slides/pt/python-net/export-to-html5/) | Pode reproduzir animações suportadas quando a animação de forma está habilitada nas opções de exportação. Teste combinações personalizadas no navegador. |
| [GIF Animado](/slides/pt/python-net/convert-powerpoint-to-animated-gif/) | Armazena quadros renderizados, não behaviors editáveis ou interação por clique. Verifique o movimento efetivamente renderizado. |
| [Vídeo](/slides/pt/python-net/convert-powerpoint-to-video/) | Renderiza quadros de animação e os codifica como vídeo. O suporte está limitado às [animações e efeitos suportados](/slides/pt/python-net/convert-powerpoint-to-video/#supported-animations-and-effects) do renderizador; comandos e eventos interativos não se tornam uma linha de tempo editável. |

## **FAQ**

**Por que meu efeito contém behaviors antes de eu adicionar algum?**

Criar um efeito predefinido pode gerar suas operações subjacentes. Inspecione‑as antes de decidir se estende o preset ou substitui seus behaviors.

**Mover um behavior para o início faz com que ele seja reproduzido primeiro?**

Não necessariamente. A ordem da coleção não substitui o tempo. Verifique atrasos, durações e interações entre operações na mesma propriedade.

**Por que um comando de fim não tem pontos?**

Ele marca o término do caminho e não precisa de coordenadas. Procure um array de pontos `None` ao inspecionar um caminho lido de um arquivo.

**Uma viagem de ida‑e‑volta bem‑sucedida é suficiente para confirmar a reprodução?**

Não. Reabrir confirma a preservação das propriedades verificadas. Teste o leitor de slides ou a exportação animada separadamente para confirmar o comportamento visual.