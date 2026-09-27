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
description: "Crie apresentações com Aspose.Slides—produza arquivos PPT, PPTX e ODP, aproveite o suporte a OpenDocument e salve-os programaticamente para resultados confiáveis."
---
## **Visão geral**

Este artigo mostra como criar uma apresentação no Aspose.Slides, adicionar uma caixa de texto ao seu primeiro slide e salvar o resultado como um arquivo.

Antes de começar, instale o pacote `aspose.slides.via.java` do npm, juntamente com o JDK, Python e as ferramentas de compilação C++ necessárias. Veja [Instalação](/slides/pt/nodejs-java/installation/).

## **Criar uma Apresentação PowerPoint**

Para criar uma apresentação e colocar uma caixa de texto em seu primeiro slide, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/). Uma nova apresentação já contém um slide vazio.  
2. Obtenha esse slide da [coleção de slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/getslides/) pelo seu índice, 0.  
3. Adicione um retângulo com o método [addAutoShape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shapecollection/addautoshape/) e defina seu texto com [setText](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/textframe/settext/).  
4. Salve a apresentação como um arquivo PPTX usando o método [save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/save/).  
5. Libere a apresentação com o método [dispose](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/dispose/), e finalize o processo.

```javascript
const asposeSlides = require("aspose.slides.via.java");

const presentation = new asposeSlides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(asposeSlides.ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save("hello.pptx", asposeSlides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Aspose.Slides roda em uma máquina virtual Java que mantém o Node.js em execução, portanto termine o processo explicitamente.
process.exit(0);
```

O canto superior esquerdo do retângulo está a 50 pontos da borda esquerda e 50 pontos da borda superior do slide, e o retângulo tem 400 pontos de largura e 100 pontos de altura. Salve o código como *hello.js* na pasta do seu projeto e execute `node hello.js`: ele salva *hello.pptx*, com um slide contendo esse retângulo e seu texto, na pasta atual.

O Aspose.Slides é executado em uma máquina virtual Java que o pacote `java` inicia dentro do processo Node.js. Essa máquina virtual impede que o Node.js saia por conta própria após a conclusão do script, portanto o exemplo termina com `process.exit(0)`.

Sem uma licença, o Aspose.Slides também adiciona uma marca d'água de avaliação a cada slide que salva; veja [Licenciamento](/slides/pt/nodejs-java/licensing/).

## **Perguntas frequentes**

### Em quais formatos posso salvar uma nova apresentação?

É possível salvar em [PPTX, PPT e ODP](/slides/pt/nodejs-java/save-presentation/), e exportar para [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), [XPS](/slides/pt/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/), [SVG](/slides/pt/nodejs-java/render-a-slide-as-an-svg-image/), e [imagens](/slides/pt/nodejs-java/convert-powerpoint-to-png/), entre outros.

### Posso começar a partir de um modelo (POTX/POTM) e salvar como um PPTX normal?

Sim. Carregue o modelo e salve no formato desejado; os formatos POTX/POTM/PPTM e semelhantes [são suportados](/slides/pt/nodejs-java/supported-file-formats/).

### Como controlo o tamanho/razão de aspecto do slide ao criar uma apresentação?

Defina o [tamanho do slide](/slides/pt/nodejs-java/slide-size/) (incluindo predefinições como 4:3 e 16:9 ou dimensões personalizadas) e escolha como o conteúdo deve ser dimensionado.

### Em quais unidades são medidos tamanhos e coordenadas?

Em pontos: 1 polegada equivale a 72 unidades.

### Como lidar com apresentações muito grandes (com muitos arquivos de mídia) para reduzir o uso de memória?

Use [BLOB management strategies](/slides/pt/nodejs-java/manage-blob/), limite o armazenamento em memória utilizando arquivos temporários e prefira fluxos de trabalho baseados em arquivos ao invés de streams puramente em memória.

### Posso criar/salvar apresentações em paralelo?

Não é possível operar na mesma instância de [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) a partir de [várias threads](/slides/pt/nodejs-java/multithreading/). Execute instâncias separadas e isoladas por thread ou processo.

### Como remover a marca d'água de avaliação e as limitações?

[Aplicar uma licença](/slides/pt/nodejs-java/licensing/) uma vez por processo. O XML da licença deve permanecer inalterado e a configuração da licença deve ser sincronizada se múltiplas threads estiverem envolvidas.

### Posso assinar digitalmente o PPTX que crio?

Sim. [Assinaturas digitais](/slides/pt/nodejs-java/digital-signature-in-powerpoint/) (adição e verificação) são suportadas para apresentações.

### Macros (VBA) são suportadas em apresentações criadas?

Sim. Você pode [criar/editar projetos VBA](/slides/pt/nodejs-java/presentation-via-vba/) e salvar arquivos com macros habilitadas como PPTM/PPSM.