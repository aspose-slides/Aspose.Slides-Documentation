---
title: Gerenciar objetos de tinta de apresentação em Python via Java
linktitle: Gerenciar tinta
type: docs
weight: 95
url: /pt/python-java/manage-ink/
keywords:
- tinta
- objeto de tinta
- rastro de tinta
- gerenciar tinta
- desenhar tinta
- desenho
- exportação de tinta
- renderização de tinta
- ocultar tinta
- InkOptions
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Gerencie objetos de tinta do PowerPoint, edite rastros e propriedades de pincel, e controle a aparência da tinta durante a exportação de PDF, HTML, SVG, TIFF e imagens com Aspose.Slides para Python via Java."
---
## **Introdução**

O PowerPoint oferece um recurso de tinta que permite desenhar traços livres. A tinta pode ser usada para destacar outros objetos, mostrar conexões e processos, e chamar a atenção para itens específicos em um slide.

Aspose.Slides fornece os tipos necessários para trabalhar com objetos de tinta. Por exemplo, a classe [Ink](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ink/) representa um objeto de tinta em um slide.

## **Diferenças entre Objetos Regulares e Objetos de Tinta**

Objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Em sua forma mais simples, uma forma é um contêiner que define a área do próprio objeto (sua moldura) junto com propriedades como o tamanho do contêiner, forma e plano de fundo. Para mais informações, veja [Shape Layout Format](/slides/pt/python-java/shape-manipulations/#access-layout-formats-for-shape).

No entanto, quando o PowerPoint manipula um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelos métodos padrão [Shape.getWidth](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getWidth) e [Shape.getHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/shape/#getHeight):

![ink_powerpoint1](ink_powerpoint1.png)

## **Rastreamentos de Tinta**

Um rastreamento de tinta é um elemento básico usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Um rastreamento armazena uma sequência de pontos conectados.

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Um pincel é usado para desenhar linhas que conectam os pontos de um rastreamento de tinta. O pincel tem sua própria cor e tamanho, representados pelos métodos [InkBrush.getColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkbrush/#getColor) e [InkBrush.getSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkbrush/#getSize).

### **Definir Cor do Pincel de Tinta**

Este código Python mostra como definir a cor de um pincel de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Definir Tamanho do Pincel de Tinta**

Este código Python mostra como definir o tamanho de um pincel de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Geralmente, a largura e a altura de um pincel não coincidem, portanto o PowerPoint não exibe o tamanho do pincel (a seção de dados correspondente fica cinza). Quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho da seguinte forma:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes:

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a imagem anterior).

Portanto, para determinar a área visível de todo o objeto de tinta, o tamanho do pincel de seus rastreamentos deve ser considerado. Aqui, o objeto alvo (o rastreamento de texto manuscrito) foi dimensionado ao tamanho do contêiner (moldura). Quando o tamanho do contêiner muda, o tamanho do pincel permanece constante, e vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint usa comportamento semelhante para objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar a Aparência da Tinta Durante Exportação e Renderização**

Aspose.Slides fornece a classe [InkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/) para controlar como os objetos de tinta aparecem na saída exportada ou renderizada. Você pode usar suas propriedades para ocultar totalmente a tinta ou alterar como as operações de máscara de pincel de tinta são interpretadas.

As opções de tinta estão disponíveis através das opções de exportação ou renderização para vários tipos de saída:

| Saída | Propriedade de opções de tinta |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Os seguintes métodos da classe [InkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/) expõem as mesmas duas configurações:

- [getHideInk](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#getHideInk) determina se os objetos de tinta são incluídos na saída. Seu valor padrão é `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) determina se uma operação de máscara é interpretada como opacidade ao renderizar um pincel de tinta. Seu valor padrão é `True`; chame [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) com `False` para usar a operação ROP em vez disso.

### **Ocultar Objetos de Tinta na Saída PDF**

Por padrão, os objetos de tinta permanecem visíveis durante a exportação. Para criar uma saída limpa sem anotações manuscritas ou outro conteúdo de tinta, chame [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#setHideInk) com `True`.

O exemplo Python a seguir exporta uma apresentação para PDF ocultando todos os objetos de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Ocultar Objetos de Tinta ao Renderizar um Slide como Imagem**

Para ocultar objetos de tinta ao renderizar slides como imagens bitmap, configure [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/renderingoptions/#getInkOptions) e passe as opções de renderização para [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage).

O exemplo Python a seguir renderiza o primeiro slide como uma imagem PNG sem objetos de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Controlar a Renderização da Máscara de Tinta**

A configuração [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) controla como as operações de máscara são interpretadas ao renderizar pincéis de tinta. O valor padrão é `True`, que usa opacidade. Para usar a operação ROP em vez disso, chame [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) com `False`.

O exemplo Python a seguir exporta um slide para SVG e usa renderização baseada em ROP para operações de máscara de tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

A mesma configuração pode ser aplicada através de [TiffOptions.getInkOptions](https://reference.aspose.com/slides/pt/python-java/aspose.slides/tiffoptions/#getInkOptions) ao exportar uma apresentação ou renderizar um slide para TIFF.

### **Escolher Entre Ocultar ou Preservar a Tinta**

Quando você precisar de uma versão limpa de uma apresentação anotada para distribuição sem marcas de revisão, chame [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#setHideInk) com `True` durante a exportação.

Mantenha [InkOptions.getHideInk](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#getHideInk) com seu valor padrão `False` quando as anotações de tinta fizerem parte do conteúdo desejado, como comentários de revisão, notas manuscritas, realces ou desenhos que devem permanecer visíveis no resultado exportado. Isso permite que aplicativos gerem saídas de revisão e finais separadas a partir da mesma apresentação sem modificar os objetos de tinta originais.

## **Perguntas Frequentes**

**Posso alterar a cor ou o tamanho de um traço de tinta existente?**

Sim. Obtém o rastreamento de [Ink.getTraces](https://reference.aspose.com/slides/pt/python-java/aspose.slides/ink/#getTraces), então altere seu [InkTrace.getBrush](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inktrace/#getBrush). Chame [InkBrush.setColor](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkbrush/#setColor) ou [InkBrush.setSize](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkbrush/#setSize) para mudar o pincel.

**Ocultar a tinta altera a apresentação original?**

Não. Chamar [InkOptions.setHideInk](https://reference.aspose.com/slides/pt/python-java/aspose.slides/inkoptions/#setHideInk) afeta apenas o resultado renderizado ou exportado; não remove nem modifica os objetos de tinta na apresentação original.

**Quais formatos de exportação suportam opções de tinta?**

Você pode configurar opções de tinta para PDF, HTML, SVG, TIFF e imagens bitmap de slides através das opções de exportação ou renderização correspondentes mostradas acima.

**Leitura adicional**

* Para ler sobre formas em geral, veja a seção [PowerPoint Shapes](/slides/pt/python-java/powerpoint-shapes/).
* Para mais informações sobre valores efetivos, veja [Shape Effective Properties](/slides/pt/python-java/shape-effective-properties/#get-effective-font-height-value).
* Para detalhes sobre exportação para PDF, veja [Convert PPT and PPTX to PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/).
* Para detalhes sobre exportação para HTML, veja [Convert PowerPoint Presentations to HTML](/slides/pt/python-java/convert-powerpoint-to-html/).
* Para detalhes sobre exportação para SVG, veja [Render Presentation Slides as SVG Images](/slides/pt/python-java/render-a-slide-as-an-svg-image/).
* Para detalhes sobre exportação para TIFF, veja [Convert PowerPoint Presentations to TIFF](/slides/pt/python-java/convert-powerpoint-to-tiff/).
* Para detalhes sobre renderização de slide para imagem, veja [Convert Presentation Slides to Images](/slides/pt/python-java/convert-slide/).