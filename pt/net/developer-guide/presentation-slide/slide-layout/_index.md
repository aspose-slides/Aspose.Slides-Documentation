---
title: Aplicar ou Alterar Layouts de Slide em .NET
linktitle: Layout de Slide
type: docs
weight: 60
url: /pt/net/slide-layout/
keywords:
- layout de slide
- layout de conteúdo
- marcador de posição
- design de apresentação
- design de slide
- layout não utilizado
- visibilidade do rodapé
- slide de título
- título e conteúdo
- cabeçalho de seção
- dois conteúdos
- comparação
- apenas título
- layout em branco
- conteúdo com legenda
- imagem com legenda
- título e texto vertical
- título vertical e texto
- PowerPoint
- OpenDocument
- apresentação
- C#
- .NET
- Aspose.Slides
description: "Aplicar, criar e modificar layouts de slide no Aspose.Slides para .NET, adicionar marcadores de posição, remover layouts não utilizados e controlar a visibilidade do rodapé."
---
## **Visão geral**

Um layout de slide define as posições e formatação de marcadores de posição, como títulos, texto, imagens, gráficos e tabelas. Aplicar um layout fornece aos slides uma estrutura consistente, permitindo que cada slide contenha seu próprio conteúdo.

Os layouts mais comuns incluem:

- **Slide de Título**: Contém marcadores de posição de título e subtítulo.
- **Título e Conteúdo**: Contém um marcador de posição de título e um marcador de posição de conteúdo de uso geral.
- **Em branco**: Não contém marcadores de posição de conteúdo e é útil quando cada forma será posicionada manualmente.

## **Entender a Herança de Layout**

Uma apresentação tem três níveis relacionados:

1. Um [slide mestre](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/) define o tema, formatação compartilhada, fundos e objetos comuns.
2. Um [slide de layout](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/) pertence a um mestre e define um arranjo específico de marcadores de posição.
3. Um [slide normal](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/) usa um layout e armazena o conteúdo inserido para esse slide.

Um slide normal herda tema e formatação do seu layout, e o layout herda do seu mestre. Um valor definido diretamente em um slide normal substitui o valor herdado nesse nível. Quando um slide normal é criado, suas formas de marcador de posição são geradas a partir do layout selecionado, enquanto o conteúdo inserido nesses marcadores pertence ao slide normal.

Adicione os marcadores de posição necessários a um layout antes de criar slides a partir dele. Adicionar outro marcador de posição a um layout posteriormente não adiciona automaticamente a forma de marcador correspondente aos slides normais existentes.

Esse relacionamento tem duas consequências importantes:

- Alterar a formatação herdada ou a geometria de marcadores de posição existentes em um layout pode atualizar todos os slides que dependem dele. Antes de editar um layout já em uso, verifique seus slides dependentes e revise a apresentação resultante.
- Um layout que ainda está sendo usado por um slide não pode ser removido. Reatribua seus slides dependentes a outro layout primeiro, ou remova apenas layouts não utilizados.

Para mais informações sobre o nível superior dessa hierarquia, veja [Mestre de Slide](/slides/pt/net/slide-master/).

## **Selecionar e Aplicar um Layout de Slide**

Use um tipo de layout quando a apresentação segue as definições padrão de layout do PowerPoint. Os nomes de layout são editáveis pelo usuário e podem ser localizados, portanto a seleção baseada em nome é menos confiável, a menos que você controle o modelo de origem.

O exemplo a seguir procura por **Título e Conteúdo** no primeiro mestre. Se esse layout não estiver disponível, ele recai deliberadamente para **Em branco**. A segunda verificação de nulo é necessária porque uma apresentação pode conter apenas layouts personalizados. O layout selecionado é então aplicado ao primeiro slide normal através da propriedade [ISlide.LayoutSlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/layoutslide/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

Alterar o layout de um slide não remove as formas ordinárias adicionadas diretamente ao slide. Entretanto, as posições dos marcadores de posição, a formatação herdada e a correspondência entre marcadores existentes e o novo layout podem mudar, portanto inspecione a saída ao alternar entre layouts substancialmente diferentes.

## **Adicionar um Slide de Layout**

Seleção e criação são operações separadas. O exemplo anterior seleciona um layout existente; não o cria. Para criar um layout, chame o método [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/pt/net/aspose.slides/masterlayoutslidecollection/add/) na coleção de layouts do mestre de destino.

O exemplo a seguir sempre adiciona um novo layout **Título e Conteúdo** chamado `Report Title and Content`, depois adiciona um slide normal baseado nele. Os nomes de layout devem ser exclusivos dentro da coleção.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

Adicione um layout somente quando o modelo realmente precisar de outra estrutura reutilizável. Se já existir um layout adequado, selecione‑o e reutilize‑o em vez de criar um duplicado.

## **Adicionar Marcadores de Posição a um Slide de Layout**

A propriedade [ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/placeholdermanager/) fornece um [ILayoutPlaceholderManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutplaceholdermanager/) para adicionar formas de marcador de posição a um layout.

| Marcador de Posição do PowerPoint | Método `ILayoutPlaceholderManager` |
| --------------------------------- | ---------------------------------- |
| ![Conteúdo](content.png)          | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![Conteúdo (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![Texto](text.png)                | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![Texto (Vertical)](textV.png)    | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![Imagem](picture.png)            | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![Gráfico](chart.png)             | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![Tabela](table.png)              | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)         | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![Mídia](media.png)               | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![Imagem Online](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/pt/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

O exemplo a seguir verifica se o layout **Em branco** existe, adiciona quatro marcadores de posição a ele e, em seguida, cria um slide normal que usa o layout modificado. A ordem é intencional: os marcadores são adicionados antes da criação do slide normal, para que o Aspose.Slides possa gerar as formas de marcador correspondentes naquele slide.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

O resultado:

![Os marcadores de posição no slide de layout](add_placeholders.png)

{{% alert color="warning" title="Aviso" %}}
Alterar a formatação herdada ou a geometria de marcadores de posição existentes no layout pode afetar os slides dependentes. Um marcador de posição de layout recém‑adicionado não é retroalimentado nos slides normais existentes. Teste alterações de layout em uma cópia da apresentação e inspecione cada slide dependente.
{{% /alert %}}

## **Remover Slides de Layout Não Utilizados**

Use o método [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para remover layouts que nenhum slide normal referencia. O método mantém intactos os layouts que ainda estão em uso.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

Para remover um layout específico, primeiro verifique sua propriedade [HasDependingSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/hasdependingslides/) ou o método [GetDependingSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/getdependingslides/). Reatribua quaisquer slides dependentes antes de chamar [ILayoutSlide.Remove](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/remove/). Tentar remover um layout em uso gera uma [PptxEditException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxeditexception/).

## **Controlar a Visibilidade do Rodapé em um Slide de Layout**

Um layout tem seus próprios marcadores de posição de rodapé, número do slide e data/hora. Use a propriedade [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/headerfootermanager/) para controlar esses marcadores em um único layout. Isso é útil quando, por exemplo, layouts de conteúdo devem exibir rodapés, mas layouts de título não devem.

O exemplo a seguir seleciona um layout com segurança e torna seus elementos de rodapé visíveis:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **Controlar a Visibilidade do Rodapé em um Mestre e Seus Layouts Filhos**

Para aplicar configurações de rodapé consistentes em toda a hierarquia do mestre, use a propriedade [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslide/headerfootermanager/). Os métodos de propagação de [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pt/net/aspose.slides/imasterslideheaderfootermanager/) atuam no mestre e em seus slides de layout dependentes e slides normais; eles não visam apenas um slide normal.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Qual é a diferença entre um slide mestre e um slide de layout?**

Um slide mestre define o tema da apresentação e a formatação compartilhada. Um slide de layout pertence a um mestre e define um arranjo reutilizável de marcadores de posição. Slides normais usam esses layouts e armazenam conteúdo específico de cada slide.

**Posso copiar um slide de layout de uma apresentação para outra?**

Sim. Adicione uma cópia à coleção de destino usando o método [AddClone](https://reference.aspose.com/slides/pt/net/aspose.slides/globallayoutslidecollection/addclone/). Ao copiar entre apresentações, verifique também fontes, temas, imagens e outros recursos usados pelo layout de origem.

**O que acontece quando modifico um layout que já está em uso?**

Slides dependentes herdam as alterações do layout, a menos que substituam a formatação ou os objetos afetados localmente. A geometria dos marcadores de posição e o estilo herdado podem mudar em muitos slides de uma só vez. Use [GetDependingSlides](https://reference.aspose.com/slides/pt/net/aspose.slides/ilayoutslide/getdependingslides/) para identificar os slides afetados antes de editar o layout.

**O que acontece se eu remover um layout que ainda está em uso?**

O Aspose.Slides lança uma [PptxEditException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxeditexception/). Reatribua primeiro os slides dependentes ou use [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) para remover apenas os layouts não referenciados.