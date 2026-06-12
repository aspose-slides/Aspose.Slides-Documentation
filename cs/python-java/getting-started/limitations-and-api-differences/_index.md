---
title: Omezení a rozdíly v API
type: docs
weight: 100
url: /cs/python-java/limitations-and-api-differences/
keywords: "node, powerpoint, omezení, api, rozdíly"
description: "Omezení a rozdíly v API Aspose.Slides pro Python přes Java."
---
## **Známé chyby/omezení**
Třídy Java mimo balíček (v `default`) nelze importovat.  
Kvůli nedostatku podpory JVM nemůžete JVM vypnout a poté jej znovu spustit. Nemůžete také spustit více než jednu instanci JVM.  
Míchání 64‑bitového Pythonu s 32‑bitovou Javou a naopak způsobí pád při importu modulu jpype.

## **Rozdíly ve veřejném API**
Následující seznam (s ukázkovými úryvky kódu) ukazuje některé rozdíly mezi Aspose.Slides pro Java a Aspose.Slides pro Python přes Java API.

### **Import knihovny (srovnání balíčků)**

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

### **Vytvoření nové prezentace**

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

### **Streamování souborů a konstant**

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

### **Další omezení Aspose.Slides pro Python přes Java API ve srovnání s Aspose.Slides pro Java API**

Pro více informací o dalších omezeních se prosím podívejte na dokumentaci jpype:  
- https://jpype.readthedocs.io/en/latest/