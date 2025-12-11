---
title: 在 C++ 中为演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/cpp/digital-signature-in-powerpoint/
keywords:
- 数字签名
- 数字证书
- 证书颁发机构
- PFX证书
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 对 PowerPoint 和 OpenDocument 文件进行数字签名。只需几秒钟即可通过清晰的代码示例保护您的幻灯片。"
---

**数字证书** 用于创建受密码保护的 PowerPoint 演示文稿，并标记为由特定组织或个人创建。可以通过联系授权组织——证书颁发机构来获取数字证书。将数字证书安装到系统后，可通过 File -> Info -> Protect Presentation 为演示文稿添加数字签名：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

演示文稿可能包含多个数字签名。添加数字签名后，PowerPoint 中会出现一条特殊消息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

要对演示文稿进行签名或检查签名的真实性，**Aspose.Slides API** 提供[**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature)接口、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection)接口和[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1)方法。目前，仅在 PPTX 格式下支持数字签名。

## **Add a Digital Signature from a PFX Certificate**
下面的代码示例演示如何使用 PFX 证书添加数字签名：

1. 打开 PFX 文件并将 PFX 密码传递给[**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature)对象。  
2. 将创建的签名添加到演示文稿对象。

``` cpp
auto pres = System::MakeObject<Presentation>();

// 使用 PFX 文件和 PFX 密码创建 DigitalSignature 对象 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// 为新数字签名添加注释
signature->set_Comments(u"Aspose.Slides digital signing test.");

// 将数字签名添加到演示文稿
pres->get_DigitalSignatures()->Add(signature);

// 保存演示文稿
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```



现在可以检查演示文稿是否已数字签名且未被修改：

``` cpp
// 打开演示文稿
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"Signatures used to sign the presentation: ");

    // 检查所有数字签名是否有效
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u", " 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"VALID") : System::String(u"INVALID")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"Presentation is genuine, all signatures are valid.");
    }
    else
    {
        Console::WriteLine(u"Presentation has been modified since signing.");
    }
}
```


## **FAQ**

**Can I remove existing signatures from a file?**  
是的。数字签名集合支持[删除单个项](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/removeat/)和[全部清除](https://reference.aspose.com/slides/cpp/aspose.slides/digitalsignaturecollection/clear/)；保存文件后，演示文稿将不再包含任何签名。

**Does the file become "read-only" after signing?**  
不会。签名保持完整性和作者信息，但并不阻止编辑。如需限制编辑，可结合使用[“只读”或密码](/slides/zh/cpp/password-protected-presentation/)。

**Will the signature display correctly in different versions of PowerPoint?**  
签名是为 OOXML（PPTX）容器创建的。支持 OOXML 签名的现代 PowerPoint 版本会正确显示这些签名的状态。