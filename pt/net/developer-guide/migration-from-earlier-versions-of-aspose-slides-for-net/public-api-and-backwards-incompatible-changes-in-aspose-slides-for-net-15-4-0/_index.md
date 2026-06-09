---
title: API Pública e Alterações Incompatíveis com Versões Anteriores no Aspose.Slides para .NET 15.4.0
linktitle: Aspose.Slides para .NET 15.4.0
type: docs
weight: 150
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/
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
description: "Revise as atualizações da API pública e as mudanças que quebram compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 
Esta página lista todos os [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) ou [removidos](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-4-0/) classes, métodos, propriedades e assim por diante, e outras alterações introduzidas com a API do Aspose.Slides for .NET 15.4.0.
{{% /alert %}} 
## **Alterações da API Pública**
#### **Enum OrganizationChartLayoutType Foi Adicionado**
O enum Aspose.Slides.SmartArt.OrganizationChartLayoutType representa o tipo de formatação dos nós filhos em um organograma.
#### **Method IBulletFormat.ApplyDefaultParagraphIndentsShifts Foi Adicionado**
O método Aspose.Slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts define deslocamentos padrão diferentes de zero para recuo de parágrafo (Indent) e margem esquerda (MarginLeft) quando as marcas de lista estão habilitadas (como o PowerPoint faz ao habilitar marcas/numeração de parágrafos). Se as marcas de lista estiverem desabilitadas, ele apenas redefinir o recuo de parágrafo e a margem esquerda (como o PowerPoint faz ao desabilitar marcas/numeração de parágrafos).
Veja exemplos [aqui](/slides/pt/net/adding-and-formatting-text/#managing-paragraph-bullets-in-pptx):
#### **Method IConnector.Reroute Foi Adicionado**
O método Aspose.Slides.IConnector.Reroute reencaminha o conector para que ele siga o caminho mais curto possível entre as formas que conecta. Para isso, o método Reroute() pode alterar os índices StartShapeConnectionSiteIndex e EndShapeConnectionSiteIndex.
``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  connector.Reroute();

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Method IPresentation.GetSlideById Foi Adicionado**
O método Aspose.Slides.IPresentation.GetSlideById(System.UInt32) retorna um Slide, MasterSlide ou LayoutSlide pelo Id do slide.
``` csharp

 using (Presentation presentation = new Presentation())

{

    uint id = presentation.Slides[0].SlideId;

    IBaseSlide slide = presentation.GetSlideById(id);

    Debug.Assert(presentation.Slides[0] == slide);

}

``` 
#### **Property IShape.ConnectionSiteCount Foi Adicionado**
A propriedade Aspose.Slides.IShape.ConnectionSiteCount retorna o número de pontos de conexão na forma.
``` csharp

 using(Presentation input = new Presentation())

{

  IShapeCollection shapes = input.Slides[0].Shapes;

  IConnector connector = shapes.AddConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

  IAutoShape ellipse = shapes.AddAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

  IAutoShape rectangle = shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

  connector.StartShapeConnectedTo = ellipse;

  connector.EndShapeConnectedTo = rectangle;

  uint wantedIndex = 6;

  if (ellipse.ConnectionSiteCount > wantedIndex)

  {

    connector.StartShapeConnectionSiteIndex = wantedIndex;

  }

  input.Save("output.pptx", SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.IsReversed Foi Adicionado**
A propriedade Aspose.Slides.SmartArt.ISmartArt.IsReversed permite obter ou definir o estado do diagrama SmartArt em relação ao LTR (da esquerda para a direita) ou RTL (da direita para a esquerda), se o diagrama suportar inversão.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

  smart.IsReversed = true;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArt.Nodes Foi Adicionado**
A propriedade Aspose.Slides.SmartArt.ISmartArt.Nodes retorna a coleção de nós raiz no objeto SmartArt.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

  ISmartArtNode node = smart.Nodes[1]; // selecionar o segundo nó raiz

  node.TextFrame.Text = "Second root node";

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.IsHidden Foi Adicionado**
A propriedade Aspose.Slides.SmartArt.ISmartArtNode.IsHidden retorna true se este nó for um nó oculto no modelo de dados.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

  ISmartArtNode node = smart.AllNodes.AddNode();

  bool hidden = node.IsHidden; // retorna true

  if(hidden)

  {

    // faça algumas ações ou notificações

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Property ISmartArtNode.OrganizationChartLayout Foi Adicionado**
A propriedade Aspose.Slides.SmartArt.ISmartArtNode.OrganizationChartLayout permite obter ou definir o tipo de organograma associado ao nó atual.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

  smart.Nodes[0].OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 
#### **Set Method for Property ISmartArt.Layout Foi Adicionado**
O método set para a propriedade Aspose.Slides.SmartArt.ISmartArt.Layout foi adicionado. Ele permite alterar o tipo de layout de um diagrama existente.
``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  smart.Layout = SmartArtLayoutType.BasicProcess;

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}
``` 
#### **Minor API Changes**
**Esta é a lista de mudanças menores da API:**

|Enum Aspose.Slides.BevelColorMode |excluído, enum não usado |
| :- | :- |
|Property ThreeDFormatEffectiveData.BevelColorMode |excluído, propriedade não usada |
|Property Aspose.Slides.Charts.ChartSeriesGroup.Chart <br>Property Aspose.Slides.Charts.IChartSeriesGroup.AsIChartComponent |adicionado |
|Property Aspose.Slides.IParagraphFormatEffectiveData.AsISlideComponent <br>Herança de IParagraphFormatEffectiveData de ISlideComponent <br>Property Aspose.Slides.IThreeDFormat.AsISlideComponent <br>Herança de IThreeDFormat de ISlideComponent |excluído |
|Property Aspose.Slides.ParagraphFormatEffectiveData.BulletChar <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletFont <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletHeight <br>Property Aspose.Slides.ParagraphFormatEffectiveData.BulletType <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStartWith <br>Property Aspose.Slides.ParagraphFormatEffectiveData.NumberedBulletStyle |excluído como obsoleto |