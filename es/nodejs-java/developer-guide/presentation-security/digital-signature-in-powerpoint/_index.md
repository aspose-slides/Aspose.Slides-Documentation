---
title: Firma digital en PowerPoint
type: docs
weight: 10
url: /es/nodejs-java/digital-signature-in-powerpoint/
keywords: "Certificado de firma digital, autoridad de certificación"
description: "Añadir certificado de firma digital, autoridad de certificación a la presentación de PowerPoint con Aspose.Slides."
---

**Certificado digital** se usa para crear una presentación de PowerPoint protegida con contraseña, marcada como creada por una organización o persona concreta. El certificado digital puede obtenerse contactando a una organización autorizada, una autoridad de certificación. Después de instalar el certificado digital en el sistema, puede usarse para añadir una firma digital a la presentación mediante Archivo → Información → Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Después de que la firma digital se añade a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar la presentación o comprobar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la clase [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature), la clase [**DigitalSignatureCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignatureCollection) y el método [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) . Actualmente, las firmas digitales solo se admiten para el formato PPTX.

## **Agregar firma digital desde un certificado PFX**
El siguiente ejemplo de código muestra cómo agregar una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña del PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature).
2. Añada la firma creada al objeto de presentación.
```javascript
// Abriendo el archivo de presentación
var pres = new aspose.slides.Presentation();
try {
    // Crear objeto DigitalSignature con archivo PFX y contraseña PFX
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Comentario de la nueva firma digital
    signature.setComments("Aspose.Slides digital signing test.");
    // Añadir firma digital a la presentación
    pres.getDigitalSignatures().add(signature);
    // Guardar presentación
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


Ahora es posible comprobar si la presentación está firmada digitalmente y no ha sido modificada:
```javascript
// Abrir presentación
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Verificar si todas las firmas digitales son válidas
        for (let i = 0; i < pres.getDigitalSignatures().size(); i++) {
        let signature = pres.getDigitalSignatures().get_Item(i);
            console.log((((signature.getComments() + ", ") + signature.getSignTime().toString()) + " -- ") + (signature.isValid() ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.isValid();
        }
        if (allSignaturesAreValid) {
            console.log("Presentation is genuine, all signatures are valid.");
        } else {
            console.log("Presentation has been modified since signing.");
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales permite [eliminar elementos individuales](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/) y [vaciarla por completo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) ; después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo se vuelve “solo lectura” después de firmarlo?**

No. Una firma preserva la integridad y la autoría, pero no bloquea la edición. Para restringir la edición, combínela con ["Solo lectura" o una contraseña](/slides/es/nodejs-java/password-protected-presentation/).

**¿La firma se mostrará correctamente en diferentes versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran el estado de dichas firmas correctamente.