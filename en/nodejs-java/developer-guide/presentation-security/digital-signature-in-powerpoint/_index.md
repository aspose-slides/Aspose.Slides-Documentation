---
title: Digital Signature in PowerPoint
type: docs
weight: 10
url: /nodejs-java/digital-signature-in-powerpoint/
keywords: "Digital signature certificate, certificate authority"
description: "Add digital signature certificate, certificate authority into PowerPoint presentation with Aspose.Slides."
---


**Digital certificate** is used to create a password protected powerpoint presentation, marked as created by a particular organization or person. Digital certificate can be obtained by contacting an authorized organization - a certificate authority. After installing digital certificate into the system, it can be used to add a digital signature to the presentation via File -> Info -> Protect Presentation:

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



Presentation may contain more than one digital signatures. After the digital signature is added to the presentation, a special message will appear in the PowerPoint:

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



To sign presentation or check the authenticity of presentation signatures, **Aspose.Slides API** provides [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature) class, [**DigitalSignatureCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignatureCollection) class and [**Presentation.getDigitalSignatures**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getDigitalSignatures--) method. Currently, digital signatures are supported for PPTX format only.
## **Add Digital Signature from PFX Certificate**
The code sample below demonstrates how to add digital signature from a PFX certificate:

1. Open PFX file and pass PFX password to [**DigitalSignature**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DigitalSignature) object.
1. Add created signature to the presentation object.

```javascript
// Opening the presentation file
var pres = new aspose.slides.Presentation();
try {
    // Create DigitalSignature object with PFX file and PFX password
    var signature = new aspose.slides.DigitalSignature("testsignature1.pfx", "testpass1");
    // Comment new digital signature
    signature.setComments("Aspose.Slides digital signing test.");
    // Add digital signature to presentation
    pres.getDigitalSignatures().add(signature);
    // Save presentation
    pres.save("SomePresentationSigned.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

Now its possible to check if the presentation was digitally signed and has not been modified:

```javascript
// Open presentation
var pres = new aspose.slides.Presentation("SomePresentationSigned.pptx");
try {
    if (pres.getDigitalSignatures().size() > 0) {
        var allSignaturesAreValid = true;
        console.log("Signatures used to sign the presentation: ");
        // Check if all digital signatures are valid
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
