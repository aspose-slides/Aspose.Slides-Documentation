---
title: Installazione
type: docs
weight: 70
url: /it/python-java/installation/
keywords:
- scarica Aspose.Slides
- installa Aspose.Slides
- installazione di Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Installa Aspose.Slides per Python via Java su Windows, Linux o macOS, configura Java e JPype e verifica l'installazione con un esempio funzionante."
---
Aspose.Slides per Python via Java funziona su Windows, Linux e macOS. Utilizza JPype per accedere alla libreria Java da Python. Microsoft PowerPoint non è richiesto.

## **Prerequisiti**

Prima di installare i pacchetti Python, installa Python e un JDK che soddisfi i [System Requirements](/slides/it/python-java/system-requirements/). Quella pagina elenca le versioni compatibili, i requisiti di architettura e le eventuali dipendenze necessarie per compilare JPype dal codice sorgente.

Imposta `JAVA_HOME` sulla directory di installazione del JDK, non sulla sua sottodirectory `bin`, e aggiungi la directory `bin` del JDK a `PATH`. Apri un nuovo terminale dopo aver modificato le variabili d'ambiente.

## **Installazione da PyPI**

Esegui i seguenti comandi in un terminale, non nella console interattiva di Python. Crea una directory di progetto e un ambiente virtuale per mantenere i pacchetti isolati dagli altri progetti.

### **Windows**

Con l'interprete Python scelto disponibile come `python` su `PATH`, esegui i seguenti comandi nel Prompt dei comandi:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux e macOS**

Con la versione di Python scelta disponibile come `python3`, esegui i seguenti comandi in Bash o zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

Su Debian o Ubuntu, se la creazione dell'ambiente fallisce perché `ensurepip` non è disponibile, installa il pacchetto `python3-venv` con `sudo apt-get install python3-venv`, quindi ripeti il comando di creazione dell'ambiente. Una versione di Python installata separatamente potrebbe richiedere il corrispondente pacchetto `venv` specifico per quella versione.

### **Installa i pacchetti**

Con l'ambiente virtuale attivo, installa JPype e Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Usare `python -m pip` garantisce che i pacchetti vengano installati per l'interprete usato per eseguire la tua applicazione.

Per aggiornare un'installazione esistente di Aspose.Slides, esegui `python -m pip install --upgrade aspose-slides-java` nello stesso ambiente.

## **Installa da un archivio ZIP**

Puoi anche usare la libreria dalla [Aspose.Slides downloads page](https://releases.aspose.com/slides/it/python-java/):

1. Installa Python e Java come descritto nei [Prerequisiti](#prerequisites).
2. Crea e attiva un ambiente virtuale usando le istruzioni sopra.
3. Installa JPype con `python -m pip install JPype1`.
4. Scarica ed estrai l'archivio ZIP di Aspose.Slides per Python via Java.
5. Individua la directory del pacchetto `asposeslides` estratta. Mantieni i suoi contenuti, inclusi la directory `lib` e il file JAR, insieme.
6. Posiziona `example.py` della sezione successiva accanto alla directory `asposeslides` in modo che Python possa importare il pacchetto.

## **Verifica l'installazione**

Salva il seguente codice come `example.py`. Crea una presentazione con una casella di testo e la salva come `out.pptx` nella directory di lavoro corrente.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Con l'ambiente virtuale attivo, esegui l'esempio dalla directory contenente `example.py`:

```sh
python example.py
```

L'importazione `asposeslides` registra la libreria Java inclusa prima dell'avvio della JVM. Importa `asposeslides.api` dopo aver avviato la JVM e rilascia le risorse della presentazione prima di chiuderla.

{{% alert color="info" title="Note" %}}
Senza una licenza, l'output include una filigrana di valutazione. Vedi [Evaluate Aspose.Slides](/slides/it/python-java/evaluate-aspose-slides/) per le limitazioni della valutazione e le informazioni sulla licenza temporanea.
{{% /alert %}}

## **FAQ**

**Perché Python segnala che la JVM non può essere trovata o caricata?**

Verifica che `JAVA_HOME` punti a un JDK compatibile con la tua installazione di Python e JPype, come descritto nei [System Requirements](/slides/it/python-java/system-requirements/). Consulta la [JPype installation troubleshooting guide](https://jpype.readthedocs.io/en/latest/install.html) per ulteriori verifiche.

**Perché Python segnala che `asposeslides` è mancante dopo l'installazione?**

Il pacchetto potrebbe essere stato installato per un interprete Python diverso. Attiva l'ambiente virtuale usato per l'installazione ed esegui `python -m pip show aspose-slides-java`. Per un'installazione da ZIP, assicurati che la directory `asposeslides` sia accanto al tuo script o comunque disponibile sul percorso di ricerca dei moduli di Python.

**Posso eseguire l'esempio più volte in un notebook?**

L'esempio è destinato a un processo Python autonomo. Prima di adattarlo per un'esecuzione ripetuta in notebook, consulta [Limitations and API Differences](/slides/it/python-java/limitations-and-api-differences/#import-the-library) per il ciclo di vita della JVM e le indicazioni sui notebook.

**Perché pip fallisce con `CERTIFICATE_VERIFY_FAILED`?**

Se la tua rete utilizza un proxy di ispezione HTTPS, pip deve fidarsi della sua autorità di certificazione. Configura il bundle CA trusted usando l'opzione `--cert` di pip o la variabile d'ambiente `PIP_CERT`, seguendo le [pip HTTPS certificate instructions](https://pip.pypa.io/en/stable/topics/https-certificates/). La configurazione necessaria dipende dalla tua rete e dalla versione di pip.