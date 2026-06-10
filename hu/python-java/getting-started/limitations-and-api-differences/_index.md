---
title: Korlátozások és API különbségek
type: docs
weight: 100
url: /hu/python-java/limitations-and-api-differences/
keywords: "csomópont, powerpoint, korlátozás, api, különbségek"
description: "Aspose.Slides for Python via Java korlátozásai és API különbségei."
---
## **Ismert hibák/korlátozások**
A csomagon kívüli Java osztályok (az `default` csomagban) nem importálhatók.  
A JVM támogatás hiánya miatt nem állítható le a JVM, majd indítható újra. Emellett nem indítható el a JVM több példánya.  
A 64 bites Python és a 32 bites Java (vagy fordítva) keverése a jpype modul importálásakor összeomlást okoz.

## **Nyilvános API eltérések**
Az alábbi lista (minta kódrészekkel) néhány különbséget mutat az Aspose.Slides for Java és az Aspose.Slides for Python Java API-kon keresztül történő használata között.

### **Könyvtár importálása (Csomag összehasonlítások)**

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

### **Új bemutató példányosítása**

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

### **Fájlok és állandók streamingelése**

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

### **Az Aspose.Slides for Python Java API egyéb korlátozásai az Aspose.Slides for Java API-hoz képest**

További információk az egyéb korlátozásokról a jpype dokumentációjában találhatók: 
- https://jpype.readthedocs.io/en/latest/