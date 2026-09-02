---
title: Gerenciar Objetos de Tinta de Apresentação em Java
linktitle: Gerenciar Tinta
type: docs
weight: 95
url: /pt/java/manage-ink/
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
- IInkOptions
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint, edite traços e propriedades de pincel, e controle a aparência da tinta durante a exportação para PDF, HTML, SVG, TIFF e imagens com Aspose.Slides para Java."
---
## **Introdução**

O PowerPoint fornece um recurso de tinta que permite desenhar traços livres. A tinta pode ser usada para realçar outros objetos, mostrar conexões e processos e chamar a atenção para itens específicos em um slide.

Aspose.Slides fornece os tipos necessários para trabalhar com objetos de tinta. Por exemplo, a interface [IInk](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iink/) representa um objeto de tinta em um slide.

## **Diferenças entre Objetos Regulares e Objetos de Tinta**

Objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Na forma mais simples, uma forma é um contêiner que define a área do próprio objeto (sua moldura) juntamente com propriedades como tamanho do contêiner, forma e plano de fundo. Para mais informações, veja [Shape Layout Format](https://docs.aspose.com/slides/pt/java/shape-manipulations/#access-layout-formats-for-shape).

Entretanto, quando o PowerPoint manipula um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos métodos padrão [IShape.getWidth](https://reference.aspose.com/slides/pt/java/com.aspose.slides.ishape/#getWidth--) e [IShape.getHeight](https://reference.aspose.com/slides/pt/java/com.aspose.slides.ishape/#getHeight--):

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Tinta**

Um traço de tinta é um elemento básico usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Um traço armazena uma sequência de pontos conectados.

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Um pincel é usado para desenhar linhas que conectam os pontos de um traço de tinta. O pincel tem sua própria cor e tamanho, representados pelos métodos [IInkBrush.getColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkbrush/#getColor--) e [IInkBrush.getSize](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkbrush/#getSize--) .

### **Definir a Cor do Pincel de Tinta**

Este código Java mostra como definir a cor de um pincel de tinta:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Definir o Tamanho do Pincel de Tinta**

Este código Java mostra como definir o tamanho de um pincel de tinta:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    Dimension brushSize = new Dimension(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Geralmente, a largura e a altura de um pincel não coincidem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados correspondente fica esmaecida). Quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes:

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a imagem anterior).

Portanto, para determinar a área visível de todo o objeto de tinta, o tamanho do pincel de seus traços deve ser levado em conta. Aqui, o objeto alvo (o traço de texto manuscrito) foi dimensionado para o tamanho do contêiner (moldura). Quando o tamanho do contêiner muda, o tamanho do pincel permanece constante, e vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint usa comportamento semelhante para objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar a Aparência da Tinta Durante Exportação e Renderização**

Aspose.Slides fornece a interface [IInkOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/) para controlar como os objetos de tinta aparecem na saída exportada ou renderizada. Você pode usar suas propriedades para ocultar completamente a tinta ou alterar como as operações de máscara do pincel de tinta são interpretadas.

As opções de tinta estão disponíveis através das opções de exportação ou renderização para vários tipos de saída:

| Saída | Propriedade de opções de tinta |
| --- | --- |
| PDF | [`PdfOptions.getInkOptions`](https://reference.aspose.com/slides/pt/java/com.aspose.slides.pdfoptions/#getInkOptions--) |
| HTML | [`HtmlOptions.getInkOptions`](https://reference.aspose.com/slides/pt/java/com.aspose.slides.htmloptions/#getInkOptions--) |
| SVG | [`SVGOptions.getInkOptions`](https://reference.aspose.com/slides/pt/java/com.aspose.slides.svgoptions/#getInkOptions--) |
| TIFF | [`TiffOptions.getInkOptions`](https://reference.aspose.com/slides/pt/java/com.aspose.slides.tiffoptions/#getInkOptions--) |
| Imagem do slide | [`RenderingOptions.getInkOptions`](https://reference.aspose.com/slides/pt/java/com.aspose.slides.renderingoptions/#getInkOptions--) |

Os seguintes métodos da [IInkOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/) expõem as mesmas duas configurações:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#getHideInk--) determina se os objetos de tinta são incluídos na saída. Seu valor padrão é `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#getInterpretMaskOpAsOpacity--) determina se uma operação de máscara é interpretada como opacidade ao renderizar um pincel de tinta. Seu valor padrão é `true`; chame [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) com `false` para usar a operação ROP em vez disso.

### **Ocultar Objetos de Tinta na Saída PDF**

Por padrão, os objetos de tinta permanecem visíveis durante a exportação. Para criar uma saída limpa sem anotações manuscritas ou outro conteúdo de tinta, chame [IInkOptions.setHideInk](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#setHideInk-boolean-) com `true`.

O exemplo Java a seguir exporta uma apresentação para PDF ocultando todos os objetos de tinta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Ocultar Objetos de Tinta ao Renderizar um Slide como Imagem**

Para ocultar objetos de tinta ao renderizar slides como imagens bitmap, configure [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides.renderingoptions/#getInkOptions--) e passe as opções de renderização para [ISlide.getImage](https://reference.aspose.com/slides/pt/java/com.aspose.slides.islide/#getImage-com.aspose.slides.IRenderingOptions-).

O exemplo Java a seguir renderiza o primeiro slide como uma imagem PNG sem objetos de tinta:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Controlar a Renderização da Máscara de Tinta**

A configuração [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#getInterpretMaskOpAsOpacity--) controla como as operações de máscara são interpretadas ao renderizar pincéis de tinta. O valor padrão é `true`, que usa opacidade. Para usar a operação ROP, chame [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) com `false`.

O exemplo Java a seguir exporta um slide para SVG e usa renderização baseada em ROP para operações de máscara de tinta:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    FileOutputStream stream = new FileOutputStream("slide.svg");
    ISlide slide = presentation.getSlides().get_Item(0);
    slide.writeAsSvg(stream, svgOptions);
} finally {
    presentation.dispose();
}
```

A mesma configuração pode ser aplicada através de [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pt/java/com.aspose.slides.tiffoptions/#getInkOptions--) ao exportar uma apresentação ou renderizar um slide para TIFF.

### **Escolher Se Ocultar ou Preservar a Tinta**

Quando precisar de uma versão limpa de uma apresentação anotada para distribuição sem marcas de revisão, chame [IInkOptions.setHideInk](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#setHideInk-boolean-) com `true` durante a exportação.

Mantenha [IInkOptions.getHideInk](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#getHideInk--) com seu valor padrão `false` quando as anotações de tinta fizerem parte do conteúdo desejado, como comentários de revisão, notas manuscritas, realces ou desenhos que devem permanecer visíveis no resultado exportado. Isso permite que aplicativos gerem saídas de revisão e finais separadas a partir da mesma apresentação sem modificar os objetos de tinta de origem.

## **FAQ**

**Posso alterar a cor ou o tamanho de um traço de tinta existente?**

Sim. Obtenha o traço via [IInk.getTraces](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iink/#getTraces--), então altere seu [IInkTrace.getBrush](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinktrace/#getBrush--). Chame [IInkBrush.setColor](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkbrush/#setColor-java.awt.Color-) ou [IInkBrush.setSize](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkbrush/#setSize-java.awt.geom.Dimension2D-) para mudar o pincel.

**Ocultar a tinta altera a apresentação de origem?**

Não. Chamar [IInkOptions.setHideInk](https://reference.aspose.com/slides/pt/java/com.aspose.slides.iinkoptions/#setHideInk-boolean-) afeta apenas o resultado renderizado ou exportado; não remove nem modifica os objetos de tinta na apresentação original.

**Quais formatos de exportação suportam opções de tinta?**

Você pode configurar opções de tinta para PDF, HTML, SVG, TIFF e imagens bitmap de slides através das opções de exportação ou renderização correspondentes mostradas acima.

**Leitura adicional**

* Para saber mais sobre formas em geral, veja a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/java/powerpoint-shapes/).
* Para informações sobre valores efetivos, veja [Shape Effective Properties](https://docs.aspose.com/slides/pt/java/shape-effective-properties/#get-effective-font-height-value).
* Para detalhes sobre exportação para PDF, veja [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pt/java/convert-powerpoint-to-pdf/).
* Para detalhes sobre exportação para HTML, veja [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pt/java/convert-powerpoint-to-html/).
* Para detalhes sobre exportação para SVG, veja [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pt/java/render-a-slide-as-an-svg-image/).
* Para detalhes sobre exportação para TIFF, veja [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pt/java/convert-powerpoint-to-tiff/).
* Para detalhes sobre renderização de slide para imagem, veja [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pt/java/convert-slide/).