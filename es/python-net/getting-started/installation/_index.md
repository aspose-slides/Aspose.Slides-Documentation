---
title: Instalación
type: docs
weight: 70
url: /python-net/installation/
keywords: "Descargar Aspose.Slides, Instalar Aspose.Slides, Instalación de Aspose.Slides, Windows, macOS, Python"
description: "Instalar Aspose.Slides para Python a través de .NET en Windows o macOS"
---

El paquete Aspose.Slides para Python a través de .NET viene con las bibliotecas .NET que necesita, por lo que no se requiere una instalación separada de .NET. Sin embargo, dependiendo de su plataforma, puede que tenga que instalar dependencias específicas para .NET y cumplir con ciertos requisitos.

## **Windows**

**Requisitos del sistema**

Verifique y confirme que las especificaciones de su máquina cumplen o superan los [requisitos del sistema](/slides/python-net/system-requirements/).

### **Instalar Aspose.Slides**

`pip` es la forma más fácil de descargar e instalar [Aspose.Slides para Python a través de .NET](https://pypi.org/project/aspose.slides/) en dispositivos Windows.

Para instalar Aspose.Slides, ejecute este comando:  `pip install aspose.slides`

**Usar Aspose.Slides**

Pruebe su instalación de Aspose.Slides ejecutando este código para crear una presentación de PowerPoint:

```python
# Importa el módulo Aspose.Slides para Python a través de .NET
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **macOS**

**Requisitos del sistema**

Verifique y confirme que las especificaciones de su máquina cumplen o superan los [requisitos del sistema](/slides/python-net/system-requirements/).

### **Prerequisitos**

**Python con bibliotecas compartidas**

Hay diferentes formas de instalar Python en macOS, pero recomendamos encarecidamente usar la [herramienta pyenv](https://github.com/pyenv/pyenv#homebrew-in-macos).

Después de instalar y configurar pyenv, tiene que instalar python con bibliotecas compartidas ejecutando estos comandos en la aplicación Terminal:

1. Instalar Python: `env PYTHON_CONFIGURE_OPTS="--enable-shared" pyenv install --verbose 3.9.13`
2. Configurarlo como una instalación global de Python: `pyenv global 3.9.13`
3. Configurarlo como una instalación de Python en la shell: `pyenv shell 3.9.13`
4. Crear un enlace simbólico para la biblioteca libpython en un directorio de bibliotecas del sistema: `ln -s /Users/<username>/.pyenv/versions/3.9.13/lib/libpython3.9.dylib /usr/local/lib/libpython3.9.dylib` 

Nota: Se requiere Python 3.5 y superior. La versión 3.9.13 de Python se utilizó simplemente como un ejemplo.

**Instalar la biblioteca libgdiplus**

La biblioteca libgdiplus es una implementación de GDI+ de Windows para macOS y Linux que .NET utiliza en esas plataformas. Para instalar esta biblioteca, ejecute este comando: `brew install mono-libgdiplus` 

### **Instalar Aspose.Slides**

`pip` es la forma más fácil de descargar e instalar [Aspose.Slides para Python a través de .NET](https://pypi.org/project/aspose.slides/) en dispositivos macOS. Para instalar Aspose.Slides, ejecute este comando: `pip install aspose.slides`

**Usar Aspose.Slides**

Pruebe su instalación de Aspose.Slides ejecutando este código para crear una presentación de PowerPoint:

```python
# Importa el módulo Aspose.Slides para Python a través de .NET
import aspose.slides as slides

# Instancia un objeto Presentation que representa un archivo de presentación
with slides.Presentation() as presentation:    
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```