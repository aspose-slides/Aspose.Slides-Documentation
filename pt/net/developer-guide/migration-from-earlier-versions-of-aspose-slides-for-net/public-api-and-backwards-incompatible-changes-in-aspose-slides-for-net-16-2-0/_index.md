---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 16.2.0
linktitle: Aspose.Slides para .NET 16.2.0
type: docs
weight: 230
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Revise as atualizações da API pública e as alterações incompatíveis no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e semelhantes que foram [added](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/) ou [removed](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-16-2-0/), e outras alterações introduzidas com a API do Aspose.Slides for .NET 16.2.0.

{{% /alert %}} 
## **Alterações da API Pública**
#### **Propriedades UpdateDateTimeFields e UpdateSlideNumberFields foram removidas**
As propriedades UpdateDateTimeFields e UpdateSlideNumberFields foram removidas da classe Aspose.Slides.Presentation e da interface Aspose.Slides.IPresentation.  
A propriedade Text das classes Aspose.Slides.TextFrame, Paragraph, Portion e das interfaces Aspose.Slides.ITextFrame, IParagraph, IPortion retorna texto com campos "datetime" atualizados.  
Além disso, as propriedades Presentation.DocumentProperties.CreatedTime, LastSavedTime e LastPrinted tornaram‑se somente leitura.  
#### **Enum Slides.Charts.CategoryAxisType foi tornado público**
Usado nas propriedades IAxis.CategoryAxisType e Axis.CategoryAxisType para determinar o tipo de eixo de categoria.  
CategoryAxisType.Auto - o tipo de eixo de categoria será determinado automaticamente durante a serialização (este comportamento ainda não está implementado)  
CategoryAxisType.Text - o tipo de eixo de categoria é Text  
CategoryAxisType.Date - o tipo de eixo de categoria é DateTime  
#### **Extração Rápida de Texto**
O novo método estático GetPresentationText foi adicionado à classe Presentation. Existem duas sobrecargas para esse método:

``` csharp

 PresentationText GetPresentationText(Stream stream)

PresentationText GetPresentationText(Stream stream, ExtractionMode mode)

``` 

O argumento enum ExtractionMode indica o modo de organizar a saída do resultado de texto e pode ser definido com os seguintes valores:  
- Unarranged - O texto bruto sem considerar a posição no slide  
- Arranged - O texto é posicionado na mesma ordem que no slide  

O modo Unarranged pode ser usado quando a velocidade é crítica, sendo mais rápido que o modo Arranged.  

PresentationText representa o texto bruto extraído da apresentação. Ele contém uma propriedade SlidesText do namespace Aspose.Slides.Util que retorna um array de objetos ISlideText. Cada objeto representa o texto no slide correspondente. O objeto ISlideText possui as seguintes propriedades:  

- ISlideText.Text - O texto nas formas do slide  
- ISlideText.MasterText - O texto nas formas da página mestre para este slide  
- ISlideText.LayoutText - O texto nas formas da página de layout para este slide  
- ISlideText.NotesText - O texto nas formas da página de notas para este slide  

Também há uma classe SlideText que implementa a interface ISlideText.  

A nova API pode ser usada da seguinte forma:

``` csharp

 PresentationText text1 = Presentation.GetPresentationText("presentation.ppt");

Console.WriteLine(text1.SlidesText[0].Text);

Console.WriteLine(text1.SlidesText[0].LayoutText);

Console.WriteLine(text1.SlidesText[0].MasterText);

Console.WriteLine(text1.SlidesText[0].NotesText);

PresentationText text2 = Presentation.GetPresentationText("presentation.pptx", ExtractionMode.Unarranged)

``` 
#### **Interface ILegacyDiagram e Classe LegacyDiagram foram adicionadas**
A interface Aspose.Slides.ILegacyDiagram e a classe Aspose.Slides.LegacyDiagram foram adicionadas para representar o objeto de diagrama legado. O objeto de diagrama legado é um formato antigo de diagramas do PowerPoint 97-2003.  
A nova classe fornece métodos para converter o diagrama legado em um objeto SmartArt editável moderno ou em um GroupShape editável.  
#### **Novo membro do enum Aspose.Slides.TextAlignment adicionado (JustifyLow)**
Foi adicionado um novo membro ao enum TextAlignment: JustifyLow - Kashida justifica baixa.  
#### **Novas propriedades para Aspose.Slides.IOleObjectFrame e OleObjectFrame**
Novas propriedades foram adicionadas à interface IOleObjectFrame e à classe OleObjectFrame que implementa essa interface. Essas propriedades são usadas para fornecer informações sobre um objeto incorporado na apresentação:  

- EmbeddedFileExtension - Retorna a extensão do arquivo do objeto incorporado atual ou string vazia se o objeto não for um link  
- EmbeddedFileLabel - Retorna o nome do arquivo do objeto OLE incorporado  
- EmbeddedFileName - Retorna o caminho do objeto OLE incorporado  

#### **Nova propriedade CategoryAxisType foi adicionada às classes IAxis e Axis**
A propriedade CategoryAxisType especifica o tipo de eixo de categoria.

``` csharp

 using (Presentation pres = new Presentation(sourcePptxFileName))

{

   IChart chart = pres.Slides[0].Shapes[0] as IChart;

   chart.Axes.HorizontalAxis.CategoryAxisType = CategoryAxisType.Date;

   chart.Axes.HorizontalAxis.IsAutomaticMajorUnit = false;

   chart.Axes.HorizontalAxis.MajorUnit = 1;

   chart.Axes.HorizontalAxis.MajorUnitScale = TimeUnitType.Months;

   pres.Save(pptxOutPath, SaveFormat.Pptx);

}

``` 
#### **Nova propriedade ShowLabelAsDataCallout foi adicionada à classe DataLabelFormat e à interface IDataLabelFormat**
A propriedade ShowLabelAsDataCallout determina se o rótulo de dados do gráfico especificado será exibido como chamada de dados ou como rótulo de dados.

``` csharp

 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.Pie, 50, 50, 500, 400);

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

   chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

   chart.ChartData.Series[0].Labels[2].DataLabelFormat.ShowLabelAsDataCallout = false;

   pres.Save(pptxFileName, SaveFormat.Pptx);

}

``` 
#### **Propriedade DrawSlidesFrame foi adicionada ao PdfOptions e XpsOptions**
A propriedade booleana DrawSlidesFrame foi adicionada às interfaces Aspose.Slides.Export.IPdfOptions, Aspose.Slides.Export.IXpsOptions e às classes relacionadas Aspose.Slides.Export.PdfOptions, Aspose.Slides.Export.XpsOptions. Uma moldura preta ao redor de cada slide será desenhada se esta propriedade for definida como 'true'.

``` csharp

 using (Presentation pres = new Presentation("input.pptx"))

{

    pres.Save("output.pdf", SaveFormat.Pdf, new PdfOptions() { DrawSlidesFrame = true });

}

```