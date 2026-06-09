---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para .NET 14.5.0
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
description: "Reveja as atualizações da API pública e as mudanças que quebram a compatibilidade no Aspose.Slides para .NET para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades e assim por diante [adicionados](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/), quaisquer novas [restrições](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) e outras [alterações](/slides/pt/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/) introduzidas com a API Aspose.Slides para .NET 14.5.0.

{{% /alert %}} 
## **API Pública e Alterações Incompatíveis Retroativas**
### **Interfaces, Classes, Propriedades e Métodos Adicionados**
#### **Adicionada a Interface Aspose.Slides.IPresentationInfo e a Classe PresentationInfo**
Representa informações sobre a apresentação.

- A propriedade Boolean IsEncrypted retorna True se uma apresentação estiver criptografada, caso contrário retorna False.
- A propriedade LoadFormat obtém o tipo de uma apresentação.
#### **Adicionada a Propriedade Aspose.Slides.IShape.IsGrouped**
A propriedade Aspose.Slides.IShape.IsGrouped determina se uma forma está agrupada.
#### **Adicionada a Propriedade Aspose.Slides.IShape.ParentGroup**
A propriedade Aspose.Slides.IShape.ParentGroup devolve o objeto GroupShape pai se uma forma estiver agrupada. Caso contrário, devolve null.
#### **Adicionado o Método Aspose.Slides.IShapeCollection.AddGroupShape()**
O método Aspose.Slides.IShapeCollection.AddGroupShape() cria um novo GroupShape e o adiciona ao final da coleção.
O tamanho e a posição da moldura do GroupShape serão ajustados ao conteúdo quando uma nova forma for adicionada.
#### **Adicionado o Método Aspose.Slides.IShapeCollection.Clear()**
O método Aspose.Slides.IShapeCollection.Clear() remove todas as formas da coleção.
#### **Adicionado o Método Aspose.Slides.IShapeCollection.InsertGroupShape(int)**
O método Aspose.Slides.IShapeCollection.InsertGroupShape(int) cria um novo GroupShape e o insere na coleção na posição de índice especificada.
O tamanho e a posição da moldura do GroupShape serão ajustados ao conteúdo quando uma nova forma for adicionada.
#### **Adicionados os Métodos IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream)**
Esses métodos permitem obter informações sobre um arquivo ou fluxo de apresentação sem carregar a apresentação integralmente.
#### **Adicionada a Propriedade IPresentationFactory PresentationFactory.Instance**
Esta propriedade permite que os desenvolvedores utilizem a funcionalidade da fábrica sem instância.
### **Restrições**
#### **Restrições ao IShape.Frame**
Restrições foram adicionadas para o uso de valores indefinidos em IShape.Frame. Código que tenta atribuir uma moldura indefinida a IShape.Frame não faz sentido na maioria dos casos (particularmente quando o GroupShape pai está aninhado múltiplas vezes em outros {{GroupShape}}s). Por exemplo:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

ou

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Tal código pode levar a situações ambíguas. Portanto, restrições foram adicionadas para o uso de valores indefinidos em IShape.Frame. Valores de x, y, width, height, flipH, flipV e rotationAngle devem ser definidos (e não definidos como float.NaN ou NullableBool.NotDefined). O código de exemplo acima agora lança uma exceção ArgumentException.
Isso se aplica a esses casos de uso:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Não pode ser indefinido

IShapeCollection shapes = ...;

// os parâmetros x, y, width, height não podem ser float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}


``` 

Mas as propriedades de moldura de IShape.RawFrame podem ser indefinidas. Isso faz sentido quando uma forma está vinculada a um placeholder. Então os valores de moldura indefinidos da forma são sobrescritos pelo placeholder pai. Se não houver placeholder pai, então essa forma usa valores padrão ao avaliar a moldura efetiva com base em seu IShape.RawFrame. Os valores padrão são 0 e NullableBool.False para x, y, width, height, flipH, flipV e rotationAngle. Por exemplo:

``` csharp

 IShape shape = ...; // shape está vinculado ao placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// agora shape herda valores x, y, height, flipH, flipV do placeholder e substitui width=100 e rotationAngle=0.

``` 
### **Propriedades Alteradas**
#### **Alterado o Nome e o Tipo da Propriedade Aspose.Slides.IShapeCollection.Parent**
- O tipo da propriedade Aspose.Slides.IShapeCollection.Parent foi alterado de ISlideComponent para a nova interface IGroupShape. A interface IGroupShape é descendente de ISlideComponent, portanto o código existente não precisa de adaptações.
- O nome da propriedade Aspose.Slides.IShapeCollection.Parent foi alterado de Parent para ParentGroup.
#### **Alterados os Tipos das Propriedades Aspose.Slides.IShapeFrame.FlipH e .FlipV**
- O tipo da propriedade Aspose.Slides.IShapeFrame.FlipH foi alterado de bool para NullableBool.
- A propriedade IShape.Frame retorna uma instância efetiva de IShapeFrame (cujas propriedades têm valores efetivos definidos).
- A propriedade IShape.RawFrame retorna uma instância de IShapeFrame cujas propriedades podem ter valores indefinidos (particularmente FlipH ou FlipV podem ter o valor NullableBool.NotDefined).