---
title: Añadir firmas digitales a presentaciones con Python
linktitle: Firma digital
type: docs
weight: 10
url: /es/python-net/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad de certificación
- certificado PFX
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda a firmar digitalmente archivos PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET. Proteja sus diapositivas en segundos con ejemplos de código claros."
---
## **Introducción**

**El certificado digital** se utiliza para crear una presentación de PowerPoint protegida con contraseña, marcada como creada por una organización o persona concreta. El certificado digital puede obtenerse contactando con una organización autorizada —una autoridad de certificación. Tras instalar el certificado digital en el sistema, puede usarse para añadir una firma digital a la presentación mediante Archivo → Información → Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Después de que la firma digital se añada a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar una presentación o comprobar la autenticidad de las firmas de la presentación, **Aspose.Slides API** ofrece la clase [**DigitalSignature**](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/), la clase [**DigitalSignatureCollection**](https://reference.aspose.com/slides/es/python-net/aspose.slides/DigitalSignatureCollection/) y la propiedad [**Presentation.digital_signatures**](https://reference.aspose.com/slides/es/python-net/aspose.slides/presentation/digital_signatures/). Actualmente, las firmas digitales solo son compatibles con el formato PPTX.

## **Añadir firma digital desde un certificado PFX**

El siguiente ejemplo de código muestra cómo añadir una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña del PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignature/).
1. Añada la firma creada al objeto de presentación.

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    # Crear objeto DigitalSignature con archivo PFX y contraseña PFX 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comentario nueva firma digital
    signature.comments = "Aspose.Slides digital signing test."

    # Añadir firma digital a la presentación
    pres.digital_signatures.add(signature)

    # guardar presentación
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Ahora es posible comprobar si la presentación está firmada digitalmente y no ha sido modificada:

```py
# Abrir presentación
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Comprobar si todas las firmas digitales son válidas
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **Preguntas frecuentes**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales permite [eliminar elementos individuales](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignaturecollection/remove_at/) y [vaciarla por completo](https://reference.aspose.com/slides/es/python-net/aspose.slides/digitalsignaturecollection/clear/); después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo pasa a ser “solo lectura” tras la firma?**

No. Una firma conserva la integridad y la autoría, pero no impide las ediciones. Para restringir la edición, combínela con ["Read-only" or a password](/slides/es/python-net/password-protected-presentation/).

**¿La firma se mostrará correctamente en distintas versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran el estado de dichas firmas correctamente.