---
title: Criar Apresentações em Python
linktitle: Criar Apresentação
type: docs
weight: 10
url: /pt/python-net/create-presentation/
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
- Python
- Aspose.Slides
description: "Crie apresentações PowerPoint em Python com Aspose.Slides — produza arquivos PPT, PPTX e ODP, aproveite o suporte OpenDocument e salve‑os programaticamente para obter resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação com Aspose.Slides for Python via .NET, adicionar uma forma com texto ao seu primeiro slide e salvar o resultado como um arquivo PPTX. A mesma API também salva apresentações como PPT e ODP, permitindo direcionar tanto os formatos PowerPoint quanto OpenDocument a partir de um único código, sem precisar do Microsoft Office. Uma breve FAQ ao final cobre perguntas comuns sobre formatos, modelos, dimensionamento de slides, unidades, uso de memória, threading, licenciamento, assinaturas digitais e suporte a VBA.

Antes de começar, instale o pacote do PyPI com `pip install aspose.slides`. Consulte [Instalação](/slides/pt/python-net/installation/) para as bibliotecas que Linux e macOS também precisam, e para o ambiente virtual que o Python do sistema do Debian e Ubuntu requer.

## **Criar uma Apresentação**

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.
1. Obtenha esse slide da coleção de [slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/slides/pt/) pelo índice 0.
1. Adicione um [AutoShape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/autoshape/) em forma de nuvem usando o método [add_auto_shape](https://reference.aspose.com/slides/pt/python-net/aspose.slides/shapecollection/add_auto_shape/) da coleção de [shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slide/shapes/) do slide, e defina seu [text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/textframe/text/).
1. Salve a apresentação como um arquivo PPTX usando o método [save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/).

```py
import aspose.slides as slides

# Instanciar a classe Presentation que representa um arquivo de apresentação.
with slides.Presentation() as presentation:
    # Obter o primeiro slide.
    slide = presentation.slides[0]

    # Adicionar uma autoforma do tipo CLOUD.
    auto_shape = slide.shapes.add_auto_shape(slides.ShapeType.CLOUD, 20, 20, 200, 80)
    auto_shape.text_frame.text = "Hello, Aspose!"

    # Salvar a apresentação como um arquivo PPTX.
    presentation.save("new_presentation.pptx", slides.export.SaveFormat.PPTX)
```

O canto superior esquerdo da nuvem está a 20 pontos da borda esquerda e a 20 pontos da borda superior do slide, e a nuvem tem 200 pontos de largura e 80 pontos de altura. A instrução `with` libera os recursos da apresentação ao final do bloco. O script salva *new_presentation.pptx* na pasta atual, com um slide que contém a nuvem e seu texto. Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide salvo; veja [Licenciamento](/slides/pt/python-net/licensing/).

O resultado:

![A nova apresentação](new_presentation.png)

## **Perguntas frequentes**

### Em quais formatos posso salvar uma nova apresentação?

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/python-net/save-presentation/), e exportar para [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/pt/python-net/convert-powerpoint-to-xps/), [HTML](/slides/pt/python-net/convert-powerpoint-to-html/), [SVG](/slides/pt/python-net/render-a-slide-as-an-svg-image/), e [imagens](/slides/pt/python-net/convert-powerpoint-to-png/), entre outros.

### Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX regular?

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e similares [são suportados](/slides/pt/python-net/supported-file-formats/).

### Como controlar o tamanho/razão de aspecto do slide ao criar uma apresentação?

Defina o [tamanho do slide](/slides/pt/python-net/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

### Em quais unidades são medidos tamanhos e coordenadas?

Em pontos: 1 polegada equivale a 72 unidades.

### Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?

Use [BLOB management strategies](/slides/pt/python-net/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos ao invés de streams puramente em memória.

### Posso criar/salvar apresentações em paralelo?

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) a partir de [várias threads](/slides/pt/python-net/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

### Como remover a marca d'água de avaliação e as limitações?

[Aplique uma licença](/slides/pt/python-net/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se múltiplas threads estiverem envolvidas.

### Posso assinar digitalmente o PPTX que crio?

Sim. [Assinaturas digitais](/slides/pt/python-net/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

### Macros (VBA) são suportadas em apresentações criadas?

Sim. Você pode [criar/editar projetos VBA](/slides/pt/python-net/presentation-via-vba/) e salvar arquivos habilitados para macros, como PPTM/PPSM.