---
title: Firma digital en PowerPoint
type: docs
weight: 10
url: /cpp/digital-signature-in-powerpoint/
keywords: "Certificado de firma digital, autoridad certificadora"
description: "Agregue un certificado de firma digital y una autoridad certificadora a la presentación de PowerPoint con Aspose.Slides."
---

**Certificado digital** se utiliza para crear una presentación de PowerPoint protegida por contraseña, marcada como creada por una organización o persona en particular. El certificado digital puede obtenerse contactando a una organización autorizada - una autoridad certificadora. Después de instalar el certificado digital en el sistema, se puede utilizar para agregar una firma digital a la presentación a través de Archivo -> Info -> Proteger Presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Después de que se agrega la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar la presentación o verificar la autenticidad de las firmas en la presentación, **Aspose.Slides API** proporciona la interfaz [**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature), la interfaz [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection) y el método [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1). Actualmente, las firmas digitales son compatibles solo con el formato PPTX.
## **Agregar Firma Digital desde Certificado PFX**
El siguiente ejemplo de código demuestra cómo agregar una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature).
1. Agregue la firma creada al objeto de presentación.

``` cpp
auto pres = System::MakeObject<Presentation>();

// Crear objeto DigitalSignature con archivo PFX y contraseña PFX 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// Comentar nueva firma digital
signature->set_Comments(u"Prueba de firma digital de Aspose.Slides.");

// Agregar firma digital a la presentación
pres->get_DigitalSignatures()->Add(signature);

// Guardar presentación
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

Ahora es posible verificar si la presentación fue firmada digitalmente y no ha sido modificada:

``` cpp
// Abrir presentación
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Firmas utilizadas para firmar la presentación: ");

    // Verificar si todas las firmas digitales son válidas
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VÁLIDO") : System::String(u"INVALIDO")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"La presentación es genuina, todas las firmas son válidas.");
    }
    else
    {
        Console::WriteLine(u"La presentación ha sido modificada desde la firma.");
    }
}
```