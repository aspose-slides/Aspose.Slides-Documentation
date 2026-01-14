---
title: 在 PHP 中为演示文稿添加数字签名
linktitle: 数字签名
type: docs
weight: 10
url: /zh/php-java/digital-signature-in-powerpoint/
keywords:
- 数字签名
- 数字证书
- 证书颁发机构
- PFX 证书
- PowerPoint
- OpenDocument
- 演示文稿
- PHP
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for PHP（通过 Java）对 PowerPoint 与 OpenDocument 文件进行数字签名。只需几秒钟，使用清晰的代码示例即可保护您的幻灯片。"
---

**数字证书**用于创建受密码保护的 PowerPoint 演示文稿，并标记为由特定组织或个人创建。数字证书可通过联系授权机构——证书颁发机构获取。将数字证书安装到系统后，可通过 文件 → 信息 → 保护演示文稿 为演示文稿添加数字签名：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

演示文稿可能包含多个数字签名。将数字签名添加到演示文稿后，PowerPoint 中会显示一条特殊消息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

要签署演示文稿或检查演示文稿签名的真实性，**Aspose.Slides API** 提供了[**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature) 类、[**DigitalSignatureCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignatureCollection) 类以及[**Presentation::getDigitalSignatures**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getDigitalSignatures) 方法。目前，仅在 PPTX 格式中支持数字签名。

## **从 PFX 证书添加数字签名**
下面的代码示例演示如何从 PFX 证书添加数字签名：

1. 打开 PFX 文件并将 PFX 密码传递给[**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature) 对象。  
1. 将创建的签名添加到演示文稿对象。  
```php
  # 打开演示文稿文件
  $pres = new Presentation();
  try {
    # 使用 PFX 文件和 PFX 密码创建 DigitalSignature 对象
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # 为新的数字签名添加注释
    $signature->setComments("Aspose.Slides digital signing test.");
    # 将数字签名添加到演示文稿
    $pres->getDigitalSignatures()->add($signature);
    # 保存演示文稿
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


现在可以检查演示文稿是否已数字签名且未被修改：
```php
  # 打开演示文稿
  $pres = new Presentation("SomePresentationSigned.pptx");
  try {
    if (java_values($pres->getDigitalSignatures()->size()) > 0) {
      $allSignaturesAreValid = true;
      echo("Signatures used to sign the presentation: ");
      # 检查所有数字签名是否有效
      foreach($pres->getDigitalSignatures() as $signature) {
        echo($signature->getComments() . ", " . $signature->getSignTime()->toString() . " -- " . $signature->isValid() ? "VALID" : "INVALID");
        $allSignaturesAreValid &= $signature->isValid();
      }
      if ($allSignaturesAreValid) {
        echo("Presentation is genuine, all signatures are valid.");
      } else {
        echo("Presentation has been modified since signing.");
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**我可以删除文件中已有的签名吗？**

可以。数字签名集合支持[删除单个项目](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/)和[完全清除](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/)；保存文件后，演示文稿将不再拥有签名。

**签名后文件会变成“只读”吗？**

不会。签名可以保留完整性和作者信息，但不会阻止编辑。若需限制编辑，可结合["只读"或密码](/slides/zh/php-java/password-protected-presentation/)使用。

**签名在不同版本的 PowerPoint 中能正确显示吗？**

签名是为 OOXML（PPTX）容器创建的。支持 OOXML 签名的现代 PowerPoint 版本能够正确显示此类签名的状态。