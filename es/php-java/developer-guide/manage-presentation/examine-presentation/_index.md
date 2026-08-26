---
title: Recuperar y actualizar información de la presentación en PHP
linktitle: Información de la presentación
type: docs
weight: 30
url: /es/php-java/examine-presentation/
keywords:
- formato de presentación
- propiedades de la presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- actualizar propiedades
- examinar PPTX
- examinar PPT
- examinar ODP
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Explore diapositivas, estructura y metadatos en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP para obtener análisis más rápidos y auditorías de contenido más inteligentes."
---
## **Descripción general**

Este artículo muestra cómo inspeccionar la información de una presentación en Aspose.Slides. Explica cómo determinar el formato actual de una presentación sin cargar el archivo completo, leer sus propiedades de documento y actualizar esas propiedades cuando sea necesario.

Los ejemplos se basan en las API [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/) y [DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/) y demuestran operaciones típicas para trabajar con los metadatos de una presentación.

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en este momento.

Puede comprobar el formato de una presentación sin cargarla. Vea este código PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **Obtener propiedades de la presentación**

Este código PHP le muestra cómo obtener las propiedades de la presentación (información sobre la presentación):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..

```

Puede que desee ver las [propiedades bajo DocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/documentproperties/#DocumentProperties--) de la clase.

## **Actualizar propiedades de la presentación**

Aspose.Slides ofrece el método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades originales del documento de la presentación PowerPoint](input_properties.png)

Este ejemplo de código le muestra cómo editar algunas propiedades de la presentación:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades modificadas del documento de la presentación PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que le resulten útiles estos enlaces:

- [Presentaciones protegidas con contraseña](/slides/es/php-java/password-protected-presentation/)
- [Presentaciones protegidas contra escritura](/slides/es/php-java/write-protected-presentation/)

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque la [información de fuentes incrustadas](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getembeddedfonts/) a nivel de presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/es/php-java/aspose.slides/fontsmanager/getfonts/) para identificar qué fuentes son críticas para la renderización.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/es/php-java/aspose.slides/slidecollection/) e inspeccione la [bandera de visibilidad](https://reference.aspose.com/slides/es/php-java/aspose.slides/slide/gethidden/) de cada diapositiva.

**¿Puedo detectar si se utilizan tamaños y orientaciones de diapositiva personalizados y si difieren de los valores predeterminados?**

Sí. Compare el [tamaño de diapositiva](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/getslidesize/) y la orientación actuales con los valores estándar; esto ayuda a anticipar el comportamiento al imprimir y exportar.

**¿Existe una forma rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/es/php-java/aspose.slides/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/es/php-java/aspose.slides/chartdata/getdatasourcetype/) y anote si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar la renderización o la exportación a PDF?**

Para cada diapositiva, cuente los objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para identificar posibles puntos críticos de rendimiento.