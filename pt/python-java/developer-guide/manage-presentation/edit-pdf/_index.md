---
title: Editar documentos PDF em Python via Java
linktitle: Editar PDF
type: docs
weight: 65
url: /pt/python-java/edit-pdf/
keywords:
- editar PDF
- substituir texto PDF
- PDF para PPTX
- PPTX para PDF
- Python
- Java
- Aspose.Slides
description: "Edite documentos PDF em Python via Java importando-os para Aspose.Slides, substituindo texto e salvando a apresentação modificada de volta em PDF."
---
## **Visão geral**

Aspose.Slides for Python via Java permite editar o conteúdo de PDF importando suas páginas como slides, modificando a apresentação e exportando-a de volta para PDF. Este artigo mostra uma substituição simples de texto. A apresentação permanece na memória, portanto salvar um arquivo PPTX intermediário é opcional.

## **Substituir texto em um PDF**

Use [addFromPdf](https://reference.aspose.com/slides/pt/python-java/aspose.slides/slidecollection/#addFromPdf) para importar as páginas, [replaceText](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#replaceText) para atualizar o texto e [save](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/#save) para exportar o resultado.

O exemplo a seguir pressupõe que `input.pdf` contém a palavra "Draft" como texto editável após a importação. Ele substitui essa palavra por "Final" e grava `edited.pdf`. Limpar o slide inicial antes da importação impede que uma página em branco extra apareça na saída. A pesquisa corresponde a palavras completas com a mesma capitalização; `None` indica que nenhum retorno de chamada de resultado é necessário.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextSearchOptions

presentation = Presentation()
try:
    presentation.getSlides().removeAt(0)

    presentation.getSlides().addFromPdf("input.pdf")

    search_options = TextSearchOptions()
    search_options.setWholeWordsOnly(True)
    search_options.setCaseSensitive(True)
    presentation.replaceText("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

Para mais opções, veja [Search and Replace Text](/slides/pt/python-java/search-and-replace-text/) e [Convert PowerPoint to PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
A substituição de texto funciona em texto importado, não em texto dentro de imagens digitalizadas. A conversão pode afetar o layout e a formatação, portanto revise a saída, especialmente quando o texto de substituição for mais longo que o original.
{{% /alert %}}

## **Perguntas frequentes**

**Preciso salvar um arquivo PPTX antes de exportar o PDF?**

Não. Você pode editar e exportar a mesma apresentação na memória. Salve uma cópia PPTX apenas se desejar continuar editando-a no PowerPoint; veja [Save Presentations](/slides/pt/python-java/save-presentation/).

**Por que algum texto pode permanecer inalterado?**

O exemplo corresponde à palavra inteira "Draft" com capitalização exata. Texto importado como imagem ou dividido entre quadros de texto separados não corresponderá necessariamente à pesquisa. Verifique o conteúdo importado e ajuste a pesquisa para o seu documento.