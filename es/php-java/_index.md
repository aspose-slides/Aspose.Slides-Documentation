---
title: Aspose.Slides for PHP via Java
second_title: Aspose.Slides for PHP
type: docs
weight: 45
url: /es/php-java/
keywords:
- documentación
- procesamiento de presentaciones
- conversión de presentaciones
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Empieza aquí: instala Aspose.Slides for PHP via Java, crea una primera presentación y encuentra las guías para tareas habituales, la referencia de API y el soporte."
is_root: true
---
<img src="aspose_slides-for-php-via-java.png" alt="Aspose.Slides for PHP via Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for PHP via Java es una biblioteca de clases para crear, leer, editar y convertir presentaciones PowerPoint y OpenDocument en aplicaciones PHP, sin Microsoft PowerPoint ni Automatización de Office.

Carga y guarda PPT, PPTX, PPS, POT y ODP, incluidas las variantes con macros y plantillas, y exporta a PDF, XPS, HTML, SVG, TIFF, Markdown e imágenes.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Comenzar</b></p>
<hr>
<p>COMENZANDO</p>
<ul>
<li><a href="/slides/es/php-java/installation/">Instalación</a></li>
<li><a href="/slides/es/php-java/create-presentation/">Crea tu primera presentación</a></li>
<li><a href="/slides/es/php-java/getting-started/">Guía de inicio</a></li>
</ul>
<p>EVALUAR</p>
<ul>
<li><a href="/slides/es/php-java/supported-file-formats/">Formatos de archivo compatibles</a></li>
<li><a href="/slides/es/php-java/evaluate-aspose-slides/">Limitaciones de la prueba</a></li>
<li><a href="/slides/es/php-java/licensing/">Licencias</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Crear con Slides</b></p>
<hr>
<p>TAREAS COMUNES</p>
<ul>
<li><a href="/slides/es/php-java/open-presentation/">Abrir una presentación</a></li>
<li><a href="/slides/es/php-java/save-presentation/">Guardar una presentación</a></li>
<li><a href="/slides/es/php-java/convert-powerpoint-to-pdf/">Convertir a PDF</a></li>
<li><a href="/slides/es/php-java/convert-slide/">Renderizar diapositivas como imágenes</a></li>
<li><a href="/slides/es/php-java/manage-text/">Editar texto y formas</a></li>
</ul>
<p>FLUJOS DE TRABAJO DE SLIDES</p>
<ul>
<li><a href="/slides/es/php-java/powerpoint-charts/">Gráficos</a></li>
<li><a href="/slides/es/php-java/powerpoint-animation/">Animaciones</a></li>
<li><a href="/slides/es/php-java/manage-media-files/">Audio y video</a></li>
<li><a href="/slides/es/php-java/presentation-design/">Diseño de diapositivas</a></li>
<li><a href="/slides/es/php-java/merge-presentation/">Combinar presentaciones</a></li>
</ul>
<p>EJEMPLOS</p>
<ul>
<li><a href="/slides/es/php-java/examples/">Ejemplos por elemento de diapositiva</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referencia &amp; Soporte</b></p>
<hr>
<p>REFERENCIA</p>
<ul>
<li><a href="https://reference.aspose.com/slides/php-java/">Referencia de API</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/release-notes/">Notas de la versión</a></li>
<li><a href="/slides/es/php-java/known-issues/">Problemas conocidos</a></li>
<li><a href="https://products.aspose.com/slides/php-java/">Página del producto</a></li>
<li><a href="https://releases.aspose.com/slides/php-java/">Descargar</a></li>
</ul>
<p>SOPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Foro de soporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Mesa de ayuda de soporte de pago</a></li>
</ul>
</div>
</div>

------

## **Tu primera presentación**

Aspose.Slides for PHP via Java se ejecuta sobre Java dentro de Apache Tomcat, y tus scripts PHP acceden a él a través de PHP/Java Bridge. [Instalación](/slides/es/php-java/installation/) configura PHP 8.3 o anterior, Java, Tomcat y el puente, y luego instala el paquete de Packagist en una carpeta del proyecto:

```bash
composer require aspose/slides
```

Entonces copie el archivo JAR del paquete en el puente y reinicie Tomcat, como en el paso 4 de [Instalar en Linux](/slides/es/php-java/installation/#install-on-linux) o el paso 6 de [Instalar en Windows](/slides/es/php-java/installation/#install-on-windows). Con Tomcat en ejecución, guarde este script como *hello.php* en la carpeta del proyecto y ejecute `php hello.php`:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/lib/aspose.slides.php");

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

La secuencia guarda *hello.pptx* junto a sí misma, con una diapositiva que contiene un cuadro de texto. Sin una licencia, el archivo guardado lleva una marca de agua de evaluación — vea [Licencias](/slides/es/php-java/licensing/). Para más formas de crear y rellenar una presentación, vea [Crear presentaciones](/slides/es/php-java/create-presentation/).