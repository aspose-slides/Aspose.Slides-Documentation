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
description: "Empaquete Aspose.Slides para Python mediante .NET con PyInstaller. Siga esta guía para empaquetar, configurar y solucionar problemas de su aplicación en un ejecutable independiente."
---

## **Compatibilidad con PyInstaller y cx_Freeze**

Las extensiones de Aspose.Slides para Python mediante .NET son extensiones estándar de Python C, por lo que pueden congelarse como dependencias del programa con herramientas como PyInstaller y cx_Freeze (o similares). Esto le permite crear archivos ejecutables a partir de sus scripts de Python. Estas herramientas se denominan “congeladores” porque agrupan su código y sus dependencias en un único archivo distribuible que se ejecuta en otras máquinas sin requerir una instalación de Python ni bibliotecas adicionales. Este enfoque simplifica la distribución de sus aplicaciones Python.

Congelar una extensión de Aspose.Slides para Python mediante .NET como dependencia se ilustra a continuación con un programa simple que utiliza Aspose.Slides.

### **PyInstaller**

En general, no se necesita nada especial al empaquetar un programa que depende de una extensión de Aspose.Slides para Python mediante .NET. Cuando un programa importa la extensión de una manera visible para PyInstaller, la extensión se incluirá en el programa. Debido a que Aspose.Slides para Python mediante .NET incluye hooks de PyInstaller, sus dependencias se detectan automáticamente y se copian al paquete.

slide_app.py:
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50.0, 150.0, 300.0, 0.0)
    presentation.save("NewPresentation.pptx", slides.export.SaveFormat.PPTX)
```

```bash
$ pyinstaller slide_app.py
```

Sin embargo, PyInstaller a veces puede pasar por alto importaciones ocultas —módulos que se importan dinámicamente o indirectamente en su código. Para incluir una importación oculta, use las opciones de PyInstaller. Las dependencias de la extensión se especifican en los hooks de PyInstaller que se entregan con Aspose.Slides para Python mediante .NET.

slide_app.spec:
```
a = Analysis(
    ['slide_app.py'],
    ...
    hiddenimports=['aspose.slides']
)
```

```bash
$ pyinstaller slide_app.spec
```

### **cx_Freeze**

Para congelar un programa con cx_Freeze, configúrelo para que incluya el paquete raíz de la extensión de Aspose.Slides para Python mediante .NET que está utilizando. Esto garantiza que la extensión y todos los módulos dependientes se copien al build junto con su aplicación.

#### **Uso del script cxfreeze**

```bash
$ cxfreeze slide_app.py --packages=aspose
```

#### **Uso del script de configuración**

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

```bash
$ python setup.py build_exe
```

## **FAQ**

**¿Necesito Microsoft PowerPoint o .NET instalado en la máquina del usuario?**

No, PowerPoint no es necesario. Aspose.Slides es un motor autosuficiente; el paquete Python incluye todo lo necesario como una extensión para CPython. El usuario no necesita instalar .NET por separado.

**¿Cómo debo adjuntar correctamente la licencia a una aplicación congelada?**

Puede almacenar el XML de la licencia junto al ejecutable o incrustarlo como recurso y cargarlo desde una ruta accesible antes de la primera llamada a la API. Importante: no modifique el contenido del XML (ni siquiera los saltos de línea).

**¿Qué debo hacer si las fuentes se renderizan de forma diferente después de la compilación respecto al desarrollo?**

Asegúrese de que las fuentes que utiliza estén disponibles en el entorno de destino (incluidas en el paquete o instaladas en el sistema) y de que sus rutas se resuelvan correctamente en tiempo de ejecución; el comportamiento de las fuentes es especialmente sensible en Linux.