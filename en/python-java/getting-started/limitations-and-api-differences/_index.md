---
title: Limitations and API Differences
type: docs
weight: 100
url: /python-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, differences"
description: "Aspose.Slides for Python via Java limitations and api differences."
---
## **Known Bugs/Limitations**
Java classes outside of a package (in the `default`) cannot be imported.
Because of lack of JVM support, you cannot shutdown the JVM and then restart it. Nor can you start more than one copy of the JVM.
Mixing 64 bit Python with 32 bit Java and vice versa crashes on import of the jpype module.

## **Public API Differences**
The following list (with sample code segments) shows some differences between Aspose.Slides for Java and Aspose.Slides for Python via Java APIs.

### **Importing library (Package Comparisons)**

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

### **Instantiating a new Presentation**

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

### **Streaming Files and Constants**

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

### **Other Limitations of Aspose.Slides for Python via Java API compared to Aspose.Slides for Java API**

For more information about other limitations, please refer to the jpype documentation: 
- https://jpype.readthedocs.io/en/latest/

