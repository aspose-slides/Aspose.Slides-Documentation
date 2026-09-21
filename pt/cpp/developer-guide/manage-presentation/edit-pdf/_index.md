---
title: Editar Documentos PDF em C++
linktitle: Editar PDF
type: docs
weight: 65
url: /pt/cpp/edit-pdf/
keywords:
- editar PDF
- substituir texto PDF
- PDF para PPTX
- PPTX para PDF
- C++
- Aspose.Slides
description: "Edite documentos PDF em C++ importando-os para Aspose.Slides, substituindo texto e salvando a apresentação modificada de volta em PDF."
---
## **Visão geral**

Aspose.Slides for C++ permite editar o conteúdo de PDF importando suas páginas como slides, modificando a apresentação e exportando-a de volta para PDF. Este artigo mostra uma substituição simples de texto. A apresentação permanece na memória, portanto salvar um arquivo PPTX intermediário é opcional.

## **Substituir Texto em um PDF**

Use [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/pt/cpp/aspose.slides/slidecollection/addfrompdf/) para importar as páginas, [Presentation::ReplaceText](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/replacetext/) para atualizar o texto e [Presentation::Save](https://reference.aspose.com/slides/pt/cpp/aspose.slides/presentation/save/) para exportar o resultado.

O exemplo a seguir espera que `input.pdf` contenha a palavra "Draft" como texto editável após a importação. Ele substitui essa palavra por "Final" e grava `edited.pdf`. Limpar o slide inicial antes da importação evita uma página em branco extra na saída. A pesquisa corresponde a palavras inteiras com a mesma capitalização; `nullptr` significa que nenhum callback de resultado é necessário.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/TextFind/TextSearchOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace System;
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

presentation->get_Slides()->AddFromPdf(u"input.pdf");

auto searchOptions = MakeObject<TextSearchOptions>();
searchOptions->set_WholeWordsOnly(true);
searchOptions->set_CaseSensitive(true);
presentation->ReplaceText(u"Draft", u"Final", searchOptions, nullptr);

presentation->Save(u"edited.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

Para mais opções, veja [Pesquisar e Substituir Texto](/slides/pt/cpp/search-and-replace-text/) e [Converter PowerPoint para PDF](/slides/pt/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
A substituição de texto funciona em texto importado, não em texto dentro de imagens escaneadas. A conversão pode afetar o layout e a formatação, portanto revise a saída, especialmente quando o texto de substituição for mais longo que o original.
{{% /alert %}}

## **Perguntas Frequentes**

**Preciso salvar um arquivo PPTX antes de exportar o PDF?**

Não. Você pode editar e exportar a mesma apresentação na memória. Salve uma cópia PPTX somente se também quiser continuar editando-a no PowerPoint; veja [Save Presentations](/slides/pt/cpp/save-presentation/).

**Por que algum texto pode permanecer inalterado?**

O exemplo corresponde à palavra inteira "Draft" com capitalização exata. Texto importado como imagem ou dividido em quadros de texto separados não corresponderá necessariamente à pesquisa. Verifique o conteúdo importado e ajuste a pesquisa para o seu documento.