---
title: Firma Digital en PowerPoint
type: docs
weight: 10
url: /androidjava/digital-signature-in-powerpoint/
keywords: "Certificado de firma digital, autoridad de certificación"
description: "Agregue certificado de firma digital, autoridad de certificación a la presentación de PowerPoint con Aspose.Slides."
---

**El certificado digital** se utiliza para crear una presentación de PowerPoint protegida por contraseña, marcada como creada por una organización o persona en particular. El certificado digital se puede obtener contactando a una organización autorizada - una autoridad de certificación. Después de instalar el certificado digital en el sistema, se puede usar para agregar una firma digital a la presentación a través de Archivo -> Información -> Proteger Presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Después de que se agregue la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar la presentación o verificar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la interfaz [**IDigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignature), la interfaz [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDigitalSignatureCollection) y el método [**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentation#getDigitalSignatures--). Actualmente, las firmas digitales son compatibles solo con el formato PPTX.
## **Agregar Firma Digital desde Certificado PFX**
El siguiente ejemplo de código demuestra cómo agregar una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/DigitalSignature).
1. Agregue la firma creada al objeto de presentación.

```java
// Abrir el archivo de presentación
Presentation pres = new Presentation();
try {
    // Crear objeto DigitalSignature con archivo PFX y contraseña PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", "testpass1");

    // Comentario sobre la nueva firma digital
    signature.setComments("Prueba de firma digital de Aspose.Slides.");

    // Agregar firma digital a la presentación
    pres.getDigitalSignatures().add(signature);

    // Guardar presentación
    pres.save("SomePresentationSigned.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Ahora es posible verificar si la presentación fue firmada digitalmente y no ha sido modificada:

```java
// Abrir presentación
Presentation pres = new Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0)
    {
        boolean allSignaturesAreValid = true;

        System.out.println("Firmas utilizadas para firmar la presentación: ");

        // Verificar si todas las firmas digitales son válidas
        for (IDigitalSignature signature : pres.getDigitalSignatures())
        {
            System.out.println(signature.getComments() + ", "
                    + signature.getSignTime().toString() + " -- " + (signature.isValid() ? "VÁLIDO" : "NO VÁLIDO"));
            allSignaturesAreValid &= signature.isValid();
        }

        if (allSignaturesAreValid)
            System.out.println("La presentación es genuina, todas las firmas son válidas.");
        else
            System.out.println("La presentación ha sido modificada desde la firma.");
    }
} finally {
    if (pres != null) pres.dispose();
}
```