---
title: "Formatar Formas do PowerPoint em JavaScript"
linktitle: "Formatação de Formas"
type: docs
weight: 20
url: /pt/nodejs-java/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência de forma
- renderização de forma em preto e branco
- renderização de forma em tons de cinza
- rotacionar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Formate formas do PowerPoint em JavaScript usando Aspose.Slides—defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e total controle."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos em seus contornos. Além disso, é possível formatar formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java fornece classes e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [estilo de linha](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [estilo de traço](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código a seguir demonstra como formatar um `AutoShape` retangular:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática do tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Remover o preenchimento da forma rectangle.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Aplicar formatação às linhas do rectangle.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Definir a cor da linha do rectangle.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Salvar o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

## **Aplicar Efeitos de Esboço nas Linhas de Forma**

Um efeito de esboço faz com que a linha da forma pareça desenhada à mão. Use [Shape.getLineFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/) para acessar as configurações de linha, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/lineformat/) para acessar as configurações de esboço e [SketchFormat.setSketchType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sketchformat/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/linesketchtype/).

O código JavaScript a seguir mostra como aplicar o efeito [LineSketchType.Curved](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/linesketchtype/), ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/linesketchtype/):

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Acessar o formato de linha da forma e seu formato de esboço.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Aplicar um efeito de esboço.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Ler o efeito de esboço atribuído diretamente à forma.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Remover o efeito de esboço.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

O valor retornado por [SketchFormat.getSketchType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/sketchformat/) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [LineFormat.getEffective](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/lineformat/), chame `getSketchFormat` no objeto retornado e, em seguida, chame seu método `getSketchType`. O valor efetivo reflete a formatação realmente aplicada após a resolução da herança:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Round**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![O estilo de junção na apresentação](join-style-powerpoint.png)

O código JavaScript a seguir demonstra como três retângulos (conforme mostrados na imagem acima) foram criados usando as configurações de tipo de junção Miter, Bevel e Round:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar três formas automáticas do tipo Rectangle.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Definir a cor de preenchimento para cada forma retângulo.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Definir a largura da linha.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Definir a cor da linha de cada retângulo.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Definir o estilo de junção.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Adicionar texto a cada retângulo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salvar o arquivo PPTX no disco.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preenchimento Gradiente**

No PowerPoint, Preenchimento Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma vá gradualmente desaparecendo na outra.

Veja como aplicar um preenchimento gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção de paradas de gradiente exposta pela classe [GradientFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/gradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

O código JavaScript a seguir demonstra como aplicar um efeito de preenchimento gradiente a uma elipse:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática do tipo Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formatação gradiente à elipse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Definir a direção do gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Adicionar duas paradas de gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Salvar o arquivo PPTX no disco.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A elipse com preenchimento gradiente](gradient-fill.png)

## **Preenchimento de Padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, hachuras ou xadrez — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides fornece mais de 45 estilos de padrão predefinidos que podem ser aplicados a formas para melhorar a aparência visual de suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão dentre as opções predefinidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/patternformat/#getBackColor--) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/patternformat/#getForeColor--) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

O código JavaScript a seguir demonstra como aplicar um preenchimento de padrão a um retângulo:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática do tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Definir o tipo de preenchimento como Pattern.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Definir o estilo do padrão.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Definir as cores de fundo e de primeiro plano do padrão.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salvar o arquivo PPTX no disco.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento de Imagem**

No PowerPoint, Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — efetivamente usando a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento de imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) a partir da imagem que deseja usar.
1. Passe a imagem para o método `ISlidesPicture.setImage`.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que temos um arquivo "lotus.png" com a seguinte imagem:

![A imagem lotus](lotus.png)

O código JavaScript a seguir demonstra como preencher uma forma com a imagem:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática do tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Definir o tipo de preenchimento como Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Definir o modo de preenchimento da imagem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Carregar uma imagem e adicioná‑la aos recursos da apresentação.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Definir a imagem.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salvar o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma com preenchimento de imagem](picture-fill.png)

### **Imagem em Tile como Textura**

Se desejar definir uma imagem em tile como textura e personalizar o comportamento do tile, use os seguintes métodos da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): especifica o alinhamento dos tiles dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): controla se o tile é invertido horizontalmente, verticalmente ou em ambos.
- [setTileOffsetX](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): define o deslocamento horizontal do tile (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): define o deslocamento vertical do tile (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): define a escala horizontal do tile como porcentagem.
- [setTileScaleY](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): define a escala vertical do tile como porcentagem.

O exemplo de código a seguir mostra como adicionar uma forma retangular com preenchimento de imagem em tile e configurar as opções de tile:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática retangular.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Definir o tipo de preenchimento da forma como Picture.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Carregar a imagem e adicioná‑la aos recursos da apresentação.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Atribuir a imagem à forma.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurar o modo de preenchimento da imagem e as propriedades de tiling.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Salvar o arquivo PPTX no disco.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As opções de tile](tile-options.png)

## **Preenchimento de Cor Sólida**

No PowerPoint, Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) da forma como `Solid`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código JavaScript a seguir demonstra como aplicar um preenchimento de cor sólida a um retângulo em um slide do PowerPoint:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática do tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Definir o tipo de preenchimento como Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Definir a cor de preenchimento.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salvar o arquivo PPTX no disco.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento de cor sólida, gradiente, imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência maior deixa a forma mais translúcida, permitindo que o plano de fundo ou objetos subjacentes sejam parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) como `Solid`.
1. Use `Color` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

O código JavaScript a seguir demonstra como aplicar uma cor de preenchimento transparente a um retângulo:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática retangular sólida.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Adicionar uma forma automática retangular transparente sobre a forma sólida.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Salvar o arquivo PPTX no disco.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar Formas**

Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com necessidades específicas de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina a propriedade de rotação da forma para o ângulo desejado.
1. Salve a apresentação.

O código JavaScript a seguir demonstra como rotacionar uma forma em 5 graus:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Instanciar a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma automática do tipo Rectangle.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotacionar a forma em 5 graus.
    shape.setRotation(5);

    // Salvar o arquivo PPTX no disco.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/).

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
1. Salve a apresentação.

O código JavaScript a seguir mostra como aplicar efeitos de bisel 3D a uma forma:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Criar uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma ao slide.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Definir as propriedades ThreeDFormat da forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Salvar a apresentação como um arquivo PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O efeito de bisel 3D](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Use [setCameraType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/lightrig/#setLightType) para definir a rotação 3D.
1. Salve a apresentação.

O código JavaScript a seguir demonstra como aplicar efeitos de rotação 3D a uma forma:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Criar uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Salvar a apresentação como um arquivo PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Controlar Renderização em Preto e Branco para Formas**

O método [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto e branco. Ele não habilita a exibição em preto e branco por si só e não altera o preenchimento, a linha ou outras formatações da forma no modo de cor normal.

Use um valor da enumeração [BlackWhiteMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` permite que o aplicativo de renderização escolha a conversão, `Gray` e `LightGray` usam coloração cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma cor única, `Color` preserva a coloração normal e `Hidden` omite a forma no modo preto e branco. `NotDefined` significa que nenhum modo de nível de forma foi atribuído.

O código JavaScript a seguir cria uma forma colorida e faz com que ela apareça cinza no modo de exibição preto e branco:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // Manter o preenchimento laranja no modo de cor, mas renderizar a forma com coloração cinza no modo preto e branco.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

No modo de cor normal, o retângulo mantém seu preenchimento laranja. No fluxo de trabalho de exibição em preto e branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite que você preserve um slide em cores completas ao definir uma aparência distinta para impressão, visualização ou outros fluxos que respeitam as configurações de exibição preto e branco da apresentação.

## **Redefinir Formatação**

O código JavaScript a seguir mostra como redefinir a formatação de um slide e restaurar a posição, tamanho e formatação de todas as formas com marcadores no [LayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/) para suas configurações padrão:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Redefinir cada forma no slide que tem um placeholder no layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**A formatação de forma afeta o tamanho final do arquivo da apresentação?**

Apenas minimamente. Imagens e mídias incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e quase não adicionam tamanho extra.

**Como posso detectar formas em um slide que compartilham formatação idêntica para agrupá‑las?**

Compare as principais propriedades de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, simplificando o gerenciamento de estilo posterior.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas necessárias e reaplique sua formatação onde for preciso.