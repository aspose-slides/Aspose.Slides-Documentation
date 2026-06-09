---
title: Adicionar marcas d'água a apresentações em JavaScript
linktitle: Marca d'água
type: docs
weight: 40
url: /pt/nodejs-java/watermark/
keywords:
- marca d'água
- marca d'água de texto
- marca d'água de imagem
- adicionar marca d'água
- alterar marca d'água
- remover marca d'água
- excluir marca d'água
- adicionar marca d'água ao PPT
- adicionar marca d'água ao PPTX
- adicionar marca d'água ao ODP
- remover marca d'água do PPT
- remover marca d'água do PPTX
- remover marca d'água do ODP
- excluir marca d'água do PPT
- excluir marca d'água do PPTX
- excluir marca d'água do ODP
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie marcas d'água de texto e imagem em apresentações PowerPoint e OpenDocument no Node.js para indicar rascunho, informações confidenciais, direitos autorais e muito mais."
---
## **Introdução**

**Uma marca d'água** em uma apresentação é um selo de texto ou imagem usado em um slide ou em todas as slides da apresentação. Normalmente, uma marca d'água é usada para indicar que a apresentação é um rascunho (por exemplo, uma marca d'água “Rascunho”), que contém informações confidenciais (por exemplo, uma marca d'água “Confidencial”), para especificar a que empresa pertence (por exemplo, uma marca d'água “Nome da Empresa”), para identificar o autor da apresentação etc. Uma marca d'água ajuda a prevenir violações de direitos autorais ao indicar que a apresentação não deve ser copiada. Marcas d'água são usadas tanto nos formatos de apresentação PowerPoint quanto OpenOffice. No Aspose.Slides, você pode adicionar uma marca d'água aos formatos de arquivo PowerPoint PPT, PPTX e OpenOffice ODP.

Em [**Aspose.Slides**](https://products.aspose.com/slides/pt/nodejs-java/), há várias maneiras de criar marcas d'água em documentos PowerPoint ou OpenOffice e modificar seu design e comportamento. O aspecto comum é que, para adicionar marcas d'água de texto, você deve usar o tipo [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/), e para adicionar marcas d'água de imagem, use a classe [PictureFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pictureframe/) ou preencha uma forma de marca d'água com uma imagem. `PictureFrame` implementa o tipo [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/), permitindo usar todas as configurações flexíveis do objeto shape. Como `TextFrame` não é uma shape e suas configurações são limitadas, ele é encapsulado em um objeto [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/).

Existem duas maneiras de aplicar uma marca d'água: a um único slide ou a todas as slides da apresentação. O Slide Master é usado para aplicar uma marca d'água a todas as slides — a marca d'água é adicionada ao Slide Master, totalmente projetada lá, e aplicada a todas as slides sem afetar a permissão de modificar a marca d'água em slides individuais.

Uma marca d'água geralmente é considerada indisponível para edição por outros usuários. Para impedir que a marca d'água (ou melhor, a shape pai da marca d'água) seja editada, o Aspose.Slides fornece funcionalidade de bloqueio de shapes. Uma shape específica pode ser bloqueada em um slide normal ou no Slide Master. Quando a shape da marca d'água é bloqueada no Slide Master, ela será bloqueada em todas as slides da apresentação.

Você pode definir um nome para a marca d'água de modo que, no futuro, se desejar excluí‑la, possa encontrá‑la nas shapes do slide pelo nome.

Você pode projetar a marca d'água de qualquer forma; porém, geralmente há recursos comuns em marcas d'água, como alinhamento central, rotação, posição frontal etc. Consideraremos como usar esses recursos nos exemplos abaixo.

## **Marca d'água de Texto**

### **Adicionar Marca d'água de Texto ao Slide**
Para adicionar uma marca d'água de texto em PPT, PPTX ou ODP, você pode primeiro adicionar uma shape ao slide e, em seguida, adicionar um frame de texto a essa shape. O frame de texto é representado pelo tipo [**TextFrame**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame). Esse tipo não herda de [Shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape), que possui um amplo conjunto de propriedades para posicionar a marca d'água de forma flexível. Portanto, o objeto [TextFrame](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/TextFrame) é encapsulado em um objeto [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape). Para adicionar texto de marca d'água à shape, use o método [**addTextFrame**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) passando o texto da marca d'água:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Veja também" %}} 
- Como usar [TextFrame](/slides/pt/nodejs-java/text-formatting/).
{{% /alert %}}

### **Adicionar Marca d'água de Texto à Apresentação**

Se desejar adicionar uma marca d'água de texto a toda a apresentação (ou seja, a todas as slides de uma vez), adicione‑a ao [**MasterSlide**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/MasterSlide). O restante da lógica é o mesmo que ao adicionar uma marca d'água a um único slide — crie um objeto [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape) e então adicione a marca d'água usando o método [**addTextFrame**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-):

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Veja também" %}} 
- [Como usar ](/slides/pt/nodejs-java/slide-master/)[Slide Master](/slides/pt/nodejs-java/slide-master/)
{{% /alert %}}

### **Definir Transparência da Shape da Marca d'água**

Por padrão, a shape retangular possui cores de preenchimento e linha. As linhas de código a seguir tornam a shape transparente.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Definir a Fonte para uma Marca d'água de Texto**

Você pode alterar a fonte da marca d'água de texto conforme mostrado abaixo.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Definir a Cor do Texto da Marca d'água**

Para definir a cor do texto da marca d'água, use este código:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Centralizar Marca d'água de Texto**
É possível centralizar a marca d'água em um slide e, para isso, você pode fazer o seguinte:



```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

A imagem abaixo mostra o resultado final.

![The text watermark](text_watermark.png)

## **Marca d'água de Imagem**

### **Adicionar uma Marca d'água de Imagem à Apresentação**

Para inserir uma marca d'água de imagem em todas as slides da apresentação, você pode fazer o seguinte:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Bloquear uma Marca d'água contra Edição**

Se for necessário impedir que uma marca d'água seja editada, use o método [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/AutoShape#getShapeLock--) na shape. Com essa propriedade, você pode proteger a shape contra seleção, redimensionamento, reposicionamento, agrupar com outros elementos, bloquear seu texto contra edição e muito mais:

```javascript
// Bloquear a shape da marca d'água contra modificações
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Trazer uma Marca d'água para a Frente**

No Aspose.Slides, a ordem Z das shapes pode ser definida via o método [**SlideCollection.reorder**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Para isso, chame esse método a partir da lista de slides da apresentação e passe a referência da shape e seu número de ordem ao método. Dessa forma, é possível trazer uma shape para a frente ou enviá‑la para o fundo do slide. Esse recurso é especialmente útil se precisar posicionar a marca d'água na frente da apresentação:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Definir Rotação da Marca d'água**

Aqui está um exemplo de código que ajusta a rotação da marca d'água para que ela fique posicionada diagonalmente ao longo do slide:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Definir um Nome para uma Marca d'água**

O Aspose.Slides permite definir o nome de uma shape. Ao usar o nome da shape, você pode acessá‑la no futuro para modificá‑la ou excluí‑la. Para definir o nome da shape da marca d'água, atribua‑o ao método [**AutoShape.getName**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getName--):

```javascript
watermarkShape.setName("watermark");
```

### **Remover uma Marca d'água**

Para remover a shape da marca d'água, use o método [AutoShape.getName](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Shape#getName--) para encontrá‑la nas shapes do slide. Em seguida, passe a shape da marca d'água ao método [**ShapeCollection.remove**](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **FAQ**

**O que é uma marca d'água e por que devo usá‑la?**

Uma marca d'água é uma sobreposição de texto ou imagem aplicada aos slides que ajuda a proteger a propriedade intelectual, reforçar o reconhecimento da marca ou impedir o uso não autorizado das apresentações.

**Posso adicionar uma marca d'água a todas as slides de uma apresentação?**

Sim, o Aspose.Slides permite adicionar uma marca d'água a cada slide da apresentação. Você pode iterar por todas as slides e aplicar as configurações da marca d'água individualmente.

**Como posso ajustar a transparência da marca d'água?**

Você pode ajustar a transparência da marca d'água modificando as [configurações de preenchimento](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/getfillformat/) da shape. Isso garante que a marca d'água seja sutil e não distraia do conteúdo do slide.

**Quais formatos de imagem são suportados para marcas d'água?**

O Aspose.Slides suporta diversos formatos de imagem, como PNG, JPEG, GIF, BMP, SVG e outros.

**Posso personalizar a fonte e o estilo de uma marca d'água de texto?**

Sim, você pode escolher qualquer fonte, tamanho e estilo para combinar com o design da sua apresentação e manter a consistência da marca.

**Como altero a posição ou orientação de uma marca d'água?**

Você pode ajustar a posição e a orientação da marca d'água modificando as coordenadas, tamanho e propriedades de rotação da shape.