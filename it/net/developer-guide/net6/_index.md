---
title: Pacchetto multipiattaforma per .NET 6 e versioni successive
linktitle: Pacchetto multipiattaforma
type: docs
weight: 235
url: /it/net/net6/
keywords:
- Aspose.Slides.NET6.CrossPlatform
- multipiattaforma
- .NET 6 support
- Linux
- macOS
- fontconfig
- libgdiplus
- System.Drawing.Common
- CS0433
- AWS Lambda
- .NET
- C#
- Aspose.Slides
description: "Scopri quando utilizzare il pacchetto Aspose.Slides.NET6.CrossPlatform: perché esiste, le piattaforme su cui funziona e cosa richiede su Linux al posto di libgdiplus."
---
## **Introduzione**

Aspose.Slides per .NET è pubblicato come due pacchetti NuGet. [Aspose.Slides.NET](https://www.nuget.org/packages/Aspose.Slides.NET/) disegna le diapositive tramite la libreria System.Drawing.Common di Microsoft. [Aspose.Slides.NET6.CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform/) le disegna invece con il proprio motore grafico. Questo articolo spiega perché esiste il secondo pacchetto, dove viene eseguito, cosa serve su Linux e come coesiste con System.Drawing.Common in un unico progetto.

## **Perché un pacchetto separato**

A partire da .NET 6, Microsoft supporta System.Drawing.Common [solo su Windows](https://learn.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only). Di conseguenza, su Linux Aspose.Slides.NET necessita dell’interruttore `System.Drawing.EnableUnixSupport` oltre alla libreria `libgdiplus`, e fallisce se il progetto fa riferimento a System.Drawing.Common 7 o successivo. [System Requirements](/slides/it/net/system-requirements/) descrive queste condizioni.

Aspose.Slides.NET6.CrossPlatform non utilizza System.Drawing.Common né `libgdiplus`. Il suo motore grafico è una libreria nativa inclusa nel pacchetto con una build per ogni piattaforma supportata. Entrambi i pacchetti forniscono gli stessi namespace e classi Aspose.Slides, quindi passare da uno all’altro modifica solo il riferimento al pacchetto, non il tuo codice.

| | Aspose.Slides.NET | Aspose.Slides.NET6.CrossPlatform |
|---|---|---|
| Grafica | System.Drawing.Common | Motore grafico nativo incluso nel pacchetto |
| Framework target | `net462`, `net6.0`, `netstandard2.0` | `net6.0` |
| Requisiti Linux | `libgdiplus` e l’interruttore `System.Drawing.EnableUnixSupport` | `fontconfig` |
| Alpine Linux | Supportato | Non supportato |

## **Piattaforme supportate**

Aspose.Slides.NET6.CrossPlatform funziona con .NET 6 e versioni successive su queste piattaforme:

- **Windows**: x86 e x64. La libreria nativa utilizza il runtime Microsoft Visual C++; vedere [System Requirements](/slides/it/net/system-requirements/).
- **Linux**: x64 con glibc 2.23 o successiva, e ARM64 con glibc 2.39 o successiva.
- **macOS**: x64 (Intel) e ARM64 (Apple silicon).

Non gira su Windows ARM64, su Alpine Linux o altre distribuzioni basate su musl invece di glibc, né su distribuzioni con una glibc più vecchia, come CentOS 7. Usa Aspose.Slides.NET su tali sistemi.

## **Installazione su Linux**

Su Linux, il pacchetto richiede la libreria `fontconfig`, ma non `libgdiplus`. Su Debian e Ubuntu, installa `fontconfig` e poi aggiungi il pacchetto al tuo progetto:

```bash
sudo apt-get update && sudo apt-get install -y libfontconfig1
dotnet add package Aspose.Slides.NET6.CrossPlatform
```

Su Debian e Ubuntu, `libfontconfig1` installa anche i font DejaVu, quindi il testo viene renderizzato senza ulteriori pacchetti di font. Senza `fontconfig`, la creazione di una [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) fallisce con una `TypeInitializationException` il cui `DllNotFoundException` interno segnala che `libfontconfig.so.1` non può essere aperto. [System Requirements](/slides/it/net/system-requirements/) include un breve programma che verifica la configurazione.

## **Host cloud e container**

Poiché non necessita di `libgdiplus`, Aspose.Slides.NET6.CrossPlatform è il pacchetto da usare su host Linux dove non è possibile installare `libgdiplus`. Richiede comunque `fontconfig` e i font, che le immagini base minimal potrebbero non includere. L’immagine base AWS Lambda per .NET 8, ad esempio, non contiene né l’uno né l’altro. In un’immagine container creata su di essa, esegui `dnf install -y fontconfig`, che installa anche i font Noto Sans.

Per le guide a piattaforme cloud specifiche, vedi [Aspose.Slides on Cloud Platforms](/slides/it/net/slides-on-cloud-platforms/).

## **Utilizzare System.Drawing.Common nello stesso progetto (CS0433)**

Un progetto che usa Aspose.Slides.NET6.CrossPlatform può anche fare riferimento a System.Drawing.Common, direttamente o tramite un altro pacchetto. L’attuale versione di Aspose.Slides non espone tipi pubblici nei namespace `System`, quindi le due librerie non entrano in conflitto, e puoi importare i namespace `Aspose.Slides` e `System.Drawing` nello stesso file.

Se il compilatore segnala l’errore CS0433 perché un tipo come `Image` o `Graphics` esiste sia in Aspose.Slides sia in System.Drawing.Common, il tuo progetto usa una versione più vecchia di Aspose.Slides. Aggiorna il pacchetto all’ultima versione. Aspose.Slides restituisce immagini renderizzate come oggetti [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), descritti in [Modern API](/slides/it/net/modern-api/).

## **FAQ**

**Devo modificare il mio codice quando passo da Aspose.Slides.NET a Aspose.Slides.NET6.CrossPlatform?**

No. Entrambi i pacchetti forniscono gli stessi namespace e classi Aspose.Slides, quindi devi solo sostituire il riferimento al pacchetto. Aspose.Slides.NET6.CrossPlatform non necessita dell’interruttore `System.Drawing.EnableUnixSupport`. Aggiungi solo uno dei due pacchetti a un progetto.

**Posso usare Aspose.Slides.NET6.CrossPlatform in un progetto .NET Framework?**

No. Il pacchetto mira solo a .NET 6 e versioni successive. Per .NET Framework 4.6.2 e successive, usa Aspose.Slides.NET.