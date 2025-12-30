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
description: "了解如何使用 Aspose.Slides for PHP (via Java) 对 PowerPoint 与 OpenDocument 文件进行数字签名。只需几秒钟即可通过清晰的代码示例保护您的幻灯片。"
---

**数字证书** 用于创建受密码保护的 PowerPoint 演示文稿，并标记为由特定组织或个人创建。可以通过联系授权机构（证书颁发机构）获取数字证书。将数字证书安装到系统后，可通过 文件 -> 信息 -> 保护演示文稿 将其用于向演示文稿添加数字签名：

![todo:image_alt_text](https://lh5.googleusercontent.com/OPGhgHMb_L54PGJztP5oIO9zhxGXzhtnbcrC-z7yLUrc_NkRX1obBfwffXhPV1NWBiqhidiupCphixNGl25LkfQhliG6MCM6E-x16ZuQgMyLABC9bQ446ohMluZr6-ThgQLXCOyy)

演示文稿可能包含多个数字签名。数字签名添加到演示文稿后，PowerPoint 中会出现一条特殊信息：

![todo:image_alt_text](https://lh3.googleusercontent.com/7ZfH7wElhwcvgJ_btF3C32zasBRbT1yA4tFOpnNnUm0q57ayBKJr0Pb43Oi4RgeCoOmwhyxxz_g8kw3H3Qw8Iqeaka5Xipip9cqvwbadY4E40D_NhXnUnbtdXSHFX6fjNm_UBvLJ)

要对演示文稿进行签名或检查演示文稿签名的真实性，**Aspose.Slides API** 提供 **IDigitalSignature** 接口、**IDigitalSignatureCollection** 接口以及 **IPresentation.getDigitalSignatures** 方法。目前，数字签名仅支持 PPTX 格式。

## **从 PFX 证书添加数字签名**
以下代码示例演示如何从 PFX 证书添加数字签名：

1. 打开 PFX 文件并将 PFX 密码传递给 [**DigitalSignature**](https://reference.aspose.com/slides/php-java/aspose.slides/DigitalSignature) 对象。
1. 将创建的签名添加到演示文稿对象。
```php
  # 打开演示文稿文件
  $pres = new Presentation();
  try {
    # 使用 PFX 文件和 PFX 密码创建 DigitalSignature 对象
    $signature = new DigitalSignature("testsignature1.pfx", "testpass1");
    # 为新数字签名添加注释
    $signature->setComments("Aspose.Slides digital signing test.");
    # 将数字签名添加到演示文稿
    $pres->getDigitalSignatures()->add($signature);
    # 保存演示文稿
    $pres->save("SomePresentationSigned.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


现在可以检查演示文稿是否已进行数字签名且未被修改：
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


## **常见问题**

**我可以删除文件中现有的签名吗？**

是的。数字签名集合支持 [删除单个项目](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/removeat/) 和 [完全清除](https://reference.aspose.com/slides/php-java/aspose.slides/digitalsignaturecollection/clear/)；保存文件后，演示文稿将不再有签名。

**签名后文件会变成“只读”吗？**

不是。签名可以保持完整性和作者身份，但不会阻止编辑。要限制编辑，可将其与 ["只读" 或密码](/slides/zh/php-java/password-protected-presentation/) 结合使用。

**签名会在不同版本的 PowerPoint 中正确显示吗？**

该签名是为 OOXML（PPTX）容器创建的。支持 OOXML 签名的现代 PowerPoint 版本会正确显示此类签名的状态。