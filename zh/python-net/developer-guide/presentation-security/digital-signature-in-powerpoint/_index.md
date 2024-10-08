---
title: PowerPoint中的数字签名
type: docs
weight: 10
url: /python-net/digital-signature-in-powerpoint/
keywords: "数字签名证书, 证书颁发机构, PowerPoint演示文稿, Python, Aspose.Slides for Python via .NET"
description: "在PowerPoint中添加数字签名或证书。Python中的证书颁发机构"
---


**数字证书**用于创建一个密码保护的PowerPoint演示文稿，标记为由特定组织或个人创建。数字证书可以通过联系授权组织——证书颁发机构获取。在将数字证书安装到系统后，可以通过文件 -> 信息 -> 保护演示文稿为演示文稿添加数字签名：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



演示文稿可能包含多个数字签名。在数字签名添加到演示文稿后，PowerPoint中将出现一条特殊消息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



要签署演示文稿或检查演示文稿签名的真实性，**Aspose.Slides API**提供了[**IDigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/idigitalsignature/)接口、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/IDigitalSignatureCollection/)接口和[**IPresentation.DigitalSignatures**](https://reference.aspose.com/slides/python-net/aspose.slides/ipresentation/)属性。目前，数字签名仅支持PPTX格式。
## **从PFX证书添加数字签名**
下面的代码示例演示如何从PFX证书添加数字签名：

1. 打开PFX文件并将PFX密码传递给[**DigitalSignature**](https://reference.aspose.com/slides/python-net/aspose.slides/digitalsignature/)对象。
1. 将创建的签名添加到演示文稿对象中。

```py

#[TODO:Exception] RuntimeError: 代理错误(FileNotFoundException): 无法加载文件或程序集'System.Security.Cryptography.Xml, Version=4.0.2.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'。找不到该文件。

import aspose.slides as slides

with slides.Presentation() as pres:
    # 使用PFX文件和PFX密码创建DigitalSignature对象 
    signature = slides.DigitalSignature(path + "testsignature1.pfx", "testpass1")

    # 注释新的数字签名
    signature.comments = "Aspose.Slides数字签名测试。"

    # 将数字签名添加到演示文稿
    pres.digital_signatures.add(signature)

    # 保存演示文稿
    pres.save("SomePresentationSigned.pptx", slides.export.SaveFormat.PPTX)
```



现在可以检查演示文稿是否已被数字签名且未被修改：



```py
# 打开演示文稿
with slides.Presentation("SomePresentationSigned.pptx") as pres:
    if len(pres.digital_signatures) > 0:
        allSignaturesAreValid = True

        print("用于签署演示文稿的签名： ")
        # 检查所有数字签名是否有效
        for signature in pres.digital_signatures :
            print(signature.certificate.subject_name.name + ", "
                    + signature.sign_time.strftime("yyyy-MM-dd HH:mm") + " -- " + "有效" if signature.is_valid else "无效")
            allSignaturesAreValid = allSignaturesAreValid and signature.is_valid
        

        if allSignaturesAreValid:
            print("演示文稿是真实的，所有签名都是有效的。")
        else:
            print("演示文稿在签署后已被修改。")
```