---
title: Compactar apresentações
description: Reduza o tamanho da apresentação comprimindo imagens e removendo conteúdo não utilizado.
type: docs
url: /pt/features/compress-presentations/
weight: 250
feature_id: compactar-apresentacoes
feature_group: operacoes
translationKey: slides-feature-compactar-apresentacoes
feature_catalogue_version: 3
feature_guides:
- /slides/net/low-code-presentation-operations/
- /slides/net/image/
---
## **Visão geral**

Comprima imagens, remova áreas recortadas de imagens quando não forem mais necessárias e escolha as configurações de compressão da apresentação antes de salvar. Isso é útil para apresentações com fotografias grandes ou mídia repetida. A quantidade economizada depende do conteúdo e das configurações que você escolher.

## **Exemplo de uso**

Este exemplo em C# carrega `input.pptx`, comprime a apresentação e a salva como `compressed.pptx`.

Use Aspose.Slides for .NET 26.11 ou posterior. Para configuração, veja [Install Aspose.Slides for .NET](/slides/pt/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

## **Perguntas frequentes**

### **Este é um interruptor único de otimização de todo o arquivo?**

Aspose.Slides for .NET 26.11 adiciona [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), que combina a remoção de layouts/mestres não utilizados, a subconfiguração de fontes incorporadas e a compressão de imagens a 150 DPI. Ele remove permanentemente as áreas recortadas das imagens. Para processamento apenas de imagens, use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); para controle mais fino, veja o [exemplo de compressão de imagem individual](/slides/pt/net/examples/optimization-batch/compression/). Esses novos auxiliares são específicos da versão .NET mencionada; verifique o guia correspondente para outros SDKs.

### **A compressão de imagens altera texto ou gráficos editáveis?**

A compressão de imagens tem como alvo os dados da imagem, não o texto editável ou os dados de gráficos. Revise as imagens, pois redimensioná-las ou recomprimí‑las pode reduzir seus detalhes.

### **Como devo escolher uma resolução para as imagens da apresentação?**

Escolha um alvo com base no tamanho da imagem exibida e no uso pretendido para tela ou impressão. Mantenha mais resolução para telas grandes, impressão e diagramas detalhados, e compare a saída renderizada antes de descartar o original.

## **Guias**

- [Compactar a apresentação inteira em .NET](/slides/pt/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Otimizar o gerenciamento de imagens em apresentações em .NET](/slides/pt/net/image/)

Recurso relacionado: [Remover mestres, layouts e mídia não utilizados](/slides/pt/features/remove-unused-content/).

## Executáveis de exemplo .NET

- [Reduzir o tamanho da apresentação](/slides/pt/net/examples/optimization-batch/compression/)