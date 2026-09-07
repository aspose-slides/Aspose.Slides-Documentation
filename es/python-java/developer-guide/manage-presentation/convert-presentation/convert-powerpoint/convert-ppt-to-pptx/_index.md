---
title: Convertir PPT a PPTX en Python
linktitle: PPT a PPTX
type: docs
weight: 20
url: /es/python-java/convert-ppt-to-pptx/
keywords:
- convertir PowerPoint
- convertir presentación
- convertir diapositiva
- convertir PPT
- PPT a PPTX
- guardar PPT como PPTX
- exportar PPT a PPTX
- PowerPoint
- presentación
- Python
- Java
- Aspose.Slides
description: "Convertir archivos PPT heredados a PPTX en Python con Aspose.Slides. Incluye ejemplos en Python para conversión de un solo archivo y por lotes, manejo de errores y notas de fidelidad."
---
## **Descripción general**

PPT es el formato binario heredado de PowerPoint, mientras que PPTX es el formato Open XML más reciente. Aspose.Slides for Python via Java puede cargar un archivo PPT y guardarlo como PPTX sin Microsoft PowerPoint. Este artículo muestra cómo convertir un archivo o un directorio de archivos y explica qué verificar después de la conversión.

Cada ejemplo inicia la máquina virtual Java si es necesario y libera la presentación después de su uso. Reemplace las rutas de ejemplo con sus propias rutas de archivo o directorio.

## **Convertir un archivo PPT a PPTX**

Cargue el archivo de origen con la clase [Presentation](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/), luego llame a [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Pptx). El bloque `finally` elimina la presentación y libera sus recursos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Cargar la presentación PPT heredada.
presentation = Presentation("presentation.ppt")
try:
    # Guardar la presentación en formato PPTX.
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La extensión del archivo no selecciona el formato de salida por sí sola; lo hace el argumento [SaveFormat.Pptx](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveformat/#Pptx). Mantenga las rutas de entrada y salida diferentes si necesita conservar el archivo PPT original.

## **Convertir varios archivos PPT**

El siguiente ejemplo convierte cada archivo `.ppt` en un directorio. Cada archivo se procesa de forma independiente, de modo que una conversión fallida no detiene el resto del lote.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

input_directory = Path("input")
output_directory = Path("output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
    input_files = list(input_directory.iterdir())
except OSError as error:
    print(f"Cannot prepare the conversion directories: {error}")
else:
    for input_file in input_files:
        if not input_file.is_file() or input_file.suffix.lower() != ".ppt":
            continue

        output_file = output_directory / (input_file.stem + ".pptx")
        input_path = str(input_file)
        output_path = str(output_file)
        presentation = None

        try:
            presentation = Presentation(input_path)
            presentation.save(output_path, SaveFormat.Pptx)
            print(f"Converted: {input_path}")
        except Exception as error:
            print(f"Failed: {input_path} ({error})")
        finally:
            if presentation is not None:
                presentation.dispose()
```

Para cargas de trabajo de producción, registre la excepción completa, decida si se puede sobrescribir un archivo de salida existente y escriba los nombres de los archivos que fallaron en una cola de reintento o revisión. Los archivos corruptos, los archivos protegidos con contraseña que se abren sin la contraseña requerida, las rutas inaccesibles y el contenido no compatible pueden provocar que una conversión falle. Consulte [Presentaciones protegidas con contraseña](/slides/es/python-java/password-protected-presentation/) para cargar archivos cifrados.

## **Fidelidad y características heredadas**

La conversión normalmente conserva diapositivas, maestros, diseños, texto, formas, imágenes, tablas y gráficos. Sin embargo, PPT y PPTX no representan todas las características de la misma manera exacta. Una característica heredada que no tiene equivalente en PPTX, o que no es compatible con la biblioteca, puede normalizarse, omitirse o mostrarse de forma diferente.

Compruebe el archivo convertido cuando contenga animaciones, transiciones, objetos OLE incrustados o vinculados, controles ActiveX, medios incrustados, fuentes poco habituales o macros VBA. Un archivo PPTX simple no es un formato con macros habilitadas, por lo que debe usar un flujo de trabajo adecuado con macros cuando VBA deba permanecer disponible. También verifique que las fuentes requeridas y los recursos externos estén presentes en el entorno donde se abrirá o renderizará la presentación convertida.

Para documentos importantes, vuelva a abrir el PPTX generado de forma programática e inspeccione el recuento y el contenido clave de las diapositivas, luego compare su apariencia y el comportamiento de la presentación en el visor previsto. No considere que una llamada exitosa a [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) sea prueba de que cada característica heredada tenga una representación PPTX exacta.

## **Cuándo usar PPTX**

Utilice PPTX cuando la presentación se va a editar en versiones actuales de PowerPoint, se vaya a intercambiar con sistemas que trabajen con paquetes Open XML, o se vaya a almacenar en un formato más fácil de inspeccionar y recuperar que el binario heredado PPT. Mantenga el PPT original como copia de archivo o de reversión hasta que la presentación convertida haya superado sus comprobaciones de fidelidad.

Si necesita PDF, HTML, imágenes, XPS u otro tipo de salida, utilice la guía específica de formato en [Convertir presentaciones a varios formatos](/slides/es/python-java/convert-presentation/) en lugar de suponer que todos los destinos conservan las características editables de PowerPoint.

## **Convertidor en línea**

Para un archivo ocasional o una comparación rápida, puede utilizar el [convertidor en línea de PPT a PPTX](https://products.aspose.app/slides/es/conversion/ppt-to-pptx). Para conversiones repetibles, procesamiento por lotes o manejo de errores a nivel de aplicación, use la API de Python vía Java.

## **Artículos relacionados**

- [PPT vs PPTX](/slides/es/python-java/ppt-vs-pptx/)
- [Guardar presentaciones en Python](/slides/es/python-java/save-presentation/)
- [Formatos de archivo compatibles](/slides/es/python-java/supported-file-formats/)
- [Abrir presentaciones en Python](/slides/es/python-java/open-presentation/)

## **FAQ**

**¿Puedo convertir PPT a PPTX sin Microsoft PowerPoint instalado?**

Sí. Aspose.Slides for Python via Java carga y guarda archivos de presentación sin requerir Microsoft PowerPoint.

**¿Conserva la conversión de PPT a PPTX todo el contenido exactamente?**

Conserva el contenido típico de la presentación, pero no se garantiza una fidelidad exacta para cada característica heredada o no compatible. Revise el archivo generado cuando contenga macros, objetos OLE o ActiveX, medios, animaciones especializadas o fuentes poco habituales.

**¿Puedo convertir un archivo PPT protegido con contraseña?**

Sí, si suministra la contraseña correcta al cargar el archivo. Una contraseña ausente o incorrecta hace que la operación de carga falle.

**¿Debo eliminar el archivo PPT después de la conversión?**

Conserve el original hasta que haya verificado el PPTX en los visores y flujos de trabajo que le importan. Esto proporciona una copia de respaldo si una característica heredada se convierte de forma diferente.