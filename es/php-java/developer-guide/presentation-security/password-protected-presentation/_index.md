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

Una contraseña de apertura cifra una presentación. Se requiere la contraseña correcta para cargar y ver el contenido de la presentación, por lo que esta protección brinda confidencialidad.

Una contraseña de apertura es distinta de una contraseña de protección contra escritura. La protección contra escritura restringe la modificación pero no cifra el contenido ni impide que la presentación se cargue. Para gestionar contraseñas para modificar presentaciones, consulte [Write-Protect Presentations](/slides/es/php-java/write-protected-presentation/).

Los flujos de trabajo a continuación se aplican tanto a presentaciones PPT como PPTX. Los ejemplos utilizan ambos formatos donde su comportamiento basado en archivos y en flujos es importante.

## **Cifrar una presentación con una contraseña de apertura**

Utilice [ProtectionManager::encrypt](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#encrypt) para asignar una contraseña de apertura. Luego use [Presentation::save](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/#save) para guardar la presentación cifrada.

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

## **Mantener públicas las propiedades del documento**

De forma predeterminada, Aspose.Slides incluye las propiedades del documento en el cifrado de la presentación. El método [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) controla este comportamiento de forma independiente al cifrado del contenido de las diapositivas. Pase `false` antes de llamar a [ProtectionManager::encrypt](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#encrypt) cuando un sistema de indexado, clasificación, búsqueda o gestión de documentos necesite leer los metadatos sin la contraseña de apertura.

El siguiente ejemplo crea una presentación PPTX cifrada dejando sus propiedades de documento integradas públicas:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pasar `false` a [ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) no hace públicas las diapositivas, maestros, diseños, formas, medios u otro contenido de la presentación. Afecta solo a las propiedades del documento. Para leer esas propiedades sin cargar el contenido cifrado, consulte [Manage Presentation Properties](/slides/es/php-java/presentation-properties/).

## **Cargar una presentación cifrada**

Establezca [LoadOptions::setPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/loadoptions/#setPassword) con la contraseña de apertura y pase las opciones a [Presentation](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentation/) al cargar el archivo. La carga falla cuando se requiere una contraseña de apertura pero la contraseña proporcionada falta o es incorrecta.

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

Cargue la presentación con su contraseña de apertura, llame a [ProtectionManager::removeEncryption](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#removeEncryption) y guarde el resultado. La presentación guardada puede entonces cargarse sin contraseña.

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

Utilice [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationfactory/#getPresentationInfo) para obtener [PresentationInfo](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/) sin crear una instancia completa de la presentación. Compruebe [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#isPasswordProtected) antes de solicitar o validar una contraseña. Cuando existe protección, valide el valor suministrado con [PresentationInfo::checkPassword](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#checkPassword).

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

El siguiente ejemplo usa un archivo PPT:

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

Después de cargar una presentación con la contraseña correcta, inspeccione [ProtectionManager::isEncrypted](https://reference.aspose.com/slides/es/php-java/aspose.slides/protectionmanager/#isEncrypted) para confirmar que la presentación original estaba cifrada. Para detectar la protección con contraseña de apertura antes de cargar, use [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/es/php-java/aspose.slides/presentationinfo/#isPasswordProtected) como se mostró anteriormente.

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
No registre contraseñas de apertura ni las incluya en mensajes de diagnóstico. Evite intentos de validación repetidos innecesarios, mantenga las contraseñas en memoria solo el tiempo necesario y reutilice un resultado de validación exitoso cuando cargue inmediatamente la presentación.

Las propiedades públicas del documento pueden revelar nombres de autor, títulos, asuntos, palabras clave, información de la empresa, comentarios y valores personalizados aunque el contenido de la presentación esté cifrado. Cifre los metadatos sensibles junto con la presentación. Dejar las propiedades públicas debe ser una decisión explícita que solo se tome cuando los sistemas deban indexar, clasificar, buscar o gestionar el archivo sin una contraseña de apertura.
{{% /alert %}}

## **Proteger con contraseña una presentación en línea**

1. Abra la aplicación [Aspose.Slides Lock](https://products.aspose.app/slides/es/lock).
2. Seleccione o cargue la presentación.
3. Introduzca una contraseña para la protección de visualización.
4. Opcionalmente, introduzca una contraseña distinta para la protección de edición.
5. Aplique la protección y descargue el archivo resultante.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/es/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/es/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Preguntas frecuentes**

**¿Cuál es la diferencia entre una contraseña de apertura y una contraseña de protección contra escritura?**

Una contraseña de apertura cifra la presentación y es necesaria para cargar su contenido. Una contraseña de protección contra escritura restringe la modificación sin cifrar el contenido.

**¿Puedo validar una contraseña de apertura sin cargar todas las diapositivas?**

Sí. Obtenga la información de la presentación, compruebe si existe protección con contraseña de apertura y valide la contraseña antes de crear una instancia completa de la presentación.

**¿Puede una aplicación leer los metadatos sin la contraseña de apertura?**

Sí, pero solo cuando la presentación se cifró con el cifrado de propiedades del documento desactivado. La aplicación debe entonces usar el modo de carga solo de propiedades del documento descrito en [Manage Presentation Properties](/slides/es/php-java/presentation-properties/).

**¿Los flujos de trabajo de comprobación de contraseña son compatibles tanto con PPT como con PPTX?**

Sí. La detección y validación de contraseñas basada en rutas de archivo y en flujos se comportan de la misma manera para presentaciones PPT y PPTX.