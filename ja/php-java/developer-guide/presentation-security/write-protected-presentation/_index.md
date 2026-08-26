---
title: PHP でプレゼンテーションを書き込み保護する
linktitle: 書き込み保護
type: docs
weight: 25
url: /ja/php-java/write-protected-presentation/
keywords:
- 書き込み保護
- PowerPoint の書き込み保護
- 変更用パスワード
- プレゼンテーションの編集制限
- 書き込み保護の削除
- 変更パスワードの検証
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して、PowerPoint PPT および PPTX プレゼンテーションの書き込み保護パスワードの設定、検出、検証、削除を行います。"
---
## **はじめに**

書き込み保護パスワードはプレゼンテーションの変更を制限しますが、コンテンツを暗号化はしません。ユーザーはパスワードなしで書き込み保護されたプレゼンテーションを読み込み、表示できます。アプリケーションによっては、コンテンツを編集して別名で保存できる場合もあるため、書き込み保護を機密性の手段として扱ってはいけません。

開くためのパスワードは別の目的を持ちます。プレゼンテーションを暗号化し、コンテンツを読み込む際に必要です。プレゼンテーションを暗号化するか、開くためのパスワードを検証するには、[Password-Protect Presentations](/slides/ja/php-java/password-protected-presentation/)をご覧ください。

本記事のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では PPTX ファイルを使用しています。PPT で保存する場合は `.ppt` 拡張子と対応する PPT の保存形式を使用してください。

## **プレゼンテーションへの書き込み保護の設定**

[ProtectionManager::setWriteProtection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#setWriteProtection) を使用して、プレゼンテーションの変更用パスワードを割り当てます。プレゼンテーションを保存すると、保護設定が保持されます。

以下の例は PPTX プレゼンテーションに書き込み保護を設定します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->setWriteProtection("modify_password");
    $presentation->save("write-protected-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **書き込み保護されたプレゼンテーションの読み込み**

書き込み保護はプレゼンテーションのコンテンツを暗号化しないため、プレゼンテーションの読み込みにパスワードは不要です。パスワードは保護されたプレゼンテーションの変更権限を検証するときにのみ関係します。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    echo("Slide count: " . $presentation->getSlides()->size() . "\n");
} finally {
    $presentation->dispose();
}
```

[LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) に書き込み保護パスワードを渡さないでください。このメソッドは暗号化されたコンテンツ用の開くためのパスワードを受け取ります。プレゼンテーションが両方の保護タイプを持つ場合は、開くためのパスワードを提供して読み込み、書き込み保護パスワードは別途処理してください。

## **プレゼンテーションから書き込み保護を削除する**

[ProtectionManager::removeWriteProtection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#removeWriteProtection) を使用して変更制限を解除し、プレゼンテーションを保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("write-protected-pres.pptx");
try {
    $presentation->getProtectionManager()->removeWriteProtection();
    $presentation->save("write-protection-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションが書き込み保護されているか確認する**

完全な [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを作成せずにファイルを検査するには、[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/#getPresentationInfo) を呼び出し、[PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#isWriteProtected) を確認します。このメソッドは [NullableBool](https://reference.aspose.com/slides/ja/php-java/aspose.slides/nullablebool/) を使用し、書き込み保護が検出された場合は `NullableBool::True` を返します。

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() == NullableBool::True) {
    echo("The presentation is write protected.\n");
} else {
    echo("Write protection was not detected.\n");
}
```

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/#getPresentationInfo) のストリームオーバーロードは、ストリームとして提供されたプレゼンテーションに対して同じ情報を提供します。

## **書き込み保護パスワードの検証**

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#checkWriteProtection) を使用して、完全なプレゼンテーションを読み込まずに変更パスワードを検証します。まず [PresentationInfo::isWriteProtected](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#isWriteProtected) を確認し、書き込み保護がある場合にのみアプリケーションがパスワードを要求または検証するようにします。

```php
use aspose\slides\NullableBool;
use aspose\slides\PresentationFactory;

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo("write-protected-pres.pptx");

if ($presentationInfo->isWriteProtected() != NullableBool::True) {
    echo("The presentation is not write protected.\n");
} elseif ($presentationInfo->checkWriteProtection("modify_password")) {
    echo("The write-protection password is correct.\n");
} else {
    echo("The write-protection password is incorrect.\n");
}
```

[PresentationInfo::checkWriteProtection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#checkWriteProtection) は書き込み保護パスワードのみを検証し、開くためのパスワードの検証や暗号化されたコンテンツが読み込めるかどうかは判定しません。逆に、[PresentationInfo::checkPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#checkPassword) は開くためのパスワードのみを検証します。完全なプレゼンテーションがすでに読み込まれている場合、[ProtectionManager::checkWriteProtection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#checkWriteProtection) が保護マネージャーを通じて同等の書き込み保護チェックを提供します。

本番アプリケーションでは、パスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返しの検証を避け、パスワードは必要な期間だけメモリに保持してください。

{{% alert color="info" title="参照" %}}
- [プレゼンテーションのパスワード保護](/slides/ja/php-java/password-protected-presentation/)
- [読み取り専用プレゼンテーション](/slides/ja/php-java/read-only-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**書き込み保護はプレゼンテーションを暗号化しますか？**

いいえ。変更を制限しますが、プレゼンテーションのコンテンツは読み込みや表示のために利用可能なままです。

**書き込み保護パスワードはプレゼンテーションを開く際に必要ですか？**

いいえ。暗号化されたプレゼンテーションのコンテンツを読み込むには、開くためのパスワードのみが必要です。

**プレゼンテーションは開くためのパスワードと書き込み保護パスワードの両方を持つことができますか？**

はい。暗号化されたプレゼンテーションを開くにはロードオプションで開くためのパスワードを指定し、変更権限が必要な場合は書き込み保護パスワードを別途検証してください。