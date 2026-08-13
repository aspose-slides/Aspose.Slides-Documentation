---
title: Optimizar la gestión de imágenes en presentaciones en .NET
linktitle: Administrar imágenes
type: docs
weight: 10
url: /es/net/image/
keywords:
- agregar imagen
- agregar foto
- agregar bitmap
- reemplazar imagen
- reemplazar foto
- desde web
- fondo
- agregar PNG
- agregar JPG
- agregar SVG
- recursos SVG externos
- resolvedor SVG
- imágenes SVG enlazadas
- fuentes SVG
- agregar EMF
- agregar WMF
- agregar TIFF
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Optimiza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para .NET, mejorando el rendimiento y automatizando tu flujo de trabajo."
---
## **Introducción**

Las imágenes hacen que las presentaciones sean más atractivas y visualmente agradables. En Microsoft PowerPoint, puedes insertar imágenes en las diapositivas desde archivos, Internet u otras fuentes. De manera similar, Aspose.Slides permite agregar imágenes a las diapositivas de la presentación de varias formas.

{{% alert  title="Consejo" color="info" %}} 

Aspose ofrece conversores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que te permiten crear rápidamente presentaciones a partir de imágenes. 

{{% /alert %}} 

{{% alert title="Información" color="info" %}}

Si deseas agregar una imagen como marco de foto—especialmente si planeas cambiar su tamaño, aplicar efectos o usar otras opciones estándar de formato—consulta [Marco de foto](/slides/es/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}

Puedes convertir imágenes de un formato a otro. Consulta las siguientes páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/net/conversion/image-to-jpg/), [JPG a imagen](https://products.aspose.com/slides/es/net/conversion/jpg-to-image/), [JPG a PNG](https://products.aspose.com/slides/es/net/conversion/jpg-to-png/), [PNG a JPG](https://products.aspose.com/slides/es/net/conversion/png-to-jpg/), [PNG a SVG](https://products.aspose.com/slides/es/net/conversion/png-to-svg/), y [SVG a PNG](https://products.aspose.com/slides/es/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides admite imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros. 

## **Agregar imágenes almacenadas localmente a las diapositivas**

Puedes agregar una o varias imágenes almacenadas en tu ordenador a una diapositiva de la presentación. El siguiente código de ejemplo en C# muestra cómo agregar una imagen a una diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Agregar imágenes desde la web a las diapositivas**

Si la imagen que deseas agregar a una diapositiva no está almacenada en tu ordenador, puedes añadirla directamente desde la web. 

El siguiente código de ejemplo en C# muestra cómo agregar una imagen desde la web a una diapositiva:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Agregar imágenes a los másters de diapositivas**

Un máster de diapositiva almacena y controla información como el tema y el diseño de las diapositivas que lo utilizan. Cuando agregas una imagen a un máster de diapositiva, la imagen aparece en cada diapositiva basada en ese máster. 

El siguiente código de ejemplo en C# muestra cómo agregar una imagen a un máster de diapositiva:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Agregar imágenes como fondos de diapositiva**

Puedes usar una imagen como fondo de una o varias diapositivas. Para más detalles, consulta *[Configurar imágenes como fondos de diapositivas](/slides/es/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a presentaciones**

El contenido SVG puede añadirse a una presentación mediante la clase [SvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/svgimage/). El objeto resultante [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/) puede luego agregarse a la colección de imágenes de la presentación y usarse para crear un marco de foto.

El siguiente ejemplo en C# importa una cadena SVG autónoma. Todas las imágenes, estilos y otros recursos utilizados por este SVG están incrustados directamente en el contenido del SVG.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **Importar contenido SVG con recursos externos**

Los archivos SVG exportados desde herramientas de diseño, editores de diagramas, sistemas de iconos y canalizaciones web pueden referenciar recursos que se almacenan fuera del documento SVG. Por ejemplo, un SVG puede contener un enlace a una imagen como `images/photo.png`, un valor CSS `url(...)` o una URL de fuente.

Para importar dicho contenido SVG, crea una implementación de [IExternalResourceResolver](https://reference.aspose.com/slides/es/net/aspose.slides.import/iexternalresourceresolver/) y pásala, junto con una URI base, a un constructor apropiado de `SvgImage`. La URI base identifica la ubicación del documento SVG y se usa para resolver enlaces relativos.

La interfaz [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/) proporciona acceso a información sobre el SVG importado:

- `SvgContent` devuelve el marcado SVG como cadena.
- `SvgData` devuelve el contenido SVG como matriz de bytes.
- `BaseUri` devuelve la URI base utilizada para enlaces relativos.
- `ExternalResourceResolver` devuelve el resolvedor asignado a la imagen SVG.

### **Implementar un resolvedor de recursos externo**

El resolvedor tiene dos métodos:

- [ResolveUri](https://reference.aspose.com/slides/es/net/aspose.slides.import/iexternalresourceresolver/resolveuri/) combina la URI base y un enlace de recurso relativo y devuelve una URI absoluta. Devuelve `null` cuando el enlace no puede resolverse o no está permitido.
- [GetEntity](https://reference.aspose.com/slides/es/net/aspose.slides.import/iexternalresourceresolver/getentity/) devuelve un flujo legible para una URI de recurso absoluta. Devuelve `null` cuando el recurso falta, está bloqueado o no está disponible. También se puede devolver un flujo de respaldo cuando sea apropiado.

El siguiente resolvedor carga recursos enlazados solo desde un directorio local permitido. Los recursos de red y rutas fuera del directorio permitido se bloquean. Se devuelve una imagen de respaldo opcional para los enlaces de imagen no resueltos.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // Este resolvedor permite intencionalmente solo archivos locales.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // Utiliza un recurso de respaldo solo para recursos de imagen.
        // Devolver un flujo de imagen para una fuente o hoja de estilo faltante no sería válido.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **Resolver recursos enlazados durante la importación de SVG**

Supongamos que `assets/diagram.svg` contiene una referencia relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

El siguiente ejemplo en C# pasa la URI del archivo SVG como URI base y proporciona un resolvedor personalizado. El resolvedor convierte el enlace de imagen relativo en una URI absoluta y devuelve un flujo que contiene el recurso enlazado mientras Aspose.Slides procesa el SVG.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// La URI base representa la ubicación del documento SVG.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage exposes the source content, binary data, base URI, and resolver.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

La clase `SvgImage` también proporciona sobrecargas que aceptan datos SVG como matriz de bytes o flujo, junto con un resolvedor de recursos externos y una URI base.

{{% alert title="Importante" color="warning" %}}

El resolvedor de recursos hace que los recursos externos estén disponibles mientras Aspose.Slides procesa y renderiza el SVG. No modifica el marcado SVG original ni incrusta automáticamente los recursos resueltos en él.

Cuando se agrega un `ISvgImage` a la colección de imágenes de la presentación, el archivo PPTX puede contener tanto la representación SVG original como una imagen raster de respaldo. Un recurso enlazado puede aparecer en la imagen de respaldo generada mientras que un enlace relativo como `images/photo.png` permanece sin cambios en el SVG almacenado. Una aplicación que renderice la representación SVG nativa puede, por lo tanto, omitir el contenido enlazado cuando el recurso externo original no está disponible.

{{% /alert %}}

### **Crear una imagen SVG portátil**

Para crear una imagen SVG que no dependa de archivos externos, haz que el SVG sea autónomo antes de crear el `SvgImage`. Por ejemplo, sustituye las URL de imágenes enlazadas por URI `data:` que contengan los datos de la imagen:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Después de incrustar todos los recursos necesarios en el contenido SVG, crea el `SvgImage`, agrégalo a la colección de imágenes de la presentación e insértalo en un marco de foto como se mostró en el ejemplo anterior.

### **Gestionar recursos ausentes o bloqueados**

Devuelve `null` desde `ResolveUri` cuando una URI de recurso sea inválida, prohibida o no pueda resolverse. Devuelve `null` desde `GetEntity` cuando el recurso no pueda leerse. Aspose.Slides continúa procesando el SVG sin ese recurso cuando es posible.

Se puede devolver un flujo de respaldo para un recurso que falta, pero su contenido debe ser compatible con el tipo de recurso solicitado. Por ejemplo, devuelve un flujo de imagen solo para una imagen ausente, no para una fuente o una hoja de estilo.

{{% alert title="Seguridad" color="warning" %}}

No resuelvas rutas de archivo arbitrarias ni URL de red sin restricciones a partir de archivos SVG no confiables. Restringe los esquemas, directorios y hosts permitidos. Para recursos de red, también aplica tiempos de espera de conexión, límites de tamaño de respuesta y validación de contenido.

{{% /alert %}}

## **Convertir SVG a un conjunto de formas**
Aspose.Slides puede convertir un SVG en un conjunto de formas, similar a la funcionalidad correspondiente en PowerPoint:

![Menú emergente de PowerPoint](img_01_01.png)

Esta funcionalidad la proporciona una sobrecarga del método [AddGroupShape](https://reference.aspose.com/slides/es/net/aspose.slides.ishapecollection/addgroupshape/methods/1) de la interfaz [IShapeCollection](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection) que acepta un objeto [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage) como primer argumento.

El siguiente código de ejemplo en C# muestra cómo usar este método para convertir un archivo SVG en un conjunto de formas:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Nombre de archivo SVG de origen
string svgFileName = "sample.svg";

// Nombre del archivo de presentación de salida
string outPptxPath = "presentation.pptx";

// Crear una nueva presentación
using (IPresentation presentation = new Presentation())
{
    // Leer el contenido del archivo SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Crear un objeto SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Obtener el tamaño de la diapositiva
    SizeF slideSize = presentation.SlideSize.Size;

    // Convertir la imagen SVG a un grupo de formas y escalarla al tamaño de la diapositiva
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Guardar la presentación en formato PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Agregar imágenes como EMF a diapositivas**
Aspose.Slides for .NET permite generar imágenes EMF a partir de hojas de cálculo de Excel con Aspose.Cells y agregarlas a diapositivas de la presentación.

El siguiente código de ejemplo en C# muestra cómo hacerlo:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // Guardar el libro de trabajo en un flujo
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas las imágenes utilizadas por formas de diapositiva. Esta sección describe varias formas de actualizar imágenes en la colección. Puedes reemplazar una imagen usando datos de bytes sin procesar, una instancia de [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) o otra imagen que ya exista en la colección.

Sigue los pasos a continuación:

1. Carga el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/).
1. Carga una nueva imagen desde un archivo en una matriz de bytes.
1. Reemplaza la imagen objetivo con la nueva imagen usando la matriz de bytes.
1. En el segundo enfoque, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Guarda la presentación modificada como un archivo PPTX.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciar la clase Presentation que representa un archivo de presentación.
using Presentation presentation = new Presentation("sample.pptx");

// La primera forma.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// La segunda forma.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// La tercera forma.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Guardar la presentación en un archivo.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Información" color="info" %}}

Con el conversor gratuito de Aspose [Texto a GIF](https://products.aspose.app/slides/es/text-to-gif), puedes animar texto fácilmente y crear GIFs a partir de texto. 

{{% /alert %}}

## **FAQ**

**¿Se conserva la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [foto](/slides/es/net/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en decenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una distribución y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, tras lo cual cada parte individual se vuelve editable con las propiedades estándar de forma.

**¿Cómo puedo establecer una foto como fondo de varias diapositivas a la vez?**

[Asigna la imagen como fondo](/slides/es/net/presentation-background/) en la diapositiva maestra o en la distribución correspondiente; todas las diapositivas que usen esa maestra/distribución heredarán el fondo.

**¿Cómo evito que una presentación se vuelva demasiado grande debido a muchas imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.