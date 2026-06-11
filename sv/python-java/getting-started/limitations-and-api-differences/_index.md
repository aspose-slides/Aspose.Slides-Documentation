---
title: Begränsningar och API‑skillnader
type: docs
weight: 100
url: /sv/python-java/limitations-and-api-differences/
keywords: "nod, powerpoint, begränsning, api, skillnader"
description: "Aspose.Slides för Python via Java begränsningar och api‑skillnader."
---
## **Kända buggar/begränsningar**
Java-klasser utanför ett paket (i `default`) kan inte importeras.
På grund av brist på JVM-stöd kan du inte stänga av JVM:n och sedan starta den igen. Du kan inte heller starta mer än en kopia av JVM:n.
Att blanda 64‑bit Python med 32‑bit Java och vice versa kraschar vid import av jpype-modulen.

## **Offentliga API‑skillnader**
Följande lista (med exempel på kodsegment) visar vissa skillnader mellan Aspose.Slides för Java och Aspose.Slides för Python via Java‑API:

### **Importera bibliotek (paketjämförelser)**

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

### **Instansiera en ny Presentation**

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

### **Strömma filer och konstanter**

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

### **Andra begränsningar för Aspose.Slides för Python via Java‑API jämfört med Aspose.Slides för Java‑API**

För mer information om andra begränsningar, se jpype-dokumentationen:
- https://jpype.readthedocs.io/en/latest/