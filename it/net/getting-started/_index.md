---
title: Guida introduttiva
type: docs
weight: 10
url: /it/net/getting-started/
keywords:
- primi passi
- requisiti di sistema
- installazione
- prima presentazione
- NuGet
- elaborazione PPT
- elaborazione PPTX
- elaborazione ODP
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Il percorso da un nuovo progetto .NET a una prima presentazione salvata con Aspose.Slides: verifica i requisiti, installa il pacchetto, esegui un primo programma e prosegui con le attività comuni."
---
## **Panoramica**

Segui i quattro passaggi di seguito nell'ordine indicato. Ogni passaggio indica cosa fare e collega all'articolo con i dettagli. Valutazione, licenza e supporto sono trattati dopo i passaggi.

## **Passo 1: Verificare i requisiti di sistema**

Aspose.Slides per .NET è compatibile con Windows, Linux e macOS. [Requisiti di sistema](/slides/it/net/system-requirements/) elenca i sistemi operativi e le versioni .NET supportate da ciascun pacchetto, e le librerie aggiuntive richieste da Linux.

## **Passo 2: Installare il pacchetto**

Aspose.Slides per .NET è distribuito tramite NuGet come due pacchetti che forniscono le stesse classi. Aggiungi uno di essi al tuo progetto:

- Su Windows: `dotnet add package Aspose.Slides.NET`
- Su Linux e macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform`. Su Linux, installa prima la libreria `fontconfig`.
- Su Alpine Linux e su sistemi Linux la cui glibc è più vecchia di 2.23 (x64) o 2.39 (ARM64): Aspose.Slides.NET, con la libreria `libgdiplus` installata.

[Installazione](/slides/it/net/installation/) fornisce i comandi Linux, l'impostazione di avvio aggiuntiva necessaria a Aspose.Slides.NET su Linux e i passaggi per Visual Studio.

## **Passo 3: Creare la prima presentazione**

Il [quick start sulla home page di Aspose.Slides per .NET](/slides/it/net/#your-first-presentation) è un programma console completo: aggiunge una casella di testo a una diapositiva e salva la presentazione come file PPTX. [Creare presentazioni](/slides/it/net/create-presentation/) spiega gli stessi passaggi in modo più dettagliato e mostra come aprire una presentazione esistente e salvarla in un altro formato.

## **Passo 4: Proseguire con le attività comuni**

- [Aprire una presentazione](/slides/it/net/open-presentation/)
- [Salvare una presentazione](/slides/it/net/save-presentation/)
- [Convertire una presentazione in PDF](/slides/it/net/convert-powerpoint-to-pdf/)
- [Renderizzare le diapositive come immagini](/slides/it/net/convert-slide/)
- [Modificare il testo della presentazione](/slides/it/net/manage-text/)
- [Esempi per elemento della diapositiva](/slides/it/net/examples/)

## **Valutare e licenziare**

Senza licenza, Aspose.Slides funziona in modalità di valutazione: aggiunge una filigrana a ogni diapositiva salvata e tronca il testo letto dalle presentazioni.

- [Valutare Aspose.Slides](/slides/it/net/evaluate-aspose-slides/) descrive le limitazioni della valutazione e come richiedere una licenza temporanea.
- [Licenza](/slides/it/net/licensing/) mostra come applicare una licenza da un file, stream o risorsa incorporata.
- [Licenza a consumo](/slides/it/net/metered-licensing/) tratta la licenza fatturata in base all'uso.
- [Formati di file supportati](/slides/it/net/supported-file-formats/) elenca i formati che Aspose.Slides può caricare e salvare.

## **Ottenere assistenza**

[Supporto prodotto](/slides/it/net/product-support/) spiega come porre una domanda sul [forum di supporto gratuito](https://forum.aspose.com/c/slides/11) e cosa includere quando si segnala un problema.

## **FAQ**

**Devo avere Microsoft PowerPoint installato?**

No. Aspose.Slides legge e scrive i file di presentazione in autonomo e non utilizza PowerPoint, quindi funziona anche su server e su Linux.

**Quale pacchetto devo usare per un'applicazione .NET Framework?**

Aspose.Slides.NET. Include build per .NET Framework 4.6.2 e versioni successive, .NET 6 e versioni successive, e .NET Standard 2.0. Aspose.Slides.NET6.CrossPlatform richiede .NET 6 o versioni successive.