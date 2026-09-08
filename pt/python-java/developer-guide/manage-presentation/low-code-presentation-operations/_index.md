---
title: Operações Low-Code de Apresentação em Python via Java
linktitle: API Low-Code
type: docs
weight: 50
url: /pt/python-java/low-code-presentation-operations/
keywords:
- API low-code de apresentação
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
- Python
- Java
- Aspose.Slides
description: "Use a API low-code do Aspose.Slides em Python via Java para converter e mesclar apresentações, iterar através do conteúdo, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

A API [Aspose.Slides for Python via Java](https://reference.aspose.com/slides/pt/python-java/aspose.slides/) fornece classes auxiliares estáticas para operações comuns de apresentações. Essas auxiliares encapsulam fluxos de trabalho do modelo de objetos frequentemente usados em métodos focados, permitindo converter ou mesclar arquivos, processar elementos da apresentação, coletar shapes e remover conteúdo não utilizado com menos código.

Essas auxiliares de low-code são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objetos completo do [Aspose.Slides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/) quando precisar de controle granulado sobre slides individuais, masters, layouts, shapes, configurações de exportação ou relacionamentos entre elementos da apresentação.

O seguinte tabela resume as auxiliares disponíveis:

| Auxiliar | Uso |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/python-java/aspose.slides/convert/) | Converter uma apresentação para outro formato com uma chamada direta arquivo-para-arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/python-java/aspose.slides/merger/) | Combinar arquivos de apresentação completos do mesmo formato. |
| [ForEach](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/) | Executar uma ação para cada slide, shape, parágrafo ou porção de texto. |
| [Collect](https://reference.aspose.com/slides/pt/python-java/aspose.slides/collect/) | Recuperar shapes de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/) | Remover masters e layouts não usados e reduzir dados de fontes incorporadas. |

## **Converter uma Apresentação**

Use [Convert.autoByExtension](https://reference.aspose.com/slides/pt/python-java/aspose.slides/convert/#autoByExtension) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato necessário a partir do caminho de saída e grava o resultado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Convert

Convert.autoByExtension("input.pptx", "output.pdf")
```

A classe [Convert](https://reference.aspose.com/slides/pt/python-java/aspose.slides/convert/) também fornece métodos dedicados para saída PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objetos completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não seja exposta pela auxiliar selecionada. Consulte [Convert Presentation](/slides/pt/python-java/convert-presentation/) para fluxos de trabalho e opções específicas de formato.

## **Mesclar Apresentações**

Use [Merger.process](https://reference.aspose.com/slides/pt/python-java/aspose.slides/merger/#process) para combinar arquivos de apresentação completos em uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Merger

input_files = jpype.JArray(jpype.JString)(["part-1.pptx", "part-2.pptx"])
Merger.process(input_files, "merged.pptx")
```

A auxiliar é adequada quando todos os slides devem ser anexados a um único resultado sem selecioná‑los ou remapeá‑los individualmente. Use o modelo de objetos completo quando precisar mesclar slides selecionados, aplicar um master ou layout de destino, preservar seções explicitamente ou conciliar tamanhos de slide diferentes. Consulte [Merge Presentations](/slides/pt/python-java/merge-presentation/) para esses cenários.

## **Iterar pelos Elementos da Apresentação**

A classe [ForEach](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/) invoca um callback para cada tipo solicitado de elemento da apresentação. Ela evita loops de coleção aninhados e é conveniente para inspeção ou alterações de formatação em toda a apresentação.

O exemplo a seguir usa [ForEach.slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#slide), [ForEach.shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#portion) para inspecionar os elementos correspondentes:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ForEach, Presentation

def print_slide(slide, index):
    print(f"Slide {index}: {slide.getShapes().size()} shapes")

def print_shape(shape, slide, index):
    print(f"Shape {index} on {slide.getClass().getSimpleName()}: {shape.getName()}")

def print_paragraph(paragraph, slide, index):
    print(f"Paragraph {index} on {slide.getClass().getSimpleName()}: {paragraph.getText()}")

def print_portion(portion, paragraph, slide, index):
    print(f"Portion {index} on {slide.getClass().getSimpleName()}: {portion.getText()}")

presentation = Presentation("input.pptx")
try:
    ForEach.slide(presentation, print_slide)
    ForEach.shape(presentation, print_shape)
    ForEach.paragraph(presentation, print_paragraph)
    ForEach.portion(presentation, print_portion)
finally:
    presentation.dispose()
```

Por padrão, a travessia de shapes e texto em toda a apresentação inclui slides normais, master e layout. Sobrecargas com um parâmetro `includeNotes` também podem processar slides de notas. Use loops de coleção diretos quando a ordem de travessia, saída antecipada, filtragem antes da invocação do callback ou controle detalhado de hierarquia pai‑filho for importante.

## **Coletar Shapes**

Use [Collect.shapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/collect/#shapes) quando precisar de uma coleção de todos os shapes de uma apresentação em vez de um callback para cada shape. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Collect, Presentation

presentation = Presentation("input.pptx")
try:
    shapes = Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.getName()}: {shape.getClass().getSimpleName()}")
finally:
    presentation.dispose()
```

Use [ForEach.shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#shape) em vez disso quando cada shape puder ser tratado imediatamente e você não precisar reter o resultado coletado.

## **Comprimir Conteúdo da Apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/) pode remover elementos estruturais não utilizados e reduzir dados de fontes incorporadas:

- [removeUnusedLayoutSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) remove slides de layout que nenhum slide normal referencia.
- [removeUnusedMasterSlides](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/#removeUnusedMasterSlides) remove masters que já não são usados.
- [compressEmbeddedFonts](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/#compressEmbeddedFonts) remove caracteres não usados de fontes incorporadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    Compress.removeUnusedMasterSlides(presentation)
    Compress.compressEmbeddedFonts(presentation)

    presentation.save("compressed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Remova layouts não usados antes dos masters não usados, para que um master que se torne sem referência após a limpeza de layouts também possa ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos masters, layouts ou dos dados completos de fontes incorporadas originais mais tarde. Para mais detalhes, consulte [Slide Master](/slides/pt/python-java/slide-master/) e [Embedded Font](/slides/pt/python-java/embedded-font/).

## **FAQ**

**Quando devo usar a API low-code em vez do modelo de objetos completo?**

Use auxiliares low-code quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objetos completo quando precisar selecionar slides específicos, controlar relacionamentos de master e layout, inspecionar o estado intermediário ou configurar um comportamento que a auxiliar não expõe.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger.process](https://reference.aspose.com/slides/pt/python-java/aspose.slides/merger/#process) requer que as apresentações de entrada estejam no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert.autoByExtension](https://reference.aspose.com/slides/pt/python-java/aspose.slides/convert/#autoByExtension), e então mescle os arquivos convertidos.

**O ForEach processa slides master, layout e de notas?**

[ForEach.slide](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#slide) percorre os slides normais da apresentação. As operações [ForEach.shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#shape), [ForEach.paragraph](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#paragraph) e [ForEach.portion](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#portion) em toda a apresentação incluem slides normais, master e layout por padrão. Use suas sobrecargas com `includeNotes` definido como `True` para incluir slides de notas.

**Qual é a diferença entre ForEach.shape e Collect.shapes?**

Use [ForEach.shape](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/#shape) para processar cada shape imediatamente por meio de um callback. Use [Collect.shapes](https://reference.aspose.com/slides/pt/python-java/aspose.slides/collect/#shapes) quando precisar de um resultado iterável que possa ser retido, filtrado, contado ou percorrido várias vezes.

**O Compress sempre reduz o tamanho do arquivo da apresentação?**

Não necessariamente. O resultado depende de a apresentação conter layouts não usados, masters não usados ou fontes incorporadas com caracteres não utilizados. Se nenhum desses estiver presente, as operações correspondentes do [Compress](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/) podem não reduzir o tamanho do arquivo.

**As alterações feitas por ForEach ou Compress são salvas automaticamente?**

Não. Essas auxiliares operam no objeto [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/) carregado na memória. Após alterar elementos em um callback de [ForEach](https://reference.aspose.com/slides/pt/python-java/aspose.slides/foreach/) ou executar [Compress](https://reference.aspose.com/slides/pt/python-java/aspose.slides/compress/), chame [Presentation.save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para gravar o resultado.

## **Artigos Relacionados**

- [Convert Presentation](/slides/pt/python-java/convert-presentation/)
- [Merge Presentations](/slides/pt/python-java/merge-presentation/)
- [Slide Master](/slides/pt/python-java/slide-master/)
- [Manage Text Box](/slides/pt/python-java/manage-textbox/)
- [Embedded Font](/slides/pt/python-java/embedded-font/)