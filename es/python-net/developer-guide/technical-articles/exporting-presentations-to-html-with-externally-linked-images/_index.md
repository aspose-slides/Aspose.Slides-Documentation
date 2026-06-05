---
title: Exportar presentaciones a HTML con imágenes vinculadas externamente en Python
linktitle: Exportar presentaciones a HTML con imágenes vinculadas externamente
type: docs
weight: 100
url: /es/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exportar PowerPoint
- exportar OpenDocument
- exportar presentación
- exportar diapositiva
- exportar PPT
- exportar PPTX
- exportar ODP
- PowerPoint a HTML
- OpenDocument a HTML
- presentación a HTML
- diapositiva a HTML
- PPT a HTML
- PPTX a HTML
- ODP a HTML
- imagen vinculada
- imagen vinculada externamente
- recurso vinculado
- recurso externo
- Python
- Aspose.Slides
description: "Exportar presentaciones PowerPoint y OpenDocument a HTML en Python usando Aspose.Slides con imágenes guardadas como archivos externos vinculados."
---
## **Visión general**

De forma predeterminada, Aspose.Slides exporta una presentación a un archivo HTML autocontenido. Las imágenes y otros recursos se escriben directamente en el HTML, normalmente como datos Base64. Esto es conveniente cuando necesita un único archivo portable, pero no siempre es el formato más adecuado para un sitio web, un CMS o una canalización de conversión del lado del servidor.

- reducir el tamaño del documento HTML;
- almacenar en caché las imágenes por separado en un navegador o CDN;
- inspeccionar, reemplazar, comprimir o post‑procesar las imágenes generadas tras la exportación;
- mantener la estructura de salida más cercana a lo que espera una aplicación web.

Para el flujo de trabajo general de conversión a HTML, consulte [Convert PowerPoint Presentations to HTML](/slides/es/python-net/convert-powerpoint-to-html/). Este artículo se centra en la parte de enlazado de imágenes de la exportación.

## **Cómo funciona la exportación de imágenes vinculadas**

En .NET y Java, [ILinkEmbedController](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/ilinkembedcontroller/) representa la interfaz de devolución de llamada que utiliza el exportador para decidir si un recurso debe incrustarse o enlazarse. En Python a través de .NET, las clases de Python actualmente no pueden implementar directamente esta interfaz de devolución de llamada de .NET, por lo que el flujo de trabajo práctico es:

1. Exportar la presentación a HTML con [HtmlOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/htmloptions/).
1. Utilizar [SlideImageFormat](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/slideimageformat/) con [SVGOptions](https://reference.aspose.com/slides/es/python-net/aspose.slides.export/svgoptions/) para que las diapositivas se representen como SVG en el HTML.
1. Mover los datos de imagen Base64 de las URL `data:` de HTML a archivos separados.
1. Reemplazar las URL `data:` originales por enlaces relativos, como `assets/resource-1.jpg`.

La ruta del sistema de archivos y la URL del navegador son asuntos separados. Por ejemplo, el ejemplo a continuación escribe los archivos de imagen en `html-output/assets` en el disco, mientras que el HTML contiene URLs relativas como `assets/resource-1.jpg`. Un navegador resuelve esas URLs en relación con el archivo HTML que contiene el enlace.

## **Exportar HTML con imágenes vinculadas**

El siguiente ejemplo en Python crea un directorio de salida, guarda allí el archivo HTML, almacena las imágenes extraídas en un subdirectorio `assets` y reescribe las URLs de imágenes Base64 a enlaces relativos. El ejemplo extrae formatos de imagen Base64 comunes cuando Aspose.Slides proporciona una extensión de archivo segura. Las URL de datos que no se reconocen permanecen incrustadas.

```python
import base64
import os
import re

import aspose.slides as slides
import aspose.slides.export as slides_export


EXTENSIONS_BY_CONTENT_TYPE = {
    "image/jpeg": ".jpg",
    "image/png": ".png",
    "image/gif": ".gif",
    "image/bmp": ".bmp",
    "image/svg+xml": ".svg",
    "image/tiff": ".tiff",
    "image/x-emf": ".emf",
    "image/x-wmf": ".wmf",
}

DATA_URI_PATTERN = re.compile(
    r"data:(?P<content_type>[-\w.+]+/[-\w.+]+);base64,(?P<data>[A-Za-z0-9+/=\r\n]+)"
)


def export_presentation_to_html_with_linked_images(
    input_file_path,
    output_directory,
    asset_directory_name="assets",
):
    asset_directory = os.path.join(output_directory, asset_directory_name)

    os.makedirs(output_directory, exist_ok=True)
    os.makedirs(asset_directory, exist_ok=True)

    html_options = slides_export.HtmlOptions()
    html_options.html_formatter = slides_export.HtmlFormatter.create_document_formatter("", False)
    html_options.slide_image_format = slides_export.SlideImageFormat.svg(
        slides_export.SVGOptions()
    )

    html_file_path = os.path.join(output_directory, "presentation.html")

    with slides.Presentation(input_file_path) as presentation:
        presentation.save(html_file_path, slides_export.SaveFormat.HTML, html_options)

    externalize_base64_images(html_file_path, asset_directory, asset_directory_name)


def externalize_base64_images(html_file_path, asset_directory, asset_directory_name):
    with open(html_file_path, "r", encoding="utf-8-sig") as html_file:
        html_content = html_file.read()

    saved_resource_names = {}
    resource_index = 1

    def replace_data_uri(match):
        nonlocal resource_index

        data_uri = match.group(0)
        if data_uri in saved_resource_names:
            return saved_resource_names[data_uri]

        content_type = match.group("content_type").lower()
        extension = EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if extension is None:
            return data_uri

        encoded_data = match.group("data")
        image_data = base64.b64decode(encoded_data)
        if len(image_data) == 0:
            return data_uri

        file_name = f"resource-{resource_index}{extension}"
        resource_index += 1

        file_path = os.path.join(asset_directory, file_name)
        with open(file_path, "wb") as image_file:
            image_file.write(image_data)

        linked_url = f"{asset_directory_name}/{file_name}"
        saved_resource_names[data_uri] = linked_url
        return linked_url

    updated_html_content = DATA_URI_PATTERN.sub(replace_data_uri, html_content)

    with open(html_file_path, "w", encoding="utf-8", newline="\n") as html_file:
        html_file.write(updated_html_content)


input_file_path = "presentation.pptx"
output_directory = "html-output"

export_presentation_to_html_with_linked_images(input_file_path, output_directory)
```

Después de la exportación, la carpeta de salida puede tener esta estructura:

```text
html-output/
  presentation.html
  assets/
    resource-1.jpg
    resource-2.png
```

Los archivos exactos dependen del contenido de la presentación y de las opciones de exportación. Por ejemplo, las imágenes raster suelen exportarse como JPEG o PNG. Aspose.Slides puede elegir un códec de imagen diferente al usado en la presentación original cuando eso produce un archivo más pequeño o más adecuado. Las imágenes con transparencia se exportan como PNG.

## **Elección de URLs para el despliegue**

El ejemplo usa un prefijo de URL relativa: `assets/`. Si `presentation.html` se abre desde `html-output/presentation.html`, el navegador carga `html-output/assets/resource-1.jpg`.

Utilice un nombre de directorio de activos diferente o reescriba los enlaces generados cuando los archivos se desplieguen en otro lugar:

- Utilice `assets/` cuando el directorio de activos esté junto al archivo HTML.
- Utilice `../assets/` cuando el directorio de activos esté un nivel por encima del archivo HTML.
- Utilice `https://cdn.example.com/presentations/job-123/assets/` cuando los archivos se suban a un CDN o a un servidor de archivos estáticos.

En aplicaciones de servidor, use un directorio de salida único o un prefijo de almacenamiento de objetos para cada trabajo de conversión para evitar sobrescribir archivos de otra exportación.

## **Cuándo incrustar en su lugar**

El HTML incrustado en Base64 sigue siendo útil cuando la salida debe ser un solo archivo, como un adjunto de correo electrónico, una vista previa offline o un documento que se moverá sin una carpeta de activos de apoyo. Las imágenes vinculadas son más adecuadas cuando el HTML será servido por una aplicación web, almacenado en un CMS, optimizado por una canalización de compilación o almacenado en caché por los navegadores de forma independiente del HTML.

## **FAQ**

**¿Puedo externalizar solo las imágenes y mantener los demás recursos incrustados?**

Sí. El ejemplo extrae solo las URL de datos Base64 `image/*` cuyos tipos de contenido están listados en `EXTENSIONS_BY_CONTENT_TYPE`. Las demás URL de datos permanecen incrustadas.

**¿Por qué la extensión de la imagen exportada difiere de la presentación original?**

Aspose.Slides puede volver a codificar las imágenes raster durante la exportación a HTML para mejorar el tamaño o la compatibilidad con el navegador. Por ejemplo, una imagen del archivo original puede escribirse como JPEG o PNG según el resultado renderizado.

**¿Funcionan las URLs relativas después de mover el archivo HTML?**

Las URLs relativas funcionan solo cuando se conserva la misma estructura de carpetas relativa. Si el HTML hace referencia a `assets/resource-1.png`, la carpeta `assets` debe permanecer junto al archivo HTML a menos que genere un prefijo de URL diferente.

**¿Deben las aplicaciones de servidor reutilizar la misma carpeta de salida?**

No. Utilice un directorio de salida único o un prefijo de almacenamiento para cada trabajo de conversión. Esto evita colisiones de nombres de archivo y previene que una exportación sobrescriba los recursos generados por otra exportación.