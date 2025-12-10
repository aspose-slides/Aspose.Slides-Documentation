---
title: Agregar firmas digitales a presentaciones en Java
linktitle: Firma digital
type: docs
weight: 10
url: /es/java/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad certificadora
- certificado PFX
- PowerPoint
- OpenDocument
- presentación
- Java
- Aspose.Slides
description: "Aprenda a firmar digitalmente archivos PowerPoint y OpenDocument con Aspose.Slides para Java. Proteja sus diapositivas en segundos con claros ejemplos de código."
---

**Certificado digital** se utiliza para crear una presentación de PowerPoint protegida con contraseña, marcada como creada por una organización o persona específica. El certificado digital se puede obtener contactando a una organización autorizada, una autoridad certificadora. Después de instalar el certificado digital en el sistema, se puede usar para añadir una firma digital a la presentación mediante Archivo -> Información -> Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Una presentación puede contener más de una firma digital. Después de que se añada la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar una presentación o comprobar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la interfaz [**IDigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignature), la interfaz [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IDigitalSignatureCollection) y el método [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentation#getDigitalSignatures--) . Actualmente, las firmas digitales solo son compatibles con el formato PPTX.

## **Agregar una firma digital desde un certificado PFX**
El siguiente ejemplo de código muestra cómo añadir una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/java/com.aspose.slides/DigitalSignature).
2. Añada la firma creada al objeto de presentación.
```java
// Abriendo el archivo de presentación
Presentation pres = new Presentation();
try {
    // Crear objeto DigitalSignature con archivo PFX y contraseña PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Comentario de nueva firma digital
    signature.setComments("Aspose.Slides digital signing test.");

    // Añadir firma digital a la presentación
    pres.getDigitalSignatures().add(signature);

    // Guardar la presentación
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Ahora es posible comprobar si la presentación está firmada digitalmente y no ha sido modificada:
```java
// Abrir presentación
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Signatures used to sign the presentation: ");

        // Verificar si todas las firmas digitales son válidas
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("Presentation is genuine, all signatures are valid.");
        else
            System.out.println("Presentation has been modified since signing.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales permite [eliminar elementos individuales](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#removeAt-int-) y [limpiarla por completo](https://reference.aspose.com/slides/java/com.aspose.slides/digitalsignaturecollection/#clear--); después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo se vuelve "solo lectura" después de firmar?**

No. Una firma preserva la integridad y la autoría pero no bloquea la edición. Para restringir la edición, combínela con [\"Solo lectura\" o una contraseña](/slides/es/java/password-protected-presentation/).

**¿La firma se mostrará correctamente en diferentes versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran correctamente el estado de dichas firmas.