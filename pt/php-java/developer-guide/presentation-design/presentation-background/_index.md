---
title: Gerenciar fundos de apresentação em PHP
linktitle: Fundo do Slide
type: docs
weight: 20
url: /pt/php-java/presentation-background/
keywords:
- fundo de apresentação
- fundo de slide
- cor sólida
- cor gradiente
- fundo de imagem
- transparência do fundo
- propriedades do fundo
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para PHP via Java, com dicas de código para melhorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usados como fundos de slides. Você pode definir o fundo para um **slide normal** (um único slide) ou um **slide mestre** (aplicado a vários slides ao mesmo tempo).

![PowerPoint background](powerpoint-background.png)

## **Definir um Fundo de Cor Sólida para um Slide Normal**

Aspose.Slides permite definir uma cor sólida como fundo para um slide específico em uma apresentação — mesmo que a apresentação use um slide mestre. A alteração se aplica somente ao slide selecionado.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) do fundo do slide como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/#getSolidFillColor) em [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo PHP a seguir mostra como definir uma cor sólida azul como fundo para um slide normal:

```php
// Crie uma instância da classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Defina a cor de fundo do slide como azul.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Salve a apresentação no disco.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir um Fundo de Cor Sólida para um Slide Mestre**

Aspose.Slides permite definir uma cor sólida como fundo para o slide mestre em uma apresentação. O slide mestre atua como um modelo que controla a formatação de todos os slides, portanto, ao escolher uma cor sólida para o fundo do slide mestre, ela será aplicada a cada slide.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/backgroundtype/) do slide mestre (via `getMasters`) como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) do fundo do slide mestre como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/#getSolidFillColor) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo PHP a seguir mostra como definir uma cor sólida (verde) como fundo para um slide mestre:

```php
// Crie uma instância da classe Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Defina a cor de fundo para o slide Master como Verde Floresta.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Salve a apresentação no disco.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir um Fundo de Gradiente para um Slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como fundo de slide, gradientes podem tornar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor de gradiente como fundo para slides.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) do fundo do slide como `Gradient`.
4. Use o método [getGradientFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/#getGradientFormat) em [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/) para configurar as opções de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo PHP a seguir mostra como definir uma cor de gradiente como fundo para um slide:

```php
// Crie uma instância da classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Aplicar um efeito de gradiente ao fundo.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Salve a apresentação no disco.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir uma Imagem como Fundo de Slide**

Além de preenchimentos sólidos e de gradiente, Aspose.Slides permite usar imagens como fundos de slide.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/filltype/) do fundo do slide como `Picture`.
4. Carregue a imagem que deseja usar como fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use o método [getPictureFillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/#getPictureFillFormat) em [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/) para atribuir a imagem como fundo.
7. Salve a apresentação modificada.

O exemplo PHP a seguir mostra como definir uma imagem como fundo para um slide:

```php
// Crie uma instância da classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Defina as propriedades da imagem de fundo.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Carregue a imagem.
    $image = Images::fromFile("Tulips.jpg");
    // Adicione a imagem à coleção de imagens da apresentação.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Salve a apresentação no disco.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

O exemplo de código a seguir mostra como definir o tipo de preenchimento de fundo como imagem em mosaico e modificar as propriedades de repetição:

```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Defina a imagem usada para o preenchimento de fundo.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Defina o modo de preenchimento da imagem como Mosaico e ajuste as propriedades do mosaico.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}

Leia mais: [**Tile Picture As Texture**](/slides/pt/php-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Alterar a Transparência da Imagem de Fundo**

Você pode querer ajustar a transparência da imagem de fundo de um slide para que o conteúdo do slide se destaque. O código PHP a seguir mostra como alterar a transparência da imagem de fundo de um slide:

```php
$transparencyValue = 30; // Por exemplo.

// Obtenha a coleção de operações de transformação de imagem.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Encontre um efeito de transparência de porcentagem fixa existente.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Defina o novo valor de transparência.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```

## **Obter o Valor de Fundo do Slide**

Aspose.Slides fornece a classe `BackgroundEffectiveData` para recuperar os valores de fundo efetivos de um slide. Essa classe expõe o [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/) e o [EffectFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/effectformat/) efetivos.

Usando o método `getBackground` da classe [BaseSlide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseslide/), você pode obter o fundo efetivo de um slide.

O exemplo PHP a seguir mostra como obter o valor de fundo efetivo de um slide:

```php
// Crie uma instância da classe Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Recupere o fundo efetivo, levando em conta mestre, layout e tema.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Posso redefinir um fundo personalizado e restaurar o fundo do tema/layout?**

Sim. Remova o preenchimento personalizado do slide e o fundo será herdado novamente do slide de [layout](/slides/pt/php-java/slide-layout/)/[mestre](/slides/pt/php-java/slide-master/) correspondente (ou seja, o [fundo do tema](/slides/pt/php-java/presentation-theme/)).

**O que acontece com o fundo se eu mudar o tema da apresentação mais tarde?**

Se um slide tem seu próprio preenchimento, ele permanecerá inalterado. Se o fundo for herdado do [layout](/slides/pt/php-java/slide-layout/)/[mestre](/slides/pt/php-java/slide-master/), ele será atualizado para corresponder ao [novo tema](/slides/pt/php-java/presentation-theme/).