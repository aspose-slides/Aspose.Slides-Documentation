---
title: Beperkingen en API-verschillen
type: docs
weight: 100
url: /nl/python-java/limitations-and-api-differences/
keywords: "node, powerpoint, beperking, api, verschillen"
description: "Aspose.Slides voor Python via Java beperkingen en api-verschillen."
---
## **Bekende bugs/beperkingen**
Java‑klassen die zich buiten een pakket bevinden (in de `default`) kunnen niet worden geïmporteerd.
Vanwege het ontbreken van JVM‑ondersteuning kun je de JVM niet afsluiten en vervolgens opnieuw starten. Je kunt ook niet meer dan één exemplaar van de JVM starten.
Het combineren van 64‑bit Python met 32‑bit Java en omgekeerd veroorzaakt een crash bij het importeren van de jpype‑module.

## **Verschillen in openbare API**
De volgende lijst (met voorbeeldcode‑segmenten) toont enkele verschillen tussen Aspose.Slides voor Java en Aspose.Slides voor Python via Java‑API’s.

### **Importeren van bibliotheek (pakketvergelijkingen)**

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

### **Een nieuwe presentatie instantiëren**

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

### **Bestanden en constanten streamen**

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

### **Andere beperkingen van Aspose.Slides voor Python via Java API in vergelijking met Aspose.Slides voor Java API**

Voor meer informatie over andere beperkingen, raadpleeg de jpype‑documentatie:
- https://jpype.readthedocs.io/en/latest/