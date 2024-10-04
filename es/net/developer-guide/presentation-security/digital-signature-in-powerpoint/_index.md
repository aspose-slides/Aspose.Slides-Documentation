---
title: Firma Digital en PowerPoint
type: docs
weight: 10
url: /es/net/digital-signature-in-powerpoint/
keywords: "Certificado de firma digital, autoridad de certificación, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Añadir firma digital o certificado en PowerPoint. Autoridad de certificación en C# o .NET"
---


**Certificado digital** se utiliza para crear una presentación de PowerPoint protegida por contraseña, marcada como creada por una organización o persona en particular. El certificado digital se puede obtener contactando a una organización autorizada - una autoridad de certificación. Después de instalar el certificado digital en el sistema, se puede usar para agregar una firma digital a la presentación a través de Archivo -> Información -> Proteger Presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



La presentación puede contener más de una firma digital. Después de que se agrega la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



Para firmar la presentación o verificar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona [**IDigitalSignature** ](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)interfaz, [**IDigitalSignatureCollection** ](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)interfaz y [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) propiedad. Actualmente, las firmas digitales son compatibles solo con el formato PPTX.
## **Agregar Firma Digital desde Certificado PFX**
El siguiente ejemplo de código demuestra cómo agregar una firma digital desde un certificado PFX:

1. Abrir el archivo PFX y pasar la contraseña PFX al [**DigitalSignature** ](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)objeto.
1. Agregar la firma creada al objeto de presentación.

```c#
using (Presentation pres = new Presentation())
{
    // Crear objeto DigitalSignature con archivo PFX y contraseña PFX 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // Comentar nueva firma digital
    signature.Comments = "Prueba de firma digital de Aspose.Slides.";

    // Agregar firma digital a la presentación
    pres.DigitalSignatures.Add(signature);

    // Guardar presentación
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```



Ahora es posible verificar si la presentación fue firmada digitalmente y no ha sido modificada:



```c#
// Abrir presentación
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Firmas utilizadas para firmar la presentación: ");

        // Verificar si todas las firmas digitales son válidas
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VÁLIDA" : "INVALIDA"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("La presentación es genuina, todas las firmas son válidas.");
        else
            Console.WriteLine("La presentación ha sido modificada desde la firma.");
    }
}
```