---
title: Exportación de Presentaciones a HTML con Imágenes Vinculadas Externamente
type: docs
weight: 100
url: /net/exporting-presentations-to-html-with-externally-linked-images/
---

{{% alert color="primary" %}} 

El procedimiento de exportación de Presentación a HTML aquí te permite especificar

1. los recursos que se integrarán en el archivo HTML resultante
2. los recursos que se guardarán externamente y se referenciarán desde el archivo HTML.

{{% /alert %}} 

## **Antecedentes**

El comportamiento predeterminado de exportación a HTML es integrar todos los recursos dentro del archivo HTML mediante codificación base64. Este enfoque produce un único archivo HTML, que es conveniente para la visualización y distribución. El enfoque predeterminado tiene estas limitaciones:

* el archivo generado es significativamente más grande que sus componentes debido a la codificación base64. 
* las imágenes o recursos contenidos en el archivo son difíciles de reemplazar.

### **Un Enfoque Diferente**

Un enfoque diferente que involucra **[ILinkEmbedController](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/)** evita las limitaciones mencionadas.  

La clase `LinkController` implementa la interfaz `ILinkEmbedController`. La interfaz se pasa entonces al constructor de la clase [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/htmloptions/#constructor). La interfaz ILinkEmbedController contiene tres métodos que controlan el proceso de integración y almacenamiento de recursos:

**[GetObjectStoringLocation](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation)(int id, byte[] entityData, string semanticName, string contentType, string recomendedExtension)**: Este método se llama cuando el exportador encuentra un recurso y debe decidir cómo almacenar el recurso. *id* (identificador único del recurso para la operación de exportación) y *contentType* (que contiene el tipo MIME del recurso) son los parámetros más importantes del método. Si deseas vincular el recurso, debes devolver el enum [LinkEmbedDecision.Link](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/) desde el método. De lo contrario (para integrar el recurso), debes devolver [LinkEmbedDecision.Embed](https://reference.aspose.com/slides/net/aspose.slides.export/linkembeddecision/).

**[GetUrl](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/geturl)(int id, int referrer)**: Este método se llama para obtener la URL del recurso de la misma manera en que se utiliza en el archivo resultante. El recurso se identifica por *id*.

**[SaveExternal](https://reference.aspose.com/slides/net/aspose.slides.export/ilinkembedcontroller/saveexternal)(int id, byte[] entityData)**: Como el último método de la secuencia, se llama cuando es el momento de almacenar el recurso externamente. Dado que el identificador del recurso y el contenido del recurso existen en un array de bytes, puedes realizar todo tipo de tareas con los datos del recurso.

Este código C# para la clase **LinkController** implementa la interfaz **ILinkEmbedController**:

```c#
class LinkController : ILinkEmbedController
{
    static LinkController()
    {
        s_templates.Add("image/jpeg", "image-{0}.jpg");
        s_templates.Add("image/png", "image-{0}.png");
    }

    /// <summary>
    /// Constructor predeterminado sin parámetros
    /// </summary>
    public LinkController()
    {
        m_externalImages = new Dictionary<int, string>();
    }

    /// <summary>
    /// Crea una instancia de clase y establece la ruta donde se guardarán los archivos de recursos generados.
    /// </summary>
    /// <param name="savePath">Ruta al lugar donde se almacenarán los archivos de recursos generados.</param>
    public LinkController(string savePath)
        : this()
    {
        SavePath = savePath;
    }

    /// <summary>
    /// Un miembro de ILinkEmbedController
    /// </summary>
    public LinkEmbedDecision GetObjectStoringLocation(int id, byte[] entityData, string semanticName,
        string contentType,
        string recomendedExtension)
    {
        // Aquí tomamos la decisión sobre almacenar imágenes externamente.
        // El id es el identificador único de cada objeto durante toda la operación de exportación.

        string template;

        // El diccionario s_templates contiene tipos de contenido que vamos a almacenar externamente y la plantilla de nombre de archivo correspondiente.
        if (s_templates.TryGetValue(contentType, out template))
        {
            // Almacenando este recurso en la lista de exportación
            m_externalImages.Add(id, template);
            return LinkEmbedDecision.Link;
        }

        // Todos los demás recursos, si los hay, se integrarán
        return LinkEmbedDecision.Embed;
    }

    /// <summary>
    /// Un miembro de ILinkEmbedController
    /// </summary>
    public string GetUrl(int id, int referrer)
    {
        // Aquí construimos la cadena de referencia del recurso para formar la etiqueta: <img src="%result%">
        // Necesitamos comprobar el diccionario para filtrar recursos innecesarios.
        // Junto con la verificación, extraemos la plantilla de nombre de archivo correspondiente.
        string template;
        if (m_externalImages.TryGetValue(id, out template))
        {
            // Suponiendo que vamos a almacenar archivos de recursos cerca del archivo HTML.
            // La etiqueta de imagen se verá como <img src="image-1.png"> con el Id del recurso apropiado y la extensión.
            var fileUrl = String.Format(template, id);
            return fileUrl;
        }

        // se debe devolver null para los recursos que permanecen integrados
        return null;
    }

    /// <summary>
    /// Un miembro de ILinkEmbedController
    /// </summary>
    public void SaveExternal(int id, byte[] entityData)
    {
        // Aquí guardamos realmente los archivos de recursos en el disco.
        // Una vez más, verificando el diccionario. Si el id no se encuentra aquí, es un indicativo de error en los métodos GetObjectStoringLocation o GetUrl.
        if (m_externalImages.ContainsKey(id))
        {
            // Ahora usamos el nombre de archivo almacenado en el diccionario y lo combinamos con la ruta requerida.

            // Construyendo el nombre del archivo usando la plantilla almacenada y el Id.
            var fileName = String.Format(m_externalImages[id], id);

            // Combinando con el directorio de ubicación
            var filePath = Path.Combine(SavePath ?? String.Empty, fileName);

            using (var fs = new FileStream(filePath, FileMode.Create))
                fs.Write(entityData, 0, entityData.Length);
        }
        else
            throw new Exception("Algo está mal");
    }

    /// <summary>
    /// Obtiene o establece la ruta donde se guardarán los archivos de recursos generados.
    /// </summary>
    public string SavePath { get; set; }

    /// <summary>
    /// Un diccionario para almacenar asociaciones entre ids de recursos y los nombres de archivo correspondientes.
    /// </summary>
    private readonly Dictionary<int, string> m_externalImages;

    /// <summary>
    /// Un diccionario para almacenar asociaciones entre tipos de contenido de recursos que vamos a almacenar externamente
    /// y las plantillas de nombres de archivo correspondientes.
    /// </summary>
    private static readonly Dictionary<string, string> s_templates = new Dictionary<string, string>();
}
```

Después de escribir la clase **LinkController**, ahora podemos usarla junto con la clase **HTMLOptions** para exportar la presentación a HTML con imágenes vinculado externamente de esta manera:

```c#
using (var pres = new Presentation(@"C:\data\input.pptx")) {

    var htmlOptions = new HtmlOptions(new LinkController(@"C:\data\out\"));
    htmlOptions.SlideImageFormat = SlideImageFormat.Svg(new SVGOptions());
    // Esta línea es necesaria para eliminar la visualización del título de la diapositiva en HTML.
    // Coméntalo si prefieres que se muestre el título de la diapositiva.
    htmlOptions.HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(String.Empty, false);

    Console.WriteLine("Iniciando exportación");
    pres.Save(@"C:\data\out\output.html", SaveFormat.Html, htmlOptions);
}
```

Asignamos `SlideImageFormat.Svg` a la propiedad `SlideImageFormat` para que el archivo HTML resultante contenga datos SVG para dibujar el contenido de la presentación.

Tipos de contenido: Si la presentación contiene mapas de bits rasterizados, entonces el código de la clase debe estar preparado para procesar tanto 'image/jpeg' como 'image/png'. El contenido de las imágenes bitmap exportadas puede no coincidir con lo que se almacenó en la presentación. Los algoritmos internos de Aspose.Slides realizan optimización de tamaño y utilizan ya sea el códec JPG o PNG (dependiendo de cuál genere un tamaño de datos menor). Las imágenes que contienen canal alfa (transparencia) se codifican siempre en PNG.