---
title: Requisiti di sistema
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
description: "Scopri i requisiti di sistema di Aspose.Slides per .NET. Garantisci un supporto fluido per PowerPoint e OpenDocument su Windows, Linux e macOS."
---
## **Introduzione**

Aspose.Slides per .NET non richiede l'installazione di Microsoft PowerPoint perché Aspose.Slides è un motore indipendente di creazione, conversione, impaginazione e rendering di documenti Microsoft PowerPoint.

## **Sistemi operativi supportati**

Aspose.Slides per .NET supporta qualsiasi sistema operativo a 32 o 64 bit su cui è installato il framework .NET o Mono, includendo (ma non limitandosi a):

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

Aspose.Slides per .NET supporta i framework .NET e Mono:

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
- Supporto COM Interop (COM, C++, VBScript)

### **Framework Mono**

- Supporto MONO su piattaforme MAC e Linux

## **Ambienti di sviluppo**

Aspose.Slides per .NET può essere usato per sviluppare applicazioni in qualsiasi ambiente di sviluppo che targetta la piattaforma .NET, ma i seguenti ambienti sono esplicitamente supportati:

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

Attualmente, esistono due build principali di Aspose.Slides — Aspose.Slides.NET e Aspose.Slides.NET6.CrossPlatform.

### **[Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET)**

Questa è la versione principale del prodotto. Utilizza il motore grafico standard di .NET.
- Su piattaforme non Windows, potrebbe essere necessario installare la libreria `libgdiplus` e le sue dipendenze.
- Prima della versione Aspose.Slides 25.3, per piattaforme non Windows, era necessario utilizzare la DLL .NET Standard 2.0 dal pacchetto ZIP di Aspose.Slides.
- A partire dalla versione Aspose.Slides 25.3, il pacchetto NuGet può essere usato direttamente anche su sistemi non Windows.
- Quando si esegue su sistemi non Windows, la tua applicazione deve includere la seguente riga all'avvio:
```cs
AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
```
- **A partire dalla versione 25.3, puoi usare questo pacchetto su piattaforme che supportano .NET, come Linux aarch64 (ARM64).**

#### **Pacchetti aggiuntivi per Linux Alpine**

Quando si esegue Aspose.Slides per .NET in un contenitore Alpine Linux, installare solo `libgdiplus` potrebbe non essere sufficiente. I contenitori Alpine normalmente non includono i font di default. Se non sono disponibili font, le operazioni di rendering o conversione potrebbero fallire con un errore simile a:
```text
System.ArgumentException: Font '?' cannot be found
```
Per usare Aspose.Slides su Alpine, installa `libgdiplus` insieme ad almeno un pacchetto di font.

**Opzione 1: Font DejaVu**

L'opzione consigliata è installare il pacchetto ttf-dejavu:
```
RUN apk add --no-cache \
    libgdiplus \
    ttf-dejavu
```

Il pacchetto `ttf-dejavu` installa automaticamente le dipendenze necessarie relative ai font, come `fontconfig`, `encodings`, `mkfontscale` e `mkfontdir`. Per la maggior parte dei casi d'uso non sono richiesti ulteriori pacchetti di font.

**Opzione 2: Font Microsoft Core**

Se le tue presentazioni utilizzano font specifici di Microsoft, come Arial, Times New Roman, Courier New o Verdana, installa invece i Microsoft Core Fonts:
```
RUN apk add --no-cache \
    libgdiplus \
    fontconfig \
    msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -fv
```

Utilizza questa opzione solo quando le presentazioni elaborate richiedono i font Microsoft. Per la maggior parte degli scenari, installare `ttf-dejavu` è più semplice e affidabile.

### **[Aspose.Slides for .NET 6 CrossPlatform](https://www.nuget.org/packages/Aspose.Slides.NET6.CrossPlatform)**

Questa è la versione di Aspose.Slides che utilizza un motore grafico cross‑platform personalizzato sviluppato dal team di Aspose.Slides.  
Su piattaforme non Windows, potrebbe essere necessaria la libreria `fontconfig`.

**Piattaforme supportate**
- *Windows*: x86, x86_64  
- *Linux*: x86_64, ARM64 (aarch64)
- *macOS*: x86_64, ARM64 (aarch64)

**Piattaforme non supportate**
- *Windows 11 ARM* (ARM64) — *Attualmente non considerato*

{{%  alert  title="Note"  color="primary"  %}}  
Per Linux x64 è richiesto GLIBC 2.23+; per Linux ARM64 è richiesto GLIBC 2.39+. Sistemi come CentOS 7 (GLIBC 2.14) non sono supportati. Se devi eseguire Aspose.Slides su CentOS 7 o altri sistemi incompatibili (ad esempio Alpine), utilizza il pacchetto standard: [Aspose.Slides for .NET](https://nuget.org/packages/Aspose.Slides.NET).  
{{% /alert %}} 

## **FAQ**

**Devo installare Microsoft PowerPoint per le conversioni e il rendering?**

No, PowerPoint non è necessario; Aspose.Slides è un motore autonomo per [creare](/slides/it/net/create-presentation/), modificare, [convertire](/slides/it/net/convert-presentation/), e [renderizzare](/slides/it/net/convert-powerpoint-to-png/) le presentazioni.

**Quali font sono necessari per un rendering corretto?**

I font utilizzati nella presentazione, o sostituti adeguati, devono essere disponibili nel sistema operativo. Su Linux e macOS, installa pacchetti di font comuni per garantire un rendering coerente.

Per i contenitori Alpine Linux, installa almeno un pacchetto di font oltre a `libgdiplus`. La configurazione minima consigliata è `libgdiplus` con `ttf-dejavu`. Se sono richiesti font Microsoft come Arial, Times New Roman, Courier New o Verdana, utilizza `msttcorefonts-installer` insieme a `fontconfig`.

**Perché un font personalizzato viene renderizzato come fallback o testo mancante su Linux?**

Se il file del font contiene voci della tabella dei nomi incoerenti o corrotte, lo stack di corrispondenza dei font di Linux (FreeType/fontconfig) può selezionare un record non valido, provocando la mancata risoluzione del font. L'uso di una versione del font con le voci della tabella dei nomi corrette o l'installazione di un sostituto coerente risolve il problema.