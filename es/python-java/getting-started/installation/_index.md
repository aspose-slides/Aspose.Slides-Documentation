---
title: Instalación
type: docs
weight: 70
url: /es/python-java/installation/
keySlides: "Descargar Aspose.Slides, Instalar Aspose.Slides, Instalación de Aspose.Slides, Windows, macOS, Linux, Python"
description: "Instalar Aspose.Slides para Python a través de Java en Windows, Linux o macOS"
---

Aspose.Slides para Python a través de Java es una API independiente de la plataforma y se puede usar en cualquier plataforma (Windows, Linux y MacOS) donde estén instalados `Python`, `Java` y el puente `jpype1`.

## **Requisitos para programas y versiones**

Para asegurar el correcto funcionamiento de Aspose.Slides para Python a través de Java, deben estar instalados los siguientes programas y paquetes:

- Versión de JRE >=8 (JPype1 ha sido probado en versiones de Java desde 1.8 hasta 11).
- Versión de Python >=3.7,<=3.12.
- Versión del paquete JPype1: >=1.5.0.

## **Instalar desde pip**

Puedes instalar fácilmente Aspose.Slides para Python a través de Java desde [pip](https://pypi.org/) siempre que tengas todos los programas requeridos (Java, Python) instalados.

Crea una nueva carpeta de proyecto.

[Instalar JPype1](https://jpype.readthedocs.io/en/latest/install.html) utilizando el siguiente comando:
```
$ pip install JPype1
```

Instala Aspose.Slides para Python a través de Java utilizando el siguiente comando:
```
$ pip install aspose-slides-java
```

## **Instalar desde archivo ZIP**

Para instalar y usar Aspose.Slides para Python a través de Java desde un archivo ZIP, sigue estas instrucciones en su lugar:

### **Windows**

1. Instala JDK8 y configura la variable de entorno `JAVA_HOME`.
2. [Instalar Python](https://www.python.org/downloads/) versión >=3.7 y agrega python.exe a `PATH`.
3. [Instalar Microsoft C++ Build Tools](https://visualstudio.microsoft.com/visual-cpp-build-tools/).
4. [Instalar JPype1](https://jpype.readthedocs.io/en/latest/install.html). Puedes ejecutar los siguientes comandos en el terminal de python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Descargar Aspose.Slides para Python a través de Java](https://releases.aspose.com/slides/python-java/) y extraerlo a `aspose-slides-java`.
6. Crea un archivo llamado `example.py` en la carpeta `aspose-slides-java` utilizando el siguiente código de muestra:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Título de la diapositiva")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```

7. Ahora ejecuta `py example.py` en el símbolo del sistema para ejecutarlo.

### **Linux**

1. Instala JDK8 para Linux y configura la variable de entorno `JAVA_HOME`.
2. [Instalar Python](https://www.python.org/downloads/) versión >=3.7
3. Instala ``g++`` y ``python-dev``. 

- Para Debian/Ubuntu:
    ```
    sudo apt-get install g++ python3-dev
    ```
- Para RedHat:
    ```
    dnf install redhat-rpm-config gcc-c++ python3-devel unixODBC-devel
    ```

4. [Instalar JPype1](https://jpype.readthedocs.io/en/latest/install.html). Puedes ejecutar los siguientes comandos en el terminal de python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
5. [Descargar Aspose.Slides para Python a través de Java](https://releases.aspose.com/slides/python-java/) y extraerlo a `aspose-slides-java`.
6. Crea un archivo de prueba llamado `example.py` utilizando este código de muestra en la carpeta `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Título de la diapositiva")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
7. Ahora ejecuta `py example.py` en el símbolo del sistema para ejecutarlo.

### **Mac**

1. Instala JDK8 para Mac y configura la variable de entorno `JAVA_HOME`.
2. Modifica la sección JVMCapabilities en `/Library/Java/JavaVirtualMachines/jdk1.8.x_xxx.jdk/Contents/Info.plist` con privilegios de root. `jdk1.8.x_xxx.jdk` depende de tu versión de jdk. Haz que se vea así:
```xml
<key>JavaVM</key>
    <dict>
        <key>JVMCapabilities</key>
        <array>
                <string>JNI</string>
                <string>BundledApp</string>
                <string>CommandLine</string>
        </array>
```
3. [Instalar Python](https://www.python.org/downloads/) versión >=3.7.
4. Instala compiladores GCC o Clang dependiendo de la versión de Python y la plataforma.
5. [Instalar JPype1](https://jpype.readthedocs.io/en/latest/install.html). Puedes ejecutar los siguientes comandos en el terminal de python:
```
$ pip install --upgrade pip
$ pip install JPype1
```
6. [Descargar Aspose.Slides para Python a través de Java](https://releases.aspose.com/slides/python-java/) y extraerlo en `aspose-slides-java`.
7. Crea un archivo de prueba llamado `example.py` utilizando este código de muestra en la carpeta `aspose-slides-java`:

```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

pres = Presentation()
slide = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0))
slide.getShapes().get_Item(0).getTextFrame().setText("Título de la diapositiva")
pres.save("out.pptx", SaveFormat.Pptx)

jpype.shutdownJVM()
```
9. Ahora ejecuta `python example.py` en el símbolo del sistema para ejecutarlo.