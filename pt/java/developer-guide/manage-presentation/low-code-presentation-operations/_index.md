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
- remover slides mestre não utilizados
- remover slides de layout não utilizados
- comprimir fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Use a API de baixo código do Aspose.Slides em Java para converter e mesclar apresentações, iterar através do conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O pacote [com.aspose.slides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/) fornece classes auxiliares estáticas para operações comuns de apresentações. Esses auxiliares encapsulam fluxos de trabalho do modelo de objetos frequentemente usados em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares de baixo código são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objetos completo do [Aspose.Slides object model](https://reference.aspose.com/slides/pt/java/com.aspose.slides/) quando precisar de controle granular sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre os elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Auxiliar | Para que usar |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/java/com.aspose.slides/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/) | Executar uma ação para cada slide, forma, parágrafo ou parte de texto. |
| [Collect](https://reference.aspose.com/slides/pt/java/com.aspose.slides/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) | Remover mestres e layouts não utilizados e reduzir os dados de fontes incorporadas. |

## **Converter uma Apresentação**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/) também fornece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objetos completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não esteja exposta pelo auxiliar selecionado. Consulte [Convert Presentation](/slides/pt/java/convert-presentation/) para fluxos de trabalho e opções específicas de formato.

## **Mesclar Apresentações**

Use [Merger.process](https://reference.aspose.com/slides/pt/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) para combinar arquivos de apresentação completos em uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

O auxiliar é adequado quando todos os slides devem ser anexados a um único resultado sem selecioná‑los ou remapeá‑los individualmente. Use o modelo de objetos completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou conciliar diferentes tamanhos de slide. Consulte [Merge Presentations](/slides/pt/java/merge-presentation/) para esses cenários.

## **Iterar pelos Elementos da Apresentação**

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

Por padrão, a travessia de formas e texto em toda a apresentação inclui slides normais, mestres e de layout. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleção diretos quando a ordem de travessia, saída antecipada, filtragem antes da invocação do callback ou controle detalhado de pais‑filhos for importante.

## **Coletar Formas**

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

Use [ForEach.shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) em vez disso quando cada forma pode ser tratada imediatamente e você não precisa reter o resultado coletado.

## **Comprimir Conteúdo da Apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) pode remover elementos estruturais não utilizados e reduzir os dados de fontes incorporadas:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) remove slides de layout que nenhum slide normal referencia.
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) remove slides mestres que não são mais usados.
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) remove caracteres não utilizados de fontes incorporadas.

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

Remova layouts não utilizados antes dos mestres não utilizados, de modo que um mestre que fique sem referência após a limpeza de layouts também possa ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos mestres, layouts ou dos dados completos de fontes incorporadas originais mais tarde. Para mais detalhes, veja [Slide Master](/slides/pt/java/slide-master/) e [Embedded Font](/slides/pt/java/embedded-font/).

## **FAQ**

**Quando devo usar a API de baixo código em vez do modelo de objetos completo?**  
Use os auxiliares de baixo código quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objetos completo quando precisar selecionar slides específicos, controlar relacionamentos de mestres e layouts, inspecionar o estado intermediário ou configurar um comportamento que o auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**  
Não. [Merger.process](https://reference.aspose.com/slides/pt/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) requer que as apresentações de entrada estejam no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert.autoByExtension](https://reference.aspose.com/slides/pt/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-), e então mescle os arquivos convertidos.

**O ForEach processa slides mestres, de layout e de notas?**  
[ForEach.slide](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) percorre os slides de apresentação normais. As operações de [ForEach.shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-) e [ForEach.portion](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) incluem slides normais, mestres e de layout por padrão. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual é a diferença entre ForEach.shape e Collect.shapes?**  
Use [ForEach.shape](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) para processar cada forma imediatamente por meio de um callback. Use [Collect.shapes](https://reference.aspose.com/slides/pt/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) quando precisar de um resultado iterável que possa ser mantido, filtrado, contado ou percorrido várias vezes.

**O Compress sempre diminui o tamanho do arquivo da apresentação?**  
Não necessariamente. O resultado depende de a apresentação conter layouts não utilizados, mestres não utilizados ou fontes incorporadas com caracteres não usados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/) podem não reduzir o tamanho do arquivo.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**  
Não. Esses auxiliares operam sobre o objeto [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/) carregado na memória. Após alterar elementos em um callback de [ForEach](https://reference.aspose.com/slides/pt/java/com.aspose.slides/foreach/) ou executar [Compress](https://reference.aspose.com/slides/pt/java/com.aspose.slides/compress/), chame [Presentation.save](https://reference.aspose.com/slides/pt/java/com.aspose.slides/presentation/#save-java.lang.String-int-) para gravar o resultado.

## **Artigos Relacionados**

- [Convert Presentation](/slides/pt/java/convert-presentation/)
- [Merge Presentations](/slides/pt/java/merge-presentation/)
- [Slide Master](/slides/pt/java/slide-master/)
- [Manage Text Box](/slides/pt/java/manage-textbox/)
- [Embedded Font](/slides/pt/java/embedded-font/)