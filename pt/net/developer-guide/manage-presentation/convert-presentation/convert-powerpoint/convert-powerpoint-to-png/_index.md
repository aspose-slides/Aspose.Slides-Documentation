---
title: Converter Slides do PowerPoint para PNG em .NET
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
description: "Converta apresentações PowerPoint em imagens PNG de alta qualidade rapidamente com Aspose.Slides para .NET, garantindo resultados precisos e automatizados."
---
## **Visão geral**

Este artigo explica como converter apresentações do PowerPoint em imagens PNG usando o Aspose.Slides. Ele mostra como carregar arquivos de apresentação em formatos como PPT, PPTX e ODP, renderizar os slides como imagens e salvar os resultados no formato PNG.

O artigo também demonstra como personalizar as imagens PNG geradas definindo valores de escala ou especificando a largura e a altura desejadas.

## **Converter PowerPoint para PNG**

Siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation).
2. Obtenha o objeto de slide da coleção [Presentation.Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/properties/slides) sob a interface [ISlide](https://reference.aspose.com/slides/pt/net/aspose.slides/islide).
3. Use o método [ISlide.GetImage](https://reference.aspose.com/slides/pt/net/aspose.slides/islide/getimage/) para obter a miniatura de cada slide.
4. Use o método [IPresentation.Save(String, SaveFormat, ISaveOptions](https://reference.aspose.com/slides/pt/net/aspose.slides.ipresentation/save/methods/5) para salvar a miniatura do slide no formato PNG.

Este código C# mostra como converter uma apresentação PowerPoint para PNG. O objeto Presentation pode carregar PPT, PPTX, ODP etc., e cada slide no objeto Presentation é convertido para o formato PNG ou outro formato de imagem.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage())
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Converter PowerPoint para PNG com Dimensões Personalizadas**

Se você quiser obter arquivos PNG em uma certa escala, pode definir os valores de `desiredX` e `desiredY`, que determinam as dimensões da miniatura resultante.

Este código em C# demonstra a operação descrita:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    float scaleX = 2f;
    float scaleY = 2f;
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(scaleX, scaleY))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Converter PowerPoint para PNG com Tamanho Personalizado**

Se você quiser obter arquivos PNG em um determinado tamanho, pode passar os argumentos preferidos `width` e `height` para `imageSize`.

Este código mostra como converter um PowerPoint para PNG especificando o tamanho das imagens:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Size size = new Size(960, 720);
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (IImage image = slide.GetImage(size))
        {
            image.Save($"slide_{index}.png", ImageFormat.Png);
        }
    }
}
```

## **Perguntas Frequentes**

**Como posso exportar apenas uma forma específica (por exemplo, gráfico ou imagem) em vez de todo o slide?**

O Aspose.Slides oferece suporte a [gerar miniaturas para formas individuais](/slides/pt/net/create-shape-thumbnails/); você pode renderizar uma forma para uma imagem PNG.

**A conversão paralela é suportada em um servidor?**

Sim, mas [não compartilhe](/slides/pt/net/multithreading/) uma única instância de apresentação entre threads. Use uma instância separada por thread ou processo.

**Quais são as limitações da versão de avaliação ao exportar para PNG?**

O modo de avaliação adiciona uma marca d'água às imagens de saída e impõe [outras restrições](/slides/pt/net/licensing/) até que uma licença seja aplicada.