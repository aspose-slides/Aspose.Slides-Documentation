---
title: Compatibilidad con PyInstaller y cx_Freeze
linktitle: Compatibilidad con PyInstaller
type: docs
weight: 122
url: /es/python-net/compatibility-with-pyinstaller/
keywords:
- compatibilidad
- PyInstaller
- cx_Freeze
- Python
- Aspose.Slides
description: "Empaquete Aspose.Slides for Python via .NET con PyInstaller. Siga esta guía para empaquetar, configurar y solucionar problemas de su aplicación en un ejecutable autónomo."
---


## Compatibilidad con PyInstaller y cx_Freeze ##

Las extensiones de 'Aspose.Slides para Python a través de .NET' son simplemente extensiones C de Python, que pueden ser congeladas con la ayuda de PyInstaller y cx_Freeze (o herramientas similares) como dependencias del programa. Esto significa que puedes usar herramientas como PyInstaller y cx_Freeze para crear archivos ejecutables a partir de tus scripts de Python. Estas herramientas se llaman congeladores porque congelan tu código y dependencias en un solo archivo que puede ejecutarse en otras máquinas sin requerir Python u otras bibliotecas. Esto facilita la distribución de tus aplicaciones de Python a otros.

Congelar una extensión de 'Aspose.Slides para Python a través de .NET' como una dependencia del programa se ilustra con un ejemplo de un programa simple que utiliza Aspose.Slides.

### PyInstaller
Generalmente, no es necesario hacer nada especial al empaquetar un programa que depende de una extensión de 'Aspose.Slides para Python a través de .NET'. Cuando un programa importa una extensión de una manera que es visible para PyInstaller, la extensión será empaquetada junto con el programa. Dado que las extensiones de 'Aspose.Slides para Python a través de .NET' vienen con ganchos de PyInstaller, sus propias dependencias serán encontradas y copiadas en el paquete.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

```
$ pyinstaller slide_app.py
```

Sin embargo, a veces PyInstaller no puede detectar algunas importaciones ocultas, que son módulos que se importan dinámicamente o indirectamente por tu código. Para manejar una importación oculta en PyInstaller, usa las opciones de PyInstaller. Las dependencias de una extensión se especifican en los ganchos de PyInstaller que vienen con la extensión de 'Aspose.Slides para Python a través de .NET'.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```
$ pyinstaller slide_app.spec
```

### cx_Freeze ###
Para congelar un programa utilizando cx_Freeze, usa sus opciones para congelar el paquete raíz de la extensión de 'Aspose.Slides para Python a través de .NET' que estás utilizando. Esto asegurará que la extensión y los módulos de los que depende sean copiados junto con el programa.

#### Usando el script cxfreeze ####
```
$ cxfreeze slide_app.py --packages=aspose
```

#### Usando el script de Setup ####
setup.py:
```
executables = [Executable('slide_app.py')]

options = {
    'build_exe': {
        'packages': ['aspose'],
    }
}

setup(...
    options=options,
    executables=executables)

```


```
$ python setup.py build_exe
```