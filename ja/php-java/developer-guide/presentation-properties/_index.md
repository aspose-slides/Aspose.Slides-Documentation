---
title: PHPでプレゼンテーション プロパティを管理
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/php-java/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメントプロパティ
- 組み込みプロパティ
- カスタムプロパティ
- 詳細プロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides for PHP via Java は **組み込み** と **カスタム** のドキュメントプロパティをサポートしています。これらのプロパティを使用して、作者、タイトル、ユーザー定義値などのプレゼンテーション メタデータを読み取りおよび更新できます。

Aspose.Slides では、[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) クラスを通じてプレゼンテーションのドキュメントプロパティを操作できます。このクラスのインスタンスは[Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/)で取得されます。以下の例は、これらのプロパティの読み取り、変更、管理方法を示しています。PHP/Java Bridge と Aspose.Slides PHP ラッパーが初期化されていることを前提としています。

{{% alert color="info" title="Note" %}}
Aspose.Slides はプレゼンテーションを保存する際にアプリケーションと製作者のメタデータを管理します。これらのフィールドは出力を作成したソフトウェアを識別します。
{{% /alert %}}

## **プレゼンテーション プロパティの管理**

ドキュメントプロパティは、プレゼンテーション コンテンツと共に記述情報を保存します。これらは 2 つのカテゴリに分かれます：

- **組み込みプロパティ** は、タイトル、作者、ドキュメント統計などの標準メタデータを含みます。
- **カスタムプロパティ** は、ユーザー定義の名前/値のペアを保存します。

Aspose.Slides for PHP via Java は両方のカテゴリへのアクセスを提供します。PowerPoint では、**ファイル → 情報 → プロパティ → 詳細プロパティ** を選択してドキュメントメタデータを確認します。ダイアログは情報を **概要**、**統計**、**コンテンツ**、**カスタム** といったタブに分類します。ユーザー定義プロパティを管理するには **カスタム** タブを使用します。

## **暗号化されたプレゼンテーションから公開プロパティを読み取る**

通常、開始パスワードはプレゼンテーションのコンテンツとドキュメントプロパティの両方を保護します。[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) を `false` で呼び出した後にプレゼンテーションが暗号化されると、ドキュメントプロパティは公開されたままになります。アプリケーションはその後、[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) を `true` で呼び出し、開始パスワードを提供せずに公開メタデータを読み取ることができます。

[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) は Aspose.Slides の読み込み対象を制御します。暗号化は行われません。プロパティが暗号化に含まれている場合、パスワードなしでの読み込みは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体が読み込まれます。

この例では、ドキュメントプロパティが公開されたままの暗号化プレゼンテーションが必要です。[ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) でロードモードを確認し、続いて [Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) を使用して組み込みプロパティを読み取ります。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $documentProperties = $presentation->getDocumentProperties();

        echo("Author: " . $documentProperties->getAuthor() . "\n");
        echo("Title: " . $documentProperties->getTitle() . "\n");
        echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $presentation->dispose();
}
```

このモードではスライド コンテンツは読み込まれません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクト モデルが必要な操作を実行する前に、必ず [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/isonlydocumentpropertiesloaded/) を確認してください。

{{% alert color="warning" title="Warning" %}}
公開メタデータにより、作者名、タイトル、主題、キーワード、会社情報、コメント、カスタム値が漏洩する可能性があります。機密性の高いプロパティはプレゼンテーションとともに暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特定の要件がある場合にのみ、公開のままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティ更新**

暗号化された PPTX ファイルの場合、[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) を `true` で呼び出して読み込まれたプレゼンテーションは、公開メタデータを読み取ることを目的としています。Aspose.Slides はそのメタデータのみのオブジェクトから変更されたプロパティを保存できません。公開プロパティは暗号化されたプレゼンテーション内の対応するデータと一貫性を保つ必要があるため、更新には正しい開始パスワードと完全なロードが必要です。

この例では、公開ドキュメントプロパティを持つ暗号化 PPTX プレゼンテーションと既知の開始パスワードが必要です。[LoadOptions::setPassword](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setpassword/) を使用してプレゼンテーション全体を開き、公開組み込みプロパティを更新して結果を保存します。その後、[PresentationInfo::isEncrypted](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/isencrypted/) で暗号化が保持されていることを確認し、パスワードなしで公開メタデータを再度開いて新しい値を検証します：

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\PresentationFactory;
use aspose\slides\SaveFormat;

$inputPath = "public-properties-encrypted.pptx";
$outputPath = "updated-public-properties-encrypted.pptx";

$loadOptions = new LoadOptions();
$loadOptions->setPassword("open_password");

$presentation = new Presentation($inputPath, $loadOptions);
try {
    $documentProperties = $presentation->getDocumentProperties();
    $documentProperties->setTitle("Updated Product Roadmap");
    $documentProperties->setKeywords("roadmap, planning, indexed");
    
    $presentation->save($outputPath, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$presentationInfo = PresentationFactory::getInstance()->getPresentationInfo($outputPath);
echo("The presentation is encrypted: " . (java_values($presentationInfo->isEncrypted()) ? "true" : "false") . "\n");

$metadataLoadOptions = new LoadOptions();
$metadataLoadOptions->setOnlyLoadDocumentProperties(true);

$metadataPresentation = new Presentation($outputPath, $metadataLoadOptions);
try {
    if (java_values($metadataPresentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        echo("Title: " . $metadataPresentation->getDocumentProperties()->getTitle() . "\n");
        echo("Keywords: " . $metadataPresentation->getDocumentProperties()->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode." . "\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

アプリケーションがプレゼンテーション コンテンツの復号またはロードを許可されていない場合、暗号化された PPTX ファイルの公開プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/) クラスは、[getAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getauthor/)、[getTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gettitle/)、[getCreatedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcreatedtime/) などの getter メソッドを通じて組み込みメタデータを公開します。この例は既存のプレゼンテーションを開き、保存されたメタデータをコンソールに出力します。値は入力プレゼンテーションに依存し、いくつかのフィールドは空の場合があります。

```php
use aspose\slides\Presentation;

$presentation = new Presentation("AccessBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    echo("Category: " . $documentProperties->getCategory() . "\n");
    echo("Content status: " . $documentProperties->getContentStatus() . "\n");
    echo("Creation date: " . $documentProperties->getCreatedTime() . "\n");
    echo("Author: " . $documentProperties->getAuthor() . "\n");
    echo("Comments: " . $documentProperties->getComments() . "\n");
    echo("Keywords: " . $documentProperties->getKeywords() . "\n");
    echo("Last modified by: " . $documentProperties->getLastSavedBy() . "\n");
    echo("Manager: " . $documentProperties->getManager() . "\n");
    echo("Modified date: " . $documentProperties->getLastSavedTime() . "\n");
    echo("Presentation format: " . $documentProperties->getPresentationFormat() . "\n");
    echo("Last print date: " . $documentProperties->getLastPrinted() . "\n");
    echo("Is shared between producers: " . (java_values($documentProperties->getSharedDoc()) ? "true" : "false") . "\n");
    echo("Subject: " . $documentProperties->getSubject() . "\n");
    echo("Title: " . $documentProperties->getTitle() . "\n");
} finally {
    $presentation->dispose();
}
```

## **組み込みプロパティの変更**

組み込みメタデータを更新するには、[Presentation::getDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getdocumentproperties/) が返すオブジェクトの setter メソッドを使用します。この例は既存のプレゼンテーションを開き、[setAuthor](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setauthor/)、[setTitle](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/settitle/)、[setSubject](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setsubject/)、[setComments](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setcomments/)、[setManager](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/setmanager/) を呼び出し、[Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) で更新したプレゼンテーションを保存します。保存された PPTX には新しいメタデータが含まれます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ModifyBuiltInProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->setAuthor("Aspose.Slides for PHP via Java");
    $documentProperties->setTitle("Manage PowerPoint Presentation Properties");
    $documentProperties->setSubject("Modify Built-in Properties");
    $documentProperties->setComments("Aspose description");
    $documentProperties->setManager("Aspose manager");

    $presentation->save("DocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ハイパーリンクベースの管理**

[DocumentProperties::getHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/gethyperlinkbase/) は相対ハイパーリンク用のドキュメント レベルのベースを返します。[DocumentProperties::setHyperlinkBase](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/sethyperlinkbase/) を使用して変更またはクリアできます。プレゼンテーションとリンクされたファイルを別の場所に移動する際に便利です。これは個々のハイパーリンクの[Hyperlink::getExternalUrl](https://reference.aspose.com/slides/php-java/aspose.slides/hyperlink/getexternalurl/)とは別で、ベースを変更しても保存されたリンクアドレスや絶対的な宛先は書き換えられません。

この例では、`target.html` のような相対リンクと `https://example.org/absolute.html` のような絶対リンクの両方を含むプレゼンテーションが必要です。既存のベースを読み取り、新しいベース アドレスを設定し、プレゼンテーションを保存して再度開き値を確認します。その後、空文字列でベースをクリアし、別の保存ファイルで空の値を検証します。例のベース アドレスはリンクされたファイルの場所に置き換えてください。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("hyperlinks.pptx");
try {
    echo("Original base: " . $presentation->getDocumentProperties()->getHyperlinkBase() . "\n");

    $newBase = "https://example.com/new/";
    $presentation->getDocumentProperties()->setHyperlinkBase($newBase);
    $presentation->save("hyperlinks-updated.pptx", SaveFormat::Pptx);

    $updatedPresentation = new Presentation("hyperlinks-updated.pptx");
    try {
        echo("Base preserved: " . ((string) $updatedPresentation->getDocumentProperties()->getHyperlinkBase() === $newBase ? "true" : "false") . "\n");

        $updatedPresentation->getDocumentProperties()->setHyperlinkBase("");
        $updatedPresentation->save("hyperlinks-cleared.pptx", SaveFormat::Pptx);

        $clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
        try {
            echo("Base cleared: " . ((string) $clearedPresentation->getDocumentProperties()->getHyperlinkBase() === "" ? "true" : "false") . "\n");
        } finally {
            $clearedPresentation->dispose();
        }
    } finally {
        $updatedPresentation->dispose();
    }
} finally {
    $presentation->dispose();
}
```

2 つの検証メッセージは `true` と出力されるはずです。ベースをクリアしても個々のハイパーリンク アドレスはそのまま残ります。

`target.pptx` への相対リンクは、ベースが `old` フォルダーを指しているときに `old/target.pptx` を開きました。ベースを `new` フォルダーに変更し、保存してプレゼンテーションを再度開くと、同じリンクは `new/target.pptx` を開きます。絶対リンクは同じファイルを開き続けます。プレゼンテーションを移動したりベースを変更したりする前後で、PowerPoint で相対リンクをテストしてください。

## **カスタム プレゼンテーション プロパティの追加**

カスタムプロパティは、対応する組み込みフィールドがないメタデータを保存します。[DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) メソッドを使用すると、プロパティ名で値を割り当てられます。この例はプレゼンテーションを作成し、2 つのテキスト値と整数のバージョン値を追加し、[Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) で保存します。既存の名前に値を割り当てると、そのプロパティの値が置き換えられます。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $documentProperties = $presentation->getDocumentProperties();

    $documentProperties->set_Item("Reviewed by", "John Smith");
    $documentProperties->set_Item("Confidentiality level", "Internal");
    $documentProperties->set_Item("Document version", 2);

    $presentation->save("CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **カスタムプロパティへのアクセスと変更**

この例はカスタムプロパティを含むプレゼンテーションを開き、[getCountOfCustomProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcountofcustomproperties/) を使用してそれらを反復処理します。[getCustomPropertyName](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/getcustompropertyname/) は 0 ベースのインデックスを受け取り、[DocumentProperties::set_Item](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/set_item/) で使用される名前を返します。例では各元の名前と値を出力し、元の型に関係なくすべての値を番号付き文字列に置き換えて変更を保存します。カスタムプロパティがない場合、ループは何も変更しません。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("AccessAndModifyProperties.pptx");
try {
    $documentProperties = $presentation->getDocumentProperties();

    for ($i = 0; $i < java_values($documentProperties->getCountOfCustomProperties()); $i++) {
        $propertyName = $documentProperties->getCustomPropertyName($i);
        $propertyValue = $documentProperties->get_Item($propertyName);

        echo("Custom property name: " . $propertyName . "\n");
        echo("Custom property value: " . $propertyValue . "\n");

        $documentProperties->set_Item($propertyName, "New Value " . ($i + 1));
    }

    $presentation->save("CustomProperties_output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **ライブ例**

Aspose.Slides API を使用してドキュメントプロパティを操作する方法を確認するには、オンライン アプリの[**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata)を試してください：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更するか、該当プロパティが許可する場合は空に設定することは可能です。

**既に存在するカスタムプロパティを追加した場合、どうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。プロパティを事前に削除したり確認したりする必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/getpresentationinfo/) を使用し、続いて [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/readdocumentproperties/) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメントメタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/php-java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションの公開プロパティを開始パスワードなしで読み取れますか？**

はい。プレゼンテーションは[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/protectionmanager/setencryptdocumentproperties/) を `false` で呼び出した後に暗号化されており、[LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/setonlyloaddocumentproperties/) を `true` で呼び出してロードされている必要があります。

**ドキュメントプロパティのみモードで暗号化された PPTX ファイルを更新できますか？**

いいえ。公開プロパティと暗号化プロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しい開始パスワードでプレゼンテーション全体をロードする必要があります。