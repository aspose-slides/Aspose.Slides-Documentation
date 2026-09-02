---
title: Optimizar la gestión de imágenes en presentaciones usando PHP
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/php-java/image/
keywords:
- agregar imagen
- agregar foto
- agregar mapa de bits
- reemplazar imagen
- reemplazar foto
- desde web
- fondo
- agregar PNG
- agregar JPG
- agregar SVG
- recursos SVG externos
- resolvedor SVG
- imágenes SVG vinculadas
- fuentes SVG
- agregar EMF
- agregar WMF
- agregar TIFF
- PowerPoint
- OpenDocument
- presentación
- EMF
- SVG
- PHP
- Aspose.Slides
description: "Agiliza la gestión de imágenes en PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java, optimizando el rendimiento y automatizando tu flujo de trabajo."
---
## **Introducción**

Las imágenes hacen que las presentaciones sean más atractivas y visualmente agradables. En Microsoft PowerPoint, puedes insertar imágenes en las diapositivas a partir de archivos, internet u otras fuentes. De forma similar, Aspose.Slides permite agregar imágenes a las diapositivas de una presentación de varias maneras.

{{% alert title="Consejo" color="primary" %}} 
Aspose ofrece convertidores gratuitos—[JPEG a PowerPoint](https://products.aspose.app/slides/es/import/jpg-to-ppt) y [PNG a PowerPoint](https://products.aspose.app/slides/es/import/png-to-ppt)—que te permiten crear presentaciones rápidamente a partir de imágenes. 
{{% /alert %}} 

{{% alert title="Información" color="info" %}}
Si deseas agregar una imagen como marco de foto—especialmente si planeas cambiar su tamaño, aplicar efectos o usar otras opciones de formato estándar—consulta [Marco de imagen](/slides/es/php-java/picture-frame/). 
{{% /alert %}} 

{{% alert title="Nota" color="warning" %}}
Puedes convertir imágenes de un formato a otro. Consulta las siguientes páginas: convertir [imagen a JPG](https://products.aspose.com/slides/es/php-java/conversion/image-to-jpg/), [JPG a imagen](https://products.aspose.com/slides/es/php-java/conversion/jpg-to-image/), [JPG a PNG](https://products.aspose.com/slides/es/php-java/conversion/jpg-to-png/), [PNG a JPG](https://products.aspose.com/slides/es/php-java/conversion/png-to-jpg/), [PNG a SVG](https://products.aspose.com/slides/es/php-java/conversion/png-to-svg/), y [SVG a PNG](https://products.aspose.com/slides/es/php-java/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides admite imágenes en formatos populares como JPEG, PNG, BMP, GIF y otros. 

## **Agregar imágenes almacenadas localmente a diapositivas**

Puedes agregar una o más imágenes almacenadas en tu ordenador a una diapositiva de la presentación. El siguiente código de muestra en PHP muestra cómo agregar una imagen a una diapositiva:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Agregar imágenes desde la web a diapositivas**

Si la imagen que deseas agregar a una diapositiva no está almacenada en tu ordenador, puedes añadirla directamente desde la web. 

El siguiente código de muestra en PHP muestra cómo agregar una imagen desde la web a una diapositiva:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);

    $imageUrl = new Java("java.net.URL", "[REPLACE WITH URL]");
    $connection = $imageUrl->openConnection();
    $inputStream = $connection->getInputStream();

    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 1024);

        while (($read = java_values($inputStream->read($buffer, 0, $Array->getLength($buffer)))) != -1) {
            $outputStream->write($buffer, 0, $read);
        }

        $outputStream->flush();

        $image = $pres->getImages()->addImage($outputStream->toByteArray());
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $image);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $pres->save("pres.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Agregar imágenes a los maestros de diapositivas**

Un maestro de diapositivas almacena y controla información como el tema y la distribución de las diapositivas que lo utilizan. Cuando agregas una imagen a un maestro de diapositivas, la imagen aparece en todas las diapositivas basadas en ese maestro. 

El siguiente código de muestra en PHP muestra cómo agregar una imagen a un maestro de diapositivas:

```php
$pres = new Presentation();
try {
    $slide = $pres->getSlides()->get_Item(0);
    $masterSlide = $slide->getLayoutSlide()->getMasterSlide();

    $picture = null;
    $image = Images::fromFile("image.png");
    try {
        $picture = $pres->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $masterSlide->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);

    $pres->save("pres.pptx", SaveFormat::Pptx);
} finally {
    $pres->dispose();
}
```

## **Agregar imágenes como fondos de diapositivas**

Puedes usar una imagen como fondo de una o varias diapositivas. Para más detalles, consulta *[Establecer imágenes como fondos de diapositivas](/slides/es/php-java/presentation-background/#setting-images-as-background-for-slides)*.

## **Agregar SVG a presentaciones**

El contenido SVG puede agregarse a una presentación mediante la clase [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/). El objeto de imagen SVG resultante puede luego añadirse a la colección de imágenes de la presentación y usarse para crear un marco de foto.

El siguiente ejemplo en PHP importa una cadena SVG autónoma. Todas las imágenes, estilos y demás recursos utilizados por este SVG están incrustados directamente en el contenido SVG.

```php
$svgContent =
    "<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>" .
    "    <rect width='320' height='180' fill='#4F81BD'/>" .
    "    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>" .
    "</svg>";

$presentation = new Presentation();
try {
    $svgImage = new SvgImage($svgContent);
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("self-contained-svg.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Importar contenido SVG con recursos externos**

Los archivos SVG exportados desde herramientas de diseño, editores de diagramas, sistemas de iconos y canalizaciones web pueden referenciar recursos que se almacenan fuera del documento SVG. Por ejemplo, un SVG puede contener un enlace a una imagen como `images/photo.png`, un valor CSS `url(...)` o una URL de fuente.

Para importar dicho contenido SVG, crea una implementación de [ExternalResourceResolver](https://reference.aspose.com/slides/es/php-java/aspose.slides/externalresourceresolver/) y pásala, junto con una URI base, al constructor apropiado de [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/). La URI base identifica la ubicación del documento SVG y se usa para resolver enlaces relativos.

El objeto de imagen SVG proporciona acceso a información sobre el SVG importado:

- `getSvgContent()` devuelve el marcado SVG como una cadena.
- `getSvgData()` devuelve el contenido SVG como un arreglo de bytes.
- `getBaseUri()` devuelve la URI base utilizada para enlaces relativos.
- `getExternalResourceResolver()` devuelve el resolvedor asignado a la imagen SVG.

### **Implementar un resolvedor de recursos externos**

El resolvedor tiene dos métodos:

- `resolveUri` combina la URI base y un enlace de recurso relativo y devuelve una URI absoluta. Devuelve `null` cuando el enlace no puede resolverse o no está permitido.
- `getEntity` devuelve un flujo legible para una URI de recurso absoluta. Devuelve `null` cuando el recurso falta, está bloqueado o no está disponible. También se puede devolver un flujo de reserva cuando sea apropiado.

El siguiente resolvedor carga recursos vinculados solo desde un directorio local permitido. Los recursos de red y rutas fuera del directorio permitido están bloqueados. Se devuelve una imagen de reserva opcional para enlaces de imagen no resueltos.

```php
class LocalSvgResourceResolver extends ExternalResourceResolver
{
    private $allowedRoot;
    private $fallbackImageData;

    public function __construct($allowedRoot, $fallbackImageData)
    {
        parent::__construct();

        $Paths = new JavaClass("java.nio.file.Paths");
        $this->allowedRoot = $Paths->get($allowedRoot)->toAbsolutePath()->normalize();
        $this->fallbackImageData = $fallbackImageData;
    }

    public function resolveUri($baseUri, $relativeUri)
    {
        if ($baseUri === null || trim(java_values($baseUri)) === "" ||
            $relativeUri === null || trim(java_values($relativeUri)) === "") {
            return null;
        }

        try {
            $URI = new JavaClass("java.net.URI");
            $baseAddress = $URI->create($baseUri);
            $absoluteAddress = $baseAddress->resolve($relativeUri);

            // Este resolvedor permite intencionalmente solo archivos locales.
            if (strcasecmp(java_values($absoluteAddress->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($absoluteAddress)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            return $resourcePath->toUri()->toString();
        } catch (JavaException $e) {
            return null;
        }
    }

    public function getEntity($absoluteUri)
    {
        try {
            $URI = new JavaClass("java.net.URI");
            $resourceUri = $URI->create($absoluteUri);

            if (strcasecmp(java_values($resourceUri->getScheme()), "file") !== 0) {
                return null;
            }

            $Paths = new JavaClass("java.nio.file.Paths");
            $resourcePath = $Paths->get($resourceUri)->toAbsolutePath()->normalize();

            if (!$this->isInsideAllowedRoot($resourcePath)) {
                return null;
            }

            $Files = new JavaClass("java.nio.file.Files");
            if (java_values($Files->exists($resourcePath))) {
                return $Files->newInputStream($resourcePath);
            }

            // Utiliza una reserva solo para recursos de imagen. Devolver un flujo de imagen
            // para una fuente o hoja de estilo faltante no sería válido.
            if ($this->fallbackImageData !== null && $this->isImageFile($resourcePath)) {
                return new Java("java.io.ByteArrayInputStream", $this->fallbackImageData);
            }
        } catch (JavaException $e) {
            return null;
        }

        return null;
    }

    private function isInsideAllowedRoot($resourcePath)
    {
        return java_values($resourcePath->normalize()->startsWith($this->allowedRoot));
    }

    private function isImageFile($path)
    {
        $fileName = strtolower(java_values($path->getFileName()->toString()));

        return str_ends_with($fileName, ".png") ||
            str_ends_with($fileName, ".jpg") ||
            str_ends_with($fileName, ".jpeg") ||
            str_ends_with($fileName, ".gif") ||
            str_ends_with($fileName, ".bmp");
    }
}
```

### **Resolver recursos vinculados durante la importación de SVG**

Supongamos que `assets/diagram.svg` contiene una referencia relativa como:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

El siguiente ejemplo en PHP pasa la URI del archivo SVG como URI base y proporciona un resolvedor personalizado. El resolvedor convierte el enlace de imagen relativo en una URI absoluta y devuelve un flujo que contiene el recurso vinculado mientras Aspose.Slides procesa el SVG.

```php
$Paths = new JavaClass("java.nio.file.Paths");
$Files = new JavaClass("java.nio.file.Files");
$StandardCharsets = new JavaClass("java.nio.charset.StandardCharsets");

$svgFilePath = $Paths->get("assets", "diagram.svg")->toAbsolutePath()->normalize();
$assetDirectory = $svgFilePath->getParent();

$svgData = $Files->readAllBytes($svgFilePath);
$svgContent = new Java("java.lang.String", $svgData, $StandardCharsets->UTF_8);

// La URI base representa la ubicación del documento SVG.
$baseUri = $svgFilePath->toUri()->toString();

$fallbackImageData = null;
$fallbackImagePath = $assetDirectory->resolve("fallback.png");
if (java_values($Files->exists($fallbackImagePath))) {
    $fallbackImageData = $Files->readAllBytes($fallbackImagePath);
}

$resolver = new LocalSvgResourceResolver(java_values($assetDirectory->toString()), $fallbackImageData);
$svgImage = new SvgImage($svgContent, $resolver, $baseUri);

// El objeto de imagen SVG expone el contenido fuente, los datos binarios, la URI base y el resolvedor.
$importedContent = $svgImage->getSvgContent();
$importedData = $svgImage->getSvgData();
$importedBaseUri = $svgImage->getBaseUri();
$importedResolver = $svgImage->getExternalResourceResolver();

$presentation = new Presentation();
try {
    $image = $presentation->getImages()->addImage($svgImage);

    $presentation->getSlides()->get_Item(0)->getShapes()->addPictureFrame(
        ShapeType::Rectangle,
        20,
        20,
        $image->getWidth(),
        $image->getHeight(),
        $image
    );

    $presentation->save("svg-with-linked-resources.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La clase `SvgImage` también ofrece sobrecargas que aceptan datos SVG como un arreglo de bytes o un flujo de entrada, junto con un resolvedor de recursos externos y una URI base.

{{% alert title="Importante" color="warning" %}}
El resolvedor de recursos pone a disposición los recursos externos mientras Aspose.Slides procesa y renderiza el SVG. No modifica el marcado SVG original ni incrusta automáticamente los recursos resueltos en él.

Cuando una imagen SVG se agrega a la colección de imágenes de la presentación, el archivo PPTX puede contener tanto la representación SVG original como una imagen raster de reserva. Un recurso vinculado puede aparecer en la imagen de reserva generada mientras que un enlace relativo como `images/photo.png` permanece sin cambios en el SVG almacenado. Una aplicación que renderice la representación SVG nativa puede, por lo tanto, omitir el contenido vinculado cuando el recurso externo original no está disponible.
{{% /alert %}}

### **Crear una imagen SVG portátil**

Para crear una imagen SVG que no dependa de archivos externos, haz que el SVG sea autónomo antes de crear el `SvgImage`. Por ejemplo, reemplaza las URL de imágenes vinculadas con URIs `data:` que contengan los datos de la imagen:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

Después de que todos los recursos necesarios estén incrustados en el contenido SVG, crea el `SvgImage`, añádelo a la colección de imágenes de la presentación e insértalo en un marco de foto como se mostró en el ejemplo anterior.

### **Gestionar recursos faltantes o bloqueados**

Devuelve `null` desde `resolveUri` cuando una URI de recurso es inválida, prohibida o no puede resolverse. Devuelve `null` desde `getEntity` cuando el recurso no puede leerse. Aspose.Slides continúa procesando el SVG sin ese recurso cuando sea posible.

Se puede devolver un flujo de reserva para un recurso faltante, pero su contenido debe ser compatible con el tipo de recurso solicitado. Por ejemplo, devuelve un flujo de imagen solo para una imagen faltante, no para una fuente o hoja de estilo.

{{% alert title="Seguridad" color="warning" %}}
No resuelvas rutas de archivo arbitrarias ni URLs de red sin restricciones desde archivos SVG no confiables. Restringe los esquemas, directorios y hosts permitidos. Para recursos de red, también aplica tiempos de espera de conexión, límites de tamaño de respuesta y validación de contenido.
{{% /alert %}}

## **Convertir SVG a un conjunto de formas**

Aspose.Slides puede convertir un SVG en un conjunto de formas, similar a la funcionalidad correspondiente en PowerPoint:

![Menú emergente de PowerPoint](img_01_01.png)

Esta funcionalidad se proporciona mediante una sobrecarga del método [addGroupShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addgroupshape/) de la clase [ShapeCollection](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/) que toma un objeto [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/) como su primer argumento.

El siguiente código de muestra en PHP muestra cómo usar este método para convertir un archivo SVG en un conjunto de formas:

```php
// Nombre del archivo SVG de origen.
$svgFileName = "sample.svg";

// Nombre del archivo de salida de la presentación.
$outPptxPath = "presentation.pptx";

// Crear una nueva presentación.
$presentation = new Presentation();
try {
    // Leer el contenido del archivo SVG.
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $svgFileName));
    try {
        $svgContent = $Array->newInstance($Byte, $dis->available());
        $dis->readFully($svgContent);
    } finally {
        if (!java_is_null($dis)) {
            $dis->close();
        }
    }

    // Crear un objeto SvgImage.
    $svgImage = new SvgImage($svgContent);

    // Obtener el tamaño de la diapositiva.
    $slideSize = $presentation->getSlideSize()->getSize();

    // Convertir la imagen SVG a un grupo de formas y escalarla al tamaño de la diapositiva.
    $presentation->getSlides()->get_Item(0)->getShapes()->addGroupShape(
        $svgImage,
        0.0,
        0.0,
        $slideSize->getWidth(),
        $slideSize->getHeight()
    );

    // Guardar la presentación en formato PPTX.
    $presentation->save($outPptxPath, SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $presentation->dispose();
}
```

## **Agregar imágenes como EMF a diapositivas**

Aspose.Slides for PHP via Java permite generar imágenes EMF a partir de hojas de cálculo Excel con Aspose.Cells y agregarlas a diapositivas de la presentación.

El siguiente código de muestra en PHP muestra cómo hacerlo:

```php
$book = new Workbook("chart.xlsx");
$sheet = $book->getWorksheets()->get(0);

$options = new ImageOrPrintOptions();
$options->setHorizontalResolution(200);
$options->setVerticalResolution(200);
$options->setImageType(ImageType::EMF);

// Guardar el libro de trabajo en un flujo.
$sr = new SheetRender($sheet, $options);
$pres = new Presentation();
try {
    $pres->getSlides()->removeAt(0);

    for ($j = 0; $j < java_values($sr->getPageCount()); $j++) {
        $emfSheetName = "test" . $sheet->getName() . " Page" . ($j + 1) . ".out.emf";
        $sr->toImage($j, $emfSheetName);

        // Añadir el archivo tal cual para que la imagen permanezca como vector EMF en lugar de rasterizarse.
        $picture = null;
        $imageStream = new Java("java.io.FileInputStream", $emfSheetName);
        try {
            $picture = $pres->getImages()->addImage($imageStream);
        } finally {
            $imageStream->close();
        }

        $slide = $pres->getSlides()->addEmptySlide($pres->getLayoutSlides()->getByType(SlideLayoutType::Blank));
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle,
            0,
            0,
            $pres->getSlideSize()->getSize()->getWidth(),
            $pres->getSlideSize()->getSize()->getHeight(),
            $picture
        );
    }

    $pres->save("output.pptx", SaveFormat::Pptx);
} catch (JavaException $e) {
} finally {
    $pres->dispose();
}
```

## **Reemplazar imágenes en la colección de imágenes**

Aspose.Slides permite reemplazar imágenes almacenadas en la colección de imágenes de una presentación, incluidas las imágenes usadas por formas de diapositiva. Esta sección describe varias formas de actualizar imágenes en la colección. Puedes reemplazar una imagen usando datos binarios crudos, una instancia de [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/), o otra imagen que ya exista en la colección.

1. Carga el archivo de presentación que contiene imágenes usando la clase [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/).
1. Carga una nueva imagen desde un archivo a un arreglo de bytes.
1. Reemplaza la imagen objetivo con la nueva imagen usando el arreglo de bytes.
1. En el segundo enfoque, carga la imagen en un objeto [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) y reemplaza la imagen objetivo con ese objeto.
1. En el tercer enfoque, reemplaza la imagen objetivo con una imagen que ya exista en la colección de imágenes de la presentación.
1. Guarda la presentación modificada como archivo PPTX.

```php
// Instanciar la clase Presentation que representa un archivo de presentación.
$presentation = new Presentation("sample.pptx");
try {
    // La primera forma.
    $imagePath = (new Java("java.io.File", "image0.jpeg"))->toPath();
    $imageData = (new JavaClass("java.nio.file.Files"))->readAllBytes($imagePath);
    $oldImage = $presentation->getImages()->get_Item(0);
    $oldImage->replaceImage($imageData);

    // La segunda forma.
    $newImage = Images::fromFile("image1.png");
    try {
        $oldImage = $presentation->getImages()->get_Item(1);
        $oldImage->replaceImage($newImage);
    } finally {
        if (!java_is_null($newImage)) {
            $newImage->dispose();
        }
    }

    // La tercera forma.
    $oldImage = $presentation->getImages()->get_Item(2);
    $oldImage->replaceImage($presentation->getImages()->get_Item(3));

    // Guardar la presentación en un archivo.
    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Información" color="info" %}}
Con el conversor gratuito [Texto a GIF](https://products.aspose.app/slides/es/text-to-gif) de Aspose, puedes animar texto fácilmente y crear GIFs a partir de texto. 
{{% /alert %}}

## **Preguntas frecuentes**

**¿Se mantiene la resolución original de la imagen después de la inserción?**

Sí. Los píxeles originales se conservan, pero la apariencia final depende de cómo se escale la [imagen](/slides/es/php-java/picture-frame/) en la diapositiva y de cualquier compresión aplicada al guardar.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en docenas de diapositivas a la vez?**

Coloca el logotipo en la diapositiva maestra o en una distribución y reemplázalo en la colección de imágenes de la presentación; las actualizaciones se propagarán a todos los elementos que usen ese recurso.

**¿Puede un SVG insertado convertirse en formas editables?**

Sí. Puedes convertir un SVG en un grupo de formas, después de lo cual las partes individuales se vuelven editables con las propiedades estándar de forma.

**¿Cómo puedo establecer una imagen como fondo para varias diapositivas a la vez?**

[Asignar la imagen como fondo](/slides/es/php-java/presentation-background/) en la diapositiva maestra o en la distribución correspondiente; cualquier diapositiva que use esa maestra/distribución heredará el fondo.

**¿Cómo evito que una presentación se vuelva demasiado grande debido a muchas imágenes?**

Reutiliza un único recurso de imagen en lugar de duplicados, elige resoluciones razonables, aplica compresión al guardar y mantén los gráficos repetidos en la maestra cuando sea apropiado.