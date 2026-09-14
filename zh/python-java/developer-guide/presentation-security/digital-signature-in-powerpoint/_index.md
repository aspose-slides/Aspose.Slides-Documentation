---
title: 在 Python 中为演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/python-java/digital-signature-in-powerpoint/
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
description: "了解如何使用 PFX 证书签署现有的 PPTX 演示文稿，并通过 Java 使用 Aspose.Slides for Python 验证或移除数字签名。"
---
## **概述**

数字签名帮助接收者确定谁签署了演示文稿以及签署的内容是否已更改。此处有三个相关的安全概念重要：

- **数字证书** 是一种将身份与公钥关联的电子凭证。受信任的证书颁发机构（CA）可以颁发证书，或者组织可以使用自签名证书用于内部工作流。
- **数字签名** 是根据演示文稿内容和证书持有者的私钥创建的。随后可以使用证书的公钥来验证签名。签名提供来源和完整性的证据；它不会加密演示文稿。
- **密码保护** 控制用户是否可以打开或修改演示文稿。它独立于数字签名，详见[Password-Protected Presentations](/slides/zh/python-java/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint 保护演示文稿菜单，突出显示“添加数字签名”](add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可以显示签名状态通知。

![PowerPoint 通知，表示演示文稿包含有效签名](digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getDigitalSignatures)公开签名，该方法返回一个[DigitalSignatureCollection](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignaturecollection/)，其项是[DigitalSignature](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignature/)的实例。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件（亦称 PKCS#12 文件，通常使用 `.pfx` 或 `.p12` 扩展名）可以包含 X.509 证书、其私钥以及证书链。私钥是持有者创建签名的关键。没有可访问私钥的证书无法用于签署演示文稿。

PFX 密码保护证书包和私钥。它**不是**用于打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理。在生产环境中，应限制对证书文件的访问，并从机密存储或其他受保护的配置源获取密码。下面的示例仅使用环境变量，以避免在代码中嵌入密码。

## **向演示文稿添加数字签名**

要在实际的演示文稿工作流中签名，加载已有的 PPTX 文件，从 PFX 证书及其密码创建一个[DigitalSignature](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignature/)，将签名添加到演示文稿的集合中，并保存为 PPTX 文件。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

import os
from asposeslides.api import Presentation, DigitalSignature, SaveFormat

certificate_password = os.environ.get("PFX_PASSWORD")
if not certificate_password:
    print("Set the PFX_PASSWORD environment variable.")
else:
    presentation = Presentation("InputPresentation.pptx")
    try:
        signature = DigitalSignature("signing-certificate.pfx", certificate_password)
        signature.setComments("Approved for release.")

        presentation.getDigitalSignatures().add(signature)
        presentation.save("InputPresentation-signed.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

将结果保存为新名称可保留未签名的源文件。通过[DigitalSignature.setComments](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignature/#setComments)设置的值描述签名的用途；它不是安全控制手段。

## **验证数字签名**

加载已签名的 PPTX 文件时，检查[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getDigitalSignatures)返回的每个项。[DigitalSignature.isValid](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignature/#isValid)方法指示嵌入的签名对于当前演示文稿内容是否有效。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

ByteArrayInputStream = jpype.JClass("java.io.ByteArrayInputStream")
CertificateFactory = jpype.JClass("java.security.cert.CertificateFactory")
SimpleDateFormat = jpype.JClass("java.text.SimpleDateFormat")

presentation = Presentation("InputPresentation-signed.pptx")
try:
    signatures = presentation.getDigitalSignatures()
    signature_count = signatures.size()

    if signature_count == 0:
        print("The presentation does not contain digital signatures.")
    else:
        all_signatures_are_valid = True
        sign_time_format = SimpleDateFormat("yyyy-MM-dd HH:mm:ss")
        certificate_factory = CertificateFactory.getInstance("X.509")

        for signature in signatures:
            signature_is_valid = signature.isValid()
            signature_status = "VALID" if signature_is_valid else "INVALID"
            sign_time = signature.getSignTime()
            formatted_sign_time = sign_time_format.format(sign_time)

            certificate_data = signature.getCertificate()
            certificate_stream = ByteArrayInputStream(certificate_data)
            certificate = certificate_factory.generateCertificate(certificate_stream)
            signer_principal = certificate.getSubjectX500Principal()
            signer_name = signer_principal.getName()

            print(f"{signer_name}, {formatted_sign_time} -- {signature_status}")

            all_signatures_are_valid = all_signatures_are_valid and signature_is_valid

        if all_signatures_are_valid:
            print("All embedded signatures are valid for the current presentation.")
        else:
            print("At least one embedded signature is invalid.")
finally:
    presentation.dispose()
```

无效结果通常意味着签名后演示文稿内容或签名数据已更改，或文件损坏。删除所有签名会产生未签名的演示文稿，因此仅检查项的有效性不足：安全敏感的工作流还必须验证期望的签名数量和期望的签署者身份是否存在。

此有效性结果不应被视为完整的证书信任决策。根据您的安全策略，应用程序可能还需要构建并验证 X.509 证书链，检查证书的有效期和吊销状态，确认预期的主体或指纹，验证密钥用法，并评估受信任的时间戳。[DigitalSignature.getSignTime](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignature/#getSignTime)的值本身并不能作为受信任时间戳机构的证明。

## **移除数字签名**

移除签名会改变演示文稿的安全状态。以下示例加载已签名的 PPTX 文件，使用[DigitalSignatureCollection.clear](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignaturecollection/#clear)移除所有签名，并保存为未签名的副本。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("InputPresentation-signed.pptx")
try:
    presentation.getDigitalSignatures().clear()
    presentation.save("InputPresentation-unsigned.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

若只需移除单个签名，请使用其零基索引调用[DigitalSignatureCollection.removeAt](https://reference.aspose.com/slides/zh/python-java/aspose.slides/digitalsignaturecollection/#removeAt)。除非工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑和格式注意事项**

- 签名并不会使演示文稿只读。用户和应用程序仍然可以编辑文件，但对已签名内容的更改通常会使现有签名失效。
- 在签名前完成所有预期的编辑。如果需要更改演示文稿，请保存修订后的文件并再次签名。
- 请保留最终输出为 PPTX 格式。将已签名的演示文稿转换为其他格式不会将原 PPTX 的签名作为有效签名转移到转换后的文件中。
- 将证书的私钥视为敏感信息。任何获取私钥及其密码的人都可能创建看似来自该证书持有者的签名。
- 当文档保留政策要求时，保留未签名的源文件或其他受控副本。

## **常见问答**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但演示文稿内容仍然可读，除非另行使用加密。需要限制内容访问时，请使用[密码保护](/slides/zh/python-java/password-protected-presentation/)。

**PFX 密码与演示文稿密码相同吗？**

不是。PFX 密码用于解锁证书包中存储的私钥，它不控制谁可以打开或编辑 PPTX 文件。

**可以使用自签名证书吗？**

技术上，只要自签名证书包含可访问的私钥即可使用。然而，接收方不会自动信任它，除非该证书已显式添加到其受信任环境中。公共或跨组织的工作流通常使用受信任 CA 颁发的证书。

**哪些情况会导致签名无效？**

在签名后更改已签名的演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果所有签名被移除，演示文稿将是未签名的，而不是包含无效签名的文件。

**有效签名是否意味着应当信任签署者？**

仅凭签名本身并不能决定是否信任签署者。签名完整性和签署者的可信度是独立的决策。生产环境的验证策略还应检查证书链、有效期、吊销状态、预期身份、密钥用法以及任何受信任的时间戳要求。

**证书过期会怎样？**

证书过期不会改变演示文稿的字节，但会影响证书信任评估。签名是否仍然可接受取决于您的策略以及是否有有效的受信任时间戳能够证明签名发生时证书仍然有效。不要仅依赖显示的签名时间作为受信任的时间戳。

**已签名的演示文稿还能编辑吗？**

可以。签名不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿的编辑并对最终版本进行签名。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到[Presentation.getDigitalSignatures](https://reference.aspose.com/slides/zh/python-java/aspose.slides/presentation/#getDigitalSignatures)返回的集合中。验证时，请检查每个签名并确认所有必需的签署者都存在。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文描述的数字签名操作。PPT 和 OpenDocument 演示文稿格式不受此 API 工作流支持。

**可以在不影响幻灯片的情况下移除签名吗？**

可以。您可以移除单个签名或清空整个集合，然后保存演示文稿。幻灯片内容仍然保留，但保存的文件不再包含已移除的签名证据。