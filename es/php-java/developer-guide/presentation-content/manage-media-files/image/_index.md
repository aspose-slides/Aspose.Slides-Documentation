---
title: Optimizar la gestión de imágenes en presentaciones usando PHP
linktitle: Gestionar imágenes
type: docs
weight: 10
url: /es/php-java/image/
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
- PHP
- Aspose.Slides
description: "Aprende cómo añadir, reutilizar, vincular, reemplazar y gestionar imágenes raster y SVG en presentaciones PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java."
---
## **Introducción**

Aspose.Slides for PHP via Java ofrece varias formas de trabajar con imágenes, y cada una sirve a un propósito diferente. Puedes almacenar una imagen en una presentación, mostrarla en un marco de imagen, usarla como fondo de diapositiva, enlazar a una imagen externa, reemplazar un recurso de imagen compartido o convertir contenido SVG en formas editables.

Este artículo se centra en los recursos de imagen y cómo se utilizan a lo largo de una presentación. Para recorte, transparencia, efectos, estirado y demás formato aplicado a un marco de imagen individual, consulta [Picture Frame](/slides/es/php-java/picture-frame/).

### **Comprender el modelo de imagen**

- La [colección de imágenes de la presentación](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/) almacena los recursos de imagen utilizados por la presentación. Utiliza [ImageCollection::addImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/) para añadir datos de imagen y obtener un recurso [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/).
- Un [marco de imagen](https://reference.aspose.com/slides/es/php-java/aspose.slides/pictureframe/) es una forma que muestra una imagen en una diapositiva, diseño o maestro. Utiliza [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addpictureframe/) para colocar un recurso de imagen en una diapositiva.
- Un fondo de diapositiva utiliza una imagen como parte del relleno de la diapositiva en lugar de como una forma. Por lo tanto, no se comporta como un marco de imagen.
- [PPImage::replaceImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) reemplaza un recurso de imagen. Si varios elementos de la presentación utilizan ese recurso, todos usarán el reemplazo.
- Convertir un SVG a formas crea formas de diapositiva editables. Después de la conversión, el contenido ya no se gestiona como un único recurso de imagen.

Un flujo de trabajo típico es, por tanto: añadir datos de imagen a la colección de imágenes, obtener un [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/), y luego usar ese recurso en uno o varios marcos de imagen o rellenos.

## **Agregar una imagen incrustada**

Para insertar una imagen local, carga el archivo, añádelo a la colección de imágenes y crea un marco de imagen que utilice el `PPImage` devuelto.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

La imagen añadida de esta forma queda incrustada en la presentación, por lo que el archivo resultante no depende de que el archivo de imagen original siga estando disponible.

### **Agregar una imagen desde la web**

Cuando una imagen está disponible a través de HTTP o HTTPS, descarga sus bytes, añádelos a la colección de imágenes de la presentación y utiliza el recurso de imagen devuelto de la misma manera que una imagen local.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

En aplicaciones de larga duración, reutiliza un cliente HTTP o una estrategia de gestión de conexiones adecuada a la aplicación en lugar de crear repetidamente infraestructura de red innecesaria. También valida las URL remotas, los tamaños de respuesta y los tipos de contenido cuando la fuente no es de confianza.

## **Reutilizar imágenes en varias diapositivas**

Si la misma imagen se necesita más de una vez, añádela a la presentación una sola vez y reutiliza el [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) devuelto al crear marcos de imagen adicionales. Esto evita cargar repetidamente los mismos datos de origen y hace explícita la relación entre el recurso de imagen compartido y sus usos.

Para gráficos que deben aparecer automáticamente en muchas diapositivas, como el logotipo de la empresa, considera colocar el marco de imagen en un [slide master](/slides/es/php-java/slide-master/) o diseño en lugar de añadir una forma equivalente a cada diapositiva.

## **Usar una imagen como fondo de diapositiva**

Una imagen de fondo se asigna al relleno de la diapositiva; no se añade como una forma de marco de imagen. Esto es útil cuando la imagen debe cubrir el fondo de la diapositiva y no debe manipularse como un objeto de diapositiva normal.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Para opciones de fondo adicionales, incluidos fondos de maestro y de diseño, consulta [Presentation Background](/slides/es/php-java/presentation-background/).

## **Imágenes incrustadas e imágenes vinculadas**

Las imágenes incrustadas y vinculadas tienen diferentes compensaciones de portabilidad y tamaño de archivo:

- **Imagen incrustada:** los datos de la imagen se almacenan dentro de la presentación. La presentación es independiente, pero el tamaño del archivo incluye los datos de la imagen.
- **Imagen vinculada:** la presentación almacena una ruta o URL a una imagen externa. Esto puede reducir el tamaño de la presentación, pero el recurso externo debe permanecer accesible cuando la presentación se abre o renderiza.

Se puede crear una imagen vinculada asignando la ruta o URL externa mediante [Picture::setLinkPathLong](https://reference.aspose.com/slides/es/php-java/aspose.slides/picture/) en lugar de incrustar los datos de la imagen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utiliza imágenes vinculadas solo cuando el entorno de despliegue pueda acceder de forma fiable al recurso externo. Para presentaciones que deben funcionar sin conexión o trasladarse entre sistemas, las imágenes incrustadas suelen ser más seguras.

## **Trabajar con imágenes SVG**

SVG es un formato vectorial, por lo que puede ser útil para iconos, diagramas y otras gráficas que deben escalar sin la misma pérdida de detalle que las imágenes raster. Aspose.Slides admite SVG tanto como recurso de imagen como como fuente de formas de diapositiva editables.

### **Agregar un SVG como imagen**

Crea un [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/), añádelo a la colección de imágenes y coloca el recurso de imagen resultante en un marco de imagen.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Archivos SVG con recursos externos**

Un SVG puede referenciar imágenes, hojas de estilo o fuentes externas. Para estos casos, [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/) proporciona constructores que aceptan un [ExternalResourceResolver](https://reference.aspose.com/slides/es/php-java/aspose.slides/externalresourceresolver/) y una URI base. El resolvedor puede mapear una URI relativa a una URI absoluta permitida y devolver un flujo para el recurso solicitado.

El resolvedor hace que los recursos externos estén disponibles mientras Aspose.Slides procesa el SVG, pero no reescribe el SVG a un documento autónomo. Si el SVG debe permanecer portable, incrusta sus recursos requeridos dentro del propio SVG, por ejemplo usando URIs `data:` para imágenes vinculadas.

Cuando los archivos SVG provienen de fuentes no fiables, restringe los esquemas, ubicaciones de archivos y hosts a los que el resolvedor puede acceder. Los resolvedores de red también deben aplicar tiempos de espera, límites de tamaño de respuesta y validación de contenido.

### **Convertir SVG a formas editables**

Aspose.Slides puede convertir un SVG en un grupo de formas de diapositiva editables, similar al comando correspondiente de PowerPoint.

![PowerPoint Popup Menu](img_01_01.png)

Utiliza la sobrecarga [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addgroupshape/) que acepta un [SvgImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/svgimage/) para realizar la conversión.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Utiliza la conversión de SVG a formas cuando los elementos vectoriales individuales necesiten editarse como formas de PowerPoint. Si el SVG solo necesita mostrarse, mantenerlo como imagen es más sencillo y evita crear muchas formas separadas.

## **Reemplazar un recurso de imagen existente**

Utiliza [PPImage::replaceImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/) cuando deseas reemplazar un recurso de imagen existente. Esto es especialmente útil para gráficos compartidos como logotipos.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Si varios marcos de imagen, fondos, maestros o diseños utilizan el mismo recurso de imagen, reemplazar ese recurso actualiza todos esos usos. Si solo debe cambiar un marco de imagen, asigna una imagen diferente a ese marco en lugar de reemplazar el recurso compartido.

`PPImage::replaceImage` también ofrece sobrecargas que aceptan una matriz de bytes u otro [PPImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/).

## **Guía práctica de gestión de imágenes**

### **Controlar el tamaño de la presentación**

Las imágenes raster grandes pueden hacer que una presentación sea innecesariamente grande. Utiliza imágenes de origen con dimensiones apropiadas para su tamaño de visualización previsto, reutiliza recursos de imagen compartidos cuando sea posible y evita incrustar copias repetidas del mismo gráfico de alta resolución.

Para imágenes raster que ya se han colocado en marcos de imagen, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/picturefillformat/) puede reducir los datos de la imagen según la resolución y los ajustes de recorte seleccionados. Esto es procesamiento de marcos de imagen más que gestión de la colección de imágenes, así que consulta [Picture Frame](/slides/es/php-java/picture-frame/) para operaciones de formato relacionadas.

### **Elegir entre contenido incrustado y vinculado**

Incrustar hace que la presentación sea portátil porque todos los datos de imagen requeridos viajan con el archivo. Vincular puede reducir el tamaño del archivo, pero introduce una dependencia externa. Utiliza enlaces solo cuando esa dependencia sea aceptable y estable.

### **Reutilizar la marca compartida**

Para logotipos, marcas de agua o gráficos decorativos repetidos, usa un recurso de imagen y reutilízalo. Si el gráfico pertenece al diseño de la presentación más que al contenido de la diapositiva, colócalo en un maestro o diseño para que sea heredado por las diapositivas correspondientes.

### **Mantener los recursos SVG portables**

Un SVG autónomo es más fácil de mover y renderizar de forma coherente que un SVG que depende de archivos externos o recursos de red. Cuando sea posible, incrusta los recursos necesarios antes de importar el SVG. Convierte SVG a formas solo cuando los elementos vectoriales individuales necesiten ser editados.

### **Utilizar la API de imagen moderna y multiplataforma**

Para código nuevo de PHP vía Java, utiliza las API de Aspose.Slides [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/) y [Images](https://reference.aspose.com/slides/es/php-java/aspose.slides/images/) en lugar de la API pública heredada basada en `java.awt.image.BufferedImage`. Consulta [Modern API](/slides/es/php-java/modern-api/) para obtener orientación sobre la migración.

WMF y EMF requieren consideraciones especiales. Cuando estos formatos se pasan a través de un [IImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/) convierte el metarchivo a una representación PNG raster antes de la inserción. Si es importante conservar los datos del metarchivo, utiliza en su lugar una sobrecarga basada en flujo de [ImageCollection::addImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/imagecollection/). Generar contenido EMF a partir de hojas de cálculo u otros productos es un flujo de integración separado y está fuera del alcance de este artículo.

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre la colección de imágenes y un marco de imagen?**

La colección de imágenes almacena recursos de imagen reutilizables. Un marco de imagen es una forma de diapositiva que muestra uno de esos recursos y ofrece formato específico de imagen, como recorte y efectos.

**¿Cuál es la mejor manera de reemplazar el mismo logotipo en todas partes?**

Si el logotipo ya se comparte como un único recurso de imagen, reemplaza ese recurso con [PPImage::replaceImage](https://reference.aspose.com/slides/es/php-java/aspose.slides/ppimage/). Para una marca en toda la presentación, colocar el logotipo en un maestro o diseño también puede reducir el contenido duplicado de las diapositivas.

**¿Por qué una imagen vinculada desaparece en otro ordenador?**

Una imagen vinculada depende de su archivo o URL externo. Si ese recurso no puede ser alcanzado desde el otro ordenador, la imagen vinculada puede no estar disponible. Incrusta la imagen cuando la presentación debe ser autónoma.

**¿Puede editarse un SVG insertado como formas de PowerPoint?**

Sí. Convierte el SVG con [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/es/php-java/aspose.slides/shapecollection/addgroupshape/); el grupo resultante contiene formas de diapositiva editables en lugar de una sola imagen SVG.

**¿Cómo puedo mantener más pequeñas las presentaciones con muchas imágenes?**

Reutiliza recursos de imagen compartidos, evita fuentes raster innecesariamente grandes, comprime imágenes raster adecuadas cuando sea apropiado, mantiene la marca repetida en maestros o diseños, y utiliza imágenes vinculadas solo cuando una dependencia externa sea aceptable.