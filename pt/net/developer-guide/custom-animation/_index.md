---
title: Criar e Modificar Comportamentos de Animação Personalizados em .NET
linktitle: Animação Personalizada
type: docs
weight: 151
url: /pt/net/custom-animation/
keywords:
- animação personalizada
- comportamento de animação
- caminho de movimento
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Criar, inspecionar e modificar comportamentos de animação personalizados e caminhos de movimento editáveis em apresentações PowerPoint com Aspose.Slides para .NET."
---
## **Visão geral**

Comportamentos de animação personalizados permitem controlar operações individuais dentro de um efeito de animação, como mudar uma cor, girar uma forma ou seguir um caminho de movimento editável. Este guia mostra como criar e combinar comportamentos, configurar seu tempo, inspecionar e modificar animações existentes e verificar se suas propriedades permanecem ao salvar e reabrir uma apresentação.

Para efeitos pré-definidos e gatilhos de clique, veja [Animação de Formas](/slides/pt/net/shape-animation/).

## **Entenda o Modelo de Animação**

Uma animação é organizada como **Timeline → Sequence → Effect → Behaviors**:

- O slide's [Timeline](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/timeline/) contém sua sequência principal e sequências interativas.
- Uma [ISequence](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/) contém efeitos, potencialmente direcionados a diferentes formas.
- Um [IEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/) identifica uma forma de destino, predefinição, subtipo e tempo do efeito.
- [IEffect.Behaviors](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/behaviors/) contém as operações que implementam o efeito: mudar cor, mover, girar, definir uma propriedade etc.

## **Crie Comportamentos Individuais**

Chame [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/addeffect/) para criar um efeito e acessar sua coleção [Behaviors](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/behaviors/). Uma predefinição pode popular essa coleção automaticamente. Mantenha suas operações ao estender a predefinição ou use [Clear](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorcollection/clear/) ao substituir deliberadamente.

[IBehaviorFactory](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/) cria os oito tipos de comportamento ilustrados abaixo. Movimento é abordado em [Criar um Caminho de Movimento](#criar-um-caminho-de-movimento). Cada exemplo de criação é um programa completo; exemplos de edição posteriores indicam qual arquivo de saída eles utilizam.

### **Rotação**

Use [CreateRotationEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createrotationeffect/) para criar uma rotação. [By](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/irotationeffect/by/) especifica um ângulo relativo em graus; [From](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/irotationeffect/from/) e [To](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/irotationeffect/to/) especificam pontos finais.

O exemplo começa com um efeito Spin, substitui suas operações predefinidas por um comportamento de rotação e atribui a essa operação uma duração de dois segundos. Um ângulo relativo de 90 graus representa um quarto de volta a partir da orientação inicial da forma, portanto não é necessário um ângulo inicial explícito.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Spin, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var rotation = factory.CreateRotationEffect();
rotation.By = 90f;
rotation.Timing.Duration = 2f;

effect.Behaviors.Add(rotation);

presentation.Save("rotation.pptx", SaveFormat.Pptx);
```

`rotation.pptx` contém uma forma e um comportamento de rotação. A coleção, o tempo e os exemplos de edição de rotação abaixo utilizam este arquivo.

### **Escala**

Use [CreateScaleEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createscaleeffect/) com percentuais X/Y: [From](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/iscaleeffect/from/) e [To](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/iscaleeffect/to/) descrevem o tamanho inicial e final, enquanto [By](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/iscaleeffect/by/) descreve uma alteração relativa. Aqui, 100 significa o tamanho original.

O exemplo aumenta ambas as dimensões de 100 % para 125 % em dois segundos. Usar percentuais horizontais e verticais iguais mantém as proporções da forma; percentuais diferentes esticariam uma dimensão mais que a outra.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.GrowShrink, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.From = new PointF(100, 100);
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

effect.Behaviors.Add(scale);

presentation.Save("scale.pptx", SaveFormat.Pptx);
```

### **Cor**

Use [CreateColorEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createcoloreffect/) para mudar o preenchimento de azul para laranja. [From](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/icoloreffect/from/) e [To](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/icoloreffect/to/) são cores; [By](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/icoloreffect/by/) é um deslocamento de cor. [IBehavior.Properties](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehavior/properties/) identifica o atributo que está sendo animado.

O preenchimento sólido da forma é inicializado em azul, correspondendo à cor inicial da animação. Selecionar o atributo de cor de preenchimento indica ao comportamento qual parte da forma mudar; os pontos de cor sozinhos não identificam esse atributo. O efeito salvo descreve uma transição de dois segundos para laranja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Blue;

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.ChangeFillColor, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var color = factory.CreateColorEffect();
color.Properties.Add(BehaviorProperty.FillColor);
color.From.Color = Color.Blue;
color.To.Color = Color.Orange;
color.Timing.Duration = 2f;

effect.Behaviors.Add(color);

presentation.Save("color.pptx", SaveFormat.Pptx);
```

### **Filtro**

Use [CreateFilterEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createfiltereffect/) para selecionar um wipe. [Type](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ifiltereffect/type/), [Subtype](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ifiltereffect/subtype/) e [Reveal](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ifiltereffect/reveal/) especificam o filtro, a direção e se revelar ou ocultar a forma.

Este exemplo configura um wipe de dois segundos que revela a forma usando o subtipo de direção direita. As configurações do filtro pertencem ao comportamento dentro do efeito, portanto são configuradas após a remoção das operações originais da predefinição.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Wipe, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var filter = factory.CreateFilterEffect();
filter.Type = FilterEffectType.Wipe;
filter.Subtype = FilterEffectSubtype.Right;
filter.Reveal = FilterEffectRevealType.In;
filter.Timing.Duration = 2f;

effect.Behaviors.Add(filter);

presentation.Save("filter.pptx", SaveFormat.Pptx);
```

### **Propriedade**

Use [CreatePropertyEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createpropertyeffect/) para animar a opacidade. [From](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ipropertyeffect/from/), [To](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ipropertyeffect/to/) e [By](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ipropertyeffect/by/) são strings interpretadas usando [ValueType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ipropertyeffect/valuetype/) e [CalcMode](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ipropertyeffect/calcmode/). Escolha pontos finais ou um deslocamento relativo ao invés de definir os três indiscriminadamente.

Aqui, o atributo selecionado é opacidade, e as strings numéricas representam uma mudança de 25 % de opacidade para opacidade total. Interpolação linear descreve uma mudança gradual entre esses valores. Ao adaptar este exemplo para outro atributo, escolha um tipo de valor e valores de ponto final apropriados ao atributo.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var property = factory.CreatePropertyEffect();
property.Properties.Add(BehaviorProperty.StyleOpacity);
property.ValueType = PropertyValueType.Number;
property.CalcMode = PropertyCalcModeType.Linear;
property.From = "0.25";
property.To = "1";
property.Timing.Duration = 2f;

effect.Behaviors.Add(property);

presentation.Save("property.pptx", SaveFormat.Pptx);
```

### **Definir**

Use [CreateSetEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createseteffect/) para atribuir visibilidade através de [To](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/iseteffect/to/). Um comportamento de definição não interpola entre os pontos finais.

O exemplo seleciona o atributo de visibilidade e atribui a string `visible` quando o comportamento é executado. O retângulo já está visível nesta apresentação mínima, portanto a atribuição pode não produzir uma mudança visual óbvia por si só. Tal operação é útil como parte de um efeito maior que também controla quando a forma se torna oculta ou visível.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Appear, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var set = factory.CreateSetEffect();
set.Properties.Add(BehaviorProperty.StyleVisibility);
set.To = "visible";

effect.Behaviors.Add(set);

presentation.Save("set.pptx", SaveFormat.Pptx);
```

### **Comando**

Use [CreateCommandEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createcommandeffect/) e configure [Type](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/icommandeffect/type/), [CommandString](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/icommandeffect/commandstring/) e [ShapeTarget](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/icommandeffect/shapetarget/). Coloque uma gravação WAV chamada `sample.wav` no diretório de trabalho. Este exemplo a incorpora com [AddAudioFrameEmbedded](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addaudioframeembedded/) e anexa um comando de reproduzir ao quadro de áudio.

O quadro de áudio é tanto o alvo do efeito quanto o alvo do comando. Isso conecta a solicitação de reprodução à gravação incorporada; uma string de comando isolada não identifica qual objeto de mídia controlar. O efeito está configurado para iniciar ao clicar durante a apresentação.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("sample.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(100, 100, 40, 40, audioStream);

var effect = slide.Timeline.MainSequence.AddEffect(audioFrame, EffectType.MediaPlay, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var command = factory.CreateCommandEffect();
command.Type = CommandEffectType.Call;
command.CommandString = "play";
command.ShapeTarget = audioFrame;

effect.Behaviors.Add(command);

presentation.Save("command.pptx", SaveFormat.Pptx);
```

Salvar armazena o comando em `command.pptx`; ele não reproduz a gravação. A reprodução requer um player de apresentação que suporte o comando e seu alvo de mídia.

## **Gerencie a Coleção de Comportamentos**

[IBehaviorCollection](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorcollection/) suporta [Add](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorcollection/add/), [Insert](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorcollection/insert/), [Remove](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorcollection/remove/) e [RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorcollection/removeat/). Este exemplo abre `rotation.pptx`, adiciona escala, move-a antes da rotação e remove a rotação. Remover e reinserir o mesmo objeto altera sua posição armazenada sem fazer uma cópia.

A sequência de edições muda a coleção de rotação‑escala para escala‑rotação, depois apenas para escala. Os índices referem‑se à coleção atual, portanto a remoção usa o novo índice da rotação após a reordenação. A enumeração final confirma qual comportamento será salvo.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var behaviors = effect.Behaviors;

IBehaviorFactory factory = new BehaviorFactory();
var scale = factory.CreateScaleEffect();
scale.To = new PointF(125, 125);
scale.Timing.Duration = 2f;

behaviors.Add(scale);

behaviors.Remove(scale);
behaviors.Insert(0, scale);
behaviors.RemoveAt(1);

foreach (var behavior in behaviors)
    Console.WriteLine(behavior.GetType().Name);

presentation.Save("collection-edited.pptx", SaveFormat.Pptx);
```

A saída é `ScaleEffect`: resta apenas a escala. A ordem da coleção, por si só, não agenda comportamentos um após o outro. Limpe a coleção somente ao substituir todas as suas operações.

## **Configure o Tempo do Comportamento**

[IBehavior.Timing](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehavior/timing/) expõe [ITiming](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/), independentemente de [IEffect.Timing](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/timing/). O tempo do efeito agenda o efeito contido; o tempo do comportamento descreve uma operação dentro dele.

### **Definir Duração, Atraso, Repetição e Aceleração**

Abra `rotation.pptx` e defina [Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/duration/) e [TriggerDelayTime](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/triggerdelaytime/) em segundos, depois configure [RepeatCount](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatcount/). [Accelerate](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/accelerate/) e [Decelerate](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/decelerate/) são frações da duração; mantenha sua soma no máximo 1.

O arquivo de entrada é o criado no exemplo de rotação, onde o primeiro comportamento é conhecido como rotação. Este exemplo altera apenas o tempo desse comportamento; seu ângulo de 90 ° permanece intacto. Manter ângulo e tempo separados facilita ajustar o ritmo sem reconstruir a animação.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var rotation = (IRotationEffect)effect.Behaviors[0];
rotation.Timing.Duration = 2f;
rotation.Timing.TriggerDelayTime = 0.5f;
rotation.Timing.RepeatCount = 3f;
rotation.Timing.Accelerate = 0.2f;
rotation.Timing.Decelerate = 0.2f;

presentation.Save("timing.pptx", SaveFormat.Pptx);
```

O comportamento usa uma duração de dois segundos, meio segundo de atraso e contagem de repetição 3. Os primeiros e últimos 20 % da sua duração são usados para aceleração e desaceleração.

Outras políticas de repetição incluem [RepeatDuration](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatduration/), [RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilendslide/) e [RepeatUntilNextClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilnextclick/); escolha uma política ao invés de habilitá‑las todas ao mesmo tempo. [AutoReverse](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/autoreverse/) reproduz a animação ao contrário após a passagem direta. Aceleração e desaceleração se aplicam a mudanças contínuas, não a atribuições discretas ou comandos.

## **Criar um Caminho de Movimento**

Use [CreateMotionEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorfactory/createmotioneffect/) para criar movimento. Seu [From](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioneffect/from/), [To](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioneffect/to/) e [By](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioneffect/by/) descrevem coordenadas ou deslocamentos baseados em percentuais. Para uma rota editável, crie um [MotionPath](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/motionpath/) e atribua‑o a [IMotionEffect.Path](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioneffect/path/). [IMotionPath](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotionpath/) armazena os comandos do caminho.

[MotionCommandPathType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/motioncommandpathtype/) seleciona a operação:

| Comando | Pontos | Significado |
| --- | --- | --- |
| MoveTo | Um | Define a posição inicial. |
| LineTo | Um | Move ao longo de um segmento reto até seu ponto final. |
| CurveTo | Três | Segue uma curva cúbica definida por dois pontos de controle e um ponto final. |
| CloseLoop | Nenhum | Retorna à posição inicial. |
| End | Nenhum | Finaliza o caminho. |

[MotionPathPointsType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/motionpathpointstype/) descreve características de edição de ponto, como ponto de canto ou suave. Não substitui o tipo de comando. Use um tipo de ponto de curva para o exemplo de curva abaixo e um tipo de ponto de canto para os segmentos retos.

As coordenadas do caminho são normalizadas às dimensões do slide: um deslocamento X de 0,25 representa um quarto da largura do slide, não 0,25 pontos. Y positivo corre para baixo. Comandos absolutos especificam posições no sistema de coordenadas do caminho; comandos relativos especificam deslocamentos a partir da posição atual. Isto é separado de [Origin](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioneffect/origin/), que seleciona o referencial do caminho, e [PathEditMode](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioneffect/patheditmode/), que controla como o caminho se move quando a forma é movida.

### **Criar um Caminho Reto**

Crie um comportamento de movimento com um ponto inicial, um segmento reto e um comando de fim. [IMotionPath.Add](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotionpath/add/) recebe o tipo de comando, seus pontos, o tipo de ponto e um sinalizador de coordenada relativa.

O comando inicial estabelece (0, 0), e a linha termina em (0,25, 0), dando à rota um deslocamento horizontal de um quarto da largura do slide. O comando final não possui pontos de coordenada. Uma vez que o caminho é atribuído, adicionar o comportamento de movimento ao efeito conecta essa rota ao retângulo.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 160, 80);

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.PathRight, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Behaviors.Clear();

IBehaviorFactory factory = new BehaviorFactory();
var motion = factory.CreateMotionEffect();
motion.Origin = MotionOriginType.Layout;
motion.Timing.Duration = 2f;

var path = new MotionPath();
path.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0, 0) }, MotionPathPointsType.Auto, false);
path.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.25f, 0) }, MotionPathPointsType.Corner, false);
path.Add(MotionCommandPathType.End, Array.Empty<PointF>(), MotionPathPointsType.None, false);

motion.Path = path;
effect.Behaviors.Add(motion);

presentation.Save("motion.pptx", SaveFormat.Pptx);
```

`motion.pptx` contém um comportamento de movimento com três comandos de caminho. Os exemplos de edição de arquivo a seguir usam esta estrutura conhecida.

### **Comparar Coordenadas Absolutas e Relativas**

Estes dois objetos de caminho descrevem a mesma rota. O comando absoluto termina em (0,3, 0,1); o comando relativo adiciona (0,1, 0,1) à posição atual, (0,2, 0).

Ambos os caminhos começam na mesma posição. Para a linha relativa, some seus deslocamentos X e Y à posição atual para obter o ponto final; para a linha absoluta, leia o ponto final diretamente. Trocar o sinalizador sem converter as coordenadas resultaria em uma rota diferente.

```csharp
using System.Drawing;
using Aspose.Slides.Animation;

var absolutePath = new MotionPath();
absolutePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
absolutePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.3f, 0.1f) }, MotionPathPointsType.Corner, false);

var relativePath = new MotionPath();
relativePath.Add(MotionCommandPathType.MoveTo, new[] { new PointF(0.2f, 0) }, MotionPathPointsType.Auto, false);
relativePath.Add(MotionCommandPathType.LineTo, new[] { new PointF(0.1f, 0.1f) }, MotionPathPointsType.Corner, true);
```

Atribua qualquer um dos caminhos a um comportamento de movimento para usá‑lo em uma apresentação. O argumento booleano final seleciona coordenadas relativas para esse comando.

### **Substituir uma Linha por uma Curva**

Abra `motion.pptx` e substitua seu comando de linha por uma curva cúbica. Forneça primeiro os dois pontos de controle, seguidos do ponto final.

A posição inicial é fornecida pelo comando precedente. Os dois primeiros pontos moldam a curva, enquanto o terceiro é seu destino; eles não são três destinos sucessivos. Atualizar simultaneamente o tipo de comando, o tipo de edição de ponto e a matriz de pontos mantém o segmento consistente com sua nova geometria.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path[1].CommandType = MotionCommandPathType.CurveTo;
path[1].PointsType = MotionPathPointsType.CurveSmooth;
path[1].Points = new[] { new PointF(0.1f, 0), new PointF(0.2f, 0.1f), new PointF(0.3f, 0.1f) };

presentation.Save("curve.pptx", SaveFormat.Pptx);
```

O caminho em `curve.pptx` ainda tem três comandos; seu comando do meio agora define uma curva.

## **Inspecionar e Editar um Caminho Salvo**

Cada [IMotionCmdPath](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioncmdpath/) expõe [Points](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioncmdpath/points/), [CommandType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioncmdpath/commandtype/), [PointsType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioncmdpath/pointstype/) e [IsRelative](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotioncmdpath/isrelative/). Os exemplos a seguir usam o caminho conhecido de três comandos em `motion.pptx`. Para entrada arbitrária, localize o efeito pretendido e verifique tipos de comando e contagem de pontos antes de editar por índice.

### **Ler Comandos e Coordenadas**

Leia o caminho sem alterá‑lo. Comandos de fim e fechamento de loop não precisam de pontos, portanto permita um array de pontos nulo.

A saída associa cada comando ao seu sinalizador de coordenada relativa antes de listar seus pontos. Isso permite distinguir um ponto final de um deslocamento antes de modificar o caminho. Uma curva listaria três pontos, enquanto a linha reta neste arquivo lista apenas um.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
foreach (var segment in path)
{
    Console.WriteLine($"{segment.CommandType}, relative: {segment.IsRelative}");
    if (segment.Points != null)
        foreach (var point in segment.Points)
            Console.WriteLine($"X={point.X}, Y={point.Y}");
}
```

A listagem contém um ponto inicial, uma linha absoluta que termina em (0,25, 0) e um comando de fim.

### **Alterar um Ponto Final**

Abra `motion.pptx` e substitua a matriz de pontos da linha para mover seu ponto final.

No arquivo de entrada, o índice 0 é o comando de início e o índice 1 é a linha. Substituir o único ponto da linha altera seu destino sem mudar seu tipo de comando, tempo ou posição na coleção. Como o comando usa coordenadas absolutas, o novo par especifica uma posição em vez de um deslocamento adicionado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

var motion = (IMotionEffect)effect.Behaviors[0];
motion.Path[1].Points = new[] { new PointF(0.4f, 0.1f) };

presentation.Save("motion-endpoint.pptx", SaveFormat.Pptx);
```

A linha em `motion-endpoint.pptx` termina em (0,4, 0,1); o arquivo original permanece inalterado.

### **Substituir um Segmento**

Use [Insert](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotionpath/insert/) e [RemoveAt](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/imotionpath/removeat/) para substituir a linha em `motion.pptx`. Inserir desloca a linha antiga para o índice 2.

Isto demonstra a substituição de um objeto de comando ao invés de editar suas coordenadas existentes. Após a inserção, a coleção contém temporariamente o comando de início, a nova linha, a linha antiga e o comando de fim. Remover o índice 2 descarta a linha antiga e deixa a nova rota no lugar.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("motion.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];
var motion = (IMotionEffect)effect.Behaviors[0];

var path = motion.Path;
path.Insert(1, MotionCommandPathType.LineTo, new[] { new PointF(0.2f, 0.1f) }, MotionPathPointsType.Corner, false);
path.RemoveAt(2);

presentation.Save("motion-edited.pptx", SaveFormat.Pptx);
```

O caminho salvo ainda tem três comandos, com a nova linha terminando em (0,2, 0,1) e o comando de fim por último.

## **Modificar e Verificar um Comportamento Existente**

Quando o índice do comportamento é desconhecido, selecione‑o por tipo. Este exemplo abre `rotation.pptx`, encontra seu [IRotationEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/irotationeffect/), altera o ângulo e verifica o valor salvo após reabrir.

A verificação de tipo permite que o loop ignore comportamentos que não são rotações. O segundo carregamento lê o arquivo salvo em um objeto de apresentação separado, de modo que a comparação verifica os dados persistidos ao invés do valor ainda mantido na memória. Este exemplo ainda assume que o efeito conhecido está primeiro na sequência principal; selecionar um comportamento por tipo não localiza o efeito correto em uma apresentação arbitrária.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation("rotation.pptx");
var effect = presentation.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in effect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        rotation.By = 180f;
}

presentation.Save("rotation-edited.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("rotation-edited.pptx");
var savedEffect = reopened.Slides[0].Timeline.MainSequence[0];

foreach (var behavior in savedEffect.Behaviors)
{
    if (behavior is IRotationEffect rotation)
        Console.WriteLine($"Rotation preserved: {Math.Abs(rotation.By - 180f) < 0.001f}");
}
```

A saída é `Rotation preserved: True`. Aplique o mesmo padrão de verificação de tipo a outros comportamentos. Para uma verificação completa de preservação, compare a forma de destino, efeito, tipos e ordem dos comportamentos, tempo e comandos do caminho. Use tolerância numérica para valores de ponto flutuante. Para uma apresentação com layout de animação desconhecido, veja [Ler Animações de Formas](/slides/pt/net/shape-animation/#read-shape-animations) para percorrer sequências principais e interativas.

## **Ordem dos Comportamentos, Predefinições e Reprodução**

A ordem em [IBehaviorCollection](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehaviorcollection/) é a ordem armazenada das operações de um efeito. Não é uma lista de reprodução na qual cada comportamento espera automaticamente o anterior. Tempo e o efeito que o contém determinam o agendamento. Os comportamentos podem sobrepor‑se, e operações na mesma propriedade podem interagir através de [Additive](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehavior/additive/) e [Accumulate](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ibehavior/accumulate/). Não use apenas a reordenação da coleção para agendar “mover, então girar”; use tempo explícito ou efeitos separados como descrito em [Animação de Formas](/slides/pt/net/shape-animation/).

O [Type](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/type/) e o [Subtype](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/subtype/) do efeito descrevem sua predefinição. Eles não são uma descrição completa de uma árvore de comportamento editada. Escolha a predefinição e o subtipo antes de personalizar comportamentos: mudar a predefinição pode reconstruir a coleção e descartar suas operações customizadas. Por exemplo, mudar um efeito Spin personalizado para Fade pode substituir seu comportamento de rotação por comportamentos de definição e filtro. Inspecione a coleção novamente após mudar uma predefinição ou subtipo. Limpar comportamentos de predefinição também pode remover operações de visibilidade ou inicialização que a predefinição requer. Os exemplos deliberadamente usam formas visíveis e substituem os comportamentos; não reconstruíram a implementação de cada predefinição.

## **Compatibilidade de Formato**

Uma árvore de comportamento preservada não garante reprodução idêntica em todo visualizador ou renderizador de exportação. Verifique os dados salvos e a saída renderizada separadamente.

| Formato ou saída | O que verificar |
| --- | --- |
| PPTX | Use como formato principal para estes exemplos. Reabra para verificar a árvore de comportamento editável e, em seguida, teste a reprodução na versão do PowerPoint pretendida. |
| PPT | A representação binária legada pode diferir do PPTX. Teste um ciclo separado de salvar‑reabrir e reprodução; não infira suporte para todas as combinações personalizadas apenas pelo sucesso do PPTX. |
| PDF, PNG, JPEG e outras imagens estáticas de slide | Contêm uma representação estática do slide, não uma linha do tempo de comportamento reproduzível nem um frame final garantido da animação. |
| [HTML5](/slides/pt/net/export-to-html5/) | Pode reproduzir animações suportadas quando a animação de forma está habilitada nas opções de exportação. Teste combinações personalizadas no navegador. |
| [Animated GIF](/slides/pt/net/convert-powerpoint-to-animated-gif/) | Armazena frames renderizados, não comportamentos editáveis ou interação por clique. Verifique o movimento realmente renderizado. |
| [Video](/slides/pt/net/convert-powerpoint-to-video/) | Renderiza frames de animação e os codifica como vídeo. O suporte é limitado às [animações e efeitos suportados](/slides/pt/net/convert-powerpoint-to-video/#supported-animations-and-effects); comandos e eventos interativos não se tornam uma linha do tempo editável. |

## **Perguntas Frequentes**

**Por que meu efeito contém comportamentos antes de eu adicionar algum?**

Criar um efeito predefinido pode gerar suas operações subjacentes. Inspecione‑as antes de decidir se estende a predefinição ou substitui seus comportamentos.

**Mover um comportamento para o início faz com que ele seja reproduzido primeiro?**

Não necessariamente. A ordem da coleção não substitui o tempo. Verifique atrasos, durações e interações entre operações na mesma propriedade.

**Por que um comando de fim não tem pontos?**

Ele marca o fim do caminho e não requer coordenadas. Verifique se há um array de pontos nulo ao inspecionar um caminho lido de um arquivo.

**Um ciclo completo bem‑sucedido é suficiente para confirmar a reprodução?**

Não. Reabrir confirma a preservação das propriedades verificadas. Teste o player de apresentação ou a exportação animada separadamente para confirmar o comportamento visual.