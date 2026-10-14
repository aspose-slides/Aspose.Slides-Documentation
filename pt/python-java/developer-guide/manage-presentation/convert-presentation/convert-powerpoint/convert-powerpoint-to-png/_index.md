---
title: Converter Slides de PowerPoint para PNG em Python
linktitle: PowerPoint para PNG
type: docs
weight: 30
url: /pt/python-java/convert-powerpoint-to-png/
keywords:
- converter PowerPoint
- converter apresentação
- converter slide
- converter PPT
- converter PPTX
- PowerPoint para PNG
- apresentação para PNG
- slide para PNG
- PPT para PNG
- PPTX para PNG
- salvar PPT como PNG
- salvar PPTX como PNG
- exportar PPT para PNG
- exportar PPTX para PNG
- Python
- Java
- Aspose.Slides
description: "Converter slides de PowerPoint em imagens PNG em Python via Java. Exportar apresentações PPT, PPTX e ODP com escalas personalizadas ou dimensões de imagem exatas."
---
## **Visão geral**

Este artigo explica como converter slides de apresentação em imagens PNG usando Aspose.Slides para Python via Java. Você pode carregar apresentações em formatos como PPT, PPTX e ODP, renderizar cada slide e salvá‑lo como uma imagem PNG separada.

Os exemplos abaixo demonstram renderização na escala padrão, aumento da escala, especificação das dimensões de saída em pixels e escolha de um estilo de renderização de gradiente.

## **Converter PowerPoint para PNG**

Carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) e acesse seus slides por meio da coleção [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). O exemplo renderiza cada slide com [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) sem parâmetros para criar uma miniatura. Em seguida, chama [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) com [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) para salvar cada slide renderizado como uma imagem PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
A sobrecarga sem parâmetros de [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) renderiza em escala de 0,2. Por exemplo, um slide que mede 720 × 540 pontos produz uma miniatura de 144 × 108 pixels. Para controlar as dimensões de saída, use as sobrecargas com fatores de escala ou um tamanho de imagem explícito mostrado abaixo.
{{% /alert %}}

## **Converter PowerPoint para PNG com Dimensões Personalizadas**

Passe fatores de escala horizontal e vertical para [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) para controlar as dimensões renderizadas. Neste exemplo, ambos os fatores são 2, de modo que um slide que mede 720 × 540 pontos produz uma imagem de 1440 × 1080 pixels. Fatores de escala iguais preservam a proporção do slide. Cada imagem renderizada é salva no formato PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Para especificar dimensões de saída em pixels, passe um tamanho para [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) em vez de fatores de escala. Este exemplo renderiza cada slide em 960 × 720 pixels e salva o resultado no formato PNG. Escolha dimensões que correspondam à proporção do slide para evitar distorção da imagem.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Escolher um Estilo de Renderização de Gradiente**

Suponha que um slide contenha preenchimentos em gradiente, mas as transições no PNG exportado pareçam mais claras ou diferentes do que você vê no PowerPoint. Você pode usar o método [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) herdado por [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) para escolher como os gradientes são renderizados.

Baixe [gradient-styles.pptx](gradient-styles.pptx) e coloque-o no diretório de trabalho da aplicação. Seu primeiro slide contém dois gradientes lineares: ciano para laranja na parte superior e azul para amarelo na parte inferior. Cada gradiente tem duas paradas, em 0 % e 100 %.

O exemplo a seguir carrega esta apresentação e renderiza o mesmo primeiro slide em ambos os modos com [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

| Default | PowerPointUI |
| --- | --- |
| ![Gradientes de ciano para laranja e azul para amarelo renderizados com Default](gradient-Default.png) | ![Os mesmos gradientes renderizados com PowerPointUI](gradient-PowerPointUI.png) |

Neste exemplo, `Default` produz cores intermediárias mais claras, enquanto `PowerPointUI` produz cores intermediárias mais escuras. A diferença depende das cores e das paradas no gradiente.

Escolha `Default` quando a saída padrão do Aspose.Slides atender às suas necessidades. Experimente `PowerPointUI` quando sua prioridade for corresponder à aparência no PowerPoint. Compare ambas as saídas com o resultado desejado; nenhum modo é universalmente preferível.

## **Perguntas frequentes**

**Como posso exportar uma forma específica, como um gráfico ou imagem, em vez de todo o slide?**

Aspose.Slides suporta [gerar miniaturas para formas individuais](/slides/pt/python-java/create-shape-thumbnails/), permitindo que você renderize uma forma como uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim. Use uma instância de apresentação separada para cada thread ou processo; [não compartilhe uma única instância entre threads](/slides/pt/python-java/multithreading/).

**Quais são as limitações da avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d’água às imagens de saída e aplica [outras restrições](/slides/pt/python-java/licensing/) até que uma licença seja aplicada.