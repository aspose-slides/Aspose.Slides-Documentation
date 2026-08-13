---
title: API pública e alterações incompatíveis retroativas no Aspose.Slides para .NET 14.5.0
linktitle: Aspose.Slides para .NET 14.5.0
type: docs
weight: 70
url: /pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
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
description: "Revise as atualizações da API pública e as mudanças disruptivas no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades e assim por diante [added](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) , quaisquer novas [restrictions](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) e outras [changes](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introduzidas com a API Aspose.Slides for .NET 14.5.0.

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Properties and Methods**
#### **Added the Aspose.Slides.IPresentationInfo Interface and PresentationInfo Class**
Representa informações sobre a apresentação.

- A propriedade Boolean IsEncrypted retorna True se a apresentação estiver criptografada, caso contrário retorna False.
- A propriedade LoadFormat LoadFormat retorna o tipo de uma apresentação.
#### **Added the Aspose.Slides.IShape.IsGrouped Property**
A propriedade Aspose.Slides.IShape.IsGrouped determina se uma forma está agrupada.
#### **Added the Aspose.Slides.IShape.ParentGroup Property**
A propriedade Aspose.Slides.IShape.ParentGroup devolve o objeto GroupShape pai se uma forma estiver agrupada. Caso contrário, devolve null.
#### **Added the Aspose.Slides.IShapeCollection.AddGroupShape() Method**
O método Aspose.Slides.IShapeCollection.AddGroupShape() cria um novo GroupShape e o adiciona ao final da coleção.  
O tamanho e a posição da moldura do GroupShape serão ajustados ao conteúdo quando uma nova forma for adicionada.
#### **Added the Aspose.Slides.IShapeCollection.Clear() Method**
O método Aspose.Slides.IShapeCollection.Clear() remove todas as formas da coleção.
#### **Added the Aspose.Slides.IShapeCollection.InsertGroupShape(int) Method**
O método Aspose.Slides.IShapeCollection.InsertGroupShape(int) cria um novo GroupShape e o insere na coleção na posição de índice especificada.  
O tamanho e a posição da moldura do GroupShape serão ajustados ao conteúdo quando uma nova forma for adicionada.
#### **Added the IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Methods**
Esses métodos permitem obter informações sobre um arquivo ou stream de apresentação sem carregar totalmente a apresentação.
#### **Added the IPresentationFactory PresentationFactory.Instance Property**
Essa propriedade permite que os desenvolvedores usem a funcionalidade da fábrica sem instanciar.
### **Restrictions**
#### **Restrictions to IShape.Frame**
Restrições foram adicionadas para o uso de valores indefinidos para IShape.Frame. Código que tenta atribuir uma moldura indefinida a IShape.Frame não faz sentido na maioria dos casos (particularmente quando o GroupShape pai está aninhado múltiplas vezes em outros {{GroupShape}}s). Por exemplo:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShape shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

// Lança ArgumentException: os valores da moldura devem ser definidos.
shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);
``` 

ou

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Lança ArgumentException: x, y, largura e altura devem ser definidos.
slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);
``` 

Tal código pode levar a situações pouco claras. Portanto, restrições foram adicionadas para o uso de valores indefinidos para IShape.Frame. Valores de x, y, width, height, flipH, flipV e rotationAngle devem estar definidos (e não ser atribuído float.NaN ou NullableBool.NotDefined). O código de exemplo acima agora lança uma exceção ArgumentException.  
Isso se aplica a estes casos de uso:

``` csharp
using Aspose.Slides;

Presentation presentation = new Presentation();
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Os parâmetros x, y, largura e altura não podem ser float.NaN, e flipH, flipV
// não podem ser NullableBool.NotDefined:
IShape shape = shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
shape.Frame = new ShapeFrame(100, 100, 200, 100, NullableBool.False, NullableBool.False, 0);

// A mesma restrição se aplica a todos os métodos que criam uma forma:
// AddAudioFrameCD, AddAudioFrameEmbedded, AddAudioFrameLinked, AddAutoShape, AddChart,
// AddConnector, AddOleObjectFrame, AddPictureFrame, AddSmartArt, AddTable, AddVideoFrame,
// InsertAudioFrameEmbedded, InsertAudioFrameLinked, InsertAutoShape, InsertChart,
// InsertConnector, InsertOleObjectFrame, InsertPictureFrame, InsertTable, InsertVideoFrame.
``` 

Mas as propriedades de moldura de IShape.RawFrame podem ser indefinidas. Isso faz sentido quando uma forma está vinculada a um placeholder. então os valores indefinidos da moldura da forma são sobrescritos pelo placeholder pai. Se não houver placeholder pai, então a forma usa valores padrão ao avaliar a moldura efetiva com base em seu IShape.RawFrame. Os valores padrão são 0 e NullableBool.False para x, y, width, height, flipH, flipV e rotationAngle. Por exemplo:

``` csharp
using Aspose.Slides;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // A forma está vinculada a um placeholder
    IShape shape = presentation.Slides[0].Shapes[0];

    shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

    // agora a forma herda valores de x, y, height, flipH, flipV do placeholder e substitui width=100 e rotationAngle=0.
}
``` 
### **Changed Properties**
#### **Changed the Aspose.Slides.IShapeCollection.Parent Property Name and Type**
- O tipo da propriedade Aspose.Slides.IShapeCollection.Parent foi alterado de ISlideComponent para a nova interface IGroupShape. A interface IGroupShape é descendente de ISlideComponent, portanto o código existente não requer adaptações.  
- O nome da propriedade Aspose.Slides.IShapeCollection.Parent foi alterado de Parent para ParentGroup.
#### **Changed the Aspose.Slides.IShapeFrame.FlipH, .FlipV Properties Types**
- O tipo da propriedade Aspose.Slides.IShapeFrame.FlipH foi alterado de bool para NullableBool.  
- A propriedade IShape.Frame devolve uma instância efetiva de IShapeFrame (cujas propriedades têm valores efetivos definidos).  
- A propriedade IShape.RawFrame devolve uma instância de IShapeFrame cujas propriedades podem ter valor indefinido (particularmente FlipH ou FlipV podem ter o valor NullableBool.NotDefined).