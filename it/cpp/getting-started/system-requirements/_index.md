---
title: Requisiti di sistema
type: docs
weight: 80
url: /it/cpp/system-requirements/
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
- C++
- Aspose.Slides
description: "Scopri i requisiti di sistema di Aspose.Slides per C++. Garantisci un supporto fluido a PowerPoint e OpenDocument su Windows, Linux e macOS."
---
## **Introduzione**

Aspose.Slides non richiede l'installazione di Microsoft PowerPoint perché Aspose.Slides è un motore indipendente per la creazione, conversione, impaginazione e rendering di documenti Microsoft PowerPoint.

## **Sistemi operativi supportati**
Aspose.Slides per C++ è una libreria nativa C++. Aspose.Slides per C++ supporta i seguenti sistemi operativi e piattaforme a 64 bit e 32 bit:

### **Windows**
- Microsoft Windows Server 2008 (x64, x86)
- Microsoft Windows Server 2012 (x64, x86)
- Microsoft Windows Server 2012 R2 (x64, x86)
- Microsoft Windows Server 2016 (x64, x86)
- Microsoft Windows Server 2019 (x64, x86)
- Microsoft Windows XP (x64, x86)
- Microsoft Windows 7 (x64, x86)
- Microsoft Windows 8, 8.1 (x64, x86)
- Microsoft Windows 10 (x64, x86)

### **Linux**
- Ubuntu 16.04 o versioni successive.
- CentOS 8 o versioni successive.
- Fedora 24 o versioni successive.
- Altri Linux x86_64 con glibc 2.23 o versioni successive.

### **macOS**
- macOS Monterey 12.1 o versioni successive.

## **Ambienti di sviluppo**
È possibile utilizzare Aspose.Slides per C++ durante lo sviluppo di applicazioni per Windows, Linux o macOS.

### **Windows**
- Microsoft Visual Studio 2017 o versioni successive.
- CMake 3.18 o versioni successive.

### **Linux**
- Clang 3.9 o versioni successive.
- GCC 6.1 o versioni successive.
- CMake 3.18 o versioni successive.

### **macOS**
- Xcode 13.4 o versioni successive.

## **FAQ**

**Devo avere Microsoft PowerPoint installato per le conversioni e il rendering?**

No, PowerPoint non è richiesto; Aspose.Slides è un motore autonomo per [creare](/slides/it/cpp/create-presentation/), modificare, [convertire](/slides/it/cpp/convert-presentation/), e [renderizzare](/slides/it/cpp/convert-powerpoint-to-png/) presentazioni.

**Quali caratteri sono necessari per un rendering corretto?**

In pratica, i caratteri utilizzati nella presentazione o i corretti [sostituti](/slides/it/cpp/font-substitution/) devono essere disponibili. Per garantire un rendering coerente su Linux/macOS, è consigliabile installare pacchetti di caratteri comuni.

**Perché un carattere personalizzato viene visualizzato come fallback o testo mancante su Linux?**

Se il file del carattere contiene voci della tabella dei nomi incoerenti o corrotte, lo stack di corrispondenza dei caratteri di Linux (FreeType/fontconfig) può selezionare un record non valido, causando la mancata risoluzione del carattere. Utilizzare una versione del carattere con le voci della tabella dei nomi corrette o installare una sostituzione coerente risolve il problema.