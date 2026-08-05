---
title: Add Digital Signatures to Presentations in PHP
linktitle: Digital Signature
type: docs
weight: 10
url: /php-java/digital-signature-in-powerpoint/
keywords:
- digital signature
- digital certificate
- certificate authority
- PFX certificate
- PKCS#12
- validate signature
- PowerPoint
- PPTX
- presentation security
- PHP
- Aspose.Slides
description: "Learn how to sign existing PPTX presentations with PFX certificates and use Aspose.Slides for PHP via Java to validate or remove digital signatures."
---

## **Overview**

A digital signature helps a recipient determine who signed a presentation and whether the signed content has changed. Three related security concepts are important here:

- A **digital certificate** is an electronic credential that associates an identity with a public key. A trusted certificate authority (CA) can issue a certificate, or an organization can use a self-signed certificate for internal workflows.
- A **digital signature** is created from the presentation content and the certificate holder's private key. The certificate's public key can then be used to verify the signature. A signature provides evidence of origin and integrity; it does not encrypt the presentation.
- **Password protection** controls whether a user can open or modify a presentation. It is separate from digital signing and is described in [Password-Protected Presentations](/php-java/password-protected-presentation/).

PowerPoint provides the **Add a Digital Signature** command under **File > Info > Protect Presentation**.

![PowerPoint Protect Presentation menu with Add a Digital Signature highlighted](add-digital-signature-in-powerpoint.png)

After a signed presentation is opened, PowerPoint can display a signature-status notification.

![PowerPoint notification stating that the presentation contains valid signatures](digital-signature-status-in-powerpoint.png)

Aspose.Slides exposes signatures through [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDigitalSignatures), which returns a [DigitalSignatureCollection](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/) whose items are represented by [DigitalSignature](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignature/) objects. A presentation can contain multiple signatures.

## **Understand PFX Certificates and Passwords**

A PFX file, also known as a PKCS#12 file and commonly given a `.pfx` or `.p12` extension, can contain an X.509 certificate, its private key, and the certificate chain. The private key is what allows the holder to create a signature. A certificate without an accessible private key cannot be used to sign a presentation.

The PFX password protects the certificate package and private key. It is **not** a password for opening or editing the presentation. Do not commit PFX files or their passwords to source control. In production, limit access to the certificate file and obtain its password from a secret store or another protected configuration source. The examples below use an environment variable only to avoid embedding the password in code.

## **Add a Digital Signature to a Presentation**

To sign a real presentation workflow, load an existing PPTX file, create a [DigitalSignature](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignature/) from a PFX certificate and its password, add the signature to the presentation's collection, and save to a PPTX file.

```php
$certificatePassword = getenv("PFX_PASSWORD");
if ($certificatePassword === false || $certificatePassword === "") {
    throw new RuntimeException("Set the PFX_PASSWORD environment variable.");
}

$presentation = new Presentation("InputPresentation.pptx");
try {
    $signature = new DigitalSignature("signing-certificate.pfx", $certificatePassword);
    $signature->setComments("Approved for release.");

    $presentation->getDigitalSignatures()->add($signature);
    $presentation->save("InputPresentation-signed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Saving the result under a new name preserves the unsigned source file. The value set by [DigitalSignature::setComments](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignature/setcomments/) describes the purpose of the signature; it is not a security control.

## **Validate Digital Signatures**

When you load a signed PPTX file, inspect every item returned by [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDigitalSignatures). The [DigitalSignature::isValid](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignature/isvalid/) method indicates whether the embedded signature is valid for the current presentation content.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $signatures = $presentation->getDigitalSignatures();
    $signatureCount = java_values($signatures->size());

    if ($signatureCount === 0) {
        echo "The presentation does not contain digital signatures." . PHP_EOL;
    } else {
        $allSignaturesAreValid = true;
        $signTimeFormat = new Java("java.text.SimpleDateFormat", "yyyy-MM-dd HH:mm:ss");
        $certificateFactoryClass = new JavaClass("java.security.cert.CertificateFactory");
        $certificateFactory = $certificateFactoryClass->getInstance("X.509");

        for ($index = 0; $index < $signatureCount; $index++) {
            $signature = $signatures->get_Item($index);
            $signatureIsValid = java_values($signature->isValid());
            $signatureStatus = $signatureIsValid ? "VALID" : "INVALID";
            $formattedSignTime = java_values($signTimeFormat->format($signature->getSignTime()));

            $certificateData = $signature->getCertificate();
            $certificateStream = new Java("java.io.ByteArrayInputStream", $certificateData);
            try {
                $certificate = $certificateFactory->generateCertificate($certificateStream);
                $signerName = java_values($certificate->getSubjectX500Principal()->getName());
            } finally {
                $certificateStream->close();
            }

            echo $signerName . ", " . $formattedSignTime . " -- " . $signatureStatus . PHP_EOL;

            $allSignaturesAreValid = $allSignaturesAreValid && $signatureIsValid;
        }

        if ($allSignaturesAreValid) {
            echo "All embedded signatures are valid for the current presentation." . PHP_EOL;
        } else {
            echo "At least one embedded signature is invalid." . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

An invalid result commonly means that the signed presentation content or signature data changed after signing, or that the file is damaged. Removing every signature produces an unsigned presentation, so checking only the validity of items is not enough: a security-sensitive workflow must also verify that the expected number of signatures and expected signer identities are present.

This validity result should not be treated as a complete certificate-trust decision. Depending on your security policy, your application may also need to build and validate the X.509 certificate chain, check certificate validity dates and revocation status, confirm the expected subject or thumbprint, verify key usage, and evaluate a trusted timestamp. The [DigitalSignature::getSignTime](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignature/getsigntime/) value by itself is not proof from a trusted timestamp authority.

## **Remove Digital Signatures**

Removing signatures changes the presentation's security state. The following example loads a signed PPTX file, removes all signatures with [DigitalSignatureCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/), and saves an unsigned copy.

```php
$presentation = new Presentation("InputPresentation-signed.pptx");
try {
    $presentation->getDigitalSignatures()->clear();
    $presentation->save("InputPresentation-unsigned.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

To remove only one signature, call [DigitalSignatureCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) with its zero-based index. Save to a new file unless overwriting the signed original is an explicit part of your workflow.

## **Editing and Format Considerations**

- A signature does not make a presentation read-only. Users and applications can still edit the file, but changes to signed content normally invalidate the existing signature.
- Complete all intended edits before signing. If a presentation must be changed, save the revised presentation and sign that revision again.
- Keep the final output in PPTX format. Converting a signed presentation to another format does not transfer the original PPTX signature as a valid signature for the converted file.
- Treat the certificate's private key as sensitive. Anyone who obtains the private key and its password may be able to create signatures that appear to come from that certificate holder.
- Retain the unsigned source or another controlled copy when your document-retention policy requires it.

## **FAQ**

**Does a digital signature encrypt the presentation?**

No. A digital signature provides evidence about origin and integrity, but presentation content remains readable unless separate encryption is applied. Use [password protection](/php-java/password-protected-presentation/) when access to the content must be restricted.

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

Yes. Add each signature to the collection returned by [Presentation::getDigitalSignatures](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDigitalSignatures) before saving. During validation, inspect every signature and confirm that all required signers are present.

**Which presentation formats support these operations?**

Aspose.Slides supports the digital-signature operations described here only for PPTX. PPT and OpenDocument presentation formats are not supported by this API workflow.

**Can I remove a signature without affecting the slides?**

Yes. You can remove one signature or clear the entire collection and then save the presentation. The slide content remains available, but the saved file no longer carries the removed signature evidence.
