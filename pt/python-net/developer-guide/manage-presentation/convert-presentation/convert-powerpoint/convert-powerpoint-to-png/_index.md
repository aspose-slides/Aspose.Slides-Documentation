---
title: Converter slides do PowerPoint para PNG em Python
linktitle: Slide para PNG
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
description: "Converta apresentações PowerPoint e OpenDocument para imagens PNG de alta qualidade rapidamente com Aspose.Slides para Python via .NET, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Aspose.Slides for Python via .NET simplifica a conversão de apresentações PowerPoint para PNG. Você carrega uma apresentação, itera pelos seus slides, renderiza cada um em uma imagem raster e salva o resultado como arquivos PNG. Isso é ideal para gerar pré-visualizações de slides, incorporar slides em páginas da web ou produzir ativos estáticos para processamento posterior.

## **Converter slides para PNG**

Esta seção mostra o exemplo mais simples possível de conversão de uma apresentação PowerPoint em imagens PNG usando Aspose.Slides for Python via .NET.

Siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Obtenha um slide da coleção `Presentation.slides` (veja a classe [Slide](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/)).
3. Use o método `Slide.get_image` para gerar uma miniatura do slide.
4. Use o método `Presentation.save` para salvar a miniatura do slide no formato PNG.

Este código Python mostra como converter uma apresentação PowerPoint para PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Converter slides para PNG com dimensões personalizadas**

Para exportar slides para PNG em uma escala personalizada, chame `Slide.get_image` com fatores de escala horizontal e vertical. Esses multiplicadores redimensionam a saída em relação às dimensões originais do slide — por exemplo, `2.0` duplica a largura e a altura. Use valores iguais para `scale_x` e `scale_y` para preservar a proporção.

Este código Python demonstra a operação descrita:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Converter slides para PNG com tamanho personalizado**

Se você quiser gerar arquivos PNG em um tamanho específico, informe os valores desejados de `width` e `height`. O código abaixo mostra como converter um PowerPoint para PNG especificando o tamanho da imagem:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Talvez você queira experimentar os conversores gratuitos de **PowerPoint para PNG** da Aspose —[PPTX to PNG](https://products.aspose.app/slides/pt/conversion/pptx-to-png) e [PPT to PNG](https://products.aspose.app/slides/pt/conversion/ppt-to-png). Eles fornecem uma implementação ao vivo do processo descrito nesta página.
{{% /alert %}}

## **FAQ**

**Como posso exportar apenas uma forma específica (por exemplo, gráfico ou imagem) em vez de todo o slide?**

O Aspose.Slides oferece suporte a [geração de miniaturas para formas individuais](/slides/pt/python-net/create-shape-thumbnails/); você pode renderizar uma forma em uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim, mas [não compartilhe](/slides/pt/python-net/multithreading/) uma única instância de apresentação entre threads. Use uma instância separada por thread ou processo.

**Quais são as limitações da versão de avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e impõe [outras restrições](/slides/pt/python-net/licensing/) até que uma licença seja aplicada.