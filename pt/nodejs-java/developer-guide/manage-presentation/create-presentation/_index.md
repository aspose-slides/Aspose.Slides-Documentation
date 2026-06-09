---
title: Criar apresentações em JavaScript
linktitle: Criar apresentação
type: docs
weight: 10
url: /pt/nodejs-java/create-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Crie apresentações com Aspose.Slides — produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve-os programaticamente para obter resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar conteúdo simples a um slide e salvar o resultado como um arquivo.

## **Criar Apresentação PowerPoint**

Para adicionar uma linha simples e plana a um slide selecionado da apresentação, siga os passos abaixo:

1. Crie uma instância da classe Presentation.
2. Obtenha a referência de um slide usando seu Índice.
3. Adicione um AutoShape do tipo Line usando o método addAutoShape exposto pelo objeto Shapes.
4. Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```javascript
// Instanciar um objeto Presentation que representa um arquivo de apresentação
var pres = new aspose.slides.Presentation();
try {
    // Obter o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    // Adicionar um autoshape do tipo linha
    slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 150, 300, 0);
    pres.save("NewPresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas frequentes**

**Em quais formatos posso salvar uma nova apresentação?**

Você pode salvar em [PPTX, PPT e ODP](/slides/pt/nodejs-java/save-presentation/), e exportar para [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/pt/nodejs-java/convert-powerpoint-to-png/), e [imagens](/slides/pt/nodejs-java/convert-powerpoint-to-png/), entre outros.

**Posso iniciar a partir de um modelo (POTX/POTM) e salvar como um PPTX regular?**

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/nodejs-java/supported-file-formats/).

**Como controlo o tamanho ou proporção do slide ao criar uma apresentação?**

Defina o [slide size](/slides/pt/nodejs-java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

**Em quais unidades são medidos os tamanhos e coordenadas?**

Em pontos: 1 polegada equivale a 72 unidades.

**Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?**

Use as [BLOB management strategies](/slides/pt/nodejs-java/manage-blob/), limite o armazenamento em memória usando arquivos temporários e prefira fluxos de trabalho baseados em arquivos em vez de fluxos puramente em memória.

**Posso criar/salvar apresentações em paralelo?**

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) a partir de [várias threads](/slides/pt/nodejs-java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

**Como remover a marca d'água de avaliação e as limitações?**

[Aplique uma licença](/slides/pt/nodejs-java/licensing/) uma vez por processo. O XML de licença deve permanecer inalterado, e a configuração da licença deve ser sincronizada se várias threads estiverem envolvidas.

**Posso assinar digitalmente o PPTX que crio?**

Sim. [Assinaturas digitais](/slides/pt/nodejs-java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

**Macros (VBA) são suportadas em apresentações criadas?**

Sim. Você pode [criar/editar projetos VBA](/slides/pt/nodejs-java/presentation-via-vba/) e salvar arquivos com macros habilitadas, como PPTM/PPSM.