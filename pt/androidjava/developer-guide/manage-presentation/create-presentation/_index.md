---
title: Criar apresentações no Android
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Crie apresentações em Java com Aspose.Slides para Android—produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve-os programaticamente para obter resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar conteúdo simples a um slide e salvar o resultado como um arquivo. Também demonstra como criar e salvar uma nova apresentação, abrir uma apresentação existente em um formato suportado e salvá‑la em outro formato.

## **Criar uma Apresentação PowerPoint**
Para adicionar uma linha simples a um slide selecionado da apresentação, siga as etapas abaixo:

1. Criar uma instância da classe Presentation.
1. Obter a referência de um slide usando seu Índice.
1. Adicionar um AutoShape do tipo Linha usando o método addAutoShape exposto pelo objeto Shapes.
1. Gravar a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```java
// Instanciar um objeto Presentation que representa um arquivo de apresentação
Presentation pres = new Presentation();
try {
    // Obter o primeiro slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adicionar um autoshape do tipo linha
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT, e ODP](/slides/pt/androidjava/save-presentation/), e exportar para [PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/pt/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/pt/androidjava/convert-powerpoint-to-html/), [SVG](/slides/pt/androidjava/convert-powerpoint-to-png/), e [imagens](/slides/pt/androidjava/convert-powerpoint-to-png/), entre outros.

**Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX comum?**

Sim. Carregue o modelo e salve no formato desejado; formatos POTX/POTM/PPTM e similares [são suportados](/slides/pt/androidjava/supported-file-formats/).

**Como controlar o tamanho/razão de aspecto do slide ao criar uma apresentação?**

Defina o [tamanho do slide](/slides/pt/androidjava/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em que unidades são medidos tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use [estratégias de gerenciamento de BLOB](/slides/pt/androidjava/manage-blob/), limite o armazenamento em memória aproveitando arquivos temporários e prefira fluxos baseados em arquivos em vez de streams puramente em memória.

**Posso criar/salvar apresentações em paralelo?**

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) a partir de [múltiplas threads](/slides/pt/androidjava/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como remover a marca d'água de avaliação e as limitações?**

[Aplice uma licença](/slides/pt/androidjava/licensing/) uma vez por processo. O XML da licença deve permanecer sem alterações, e a configuração da licença deve ser sincronizada se houver múltiplas threads.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/androidjava/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/androidjava/presentation-via-vba/) e salvar arquivos habilitados para macro, como PPTM/PPSM.