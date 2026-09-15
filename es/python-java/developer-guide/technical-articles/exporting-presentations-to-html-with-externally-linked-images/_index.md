---
title: Exportar presentaciones a HTML con imágenes enlazadas externamente
type: docs
weight: 100
url: /es/python-java/exporting-presentations-to-html-with-externally-linked-images/
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
- imagen enlazada
- imagen enlazada externamente
- recurso enlazado
- recurso externo
- Python
- Java
- Aspose.Slides
description: "Exportar presentaciones de PowerPoint y OpenDocument a HTML en Python usando Aspose.Slides con imágenes y otros recursos guardados como archivos enlazados externamente."
---
## **Resumen**

Por defecto, Aspose.Slides exporta una presentación a un archivo HTML autónomo. Las imágenes y otros recursos se escriben directamente en el HTML, normalmente como datos Base64. Esto es conveniente cuando se necesita un único archivo portable, pero no siempre es el formato más adecuado para un sitio web, un CMS o una canalización de conversión del lado del servidor.

Utilice recursos enlazados externamente cuando quiera:

- reducir el tamaño del documento HTML;
- almacenar en caché imágenes, fuentes, audio o vídeo por separado en un navegador o CDN;
- inspeccionar, sustituir, comprimir o posprocesar los recursos generados después de la exportación;
- mantener la estructura de salida más cercana a lo que una aplicación web espera.

Para el flujo de trabajo general de conversión a HTML, consulte [Convertir presentaciones de PowerPoint a HTML](/slides/es/python-java/convert-powerpoint-to-html/). Este artículo se centra en la parte de enlace de recursos de la exportación.

## **Cómo funciona la exportación con recursos enlazados**

`ILinkEmbedController` permite a su aplicación decidir, recurso por recurso, si el exportador incrusta los datos en el HTML o los guarda externamente y escribe un enlace.

La interfaz tiene tres métodos:

- `ILinkEmbedController.getObjectStoringLocation` decide si un recurso debe enlazarse o incrustarse.
- `ILinkEmbedController.getUrl` devuelve la URL que se escribirá en el HTML generado o en otro recurso enlazado.
- `ILinkEmbedController.saveExternal` escribe los datos del recurso enlazado en disco o en otro destino de almacenamiento.

La ruta del sistema de archivos y la URL del navegador son preocupaciones separadas. Por ejemplo, el ejemplo a continuación escribe los archivos de recursos en `html-output/assets` en disco, mientras que el HTML contiene URLs relativas como `assets/resource-1.svg`. Un navegador resuelve esas URLs relativas al archivo que contiene el enlace. Por lo tanto, un enlace de `presentation.html` a un archivo SVG usa `assets/resource-1.svg`, mientras que un enlace de ese archivo SVG a una imagen guardada en la misma carpeta `assets` usa `resource-4.jpg`.

## **Exportar HTML con recursos enlazados**

El siguiente ejemplo en Python crea un directorio de salida, guarda el archivo HTML allí y almacena los recursos enlazados en un subdirectorio `assets`. El controlador enlaza recursos comunes de imagen, fuente, audio, vídeo y CSS cuando Aspose.Slides proporciona o puede deducir una extensión de archivo segura. Los recursos que no se reconocen permanecen incrustados.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HtmlFormatter, HtmlOptions, LinkEmbedDecision, Presentation, SVGOptions, SaveFormat, SlideImageFormat


class ExternalResourceController:
    EXTENSIONS_BY_CONTENT_TYPE = {
        "image/jpeg": ".jpg",
        "image/png": ".png",
        "image/gif": ".gif",
        "image/bmp": ".bmp",
        "image/svg+xml": ".svg",
        "image/tiff": ".tiff",
        "image/x-emf": ".emf",
        "image/x-wmf": ".wmf",
        "font/woff": ".woff",
        "font/woff2": ".woff2",
        "font/ttf": ".ttf",
        "application/font-woff": ".woff",
        "application/vnd.ms-fontobject": ".eot",
        "application/x-font-ttf": ".ttf",
        "text/css": ".css",
        "audio/mpeg": ".mp3",
        "audio/mp4": ".m4a",
        "audio/wav": ".wav",
        "video/mp4": ".mp4",
        "video/webm": ".webm",
    }

    def __init__(self, asset_directory, asset_url_prefix):
        self.asset_directory = asset_directory
        normalized_prefix = asset_url_prefix.replace("\\", "/") if asset_url_prefix else ""
        self.asset_url_prefix = normalized_prefix.rstrip("/") + "/" if normalized_prefix else ""
        self.file_names_by_resource_id = {}

    def getObjectStoringLocation(self, resource_id, entity_data, semantic_name, content_type, recommended_extension):
        extension = self.resolve_extension(content_type, recommended_extension)
        if extension is None:
            return LinkEmbedDecision.Embed

        self.file_names_by_resource_id[resource_id] = f"resource-{resource_id}{extension}"
        return LinkEmbedDecision.Link

    def getUrl(self, resource_id, referrer):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            return None
        if referrer in self.file_names_by_resource_id:
            return file_name
        return self.asset_url_prefix + file_name

    def saveExternal(self, resource_id, entity_data):
        file_name = self.file_names_by_resource_id.get(resource_id)
        if file_name is None:
            print(f"Resource {resource_id} was not registered for external storage.")
            return
        if entity_data is None or len(entity_data) == 0:
            print(f"Resource {resource_id} contains no data and cannot be saved.")
            return

        try:
            self.asset_directory.mkdir(parents=True, exist_ok=True)
            file_path = self.asset_directory / file_name
            resource_data = bytes(entity_data)
            file_path.write_bytes(resource_data)
        except OSError as error:
            print(f"Failed to save external resource {resource_id}: {error}")

    @classmethod
    def resolve_extension(cls, content_type, recommended_extension):
        content_type = str(content_type) if content_type is not None else ""
        mapped_extension = cls.EXTENSIONS_BY_CONTENT_TYPE.get(content_type)
        if mapped_extension is not None:
            return mapped_extension
        if not content_type.lower().startswith(("image/", "font/", "audio/", "video/")):
            return None
        if recommended_extension is None:
            return None
        extension_characters = str(recommended_extension).strip().lstrip(".")
        if not extension_characters or not extension_characters.isalnum():
            return None
        return "." + extension_characters.lower()


input_file_path = Path("presentation.pptx")
output_directory = Path("html-output")
asset_directory_name = "assets"
asset_directory = output_directory / asset_directory_name

output_directory.mkdir(parents=True, exist_ok=True)
asset_directory.mkdir(parents=True, exist_ok=True)

asset_url_prefix = asset_directory_name + "/"
controller = ExternalResourceController(asset_directory, asset_url_prefix)
controller_proxy = jpype.JProxy("com.aspose.slides.ILinkEmbedController", inst=controller)
svg_options = SVGOptions(controller_proxy)
slide_image_format = SlideImageFormat.svg(svg_options)

html_options = HtmlOptions(controller_proxy)
html_formatter = HtmlFormatter.createDocumentFormatter("", False)
html_options.setHtmlFormatter(html_formatter)
html_options.setSlideImageFormat(slide_image_format)

presentation = Presentation(str(input_file_path))
try:
    html_file_path = output_directory / "presentation.html"
    presentation.save(str(html_file_path), SaveFormat.Html, html_options)
finally:
    presentation.dispose()
```

Después de la exportación, la carpeta de salida tiene esta estructura:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Los archivos exactos dependen del contenido de la presentación y de las opciones de exportación. Por ejemplo, las imágenes raster suelen exportarse como JPEG o PNG. Aspose.Slides puede elegir un códec de imagen diferente al usado en la presentación original cuando eso produce un archivo más pequeño o más adecuado. Las imágenes con transparencia se exportan como PNG.

## **Elección de URLs para la implementación**

El ejemplo utiliza un prefijo de URL relativa: `assets/`. Si `presentation.html` se abre desde `html-output/presentation.html`, el navegador carga `html-output/assets/resource-1.svg`.

Cuando un recurso enlazado hace referencia a otro recurso enlazado, el ejemplo usa el parámetro `referrer` en `ILinkEmbedController.getUrl` y devuelve solo el nombre del archivo. Por ejemplo, si `resource-1.svg` y `resource-4.jpg` están ambos en la carpeta `assets`, el archivo SVG debe referirse a `resource-4.jpg`, no a `assets/resource-4.jpg`.

Utilice un prefijo de URL diferente cuando los archivos se implementen en otro lugar:

- Use `assets/` cuando el directorio de activos esté junto al archivo HTML.
- Use `../assets/` cuando el directorio de activos esté un nivel por encima del archivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` cuando los archivos se carguen en un CDN o servidor de archivos estáticos.

La URL devuelta por `ILinkEmbedController.getUrl` debe coincidir con la ubicación final donde se despliegue el archivo escrito por `ILinkEmbedController.saveExternal`. En aplicaciones de servidor, utilice un directorio de salida único o un prefijo de almacenamiento de objetos para cada trabajo de conversión para evitar sobrescribir archivos de otra exportación.

## **Cuándo incrustar en su lugar**

El HTML con Base64 incrustado sigue siendo útil cuando la salida debe ser un único archivo, como un adjunto de correo electrónico, una vista previa offline o un documento que se moverá sin una carpeta de activos de soporte. Los recursos enlazados son más adecuados cuando el HTML será servido por una aplicación web, almacenado en un CMS, optimizado por una canalización de compilación o almacenado en caché por navegadores de forma independiente del HTML.

## **Preguntas frecuentes**

**¿Puedo externalizar solo las imágenes y mantener los demás recursos incrustados?**

Sí. En `ILinkEmbedController.getObjectStoringLocation`, devuelva [LinkEmbedDecision.Link](https://reference.aspose.com/slides/es/python-java/aspose.slides/linkembeddecision/#Link) solo para los tipos de contenido que desea guardar como archivos separados, y devuelva [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/es/python-java/aspose.slides/linkembeddecision/#Embed) para todo lo demás.

**¿Por qué la extensión de la imagen exportada difiere de la presentación original?**

Aspose.Slides puede volver a codificar las imágenes raster durante la exportación a HTML para mejorar el tamaño o la compatibilidad con el navegador. Por ejemplo, una imagen del archivo original puede escribirse como JPEG o PNG dependiendo del resultado renderizado.

**¿Funcionan las URLs relativas después de mover el archivo HTML?**

Las URLs relativas funcionan solo cuando se preserva la misma estructura de carpetas relativa. Si el HTML hace referencia a `assets/resource-1.png`, la carpeta `assets` debe permanecer junto al archivo HTML a menos que genere un prefijo de URL diferente.

**¿Deben las aplicaciones de servidor reutilizar la misma carpeta de salida?**

No. Utilice un directorio de salida único o un prefijo de almacenamiento para cada trabajo de conversión. Así se evitan colisiones de nombres de archivo y se impide que una exportación sobrescriba recursos generados por otra exportación.