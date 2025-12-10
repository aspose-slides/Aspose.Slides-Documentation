---
title: 在 .NET 中向演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/net/digital-signature-in-powerpoint/
keywords:
- 数字签名
- 数字证书
- 证书颁发机构
- PFX 证书
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 对 PowerPoint 与 OpenDocument 文件进行数字签名。几秒钟内使用清晰的代码示例保护您的幻灯片。"
---

**数字证书** 用于创建受密码保护的 PowerPoint 演示文稿，标记为由特定组织或个人创建。数字证书可以通过联系授权组织——证书颁发机构获得。将数字证书安装到系统后，可通过 File -> Info -> Protect Presentation 为演示文稿添加数字签名：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

演示文稿可能包含多个数字签名。数字签名添加到演示文稿后，PowerPoint 中会出现一条特殊信息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

要对演示文稿进行签名或检查演示文稿签名的真实性，**Aspose.Slides API** 提供[**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature)接口、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection)接口和[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures)属性。目前，数字签名仅支持 PPTX 格式。

## **从 PFX 证书添加数字签名**
下面的代码示例演示如何从 PFX 证书添加数字签名：

1. 打开 PFX 文件并将 PFX 密码传递给[**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature)对象。
2. 将创建的签名添加到演示文稿对象。
```c#
using (Presentation pres = new Presentation())
{
    // 使用 PFX 文件和 PFX 密码创建 DigitalSignature 对象 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // 对新数字签名添加注释
    signature.Comments = "Aspose.Slides digital signing test.";

    // 将数字签名添加到演示文稿
    pres.DigitalSignatures.Add(signature);

    // 保存演示文稿
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


现在可以检查演示文稿是否已数字签名且未被修改：
```c#
// 打开演示文稿
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("Signatures used to sign the presentation: ");

        // 检查所有数字签名是否有效
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "VALID" : "INVALID"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("Presentation is genuine, all signatures are valid.");
        else
            Console.WriteLine("Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**可以从文件中移除已有的签名吗？**

可以。数字签名集合支持[删除单个项](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/removeat/)和[完全清除](https://reference.aspose.com/slides/net/aspose.slides/digitalsignaturecollection/clear/)；保存文件后，演示文稿将不再包含签名。

**签名后文件会变成“只读”吗？**

不会。签名保留完整性和作者信息，但不会阻止编辑。如需限制编辑，请结合使用[“只读”或密码](/slides/zh/net/password-protected-presentation/)。

**签名在不同版本的 PowerPoint 中会正确显示吗？**

签名是为 OOXML（PPTX）容器创建的。支持 OOXML 签名的现代 PowerPoint 版本能够正确显示此类签名的状态。