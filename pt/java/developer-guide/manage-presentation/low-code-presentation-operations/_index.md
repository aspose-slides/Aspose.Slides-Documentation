---
title: Operações de Apresentação de Baixo Código em Java
linktitle: API de Baixo Código
type: docs
weight: 50
url: /pt/java/low-code-presentation-operations/
keywords:
- API de apresentação de baixo código
- converter apresentação
- mesclar apresentações
- iterar slides
- iterar formas
- iterar texto
- coletar formas
- comprimir apresentação
- remover slides mestres não usados
- remover slides de layout não usados
- compactar fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Use a API de baixo código Aspose.Slides em Java para converter e mesclar apresentações, iterar através do conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O pacote [com.aspose.slides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/) fornece classes auxiliares estáticas para operações comuns de apresentação. Esses auxiliares encapsulam fluxos de trabalho do modelo de objeto frequentemente usados em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares de baixo código são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos requisitos. Use o modelo de objeto completo da [Aspose.Slides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/) quando precisar de controle detalhado sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Auxiliar | Para que serve |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/java/com.aspose.slides/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/) | Executar uma ação para cada slide, forma, parágrafo ou trecho de texto. |
| [Collect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) | Remover mestres e layouts não usados e reduzir dados de fontes incorporadas. |

## **Converter uma apresentação**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/) também oferece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objeto completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não seja exposta pelo auxiliar selecionado. Consulte [Convert Presentation](/java/convert-presentation/) para fluxos de trabalho e opções específicas de formato.

## **Mesclar apresentações**

Use [Merger.process](https://reference.aspose.com/slides/pt/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

O auxiliar é adequado quando todos os slides devem ser anexados a um único resultado sem selecionar ou remapear individualmente. Use o modelo de objeto completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou reconciliar tamanhos de slide diferentes. Consulte [Merge Presentations](/java/merge-presentation/) para esses cenários.

## **Iterar pelos elementos da apresentação**

A classe [ForEach](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/) invoca um callback para cada tipo solicitado de elemento da apresentação. Ela evita loops de coleções aninhados e é conveniente para inspeção ou alterações de formatação em toda a apresentação.

O exemplo a seguir usa [ForEach.slide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) para inspecionar os elementos correspondentes:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

Por padrão, a travessia de formas e texto em toda a apresentação inclui slides normais, mestres e layouts. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleção diretos quando a ordem de travessia, saída antecipada, filtragem antes da invocação do callback ou controle detalhado de pai‑filho for importante.

## **Coletar formas**

Use [Collect.shapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando precisar de uma coleção de todas as formas em uma apresentação em vez de um callback para cada forma. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

Use [ForEach.shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) em vez disso quando cada forma puder ser tratada imediatamente e não for necessário reter o resultado coletado.

## **Comprimir conteúdo da apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) pode remover elementos estruturais não usados e reduzir dados de fontes incorporadas:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) remove slides de layout que nenhum slide normal referencia.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) remove slides mestres que não são mais usados.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) remove caracteres não usados de fontes incorporadas.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Remova layouts não usados antes dos mestres não usados, pois um mestre que se torne sem referência após a limpeza de layouts também pode ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos mestres, layouts ou dos dados completos de fontes incorporadas posteriormente. Para mais detalhes, veja [Slide Master](/java/slide-master/) e [Embedded Font](/java/embedded-font/).

## **FAQ**

**Quando devo usar a API de baixo código em vez do modelo de objeto completo?**

Use os auxiliares de baixo código quando uma operação padrão se aplicar a um arquivo ou apresentação completa e não exigir controle detalhado sobre elementos individuais. Use o modelo de objeto completo quando precisar selecionar slides específicos, controlar relações entre mestres e layouts, inspecionar o estado intermediário ou configurar comportamentos que o auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger.process](https://reference.aspose.com/slides/pt/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) requer apresentações de entrada no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert.autoByExtension](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), e então mescle os arquivos convertidos.

**O ForEach processa slides mestres, de layout e de notas?**

[ForEach.slide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itera pelos slides normais da apresentação. As operações de [ForEach.shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) incluem slides normais, mestres e layouts por padrão. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual é a diferença entre ForEach.shape e Collect.shapes?**

Use [ForEach.shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) para processar cada forma imediatamente por meio de um callback. Use [Collect.shapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando precisar de um resultado iterável que possa ser retido, filtrado, contado ou percorrido várias vezes.

**O Compress sempre diminui o tamanho do arquivo da apresentação?**

Nem sempre. O resultado depende de a apresentação conter layouts não usados, mestres não usados ou fontes incorporadas com caracteres não utilizados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) podem não reduzir o tamanho do arquivo.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**

Não. Esses auxiliares operam no objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) carregado na memória. Após alterar elementos em um callback de [ForEach](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/) ou executar [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/), chame [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-) para gravar o resultado.

## **Artigos relacionados**

- [Convert Presentation](/java/convert-presentation/)
- [Merge Presentations](/java/merge-presentation/)
- [Slide Master](/java/slide-master/)
- [Manage Text Box](/java/manage-textbox/)
- [Embedded Font](/java/embedded-font/)