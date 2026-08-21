---
title: Operações de Apresentação de Baixo Código em PHP
linktitle: API de Baixo Código
type: docs
weight: 50
url: /pt/php-java/low-code-presentation-operations/
keywords:
- API de apresentação de baixo código
- converter apresentação
- mesclar apresentações
- iterar slides
- iterar formas
- iterar texto
- coletar formas
- compactar apresentação
- remover mestres de slide não utilizados
- remover layouts de slide não utilizados
- compactar fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Use a API de baixo código do Aspose.Slides em PHP para converter e mesclar apresentações, iterar o conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O namespace [aspose.slides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/) fornece classes auxiliares estáticas para operações comuns de apresentação. Esses auxiliares encapsulam fluxos de trabalho frequentemente usados do modelo de objetos em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares de baixo código são mais úteis quando a operação se aplica a um arquivo ou apresentação completa e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objetos completo [Aspose.Slides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/) quando precisar de controle detalhado sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Auxiliar | Para que serve |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/php-java/aspose.slides/convert/) | Converte uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/php-java/aspose.slides/merger/) | Combina arquivos de apresentação completos do mesmo formato. |
| [ForEach_](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/) | Executa uma função de retorno para cada slide, forma, parágrafo ou fragmento de texto. |
| [Collect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/collect/) | Recupera formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/) | Remove mestres e layouts não utilizados e reduz dados de fontes incorporadas. |

## **Converter uma apresentação**

Use [Convert::autoByExtension](https://reference.aspose.com/slides/pt/php-java/aspose.slides/convert/#autoByExtension) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/pt/php-java/aspose.slides/convert/) também oferece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objetos completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não esteja exposta pelo auxiliar selecionado. Consulte [Convert Presentation](/php-java/convert-presentation/) para fluxos de trabalho e opções específicas de formato.

## **Mesclar apresentações**

Use [Merger::process](https://reference.aspose.com/slides/pt/php-java/aspose.slides/merger/#process) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

O auxiliar é apropriado quando todos os slides devem ser anexados a um resultado único sem selecionar ou remapear individualmente. Use o modelo de objetos completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou conciliar tamanhos de slide diferentes. Consulte [Merge Presentations](/php-java/merge-presentation/) para esses cenários.

## **Iterar pelos elementos da apresentação**

A classe [ForEach_](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/) invoca uma função de retorno para cada tipo solicitado de elemento da apresentação. Ela evita loops de coleta aninhados e é conveniente para inspeção ou alterações de formatação em toda a apresentação.

O exemplo a seguir usa [ForEach_::slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#paragraph) e [ForEach_::portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#portion) para inspecionar os elementos correspondentes:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Por padrão, a travessia de formas e texto em toda a apresentação inclui slides normais, mestres e layouts. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleta diretos quando a ordem de travessia, saída antecipada, filtragem antes da invocação da função de retorno ou controle detalhado de hierarquia pai‑filho for importante.

## **Coletar formas**

Use [Collect::shapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/collect/#shapes) quando precisar de uma coleção de todas as formas em uma apresentação em vez de uma função de retorno para cada forma. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Use [ForEach_::shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#shape) em vez disso quando cada forma puder ser tratada imediatamente e não for necessário reter o resultado coletado.

## **Compactar o conteúdo da apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/) pode remover elementos estruturais não utilizados e reduzir dados de fontes incorporadas:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) remove slides de layout que nenhum slide normal referencia.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#removeUnusedMasterSlides) remove mestres que não são mais usados.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/#compressEmbeddedFonts) remove caracteres não utilizados de fontes incorporadas.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Remova layouts não utilizados antes dos mestres não utilizados, de modo que um mestre que se torne sem referência após a limpeza de layouts também possa ser removido. Salve a apresentação otimizada em um novo arquivo caso precise dos mestres, layouts ou dados completos de fontes incorporadas posteriormente. Para mais detalhes, consulte [Slide Master](/php-java/slide-master/) e [Embedded Font](/php-java/embedded-font/).

## **Perguntas frequentes**

**Quando devo usar a API de baixo código em vez do modelo de objetos completo?**

Use os auxiliares de baixo código quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objetos completo quando precisar selecionar slides específicos, controlar relacionamentos entre mestres e layouts, inspecionar estado intermediário ou configurar comportamentos que o auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger::process](https://reference.aspose.com/slides/pt/php-java/aspose.slides/merger/#process) exige que as apresentações de entrada estejam no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert::autoByExtension](https://reference.aspose.com/slides/pt/php-java/aspose.slides/convert/#autoByExtension), e então mescle os arquivos convertidos.

**O ForEach_ processa slides de mestre, layout e notas?**

[ForEach_::slide](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#slide) itera pelos slides normais da apresentação. As operações de [ForEach_::shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#paragraph) e [ForEach_::portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#portion) em toda a apresentação incluem, por padrão, slides normais, mestres e layouts. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual a diferença entre ForEach_::shape e Collect::shapes?**

Use [ForEach_::shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_/#shape) para processar cada forma imediatamente por meio de uma função de retorno. Use [Collect::shapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/collect/#shapes) quando precisar de um resultado iterável que possa ser retido, filtrado, contado ou percorrido várias vezes.

**O Compress sempre reduz o tamanho do arquivo da apresentação?**

Não necessariamente. O resultado depende de a apresentação conter layouts não usados, mestres não usados ou fontes incorporadas com caracteres não utilizados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/) podem não diminuir o tamanho do arquivo.

**As alterações feitas por ForEach_ ou Compress são salvas automaticamente?**

Não. Esses auxiliares operam sobre o objeto [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) carregado na memória. Após alterar elementos em um retorno de chamada de [ForEach_](https://reference.aspose.com/slides/pt/php-java/aspose.slides/foreach_) ou executar [Compress](https://reference.aspose.com/slides/pt/php-java/aspose.slides/compress/), chame [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) para gravar o resultado.

## **Artigos relacionados**

- [Convert Presentation](/php-java/convert-presentation/)
- [Merge Presentations](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Manage Text Box](/php-java/manage-textbox/)
- [Embedded Font](/php-java/embedded-font/)