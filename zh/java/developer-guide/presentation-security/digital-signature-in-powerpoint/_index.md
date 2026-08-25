---
title: 在 Java 中为演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/java/digital-signature-in-powerpoint/
keywords:
- 数字签名
- 数字证书
- 证书颁发机构
- PFX 证书
- PKCS#12
- 验证签名
- PowerPoint
- PPTX
- 演示文稿安全
- Java
- Aspose.Slides
description: "了解如何使用 PFX 证书对现有 PPTX 演示文稿进行签名，并使用 Aspose.Slides for Java 验证或移除数字签名。"
---
## **概述**

数字签名帮助收件人确定演示文稿是谁签署的以及签署后内容是否被更改。这里有三个相关的安全概念：

- **数字证书** 是一种将身份与公钥关联的电子凭证。受信任的证书颁发机构（CA）可以颁发证书，组织也可以使用自签名证书用于内部工作流。
- **数字签名** 是根据演示文稿内容和证书持有者的私钥创建的。然后可以使用证书的公钥来验证签名。签名提供来源和完整性证据；它不会加密演示文稿。
- **密码保护** 控制用户是否可以打开或修改演示文稿。它与数字签名独立，详见 [Password-Protected Presentations](/slides/zh/java/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint 保护演示文稿菜单，突出显示“添加数字签名”] (add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可以显示签名状态通知。

![PowerPoint 通知，指示演示文稿包含有效签名] (digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) 暴露签名，该方法返回一个实现了 [IDigitalSignatureCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignaturecollection/) 接口的集合，其项实现了 [IDigitalSignature](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/) 接口。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件（也称为 PKCS#12 文件，通常使用 `.pfx` 或 `.p12` 扩展名）可以包含 X.509 证书、私钥以及证书链。私钥是持有人创建签名的关键。没有可访问私钥的证书无法用于签署演示文稿。

PFX 密码保护证书包及其私钥。它 **不是** 用于打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理。在生产环境中，应限制对证书文件的访问，并从机密存储或其他受保护的配置来源获取密码。下面的示例仅使用环境变量，以避免在代码中嵌入密码。

## **向演示文稿添加数字签名**

要对真实演示文稿进行签名，加载现有 PPTX 文件，使用 PFX 证书及其密码创建一个 [DigitalSignature](https://reference.aspose.com/slides/zh/java/com.aspose.slides/digitalsignature/)，将签名添加到演示文稿的集合中，然后保存为 PPTX 文件。

```java
String certificatePassword = System.getenv("PFX_PASSWORD");
if (certificatePassword == null || certificatePassword.isEmpty()) {
    throw new IllegalStateException("Set the PFX_PASSWORD environment variable.");
}

Presentation presentation = new Presentation("InputPresentation.pptx");
try {
    DigitalSignature signature = new DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

将结果保存为新名称可保留未签名的源文件。通过 [IDigitalSignature.setComments](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-) 设置的值描述签名的目的；它不是安全控制手段。

## **验证数字签名**

加载已签名的 PPTX 文件时，检查由 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) 返回的每个项。 [IDigitalSignature.isValid](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/#isValid--) 方法指示嵌入的签名对当前演示文稿内容是否有效。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    IDigitalSignatureCollection signatures = presentation.getDigitalSignatures();
    int signatureCount = signatures.size();

    if (signatureCount == 0) {
        System.out.println("The presentation does not contain digital signatures.");
    } else {
        boolean allSignaturesAreValid = true;
        java.text.SimpleDateFormat signTimeFormat = new java.text.SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        java.security.cert.CertificateFactory certificateFactory = java.security.cert.CertificateFactory.getInstance("X.509");

        for (IDigitalSignature signature : signatures) {
            boolean signatureIsValid = signature.isValid();
            String signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            java.util.Date signTime = signature.getSignTime();
            String formattedSignTime = signTimeFormat.format(signTime);

            byte[] certificateData = signature.getCertificate();
            java.io.ByteArrayInputStream certificateStream = new java.io.ByteArrayInputStream(certificateData);
            java.security.cert.X509Certificate certificate = (java.security.cert.X509Certificate) certificateFactory.generateCertificate(certificateStream);
            javax.security.auth.x500.X500Principal signerPrincipal = certificate.getSubjectX500Principal();
            String signerName = signerPrincipal.getName();

            System.out.println(signerName + ", " + formattedSignTime + " -- " + signatureStatus);

            allSignaturesAreValid &= signatureIsValid;
        }

        if (allSignaturesAreValid) {
            System.out.println("All embedded signatures are valid for the current presentation.");
        } else {
            System.out.println("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

无效结果通常意味着签名后演示文稿内容或签名数据已更改，或文件已损坏。删除所有签名会生成未签名的演示文稿，仅检查项的有效性不足以满足安全敏感的工作流，还必须验证签名数量和签署者身份是否符合预期。

此有效性结果不应视为完整的证书信任决定。根据安全策略，应用程序可能还需要构建并验证 X.509 证书链，检查证书有效期限和吊销状态，确认预期的主题或指纹，验证密钥用途，并评估受信任的时间戳。仅凭 [IDigitalSignature.getSignTime](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/#getSignTime--) 的值并不能证明来自受信任的时间戳机构。

## **删除数字签名**

删除签名会改变演示文稿的安全状态。下面的示例加载已签名的 PPTX 文件，使用 [IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignaturecollection/#clear--) 删除所有签名，然后保存为未签名的副本。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如需仅删除单个签名，请使用其零基索引调用 [IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-)。除非工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑和格式注意事项**

- 签名并不会使演示文稿只读。用户和应用程序仍然可以编辑文件，但对已签名内容的更改通常会使现有签名失效。
- 在签名之前完成所有预期的编辑。如果需要更改演示文稿，请保存修订后的版本并再次签名。
- 保持最终输出为 PPTX 格式。将已签名的演示文稿转换为其他格式不会将原 PPTX 的签名作为有效签名转移到转换后的文件中。
- 将证书的私钥视为敏感信息。任何获取私钥及其密码的人都可能创建看似来自该证书持有者的签名。
- 当文档保留策略要求时，保留未签名的源文件或其他受控副本。

## **常见问题**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但演示文稿内容仍然可读，除非另行使用加密。需要限制内容访问时，请使用 [password protection](/slides/zh/java/password-protected-presentation/)。

**PFX 密码与演示文稿密码是同一个吗？**

不是。PFX 密码用于解锁存储在证书包中的私钥，它不控制谁可以打开或编辑 PPTX 文件。

**可以使用自签名证书吗？**

在技术上，只要自签名证书包含可访问的私钥就可以使用。但收件人不会自动信任它，除非该证书已显式添加到其受信任环境中。公共或跨组织工作流通常使用受信任 CA 颁发的证书。

**是什么导致签名无效？**

在签名后更改已签名的演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果删除所有签名，演示文稿将变为未签名，而不是包含无效签名的文件。

**有效的签名是否意味着应当信任签署者？**

仅凭签名本身不能决定是否信任签署者。签名完整性和签署者信任是两个独立的判断。生产环境的验证策略还应检查证书链、有效期、吊销状态、预期身份、密钥用途以及任何受信任的时间戳要求。

**证书过期会怎样？**

证书过期不会改变演示文稿的字节内容，但会影响证书信任评估。签名是否仍然可接受取决于您的政策以及是否有有效的受信任时间戳证明签名发生时证书仍然有效。不要仅依据显示的签名时间作为受信任的时间戳。

**已签名的演示文稿还能编辑吗？**

可以。签名不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿的编辑并对最终修订进行签名。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到 [IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) 返回的集合中。验证时检查每个签名并确认所有必需的签署者均已出现。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文所述的数字签名操作。PPT 和 OpenDocument 演示文稿格式不受此 API 工作流支持。

**我能在不影响幻灯片的情况下删除签名吗？**

可以。您可以删除单个签名或清空整个集合，然后保存演示文稿。幻灯片内容仍然保留，但保存后的文件不再携带已删除的签名证据。