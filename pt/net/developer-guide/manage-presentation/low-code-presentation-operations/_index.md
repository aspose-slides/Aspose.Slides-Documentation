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
- remover mestres de slide não usados
- remover layouts de slide não usados
- comprimir fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Use a API low-code do Aspose.Slides em .NET para converter e mesclar apresentações, iterar através do conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O namespace [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) fornece classes auxiliares estáticas para operações comuns de apresentação. Esses auxiliares embrulham fluxos de trabalho frequentemente usados do modelo de objetos em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares de low‑code são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão corresponde aos seus requisitos. Use o modelo de objetos completo do [Aspose.Slides](https://reference.aspose.com/slides/net/aspose.slides/) quando precisar de controle granular sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Assistente | Use para |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Executar uma ação para cada slide, forma, parágrafo ou trecho de texto. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Remover mestres/layouts não usados, reduzir dados de fontes incorporadas e comprimir imagens. |

## **Converter uma Apresentação**

Use [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação fonte, determina o formato necessário a partir do caminho de saída e grava o resultado.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) também fornece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objetos completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não seja exposta pelo auxiliar selecionado. Consulte [Converter Apresentação](/slides/pt/net/convert-presentation/) para fluxos de trabalho e opções específicas de formato.

## **Mesclar Apresentações**

Use [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

O auxiliar é apropriado quando todos os slides devem ser anexados a um único resultado sem selecionar ou remapear individualmente. Use o modelo de objetos completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou reconciliar diferentes tamanhos de slide. Consulte [Mesclar Apresentações](/slides/pt/net/merge-presentation/) para esses cenários.

## **Iterar pelos Elementos da Apresentação**

A classe [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) invoca um callback para cada tipo solicitado de elemento da apresentação. Ela evita loops de coleta aninhados e é conveniente para inspeção ou alterações de formatação em toda a apresentação.

O exemplo a seguir usa [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) para inspecionar os elementos correspondentes:

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

Por padrão, a travessia de formas e texto em toda a apresentação inclui slides normais, mestres e layouts. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleta diretos quando a ordem de travessia, saída antecipada, filtragem antes da invocação do callback ou controle detalhado de pai‑filho for importante.

## **Coletar Formas**

Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) quando precisar de uma coleção de todas as formas em uma apresentação ao invés de um callback para cada forma. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

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

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) em vez disso quando cada forma puder ser tratada imediatamente e você não precisar reter o resultado coletado.

## **Comprimir Conteúdo da Apresentação**

A classe [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) pode remover elementos estruturais não usados e reduzir dados de fontes incorporadas:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) remove slides de layout que não são referenciados por nenhum slide normal.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) remove mestres que não são mais utilizados.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) remove caracteres não usados de fontes incorporadas.

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

Remova layouts não usados antes dos mestres não usados, de modo que um mestre que deixe de ser referenciado após a limpeza de layouts também possa ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos mestres, layouts ou dados completos de fontes incorporadas originais posteriormente. Para mais detalhes, consulte [Slide Master](/slides/pt/net/slide-master/) e [Embedded Font](/slides/pt/net/embedded-font/).

### **Comprimir Toda a Apresentação**

Aspose.Slides for .NET 26.11 adiciona [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Ele combina a remoção de slides de layout/mestre não usados, a criação de subconjunto de fontes incorporadas para os caracteres usados e a compressão de imagens a 150 DPI. Use as operações individuais acima quando precisar controlar quais alterações são aplicadas.

Instale o [Aspose.Slides for .NET](/slides/pt/net/installation/) 26.11 ou posterior e forneça `input.pptx`. Salve em um arquivo separado: layouts removidos, caracteres de fonte e pixels de imagem recortados podem ser necessários para edição futura.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Comprimir Imagens em Resolução Escolhida**

Use [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) para processar imagens elegíveis sem também remover layouts ou criar subconjuntos de fontes. Este exemplo usa 96 DPI; selecione outro valor de [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) para atender às suas necessidades de saída.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Ambos os auxiliares usam o seguinte escopo de processamento de imagens:

| Conteúdo | Tratamento |
| --- | --- |
| Imagens raster e preenchimentos de forma com imagem em slides normais, mestres e layouts, incluindo formas agrupadas | Elegíveis para compressão. |
| Imagens já na resolução solicitada ou inferior | Não são ampliadas. Áreas recortadas ainda podem ser removidas. |
| Áreas de imagem recortadas | Pixels ocultos são removidos permanentemente e os deslocamentos de recorte são redefinidos. |
| Fundos de slide e preenchimentos de célula de tabela | Não são processados por esses auxiliares. |
| Internos de gráficos/SmartArt, GIF e formatos vetoriais como SVG, EMF e WMF | Fora do escopo documentado de compressão de imagens. |

Na versão 26.11, [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) evita o redimensionamento baseado em resolução de uma imagem não recortada, mas **não preserva pixels recortados**. Uma imagem recortada ainda pode ser reescrita com suas áreas ocultas removidas. Nenhum dos auxiliares expõe uma opção de preservação de recorte. Para controle individual, veja o [exemplo de compressão por imagem](/slides/pt/net/examples/optimization-batch/compression/).

Compare a aparência e o tamanho do arquivo de saída antes de substituir o original. A economia depende das imagens originais, seu tamanho exibido e do conteúdo não utilizado; a compressão não garante um arquivo menor. Consulte [Embedded Fonts](/slides/pt/net/embedded-font/) para as implicações da criação de subconjunto de fontes.

## **FAQ**

**Quando devo usar a API low‑code em vez do modelo de objetos completo?**

Use os auxiliares de low‑code quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objetos completo quando precisar selecionar slides específicos, controlar relações de mestres e layouts, inspecionar estados intermediários ou configurar comportamentos que o auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) requer que as apresentações de entrada estejam no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), e então mescle os arquivos convertidos.

**O ForEach processa slides de mestre, layout e notas?**

[ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) itera pelos slides normais da apresentação. As operações de [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) e [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) em toda a apresentação incluem slides normais, mestres e layouts por padrão. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual a diferença entre ForEach.Shape e Collect.Shapes?**

Use [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) para processar cada forma imediatamente por meio de um callback. Use [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) quando precisar de um resultado enumerável que possa ser retido, filtrado, contado ou percorrido várias vezes.

**O Compress sempre diminui o tamanho do arquivo da apresentação?**

Não necessariamente. A economia depende de layouts/mestres não usados, fontes incorporadas com caracteres não utilizados e imagens que se beneficiam da compressão. Os auxiliares [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) podem deixar o tamanho inalterado ou gerar um arquivo maior para algumas entradas. Compare tamanho e qualidade renderizada, e mantenha o original.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**

Não. Esses auxiliares operam no objeto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) carregado na memória. Após alterar elementos em um callback de [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) ou executar [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), chame [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) para gravar o resultado.

## **Artigos Relacionados**

- [Converter Apresentação](/slides/pt/net/convert-presentation/)
- [Mesclar Apresentações](/slides/pt/net/merge-presentation/)
- [Slide Master](/slides/pt/net/slide-master/)
- [Manage Text Box](/slides/pt/net/manage-textbox/)
- [Embedded Font](/slides/pt/net/embedded-font/)