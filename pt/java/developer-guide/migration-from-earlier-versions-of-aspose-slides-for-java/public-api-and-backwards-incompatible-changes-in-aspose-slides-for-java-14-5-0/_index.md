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
description: "Revise as atualizações da API pública e as alterações incompatíveis na Aspose.Slides para Java para migrar suavemente suas soluções de apresentação PowerPoint PPT, PPTX e ODP."
---
{{% alert color="info" %}} 

Esta página lista todas as classes, métodos, propriedades e assim por diante, quaisquer novas [restrições](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) e outras [alterações](/slides/pt/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) introduzidas com a API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **API Pública e Alterações Incompatíveis Retroativas**
### **Classes e Métodos Adicionados**
#### **Adicionada a interface Aspose.Slides.IPresentationInfo e as classes PresentationInfo**
Representa informações sobre a apresentação.

Método Boolean isEncrypted() devolve True se a apresentação estiver criptografada, caso contrário devolve False.

Método LoadFormat getLoadFormat() devolve o tipo da apresentação.
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
#### **Adicionados os métodos IPresentationFactory.getPresentationInfo(string file), IPresentationFactory.getPresentationInfo(InputStream stream)**
Esses métodos permitem que os desenvolvedores obtenham informações sobre um arquivo/fluxo de apresentação sem carregar a apresentação completa.
#### **Adicionado o método IPresentationFactory PresentationFactory.getInstance()**
Permite usar a funcionalidade da fábrica sem instanciação.
### **Restrições**
#### **Restrições foram adicionadas para o uso de valores indefinidos em IShape.getFrame()**
Código que tenta atribuir uma moldura indefinida a IShape.setFrame(IShapeFrame) não faz sentido em casos gerais (particularmente quando o GroupShape pai está aninhado múltiplas vezes em outros {{GroupShape}}s). Por exemplo:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Lança uma ArgumentException: os valores da moldura devem ser definidos.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

ou

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Lança uma ArgumentException: os valores de x, y, largura e altura devem ser definidos.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Este código pode levar a situações pouco claras. Portanto, restrições foram adicionadas para o uso de valores indefinidos em IShape.Frame. Os valores de x, y, width, height, flipH, flipV e rotationAngle devem estar definidos (não Float.NaN ou NullableBool.NotDefined). O código de exemplo acima agora lança uma exceção ArgumentException.
Isso se aplica a esses casos de uso:

``` java
// A moldura passada para IShape.setFrame(IShapeFrame) não pode conter valores indefinidos.

// Os parâmetros x, y, largura e altura dos seguintes métodos IShapeCollection
// não podem ser Float.NaN também:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Mas a moldura retornada por IShape.getRawFrame() pode ser indefinida. Isso faz sentido quando uma forma está vinculada a um placeholder. Então os valores de moldura indefinidos são sobrescritos pela forma placeholder pai. Se não houver placeholder pai para aquela forma, ele usa valores padrão ao avaliar a moldura efetiva com base em seu IShape.getRawFrame(). Os valores padrão são 0 e NullableBool.False para x, y, width, height, flipH, flipV e rotationAngle. Por exemplo:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // A forma está vinculada a um placeholder.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Agora a forma herda os valores de x, y, altura, flipH e flipV do placeholder
    // e substitui largura = 100 e rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Propriedades Alteradas**
#### **Alterado o Tipo e o Nome do método Aspose.Slides.IShapeCollection.getParent()**
O tipo da propriedade Aspose.Slides.IShapeCollection.Parent foi alterado de ISlideComponent para a nova interface IGroupShape. A interface IGroupShape é descendente de ISlideComponent, portanto o código existente não precisa de adaptação.

O nome do método Aspose.Slides.IShapeCollection.getParent() foi alterado de getParent para getParentGroup().
#### **Alterado o Tipo dos métodos Aspose.Slides.IShapeFrame.getFlipH() e .getFlipV()**
O tipo do método Aspose.Slides.IShapeFrame.getFlipH() foi alterado de bool para NullableBool.

O método IShape.getFrame() retorna a instância efetiva de IShapeFrame (cujas propriedades têm valores efetivos definidos).

O método IShape.getRawFrame() retorna uma instância de IShapeFrame na qual cada propriedade pode ter valor indefinido (particularmente FlipH ou FlipV podem ter o valor NullableBool.NotDefined).