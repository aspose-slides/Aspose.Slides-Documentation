---
title: Converter slides do PowerPoint para PNG em .NET
linktitle: PowerPoint para PNG
type: docs
weight: 30
url: /pt/net/convert-powerpoint-to-png/
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
- .NET
- C#
- Aspose.Slides
description: "Converter apresentações PowerPoint em imagens PNG de alta qualidade rapidamente com Aspose.Slides para .NET, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter slides de apresentação em imagens PNG usando Aspose.Slides para .NET. Você pode carregar apresentações em formatos como PPT, PPTX e ODP, renderizar cada slide e salvá‑lo como uma imagem PNG separada.

Os exemplos abaixo demonstram como renderizar miniaturas, definir fatores de escala, especificar as dimensões de saída em pixels e escolher um estilo de renderização de gradiente.

## **Converter PowerPoint para PNG**

Carregue uma apresentação com a classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e acesse seus slides através da coleção [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/). O exemplo renderiza cada slide com [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) sem parâmetros para criar uma miniatura. Em seguida, chama [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) com [ImageFormat.Png](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) para salvar cada slide renderizado como uma imagem PNG.

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage();
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

{{% alert color="info" title="Note" %}}
A sobrecarga sem parâmetros de [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) renderiza com escala de 0,2. Por exemplo, um slide de 720 × 540 pontos produz uma miniatura de 144 × 108 pixels. Para controlar as dimensões de saída, use as sobrecargas com fatores de escala ou um tamanho de imagem explícito mostrados abaixo.
{{% /alert %}}

## **Converter PowerPoint para PNG com Dimensões Personalizadas**

Passe fatores de escala horizontal e vertical para [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) para controlar as dimensões renderizadas. Neste exemplo, ambos os fatores são 2, de modo que um slide de 720 × 540 pontos produz uma imagem de 1440 × 1080 pixels. Fatores de escala iguais preservam a proporção do slide. Cada imagem é salva em formato PNG com [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/).

```cs
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var scaleX = 2f;
var scaleY = scaleX;

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Para especificar as dimensões de saída em pixels, passe um tamanho para [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/) em vez de fatores de escala. Este exemplo renderiza cada slide em 960 × 720 pixels e salva o resultado com [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Escolha dimensões que correspondam à proporção do slide para evitar alongamento da imagem.

```cs
using System.Drawing;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var imageSize = new Size(960, 720);

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(imageSize);
    image.Save($"slide_{index}.png", ImageFormat.Png);
}
```

## **Escolher um Estilo de Renderização de Gradiente**

Suponha que um slide contenha preenchimentos em gradiente, mas as transições no PNG exportado pareçam mais claras ou diferentes do que você vê no PowerPoint. Você pode usar a propriedade [GradientStyle](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/gradientstyle/) de [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/) para escolher como os gradientes são renderizados.

Faça download de [gradient-styles.pptx](gradient-styles.pptx) e coloque-o no diretório de trabalho da aplicação. Seu primeiro slide contém dois gradientes lineares: ciano para laranja na parte superior e azul para amarelo na parte inferior. Cada gradiente tem duas paradas, em 0 % e 100 %.

O exemplo a seguir carrega esta apresentação e renderiza o mesmo primeiro slide em ambos os modos com [ISlide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/islide/getimage/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("gradient-styles.pptx");
var slide = presentation.Slides[0];

var gradientStyles = new[] { GradientStyle.Default, GradientStyle.PowerPointUI };
foreach (var style in gradientStyles)
{
    var options = new RenderingOptions { GradientStyle = style };
    using var image = slide.GetImage(options, 1f, 1f);
    image.Save($"gradient-{style}.png", ImageFormat.Png);
}
```

As imagens abaixo mostram a saída do mesmo slide, com ambos os gradientes em cada imagem:

| Default | PowerPointUI |
| --- | --- |
| ![Gradientes ciano-para-laranja e azul-para-amarelo renderizados com Default](gradient-Default.png) | ![Os mesmos gradientes renderizados com PowerPointUI](gradient-PowerPointUI.png) |

Neste exemplo, `Default` produz cores intermediárias mais claras, enquanto `PowerPointUI` produz cores intermediárias mais escuras. A diferença depende das cores e das paradas no gradiente.

Escolha `Default` quando a saída padrão do Aspose.Slides atender às suas necessidades. Experimente `PowerPointUI` quando sua prioridade for igualar a aparência no PowerPoint. Compare ambas as saídas com o resultado desejado; nenhum modo é universalmente preferível.

## **Perguntas frequentes**

**Como posso exportar uma forma específica, como um gráfico ou uma imagem, em vez de todo o slide?**

Aspose.Slides suporta [gerando miniaturas para formas individuais](/slides/pt/net/create-shape-thumbnails/), permitindo renderizar uma forma como imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim. Use uma instância de apresentação separada para cada thread ou processo; [não compartilhe uma única instância entre threads](/slides/pt/net/multithreading/).

**Quais são as limitações da avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e aplica [outras restrições](/slides/pt/net/licensing/) até que uma licença seja aplicada.