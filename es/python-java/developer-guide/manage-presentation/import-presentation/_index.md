---
title: Importar presentaciones desde PDF o HTML en Python mediante Java
linktitle: Importar presentación
type: docs
weight: 60
url: /es/python-java/import-presentation/
keywords:
- importar presentación
- importar diapositiva
- importar PDF
- importar HTML
- PDF a presentación
- PDF a PPT
- PDF a PPTX
- PDF a ODP
- HTML a presentación
- HTML a PPT
- HTML a PPTX
- HTML a ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Aprenda a importar contenido PDF y HTML en presentaciones PowerPoint con Python mediante Java usando Aspose.Slides y guarde los resultados como archivos PPTX."
---
## **Introducción**

Aspose.Slides para Python a través de Java puede convertir páginas PDF o contenido HTML en diapositivas de PowerPoint sin Microsoft PowerPoint. La clase [SlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/) proporciona [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) y [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml) para añadir contenido importado a una presentación.

Para un mayor control sobre la ubicación del HTML, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) puede insertar diapositivas generadas en un índice de la colección o comenzar a rellenar el espacio disponible en una diapositiva existente. El HTML largo se pagina automáticamente en diapositivas adicionales, la fuente puede proporcionarse como una cadena o flujo, y los recursos externos pueden cargarse mediante [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) con un URI base. La matriz de [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) devuelta identifica las diapositivas afectadas y las recién creadas.

## **Importar desde PDF**

Para convertir un documento PDF a una presentación PowerPoint, importe su contenido en la colección de diapositivas y guarde el resultado como un archivo PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Cree un nuevo objeto [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Llame a [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) con la ruta al archivo PDF.
3. Llame a [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) para escribir la presentación en un archivo PPTX.

El siguiente ejemplo en Python importa un documento PDF y guarda las diapositivas generadas como una presentación PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La diapositiva en blanco predeterminada permanece en la presentación porque la importación añade diapositivas. Para conservar solo las páginas importadas, vacíe la colección de diapositivas con [SlideCollection.clear](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#clear) antes de importar.

El método [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf) devuelve las diapositivas que añade, lo que es útil cuando necesita procesar solo las diapositivas importadas.

{{% alert title="Tip" color="success" %}}
Pruebe la aplicación web gratuita [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) para ver este flujo de conversión en acción.
{{% /alert %}}

## **Importar desde HTML**

Aspose.Slides también puede crear diapositivas a partir de un documento HTML. La fuente puede proporcionarse como texto HTML o como un flujo. Los pasos siguientes utilizan un flujo de archivo:

1. Cree un nuevo objeto [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) .
2. Abra el archivo HTML para lectura y pase el flujo a [addFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Llame a [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) con [SaveFormat.Pptx](https://reference.aspose.com/slides/python-java/aspose.slides/saveformat/#Pptx) para escribir el resultado en un archivo PPTX.

El siguiente ejemplo en Python importa un documento HTML y guarda las diapositivas generadas como una presentación PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Insertar contenido HTML**

Utilice [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml) cuando las diapositivas generadas a partir de HTML deban colocarse en una posición específica en lugar de añadirse al final. El índice comienza en cero e identifica la posición donde comienza la importación.

El argumento `useSlideWithIndexAsStart` controla cómo el importador utiliza esa posición:

- Cuando es `False`, el importador crea nuevas diapositivas en el índice especificado y desplaza las diapositivas que siguen.
- Cuando es `True`, el importador comienza a colocar el contenido en el espacio disponible de la diapositiva existente en ese índice. Si el HTML no cabe, Aspose.Slides lo pagina automáticamente e inserta diapositivas adicionales inmediatamente después de la diapositiva inicial.

`[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#insertFromHtml)` devuelve una matriz de objetos [Slide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/) . Cuando la inserción comienza en diapositivas nuevas, cada elemento devuelto es recién creado. Cuando se utiliza una diapositiva existente como inicio, la matriz incluye esa diapositiva afectada seguida de cualquier diapositiva nueva de desbordamiento. Puede inspeccionar esta matriz en lugar de calcular el rango afectado a partir del recuento de diapositivas de la presentación.

### **Insertar HTML como nuevas diapositivas**

El siguiente ejemplo proporciona HTML como una cadena e inserta las diapositivas generadas en el índice `1` de la colección. Pasar `False` deja las diapositivas existentes sin cambios, salvo por desplazarlas para crear espacio.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Comenzar en una diapositiva existente**

El siguiente ejemplo proporciona el HTML a través de un flujo. Mantiene una forma de encabezado en la diapositiva de plantilla existente, comienza la importación debajo del área ocupada y permite que el cuerpo extenso continúe en nuevas diapositivas.

El HTML también contiene una URL de imagen relativa. Un [ExternalResourceResolver](https://reference.aspose.com/slides/python-java/aspose.slides/externalresourceresolver/) obtiene el recurso, mientras que el URI base indica al importador cómo resolver `images/logo.png`. En este ejemplo, se espera que ese archivo esté en `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Un resolvedor de recursos externos sin restricciones puede leer recursos locales o de red referenciados por el HTML. Para entradas no confiables, valide y sanee las URLs de los recursos contra una lista blanca de esquemas, directorios y hosts permitidos antes de importar el HTML.
{{% /alert %}}

## **Preguntas frecuentes**

**¿Puede Aspose.Slides detectar tablas al importar un PDF?**

Sí. Cree un objeto [PdfImportOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/) , llame a [setDetectTables](https://reference.aspose.com/slides/python-java/aspose.slides/pdfimportoptions/#setDetectTables) con `True` y pase las opciones a [addFromPdf](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addFromPdf). La calidad del reconocimiento de tablas depende de la estructura y complejidad del PDF de origen.

{{% alert title="Note" color="info" %}}
Después de importar HTML, también puede exportar las diapositivas a [imágenes](/slides/es/python-java/convert-powerpoint-to-png/), [TIFF](/slides/es/python-java/convert-powerpoint-to-tiff/), o [SVG](/slides/es/python-java/render-a-slide-as-an-svg-image/).
{{% /alert %}}