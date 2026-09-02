---
title: เพิ่มลายเซ็นดิจิทัลในงานนำเสนอด้วย .NET
linktitle: ลายเซ็นดิจิทัล
type: docs
weight: 10
url: /th/net/digital-signature-in-powerpoint/
keywords:
- ลายเซ็นดิจิทัล
- ใบรับรองดิจิทัล
- หน่วยรับรองใบรับรอง
- ใบรับรอง PFX
- PKCS#12
- ตรวจสอบลายเซ็น
- PowerPoint
- PPTX
- ความปลอดภัยของงานนำเสนอ
- .NET
- C#
- Aspose.Slides
description: "เรียนรู้วิธีการลงลายเซ็นในงานนำเสนอ PPTX ที่มีอยู่ด้วยใบรับรอง PFX และใช้ Aspose.Slides สำหรับ .NET เพื่อทำการตรวจสอบหรือเอาลายเซ็นดิจิทัลออก"
---
## **ภาพรวม**

ลายเซ็นดิจิทัลช่วยให้ผู้รับสามารถระบุได้ว่าใครเป็นผู้ลงนามในงานนำเสนอและเนื้อหาที่ลงนามนั้นมีการเปลี่ยนแปลงหรือไม่ มีแนวคิดด้านความปลอดภัยที่เกี่ยวข้องสามอย่างที่สำคัญในที่นี้:

- A **digital certificate** is an electronic credential that associates an identity with a public key. A trusted certificate authority (CA) can issue a certificate, or an organization can use a self-signed certificate for internal workflows.
- A **digital signature** is created from the presentation content and the certificate holder's private key. The certificate's public key can then be used to verify the signature. A signature provides evidence of origin and integrity; it does not encrypt the presentation.
- **Password protection** controls whether a user can open or modify a presentation. It is separate from digital signing and is described in [การป้องกันโดยใช้รหัสผ่าน](/net/password-protected-presentation/).

PowerPoint provides the **Add a Digital Signature** command under **File > Info > Protect Presentation**.

![เมนู Protect Presentation ของ PowerPoint พร้อมไฮไลท์ Add a Digital Signature](add-digital-signature-in-powerpoint.png)

After a signed presentation is opened, PowerPoint can display a signature-status notification.

![การแจ้งเตือนของ PowerPoint บ่งชี้ว่าการนำเสนอมีลายเซ็นที่ถูกต้อง](digital-signature-status-in-powerpoint.png)

Aspose.Slides exposes signatures through [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/digitalsignatures/), an [IDigitalSignatureCollection](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignaturecollection/) whose items implement [IDigitalSignature](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignature/). A presentation can contain multiple signatures.

## **ทำความเข้าใจใบรับรอง PFX และรหัสผ่าน**

A PFX file, also known as a PKCS#12 file and commonly given a `.pfx` or `.p12` extension, can contain an X.509 certificate, its private key, and the certificate chain. The private key is what allows the holder to create a signature. A certificate without an accessible private key cannot be used to sign a presentation.

The PFX password protects the certificate package and private key. It is **not** a password for opening or editing the presentation. Do not commit PFX files or their passwords to source control. In production, limit access to the certificate file and obtain its password from a secret store or another protected configuration source. The examples below use an environment variable only to avoid embedding the password in code.

## **เพิ่มลายเซ็นดิจิทัลลงในงานนำเสนอ**

To sign a real presentation workflow, load an existing PPTX file, create a [DigitalSignature](https://reference.aspose.com/slides/th/net/aspose.slides/digitalsignature/) from a PFX certificate and its password, add the signature to the presentation's collection, and save to a PPTX file.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

var certificatePassword = Environment.GetEnvironmentVariable("PFX_PASSWORD")
    ?? throw new InvalidOperationException("Set the PFX_PASSWORD environment variable.");

using var presentation = new Presentation("InputPresentation.pptx");

var signature = new DigitalSignature("signing-certificate.pfx", certificatePassword)
{
    Comments = "Approved for release."
};

presentation.DigitalSignatures.Add(signature);
presentation.Save("InputPresentation-signed.pptx", SaveFormat.Pptx);
```

Saving the result under a new name preserves the unsigned source file. The [DigitalSignature.Comments](https://reference.aspose.com/slides/th/net/aspose.slides/digitalsignature/comments/) value describes the purpose of the signature; it is not a security control.

## **ตรวจสอบลายเซ็นดิจิทัล**

When you load a signed PPTX file, inspect every item in [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/digitalsignatures/). The [IDigitalSignature.IsValid](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignature/isvalid/) property indicates whether the embedded signature is valid for the current presentation content.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("InputPresentation-signed.pptx");

var signatureCount = presentation.DigitalSignatures.Count;

if (signatureCount == 0)
{
    Console.WriteLine("The presentation does not contain digital signatures.");
}
else
{
    var allSignaturesAreValid = true;

    foreach (var signature in presentation.DigitalSignatures)
    {
        var signatureStatus = signature.IsValid ? "VALID" : "INVALID";
        var signerName = signature.Certificate.SubjectName.Name;

        Console.WriteLine(
            $"{signerName}, {signature.SignTime:yyyy-MM-dd HH:mm:ss} -- {signatureStatus}");

        allSignaturesAreValid &= signature.IsValid;
    }

    Console.WriteLine(allSignaturesAreValid
        ? "All embedded signatures are valid for the current presentation."
        : "At least one embedded signature is invalid.");
}
```

An invalid result commonly means that the signed presentation content or signature data changed after signing, or that the file is damaged. Removing every signature produces an unsigned presentation, so checking only the validity of items is not enough: a security-sensitive workflow must also verify that the expected number of signatures and expected signer identities are present.

This validity result should not be treated as a complete certificate-trust decision. Depending on your security policy, your application may also need to build and validate the X.509 certificate chain, check certificate validity dates and revocation status, confirm the expected subject or thumbprint, verify key usage, and evaluate a trusted timestamp. The [IDigitalSignature.SignTime](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignature/signtime/) value by itself is not proof from a trusted timestamp authority.

## **ลบลายเซ็นดิจิทัล**

Removing signatures changes the presentation's security state. The following example loads a signed PPTX file, removes all signatures with [IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignaturecollection/clear/), and saves an unsigned copy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

To remove only one signature, call [IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/th/net/aspose.slides/idigitalsignaturecollection/removeat/) with its zero-based index. Save to a new file unless overwriting the signed original is an explicit part of your workflow.

## **การแก้ไขและข้อพิจารณารูปแบบ**

- A signature does not make a presentation read-only. Users and applications can still edit the file, but changes to signed content normally invalidate the existing signature.
- Complete all intended edits before signing. If a presentation must be changed, save the revised presentation and sign that revision again.
- Keep the final output in PPTX format. Converting a signed presentation to another format does not transfer the original PPTX signature as a valid signature for the converted file.
- Treat the certificate's private key as sensitive. Anyone who obtains the private key and its password may be able to create signatures that appear to come from that certificate holder.
- Retain the unsigned source or another controlled copy when your document-retention policy requires it.

## **คำถามที่พบบ่อย**

**Does a digital signature encrypt the presentation?**

No. A digital signature provides evidence about origin and integrity, but presentation content remains readable unless separate encryption is applied. Use [การป้องกันโดยใช้รหัสผ่าน](/net/password-protected-presentation/) when access to the content must be restricted.

**Is the PFX password the same as a presentation password?**

No. The PFX password unlocks the private key stored in the certificate package. It does not control who can open or edit the PPTX file.

**Can I use a self-signed certificate?**

Technically, a self-signed certificate can be used when it includes an accessible private key. Recipients will not automatically trust it, however, unless that certificate has been explicitly added to their trusted environment. Public or cross-organization workflows generally use a certificate issued by a trusted CA.

**What makes a signature invalid?**

Changing signed presentation content or the signature data after signing can invalidate the signature. File corruption can also cause validation to fail. If all signatures are removed, the presentation is unsigned rather than a file containing an invalid signature.

**Does a valid signature mean that I should trust the signer?**

Not by itself. Signature integrity and signer trust are separate decisions. A production validation policy should also check the certificate chain, validity period, revocation status, expected identity, key usage, and any trusted timestamp requirements.

**What happens when the certificate expires?**

Certificate expiration does not alter the presentation bytes, but it affects certificate-trust evaluation. Whether a signature remains acceptable depends on your policy and on whether a valid trusted timestamp proves that signing occurred while the certificate was valid. Do not rely on the displayed signing time alone as a trusted timestamp.

**Can a signed presentation still be edited?**

Yes. Signing does not lock the file. Editing signed content generally makes the existing signature invalid, so finish the presentation first and sign the final revision.

**Can a presentation contain more than one signature?**

Yes. Add each signature to [IPresentation.DigitalSignatures](https://reference.aspose.com/slides/th/net/aspose.slides/ipresentation/digitalsignatures/) before saving. During validation, inspect every signature and confirm that all required signers are present.

**Which presentation formats support these operations?**

Aspose.Slides supports the digital-signature operations described here only for PPTX. PPT and OpenDocument presentation formats are not supported by this API workflow.

**Can I remove a signature without affecting the slides?**

Yes. You can remove one signature or clear the entire collection and then save the presentation. The slide content remains available, but the saved file no longer carries the removed signature evidence.