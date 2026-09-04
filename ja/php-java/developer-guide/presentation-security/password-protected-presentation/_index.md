---
title: PHP でプレゼンテーションにパスワード保護を設定する
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
- 暗号化を除去
- PowerPoint
- PPT
- PPTX
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides を利用して、PHP でパスワード保護された PowerPoint の PPT と PPTX プレゼンテーションを暗号化、検出、検証、開く、復号化します。"
---
## **概要**

オープニング パスワードはプレゼンテーションを暗号化します。正しいパスワードが必要で、プレゼンテーションのコンテンツを読み込み表示できるため、この保護は機密性を提供します。

オープニング パスワードは書き込み保護パスワードとは異なります。書き込み保護は変更を制限しますが、コンテンツを暗号化したりプレゼンテーションの読み込みを防止したりはしません。プレゼンテーションの変更用パスワードを管理するには、[書き込み保護されたプレゼンテーション](/slides/ja/php-java/write-protected-presentation/)をご覧ください。

以下のワークフローは PPT と PPTX の両方のプレゼンテーションに適用されます。例では、ファイルベースとストリームベースの動作が重要な場合の両形式を使用しています。

## **オープニング パスワードでプレゼンテーションを暗号化する**

[ProtectionManager::encrypt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#encrypt) を使用してオープニング パスワードを割り当てます。その後、[Presentation::save](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#save) を使用して暗号化されたプレゼンテーションを永続化します。

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

## **ドキュメント プロパティを公開したままにする**

既定では、Aspose.Slides はプレゼンテーション暗号化にドキュメント プロパティを含めます。[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) メソッドは、スライド コンテンツの暗号化とは独立してこの動作を制御します。インデックス作成、分類、検索、またはドキュメント管理システムがオープニング パスワードなしでメタデータを読み取る必要がある場合は、[ProtectionManager::encrypt](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#encrypt) を呼び出す前に `false` を渡します。

次の例は、組み込みドキュメント プロパティを公開したまま暗号化された PPTX プレゼンテーションを作成します：

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $properties = $presentation->getDocumentProperties();
    $properties->setAuthor("Contoso Knowledge Management");
    $properties->setTitle("Quarterly Product Roadmap");
    $properties->setKeywords("roadmap, planning, internal");

    $presentation->getSlides()->get_Item(0)->setName("Encrypted presentation content");
    $presentation->getProtectionManager()->setEncryptDocumentProperties(false);
    $presentation->getProtectionManager()->encrypt("open_password");
    $presentation->save("public-properties-encrypted.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) に `false` を渡しても、スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション コンテンツが公開されるわけではありません。影響を受けるのはドキュメント プロパティだけです。暗号化されたコンテンツを読み込まずにそれらのプロパティを取得する方法については、[Manage Presentation Properties](/slides/ja/php-java/presentation-properties/) を参照してください。

## **暗号化されたプレゼンテーションを読み込む**

[LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) にオープニング パスワードを設定し、ファイルの読み込み時にオプションを [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) に渡します。オープニング パスワードが必要なのにパスワードが提供されていない、または誤っている場合は読み込みが失敗します。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation("encrypted-pres.pptx", $loadOptions);
try {
    # 復号化されたプレゼンテーションを扱う。
} finally {
    $presentation->dispose();
}
```

## **プレゼンテーションから暗号化を除去する**

プレゼンテーションをオープニング パスワードで読み込み、[ProtectionManager::removeEncryption](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#removeEncryption) を呼び出し、結果を保存します。保存されたプレゼンテーションはパスワードなしで読み込めるようになります。

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

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/#getPresentationInfo) を使用して、完全なプレゼンテーション インスタンスを作成せずに [PresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/) を取得します。[PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#isPasswordProtected) を確認してから、パスワードの要求または検証を行います。保護が存在する場合は、[PresentationInfo::checkPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#checkPassword) で提供された値を検証します。

### **ファイル パス ワークフロー**

次の例は PPTX ファイルのオープニング パスワードを検証し、検証済みの値を [LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) に渡してから完全なプレゼンテーションを読み込みます：

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

[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/#getPresentationInfo) のストリーム オーバーロードでも同様のワークフローが提供されます。ストリームから完全なプレゼンテーションを読み込む前に、シーク可能なストリームの位置をリセットしてください。

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

[PresentationInfo::checkPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#checkPassword) は、プレゼンテーションにオープニング パスワードが設定され、提供されたパスワードが正しい場合にのみ `true` を返します。次の場合は `false` を返します：

- パスワードが正しくない。
- プレゼンテーションにオープニング パスワードが設定されていない。
- 提供されたパスワードが `null` もしくは空文字列。

この動作は PPT と PPTX の両方で同じです。

## **読み込まれたプレゼンテーションが暗号化されているか確認する**

正しいパスワードでプレゼンテーションを読み込んだ後、[ProtectionManager::isEncrypted](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#isEncrypted) を調べて、元のプレゼンテーションが暗号化されていたか確認します。読み込み前にオープニング パスワード保護を検出するには、上記と同様に [PresentationInfo::isPasswordProtected](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#isPasswordProtected) を使用します。

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

## **セキュリティに関する推奨事項**

{{% alert color="warning" title="Security" %}}
オープニング パスワードをログに記録したり診断メッセージに含めたりしないでください。不要な繰り返し検証は避け、パスワードは必要な期間だけメモリに保持し、プレゼンテーションを直ちに読み込む場合は成功した検証結果を再利用してください。

ドキュメント プロパティは、プレゼンテーション コンテンツが暗号化されていても、作者名、タイトル、テーマ、キーワード、会社情報、コメント、カスタム値などを公開する可能性があります。機密メタデータはプレゼンテーションと同時に暗号化してください。プロパティを公開したままにするのは、システムがオープニング パスワードなしでファイルをインデックス、分類、検索、または管理しなければならない場合に限り、明示的に決定すべきです。
{{% /alert %}}

## **オンラインでプレゼンテーションにパスワード保護を設定する**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ja/lock) アプリケーションを開きます。
2. プレゼンテーションを選択またはアップロードします。
3. 表示保護用のパスワードを入力します。
4. 必要に応じて編集保護用の別のパスワードを入力します。
5. 保護を適用し、結果のファイルをダウンロードします。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ja/php-java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ja/php-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**オープニング パスワードと書き込み保護パスワードの違いは何ですか？**

オープニング パスワードはプレゼンテーションを暗号化し、コンテンツの読み込みに必要です。書き込み保護パスワードはコンテンツを暗号化せずに変更を制限します。

**すべてのスライドを読み込まずにオープニング パスワードを検証できますか？**

はい。プレゼンテーション情報を取得し、オープニング パスワード保護があるか確認してから、完全なプレゼンテーション インスタンスを作成せずにパスワードを検証できます。

**アプリケーションはオープニング パスワードなしでメタデータを読み取れますか？**

はい、ただしプレゼンテーションが「ドキュメント プロパティの暗号化」設定なしで暗号化されている場合に限ります。その場合は、[Manage Presentation Properties](/slides/ja/php-java/presentation-properties/) で説明されているドキュメント プロパティのみの読み込みモードを使用してください。

**パスワード検証ワークフローは PPT と PPTX の両方に対応していますか？**

はい。ファイル パスおよびストリーム ベースのパスワード検出と検証は、PPT と PPTX のプレゼンテーションで同じように動作します。