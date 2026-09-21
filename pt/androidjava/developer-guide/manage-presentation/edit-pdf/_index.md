---
title: Editar documentos PDF no Android
linktitle: Editar PDF
type: docs
weight: 65
url: /pt/androidjava/edit-pdf/
keywords:
- editar PDF
- substituir texto PDF
- PDF para PPTX
- PPTX para PDF
- Android
- Java
- Aspose.Slides
description: "Edite documentos PDF no Android com Java importando-os para o Aspose.Slides, substituindo texto e salvando a apresentação modificada de volta em PDF."
---
## **Visão geral**

Aspose.Slides for Android via Java permite editar o conteúdo de PDF importando suas páginas como slides, modificando a apresentação e exportando‑a de volta para PDF. Este artigo mostra uma substituição simples de texto. A apresentação permanece na memória, portanto salvar um arquivo PPTX intermediário é opcional.

## **Substituir texto em um PDF**

Use [addFromPdf](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) para importar as páginas, [replaceText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) para atualizar o texto e [save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) para exportar o resultado.

O exemplo a seguir espera que `input.pdf` contenha a palavra "Draft" como texto editável após a importação. Ele substitui essa palavra por "Final" e grava `edited.pdf`. Limpar o slide inicial antes da importação impede uma página em branco extra na saída. A pesquisa corresponde a palavras completas com a mesma capitalização; `null` significa que nenhum callback de resultado é necessário.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.TextSearchOptions;

Presentation presentation = new Presentation();
try {
    presentation.getSlides().removeAt(0);

    presentation.getSlides().addFromPdf("input.pdf");

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);
    presentation.replaceText("Draft", "Final", searchOptions, null);

    presentation.save("edited.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Para mais opções, veja [Pesquisar e Substituir Texto](/slides/pt/androidjava/search-and-replace-text/) e [Converter PowerPoint para PDF](/slides/pt/androidjava/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
A substituição de texto funciona em texto importado, não em texto dentro de imagens digitalizadas. A conversão pode afetar o layout e a formatação, portanto revise o resultado, especialmente quando o texto substituto é mais longo que o original.
{{% /alert %}}

## **FAQ**

**Preciso salvar um arquivo PPTX antes de exportar o PDF?**

Não. Você pode editar e exportar a mesma apresentação na memória. Salve uma cópia PPTX somente se também quiser continuar editando‑a no PowerPoint; veja [Salvar apresentações](/slides/pt/androidjava/save-presentation/).

**Por que algum texto pode permanecer inalterado?**

O exemplo corresponde à palavra completa "Draft" com correspondência exata de maiúsculas/minúsculas. Texto importado como imagem ou dividido em quadros de texto separados não corresponderá necessariamente à pesquisa. Verifique o conteúdo importado e ajuste a pesquisa para o seu documento.