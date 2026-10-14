---
title: Converter Slides do PowerPoint para PNG em Python
linktitle: PowerPoint para PNG
type: docs
weight: 30
url: /pt/python-net/convert-powerpoint-to-png/
keywords:
- converter PowerPoint para PNG
- converter apresentação para PNG
- converter slide para PNG
- converter PPT para PNG
- converter PPTX para PNG
- converter ODP para PNG
- PowerPoint para PNG
- apresentação para PNG
- slide para PNG
- PPT para PNG
- PPTX para PNG
- ODP para PNG
- Python
- Aspose.Slides
description: "Converta apresentações PowerPoint e OpenDocument em imagens PNG de alta qualidade rapidamente com Aspose.Slides para Python via .NET, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter slides de apresentação em imagens PNG usando Aspose.Slides para Python via .NET. Você pode carregar apresentações em formatos como PPT, PPTX e ODP, renderizar cada slide e salvá‑lo como uma imagem PNG separada.

Os exemplos abaixo demonstram a renderização na escala padrão, o aumento da escala, a especificação das dimensões de saída em pixels e a escolha de um estilo de renderização de gradiente.

## **Converter PowerPoint para PNG**

Carregue uma apresentação com a [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) classe e acesse seus slides através da coleção [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). O exemplo renderiza cada slide com [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) sem parâmetros para criar uma miniatura. Em seguida, chama [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) com [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) para salvar cada slide renderizado como uma imagem PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
A sobrecarga sem parâmetros de [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) renderiza em uma escala de 0,2. Por exemplo, um slide com 720 × 540 pontos produz uma miniatura de 144 × 108 pixels. Para controlar as dimensões de saída, use as sobrecargas com fatores de escala ou um tamanho de imagem explícito mostrado abaixo.
{{% /alert %}}

## **Converter PowerPoint para PNG com Dimensões Personalizadas**

Passe fatores de escala horizontal e vertical para [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) para controlar as dimensões renderizadas. Neste exemplo, ambos os fatores são 2, portanto um slide de 720 × 540 pontos produz uma imagem de 1440 × 1080 pixels. Fatores de escala iguais preservam a proporção do slide. Cada imagem é salva no formato PNG com [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Para especificar as dimensões de saída em pixels, passe um tamanho para [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) em vez de fatores de escala. Este exemplo renderiza cada slide em 960 × 720 pixels e salva o resultado com [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Escolha dimensões que correspondam à proporção do slide para evitar distorção da imagem.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Escolher um Estilo de Renderização de Gradiente**

Suponha que um slide contenha preenchimentos em gradiente, mas as transições no PNG exportado pareçam mais claras ou diferentes do que você vê no PowerPoint. Você pode usar a propriedade [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) de [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) para escolher como os gradientes são renderizados.

Faça o download de [gradient-styles.pptx](gradient-styles.pptx) e coloque‑o no diretório de trabalho da aplicação. Seu primeiro slide contém dois gradientes lineares: ciano para laranja na parte superior e azul para amarelo na parte inferior. Cada gradiente tem duas paradas, em 0% e 100%.

O exemplo a seguir carrega esta apresentação e renderiza o mesmo primeiro slide em ambos os modos com [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

As imagens abaixo mostram a saída do mesmo slide, com ambos os gradientes em cada imagem:

| Default | PowerPointUI |
| --- | --- |
| ![Gradientes de ciano para laranja e azul para amarelo renderizados com Default](gradient-Default.png) | ![Os mesmos gradientes renderizados com PowerPointUI](gradient-PowerPointUI.png) |

Neste exemplo, `DEFAULT` produz cores intermediárias mais claras, enquanto `POWER_POINT_UI` produz cores intermediárias mais escuras. A diferença depende das cores e das paradas no gradiente.

Escolha `DEFAULT` quando a saída padrão do Aspose.Slides atender às suas necessidades. Experimente `POWER_POINT_UI` quando sua prioridade for corresponder à aparência no PowerPoint. Compare ambas as saídas com o resultado desejado; nenhum modo é universalmente preferível.

## **FAQ**

**Como posso exportar uma forma específica, como um gráfico ou imagem, em vez de todo o slide?**

O Aspose.Slides suporta [gerar miniaturas para formas individuais](/slides/pt/python-net/create-shape-thumbnails/), permitindo que você renderize uma forma como uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim. Use uma instância de apresentação separada para cada thread ou processo; [não compartilhe uma única instância entre threads](/slides/pt/python-net/multithreading/).

**Quais são as limitações da avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e aplica [outras restrições](/slides/pt/python-net/licensing/) até que uma licença seja aplicada.