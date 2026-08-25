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

数字签名帮助接收者确定是谁签署了演示文稿以及已签名的内容是否已更改。以下三个相关的安全概念在此尤为重要：

- **数字证书**是一种将身份与公钥关联的电子凭证。受信任的证书颁发机构（CA）可以签发证书，或者组织可以使用自签名证书用于内部工作流。
- **数字签名**是基于演示文稿内容和证书持有者的私钥创建的。随后可以使用证书的公钥来验证签名。签名提供了来源和完整性的证据；它并不对演示文稿进行加密。
- **密码保护**控制用户是否能够打开或修改演示文稿。它与数字签名分离，相关内容请参阅[Password-Protected Presentations](/slides/zh/nodejs-java/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint“保护演示文稿”菜单，突出显示“添加数字签名”](add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可显示签名状态通知。

![PowerPoint 通知，指出演示文稿包含有效签名](digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 公开签名，该方法返回一个包含 [DigitalSignature](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 对象的 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignaturecollection/)。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件，也称为 PKCS#12 文件，通常使用 `.pfx` 或 `.p12` 扩展名，可以包含 X.509 证书、其私钥以及证书链。私钥是持有者创建签名的关键。没有可访问私钥的证书无法用于签署演示文稿。

PFX 密码用于保护证书包和私钥。它 **不是** 用于打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理中。在生产环境中，应限制对证书文件的访问，并从机密存储或其他受保护的配置源获取密码。下面的示例仅使用环境变量，以避免在代码中嵌入密码。

## **向演示文稿添加数字签名**

要对实际演示文稿工作流进行签名，需要加载现有的 PPTX 文件，从 PFX 证书及其密码创建一个 [DigitalSignature](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/)，将签名添加到演示文稿的集合中，并保存为 PPTX 文件。

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

将结果保存为新名称可保留未签名的源文件。通过 [DigitalSignature.setComments](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 设置的值描述签名的目的；它不是安全控制措施。

## **验证数字签名**

加载已签名的 PPTX 文件时，检查由 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 返回的每个项目。[DigitalSignature.isValid](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 方法指示嵌入的签名对当前演示文稿内容是否有效。

下面的示例还使用 Node.js `X509Certificate` 类读取每个嵌入证书的主题名称。

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

无效的结果通常表示签名后演示文稿内容或签名数据已更改，或文件已损坏。删除所有签名会生成未签名的演示文稿，因此仅检查项目的有效性不足；安全敏感的工作流还必须验证是否存在预期数量的签名以及预期的签署者身份。

此有效性结果不应被视为完整的证书信任决策。根据您的安全策略，应用程序可能还需要构建并验证 X.509 证书链、检查证书的有效期和吊销状态、确认预期的主题或指纹、验证密钥用途以及评估受信任的时间戳。[DigitalSignature.getSignTime](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignature/) 的返回值本身并不能作为受信任时间戳机构的证明。

## **删除数字签名**

删除签名会改变演示文稿的安全状态。下面的示例加载已签名的 PPTX 文件，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignaturecollection/clear/) 删除所有签名，并保存为未签名的副本。

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

若仅删除单个签名，请使用其基于零的索引调用 [DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/digitalsignaturecollection/removeat/)。除非工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑和格式注意事项**

- **签名不会使演示文稿只读**。用户和应用程序仍然可以编辑文件，但对已签名内容的更改通常会使现有签名失效。
- **在签名之前完成所有预期的编辑**。如果必须更改演示文稿，请保存修订后的文件并重新签名该修订版。
- **保持最终输出为 PPTX 格式**。将已签名的演示文稿转换为其他格式时，原始 PPTX 签名不会作为有效签名转移到转换后的文件中。
- **将证书的私钥视为敏感信息**。任何获取私钥及其密码的人都可能创建看似来自该证书持有者的签名。
- **在文档保留策略要求时，保留未签名的源文件或其他受控副本**。

## **常见问题**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但演示文稿内容仍然可读，除非另行加密。当需要限制对内容的访问时，请使用[password protection](/slides/zh/nodejs-java/password-protected-presentation/)。

**PFX 密码与演示文稿密码相同吗？**

不是。PFX 密码用于解锁存放在证书包中的私钥。它不控制谁可以打开或编辑 PPTX 文件。

**我可以使用自签名证书吗？**

在技术上，只要自签名证书包含可访问的私钥即可使用。然而，除非收件人已明确将该证书加入其信任环境，否则他们不会自动信任它。公共或跨组织的工作流通常使用受信任 CA 签发的证书。

**什么会导致签名无效？**

在签名后更改已签名的演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果删除了所有签名，则该演示文稿为未签名状态，而不是包含无效签名的文件。

**有效的签名意味着我应该信任签署者吗？**

单凭它并不能。签名的完整性与签署者的可信度是独立的判断。生产环境的验证策略还应检查证书链、有效期、吊销状态、预期身份、密钥用途以及任何受信任的时间戳要求。

**证书过期后会怎样？**

证书过期不会改变演示文稿的字节，但会影响证书信任的评估。签名是否仍然可接受取决于您的策略以及是否存在有效的受信任时间戳能够证明签名发生时证书仍然有效。不要仅依赖显示的签名时间作为受信任的时间戳。

**已签名的演示文稿仍然可以编辑吗？**

可以。签名不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿并对最终修订进行签名。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到 [Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/#getDigitalSignatures--) 返回的集合中。验证时，检查每个签名并确认所有必需的签署者均已存在。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文所述的数字签名操作。PPT 和 OpenDocument 演示文稿格式不受此 API 工作流的支持。

**我可以在不影响幻灯片的情况下删除签名吗？**

可以。您可以删除单个签名或清空整个集合后再保存演示文稿。幻灯片内容仍然保留，但保存的文件不再包含已删除的签名证据。