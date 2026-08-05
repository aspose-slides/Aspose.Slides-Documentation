---
title: 在 Java 中向演示文稿添加数字签名
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

数字签名帮助接收者确定是谁签署了演示文稿以及已签名的内容是否已更改。此处涉及的三个相关安全概念如下：

- **数字证书** 是将身份与公钥关联的电子凭证。受信任的证书颁发机构（CA）可以颁发证书，组织也可以使用自签名证书用于内部工作流。
- **数字签名** 由演示文稿内容和证书持有者的私钥生成。随后可使用证书的公钥来验证签名。签名提供来源和完整性的证据；它并不对演示文稿进行加密。
- **密码保护** 控制用户是否可以打开或修改演示文稿。它与数字签名分离，详见[Password-Protected Presentations](/java/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint 保护演示文稿菜单，突出显示“添加数字签名”] (add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可以显示签名状态通知。

![PowerPoint 通知，说明演示文稿包含有效签名] (digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)公开签名，该方法返回一个[IDigitalSignatureCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignaturecollection/)，其项实现[IDigitalSignature](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/)。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件（亦称 PKCS#12 文件，通常使用 `.pfx` 或 `.p12` 扩展名）可以包含 X.509 证书、其私钥以及证书链。私钥使持有者能够创建签名。没有可访问私钥的证书无法用于签署演示文稿。

PFX 密码保护证书包和私钥。它 **不是** 用于打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理。生产环境中应限制对证书文件的访问，并从密钥库或其他受保护的配置源获取密码。下面的示例仅使用环境变量，以避免在代码中嵌入密码。

## **向演示文稿添加数字签名**

要在实际工作流中签名演示文稿，请加载现有 PPTX 文件，从 PFX 证书及其密码创建[DigitalSignature](https://reference.aspose.com/slides/zh/java/com.aspose.slides/digitalsignature/)，将签名添加到演示文稿的集合中，然后保存为 PPTX 文件。

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

将结果另存为新名称可保留未签名的源文件。使用[IDigitalSignature.setComments](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/#setComments-java.lang.String-)设置的值描述签名的用途；它不是安全控制手段。

## **验证数字签名**

加载已签名的 PPTX 文件后，检查[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getDigitalSignatures--)返回的每一项。[IDigitalSignature.isValid](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/#isValid--) 方法指示嵌入的签名对于当前演示文稿内容是否有效。

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

无效结果通常意味着签名后演示文稿内容或签名数据已更改，或文件已损坏。删除所有签名会得到未签名的演示文稿，因此仅检查项的有效性不足：安全敏感的工作流还必须验证预期的签名数量和预期的签署人身份是否存在。

此有效性结果不应被视为完整的证书信任决策。根据安全策略，应用程序可能还需要构建并验证 X.509 证书链，检查证书有效期和撤销状态，确认预期的主体或指纹，验证密钥用法，并评估受信任的时间戳。[IDigitalSignature.getSignTime](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignature/#getSignTime--) 的值本身并非受信任时间戳权威的凭证。

## **移除数字签名**

移除签名会改变演示文稿的安全状态。下面的示例加载已签名的 PPTX 文件，使用[IDigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignaturecollection/#clear--) 删除所有签名，并保存为未签名的副本。

```java
Presentation presentation = new Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若只移除单个签名，请使用其基于零的索引调用[IDigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/idigitalsignaturecollection/#removeAt-int-)。除非工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑与格式注意事项**

- 签名并不会将演示文稿设为只读。用户和应用程序仍然可以编辑文件，但对已签名内容的更改通常会使现有签名失效。
- 在签名之前完成所有预期的编辑。如果必须更改演示文稿，请保存修改后的版本并再次签名。
- 保持最终输出为 PPTX 格式。将已签名的演示文稿转换为其他格式不会将原始 PPTX 签名作为有效签名转移到转换后的文件中。
- 将证书私钥视为敏感信息。获取私钥及其密码的任何人都可能创建看似来自该证书持有者的签名。
- 当文档保留策略要求时，保留未签名的源文件或其他受控副本。

## **常见问答**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但演示文稿内容仍可阅读，除非另行加密。需要限制内容访问时请使用[密码保护](/java/password-protected-presentation/)。

**PFX 密码与演示文稿密码是同一个吗？**

不是。PFX 密码用于解锁存储在证书包中的私钥。它不控制谁可以打开或编辑 PPTX 文件。

**可以使用自签名证书吗？**

技术上，只要自签名证书包含可访问的私钥即可使用。但收件人不会自动信任它，除非该证书已显式加入其受信任环境。公共或跨组织工作流通常使用受信任 CA 颁发的证书。

**什么会导致签名无效？**

在签名后更改已签名的演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果所有签名都被删除，演示文稿变为未签名，而不是包含无效签名的文件。

**有效签名是否意味着应当信任签署人？**

仅凭签名本身不能。签名完整性与签署人信任是独立的决定。生产环境的验证策略应同时检查证书链、有效期、撤销状态、预期身份、密钥用法以及任何受信任时间戳要求。

**证书过期会怎样？**

证书过期不会改变演示文稿的字节，但会影响证书信任评估。签名是否仍然可接受取决于您的策略以及是否有有效的受信任时间戳证明签署发生在证书有效期间。不要仅凭显示的签署时间作为受信任时间戳。

**已签名的演示文稿还能编辑吗？**

可以。签名不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿并对最终修订进行签名。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到[IPresentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ipresentation/#getDigitalSignatures--) 返回的集合中。验证时检查每个签名并确认所有必需的签署人已出现。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文描述的数字签名操作。PPT 和 OpenDocument 演示文稿格式不受此 API 工作流支持。

**移除签名会影响幻灯片内容吗？**

不会。您可以移除单个签名或清除整个集合后再保存演示文稿。幻灯片内容仍然保留，只是保存的文件不再携带已移除的签名证据。