---
title: Digital Signature in PowerPoint
type: docs
weight: 10
url: /net/digital-signature-in-powerpoint/
keywords: "Digital signature certificate, certificate authority"
description: "Add digital signature certificate, certificate authority into PowerPoint presentation with Aspose.Slides."
---


**Digital certificate** is used to create a password protected powerpoint presentation, marked as created by a particular organization or person. Digital certificate can be obtained by contacting an authorized organization - a certificate authority. After installing digital certificate into the system, it can be used to add a digital signature to the presentation via File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Presentation may contain more than one digital signatures. After the digital signature is added to the presentation, a special message will appear in the PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



To sign presentation or check the authenticity of presentation signatures, **Aspose.Slides API** provides [**IDigitalSignature** ](https://apireference.aspose.com/net/slides/aspose.slides/idigitalsignature)interface, [**IDigitalSignatureCollection** ](https://apireference.aspose.com/net/slides/aspose.slides/IDigitalSignatureCollection)interface and[ **IPresentation.DigitalSignatures**](https://apireference.aspose.com/net/slides/aspose.slides/ipresentation/properties/digitalsignatures) property. Currently, digital signatures are supported for PPTX format only.
## **Add Digital Signature from PFX Certificate**
The code sample below demonstrates how to add digital signature from a PFX certificate:

1. Open PFX file and pass PFX password to [**DigitalSignature** ](https://apireference.aspose.com/net/slides/aspose.slides/digitalsignature)object.
1. Add created signature to the presentation object.

{{< gist "aspose-com-gists" "111e222692fbbcd3b6015105d871a492" "Add-Digital-Signature-to-Presentation-with-Aspose-Slides.cs" >}}



Now its possible to check if the presentation was digitally signed and has not been modified:



{{< gist "aspose-com-gists" "de2e7e1e2401abf9a906b3b7fedaf8d8" "Check-Digitally-Signed-Presentation-with-Aspose-Slides.cs" >}}
