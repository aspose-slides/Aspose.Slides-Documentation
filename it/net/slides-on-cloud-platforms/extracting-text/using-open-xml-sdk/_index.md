---
title: "Come estrarre testo da file PPT, PPTX e ODP usando Open XML SDK in .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /it/net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- piattaforme cloud
- integrazione cloud
- Open XML SDK
- estrazione testo PPTX
- elaborazione slide .NET
- estrazione testo presentazione
- slide master
- note del relatore
- estrazione testo dalle slide
- C#
description: "Scopri come estrarre testo da PPT, PPTX e ODP in .NET usando Open XML SDK, con accesso basato su XML, consigli sulle prestazioni e soluzioni di conversione per le app cloud."
---
## **Panoramica**

Questo articolo spiega come estrarre testo da file di presentazione utilizzando l'Open XML SDK in .NET. Si concentra sull'accesso diretto a XML per file PPTX, dove il testo può essere recuperato da elementi di slide strutturati senza rendere le slide o richiedere Microsoft PowerPoint. L'articolo descrive inoltre i vantaggi di prestazione, come un'elaborazione più rapida e un minore utilizzo di memoria.

Per i file PPT e ODP, l'articolo spiega che il testo non può essere estratto direttamente con l'Open XML SDK. È necessario prima convertire questi formati in PPTX, dopodiché il testo può essere estratto dal file risultante.

## **Open XML SDK**

L'**Open XML SDK** fornisce un metodo altamente strutturato ed efficiente per estrarre testo da file di presentazione—soprattutto **PPTX**, che segue lo standard Open XML. Offrendo accesso diretto all'XML sottostante, questo SDK consente una gestione più veloce e flessibile del contenuto delle slide rispetto ai metodi tradizionali.

## **Accesso XML diretto**

- **Analizza il testo direttamente**: l'Open XML SDK consente di estrarre testo dalle parti XML senza rendere le slide.  
- **Elementi strutturati**: poiché il testo è memorizzato in tag XML ben definiti, è più semplice recuperarlo e processarlo.

### **Esempio: estrarre testo direttamente dal contenuto XML di una slide**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## **Vantaggi delle prestazioni**

- **Estrazione più veloce**: evita il sovraccarico di apertura di PowerPoint o di altre API di alto livello.  
- **Minor utilizzo di memoria**: vengono accedute solo le parti XML rilevanti, riducendo il consumo di risorse.  
- **Nessun Microsoft PowerPoint necessario**: elimina la necessità di installazioni aggiuntive.

### **Esempio: estrarre testo in modo efficiente senza caricare l'intera presentazione**

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## **Identificazione degli elementi di testo**

### **Specifiche per l'estrazione del testo dalle presentazioni**

Quando si estrae testo dalle presentazioni, considerare questi fattori:

- **Il testo può trovarsi in diverse sezioni**: slide normali, slide master, layout o note del relatore.  
- **Segnaposti predefiniti**: slide master e layout possono includere segnaposti (ad es., “Fai clic per modificare lo stile del titolo master”) che non sono contenuti reali della presentazione.  
- **Filtrare testo vuoto o nascosto**: alcuni elementi potrebbero essere vuoti o non destinati alla visualizzazione.

### **Tag contenenti testo**

In un file **PPTX**, il testo è generalmente memorizzato in:
- elementi `<a:t>` all'interno di `<a:p>` (paragrafi)  
- elementi `<a:r>` (segmenti di testo all'interno dei paragrafi)

### **Esempio: estrarre tutti gli elementi di testo da una slide**

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## **ODP e PPT**

### **Impossibilità di estrarre il testo direttamente**

- A differenza di **PPTX**, **PPT** (formato binario) e **ODP** (OpenDocument Presentation) **non sono supportati** da Open XML SDK.  
- **PPT** conserva il contenuto in un formato binario chiuso, rendendo complessa l'estrazione del testo.  
- **ODP** si basa su **OpenDocument XML**, che differisce strutturalmente da PPTX.

### **Soluzione alternativa: conversione in PPTX**

Per estrarre testo da **PPT** o **ODP**, l'approccio consigliato è:

1. **Convertire PPT → PPTX** usando PowerPoint o uno strumento di terze parti.  
2. **Convertire ODP → PPTX** tramite LibreOffice o PowerPoint.  
3. **Estrarre il testo** dal nuovo PPTX usando Open XML SDK.

### **Esempio: conversione di ODP in PPTX tramite riga di comando di LibreOffice**

```sh
soffice --headless --convert-to pptx presentation.odp
```

## **Piattaforme e framework supportati**

- **Windows**: .NET Framework 4.6.1 e versioni successive, .NET Core 2.1+, .NET 5/6/7.  
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.  
- **Ambienti cloud**: Microsoft Azure Functions, AWS Lambda (.NET Core), container Docker.  
- **Compatibilità con le applicazioni Office**: non è necessaria l'installazione di Microsoft Office.  
- **Linguaggi di programmazione supportati**: Open XML SDK può essere usato con **C#**, **VB.NET**, **F#** e altri linguaggi supportati da .NET.

## **Conclusione**

Sfruttare l'**Open XML SDK** per l'**estrazione di testo da PPTX** offre sia efficienza sia chiarezza, mentre **PPT** e **ODP** richiedono un passaggio di conversione iniziale per una gestione fluida. Adottare questo approccio garantisce **alte prestazioni**, **flessibilità** e **ampia compatibilità** con le applicazioni .NET moderne.