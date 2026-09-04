---
title: Limitaciones y diferencias de la API
type: docs
weight: 100
url: /es/python-java/limitations-and-api-differences/
keywords:
- Aspose.Slides para Python mediante Java
- Diferencias de API
- Python
- Java
- JPype
- Limitaciones de la JVM
- PowerPoint
description: "Aprenda sobre las limitaciones de la JVM y las diferencias de API entre Aspose.Slides para Java y Python mediante Java, incluyendo importaciones, limpieza de recursos y gestión de archivos."
---
## **Visión general**

Aspose.Slides for Python via Java utiliza JPype para acceder a la biblioteca Java desde Python. Los ejemplos a continuación comparan la importación de paquetes, la creación de presentaciones y la gestión de archivos en ambas API.

## **Limitaciones conocidas**

- **Ciclo de vida de la JVM:** JPype admite una JVM por proceso de Python. Tras apagarla, no puede reiniciarse en el mismo proceso. Iníciela una vez y reutilícela para operaciones posteriores con presentaciones.
- **Compatibilidad de arquitectura:** Python y Java deben tener arquitecturas coincidentes. Consulte [Requisitos del sistema](/slides/es/python-java/system-requirements/#python-java-and-jpype-requirements) para obtener más detalles.

Consulte la [Guía del usuario de JPype](https://jpype.readthedocs.io/en/latest/userguide.html) para obtener detalles sobre estas restricciones y la interoperabilidad con Java.

## **Diferencias en la API pública**

Compare los ejemplos de Java y Python a continuación. Para obtener detalles de los miembros de Python via Java, consulte la [Referencia de API](/slides/es/python-java/api-reference/).

### **Importar la biblioteca**

Java importa clases desde `com.aspose.slides`. En Python, importe `asposeslides` antes de iniciar la JVM, y luego importe clases desde `asposeslides.api` una vez que la JVM esté en ejecución. Utilice [jpype.isJVMStarted](https://jpype.readthedocs.io/en/latest/api.html#jpype.isJVMStarted) para evitar iniciar una JVM que ya esté en ejecución.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
```

{{% alert color="info" title="Nota" %}}
Los ejemplos de Python dejan la JVM en ejecución hasta que el proceso de Python termina. En un cuaderno, reutilice la JVM activa entre celdas. Si ya se ha apagado, reinicie el kernel del cuaderno antes de volver a usar objetos Java.
{{% /alert %}}

### **Crear una presentación**

Java utiliza la palabra clave `new`; Python llama a la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) directamente. Libere los recursos de la presentación con [Presentation.dispose](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#dispose) en un bloque `finally`.

Ambos ejemplos guardan una presentación vacía usando [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) y [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#pptx).

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.save("new-presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Leer archivos y usar constantes de formato**

Java puede cargar una presentación desde un flujo de entrada Java. En Python, lea el archivo como datos binarios y pase los bytes resultantes a [Presentation.createPresentationFromBytes](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#createpresentationfrombytes). Un objeto de archivo de Python no es un flujo de entrada Java.

Los ejemplos a continuación requieren un `presentation.pptx` existente en el directorio de trabajo y guardan una copia como `result.pptx`. Ambos cierran el archivo de entrada y liberan los recursos de la presentación. El ejemplo de Python lee todo el archivo de entrada en memoria.

**Aspose.Slides for Java**

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.FileInputStream;
import java.io.InputStream;

try (InputStream inputStream = new FileInputStream("presentation.pptx")) {
    Presentation presentation = new Presentation(inputStream);
    try {
        presentation.save("result.pptx", SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

**Aspose.Slides for Python via Java**

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

with open("presentation.pptx", "rb") as input_file:
    data = input_file.read()

presentation = Presentation.createPresentationFromBytes(data)
try:
    presentation.save("result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Preguntas frecuentes**

**¿Necesito reiniciar la JVM para cada presentación?**

No. Mantenga la JVM en ejecución y cree y elimine los objetos de presentación según sea necesario. Apagar la JVM impide realizar más operaciones Java en el mismo proceso de Python.

**¿Puedo abrir una presentación directamente a partir de una ruta de archivo?**

Sí. El constructor [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) acepta una ruta de archivo. Utilice el asistente basado en bytes cuando los datos de la presentación ya estén disponibles como bytes de Python.

**¿Debo cambiar los nombres de las constantes de formato al traducir ejemplos de Java a Python?**

No. Por ejemplo, [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#pptx) utiliza la misma ortografía y capitalización en ambas API.