---
title: Compactar apresentações
description: Reduzir o tamanho da apresentação compactando imagens e removendo conteúdo não usado.
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

Compacte imagens, remova áreas recortadas das imagens quando não forem mais necessárias e escolha as configurações de compactação da apresentação antes de salvar. Isso é útil para apresentações com fotografias grandes ou mídia repetida. A quantidade economizada depende do conteúdo e das configurações que você escolher.

## **Exemplo de uso**

Este exemplo em C# carrega `input.pptx`, compacta a apresentação e a salva como `compressed.pptx`.

Use Aspose.Slides for .NET 26.11 ou posterior. Para configuração, veja [Instalar Aspose.Slides for .NET](/slides/pt/net/installation/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```


<!-- visual-explanation:compress-presentations:start -->
[![Renderizações de imagem com escala idêntica antes e depois da compactação, seguidas por barras de tamanho de arquivo PPTX medidas e dimensões da imagem armazenada.](visual-compress-presentations-1adbf86268a5.svg)](visual-compress-presentations-1adbf86268a5.svg)

*Medido em uma única fixture sintética de grade de detalhes: 584.030 → 128.323 bytes. Ambas as renderizações usam a mesma escala e quadro de 252 × 336 pontos. A compactação remove as margens recortadas e reduz a imagem armazenada para 525 × 700 pixels; a economia de tamanho depende da entrada.*
<!-- visual-explanation:compress-presentations:end -->

## **Perguntas frequentes**

### **Este é um interruptor de otimização de arquivo inteiro?**

Aspose.Slides for .NET 26.11 adiciona [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/), que combina remoção de layout/master não usados, subconjunto de fontes incorporadas e compactação de imagens de 150 DPI. Ele remove permanentemente as áreas recortadas das imagens. Para processamento apenas de imagens, use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/); para controle mais fino, veja o [exemplo de compactação de imagem individual](/slides/pt/net/examples/optimization-batch/compression/). Desde a versão 26.11, a mesma chamada de apresentação inteira também está disponível em Java, Node.js via Java, Python via .NET e C++. O exemplo e os links nesta página são para .NET.

### **A compactação de imagens altera texto editável ou gráficos?**

A compactação de imagens tem como alvo os dados da imagem, não o texto editável ou os dados de gráficos. Revise as imagens, pois redimensionar ou recomprimir pode reduzir seu detalhe.

### **Como devo escolher a resolução para imagens de apresentação?**

Escolha um alvo com base no tamanho da imagem exibida e no uso pretendido em tela ou impressão. Mantenha mais resolução para telas grandes, impressão e diagramas detalhados, e compare o resultado renderizado antes de descartar o original.

## **Guias**

- [Compactar a apresentação inteira em .NET](/slides/pt/net/low-code-presentation-operations/#compress-the-whole-presentation)
- [Otimizar o gerenciamento de imagens em apresentações em .NET](/slides/pt/net/image/)

Recurso relacionado: [Remover mestres, layouts e mídia não usados](/slides/pt/features/remove-unused-content/).

## Exemplos .NET executáveis

- [Reduzir o tamanho da apresentação](/slides/pt/net/examples/optimization-batch/compression/)