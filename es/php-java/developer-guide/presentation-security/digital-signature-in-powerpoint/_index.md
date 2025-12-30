---
title: Añadir firmas digitales a presentaciones en PHP
linktitle: Firma digital
type: docs
weight: 10
url: /es/php-java/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad certificadora
- certificado PFX
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Aprenda cómo firmar digitalmente archivos PowerPoint y OpenDocument con Aspose.Slides para PHP a través de Java. Proteja sus diapositivas en segundos con ejemplos de código claros."
---

**Certificado digital** se utiliza para crear una presentación de PowerPoint protegida con contraseña, marcada como creada por una organización o persona concreta. El certificado digital puede obtenerse poniéndose en contacto con una entidad autorizada, una autoridad certificadora. Tras instalar el certificado digital en el sistema, puede usarse para añadir una firma digital a la presentación mediante Archivo → Info → Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Tras añadir la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar la presentación o comprobar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la interfaz [**IDigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignature), la interfaz [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignatureCollection) y el método [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getDigitalSignatures--) . Actualmente, las firmas digitales solo son compatibles con el formato PPTX.

## **Añadir una firma digital a partir de un certificado PFX**
El fragmento de código a continuación demuestra cómo añadir una firma digital a partir de un certificado PFX:

1. Abra el archivo PFX y pase la contraseña del PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature).
1. Añada la firma creada al objeto de la presentación.
```php
  # Abriendo el archivo de presentación
  $pres = new Presentation();
  try {
    # Crear objeto DigitalSignature con archivo PFX y contraseña PFX
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # Comentario de la nueva firma digital
    $signature->setComments("Aspose.Slides digital signing test.");
    # Agregar firma digital a la presentación
    $pres->getDigitalSignatures()->add($signature);
    # Guardar la presentación
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


Ahora es posible comprobar si la presentación está firmada digitalmente y no ha sido modificada:
```php
  # Abrir presentación
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # Comprobar si todas las firmas digitales son válidas
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales permite [eliminar elementos individuales](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) y [vaciarla por completo](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/); después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo queda “solo lectura” después de firmarlo?**

No. Una firma preserva la integridad y la autoría, pero no bloquea la edición. Para restringir la edición, combínela con ["Solo lectura" o una contraseña](/slides/es/php-java/password-protected-presentation/).

**¿La firma se mostrará correctamente en diferentes versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran el estado de dichas firmas correctamente.