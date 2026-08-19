---
title: Optimizar la gestión de imágenes en presentaciones en .NET
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/net/image/
keywords:
- añadir imagen
- añadir foto
- reemplazar imagen
- colección de imágenes
- marco de imagen
- imagen vinculada
- fondo
- añadir PNG
- añadir JPG
- añadir SVG
- SVG a formas
- recursos SVG externos
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda a añadir, reutilizar, vincular, reemplazar y gestionar imágenes raster y SVG en presentaciones de PowerPoint y OpenDocument con Aspose.Slides para .NET."
---
## **Introducción**

Aspose.Slides for .NET ofrece varias formas de trabajar con imágenes, y cada una sirve a un propósito distinto. Puede almacenar una imagen en una presentación, mostrarla en un marco de imagen, usarla como fondo de diapositiva, enlazar a una imagen externa, reemplazar un recurso de imagen compartido o convertir contenido SVG en formas editables.

Este artículo se centra en los recursos de imagen y cómo se utilizan en una presentación. Para recorte, transparencia, efectos, estirado y otros formatos aplicados a un marco de imagen individual, consulte [Marco de imagen](/slides/es/net/picture-frame/).

## **Comprender el modelo de imagen**

Los siguientes conceptos de API están estrechamente relacionados pero no son intercambiables:

- La [colección de imágenes de la presentación](https://reference.aspose.com/slides/es/net/aspose.slides/iimagecollection/) almacena los recursos de imagen utilizados por la presentación. Utilice [ImageCollection.AddImage](https://reference.aspose.com/slides/es/net/aspose.slides/imagecollection/addimage/) para agregar datos de imagen y obtener un recurso [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/).
- Un [marco de imagen](https://reference.aspose.com/slides/es/net/aspose.slides/ipictureframe/) es una forma que muestra una imagen en una diapositiva, diseño o maestro. Utilice [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addpictureframe/) para colocar un recurso de imagen en una diapositiva.
- Un fondo de diapositiva utiliza una imagen como parte del relleno de la diapositiva en lugar de como una forma. Por lo tanto, no se comporta como un marco de imagen.
- [IPPImage.ReplaceImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/replaceimage/) reemplaza un recurso de imagen. Si varios elementos de la presentación usan ese recurso, todos utilizan el reemplazo.
- Convertir un SVG a formas crea formas editables en la diapositiva. Después de la conversión, el contenido ya no se gestiona como un único recurso de imagen.

Un flujo de trabajo típico es, por tanto: añadir datos de imagen a la colección de imágenes, recibir un [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/), y luego usar ese recurso en uno o varios marcos de imagen o rellenos.

## **Agregar una imagen incrustada**

Para insertar una imagen local, lea el archivo, agregue sus datos a la colección de imágenes y cree un marco de imagen que utilice el `IPPImage` devuelto.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

La imagen añadida de esta manera se incrusta en la presentación, de modo que el archivo resultante no depende de que el archivo de imagen original siga estando disponible.

### **Agregar una imagen desde la web**

Cuando una imagen está disponible a través de HTTP o HTTPS, descargue sus bytes con `HttpClient`, agréguelos a la colección de imágenes de la presentación y use el recurso de imagen devuelto del mismo modo que con una imagen local.

```csharp
using System;
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

var imageUri = new Uri("https://example.com/image.png");
using var httpClient = new HttpClient();
var imageData = await httpClient.GetByteArrayAsync(imageUri);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(imageData);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, image);

presentation.Save("presentation-from-web.pptx", SaveFormat.Pptx);
```

En aplicaciones de larga duración, reutilice `HttpClient` en lugar de crear una nueva instancia para cada solicitud. También valide las URL remotas, los tamaños de respuesta y los tipos de contenido cuando la fuente no sea de confianza.

## **Reutilizar imágenes en distintas diapositivas**

Si la misma imagen se necesita más de una vez, añádala a la presentación una sola vez y reutilice el [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/) devuelto al crear marcos de imagen adicionales. Esto evita cargar repetidamente los mismos datos de origen y hace explícita la relación entre el recurso de imagen compartido y sus usos.

Para gráficos que deben aparecer automáticamente en muchas diapositivas, como el logotipo de la empresa, considere colocar el marco de imagen en un [maestro de diapositivas](/slides/es/net/slide-master/) o diseño en lugar de añadir una forma equivalente a cada diapositiva.

## **Usar una imagen como fondo de diapositiva**

Una imagen de fondo se asigna al relleno de la diapositiva; no se añade como una forma de marco de imagen. Esto es útil cuando la imagen debe cubrir todo el fondo y no debe manipularse como un objeto de diapositiva normal.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("background.jpg");
var image = presentation.Images.AddImage(imageData);
slide.Background.Type = BackgroundType.OwnBackground;
slide.Background.FillFormat.FillType = FillType.Picture;
slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
slide.Background.FillFormat.PictureFillFormat.Picture.Image = image;

presentation.Save("background-image.pptx", SaveFormat.Pptx);
```

Para opciones adicionales de fondo, incluidos fondos de maestros y diseños, vea [Fondo de presentación](/slides/es/net/presentation-background/).

## **Imágenes incrustadas e imágenes vinculadas**

Las imágenes incrustadas y las vinculadas tienen diferentes compensaciones de portabilidad y tamaño de archivo:

- **Imagen incrustada:** los datos de la imagen se almacenan dentro de la presentación. La presentación es autónoma, pero el tamaño del archivo incluye los datos de la imagen.
- **Imagen vinculada:** la presentación almacena una ruta o URL a una imagen externa. Esto puede reducir el tamaño de la presentación, pero el recurso externo debe seguir siendo accesible cuando se abra o renderice la presentación.

Una imagen vinculada puede crearse asignando la ruta o URL externa mediante [ISlidesPicture.LinkPathLong](https://reference.aspose.com/slides/es/net/aspose.slides/islidespicture/linkpathlong/) en lugar de incrustar los datos de la imagen.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 320, 180, null);
pictureFrame.PictureFormat.Picture.LinkPathLong = "https://example.com/image.png";

presentation.Save("linked-image.pptx", SaveFormat.Pptx);
```

Utilice imágenes vinculadas solo cuando el entorno de despliegue pueda acceder de forma fiable al recurso externo. Para presentaciones que deben funcionar sin conexión o trasladarse entre sistemas, las imágenes incrustadas suelen ser más seguras.

## **Trabajar con imágenes SVG**

SVG es un formato vectorial, por lo que puede ser útil para iconos, diagramas y otros gráficos que deben escalarse sin la misma pérdida de detalle que las imágenes raster. Aspose.Slides admite SVG tanto como recurso de imagen como como fuente de formas editables en la diapositiva.

### **Agregar un SVG como imagen**

Cree un [SvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/svgimage/), agréguelo a la colección de imágenes y coloque el recurso de imagen resultante en un marco de imagen.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("icon.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var image = presentation.Images.AddImage(svgImage);
var slide = presentation.Slides[0];
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 200, image);

presentation.Save("svg-image.pptx", SaveFormat.Pptx);
```

### **Archivos SVG con recursos externos**

Un SVG puede hacer referencia a imágenes externas, hojas de estilo o fuentes. Para estos casos, [SvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/svgimage/) proporciona constructores que aceptan un [IExternalResourceResolver](https://reference.aspose.com/slides/es/net/aspose.slides.import/iexternalresourceresolver/) y una URI base. El resolvedor puede asignar una URI relativa a una URI absoluta permitida y devolver un flujo para el recurso solicitado.

El resolvedor pone los recursos externos a disposición mientras Aspose.Slides procesa el SVG, pero no reescribe el SVG en un documento autónomo. Si el SVG debe permanecer portable, incruste sus recursos necesarios dentro del propio SVG, por ejemplo usando URIs `data:` para imágenes vinculadas.

Cuando los archivos SVG provienen de fuentes no fiables, restrinja los esquemas, ubicaciones de archivo y hosts a los que el resolvedor pueda acceder. Los resolvedores de red también deben aplicar límites de tiempo, tamaños de respuesta y validación de contenido.

### **Convertir SVG a formas editables**

Aspose.Slides puede convertir un SVG en un grupo de formas editables en la diapositiva, similar al comando correspondiente de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utilice la sobrecarga de [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addgroupshape/) que acepta un [ISvgImage](https://reference.aspose.com/slides/es/net/aspose.slides/isvgimage/) para realizar la conversión.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = File.ReadAllText("diagram.svg");
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var slide = presentation.Slides[0];
slide.Shapes.AddGroupShape(svgImage, 0, 0, slideSize.Width, slideSize.Height);

presentation.Save("editable-svg-shapes.pptx", SaveFormat.Pptx);
```

Use la conversión de SVG a formas cuando los elementos vectoriales individuales necesiten editarse como formas de PowerPoint. Si el SVG solo necesita mostrarse, mantenerlo como imagen es más simple y evita crear muchas formas separadas.

## **Reemplazar un recurso de imagen existente**

Utilice [IPPImage.ReplaceImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/replaceimage/) cuando desee reemplazar un recurso de imagen existente. Esto es particularmente útil para gráficos compartidos como logotipos.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var imageToReplace = presentation.Images[0];
imageToReplace.ReplaceImage(File.ReadAllBytes("new-logo.png"));

presentation.Save("output.pptx", SaveFormat.Pptx);
```

Si varios marcos de imagen, fondos, maestros o diseños usan el mismo recurso de imagen, reemplazar ese recurso actualiza todos esos usos. Si solo debe cambiar un marco de imagen, asigne una imagen diferente a ese marco en vez de reemplazar el recurso compartido.

`ReplaceImage` también proporciona sobrecargas que aceptan un [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) u otro [IPPImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/).

## **Guía práctica de gestión de imágenes**

### **Controlar el tamaño de la presentación**

Las imágenes raster grandes pueden hacer que una presentación sea innecesariamente pesada. Utilice imágenes de origen con dimensiones apropiadas para el tamaño de visualización previsto, reutilice recursos de imagen compartidos cuando sea posible y evite incrustar copias repetidas del mismo gráfico de alta resolución.

Para imágenes raster que ya se han colocado en marcos de imagen, [IPictureFillFormat.CompressImage](https://reference.aspose.com/slides/es/net/aspose.slides/ipicturefillformat/compressimage/) puede reducir los datos de la imagen según la resolución y la configuración de recorte seleccionadas. Esto es un procesamiento de marco de imagen, no de gestión de la colección de imágenes, por lo que consulte [Marco de imagen](/slides/es/net/picture-frame/) para operaciones de formato relacionadas.

### **Elegir entre contenido incrustado y vinculado**

Incrustar hace que la presentación sea portable porque todos los datos de imagen requeridos viajan con el archivo. Vincular puede reducir el tamaño del archivo, pero introduce una dependencia externa. Use enlaces solo cuando esa dependencia sea aceptable y estable.

### **Reutilizar la marca compartida**

Para logotipos, marcas de agua o gráficos decorativos repetidos, utilice un solo recurso de imagen y reutilícelo. Si el gráfico pertenece al diseño de la presentación más que al contenido de las diapositivas, colóquelo en un maestro o diseño para que sea heredado por las diapositivas correspondientes.

### **Mantener los recursos SVG portables**

Un SVG autónomo es más fácil de mover y renderizar de forma coherente que un SVG que depende de archivos externos o recursos de red. Cuando sea posible, incruste los recursos necesarios antes de importar el SVG. Convierta SVG a formas solo cuando los elementos vectoriales individuales necesiten editarse.

### **Utilizar la API de imágenes moderna multiplataforma**

Para nuevo código .NET, utilice las APIs de Aspose.Slides [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/) y [Images](https://reference.aspose.com/slides/es/net/aspose.slides/images/) en lugar de depender de `System.Drawing.Image` o `Bitmap`. Vea [API moderna](/slides/es/net/modern-api/) para orientación sobre la migración.

WMF y EMF requieren consideraciones especiales. Cuando estos formatos se pasan a través de un [IImage](https://reference.aspose.com/slides/es/net/aspose.slides/iimage/), [ImageCollection.AddImage](https://reference.aspose.com/slides/es/net/aspose.slides/imagecollection/addimage/) convierte el metarchivo a una representación PNG raster antes de la inserción. Si es importante preservar los datos del metarchivo, utilice la sobrecarga basada en flujo de [ImageCollection.AddImage](https://reference.aspose.com/slides/es/net/aspose.slides/imagecollection/addimage/). Generar contenido EMF a partir de hojas de cálculo u otros productos es un flujo de integración separado y está fuera del alcance de este artículo.

## **FAQ**

**¿Cuál es la diferencia entre la colección de imágenes y un marco de imagen?**

La colección de imágenes almacena recursos de imagen reutilizables. Un marco de imagen es una forma de diapositiva que muestra uno de esos recursos y proporciona formatos específicos de imagen, como recorte y efectos.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en todas partes?**

Si el logotipo ya se comparte como un único recurso de imagen, reemplácelo con [IPPImage.ReplaceImage](https://reference.aspose.com/slides/es/net/aspose.slides/ippimage/replaceimage/). Para la marca a nivel de presentación, colocar el logotipo en un maestro o diseño también puede reducir el contenido duplicado de las diapositivas.

**¿Por qué una imagen vinculada desaparece en otro ordenador?**

Una imagen vinculada depende de su archivo o URL externo. Si ese recurso no se puede alcanzar desde el otro ordenador, la imagen vinculada puede estar indisponible. Incruste la imagen cuando la presentación deba ser autónoma.

**¿Se puede editar un SVG insertado como formas de PowerPoint?**

Sí. Convierta el SVG con [IShapeCollection.AddGroupShape](https://reference.aspose.com/slides/es/net/aspose.slides/ishapecollection/addgroupshape/); el grupo resultante contiene formas editables en la diapositiva en lugar de una única imagen SVG.

**¿Cómo puedo mantener más pequeñas las presentaciones con muchas imágenes?**

Reutilice recursos de imagen compartidos, evite fuentes raster innecesariamente grandes, comprima las imágenes raster adecuadas cuando corresponda, mantenga la marca repetida en maestros o diseños y use imágenes vinculadas solo cuando una dependencia externa sea aceptable.