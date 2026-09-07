---
title: Converter slides do PowerPoint para PNG em Python
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
description: "Converter slides do PowerPoint em imagens PNG em Python via Java. Exportar apresentações PPT, PPTX e ODP com escalas personalizadas ou dimensões de imagem exatas."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint em imagens PNG usando Aspose.Slides para Python via Java. Você pode carregar arquivos PPT, PPTX e ODP, renderizar cada slide e salvá‑lo como uma imagem PNG separada.

Os exemplos também mostram como controlar as dimensões de saída com fatores de escala ou uma largura e altura exatas. Cada exemplo inicia a máquina virtual Java, se necessário, e libera os recursos de apresentação e imagem após o uso.

## **Converter PowerPoint para PNG**

1. Carregue o arquivo de entrada usando a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Recupere os slides usando [Presentation.getSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#getSlides).
3. Renderize cada slide usando [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage).
4. Salve cada imagem renderizada com [ImageFormat.Png](https://reference.aspose.com/slides/pt/python-java/aspose.slides/imageformat/#Png) e, em seguida, libere seus recursos.

O exemplo Python a seguir exporta todos os slides em seu tamanho padrão:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage()
        try:
            slide_image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Converter PowerPoint para PNG com Escala Personalizada**

Passe fatores de escala horizontal e vertical para [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage) para aumentar ou diminuir as dimensões de saída. Por exemplo, um slide de 720 × 540 pontos renderizado com um fator de escala 2 em ambos os eixos produz uma imagem de 1440 × 1080 pixels.

Use fatores de escala iguais para preservar a proporção do slide. Fatores diferentes esticam o slide horizontal ou verticalmente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = 2.0
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"slide_scaled_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Para especificar dimensões de pixel exatas, passe um objeto Java `Dimension` com a largura e altura desejadas para [Slide.getImage](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slide/#getImage). Escolha dimensões com a mesma proporção do slide de origem para evitar distorções.

O exemplo a seguir salva cada slide como uma imagem PNG de 960 × 720 pixels:

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
    for index, slide in enumerate(presentation.getSlides(), start=1):
        slide_image = slide.getImage(image_size)
        try:
            slide_image.save(f"slide_sized_{index}.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Perguntas frequentes**

**Posso exportar uma forma individual, como um gráfico ou imagem, em vez de todo o slide?**

Sim. Aspose.Slides oferece suporte a [geração de miniaturas para formas individuais](/slides/pt/python-java/create-shape-thumbnails/), que você pode salvar como imagens PNG.

**Posso converter apresentações em paralelo em um servidor?**

Use uma instância de apresentação separada para cada thread ou processo e utilize caminhos de saída exclusivos para evitar que arquivos sejam sobrescritos. Não compartilhe uma instância de apresentação entre threads. Consulte [Multithreading](/slides/pt/python-java/multithreading/).

**Quais são as limitações da versão de avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e aplica [outras restrições](/slides/pt/python-java/licensing/). Aplique uma licença para remover essas limitações.