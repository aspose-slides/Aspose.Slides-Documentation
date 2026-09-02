---
title: Formatar Formas do PowerPoint em Java
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/java/shape-formatting/
keywords:
- formatar forma
- formatar linha
- efeito de esboço
- linha de forma esboçada
- formatar estilo de junção
- preenchimento em degradê
- preenchimento com padrão
- preenchimento com imagem
- preenchimento com textura
- preenchimento com cor sólida
- transparência da forma
- renderização de forma em preto e branco
- renderização de forma em escala de cinza
- rotacionar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como formatar formas do PowerPoint em Java usando Aspose.Slides — defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá‑las modificando ou aplicando efeitos aos seus contornos. Além disso, pode formatar as formas especificando configurações que controlam como os interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java fornece interfaces e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/pt/java/com.aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/pt/java/com.aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código a seguir demonstra como formatar um `AutoShape` retangular:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Definir a cor de preenchimento para a forma retângulo.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Aplicar formatação às linhas do retângulo.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Definir a cor para a linha do retângulo.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Salvar o arquivo PPTX no disco.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The formatted lines in the presentation](formatted-lines.png)

## **Aplicar Efeitos de Esboço às Linhas da Forma**

Um efeito de esboço faz com que a linha da forma pareça desenhada à mão. Use [IShape.getLineFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/) para acessar as configurações da linha, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilineformat/) para acessar as configurações de esboço e [ISketchFormat.setSketchType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isketchformat/) para selecionar um valor da enumeração [LineSketchType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/linesketchtype/).

O código Java a seguir mostra como aplicar o efeito [LineSketchType.Curved](https://reference.aspose.com/slides/pt/java/com.aspose.slides/linesketchtype/), ler o valor atribuído explicitamente e remover o efeito com [LineSketchType.None](https://reference.aspose.com/slides/pt/java/com.aspose.slides/linesketchtype/):

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Acessar o formato de linha da forma e seu formato de esboço.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Aplicar um efeito de esboço.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Ler o efeito de esboço atribuído diretamente à forma.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Remover o efeito de esboço.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

O valor devolvido por [ISketchFormat.getSketchType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isketchformat/) representa a configuração atribuída diretamente à forma. Se a formatação da linha puder ser herdada de um tema, slide mestre ou slide de layout, use [ILineFormat.getEffective](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilineformat/), acesse [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilineformateffectivedata/) e leia [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/isketchformateffectivedata/). O valor efetivo reflete a formatação realmente aplicada após a resolução da herança:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Round
* Miter
* Bevel

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Round**. Contudo, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

O código Java a seguir demonstra como três retângulos (conforme a imagem acima) foram criados usando as configurações de tipo de junção Miter, Bevel e Round:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar três autoformas do tipo Retângulo.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Definir a cor de preenchimento para cada forma retângulo.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Definir a largura da linha.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Definir a cor para a linha de cada retângulo.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Definir o estilo de junção.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Adicionar texto a cada retângulo.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Salvar o arquivo PPTX no disco.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Preenchimento em Degradê**

No PowerPoint, Preenchimento em Degradê é uma opção de formatação que permite aplicar uma transição contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma se dissolva gradualmente na outra.

Veja como aplicar um preenchimento em degradê a uma forma usando Aspose.Slides:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção de parada de degradê exposta pela interface [IGradientFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/igradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

O código Java a seguir demonstra como aplicar um efeito de preenchimento em degradê a uma elipse:

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma do tipo Ellipse.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Aplicar formatação de degradê à elipse.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Definir a direção do degradê.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Adicionar duas paradas de degradê.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Salvar o arquivo PPTX no disco.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The ellipse with gradient fill](gradient-fill.png)

## **Preenchimento com Padrão**

No PowerPoint, Preenchimento com Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, tramas ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e o plano de fundo do padrão.

Aspose.Slides oferece mais de 45 estilos de padrão predefinidos que podem ser aplicados às formas para melhorar o apelo visual das apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento com padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão entre as opções predefinidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/pt/java/com.aspose.slides/patternformat/#getBackColor--) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/java/com.aspose.slides/patternformat/#getForeColor--) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

O código Java a seguir demonstra como aplicar um preenchimento com padrão a um retângulo:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Definir o tipo de preenchimento como Padrão.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Definir o estilo de padrão.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Definir as cores de fundo e de primeiro plano do padrão.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Salvar o arquivo PPTX no disco.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The rectangle with pattern fill](pattern-fill.png)

## **Preenchimento com Imagem**

No PowerPoint, Preenchimento com Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — efetivamente usando a imagem como plano de fundo da forma.

Veja como usar Aspose.Slides para aplicar um preenchimento com imagem a uma forma:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento da imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [IPPImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ippimage/) a partir da imagem que deseja usar.
1. Passe a imagem para o método `ISlidesPicture.setImage`.
1. Salve a apresentação modificada como um arquivo PPTX.

Suponha que temos um arquivo "lotus.png" com a imagem a seguir:

![The lotus picture](lotus.png)

O código Java a seguir demonstra como preencher uma forma com a imagem:

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Definir o tipo de preenchimento como Imagem.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Definir o modo de preenchimento da imagem.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Carregar uma imagem e adicioná‑la aos recursos da apresentação.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Definir a imagem.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Salvar o arquivo PPTX no disco.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The shape with picture fill](picture-fill.png)

### **Imagem em Tile como Textura**

Se desejar definir uma imagem em “tile” como textura e personalizar o comportamento de ladrilhamento, use os seguintes métodos da interface [IPictureFillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/) e da classe [PictureFillFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Especifica o alinhamento dos tiles dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Controla se o tile é espelhado horizontalmente, verticalmente ou em ambas as direções.
- [setTileOffsetX](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Define o deslocamento horizontal do tile (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Define o deslocamento vertical do tile (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Define a escala horizontal do tile como percentual.
- [setTileScaleY](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Define a escala vertical do tile como percentual.

O exemplo de código a seguir mostra como adicionar uma forma retangular com preenchimento de imagem em tile e configurar as opções de tile:

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma de retângulo.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Definir o tipo de preenchimento da forma como Imagem.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Carregar a imagem e adicioná‑la aos recursos da apresentação.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Atribuir a imagem à forma.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Configurar o modo de preenchimento da imagem e as propriedades de ladrilhamento.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Salvar o arquivo PPTX no disco.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The tile options](tile-options.png)

## **Preenchimento com Cor Sólida**

No PowerPoint, Preenchimento com Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem degradês, texturas ou padrões.

Para aplicar um preenchimento com cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/filltype/) da forma como `Solid`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código Java a seguir demonstra como aplicar um preenchimento com cor sólida a um retângulo em um slide do PowerPoint:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Definir o tipo de preenchimento como Sólido.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Definir a cor de preenchimento.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Salvar o arquivo PPTX no disco.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The shape with solid color fill](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, degradê, imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência maior deixa a forma mais translúcida, permitindo que o fundo ou objetos subjacentes fiquem parcialmente visíveis.

Aspose.Slides permite definir o nível de transparência ajustando o valor alfa da cor usada no preenchimento. Veja como fazer isso:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/filltype/) como `Solid`.
1. Use `Color` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

O código Java a seguir demonstra como aplicar uma cor de preenchimento transparente a um retângulo:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma retangular sólida.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adicionar uma autoforma retangular transparente sobre a forma sólida.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Salvar o arquivo PPTX no disco.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The transparent shape](shape-transparency.png)

## **Rotacionar Formas**

Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com requisitos específicos de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Defina a propriedade de rotação da forma para o ângulo desejado.
1. Salve a apresentação.

O código Java a seguir demonstra como rotacionar uma forma em 5 graus:

```java
import com.aspose.slides.*;

// Instanciar a classe Presentation que representa um arquivo de apresentação.
Presentation presentation = new Presentation();
try {
    // Obter o primeiro slide.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma autoforma do tipo Retângulo.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotacionar a forma em 5 graus.
    shape.setRotation(5);

    // Salvar o arquivo PPTX no disco.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The shape rotation](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/threedformat/).

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Configure o [ThreeDFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/threedformat/) da forma para definir as configurações de bisel.
1. Salve a apresentação.

O código Java a seguir mostra como aplicar efeitos de bisel 3D a uma forma:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Criar uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adicionar uma forma ao slide.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Definir as propriedades ThreeDFormat da forma.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Salvar a apresentação como um arquivo PPTX.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The 3D bevel effect](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat](https://reference.aspose.com/slides/pt/java/com.aspose.slides/threedformat/).

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) class.
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [IAutoShape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iautoshape/) ao slide.
1. Use [setCameraType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/icamera/#setCameraType-int-) e [setLightType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ilightrig/#setLightType-int-) para definir a rotação 3D.
1. Salve a apresentação.

O código Java a seguir demonstra como aplicar efeitos de rotação 3D a uma forma:

```java
import com.aspose.slides.*;

// Criar uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Salvar a apresentação como um arquivo PPTX.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O resultado:

![The 3D rotation effect](3D-rotation-effect.png)

## **Controlar Renderização em Preto‑e‑Branco para Formas**

O método [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) especifica como uma forma individual é renderizada quando uma apresentação é visualizada ou processada em modo preto‑e‑branco. Ele não habilita a exibição em preto‑e‑branco por si só e não altera o preenchimento, a linha ou outras formatações da forma no modo de cor normal.

Use um valor da classe [BlackWhiteMode](https://reference.aspose.com/slides/pt/java/com.aspose.slides/blackwhitemode/) para selecionar o comportamento desejado. Por exemplo, `Automatic` permite que o aplicativo de renderização escolha a conversão, `Gray` e `LightGray` usam tons de cinza, `BlackWhite` usa apenas preto e branco, `Black` e `White` forçam uma única cor, `Color` preserva a coloração normal e `Hidden` omite a forma no modo preto‑e‑branco. `NotDefined` indica que nenhum modo de nível de forma foi atribuído.

O código Java a seguir cria uma forma colorida e faz com que ela apareça cinza em modo de exibição preto‑e‑branco:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Manter o preenchimento laranja no modo colorido, mas renderizar a forma com coloração cinza no modo preto-e-branco.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

No modo de cor normal, o retângulo mantém seu preenchimento laranja. Em um fluxo de trabalho de exibição preto‑e‑branco, ele usa coloração cinza porque seu modo está definido como `Gray`. Isso permite que você preserve um slide em cores completas enquanto define uma aparência distinta para impressão, visualização ou outros fluxos de trabalho que respeitam as configurações de exibição preto‑e‑branco da apresentação.

## **Redefinir Formatação**

O código Java a seguir mostra como redefinir a formatação de um slide e restaurar a posição, tamanho e formatação de todas as formas com marcadores de posição no [LayoutSlide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/layoutslide/) para suas configurações padrão:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Redefinir cada forma no slide que tem um marcador de posição no layout.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Apenas minimamente. Imagens e mídia incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e degradês são armazenados como metadados e adicionam praticamente nenhum tamanho extra.

**Como posso detectar formas em um slide que compartilham formatação idêntica para agrupá‑las?**

Compare as propriedades chave de formatação de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, trate seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento de estilos posteriormente.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um slide‑modelo ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.