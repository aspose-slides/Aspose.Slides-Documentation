---
title: Administrar marcos de imagen en presentaciones en .NET
linktitle: Marco de Imagen
type: docs
weight: 10
url: /es/net/picture-frame/
keywords:
- marco de imagen
- añadir marco de imagen
- crear marco de imagen
- imagen incrustada
- imagen enlazada
- extraer imagen
- imagen raster
- imagen SVG
- recortar imagen
- eliminar áreas recortadas
- comprimir imagen
- StretchOffset
- formato de marco de imagen
- escala relativa
- efecto de imagen
- relación de aspecto
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Crear, dar formato, enlazar, recortar, extraer y comprimir marcos de imagen en presentaciones con Aspose.Slides para .NET."
---
## **Visión general**

Un marco de imagen es una forma deslizante que muestra una imagen. En Aspose.Slides, el recurso de imagen y la forma que la muestra son objetos separados: una [Presentation](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/) posee recursos de imagen incrustados a través de su colección [Images](https://reference.aspose.com/slides/es/net/aspose.slides/presentation/images/), mientras que un [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) controla la posición, el tamaño, el formato de línea, la rotación, el recorte, los efectos de imagen y otras configuraciones a nivel de marco.

Esta separación es útil cuando la misma imagen se muestra más de una vez. Añada la imagen a la presentación una sola vez, conserve el [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) devuelto y utilice ese recurso de imagen al crear marcos de imagen.

Los marcos de imagen pueden contener imágenes raster como PNG o JPEG y imágenes vectoriales SVG. También pueden referirse a imágenes enlazadas en lugar de almacenar los bytes de la imagen en la presentación. La elección afecta la portabilidad, el tamaño del archivo, la extracción y el comportamiento de exportación, por lo que es útil decidir cómo debe almacenarse la imagen antes de aplicar formato u optimización.

## **Agregar y dar formato a una imagen incrustada**

Para una imagen incrustada, añada los datos de la imagen a la presentación y cree un marco de imagen con [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addpictureframe/). La imagen pasa a formar parte del paquete de la presentación, de modo que la presentación permanece autocontenida cuando se traslada a otro equipo.

El siguiente ejemplo añade una imagen JPEG, crea un marco con las dimensiones nativas de la imagen y aplica formato de línea y rotación:

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
pictureFrame.LineFormat.Width = 3;
pictureFrame.Rotation = 15;

presentation.Save("picture-frame.pptx", SaveFormat.Pptx);
```

El marco de imagen controla la geometría mostrada; cambiar el tamaño del marco no modifica las dimensiones de píxel originales almacenadas en el recurso de imagen incrustado. Esta distinción se vuelve importante al recortar o comprimir una imagen más adelante.

## **Usar escala relativa**

[IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) expone el escalado relativo de ancho y alto para el marco. Un valor de `1.0` corresponde al 100 % del tamaño original de la imagen. La escala relativa es útil cuando un flujo de trabajo necesita mantener una relación con el tamaño de la imagen fuente en lugar de calcular manualmente las dimensiones finales.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, image);
pictureFrame.RelativeScaleWidth = 1.35f;
pictureFrame.RelativeScaleHeight = 0.8f;

presentation.Save("relative-scale.pptx", SaveFormat.Pptx);
```

La escala relativa cambia la configuración de escala del marco; no vuelve a muestrear ni comprime la imagen incrustada.

## **Imágenes incrustadas y enlazadas**

Una imagen incrustada almacena los datos de la imagen dentro de la presentación y, por tanto, es la opción más segura para la portabilidad y la representación predecible. Una imagen enlazada almacena una ubicación externa mediante la ruta de enlace [ISlidesPicture](https://reference.aspose.com/slides/es/net/aspose.slides/islidespicture/) en lugar de incrustar los datos de la imagen de la misma manera.

Las imágenes enlazadas pueden reducir la cantidad de datos de imagen almacenados en el PPTX, pero introducen una dependencia externa. El archivo enlazado debe seguir siendo accesible para la aplicación que abre o renderiza la presentación. Si la ruta cambia, el archivo se mueve o el recurso no está disponible, la imagen enlazada puede no mostrarse como se espera. Para presentaciones que deben enviarse por correo electrónico, archivarse o renderizarse en entornos aislados, las imágenes incrustadas suelen ser más fiables.

### **Añadir una imagen enlazada**

El siguiente ejemplo crea un marco de imagen y lo apunta a un archivo de imagen local. Solo trata el enlace de imágenes; el enlace de vídeo es un flujo de trabajo multimedia separado y se ha omitido intencionalmente en este ejemplo.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = Path.GetFullPath("linked-image.jpg");

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Utilice enlaces cuando la gestión de archivos externos sea intencional. No los use simplemente como sustituto de la compresión: un PPTX pequeño con dependencias de imágenes rotas suele ser menos útil que una presentación más grande y autocontenida.

## **Extraer imágenes de marcos de imagen**

Antes de extraer una imagen de una presentación existente, compruebe que una forma es realmente un [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) y que contiene una imagen incrustada. Los marcos de imagen enlazados pueden no contener bytes de imagen que puedan extraerse de la misma manera.

### **Extraer una imagen raster**

La API de imágenes moderna utiliza [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) directamente y no requiere el contenedor de imagen del sistema anterior. El siguiente ejemplo encuentra la primera imagen raster incrustada en una diapositiva y la guarda como PNG:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    if (embeddedImage == null || embeddedImage.SvgImage != null)
    {
        continue;
    }

    using var rasterImage = embeddedImage.Image;
    rasterImage.Save("extracted-image.png", Aspose.Slides.ImageFormat.Png);
    break;
}
```

Guardar mediante [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) convierte la imagen extraída al formato de salida solicitado. Si necesita los bytes codificados almacenados en la presentación en lugar de un archivo raster convertido, use los datos binarios del recurso de imagen.

### **Extraer una imagen SVG**

Para una imagen SVG, el [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) expone un objeto [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/). Esto le permite recuperar los datos SVG directamente en lugar de rasterizar la imagen primero.

```csharp
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is not IPictureFrame pictureFrame)
    {
        continue;
    }

    var embeddedImage = pictureFrame.PictureFormat.Picture.Image;
    var svgImage = embeddedImage?.SvgImage;
    if (svgImage == null)
    {
        continue;
    }

    File.WriteAllBytes("extracted-image.svg", svgImage.SvgData);
    break;
}
```

Mantener el contenido SVG como SVG preserva la fuente vectorial dentro de la presentación. Las exportaciones raster como PNG o JPEG necesariamente convierten ese contenido vectorial a píxeles. La exportación de diapositivas a PDF o SVG también es una operación de renderizado, por lo que los gráficos exportados no deben considerarse una copia byte a byte del SVG incrustado original; use los datos del [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/) incrustado cuando se requiera el recurso vectorial original.

## **Recortar una imagen**

Recortar cambia qué parte de una imagen es visible dentro del marco. Los valores de recorte en [IPictureFillFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ipicturefillformat/) son porcentajes de las dimensiones de la imagen fuente. El recorte no elimina inicialmente los píxeles ocultos de la imagen incrustada; solo cambia la región visible.

El siguiente ejemplo encuentra un marco de imagen de forma segura y aplica valores de recorte:

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    pictureFrame.PictureFormat.CropLeft = 23.6f;
    pictureFrame.PictureFormat.CropRight = 21.5f;
    pictureFrame.PictureFormat.CropTop = 3f;
    pictureFrame.PictureFormat.CropBottom = 31f;
    presentation.Save("cropped-image.pptx", SaveFormat.Pptx);
}
```

Como los datos de la imagen oculta siguen presentes, el recorte puede modificarse más adelante sin perder los píxeles originales. Si el tamaño del archivo es más importante que la reversibilidad, las regiones recortadas pueden eliminarse físicamente como se describe en la sección siguiente.

## **Eliminar datos de imagen recortados**

[IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/es/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) elimina los datos de imagen fuera del rectángulo de recorte actual y devuelve el recurso de imagen resultante. Esto puede reducir el tamaño del archivo, pero es una optimización destructiva: después de guardar la presentación, los píxeles eliminados ya no están disponibles para una operación de desrecorte posterior.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("cropped-image.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var croppedImage = pictureFrame.PictureFormat.DeletePictureCroppedAreas();
    if (croppedImage != null)
    {
        presentation.Save("cropped-data-removed.pptx", SaveFormat.Pptx);
    }
}
```

El método puede añadir un nuevo recurso de imagen a la presentación. Si la imagen original también se utiliza en otros marcos de imagen, esos marcos siguen necesitando su recurso existente, por lo que eliminar áreas recortadas no reduce necesariamente el número total de imágenes. Recortar contenido WMF o EMF con este método rasteriza el resultado recortado a PNG.

## **Comprimir imágenes raster**

[IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/es/net/aspose.slides/ipicturefillformat/compressimage/) reduce la resolución de la imagen raster en relación con el tamaño en el que se muestra la imagen. También puede eliminar áreas recortadas en la misma operación. El método devuelve `true` cuando la imagen se ha redimensionado o recortado y `false` cuando no fue necesario ningún cambio.

Utilice un valor predefinido de [PicturesCompression](https://reference.aspose.com/slides/es/net/aspose.slides.export/picturescompression/) cuando una resolución objetivo estándar sea suficiente:

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var compressed = pictureFrame.PictureFormat.CompressImage(true, PicturesCompression.Dpi150);
    Console.WriteLine(compressed ? "The image was compressed." : "No compression was necessary.");
    presentation.Save("compressed-image.pptx", SaveFormat.Pptx);
}
```

Se puede pasar un valor DPI positivo personalizado en lugar de un valor de enumeración cuando se requiere un objetivo específico.

La compresión está pensada para imágenes raster. El contenido SVG y de metarchivo no se reduce con este flujo de compresión raster. También recuerde que la resolución inferior y las regiones recortadas eliminadas no pueden recuperarse de la presentación optimizada. Elija una resolución objetivo según el mayor tamaño al que la imagen será visualizada o exportada, en lugar de aplicar el DPI más bajo de forma global.

## **Gestionar efectos de transformación de imagen**

Para un flujo de trabajo completo que cubra brillo, contraste, transformaciones de color, desenfoque, efectos alfa, cadenas ordenadas, inspección, eliminación y verificación de ida y vuelta, consulte [Image Transform Effects](/slides/es/net/image-transform-effects/).

## **Bloquear la geometría del marco de imagen**

La configuración [IPictureFrameLock](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframelock/) controla qué operaciones de edición están deshabilitadas para un marco de imagen. Por ejemplo, el bloqueo de relación de aspecto conserva las proporciones de la forma mientras se redimensiona.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.jpg");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 100, image.Width, image.Height, image);
pictureFrame.PictureFrameLock.AspectRatioLocked = true;

presentation.Save("locked-picture-frame.pptx", SaveFormat.Pptx);
```

El bloqueo se aplica a la forma del marco de imagen. No obliga a que la imagen fuente sea muestreada nuevamente o cambiada permanentemente a la misma relación de aspecto.

## **Ajustar los valores StretchOffset**

Cuando el modo de relleno de imagen es estirado, los valores stretch‑offset en [IPictureFillFormat](https://reference.aspose.com/slides/es/net/aspose.slides/ipicturefillformat/) definen el rectángulo de relleno relativo al cuadro delimitador del marco de imagen. Los porcentajes positivos crean una inserción desde un borde, mientras que los porcentajes negativos crean una sobresaliente.

Esto es diferente del recorte. Los valores de recorte seleccionan qué parte de la imagen fuente es visible; los offsets de estiramiento cambian el rectángulo en el que se estira el relleno de imagen visible.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 400, 300, image);
pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Stretch;
pictureFrame.PictureFormat.StretchOffsetLeft = 12f;
pictureFrame.PictureFormat.StretchOffsetRight = 12f;
pictureFrame.PictureFormat.StretchOffsetTop = 8f;
pictureFrame.PictureFormat.StretchOffsetBottom = 8f;

presentation.Save("stretch-offsets.pptx", SaveFormat.Pptx);
```

Use offsets de estiramiento para la colocación del relleno. Use las propiedades de recorte cuando el objetivo sea ocultar los bordes de la imagen fuente.

## **Almacenamiento, tamaño del archivo y consideraciones de exportación**

Los principales compromisos son más fáciles de gestionar cuando el almacenamiento de imágenes y el formato del marco de imagen se tratan por separado:

- **Imágenes incrustadas** hacen que la presentación sea autocontenida y son la opción más fiable para compartir y renderizar en servidor, pero las imágenes raster grandes aumentan el tamaño del PPTX y el uso de memoria.
- **Imágenes enlazadas** pueden mantener el paquete más pequeño, pero la presentación depende de que los archivos externos permanezcan disponibles en las rutas o ubicaciones almacenadas.
- **Recorte** es inicialmente no destructivo. Los píxeles ocultos permanecen incrustados hasta que las áreas recortadas se eliminen explícitamente o se eliminen durante la compresión.
- **Compresión** puede reducir considerablemente el tamaño del archivo para imágenes raster sobredimensionadas, pero sacrifica la resolución original. Debe aplicarse después de conocer el tamaño final en la diapositiva.
- **Imágenes SVG** deben permanecer como SVG cuando la preservación vectorial es importante. Extraiga el SVG incrustado directamente cuando necesite el recurso vectorial en sí. Las exportaciones de diapositivas raster siempre convierten la diapositiva renderizada a píxeles.
- **Imágenes repetidas** deben reutilizar un recurso [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) existente cuando sea posible en lugar de cargar repetidamente el mismo archivo en el flujo de trabajo de la presentación.

Para presentaciones grandes, la optimización de imágenes suele ser más eficaz cuando se realiza de forma selectiva: mantenga logotipos y diagramas como contenido vectorial, comprima fotografías según su tamaño de visualización real, elimine los píxeles recortados solo cuando no se requiera una edición posterior y evite enlaces externos salvo que la gestión de dependencias forme parte del diseño de despliegue.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre un marco de imagen y un recurso de imagen?**

Un [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) representa un recurso de imagen asociado a la presentación. Un [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) es una forma en una diapositiva que muestra una imagen y almacena la geometría y el formato a nivel de marco, como tamaño, rotación, valores de recorte, efectos y bloqueos.

**¿Debo incrustar o enlazar imágenes?**

Incruste imágenes cuando la presentación deba ser portátil, archivada o renderizada sin acceso a recursos externos. Enlace imágenes solo cuando mantener los archivos de imagen fuera del PPTX sea intencional y las ubicaciones externas puedan mantenerse de forma fiable.

**¿El recorte reduce el tamaño del archivo PPTX?**

No por sí mismo. La configuración de recorte normal oculta partes de la imagen fuente pero conserva los píxeles subyacentes. Use [IPictureFillFormat.DeletePictureCroppedAreas](https://reference.aspose.com/slides/es/net/aspose.slides/ipicturefillformat/deletepicturecroppedareas/) o compresión de imágenes con eliminación de áreas recortadas cuando esos píxeles puedan descartarse permanentemente.

**¿Puedo restaurar la calidad de la imagen después de la compresión?**

No. La compresión puede reducir la resolución raster almacenada, y la eliminación de regiones recortadas descarta datos de imagen. Mantenga la imagen fuente original fuera de la presentación si más adelante se necesita edición en alta resolución.

**¿Cómo deben manejarse las imágenes SVG?**

Mantenga el contenido SVG como SVG cuando la fidelidad vectorial sea importante. El [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/) incrustado puede extraerse directamente. Renderizar una diapositiva a un formato raster como PNG o JPEG rasteriza el SVG como parte de la imagen de la diapositiva.

**¿Cómo puedo evitar conversiones inseguras al leer diapositivas existentes?**

Compruebe el tipo de forma antes de usar miembros específicos de marcos de imagen. El patrón de coincidencia con [IPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) o el filtrado de la colección de formas por esa interfaz evita conversiones inválidas y permite que el código gestione diapositivas que no contengan marcos de imagen.