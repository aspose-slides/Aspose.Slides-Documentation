---
title: Instalación
type: docs
weight: 70
url: /es/python-net/installation/
keywords:
- descargar Aspose.Slides
- instalar Aspose.Slides
- usar Aspose.Slides
- instalación de Aspose.Slides
- Windows
- macOS
- Python
description: "Aprenda cómo instalar rápidamente Aspose.Slides para Python via .NET. Guía paso a paso, requisitos del sistema y ejemplos de código — ¡comience a trabajar con presentaciones PowerPoint hoy!"
---

## **Descripción general**

El paquete Aspose.Slides for Python via .NET incluye todas las bibliotecas .NET esenciales, lo que significa que no es necesario instalar .NET por separado. Esto simplifica el proceso de configuración y permite a los desarrolladores comenzar a trabajar con presentaciones de inmediato. Sin embargo, es importante tener en cuenta que, según su sistema operativo o entorno, aún podría necesitar instalar algunas dependencias específicas de la plataforma requeridas por .NET. Además, se deben cumplir ciertos requisitos del sistema para garantizar la compatibilidad total y el correcto funcionamiento del paquete.

## **Windows**

**Requisitos del sistema**

Verifique y confirme que las especificaciones de su máquina cumplen o superan los [requisitos del sistema](/slides/es/python-net/system-requirements/).

### **Instalar Aspose.Slides**

`pip` es la forma más sencilla de descargar e instalar [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) en Windows.

Para instalar Aspose.Slides, ejecute el siguiente comando:
```sh
pip install aspose-slides
```


**Usar Aspose.Slides**

Pruebe su instalación de Aspose.Slides ejecutando el siguiente código para crear una presentación PowerPoint:
```python
# Importar el módulo Aspose.Slides para Python vía .NET.
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **macOS**

**Requisitos del sistema**

Verifique y confirme que las especificaciones de su máquina cumplen o superan los [requisitos del sistema](/slides/es/python-net/system-requirements/).

### **Requisitos previos**

**Python con bibliotecas compartidas**

Existen varias formas de instalar Python en macOS, pero recomendamos encarecidamente usar la [herramienta pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

Después de instalar y configurar **pyenv**, instale Python con bibliotecas compartidas ejecutando los siguientes comandos en la aplicación Terminal:

1. Instalar Python:
```sh
env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13
```


2. Configúrelo como la versión global de Python:
```sh
pyenv global 3.9.13
```


3. Configúrelo como la versión de Python específica del shell:
```sh
pyenv shell 3.9.13
```


4. Cree un enlace simbólico para la biblioteca libpython en un directorio de biblioteca del sistema:
```sh
ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib
```


Nota: se requiere Python 3.5 o superior. La versión 3.9.13 se usa aquí solo como ejemplo.

**Instalar la biblioteca libgdiplus**

La biblioteca **libgdiplus** es una implementación de Windows GDI+ para macOS y Linux de la que .NET depende para la funcionalidad gráfica en esas plataformas.  
Para instalar esta biblioteca en macOS, ejecute el siguiente comando:
```sh
brew install mono-libgdiplus
```


### **Instalar Aspose.Slides**

`pip` es la forma más sencilla de descargar e instalar [Aspose.Slides for Python via .NET](https://pypi.org/project/aspose-slides/) en macOS.

Para instalar Aspose.Slides, ejecute el siguiente comando:
```sh
pip install aspose-slides
```


**Usar Aspose.Slides**

Pruebe su instalación de Aspose.Slides ejecutando el siguiente código para crear una presentación PowerPoint:
```python
# Importar el módulo Aspose.Slides para Python vía .NET.
import aspose.slides as slides

# Instanciar la clase Presentation que representa un archivo de presentación.
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 20, 20, 300, 200)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**¿Puedo instalar Aspose.Slides en un entorno virtual?**

Sí, puede instalarlo en cualquier entorno virtual de Python usando `pip`. Solo asegúrese de que el entorno tenga acceso a las dependencias nativas requeridas según su SO.

**¿Puedo usar Aspose.Slides en contenedores Docker?**

Sí, pero debe asegurarse de que su imagen Docker incluya las bibliotecas nativas requeridas (**libgdiplus**, paquetes de fuentes, etc.) y la versión correcta de Python.

**¿Hay una versión gratuita o limitación de prueba?**

Sí, por defecto, Aspose.Slides se ejecuta en modo de evaluación, lo que coloca marcas de agua y puede tener otras limitaciones. Para eliminar las restricciones, debe aplicar una [licencia](/slides/es/python-net/licensing/).