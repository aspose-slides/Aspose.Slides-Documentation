---
title: PowerPoint 中的数字签名
type: docs
weight: 10
url: /zh/net/digital-signature-in-powerpoint/
keywords: "数字签名证书, 证书颁发机构, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 PowerPoint 中添加数字签名或证书。C# 或 .NET 中的证书颁发机构"
---


**数字证书**用于创建一个受密码保护的 PowerPoint 演示文稿，标记为由特定组织或个人创建。数字证书可以通过联系授权组织（证书颁发机构）来获得。在将数字证书安装到系统后，可以通过 文件 -> 信息 -> 保护演示文稿 来将数字签名添加到演示文稿中：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)


演示文稿可以包含多个数字签名。添加数字签名后，PowerPoint 中会出现特殊消息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)


要签署演示文稿或检查演示文稿签名的真实性，**Aspose.Slides API** 提供了 [**IDigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/idigitalsignature) 接口、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/net/aspose.slides/IDigitalSignatureCollection) 接口和 [**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/properties/digitalsignatures) 属性。目前，数字签名仅支持 PPTX 格式。
## **从 PFX 证书添加数字签名**
下面的代码示例演示如何从 PFX 证书添加数字签名：

1. 打开 PFX 文件并将 PFX 密码传递给 [**DigitalSignature**](https://reference.aspose.com/slides/net/aspose.slides/digitalsignature) 对象。
1. 将创建的签名添加到演示文稿对象。

```c#
using (Presentation pres = new Presentation())
{
    // 使用 PFX 文件和 PFX 密码创建 DigitalSignature 对象 
    DigitalSignature signature = new DigitalSignature("testsignature1.pfx", @"testpass1");

    // 添加新数字签名的注释
    signature.Comments = "Aspose.Slides 数字签名测试。";

    // 将数字签名添加到演示文稿
    pres.DigitalSignatures.Add(signature);

    // 保存演示文稿
    pres.Save("SomePresentationSigned.pptx", SaveFormat.Pptx);
}
```


现在可以检查演示文稿是否已被数字签名并且没有被修改：

```c#
// 打开演示文稿
using (Presentation pres = new Presentation("SomePresentationSigned.pptx"))
{
    if (pres.DigitalSignatures.Count > 0)
    {
        bool allSignaturesAreValid = true;

        Console.WriteLine("用于签署演示文稿的签名：");

        // 检查所有数字签名是否有效
        foreach (DigitalSignature signature in pres.DigitalSignatures)
        {
            Console.WriteLine(signature.Certificate.SubjectName.Name + ", "
                    + signature.SignTime.ToString("yyyy-MM-dd HH:mm") + " -- " + (signature.IsValid ? "有效" : "无效"));
            allSignaturesAreValid &= signature.IsValid;
        }

        if (allSignaturesAreValid)
            Console.WriteLine("演示文稿是真实的，所有签名都是有效的。");
        else
            Console.WriteLine("演示文稿在签名后已被修改。");
    }
}
```