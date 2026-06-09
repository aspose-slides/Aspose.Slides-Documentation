---
title: Formatar Formas do PowerPoint no Android
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/androidjava/shape-formatting/
keywords:
- formatar forma
- formatar linha
- formatar estilo de junção
- preenchimento gradiente
- preenchimento de padrão
- preenchimento de imagem
- preenchimento de textura
- preenchimento de cor sólida
- transparência da forma
- rotacionar forma
- efeito de chanfro 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint no Android usando Aspose.Slides—defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos em seus contornos. Além disso, você pode formatar as formas especificando configurações que controlam como seus interiores são preenchidos.

![formato da forma no PowerPoint](format-shape-powerpoint.png)

Aspose.Slides for Android via Java fornece interfaces e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [estilo de linha](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [estilo de traço](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha da forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código a seguir demonstra como formatar um `AutoShape` retangular:

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Defina a cor de preenchimento para a forma retangular.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Aplique formatação às linhas do retângulo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Defina a cor da linha do retângulo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Salve o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As linhas formatadas na apresentação](formatted-lines.png)

## **Formatar estilos de junção**

Aqui estão as três opções de tipo de junção:

* Arredondado
* Acanalado
* Bisel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como em um canto de forma), ele usa a configuração **Arredondado**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Acanalado**.

![O estilo de junção na apresentação](join-style-powerpoint.png)

O código Java a seguir demonstra como três retângulos (conforme mostrados na imagem acima) foram criados usando as configurações de tipo de junção Acanalado, Bisel e Arredondado:

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione três autoformas do tipo Retângulo.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Defina a cor de preenchimento para cada forma retangular.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Defina a largura da linha.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Defina a cor da linha de cada retângulo.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Defina o estilo de junção.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Adicione texto a cada retângulo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salve o arquivo PPTX no disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preenchimento gradiente**

No PowerPoint, Preenchimento Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma se funda gradualmente na outra.

Veja como aplicar um preenchimento gradiente a uma forma usando o Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção de paradas de gradiente exposta pela interface [IGradientFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/igradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma do tipo Elipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplique formatação de gradiente à elipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Defina a direção do gradiente.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Adicione duas paradas de gradiente.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Salve o arquivo PPTX no disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A elipse com preenchimento gradiente](gradient-fill.png)

## **Preenchimento de padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, cruzamentos ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides oferece mais de 45 estilos de padrão pré‑definidos que você pode aplicar às formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão pré‑definido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando o Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão dentre as opções pré‑definidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/patternformat/#getBackColor--) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/patternformat/#getForeColor--) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Defina o tipo de preenchimento como Padrão.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Defina o estilo do padrão.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Defina as cores de fundo e de primeiro plano do padrão.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Salve o arquivo PPTX no disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O retângulo com preenchimento de padrão](pattern-fill.png)

## **Preenchimento com imagem**

No PowerPoint, Preenchimento com Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — usando efetivamente a imagem como fundo da forma.

Veja como usar o Aspose.Slides para aplicar um preenchimento com imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento de imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ippimage/) a partir da imagem que deseja usar.
1. Passe a imagem ao método `ISlidesPicture.setImage`.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que tenhamos um arquivo "lotus.png" com a imagem a seguir:

![A imagem lotus](lotus.png)

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Defina o tipo de preenchimento como Imagem.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Defina o modo de preenchimento da imagem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Carregue uma imagem e adicione-a aos recursos da apresentação.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Defina a imagem.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salve o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma com preenchimento de imagem](picture-fill.png)

### **Azulejar imagem como textura**

Se você quiser definir uma imagem em ladrilhos como textura e personalizar o comportamento de ladrilhamento, pode usar os seguintes métodos da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Define o modo de preenchimento de imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Especifica o alinhamento dos ladrilhos dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controla se o ladrilho é invertido horizontalmente, verticalmente ou ambos.
- [setTileOffsetX](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Define o deslocamento horizontal do ladrilho (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Define o deslocamento vertical do ladrilho (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Define a escala horizontal do ladrilho como porcentagem.
- [setTileScaleY](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Define a escala vertical do ladrilho como porcentagem.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma de retângulo.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Defina o tipo de preenchimento da forma como Imagem.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Carregue a imagem e adicione-a aos recursos da apresentação.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Atribua a imagem à forma.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configure o modo de preenchimento da imagem e as propriedades de ladrilhamento.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Salve o arquivo PPTX no disco.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![As opções de ladrilho](tile-options.png)

## **Preenchimento de cor sólida**

No PowerPoint, Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando o Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) da forma como `Solid`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Defina o tipo de preenchimento como Sólido.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Defina a cor de preenchimento.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Salve o arquivo PPTX no disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma com preenchimento de cor sólida](solid-color-fill.png)

## **Definir transparência**

No PowerPoint, ao aplicar um preenchimento de cor sólida, gradiente, imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes sejam parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) como `Solid`.
1. Use `Color` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma de retângulo sólido.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adicione uma autoforma de retângulo transparente sobre a forma sólida.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Salve o arquivo PPTX no disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A forma transparente](shape-transparency.png)

## **Rotacionar formas**

Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com necessidades específicas de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Defina a propriedade de rotação da forma para o ângulo desejado.
1. Salve a apresentação.

```java
// Instancie a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obtenha o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Gire a forma em 5 graus.
    shape.setRotation(5);

    // Salve o arquivo PPTX no disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![A rotação da forma](shape-rotation.png)

## **Adicionar efeitos de chanfro 3D**

Aspose.Slides permite aplicar efeitos de chanfro 3D a formas configurando as propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/threedformat/).

Para adicionar efeitos de chanfro 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/threedformat/) da forma para definir as configurações de chanfro.
1. Salve a apresentação.

```java
// Crie uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicione uma forma ao slide.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Defina as propriedades ThreeDFormat da forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Salve a apresentação como um arquivo PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O efeito de chanfro 3D](3D-bevel-effect.png)

## **Adicionar efeitos de rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando as propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iautoshape/) ao slide.
1. Use [setCameraType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/icamera/#setCameraType-int-) e [setLightType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) para definir a rotação 3D.
1. Salve a apresentação.

```java
// Crie uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Salve a apresentação como um arquivo PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![O efeito de rotação 3D](3D-rotation-effect.png)

## **Redefinir formatação**

O código Java a seguir mostra como redefinir a formatação de um slide e restaurar a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/layoutslide/) para suas configurações padrão:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Redefina cada forma no slide que possui um marcador de posição no layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**A formatação de forma afeta o tamanho final do arquivo da apresentação?**

Apenas de forma mínima. Imagens e mídia incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e quase não adicionam tamanho extra.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as propriedades de formatação principais de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, considere seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilizar em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas necessárias e reaplique sua formatação onde for preciso.