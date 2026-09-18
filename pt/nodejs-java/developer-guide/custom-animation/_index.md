---
title: Criar e Modificar Comportamentos de Animação Personalizados em JavaScript
linktitle: Animação Personalizada
type: docs
weight: 151
url: /pt/nodejs-java/custom-animation/
keywords:
- animação personalizada
- comportamento de animação
- caminho de movimento
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Criar, inspecionar e modificar comportamentos de animação personalizados e caminhos de movimento editáveis em apresentações PowerPoint com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Comportamentos de animação personalizados permitem controlar operações individuais dentro de um efeito de animação, como mudar a cor, girar uma forma ou seguir um caminho de movimento editável. Este guia mostra como criar e combinar comportamentos, configurar seu tempo, inspecionar e modificar animações existentes e verificar se suas propriedades sobrevivem ao salvar e reabrir uma apresentação.

Para efeitos predefinidos e gatilhos de clique, veja [Animação de Forma](/slides/pt/nodejs-java/shape-animation/).

## **Entenda o Modelo de Animação**

Uma animação é organizada como **Timeline → Sequence → Effect → Behaviors**:

- O método [getTimeline](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/#getTimeline) retorna a linha do tempo do slide, que contém sua sequência principal e sequências interativas.
- Uma [Sequence](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/) contém efeitos, possivelmente direcionados a diferentes formas.
- Um [Effect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/) identifica uma forma‑alvo, predefinição, subtipo e tempo do efeito.
- A coleção retornada por [Effect.getBehaviors](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getBehaviors) contém as operações que implementam o efeito: mudar cor, mover, girar, definir uma propriedade etc.

## **Criar Comportamentos Individuais**

Chame [Sequence.addEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sequence/#addEffect) para criar um efeito e acessar a coleção [getBehaviors](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getBehaviors). Uma predefinição pode preencher essa coleção automaticamente. Mantenha suas operações ao estender a predefinição, ou use [clear](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorcollection/#clear) ao substituí‑las deliberadamente.

[BehaviorFactory](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/) cria os oito tipos de comportamento ilustrados abaixo. Movimento é abordado em [Construir um Caminho de Movimento](#build-a-motion-path). Cada trecho inclui suas importações de módulo e pode ser executado como script Node.js com os pacotes `aspose.slides.via.java` e `java` instalados. Execute os exemplos de criação de arquivos antes dos exemplos que leem sua saída. Exemplos de edição posteriores indicam qual arquivo de saída eles utilizam.

### **Rotação**

Use [createRotationEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createRotationEffect) para criar uma rotação. [getBy](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/rotationeffect/#getBy) especifica um ângulo relativo em graus; [getFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/rotationeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/rotationeffect/#getTo) especificam os pontos finais.

O exemplo começa com um efeito Spin, substitui suas operações de predefinição por um comportamento de rotação e dá a essa operação uma duração de dois segundos. Um ângulo relativo de 90 graus representa um quarto de volta a partir da orientação inicial da forma, portanto não é necessário especificar um ângulo inicial explícito.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Spin, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const rotation = factory.createRotationEffect();
    rotation.setBy(90);
    rotation.getTiming().setDuration(2);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contém uma forma e um comportamento de rotação. A coleção, o tempo e os exemplos de edição de rotação abaixo utilizam este arquivo.

### **Escala**

Use [createScaleEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createScaleEffect) com percentuais X/Y: [getFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/scaleeffect/#getFrom) e [getTo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/scaleeffect/#getTo) descrevem o tamanho inicial e final, enquanto [getBy](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/scaleeffect/#getBy) descreve uma mudança relativa. Aqui, 100 significa o tamanho original.

O exemplo aumenta ambas as dimensões de 100 % para 125 % ao longo de dois segundos. Usar percentuais horizontais e verticais iguais mantém as proporções da forma; percentuais diferentes esticariam uma dimensão mais que a outra.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.GrowShrink, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setFrom(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(100), java.newFloat(100)));
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Cor**

Use [createColorEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createColorEffect) para mudar o preenchimento de azul para laranja. [getFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/coloreffect/#getFrom) e [getTo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/coloreffect/#getTo) são cores; [getBy](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/coloreffect/#getBy) é um deslocamento de cor. [Behavior.getProperties](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behavior/#getProperties) identifica o atributo sendo animado.

O preenchimento sólido da forma é iniciado em azul, correspondendo à cor inicial da animação. Selecionar o atributo de preenchimento‑cor indica ao comportamento qual parte da forma deve ser alterada; os pontos de cor sozinhos não identificam esse atributo. O efeito salvo descreve uma transição de dois segundos para laranja.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.ChangeFillColor, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const color = factory.createColorEffect();
    color.getProperties().add(aspose.slides.BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtro**

Use [createFilterEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createFilterEffect) para selecionar uma transição de varredura. [getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filtereffect/#getType), [getSubtype](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filtereffect/#getSubtype) e [getReveal](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filtereffect/#getReveal) especificam o filtro, a direção e se revelar ou ocultar a forma.

Este exemplo configura uma varredura de dois segundos que revela a forma usando o subtipo de direção direita. As configurações do filtro pertencem ao comportamento dentro do efeito, portanto são configuradas após as operações originais da predefinição serem removidas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Wipe, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const filter = factory.createFilterEffect();
    filter.setType(aspose.slides.FilterEffectType.Wipe);
    filter.setSubtype(aspose.slides.FilterEffectSubtype.Right);
    filter.setReveal(aspose.slides.FilterEffectRevealType.In);
    filter.getTiming().setDuration(2);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Propriedade**

Use [createPropertyEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createPropertyEffect) para animar opacidade. [getFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/propertyeffect/#getFrom), [getTo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/propertyeffect/#getTo) e [getBy](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/propertyeffect/#getBy) são strings interpretadas usando [getValueType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/propertyeffect/#getValueType) e [getCalcMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/propertyeffect/#getCalcMode). Escolha pontos finais ou um deslocamento relativo em vez de definir os três indiscriminadamente.

Aqui, o atributo selecionado é opacidade, e as strings numéricas representam uma mudança de 25 % de opacidade para opacidade total. A interpolação linear descreve uma mudança gradual entre esses valores. Ao adaptar este exemplo para outro atributo, escolha um tipo de valor e valores de ponto final adequados ao atributo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const property = factory.createPropertyEffect();
    property.getProperties().add(aspose.slides.BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(aspose.slides.PropertyValueType.Number);
    property.setCalcMode(aspose.slides.PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Definir**

Use [createSetEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createSetEffect) para atribuir visibilidade através de [getTo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/seteffect/#getTo). Um comportamento de definição não interpola entre pontos finais.

O exemplo seleciona o atributo de visibilidade e atribui a string `visible` quando o comportamento é executado. O retângulo já está visível nesta apresentação mínima, portanto a atribuição pode não produzir uma mudança visual óbvia por si só. Essa operação é útil como parte de um efeito maior que também controla quando a forma se torna oculta ou visível.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Appear, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const set = factory.createSetEffect();
    set.getProperties().add(aspose.slides.BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Comando**

Use [createCommandEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createCommandEffect) e configure [getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/commandeffect/#getType), [getCommandString](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/commandeffect/#getCommandString) e [getShapeTarget](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/commandeffect/#getShapeTarget). Coloque uma gravação WAV nomeada `sample.wav` no diretório de trabalho. Este exemplo a incorpora com [addAudioFrameEmbedded](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/#addAudioFrameEmbedded) e anexa um comando de reprodução ao quadro de áudio.

O quadro de áudio é tanto o alvo do efeito quanto o alvo do comando. Isso conecta a solicitação de reprodução à gravação incorporada; uma string de comando isolada não identifica qual objeto de mídia controlar. O efeito é configurado para iniciar ao clicar durante a apresentação de slides.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sample.wav");
    try {
        const audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        const effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, aspose.slides.EffectType.MediaPlay, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        const factory = new aspose.slides.BehaviorFactory();
        const command = factory.createCommandEffect();
        command.setType(java.newByte(aspose.slides.CommandEffectType.Call));
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        audioStream.close();
    }
} finally {
    presentation.dispose();
}
```

Salvar armazena o comando em `command.pptx`; ele não reproduz a gravação. A reprodução requer um reprodutor de slides que suporte o comando e seu alvo de mídia.

## **Gerenciar a Coleção de Comportamentos**

[BehaviorCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorcollection/) oferece suporte a [add](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorcollection/#add), [insert](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorcollection/#insert), [remove](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorcollection/#remove) e [removeAt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorcollection/#removeAt). Este exemplo abre `rotation.pptx`, adiciona escala, move‑a antes da rotação e remove a rotação. Remover e reinserir o mesmo objeto altera sua posição armazenada sem criar uma cópia.

A sequência de edições muda a coleção de rotação‑escala para escala‑rotação e, finalmente, para apenas escala. Os índices referem‑se à coleção atual, de modo que a remoção usa o novo índice da rotação após a reordenação. A enumeração final confirma qual comportamento será salvo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const behaviors = effect.getBehaviors();

    const factory = new aspose.slides.BehaviorFactory();
    const scale = factory.createScaleEffect();
    scale.setTo(java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(125), java.newFloat(125)));
    scale.getTiming().setDuration(2);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (let i = 0; i < behaviors.getCount(); i++) {
        const behavior = behaviors.get_Item(i);
        console.log(behavior.getClass().getSimpleName());
    }

    presentation.save("collection-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A saída é `ScaleEffect`: apenas a escala permanece. A ordem da coleção, por si só, não agenda comportamentos sequencialmente. Limpe a coleção somente ao substituir todas as suas operações.

## **Configurar o Tempo do Comportamento**

[Behavior.getTiming](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behavior/#getTiming) expõe [Timing](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/), independentemente de [Effect.getTiming](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getTiming). O tempo do efeito agenda o efeito envolvente; o tempo do comportamento descreve uma operação dentro dele.

### **Definir Duração, Atraso, Repetição e Aceleração**

Abra `rotation.pptx` e defina a duração ([getDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getDuration)) e o atraso de gatilho ([getTriggerDelayTime](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getTriggerDelayTime)) em segundos, depois configure a contagem de repetições através de [setRepeatCount](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#setRepeatCount). [getAccelerate](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getAccelerate) e [getDecelerate](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getDecelerate) são frações da duração; mantenha a soma delas em no máximo 1.

O arquivo de entrada é o criado no exemplo de rotação, onde o primeiro comportamento é conhecido como rotação. Este exemplo altera apenas o tempo desse comportamento; seu ângulo de 90 graus permanece intacto. Manter ângulo e tempo separados facilita ajustar o ritmo sem reconstruir a animação.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const rotation = effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2);
    rotation.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    rotation.getTiming().setRepeatCount(3);
    rotation.getTiming().setAccelerate(java.newFloat(0.2));
    rotation.getTiming().setDecelerate(java.newFloat(0.2));

    presentation.save("timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O comportamento usa uma duração de dois segundos, um atraso de meio segundo e uma contagem de repetições de 3. Os primeiros e últimos 20 % da sua duração são usados para aceleração e desaceleração.

Outras políticas de repetição incluem [getRepeatDuration](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getRepeatDuration), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide) e [getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick); escolha uma política em vez de habilitar todas ao mesmo tempo. [getAutoReverse](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/timing/#getAutoReverse) reproduz a animação ao contrário após a passagem direta. Aceleração e desaceleração aplicam‑se a mudanças contínuas, não a atribuições discretas ou comandos.

## **Construir um Caminho de Movimento**

Use [createMotionEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorfactory/#createMotionEffect) para criar movimento. Seu [getFrom](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioneffect/#getFrom), [getTo](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioneffect/#getTo) e [getBy](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioneffect/#getBy) descrevem coordenadas ou deslocamentos baseados em percentuais. Para uma rota editável, crie um [MotionPath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motionpath/) e atribua‑o com [MotionEffect.setPath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioneffect/#setPath). [MotionPath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motionpath/) armazena os comandos do caminho.

[MotionCommandPathType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioncommandpathtype/) seleciona a operação:

| Comando | Pontos | Significado |
| --- | --- | --- |
| MoveTo | Um | Define a posição inicial. |
| LineTo | Um | Move ao longo de um segmento reto até seu ponto final. |
| CurveTo | Três | Segue uma curva cúbica definida por dois pontos de controle e um ponto final. |
| CloseLoop | Nenhum | Retorna à posição inicial. |
| End | Nenhum | Finaliza o caminho. |

[MotionPathPointsType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motionpathpointstype/) descreve características de edição de pontos, como cantos ou pontos suaves. Não substitui o tipo de comando. Use um tipo de ponto de curva para o exemplo de curva abaixo e um tipo de ponto de canto para os segmentos retos.

As coordenadas do caminho são normalizadas às dimensões do slide: um deslocamento X de 0,25 representa um quarto da largura do slide, não 0,25 pontos. Y positivo corre para baixo. Comandos absolutos especificam posições no sistema de coordenadas do caminho; comandos relativos especificam deslocamentos a partir da posição atual. Isso é separado de [getOrigin](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioneffect/#getOrigin), que seleciona o referencial do caminho, e de [getPathEditMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioneffect/#getPathEditMode), que controla como o caminho se movimenta quando a forma é movida.

### **Criar um Caminho Reto**

Crie um comportamento de movimento com um ponto inicial, um segmento reto e um comando de fim. [MotionPath.add](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motionpath/#add) recebe o tipo de comando, seus pontos, o tipo de ponto e um sinalizador de coordenada relativa.

O comando inicial estabelece (0, 0), e a linha termina em (0.25, 0), dando ao trajeto um deslocamento horizontal de um quarto da largura do slide. O comando final não tem pontos de coordenada. Depois que o caminho é atribuído, adicionar o comportamento de movimento ao efeito conecta esse trajeto ao retângulo.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 160, 80);

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.PathRight, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    const factory = new aspose.slides.BehaviorFactory();
    const motion = factory.createMotionEffect();
    motion.setOrigin(aspose.slides.MotionOriginType.Layout);
    motion.getTiming().setDuration(2);

    const path = new aspose.slides.MotionPath();
    path.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
    path.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.25), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.add(aspose.slides.MotionCommandPathType.End, java.newArray("java.awt.geom.Point2D$Float", []), aspose.slides.MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contém um comportamento de movimento com três comandos de caminho. Os exemplos de edição de arquivo a seguir utilizam esta estrutura conhecida.

### **Comparar Coordenadas Absolutas e Relativas**

Esses dois objetos de caminho descrevem o mesmo trajeto. O comando absoluto termina em (0.3, 0.1); o comando relativo adiciona (0.1, 0.1) à posição atual, (0.2, 0).

Ambos os caminhos iniciam na mesma posição. Para a linha relativa, some seus deslocamentos X e Y à posição atual para obter o ponto final; para a linha absoluta, leia o ponto final diretamente. Trocar o sinalizador sem converter as coordenadas resultaria em um trajeto diferente.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const absolutePath = new aspose.slides.MotionPath();
absolutePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
absolutePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);

const relativePath = new aspose.slides.MotionPath();
relativePath.add(aspose.slides.MotionCommandPathType.MoveTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0))]), aspose.slides.MotionPathPointsType.Auto, false);
relativePath.add(aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, true);
```

Atribua qualquer um dos caminhos a um comportamento de movimento para usá‑lo em uma apresentação. O argumento booleano final seleciona coordenadas relativas para esse comando.

### **Substituir uma Linha por uma Curva**

Abra `motion.pptx` e substitua seu comando de linha por uma curva cúbica. Forneça primeiro os dois pontos de controle, seguidos pelo ponto final.

A posição inicial é fornecida pelo comando anterior. Os dois primeiros pontos moldam a curva, enquanto o terceiro é seu destino; eles não são três destinos sucessivos. Atualizar simultaneamente o tipo de comando, o tipo de edição de ponto e o array de pontos mantém o segmento consistente com sua nova geometria.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.get_Item(1).setCommandType(aspose.slides.MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(aspose.slides.MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.1), java.newFloat(0)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1)), java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.3), java.newFloat(0.1))]));

    presentation.save("curve.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O caminho em `curve.pptx` ainda possui três comandos; seu comando do meio agora define uma curva.

## **Inspecionar e Editar um Caminho Salvo**

Cada [MotionCmdPath](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioncmdpath/) expõe [getPoints](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioncmdpath/#getPoints), [getCommandType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioncmdpath/#getCommandType), [getPointsType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioncmdpath/#getPointsType) e [isRelative](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motioncmdpath/#isRelative). Os exemplos a seguir utilizam o caminho conhecido de três comandos em `motion.pptx`. Para entrada arbitrária, localize o efeito desejado e verifique os tipos de comando e a contagem de pontos antes de editar por índice.

### **Ler Comandos e Coordenadas**

Leia o caminho sem alterá‑lo. Comandos de fim e de fechamento de loop não precisam de pontos, portanto permita um array de pontos nulo.

A saída associa cada tipo numérico de comando ao seu sinalizador de coordenada relativa antes de listar seus pontos. Isso permite distinguir um ponto final de um deslocamento antes de modificar o caminho. Uma curva listaria três pontos, enquanto a linha reta neste arquivo lista apenas um.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    for (let i = 0; i < path.getCount(); i++) {
        const segment = path.get_Item(i);
        console.log(segment.getCommandType() + ", relative: " + segment.isRelative());
        const points = segment.getPoints();
        if (points != null) {
            for (const point of points) {
                console.log("X=" + point.getX() + ", Y=" + point.getY());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

A listagem contém um ponto inicial, uma linha absoluta terminando em (0.25, 0) e um comando de fim.

### **Alterar um Ponto Final**

Abra `motion.pptx` e substitua o array de pontos da linha para mover seu ponto final.

No arquivo de entrada, o índice 0 é o comando inicial e o índice 1 é a linha. Substituir o único ponto da linha altera seu destino sem mudar o tipo de comando, o tempo ou a posição na coleção. Como o comando usa coordenadas absolutas, o novo par especifica uma posição em vez de um deslocamento adicionado.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    const motion = effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.4), java.newFloat(0.1))]));

    presentation.save("motion-endpoint.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A linha em `motion-endpoint.pptx` termina em (0.4, 0.1); o arquivo original permanece inalterado.

### **Substituir um Segmento**

Use [insert](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motionpath/#insert) e [removeAt](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/motionpath/#removeAt) para substituir a linha em `motion.pptx`. Inserir desloca a linha antiga para o índice 2.

Isso demonstra a substituição de um objeto de comando ao invés de editar suas coordenadas existentes. Após a inserção, a coleção contém temporariamente o comando inicial, a nova linha, a linha antiga e o comando de fim. Remover o índice 2 descarta a linha antiga e deixa a nova rota no lugar.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("motion.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    const motion = effect.getBehaviors().get_Item(0);

    const path = motion.getPath();
    path.insert(1, aspose.slides.MotionCommandPathType.LineTo, java.newArray("java.awt.geom.Point2D$Float", [java.newInstanceSync("java.awt.geom.Point2D$Float", java.newFloat(0.2), java.newFloat(0.1))]), aspose.slides.MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O caminho salvo ainda tem três comandos, com a nova linha terminando em (0.2, 0.1) e o comando de fim por último.

## **Modificar e Verificar um Comportamento Existente**

Quando o índice do comportamento é desconhecido, selecione‑o por tipo. Este exemplo abre `rotation.pptx`, encontra seu [RotationEffect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/rotationeffect/), altera o ângulo e verifica o valor salvo após reabrir.

A verificação de tipo permite que o laço ignore comportamentos que não sejam rotações. O segundo carregamento lê o arquivo salvo em um objeto de apresentação separado, de modo que a comparação verifica dados persistidos em vez do valor ainda mantido na memória. Este exemplo ainda supõe que o efeito conhecido seja o primeiro na sequência principal; selecionar um comportamento por tipo não localiza o efeito correto em uma apresentação arbitrária.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("rotation.pptx");
try {
    const effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (let i = 0; i < effect.getBehaviors().getCount(); i++) {
        const behavior = effect.getBehaviors().get_Item(i);
        if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
            const rotation = behavior;
            rotation.setBy(180);
        }
    }

    presentation.save("rotation-edited.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("rotation-edited.pptx");
    try {
        const savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (let i = 0; i < savedEffect.getBehaviors().getCount(); i++) {
            const behavior = savedEffect.getBehaviors().get_Item(i);
            if (java.instanceOf(behavior, "com.aspose.slides.IRotationEffect")) {
                const rotation = behavior;
                console.log("Rotation preserved: " + (Math.abs(rotation.getBy() - 180) < 0.001));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A saída é `Rotation preserved: true`. Aplique o mesmo padrão de verificação de tipo a outros comportamentos. Para uma verificação completa de preservação, compare a forma‑alvo, o efeito, os tipos e a ordem dos comportamentos, o tempo e os comandos do caminho. Use tolerância numérica para valores de ponto flutuante. Para uma apresentação com layout de animação desconhecido, veja [Read Shape Animations](/slides/pt/nodejs-java/shape-animation/#read-shape-animations) para percorrer sequências principais e interativas.

## **Ordem dos Comportamentos, Predefinições e Reprodução**

A ordem em [BehaviorCollection](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behaviorcollection/) é a ordem armazenada das operações de um efeito. Não é uma lista de reprodução em que cada comportamento espera automaticamente o anterior. O tempo e o efeito envolvente determinam o agendamento. Os comportamentos podem se sobrepor, e operações sobre a mesma propriedade podem interagir através de [getAdditive](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behavior/#getAdditive) e [getAccumulate](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/behavior/#getAccumulate). Não use apenas a reordenação da coleção para programar “mover, depois girar”; use tempo explícito ou efeitos separados como descrito em [Animação de Forma](/slides/pt/nodejs-java/shape-animation/).

O [getType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getType) e o [getSubtype](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effect/#getSubtype) do efeito descrevem sua predefinição. Não constituem uma descrição completa de uma árvore de comportamento editada. Escolha a predefinição e o subtipo antes de personalizar comportamentos: mudar a predefinição pode reconstruir a coleção e descartar suas operações personalizadas. Por exemplo, mudar um efeito Spin personalizado para Fade pode substituir seu comportamento de rotação por comportamentos de definição e filtro. Inspecione a coleção novamente após mudar uma predefinição ou subtipo. Limpar comportamentos de predefinição também pode remover operações de visibilidade ou inicialização que a predefinição necessita. Os exemplos usam deliberadamente formas visíveis e substituem os comportamentos; eles não reconstruem toda a implementação da predefinição.

## **Compatibilidade de Formato**

Uma árvore de comportamento preservada não garante reprodução idêntica em todo visualizador ou renderizador de exportação. Verifique os dados salvos e a saída renderizada separadamente.

| Formato ou saída | O que verificar |
| --- | --- |
| PPTX | Use como formato principal para estes exemplos. Reabra‑o para verificar a árvore de comportamentos editável, depois verifique a reprodução na versão do PowerPoint pretendida. |
| PPT | Representação binária legada pode diferir do PPTX. Teste um ciclo separado de salvar‑reabrir e reprodução; não infira suporte para toda combinação personalizada a partir de um sucesso de saída PPTX. |
| PDF, PNG, JPEG e outras imagens estáticas de slide | Contêm uma representação estática do slide, não uma linha de tempo de comportamentos reproduzível nem um quadro final de animação garantido. |
| [HTML5](/slides/pt/nodejs-java/export-to-html5/) | Pode reproduzir animações suportadas quando a animação de forma está habilitada nas opções de exportação. Teste combinações personalizadas no navegador. |
| [Animated GIF](/slides/pt/nodejs-java/convert-powerpoint-to-animated-gif/) | Armazena quadros renderizados, não comportamentos editáveis ou interação acionada por clique. Verifique o movimento realmente renderizado. |
| [Video](/slides/pt/nodejs-java/convert-powerpoint-to-video/) | Renderiza quadros de animação e os codifica como vídeo. O suporte está limitado às [animações e efeitos suportados](/slides/pt/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects); comandos e eventos interativos não se tornam uma linha de tempo editável. |

## **Perguntas Frequentes**

**Por que meu efeito contém comportamentos antes de eu adicionar qualquer um?**

Criar um efeito predefinido pode gerar suas operações subjacentes. Inspecione‑as antes de decidir se estende a predefinição ou substitui seus comportamentos.

**Mover um comportamento para o início faz com que ele seja reproduzido primeiro?**

Nem sempre. A ordem da coleção não substitui o tempo. Verifique atrasos, durações e interações entre operações sobre o mesmo atributo.

**Por que um comando de fim não tem pontos?**

Ele marca o fim do caminho e não precisa de coordenadas. Verifique um array de pontos nulo ao inspecionar um caminho lido de um arquivo.

**Uma viagem de ida‑e‑volta bem‑sucedida é suficiente para confirmar a reprodução?**

Não. Reabrir confirma a preservação das propriedades verificadas. Teste o reprodutor de slides ou a exportação animada separadamente para confirmar seu comportamento visual.