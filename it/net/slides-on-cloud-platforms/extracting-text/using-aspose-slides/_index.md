---
title: "Come estrarre testo da PPT, PPTX e ODP con Aspose.Slides"
linktitle: Diapositive
type: docs
weight: 30
url: /it/net/extracting-text-on-cloud-platforms-using-aspose-slides/
keywords:
- piattaforme cloud
- integrazione cloud
- estrazione del testo
- estrarre testo
- PPT
- PPTX
- ODP
- file di presentazione
- multipiattaforma
- indipendente da Office
- note e commenti
- indicizzazione aziendale
- arricchimento dei dati
- .NET
- Aspose.Slides
description: "Estrai testo dalle presentazioni su popolari piattaforme cloud usando le API di Aspose.Slides, automatizzando ricerca, analisi ed esportazione per PPT, PPTX e ODP."
---
## **Introduzione**

Aspose.Slides fornisce un'**API potente e di alto livello** per estrarre testo da file di presentazione, inclusi **PPT, PPTX e ODP**. A differenza dell'Open XML SDK—che supporta solo PPTX e richiede una complessa analisi XML—Aspose.Slides semplifica l'estrazione del testo, permettendoti di concentrarti sull'integrazione del contenuto estratto nei tuoi flussi di lavoro.

## **Estrazione rapida del testo con PresentationFactory.Instance.GetPresentationText**

Per estrarre testo da una presentazione, l'**API Aspose.Slides** offre il metodo statico `PresentationFactory.Instance.GetPresentationText`. Include diverse overload per lavorare con un file di presentazione o con un flusso di dati, catturando il testo da **diapositive, diapositive master, layout, note e commenti**. Il testo estratto è accessibile tramite l'interfaccia `IPresentationText`.

Esempio d'uso:

```csharp
string filePath = "presentation.pptx";
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Unarranged;

IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText(filePath, mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text: " + slideText.Text);
    Console.WriteLine("Notes Text: " + slideText.NotesText);
    Console.WriteLine("Comments Text: " + slideText.CommentsText);
}
```

## **Modalità di funzionamento per GetPresentationText**

Il metodo `GetPresentationText` in `PresentationFactory` consente di perfezionare l'estrazione del testo utilizzando il parametro `TextExtractionArrangingMode`, che controlla come il testo è organizzato nell'output.

### **Modalità disponibili**

- **TextExtractionArrangingMode.Unarranged** – Estrae il testo in modo libero, ignorando il layout originale della diapositiva.  
- **TextExtractionArrangingMode.Arranged** – Mantiene l'ordine del testo in base alla sua posizione in ciascuna diapositiva.

Esempio di utilizzo:

```csharp
TextExtractionArrangingMode mode = TextExtractionArrangingMode.Arranged;
IPresentationText presentationText = PresentationFactory.Instance.GetPresentationText("presentation.pptx", mode);
ISlideText[] slideTexts = presentationText.SlidesText;

foreach (var slideText in slideTexts)
{
    Console.WriteLine("Slide Text (preserving order): " + slideText.Text);
}
```

## **Vantaggi principali dei metodi PresentationFactory**

- **Nessuna necessità di caricare intere presentazioni**: riduce il consumo di memoria e aumenta la velocità di elaborazione.  
- **Ottimizzato per file di grandi dimensioni**: gestisce in modo efficiente anche presentazioni volumose, estraendo il testo rapidamente.  
- **Recupera note e commenti**: include le annotazioni degli utenti per una copertura completa del contenuto.  
- **Ideale per indicizzazione e analisi del contenuto**: perfetto per sistemi aziendali che richiedono elaborazione automatica e arricchimento dei dati.  
- **Indipendente da Office**: funziona senza l'installazione di Microsoft PowerPoint, offrendo una soluzione davvero autonoma.  
- **Supporto multi-formato**: funziona senza problemi con **PPT, PPTX e ODP**.  
- **API flessibile e potente**: fornisce metodi versatili per l'estrazione strutturata del testo.  
- **Copertura completa delle diapositive**: estrae il testo da **layout, diapositive master, diapositive standard, sfondi, note del relatore e commenti**.  
- **Compatibilità cross‑platform**: opera su **Windows, Linux, macOS** e negli ambienti cloud.  
- **Alte prestazioni e scalabilità**: adatto per **applicazioni SaaS** e distribuzioni aziendali su larga scala.

## **Sistemi operativi supportati**

Aspose.Slides è eseguibile su una varietà di sistemi operativi:

- **Windows** (ad esempio Windows 7, 8, 10, 11 e edizioni Server)  
- **Linux** (varie distribuzioni, incluse Ubuntu, Debian, Fedora, CentOS, ecc.)  
- **macOS** (incluse versioni recenti come 10.15 Catalina e successive)  

## **Linguaggi di programmazione supportati**

Aspose.Slides si integra con più piattaforme e linguaggi:

- **C#** – Principalmente supportato tramite Aspose.Slides per .NET.  
- **Java** – API completa disponibile con Aspose.Slides per Java.  
- **C++** – Sfrutta Aspose.Slides per applicazioni C++ critiche per le prestazioni.  
- **Python via .NET** – Integra la funzionalità di Aspose.Slides usando l'interoperabilità .NET.  
- **Altri linguaggi compatibili con .NET** – Utilizza la libreria in qualsiasi ambiente supportato da .NET.  

## **Conclusione**

Aspose.Slides offre un'**estrazione completa del testo** per presentazioni PowerPoint e OpenDocument, supportando **vari formati di file, strutturazione intuitiva del testo e implementazione semplice** rispetto all'Open XML SDK. Da **diapositive e note a contenuti di modelli**, **Aspose.Slides** è una soluzione ad alta efficienza e ricca di funzionalità per estrarre e gestire il testo delle presentazioni.