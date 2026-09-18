---
title: Criar e Modificar Comportamentos de Animação Personalizados em Python via Java
linktitle: Animação Personalizada
type: docs
weight: 151
url: /pt/python-java/custom-animation/
keywords:
- animação personalizada
- comportamento de animação
- caminho de movimento
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Criar, inspecionar e modificar comportamentos de animação personalizados e caminhos de movimento editáveis em apresentações PowerPoint com Aspose.Slides para Python via Java."
---
## **Visão geral**

Comportamentos de animação personalizados permitem que você controle operações individuais dentro de um efeito de animação, como mudar uma cor, girar uma forma ou seguir um caminho de movimento editável. Este guia mostra como criar e combinar comportamentos, configurar seu tempo, inspecionar e modificar animações existentes e verificar se suas propriedades permanecem ao salvar e reabrir uma apresentação.

Para efeitos predefinidos e gatilhos de clique, veja [Animação de Forma](/slides/pt/python-java/shape-animation/).

## **Entenda o Modelo de Animação**

Uma animação é organizada como **Timeline → Sequence → Effect → Behaviors**:

- O método [getTimeline](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseslide/#getTimeline) retorna a linha do tempo do slide, que contém sua sequência principal e sequências interativas.
- Uma [Sequence](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/) contém efeitos, potencialmente direcionados a diferentes formas.
- Um [Effect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/) identifica uma forma alvo, preset, subtipo e o tempo do efeito.
- A coleção retornada por [Effect.getBehaviors](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getBehaviors) contém as operações que implementam o efeito: mudar cor, mover, girar, definir uma propriedade, etc.

## **Crie Comportamentos Individuais**

Chame [Sequence.addEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/sequence/#addEffect) para criar um efeito e acessar a coleção [getBehaviors](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getBehaviors). Um preset pode preencher essa coleção automaticamente. Mantenha suas operações ao estender o preset ou use [clear](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorcollection/#clear) quando substituir deliberadamente.

[BehaviorFactory](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/) cria os oito tipos de comportamento ilustrados abaixo. Movimento é abordado em [Build a Motion Path](#build-a-motion-path). Cada trecho inclui suas importações e inicia a JVM se necessário. Objetos e arrays de ponto Java são criados via JPype onde a API os requer. Exemplos de edição posteriores indicam qual arquivo de saída eles usam.

### **Rotação**

Use [createRotationEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createRotationEffect) para criar uma rotação. [getBy](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotationeffect/#getBy) especifica um ângulo relativo em graus; [getFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotationeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotationeffect/#getTo) especificam os pontos finais.

O exemplo começa com um efeito Spin, substitui suas operações de preset por um único comportamento de rotação e atribui a essa operação uma duração de dois segundos. Um ângulo relativo de 90 graus expressa um quarto de volta a partir da orientação inicial da forma, portanto não é necessário especificar um ângulo inicial explícito.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    rotation = factory.createRotationEffect()
    rotation.setBy(90)
    rotation.getTiming().setDuration(2)

    effect.getBehaviors().add(rotation)

    presentation.save("rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`rotation.pptx` contém uma forma e um comportamento de rotação. A coleção, o tempo e os exemplos de edição de rotação abaixo usam este arquivo.

### **Escala**

Use [createScaleEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createScaleEffect) com percentuais X/Y: [getFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/scaleeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/scaleeffect/#getTo) descrevem o tamanho inicial e final, enquanto [getBy](https://reference.aspose.com/slides/pt/python-java/aspose.slides/scaleeffect/#getBy) descreve uma alteração relativa. Aqui, 100 significa o tamanho original.

O exemplo aumenta ambas as dimensões de 100 % para 125 % em dois segundos. Usar percentuais horizontais e verticais iguais mantém as proporções da forma; percentuais diferentes esticariam uma dimensão mais que a outra.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setFrom(Point2DFloat(100, 100))
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    effect.getBehaviors().add(scale)

    presentation.save("scale.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Cor**

Use [createColorEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createColorEffect) para mudar o preenchimento de azul para laranja. [getFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/coloreffect/#getFrom) e [getTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/coloreffect/#getTo) são cores; [getBy](https://reference.aspose.com/slides/pt/python-java/aspose.slides/coloreffect/#getBy) é um deslocamento de cor. [Behavior.getProperties](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behavior/#getProperties) identifica o atributo que está sendo animado.

O preenchimento sólido da forma é inicializado em azul, correspondendo à cor inicial da animação. Selecionar o atributo de cor de preenchimento informa ao comportamento qual parte da forma mudar; os pontos finais de cor sozinhos não identificam esse atributo. O efeito salvo descreve uma transição de dois segundos para laranja.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, FillType, Presentation, SaveFormat, ShapeType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    color = factory.createColorEffect()
    color.getProperties().add(BehaviorProperty.getFillColor().getValue())
    color.getFrom().setColor(Color.BLUE)
    color.getTo().setColor(Color(255, 165, 0))
    color.getTiming().setDuration(2)

    effect.getBehaviors().add(color)

    presentation.save("color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Filtro**

Use [createFilterEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createFilterEffect) para selecionar uma varredura. [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filtereffect/#getSubtype) e [getReveal](https://reference.aspose.com/slides/pt/python-java/aspose.slides/filtereffect/#getReveal) especificam o filtro, a direção e se revelar ou ocultar a forma.

Este exemplo configura uma varredura de dois segundos que revela a forma usando o subtipo de direção à direita. As configurações do filtro pertencem ao comportamento dentro do efeito, portanto são configuradas após as operações originais do preset terem sido removidas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, FilterEffectRevealType, FilterEffectSubtype, FilterEffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    filter = factory.createFilterEffect()
    filter.setType(FilterEffectType.Wipe)
    filter.setSubtype(FilterEffectSubtype.Right)
    filter.setReveal(FilterEffectRevealType.In)
    filter.getTiming().setDuration(2)

    effect.getBehaviors().add(filter)

    presentation.save("filter.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Propriedade**

Use [createPropertyEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createPropertyEffect) para animar a opacidade. [getFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/propertyeffect/#getTo) e [getBy](https://reference.aspose.com/slides/pt/python-java/aspose.slides/propertyeffect/#getBy) são strings interpretadas usando [getValueType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/propertyeffect/#getValueType) e [getCalcMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/propertyeffect/#getCalcMode). Escolha pontos finais ou um deslocamento relativo em vez de definir os três indiscriminadamente.

Aqui, o atributo selecionado é opacidade, e as strings numéricas representam uma mudança de 25 % de opacidade para opacidade total. Interpolação linear descreve uma mudança gradual entre esses valores. Ao adaptar este exemplo para outro atributo, escolha um tipo de valor e valores de ponto final adequados a esse atributo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, PropertyCalcModeType, PropertyValueType, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    property = factory.createPropertyEffect()
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue())
    property.setValueType(PropertyValueType.Number)
    property.setCalcMode(PropertyCalcModeType.Linear)
    property.setFrom("0.25")
    property.setTo("1")
    property.getTiming().setDuration(2)

    effect.getBehaviors().add(property)

    presentation.save("property.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Definir**

Use [createSetEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createSetEffect) para atribuir visibilidade através de [getTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/seteffect/#getTo). Um comportamento de definição não interpola entre os pontos finais.

O exemplo seleciona o atributo de visibilidade e atribui a string `visible` quando o comportamento é executado. O retângulo já está visível nesta apresentação mínima, portanto a atribuição pode não produzir uma mudança visual óbvia por si só. Essa operação é útil como parte de um efeito maior que também controla quando a forma se torna oculta ou visível.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, BehaviorProperty, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    set = factory.createSetEffect()
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue())
    set.setTo("visible")

    effect.getBehaviors().add(set)

    presentation.save("set.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Comando**

Use [createCommandEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createCommandEffect) e configure [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/pt/python-java/aspose.slides/commandeffect/#getCommandString) e [getShapeTarget](https://reference.aspose.com/slides/pt/python-java/aspose.slides/commandeffect/#getShapeTarget). Coloque uma gravação WAV chamada `sample.wav` no diretório de trabalho. Este exemplo a incorpora com [addAudioFrameEmbedded](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) e anexa um comando de reprodução ao quadro de áudio.

O quadro de áudio é ao mesmo tempo o alvo do efeito e o alvo do comando. Isso conecta a solicitação de reprodução à gravação incorporada; uma string de comando por si só não identifica qual objeto de mídia controlar. O efeito está configurado para iniciar ao clicar durante a apresentação de slides.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path

from asposeslides.api import BehaviorFactory, CommandEffectType, EffectSubtype, EffectTriggerType, EffectType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    audio_data = Path("sample.wav").read_bytes()
    audio_bytes = jpype.JArray(jpype.JByte)(audio_data)
    audio = presentation.getAudios().addAudio(audio_bytes)
    audio_frame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audio)

    effect = slide.getTimeline().getMainSequence().addEffect(audio_frame, EffectType.MediaPlay, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    command = factory.createCommandEffect()
    command.setType(CommandEffectType.Call)
    command.setCommandString("play")
    command.setShapeTarget(audio_frame)

    effect.getBehaviors().add(command)

    presentation.save("command.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Salvar armazena o comando em `command.pptx`; ele não reproduz a gravação. A reprodução requer um visualizador de apresentação que suporte o comando e seu alvo de mídia.

## **Gerencie a Coleção de Comportamentos**

[BehaviorCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorcollection/) suporta [add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorcollection/#remove) e [removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorcollection/#removeAt). Este exemplo abre `rotation.pptx`, adiciona escala, move-a antes da rotação e remove a rotação. Remover e reinserir o mesmo objeto altera sua posição armazenada sem criar uma cópia.

A sequência de edições muda a coleção de rotação–escala para escala–rotação, depois para apenas escala. Índices referem‑se à coleção atual, portanto a remoção usa o novo índice da rotação após a reordenação. A enumeração final confirma qual comportamento será salvo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    behaviors = effect.getBehaviors()

    factory = BehaviorFactory()
    scale = factory.createScaleEffect()
    scale.setTo(Point2DFloat(125, 125))
    scale.getTiming().setDuration(2)

    behaviors.add(scale)

    behaviors.remove(scale)
    behaviors.insert(0, scale)
    behaviors.removeAt(1)

    for behavior in behaviors:
        print(behavior.getClass().getSimpleName())

    presentation.save("collection-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A saída é `ScaleEffect`: apenas a escala permanece. A ordem da coleção não agenda comportamentos um após o outro por si só. Limpe a coleção somente ao substituir todas as suas operações.

## **Configure o Tempo do Comportamento**

[Behavior.getTiming](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behavior/#getTiming) expõe [Timing](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/), independentemente de [Effect.getTiming](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getTiming). O tempo do efeito agenda o efeito envolvente; o tempo do comportamento descreve uma operação dentro dele.

### **Defina Duração, Atraso, Repetição e Aceleração**

Abra `rotation.pptx` e defina a duração ([getDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getDuration)) e o atraso de gatilho ([getTriggerDelayTime](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getTriggerDelayTime)) em segundos, depois configure a contagem de repetições através de [setRepeatCount](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getAccelerate) e [getDecelerate](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getDecelerate) são frações da duração; mantenha sua soma no máximo 1.

O arquivo de entrada é o criado no exemplo de rotação, onde o primeiro comportamento é conhecido como uma rotação. Este exemplo altera apenas o tempo desse comportamento; seu ângulo de 90 graus permanece intacto. Manter ângulo e tempo separados facilita ajustar o ritmo sem reconstruir a animação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    rotation = effect.getBehaviors().get_Item(0)
    rotation.getTiming().setDuration(2)
    rotation.getTiming().setTriggerDelayTime(0.5)
    rotation.getTiming().setRepeatCount(3)
    rotation.getTiming().setAccelerate(0.2)
    rotation.getTiming().setDecelerate(0.2)

    presentation.save("timing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O comportamento usa duração de dois segundos, atraso de meio segundo e contagem de repetições 3. Os primeiros e últimos 20 % da duração são usados para aceleração e desaceleração.

Outras políticas de repetição incluem [getRepeatDuration](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getRepeatUntilEndSlide) e [getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getRepeatUntilNextClick); escolha uma política em vez de habilitá‑las todas juntas. [getAutoReverse](https://reference.aspose.com/slides/pt/python-java/aspose.slides/timing/#getAutoReverse) reproduz a animação ao contrário após a passagem forward. Aceleração e desaceleração aplicam‑se a mudanças contínuas, não a atribuições discretas ou comandos.

## **Crie um Caminho de Movimento**

Use [createMotionEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorfactory/#createMotionEffect) para criar movimento. Seus [getFrom](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioneffect/#getTo) e [getBy](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioneffect/#getBy) descrevem coordenadas ou deslocamentos baseados em percentual. Para uma rota editável, crie um [MotionPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motionpath/) e atribua‑a com [MotionEffect.setPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motionpath/) armazena os comandos do caminho.

[MotionCommandPathType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioncommandpathtype/) seleciona a operação:

| Comando | Pontos | Significado |
| --- | --- | --- |
| MoveTo | Um | Define a posição inicial. |
| LineTo | Um | Move ao longo de um segmento reto até seu ponto final. |
| CurveTo | Três | Segue uma curva cúbica definida por dois pontos de controle e um ponto final. |
| CloseLoop | Nenhum | Retorna à posição inicial. |
| End | Nenhum | Finaliza o caminho. |

[MotionPathPointsType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motionpathpointstype/) descreve características de edição de ponto, como cantos ou pontos suaves. Não substitui o tipo de comando. Use um tipo de ponto de curva para o exemplo de curva abaixo e um tipo de ponto de canto para os segmentos retos.

As coordenadas do caminho são normalizadas às dimensões do slide: um deslocamento X de 0.25 representa um quarto da largura do slide, não 0.25 pontos. Y positivo corre para baixo. Comandos absolutos especificam posições no sistema de coordenadas do caminho; comandos relativos especificam deslocamentos a partir da posição atual. Isso é separado de [getOrigin](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioneffect/#getOrigin), que seleciona o quadro de referência do caminho, e de [getPathEditMode](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioneffect/#getPathEditMode), que controla como o caminho se move quando a forma é movida.

### **Crie um Caminho Reto**

Crie um comportamento de movimento com um ponto inicial, um segmento reto e um comando de fim. [MotionPath.add](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motionpath/#add) recebe o tipo de comando, seus pontos, o tipo de ponto e um sinalizador de coordenada relativa.

O comando inicial estabelece (0, 0), e a linha termina em (0.25, 0), dando ao trajeto um deslocamento horizontal de um quarto da largura do slide. O comando de fim não tem pontos de coordenada. Uma vez que o caminho é atribuído, adicionar o comportamento de movimento ao efeito conecta essa rota ao retângulo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BehaviorFactory, EffectSubtype, EffectTriggerType, EffectType, MotionCommandPathType, MotionOriginType, MotionPath, MotionPathPointsType, Presentation, SaveFormat, ShapeType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80)

    effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None_, EffectTriggerType.OnClick)
    effect.getBehaviors().clear()

    factory = BehaviorFactory()
    motion = factory.createMotionEffect()
    motion.setOrigin(MotionOriginType.Layout)
    motion.getTiming().setDuration(2)

    path = MotionPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0, 0)])
    path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
    path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.25, 0)])
    path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)
    path_points_3 = jpype.JArray(Point2DFloat)(0)
    path.add(MotionCommandPathType.End, path_points_3, MotionPathPointsType.None_, False)

    motion.setPath(path)
    effect.getBehaviors().add(motion)

    presentation.save("motion.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

`motion.pptx` contém um comportamento de movimento com três comandos de caminho. Os exemplos de edição de arquivo a seguir usam essa estrutura conhecida.

### **Compare Coordenadas Absolutas e Relativas**

Esses dois objetos de caminho descrevem a mesma rota. O comando absoluto termina em (0.3, 0.1); o comando relativo adiciona (0.1, 0.1) à posição atual, (0.2, 0).

Ambos os caminhos começam na mesma posição. Para a linha relativa, some seus deslocamentos X e Y à posição atual para obter o ponto final; para a linha absoluta, leia o ponto final diretamente. Trocar o sinalizador sem converter as coordenadas descreveria uma rota diferente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPath, MotionPathPointsType

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

absolute_path = MotionPath()
path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
absolute_path.add(MotionCommandPathType.MoveTo, path_points, MotionPathPointsType.Auto, False)
path_points_2 = jpype.JArray(Point2DFloat)([Point2DFloat(0.3, 0.1)])
absolute_path.add(MotionCommandPathType.LineTo, path_points_2, MotionPathPointsType.Corner, False)

relative_path = MotionPath()
path_points_3 = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0)])
relative_path.add(MotionCommandPathType.MoveTo, path_points_3, MotionPathPointsType.Auto, False)
path_points_4 = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0.1)])
relative_path.add(MotionCommandPathType.LineTo, path_points_4, MotionPathPointsType.Corner, True)
```

Atribua qualquer um dos caminhos a um comportamento de movimento para usá‑lo em uma apresentação. O argumento Boolean final seleciona coordenadas relativas para esse comando.

### **Substitua uma Linha por uma Curva**

Abra `motion.pptx` e substitua seu comando de linha por uma curva cúbica. Forneça primeiro os dois pontos de controle, seguidos do ponto final.

A posição inicial é fornecida pelo comando anterior. Os dois primeiros pontos dão forma à curva, enquanto o terceiro é seu destino; não são três destinos sucessivos. Atualizar simultaneamente o tipo de comando, o tipo de edição de ponto e a matriz de pontos mantém o segmento consistente com sua nova geometria.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo)
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.1, 0), Point2DFloat(0.2, 0.1), Point2DFloat(0.3, 0.1)])
    path.get_Item(1).setPoints(path_points)

    presentation.save("curve.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O caminho em `curve.pptx` ainda tem três comandos; seu comando do meio agora define uma curva.

## **Inspecione e Edite um Caminho Salvo**

Cada [MotionCmdPath](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioncmdpath/) expõe [getPoints](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioncmdpath/#getPointsType) e [isRelative](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motioncmdpath/#isRelative). Os exemplos a seguir usam o caminho de três comandos conhecido em `motion.pptx`. Para entrada arbitrária, localize o efeito desejado e verifique tipos de comando e contagem de pontos antes de editar por índice.

### **Leia Comandos e Coordenadas**

Leia o caminho sem modificá‑lo. Comandos de fim e de fechar‑loop não precisam de pontos, portanto permita uma matriz de pontos nula.

A saída associa cada tipo numérico de comando ao seu sinalizador de coordenada relativa antes de listar seus pontos. Isso permite distinguir um ponto final de um deslocamento antes de modificar o caminho. Uma curva listaria três pontos, enquanto a linha reta neste arquivo lista apenas um.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    for segment in path:
        print(f"{segment.getCommandType()}, relative: {segment.isRelative()}")
        if segment.getPoints() is not None:
            for point in segment.getPoints():
                print(f"X={point.x}, Y={point.y}")
finally:
    presentation.dispose()
```

A listagem contém um ponto inicial, uma linha absoluta terminando em (0.25, 0) e um comando de fim.

### **Mude um Ponto Final**

Abra `motion.pptx` e substitua a matriz de pontos da linha para mover seu ponto final.

No arquivo de entrada, o índice 0 é o comando inicial e o índice 1 é a linha. Substituir o único ponto da linha altera seu destino sem mudar o tipo de comando, o tempo ou a posição na coleção. Como o comando usa coordenadas absolutas, o novo par especifica uma posição em vez de um deslocamento adicional.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    motion = effect.getBehaviors().get_Item(0)
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.4, 0.1)])
    motion.getPath().get_Item(1).setPoints(path_points)

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A linha em `motion-endpoint.pptx` termina em (0.4, 0.1); o arquivo original permanece inalterado.

### **Substitua um Segmento**

Use [insert](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motionpath/#insert) e [removeAt](https://reference.aspose.com/slides/pt/python-java/aspose.slides/motionpath/#removeAt) para substituir a linha em `motion.pptx`. Inserir desloca a linha antiga para o índice 2.

Isso demonstra a substituição de um objeto de comando em vez de editar suas coordenadas existentes. Após a inserção, a coleção temporariamente contém o comando inicial, a nova linha, a linha antiga e o comando de fim. Remover o índice 2 descarta a linha antiga e deixa a nova rota no lugar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MotionCommandPathType, MotionPathPointsType, Presentation, SaveFormat

Point2DFloat = jpype.JClass("java.awt.geom.Point2D$Float")

presentation = Presentation("motion.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)
    motion = effect.getBehaviors().get_Item(0)

    path = motion.getPath()
    path_points = jpype.JArray(Point2DFloat)([Point2DFloat(0.2, 0.1)])
    path.insert(1, MotionCommandPathType.LineTo, path_points, MotionPathPointsType.Corner, False)
    path.removeAt(2)

    presentation.save("motion-edited.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

O caminho salvo ainda tem três comandos, com a nova linha terminando em (0.2, 0.1) e o comando de fim por último.

## **Modifique e Verifique um Comportamento Existente**

Quando o índice do comportamento é desconhecido, selecione‑o por tipo. Este exemplo abre `rotation.pptx`, encontra seu [RotationEffect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/rotationeffect/), altera o ângulo e verifica o valor salvo após reabrir.

A verificação de tipo permite que o laço ignore comportamentos que não sejam rotações. A segunda carga lê o arquivo salvo em um objeto de apresentação separado, de modo que a comparação verifica os dados persistidos em vez do valor ainda mantido na memória. Este exemplo ainda supõe que o efeito conhecido seja o primeiro na sequência principal; selecionar um comportamento por tipo não localiza o efeito correto em uma apresentação arbitrária.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RotationEffect, SaveFormat

presentation = Presentation("rotation.pptx")
try:
    effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

    for behavior in effect.getBehaviors():
        if isinstance(behavior, RotationEffect):
            rotation = behavior
            rotation.setBy(180)

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx)

    reopened = Presentation("rotation-edited.pptx")
    try:
        saved_effect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0)

        for behavior in saved_effect.getBehaviors():
            if isinstance(behavior, RotationEffect):
                rotation = behavior
                print(f"Rotation preserved: {abs(rotation.getBy() - 180) < 0.001}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

A saída é `Rotation preserved: True`. Aplique o mesmo padrão de verificação de tipo a outros comportamentos. Para uma verificação completa de preservação, compare a forma alvo, o efeito, os tipos e a ordem dos comportamentos, o tempo e os comandos de caminho. Use tolerância numérica para valores de ponto flutuante. Para uma apresentação com layout de animação desconhecido, veja [Read Shape Animations](/slides/pt/python-java/shape-animation/#read-shape-animations) para percorrer sequências principal e interativas.

## **Ordem dos Comportamentos, Presets e Reprodução**

A ordem em [BehaviorCollection](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behaviorcollection/) é a ordem armazenada das operações de um efeito. Não é uma lista de reprodução na qual cada comportamento aguarda automaticamente o anterior. Tempo e o efeito envolvente determinam o agendamento. Comportamentos podem se sobrepor, e operações na mesma propriedade podem interagir através de [getAdditive](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behavior/#getAdditive) e [getAccumulate](https://reference.aspose.com/slides/pt/python-java/aspose.slides/behavior/#getAccumulate). Não use apenas a reordenação da coleção para agendar “mover, depois girar”; use tempo explícito ou efeitos separados conforme descrito em [Shape Animation](/slides/pt/python-java/shape-animation/).

Os métodos do efeito [getType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getType) e [getSubtype](https://reference.aspose.com/slides/pt/python-java/aspose.slides/effect/#getSubtype) descrevem seu preset. Eles não são uma descrição completa de uma árvore de comportamentos editada. Escolha o preset e o subtipo antes de personalizar comportamentos: mudar o preset pode reconstruir a coleção e descartar suas operações personalizadas. Por exemplo, mudar um efeito Spin customizado para Fade pode substituir seu comportamento de rotação por comportamentos de set e filter. Inspecione a coleção novamente após mudar um preset ou subtipo. Limpar os comportamentos do preset também pode remover operações de visibilidade ou inicialização que o preset necessita. Os exemplos deliberadamente usam formas visíveis e substituem os comportamentos; eles não recriam a implementação de cada preset.

## **Compatibilidade de Formato**

Uma árvore de comportamentos preservada não garante reprodução idêntica em todo visualizador ou renderizador de exportação. Verifique os dados salvos e a saída renderizada separadamente.

| Formato ou saída | O que verificar |
| --- | --- |
| PPTX | Use como formato principal para estes exemplos. Reabra-o para verificar a árvore de comportamentos editável e, em seguida, teste a reprodução na versão do PowerPoint pretendida. |
| PPT | A representação binária legada pode diferir do PPTX. Teste um ciclo separado de salvar‑e‑reabrir e a reprodução; não infira suporte para toda combinação customizada a partir de um resultado bem‑sucedido em PPTX. |
| PDF, PNG, JPEG e outras imagens estáticas de slides | Contêm uma representação estática do slide, não uma linha do tempo reproduzível ou um quadro final de animação garantido. |
| [HTML5](/slides/pt/python-java/export-to-html5/) | Pode reproduzir animações suportadas quando a animação de forma está habilitada nas opções de exportação. Teste combinações customizadas no navegador. |
| [Animated GIF](/slides/pt/python-java/convert-powerpoint-to-animated-gif/) | Armazena quadros renderizados, não comportamentos editáveis ou interação por clique. Verifique o movimento realmente renderizado. |
| [Video](/slides/pt/python-java/convert-powerpoint-to-video/) | Renderiza quadros de animação e os codifica como vídeo. O suporte é limitado às [animações e efeitos suportados](/slides/pt/python-java/convert-powerpoint-to-video/#supported-animations-and-effects) pelo renderizador; comandos e eventos interativos não se tornam uma linha do tempo editável. |

## **Perguntas Frequentes**

**Por que meu efeito contém comportamentos antes de eu adicionar algum?**  
Criar um efeito predefinido pode gerar suas operações subjacentes. Inspecione‑as antes de decidir se estende o preset ou substitui seus comportamentos.

**Mover um comportamento para o início faz com que ele seja reproduzido primeiro?**  
Não necessariamente. A ordem da coleção não substitui o tempo. Verifique atrasos, durações e interações entre operações na mesma propriedade.

**Por que um comando de fim não tem pontos?**  
Ele marca o final do caminho e não precisa de coordenadas. Verifique uma matriz de pontos nula ao inspecionar um caminho lido de um arquivo.

**Um ciclo completo bem‑sucedido é suficiente para confirmar a reprodução?**  
Não. Reabrir confirma a preservação das propriedades verificadas. Teste o leitor de apresentações ou a exportação animada separadamente para confirmar o comportamento visual.