---
title: Formatar formas do PowerPoint em JavaScript
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/nodejs-java/shape-formatting/
keywords:
- formatar forma
- formatar linha
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência de forma
- rotacionar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Formate formas do PowerPoint em JavaScript usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos às suas contornos. Além disso, pode formatar formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Node.js via Java fornece classes e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código a seguir demonstra como formatar um `AutoShape` retangular:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Define a cor de preenchimento para a forma retângulo.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Aplica formatação às linhas do retângulo.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Define a cor da linha do retângulo.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Salva o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The formatted lines in the presentation](formatted-lines.png)

## **Formatar estilos de junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Round**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

O código JavaScript a seguir demonstra como três retângulos (conforme a imagem acima) foram criados usando as configurações de tipo de junção Miter, Bevel e Round:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona três formas automáticas do tipo Retângulo.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Define a cor de preenchimento para cada forma retângulo.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Define a largura da linha.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Define a cor da linha de cada retângulo.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Define o estilo de junção.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Adiciona texto a cada retângulo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salva o arquivo PPTX no disco.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preenchimento gradiente**

No PowerPoint, Preenchimento Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma desapareça gradualmente na outra.

Veja como aplicar um preenchimento gradiente a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção de paradas de gradiente exposta pela classe [GradientFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/gradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

O código JavaScript a seguir demonstra como aplicar um efeito de preenchimento gradiente a uma elipse:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática do tipo Elipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplica formatação gradiente à elipse.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Define a direção do gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Adiciona duas paradas de gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Salva o arquivo PPTX no disco.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The ellipse with gradient fill](gradient-fill.png)

## **Preenchimento de padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, cruzes ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides fornece mais de 45 estilos de padrão predefinidos que podem ser aplicados a formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão entre as opções predefinidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/patternformat/#getBackColor--) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/patternformat/#getForeColor--) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

O código JavaScript a seguir demonstra como aplicar um preenchimento de padrão a um retângulo:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Define o tipo de preenchimento como Padrão.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Define o estilo de padrão.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Define as cores de fundo e de primeiro plano do padrão.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salva o arquivo PPTX no disco.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The rectangle with pattern fill](pattern-fill.png)

## **Preenchimento de imagem**

No PowerPoint, Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — efetivamente usando a imagem como fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento da imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [PPImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ppimage/) a partir da imagem que você deseja usar.
1. Passe a imagem para o método `ISlidesPicture.setImage`.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que tenhamos um arquivo "lotus.png" com a seguinte imagem:

![The lotus picture](lotus.png)

O código JavaScript a seguir demonstra como preencher uma forma com a imagem:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Define o tipo de preenchimento como Imagem.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Define o modo de preenchimento da imagem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Carrega uma imagem e a adiciona aos recursos da apresentação.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Define a imagem.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salva o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The shape with picture fill](picture-fill.png)

### **Imagem em bloco como textura**

Se você quiser definir uma imagem em bloco como textura e personalizar o comportamento de ladrilhamento, pode usar os seguintes métodos da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica o alinhamento dos blocos dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Controla se o bloco é invertido horizontalmente, verticalmente ou em ambas as direções.
- [setTileOffsetX](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Define o deslocamento horizontal do bloco (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Define o deslocamento vertical do bloco (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Define a escala horizontal do bloco como porcentagem.
- [setTileScaleY](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Define a escala vertical do bloco como porcentagem.

O exemplo de código a seguir mostra como adicionar uma forma retangular com preenchimento de imagem em bloco e configurar as opções de bloco:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática de retângulo.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Define o tipo de preenchimento da forma como Imagem.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Carrega a imagem e a adiciona aos recursos da apresentação.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Atribui a imagem à forma.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configura o modo de preenchimento da imagem e as propriedades de ladrilhamento.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Salva o arquivo PPTX no disco.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The tile options](tile-options.png)

## **Preenchimento de cor sólida**

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
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Define o tipo de preenchimento como Sólido.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Define a cor de preenchimento.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Salva o arquivo PPTX no disco.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The shape with solid color fill](solid-color-fill.png)

## **Definir transparência**

No PowerPoint, ao aplicar um preenchimento de cor sólida, gradiente, imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência maior torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes sejam parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa da cor usada no preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) como `Solid`.
1. Use `Color` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

O código JavaScript a seguir demonstra como aplicar uma cor de preenchimento transparente a um retângulo:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática de retângulo sólido.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Adiciona uma forma automática de retângulo transparente sobre a forma sólida.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Salva o arquivo PPTX no disco.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The transparent shape](shape-transparency.png)

## **Rotacionar formas**

Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com alinhamento ou necessidades de design específicas.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Defina a propriedade de rotação da forma para o ângulo desejado.
1. Salve a apresentação.

O código JavaScript a seguir demonstra como rotacionar uma forma em 5 graus:

```js
// Instancia a classe Presentation que representa um arquivo de apresentação.
let presentation = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide.
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotaciona a forma em 5 graus.
    shape.setRotation(5);

    // Salva o arquivo PPTX no disco.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The shape rotation](shape-rotation.png)

## **Adicionar efeitos de bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/).

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/) da forma para definir as configurações de bisel.
1. Salve a apresentação.

O código JavaScript a seguir mostra como aplicar efeitos de bisel 3D a uma forma:

```js
// Cria uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Adiciona uma forma ao slide.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Define as propriedades ThreeDFormat da forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Salva a apresentação como um arquivo PPTX.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The 3D bevel effect](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/autoshape/) ao slide.
1. Use os métodos [setCameraType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/lightrig/#setLightType) para definir a rotação 3D.
1. Salve a apresentação.

O código JavaScript a seguir demonstra como aplicar efeitos de rotação 3D a uma forma:

```js
// Cria uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Salva a apresentação como um arquivo PPTX.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The 3D rotation effect](3D-rotation-effect.png)

## **Redefinir formatação**

O código Java a seguir mostra como redefinir a formatação de um slide e reverter a posição, tamanho e formatação de todas as formas com marcadores no [LayoutSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/layoutslide/) para as configurações padrão:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Redefinir cada forma no slide que possui um placeholder no layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo de apresentação?**

Somente minimamente. Imagens e mídias incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e praticamente não adicionam tamanho extra.

**Como posso detectar formas em um slide que compartilham formatação idêntica para agrupá‑las?**

Compare as propriedades principais de formatação de cada forma — configurações de preenchimento, linha e efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, simplificando a gestão de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.