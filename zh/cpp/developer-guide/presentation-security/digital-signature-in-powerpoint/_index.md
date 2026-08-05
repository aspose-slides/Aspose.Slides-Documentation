---
title: 为 C++ 演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/cpp/digital-signature-in-powerpoint/
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
- C++
- Aspose.Slides
description: "了解如何使用 PFX 证书对现有 PPTX 演示文稿进行签名，并使用 Aspose.Slides for C++ 验证或移除数字签名。"
---
## **概览**

数字签名帮助接收者确定是谁签署了演示文稿以及签署的内容是否已被更改。此处涉及的三个相关安全概念如下：

- **数字证书** 是一种电子凭证，用于将身份与公钥关联。受信任的证书颁发机构（CA）可以颁发证书，或组织使用自签名证书用于内部工作流。
- **数字签名** 由演示文稿内容和证书持有者的私钥生成。随后可使用证书的公钥验证签名。签名提供来源和完整性的证据；它并不对演示文稿进行加密。
- **密码保护** 控制用户是否能够打开或修改演示文稿。它与数字签名分离，详见[密码保护演示文稿](/cpp/password-protected-presentation/)。

PowerPoint 在 **文件 > 信息 > 保护演示文稿** 下提供 **添加数字签名** 命令。

![PowerPoint 保护演示文稿菜单，突出显示“添加数字签名”](add-digital-signature-in-powerpoint.png)

打开已签名的演示文稿后，PowerPoint 可以显示签名状态通知。

![PowerPoint 通知，说明演示文稿包含有效签名](digital-signature-status-in-powerpoint.png)

Aspose.Slides 通过[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_digitalsignatures/)公开签名，该方法返回实现了[IDigitalSignature](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idigitalsignature/)的[IDigitalSignatureCollection](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idigitalsignaturecollection/)。一个演示文稿可以包含多个签名。

## **了解 PFX 证书和密码**

PFX 文件，也称为 PKCS#12 文件，通常使用 `.pfx` 或 `.p12` 扩展名，可包含 X.509 证书、其私钥以及证书链。私钥是持有者创建签名的关键。没有可访问私钥的证书无法用于签署演示文稿。

PFX 密码用于保护证书包和私钥。它 **不是** 打开或编辑演示文稿的密码。不要将 PFX 文件或其密码提交到源代码管理。在生产环境中，应限制对证书文件的访问，并从机密存储或其他受保护的配置源获取密码。下面的示例仅使用环境变量以避免在代码中嵌入密码。

## **向演示文稿添加数字签名**

要在实际工作流中签署演示文稿，加载已有的 PPTX 文件，从 PFX 证书及其密码创建[DigitalSignature](https://reference.aspose.com/slides/zh/cpp/aspose.slides/digitalsignature/)，将签名添加到演示文稿的集合中，并保存为 PPTX 文件。

```cpp
auto certificatePassword = Environment::GetEnvironmentVariable(u"PFX_PASSWORD");
if (certificatePassword.IsNullOrEmpty())
{
    throw InvalidOperationException(u"Set the PFX_PASSWORD environment variable.");
}

auto presentation = MakeObject<Presentation>(u"InputPresentation.pptx");

auto signature = MakeObject<DigitalSignature>(u"signing-certificate.pfx", certificatePassword);
signature->set_Comments(u"Approved for release.");

presentation->get_DigitalSignatures()->Add(signature);
presentation->Save(u"InputPresentation-signed.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

将结果另存为新文件可保留未签名的源文件。通过[IDigitalSignature::set_Comments](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idigitalsignature/set_comments/)设置的值用于描述签名的目的；它不是安全控制手段。

## **验证数字签名**

加载已签名的 PPTX 文件后，检查由[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_digitalsignatures/)返回的每个项目。[IDigitalSignature::get_IsValid](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idigitalsignature/get_isvalid/) 方法指示嵌入的签名对当前演示文稿内容是否有效。

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

auto signatureCount = presentation->get_DigitalSignatures()->get_Count();

if (signatureCount == 0)
{
    Console::WriteLine(u"The presentation does not contain digital signatures.");
}
else
{
    bool allSignaturesAreValid = true;

    for (int signatureIndex = 0; signatureIndex < signatureCount; ++signatureIndex)
    {
        auto signature = presentation->get_DigitalSignature(signatureIndex);
        auto signatureIsValid = signature->get_IsValid();
        auto signatureStatus = signatureIsValid ? u"VALID" : u"INVALID";
        auto signerName = signature->get_Certificate()->get_SubjectName()->get_Name();
        auto signingTime = signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm:ss");

        Console::WriteLine(u"{0}, {1} -- {2}", signerName, signingTime, signatureStatus);

        allSignaturesAreValid = allSignaturesAreValid && signatureIsValid;
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"All embedded signatures are valid for the current presentation.");
    }
    else
    {
        Console::WriteLine(u"At least one embedded signature is invalid.");
    }
}

presentation->Dispose();
```

无效结果通常意味着签名后演示文稿内容或签名数据发生了更改，或文件已损坏。删除所有签名会得到未签名的演示文稿，因此仅检查项目的有效性不足：安全敏感的工作流还必须验证期望的签名数量以及期望的签署者身份是否存在。

此有效性结果不应视为完整的证书信任决策。根据安全策略，应用程序可能还需要构建并验证 X.509 证书链、检查证书有效期和撤销状态、确认期望的主体或指纹、验证密钥用法，并评估受信时间戳。[IDigitalSignature::get_SignTime](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idigitalsignature/get_signtime/) 的值本身并不能作为受信时间戳机构的证明。

## **移除数字签名**

移除签名会改变演示文稿的安全状态。以下示例加载已签名的 PPTX 文件，使用[IDigitalSignatureCollection::Clear](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idigitalsignaturecollection/clear/) 删除所有签名，并保存为未签名的副本。

```cpp
auto presentation = MakeObject<Presentation>(u"InputPresentation-signed.pptx");

presentation->get_DigitalSignatures()->Clear();
presentation->Save(u"InputPresentation-unsigned.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

若只想移除单个签名，可调用[IDigitalSignatureCollection::RemoveAt](https://reference.aspose.com/slides/zh/cpp/aspose.slides/idigitalsignaturecollection/removeat/) 并传入其基于零的索引。除非工作流明确要求覆盖已签名的原文件，否则请保存为新文件。

## **编辑和格式注意事项**

- 签名并不会使演示文稿只读。用户和应用程序仍可编辑文件，但对已签名内容的更改通常会使现有签名失效。
- 在签名之前完成所有预期的编辑。如果必须修改演示文稿，请保存修订后的文件并再次签名该修订版。
- 保持最终输出为 PPTX 格式。将已签名的演示文稿转换为其他格式不会将原始 PPTX 签名作为有效签名转移到转换后的文件中。
- 将证书的私钥视为敏感信息。获取私钥及其密码的任何人都可能创建看似来自该证书持有者的签名。
- 在文档保留策略要求时，保留未签名的源文件或其他受控副本。

## **常见问题**

**数字签名会加密演示文稿吗？**

不会。数字签名提供关于来源和完整性的证据，但演示文稿内容仍然可读，除非另行加密。需要限制内容访问时请使用[密码保护](/cpp/password-protected-presentation/)。

**PFX 密码与演示文稿密码是同一个吗？**

不是。PFX 密码用于解锁存储在证书包中的私钥，它不控制谁可以打开或编辑 PPTX 文件。

**可以使用自签名证书吗？**

技术上可以，只要自签名证书包含可访问的私钥。收件人不会自动信任该证书，除非已将其显式加入受信环境。公共或跨组织工作流通常使用受信 CA 颁发的证书。

**什么情况会导致签名无效？**

在签名后更改已签名的演示文稿内容或签名数据会使签名失效。文件损坏也会导致验证失败。如果全部签名被删除，演示文稿将变为未签名，而不是包含无效签名的文件。

**有效签名是否意味着应当信任签署者？**

单凭签名本身不能。签名完整性和签署者信任是独立的判断。生产环境的验证策略还应检查证书链、有效期、撤销状态、期望的身份、密钥用法以及任何受信时间戳要求。

**证书过期后会怎样？**

证书过期不会改变演示文稿的字节，但会影响证书信任评估。签名是否仍然可接受取决于您的策略以及是否有有效的受信时间戳证明签署发生时证书仍然有效。不要仅依赖显示的签署时间作为受信时间戳。

**已签名的演示文稿还能编辑吗？**

可以。签名不会锁定文件。编辑已签名的内容通常会使现有签名失效，因此请先完成演示文稿并签署最终修订版。

**演示文稿可以包含多个签名吗？**

可以。在保存之前，将每个签名添加到[IPresentation::get_DigitalSignatures](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_digitalsignatures/) 返回的集合中。验证时检查每个签名，并确认所有必需的签署者均已到位。

**哪些演示文稿格式支持这些操作？**

Aspose.Slides 仅在 PPTX 格式下支持本文档所述的数字签名操作。PPT 和 OpenDocument 演示文稿格式不受此 API 工作流支持。

**删除签名会影响幻灯片吗？**

不会。您可以删除单个签名或清空整个集合，然后保存演示文稿。幻灯片内容仍然保留，但保存的文件不再携带已删除的签名证据。