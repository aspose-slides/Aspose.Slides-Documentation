---
title: Exportando Presentaciones a HTML con Imágenes Enlazadas Externamente
type: docs
weight: 50
url: /cpp/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

Este artículo describe una técnica avanzada que permite controlar qué recursos se incrustan en el archivo HTML resultante y cuáles se guardan externamente y se referencian desde el archivo HTML.

{{% /alert %}} 
## **Contexto**
El comportamiento predeterminado de exportación a HTML es incrustar cualquier recurso en el archivo HTML. Este enfoque da como resultado un solo archivo HTML que es fácil de ver y distribuir. Todos los recursos necesarios están codificados en base64 dentro. Pero este enfoque tiene dos desventajas:

- El tamaño de salida es significativamente mayor debido a la codificación en base64. Es difícil reemplazar las imágenes contenidas en el archivo.

En este artículo veremos cómo podemos cambiar el comportamiento predeterminado usando **Aspose.Slides para C++** para enlazar las imágenes externamente en lugar de incrustarlas en el archivo HTML. Usaremos la interfaz [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller) que contiene tres métodos para controlar el proceso de incrustación y guardado de recursos. Podemos pasar esta interfaz al constructor de la clase [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) al preparar la exportación.

A continuación se muestra el código completo de la clase **LinkController** que implementa la interfaz [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). Como se mencionó anteriormente, el **LinkController** debe implementar la interfaz [ILinkEmbedController](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.i_link_embed_controller). Esta interfaz especifica tres métodos:

- **LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, String semanticName, String contentType, String recomendedExtension)** Se llama cuando el exportador encuentra un recurso y necesita decidir cómo almacenarlo. Los parámetros más importantes son ‘id’ – el identificador único del recurso para toda la operación de exportación y ‘contentType’ – contiene el tipo MIME del recurso. Si decidimos enlazar el recurso, deberíamos retornar LinkEmbedDecision::Link desde este método. De lo contrario, se debe retornar LinkEmbedDecision::Embed para incrustar el recurso.
- **String GetUrl(int32_t id, int32_t referrer)**
  Se llama para obtener la URL del recurso en la forma en que se utiliza en el archivo resultante, digamos para una etiqueta ```<img src="%method_result_here%">```. El recurso se identifica por ‘id’.
- **SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData)** 
  El método final de la secuencia, se llama cuando se trata de almacenar el recurso externamente. Tenemos el identificador del recurso y el contenido del recurso como un arreglo de bytes. Depende de nosotros qué hacer con los datos del recurso proporcionados.

``` cpp
/// <summary>
/// Esta clase es responsable de tomar decisiones sobre los recursos guardados externamente.
/// Debe implementar la interfaz Aspose::Slides::Export::ILinkEmbedController.
/// </summary>
class LinkController : public ILinkEmbedController
{
public:
    LinkController()
    {
        m_externalImages = System::MakeObject<Dictionary<int32_t, String>>();
    }
    LinkController::LinkController(String savePath) : LinkController()
    {
        m_savePath = savePath;
    }

    LinkEmbedDecision GetObjectStoringLocation(int32_t id, ArrayPtr<uint8_t> entityData, 
        String semanticName, String contentType, String recomendedExtension) override
    {
        // Aquí tomamos la decisión sobre almacenar imágenes externamente.
        // El id es el identificador único de cada objeto durante toda la operación de exportación.

        String template_;

        // El diccionario s_templates contiene tipos de contenido que vamos a almacenar externamente y el correspondiente nombre de archivo plantilla.
        if (s_templates->TryGetValue(contentType, template_))
        {
            // Almacenando este recurso en la lista de exportación
            m_externalImages->Add(id, template_);
            return LinkEmbedDecision::Link;
        }

        // Todos los demás recursos, si los hay, serán incrustados
        return LinkEmbedDecision::Embed;
    }

    String GetUrl(int32_t id, int32_t referrer) override
    {
        // Aquí construimos la cadena de referencia del recurso para formar la etiqueta: <img src="%result%">
        // Necesitamos verificar el diccionario para filtrar recursos innecesarios.
        // Junto con la verificación extraemos el correspondiente nombre de archivo plantilla.
        String template_;
        if (m_externalImages->TryGetValue(id, template_))
        {
            // Suponiendo que vamos a almacenar archivos de recursos justo cerca del archivo HTML.
            // La etiqueta de imagen se verá como <img src="image-1.png"> con el Id y la extensión del recurso apropiados.
            String fileUrl = String::Format(template_, id);
            return fileUrl;
        }

        // se debe retornar null para los recursos que siguen incrustados
        return nullptr;
    }

    void SaveExternal(int32_t id, ArrayPtr<uint8_t> entityData) override
    {
        // Aquí realmente guardamos los archivos de recursos en disco.
        // Una vez más, verificando el diccionario. Si el id no se encuentra aquí, es un signo de error en los métodos GetObjectStoringLocation o GetUrl.
        if (m_externalImages->ContainsKey(id))
        {
            // Ahora usamos el nombre de archivo almacenado en el diccionario y lo combinamos con una ruta según sea necesario.

            // Construyendo el nombre de archivo usando la plantilla almacenada y el Id.
            String fileName = String::Format(m_externalImages->idx_get(id), id);
            
            // Combinando con el directorio de ubicación
            const String savePath = m_savePath != nullptr ? m_savePath : String::Empty;
            String filePath = Path::Combine(savePath, fileName);

            auto fs = System::MakeObject<FileStream>(filePath, FileMode::Create);
            fs->Write(entityData, 0, entityData->get_Length());
        }
        else
        {
            throw Exception(u"Algo está mal");
        }
    }

private:
    String m_savePath;
    SharedPtr<Dictionary<int32_t, String>> m_externalImages;
    static SharedPtr<Dictionary<String, String>> s_templates;

    static struct __StaticConstructor__
    {
        __StaticConstructor__()
        {
            s_templates->Add(u"image/jpeg", u"image-{0}.jpg");
            s_templates->Add(u"image/png", u"image-{0}.png");
        }
    } s_constructor__;
};
```

Después de escribir la clase **LinkController**, ahora la usaremos con la clase [HtmlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.html_options) para exportar la presentación a HTML con imágenes enlazadas externamente utilizando el siguiente código.

``` cpp
const String templatePath = u"../templates/image.pptx";
auto pres = System::MakeObject<Presentation>(templatePath);

auto htmlOptions = System::MakeObject<HtmlOptions>(System::MakeObject<LinkController>(GetOutPath()));
htmlOptions->set_SlideImageFormat(SlideImageFormat::Svg(System::MakeObject<SVGOptions>()));
// Esta línea es necesaria para eliminar la visualización del título de la diapositiva en HTML.
// Comente esta línea si prefiere que se muestre el título de la diapositiva.
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));

pres->Save(GetOutPath() + u"/output.html", SaveFormat::Html, htmlOptions);
```

Pasamos **SlideImageFormat::Svg** al método **set_SlideImageFormat**, lo que significa que el archivo HTML resultante contendrá datos SVG dentro para dibujar el contenido de la presentación.

En cuanto a los tipos de contenido, depende de los datos de imagen reales contenidos en la presentación. Si hay mapas de bits rasterizados en la presentación, entonces el código de la clase debe estar listo para procesar tanto ‘image/jpeg’ como ‘image/png’. El tipo de contenido real de los mapas de bits rasterizados exportados puede no coincidir con el tipo de contenido de las imágenes almacenadas en la presentación. Los algoritmos internos de Aspose.Slides para C++ realizan optimización de tamaño y utilizan ya sea el códec JPG o PNG, el que genere un tamaño de datos más pequeño. Las imágenes que contienen canal alfa (transparencia) siempre se codifican a PNG.