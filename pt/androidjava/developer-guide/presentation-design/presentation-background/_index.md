---
title: Gerenciar fundos de apresentação no Android
linktitle: Fundo do Slide
type: docs
weight: 20
url: /pt/androidjava/presentation-background/
keywords:
- fundo de apresentação
- fundo do slide
- cor sólida
- cor em gradiente
- fundo de imagem
- transparência do fundo
- propriedades do fundo
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda como definir fundos dinâmicos em arquivos PowerPoint e OpenDocument usando Aspose.Slides para Android via Java, com dicas de código para melhorar suas apresentações."
---
## **Introdução**

Cores sólidas, gradientes e imagens são comumente usados como fundos de slides. Você pode definir o fundo para um **slide normal** (um slide único) ou um **slide mestre** (aplicado a vários slides de uma vez).

![Fundo do PowerPoint](powerpoint-background.png)

## **Definir um Fundo de Cor Sólida para um Slide Normal**

Aspose.Slides permite definir uma cor sólida como fundo para um slide específico em uma apresentação — mesmo que a apresentação use um slide mestre. A alteração se aplica somente ao slide selecionado.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) do fundo do slide como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) em [FillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo Java a seguir mostra como definir uma cor sólida azul como fundo para um slide normal:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crie uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Defina a cor de fundo do slide para azul.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    // Salve a apresentação no disco.
    presentation.save("SolidColorBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir um Fundo de Cor Sólida para um Slide Mestre**

Aspose.Slides permite definir uma cor sólida como fundo para o slide mestre em uma apresentação. O slide mestre funciona como um modelo que controla a formatação de todos os slides, portanto, ao escolher uma cor sólida para o fundo do slide mestre, ela será aplicada a todos os slides.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/backgroundtype/) do slide mestre (via `getMasters`) como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) do fundo do slide mestre como `Solid`.
4. Use o método [getSolidFillColor](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/#getSolidFillColor--) para especificar a cor de fundo sólida.
5. Salve a apresentação modificada.

O exemplo Java a seguir mostra como definir uma cor sólida (verde) como fundo para um slide mestre:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crie uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

    // Defina a cor de fundo do slide mestre para verde.
    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    // Salve a apresentação no disco.
    presentation.save("MasterSlideBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir um Fundo em Gradiente para um Slide**

Um gradiente é um efeito gráfico criado por uma mudança gradual de cor. Quando usado como fundo de slide, gradientes podem tornar as apresentações mais artísticas e profissionais. Aspose.Slides permite definir uma cor em gradiente como fundo para slides.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) do fundo do slide como `Gradient`.
4. Use o método [getGradientFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/#getGradientFormat--) em [FillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/) para configurar as opções de gradiente desejadas.
5. Salve a apresentação modificada.

O exemplo Java a seguir mostra como definir uma cor em gradiente como fundo para um slide:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Crie uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    // Aplique um efeito de gradiente ao fundo.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Gradient);

    IGradientFormat gradientFormat = slide.getBackground().getFillFormat().getGradientFormat();
    gradientFormat.setTileFlip(TileFlip.FlipBoth);

    // Adicione as cores do gradiente. Sem paradas de gradiente, o fundo volta para uma rampa padrão preto-para-branco.
    gradientFormat.getGradientStops().add(0f, Color.CYAN);
    gradientFormat.getGradientStops().add(1f, Color.BLUE);

    // Salve a apresentação no disco.
    presentation.save("GradientBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir uma Imagem como Fundo de Slide**

Além de preenchimentos sólidos e em gradiente, Aspose.Slides permite usar imagens como fundos de slide.

1. Crie uma instância da [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) class.
2. Defina o [BackgroundType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/backgroundtype/) do slide como `OwnBackground`.
3. Defina o [FillType](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/filltype/) do fundo do slide como `Picture`.
4. Carregue a imagem que deseja usar como fundo do slide.
5. Adicione a imagem à coleção de imagens da apresentação.
6. Use o método [getPictureFillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/#getPictureFillFormat--) em [FillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/fillformat/) para atribuir a imagem como fundo.
7. Salve a apresentação modificada.

O exemplo Java a seguir mostra como definir uma imagem como fundo para um slide:

```java
import com.aspose.slides.*;

// Crie uma instância da classe Presentation.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Defina as propriedades da imagem de fundo.
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Picture);
    slide.getBackground().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
    
    // Carregue a imagem.
    IImage image = Images.fromFile("Tulips.jpg");
    // Adicione a imagem à coleção de imagens da apresentação.
    IPPImage ppImage = presentation.getImages().addImage(image);
    image.dispose();

    slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().setImage(ppImage);
    
    // Salve a apresentação no disco.
    presentation.save("ImageAsBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

O exemplo de código a seguir mostra como definir o tipo de preenchimento de fundo como imagem em ladrilho e modificar as propriedades de ladrilhamento:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IBackground background = firstSlide.getBackground();

    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Picture);

    IImage newImage = Images.fromFile("image.png");
    IPPImage ppImage = presentation.getImages().addImage(newImage);
    newImage.dispose();

    // Defina a imagem usada para o preenchimento do fundo.
    IPictureFillFormat backPictureFillFormat = background.getFillFormat().getPictureFillFormat();
    backPictureFillFormat.getPicture().setImage(ppImage);

    // Defina o modo de preenchimento da imagem para Ladrilho e ajuste as propriedades de ladrilhamento.
    backPictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    backPictureFillFormat.setTileOffsetX(15f);
    backPictureFillFormat.setTileOffsetY(15f);
    backPictureFillFormat.setTileScaleX(46f);
    backPictureFillFormat.setTileScaleY(87f);
    backPictureFillFormat.setTileAlignment(RectangleAlignment.Center);
    backPictureFillFormat.setTileFlip(TileFlip.FlipY);

    presentation.save("TileBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}

Leia mais:[**Imagem em Ladrilho como Textura**](/slides/pt/androidjava/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Alterar a Transparência da Imagem de Plano de Fundo**

Você pode desejar ajustar a transparência da imagem de fundo de um slide para que o conteúdo do slide se destaque. O código Java a seguir mostra como alterar a transparência da imagem de fundo de um slide:

```java
import com.aspose.slides.*;

int transparencyValue = 30; // Por exemplo.

Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Obtenha a coleção de operações de transformação de imagem.
    IImageTransformOperationCollection imageTransform = slide.getBackground().getFillFormat().getPictureFillFormat().getPicture().getImageTransform();

    // Encontre um efeito de transparência fixo por percentual existente.
    IAlphaModulateFixed transparencyOperation = null;
    for (IImageTransformOperation operation : imageTransform) {
        if (operation instanceof IAlphaModulateFixed) {
            transparencyOperation = (IAlphaModulateFixed)operation;
            break;
        }
    }

    // Defina o novo valor de transparência.
    if (transparencyOperation == null) {
        imageTransform.addAlphaModulateFixedEffect(100 - transparencyValue);
    }
    else {
        transparencyOperation.setAmount(100 - transparencyValue);
    }

    presentation.save("TransparentBackground.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Obter o Valor de Plano de Fundo do Slide**

Aspose.Slides fornece a interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibackgroundeffectivedata/) para recuperar os valores efetivos de fundo de um slide. Essa interface expõe o [FillFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getFillFormat--) e o [EffectFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibackgroundeffectivedata/#getEffectFormat--) efetivos.

Usando o método `getBackground` da classe [BaseSlide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/baseslide/), você pode obter o fundo efetivo de um slide.

O exemplo Java a seguir mostra como obter o valor efetivo de fundo de um slide:

```java
import com.aspose.slides.*;

// Crie uma instância da classe Presentation.
Presentation presentation = new Presentation("Sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Recupere o fundo efetivo, levando em conta mestre, layout e tema.
    IBackgroundEffectiveData effBackground = slide.getBackground().getEffective();
    
    if (effBackground.getFillFormat().getFillType() == FillType.Solid)
        System.out.println("Fill color: " + effBackground.getFillFormat().getSolidFillColor());
    else
        System.out.println("Fill type: " + effBackground.getFillFormat().getFillType());
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Posso redefinir um fundo personalizado e restaurar o fundo do tema/layout?

Sim. Remova o preenchimento personalizado do slide e o fundo será herdado novamente do slide de [layout](/slides/pt/androidjava/slide-layout/)/[mestre](/slides/pt/androidjava/slide-master/) correspondente (ou seja, do [fundo do tema](/slides/pt/androidjava/presentation-theme/)).

### O que acontece com o fundo se eu mudar o tema da apresentação mais tarde?

Se um slide tem seu próprio preenchimento, ele permanecerá inalterado. Se o fundo for herdado do [layout](/slides/pt/androidjava/slide-layout/)/[mestre](/slides/pt/androidjava/slide-master/), ele será atualizado para coincidir com o [novo tema](/slides/pt/androidjava/presentation-theme/).