---
title: Limitazioni e Differenze API
type: docs
weight: 100
url: /it/python-java/limitations-and-api-differences/
keywords: "nodo, PowerPoint, limitazione, API, differenze"
description: "Limitazioni e differenze dell'API di Aspose.Slides per Python tramite Java."
---
## **Bug/Limitazioni Note**
Le classi Java al di fuori di un package (nel `default`) non possono essere importate.
A causa della mancanza di supporto JVM, non è possibile spegnere la JVM e poi riavviarla. Inoltre non è possibile avviare più di una copia della JVM.
Mescolare Python a 64 bit con Java a 32 bit e viceversa provoca un crash all'importazione del modulo jpype.

## **Differenze API Pubbliche**
L'elenco seguente (con segmenti di codice di esempio) mostra alcune differenze tra Aspose.Slides per Java e Aspose.Slides per Python tramite le API Java.

### **Importazione della libreria (Confronto dei package)**

**Aspose.Slides for Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **Istanziazione di una nuova Presentazione**

**Aspose.Slides for Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Streaming di file e costanti**

**Aspose.Slides for Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input = open("presentation.pptx", mode="rb")
data = input.read()
pres = Presentation.createPresentationFromBytes(data)
pres.save("result.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

### **Altre limitazioni di Aspose.Slides per Python tramite API Java rispetto alle API di Aspose.Slides per Java**

Per ulteriori informazioni sulle altre limitazioni, fare riferimento alla documentazione jpype: 
- https://jpype.readthedocs.io/en/latest/