---
title: Ograniczenia i różnice w API
type: docs
weight: 100
url: /pl/python-java/limitations-and-api-differences/
keywords: "węzeł, powerpoint, ograniczenie, api, różnice"
description: "Ograniczenia i różnice w API Aspose.Slides for Python via Java."
---
## **Znane błędy/ograniczenia**
Klasy Java spoza pakietu (w `default`) nie mogą być importowane.
Z powodu braku wsparcia JVM nie można wyłączyć JVM i ponownie go uruchomić. Nie można także uruchomić więcej niż jednej kopii JVM.
Mieszanie 64-bitowego Pythona z 32-bitową Javą i odwrotnie powoduje awarię podczas importu modułu jpype.

## **Różnice w publicznym API**
Poniższa lista (z przykładowymi fragmentami kodu) pokazuje niektóre różnice między Aspose.Slides for Java a Aspose.Slides for Python przy użyciu API Javy.

### **Importowanie biblioteki (porównanie pakietów)**

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

### **Tworzenie nowej prezentacji**

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

### **Strumieniowanie plików i stałych**

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

### **Inne ograniczenia Aspose.Slides for Python via Java API w porównaniu z Aspose.Slides for Java API**

Po więcej informacji o innych ograniczeniach zobacz dokumentację jpype:
- https://jpype.readthedocs.io/en/latest/