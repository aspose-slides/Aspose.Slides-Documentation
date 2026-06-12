---
title: Installazione
type: docs
weight: 70
url: /it/python-net/installation/
keywords:
- scaricare Aspose.Slides
- installare Aspose.Slides
- utilizzare Aspose.Slides
- installazione di Aspose.Slides
- Windows
- macOS
- Python
description: "Scopri come installare rapidamente Aspose.Slides per Python via .NET. Guida passo-passo, requisiti di sistema e esempi di codice — inizia a lavorare con le presentazioni PowerPoint oggi!"
---
## **Panoramica**

Il pacchetto Aspose.Slides for Python via .NET include tutte le librerie .NET essenziali, il che significa che non è necessario installare .NET separatamente. Questo semplifica il processo di configurazione e consente agli sviluppatori di iniziare a lavorare con le presentazioni subito. Tuttavia, è importante notare che, a seconda del sistema operativo o dell'ambiente, potrebbe comunque essere necessario installare alcune dipendenze specifiche della piattaforma richieste da .NET. Inoltre, devono essere soddisfatti determinati requisiti di sistema per garantire la piena compatibilità e il corretto funzionamento del pacchetto.

## **Windows**

**Requisiti di sistema**

Verifica e conferma che le specifiche della tua macchina soddisfino o superino i [requisiti di sistema](/slides/it/python-net/system-requirements/).

### **Installa Aspose.Slides**

`pip` è il modo più semplice per scaricare e installare [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) su Windows.

Per installare Aspose.Slides, esegui il seguente comando:

```sh
pip install aspose-slides
```

**Usa Aspose.Slides**

Verifica l’installazione di Aspose.Slides eseguendo il codice seguente per creare una presentazione PowerPoint:

```python
# Importa il modulo Aspose.Slides per Python via .NET.
import aspose.slides as slides

# Istanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Requisiti di sistema**

Verifica e conferma che le specifiche della tua macchina soddisfino o superino i [requisiti di sistema](/slides/it/python-net/system-requirements/).

### **Prerequisiti**

**Python con librerie condivise**

Esistono diversi modi per installare Python su macOS, ma consigliamo vivamente di utilizzare lo strumento [pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

Dopo aver installato e configurato **pyenv**, installa Python con librerie condivise eseguendo i seguenti comandi nel Terminale:

1. Installa Python:

```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```

2. Impostalo come versione globale di Python:

```sh
pyenv global 3.9.13
```

3. Impostalo come versione di Python specifica per la shell:

```sh
pyenv shell 3.9.13
```

4. Crea un collegamento simbolico per la libreria libpython in una directory di librerie di sistema:

```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```

Nota: è richiesto Python 3.5 o superiore. La versione 3.9.13 è usata qui solo a scopo dimostrativo.

**Installa la libreria libgdiplus**

La libreria **libgdiplus** è un'implementazione di Windows GDI+ per macOS e Linux su cui .NET fa affidamento per le funzionalità grafiche su queste piattaforme.
Per installare questa libreria su macOS, esegui il seguente comando:

```sh
brew install mono-libgdiplus
```

### **Installa Aspose.Slides**

`pip` è il modo più semplice per scaricare e installare [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) su macOS.

Per installare Aspose.Slides, esegui il seguente comando:

```sh
pip install aspose-slides
```

**Usa Aspose.Slides**

Verifica l’installazione di Aspose.Slides eseguendo il codice seguente per creare una presentazione PowerPoint:

```python
# Importa il modulo Aspose.Slides per Python via .NET.
import aspose.slides as slides

# Instanzia la classe Presentation che rappresenta un file di presentazione.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Posso installare Aspose.Slides in un ambiente virtuale?**

Sì, puoi installarlo in qualsiasi ambiente virtuale Python usando `pip`. Assicurati solo che l’ambiente abbia accesso alle dipendenze native richieste a seconda del tuo sistema operativo.

**Posso usare Aspose.Slides in container Docker?**

Sì, ma devi assicurarti che la tua immagine Docker includa le librerie native necessarie (**libgdiplus**, pacchetti di font, ecc.) e la versione corretta di Python.

**Esiste una versione gratuita o limitata di prova?**

Sì, per impostazione predefinita Aspose.Slides funziona in modalità valutazione, che applica filigrane e può avere altre limitazioni. Per rimuovere le restrizioni, devi applicare una licenza valida [licenza](/slides/it/python-net/licensing/).