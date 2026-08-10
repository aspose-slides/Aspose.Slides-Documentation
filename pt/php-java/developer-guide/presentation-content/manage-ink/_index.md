---
title: Gerenciar objetos de caneta de apresentação em PHP
linktitle: Gerenciar caneta
type: docs
weight: 95
url: /pt/php-java/manage-ink/
keywords:
- caneta
- objeto de caneta
- traço de caneta
- gerenciar caneta
- desenhar caneta
- desenho
- exportação de caneta
- renderização de caneta
- ocultar caneta
- InkOptions
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Gerencie objetos de caneta do PowerPoint, edite traços e propriedades de pincel, e controle a aparência da caneta durante exportação para PDF, HTML, SVG, TIFF e imagens com Aspose.Slides para PHP via Java."
---
## **Introdução**

O PowerPoint oferece um recurso de caneta que permite desenhar traços livres. A caneta pode ser usada para realçar outros objetos, mostrar conexões e processos, e chamar a atenção para itens específicos em um slide.

Aspose.Slides fornece os tipos necessários para trabalhar com objetos de caneta. Por exemplo, a classe [Ink](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ink/) representa um objeto de caneta em um slide.

## **Diferenças entre Objetos Regulares e Objetos de Caneta**

Objetos em um slide do PowerPoint são normalmente representados por objetos [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/). Na sua forma mais simples, um shape é um contêiner que define a área do próprio objeto (sua moldura) juntamente com propriedades como tamanho do contêiner, forma e plano de fundo. Para mais informações, veja [Shape Layout Format](https://docs.aspose.com/slides/pt/php-java/shape-manipulations/#access-layout-formats-for-shape).

Entretanto, quando o PowerPoint manipula um objeto de caneta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos métodos padrão [Shape.getWidth](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getWidth) e [Shape.getHeight](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Caneta**

Um traço de caneta é um elemento básico usado para registrar a trajetória de uma caneta enquanto o usuário escreve com caneta digital. Um traço armazena uma sequência de pontos conectados.

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles geram uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Um pincel é usado para desenhar linhas que conectam os pontos de um traço de caneta. O pincel tem sua própria cor e tamanho, representados pelos métodos [InkBrush.getColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkbrush/#getColor) e [InkBrush.getSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkbrush/#getSize).

### **Definir Cor do Pincel de Caneta**

Este código PHP mostra como definir a cor de um pincel de caneta:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brush->setColor(java("java.awt.Color")->RED);
} finally {
    $presentation->dispose();
}
```

### **Definir Tamanho do Pincel de Caneta**

Este código PHP mostra como definir o tamanho de um pincel de caneta:

```php
$presentation = new Presentation("pres.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $ink = $slide->getShapes()->get_Item(0);
    $brush = $ink->getTraces()[0]->getBrush();
    $brushSize = new Java("java.awt.Dimension", 5, 10);
    $brush->setSize($brushSize);
} finally {
    $presentation->dispose();
}
```

De modo geral, a largura e a altura de um pincel não coincidem, por isso o PowerPoint não exibe o tamanho do pincel (a seção de dados correspondente está esmaecida). Quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho assim:

![ink_powerpoint3](ink_powerpoint3.png)

Para maior clareza, vamos aumentar a altura do objeto de caneta e revisar as dimensões importantes:

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não leva em conta o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a imagem anterior).

Portanto, para determinar a área visível de todo o objeto de caneta, o tamanho do pincel de seus traços deve ser considerado. Aqui, o objeto‑alvo (o traço de texto manuscrito) foi dimensionado para o tamanho do contêiner (moldura). Quando o tamanho do contêiner muda, o tamanho do pincel permanece constante, e vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint usa comportamento semelhante para objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar Aparência da Caneta Durante Exportação e Renderização**

Aspose.Slides fornece a classe [InkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/) para controlar como os objetos de caneta aparecem na saída exportada ou renderizada. Você pode usar suas propriedades para ocultar a caneta completamente ou alterar como as operações de máscara do pincel de caneta são interpretadas.

As opções de caneta estão disponíveis nas opções de exportação ou renderização para vários tipos de saída:

| Saída | Propriedade de opções de caneta |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/renderingoptions/#getInkOptions) |

Os seguintes métodos da classe [InkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/) expõem as mesmas duas configurações:

- [InkOptions.getHideInk](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#getHideInk) determina se os objetos de caneta são incluídos na saída. Seu valor padrão é `false`.
- [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) determina se uma operação de máscara é interpretada como opacidade ao renderizar um pincel de caneta. Seu valor padrão é `true`; chame [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) com `false` para usar a operação ROP em vez disso.

### **Ocultar Objetos de Caneta na Saída PDF**

Por padrão, os objetos de caneta permanecem visíveis durante a exportação. Para criar uma saída limpa sem anotações manuscritas ou outro conteúdo de caneta, chame [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#setHideInk) com `true`.

O exemplo PHP a seguir exporta uma apresentação para PDF ocultando todos os objetos de caneta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->getInkOptions()->setHideInk(true);

    $presentation->save("presentation_without_ink.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Ocultar Objetos de Caneta ao Renderizar um Slide como Imagem**

Para ocultar objetos de caneta ao renderizar slides como imagens bitmap, configure [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/renderingoptions/#getInkOptions) e passe as opções de renderização para [Slide.getImage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slide/#getImage).

O exemplo PHP a seguir renderiza o primeiro slide como uma imagem PNG sem objetos de caneta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $renderingOptions = new RenderingOptions();
    $renderingOptions->getInkOptions()->setHideInk(true);

    $slide = $presentation->getSlides()->get_Item(0);
    $image = $slide->getImage($renderingOptions);
    try {
        $image->save("slide_without_ink.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

### **Controlar Renderização de Máscara de Caneta**

A configuração [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) controla como as operações de máscara são interpretadas ao renderizar pincéis de caneta. O valor padrão é `true`, que usa opacidade. Para usar a operação ROP em vez disso, chame [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) com `false`.

O exemplo PHP a seguir exporta um slide para SVG e usa renderização baseada em ROP para operações de máscara de caneta:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $svgOptions = new SVGOptions();
    $svgOptions->getInkOptions()->setInterpretMaskOpAsOpacity(false);

    $outputStream = new Java("java.io.FileOutputStream", "slide.svg");
    try {
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->writeAsSvg($outputStream, $svgOptions);
    } finally {
        $outputStream->close();
    }
} finally {
    $presentation->dispose();
}
```

A mesma configuração pode ser aplicada através de [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/tiffoptions/#getInkOptions) ao exportar uma apresentação ou renderizar um slide para TIFF.

### **Escolher Entre Ocultar ou Preservar a Caneta**

Quando você precisar de uma versão limpa de uma apresentação anotada para distribuição sem marcas de revisão, chame [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#setHideInk) com `true` durante a exportação.

Mantenha [InkOptions.getHideInk](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#getHideInk) em seu valor padrão `false` quando as anotações de caneta fizerem parte do conteúdo desejado, como comentários de revisão, notas manuscritas, realces ou desenhos que devem permanecer visíveis no resultado exportado. Isso permite que aplicativos gerem saídas de revisão e finais separadas a partir da mesma apresentação sem modificar os objetos de caneta originais.

## **Perguntas Frequentes**

**Posso alterar a cor ou o tamanho de um traço de caneta existente?**

Sim. Obtenha o traço via [Ink.getTraces](https://reference.aspose.com/slides/pt/php-java/aspose.slides/ink/#getTraces), então altere seu [InkTrace.getBrush](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inktrace/#getBrush). Chame [InkBrush.setColor](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkbrush/#setColor) ou [InkBrush.setSize](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkbrush/#setSize) para mudar o pincel.

**Ocultar a caneta altera a apresentação original?**

Não. Chamar [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/php-java/aspose.slides/inkoptions/#setHideInk) afeta apenas o resultado renderizado ou exportado; não remove nem modifica os objetos de caneta na apresentação original.

**Quais formatos de exportação suportam opções de caneta?**

Você pode configurar opções de caneta para PDF, HTML, SVG, TIFF e imagens bitmap de slides por meio das opções de exportação ou renderização correspondentes mostradas acima.

**Leitura adicional**

* Para ler sobre formas em geral, veja a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/php-java/powerpoint-shapes/).
* Para mais informações sobre valores efetivos, veja [Shape Effective Properties](https://docs.aspose.com/slides/pt/php-java/shape-effective-properties/#get-effective-font-height-value).
* Para detalhes sobre exportação para PDF, veja [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pt/php-java/convert-powerpoint-to-pdf/).
* Para detalhes sobre exportação para HTML, veja [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pt/php-java/convert-powerpoint-to-html/).
* Para detalhes sobre exportação para SVG, veja [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pt/php-java/render-a-slide-as-an-svg-image/).
* Para detalhes sobre exportação para TIFF, veja [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pt/php-java/convert-powerpoint-to-tiff/).
* Para detalhes sobre renderização de slide para imagem, veja [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pt/php-java/convert-slide/).