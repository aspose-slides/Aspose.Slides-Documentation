---
title: Modifica documenti PDF in C++
linktitle: Modifica PDF
type: docs
weight: 65
url: /it/cpp/edit-pdf/
keywords:
- modifica PDF
- sostituisci testo PDF
- PDF in PPTX
- PPTX in PDF
- C++
- Aspose.Slides
description: "Modifica documenti PDF in C++ importandoli in Aspose.Slides, sostituendo il testo e salvando la presentazione modificata nuovamente in PDF."
---
## **Panoramica**

Aspose.Slides for C++ ti consente di modificare il contenuto PDF importando le sue pagine come diapositive, modificando la presentazione ed esportandola nuovamente in PDF. Questo articolo mostra una semplice sostituzione di testo. La presentazione rimane in memoria, quindi salvare un file PPTX intermedio è opzionale.

## **Sostituire testo in un PDF**

Usa [SlideCollection::AddFromPdf](https://reference.aspose.com/slides/it/cpp/aspose.slides/slidecollection/addfrompdf/) per importare le pagine, [Presentation::ReplaceText](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/replacetext/) per aggiornare il testo e [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) per esportare il risultato.

L'esempio seguente si aspetta che `input.pdf` contenga la parola "Draft" come testo modificabile dopo l'importazione. Sostituisce tale parola con "Final" e scrive `edited.pdf`. Cancellare la diapositiva iniziale prima dell'importazione evita una pagina vuota aggiuntiva nell'output. La ricerca corrisponde a parole intere con la stessa capitalizzazione; `nullptr` indica che non è necessario un callback di risultato.

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

Per ulteriori opzioni, vedere [Search and Replace Text](/slides/it/cpp/search-and-replace-text/) e [Convert PowerPoint to PDF](/slides/it/cpp/convert-powerpoint-to-pdf/).

{{% alert color="info" title="Note" %}}
La sostituzione di testo funziona sul testo importato, non sul testo all'interno di immagini scannerizzate. La conversione può influire su layout e formattazione, quindi rivedi l'output, soprattutto quando il testo di sostituzione è più lungo dell'originale.
{{% /alert %}}

## **FAQ**

**Devo salvare un file PPTX prima di esportare il PDF?**

No. Puoi modificare ed esportare la stessa presentazione in memoria. Salva una copia PPTX solo se desideri continuare a modificarla in PowerPoint; consulta [Save Presentations](/slides/it/cpp/save-presentation/).

**Perché parte del testo potrebbe rimanere invariato?**

L'esempio corrisponde alla parola intera "Draft" con esatta capitalizzazione. Il testo importato come immagine o suddiviso in più riquadri di testo potrebbe non corrispondere alla ricerca. Verifica il contenuto importato e adatta la ricerca al tuo documento.