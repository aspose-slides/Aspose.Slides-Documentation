---
title: Requisiti di sistema
type: docs
weight: 60
url: /it/python-java/system-requirements/
keywords:
- requisiti di sistema
- Python
- Java
- JPype
- Windows
- Linux
- macOS
- Aspose.Slides
description: "Verifica i requisiti del sistema operativo, Python, Java e JPype per eseguire Aspose.Slides per Python via Java su Windows, Linux e macOS."
---
## **Panoramica**

Aspose.Slides per Python via Java crea, modifica, converte e rende le presentazioni senza la necessità di avere installato Microsoft PowerPoint. Utilizza JPype per accedere alla libreria Java da Python, quindi l'ambiente deve supportare Python, Java e JPype insieme.

## **Sistemi operativi supportati**

Il [pacchetto Aspose.Slides](https://pypi.org/project/aspose-slides-java/) supporta le seguenti famiglie di sistemi operativi:

- Windows
- Linux
- macOS

Scegli una versione del sistema operativo supportata dalle versioni di Python, Java e JPype selezionate. La sola disponibilità di Java non garantisce la compatibilità con il pacchetto Python e il suo bridge.

## **Requisiti per Python, Java e JPype**

| Componente | Requisito |
| --- | --- |
| Python | Il pacchetto Aspose.Slides dichiara il supporto da Python 3.7 a 3.14. La versione di JPype selezionata deve supportare la stessa versione di Python; per esempio, [JPype1 1.7.1](https://pypi.org/project/jpype1/1.7.1/) richiede Python 3.8 o successivo. |
| Java | Installa un runtime Java o un JDK compatibile con la versione di JPype selezionata. Gli attuali [prerequisiti JPype](https://jpype.readthedocs.io/en/latest/userguide.html#prerequisites) richiedono Java 11 o versioni successive. Java 8 non può eseguire JPype1 1.7.1. |
| JPype | Installa il pacchetto JPype1 per il tuo interprete Python, il sistema operativo e l'architettura CPU. |
| Architettura CPU | Python e la Java Virtual Machine (JVM) devono utilizzare architetture corrispondenti. Per esempio, un interprete Python a 64 bit richiede una JVM a 64 bit compatibile. |

Su Apple Silicon, Python e Java devono entrambi utilizzare ARM64 oppure entrambi x64. Una JVM che viene eseguita in modo indipendente può comunque non riuscire a caricarsi tramite JPype se la sua architettura differisce da quella di Python.

Per un nuovo ambiente, Python 3.12, JDK 17 e JPype1 1.7.1 costituiscono un punto di partenza adeguato. Questa combinazione è stata verificata con Aspose.Slides per Python via Java 26.6.0 su Windows. Altre combinazioni devono soddisfare i requisiti di tutti e tre i componenti.

Per la configurazione dell'ambiente e un esempio di verifica funzionante, vedi [Installation](/slides/it/python-java/installation/).

## **Dipendenze aggiuntive**

Un wheel JPype precompilato compatibile non richiede un compilatore C++. Se JPype deve essere compilato dal sorgente, installa un compilatore C++ compatibile e i file di sviluppo Python richiesti dalla tua piattaforma. Consulta le [istruzioni di installazione di JPype](https://jpype.readthedocs.io/en/latest/install.html) per i requisiti di compilazione e la risoluzione dei problemi.

## **FAQ**

**Devo installare Microsoft PowerPoint?**

No. Aspose.Slides elabora le presentazioni in modo indipendente da PowerPoint. Python, Java e JPype sono comunque necessari.

**Posso usare Python 3.7 con qualsiasi versione di JPype?**

No. Sebbene il pacchetto Aspose.Slides dichiari il supporto per Python 3.7, JPype1 1.7.1 richiede Python 3.8 o versioni successive. Scegli versioni i cui requisiti si sovrappongono.

**Posso mescolare Python a 32 bit con Java a 64 bit?**

No. JPype carica la JVM nel processo Python, quindi Python e Java devono avere architetture corrispondenti. Lo stesso requisito si applica a ARM64 e x64 su macOS.