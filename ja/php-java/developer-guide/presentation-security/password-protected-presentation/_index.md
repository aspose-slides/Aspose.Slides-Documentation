---
title: PHPでプレゼンテーションをパスワード保護する
linktitle: パスワード保護
type: docs
weight: 20
url: /ja/php-java/password-protected-presentation/
keywords:
- パスワード保護されたプレゼンテーション
- オープニング パスワード
- PowerPoint を暗号化
- PowerPoint を復号化
- プレゼンテーション パスワードを検証
- プレゼンテーション パスワードを確認
- 暗号化されたプレゼンテーションを開く
- 暗号化を削除
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して、PHP でパスワード保護された PowerPoint PPT および PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

オープニング パスワードはプレゼンテーションを暗号化します。正しいパスワードが必要であり、プレゼンテーションのコンテンツを読み込み表示する際に使用されるため、この保護は機密性を提供します。

オープニング パスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[Write-Protect Presentations](/slides/ja/php-java/write-protected-presentation/) を参照してください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要な場合に両方の形式を使用しています。

## **オープニング パスワードでプレゼンテーションを暗号化する**

オープニング パスワードを割り当てるには、[ProtectionManager::encrypt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#encrypt) を使用します。その後、暗号化されたプレゼンテーションを永続化するには、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) を使用します。

次の例は PPTX プレゼンテーションを暗号化します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("pres.pptx");
try {
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("encrypted-pres.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **暗号化されたプレゼンテーションの読み込み**

オープニング パスワードを設定するには、[LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) に設定し、ファイルの読み込み時にそのオプションを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) に渡します。オープニング パスワードが必要なのに提供されたパスワードが欠落または正しくない場合、読み込みは失敗します。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # 復号化されたプレゼンテーションを操作する。
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションから暗号化を削除する**

プレゼンテーションをオープニング パスワードで読み込み、[ProtectionManager::removeEncryption](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#removeEncryption) を呼び出して結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込むことができます。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $presentation->getProtectionManager()->removeEncryption();
    $presentation->save("encryption-removed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **読み込み前にオープニング パスワードを検証する**

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して、完全なプレゼンテーション インスタンスを作成せずに [PresentationInfo] を取得します。パスワードの要求または検証を行う前に、[PresentationInfo::isPasswordProtected] を確認します。保護が存在する場合、提供された値を [PresentationInfo::checkPassword] で検証します。

### **ファイルパス ワークフロー**

次の例は PPTX ファイルのオープニング パスワードを検証し、検証された値を [LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) に渡してから、完全なプレゼンテーションを読み込みます：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$filePath = "protected-presentation.pptx";
$password = "open_password";
$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($filePath);

if (!$presentationInfo->isPasswordProtected()) {
    echo("The presentation does not have an opening password.\n");
} elseif (!$presentationInfo->checkPassword($password)) {
    echo("The opening password is incorrect.\n");
} else {
    $loadOptions = new LoadOptions();
    $loadOptions->setPassword($password);

    $presentation = new Presentation($filePath, $loadOptions);
    try {
        echo("The presentation was validated and loaded successfully.\n");
    } finally {
        $presentation->dispose();
    }
}
```

### **ストリーム ワークフロー**

[PresentationFactory::getPresentationInfo] のストリーム オーバーロードは同じワークフローを提供します。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

次の例は PPT ファイルを使用します：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;

$password = "open_password";

$presentationStream = new Java("java.io.FileInputStream", "protected-presentation.ppt");
try {
    $presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($presentationStream);

    if (!$presentationInfo->isPasswordProtected()) {
        echo("The presentation does not have an opening password.\n");
    } elseif (!$presentationInfo->checkPassword($password)) {
        echo("The opening password is incorrect.\n");
    } else {
        $presentationStream->getChannel()->position(0);

        $loadOptions = new LoadOptions();
        $loadOptions->setPassword($password);

        $presentation = new Presentation($presentationStream, $loadOptions);
        try {
            echo("The presentation was validated and loaded successfully.\n");
        } finally {
            $presentation->dispose();
        }
    }
} finally {
    $presentationStream->close();
}
```

### **checkPassword の戻り値**

[PresentationInfo::checkPassword] は、プレゼンテーションにオープニング パスワードが設定され、提供されたパスワードが正しい場合にのみ `true` を返します。以下の場合には `false` を返します：

- パスワードが正しくありません。
- プレゼンテーションにオープニング パスワードが設定されていません。
- 提供されたパスワードが `null` または空です。

この動作は PPT と PPTX のプレゼンテーションで同じです。

## **読み込んだプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[ProtectionManager::isEncrypted] を調べて元のプレゼンテーションが暗号化されていたことを確認します。読み込み前にオープニング パスワード保護を検出するには、上記のように [PresentationInfo::isPasswordProtected] を使用します。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    $isEncrypted = $presentation->getProtectionManager()->isEncrypted();
    echo("The presentation is encrypted: " . ($isEncrypted ? "true" : "false") . "\n");
} finally {
    $presentation->dispose();
}
```

## **セキュリティ推奨事項**

{{% alert color="warning" title="セキュリティ" %}}
オープニング パスワードをログに記録したり診断メッセージに含めたりしないでください。不必要な繰り返しの検証を避け、パスワードは必要な間だけメモリに保持し、プレゼンテーションをすぐに読み込む場合は成功した検証結果を再利用してください。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護を設定する**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
1. プレゼンテーションを選択するかアップロードします。
1. 表示保護用のパスワードを入力します。
1. 必要に応じて、編集保護用の別のパスワードを入力します。
1. 保護を適用し、結果のファイルをダウンロードします。

{{% alert color="info" title="参照" %}}
- [プレゼンテーションの書き込み保護](/slides/ja/php-java/write-protected-presentation/)
- [PowerPoint のデジタル署名](/slides/ja/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**オープニング パスワードと書き込み保護パスワードの違いは何ですか？**

オープニング パスワードはプレゼンテーションを暗号化し、コンテンツを読み込む際に必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドを読み込まずにオープニング パスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープニング パスワード保護が存在するか確認してから、完全なプレゼンテーション インスタンスを作成する前にパスワードを検証します。

**パスワード検証ワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイルパスおよびストリームベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同様に動作します。