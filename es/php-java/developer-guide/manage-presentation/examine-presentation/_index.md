---
title: Recuperar y actualizar información de presentación en PHP
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
description: "Explore diapositivas, estructura y metadatos en presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para PHP para obtener ideas más rápidas y auditorías de contenido más inteligentes."
---

Aspose.Slides para PHP mediante Java le permite examinar una presentación para obtener sus propiedades y comprender su comportamiento.

{{% alert title="Info" color="info" %}} 

Las clases [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) y [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) contienen las propiedades y métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Comprobar el formato de una presentación**

Antes de trabajar con una presentación, puede que desee averiguar en qué formato (PPT, PPTX, ODP, y otros) se encuentra actualmente la presentación.

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


Puede que desee ver las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Actualizar propiedades de la presentación**

Aspose.Slides proporciona el método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que le permite realizar cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades originales del documento de la presentación de PowerPoint](input_properties.png)

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

![Propiedades modificadas del documento de la presentación de PowerPoint](output_properties.png)

## **Enlaces útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puede que encuentre útiles los siguientes enlaces:

- [Comprobación de si una presentación está cifrada](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobación de si una presentación está protegida contra escritura (solo lectura)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobación de si una presentación está protegida con contraseña antes de cargarla](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmación de la contraseña utilizada para proteger una presentación](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **Preguntas frecuentes**

**¿Cómo puedo comprobar si las fuentes están incrustadas y cuáles son?**

Busque información de [fuentes incrustadas](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getembeddedfonts/) a nivel de presentación, luego compare esas entradas con el conjunto de [fuentes realmente usadas en el contenido](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getfonts/) para identificar qué fuentes son críticas para el renderizado.

**¿Cómo puedo saber rápidamente si el archivo tiene diapositivas ocultas y cuántas?**

Itere a través de la [colección de diapositivas](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) y examine la [bandera de visibilidad](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) de cada diapositiva.

**¿Puedo detectar si se usan tamaño y orientación de diapositiva personalizados, y si difieren de los predeterminados?**

Sí. Compare el [tamaño de diapositiva](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslidesize/) y la orientación actuales con los valores preestablecidos estándar; esto ayuda a anticipar el comportamiento para impresión y exportación.

**¿Existe una manera rápida de ver si los gráficos hacen referencia a fuentes de datos externas?**

Sí. Recorra todos los [gráficos](https://reference.aspose.com/slides/php-java/aspose.slides/chart/), verifique su [fuente de datos](https://reference.aspose.com/slides/php-java/aspose.slides/chartdata/getdatasourcetype/), y anote si los datos son internos o basados en enlaces, incluidos los enlaces rotos.

**¿Cómo puedo evaluar las diapositivas “pesadas” que pueden ralentizar el renderizado o la exportación a PDF?**

Para cada diapositiva, contabilice la cantidad de objetos y busque imágenes grandes, transparencias, sombras, animaciones y contenido multimedia; asigne una puntuación de complejidad aproximada para identificar posibles puntos críticos de rendimiento.