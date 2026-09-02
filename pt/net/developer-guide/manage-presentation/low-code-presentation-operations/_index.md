---
title: Operações de Apresentação Low-Code em .NET
linktitle: API Low-Code
type: docs
weight: 50
url: /pt/net/low-code-presentation-operations/
keywords:
- API de apresentação low-code
- converter apresentação
- mesclar apresentações
- iterar slides
- iterar formas
- iterar texto
- coletar formas
- comprimir apresentação
- remover slides mestres não usados
- remover slides de layout não usados
- comprimir fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Use a API low-code do Aspose.Slides em .NET para converter e mesclar apresentações, iterar conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/) fornece classes auxiliares estáticas para operações comuns de apresentação. Esses auxiliares encapsulam fluxos de trabalho do modelo de objeto frequentemente usados em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares de low‑code são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objeto completo [Aspose.Slides](https://reference.aspose.com/slides/pt/net/aspose.slides/) quando precisar de controle granular sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Assistente | Para que usar |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/) | Executar uma ação para cada slide, forma, parágrafo ou porção de texto. |
| [Collect](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetida. |
| [Compress](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/) | Remover mestres e layouts não usados e reduzir os dados de fontes incorporadas. |

## **Converter uma Apresentação**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/convert/autobyextension/) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/convert/) também fornece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objeto completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não esteja exposta pelo auxiliar selecionado. Consulte [Convert Presentation](/net/convert-presentation/) para fluxos de trabalho e opções específicos de formato.

## **Mesclar Apresentações**

Use [Merger.Process](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/merger/process/) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

O auxiliar é adequado quando todos os slides devem ser acrescentados a um único resultado sem selecionar ou remapear individualmente. Use o modelo de objeto completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou reconciliar tamanhos de slide diferentes. Consulte [Merge Presentations](/net/merge-presentation/) para esses cenários.

## **Iterar pelos Elementos da Apresentação**

A classe [ForEach](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/) invoca um callback para cada tipo solicitado de elemento da apresentação. Ela evita loops aninhados de coleções e é conveniente para inspeção ou alterações de formatação em toda a apresentação.

O exemplo a seguir usa [ForEach.Slide](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/portion/) para inspecionar os elementos correspondentes:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Por padrão, a travessia de formas e texto em toda a apresentação inclui slides normais, mestres e layouts. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleção diretos quando a ordem de travessia, a saída antecipada, a filtragem antes da invocação do callback ou o controle detalhado de pai‑filho forem importantes.

## **Coletar Formas**

Use [Collect.Shapes](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/collect/shapes/) quando precisar de uma coleção de todas as formas em uma apresentação em vez de um callback para cada forma. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Use [ForEach.Shape](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/shape/) em vez disso quando cada forma puder ser tratada imediatamente e você não precisar reter o resultado coletado.

## **Comprimir Conteúdo da Apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/) pode remover elementos estruturais não usados e reduzir os dados de fontes incorporadas:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) remove slides de layout que nenhum slide normal referencia.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) remove mestres que não são mais usados.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/compressembeddedfonts/) remove caracteres não utilizados de fontes incorporadas.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Remova layouts não usados antes dos mestres não usados, pois um mestre que deixa de ser referenciado após a limpeza de layouts também pode ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos mestres, layouts ou dos dados completos de fontes incorporadas originais posteriormente. Para mais detalhes, consulte [Slide Master](/net/slide-master/) e [Embedded Font](/net/embedded-font/).

## **FAQ**

**Quando devo usar a API low‑code em vez do modelo de objeto completo?**

Use os auxiliares low‑code quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objeto completo quando precisar selecionar slides específicos, controlar relacionamentos de mestres e layouts, inspecionar estados intermediários ou configurar comportamentos que o auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger.Process](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/merger/process/) exige que as apresentações de entrada estejam no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert.AutoByExtension](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/convert/autobyextension/), e então mescle os arquivos convertidos.

**O ForEach processa slides mestre, layout e de notas?**

[ForEach.Slide](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/slide/) itera pelos slides normais da apresentação. As operações de [ForEach.Shape](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/portion/) em toda a apresentação incluem, por padrão, slides normais, mestres e layouts. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual é a diferença entre ForEach.Shape e Collect.Shapes?**

Use [ForEach.Shape](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/shape/) para processar cada forma imediatamente através de um callback. Use [Collect.Shapes](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/collect/shapes/) quando precisar de um resultado enumerável que possa ser retido, filtrado, contado ou percorrido múltiplas vezes.

**O Compress sempre diminui o tamanho do arquivo da apresentação?**

Nem sempre. O resultado depende de a apresentação conter ou não layouts não usados, mestres não usados ou fontes incorporadas com caracteres não utilizados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/) podem não reduzir o tamanho do arquivo.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**

Não. Esses auxiliares operam sobre o objeto [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) carregado na memória. Depois de alterar elementos em um callback de [ForEach](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/foreach/) ou executar [Compress](https://reference.aspose.com/slides/pt/net/aspose.slides.lowcode/compress/), chame [Presentation.Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) para gravar o resultado.

## **Artigos Relacionados**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)