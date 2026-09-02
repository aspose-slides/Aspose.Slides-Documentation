---
title: Gerenciar objetos de tinta de apresentação em JavaScript
linktitle: Gerenciar tinta
type: docs
weight: 95
url: /pt/nodejs-java/manage-ink/
keywords:
- tinta
- objeto de tinta
- traço de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- exportação de tinta
- renderização de tinta
- ocultar tinta
- InkOptions
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint, edite traços e propriedades de pincel, e controle a aparência da tinta durante exportação para PDF, HTML, SVG, TIFF e imagens com Aspose.Slides para Node.js via Java."
---
## **Introdução**

O PowerPoint oferece um recurso de tinta que permite desenhar traços livres. A tinta pode ser usada para destacar outros objetos, mostrar conexões e processos e chamar a atenção para itens específicos em um slide.

O Aspose.Slides fornece os tipos necessários para trabalhar com objetos de tinta. Por exemplo, a classe [Ink](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ink/) representa um objeto de tinta em um slide.

## **Diferenças entre Objetos Regulares e Objetos de Tinta**

Os objetos em um slide do PowerPoint geralmente são representados por objetos de forma. Na sua forma mais simples, uma forma é um contêiner que define a área do próprio objeto (sua moldura) junto com propriedades como o tamanho do contêiner, o formato e o plano de fundo. Para mais informações, consulte [Shape Layout Format](https://docs.aspose.com/slides/pt/nodejs-java/shape-manipulations/#access-layout-formats-for-shape).

Entretanto, quando o PowerPoint trata um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos métodos padrão [Shape.getWidth](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getWidth--) e [Shape.getHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Tinta**

Um traço de tinta é um elemento básico usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Um traço armazena uma sequência de pontos conectados.

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades de Pincel para Desenho**

Um pincel é usado para desenhar linhas que conectam os pontos de um traço de tinta. O pincel tem sua própria cor e tamanho, representados pelos métodos [InkBrush.getColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkbrush/#getColor--) e [InkBrush.getSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkbrush/#getSize--) .

### **Definir Cor do Pincel de Tinta**

Este código JavaScript mostra como definir a cor de um pincel de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const red = java.getStaticFieldValue("java.awt.Color", "RED");
    brush.setColor(red);
} finally {
    presentation.dispose();
}
```

### **Definir Tamanho do Pincel de Tinta**

Este código JavaScript mostra como definir o tamanho de um pincel de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const ink = slide.getShapes().get_Item(0);
    const brush = ink.getTraces()[0].getBrush();
    const brushSize = java.newInstanceSync("java.awt.Dimension", 5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Em geral, a largura e a altura de um pincel não correspondem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados correspondente está esmaecida). Quando a largura e a altura do pincel correspondem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes:

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não leva em conta o tamanho dos pincéis - ele sempre assume que a espessura da linha é zero (veja a imagem anterior).

Portanto, para determinar a área visível de todo o objeto de tinta, o tamanho do pincel de seus traços deve ser considerado. Aqui, o objeto alvo (o traço de texto manuscrito) foi dimensionado ao tamanho do contêiner (moldura). Quando o tamanho do contêiner muda, o tamanho do pincel permanece constante, e vice-versa.

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint usa comportamento semelhante para objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar a Aparência da Tinta Durante Exportação e Renderização**

O Aspose.Slides fornece a classe [InkOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/) para controlar como os objetos de tinta aparecem na saída exportada ou renderizada. Você pode usar suas propriedades para ocultar completamente a tinta ou alterar como as operações de máscara de pincel de tinta são interpretadas.

As opções de tinta estão disponíveis através das opções de exportação ou renderização para vários tipos de saída:

| Saída | Propriedade de opções de tinta |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) |
| Imagem do slide | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) |

Os seguintes métodos de [InkOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/) expõem as mesmas duas configurações:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#getHideInk--) determina se os objetos de tinta são incluídos na saída. Seu valor padrão é `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) determina se uma operação de máscara é interpretada como opacidade ao renderizar um pincel de tinta. Seu valor padrão é `true`; chame [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) com `false` para usar a operação ROP em vez disso.

### **Ocultar Objetos de Tinta na Saída PDF**

Por padrão, os objetos de tinta permanecem visíveis durante a exportação. Para criar uma saída limpa sem anotações manuscritas ou outro conteúdo de tinta, chame [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) com `true`.

O exemplo JavaScript a seguir exporta uma apresentação para PDF enquanto oculta todos os objetos de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ocultar Objetos de Tinta ao Renderizar um Slide como Imagem**

Para ocultar objetos de tinta ao renderizar slides como imagens bitmap, configure [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/renderingoptions/#getInkOptions--) e passe as opções de renderização para [Slide.getImage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/slide/#getImage-aspose.slides.IRenderingOptions-).

O exemplo JavaScript a seguir renderiza o primeiro slide como uma imagem PNG sem objetos de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const renderingOptions = new aspose.slides.RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    const slide = presentation.getSlides().get_Item(0);
    const image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Controlar Renderização da Máscara de Tinta**

A configuração [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity--) controla como as operações de máscara são interpretadas ao renderizar pincéis de tinta. O valor padrão é `true`, que utiliza opacidade. Para usar a operação ROP em vez disso, chame [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity-boolean-) com `false`.

O exemplo JavaScript a seguir exporta um slide para SVG e usa renderização baseada em ROP para operações de máscara de tinta:

```javascript
const aspose = {
    slides: require("aspose.slides.via.java")
};
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const svgOptions = new aspose.slides.SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "slide.svg");
    try {
        const slide = presentation.getSlides().get_Item(0);
        slide.writeAsSvg(outputStream, svgOptions);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

A mesma configuração pode ser aplicada através de [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/tiffoptions/#getInkOptions--) ao exportar uma apresentação ou renderizar um slide para TIFF.

### **Escolher se Ocultar ou Manter a Tinta**

Quando você precisa de uma versão limpa de uma apresentação anotada para distribuição sem marcas de revisão, chame [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) com `true` durante a exportação.

Deixe [InkOptions.getHideInk](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#getHideInk--) com seu valor padrão `false` quando as anotações de tinta fizerem parte do conteúdo desejado, como comentários de revisão, notas manuscritas, realces ou desenhos que devem permanecer visíveis no resultado exportado. Isso permite que os aplicativos gerem saídas de revisão e final separadas a partir da mesma apresentação sem modificar os objetos de tinta de origem.

## **Perguntas Frequentes**

**Posso alterar a cor ou o tamanho de um traço de tinta existente?**

Sim. Obtenha o traço através de [Ink.getTraces](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/ink/#getTraces--) e então altere seu [InkTrace.getBrush](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inktrace/#getBrush--). Chame [InkBrush.setColor](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkbrush/#setColor-java.awt.Color-) ou [InkBrush.setSize](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkbrush/#setSize-java.awt.geom.Dimension2D-) para mudar o pincel.

**Ocultar a tinta altera a apresentação original?**

Não. Chamar [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/inkoptions/#setHideInk-boolean-) afeta apenas o resultado renderizado ou exportado; não remove nem modifica os objetos de tinta na apresentação original.

**Quais formatos de exportação suportam opções de tinta?**

Você pode configurar opções de tinta para PDF, HTML, SVG, TIFF e imagens bitmap de slides através das opções de exportação ou renderização correspondentes mostradas acima.

**Leitura adicional**

* Para ler sobre formas em geral, veja a seção [Formas do PowerPoint](https://docs.aspose.com/slides/pt/nodejs-java/powerpoint-shapes/).
* Para mais informações sobre valores eficazes, veja [Propriedades Eficazes da Forma](https://docs.aspose.com/slides/pt/nodejs-java/shape-effective-properties/#get-effective-font-height-value).
* Para detalhes sobre exportação PDF, veja [Converter PPT e PPTX para PDF](https://docs.aspose.com/slides/pt/nodejs-java/convert-powerpoint-to-pdf/).
* Para detalhes sobre exportação HTML, veja [Converter Apresentações PowerPoint para HTML](https://docs.aspose.com/slides/pt/nodejs-java/convert-powerpoint-to-html/).
* Para detalhes sobre exportação SVG, veja [Renderizar Slides de Apresentação como Imagens SVG](https://docs.aspose.com/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/).
* Para detalhes sobre exportação TIFF, veja [Converter Apresentações PowerPoint para TIFF](https://docs.aspose.com/slides/pt/nodejs-java/convert-powerpoint-to-tiff/).
* Para detalhes sobre renderização de slide para imagem, veja [Converter Slides de Apresentação em Imagens](https://docs.aspose.com/slides/pt/nodejs-java/convert-slide/).