---
title: Criar apresentações em C++
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/cpp/create-presentation/
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
- C++
- Aspose.Slides
description: "Crie apresentações em C++ com Aspose.Slides — produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo demonstra como criar uma apresentação no Aspose.Slides, adicionar conteúdo simples a um slide e salvar o resultado como um arquivo.

## **Criar uma Apresentação PowerPoint**
Para adicionar uma linha simples a um slide selecionado da apresentação, siga os passos abaixo:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/cpp/class/aspose.slides.presentation).
2. Obtenha a referência de um slide usando seu Índice.
3. Adicione um AutoShape do tipo Linha usando o método AddAutoShape exposto pelo objeto Shapes.
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateNewPresentation-CreateNewPresentation.cpp" >}}

## **Perguntas Frequentes**

**Em que formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/cpp/save-presentation/), e exportar para [PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/), [XPS](/slides/pt/cpp/convert-powerpoint-to-xps/), [HTML](/slides/pt/cpp/convert-powerpoint-to-html/), [SVG](/slides/pt/cpp/convert-powerpoint-to-png/) e [imagens](/slides/pt/cpp/convert-powerpoint-to-png/), entre outros.

**Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX padrão?**

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/cpp/supported-file-formats/).

**Como controlo o tamanho/razão de aspecto do slide ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/cpp/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em que unidades são medidos os tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lido com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/cpp/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de streams puramente em memória.

**Posso criar/salvar apresentações em paralelo?**

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) a partir de [várias threads](/slides/pt/cpp/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como removo a marca d'água de avaliação e as limitações?**

[Aplique uma licença](/slides/pt/cpp/licensing/) uma vez por processo. O XML da licença deve permanecer sem alterações, e a configuração da licença deve ser sincronizada se várias threads estiverem envolvidas.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/cpp/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/cpp/presentation-via-vba/) e salvar arquivos com macro, como PPTM/PPSM.