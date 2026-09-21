---
title: Editar documentos PDF em .NET
linktitle: Editar PDF
type: docs
weight: 65
url: /pt/net/edit-pdf/
keywords:
- editar PDF
- substituir texto PDF
- PDF para PPTX
- PPTX para PDF
- .NET
- C#
- Aspose.Slides
description: "Edite documentos PDF em C# importando-os para o Aspose.Slides, substituindo o texto e salvando a apresentação modificada de volta em PDF."
---
## **Visão geral**

Aspose.Slides for .NET permite editar o conteúdo de PDF importando suas páginas como slides, modificando a apresentação e exportando-a de volta para PDF. Este artigo mostra uma substituição simples de texto. A apresentação permanece na memória, portanto salvar um arquivo PPTX intermediário é opcional.

## **Substituir texto em um PDF**

Use [AddFromPdf](https://reference.aspose.com/slides/pt/net/aspose.slides/slidecollection/addfrompdf/) para importar as páginas, [ReplaceText](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/replacetext/) para atualizar o texto e [Save](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/save/) para exportar o resultado.

O exemplo a seguir espera que `input.pdf` contenha a palavra "Draft" como texto editável após a importação. Ele substitui essa palavra por "Final" e grava `edited.pdf`. Limpar o slide inicial antes da importação evita uma página em branco extra na saída. A pesquisa corresponde a palavras inteiras com a mesma capitalização; `null` indica que nenhum callback de resultado é necessário.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.Slides.RemoveAt(0);

presentation.Slides.AddFromPdf("input.pdf");

var searchOptions = new TextSearchOptions
{
    WholeWordsOnly = true,
    CaseSensitive = true
};
presentation.ReplaceText("Draft", "Final", searchOptions, null);

presentation.Save("edited.pdf", SaveFormat.Pdf);
```

Para mais opções, veja [Pesquisar e Substituir Texto](/slides/pt/net/search-and-replace-text/) e [Converter PowerPoint para PDF](/slides/pt/net/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
A substituição de texto funciona em texto importado, não em texto dentro de imagens escaneadas. A conversão pode afetar o layout e a formatação, portanto revise a saída, especialmente quando o texto de substituição for maior que o original.
{{% /alert %}}

## **FAQ**

**Preciso salvar um arquivo PPTX antes de exportar o PDF?**

Não. Você pode editar e exportar a mesma apresentação na memória. Salve uma cópia PPTX somente se também quiser continuar editando-a no PowerPoint; veja [Salvar Apresentações](/slides/pt/net/save-presentation/).

**Por que algum texto pode permanecer sem alterações?**

O exemplo corresponde à palavra inteira "Draft" com capitalização exata. Texto importado como imagem ou dividido em quadros de texto separados não corresponderá necessariamente à pesquisa. Verifique o conteúdo importado e ajuste a pesquisa para o seu documento.