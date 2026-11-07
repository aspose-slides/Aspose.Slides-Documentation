---
title: Comprimir apresentações
description: Reduza o tamanho da apresentação com compressão de imagens e salvamento de configurações.
type: docs
url: /pt/features/compress-presentations/
weight: 250
feature_id: compress-presentations
feature_group: operações
translationKey: slides-feature-compress-presentations
feature_catalogue_version: 3
feature_guides:
- /slides/net/image/
---
## **Visão geral**

Comprima imagens, remova áreas de imagem recortadas quando não forem mais necessárias e escolha as configurações de compressão da apresentação antes de salvar. Isso é útil para decks com fotografias grandes ou mídia repetida. A quantidade economizada depende do conteúdo e das configurações que você escolher.

## **Exemplo de uso**

Este exemplo em C# usa Aspose.Slides for .NET. Ele gera visivelmente um PNG gradiente de 1600 × 900 pixels, insere‑o em uma pequena moldura de imagem e salva *before.pptx*. Em seguida, compacta essa imagem para uma resolução alvo de 96 DPI e salva *compressed.pptx*. Compare os tamanhos dos arquivos e as pré‑visualizações: a economia depende da imagem de entrada e do tamanho exibido.

Para configuração, veja [Instalar Aspose.Slides for .NET](/slides/pt/net/installation/).

```csharp
using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using (var bitmap = new Bitmap(1600, 900))
{
    for (var y = 0; y < bitmap.Height; y++)
        for (var x = 0; x < bitmap.Width; x++)
            bitmap.SetPixel(x, y, Color.FromArgb(x % 256, y % 256, (x + y) % 256));
    bitmap.Save("large.png", System.Drawing.Imaging.ImageFormat.Png);
}
using var presentation = new Presentation();
var title = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 500, 60);
title.TextFrame.Text = "Photo";
var bytes = File.ReadAllBytes("large.png");
var image = presentation.Images.AddImage(bytes);
var picture = presentation.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 40, 120, 240, 135, image);
presentation.Save("before.pptx", SaveFormat.Pptx);
var compressed = picture.PictureFormat.CompressImage(true, 96f);
Console.WriteLine($"Picture compressed: {compressed}");
presentation.Save("compressed.pptx", SaveFormat.Pptx);
using var preview = presentation.Slides[0].GetImage(1f, 1f);
preview.Save("compressed.png", ImageFormat.Png);
```

## **Perguntas frequentes**

### **Este é um interruptor de otimização de arquivo inteiro?**

Aspose.Slides for .NET 26.11 adiciona [Compress.CompressPresentation](/slides/pt/net/low-code-presentation-operations/#compress-the-whole-presentation), que combina a remoção de layouts/mestres não usados, subconfiguração de fontes incorporadas e compressão de imagens de 150 DPI. Ele remove permanentemente áreas de imagem recortadas. Para processamento apenas de imagens, use Compress.CompressImages; para controle mais fino, mantenha o fluxo de trabalho por imagem acima. Esses novos ajudantes são específicos da versão .NET mencionada; verifique o guia correspondente para outros SDKs.

### **A compressão de imagens altera texto editável ou gráficos?**

A compressão de imagens tem como alvo os dados da imagem, não o texto editável ou os dados de gráficos. Revise as imagens, pois redimensionar ou recomprimir pode reduzir seus detalhes.

### **Como devo escolher uma resolução para imagens da apresentação?**

Escolha um alvo com base no tamanho da imagem exibida e no uso pretendido em tela ou impressão. Mantenha maior resolução para telas grandes, impressão e diagramas detalhados, e compare a saída renderizada antes de descartar o original.

## **Guias**

- [Otimizar o gerenciamento de imagens em apresentações no .NET](/slides/pt/net/image/)

Recurso relacionado: [Remover mestres, layouts e mídia não usados](/slides/pt/features/remove-unused-content/).

## Exemplos .NET executáveis

- [Reduzir tamanho da apresentação](/slides/pt/net/examples/optimization-batch/compression/)