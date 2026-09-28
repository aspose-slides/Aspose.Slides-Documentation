---
title: Gerenciar Mestres de Slides de Apresentação no .NET
linktitle: Mestre de Slide
type: docs
weight: 80
url: /pt/net/slide-master/
keywords:
- mestre de slide
- slide mestre
- slide mestre PPT
- vários slides mestres
- comparar slides mestres
- fundo
- placeholder
- clonar slide mestre
- copiar slide mestre
- duplicar slide mestre
- slide mestre não usado
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Gerencie mestres de slides no Aspose.Slides para .NET: acesse, edite, clone, compare e remova slides mestres em apresentações PowerPoint e OpenDocument."
---
## **Visão geral**

Um **slide master** define configurações de design compartilhadas para um grupo de slides. Ele pode conter formas comuns, logotipos, fundos, estilos de texto, configurações de tema e configurações de rodapé. No PowerPoint, editar um slide master é a forma usual de manter uma apresentação consistente sem repetir a mesma formatação em cada slide.

Aspose.Slides for .NET suporta o mesmo modelo. Uma apresentação pode conter um ou mais slide masters, e cada slide master pode conter vários layout slides. Slides normais geralmente não referenciam um slide master diretamente. Em vez disso, um slide normal usa um layout slide, e esse layout slide pertence a um slide master.

A hierarquia é:

1. **Slide master** – define o design e o tema compartilhados.  
1. **Layout slide** – define um arranjo específico de placeholders e formatação de nível de layout.  
1. **Normal slide** – contém o conteúdo real da apresentação e usa um layout slide.

![A hierarquia de slide masters, layout slides e slides normais](slide-master_2.jpg)

No Aspose.Slides, um slide master é representado pela interface [IMasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/) . Todos os slide masters em uma apresentação estão disponíveis através da coleção [Presentation.Masters](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/masters/) , que implementa [IMasterSlideCollection](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection/).

{{% alert color="info" title="Inheritance" %}}
Quando a mesma propriedade é definida em mais de um nível, o nível mais específico prevalece. Por exemplo, se um slide master e um layout slide ambos definirem um fundo, os slides baseados nesse layout usarão o fundo do layout. Para mais informações sobre layout slides, veja [Aplicar ou Alterar Layouts de Slides](/slides/pt/net/slide-layout/).
{{% /alert %}}

## **Acessar Slide Masters**

No PowerPoint, você pode abrir a visualização Slide Master em **Exibir** > **Slide Master**.

![O comando Slide Master na aba Exibir do PowerPoint](slide-master_3.jpg)

No Aspose.Slides, use a coleção `Masters` para acessar slide masters:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

Você também pode obter o slide master usado por um slide normal por meio de seu layout:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **O que um Slide Master contém**

Um slide master é um objeto semelhante a um slide. Ele implementa [IBaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/), portanto expõe muitas das mesmas propriedades de slide usadas por slides normais e de layout. Membros específicos do master estão listados na página da API [IMasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/).

Membros de slide master frequentemente usados incluem:

| Membro | Finalidade |
| --- | --- |
| `Background` | Define o fundo do slide no nível do master. |
| `Shapes` | Armazena as formas colocadas no master, como logotipos, molduras de imagem e texto compartilhado. |
| `LayoutSlides` | Armazena os layout slides que pertencem ao master. |
| `ThemeManager` | Fornece acesso às APIs de tema do master. |
| `HeaderFooterManager` | Controla cabeçalhos, rodapés, datas e números de slide para o master e seus layouts filhos. |
| `GetDependingSlides` | Retorna slides normais que dependem do master por meio de seus layouts. |

## **Adicionar uma imagem a um Slide Master**

Quando você adiciona uma imagem a um slide master, ela aparece nos slides que utilizam layouts desse master. Isso é útil para logotipos, marcas d’água, faixas decorativas e outros elementos visuais repetidos.

O exemplo a seguir adiciona um logotipo ao primeiro slide master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

Para mais informações sobre quadros de imagem, veja [Quadro de Imagem](/slides/pt/net/picture-frame/).

## **Controlar a visibilidade de gráficos do Master**

Use [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/showmastershapes/) para ocultar gráficos herdados do master, como logotipos ou formas decorativas, sem excluí‑los do master. Defina [Slide.ShowMasterShapes](https://reference.aspose.com/slides/pt/net/aspose.slides/slide/showmastershapes/) como `false` no slide que deve omitir esses gráficos e mantenha `true` nos slides que devem exibí‑los.

O exemplo a seguir cria uma faixa decorativa azul em um master e dois slides que utilizam o mesmo layout em branco. A faixa fica visível no primeiro slide e oculta no segundo. Nenhuma apresentação ou imagem de entrada é necessária.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

O exemplo usa o layout **Blank** fornecido com uma nova apresentação e remove os placeholders próprios do slide inicial.

### **Escolher o escopo da configuração**

Um slide normal usa seu master por meio de [ISlide.LayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/layoutslide/) e [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/masterslide/). Definir a propriedade em um slide individual afeta apenas esse slide. Definir [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutslide/showmastershapes/) como `false` oculta os gráficos do master para slides que utilizam esse layout compartilhado, mesmo que a configuração própria seja `true`. Para ocultar gráficos em apenas um slide, altere a propriedade do slide e deixe o layout compartilhado inalterado.

A configuração não é suportada como controle de visibilidade no próprio slide master. Em um master ela sempre retorna `false`, e atribuir `true` gera `NotSupportedException`. Aplique-a a um slide normal ou a um layout.

### **Distinguir gráficos do fundo**

| Operação | Efeito |
| --- | --- |
| Ocultar gráficos do master | Controla a visibilidade das formas herdadas do master sem excluí‑las ou alterar as próprias formas do slide. |
| Alterar o preenchimento do fundo do slide | Altera a cor, gradiente ou imagem de fundo. Os gráficos do master são formas separadas e podem permanecer visíveis sobre esse fundo. Veja [Fundo da Apresentação](/slides/pt/net/presentation-background/). |
| Excluir uma forma do master | Remove a forma fonte compartilhada, de modo que ela não esteja mais disponível para nenhum slide que use esse master. |

## **Trabalhar com placeholders**

Placeholders são normalmente definidos em layout slides. O slide master fornece o estilo e o tema compartilhados que esses layouts herdam, enquanto cada layout decide quais placeholders estão disponíveis e onde são colocados.

No PowerPoint, os comandos de placeholder estão disponíveis na visualização Slide Master.

![O comando Inserir Placeholder na visualização Slide Master do PowerPoint](slide-master_5.png)

Para adicionar novos placeholders com Aspose.Slides, trabalhe com o layout slide que pertence ao master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

Você também pode formatar formas de placeholder que já existam em um slide master. O exemplo a seguir encontra o placeholder de título e aplica um preenchimento de degradê linear:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![Placeholder de título formatado herdado por slides normais](slide-master_8.png)

Para mais opções de placeholders e formatação de texto, veja [Definir Texto de Prompt em Placeholder](/slides/pt/net/manage-placeholder/) e [Formatação de Texto](/slides/pt/net/text-formatting/).

## **Alterar o fundo de um Slide Master**

Um fundo de master é herdado por layouts e slides que não o sobrescrevem. O exemplo a seguir define uma cor de fundo sólida para o primeiro slide master:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

Para tópicos relacionados, veja [Fundo da Apresentação](/slides/pt/net/presentation-background/) e [Tema da Apresentação](/slides/pt/net/presentation-theme/).

## **Clonar um Slide Master para outra apresentação**

Use [IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslidecollection/addclone/) para copiar um slide master para outra apresentação. O master copiado pode então ser usado por layouts e slides na apresentação de destino.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

Se precisar clonar slides normais juntamente com seu master, veja [Clonar Slides](/slides/pt/net/clone-slides/).

## **Adicionar vários Slide Masters**

Uma apresentação pode conter múltiplos slide masters. Isso é útil quando diferentes seções requerem branding, estrutura de página ou configurações de tema diferentes.

![Comandos do PowerPoint para inserir e gerenciar slide masters](slide-master_9.jpg)

O exemplo a seguir clona o master padrão, atribui ao clone um fundo diferente, cria um layout sob esse master clonado e adiciona um novo slide baseado nesse layout:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **Comparar Slide Masters**

Slide masters podem ser comparados com o método `Equals` herdado de [IBaseSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/ibaseslide/). A comparação verifica estrutura e conteúdo estático, como formas, texto, formatação, animações e outras configurações de slide. Não compara identificadores únicos, como IDs de slide, ou valores dinâmicos de placeholder, como a data atual.

```csharp
using Aspose.Slides;

using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

Para mais informações, veja [Comparar Slides da Apresentação](/slides/pt/net/compare-slides/).

## **Definir a visualização Slide Master como visualização padrão**

Use a propriedade `LastView` em [ViewProperties](https://reference.aspose.com/slides/pt/net/aspose.slides/viewproperties/) para controlar a visualização que o PowerPoint abre primeiro. O exemplo a seguir abre a apresentação na visualização Slide Master:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

Para mais configurações de visualização, veja [Salvar Apresentação](/slides/pt/net/save-presentation/).

## **Remover Slide Masters não utilizados**

Apresentações às vezes contêm slide masters que não são mais usados por nenhum slide normal. Remover masters não utilizados pode reduzir o tamanho do arquivo e simplificar a manutenção de modelos.

Use [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/pt/net/aspose.slides/masterslidecollection/removeunused/) para remover masters não utilizados da coleção `Masters`:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

Você também pode usar o método de low‑code [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Qual é a diferença entre um slide master e um layout slide?**

Um slide master define configurações de design compartilhadas como tema, fundo, formas comuns e estilos de texto. Um layout slide pertence a um slide master e define um arranjo específico de placeholders. Um slide normal usa um layout slide, herdando tanto do layout quanto do master.

**Uma apresentação pode conter vários slide masters?**

Sim. Uma apresentação pode conter vários slide masters. Use múltiplos masters quando diferentes seções precisam de sistemas visuais ou branding diferentes.

**Devo adicionar placeholders a um slide master ou a um layout slide?**

Na maioria dos casos, adicione placeholders a layout slides. Coloque elementos visuais compartilhados e formatação comum no slide master e coloque os placeholders de conteúdo nos layouts que os slides normais usarão.

**Posso excluir um slide master que ainda está em uso?**

Não. Um slide master que tem slides dependentes não pode ser removido com segurança diretamente. Primeiro mova esses slides para layouts sob outro master, ou use um método de limpeza de masters não usados que remove apenas masters que não estão em uso.