---
title: Einschränkungen und API-Unterschiede
type: docs
weight: 100
url: /de/python-java/einschraenkungen-und-api-unterschiede/
keywords: "knoten, powerpoint, einschränkung, api, unterschiede"
description: "Einschränkungen und API-Unterschiede von Aspose.Slides für Python über Java."
---
## **Bekannte Fehler/Einschränkungen**
Java-Klassen außerhalb eines Pakets (im `default`) können nicht importiert werden.  
Aufgrund mangelnder JVM-Unterstützung können Sie die JVM nicht herunterfahren und dann neu starten. Sie können auch nicht mehr als eine Kopie der JVM starten.  
Die Kombination von 64-Bit-Python mit 32-Bit-Java und umgekehrt führt beim Import des jpype-Moduls zu einem Absturz.

## **Öffentliche API-Unterschiede**
Die folgende Liste (mit Beispielcode-Segmenten) zeigt einige Unterschiede zwischen Aspose.Slides für Java und Aspose.Slides für Python über die Java APIs.

### **Bibliothek importieren (Paketvergleiche)**

**Aspose.Slides für Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides für Python über Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **Erstellen einer neuen Präsentation**

**Aspose.Slides für Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides für Python über Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Streaming-Dateien und Konstanten**

**Aspose.Slides für Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides für Python über Java**

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

### **Weitere Einschränkungen der Aspose.Slides für Python über Java API im Vergleich zur Aspose.Slides für Java API**

Für weitere Informationen zu anderen Einschränkungen beziehen Sie sich bitte auf die jpype-Dokumentation:  
- https://jpype.readthedocs.io/en/latest/