---
title: Operações de Apresentação Low-Code em JavaScript
linktitle: API Low-Code
type: docs
weight: 50
url: /pt/nodejs-java/low-code-presentation-operations/
keywords:
- API de apresentação low-code
- converter apresentação
- mesclar apresentações
- iterar slides
- iterar formas
- iterar texto
- coletar formas
- compactar apresentação
- remover slides mestres não usados
- remover slides de layout não usados
- compactar fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Use a API low-code do Aspose.Slides em JavaScript para converter e mesclar apresentações, iterar pelo conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O namespace `aspose.slides` fornece classes auxiliares estáticas para operações comuns de apresentação. Esses auxiliares encapsulam fluxos de trabalho do modelo de objeto frequentemente usados em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares de low‑code são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objeto completo do [Aspose.Slides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/) quando precisar de controle granular sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Auxiliar | Use para |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/) | Executar uma ação para cada slide, forma, parágrafo ou porção de texto. |
| [Collect](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/) | Remover mestres e layouts não usados e reduzir dados de fontes incorporadas. |

## **Converter uma apresentação**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/convert/#autoByExtension) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

aspose.slides.Convert.autoByExtension("input.pptx", "output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/convert/) também fornece métodos dedicados para saída PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objeto completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não esteja exposta pelo auxiliar selecionado. Consulte [Convert Presentation](/slides/pt/nodejs-java/convert-presentation/) para fluxos de trabalho e opções específicos de formato.

## **Mesclar apresentações**

Use [Merger.process](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/merger/#process) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const inputFiles = ["first.pptx", "second.pptx"];
aspose.slides.Merger.process(inputFiles, "merged.pptx");
```

O auxiliar é adequado quando todos os slides devem ser anexados a um único resultado sem precisar selecioná‑los ou remapeá‑los individualmente. Use o modelo de objeto completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou reconciliar tamanhos de slide diferentes. Consulte [Merge Presentations](/slides/pt/nodejs-java/merge-presentation/) para esses cenários.

## **Iterar pelos elementos da apresentação**

A classe [ForEach](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/) invoca um callback para cada tipo solicitado de elemento da apresentação. Ela evita loops aninhados de coleções e é conveniente para inspeção ou alterações de formatação em toda a apresentação. No Node.js, crie implementações das interfaces de callback com `java.newProxy`.

O exemplo a seguir usa [ForEach.slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#portion) para inspecionar os elementos correspondentes:

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slideCallback = java.newProxy("com.aspose.slides.ForEach$ForEachSlideCallback", {
        invoke: function (slide, index) {
            console.log(`Slide ${index}: ${slide.getShapes().size()} shapes`);
        }
    });
    aspose.slides.ForEach.slide(presentation, slideCallback);

    const shapeCallback = java.newProxy("com.aspose.slides.ForEach$ForEachShapeCallback", {
        invoke: function (shape, slide, index) {
            console.log(`Shape ${index} on ${slide.getClass().getSimpleName()}: ${shape.getName()}`);
        }
    });
    aspose.slides.ForEach.shape(presentation, shapeCallback);

    const paragraphCallback = java.newProxy("com.aspose.slides.ForEach$ForEachParagraphCallback", {
        invoke: function (paragraph, slide, index) {
            console.log(`Paragraph ${index} on ${slide.getClass().getSimpleName()}: ${paragraph.getText()}`);
        }
    });
    aspose.slides.ForEach.paragraph(presentation, paragraphCallback);

    const portionCallback = java.newProxy("com.aspose.slides.ForEach$ForEachPortionCallback", {
        invoke: function (portion, paragraph, slide, index) {
            console.log(`Portion ${index} on ${slide.getClass().getSimpleName()}: ${portion.getText()}`);
        }
    });
    aspose.slides.ForEach.portion(presentation, portionCallback);
} finally {
    presentation.dispose();
}
```

Por padrão, a travessia de formas e texto em toda a apresentação inclui slides normais, mestres e layouts. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleção diretos quando a ordem de travessia, saída antecipada, filtragem antes da invocação do callback ou controle detalhado de pai‑filho for importante.

## **Coletar formas**

Use [Collect.shapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/collect/#shapes) quando precisar de uma coleção de todas as formas em uma apresentação em vez de um callback para cada forma. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const shapes = aspose.slides.Collect.shapes(presentation);
    const iterator = shapes.iterator();

    while (iterator.hasNext()) {
        const shape = iterator.next();
        console.log(`${shape.getName()}: ${shape.getClass().getSimpleName()}`);
    }
} finally {
    presentation.dispose();
}
```

Use [ForEach.shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#shape) em vez disso quando cada forma puder ser tratada imediatamente e não for necessário reter o resultado coletado.

## **Comprimir conteúdo da apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/) pode remover elementos estruturais não usados e reduzir dados de fontes incorporadas:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) remove slides de layout que não são referenciados por nenhum slide normal.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides) remove mestres que não são mais usados.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/#compressEmbeddedFonts) remove caracteres não utilizados de fontes incorporadas.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    aspose.slides.Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Remova layouts não usados antes dos mestres não usados, pois um mestre que se tornar desreferenciado após a limpeza de layouts também pode ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos mestres, layouts ou dados completos de fontes incorporadas originais mais tarde. Para mais detalhes, consulte [Slide Master](/slides/pt/nodejs-java/slide-master/) e [Embedded Font](/slides/pt/nodejs-java/embedded-font/).

## **Perguntas frequentes**

**Quando devo usar a API low‑code em vez do modelo de objeto completo?**

Use os auxiliares low‑code quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objeto completo quando precisar selecionar slides específicos, controlar relacionamentos de mestres e layouts, inspecionar estado intermediário ou configurar um comportamento que o auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger.process](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/merger/#process) exige apresentações de entrada no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert.autoByExtension](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/convert/#autoByExtension), e então mescle os arquivos convertidos.

**O ForEach processa slides mestre, layout e de notas?**

[ForEach.slide](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#slide) itera pelos slides normais da apresentação. As operações de [ForEach.shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#portion) em toda a apresentação incluem slides normais, mestre e layout por padrão. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual é a diferença entre ForEach.shape e Collect.shapes?**

Use [ForEach.shape](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/#shape) para processar cada forma imediatamente por meio de um callback. Use [Collect.shapes](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/collect/#shapes) quando precisar de um resultado iterável que possa ser retido, filtrado, contado ou percorrido múltiplas vezes.

**O Compress sempre reduz o tamanho do arquivo da apresentação?**

Não necessariamente. O resultado depende de a apresentação conter ou não layouts não usados, mestres não usados ou fontes incorporadas com caracteres não utilizados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/) podem não diminuir o tamanho do arquivo.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**

Não. Esses auxiliares operam no objeto [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/) carregado na memória. Após alterar elementos em um callback de [ForEach](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/foreach/) ou executar [Compress](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/compress/), chame [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save) para gravar o resultado.

## **Artigos relacionados**

- [Convert Presentation](/slides/pt/nodejs-java/convert-presentation/)
- [Merge Presentations](/slides/pt/nodejs-java/merge-presentation/)
- [Slide Master](/slides/pt/nodejs-java/slide-master/)
- [Manage Text Box](/slides/pt/nodejs-java/manage-textbox/)
- [Embedded Font](/slides/pt/nodejs-java/embedded-font/)