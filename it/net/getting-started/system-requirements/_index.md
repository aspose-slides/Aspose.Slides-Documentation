---
title: Requisiti di Sistema
type: docs
weight: 60
url: /it/net/system-requirements/
keywords:
- requisiti di sistema
- sistema operativo
- installazione
- dipendenze
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Scopri i requisiti di sistema di Aspose.Slides per .NET. Garantisci un supporto senza interruzioni per PowerPoint e OpenDocument su Windows, Linux e macOS."
---
## **Introduzione**

Aspose.Slides for .NET non richiede l'installazione di Microsoft PowerPoint perché Aspose.Slides è un motore indipendente per la creazione, conversione, impaginazione e rendering di documenti Microsoft PowerPoint.

## **Sistemi operativi supportati**

Aspose.Slides for .NET supporta qualsiasi sistema operativo a 32-bit o 64-bit su cui è installato .NET o il framework Mono, includendo (ma non limitandosi a):

### **Windows**

- Microsoft Windows 2000 Server ( x64, x86)
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2022 Server
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)
- Microsoft Windows 11 ( x64, x86)
- Microsoft Azure

### **Linux**

- Linux (Ubuntu, OpenSUSE, CentOS, Alpine e altri)

### **Mac**

- Mac OS X

## **Framework supportati**

Aspose.Slides for .NET supporta i framework .NET e Mono:

### **Framework .NET**

- .NET Framework 2.0
- .NET Framework 3.5
- .NET Framework 4.0
- .NET Framework 4.0_ClientProfile
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.5.2
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.5.0
- .NET Framework 4.5.1
- .NET Framework 4.6.0
- .NET Framework 4.6.2
- .NET Framework 4.7
- .NET Framework 4.7.2
- .NET 5
- .NET 6
- .NET 7
- .NET 8
- .NET 9
- .NET Core
- COM Interop support (COM, C++, VBScript)

### **Framework Mono**

- Supporto MONO su piattaforme MAC e Linux

## **Ambienti di sviluppo**

Aspose.Slides for .NET può essere usato per sviluppare applicazioni in qualsiasi ambiente di sviluppo che mira alla piattaforma .NET, ma questi ambienti sono supportati esplicitamente:

- Microsoft Visual Studio 2005
- Microsoft Visual Studio 2008
- Microsoft Visual Studio 2010
- Microsoft Visual Studio 2012
- Microsoft Visual Studio 2013
- Microsoft Visual Studio 2015
- Microsoft Visual Studio 2017
- Microsoft Visual Studio 2019
- Microsoft Visual Studio 2022

## **Build principali di Aspose.Slides**

Attualmente, ci sono due build principali di Aspose.Slides — Aspose.Slides.NET e Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Questa è la versione principale del prodotto. Utilizza il motore grafico standard .NET.
- Su piattaforme non Windows, potrebbe essere necessario installare la libreria `libgdiplus` e le relative dipendenze.
- Prima della versione Aspose.Slides 25.3, su piattaforme non Windows era necessario usare la DLL .NET Standard 2.0 dal pacchetto ZIP di Aspose.Slides.
- A partire dalla versione Aspose.Slides 25.3, il pacchetto NuGet può essere usato direttamente anche su sistemi non Windows.
- Quando si esegue su sistemi non Windows, l'applicazione deve includere la seguente riga all'avvio:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **A partire dalla versione 25.3, è possibile utilizzare questo pacchetto su piattaforme che supportano .NET, come Linux aarch64 (ARM64).**

#### **Pacchetti aggiuntivi per Linux Alpine**

Quando si esegue Aspose.Slides for .NET in un container Alpine Linux, l'installazione di `libgdiplus` da sola potrebbe non essere sufficiente. I container Alpine di solito non includono font di default. Se non sono disponibili font, le operazioni di rendering o conversione potrebbero fallire con un errore simile a:

```text
System.ArgumentException: Font '?' cannot be found
```
Per utilizzare Aspose.Slides su Alpine, installare `libgdiplus` insieme ad almeno un pacchetto di font.

**Opzione 1: Font DejaVu**

L'opzione consigliata è installare il pacchetto ttf-dejavu:

```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Il pacchetto `ttf-dejavu` installa automaticamente le dipendenze necessarie relative ai font, come `fontconfig`, `encodings`, `mkfontscale` e `mkfontdir`. Non sono richiesti pacchetti di font aggiuntivi per la maggior parte dei casi d'uso.

**Opzione 2: Microsoft Core Fonts**

Se le tue presentazioni usano font specifici di Microsoft, come Arial, Times New Roman, Courier New o Verdana, installa invece Microsoft Core Fonts:

```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Usa questa opzione solo quando le presentazioni da elaborare richiedono i font Microsoft. Per la maggior parte degli scenari, installare `ttf-dejavu` è più semplice e affidabile.

**Requisiti aggiuntivi per la globalizzazione**

Per abilitare un corretto supporto alla globalizzazione su Alpine, installa il pacchetto `icu-libs` e disabilita la modalità invariata:

```dockerfile
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN apk --no-cache add icu-libs
```

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Questa è la versione di Aspose.Slides che utilizza un motore grafico cross-platform personalizzato sviluppato dal team di Aspose.Slides. Su piattaforme non Windows, potrebbe essere necessaria la libreria `fontconfig`.

**Piattaforme supportate**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Piattaforme non supportate**
- *Windows 11 ARM* (ARM64) — *Attualmente non considerato*

{{%  alert  title="Notes"  color="info"  %}}  
Per Linux x64, è richiesto GLIBC 2.23+; per Linux ARM64, è richiesto GLIBC 2.39+. Sistemi come CentOS 7 (GLIBC 2.14) non sono supportati. Se è necessario eseguire Aspose.Slides su CentOS 7 o altri sistemi incompatibili (ad esempio Alpine), utilizzare il pacchetto standard: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

### Devo avere Microsoft PowerPoint installato per le conversioni e il rendering?

No, PowerPoint non è necessario; Aspose.Slides è un motore autonomo per [creare](/slides/it/net/create-presentation/), modificare, [convertire](/slides/it/net/convert-presentation/), e [renderizzare](/slides/it/net/convert-powerpoint-to-png/) le presentazioni.

### Quali font sono necessari per un rendering corretto?

I font utilizzati nella presentazione, o sostituti adeguati, devono essere disponibili nel sistema operativo. Su Linux e macOS, installa pacchetti di font comuni per garantire un rendering coerente.

Per i container Alpine Linux, installa almeno un pacchetto di font oltre a `libgdiplus`. La configurazione minima consigliata è `libgdiplus` con `ttf-dejavu`. Se sono richiesti font Microsoft come Arial, Times New Roman, Courier New o Verdana, usa `msttcorefonts-installer` insieme a `fontconfig`.

### Perché un font personalizzato viene visualizzato come fallback o testo mancante su Linux?

Se il file del font contiene voci della tabella dei nomi incoerenti o corrotte, lo stack di corrispondenza dei font su Linux (FreeType/fontconfig) può selezionare un record non valido, causando il mancato riconoscimento del font. Utilizzare una versione del font con record della tabella dei nomi corretti o installare un sostituto coerente risolve il problema.