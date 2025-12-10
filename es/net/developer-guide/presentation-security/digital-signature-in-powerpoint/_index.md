---
title: Añadir firmas digitales a presentaciones en .NET
linktitle: Firma digital
type: docs
weight: 10
url: /es/net/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad de certificación
- certificado PFX
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Aprenda cómo firmar digitalmente archivos PowerPoint y OpenDocument con Aspose.Slides para .NET. Asegure sus diapositivas en segundos con ejemplos de código claros."
---

**Certificado digital** se utiliza para crear una presentación de PowerPoint protegida con contraseña, marcada como creada por una organización o persona específica. El certificado digital puede obtenerse contactando a una organización autorizada, una autoridad de certificación. Después de instalar el certificado digital en el sistema, puede usarse para añadir una firma digital a la presentación a través de Archivo -> Información -> Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

Una presentación puede contener más de una firma digital. Después de que se añade la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar una presentación o verificar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la interfaz [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)interface, la interfaz [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)interface y la propiedad [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures)property. Actualmente, las firmas digitales solo se admiten para el formato PPTX.

## **Agregar una firma digital desde un certificado PFX**
El siguiente ejemplo de código muestra cómo agregar una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature) objeto.
2. Añada la firma creada al objeto de la presentación.
```c#
using (Presentation pres = new Presentation())
{
    // Crear objeto DigitalSignature con archivo PFX y contraseña PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Comentario de la nueva firma digital
    signature.Comments = "Aspose.Slides digital signing test.";

    // Añadir firma digital a la presentación
    pres.DigitalSignatures.Add(signature);

    // Guardar presentación
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


Ahora es posible comprobar si la presentación está firmada digitalmente y no ha sido modificada:
```c#
// Abrir presentación
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // Verificar si todas las firmas digitales son válidas
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```


## **Preguntas frecuentes**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales admite [eliminar elementos individuales](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) y [borrarla por completo](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo se vuelve "solo lectura" después de firmar?**

No. Una firma preserva la integridad y la autoría, pero no bloquea las ediciones. Para restringir la edición, combínela con ["Solo lectura" o una contraseña](/slides/es/net/password-protected-presentation/).

**¿La firma se mostrará correctamente en diferentes versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran correctamente el estado de dichas firmas.