---
title: Criar e Modificar Comportamentos de Animação Personalizados em Java
linktitle: Animação Personalizada
type: docs
weight: 151
url: /pt/java/custom-animation/
keywords:
- animação personalizada
- comportamento de animação
- caminho de movimento
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Crie, inspecione e modifique comportamentos de animação personalizados e caminhos de movimento editáveis em apresentações PowerPoint com Aspose.Slides para Java."
---
## **Visão geral**

Comportamentos de animação personalizados permitem controlar operações individuais dentro de um efeito de animação, como alterar uma cor, girar uma forma ou seguir um caminho de movimento editável. Este guia mostra como criar e combinar comportamentos, configurar seu tempo, inspecionar e modificar animações existentes e verificar se suas propriedades permanecem ao salvar e reabrir uma apresentação.

Para efeitos predefinidos e gatilhos de clique, veja [Animação de Formas](/slides/pt/java/shape-animation/).

## **Entenda o Modelo de Animação**

A animação é organizada como **Linha do tempo → Sequência → Efeito → Comportamentos**:

- O método [getTimeline](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibaseslide/#getTimeline--) retorna a linha do tempo do slide, que contém sua sequência principal e sequências interativas.
- Um [ISequence](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isequence/) contém efeitos, potencialmente direcionados a diferentes formas.
- Um [IEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/) identifica a forma alvo, predefinição, subtipo e tempo do efeito.
- A coleção retornada por [IEffect.getBehaviors](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#getBehaviors--) contém as operações que implementam o efeito: mudar cor, mover, girar, definir uma propriedade etc.

## **Crie Comportamentos Individuais**

Chame [ISequence.addEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) para criar um efeito e acessar a coleção [getBehaviors](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#getBehaviors--). Uma predefinição pode preencher essa coleção automaticamente. Mantenha suas operações ao estender a predefinição ou use [clear](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorcollection/#clear--) ao substituí‑las deliberadamente.

[IBehaviorFactory](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/) cria os oito tipos de comportamento ilustrados abaixo. Movimento é abordado em [Construir um Trajeto de Movimento](#build-a-motion-path). Cada trecho inclui suas importações; coloque suas instruções executáveis dentro de um método. Exemplos de edição posteriores indicam qual arquivo de saída eles utilizam.

### **Rotação**

Use [createRotationEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createRotationEffect--) para criar uma rotação. [getBy](https://reference.aspose.com/slides/pt/java/com.aspose.slides/irotationeffect/#getBy--) especifica um ângulo relativo em graus; [getFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/irotationeffect/#getFrom--) e [getTo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/irotationeffect/#getTo--) especificam os pontos finais.

O exemplo começa com um efeito Spin, substitui suas operações predefinidas por um comportamento de rotação e atribui a essa operação uma duração de dois segundos. Um ângulo relativo de 90 graus representa um quarto de volta a partir da orientação inicial da forma, portanto não é necessário um ângulo inicial explícito.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IRotationEffect rotation = factory.createRotationEffect();
    rotation.setBy(90f);
    rotation.getTiming().setDuration(2f);

    effect.getBehaviors().add(rotation);

    presentation.save("rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`rotation.pptx` contém uma forma e um comportamento de rotação. A coleção, o tempo e os exemplos de edição de rotação abaixo utilizam este arquivo.

### **Escala**

Use [createScaleEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createScaleEffect--) com porcentagens X/Y: [getFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iscaleeffect/#getFrom--) e [getTo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iscaleeffect/#getTo--) descrevem o tamanho inicial e final, enquanto [getBy](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iscaleeffect/#getBy--) descreve uma mudança relativa. Aqui, 100 significa o tamanho original.

O exemplo aumenta ambas as dimensões de 100 % para 125 % em dois segundos. Usar porcentagens horizontais e verticais iguais preserva as proporções da forma; porcentagens diferentes esticariam uma dimensão mais que a outra.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setFrom(new Point2D.Float(100, 100));
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    effect.getBehaviors().add(scale);

    presentation.save("scale.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Cor**

Use [createColorEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createColorEffect--) para mudar o preenchimento de azul para laranja. [getFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icoloreffect/#getFrom--) e [getTo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icoloreffect/#getTo--) são cores; [getBy](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icoloreffect/#getBy--) é um deslocamento de cor. [IBehavior.getProperties](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehavior/#getProperties--) identifica o atributo que está sendo animado.

O preenchimento sólido da forma é inicialmente azul, correspondendo à cor inicial da animação. Selecionar o atributo de cor de preenchimento indica ao comportamento qual parte da forma mudar; os pontos finais de cor por si só não identificam esse atributo. O efeito salvo descreve uma transição de dois segundos para laranja.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IColorEffect color = factory.createColorEffect();
    color.getProperties().add(BehaviorProperty.getFillColor().getValue());
    color.getFrom().setColor(Color.BLUE);
    Color orange = new Color(255, 165, 0);
    color.getTo().setColor(orange);
    color.getTiming().setDuration(2f);

    effect.getBehaviors().add(color);

    presentation.save("color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Filtro**

Use [createFilterEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createFilterEffect--) para selecionar uma varredura. [getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifiltereffect/#getType--), [getSubtype](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifiltereffect/#getSubtype--), e [getReveal](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ifiltereffect/#getReveal--) especificam o filtro, a direção e se a forma será revelada ou ocultada.

Este exemplo configura uma varredura de dois segundos que revela a forma usando o subtipo de direção direita. As configurações do filtro pertencem ao comportamento dentro do efeito, portanto são configuradas após a remoção das operações originais da predefinição.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IFilterEffect filter = factory.createFilterEffect();
    filter.setType(FilterEffectType.Wipe);
    filter.setSubtype(FilterEffectSubtype.Right);
    filter.setReveal(FilterEffectRevealType.In);
    filter.getTiming().setDuration(2f);

    effect.getBehaviors().add(filter);

    presentation.save("filter.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Propriedade**

Use [createPropertyEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createPropertyEffect--) para animar a opacidade. [getFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipropertyeffect/#getFrom--), [getTo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipropertyeffect/#getTo--), e [getBy](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipropertyeffect/#getBy--) são strings interpretadas usando [getValueType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipropertyeffect/#getValueType--) e [getCalcMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipropertyeffect/#getCalcMode--). Escolha pontos finais ou um deslocamento relativo ao invés de definir os três indiscriminadamente.

Aqui, o atributo selecionado é opacidade, e as strings numéricas representam uma mudança de 25 % de opacidade para opacidade total. A interpolação linear descreve uma mudança gradual entre esses valores. Ao adaptar este exemplo para outro atributo, escolha um tipo de valor e valores de ponto final apropriados para esse atributo.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IPropertyEffect property = factory.createPropertyEffect();
    property.getProperties().add(BehaviorProperty.getStyleOpacity().getValue());
    property.setValueType(PropertyValueType.Number);
    property.setCalcMode(PropertyCalcModeType.Linear);
    property.setFrom("0.25");
    property.setTo("1");
    property.getTiming().setDuration(2f);

    effect.getBehaviors().add(property);

    presentation.save("property.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Definir**

Use [createSetEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createSetEffect--) para atribuir visibilidade através de [getTo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iseteffect/#getTo--). Um comportamento de definição não interpola entre pontos finais.

O exemplo seleciona o atributo de visibilidade e atribui a string `visible` quando o comportamento é executado. O retângulo já está visível nesta apresentação mínima, portanto a atribuição pode não produzir uma mudança visual óbvia por si só. Essa operação é útil como parte de um efeito maior que também controla quando a forma se torna oculta ou visível.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    ISetEffect set = factory.createSetEffect();
    set.getProperties().add(BehaviorProperty.getStyleVisibility().getValue());
    set.setTo("visible");

    effect.getBehaviors().add(set);

    presentation.save("set.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Comando**

Use [createCommandEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createCommandEffect--) e configure [getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icommandeffect/#getType--), [getCommandString](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icommandeffect/#getCommandString--), e [getShapeTarget](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icommandeffect/#getShapeTarget--). Coloque uma gravação WAV chamada `sample.wav` no diretório de trabalho. Este exemplo a incorpora com [addAudioFrameEmbedded](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishapecollection/#addAudioFrameEmbedded-float-float-float-float-java.io.InputStream-) e anexa um comando de reprodução ao quadro de áudio.

O quadro de áudio é tanto o alvo do efeito quanto o alvo do comando. Isso conecta a solicitação de reprodução à gravação incorporada; uma string de comando sozinha não identifica qual objeto de mídia controlar. O efeito é configurado para iniciar ao clique durante a apresentação de slides.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.IOException;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    try (FileInputStream audioStream = new FileInputStream("sample.wav")) {
        IAudioFrame audioFrame = slide.getShapes().addAudioFrameEmbedded(100, 100, 40, 40, audioStream);

        IEffect effect = slide.getTimeline().getMainSequence().addEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
        effect.getBehaviors().clear();

        IBehaviorFactory factory = new BehaviorFactory();
        ICommandEffect command = factory.createCommandEffect();
        command.setType(CommandEffectType.Call);
        command.setCommandString("play");
        command.setShapeTarget(audioFrame);

        effect.getBehaviors().add(command);

        presentation.save("command.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Unable to read sample.wav: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

Salvar armazena o comando em `command.pptx`; ele não reproduz a gravação. A reprodução requer um leitor de apresentação que suporte o comando e seu alvo de mídia.

## **Gerencie a Coleção de Comportamentos**

[IBehaviorCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorcollection/) suporta [add](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorcollection/#add-com.aspose.slides.IBehavior-), [insert](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorcollection/#insert-int-com.aspose.slides.IBehavior-), [remove](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorcollection/#remove-com.aspose.slides.IBehavior-), e [removeAt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorcollection/#removeAt-int-). Este exemplo abre `rotation.pptx`, adiciona escala, move-a antes da rotação e remove a rotação. Remover e reinserir o mesmo objeto altera sua posição armazenada sem criar uma cópia.

A sequência de edições muda a coleção de rotação–escala para escala–rotação e, depois, apenas escala. Os índices referem‑se à coleção atual, portanto a remoção usa o novo índice da rotação após a reordenação. A enumeração final confirma qual comportamento será salvo.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IBehaviorCollection behaviors = effect.getBehaviors();

    IBehaviorFactory factory = new BehaviorFactory();
    IScaleEffect scale = factory.createScaleEffect();
    scale.setTo(new Point2D.Float(125, 125));
    scale.getTiming().setDuration(2f);

    behaviors.add(scale);

    behaviors.remove(scale);
    behaviors.insert(0, scale);
    behaviors.removeAt(1);

    for (IBehavior behavior : behaviors)
        System.out.println(behavior.getClass().getSimpleName());

    presentation.save("collection-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A saída é `ScaleEffect`: apenas a escala permanece. A ordem da coleção não agenda comportamentos um após o outro por si só. Limpe a coleção somente ao substituir todas as suas operações.

## **Configure o Tempo do Comportamento**

[IBehavior.getTiming](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehavior/#getTiming--) expõe [ITiming](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/), independentemente de [IEffect.getTiming](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#getTiming--). O tempo do efeito agenda o efeito envolvente; o tempo do comportamento descreve uma operação dentro dele.

### **Definir Duração, Atraso, Repetição e Aceleração**

Abra `rotation.pptx` e defina a duração ([getDuration](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getDuration--)) e o atraso de gatilho ([getTriggerDelayTime](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getTriggerDelayTime--)) em segundos, depois configure a contagem de repetições através de [setRepeatCount](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#setRepeatCount-float-). [getAccelerate](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getAccelerate--) e [getDecelerate](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getDecelerate--) são frações da duração; mantenha sua soma no máximo 1.

O arquivo de entrada é o criado no exemplo de rotação, onde o primeiro comportamento é conhecido como rotação. Este exemplo altera apenas o tempo desse comportamento; seu ângulo de 90 graus permanece intacto. Manter ângulo e tempo separados facilita ajustar o ritmo sem reconstruir a animação.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IRotationEffect rotation = (IRotationEffect)effect.getBehaviors().get_Item(0);
    rotation.getTiming().setDuration(2f);
    rotation.getTiming().setTriggerDelayTime(0.5f);
    rotation.getTiming().setRepeatCount(3f);
    rotation.getTiming().setAccelerate(0.2f);
    rotation.getTiming().setDecelerate(0.2f);

    presentation.save("timing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O comportamento usa uma duração de dois segundos, um atraso de meio segundo e uma contagem de repetições de 3. Os primeiros e últimos 20 % de sua duração são usados para aceleração e desaceleração.

Outras políticas de repetição incluem [getRepeatDuration](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getRepeatDuration--), [getRepeatUntilEndSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--), e [getRepeatUntilNextClick](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--); escolha uma política ao invés de habilitá‑las todas juntas. [getAutoReverse](https://reference.aspose.com/slides/pt/java/com.aspose.slides/itiming/#getAutoReverse--) reproduz a animação ao contrário após a passagem direta. Aceleração e desaceleração aplicam‑se a mudanças contínuas, não a atribuições discretas ou comandos.

## **Construa um Trajeto de Movimento**

Use [createMotionEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorfactory/#createMotionEffect--) para criar movimento. Seus [getFrom](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioneffect/#getFrom--), [getTo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioneffect/#getTo--), e [getBy](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioneffect/#getBy--) descrevem coordenadas ou deslocamentos baseados em porcentagem. Para uma rota editável, crie um [MotionPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/motionpath/) e atribua‑a com [IMotionEffect.setPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioneffect/#setPath-com.aspose.slides.IMotionPath-). [IMotionPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotionpath/) armazena os comandos do caminho.

[MotionCommandPathType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/motioncommandpathtype/) seleciona a operação:

| Command | Points | Meaning |
| --- | --- | --- |
| MoveTo | Um | Define a posição inicial. |
| LineTo | Um | Move ao longo de um segmento reto até seu ponto final. |
| CurveTo | Três | Siga uma curva cúbica definida por dois pontos de controle e um ponto final. |
| CloseLoop | Nenhum | Retorne à posição inicial. |
| End | Nenhum | Finaliza o trajeto. |

[MotionPathPointsType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/motionpathpointstype/) descreve características de edição de pontos, como canto ou ponto suave. Não substitui o tipo de comando. Use um tipo de ponto de curva para o exemplo de curva abaixo e um tipo de ponto de canto para os segmentos retos.

As coordenadas do caminho são normalizadas às dimensões do slide: um deslocamento X de 0,25 representa um quarto da largura do slide, não 0,25 pontos. Y positivo corre para baixo. Comandos absolutos especificam posições no sistema de coordenadas do caminho; comandos relativos especificam deslocamentos a partir da posição atual. Isso é separado de [getOrigin](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioneffect/#getOrigin--), que seleciona o quadro de referência do caminho, e [getPathEditMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioneffect/#getPathEditMode--), que controla como o caminho se move quando a forma é deslocada.

### **Crie um Trajeto Reto**

Crie um comportamento de movimento com um ponto inicial, um segmento reto e um comando de fim. [IMotionPath.add](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotionpath/#add-int-java.awt.geom.Point2D.Float---int-boolean-) recebe o tipo de comando, seus pontos, o tipo de ponto e um sinalizador de coordenada relativa.

O comando inicial estabelece (0, 0) e a linha termina em (0,25, 0), proporcionando ao trajeto um deslocamento horizontal de um quarto da largura do slide. O comando de fim não possui pontos de coordenada. Uma vez que o caminho é atribuído, adicionar o comportamento de movimento ao efeito conecta esse trajeto ao retângulo.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

    IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
    effect.getBehaviors().clear();

    IBehaviorFactory factory = new BehaviorFactory();
    IMotionEffect motion = factory.createMotionEffect();
    motion.setOrigin(MotionOriginType.Layout);
    motion.getTiming().setDuration(2f);

    IMotionPath path = new MotionPath();
    path.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0, 0) }, MotionPathPointsType.Auto, false);
    path.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.25f, 0) }, MotionPathPointsType.Corner, false);
    path.add(MotionCommandPathType.End, new Point2D.Float[0], MotionPathPointsType.None, false);

    motion.setPath(path);
    effect.getBehaviors().add(motion);

    presentation.save("motion.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`motion.pptx` contém um comportamento de movimento com três comandos de caminho. Os exemplos de edição de arquivo a seguir utilizam esta estrutura conhecida.

### **Compare Coordenadas Absolutas e Relativas**

Esses dois objetos de caminho descrevem a mesma rota. O comando absoluto termina em (0,3, 0,1); o comando relativo adiciona (0,1, 0,1) à posição atual, (0,2, 0).

Ambos os caminhos começam na mesma posição. Para a linha relativa, some seus deslocamentos X e Y à posição atual para obter o ponto final; para a linha absoluta, leia o ponto final diretamente. Trocar o sinalizador sem converter as coordenadas descreve uma rota diferente.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

MotionPath absolutePath = new MotionPath();
absolutePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

MotionPath relativePath = new MotionPath();
relativePath.add(MotionCommandPathType.MoveTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.add(MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Atribua qualquer um dos caminhos a um comportamento de movimento para usá‑lo em uma apresentação. O argumento booleano final seleciona coordenadas relativas para esse comando.

### **Substitua uma Linha por uma Curva**

Abra `motion.pptx` e substitua seu comando de linha por uma curva cúbica. Forneça primeiro os dois pontos de controle, seguidos do ponto final.

A posição inicial é fornecida pelo comando precedente. Os dois primeiros pontos moldam a curva, enquanto o terceiro é seu destino; não são três destinos sucessivos. Atualizar simultaneamente o tipo de comando, o tipo de edição de pontos e a matriz de pontos mantém o segmento consistente com sua nova geometria.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.get_Item(1).setCommandType(MotionCommandPathType.CurveTo);
    path.get_Item(1).setPointsType(MotionPathPointsType.CurveSmooth);
    path.get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.1f, 0), new Point2D.Float(0.2f, 0.1f), new Point2D.Float(0.3f, 0.1f) });

    presentation.save("curve.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O caminho em `curve.pptx` ainda possui três comandos; seu comando do meio agora define uma curva.

## **Inspecione e Edite um Trajeto Salvo**

Cada [IMotionCmdPath](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioncmdpath/) expõe [getPoints](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioncmdpath/#getPoints--), [getCommandType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioncmdpath/#getCommandType--), [getPointsType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioncmdpath/#getPointsType--), e [isRelative](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotioncmdpath/#isRelative--). Os exemplos a seguir utilizam o caminho de três comandos conhecido em `motion.pptx`. Para entrada arbitrária, localize o efeito pretendido e verifique tipos de comando e contagem de pontos antes de editar por índice.

### **Leia Comandos e Coordenadas**

Leia o caminho sem alterá‑lo. Comandos de fim e de fechamento de loop não precisam de pontos, portanto permita uma matriz de pontos nula.

A saída associa cada tipo de comando numérico ao seu sinalizador de coordenada relativa antes de listar seus pontos. Isso permite distinguir um ponto final de um deslocamento antes de modificar o caminho. Uma curva listaria três pontos, enquanto a linha reta neste arquivo lista apenas um.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    for (IMotionCmdPath segment : path)
    {
        System.out.println(segment.getCommandType() + ", relative: " + segment.isRelative());
        if (segment.getPoints() != null)
            for (Point2D.Float point : segment.getPoints())
                System.out.println("X=" + point.x + ", Y=" + point.y);
    }
} finally {
    presentation.dispose();
}
```

A listagem contém um ponto inicial, uma linha absoluta terminando em (0,25, 0) e um comando de fim.

### **Alterar um Ponto Final**

Abra `motion.pptx` e substitua a matriz de pontos da linha para mover seu ponto final.

No arquivo de entrada, o índice 0 é o comando inicial e o índice 1 é a linha. Substituir o único ponto da linha altera seu destino sem mudar seu tipo de comando, tempo ou posição na coleção. Como o comando usa coordenadas absolutas, o novo par especifica uma posição em vez de um deslocamento adicionado.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);
    motion.getPath().get_Item(1).setPoints(new Point2D.Float[] { new Point2D.Float(0.4f, 0.1f) });

    presentation.save("motion-endpoint.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A linha em `motion-endpoint.pptx` termina em (0,4, 0,1); o arquivo original permanece inalterado.

### **Substituir um Segmento**

Use [insert](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotionpath/#insert-int-int-java.awt.geom.Point2D.Float---int-boolean-) e [removeAt](https://reference.aspose.com/slides/pt/java/com.aspose.slides/imotionpath/#removeAt-int-) para substituir a linha em `motion.pptx`. Inserir desloca a linha antiga para o índice 2.

Isso demonstra substituir um objeto de comando ao invés de editar suas coordenadas existentes. Após a inserção, a coleção contém temporariamente o comando inicial, a nova linha, a linha antiga e o comando de fim. Remover o índice 2 descarta a linha antiga e deixa o novo trajeto no lugar.

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

Presentation presentation = new Presentation("motion.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);
    IMotionEffect motion = (IMotionEffect)effect.getBehaviors().get_Item(0);

    IMotionPath path = motion.getPath();
    path.insert(1, MotionCommandPathType.LineTo, new Point2D.Float[] { new Point2D.Float(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
    path.removeAt(2);

    presentation.save("motion-edited.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O caminho salvo ainda tem três comandos, com a nova linha terminando em (0,2, 0,1) e o comando de fim por último.

## **Modifique e Verifique um Comportamento Existente**

Quando o índice do comportamento é desconhecido, selecione‑o por tipo. Este exemplo abre `rotation.pptx`, encontra seu [IRotationEffect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/irotationeffect/), altera o ângulo e verifica o valor salvo após reabertura.

A verificação de tipo permite que o laço ignore comportamentos que não são rotações. O segundo carregamento lê o arquivo salvo em um objeto de apresentação separado, de modo que a comparação verifica os dados persistidos em vez do valor ainda mantido na memória. Este exemplo ainda assume que o efeito conhecido é o primeiro na sequência principal; selecionar um comportamento por tipo não localiza o efeito correto em uma apresentação arbitrária.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("rotation.pptx");
try {
    IEffect effect = presentation.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

    for (IBehavior behavior : effect.getBehaviors())
    {
        if (behavior instanceof IRotationEffect) {
            IRotationEffect rotation = (IRotationEffect) behavior;
            rotation.setBy(180f);
        }
    }

    presentation.save("rotation-edited.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("rotation-edited.pptx");
    try {
        IEffect savedEffect = reopened.getSlides().get_Item(0).getTimeline().getMainSequence().get_Item(0);

        for (IBehavior behavior : savedEffect.getBehaviors())
        {
            if (behavior instanceof IRotationEffect) {
                IRotationEffect rotation = (IRotationEffect) behavior;
                System.out.println("Rotation preserved: " + (Math.abs(rotation.getBy() - 180f) < 0.001f));
            }
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

A saída é `Rotation preserved: true`. Aplique o mesmo padrão de verificação de tipo a outros comportamentos. Para uma verificação completa de preservação, compare a forma alvo, efeito, tipos e ordem dos comportamentos, tempo e comandos do caminho. Use tolerância numérica para valores de ponto flutuante. Para uma apresentação com layout de animação desconhecido, veja [Read Shape Animations](/slides/pt/java/shape-animation/#read-shape-animations) para percorrer sequências principais e interativas.

## **Ordem dos Comportamentos, Predefinições e Reprodução**

A ordem em [IBehaviorCollection](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehaviorcollection/) é a ordem armazenada das operações de um efeito. Não é uma playlist na qual cada comportamento aguarda automaticamente o anterior. Tempo e o efeito envolvente determinam o agendamento. Os comportamentos podem se sobrepor, e operações na mesma propriedade podem interagir através de [getAdditive](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehavior/#getAdditive--) e [getAccumulate](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ibehavior/#getAccumulate--). Não use apenas reordenação da coleção para programar “mover, então girar”; use tempo explícito ou efeitos separados conforme descrito em [Animação de Formas](/slides/pt/java/shape-animation/).

O [getType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#getType--) e [getSubtype](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ieffect/#getSubtype--) do efeito descrevem sua predefinição. Não são uma descrição completa de uma árvore de comportamentos editada. Escolha a predefinição e subtipo antes de personalizar comportamentos: mudar a predefinição pode reconstruir a coleção e descartar suas operações customizadas. Por exemplo, mudar um efeito Spin customizado para Fade pode substituir seu comportamento de rotação por comportamentos de definição e filtro. Inspecione a coleção novamente após mudar uma predefinição ou subtipo. Limpar comportamentos predefinidos também pode remover operações de visibilidade ou inicialização que a predefinição necessita. Os exemplos usam deliberadamente formas visíveis e substituem os comportamentos; não reconstruem a implementação de cada predefinição.

## **Compatibilidade de Formato**

Uma árvore de comportamentos preservada não garante reprodução idêntica em todos os visualizadores ou renderizadores de exportação. Verifique os dados salvos e a saída renderizada separadamente.

| Formato ou saída | O que verificar |
| --- | --- |
| PPTX | Use como formato principal para estes exemplos. Reabra‑lo para verificar a árvore de comportamentos editável e, em seguida, teste a reprodução na versão do PowerPoint desejada. |
| PPT | A representação binária legada pode diferir do PPTX. Teste um ciclo separado de salvar‑reabrir e reproduza; não infera suporte para toda combinação personalizada apenas pelo sucesso no PPTX. |
| PDF, PNG, JPEG e outras imagens estáticas de slides | Contêm uma representação estática do slide, não uma linha do tempo de comportamento reproduzível nem um quadro final de animação garantido. |
| [HTML5](/slides/pt/java/export-to-html5/) | Pode reproduzir animações suportadas quando a animação de forma está habilitada nas opções de exportação. Teste combinações customizadas no navegador. |
| [Animated GIF](/slides/pt/java/convert-powerpoint-to-animated-gif/) | Armazena quadros renderizados, não comportamentos editáveis ou interações acionadas por clique. Verifique o movimento efetivamente renderizado. |
| [Video](/slides/pt/java/convert-powerpoint-to-video/) | Renderiza quadros de animação e os codifica como vídeo. O suporte é limitado às [animações e efeitos suportados](/slides/pt/java/convert-powerpoint-to-video/#supported-animations-and-effects) pelo renderizador; comandos e eventos interativos não se tornam uma linha do tempo editável. |

## **Perguntas Frequentes**

**Por que meu efeito contém comportamentos antes de eu adicionar algum?**

Criar um efeito predefinido pode gerar suas operações subjacentes. Inspecione‑as antes de decidir se estende a predefinição ou substitui seus comportamentos.

**Mover um comportamento para o início faz com que ele seja reproduzido primeiro?**

Não necessariamente. A ordem da coleção não substitui o tempo. Verifique atrasos, durações e interações entre operações na mesma propriedade.

**Por que um comando de fim não tem pontos?**

Ele marca o final do caminho e não requer coordenadas. Ao inspecionar um caminho lido de um arquivo, verifique se a matriz de pontos é nula.

**Um ciclo completo de salvar e reabrir é suficiente para confirmar a reprodução?**

Não. Reabrir confirma a preservação das propriedades verificadas. Teste o leitor de apresentação ou a exportação animada separadamente para confirmar o comportamento visual.