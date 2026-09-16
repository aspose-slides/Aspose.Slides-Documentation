---
title: Exportar presentaciones a XAML con Python
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/python-net/export-to-xaml/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- convertir PowerPoint
- convertir OpenDocument
- convertir presentación
- PowerPoint a XAML
- OpenDocument a XAML
- presentación a XAML
- PPT a XAML
- PPTX a XAML
- ODP a XAML
- guardar PPT como XAML
- guardar PPTX como XAML
- guardar ODP como XAML
- exportar PPT a XAML
- exportar PPTX a XAML
- exportar ODP a XAML
- Python
- Aspose.Slides
description: "Convertir diapositivas de PowerPoint y OpenDocument a XAML con Python usando Aspose.Slides—solución rápida y sin Office que mantiene intacto tu diseño."
---
## **Visión general**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML usando Aspose.Slides. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación mediante [XamlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/), incluida la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas comunes relacionadas con fuentes de reserva, compatibilidad de pilas XAML y el comportamiento de exportación de diapositivas ocultas.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML utilizado para describir interfaces de usuario en frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puedes trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

## **Exportar presentaciones a XAML con opciones predeterminadas**

El siguiente ejemplo en Python muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    presentation.save(xaml_options)
```

De forma predeterminada, las diapositivas exportadas se guardan en una subcarpeta `pres` del directorio de trabajo actual del proceso, obtenido mediante [os.getcwd](https://docs.python.org/3/library/os.html#os.getcwd). La carpeta se crea automáticamente, y cualquier imagen requerida también se guarda allí.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. Para `pres.pptx`, los archivos resultantes se nombran `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Incluso si pasas una ruta absoluta a la presentación de entrada, la carpeta de salida se crea relativa al directorio de trabajo actual, no junto al archivo de entrada.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utiliza la clase [XamlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para incluir diapositivas ocultas en la salida XAML, establece la propiedad [export_hidden_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) en `True`, como se muestra en el siguiente ejemplo en Python:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    xaml_options = slides.export.xaml.XamlOptions()
    xaml_options.export_hidden_slides = True
    presentation.save(xaml_options)
```

## **Capturar todos los artefactos XAML generados**

Una exportación XAML puede producir un documento XAML por cada diapositiva exportada, además de imágenes y recursos de apoyo separados. Conserva todos estos archivos al almacenar o transmitir una exportación.

Los ejemplos a continuación usan el guardado predeterminado del sistema de archivos en un directorio temporal, y luego recogen los archivos generados.

### **Entender el ciclo de vida de la exportación**

- Inicia la exportación con la sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/save/) que acepta opciones XAML. Lee los archivos generados solo después de que devuelva con éxito.
- Conserva la ruta relativa de cada artefacto porque XAML puede referenciar recursos usando rutas relativas.
- Lee los artefactos como bytes. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- Informa del éxito global solo después de que la recopilación y cualquier operación de almacenamiento posterior se completen. Permite que los errores de almacenamiento alcancen al llamador y elimina la salida parcial si la persistencia falla.

`[XamlOptions.export_hidden_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/)` tiene como valor predeterminado `False`, lo que excluye los documentos XAML de diapositivas ocultas. Establecerlo en `True` los incluye junto con los recursos necesarios para su exportación. La cantidad de recursos depende de la presentación; no asumas un archivo por diapositiva.

{{% alert color="warning" title="Warning" %}}
Los ejemplos cambian temporalmente el directorio de trabajo actual del proceso, lo que afecta a todos los hilos. Ejecuta cada exportación en un proceso trabajador dedicado, o asegura que no haya otro trabajo en el proceso que dependa del directorio actual durante la exportación. Un directorio temporal único por sí solo no hace seguras las exportaciones concurrentes en el mismo proceso.
{{% /alert %}}

### **Exportar a memoria y examinar los artefactos**

Este ejemplo completo carga `pres.pptx`, lo exporta a un directorio temporal, recopila cada artefacto en un diccionario de nombres relativos y bytes, y muestra su nombre, tipo y recuento de bytes. Conserva la estructura de directorios generada y elimina los archivos temporales después de la recopilación. La ruta de entrada se resuelve antes de cambiar el directorio de trabajo.

```python
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


artifacts = collect_xaml_artifacts("pres.pptx", True)
inspect_xaml_text = False
image_extensions = {".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg"}
for name, data in artifacts.items():
    extension = Path(name).suffix.lower()
    if extension == ".xaml":
        kind = "slide XAML"
    elif extension in image_extensions:
        kind = "image"
    else:
        kind = "supporting resource"
    print(f"{name}: {len(data)} bytes ({kind})")

    # Decodificar solo XAML, y solo cuando se necesite inspección textual.
    if extension == ".xaml" and inspect_xaml_text:
        print(data.decode("utf-8"))
```

Las comprobaciones de extensión son útiles para la inspección; conserva todos los artefactos, incluidos los tipos de recurso desconocidos. Deja los bytes sin modificar al almacenarlos o transmitirlos. Decodifica solo el XAML que necesita procesamiento textual. Este enfoque usa espacio en disco temporal así como memoria para la exportación recopilada.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP. Un nombre de archivo único separa los trabajos de exportación. Las entradas ZIP usan barras diagonales hacia adelante y conservan los directorios relativos. Los nombres inseguros o los que colisionan después de la normalización rechazan todo el paquete antes de escribirlo.

```python
from uuid import uuid4
from zipfile import ZIP_DEFLATED, ZipFile
import os
from pathlib import Path
from tempfile import TemporaryDirectory

import aspose.slides as slides


def collect_xaml_artifacts(source_path, export_hidden_slides):
    source_path = Path(source_path).resolve()
    original_directory = Path.cwd()
    artifacts = {}

    with TemporaryDirectory(prefix="xaml-") as temporary_directory:
        try:
            os.chdir(temporary_directory)
            with slides.Presentation(str(source_path)) as presentation:
                options = slides.export.xaml.XamlOptions()
                options.export_hidden_slides = export_hidden_slides
                presentation.save(options)

            for artifact_path in Path(temporary_directory).rglob("*"):
                if artifact_path.is_file():
                    relative_path = artifact_path.relative_to(temporary_directory)
                    artifacts[relative_path.as_posix()] = artifact_path.read_bytes()
        finally:
            os.chdir(original_directory)

    return artifacts


def package_xaml():
    artifacts = collect_xaml_artifacts("pres.pptx", False)
    entries = {}
    normalized_names = set()
    for name, data in artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name
        unsafe_name = unsafe_name or any(not segment.strip() or segment in {".", ".."} for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in normalized_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        normalized_names.add(normalized_name)
        entries[entry_name] = data

    archive_path = Path(f"xaml-{uuid4().hex}.zip")
    with ZipFile(archive_path, "x", compression=ZIP_DEFLATED) as archive:
        for name, data in entries.items():
            archive.writestr(name, data)

    # El directorio ZIP se ha finalizado antes de informar del éxito.
    print(f"Saved {len(entries)} artifacts to {archive_path}")


package_xaml()
```

El ejemplo utiliza [ZipFile](https://docs.python.org/3/library/zipfile.html#zipfile.ZipFile) para escribir un archivo local después de recopilar la exportación temporal. Para almacenamiento remoto, sustituye la fase de escritura del archivo por cargas de los bytes recopilados. Usa un identificador de trabajo de exportación más el nombre relativo completo del artefacto como clave de objeto, o guarda el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publica el trabajo solo después de que se completen todas las cargas o se confirme la transacción de la base de datos. Elimina la salida parcial si la persistencia falla.

Para presentaciones grandes, procesa los archivos temporales uno a la vez después de la exportación en lugar de recopilar todos sus bytes en un diccionario. Esto evita una copia adicional en memoria de toda la exportación, pero no elimina los requisitos de memoria del propio exportador.

### **Conservar los nombres de recursos y verificar referencias**

- Normaliza los separadores de ruta cuando el destino lo requiera, pero conserva los directorios relativos. No conserves solo el nombre de archivo final a menos que se sepa que cada nombre generado es único y las referencias de recursos siguen siendo válidas.
- Aplica validación de nombres específica del destino. Al escribir archivos sueltos, rechaza rutas absolutas y segmentos de recorrido, resuelve el destino y verifica que permanezca dentro del directorio de exportación previsto. Utiliza un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Usa un espacio de nombres de almacenamiento separado para cada trabajo de exportación. Detecta colisiones después de la normalización de separadores y según las reglas de sensibilidad a mayúsculas del destino.
- Antes de publicar, analiza cada documento XAML como XML y examina sus referencias a recursos basados en archivos, como los atributos `Source` o `ImageSource` de imágenes. Resuelve cada URI relativa contra el directorio del artefacto XAML contenedor, normaliza el nombre de almacenamiento resultante y confirma que la clave del diccionario correspondiente, la entrada ZIP o el objeto almacenado exista. Trata los URI externos y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `pres/Slide_1.xaml` referencia `images/image1.png`, el recurso almacenado debe estar disponible como `pres/images/image1.png`. Mantener solo `image1.png` rompería esa relación. Para almacenamiento de objetos, conserva la misma estructura bajo el prefijo del trabajo y haz que esas URL de recursos sean accesibles para el consumidor de XAML. Reabre el ZIP completado para verificar los nombres de entrada y los bytes de los recursos, y carga diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelven correctamente.

## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en el equipo?**

Establece [default_regular_font](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) en [XamlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/); se utiliza como fuente de reserva durante la exportación cuando falta la original. Esto no garantiza que el XAML generado haga referencia a la fuente de reserva o que la fuente esté disponible en la máquina de destino. Asegúrate de que las fuentes referenciadas por el XAML estén disponibles en el entorno donde se muestre.

**¿El XAML exportado está pensado solo para WPF o puede usarse también en otras pilas XAML?**

Aspose.Slides exporta XAML de WPF mediante su API pública. No se garantiza la compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms. Prueba el marcado generado en tu entorno de destino.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puedes controlar este comportamiento mediante [export_hidden_slides](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) en [XamlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export.xaml/xamloptions/); mantenlo desactivado si no necesitas exportarlas.