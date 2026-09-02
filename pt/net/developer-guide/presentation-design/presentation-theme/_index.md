---
title: Gerenciar Temas de Apresentação em .NET
linktitle: Tema de Apresentação
type: docs
weight: 10
url: /pt/net/presentation-theme/
keywords:
- Tema PowerPoint
- tema de apresentação
- tema de slide
- definir tema
- alterar tema
- gerenciar tema
- tema externo
- THMX
- cor do tema
- paleta adicional
- fonte do tema
- estilo do tema
- efeito do tema
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Temas mestre de apresentação no Aspose.Slides para .NET para criar, personalizar e converter arquivos PowerPoint com identidade visual consistente."
---
## **Introdução**

Um tema de apresentação define um conjunto coordenado de cores, fontes, estilos de plano de fundo, preenchimentos, linhas e efeitos. Objetos que respeitam o tema referem‑se a essas definições compartilhadas em vez de armazenar cada propriedade visual como um valor fixo, de modo que uma alteração de tema pode atualizar muitos objetos de uma só vez.

No Aspose.Slides, o tema no nível da apresentação está disponível através da propriedade [Presentation.MasterTheme](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/mastertheme/). Uma apresentação também pode conter substituições de tema em níveis inferiores. Um mestre pode substituir o tema da apresentação através de [MasterThemeManager.OverrideTheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/masterthememanager/overridetheme/), um layout pode substituir seu tema herdado através de [BaseOverrideThemeManager.OverrideTheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/baseoverridethememanager/overridetheme/), e um slide individual pode fazer o mesmo. Na prática, o tema efetivo de um slide é resolvido por esta cadeia de herança: tema da apresentação, substituição do mestre, substituição do layout e substituição do slide.

![Componentes do tema: cores, fontes, estilos de plano de fundo e efeitos](theme-constituents.png)

As seções abaixo mostram os fluxos de trabalho mais comuns relacionados a temas: inspecionar um tema, alterar cores e fontes, copiar ou aplicar um tema, atualizar estilos de plano de fundo e efeito, e ler valores efetivos após a herança e as substituições serem resolvidas.

## **Inspecionar um Tema**

O objeto [MasterTheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/mastertheme/) expõe o [ColorScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/mastertheme/colorscheme/), [FontScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/mastertheme/fontscheme/) e [FormatScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/mastertheme/formatscheme/) do tema. Inspecionar essas coleções antes de alterá‑las é especialmente útil quando uma apresentação provém de uma fonte externa, pois o número e o conteúdo das entradas de estilo podem variar.

O exemplo a seguir lê as propriedades principais do tema e relata quantos estilos de plano de fundo, preenchimento, linha e efeito estão armazenados no tema:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var theme = presentation.MasterTheme;

Console.WriteLine($"Theme name: {theme.Name}");
Console.WriteLine($"Accent 1: {theme.ColorScheme.Accent1.Color}");
Console.WriteLine($"Major Latin font: {theme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Minor Latin font: {theme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Background fill styles: {theme.FormatScheme.BackgroundFillStyles.Count}");
Console.WriteLine($"Fill styles: {theme.FormatScheme.FillStyles.Count}");
Console.WriteLine($"Line styles: {theme.FormatScheme.LineStyles.Count}");
Console.WriteLine($"Effect styles: {theme.FormatScheme.EffectStyles.Count}");
```

Se um arquivo usa múltiplos mestres, não presuma que cada slide tem o mesmo tema efetivo. Inspecione o mestre associado ao slide e use o fluxo de trabalho de tema efetivo mostrado mais adiante neste artigo quando substituições de layout ou slide possam estar presentes.

## **Alterar Cores do Tema**

Preenchimentos, linhas e textos que respeitam o tema podem referir‑se a uma cor lógica da enumeração [SchemeColor](https://reference.aspose.com/slides/pt/net/aspose.slides/schemecolor/). Quando você altera a entrada correspondente no [IColorScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/icolorscheme/) do tema, todos os objetos que ainda referenciam aquela cor de tema são resolvidos contra o novo valor. Objetos que utilizam uma cor RGB direta não são alterados por uma atualização de cor de tema.

O exemplo completo a seguir cria uma forma que usa `Accent4`, altera a cor `Accent4` do tema para vermelho, salva a apresentação, reabre‑a e imprime a cor de preenchimento efetiva:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
presentation.MasterTheme.ColorScheme.Accent4.Color = Color.Red;
presentation.Save("theme-color.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("theme-color.pptx");
var savedSlide = savedPresentation.Slides[0];
var savedShape = savedSlide.Shapes[0];
var effectiveFill = savedShape.FillFormat.GetEffective();
Console.WriteLine($"Effective fill color: {effectiveFill.SolidFillColor}");
```

Como o retângulo continua vinculado ao `Accent4`, sua cor visível torna‑se vermelha após a alteração do tema. Se você substituir a cor do esquema por uma cor direta na forma, alterações posteriores ao `Accent4` não afetarão mais esse preenchimento.

### **Usar Cores da Paleta Adicional**

O PowerPoint gera variantes mais claras e mais escuras a partir de uma cor de tema aplicando transformações de cor. O Aspose.Slides expõe essas transformações através de [ColorTransformOperation](https://reference.aspose.com/slides/pt/net/aspose.slides/colortransformoperation/).

![Cores principais do tema e cores mais claras e mais escuras geradas a partir da paleta adicional](additional-palette-colors.png)

**1** – Cores principais do tema.

**2** – Variantes mais claras e mais escuras produzidas a partir das cores principais do tema.

O exemplo a seguir cria seis retângulos baseados em `Accent4`, aplica transformações de luminância a cinco deles e salva o resultado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
shape1.FillFormat.FillType = FillType.Solid;
shape1.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
shape2.FillFormat.FillType = FillType.Solid;
shape2.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.2f);
shape2.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.8f);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
shape3.FillFormat.FillType = FillType.Solid;
shape3.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.4f);
shape3.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.6f);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
shape4.FillFormat.FillType = FillType.Solid;
shape4.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.6f);
shape4.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.AddLuminance, 0.4f);

var shape5 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
shape5.FillFormat.FillType = FillType.Solid;
shape5.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape5.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.75f);

var shape6 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
shape6.FillFormat.FillType = FillType.Solid;
shape6.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent4;
shape6.FillFormat.SolidFillColor.ColorTransform.Add(ColorTransformOperation.MultiplyLuminance, 0.5f);

presentation.Save("theme-color-palette.pptx", SaveFormat.Pptx);
```

Essas variantes permanecem baseadas na cor do tema. Se `Accent4` mudar mais tarde, as cores transformadas são recalculadas a partir do novo valor de `Accent4`.

### **Mapear Valores de `SchemeColor` para Slots de `IColorScheme`**

A enumeração [SchemeColor](https://reference.aspose.com/slides/pt/net/aspose.slides/schemecolor/) usa `Text1`, `Background1`, `Text2` e `Background2`, enquanto [IColorScheme](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/icolorscheme/) expõe os mesmos slots do tema como `Dark1`, `Light1`, `Dark2` e `Light2`. O mapeamento é fixo:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

São nomes alternativos para os mesmos slots de tema; não são valores convertidos dinamicamente de uma forma para outra.

## **Alterar Fontes do Tema**

Um esquema de fontes de tema contém um conjunto de fontes principal para títulos e um conjunto de fontes secundário para o corpo do texto. As propriedades [FontScheme.Major](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/fontscheme/major/) e [FontScheme.Minor](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/fontscheme/minor/) expõem esses conjuntos.

Identificadores de fontes de tema compatíveis com PowerPoint podem ser usados na formatação de texto:

* `+mn‑lt` – Fonte do corpo Latin (Minor Latin Font)
* `+mj‑lt` – Fonte do título Latin (Major Latin Font)
* `+mn‑ea` – Fonte do corpo East Asian (Minor East Asian Font)
* `+mj‑ea` – Fonte do título East Asian (Major East Asian Font)

O exemplo a seguir cria um título que usa a fonte Latin principal do tema e uma linha de corpo que usa a fonte Latin secundária. Em seguida altera as fontes do tema e salva o resultado:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var heading = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
heading.TextFrame.Text = "Theme heading";
heading.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mj-lt");

var body = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
body.TextFrame.Text = "Theme body text";
body.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LatinFont = new FontData("+mn-lt");

presentation.MasterTheme.FontScheme.Major.LatinFont = new FontData("Aptos Display");
presentation.MasterTheme.FontScheme.Minor.LatinFont = new FontData("Arial");

presentation.Save("theme-fonts.pptx", SaveFormat.Pptx);
```

O título segue a fonte principal e o texto do corpo segue a fonte secundária. Texto que possui um nome de fonte explícito em vez de um identificador de tema não mudará automaticamente quando o esquema de fontes do tema for alterado.

As coleções de fontes principal e secundária também podem conter mapeamentos de fontes para sistemas de escrita individuais, como Cirílico, Árabe, Japonês, Georgiano e Thaana. Para inspecionar, adicionar, substituir ou remover esses mapeamentos, veja [Script-Specific Theme Fonts](/slides/pt/net/script-specific-font-mappings/).

{{% alert color="info" title="Dica" %}}
Para mais informações sobre fontes em apresentações, veja [PowerPoint Fonts](/slides/pt/net/powerpoint-fonts/).
{{% /alert %}}

## **Copiar ou Aplicar um Tema**

Os fluxos de trabalho abaixo resolvem diferentes problemas relacionados a temas.

### **Aplicar um Tema Externo a Slides Dependentes de um Mestre**

Use [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) quando você tem um arquivo de tema do PowerPoint (`.thmx`) e deseja restilizar todos os slides que dependem de um mestre específico. Selecione o mestre da coleção [Presentation.Masters](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/masters/), que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection/), e passe o caminho do arquivo de tema ao método.

O método executa as seguintes operações:

1. Cria um novo slide mestre baseado no mestre selecionado.  
2. Aplica o tema externo ao novo mestre.  
3. Atribui o novo mestre a todos os slides que anteriormente dependiam do mestre selecionado.  
4. Retorna o [IMasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/) recém‑criado.

O exemplo a seguir aplica um tema externo aos slides que dependem do primeiro mestre, salva a apresentação e reabre o resultado:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var selectedMaster = presentation.Masters[0];
var themedMaster = selectedMaster.ApplyExternalThemeToDependingSlides("corporate-theme.thmx");

Console.WriteLine($"Created master: {themedMaster.Name}");
presentation.Save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
```

Um tema inválido, corrompido ou não suportado pode gerar [PptxException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxexception/) ou uma de suas subclasses relacionadas ao formato. Valide caminhos fornecidos por usuários, trate falhas de acesso ao sistema de arquivos e salve a apresentação somente depois que o tema for aplicado com sucesso.

Apenas os slides que dependiam do mestre selecionado são reatribuídos. Slides associados a outros mestres mantêm seus mestres e temas existentes. Cores, fontes, preenchimentos, linhas, planos de fundo e efeitos que respeitam o tema são resolvidos contra o tema externo. Cores, fontes, preenchimentos e outras formatações atribuídas diretamente podem permanecer inalterados. Substituições em nível de layout e de slide também podem ter precedência sobre valores herdados do novo mestre.

O tema pode referir‑se a fontes que não estão disponíveis no ambiente de tempo de execução. Para garantir renderização e exportação consistentes, instale as fontes necessárias, disponibilize‑as através de [fontes personalizadas](/slides/pt/net/custom-font/), ou configure [substituição de fontes](/slides/pt/net/font-substitution/).

Este é um fluxo de trabalho direto ao nível do mestre: o método aceita um caminho de arquivo `.thmx` e não requer a criação manual de substituições de tema em nível de slide ou layout.

### **Aplicar Temas Externos Diferentes em uma Apresentação com Múltiplos Mestres**

Quando o mestre relevante não é conhecido antecipadamente, obtenha‑o a partir de um slide representativo através de [ISlide.LayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/layoutslide/) e [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/masterslide/). Armazene as referências originais dos mestres antes de aplicar quaisquer temas, pois cada chamada cria outro mestre na apresentação.

O exemplo a seguir usa slides de duas seções para localizar seus mestres e aplica um tema externo diferente a cada grupo:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("multi-master-presentation.pptx");

if (presentation.Slides.Count < 5)
{
    Console.WriteLine("The presentation does not contain the expected representative slides.");
}
else
{
    var firstGroupMaster = presentation.Slides[0].LayoutSlide.MasterSlide;
    var secondGroupMaster = presentation.Slides[4].LayoutSlide.MasterSlide;

    if (ReferenceEquals(firstGroupMaster, secondGroupMaster))
    {
        Console.WriteLine("The representative slides use the same master.");
    }
    else
    {
        var firstThemedMaster = firstGroupMaster.ApplyExternalThemeToDependingSlides("blue-theme.thmx");
        var secondThemedMaster = secondGroupMaster.ApplyExternalThemeToDependingSlides("green-theme.thmx");

        Console.WriteLine($"First themed master: {firstThemedMaster.Name}");
        Console.WriteLine($"Second themed master: {secondThemedMaster.Name}");
        presentation.Save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
    }
}
```

A primeira chamada afeta apenas os slides que dependiam de `firstGroupMaster`, e a segunda chamada afeta apenas os slides que dependiam de `secondGroupMaster`. Slides pertencentes a qualquer outro mestre não são restilizados.

### **Preservar o Tema de Origem ao Mover Slides**

Se você deseja mover um slide para outra apresentação e preservar seu design original, clone o mestre de origem na apresentação de destino com [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection/addclone/), depois clone o slide com [ISlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/) e o mestre clonado. Isso transporta o mestre, seus layouts e o tema associado juntos.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var sourceSlide = source.Slides[0];
var sourceMaster = sourceSlide.LayoutSlide.MasterSlide;
var clonedMaster = target.Masters.AddClone(sourceMaster);
target.Slides.AddClone(sourceSlide, clonedMaster, true);

target.Save("theme-preserved.pptx", SaveFormat.Pptx);
```

Este é o fluxo de trabalho recomendado quando o slide de origem deve ter a mesma aparência no destino. Simplesmente clonar o conteúdo sobre um mestre de destino não relacionado pode alterar cores, fontes, planos de fundo e efeitos controlados pelo tema.

### **Aplicar Valores de Tema a um Slide Existente**

Se o slide de destino deve permanecer no mestre e layout atuais, inicialize uma substituição em nível de slide a partir do tema de origem. Os métodos [OverrideTheme.InitColorSchemeFrom](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme.InitFontSchemeFrom](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/overridetheme/initfontschemefrom/) e [OverrideTheme.InitFormatSchemeFrom](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/overridetheme/initformatschemefrom/) copiam os três componentes principais do tema para a substituição.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetSlide = target.Slides[0];
var overrideTheme = targetSlide.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
```

Isso altera o tema usado por esse slide sem mudar o tema herdado por outros slides. Para remover a substituição local e voltar aos valores herdados, chame [OverrideTheme.Clear](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/overridetheme/clear/).

### **Aplicar uma Substituição de Tema a um Layout**

Uma substituição em nível de layout aplica‑se aos slides que usam esse layout, a menos que um slide específico tenha sua própria substituição. Os mesmos métodos de inicialização podem ser usados através do [LayoutSlideThemeManager](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/layoutslidethememanager/) do layout:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var source = new Presentation("source-theme.pptx");
using var target = new Presentation("target.pptx");

var targetLayout = target.Slides[0].LayoutSlide;
var overrideTheme = targetLayout.ThemeManager.OverrideTheme;
overrideTheme.InitColorSchemeFrom(source.MasterTheme.ColorScheme);
overrideTheme.InitFontSchemeFrom(source.MasterTheme.FontScheme);
overrideTheme.InitFormatSchemeFrom(source.MasterTheme.FormatScheme);

target.Save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
```

Use um tema ao nível de mestre ou apresentação quando muitos layouts e slides devem compartilhar o mesmo design base, uma substituição de layout quando uma família de layouts precisa de estilização diferente, e uma substituição de slide apenas para exceções reais. Substituições excessivas em nível de slide tornam alterações globais de tema posteriores mais difíceis de prever.

## **Atualizar Estilos de Plano de Fundo do Tema**

Os preenchimentos de plano de fundo do tema são armazenados em [FormatScheme.BackgroundFillStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/backgroundfillstyles/). O PowerPoint pode apresentar mais opções de plano de fundo em sua interface do que o número de definições de preenchimento realmente armazenadas nessa coleção, pois a UI pode combinar preenchimentos de tema com cores de tema e outras referências de estilo.

![Galeria de estilos de plano de fundo do PowerPoint para um tema de apresentação](presentation-design_8.png)

Antes de usar um estilo de plano de fundo, inspecione a coleção armazenada e o atual [Background.StyleIndex](https://reference.aspose.com/slides/pt/net/aspose.slides/background/styleindex/). `StyleIndex` usa `0` para nenhum preenchimento temático; valores positivos são referências a estilos de plano de fundo do tema. Isso difere da indexação direta da coleção .NET, onde `[0]` significa o primeiro item armazenado. Não presuma que toda apresentação contenha o mesmo número de estilos de preenchimento de plano de fundo.

O exemplo a seguir relata a contagem de preenchimentos de fundo disponíveis, atribui uma referência de plano de fundo temático ao primeiro mestre e salva a apresentação:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var backgroundStyles = presentation.MasterTheme.FormatScheme.BackgroundFillStyles;
Console.WriteLine($"Background fill styles: {backgroundStyles.Count}");

if (backgroundStyles.Count == 0)
{
    throw new InvalidOperationException("The presentation theme does not contain background fill styles.");
}

presentation.Masters[0].Background.Type = BackgroundType.Themed;
presentation.Masters[0].Background.StyleIndex = 1;

presentation.Save("theme-background.pptx", SaveFormat.Pptx);
```

O resultado visível depende da entrada do tema referenciada pelo mestre e de quaisquer substituições de plano de fundo no nível de layout ou slide. Se um slide usar seu próprio plano de fundo, alterar apenas o plano de fundo do mestre pode não alterar esse slide. Use [Background.GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/background/geteffective/) quando precisar saber o plano de fundo final após a aplicação da herança.

{{% alert color="warning" title="Aviso" %}}
Não trate `StyleIndex` como um índice de coleção zero‑based. Também evite codificar um número de estilo de um arquivo e presumir que ele terá a mesma aparência em outro arquivo; as definições de estilo de tema são específicas da apresentação.
{{% /alert %}}

{{% alert color="info" title="Dica" %}}
Para formatação direta de plano de fundo e herança de plano de fundo, veja [Presentation Background](/slides/pt/net/presentation-background/).
{{% /alert %}}

## **Atualizar Efeitos do Tema**

Um esquema de formato de tema contém coleções separadas de [FillStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/fillstyles/), [LineStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/linestyles/) e [EffectStyles](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/formatscheme/effectstyles/). Temas típicos do Office costumam conter três entradas principais de estilo que correspondem visualmente a formatações sutil, moderada e intensa, mas o código deve inspecionar cada coleção em vez de presumir uma contagem fixa.

![Efeitos de tema sutis, moderados e intensos aplicados à mesma forma](presentation-design_10.png)

Ao acessar essas coleções em C#, o índice da coleção é zero‑based: `[0]` é o primeiro estilo armazenado e `[2]` é o terceiro. Os índices de referência de estilo de uma forma são um conceito separado, exposto através de [IShapeStyle](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapestyle/). Modificar um estilo de tema afeta formas que referenciam esse estilo; formas com formatação direta podem permanecer inalteradas.

O exemplo a seguir verifica se as entradas de estilo necessárias existem, altera o primeiro estilo de linha, altera o terceiro estilo de preenchimento, habilita uma sombra externa no terceiro estilo de efeito e salva o resultado:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Subtle_Moderate_Intense.pptx");
var formatScheme = presentation.MasterTheme.FormatScheme;

if (formatScheme.LineStyles.Count < 1 || formatScheme.FillStyles.Count < 3 || formatScheme.EffectStyles.Count < 3)
{
    throw new InvalidOperationException("The theme does not contain the style entries required by this example.");
}

formatScheme.LineStyles[0].FillFormat.FillType = FillType.Solid;
formatScheme.LineStyles[0].FillFormat.SolidFillColor.Color = Color.Red;
formatScheme.FillStyles[2].FillType = FillType.Solid;
formatScheme.FillStyles[2].SolidFillColor.Color = Color.ForestGreen;
formatScheme.EffectStyles[2].EffectFormat.EnableOuterShadowEffect();
formatScheme.EffectStyles[2].EffectFormat.OuterShadowEffect.Distance = 10f;

presentation.Save("theme-effects.pptx", SaveFormat.Pptx);
```

Para formas que referenciam esses slots, o primeiro estilo de linha do tema torna‑se vermelho, o terceiro estilo de preenchimento do tema torna‑se verde floresta sólido, e o terceiro estilo de efeito ganha uma sombra externa com distância de 10 pontos. O resultado visual exato ainda depende de quais slots de estilo cada forma referencia e se a formatação direta sobrescreve o tema.

![Estilos de efeito de tema após alterar linha, preenchimento e configurações de sombra](presentation-design_11.png)

## **Ler Valores Efetivos do Tema**

Objetos de tema bruto mostram o que está definido em um nível específico. Valores efetivos mostram o que um slide ou forma realmente usa após a herança e substituições locais serem resolvidas. Para um slide, chame [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/). Para um plano de fundo, use [Background.GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/background/geteffective/), e para um preenchimento, use [FillFormat.GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/geteffective/).

O exemplo a seguir lê o tema efetivo, o plano de fundo e o primeiro preenchimento de forma de um slide:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];
var effectiveTheme = slide.ThemeManager.CreateThemeEffective();
var effectiveBackground = slide.Background.GetEffective();

Console.WriteLine($"Effective major Latin font: {effectiveTheme.FontScheme.Major.LatinFont.FontName}");
Console.WriteLine($"Effective minor Latin font: {effectiveTheme.FontScheme.Minor.LatinFont.FontName}");
Console.WriteLine($"Effective background fill type: {effectiveBackground.FillFormat.FillType}");

if (slide.Shapes.Count > 0)
{
    var effectiveFill = slide.Shapes[0].FillFormat.GetEffective();
    Console.WriteLine($"First shape effective fill type: {effectiveFill.FillType}");
    if (effectiveFill.FillType == FillType.Solid)
    {
        Console.WriteLine($"First shape effective fill color: {effectiveFill.SolidFillColor}");
    }
}
```

Use dados efetivos para diagnósticos de renderização, validação e comparações. Se você inspecionar apenas [Presentation.MasterTheme](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/mastertheme/), pode perder uma substituição de mestre, layout, slide ou forma que altere a aparência final.

## **FAQ**

**Aplicar um tema externo afeta todos os slides da apresentação?**

Não. [IMasterSlide.ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/applyexternalthemetodependingslides/) reatribui apenas os slides que dependem do mestre selecionado. Slides que usam outros mestres mantêm seus temas existentes.

**Posso aplicar um tema a um único slide sem alterar o mestre?**

Sim. Use o [SlideThemeManager](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/slidethememanager/) do slide e inicialize sua substituição de tema. A alteração permanece local a esse slide; os demais slides continuam herdando seus temas atuais.

**Qual é a maneira mais segura de transferir um tema de uma apresentação para outra?**

Ao mover um slide e preservar sua aparência original, clone o mestre de origem no destino e clone o slide com esse mestre usando [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection/addclone/) e [ISlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/islidecollection/addclone/). Isso mantém o mestre, os layouts e o tema juntos.

**Como posso ver os valores efetivos após herança e substituições?**

Use [BaseOverrideThemeManager.CreateThemeEffective](https://reference.aspose.com/slides/pt/net/aspose.slides.theme/baseoverridethememanager/createthemeeffective/) para um slide ou tema de layout e os métodos de dados efetivos correspondentes para objetos de formato, como [Background.GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/background/geteffective/) e [FillFormat.GetEffective](https://reference.aspose.com/slides/pt/net/aspose.slides/fillformat/geteffective/). Essas APIs retornam os valores resolvidos após a aplicação de herança e substituições.