---
title: Criar Apresentações em .NET
linktitle: Criar Apresentação
type: docs
weight: 10
url: /pt/net/create-presentation/
keywords:
- criar apresentação
- nova apresentação
- criar PPT
- novo PPT
- criar PPTX
- novo PPTX
- criar ODP
- novo ODP
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Crie apresentações em .NET com Aspose.Slides — produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão Geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar uma caixa de texto ao seu primeiro slide e salvar o resultado como um arquivo. Também demonstra como criar e salvar uma apresentação vazia e como abrir uma apresentação existente em um formato suportado e salvá‑la em outro formato. Uma breve FAQ ao final aborda perguntas comuns sobre formatos, modelos, tamanho de slides, unidades, uso de memória, multithreading, licenciamento, assinaturas digitais e suporte a VBA.

Antes de começar, adicione o Aspose.Slides ao seu projeto via NuGet. Consulte [Installation](/slides/pt/net/installation/) para o pacote a ser usado no Windows, Linux e macOS.

## **Criar uma Apresentação PowerPoint**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.
1. Obtenha esse slide da coleção [Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/slides/pt/) pelo índice 0.
1. Adicione um retângulo com o método [AddAutoShape](https://reference.aspose.com/slides/pt/net/aspose.slides/ishapecollection/addautoshape/) e defina seu [text](https://reference.aspose.com/slides/pt/net/aspose.slides/itextframe/text/).
1. Salve a apresentação como um arquivo PPTX com o método [Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/).

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

O canto superior esquerdo do retângulo está a 50 pontos da borda esquerda e 50 pontos da borda superior do slide, e o retângulo tem 400 pontos de largura e 100 pontos de altura. O arquivo salvo contém um slide com esse retângulo e seu texto. Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide salvo; veja [Licensing](/slides/pt/net/licensing/).

## **Criar e Salvar uma Apresentação**

<a name="csharp-create-save-presentation"></a>

Para criar uma apresentação vazia e salvá‑la, crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e salve‑a em qualquer formato da enumeração [SaveFormat](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveformat/). O resultado é uma apresentação com um slide vazio.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Abrir e Salvar uma Apresentação**

<a name="csharp-open-save-presentation"></a>

Para converter uma apresentação de um formato para outro, abra‑a passando seu caminho ao construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/presentation/), então salve‑a no formato de destino. O Aspose.Slides detecta o formato de entrada, como PPT, PPTX ou ODP, a partir do próprio arquivo.

O exemplo abaixo espera uma apresentação OpenDocument chamada *Sample.odp* no diretório de trabalho e a salva como PPTX.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Sample.odp");
presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
```

## **Perguntas Frequentes**

### Quais formatos posso salvar uma nova apresentação?

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/net/save-presentation/), e exportar para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), [XPS](/slides/pt/net/convert-powerpoint-to-xps/), [HTML](/slides/pt/net/convert-powerpoint-to-html/), [SVG](/slides/pt/net/render-a-slide-as-an-svg-image/), e [imagens](/slides/pt/net/convert-powerpoint-to-png/), entre outros.

### Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX comum?

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/net/supported-file-formats/).

### Como controlo o tamanho/ratio de aspecto do slide ao criar uma apresentação?

Defina o [tamanho do slide](/slides/pt/net/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

### Em quais unidades são medidos tamanho e coordenadas?

Em pontos: 1 polegada equivale a 72 unidades.

### Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?

Use [estratégias de gerenciamento de BLOB](/slides/pt/net/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de streams puramente em memória.

### Posso criar/salvar apresentações em paralelo?

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/net/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

### Como remover a marca d'água de avaliação e as limitações?

[Aplique uma licença](/slides/pt/net/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se múltiplas threads estiverem envolvidas.

### Posso assinar digitalmente o PPTX que crio?

Sim. [Assinaturas digitais](/slides/pt/net/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

### Macros (VBA) são suportadas em apresentações criadas?

Sim. Você pode [criar/editar projetos VBA](/slides/pt/net/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.