---
title: Editar documentos PDF em Python
linktitle: Editar PDF
type: docs
weight: 65
url: /pt/python-net/edit-pdf/
keywords:
- editar PDF
- substituir texto PDF
- PDF para PPTX
- PPTX para PDF
- Python
- Aspose.Slides
description: "Edite documentos PDF em Python importando-os para Aspose.Slides, substituindo texto e salvando a apresentação modificada de volta em PDF."
---
## **Visão geral**

Aspose.Slides for Python via .NET permite editar o conteúdo de PDFs importando suas páginas como slides, modificando a apresentação e exportando-a de volta para PDF. Este artigo mostra uma substituição simples de texto. A apresentação permanece na memória, portanto salvar um arquivo PPTX intermediário é opcional.

## **Substituir texto em um PDF**

Use [add_from_pdf](https://reference.aspose.com/slides/pt/python-net/aspose.slides/slidecollection/add_from_pdf/) para importar as páginas, [replace_text](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/replace_text/) para atualizar o texto e [save](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/save/) para exportar o resultado.

O exemplo a seguir pressupõe que `input.pdf` contenha a palavra "Draft" como texto editável após a importação. Ele substitui essa palavra por "Final" e grava `edited.pdf`. Limpar o slide inicial antes da importação evita uma página em branco extra na saída. A pesquisa corresponde a palavras inteiras com a mesma capitalização; `None` significa que nenhum retorno de chamada de resultado é necessário.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.slides.remove_at(0)

    presentation.slides.add_from_pdf("input.pdf")

    search_options = slides.TextSearchOptions()
    search_options.whole_words_only = True
    search_options.case_sensitive = True
    presentation.replace_text("Draft", "Final", search_options, None)

    presentation.save("edited.pdf", slides.export.SaveFormat.PDF)
```

Para mais opções, veja [Pesquisar e Substituir Texto](/slides/pt/python-net/search-and-replace-text/) e [Converter PowerPoint para PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Observação" %}}

A substituição de texto funciona em texto importado, não em texto dentro de imagens digitalizadas. A conversão pode afetar o layout e a formatação, portanto revise a saída, especialmente quando o texto substituto for mais longo que o original.

{{% /alert %}}

## **FAQ**

**Preciso salvar um arquivo PPTX antes de exportar o PDF?**

Não. Você pode editar e exportar a mesma apresentação na memória. Salve uma cópia PPTX apenas se também quiser continuar editando-a no PowerPoint; veja [Salvar Apresentações](/slides/pt/python-net/save-presentation/).

**Por que algum texto pode permanecer inalterado?**

O exemplo corresponde à palavra inteira "Draft" com capitalização exata. Texto importado como imagem ou dividido em quadros de texto separados não corresponderá necessariamente à pesquisa. Verifique o conteúdo importado e ajuste a pesquisa para o seu documento.