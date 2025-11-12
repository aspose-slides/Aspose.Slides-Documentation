---
title: Agregar firmas digitales a presentaciones con Python
linktitle: Firma digital
type: docs
weight: 10
url: /es/python-net/digital-signature-in-powerpoint/
keywords:
- firma digital
- certificado digital
- autoridad certificadora
- certificado PFX
- PowerPoint
- OpenDocument
- presentación
- Python
- Aspose.Slides
description: "Aprenda cómo firmar digitalmente archivos PowerPoint y OpenDocument con Aspose.Slides para Python mediante .NET. Asegure sus diapositivas en segundos con ejemplos de código claros."
---

**Certificado digital** se utiliza para crear una presentación PowerPoint protegida con contraseña, marcada como creada por una organización o persona específica. El certificado digital puede obtenerse contactando a una organización autorizada, una autoridad certificadora. Después de instalar el certificado digital en el sistema, puede usarse para añadir una firma digital a la presentación mediante Archivo → Información → Proteger presentación:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

La presentación puede contener más de una firma digital. Después de que se añada la firma digital a la presentación, aparecerá un mensaje especial en PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

Para firmar una presentación o comprobar la autenticidad de las firmas de la presentación, la **API de Aspose.Slides** proporciona la interfaz [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) , la interfaz [**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) y la propiedad [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/). Actualmente, las firmas digitales solo son compatibles con el formato PPTX.

## **Agregar firma digital desde certificado PFX**

El siguiente ejemplo de código muestra cómo añadir una firma digital desde un certificado PFX:

1. Abra el archivo PFX y pase la contraseña PFX al objeto [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) .
2. Añada la firma creada al objeto de la presentación.

```py
#[TODO:Exception] RuntimeError: Error de proxy (FileNotFoundException): No se pudo cargar el archivo o ensamblado 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. No se encontró el archivo.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Crear objeto DigitalSignature con archivo PFX y contraseña PFX
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comentario de la nueva firma digital
    signature.comments = "Aspose.Slides digital signing test."

    # Añadir firma digital a la presentación
    pres.digital_signatures.add(signature)

    # Guardar presentación
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

Ahora es posible comprobar si la presentación está firmada digitalmente y no ha sido modificada:

```py
# Abrir presentación
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Firmas usadas para firmar la presentación: ")
        # Comprobar si todas las firmas digitales son válidas
        for signature in pres.digital_signatures:
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid

        if allSignaturesAreValid:
            print("La presentación es genuina, todas las firmas son válidas.")
        else:
            print("La presentación ha sido modificada desde la firma.")
```

## **Preguntas frecuentes**

**¿Puedo eliminar firmas existentes de un archivo?**

Sí. La colección de firmas digitales admite [eliminar elementos individuales](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) y [borrarla por completo](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); después de guardar el archivo, la presentación no tendrá firmas.

**¿El archivo pasa a ser "solo lectura" después de firmarlo?**

No. Una firma preserva la integridad y la autoría pero no impide las ediciones. Para restringir la edición, combínela con ["Solo lectura" o una contraseña](/slides/es/python-net/password-protected-presentation/).

**¿La firma se mostrará correctamente en diferentes versiones de PowerPoint?**

La firma se crea para el contenedor OOXML (PPTX). Las versiones modernas de PowerPoint que admiten firmas OOXML muestran correctamente el estado de dichas firmas.