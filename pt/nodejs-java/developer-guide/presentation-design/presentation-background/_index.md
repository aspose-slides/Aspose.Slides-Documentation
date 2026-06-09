---
title: Gerenciar fundos de apresentação em JavaScript
linktitle: Fundo do Slide
type: docs
weight: 20
url: /pt/nodejs-java/presentation-background/
keywords:
- fundo da apresentação
- fundo do slide
- cor sólida
- cor gradiente
- fundo de imagem
- transparência do fundo
- propriedades do fundo
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para Node.js, com dicas de código para melhorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usados como fundos de slides. Você pode definir o fundo para um **slide normal** (um slide único) ou um **slide mestre** (aplicado a vários slides de uma vez).

![Fundo do PowerPoint](powerpoint-background.png)

## **Definir um Fundo de Cor Sólida para um Slide Normal**

Aspose.Slides permite definir uma cor sólida como fundo para um slide específico em uma apresentação — mesmo que a apresentação use um slide mestre. A alteração se aplica somente ao slide selecionado.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) do fundo do slide como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) em [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/) para especificar a cor sólida de fundo.
5. Salve a apresentação modificada.

O exemplo JavaScript a seguir mostra como definir uma cor azul sólida como fundo para um slide normal:

```js
// Crie uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Defina a cor de fundo do slide para azul.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    
    // Salve a apresentação no disco.
    presentation.save("SolidColorBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir um Fundo de Cor Sólida para o Slide Mestre**

Aspose.Slides permite definir uma cor sólida como fundo para o slide mestre em uma apresentação. O slide mestre atua como um modelo que controla a formatação de todos os slides, portanto, ao escolher uma cor sólida para o fundo do slide mestre, ela será aplicada a cada slide.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/backgroundtype/) do slide mestre (via `getMasters`) como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) do fundo do slide mestre como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/#getSolidFillColor--) para especificar a cor sólida de fundo.
5. Salve a apresentação modificada.

O exemplo JavaScript a seguir mostra como definir uma cor sólida (verde) como fundo para um slide mestre:

```js
// Crie uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);

    // Defina a cor de fundo do slide Master para Verde Floresta.
    masterSlide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    masterSlide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));

    // Salve a apresentação no disco.
    presentation.save("MasterSlideBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir um Fundo com Gradiente para um Slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como fundo de slide, gradientes podem tornar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor gradiente como fundo para slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) do fundo do slide como `Gradient`.
4. Use o método [getGradientFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/#getGradientFormat) em [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/) para configurar as definições de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo JavaScript a seguir mostra como definir uma cor gradiente como fundo para um slide:

```js
// Crie uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Aplique um efeito de gradiente ao fundo.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    slide.getBackground().getFillFormat().getGradientFormat().setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Salve a apresentação no disco.
    presentation.save("GradientBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir uma Imagem como Fundo de um Slide**

Além de preenchimentos sólidos e gradientes, Aspose.Slides permite usar imagens como fundos de slides.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/filltype/) do fundo do slide como `Picture`.
4. Carregue a imagem que deseja usar como fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use o método [getPictureFillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/#getPictureFillFormat) em [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/) para atribuir a imagem como fundo.
7. Salve a apresentação modificada.

O exemplo JavaScript a seguir mostra como definir uma imagem como fundo para um slide:

```js
// Crie uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Defina as propriedades da imagem de fundo.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    // Carregue a imagem.
    let image = aspose.slides.Images.fromFile("Tulips.jpg");
    // Adicione a imagem à coleção de imagens da apresentação.
    let ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Salve a apresentação no disco.
    presentation.save("ImageAsBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O exemplo de código a seguir mostra como definir o tipo de preenchimento de fundo como uma imagem em mosaico e modificar as propriedades de ladrilhamento:

```js
let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let background = firstSlide.getBackground();

    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let newImage = aspose.slides.Images.fromFile("image.png");
    let ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Defina a imagem usada para o preenchimento de fundo.
    let backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Defina o modo de preenchimento da imagem como Tile e ajuste as propriedades do ladrilho.
    backPictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15.0);
    backPictureFillFormat.setTileOffsetY(15.0);
    backPictureFillFormat.setTileScaleX(46.0);
    backPictureFillFormat.setTileScaleY(87.0);
    backPictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.Center));
    backPictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipY);

    presentation.save("TileBackground.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
Leia mais: [**Tile Picture As Texture**](/slides/pt/nodejs-java/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Alterar a Transparência da Imagem de Fundo**

Pode ser que você queira ajustar a transparência da imagem de fundo de um slide para que o conteúdo do slide se destaque. O código JavaScript a seguir mostra como alterar a transparência da imagem de fundo de um slide:

```js
var transparencyValue = 30; // Por exemplo.

// Obtenha a coleção de operações de transformação da imagem.
var imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

// Encontre um efeito de transparência fixo percentual existente.
var transparencyOperation = null;
for (let i = 0; i < imageTransform.size(); i++) {
    let operation = imageTransform.get_Item(i);
    if (java.instanceOf(operation, "com.aspose.slides.AlphaModulateFixed")) {
        transparencyOperation = operation;
        break;
    }
}

// Defina o novo valor de transparência.
if (transparencyOperation == null) {
    imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
} else {
    transparencyOperation.setAmount(100 - transparencyValue);
}
```

## **Obter o Valor de Fundo do Slide**

Aspose.Slides fornece a classe `BackgroundEffectiveData` para obter os valores efetivos de fundo de um slide. Essa classe expõe o [FillFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/fillformat/) e o [EffectFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/effectformat/) efetivos.

Usando o método `getBackground` da classe [BaseSlide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseslide/), você pode obter o fundo efetivo de um slide.

O exemplo JavaScript a seguir mostra como obter o valor efetivo do fundo de um slide:

```js
// Crie uma instância da classe Presentation.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    // Recupere o fundo efetivo, levando em conta o mestre, layout e tema.
    let effBackground = slide.getBackground().getEffective();

    if (effBackground.getFillFormat().getFillType() == aspose.slides.FillType.Solid)
        console.log("Fill color:", effBackground.getFillFormat().getSolidFillColor().toString());
    else
        console.log("Fill type:", effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **Perguntas Frequentes**

**Posso redefinir um fundo personalizado e restaurar o fundo do tema/layout?**

Sim. Remova o preenchimento personalizado do slide, e o fundo será herdado novamente do slide de [layout](/slides/pt/nodejs-java/slide-layout/)/[master](/slides/pt/nodejs-java/slide-master/) correspondente (ou seja, o [tema de fundo](/slides/pt/nodejs-java/presentation-theme/)).

**O que acontece com o fundo se eu mudar o tema da apresentação mais tarde?**

Se um slide possui seu próprio preenchimento, ele permanecerá inalterado. Se o fundo for herdado do [layout](/slides/pt/nodejs-java/slide-layout/)/[master](/slides/pt/nodejs-java/slide-master/), ele será atualizado para corresponder ao [novo tema](/slides/pt/nodejs-java/presentation-theme/).