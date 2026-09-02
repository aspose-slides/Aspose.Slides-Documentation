---
title: 添加数字签名到 .NET 中的演示文稿
linktitle: 数字签名
type: docs
weight: 10
url: /zh/net/digital-signature-in-powerpoint/
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 PFX 证书对现有 PPTX 演示文稿进行签名，并使用 Aspose.Slides for .NET 验证或移除数字签名。"
---
## **概述**

数字签名帮助接收者确定是谁对演示文稿进行了签名以及签名内容是否已被更改。此处有三个相关的安全概念需要了解：

- **数字证书** 是一种电子凭证，将身份与公钥关联。受信任的证书颁发机构（CA）可以颁发证书，组织也可以使用自签名证书用于内部工作流。
- **数字签名** 是使用演示文稿内容和证书持有者的私钥生成的。随后可以使用证书的公钥来验证签名。签名提供来源和完整性的证据；它并不对演示文稿进行加密。
- **密码保护** 控制用户是否可以打开或修改演示文稿。它与数字签名分离，详见[密码保护的演示文稿](/slides/zh/net/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint 保护演示文稿菜单，突出显示“添加数字签名”](/add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可以显示签名状态通知。

![PowerPoint 通知，说明演示文稿包含有效签名](/digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/digitalsignatures/)公开签名，这是一个实现了[IDigitalSignature](https://reference.aspose.com/slides/zh/net/aspose.slides/idigitalsignature/)的[IDigitalSignatureCollection](https://reference.aspose.com/slides/zh/net/aspose.slides/idigitalsignaturecollection/)。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件（也称为 PKCS#12 文件，通常以 `.pfx` 或 `.p12` 为扩展名）可以包含 X.509 证书、其私钥以及证书链。私钥是持有者创建签名的依据。没有可访问私钥的证书无法用于签名演示文稿。

PFX 密码用于保护证书包及其私钥。它 **不是** 用于打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理。在生产环境中，应限制对证书文件的访问，并从密钥库或其他受保护的配置源获取密码。下面的示例仅使用环境变量，以避免在代码中硬编码密码。

## **向演示文稿添加数字签名**

要在真实的工作流中签名演示文稿，加载已有的 PPTX 文件，使用 PFX 证书及其密码创建[DigitalSignature](https://reference.aspose.com/slides/zh/net/aspose.slides/digitalsignature/)，将签名添加到演示文稿的集合中，然后保存为 PPTX 文件。

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

将结果保存为新名称可保留未签名的源文件。[DigitalSignature.Comments](https://reference.aspose.com/slides/zh/net/aspose.slides/digitalsignature/comments/)属性用于描述签名的用途；它不是安全控制手段。

## **验证数字签名**

加载已签名的 PPTX 文件时，检查[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/digitalsignatures/)中的每个项目。[IDigitalSignature.IsValid](https://reference.aspose.com/slides/zh/net/aspose.slides/idigitalsignature/isvalid/)属性指示嵌入的签名是否对当前演示文稿内容有效。

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

无效结果通常意味着签名后演示文稿内容或签名数据被更改，或文件已损坏。仅删除所有签名会得到未签名的演示文稿，因此仅检查项目的有效性并不足以满足安全敏感的工作流——还必须验证预期的签名数量和签名者身份是否存在。

此有效性结果不应视为完整的证书信任决策。根据您的安全策略，应用程序可能还需要构建并验证 X.509 证书链，检查证书有效期和吊销状态，确认预期的主题或指纹，验证密钥用途，并评估受信任的时间戳。[IDigitalSignature.SignTime](https://reference.aspose.com/slides/zh/net/aspose.slides/idigitalsignature/signtime/)本身并不能作为受信任时间戳机构的证明。

## **移除数字签名**

移除签名会改变演示文稿的安全状态。下面的示例加载已签名的 PPTX 文件，使用[IDigitalSignatureCollection.Clear](https://reference.aspose.com/slides/zh/net/aspose.slides/idigitalsignaturecollection/clear/)删除所有签名，然后保存为未签名的副本。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("InputPresentation-signed.pptx");

presentation.DigitalSignatures.Clear();
presentation.Save("InputPresentation-unsigned.pptx", SaveFormat.Pptx);
```

若只想删除单个签名，请使用其基于零的索引调用[IDigitalSignatureCollection.RemoveAt](https://reference.aspose.com/slides/zh/net/aspose.slides/idigitalsignaturecollection/removeat/)。除非您的工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑和格式注意事项**

- 签名并不会使演示文稿只读。用户和应用仍然可以编辑文件，但对已签名内容的更改通常会使现有签名失效。
- 在签名之前完成所有预期的编辑。如果需要更改演示文稿，请保存修订后的文件并再次进行签名。
- 保持最终输出为 PPTX 格式。将已签名的演示文稿转换为其他格式不会将原始 PPTX 签名转移为转换后文件的有效签名。
- 将证书的私钥视为敏感信息。任何获取私钥及其密码的人都可能创建看似来自该证书持有者的签名。
- 当文档保留策略要求时，保留未签名的源文件或其他受控副本。

## **常见问题**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但演示文稿内容仍可阅读，除非另行进行加密。需要限制内容访问时，请使用[密码保护](/slides/zh/net/password-protected-presentation/)。

**PFX 密码与演示文稿密码是同一个吗？**

不是。PFX 密码用于解锁存放在证书包中的私钥， 与打开或编辑 PPTX 文件的权限无关。

**可以使用自签名证书吗？**

技术上，只要自签名证书包含可访问的私钥即可使用。但接收方不会自动信任该证书，除非其已显式添加到受信任环境中。公共或跨组织的工作流通常使用受信任 CA 颁发的证书。

**什么情况会导致签名失效？**

在签名后更改演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果所有签名都被移除，则演示文稿为未签名状态，而不是包含无效签名的文件。

**有效的签名是否意味着应该信任签名者？**

单凭签名本身并不能决定信任。签名的完整性与签名者的可信度是两个独立的判断。生产环境的验证策略应同时检查证书链、有效期、吊销状态、预期身份、密钥用途以及任何受信任的时间戳要求。

**证书过期后会怎样？**

证书过期不会改变演示文稿的字节内容，但会影响证书信任评估。签名是否仍然可接受取决于您的策略以及是否存在有效的受信任时间戳能够证明签名发生时证书仍然有效。不要仅凭显示的签署时间作为受信任时间戳。

**已签名的演示文稿还能编辑吗？**

可以。签名不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿的最终版本，再进行签名。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到[IPresentation.DigitalSignatures](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/digitalsignatures/)。验证时，请检查每个签名并确认所有必需的签名者均已出现。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文描述的数字签名操作。PPT 和 OpenDocument 演示文稿格式不受此 API 工作流支持。

**可以在不影响幻灯片的情况下移除签名吗？**

可以。您可以移除单个签名或清除整个集合后再保存演示文稿。幻灯片内容仍然保留，但保存后的文件不再包含已移除的签名证据。