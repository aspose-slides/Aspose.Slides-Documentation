---
title: Operações de Apresentação Low-Code no Android
linktitle: API Low-Code
type: docs
weight: 50
url: /pt/androidjava/low-code-presentation-operations/
keywords:
- API de apresentação low-code
- converter apresentação
- mesclar apresentações
- percorrer slides
- percorrer formas
- percorrer texto
- coletar formas
- compactar apresentação
- remover slides mestre não utilizados
- remover slides de layout não utilizados
- compactar fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- Android
- Java
- Aspose.Slides
description: "Use a API low-code do Aspose.Slides no Android para converter e mesclar apresentações, percorrer o conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O pacote [com.aspose.slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/) fornece classes auxiliares estáticas para operações comuns de apresentação. Esses auxiliares encapsulam fluxos de trabalho do modelo de objetos frequentemente usados em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares de low‑code são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objetos completo da [Aspose.Slides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/) quando precisar de controle fino sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Assistente | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/) | Executar uma ação para cada slide, forma, parágrafo ou porção de texto. |
| [Collect](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/) | Remover mestres e layouts não utilizados e reduzir dados de fontes incorporadas. |

## **Converter uma Apresentação**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/convert/) também fornece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objetos completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não seja exposta pelo auxiliar selecionado. Veja [Convert Presentation](/androidjava/convert-presentation/) para fluxos de trabalho e opções específicos de formato.

## **Mesclar Apresentações**

Use [Merger.process](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

O auxiliar é apropriado quando todos os slides devem ser anexados a um único resultado sem selecionar ou remapear individualmente. Use o modelo de objetos completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou reconciliar diferentes tamanhos de slide. Veja [Merge Presentations](/androidjava/merge-presentation/) para esses cenários.

## **Iterar Através dos Elementos da Apresentação**

A classe [ForEach](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/) invoca um callback para cada tipo solicitado de elemento da apresentação. Ela evita loops de coleta aninhados e é conveniente para inspeção ou alterações de formatação em toda a apresentação.

O exemplo a seguir usa [ForEach.slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) para inspecionar os respectivos elementos:

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

Por padrão, a travessia de formas e texto em toda a apresentação inclui slides normais, mestres e layouts. Sobrecargas com o parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleção direta quando a ordem de travessia, saída antecipada, filtragem antes da invocação do callback ou controle detalhado de pais‑filhos for importante.

## **Coletar Formas**

Use [Collect.shapes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando precisar de uma coleção de todas as formas em uma apresentação em vez de um callback para cada forma. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

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

Use [ForEach.shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) em vez disso quando cada forma puder ser tratada imediatamente e não for necessário reter o resultado coletado.

## **Comprimir Conteúdo da Apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/) pode remover elementos estruturais não utilizados e reduzir dados de fontes incorporadas:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) remove slides de layout que não são referenciados por nenhum slide normal.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) remove mestres que não são mais usados.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) remove caracteres não utilizados de fontes incorporadas.

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

Remova layouts não utilizados antes dos mestres não utilizados, de modo que um mestre que se torne desreferenciado após a limpeza de layouts também possa ser removido. Salve a apresentação otimizada em um novo arquivo caso precise dos mestres, layouts ou dos dados completos de fontes incorporadas originais mais tarde. Para mais detalhes, veja [Slide Master](/androidjava/slide-master/) e [Embedded Font](/androidjava/embedded-font/).

## **Perguntas Frequentes**

**Quando devo usar a API low‑code em vez do modelo de objetos completo?**

Use os auxiliares low‑code quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objetos completo quando precisar selecionar slides específicos, controlar relacionamentos de mestres e layouts, inspecionar estado intermediário ou configurar comportamento que o auxiliar não expõe.

**O Merger pode combinar apresentações em diferentes formatos de arquivo?**

Não. [Merger.process](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) exige que as apresentações de entrada estejam no mesmo formato. Converta primeiro os arquivos de entrada para um formato comum, por exemplo com [Convert.autoByExtension](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), e então mescle os arquivos convertidos.

**O ForEach processa slides de mestre, layout e notas?**

[ForEach.slide](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) itera pelos slides normais da apresentação. As operações [ForEach.shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) incluem, por padrão, slides normais, mestres e layouts. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual é a diferença entre ForEach.shape e Collect.shapes?**

Use [ForEach.shape](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) para processar cada forma imediatamente por meio de um callback. Use [Collect.shapes](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando precisar de um resultado iterável que possa ser retido, filtrado, contado ou percorrido várias vezes.

**O Compress sempre torna o arquivo da apresentação menor?**

Não necessariamente. O resultado depende de a apresentação conter layouts não utilizados, mestres não utilizados ou fontes incorporadas com caracteres não usados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/) podem não reduzir o tamanho do arquivo.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**

Não. Esses auxiliares operam sobre o objeto [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/) carregado na memória. Após alterar elementos em um callback de [ForEach](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/foreach/) ou executar [Compress](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/compress/), chame [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para gravar o resultado.

## **Artigos Relacionados**

- [Convert Presentation](/androidjava/convert-presentation/)
- [Merge Presentations](/androidjava/merge-presentation/)
- [Slide Master](/androidjava/slide-master/)
- [Manage Text Box](/androidjava/manage-textbox/)
- [Embedded Font](/androidjava/embedded-font/)