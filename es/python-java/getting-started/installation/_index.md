---
title: Instalación
type: docs
weight: 70
url: /es/python-java/installation/
keywords:
- descargar Aspose.Slides
- instalar Aspose.Slides
- instalación de Aspose.Slides
- Python
- Java
- JPype
- Windows
- macOS
- Linux
description: "Instala Aspose.Slides para Python a través de Java en Windows, Linux o macOS, configura Java y JPype, y verifica la configuración con un ejemplo funcional."
---
Aspose.Slides para Python a través de Java se ejecuta en Windows, Linux y macOS. Utiliza JPype para acceder a la biblioteca Java desde Python. Microsoft PowerPoint no es necesario.

## **Requisitos previos**

Antes de instalar los paquetes de Python, instale Python y un JDK que cumpla con los [Requisitos del sistema](/slides/es/python-java/system-requirements/). Esa página enumera las versiones compatibles, los requisitos de arquitectura y cualquier dependencia necesaria para compilar JPype desde el código fuente.

Establezca `JAVA_HOME` en el directorio de instalación del JDK, no en su subdirectorio `bin`, y añada el directorio `bin` del JDK a `PATH`. Abra una nueva terminal después de cambiar las variables de entorno.

## **Instalar desde PyPI**

Ejecute los siguientes comandos en una terminal, no en el intérprete interactivo de Python. Cree un directorio de proyecto y un entorno virtual para mantener los paquetes aislados de otros proyectos.

### **Windows**

Con el intérprete de Python que haya elegido disponible como `python` en `PATH`, ejecute los siguientes comandos en el Símbolo del sistema:

```bat
mkdir slides-example
cd slides-example
python -m venv .venv
.venv\Scripts\activate.bat
```

### **Linux y macOS**

Con la versión de Python que haya elegido disponible como `python3`, ejecute los siguientes comandos en Bash o zsh:

```bash
mkdir slides-example
cd slides-example
python3 -m venv .venv
source .venv/bin/activate
```

En Debian o Ubuntu, si la creación del entorno falla porque `ensurepip` no está disponible, instale el paquete `python3-venv` con `sudo apt-get install python3-venv`, y luego repita el comando de creación del entorno. Una versión de Python instalada por separado puede necesitar su paquete `venv` específico de versión correspondiente.

### **Instalar los paquetes**

Con el entorno virtual activo, instale JPype y Aspose.Slides:

```sh
python -m pip install --upgrade pip
python -m pip install JPype1 aspose-slides-java
```

Usar `python -m pip` garantiza que los paquetes se instalen para el intérprete que se utiliza para ejecutar su aplicación.

Para actualizar una instalación existente de Aspose.Slides, ejecute `python -m pip install --upgrade aspose-slides-java` en el mismo entorno.

## **Instalar desde un archivo ZIP**

También puede usar la biblioteca desde la [página de descargas de Aspose.Slides](https://releases.aspose.com/slides/es/python-java/):

1. Instale Python y Java como se describe en los [Requisitos previos](#prerequisites).
2. Cree y active un entorno virtual siguiendo las instrucciones anteriores.
3. Instale JPype con `python -m pip install JPype1`.
4. Descargue y extraiga el archivo ZIP de Aspose.Slides para Python a través de Java.
5. Localice el directorio del paquete `asposeslides` extraído. Mantenga su contenido, incluido el directorio `lib` y el archivo JAR, juntos.
6. Coloque `example.py` de la sección siguiente junto al directorio `asposeslides` para que Python pueda importar el paquete.

## **Verificar la instalación**

Guarde el siguiente código como `example.py`. Crea una presentación con un cuadro de texto y la guarda como `out.pptx` en el directorio de trabajo actual.

```python
import jpype
import asposeslides

jpype.startJVM()

try:
    from asposeslides.api import Presentation, SaveFormat, ShapeType

    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 500, 80)
        shape.getTextFrame().setText("Aspose.Slides is ready!")
        presentation.save("out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    jpype.shutdownJVM()
```

Con el entorno virtual activo, ejecute el ejemplo desde el directorio que contiene `example.py`:

```sh
python example.py
```

La importación `asposeslides` registra la biblioteca Java incluida antes de que se inicie la JVM. Importe `asposeslides.api` después de iniciar la JVM y libere los recursos de la presentación antes de cerrarla.

{{% alert color="info" title="Nota" %}}
Sin una licencia, la salida incluye una marca de agua de evaluación. Consulte [Evaluar Aspose.Slides](/slides/es/python-java/evaluate-aspose-slides/) para conocer las limitaciones de la evaluación y la información de licencias temporales.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Por qué Python indica que no se puede encontrar o cargar la JVM?**  
Verifique que `JAVA_HOME` apunte a un JDK compatible con su instalación de Python y JPype, como se describe en los [Requisitos del sistema](/slides/es/python-java/system-requirements/). Consulte la [guía de solución de problemas de instalación de JPype](https://jpype.readthedocs.io/en/latest/install.html) para comprobaciones adicionales.

**¿Por qué Python indica que falta `asposeslides` después de la instalación?**  
Es posible que el paquete se haya instalado para un intérprete de Python diferente. Active el entorno virtual usado para la instalación y ejecute `python -m pip show aspose-slides-java`. Para una instalación ZIP, asegúrese de que el directorio `asposeslides` esté junto a su script o disponible en la ruta de búsqueda de módulos de Python.

**¿Puedo ejecutar el ejemplo repetidamente en un cuaderno?**  
El ejemplo está pensado para un proceso Python independiente. Antes de adaptarlo para ejecución repetida en un cuaderno, revise las [Limitaciones y diferencias de API](/slides/es/python-java/limitations-and-api-differences/#import-the-library) para obtener información sobre el ciclo de vida de la JVM y la guía para cuadernos.

**¿Por qué pip falla con `CERTIFICATE_VERIFY_FAILED`?**  
Si su red utiliza un proxy de inspección HTTPS, pip debe confiar en su autoridad de certificación. Configure el paquete de CA de confianza usando la opción `--cert` de pip o la variable de entorno `PIP_CERT`, siguiendo las [instrucciones de certificados HTTPS de pip](https://pip.pypa.io/en/stable/topics/https-certificates/). La configuración requerida depende de su red y de la versión de pip.