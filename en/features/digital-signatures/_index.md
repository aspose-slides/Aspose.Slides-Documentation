---
title: Sign presentations digitally
description: Add a certificate-based digital signature to a presentation.
type: docs
url: /features/digital-signatures/
weight: 1330
feature_id: digital-signatures
feature_group: security
translationKey: slides-feature-digital-signatures
feature_catalogue_version: 3
feature_guides:
- /slides/net/digital-signature-in-powerpoint/
---

## **Overview**

Sign a presentation using a certificate and save the signature with a supported presentation format. The signature records information such as the certificate, signing time and comments. Apply it after finishing edits, because later processing can remove the signature.

## **Usage example (C#)**

Install [Aspose.Slides for .NET](/slides/net/installation/) before running this standalone example. Download the [public test certificate](https://raw.githubusercontent.com/aspose-slides/Aspose.Slides-for-.NET/master/Examples/Data/Rendering-Printing/testsignature1.pfx) as testsignature1.pfx in the working directory. Its public example password is testpass1; use it only for demonstrations. Sign the generated deck after editing, then inspect the signature on the reopened file.

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
Console.WriteLine(opened.DigitalSignatures.Count);
```

## **FAQ**

### **Does the signature protect every property in the file?**

Its coverage has limits, including document-property parts. Signature validity is not a blanket guarantee that every byte or property is unchanged.

### **Which certificate material is required to sign a deck?**

Signing requires a certificate with its private key and access to that key, commonly supplied as a password-protected PFX file. Keep real signing material outside published samples.

### **What happens to a signature after I edit the presentation?**

Later edits or processing can remove or invalidate a signature. Complete edits first, sign the final output and inspect the saved result.

## **Guides**

- [Add Digital Signatures to Presentations in .NET](/slides/net/digital-signature-in-powerpoint/)

Related feature: [Check presentation signatures](/slides/features/check-signatures/).

## Runnable .NET examples

- [Sign and Verify Presentations](/slides/net/examples/protection-signatures/digital-signatures/)
