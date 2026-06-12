---
title: Requisiti di sistema
type: docs
weight: 60
url: /it/php-java/system-requirements/
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
- PHP
- Aspose.Slides
description: "Scopri i requisiti di sistema di Aspose.Slides per PHP tramite Java. Garantisci un supporto fluido per PowerPoint e OpenDocument su Windows, Linux e macOS."
---
## **Introduzione**

Aspose.Slides per PHP tramite Java non richiede alcun prodotto di terze parti come Microsoft PowerPoint installato. Aspose.Slides stesso è un motore per creare, modificare, convertire e renderizzare documenti in vari formati, inclusi i formati di presentazione Microsoft PowerPoint.

## **Sistemi Operativi Supportati**

Aspose.Slides per Java supporta qualsiasi sistema operativo a 32 o 64 bit che esegue il runtime Java, inclusi, ma non limitati a:

### **Windows**
- Microsoft Windows 2003 Server ( x64, x86)
- Microsoft Windows 2008 Server ( x64, x86)
- Microsoft Windows 2012 Server ( x64, x86)
- Microsoft Windows 2012 R2 Server ( x64, x86)
- Microsoft Windows 2016 Server ( x64, x86)
- Microsoft Windows 2019 Server ( x64, x86)
- Microsoft Windows Vista ( x64, x86)
- Microsoft Windows XP ( x64, x86)
- Microsoft Windows 7 ( x64, x86)
- Microsoft Windows 8, 8.1 ( x64, x86)
- Microsoft Windows 10 ( x64, x86)

### **Linux**
- Linux (Ubuntu, OpenSUSE, CentOS e altri)

### **Mac**
- Mac OS X

## **FAQ**

**Devo avere Microsoft PowerPoint installato per le conversioni e il rendering?**

No, PowerPoint non è necessario; Aspose.Slides è un motore autonomo per [creare](/slides/it/php-java/create-presentation/), modificare, [convertire](/slides/it/php-java/convert-presentation/) e [renderizzare](/slides/it/php-java/convert-powerpoint-to-png/) le presentazioni.

**Quali caratteri sono necessari per un rendering corretto?**

In pratica, i caratteri utilizzati nella presentazione o i relativi [sostituti](/slides/it/php-java/font-substitution/) devono essere disponibili. Per garantire un rendering coerente su Linux/macOS, è consigliabile installare pacchetti di caratteri comuni.

**Perché un carattere personalizzato viene visualizzato come fallback o testo mancante su Linux?**

Se il file del carattere contiene voci della tabella dei nomi incoerenti o corrotte, lo stack di abbinamento dei caratteri di Linux (FreeType/fontconfig) può selezionare un record non valido, causando la mancata risoluzione del carattere. L'uso di una versione del carattere con record della tabella dei nomi corretti o l'installazione di una sostituzione coerente risolve il problema.