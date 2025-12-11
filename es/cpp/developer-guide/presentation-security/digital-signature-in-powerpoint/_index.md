---
title: Agregar firmas digitales a presentaciones en C++
linktitle: Firma digital
type: docs
weight: 10
url: /es/cpp/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad certificadora
- certificado PFX
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda a firmar digitalmente archivos PowerPoint y OpenDocument con Aspose.Slides para C++. Proteja sus diapositivas en segundos con ejemplos de código claros."
---

**Certificado digital** se utiliza para crear una presentación de PowerPoint protegida con contraseña, marcada como creada por una organización o persona específica. El certificado digital puede obtenerse contactando a una organización autorizada, una autoridad certificadora. Después de instalar el certificado digital en el sistema, se puede usar para añadir una firma digital a la presentación mediante Archivo -> Información -> Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Después de que la firma digital se añada a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar la presentación o comprobar la autenticidad de las firmas de la presentación, **Aspose.Slides API** proporciona la interfaz[**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature), la interfaz[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) y el método[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Actualmente, las firmas digitales solo son compatibles con el formato PPTX.

## **Agregar una firma digital desde un certificado PFX**
El siguiente ejemplo de código muestra cómo agregar una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña PFX al objeto[**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature).
2. Añada la firma creada al objeto de la presentación.
``` cpp
auto pres = System::MakeObject<Presentation>();

// Crear objeto DigitalSignature con archivo PFX y contraseña PFX
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Comentario de la nueva firma digital
signature->set_Comments(u"Aspose.Slides digital signing test.");

// Agregar firma digital a la presentación
pres->get_DigitalSignatures()->Add(signature);

// Guardar presentación
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```


Ahora es posible comprobar si la presentación fue firmada digitalmente y no ha sido modificada:
``` cpp
// Abrir presentación
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // Verificar si todas las firmas digitales son válidas
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales permite [eliminar elementos individuales](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/removeat/) y [borrarla completamente](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/clear/); después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo se vuelve \"solo lectura\" después de firmarlo?**

No. Una firma preserva la integridad y la autoría pero no bloquea la edición. Para restringir la edición, combínela con [\"Solo lectura\" o una contraseña](/slides/es/cpp/password-protected-presentation/).

**¿La firma se mostrará correctamente en diferentes versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran el estado de dichas firmas correctamente.