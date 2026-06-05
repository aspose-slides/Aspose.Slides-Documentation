---
title: Exportar presentaciones a HTML con imágenes enlazadas externamente
type: docs
weight: 50
url: /es/cpp/exporting-presentations-to-html-with-externally-linked-images/
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
- C++
- Aspose.Slides
description: "Exportar presentaciones de PowerPoint y OpenDocument a HTML en C++ usando Aspose.Slides con imágenes y otros recursos guardados como archivos enlazados externamente."
---
## **Visión general**

De forma predeterminada, Aspose.Slides exporta una presentación a un archivo HTML autocontenido. Las imágenes y otros recursos se escriben directamente en el HTML, generalmente como datos Base64. Esto es práctico cuando se necesita un único archivo portable, pero no siempre es el mejor formato para un sitio web, un CMS o una canalización de conversión del lado del servidor.

Utilice recursos enlazados externamente cuando quiera:

- reducir el tamaño del documento HTML;
- almacenar en caché imágenes, fuentes, audio o vídeo por separado en un navegador o CDN;
- inspeccionar, reemplazar, comprimir o post‑procesar los recursos generados después de la exportación;
- mantener la estructura de salida más cercana a lo que espera una aplicación web.

Para el flujo de trabajo general de conversión a HTML, consulte [Convertir presentaciones de PowerPoint a HTML](/slides/es/cpp/convert-powerpoint-to-html/). Este artículo se centra en la parte de enlazado de recursos de la exportación.

## **Cómo funciona la exportación con recursos enlazados**

[ILinkEmbedController](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/) permite a su aplicación decidir, recurso por recurso, si el exportador incrusta los datos en el HTML o los guarda externamente y escribe un enlace.

La interfaz tiene tres métodos:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) decide si un recurso debe estar enlazado o incrustado.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) devuelve la URL que se escribirá en el HTML generado o en otro recurso enlazado.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) escribe los datos del recurso enlazado en disco o en otro objetivo de almacenamiento.

La ruta del sistema de archivos y la URL del navegador son aspectos separados. Por ejemplo, el ejemplo a continuación escribe los archivos de recursos en `html-output/assets` en disco, mientras que el HTML contiene URL relativas como `assets/resource-1.svg`. Un navegador resuelve esas URL respecto al archivo que contiene el enlace. Por lo tanto, un enlace desde `presentation.html` a un archivo SVG usa `assets/resource-1.svg`, mientras que un enlace desde ese archivo SVG a una imagen guardada en la misma carpeta `assets` usa `resource-4.jpg`.

## **Exportar HTML con recursos enlazados**

El siguiente ejemplo en C++ crea un directorio de salida, guarda el archivo HTML allí y almacena los recursos enlazados en un subdirectorio `assets`. El controlador enlaza los recursos de imagen, fuente, audio, vídeo y CSS comunes cuando Aspose.Slides proporciona o puede inferir una extensión de archivo segura. Los recursos que no se reconocen permanecen incrustados.

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
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

Los archivos exactos dependen del contenido de la presentación y de las opciones de exportación. Por ejemplo, las imágenes raster se exportan normalmente como JPEG o PNG. Aspose.Slides puede elegir un códec de imagen diferente al usado en la presentación original cuando eso produce un archivo más pequeño o más adecuado. Las imágenes con transparencia se exportan como PNG.

## **Elección de URL para la implementación**

El ejemplo utiliza un prefijo de URL relativa: `assets/`. Si `presentation.html` se abre desde `html-output/presentation.html`, el navegador carga `html-output/assets/resource-1.svg`.

Cuando un recurso enlazado hace referencia a otro recurso enlazado, el ejemplo usa el parámetro `referrer` en [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) y devuelve solo el nombre del archivo. Por ejemplo, si `resource-1.svg` y `resource-4.jpg` están ambos en la carpeta `assets`, el archivo SVG debe referirse a `resource-4.jpg`, no a `assets/resource-4.jpg`.

Utilice un prefijo de URL distinto cuando los archivos se implementen en otro lugar:

- Use `assets/` cuando el directorio de activos esté junto al archivo HTML.
- Use `../assets/` cuando el directorio de activos esté un nivel por encima del archivo HTML.
- Use `https://cdn.example.com/presentations/job-123/assets/` cuando los archivos se suban a un CDN o a un servidor de archivos estático.

La URL devuelta por [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) debe coincidir con la ubicación final donde se implemente el archivo escrito por [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/). En aplicaciones de servidor, utilice un directorio de salida único o un prefijo de almacenamiento de objetos para cada trabajo de conversión para evitar sobrescribir archivos de otra exportación.

## **Cuándo incrustar en su lugar**

El HTML incrustado en Base64 sigue siendo útil cuando la salida debe ser un único archivo, como un adjunto de correo electrónico, una vista previa sin conexión o un documento que se moverá sin una carpeta de recursos de apoyo. Los recursos enlazados son más apropiados cuando el HTML será servido por una aplicación web, almacenado en un CMS, optimizado por una canalización de compilación o almacenado en caché por los navegadores de forma independiente del HTML.

## **Preguntas frecuentes**

**¿Puedo externalizar solo las imágenes y mantener los demás recursos incrustados?**

Sí. En [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/es/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), devuelva `LinkEmbedDecision::Link` solo para los tipos de contenido que quiera guardar como archivos separados, y devuelva `LinkEmbedDecision::Embed` para todo lo demás.

**¿Por qué la extensión de la imagen exportada difiere de la presentación original?**

Aspose.Slides puede volver a codificar las imágenes raster durante la exportación a HTML para mejorar el tamaño o la compatibilidad con el navegador. Por ejemplo, una imagen del archivo fuente puede escribirse como JPEG o PNG según el resultado renderizado.

**¿Funcionan las URL relativas después de mover el archivo HTML?**

Las URL relativas solo funcionan cuando se conserva la misma estructura de carpetas relativa. Si el HTML hace referencia a `assets/resource-1.png`, la carpeta `assets` debe quedar junto al archivo HTML a menos que genere un prefijo de URL diferente.

**¿Deben las aplicaciones de servidor reutilizar la misma carpeta de salida?**

No. Utilice un directorio de salida único o un prefijo de almacenamiento para cada trabajo de conversión. Esto evita colisiones de nombres de archivo y previene que una exportación sobrescriba recursos generados por otra exportación.