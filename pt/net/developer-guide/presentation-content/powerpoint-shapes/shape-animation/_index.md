---
title: Aplicar Animações de Forma em Apresentações em .NET
linktitle: Animação de Forma
type: docs
weight: 60
url: /pt/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Aprenda a adicionar, inspecionar e personalizar animações de forma, temporização, sons, comportamento pós-animação e texto animado com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides for .NET representa animações de slide como efeitos em uma linha de tempo do slide. Um efeito tem uma forma de destino, um tipo e subtipo de animação, um gatilho, configurações de temporização e propriedades opcionais, como som ou comportamento pós-animação.

A linha de tempo contém dois tipos de sequências:

- A **sequência principal** é reproduzida à medida que o slide avança.  
- Uma **sequência interativa** inicia quando sua forma de gatilho é clicada.

Como caixas de texto, imagens, gráficos, tabelas e outros objetos de slide implementam [IShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/), você usa o mesmo método [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/addeffect/) para a maioria do conteúdo do slide. Os efeitos disponíveis estão listados na enumeração [EffectType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effecttype/).

## **Adicionar animações de forma**

Para adicionar uma animação, obtenha a sequência principal do slide e chame [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/addeffect/) com a forma de destino, tipo de efeito, subtipo e gatilho. Para um efeito que inicia quando outra forma é clicada, crie uma sequência interativa cujo gatilho seja essa outra forma.

O exemplo a seguir cria os dois tipos de animação e salva o resultado em `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

O gatilho controla quando um efeito inicia:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effecttriggertype/) aguarda um clique na sequência principal ou um clique na forma de gatilho em uma sequência interativa.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effecttriggertype/) inicia juntamente com o efeito anterior.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/effecttriggertype/) inicia quando o efeito anterior termina.

Para animar uma imagem, gráfico ou outro tipo de forma, passe esse objeto para [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/addeffect/) em vez de `targetShape`. Para opções de agrupamento específicas de gráficos, veja [Animated Charts](/slides/pt/net/animated-charts/).

## **Ler animações de forma**

Use [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/geteffectsbyshape/) quando souber a forma de destino. Para inspecionar cada efeito, enumere a sequência principal e todas as sequências interativas. A enumeração evita assumir que uma sequência contém um efeito no índice `0`.

O exemplo a seguir cria uma forma com efeitos de sequência principal e interativa, obtém os efeitos que têm a forma como alvo e, em seguida, enumera todas as sequências no slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Se precisar apenas dos efeitos para uma única forma, primeiro identifique a forma por nome, tipo de placeholder ou outra propriedade estável; então chame [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/geteffectsbyshape/). Não presuma que [IShapeCollection.Item](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/item/) no índice `0` seja sempre o objeto desejado.

## **Trabalhar com efeitos de placeholder herdados**

Um placeholder em um slide normal pode herdar comportamento de animação do placeholder correspondente no slide de layout e no slide mestre. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/getbaseplaceholder/) devolve esse placeholder pai, ou `null` quando não há pai.

Na apresentação de exemplo a seguir, o rodapé tem **Random Bars** no slide normal, **Split** no slide de layout e **Fly In** no slide mestre.

![Efeito de animação do rodapé no slide normal](slide-shape-animation.png)

![Efeito de animação do placeholder de rodapé no slide de layout](layout-shape-animation.png)

![Efeito de animação do placeholder de rodapé no slide mestre](master-shape-animation.png)

O próximo exemplo constrói a hierarquia de placeholders. Ele adiciona efeitos a um placeholder mestre, a um placeholder de layout e ao placeholder correspondente em um slide normal. Cada chamada a [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pt/net/aspose.slides/ishape/getbaseplaceholder/) é verificada antes de usar a forma retornada.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Alterar temporização da animação**

A caixa de diálogo **Timing** do PowerPoint corresponde às propriedades de [ITiming](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/).

![Caixa de diálogo de Temporização do PowerPoint para um efeito de animação](shape-animation.png)

- **Início** corresponde a [ITiming.TriggerType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/triggertype/).  
- **Duração** corresponde a [ITiming.Duration](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/duration/), em segundos.  
- **Atraso** corresponde a [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/triggerdelaytime/), em segundos.  
- **Repetir** corresponde a [ITiming.RepeatCount](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilnextclick/) ou [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilendslide/).  
- **Retroceder ao terminar a reprodução** corresponde a [ITiming.Rewind](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/rewind/).

Este exemplo independente adiciona um efeito, altera sua temporização por meio do objeto retornado por [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/addeffect/) e salva o resultado. Manter a referência ao [IEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/) devolvido evita um índice de coleção desnecessário.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Use apenas um modo de repetição intencionalmente. Combinar um contador de repetições com uma flag “até” pode produzir resultados confusos em diferentes visualizadores. Ao mudar os modos de repetição, defina [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilnextclick/) e [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatuntilendslide/) antes de [ITiming.RepeatCount](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itiming/repeatcount/), pois definir qualquer uma das flags também altera o modo de repetição ativo.

## **Adicionar e extrair sons de animação**

Um efeito de animação pode referenciar áudio incorporado por meio de [IEffect.Sound](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/stopprevioussound/) indica que um efeito deve parar o áudio iniciado por um efeito anterior.

### **Adicionar um som a um efeito**

O exemplo a seguir presume um arquivo de áudio local chamado `animation-sound.wav`. Ele cria dois efeitos, incorpora esse arquivo como som do primeiro efeito e configura o segundo efeito para parar o som. Usa os objetos devolvidos por [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/addeffect/), portanto nenhum índice de sequência é necessário.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Extrair sons de efeito incorporados**

O exemplo a seguir presume uma apresentação local chamada `presentation-with-animation-sounds.pptx`. Ele varre as sequências principal e interativa e grava cada som de efeito incorporado no diretório `extracted-animation-sounds`. A extensão é selecionada a partir do tipo MIME de áudio exposto por [IAudio.ContentType](https://reference.aspose.com/slides/pt/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Para objetos de áudio grandes, use [IAudio.GetStream](https://reference.aspose.com/slides/pt/net/aspose.slides/iaudio/getstream/) e copie o fluxo para um arquivo em vez de carregar todo o objeto em um array de bytes.

## **Definir comportamento pós-animação**

A opção **After animation** controla o que acontece com uma forma depois que seu efeito termina.

![Caixa de diálogo de Opções de Efeito do PowerPoint mostrando configurações de Pós-animação](shape-after-animation.png)

A enumeração [AfterAnimationType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) oferece deixar a forma inalterada, mudar sua cor, ocultá‑la após a animação ou ocultá‑la no próximo clique. Quando o tipo é [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/), defina também [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Este exemplo independente cria um efeito, define seu comportamento pós-animação por meio do objeto de efeito devolvido e salva o resultado.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Alterar o tipo para algo diferente de [AfterAnimationType.Color](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/afteranimationtype/) limpa a configuração de cor pós‑animação.

## **Animar texto**

A animação de texto possui dois controles relacionados:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/itextanimation/buildtype/) controla se os parágrafos aparecem juntos ou por nível de parágrafo.  
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/animatetexttype/) controla se o texto aparece tudo de uma vez, por palavra ou por letra. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/ieffect/delaybetweentextparts/) define o atraso entre palavras ou letras. Um valor positivo é uma porcentagem da duração do efeito; um valor negativo é um atraso em segundos.

O exemplo independente a seguir anima as palavras em uma caixa de texto. [BuildType.AsOneObject](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/buildtype/) desativa a construção parágrafo a parágrafo, de modo que a configuração de palavra se aplica a todo o quadro de texto.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Para construir uma caixa de texto por parágrafo, defina [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/buildtype/) (ou outro nível de parágrafo). Para direcionar um único parágrafo com seu próprio efeito, use a sobrecarga de [ISequence.AddEffect](https://reference.aspose.com/slides/pt/net/aspose.slides.animation/isequence/addeffect/) que aceita um [IParagraph](https://reference.aspose.com/slides/pt/net/aspose.slides/iparagraph/). Veja [Animated Text](/slides/pt/net/animated-text/) para exemplos ao nível de parágrafo.

## **Notas de exportação e compatibilidade**

- Salvar em PPT ou PPTX preserva o modelo de animação, mas a reprodução final é controlada pelo visualizador da apresentação.  
- PDF e imagens estáticas não reproduzem animações. Use [HTML5 export](/slides/pt/net/export-to-html5/), GIF animado ou [conversão para vídeo](/slides/pt/net/convert-powerpoint-to-video/) quando a saída precisar mostrar movimento.  
- Para HTML5, habilite [Html5Options.AnimateShapes](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animateshapes/) e, quando necessário, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/pt/net/aspose.slides.export/html5options/animatetransitions/).  
- A renderização de vídeo suporta muitos efeitos comuns de entrada, ênfase, saída e caminho de movimento, mas nem todo efeito do PowerPoint é suportado. Verifique a lista atual de [animações e efeitos suportados](/slides/pt/net/convert-powerpoint-to-video/#supported-animations-and-effects) e teste apresentações críticas com a versão do Aspose.Slides que você usa.  
- Efeitos customizados avançados e efeitos importados de outros formatos de apresentação podem ser preservados no arquivo, porém renderizados de forma diferente no PowerPoint, HTML5 ou vídeo. Valide o resultado exportado em vez de confiar apenas no nome do efeito.

## **Perguntas frequentes**

**Por que uma animação aparece no PowerPoint mas não em um PDF?**

PDF é um formato estático, portanto animações e transições de slide não são reproduzidas. Exporte para HTML5, GIF animado ou vídeo quando o movimento precisar ser mantido.

**Por que um efeito é reproduzido de forma diferente em um vídeo?**

A exportação para vídeo renderiza animações em vez de armazenar o comportamento original do PowerPoint. Alguns efeitos avançados não são suportados ou são aproximados. Consulte a tabela de efeitos suportados e teste a apresentação real antes do uso em produção.

**Mover uma forma para frente ou para trás altera a ordem da animação?**

Não. A ordem Z da forma controla a sobreposição, enquanto a ordem da sequência e os gatilhos controlam a reprodução da animação. Altere a linha de tempo se precisar de uma ordem de reprodução diferente.