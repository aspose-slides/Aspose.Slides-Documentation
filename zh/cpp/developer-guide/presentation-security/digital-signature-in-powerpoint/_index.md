---
title: PowerPoint中的数字签名
type: docs
weight: 10
url: /zh/cpp/digital-signature-in-powerpoint/
keywords: "数字签名证书, 证书颁发机构"
description: "使用Aspose.Slides将数字签名证书和证书颁发机构添加到PowerPoint演示文稿中。"
---


**数字证书**用于创建受密码保护的PowerPoint演示文稿，标记为由特定组织或个人创建。数字证书可以通过联系授权机构——证书颁发机构来获取。将数字证书安装到系统后，可以通过文件 -> 信息 -> 保护演示文稿将其用于为演示文稿添加数字签名：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



演示文稿可能包含多个数字签名。在演示文稿添加数字签名后，PowerPoint中将出现一条特殊消息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



要对演示文稿进行签名或检查演示文稿签名的真实性，**Aspose.Slides API**提供了[**IDigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature)接口、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_digital_signature_collection)接口和[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_presentation#a6f78aff0f8ffa07ff67368fa003722b1)方法。目前，仅支持PPTX格式的数字签名。
## **从PFX证书添加数字签名**
下面的代码示例演示了如何从PFX证书添加数字签名：

1. 打开PFX文件并将PFX密码传递给[**DigitalSignature**](https://reference.aspose.com/slides/cpp/class/aspose.slides.digital_signature)对象。
1. 将创建的签名添加到演示文稿对象。

``` cpp
auto pres = System::MakeObject<Presentation>();

// 创建具有PFX文件和PFX密码的DigitalSignature对象 
auto signature = System::MakeObject<DigitalSignature>(u"testsignature1.pfx", u"testpass1");

// 评论新的数字签名
signature->set_Comments(u"Aspose.Slides数字签名测试。");

// 将数字签名添加到演示文稿
pres->get_DigitalSignatures()->Add(signature);

// 保存演示文稿
pres->Save(u"SomePresentationSigned.pptx", SaveFormat::Pptx);
```

现在可以检查演示文稿是否已数字签名并且未被修改：

``` cpp
// 打开演示文稿
auto pres = System::MakeObject<Presentation>(u"SomePresentationSigned.pptx");

if (pres->get_DigitalSignatures()->get_Count() > 0)
{
    bool allSignaturesAreValid = true;

    Console::WriteLine(u"用于签署演示文稿的签名：");

    // 检查所有数字签名是否有效
    for (auto signature : pres->get_DigitalSignatures())
    {
        Console::WriteLine(signature->get_Certificate()->get_SubjectName()->get_Name() 
            + u"，" 
            + signature->get_SignTime().ToString(u"yyyy-MM-dd HH:mm") 
            + u" -- " 
            + (signature->get_IsValid() ? System::String(u"有效") : System::String(u"无效")));
        allSignaturesAreValid &= signature->get_IsValid();
    }

    if (allSignaturesAreValid)
    {
        Console::WriteLine(u"演示文稿是真正的，所有签名都是有效的。");
    }
    else
    {
        Console::WriteLine(u"演示文稿在签名后已被修改。");
    }
}
```