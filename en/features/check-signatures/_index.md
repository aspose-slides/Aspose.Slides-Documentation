---
title: Check presentation signatures
description: Inspect presentation signature validity and certificate details.
type: docs
url: /features/check-signatures/
weight: 1340
feature_id: check-signatures
feature_group: security
translationKey: slides-feature-check-signatures
feature_catalogue_version: 3
feature_guides:
- /slides/net/digital-signature-in-powerpoint/
---

## **Overview**

Read a presentation's signatures and inspect their validity status, certificate metadata, signing time and comments. This helps an application display the signature information exposed by the library. Use the result within the signature format's documented scope.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Download the [public test certificate](https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Rendering-Printing/testsignature1.pfx) as testsignature1.pfx in the working directory. Its public example password is testpass1; use it only for demonstrations. Create a signed fixture, then print each signature's reported validity and certificate subject. This does not establish certificate trust or revocation status.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 500, 140);
shape.AddTextFrame("Sample slide");
var signature = new DigitalSignature("testsignature1.pfx", "testpass1");
signature.Comments = "Public test certificate demonstration";
presentation.DigitalSignatures.Add(signature);
presentation.Save("signed.pptx", SaveFormat.Pptx);
using var opened = new Presentation("signed.pptx");
foreach (var storedSignature in opened.DigitalSignatures)
{
    Console.WriteLine("Reported validity: " + storedSignature.IsValid);
    Console.WriteLine("Certificate subject: " + storedSignature.Certificate.Subject);
}
```

## **FAQ**

### **Does a valid result establish trust in the signer?**

No. Certificate trust-chain checking is separate. Signature coverage also has format and document-part limitations, so validity does not imply that every part was signed.

### **How can I distinguish an unsigned deck from a signed one?**

Check the signature collection count. An empty collection means no signatures are exposed by this workflow.

### **Which certificate metadata can I inspect without establishing trust?**

Read certificate details such as subject, issuer and validity dates. These describe the certificate; trust-chain and revocation checks are separate.

## **Guides**

- [Add Digital Signatures to Presentations in .NET](/slides/net/digital-signature-in-powerpoint/)

Related feature: [Sign presentations digitally](/slides/features/digital-signatures/).
