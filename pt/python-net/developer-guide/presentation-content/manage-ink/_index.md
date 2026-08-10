---
title: Gerenciar Objetos de Tinta de Apresentação em Python
linktitle: Gerenciar Tinta
type: docs
weight: 95
url: /pt/python-net/manage-ink/
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
- Python
- Aspose.Slides
description: "Gerenciar objetos de tinta do PowerPoint, editar traços e propriedades do pincel, e controlar a aparência da tinta durante a exportação para PDF, HTML, SVG, TIFF e imagens com Aspose.Slides para Python via .NET."
---
## **Introdução**

O PowerPoint oferece um recurso de tinta que permite desenhar traços livres. A tinta pode ser usada para destacar outros objetos, mostrar conexões e processos e chamar a atenção para itens específicos em um slide.

O namespace [aspose.slides.ink](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/) contém as classes necessárias para trabalhar com objetos de tinta. Por exemplo, a classe [Ink](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/ink/) representa um objeto de tinta em um slide.

## **Diferenças entre Objetos Regulares e Objetos de Tinta**

Os objetos em um slide do PowerPoint são tipicamente representados por objetos de forma. Na sua forma mais simples, uma forma é um contêiner que define a área do próprio objeto (sua moldura) junto com propriedades como tamanho do contêiner, forma e plano de fundo. Para mais informações, veja [Shape Layout Format](https://docs.aspose.com/slides/pt/python-net/shape-manipulations/#access-layout-formats-for-shape).

Entretanto, quando o PowerPoint manipula um objeto de tinta, ele ignora todas as propriedades da moldura do objeto (contêiner) exceto seu tamanho. O tamanho da área do contêiner é determinado pelas propriedades padrão [Ink.width](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/ink/width/) e [Ink.height](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/ink/height/):

![ink_powerpoint1](ink_powerpoint1.png)

## **Traços de Tinta**

Um traço de tinta é um elemento básico usado para registrar a trajetória de uma caneta enquanto o usuário escreve tinta digital. Um traço armazena uma sequência de pontos conectados.

A forma mais simples de codificação especifica as coordenadas X e Y de cada ponto de amostra. Quando todos os pontos conectados são renderizados, eles produzem uma imagem como esta:

![ink_powerpoint2](ink_powerpoint2.png)

## **Propriedades do Pincel para Desenho**

Um pincel é usado para desenhar linhas que conectam os pontos de um traço de tinta. Suas propriedades [InkBrush.color](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/inkbrush/color/) e [InkBrush.size](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/inkbrush/size/) controlam sua cor e tamanho.

### **Definir a Cor do Pincel de Tinta**

Este código Python mostra como definir a cor de um pincel de tinta:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Definir o Tamanho do Pincel de Tinta**

Este código Python mostra como definir o tamanho de um pincel de tinta:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Normalmente, a largura e a altura de um pincel não coincidem, de modo que o PowerPoint não exibe o tamanho do pincel (a seção de dados correspondente fica esmaecida). Quando a largura e a altura do pincel coincidem, o PowerPoint exibe seu tamanho assim:

![ink_powerpoint3](ink_powerpoint3.png)

Para clareza, vamos aumentar a altura do objeto de tinta e revisar as dimensões importantes:

![ink_powerpoint4](ink_powerpoint4.png)

O contêiner (moldura) não considera o tamanho dos pincéis — ele sempre assume que a espessura da linha é zero (veja a imagem anterior).

Portanto, para determinar a área visível de todo o objeto de tinta, deve‑se levar em conta o tamanho do pincel de seus traços. Aqui, o objeto alvo (o traço de texto manuscrito) foi escalado para o tamanho do contêiner (moldura). Quando o tamanho do contêiner muda, o tamanho do pincel permanece constante, e vice‑versa.

![ink_powerpoint5](ink_powerpoint5.png)

O PowerPoint usa comportamento semelhante para objetos de texto:

![ink_powerpoint6](ink_powerpoint6.png)

## **Controlar a Aparência da Tinta Durante Exportação e Renderização**

Aspose.Slides fornece a classe [InkOptions](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/) para controlar como os objetos de tinta aparecem na saída exportada ou renderizada. Você pode usar suas propriedades para ocultar totalmente a tinta ou alterar a forma como as operações de máscara do pincel de tinta são interpretadas.

As opções de tinta estão disponíveis por meio das opções de exportação ou renderização para vários tipos de saída:

| Saída | Propriedade de opções de Ink |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Imagem do slide | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/renderingoptions/ink_options/) |

As mesmas duas configurações estão disponíveis por meio dessas propriedades:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/hide_ink/) determina se os objetos de tinta são incluídos na saída. Seu valor padrão é `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) determina se uma operação de máscara é interpretada como opacidade ao renderizar um pincel de tinta. Seu valor padrão é `True`; defina como `False` para usar a operação ROP em vez disso.

### **Ocultar Objetos de Tinta na Saída PDF**

Por padrão, os objetos de tinta permanecem visíveis durante a exportação. Defina [InkOptions.hide_ink](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/hide_ink/) como `True` quando precisar de uma saída limpa sem anotações manuscritas ou outro conteúdo de tinta.

O exemplo Python a seguir exporta uma apresentação para PDF ocultando todos os objetos de tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Ocultar Objetos de Tinta ao Renderizar um Slide como Imagem**

Para ocultar objetos de tinta ao renderizar slides como imagens bitmap, configure [RenderingOptions.ink_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/renderingoptions/ink_options/) e passe as opções de renderização ao método [Slide.get_image](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/get_image/).

O exemplo Python a seguir renderiza o primeiro slide como uma imagem PNG sem objetos de tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Controlar a Renderização da Máscara de Tinta**

A propriedade [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) controla como as operações de máscara são interpretadas ao renderizar pincéis de tinta. O valor padrão é `True`, que usa opacidade. Defina a propriedade como `False` para usar a operação ROP em vez disso.

O exemplo Python a seguir exporta um slide para SVG e usa renderização baseada em ROP para as operações de máscara de tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

A mesma configuração pode ser aplicada via [TiffOptions.ink_options](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/tiffoptions/ink_options/) ao exportar uma apresentação ou renderizar um slide para TIFF.

### **Escolher Entre Ocultar ou Preservar a Tinta**

Defina [InkOptions.hide_ink](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/hide_ink/) como `True` quando o arquivo exportado deve ser uma versão limpa de uma apresentação anotada, por exemplo, uma cópia final destinada à distribuição sem marcas de revisão.

Mantenha [InkOptions.hide_ink](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/hide_ink/) em seu valor padrão `False` quando as anotações de tinta fizerem parte do conteúdo previsto, como comentários de revisão, notas manuscritas, realces ou desenhos que devem permanecer visíveis no resultado exportado. Isso permite que aplicativos gerem saídas de revisão e final separadas a partir da mesma apresentação sem modificar os objetos de tinta de origem.

## **Perguntas Frequentes**

**Posso mudar a cor ou o tamanho de um traço de tinta existente?**

Sim. Obtenha o traço a partir de [Ink.traces](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/ink/traces/), então altere seu [InkTrace.brush](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/inktrace/brush/). Você pode definir as propriedades [InkBrush.color](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/inkbrush/color/) e [InkBrush.size](https://reference.aspose.com/slides/pt/python-net/aspose.slides.ink/inkbrush/size/) do pincel.

**Ocultar a tinta altera a apresentação original?**

Não. [InkOptions.hide_ink](https://reference.aspose.com/slides/pt/python-net/aspose.slides.export/inkoptions/hide_ink/) afeta apenas o resultado renderizado ou exportado; ele não remove nem modifica os objetos de tinta na apresentação original.

**Quais formatos de exportação suportam opções de tinta?**

Você pode configurar opções de tinta para PDF, HTML, SVG, TIFF e imagens bitmap de slides por meio das opções de exportação ou renderização correspondentes mostradas acima.

**Leitura adicional**

* Para ler sobre formas em geral, consulte a seção [PowerPoint Shapes](https://docs.aspose.com/slides/pt/python-net/powerpoint-shapes/).
* Para mais informações sobre valores efetivos, veja [Shape Effective Properties](https://docs.aspose.com/slides/pt/python-net/shape-effective-properties/#get-effective-font-height-value).
* Para detalhes sobre exportação para PDF, veja [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/pt/python-net/convert-powerpoint-to-pdf/).
* Para detalhes sobre exportação para HTML, veja [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/pt/python-net/convert-powerpoint-to-html/).
* Para detalhes sobre exportação para SVG, veja [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/pt/python-net/render-a-slide-as-an-svg-image/).
* Para detalhes sobre exportação para TIFF, veja [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/pt/python-net/convert-powerpoint-to-tiff/).
* Para detalhes sobre renderização de slide para imagem, veja [Convert Presentation Slides to Images](https://docs.aspose.com/slides/pt/python-net/convert-slide/).