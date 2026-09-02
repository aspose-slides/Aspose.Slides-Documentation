---
title: 在 Python 中为演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/python-net/digital-signature-in-powerpoint/
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
- Python
- Aspose.Slides
description: "了解如何使用 PFX 证书对现有 PPTX 演示文稿进行签名，并通过 .NET 使用 Aspose.Slides for Python 验证或删除数字签名。"
---
## **概述**

数字签名帮助接收者确定谁对演示文稿签名以及签名内容是否已更改。这里有三个相关的安全概念：

- **数字证书** 是将身份与公钥关联的电子凭证。受信任的证书颁发机构 (CA) 可以颁发证书，组织也可以使用自签名证书用于内部工作流。
- **数字签名** 由演示文稿内容和证书持有者的私钥生成。随后可以使用证书的公钥验证签名。签名提供来源和完整性证据；它不对演示文稿进行加密。
- **密码保护** 控制用户是否可以打开或修改演示文稿。它与数字签名分离，详见[密码保护的演示文稿](/python-net/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint保护演示文稿菜单，突出显示添加数字签名](add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可以显示签名状态通知。

![PowerPoint通知，说明演示文稿包含有效签名](digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/digital_signatures/) 暴露签名，这是一个 [DigitalSignatureCollection](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignaturecollection/)，其项为 [DigitalSignature](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignature/) 对象。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件，也称为 PKCS#12 文件，通常使用 `.pfx` 或 `.p12` 扩展名，可以包含 X.509 证书、其私钥以及证书链。私钥是持有者创建签名的关键。没有可访问私钥的证书无法用于签署演示文稿。

PFX 密码保护证书包和私钥。它 **不是** 用于打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理。生产环境中，请限制对证书文件的访问，并从密钥库或其他受保护的配置源获取密码。下面的示例仅使用环境变量，以避免在代码中嵌入密码。

## **向演示文稿添加数字签名**

要对真实演示文稿工作流进行签名，加载已有的 PPTX 文件，从 PFX 证书及其密码创建 [DigitalSignature](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignature/)，将签名添加到演示文稿的集合中，然后保存为 PPTX 文件。

```python
import os
import aspose.slides as slides

certificate_password = os.environ.get("PFX_PASSWORD")
if certificate_password is None:
    raise RuntimeError("Set the PFX_PASSWORD environment variable.")

with slides.Presentation("InputPresentation.pptx") as presentation:
    signature = slides.DigitalSignature("signing-certificate.pfx", certificate_password)
    signature.comments = "Approved for release."

    presentation.digital_signatures.add(signature)
    presentation.save("InputPresentation-signed.pptx", slides.export.SaveFormat.PPTX)
```

将结果保存为新名称可保留未签名的源文件。[DigitalSignature.comments](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignature/comments/) 值描述签名的目的；它不是安全控制。

## **验证数字签名**

加载已签名的 PPTX 文件时，检查 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/digital_signatures/) 中的每个项。[DigitalSignature.is_valid](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignature/is_valid/) 属性指示嵌入的签名是否对当前演示文稿内容有效。

```python
import hashlib
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    signature_count = len(presentation.digital_signatures)

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True

        for signature in presentation.digital_signatures:
            signature_status = "VALID" if signature.is_valid else "INVALID"
            certificate_fingerprint = hashlib.sha256(signature.certificate).hexdigest().upper()
            signing_time = signature.sign_time.strftime("%Y-%m-%d %H:%M:%S")

            print(
                f"Certificate SHA-256: {certificate_fingerprint}, "
                f"{signing_time} -- {signature_status}"
            )

            all_signatures_are_valid = (all_signatures_are_valid and signature.is_valid)

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
```

无效结果通常意味着签名后演示文稿内容或签名数据已更改，或文件已损坏。删除所有签名会产生未签名的演示文稿，仅检查项的有效性不足：安全敏感的工作流还必须验证预期的签名数量和签名者身份是否存在。

[DigitalSignature.certificate](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignature/certificate/) 属性以字节数组形式提供证书数据。示例计算其 SHA-256 指纹，以便应用程序可以将其与预期签名者证书的指纹进行比较。

此有效性结果不应视为完整的证书信任决定。根据您的安全策略，应用程序可能还需要构建并验证 X.509 证书链，检查证书有效期和吊销状态，确认预期的主题或指纹，验证密钥用法，并评估可信时间戳。[DigitalSignature.sign_time](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignature/sign_time/) 本身并非可信时间戳机构的证明。

## **删除数字签名**

删除签名会更改演示文稿的安全状态。以下示例加载已签名的 PPTX 文件，使用 [DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignaturecollection/clear/) 删除所有签名，并保存未签名的副本。

```python
import aspose.slides as slides

with slides.Presentation("InputPresentation-signed.pptx") as presentation:
    presentation.digital_signatures.clear()
    presentation.save("InputPresentation-unsigned.pptx", slides.export.SaveFormat.PPTX)
```

要仅删除一个签名，请使用其零基索引调用 [DigitalSignatureCollection.remove_at](https://reference.aspose.com/slides/zh/python-net/aspose.slides/digitalsignaturecollection/remove_at/)。除非工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑和格式注意事项**

- 签名并不会使演示文稿只读。用户和应用程序仍可编辑文件，但对已签名内容的更改通常会使现有签名失效。
- 在签名前完成所有预期的编辑。如果必须更改演示文稿，请保存修订后的演示文稿并再次签名该修订版。
- 保持最终输出为 PPTX 格式。将已签名的演示文稿转换为其他格式不会将原 PPTX 签名转移为转换后文件的有效签名。
- 将证书的私钥视为敏感信息。获取私钥及其密码的任何人，都可能创建看似来自该证书持有者的签名。
- 当文档保留策略要求时，保留未签名的源文件或其他受控副本。

## **常见问题解答**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但演示文稿内容仍可读取，除非另行加密。需要限制对内容的访问时，请使用[密码保护](/python-net/password-protected-presentation/)。

**PFX 密码与演示文稿密码相同吗？**

不相同。PFX 密码用于解锁存放在证书包中的私钥。它不控制谁可以打开或编辑 PPTX 文件。

**我可以使用自签名证书吗？**

技术上，只要自签名证书包含可访问的私钥即可使用。但除非接收方显式将该证书加入其受信任环境，否则他们不会自动信任它。公共或跨组织工作流通常使用受信任 CA 颁发的证书。

**什么会导致签名无效？**

签名后更改已签名的演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果删除所有签名，演示文稿将变为未签名，而不是包含无效签名的文件。

**有效签名是否意味着我应该信任签名者？**

仅凭此不能。签名的完整性与签名者的可信度是独立的决策。生产环境的验证策略还应检查证书链、有效期、吊销状态、预期身份、密钥用法以及任何可信时间戳要求。

**证书过期会怎样？**

证书过期不会改变演示文稿的字节，但会影响证书信任评估。签名是否仍然可接受取决于您的策略以及是否有有效的可信时间戳证明签名发生时证书仍然有效。不要仅凭显示的签名时间作为可信时间戳。

**已签名的演示文稿还能编辑吗？**

可以。签名不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿并对最终修订进行签名。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到 [Presentation.digital_signatures](https://reference.aspose.com/slides/zh/python-net/aspose.slides/presentation/digital_signatures/)。验证时，检查每个签名并确认所有必需的签名者都已出现。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文所述的数字签名操作。不支持 PPT 和 OpenDocument 演示文稿格式的此 API 工作流。

**我可以在不影响幻灯片的情况下删除签名吗？**

可以。您可以删除单个签名或清空整个集合，然后保存演示文稿。幻灯片内容仍然保留，但保存后的文件不再携带已删除的签名证据。