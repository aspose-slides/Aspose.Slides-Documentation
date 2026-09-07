---
title: Convertir PPTX a PPT en Python
linktitle: PPTX a PPT
type: docs
weight: 21
url: /es/python-java/convert-pptx-to-ppt/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPTX
- PPTX a PPT
- guardar PPTX como PPT
- exportar PPTX a PPT
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Convertir PPTX al formato PPT heredado en Python con Aspose.Slides para Python a través de Java. Incluye un ejemplo de código y notas sobre compatibilidad y archivos protegidos."
---
## **Visión general**

Aspose.Slides for Python via Java le permite convertir una presentación PPTX al formato PPT heredado usado por PowerPoint 97–2003 sin necesidad de Microsoft PowerPoint instalado. Cargue el archivo PPTX y guárdelo con el formato de salida PPT, como se muestra a continuación.

## **Convertir PPTX a PPT**

Cargue el archivo fuente con la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) , luego llame a [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con la ruta de salida y [SaveFormat.Ppt](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Ppt).

El siguiente ejemplo inicia la máquina virtual Java si es necesario y convierte `template.pptx` a `output.ppt` usando las opciones predeterminadas. Reemplace las rutas por los nombres de archivo que desee. El bloque `finally` libera los recursos de la presentación incluso si el guardado falla.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Cargar la presentación PPTX.
presentation = Presentation("template.pptx")
try:
    # Guardar la presentación en formato PPT.
    presentation.save("output.ppt", SaveFormat.Ppt)
finally:
    presentation.dispose()
```

El argumento [SaveFormat.Ppt](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Ppt) selecciona el formato de salida; cambiar solo la extensión del archivo no convierte una presentación. Conserve el archivo PPTX original para poder volver a él si una característica más reciente no tiene equivalente en PPT.

## **Convertir PPTX a otros formatos**

Aspose.Slides también admite otros formatos de salida. Consulte los artículos correspondientes para opciones específicas de cada formato y ejemplos:

- [Convertir PowerPoint a PDF en Python](/slides/es/python-java/convert-powerpoint-to-pdf/)
- [Convertir PowerPoint a XPS en Python](/slides/es/python-java/convert-powerpoint-to-xps/)
- [Convertir PowerPoint a HTML en Python](/slides/es/python-java/convert-powerpoint-to-html/)
- [Guardar presentaciones como ODP en Python](/slides/es/python-java/save-presentation/)
- [Convertir PowerPoint a PNG en Python](/slides/es/python-java/convert-powerpoint-to-png/)

## **Preguntas frecuentes**

**¿Todos los efectos y características de PPTX sobreviven a la conversión a PPT?**

No siempre. El formato PPT heredado no admite todas las características disponibles en PPTX. Algunos efectos, objetos o comportamientos pueden simplificarse o mostrarse de forma diferente. Revise la presentación convertida en el visor previsto, sobre todo si contiene características nuevas de PowerPoint.

**¿Puedo convertir sólo diapositivas seleccionadas a PPT?**

Guardar como PPT escribe toda la presentación. Para convertir diapositivas seleccionadas, cree una nueva presentación, elimine su diapositiva vacía inicial, clone las diapositivas necesarias en ella y guárdela como PPT. Vea [Clone Slides in Python](/slides/es/python-java/clone-slides/).

**¿Puedo convertir un archivo PPTX protegido con contraseña?**

Sí, si proporciona la contraseña correcta al cargar la presentación fuente. También puede configurar la protección para el archivo de salida. Vea [Password-Protected Presentations](/slides/es/python-java/password-protected-presentation/).