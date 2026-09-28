---
title: Panoramica delle funzionalità
type: docs
weight: 94
url: /it/net/features-overview/
keywords:
- funzionalità
- piattaforme supportate
- formati file
- conversione
- renderizzazione
- contenuto della presentazione
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Esamina cosa copre Aspose.Slides per .NET prima di valutarlo: piattaforme supportate, formati file, rendering delle diapositive e contenuti che puoi creare e modificare."
---
## **Panoramica**

Aspose.Slides for .NET è una libreria di classi per creare, leggere, modificare, convertire e rendere presentazioni PowerPoint e OpenDocument. Non ha un'interfaccia utente propria e non richiede Microsoft PowerPoint o Office, così puoi usarla in applicazioni console, applicazioni desktop come Windows Forms, applicazioni web e servizi web. Questo articolo riassume ciò che la libreria copre e collega gli articoli che descrivono ogni area.

## **Piattaforme supportate**

Aspose.Slides for .NET è distribuito come due pacchetti NuGet con la stessa API:

|**Pacchetto**|**Build inclusi nel pacchetto**|**Sistemi operativi**|
| :- | :- | :- |
|[Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/)|.NET Framework 4.6.2, .NET Standard 2.0 e .NET 6. Usalo con .NET Framework 4.6.2 o successivo, o con .NET 6 o successivo.|Windows. Linux e macOS con la libreria `libgdiplus` e l'opzione `System.Drawing.EnableUnixSupport`.|
|[Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/)|.NET 6. Usalo con .NET 6 o successivo.|Windows (x86, x64), Linux (x64 con glibc 2.23 o successivo, ARM64 con glibc 2.39 o successivo) e macOS (x64, ARM64).|

[Installazione](/slides/it/net/installation/) spiega quale pacchetto scegliere e cosa richiede ciascuno su Linux. [Requisiti di sistema](/slides/it/net/system-requirements/) elenca le piattaforme supportate in dettaglio.

## **Formati di file e conversioni**

Aspose.Slides apre e salva presentazioni PPT, PPTX, PPS, POT, PPSX, POTX, PPTM, PPSM, POTM, ODP, OTP, FODP e PowerPoint XML. Importa contenuti PDF e HTML nelle diapositive e salva le presentazioni come PDF, XPS, HTML, HTML5, TIFF, GIF animato, SWF, Markdown e XAML. [Formati di file supportati](/slides/it/net/supported-file-formats/) elenca ogni formato con l'API che lo legge o lo scrive.

|**Funzionalità**|**Descrizione**|
| :- | :- |
|[PPT e PPTX](/slides/it/net/ppt-vs-pptx/)|Legge e scrive sia il formato binario PowerPoint 97-2003 sia il formato Office Open XML.| 
|[Conversione da PPT a PPTX](/slides/it/net/convert-ppt-to-pptx/)|Converti le presentazioni PPT legacy in PPTX.| 
|[Portable Document Format (PDF)](/slides/it/net/convert-powerpoint-to-pdf/)|Esporta le presentazioni in PDF, inclusi i documenti PDF/A e PDF/UA.| 
|[XML Paper Specification (XPS)](/slides/it/net/convert-powerpoint-to-xps/)|Esporta le presentazioni in documenti XPS.| 
|[Tagged Image File Format (TIFF)](/slides/it/net/convert-powerpoint-to-tiff/)|Esporta le presentazioni in immagini TIFF.| 
|[HTML](/slides/it/net/convert-powerpoint-to-html/)|Esporta le presentazioni in HTML e HTML5.| 
|[Importazione PDF e HTML](/slides/it/net/import-presentation/)|Crea diapositive da pagine PDF e contenuti HTML.| 

## **Rendering delle presentazioni**

Aspose.Slides rende le diapositive e le forme individuali come immagini PNG, JPEG, BMP, GIF, TIFF e SVG, e le diapositive come metafili EMF. Vedi [Converti le diapositive della presentazione in immagini](/slides/it/net/convert-slide/), [Rendi una diapositiva come immagine SVG](/slides/it/net/render-a-slide-as-an-svg-image/), e [Crea miniature di forme](/slides/it/net/create-shape-thumbnails/).

## **Funzionalità del contenuto**

Aspose.Slides ti consente di creare, leggere e modificare quasi tutti i contenuti di una presentazione:

|**Area**|**Cosa puoi fare**|
| :- | :- |
|[Diapositive](/slides/it/net/presentation-slide/)|Aggiungi, clona, riordina e rimuovi diapositive; applica layout e master; organizza le diapositive in sezioni; cambia la dimensione della diapositiva.| 
|[Design](/slides/it/net/presentation-design/)|Imposta sfondi, colori del tema, intestazioni e piè di pagina, e caratteri.| 
|[Testo](/slides/it/net/manage-text/)|Crea e modifica riquadri di testo, paragrafi e porzioni; imposta caratteri, colori, elenchi puntati e allineamento; trova e sostituisci il testo.| 
|[Forme](/slides/it/net/powerpoint-shapes/)|Crea AutoShape, linee, connettori, forme raggruppate e riquadri immagine; imposta posizione, dimensione, linea e riempimento solido, gradiente o a motivo; trova una forma tramite il suo testo alternativo.| 
|[Tabelle](/slides/it/net/powerpoint-table/), [grafici](/slides/it/net/powerpoint-charts/), e [SmartArt](/slides/it/net/powerpoint-smartart/)|Crea e modifica tabelle, grafici Microsoft Office e diagrammi SmartArt.| 
|[Media](/slides/it/net/manage-media-files/), [oggetti OLE](/slides/it/net/manage-ole/), e [controlli ActiveX](/slides/it/net/activex/)|Aggiungi riquadri audio e video incorporati o collegati, incorpora oggetti OLE e aggiungi, modifica o rimuovi controlli ActiveX.| 
|[Note](/slides/it/net/presentation-notes/) e [commenti](/slides/it/net/presentation-comments/)|Aggiungi, leggi e modifica note del relatore e commenti di revisione.| 
|[Animazione](/slides/it/net/powerpoint-animation/) e [transizioni](/slides/it/net/slide-transition/)|Applica effetti di animazione alle forme, imposta transizioni diapositive e configura le impostazioni della presentazione.| 
|[Sicurezza](/slides/it/net/presentation-security/)|Cifra le presentazioni con una password, imposta protezione in scrittura e lavora con firme digitali.| 
|[Macro VBA](/slides/it/net/presentation-via-vba/)|Aggiungi, estrai e rimuovi moduli VBA nelle presentazioni con macro.| 
|[Proprietà](/slides/it/net/presentation-properties/)|Leggi e modifica le proprietà del documento.| 

## **FAQ**

**Devo installare Microsoft PowerPoint sul server o sul PC perché la libreria funzioni?**

No. PowerPoint non è richiesto; Aspose.Slides è un motore autonomo per creare, modificare, convertire e rendere presentazioni.

**Come funziona il multithreading? È possibile parallelizzare l'elaborazione?**

È sicuro elaborare documenti diversi in thread differenti; lo stesso oggetto [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) non deve essere utilizzato da [multiple threads](/slides/it/net/multithreading/) contemporaneamente.

**Sono supportate le password dei file e la crittografia?**

Sì. [Puoi](/slides/it/net/password-protected-presentation/) aprire presentazioni criptate, impostare o rimuovere una password di apertura e di scrittura, e verificare lo stato di protezione.

**Devo preoccuparmi dei caratteri nei container Linux?**

Sì. I caratteri utilizzati nelle tue presentazioni, o i sostituti adeguati, devono essere installati sul sistema perché il testo venga visualizzato correttamente. Puoi anche [specificare le directory dei font](/slides/it/net/custom-font/) nella tua applicazione. [Installazione](/slides/it/net/installation/) elenca i prerequisiti Linux di ciascun pacchetto.

**Ci sono limitazioni nella versione di valutazione?**

Sì. Senza una [licenza](/slides/it/net/licensing/), Aspose.Slides aggiunge una filigrana di valutazione a ogni diapositiva salvata e tronca il testo letto dalle presentazioni. È disponibile una [licenza temporanea di 30 giorni](https://purchase.aspose.com/temporary-license/) per testare tutte le funzionalità.

**È supportata l'importazione di formati esterni in una presentazione (PDF o HTML in PPTX)?**

Sì. Puoi aggiungere [pagine PDF e contenuto HTML](/slides/it/net/import-presentation/) a una presentazione, trasformandoli in diapositive.