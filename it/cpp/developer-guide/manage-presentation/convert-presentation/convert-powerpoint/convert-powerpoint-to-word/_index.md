---
title: Converti le presentazioni PowerPoint in documenti Word in C++
linktitle: PowerPoint in Word
type: docs
weight: 110
url: /it/cpp/convert-powerpoint-to-word/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in Word
- presentazione in Word
- diapositiva in Word
- PPT in Word
- PPTX in Word
- PowerPoint in DOCX
- presentazione in DOCX
- diapositiva in DOCX
- PPT in DOCX
- PPTX in DOCX
- PowerPoint in DOC
- presentazione in DOC
- diapositiva in DOC
- PPT in DOC
- PPTX in DOC
- salva PPT come DOCX
- salva PPTX come DOCX
- esporta PPT in DOCX
- esporta PPTX in DOCX
- C++
- Aspose.Slides
description: "Converti le diapositive PowerPoint PPT e PPTX in documenti Word modificabili in C++ utilizzando Aspose.Slides, mantenendo layout, immagini e formattazione precisi."
---
## **Introduzione**

Se prevedi di utilizzare contenuti testuali o informazioni da una presentazione (PPT o PPTX) in modi nuovi, potresti trarre vantaggio dalla conversione della presentazione in Word (DOC o DOCX). 

* Rispetto a Microsoft PowerPoint, l'app Microsoft Word è più dotata di strumenti o funzionalità per i contenuti. 
* Oltre alle funzioni di modifica in Word, puoi beneficiare anche di funzionalità migliorate di collaborazione, stampa e condivisione. 

{{% alert color="primary" %}} 

Potresti provare il nostro [**Convertitore online da Presentazione a Word**](https://products.aspose.app/slides/it/conversion/ppt-to-word) per vedere cosa potresti guadagnare lavorando con contenuti testuali delle diapositive. 

{{% /alert %}} 

## **Aspose.Slides e Aspose.Words**

Per convertire un file PowerPoint (PPTX o PPT) in Word (DOCX o DOCX), hai bisogno sia di [Aspose.Slides for C++](https://products.aspose.com/slides/it/cpp/) che di [Aspose.Words for C++](https://products.aspose.com/words/cpp/).

Come API autonoma, [Aspose.Slides](https://products.aspose.app/slides) per C++ fornisce funzioni che consentono di estrarre testi dalle presentazioni. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) è un'API avanzata di elaborazione dei documenti che permette alle applicazioni di generare, modificare, convertire, renderizzare, stampare file e svolgere altre attività con i documenti senza utilizzare Microsoft Word.

## **Convertire una presentazione PowerPoint in un documento Word**

Utilizza questo snippet di codice per convertire il PowerPoint in Word:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // genera e inserisce l'immagine della diapositiva
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

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
```

## **FAQ**

**Quali componenti devono essere installati per convertire presentazioni PowerPoint e OpenDocument in documenti Word?**

Devi solo aggiungere i rispettivi pacchetti per [Aspose.Slides for C++](https://releases.aspose.com/slides/it/cpp/) e [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) al tuo progetto. Entrambe le librerie funzionano come API autonome e non è necessario avere installato Microsoft Office.

**Sono supportati tutti i formati di presentazione PowerPoint e OpenDocument?**

Aspose.Slides [supporta tutti i formati di presentazione](/slides/it/cpp/supported-file-formats/), inclusi PPT, PPTX, ODP e altri formati comuni. Questo garantisce che tu possa lavorare con presentazioni create in diverse versioni di Microsoft PowerPoint.