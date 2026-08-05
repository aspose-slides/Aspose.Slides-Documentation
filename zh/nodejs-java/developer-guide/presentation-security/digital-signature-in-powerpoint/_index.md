---
title: 在 JavaScript 中为演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/nodejs-java/digital-signature-in-powerpoint/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "了解如何使用 PFX 证书对现有 PPTX 演示文稿进行签名，并通过 Java 使用 Aspose.Slides for Node.js 来验证或删除数字签名。"
---
## **概述**

数字签名帮助接收者确定是谁签署了演示文稿以及已签署的内容是否已更改。此处涉及的三个相关安全概念如下：

- **数字证书** 是将身份与公钥关联的电子凭证。受信任的证书颁发机构（CA）可以颁发证书，或者组织可以使用自签名证书用于内部工作流。
- **数字签名** 是使用演示文稿内容和证书持有者的私钥创建的。随后可以使用证书的公钥来验证签名。签名提供来源和完整性的证据；它不对演示文稿进行加密。
- **密码保护** 控制用户是否可以打开或修改演示文稿。它与数字签名分离，详见[Password-Protected Presentations](/nodejs-java/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint 保护演示文稿菜单，突出显示“添加数字签名”] (add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可以显示签名状态通知。

![PowerPoint 通知，说明演示文稿包含有效签名] (digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 暴露签名，该方法返回一个包含 [DigitalSignature](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 对象的 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignaturecollection/)。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件，也称为 PKCS#12 文件，通常使用 `.pfx` 或 `.p12` 扩展名，能够包含 X.509 证书、其私钥以及证书链。私钥是持有者创建签名的关键。没有可访问私钥的证书无法用于签署演示文稿。

PFX 密码用于保护证书包和私钥。它 **不是** 用于打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理。在生产环境中，应限制对证书文件的访问，并从密钥库或其他受保护的配置源获取其密码。下面的示例仅使用环境变量以避免在代码中嵌入密码。

## **向演示文稿添加数字签名**

要在真实的演示文稿工作流中签名，加载现有的 PPTX 文件，从 PFX 证书及其密码创建一个 [DigitalSignature](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/)，将该签名添加到演示文稿的集合中，然后保存为 PPTX 文件。

```javascript
const slides = require("aspose.slides.via.java");

const certificatePassword = process.env.PFX_PASSWORD;
if (!certificatePassword) {
    throw new Error("Set the PFX_PASSWORD environment variable.");
}

const presentation = new slides.Presentation("InputPresentation.pptx");
try {
    const signature = new slides.DigitalSignature("signing-certificate.pfx", certificatePassword);
    signature.setComments("Approved for release.");

    presentation.getDigitalSignatures().add(signature);
    presentation.save("InputPresentation-signed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

将结果另存为新名称可保留未签名的源文件。通过 [DigitalSignature.setComments](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 设置的值描述签名的用途；它不是安全控制手段。

## **验证数字签名**

当加载已签名的 PPTX 文件时，检查由 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 返回的每个项。 [DigitalSignature.isValid](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 方法指示嵌入的签名对当前演示文稿内容是否有效。

下面的示例还使用 Node.js 的 `X509Certificate` 类读取每个嵌入证书的主题名称。

```javascript
const { X509Certificate } = require("node:crypto");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    const signatures = presentation.getDigitalSignatures();
    const signatureCount = signatures.size();

    if (signatureCount === 0) {
        console.log("The presentation does not contain digital signatures.");
    } else {
        let allSignaturesAreValid = true;

        for (let index = 0; index < signatureCount; index++) {
            const signature = signatures.get_Item(index);
            const signatureIsValid = signature.isValid();
            const signatureStatus = signatureIsValid ? "VALID" : "INVALID";
            const signTime = signature.getSignTime().toString();

            const certificateData = signature.getCertificate();
            const certificate = new X509Certificate(Buffer.from(certificateData));
            const signerName = certificate.subject;

            console.log(`${signerName}, ${signTime} -- ${signatureStatus}`);

            allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
        }

        if (allSignaturesAreValid) {
            console.log("All embedded signatures are valid for the current presentation.");
        } else {
            console.log("At least one embedded signature is invalid.");
        }
    }
} finally {
    presentation.dispose();
}
```

无效结果通常意味着签名后演示文稿内容或签名数据已更改，或文件已损坏。删除所有签名会生成未签名的演示文稿，因此仅检查项的有效性不足：安全敏感的工作流还必须验证预期的签名数量和预期的签名者身份是否存在。

此有效性结果不应被视为完整的证书信任决策。根据您的安全策略，应用程序可能还需要构建并验证 X.509 证书链，检查证书的有效日期和撤销状态，确认预期的主题或指纹，验证密钥用法，并评估受信任的时间戳。仅凭 [DigitalSignature.getSignTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 的值并不能证明来自受信任的时间戳机构。

## **删除数字签名**

删除签名会改变演示文稿的安全状态。下面的示例加载已签名的 PPTX 文件，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) 删除所有签名，并保存未签名的副本。

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("InputPresentation-signed.pptx");
try {
    presentation.getDigitalSignatures().clear();
    presentation.save("InputPresentation-unsigned.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

若只想删除单个签名，请使用其零基索引调用 [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/)。除非工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑和格式注意事项**

- 签名不会使演示文稿只读。用户和应用仍然可以编辑文件，但对已签名内容的更改通常会使现有签名失效。
- 在签名之前完成所有预期的编辑。如果必须更改演示文稿，请保存修订后的文件并再次对该修订进行签名。
- 保持最终输出为 PPTX 格式。将已签名的演示文稿转换为其他格式不会将原始 PPTX 签名转移为该转换文件的有效签名。
- 将证书的私钥视为敏感信息。获取私钥及其密码的任何人都可能创建看似来自该证书持有者的签名。
- 当文档保留策略要求时，保留未签名的源文件或其他受控副本。

## **常见问题解答**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但除非另行加密，演示文稿内容仍然可读。需要限制内容访问时，请使用[密码保护](/nodejs-java/password-protected-presentation/)。

**PFX 密码与演示文稿密码是同一个吗？**

不是。PFX 密码用于解锁存放在证书包中的私钥。它不控制谁可以打开或编辑 PPTX 文件。

**我可以使用自签名证书吗？**

技术上，只要自签名证书包含可访问的私钥，就可以使用。然而，接收方不会自动信任它，除非该证书已明确添加到其受信任环境中。公共或跨组织工作流通常使用受信任 CA 颁发的证书。

**导致签名无效的原因是什么？**

在签名后更改已签名的演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果所有签名被删除，演示文稿将变为未签名，而不是包含无效签名的文件。

**有效签名是否意味着我应该信任签名者？**

单凭签名本身不能决定信任。签名完整性和签名者信任是独立的决策。生产环境的验证策略应同时检查证书链、有效期、撤销状态、预期身份、密钥用法以及任何受信任的时间戳要求。

**证书过期会怎样？**

证书过期不会改变演示文稿的字节，但会影响证书信任评估。签名是否仍然可接受取决于您的策略以及是否有有效的受信任时间戳证明签名发生时证书仍然有效。不要仅凭显示的签名时间作为受信任的时间戳。

**已签名的演示文稿还能编辑吗？**

可以。签名并不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿的编辑，然后对最终修订进行签名。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到由 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 返回的集合中。验证时，检查每个签名并确认所有必需的签名者均已出现。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文所述的数字签名操作。PPT 和 OpenDocument 演示文稿格式不受此 API 工作流支持。

**我可以在不影响幻灯片的情况下删除签名吗？**

可以。您可以删除单个签名或清除整个集合，然后保存演示文稿。幻灯片内容仍然可用，但保存后的文件不再携带已删除的签名证据。