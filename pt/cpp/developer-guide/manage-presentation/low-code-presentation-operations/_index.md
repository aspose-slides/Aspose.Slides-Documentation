---
title: Operações de Apresentação Low-Code em C++
linktitle: API Low-Code
type: docs
weight: 50
url: /pt/cpp/low-code-presentation-operations/
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
- C++
- Aspose.Slides
description: "Use a API low-code do Aspose.Slides em C++ para converter e mesclar apresentações, iterar pelo conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O namespace [Aspose::Slides::LowCode](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/) fornece classes auxiliares estáticas para operações comuns de apresentação. Esses auxiliares encapsulam fluxos de trabalho do modelo de objetos frequentemente usados em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar formas e remover conteúdo não utilizado com menos código.

Os auxiliares low‑code são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objetos completo [Aspose.Slides object model](https://reference.aspose.com/slides/pt/cpp/aspose.slides/) quando precisar de controle granulado sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relacionamentos entre elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Auxiliar | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/) | Executar uma ação para cada slide, forma, parágrafo ou porção de texto. |
| [Collect](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/) | Remover mestres e layouts não utilizados e reduzir dados de fontes incorporadas. |

## **Converter uma apresentação**

Use [Convert::AutoByExtension](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/convert/autobyextension/) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

A classe [Convert](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/convert/) também fornece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objetos completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não esteja exposta pelo auxiliar selecionado. Consulte [Convert Presentation](/cpp/convert-presentation/) para fluxos de trabalho e opções específicas de formato.

## **Mesclar apresentações**

Use [Merger::Process](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/merger/process/) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

O auxiliar é adequado quando todos os slides devem ser anexados a um único resultado sem selecionar ou remapeá‑los individualmente. Use o modelo de objetos completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou conciliar diferentes tamanhos de slide. Consulte [Merge Presentations](/cpp/merge-presentation/) para esses cenários.

## **Iterar pelos elementos da apresentação**

A classe [ForEach](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/) invoca um retorno de chamada para cada tipo solicitado de elemento da apresentação. Ela evita loops aninhados de coleta e é conveniente para inspeção ou alterações de formatação em toda a apresentação.

O exemplo a seguir usa [ForEach::Slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/paragraph/) e [ForEach::Portion](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/portion/) para inspecionar os elementos correspondentes:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

Por padrão, a travessia de formas e textos em toda a apresentação inclui slides normais, mestres e layouts. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleta diretos quando a ordem de travessia, saída antecipada, filtragem antes da invocação do retorno de chamada ou controle detalhado de pais‑filhos for importante.

## **Coletar formas**

Use [Collect::Shapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/collect/shapes/) quando precisar de uma coleção de todas as formas em uma apresentação em vez de um retorno de chamada para cada forma. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Use [ForEach::Shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/shape/) em vez disso quando cada forma puder ser tratada imediatamente e você não precisar reter o resultado coletado.

## **Comprimir conteúdo da apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/) pode remover elementos estruturais não utilizados e reduzir dados de fontes incorporadas:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) remove slides de layout que não são referenciados por nenhum slide normal.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) remove mestres que não são mais usados.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) remove caracteres não utilizados de fontes incorporadas.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Remova layouts não utilizados antes dos mestres não utilizados, de modo que um mestre que se torne desreferenciado após a limpeza dos layouts também possa ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos mestres, layouts ou dados completos de fontes incorporadas originais posteriormente. Para mais detalhes, veja [Slide Master](/cpp/slide-master/) e [Embedded Font](/cpp/embedded-font/).

## **Perguntas frequentes**

**Quando devo usar a API low‑code em vez do modelo de objetos completo?**

Use os auxiliares low‑code quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objetos completo quando precisar selecionar slides específicos, controlar relacionamentos de mestres e layouts, inspecionar estado intermediário ou configurar comportamentos que o auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger::Process](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/merger/process/) requer que as apresentações de entrada estejam no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert::AutoByExtension](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/convert/autobyextension/), e então mescle os arquivos convertidos.

**O ForEach processa slides de mestre, layout e notas?**

[ForEach::Slide](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/slide/) itera pelos slides de apresentação normais. As operações [ForEach::Shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/paragraph/) e [ForEach::Portion](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/portion/) em toda a apresentação incluem, por padrão, slides normais, de mestre e de layout. Use suas sobrecargas com `includeNotes` definido como `true` para incluir slides de notas.

**Qual a diferença entre ForEach::Shape e Collect::Shapes?**

Use [ForEach::Shape](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/shape/) para processar cada forma imediatamente através de um retorno de chamada. Use [Collect::Shapes](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/collect/shapes/) quando precisar de um resultado enumerável que possa ser retido, filtrado, contado ou percorrido múltiplas vezes.

**O Compress sempre reduz o tamanho do arquivo da apresentação?**

Não necessariamente. O resultado depende de a apresentação conter ou não layouts não utilizados, mestres não utilizados ou fontes incorporadas com caracteres não utilizados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/) podem não diminuir o tamanho do arquivo.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**

Não. Esses auxiliares operam sobre o objeto [Presentation](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/) carregado na memória. Após modificar elementos em um retorno de chamada de [ForEach](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/foreach/) ou executar [Compress](https://reference.aspose.com/slides/pt/cpp/aspose.slides.lowcode/compress/), chame [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) para gravar o resultado.

## **Artigos relacionados**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)