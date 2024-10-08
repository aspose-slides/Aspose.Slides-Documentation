---
title: PowerPoint中的数字签名
type: docs
weight: 10
url: /zh/php-java/digital-signature-in-powerpoint/
keywords: "数字签名证书, 证书颁发机构"
description: "使用Aspose.Slides将数字签名证书和证书颁发机构添加到PowerPoint演示文稿中。"
---


**数字证书**用于创建受密码保护的PowerPoint演示文稿，标记为由特定组织或个人创建。数字证书可以通过联系授权组织（即证书颁发机构）来获取。在将数字证书安装到系统后，可以通过文件 -> 信息 -> 保护演示文稿将数字签名添加到演示文稿中：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)



演示文稿可以包含多个数字签名。在将数字签名添加到演示文稿后，PowerPoint中将出现一条特殊消息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)



要对演示文稿进行签名或检查演示文稿签名的真实性，**Aspose.Slides API**提供了[**IDigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignature)接口、[**IDigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IDigitalSignatureCollection)接口和[**IPresentation.getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentation#getDigitalSignatures--)方法。目前，仅支持PPTX格式的数字签名。
## **从PFX证书添加数字签名**
以下代码示例演示如何从PFX证书添加数字签名：

1. 打开PFX文件并将PFX密码传递给[**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature)对象。
1. 将创建的签名添加到演示文稿对象中。

```php
  # 打开演示文稿文件
  $pres = new Presentation();
  try {
    # 创建带有PFX文件和PFX密码的DigitalSignature对象
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # 添加新数字签名注释
    $signature->setComments("Aspose.Slides数字签名测试。");
    # 添加数字签名到演示文稿
    $pres->getDigitalSignatures()->add($signature);
    # 保存演示文稿
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

现在可以检查演示文稿是否经过数字签名并且未被修改：

```php
  # 打开演示文稿
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("用于签署演示文稿的签名：");
      # 检查所有数字签名是否有效
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "有效" : "无效");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("演示文稿是真实的，所有签名都有效。");
      } else {
        echo("演示文稿自签名以来已被修改。");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```