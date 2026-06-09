---
title: API Pública e Alterações Incompatíveis Retroativas no Aspose.Slides para Java 14.5.0
linktitle: Aspose.Slides para Java 14.5.0
type: docs
weight: 40
url: /pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- migração
- código legado
- código moderno
- abordagem legada
- abordagem moderna
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Revise as atualizações da API pública e as mudanças quebradoras no Aspose.Slides para Java para migrar suavemente suas soluções de apresentações PowerPoint PPT, PPTX e ODP."
---
{{% alert color="primary" %}} 

Esta página lista todas as classes, métodos, propriedades etc., [adicionados](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/), quaisquer novas [restrições](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introduzidas com a API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **API Pública e Alterações Incompatíveis Retroativas**
### **Classes e Métodos Adicionados**
#### **Adicionada a interface Aspose.Slides.IPresentationInfo e as classes PresentationInfo**
Representa informações sobre a apresentação.

Método Boolean isEncrypted() retorna True se a apresentação está criptografada, caso contrário retorna False.

Método LoadFormat getLoadFormat() obtém o tipo da apresentação.
#### **Adicionado o método Aspose.Slides.IShape.isGrouped()**
O método Aspose.Slides.IShape.isGrouped() determina se a forma está agrupada.
#### **Adicionado o método Aspose.Slides.IShape.getParentGroup()**
O método Aspose.Slides.IShape.getParentGroup() retorna o objeto GroupShape pai se a forma estiver agrupada. Caso contrário, retorna null.
#### **Adicionado o método Aspose.Slides.IShapeCollection.addGroupShape()**
O método Aspose.Slides.IShapeCollection.addGroupShape() cria um novo GroupShape e o adiciona ao final da coleção.

O tamanho e a posição da moldura do GroupShape serão ajustados ao conteúdo quando uma nova forma for adicionada ao GroupShape.
#### **Adicionado o método Aspose.Slides.IShapeCollection.clear()**
O método Aspose.Slides.IShapeCollection.clear() remove todas as formas da coleção.
#### **Adicionado o método Aspose.Slides.IShapeCollection.insertGroupShape(int)**
O método Aspose.Slides.IShapeCollection.insertGroupShape(int) cria um novo GroupShape e o insere na coleção no índice especificado.
O tamanho e a posição da moldura do GroupShape serão ajustados ao conteúdo quando uma nova forma for adicionada ao GroupShape.
#### **Adicionados os métodos IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Esses métodos permitem que os desenvolvedores obtenham informações sobre um arquivo/fluxo de apresentação sem carregar a apresentação completa.
#### **Adicionado o método IPresentationFactory PresentationFactory.getInstance()**
Permite usar a funcionalidade da fábrica sem instanciar.
### **Restrições**
#### **Restrições foram adicionadas para o uso de valores indefinidos em IShape.getFrame()**
Código que tenta atribuir uma moldura indefinida a IShape.setFrame(IShapeFrame) não faz sentido em casos gerais (particularmente quando o GroupShape pai está múltiplas vezes aninhado em outros {{GroupShape}}s). Por exemplo:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

or

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Tal código pode levar a situações pouco claras. Portanto, restrições foram adicionadas para o uso de valores indefinidos em IShape.Frame. Os valores de x, y, width, height, flipH, flipV e rotationAngle devem estar definidos (não Float.NaN ou NullableBool.NotDefined). O código de exemplo acima agora lança uma exceção ArgumentException.
Isso se aplica a esses casos de uso:

``` java

 IShape shape = ...;

shape.setFrame(...); // não pode ser indefinido

IShapeCollection shapes = ...;

// os parâmetros x, y, largura, altura não podem ser Float.NaN:

{
    shapes.addAudioFrameCD(...);
    shapes.addAudioFrameEmbedded(...);
    shapes.addAudioFrameLinked(...);
    shapes.addAutoShape(...);
    shapes.addChart(...);
    shapes.addConnector(...);
    shapes.addOleObjectFrame(...);
    shapes.addPictureFrame(...);
    shapes.addSmartArt(...);
    shapes.addTable(...);
    shapes.addVideoFrame(...);
    shapes.insertAudioFrameEmbedded(...);
    shapes.insertAudioFrameLinked(...);
    shapes.insertAutoShape(...);
    shapes.insertChart(...);
    shapes.insertConnector(...);
    shapes.insertOleObjectFrame(...);
    shapes.insertPictureFrame(...);
    shapes.insertTable(...);
    shapes.insertVideoFrame(...);
}
```

Mas a moldura retornada por IShape.getRawFrame() pode ser indefinida. Isso faz sentido quando uma forma está vinculada a um placeholder. Então, os valores indefinidos da moldura da forma são sobrescritos a partir da forma placeholder pai. Se não houver placeholder pai para aquela forma, ele usa valores padrão ao avaliar a moldura efetiva com base em seu IShape.getRawFrame(). Os valores padrão são 0 e NullableBool.False para x, y, width, height, flipH, flipV e rotationAngle. Por exemplo:

``` java

 IShape shape = ...; // a forma está vinculada ao placeholder

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// agora a forma herda os valores x, y, height, flipH, flipV do placeholder e sobrescreve width=100 e rotationAngle=0.

```
### **Propriedades Alteradas**
#### **Alterado o Tipo e o Nome do método Aspose.Slides.IShapeCollection.getParent()**
O tipo da propriedade Aspose.Slides.IShapeCollection.Parent foi alterado de ISlideComponent para a nova interface IGroupShape. A interface IGroupShape é descendente de ISlideComponent, portanto o código existente não precisa de adaptação.

O nome do método Aspose.Slides.IShapeCollection.getParent() foi alterado de getParent para getParentGroup().
#### **Alterado o Tipo dos Métodos Aspose.Slides.IShapeFrame.getFlipH() e .getFlipV()**
O tipo do método Aspose.Slides.IShapeFrame.getFlipH() foi alterado de bool para NullableBool.

O método IShape.getFrame() retorna a instância efetiva de IShapeFrame (cujas propriedades todas têm valores efetivos definidos).

O método IShape.getRawFrame() retorna uma instância de IShapeFrame na qual cada propriedade pode ter valor indefinido (particularmente FlipH ou FlipV podem ter o valor NullableBool.NotDefined).