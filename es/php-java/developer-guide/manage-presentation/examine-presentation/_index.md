---
title: Examinar Presentación
type: docs
weight: 30
url: /php-java/examine-presentation/
keywords:
- PowerPoint
- presentación
- formato de presentación
- propiedades de presentación
- propiedades del documento
- obtener propiedades
- leer propiedades
- cambiar propiedades
- modificar propiedades
- PPTX
- PPT
- PHP
- Java
description: "Leer y modificar propiedades de presentaciones de PowerPoint en PHP a través de Java"
---

Aspose.Slides para PHP vía Java te permite examinar una presentación para descubrir sus propiedades y entender su comportamiento.

{{% alert title="Info" color="info" %}} 

Las clases [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) y [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) contienen las propiedades y métodos utilizados en las operaciones aquí.

{{% /alert %}} 

## **Verificar un Formato de Presentación**

Antes de trabajar en una presentación, es posible que desees averiguar en qué formato (PPT, PPTX, ODP y otros) se encuentra la presentación en este momento.

Puedes verificar el formato de una presentación sin cargarla. Ve este código PHP:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP
```

## **Obtener Propiedades de la Presentación**

Este código PHP te muestra cómo obtener propiedades de la presentación (información sobre la presentación):

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

Es posible que desees ver las [propiedades bajo la clase DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#DocumentProperties--) .

## **Actualizar Propiedades de la Presentación**

Aspose.Slides proporciona el método [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) que te permite hacer cambios en las propiedades de la presentación.

Supongamos que tenemos una presentación de PowerPoint con las propiedades del documento mostradas a continuación.

![Propiedades del documento originales de la presentación de PowerPoint](input_properties.png)

Este ejemplo de código te muestra cómo editar algunas propiedades de la presentación:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("Mi título");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

Los resultados de cambiar las propiedades del documento se muestran a continuación.

![Propiedades del documento cambiadas de la presentación de PowerPoint](output_properties.png)

## **Enlaces Útiles**

Para obtener más información sobre una presentación y sus atributos de seguridad, puedes encontrar útiles estos enlaces:

- [Comprobar si una Presentación está Encriptada](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Comprobar si una Presentación está Protegida contra Escritura (solo lectura)](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Comprobar si una Presentación está Protegida por Contraseña Antes de Cargarla](https://docs.aspose.com/slides/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmar la Contraseña Utilizada para Proteger una Presentación](https://docs.aspose.com/slides/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).