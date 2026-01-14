---
title: Add Digital Signatures to Presentations with Python
linktitle: Digital Signature
type: docs
weight: 10
url: /python-net/digital-signature-in-powerpoint/
keywords:
- digital signature
- digital certificate
- certificate authority
- PFX certificate
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Learn how to digitally sign PowerPoint & OpenDocument files with Aspose.Slides for Python via .NET. Secure your slides in seconds with clear code examples."
---


**Digital certificate** is used to create a password protected powerpoint presentation, marked as created by a particular organization or person. Digital certificate can be obtained by contacting an authorized organization - a certificate authority. After installing digital certificate into the system, it can be used to add a digital signature to the presentation via File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Presentation may contain more than one digital signatures. After the digital signature is added to the presentation, a special message will appear in the PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



To sign presentation or check the authenticity of presentation signatures, **Aspose.Slides API** provides [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) class, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/DigitalSignatureCollection/) class and [**Presentation.digital_signatures**](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/digital_signatures/) property. Currently, digital signatures are supported for PPTX format only.
## **Add Digital Signature from PFX Certificate**
The code sample below demonstrates how to add digital signature from a PFX certificate:

1. Open PFX file and pass PFX password to [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) object.
1. Add created signature to the presentation object.

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Create DigitalSignature object with PFX file and PFX password 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comment new digital signature
    signature.comments = "Aspose.Slides digital signing test."

    # Add digital signature to presentation
    pres.digital_signatures.add(signature)

    # save presentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



Now its possible to check if the presentation was digitally signed and has not been modified:



```py
# Open presentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Check if all digital signatures are valid
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **FAQ**

**Can I remove existing signatures from a file?**

Yes. The digital signatures collection supports [removing individual items](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/) and [clearing it entirely](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/); after you save the file, the presentation will have no signatures.

**Does the file become "read-only" after signing?**

No. A signature preserves integrity and authorship but does not block edits. To restrict editing, combine it with ["Read-only" or a password](/slides/python-net/password-protected-presentation/).

**Will the signature display correctly in different versions of PowerPoint?**

The signature is created for the OOXML (PPTX) container. Modern versions of PowerPoint that support OOXML signatures display the status of such signatures correctly.
