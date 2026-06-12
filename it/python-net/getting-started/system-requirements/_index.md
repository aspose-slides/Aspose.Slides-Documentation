---
title: Requisiti di Sistema
type: docs
weight: 60
url: /it/python-net/system-requirements/
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
- Python
- Aspose.Slides
description: "Scopri i requisiti di sistema di Aspose.Slides per Python tramite .NET. Assicura un supporto fluido a PowerPoint e OpenDocument su Windows, Linux e macOS."
---
## **Introduzione**

Aspose.Slides per Python tramite .NET non richiede alcun prodotto di terze parti, come Microsoft PowerPoint, installato. Aspose.Slides è un motore per creare, modificare, convertire e rendere documenti in vari formati, inclusi i formati di presentazione Microsoft PowerPoint.

## **Sistemi Operativi Supportati**

Aspose.Slides per Python supporta Windows (32-bit e 64-bit), macOS e Linux a 64-bit su sistemi con Python 3.5 o versioni successive installate.

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">Sistema Operativo</td>
        <td style="font-weight: bold; width:400px">Versioni</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>e altri</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 "Monterey"</li>
            </ul>
        </td>
    </tr>
</table>

## **Requisiti di Sistema per le Piattaforme Linux e macOS di Destinazione**

- Librerie di runtime GCC 6 (o successive).
- [libgdiplus](https://github.com/mono/libgdiplus), un'implementazione open‑source dell'API GDI+.
- Dipendenze del runtime .NET Core. L'installazione del runtime .NET Core stesso NON è richiesta.
- Per Python 3.5–3.7: è richiesto il build `pymalloc` di Python. L'opzione di build `--with-pymalloc` è abilitata per impostazione predefinita. Tipicamente, il build `pymalloc` di Python è contrassegnato dal suffisso `m` nel nome file.
- La libreria condivisa `libpython`. L'opzione di build Python `--enable-shared` è disabilitata per impostazione predefinita e alcune distribuzioni Python non includono la libreria condivisa `libpython`. Su alcune piattaforme Linux, è possibile installare la libreria condivisa `libpython` tramite il gestore di pacchetti (ad esempio, `sudo apt-get install libpython3.7`). Un problema comune è che la libreria `libpython` è installata in una posizione non standard per le librerie condivise. È possibile risolvere il problema impostando percorsi alternativi per le librerie durante la compilazione di Python, oppure creando un collegamento simbolico al file della libreria `libpython` nella posizione standard delle librerie condivise del sistema. Tipicamente, il nome file della libreria condivisa `libpython` è `libpythonX.Ym.so.1.0` per Python 3.5–3.7 oppure `libpythonX.Y.so.1.0` per Python 3.8 o versioni successive (ad esempio, `libpython3.7m.so.1.0`, `libpython3.9.so.1.0`).

## **FAQ**

**Devo avere Microsoft PowerPoint installato per le conversioni e il rendering?**

No, PowerPoint non è necessario; Aspose.Slides è un motore indipendente per [creare](/slides/it/python-net/create-presentation/), modificare, [convertire](/slides/it/python-net/convert-presentation/) e [rendere](/slides/it/python-net/convert-powerpoint-to-png/) le presentazioni.

**È necessaria una versione specifica di .NET (Core/5+/6+) sulla macchina?**

L'installazione del runtime .NET non è richiesta, ma le sue dipendenze devono essere presenti su Linux/macOS. Ciò significa che il sistema deve contenere i pacchetti solitamente installati come dipendenze di .NET, senza installare l'intero runtime.

**Quali caratteri sono necessari per il rendering corretto?**

In pratica, i caratteri utilizzati nella presentazione o i relativi [sostituti](/slides/it/python-net/font-substitution/) devono essere disponibili. Per garantire un rendering coerente su Linux/macOS, è consigliabile installare pacchetti di caratteri comuni.

**Perché un carattere personalizzato viene visualizzato come fallback o testo mancante su Linux?**

Se il file del carattere presenta voci della tabella dei nomi incoerenti o corrotte, lo stack di corrispondenza dei caratteri di Linux (FreeType/fontconfig) può selezionare un record non valido, causando la mancata risoluzione del carattere. L'uso di una versione del carattere con le voci della tabella dei nomi corrette o l'installazione di un sostituto coerente risolve il problema.