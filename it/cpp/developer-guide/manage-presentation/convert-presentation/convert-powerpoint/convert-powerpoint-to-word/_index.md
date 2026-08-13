---
title: Converti le presentazioni PowerPoint in documenti Word in C++
linktitle: PowerPoint a Word
type: docs
weight: 110
url: /it/cpp/convert-powerpoint-to-word/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint a Word
- presentazione a Word
- diapositiva a Word
- PPT a Word
- PPTX a Word
- PowerPoint a DOCX
- presentazione a DOCX
- diapositiva a DOCX
- PPT a DOCX
- PPTX a DOCX
- PowerPoint a DOC
- presentazione a DOC
- diapositiva a DOC
- PPT a DOC
- PPTX a DOC
- salva PPT come DOCX
- salva PPTX come DOCX
- esporta PPT in DOCX
- esporta PPTX in DOCX
- C++
- Aspose.Slides
description: "Converti le diapositive PowerPoint PPT e PPTX in documenti Word modificabili in C++ usando Aspose.Slides con layout preciso, immagini e formattazione preservati."
---
## **Introduzione**

Se prevedi di utilizzare contenuti testuali o informazioni da una presentazione (PPT o PPTX) in modi nuovi, potresti trarre vantaggio dalla conversione della presentazione in Word (DOC o DOCX). 

* Rispetto a Microsoft PowerPoint, l'app Microsoft Word è più dotata di strumenti o funzionalità per i contenuti. 
* Oltre alle funzioni di editing in Word, potresti anche beneficiare di funzionalità avanzate di collaborazione, stampa e condivisione. 

{{% alert color="info" %}} 

Potresti voler provare il nostro [**Conversione da Presentazione a Word Online**](https://products.aspose.app/slides/it/conversion/ppt-to-word) per vedere cosa potresti guadagnare lavorando con i contenuti testuali delle diapositive. 

{{% /alert %}} 

## **Aspose.Slides e Aspose.Words**

Per convertire un file PowerPoint (PPTX o PPT) in Word (DOCX o DOC), è necessario sia [Aspose.Slides for C++](https://products.aspose.com/slides/it/cpp/) sia [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Come API autonoma, [Aspose.Slides](https://products.aspose.app/slides) per C++ fornisce funzioni che consentono di estrarre testi dalle presentazioni. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) è un'API avanzata di elaborazione documenti che permette alle applicazioni di generare, modificare, convertire, renderizzare, stampare file e svolgere altre operazioni sui documenti senza utilizzare Microsoft Word.

## **Convertire una Presentazione PowerPoint in un Documento Word**

Utilizza questo frammento di codice per convertire il PowerPoint in Word:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // genera un'immagine della diapositiva come flusso di byte
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // inserisce i testi della diapositiva
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}

doc->Save(u"output.docx");
presentation->Dispose();
```

## **FAQ**

### Quali componenti è necessario installare per convertire presentazioni PowerPoint e OpenDocument in documenti Word?

È sufficiente aggiungere i relativi pacchetti per [Aspose.Slides for C++](https://releases.aspose.com/slides/it/cpp/) e [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) al tuo progetto. Entrambe le librerie funzionano come API autonome e non è necessario avere Microsoft Office installato.

### Sono supportati tutti i formati di presentazione PowerPoint e OpenDocument?

Aspose.Slides [supporta tutti i formati di presentazione](/slides/it/cpp/supported-file-formats/), inclusi PPT, PPTX, ODP e altri tipi di file comuni. Questo garantisce che tu possa lavorare con presentazioni create in diverse versioni di Microsoft PowerPoint.