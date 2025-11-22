---
title: Firma digital en PowerPoint
type: docs
weight: 10
url: /es/net/digital-signature-in-powerpoint/
keywords: "Certificado de firma digital, autoridad de certificación, presentación PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Agregar firma digital o certificado en PowerPoint. Autoridad de certificación en C# o .NET"
---

**Digital certificate** se utiliza para crear una presentación de PowerPoint protegida con contraseña, marcada como creada por una organización o persona específica. El certificado digital puede obtenerse contactando a una organización autorizada, una autoridad certificadora. Después de instalar el certificado digital en el sistema, puede usarse para añadir una firma digital a la presentación mediante Archivo -> Información -> Proteger Presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Después de que se añada la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar la presentación o verificar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la interface [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)interface, [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)interface y[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) property. Actualmente, las firmas digitales solo son compatibles con el formato PPTX.

## **Agregar firma digital desde certificado PFX**
El siguiente ejemplo de código muestra cómo añadir una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña PFX a [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)object.
2. Añada la firma creada al objeto de presentación.
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


## **FAQ**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales admite [eliminar elementos individuales](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/) y [vaciarla completamente](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/); después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo se vuelve "solo lectura" después de firmar?**

No. Una firma preserva la integridad y la autoría pero no bloquea la edición. Para restringir la edición, combínela con [\"Solo lectura\" o una contraseña](/slides/es/net/password-protected-presentation/).

**¿La firma se mostrará correctamente en diferentes versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran correctamente el estado de dichas firmas.