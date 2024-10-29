---
title: Limitaciones y Diferencias en la API
type: docs
weight: 100
url: /es/python-java/limitations-and-api-differences/
keywords: "node, powerpoint, limitación, api, diferencias"
description: "Limitaciones y diferencias en la api de Aspose.Slides para Python a través de Java."
---
## **Errores/Limitaciones Conocidos**
Las clases de Java fuera de un paquete (en `default`) no se pueden importar.
Debido a la falta de soporte de JVM, no se puede apagar la JVM y luego reiniciarla. Tampoco se puede iniciar más de una copia de la JVM.
Mezclar Python de 64 bits con Java de 32 bits y viceversa provoca un fallo al importar el módulo jpype.

## **Diferencias en la API Pública**
La siguiente lista (con segmentos de código de ejemplo) muestra algunas diferencias entre Aspose.Slides para Java y Aspose.Slides para Python a través de Java APIs.

### **Importando la biblioteca (Comparaciones de Paquetes)**

**Aspose.Slides para Java**

```java
import com.aspose.slides.*;
```

**Aspose.Slides para Python a través de Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

jpype.shutdownJVM()

```

### **Instanciando una nueva Presentación**

**Aspose.Slides para Java**

```java
Presentation pres = new Presentation();
```

**Aspose.Slides para Python a través de Java**

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation

pres = Presentation();

jpype.shutdownJVM()
```

### **Archivos de Transmisión y Constantes**

**Aspose.Slides para Java**

```java
InputStream inputstream = new FileInputStream("Pres1.pptx");
Presentation pres = new Presentation(inputstream);
pres.save("result.pptx", SaveFormat.Pptx);
```

**Aspose.Slides para Python a través de Java**

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

### **Otras Limitaciones de Aspose.Slides para Python a través de la API de Java en comparación con la API de Aspose.Slides para Java**

Para más información sobre otras limitaciones, consulte la documentación de jpype: 
- https://jpype.readthedocs.io/en/latest/