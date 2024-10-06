---
title: Limitations et différences d'API
type: docs
weight: 100
url: /python-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitation, api, différences"
description: "Limitations et différences d'api d'Aspose.Slides pour Python via Java."
---
## **Bugs/Limitations connus**
Les classes Java en dehors d'un package (dans le `default`) ne peuvent pas être importées.
En raison du manque de support de la JVM, vous ne pouvez pas arrêter la JVM puis la redémarrer. Vous ne pouvez pas non plus démarrer plusieurs copies de la JVM.
Mélanger Python 64 bits avec Java 32 bits et vice versa plante lors de l'import du module jpype.

## **Différences d'API publique**
La liste suivante (avec des segments de code en exemple) montre certaines différences entre Aspose.Slides pour Java et Aspose.Slides pour Python via les API Java.

### **Importation de la bibliothèque (comparaisons de packages)**

**Aspose.Slides pour Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides pour Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **Instanciation d'une nouvelle présentation**

**Aspose.Slides pour Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides pour Python via Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Fichiers de streaming et constantes**

**Aspose.Slides pour Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides pour Python via Java**

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

### **Autres limitations d'Aspose.Slides pour Python via l'API Java par rapport à l'API Java d'Aspose.Slides**

Pour plus d'informations sur d'autres limitations, veuillez vous référer à la documentation de jpype : 
- https://jpype.readthedocs.io/en/latest/