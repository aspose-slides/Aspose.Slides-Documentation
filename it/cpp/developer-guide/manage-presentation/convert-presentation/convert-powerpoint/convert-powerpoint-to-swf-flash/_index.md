---
title: Converti le presentazioni PowerPoint in SWF Flash in C++
linktitle: PowerPoint in SWF
type: docs
weight: 80
url: /it/cpp/convert-powerpoint-to-swf-flash/
keywords:
- converti PowerPoint
- converti presentazione
- converti diapositiva
- converti PPT
- converti PPTX
- PowerPoint in SWF
- presentazione in SWF
- diapositiva in SWF
- PPT in SWF
- PPTX in SWF
- PowerPoint in Flash
- presentazione in Flash
- diapositiva in Flash
- PPT in Flash
- PPTX in Flash
- salva PPT come SWF
- salva PPTX come SWF
- esporta PPT in SWF
- esporta PPTX in SWF
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Converti PowerPoint (PPT/PPTX) in SWF Flash in C++ con Aspose.Slides. Esempi di codice passo‑a‑passo, output di alta qualità e veloce, senza automazione di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire presentazioni PowerPoint in SWF utilizzando Aspose.Slides. Mostra come salvare una presentazione come file SWF con il metodo [Presentation::Save](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/save/) e come configurare l'esportazione con [SwfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/swfoptions/), incluse le impostazioni del visualizzatore e il layout di note o commenti.

## **Converti le presentazioni in Flash**

Il metodo [Save](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) può essere usato per convertire l'intera presentazione in un documento SWF. È inoltre possibile includere i commenti nello SWF generato usando la classe [SWFOptions](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.export.swf_options) e la classe [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/notescommentslayoutingoptions/) . L'esempio seguente mostra come convertire una presentazione in un documento SWF utilizzando le opzioni fornite dalla classe SWFOptions.

``` cpp
// Il percorso della directory dei documenti.
    System::String dataDir = GetDataPath();

    // Instanzia un oggetto Presentation che rappresenta un file di presentazione
    auto presentation = System::MakeObject<Presentation>(dataDir + u"HelloWorld.pptx");

    auto swfOptions = System::MakeObject<SwfOptions>();
    swfOptions->set_ViewerIncluded(false);

    auto notesOptions = swfOptions->get_NotesCommentsLayouting();
    notesOptions->set_NotesPosition(NotesPositions::BottomFull);

    // Salvataggio della presentazione e delle pagine delle note
    presentation->Save(dataDir + u"SaveAsSwf_out.swf", SaveFormat::Swf, swfOptions);
    swfOptions->set_ViewerIncluded(true);
    presentation->Save(dataDir + u"SaveNotes_out.swf", SaveFormat::Swf, swfOptions);
```

## **FAQ**

**Posso includere diapositive nascoste nello SWF?**

Sì. Usa il metodo [set_ShowHiddenSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/swfoptions/set_showhiddenslides/) in [SwfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/swfoptions/). Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e la dimensione finale dello SWF?**

Usa il metodo [set_Compressed](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/swfoptions/set_compressed/) e regola la [JPEG quality](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/swfoptions/set_jpegquality/) per bilanciare la dimensione del file e la fedeltà dell'immagine.

**A cosa serve 'set_ViewerIncluded' e quando dovrei usarlo?**

[set_ViewerIncluded](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/swfoptions/set_viewerincluded/) aggiunge un'interfaccia player incorporata (controlli di navigazione, pannelli, ricerca). Disabilitala se prevedi di usare un tuo player o vuoi un semplice frame SWF senza UI.

**Cosa succede se il font sorgente manca sulla macchina di esportazione?**

Aspose.Slides sostituirà il font specificato tramite [set_DefaultRegularFont](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides.export/swfoptions/) per evitare un fallback non intenzionale.