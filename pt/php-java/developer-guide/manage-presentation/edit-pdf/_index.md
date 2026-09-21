---
title: Editar documentos PDF em PHP
linktitle: Editar PDF
type: docs
weight: 65
url: /pt/php-java/edit-pdf/
keywords:
- editar PDF
- substituir texto PDF
- PDF para PPTX
- PPTX para PDF
- PHP
- Aspose.Slides
description: "Edite documentos PDF em PHP importando-os para Aspose.Slides, substituindo texto e salvando a apresentação modificada de volta em PDF."
---
## **Visão Geral**

Aspose.Slides for PHP via Java permite editar conteúdo PDF importando suas páginas como slides, modificando a apresentação e exportando-a de volta para PDF. Este artigo mostra uma substituição de texto simples. A apresentação permanece na memória, portanto salvar um arquivo PPTX intermediário é opcional.

## **Substituir Texto em um PDF**

Use [SlideCollection::addFromPdf](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slidecollection/#addFromPdf) para importar as páginas, [Presentation::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceText) para atualizar o texto e [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save) para exportar o resultado.

O exemplo a seguir espera que `input.pdf` contenha a palavra "Draft" como texto editável após a importação. Ele substitui essa palavra por "Final" e grava `edited.pdf`. Limpar o slide inicial antes da importação evita uma página em branco extra na saída. A pesquisa corresponde a palavras inteiras com a mesma capitalização; `null` significa que não é necessário um callback de resultado.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextSearchOptions;

$presentation = new Presentation();
try {
    $presentation->getSlides()->removeAt(0);

    $presentation->getSlides()->addFromPdf("input.pdf");

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);
    $presentation->replaceText("Draft", "Final", $searchOptions, null);

    $presentation->save("edited.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

Para mais opções, veja [Pesquisar e Substituir Texto](/slides/pt/php-java/search-and-replace-text/) e [Converter PowerPoint para PDF](/slides/pt/php-java/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
A substituição de texto funciona no texto importado, não no texto dentro de imagens digitalizadas. A conversão pode afetar o layout e a formatação, portanto revise a saída, especialmente quando o texto de substituição for maior que o original.
{{% /alert %}}

## **FAQ**

**Preciso salvar um arquivo PPTX antes de exportar o PDF?**

Não. Você pode editar e exportar a mesma apresentação na memória. Salve uma cópia PPTX somente se também quiser continuar editando-a no PowerPoint; veja [Salvar Apresentações](/slides/pt/php-java/save-presentation/).

**Por que algum texto pode permanecer inalterado?**

O exemplo corresponde à palavra inteira "Draft" com capitalização exata. Texto importado como imagem ou dividido em quadros de texto separados pode não corresponder à pesquisa. Verifique o conteúdo importado e ajuste a pesquisa para o seu documento.