---
title: Protección contra escritura de presentaciones en PHP
linktitle: Protección contra escritura
type: docs
weight: 25
url: /es/php-java/write-protected-presentation/
keywords:
- protección contra escritura
- PowerPoint con protección contra escritura
- contraseña para modificar
- restringir la edición de la presentación
- eliminar la protección contra escritura
- validar contraseña de modificación
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Establecer, detectar, validar y eliminar contraseñas de protección contra escritura en presentaciones PowerPoint PPT y PPTX utilizando Aspose.Slides para PHP."
---
## **Introducción**

Una contraseña de protección contra escritura restringe la modificación de una presentación, pero no cifra su contenido. Los usuarios pueden cargar y ver una presentación protegida contra escritura sin la contraseña. Según la aplicación, también pueden editar el contenido y guardarlo con otro nombre, por lo que la protección contra escritura no debe considerarse un mecanismo de confidencialidad.

Una contraseña de apertura tiene un propósito diferente: cifra la presentación y es necesaria para cargar su contenido. Para cifrar una presentación o validar una contraseña de apertura, consulte [Presentaciones protegidas con contraseña](/slides/es/php-java/password-protected-presentation/).

Los flujos de trabajo en este artículo se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan archivos PPTX; al guardar en PPT, use la extensión `.ppt` y el formato de guardado PPT correspondiente.

## **Establecer protección contra escritura en una presentación**

Utilice [ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#setWriteProtection) para asignar una contraseña que permita modificar una presentación. Guardar la presentación conserva la configuración de protección.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Cargar una presentación protegida contra escritura**

Dado que la protección contra escritura no cifra el contenido de la presentación, no se necesita una contraseña para cargarla. La contraseña solo es relevante al validar la autorización para modificar la presentación protegida.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

No pase una contraseña de protección contra escritura a [LoadOptions::setPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setPassword). Ese método acepta una contraseña de apertura para contenido cifrado. Si una presentación tiene ambos tipos de protección, proporcione la contraseña de apertura para cargarla y gestione la contraseña de protección contra escritura por separado.

## **Eliminar la protección contra escritura de una presentación**

Utilice [ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#removeWriteProtection) para eliminar la restricción de modificación y, a continuación, guarde la presentación.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Comprobar si una presentación está protegida contra escritura**

Para inspeccionar un archivo sin crear una instancia completa de [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/), llame a [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/#getPresentationInfo) y examine [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#isWriteProtected). El método utiliza [NullableBool](https://reference.aspose.com/slides/es/php-java/aspose.slides/nullablebool/) y devuelve `NullableBool::True` cuando se detecta protección contra escritura.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

La sobrecarga de flujo de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/#getPresentationInfo) proporciona la misma información para una presentación suministrada como flujo.

## **Validar una contraseña de protección contra escritura**

Utilice [PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#checkWriteProtection) para validar una contraseña de modificación sin cargar la presentación completa. Primero compruebe [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#isWriteProtected) para que la aplicación solicite o valide una contraseña solo cuando exista protección contra escritura.

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#checkWriteProtection) valida solo la contraseña de protección contra escritura. No valida una contraseña de apertura ni determina si se puede cargar contenido cifrado. Por el contrario, [PresentationInfo::checkPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#checkPassword) valida únicamente una contraseña de apertura. Si ya se ha cargado una presentación completa, [ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#checkWriteProtection) ofrece la comprobación equivalente de protección contra escritura a través de su gestor de protección.

En aplicaciones de producción, no registre contraseñas ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios y mantenga las contraseñas en memoria solo el tiempo necesario.

{{% alert color="info" title="Ver también" %}}
- [Presentaciones protegidas con contraseña](/slides/es/php-java/password-protected-presentation/)
- [Presentaciones de solo lectura](/slides/es/php-java/read-only-presentation/)
- [Firma digital en PowerPoint](/slides/es/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿La protección contra escritura cifra una presentación?**

No. Restringe la modificación pero deja el contenido de la presentación disponible para cargarlo y visualizarlo.

**¿Se requiere la contraseña de protección contra escritura para abrir una presentación?**

No. Sólo se necesita una contraseña de apertura para cargar el contenido cifrado de la presentación.

**¿Puede una presentación tener tanto una contraseña de apertura como una contraseña de protección contra escritura?**

Sí. Proporcione la contraseña de apertura mediante las opciones de carga para abrir la presentación cifrada y valide la contraseña de protección contra escritura por separado cuando se requiera autorización para modificarla.