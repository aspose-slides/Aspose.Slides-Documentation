---
title: Exportar presentaciones a XAML en Python mediante Java
linktitle: Presentación a XAML
type: docs
weight: 30
url: /es/python-java/export-to-xaml/
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
- Java
- Aspose.Slides
description: "Exporta presentaciones de PowerPoint y OpenDocument a XAML con Aspose.Slides para Python mediante Java. Usa las opciones predeterminadas o incluye diapositivas ocultas."
---
## **Visión general**

Este artículo explica cómo exportar presentaciones de PowerPoint a XAML utilizando Aspose.Slides para Python a través de Java. Incluye una breve introducción a XAML, muestra cómo guardar una presentación en XAML con la configuración predeterminada y demuestra cómo personalizar la exportación mediante [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/), incluyendo la exportación de diapositivas ocultas. El artículo también responde a algunas preguntas frecuentes relacionadas con fuentes de respaldo, compatibilidad de la pila XAML y el comportamiento de exportación de diapositivas ocultas.

Los ejemplos requieren Aspose.Slides para Python a través de Java y un tiempo de ejecución Java compatible. Coloque `pres.pptx` en el directorio de trabajo actual. Cada ejemplo inicia la JVM solo si aún no está en ejecución.

## **Acerca de XAML**

XAML es un lenguaje de marcado basado en XML utilizado para describir interfaces de usuario en frameworks como WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) y Xamarin.Forms.

Puede trabajar con archivos XAML en un diseñador visual o escribir y editar el marcado directamente.

## **Exportar presentaciones a XAML con opciones predeterminadas**

El siguiente ejemplo en Python muestra cómo exportar una presentación a XAML con la configuración predeterminada:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

Por defecto, las diapositivas exportadas se guardan en una subcarpeta `pres` del directorio de trabajo actual del proceso. La carpeta se crea automáticamente, y también se guardan allí las imágenes necesarias.

El nombre de la carpeta de salida se toma del nombre del archivo fuente sin su extensión. Para `pres.pptx`, los archivos de salida se nombran `pres/Slide_1.xaml`, `pres/Slide_2.xaml`, etc. Incluso si pasa una ruta absoluta a la presentación de entrada, la carpeta de salida se crea relativa al directorio de trabajo actual, en lugar de al lado del archivo de entrada.

## **Exportar presentaciones a XAML con opciones personalizadas**

Utilice la clase [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/) para controlar cómo Aspose.Slides exporta una presentación a XAML.

Para guardar la salida en una ubicación personalizada, implemente `IXamlOutputSaver` y pase una instancia de su implementación al método [setOutputSaver](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/#setOutputSaver) de [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/).

Para incluir diapositivas ocultas en la salida XAML, llame a [setExportHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) con `True`, como se muestra en el siguiente ejemplo en Python:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **Capturar todos los artefactos XAML generados**

Una exportación XAML puede producir un documento XAML para cada diapositiva exportada más imágenes y recursos de soporte separados. Asigne un `IXamlOutputSaver` personalizado a [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/#setOutputSaver) para recibir estos artefactos en lugar de usar el guardador predeterminado del sistema de archivos. Inicie la exportación con la sobrecarga específica de XAML de [Presentation.save](https://reference.aspose.com/slides/es/python-java/aspose.slides/presentation/#save) que acepta opciones XAML.

En Python, use `jpype.JProxy` para implementar la interfaz Java `IXamlOutputSaver`. Convierta la ruta de la devolución de llamada a `str` y copie la matriz de bytes de Java a `bytes` de Python antes de devolverla, como se muestra a continuación.

### **Entender el ciclo de vida de la devolución de llamada**

El exportador llama a `IXamlOutputSaver.save` por separado para cada artefacto generado:

- `path` identifica el artefacto y puede incluir directorios relativos. Conserve esta información porque XAML puede referenciar recursos mediante rutas relativas.
- `data` contiene los bytes del artefacto. Las imágenes y otros recursos binarios no deben decodificarse como texto.
- El guardador es responsable de retener o persistir los datos antes de devolverlos. Los ejemplos copian cada matriz de bytes en memoria propia de la aplicación.
- Considere la exportación como exitosa solo cuando la operación de guardado de la presentación devuelve y cada devolución de llamada se ha completado correctamente. No suprima los errores de almacenamiento ni inicie escrituras en segundo plano no observadas. Si la persistencia ocurre después, informe el éxito global solo después de que ese paso también haya tenido éxito.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) también se aplica a un guardador personalizado. La configuración predeterminada, `False`, excluye los documentos XAML de diapositivas ocultas. Pasar `True` los incluye junto con los recursos necesarios para su exportación. El recuento de recursos depende de la presentación; no asuma una devolución de llamada por diapositiva o un orden fijo de devoluciones.

### **Exportar a la memoria y examinar los artefactos**

Este ejemplo completo carga `pres.pptx`, recopila cada artefacto en un diccionario de Python de nombres y valores `bytes` inmutables, y muestra su nombre, tipo y recuento de bytes. Conserva los nombres proporcionados exactamente. Los nombres duplicados marcan la colección como inválida en lugar de sobrescribir silenciosamente un artefacto. El ejemplo verifica esto antes de usar los resultados.

```python
import jpase

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # Decodificar solo XAML, y solo cuando sea necesaria la inspección textual.
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

Las comprobaciones de extensión son útiles para la inspección; conserve todos los artefactos, incluidos los tipos de recursos desconocidos. Deje los bytes sin modificar al almacenarlos o transmitirlos. Use `bytes.decode` con UTF-8 solo para XAML que necesite procesamiento textual.

### **Empaquetar los artefactos recopilados en un archivo ZIP**

Este ejemplo independiente recopila la exportación, valida sus nombres y escribe los bytes originales en un archivo ZIP. Un nombre de archivo único separa trabajos de exportación concurrentes. Las entradas ZIP utilizan barras diagonales y conservan los directorios relativos. Los nombres inseguros o los nombres que colisionan después de la normalización rechazan todo el paquete antes de escribirlo.

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # El cierre finaliza el directorio ZIP antes de que se informe el éxito.
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

El ejemplo usa `zipfile.ZipFile` de Python para escribir un archivo local; el propio exportador no escribe archivos XAML o de imagen sueltos. Para almacenamiento remoto, reemplace la etapa de escritura del archivo con cargas de los matrices de bytes recopilados. Use un identificador de trabajo de exportación más el nombre relativo completo del artefacto como clave blob, o almacene el identificador del trabajo, el nombre relativo y los datos binarios en una fila de base de datos. Publique el trabajo solo después de que todas las cargas se completen o la transacción de la base de datos se confirme. Limpie la salida parcial si la persistencia falla.

Para presentaciones grandes, un guardador personalizado puede persistir cada artefacto directamente en el almacenamiento de la aplicación para evitar mantener una copia adicional de toda la exportación en la memoria de la aplicación. Mantenga cada devolución de llamada sincrónica desde la perspectiva del exportador: devuelva solo después de que el destino haya aceptado los bytes y permita que los fallos lleguen al llamador.

### **Conservar los nombres de recursos y verificar las referencias**

- Normalice los separadores de ruta cuando el destino lo requiera, pero conserve los directorios relativos. No use solo `pathlib.Path.name` a menos que se sepa que cada nombre generado es único y las referencias de recursos sigan siendo válidas.
- Aplique la validación de nombres específica del destino. Al escribir archivos sueltos, rechace rutas raíz y segmentos de recorrido, resuelva el destino con `pathlib.Path.resolve` y verifique que permanezca bajo el directorio de exportación previsto, incluyendo el separador de directorios en la comprobación de contención. Use un directorio controlado por la aplicación sin enlaces simbólicos que puedan redirigir escrituras.
- Utilice un guardador y un espacio de nombres de almacenamiento separados para cada trabajo de exportación. Detecte colisiones después de la normalización de separadores y de acuerdo con las reglas de sensibilidad a mayúsculas del destino.
- Antes de publicar, analice cada documento XAML como XML e inspeccione sus referencias de recursos basados en archivos, como los atributos `Source` o `ImageSource` de imágenes. Resuelva cada URI relativa contra el directorio del artefacto XAML contenedor, normalice el nombre de almacenamiento resultante y confirme que la clave del mapa correspondiente, la entrada ZIP o el objeto almacenado exista. Trate las URIs externas y las expresiones de marcado XAML por separado de los nombres de archivo relativos.

Por ejemplo, si `pres/Slide_1.xaml` referencia `images/image1.png`, el recurso almacenado debe estar disponible como `pres/images/image1.png`. Mantener solo `image1.png` rompería esa relación. Para almacenamiento de objetos, conserve la misma estructura bajo el prefijo del trabajo y haga que esas URL de recursos sean accesibles para el consumidor XAML. Reabra el ZIP completado para verificar los nombres de las entradas y los bytes de los recursos, y cargue diapositivas representativas en el entorno XAML de destino para confirmar que las imágenes se resuelvan correctamente.

## **Preguntas frecuentes**

**¿Cómo puedo garantizar fuentes predecibles si la fuente original no está disponible en la máquina?**

Llame a [setDefaultRegularFont](https://reference.aspose.com/slides/es/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) en [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/) — se utiliza como fuente de respaldo durante la exportación cuando la original falta. Esto no garantiza que el XAML generado haga referencia a la fuente de respaldo o que la fuente esté disponible en la máquina de destino. Asegúrese de que las fuentes referenciadas por el XAML estén disponibles en el entorno donde se muestra.

**¿El XAML exportado está destinado solo a WPF o puede usarse también en otras pilas XAML?**

Aspose.Slides exporta XAML de WPF a través de su API pública. La compatibilidad con otras pilas XAML, como UWP y Xamarin.Forms, no está garantizada. Pruebe el marcado generado en su entorno de destino.

**¿Se admiten diapositivas ocultas y cómo puedo evitar que se exporten por defecto?**

Por defecto, las diapositivas ocultas no se incluyen. Puede controlar este comportamiento mediante [setExportHiddenSlides](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) en [XamlOptions](https://reference.aspose.com/slides/es/python-java/aspose.slides/xamloptions/) — manténgalo desactivado si no necesita exportarlas.