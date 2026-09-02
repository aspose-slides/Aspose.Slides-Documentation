---
title: Operações de Apresentação Low-Code em Python
linktitle: API de Código Baixo
type: docs
weight: 50
url: /pt/python-net/low-code-presentation-operations/
keywords:
- API de apresentação de código baixo
- converter apresentação
- mesclar apresentações
- coletar formas
- compactar apresentação
- remover mestres de slide não utilizados
- remover layouts de slide não utilizados
- compactar fontes incorporadas
- PowerPoint
- OpenDocument
- apresentação
- Python
- Aspose.Slides
description: "Use a API low-code do Aspose.Slides em Python para converter e mesclar apresentações, coletar formas e reduzir o tamanho da apresentação."
---
## **Visão geral**

O módulo [aspose.slides.lowcode](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/) fornece classes auxiliares para operações comuns de apresentação. Esses auxiliares encapsulam fluxos de trabalho frequentemente usados do modelo de objetos em métodos focados, permitindo que você converta ou mescle arquivos, colete formas e remova conteúdo não utilizado com menos código.

Os auxiliares low-code são mais úteis quando a operação se aplica a um arquivo ou apresentação inteira e o fluxo de trabalho padrão atende aos seus requisitos. Use o modelo de objeto completo [Aspose.Slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides/) quando precisar de controle granular sobre slides individuais, mestres, layouts, formas, configurações de exportação ou relações entre os elementos da apresentação.

A tabela a seguir resume os auxiliares disponíveis:

| Auxiliar | Use para |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/convert/) | Converter uma apresentação para outro formato com uma chamada direta de arquivo para arquivo. |
| [Merger](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/merger/) | Combinar arquivos de apresentação completos no mesmo formato. |
| [Collect](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/collect/) | Recuperar formas de toda a apresentação para processamento ou análise repetidos. |
| [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/) | Remover mestres e layouts não utilizados e reduzir dados de fontes incorporadas. |

## **Converter uma apresentação**

Use [Convert.auto_by_extension](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/convert/auto_by_extension/) quando a extensão do arquivo de saída for suficiente para selecionar o formato de exportação. O método abre a apresentação de origem, determina o formato requerido a partir do caminho de saída e grava o resultado.

```python
import aspose.slides as slides

slides.lowcode.Convert.auto_by_extension("input.pptx", "output.pdf")
```

A classe [Convert](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/convert/) também fornece métodos dedicados para saída em PDF, SVG, JPEG, PNG e TIFF. Use o modelo de objeto completo quando precisar inspecionar ou modificar a apresentação antes da exportação ou configurar uma opção de exportação que não seja exposta pelo auxiliar selecionado. Consulte [Convert Presentation](/slides/pt/python-net/convert-presentation/) para fluxos de trabalho e opções específicas de formato.

## **Mesclar apresentações**

Use [Merger.process](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/merger/process/) para combinar arquivos de apresentação completos com uma única chamada. As apresentações de entrada devem ter o mesmo formato de arquivo.

```python
import aspose.slides as slides

input_files = ["part-1.pptx", "part-2.pptx"]
slides.lowcode.Merger.process(input_files, "merged.pptx")
```

O auxiliar é adequado quando todos os slides devem ser anexados a um único resultado sem selecioná‑los ou remapeá‑los individualmente. Use o modelo de objeto completo quando precisar mesclar slides selecionados, aplicar um mestre ou layout de destino, preservar seções explicitamente ou reconciliar tamanhos de slide diferentes. Consulte [Merge Presentations](/slides/pt/python-net/merge-presentation/) para esses cenários.

## **Coletar formas**

Use [Collect.shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/collect/shapes/) quando precisar de uma coleção de todas as formas em uma apresentação. Isso é útil quando o mesmo conjunto será filtrado, contado ou processado mais de uma vez.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    shapes = slides.lowcode.Collect.shapes(presentation)

    for shape in shapes:
        print(f"{shape.name}: {type(shape).__name__}")
```

Use loops de coleta diretos quando a ordem de travessia, saída antecipada, filtragem antes do processamento ou controle detalhado de pais‑filhos for importante.

## **Compactar o conteúdo da apresentação**

A classe [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/) pode remover elementos estruturais não utilizados e reduzir dados de fontes incorporadas:

- [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) remove slides de layout que não são referenciados por nenhum slide normal.
- [Compress.remove_unused_master_slides](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/remove_unused_master_slides/) remove mestres que não são mais usados.
- [Compress.compress_embedded_fonts](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/) remove caracteres não utilizados de fontes incorporadas.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    slides.lowcode.Compress.compress_embedded_fonts(presentation)

    presentation.save("compressed.pptx", slides.export.SaveFormat.PPTX)
```

Remova layouts não utilizados antes de mestres não utilizados, de modo que um mestre que se torne não referenciado após a limpeza de layout também possa ser removido. Salve a apresentação otimizada em um novo arquivo se precisar dos mestres, layouts ou dos dados completos de fontes incorporadas originais posteriormente. Para mais detalhes, veja [Slide Master](/slides/pt/python-net/slide-master/) e [Embedded Font](/slides/pt/python-net/embedded-font/).

## **FAQ**

**Quando devo usar a API low-code em vez do modelo de objeto completo?**

Use os auxiliares low-code quando uma operação padrão se aplica a um arquivo ou apresentação completa e não requer controle detalhado sobre elementos individuais. Use o modelo de objeto completo quando precisar selecionar slides específicos, controlar relações entre mestres e layouts, inspecionar o estado intermediário ou configurar comportamentos que o auxiliar não exponha.

**O Merger pode combinar apresentações em formatos de arquivo diferentes?**

Não. [Merger.process](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/merger/process/) requer que as apresentações de entrada estejam no mesmo formato. Converta os arquivos de entrada para um formato comum primeiro, por exemplo com [Convert.auto_by_extension](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/convert/auto_by_extension/), e então mescle os arquivos convertidos.

**O que o Collect.shapes inclui?**

[Collect.shapes](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/collect/shapes/) recupera as formas da apresentação para que possam ser mantidas, filtradas, contadas ou percorridas múltiplas vezes. Use loops de coleta diretos quando precisar de controle preciso sobre quais tipos de slide ou objetos aninhados são visitados.

**O Compress sempre torna o arquivo da apresentação menor?**

Não necessariamente. O resultado depende de a apresentação conter layouts não utilizados, mestres não utilizados ou fontes incorporadas com caracteres não usados. Se nenhum desses itens estiver presente, as operações correspondentes de [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/) podem não reduzir o tamanho do arquivo.

**As alterações feitas pelo Compress são salvas automaticamente?**

Não. Esses auxiliares operam no objeto [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/) carregado em memória. Após executar [Compress](https://reference.aspose.com/slides/pt/python-net/aspose.slides.lowcode/compress/), chame [Presentation.save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) para gravar o resultado.

## **Artigos relacionados**

- [Convert Presentation](/slides/pt/python-net/convert-presentation/)
- [Merge Presentations](/slides/pt/python-net/merge-presentation/)
- [Slide Master](/slides/pt/python-net/slide-master/)
- [Manage Text Box](/slides/pt/python-net/manage-textbox/)
- [Embedded Font](/slides/pt/python-net/embedded-font/)