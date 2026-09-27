---
title: Crear presentaciones en PHP
linktitle: Crear presentación
type: docs
weight: 10
url: /es/php-java/create-presentation/
keywords:
- crear presentación
- nueva presentación
- crear PPT
- nuevo PPT
- crear PPTX
- nuevo PPTX
- crear ODP
- nuevo ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Cree presentaciones con Aspose.Slides para PHP mediante Java — genere archivos PPT, PPTX y ODP y guárdelos programáticamente para obtener resultados fiables."
---
## **Visión general**

Este artículo muestra cómo crear una presentación en Aspose.Slides, añadir un cuadro de texto a su primera diapositiva y guardar el resultado como un archivo. También muestra cómo crear y guardar una presentación vacía, y cómo abrir una presentación existente en un formato compatible y guardarla en otro formato. Al final hay una breve FAQ que cubre preguntas habituales sobre formatos, plantillas, tamaño de diapositivas, unidades, uso de memoria, subprocesos, licencias, firmas digitales y compatibilidad con VBA.

Antes de comenzar, instale Aspose.Slides para PHP vía Java con Composer y arranque PHP/Java Bridge en Apache Tomcat. Consulte [Instalación](/slides/es/php-java/installation/) para la configuración completa. Los ejemplos a continuación asumen que Tomcat se está ejecutando en `localhost:8080` y que la carpeta `vendor` de Composer está junto al script.

## **Crear una presentación de PowerPoint**

1. Crear una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Una nueva presentación ya contiene una diapositiva vacía.
1. Obtener esa diapositiva de la colección devuelta por [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/), mediante su índice, 0.
1. Añadir un rectángulo con el método [ShapeCollection::addAutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addautoshape/) y establecer su texto con [TextFrame::setText](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/settext/).
1. Guardar la presentación como archivo PPTX con el método [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/).

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/es/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Las dos líneas `require_once` cargan el cliente PHP/Java Bridge desde Tomcat y las clases Aspose.Slides del paquete Composer. La esquina superior izquierda del rectángulo está a 50 puntos del borde izquierdo y a 50 puntos del borde superior de la diapositiva, y el rectángulo tiene 400 puntos de ancho y 100 puntos de alto. El archivo guardado contiene una diapositiva con ese rectángulo y su texto. Sin una licencia, Aspose.Slides también añade una marca de agua de evaluación a cada diapositiva que guarda; vea [Licencias](/slides/es/php-java/licensing/).

{{% alert color="info" title="Note" %}}
Aspose.Slides lee y escribe archivos dentro de Tomcat, no en su proceso PHP, por lo que una ruta relativa como `"hello.pptx"` se resuelve respecto a la carpeta de trabajo de Tomcat. Los ejemplos de esta página construyen rutas absolutas con `__DIR__`, de modo que los archivos se leen y se guardan junto al script.
{{% /alert %}}

## **Crear y guardar una presentación**

Para crear una presentación vacía y guardarla, cree una instancia de la clase [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) y guárdala en cualquier formato de la enumeración [SaveFormat](https://reference.aspose.com/slides/php-java/aspose.slides/saveformat/). El resultado es una presentación con una diapositiva vacía.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/es/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Abrir y guardar una presentación**

Para convertir una presentación de un formato a otro, ábrala pasando su ruta al constructor [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), y luego guárdala en el formato de destino. Aspose.Slides detecta el formato de entrada, como PPT, PPTX u ODP, a partir del propio archivo.

El ejemplo a continuación espera una presentación OpenDocument llamada *Sample.odp* junto al script y la guarda como PPTX.

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/es/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation(__DIR__ . "/Sample.odp");
try {
    $presentation->save(__DIR__ . "/OutputPresentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Preguntas frecuentes**

### ¿En qué formatos puedo guardar una nueva presentación?

Puede guardar en [PPTX, PPT, and ODP](/slides/es/php-java/save-presentation/), y exportar a [PDF](/slides/es/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/es/php-java/convert-powerpoint-to-xps/), [HTML](/slides/es/php-java/convert-powerpoint-to-html/), [SVG](/slides/es/php-java/render-a-slide-as-an-svg-image/), y [images](/slides/es/php-java/convert-powerpoint-to-png/), entre otros.

### ¿Puedo iniciar a partir de una plantilla (POTX/POTM) y guardarla como un PPTX normal?

Sí. Cargue la plantilla y guárdela en el formato deseado; los formatos POTX/POTM/PPTM y similares [son compatibles](/slides/es/php-java/supported-file-formats/).

### ¿Cómo controlo el tamaño/relación de aspecto de la diapositiva al crear una presentación?

Establezca el [tamaño de diapositiva](/slides/es/php-java/slide-size/) (incluidos los preajustes como 4:3 y 16:9 o dimensiones personalizadas) y elija cómo debe escalar el contenido.

### ¿En qué unidades se miden los tamaños y coordenadas?

En puntos: 1 pulgada equivale a 72 unidades.

### ¿Cómo gestiono presentaciones muy grandes (con muchos archivos multimedia) para reducir el uso de memoria?

Utilice [estrategias de gestión de BLOB](/slides/es/php-java/manage-blob/), limite el almacenamiento en memoria aprovechando archivos temporales y prefiera flujos basados en archivos en lugar de flujos puramente en memoria.

### ¿Puedo crear/guardar presentaciones en paralelo?

No puede operar sobre la misma instancia de [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) desde [múltiples subprocesos](/slides/es/php-java/multithreading/). Ejecute instancias separadas e aisladas por subproceso o proceso.

### ¿Cómo elimino la marca de agua de prueba y las limitaciones?

[Aplique una licencia](/slides/es/php-java/licensing/) una vez por proceso. El XML de la licencia debe permanecer sin modificar, y la configuración de la licencia debe sincronizarse si intervienen varios subprocesos.

### ¿Puedo firmar digitalmente el PPTX que creo?

Sí. Las [firmas digitales](/slides/es/php-java/digital-signature-in-powerpoint/) (añadir y verificar) son compatibles con las presentaciones.

### ¿Se admiten macros (VBA) en las presentaciones creadas?

Sí. Puede [crear/editar proyectos VBA](/slides/es/php-java/presentation-via-vba/) y guardar archivos con macros como PPTM/PPSM.