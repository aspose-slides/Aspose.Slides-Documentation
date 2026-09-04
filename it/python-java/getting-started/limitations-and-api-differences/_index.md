---
title: Limitazioni e differenze API
type: docs
weight: 100
url: /it/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides per Python via Java
- Differenze API
- Python
- Java
- JPype
- Limitazioni JVM
- PowerPoint
description: "Scopri le limitazioni della JVM e le differenze API tra Aspose.Slides per Java e Python tramite Java, incluse le importazioni, la pulizia delle risorse e la gestione dei file."
---
## **Panoramica**

Aspose.Slides per Python tramite Java utilizza JPype per accedere alla libreria Java da Python. Gli esempi seguenti confrontano le importazioni dei pacchetti, la creazione di presentazioni e la gestione dei file nelle due API.

## **Limitazioni note**

- **Ciclo di vita della JVM:** JPype supporta una JVM per processo Python. Dopo averla arrestata, non è possibile riavviarla nello stesso processo. Avviala una volta e riutilizzala per le operazioni successive di presentazione.
- **Compatibilità dell'architettura:** Python e Java devono avere architetture corrispondenti. Vedi [Requisiti di sistema](/slides/it/python-java/system-requirements/#python-java-and-jpype-requirements) per i dettagli.

Consulta la [Guida per l'utente di JPype](https://jpype.readthedocs.io/en/latest/userguide.html) per i dettagli su queste limitazioni e sull'interoperabilità Java.

## **Differenze nelle API pubbliche**

Confronta gli esempi Java e Python seguenti. Per i dettagli dei membri Python tramite Java, consulta la [Riferimento API](/slides/it/python-java/api-reference/).

### **Importare la libreria**

Java importa le classi da `com.aspose.slides`. In Python, importa `asposeslides` prima di avviare la JVM, poi importa le classi da `asposeslides.api` dopo che la JVM è in esecuzione. Usa [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) per evitare di avviare una JVM già in esecuzione.

**Aspose.Slides per Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides per Python tramite Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Note" %}}
Gli esempi Python lasciano la JVM in esecuzione fino all'uscita del processo Python. In un notebook, riutilizza la JVM attiva tra le celle. Se è già stata arrestata, riavvia il kernel del notebook prima di utilizzare nuovamente gli oggetti Java.
{{% /alert %}}

### **Creare una presentazione**

Java utilizza la parola chiave `new`; Python chiama direttamente la classe [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/). Rilascia le risorse della presentazione con [Presentation.dispose](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#dispose) in un blocco `finally`.

Entrambi gli esempi salvano una presentazione vuota usando [Presentation.save](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#save) e [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides per Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides per Python tramite Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Leggere i file e utilizzare le costanti di formato**

Java può caricare una presentazione da uno stream di input Java. In Python, leggi il file come dati binari e passa i byte risultanti a [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/#createpresentationfrombytes). Un oggetto file Python non è uno stream di input Java.

Gli esempi seguenti richiedono un `presentation.pptx` esistente nella directory di lavoro e salvano una copia come `result.pptx`. Entrambi chiudono il file di input e rilasciano le risorse della presentazione. L'esempio Python legge l'intero file di input in memoria.

**Aspose.Slides per Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides per Python tramite Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Devo riavviare la JVM per ogni presentazione?**

No. Mantieni la JVM in esecuzione e crea e elimina gli oggetti presentazione secondo necessità. Arrestare la JVM impedisce ulteriori operazioni Java nello stesso processo Python.

**Posso aprire una presentazione direttamente da un percorso file?**

Sì. Il costruttore [Presentation](https://reference.aspose.com/slides/it/python-java/aspose.slides/presentation/) accetta un percorso file. Usa l'utility basata su byte quando i dati della presentazione sono già disponibili come byte Python.

**Devo modificare i nomi delle costanti di formato quando traduco gli esempi Java in Python?**

No. Ad esempio, [SaveFormat.Pptx](https://reference.aspose.com/slides/it/python-java/aspose.slides/saveformat/#pptx) utilizza la stessa ortografia e capitalizzazione in entrambe le API.