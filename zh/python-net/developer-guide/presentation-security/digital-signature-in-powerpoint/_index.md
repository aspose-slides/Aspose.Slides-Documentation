---
title: 使用 Python 为演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/python-net/digital-signature-in-powerpoint/
keywords:
- 数字签名
- 数字证书
- 证书颁发机构
- PFX 证书
- PowerPoint
- OpenDocument
- 演示文稿
- Python
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for Python via .NET 对 PowerPoint 与 OpenDocument 文件进行数字签名。通过清晰的代码示例，几秒钟即可保护您的幻灯片。"
---

**数字证书** 用于创建受密码保护的 PowerPoint 演示文稿，并标记为由特定组织或个人创建。数字证书可通过联系授权机构——证书颁发机构获取。将数字证书安装到系统后，可通过 **文件 → 信息 → 保护演示文稿** 为演示文稿添加数字签名：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

演示文稿可以包含多个数字签名。添加数字签名后，PowerPoint 会显示一条特殊的消息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

要对演示文稿进行签名或检查签名的真实性，**Aspose.Slides API** 提供了 [**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/) 接口、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/) 接口以及 [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/) 属性。目前，仅在 PPTX 格式中支持数字签名。

## **从 PFX 证书添加数字签名**
下面的代码示例演示如何从 PFX 证书添加数字签名：

1. 打开 PFX 文件并将 PFX 密码传递给 [**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/) 对象。  
1. 将创建的签名添加到演示文稿对象。

```py

#[TODO:Exception] RuntimeError: Proxy error(FileNotFoundException): Could not load file or assembly 'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. File was not found.

import aspose.slides as slides

with slides.Presentation() as pres:
    # Create DigitalSignature object with PFX file and PFX password 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # Comment new digital signature
    signature.comments = "Aspose.Slides digital signing test."

    # Add digital signature to presentation
    pres.digital_signatures.add(signature)

    # save presentation
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```

现在可以检查演示文稿是否已数字签名且未被修改：

```py
# Open presentation
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("Signatures used to sign the presentation: ")
        # Check if all digital signatures are valid
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "VALID" if signature.is_valid else "INVALID")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("Presentation is genuine, all signatures are valid.")
        else:
            print("Presentation has been modified since signing.")
```

## **常见问题**

**我可以从文件中移除已有的签名吗？**

可以。数字签名集合支持[删除单个项目](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/remove_at/)以及[全部清除](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignaturecollection/clear/)；保存文件后，演示文稿将不再包含任何签名。

**签名后文件会变成“只读”吗？**

不会。签名仅保证完整性和作者身份，不会阻止编辑。若需限制编辑，请结合使用["只读" 或密码](/slides/zh/python-net/password-protected-presentation/)。

**签名在不同版本的 PowerPoint 中会正确显示吗？**

签名是针对 OOXML（PPTX）容器创建的。支持 OOXML 签名的现代 PowerPoint 版本会正确显示此类签名的状态。