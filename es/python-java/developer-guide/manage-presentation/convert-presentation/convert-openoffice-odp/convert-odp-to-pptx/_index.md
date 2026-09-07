---
title: Convertir ODP a PPTX en Python
linktitle: ODP a PPTX
type: docs
weight: 10
url: /es/python-java/convert-odp-to-pptx/
keywords:
- convertir OpenDocument
- convertir presentación
- convertir diapositiva
- convertir ODP
- OpenDocument a PPTX
- ODP a PPTX
- guardar ODP como PPTX
- exportar ODP a PPTX
- PowerPoint
- OpenDocument
- presentación
- Python
- Java
- Aspose.Slides
description: "Convertir presentaciones ODP a PPTX con Aspose.Slides para Python a través de Java. Utilice un ejemplo completo en Python sin instalar PowerPoint ni LibreOffice."
---
## **Resumen**

Este artículo explica cómo convertir una presentación OpenDocument (ODP) al formato PowerPoint (PPTX) usando Aspose.Slides para Python a través de Java.

## **Convertir ODP a PPTX**

La clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/) puede cargar un archivo ODP directamente. Guarde la presentación cargada en formato PPTX usando [SaveFormat](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/).

Siga las [instrucciones de instalación](/slides/es/python-java/installation/) antes de ejecutar el ejemplo. Coloque una presentación ODP llamada `AccessOpenDoc.odp` en el directorio de trabajo. El siguiente código inicia la JVM si es necesario, abre el archivo ODP y lo guarda como `AccessOpenDoc_out.pptx`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # Guardar la presentación ODP en formato PPTX.
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ejemplo en vivo**

Pruebe la aplicación web [Aspose.Slides Conversion](https://products.aspose.app/slides/es/conversion/) para ver la conversión de ODP a PPTX impulsada por Aspose.Slides.

## **Preguntas frecuentes**

**¿Necesito instalar Microsoft PowerPoint o LibreOffice para convertir ODP a PPTX?**

No. Aspose.Slides para Python a través de Java lee y escribe archivos de presentación sin ninguna de esas aplicaciones. Necesita el paquete de Python y un entorno de ejecución Java compatible.

**¿Se conservan las diapositivas maestras, los diseños y los temas durante la conversión?**

Aspose.Slides mapea la estructura y el formato de la presentación origen a PPTX. Sin embargo, ODP y PPTX admiten diferentes características, por lo que algunos elementos pueden aparecer diferentes tras la conversión. Proporcione las fuentes necesarias y revise las presentaciones con formato complejo. Consulte [conversión OpenDocument](/slides/es/python-java/convert-openoffice-odp/) para consideraciones de compatibilidad.

**¿Puedo convertir archivos ODP protegidos con contraseña?**

Sí, cuando proporcione la contraseña necesaria para abrir el archivo. Consulte [presentaciones protegidas con contraseña](/slides/es/python-java/password-protected-presentation/) para obtener detalles sobre cómo cargar archivos protegidos antes de guardarlos en otro formato.

**¿Es Aspose.Slides adecuado para servicios de conversión en la nube o basados en REST?**

Sí. Puede usar Aspose.Slides para Python a través de Java en su backend con el entorno de ejecución Java requerido. Para una API REST, consulte [Aspose.Slides Cloud](https://products.aspose.cloud/slides/es/family/).