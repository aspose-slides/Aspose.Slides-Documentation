---
title: Formatar Formas do PowerPoint em PHP
linktitle: Formatação de Formas
type: docs
weight: 20
url: /pt/php-java/shape-formatting/
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
- girar forma
- efeito de bisel 3D
- efeito de rotação 3D
- redefinir formatação
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a formatar formas do PowerPoint em PHP usando Aspose.Slides—defina estilos de preenchimento, linha e efeito para arquivos PPT, PPTX e ODP com precisão e controle total."
---
## **Introdução**

No PowerPoint, você pode adicionar formas aos slides. Como as formas são compostas por linhas, você pode formatá-las modificando ou aplicando efeitos em seus contornos. Além disso, você pode formatar as formas especificando configurações que controlam como seus interiores são preenchidos.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for PHP via Java fornece classes e métodos que permitem formatar formas usando as mesmas opções disponíveis no PowerPoint.

## **Formatar Linhas**

Usando Aspose.Slides, você pode especificar um estilo de linha personalizado para uma forma. As etapas a seguir descrevem o procedimento:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Defina o [line style](https://reference.aspose.com/slides/pt/php-java/aspose.slides/linestyle/) da forma.
1. Defina a largura da linha.
1. Defina o [dash style](https://reference.aspose.com/slides/pt/php-java/aspose.slides/linedashstyle/) da linha.
1. Defina a cor da linha para a forma.
1. Salve a apresentação modificada como um arquivo PPTX.

O código PHP a seguir demonstra como formatar um `AutoShape` retangular:

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Define a cor de preenchimento para a forma retangular.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Aplica formatação às linhas do retângulo.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Define a cor da linha do retângulo.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Salva o arquivo PPTX no disco.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The formatted lines in the presentation](formatted-lines.png)

## **Formatar Estilos de Junção**

Aqui estão as três opções de tipo de junção:

* Arredondado
* Bisel
* Chanfro

Por padrão, quando o PowerPoint une duas linhas em um ângulo (como no canto de uma forma), ele usa a configuração **Round**. No entanto, se você estiver desenhando uma forma com ângulos agudos, pode preferir a opção **Miter**.

![The join style in the presentation](join-style-powerpoint.png)

O código PHP a seguir demonstra como três retângulos (conforme mostrado na imagem acima) foram criados usando as configurações de tipo de junção Miter, Bevel e Round:

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona três formas automáticas do tipo Retângulo.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Define a cor de preenchimento para cada forma retangular.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Define a largura da linha.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Define a cor da linha de cada retângulo.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Define o estilo de junção.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Adiciona texto a cada retângulo.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Salva o arquivo PPTX no disco.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preenchimento Gradiente**

No PowerPoint, Preenchimento Gradiente é uma opção de formatação que permite aplicar uma mescla contínua de cores a uma forma. Por exemplo, você pode aplicar duas ou mais cores de modo que uma se funde gradualmente na outra.

O modo de aplicar um preenchimento gradiente a uma forma usando Aspose.Slides é o seguinte:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) da forma como `Gradient`.
1. Adicione suas duas cores preferidas com posições definidas usando os métodos `add` da coleção de paradas de gradiente exposta pela classe [GradientFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/gradientformat/).
1. Salve a apresentação modificada como um arquivo PPTX.

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática do tipo Elipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Aplica formatação de gradiente à elipse.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Define a direção do gradiente.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Adiciona duas paradas de gradiente.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Salva o arquivo PPTX no disco.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The ellipse with gradient fill](gradient-fill.png)

## **Preenchimento de Padrão**

No PowerPoint, Preenchimento de Padrão é uma opção de formatação que permite aplicar um design de duas cores — como pontos, listras, traços cruzados ou quadriculados — a uma forma. Você pode escolher cores personalizadas para o primeiro plano e fundo do padrão.

O Aspose.Slides oferece mais de 45 estilos de padrão predefinidos que você pode aplicar às formas para melhorar o apelo visual de suas apresentações. Mesmo após selecionar um padrão predefinido, ainda é possível especificar as cores exatas que ele deve usar.

Veja como aplicar um preenchimento de padrão a uma forma usando Aspose.Slides:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) da forma como `Pattern`.
1. Escolha um estilo de padrão nas opções predefinidas.
1. Defina a [Background Color](https://reference.aspose.com/slides/pt/php-java/aspose.slides/patternformat/#getBackColor) do padrão.
1. Defina a [Foreground Color](https://reference.aspose.com/slides/pt/php-java/aspose.slides/patternformat/#getForeColor) do padrão.
1. Salve a apresentação modificada como um arquivo PPTX.

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Define o tipo de preenchimento como Padrão.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Define o estilo do padrão.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Define as cores de fundo e de primeiro plano do padrão.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Salva o arquivo PPTX no disco.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The rectangle with pattern fill](pattern-fill.png)

## **Preenchimento de Imagem**

No PowerPoint, Preenchimento de Imagem é uma opção de formatação que permite inserir uma imagem dentro de uma forma — usando efetivamente a imagem como fundo da forma.

Eis como usar o Aspose.Slides para aplicar um preenchimento de imagem a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) da forma como `Picture`.
1. Defina o modo de preenchimento da imagem como `Tile` (ou outro modo preferido).
1. Crie um objeto [PPImage] a partir da imagem que você deseja usar.
1. Passe a imagem para o método `SlidesPicture.setImage`.
1. Salve a apresentação modificada como um arquivo PPTX.

![The lotus picture](lotus.png)

O código PHP a seguir demonstra como preencher uma forma com a imagem:

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Define o tipo de preenchimento como Imagem.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Define o modo de preenchimento da imagem.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Carrega uma imagem e a adiciona aos recursos da apresentação.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Define a imagem.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Salva o arquivo PPTX no disco.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The shape with picture fill](picture-fill.png)

### **Imagem em Tile como Textura**

Se você deseja definir uma imagem em mosaico como textura e personalizar o comportamento do mosaico, pode usar os seguintes métodos da classe [PictureFillFormat]:

- [setPictureFillMode](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Define o modo de preenchimento da imagem — `Tile` ou `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#setTileAlignment): Especifica o alinhamento dos tiles dentro da forma.
- [setTileFlip](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#setTileFlip): Controla se o tile é invertido horizontalmente, verticalmente ou ambos.
- [setTileOffsetX](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Define o deslocamento horizontal do tile (em pontos) a partir da origem da forma.
- [setTileOffsetY](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Define o deslocamento vertical do tile (em pontos) a partir da origem da forma.
- [setTileScaleX](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#setTileScaleX): Define a escala horizontal do tile como percentual.
- [setTileScaleY](https://reference.aspose.com/slides/pt/php-java/aspose.slides/picturefillformat/#setTileScaleY): Define a escala vertical do tile como percentual.

O exemplo de código a seguir mostra como adicionar uma forma retangular com preenchimento de imagem em tile e configurar as opções de tile:

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática retangular.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Define o tipo de preenchimento da forma como Imagem.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Carrega a imagem e a adiciona aos recursos da apresentação.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Atribui a imagem à forma.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Configura o modo de preenchimento da imagem e as propriedades de ladrilhamento.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Salva o arquivo PPTX no disco.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The tile options](tile-options.png)

## **Preenchimento de Cor Sólida**

No PowerPoint, Preenchimento de Cor Sólida é uma opção de formatação que preenche uma forma com uma única cor uniforme. Essa cor de fundo simples é aplicada sem gradientes, texturas ou padrões.

Para aplicar um preenchimento de cor sólida a uma forma usando Aspose.Slides, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) da forma como `Solid`.
1. Atribua a cor de preenchimento desejada à forma.
1. Salve a apresentação modificada como um arquivo PPTX.

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Define o tipo de preenchimento como Sólido.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Define a cor de preenchimento.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Salva o arquivo PPTX no disco.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The shape with solid color fill](solid-color-fill.png)

## **Definir Transparência**

No PowerPoint, ao aplicar um preenchimento sólido, gradiente, imagem ou textura a formas, você também pode definir um nível de transparência para controlar a opacidade do preenchimento. Um valor de transparência mais alto torna a forma mais translúcida, permitindo que o fundo ou objetos subjacentes sejam parcialmente visíveis.

O Aspose.Slides permite definir o nível de transparência ajustando o valor alfa na cor usada para o preenchimento. Veja como fazer isso:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) como `Solid`.
1. Use `Color` para definir uma cor com transparência (o componente `alpha` controla a transparência).
1. Salve a apresentação.

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática retangular sólida.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Adiciona uma forma automática retangular transparente sobre a forma sólida.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Salva o arquivo PPTX no disco.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The transparent shape](shape-transparency.png)

## **Rotacionar Formas**

O Aspose.Slides permite rotacionar formas em apresentações do PowerPoint. Isso pode ser útil ao posicionar elementos visuais com requisitos específicos de alinhamento ou design.

Para rotacionar uma forma em um slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Defina a propriedade de rotação da forma para o ângulo desejado.
1. Salve a apresentação.

```php
// Instancie a classe Presentation que representa um arquivo de apresentação.
$presentation = new Presentation();
try {
    // Obtém o primeiro slide.
    $slide = $presentation->getSlides()->get_Item(0);

    // Adiciona uma forma automática do tipo Retângulo.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Rotaciona a forma em 5 graus.
    $shape->setRotation(5);

    // Salva o arquivo PPTX no disco.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The shape rotation](shape-rotation.png)

## **Adicionar Efeitos de Bisel 3D**

O Aspose.Slides permite aplicar efeitos de bisel 3D a formas configurando suas propriedades [ThreeDFormat].

Para adicionar efeitos de bisel 3D a uma forma, siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Configure o [ThreeDFormat] da forma para definir as configurações de bisel.
1. Salve a apresentação.

```php
// Crie uma instância da classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Adicione uma forma ao slide.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Defina as propriedades ThreeDFormat da forma.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Salve a apresentação como um arquivo PPTX.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The 3D bevel effect](3D-bevel-effect.png)

## **Adicionar Efeitos de Rotação 3D**

O Aspose.Slides permite aplicar efeitos de rotação 3D a formas configurando suas propriedades [ThreeDFormat].

Para aplicar rotação 3D a uma forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/).
1. Obtenha uma referência a um slide pelo seu índice.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) ao slide.
1. Use [setCameraType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/camera/#setCameraType) e [setLightType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/lightrig/#setLightType) para definir a rotação 3D.
1. Salve a apresentação.

```php
// Crie uma instância da classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Salve a apresentação como um arquivo PPTX.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O resultado:

![The 3D rotation effect](3D-rotation-effect.png)

## **Redefinir Formatação**

O código Java a seguir mostra como redefinir a formatação de um slide e reverter a posição, tamanho e formatação de todas as formas com espaços reservados no [LayoutSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/layoutslide/) para suas configurações padrão:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Redefinir cada forma no slide que possui um placeholder no layout.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**A formatação de formas afeta o tamanho final do arquivo da apresentação?**

Somente minimamente. Imagens e mídias incorporadas ocupam a maior parte do espaço do arquivo, enquanto parâmetros de forma como cores, efeitos e gradientes são armazenados como metadados e praticamente não aumentam o tamanho.

**Como posso detectar formas em um slide que compartilham formatação idêntica para que eu possa agrupá‑las?**

Compare as propriedades de formatação principais de cada forma — preenchimento, linha e configurações de efeito. Se todos os valores correspondentes coincidirem, considere seus estilos como idênticos e agrupe logicamente essas formas, o que simplifica o gerenciamento posterior de estilos.

**Posso salvar um conjunto de estilos de forma personalizados em um arquivo separado para reutilização em outras apresentações?**

Sim. Armazene formas de exemplo com os estilos desejados em um modelo de conjunto de slides ou em um arquivo de modelo .POTX. Ao criar uma nova apresentação, abra o modelo, clone as formas estilizadas que precisar e reaplique sua formatação onde for necessário.