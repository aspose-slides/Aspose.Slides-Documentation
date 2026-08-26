---
title: Proteger presentaciones con contraseña en PHP
linktitle: Protección con contraseña
type: docs
weight: 20
url: /es/php-java/password-protected-presentation/
keywords:
- presentación protegida con contraseña
- contraseña de apertura
- cifrar PowerPoint
- descifrar PowerPoint
- validar contraseña de presentación
- comprobar contraseña de presentación
- abrir presentación cifrada
- eliminar cifrado
- PowerPoint
- PPT
- PPTX
- presentación
- PHP
- Aspose.Slides
description: "Cifrar, detectar, validar, abrir y descifrar presentaciones de PowerPoint PPT y PPTX protegidas con contraseña en PHP con Aspose.Slides."
---
## **Visión general**

Una contraseña de apertura cifra una presentación. La contraseña correcta es necesaria para cargar y ver el contenido de la presentación, por lo que esta protección proporciona confidencialidad.

Una contraseña de apertura es diferente de una contraseña de protección de escritura. La protección de escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para gestionar contraseñas para modificar presentaciones, consulte [Write-Protect Presentations](/slides/es/php-java/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos cuando su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [ProtectionManager::encrypt](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#encrypt) para asignar una contraseña de apertura. Luego utilice [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) para guardar la presentación cifrada.

El siguiente ejemplo cifra una presentación PPTX:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Cargar una presentación cifrada**

Establezca [LoadOptions::setPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setPassword) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña suministrada falta o es incorrecta.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # Trabajar con la presentación descifrada.
} finally {
    $presentation->dispose();
}
```

## **Eliminar el cifrado de una presentación**

Cargue la presentación con su contraseña de apertura, llame a [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#removeEncryption) y guarde el resultado. La presentación guardada puede entonces cargarse sin una contraseña.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Validar una contraseña de apertura antes de cargar**

Utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/#getPresentationInfo) para obtener [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/) sin crear una instancia completa de la presentación. Verifique [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#isPasswordProtected) antes de solicitar o validar una contraseña. Cuando la protección está presente, valide el valor validado con [PresentationInfo::checkPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#checkPassword).

### **Flujo de trabajo con ruta de archivo**

El siguiente ejemplo valida una contraseña de apertura para un archivo PPTX, pasa el valor validado a [LoadOptions::setPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setPassword) y luego carga la presentación completa:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **Flujo de trabajo con flujo**

La sobrecarga de flujo de [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/#getPresentationInfo) ofrece el mismo flujo de trabajo. Restablezca la posición de un flujo buscable antes de cargar la presentación completa desde ese flujo.

El siguiente ejemplo utiliza un archivo PPT:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **Valores de retorno de checkPassword**

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#checkPassword) devuelve `true` solo cuando la presentación tiene una contraseña de apertura y la contraseña suministrada es correcta. Devuelve `false` en cada uno de estos casos:

- La contraseña es incorrecta.
- La presentación no tiene una contraseña de apertura.
- La contraseña suministrada es `null` o está vacía.

El comportamiento es el mismo para presentaciones PPT y PPTX.

## **Comprobar si una presentación cargada está cifrada**

Después de cargar una presentación con la contraseña correcta, inspeccione [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#isEncrypted) para confirmar que la presentación original estaba cifrada. Para detectar la protección con contraseña de apertura antes de cargar, use [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#isPasswordProtected) como se mostró arriba.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **Recomendaciones de seguridad**

{{% alert color="warning" title="Security" %}}
No registre las contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos e innecesarios, mantenga las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso al cargar inmediatamente la presentación.
{{% /alert %}}

## **Proteger con contraseña una presentación en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
2. Seleccione o cargue la presentación.
3. Introduzca una contraseña para la protección de visualización.
4. Opcionalmente, introduzca una contraseña distinta para la protección de edición.
5. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="See also" %}}
- [Proteger presentaciones contra escritura](/slides/es/php-java/write-protected-presentation/)
- [Firma digital en PowerPoint](/slides/es/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección de escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección de escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si la protección con contraseña de apertura está presente y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Los flujos de trabajo de verificación de contraseña son compatibles tanto con PPT como con PPTX?**

Sí. La detección y validación de contraseñas basada en ruta de archivo y en flujos se comportan de la misma manera para presentaciones PPT y PPTX.