---
title: Automatizzare la localizzazione delle presentazioni in .NET
linktitle: Localizzazione delle presentazioni
type: docs
weight: 100
url: /it/net/presentation-localization/
keywords:
- cambia lingua
- controllo ortografico
- ID lingua
- PowerPoint
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Automatizza la localizzazione di diapositive PowerPoint e OpenDocument in .NET con Aspose.Slides, usando esempi pratici di codice C# e suggerimenti per una distribuzione globale più veloce."
---
## **Panoramica**

Questo articolo spiega come impostare `LanguageId` per il testo in una presentazione utilizzando Aspose.Slides. Mostra come aprire una presentazione, aggiungere una forma con testo, assegnare un identificatore di lingua a una porzione di testo e salvare il risultato come file PPTX.

## **Modifica della lingua per una presentazione e il testo di una forma**
- Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
- Ottieni il riferimento di una diapositiva usando il suo indice.
- Aggiungi un'AutoShape di tipo Rettangolo alla diapositiva.
- Aggiungi del testo al TextFrame.
- Imposta LanguageId sul testo.
- Scrivi la presentazione come file PPTX.

L'implementazione dei passaggi precedenti è mostrata di seguito in un esempio.

```c#
using (Presentation pres = new Presentation("test0.pptx"))
{
    IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
    shape.AddTextFrame("Text to apply spellcheck language");
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.LanguageId = "en-EN";

    pres.Save("test1.pptx",Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **FAQ**

**L'ID lingua attiva la traduzione automatica del testo?**

No. [LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/languageid/) in Aspose.Slides memorizza la lingua per il controllo ortografico e la verifica grammaticale, ma non traduce né modifica il contenuto del testo. È un metadato che PowerPoint comprende per la revisione.

**L'ID lingua influisce sulla sillabazione e sulle interruzioni di riga durante il rendering?**

In Aspose.Slides, [LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/languageid/) è destinato alla revisione. La qualità della sillabazione e l'adattamento delle righe dipendono principalmente dalla disponibilità di [font appropriati](/slides/it/net/powerpoint-fonts/) e dalle impostazioni di layout/interruzione di riga per il sistema di scrittura. Per garantire un rendering corretto, rendi disponibili i font necessari, configura le [regole di sostituzione dei font](/slides/it/net/font-substitution/) e/o [incorpora i font](/slides/it/net/embedded-font/) nella presentazione.

**Posso impostare lingue diverse all'interno di un singolo paragrafo?**

Sì. [LanguageId](https://reference.aspose.com/slides/it/net/aspose.slides/baseportionformat/languageid/) viene applicato a livello di porzione di testo, quindi un singolo paragrafo può mescolare più lingue con impostazioni di revisione distinte.