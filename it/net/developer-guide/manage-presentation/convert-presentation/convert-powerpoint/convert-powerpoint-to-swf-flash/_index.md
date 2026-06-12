---
title: Converti le presentazioni PowerPoint in SWF Flash in .NET
linktitle: PowerPoint in SWF
type: docs
weight: 80
url: /it/net/convert-powerpoint-to-swf-flash/
keywords:
- convertire PowerPoint
- convertire presentazione
- convertire diapositiva
- convertire PPT
- convertire PPTX
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
- salvare PPT come SWF
- salvare PPTX come SWF
- esportare PPT in SWF
- esportare PPTX in SWF
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Converti PowerPoint (PPT/PPTX) in SWF Flash in .NET con Aspose.Slides. Esempi di codice C# passo per passo, output veloce e di qualità, senza automazione di PowerPoint."
---
## **Panoramica**

Questo articolo spiega come convertire le presentazioni PowerPoint in SWF utilizzando Aspose.Slides. Mostra come salvare una presentazione come file SWF con il metodo [Presentation.Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/save/) e come configurare l'esportazione con [SwfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/swfoptions/), incluse le impostazioni del visualizzatore e il layout di note o commenti.

## **Converti le Presentazioni in Flash**

Il metodo [Save](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/methods/save/index) esposto dalla classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) può essere utilizzato per convertire l'intera presentazione in un documento SWF. È anche possibile includere i commenti nello SWF generato utilizzando la classe [SWFOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/swfoptions) e l'interfaccia [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/inotescommentslayoutingoptions). L'esempio seguente mostra come convertire una presentazione in un documento SWF usando le opzioni fornite dalla classe SWFOptions.

```c#
// Instanziare un oggetto Presentation che rappresenta un file di presentazione
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Salvataggio della presentazione e delle pagine delle note
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **FAQ**

**Posso includere diapositive nascoste nello SWF?**

Sì. Attiva l'opzione [ShowHiddenSlides](https://reference.aspose.com/slides/it/net/aspose.slides.export/swfoptions/showhiddenslides/) in [SwfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/swfoptions/). Per impostazione predefinita, le diapositive nascoste non vengono esportate.

**Come posso controllare la compressione e le dimensioni finali dello SWF?**

Utilizza il flag [Compressed](https://reference.aspose.com/slides/it/net/aspose.slides.export/swfoptions/compressed/) (abilitato per impostazione predefinita) e regola [JpegQuality](https://reference.aspose.com/slides/it/net/aspose.slides.export/swfoptions/jpegquality/) per bilanciare le dimensioni del file e la fedeltà delle immagini.

**A cosa serve 'ViewerIncluded' e quando dovrei disabilitarlo?**

[ViewerIncluded](https://reference.aspose.com/slides/it/net/aspose.slides.export/swfoptions/viewerincluded/) aggiunge un'interfaccia utente del lettore incorporata (controlli di navigazione, pannelli, ricerca). Disabilitalo se prevedi di utilizzare un lettore personalizzato o se hai bisogno di un frame SWF minimale senza UI.

**Cosa succede se un font sorgente manca sulla macchina di esportazione?**

Aspose.Slides sostituirà il font specificato tramite [DefaultRegularFont](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/defaultregularfont/) in [SwfOptions](https://reference.aspose.com/slides/it/net/aspose.slides.export/saveoptions/) per evitare un fallback non intenzionale.