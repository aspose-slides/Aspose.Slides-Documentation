---
title: PHP でプレゼンテーション プロパティを管理
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/php-java/presentation-properties/
keywords:
- PowerPoint プロパティ
- プレゼンテーション プロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタム プロパティ
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正用言語
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides はドキュメント プロパティの 2 種類、**Built-in** と **Custom** をサポートしています。これらのプロパティは、Aspose.Slides API を使用して簡単にアクセスおよび管理できます。

Aspose.Slides は、[DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/) クラスを介してプレゼンテーションのドキュメント プロパティを操作できます。このクラスのインスタンスは、[Presentation::getDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDocumentProperties) メソッドで取得されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="Note" %}}
**Application** と **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存のたびにこれらのフィールドを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for PHP via Java」とその作成に使用されたライブラリのバージョンを報告します。`setNameOfApplication` に渡された値は、プレゼンテーションが書き込まれる際に破棄されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint では、プレゼンテーション ファイルにプロパティを追加する機能が提供されています。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）に有用な情報を格納できます。ドキュメント プロパティは次の 2 種類あります。

- System Defined (Built-in) プロパティ
- User-Defined (Custom) プロパティ

**Built-in** プロパティは、ドキュメントのタイトル、作者名、統計情報など、一般的な情報を含みます。**Custom** プロパティは、ユーザーが **Name/Value** のペアとして定義するもので、名前と値はユーザーが決めます。Aspose.Slides for PHP via Java を使用すると、開発者は組み込みプロパティとカスタムプロパティの値にアクセスし、変更できます。

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。以下のように Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです。

|**Advanced Properties メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます（下図参照）。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **Properties Dialog** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** など多数のタブがあることがわかります。これらのタブは、PowerPoint ファイルに関するさまざまな情報を設定できます。**Custom** タブは、PowerPoint ファイルのカスタム プロパティを管理するために使用されます。

### Aspose.Slides for PHP via Java を使用したドキュメント プロパティの操作

前述のとおり、Aspose.Slides for PHP via Java は **Built-in** と **Custom** の 2 種類のドキュメント プロパティをサポートしています。そのため、開発者は Aspose.Slides for PHP via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for PHP via Java は、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを **Presentation.DocumentProperties** プロパティを通じて表すクラス [DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties) を提供します。

[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) オブジェクトが公開する **DocumentProperties** プロパティを使用すると、以下のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **暗号化されたプレゼンテーションからパブリック プロパティを読み取る**

通常、オープニング パスワードはプレゼンテーションのコンテンツとドキュメント プロパティの両方を保護します。[ProtectionManager::setEncryptDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) に `false` を渡してプレゼンテーションを暗号化すると、ドキュメント プロパティはパブリックのままです。その後、アプリケーションは [LoadOptions::setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) に `true` を渡すことで、オープニング パスワードを提供せずにパブリック メタデータを読み取れます。

document-properties-only オプションは Aspose.Slides がロードする内容を制御しますが、復号は行いません。プロパティが暗号化に含まれている場合、パスワードなしでのロードは失敗します。プレゼンテーションが暗号化されていない場合、このオプションは無視され、プレゼンテーション全体がロードされます。

以下の例では、[ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) で読み込みモードを確認し、続いて [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDocumentProperties) を使用して組み込みプロパティを読み取ります。

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setOnlyLoadDocumentProperties(true);

$presentation = new Presentation("public-properties-encrypted.pptx", $loadOptions);
try {
    if (java_values($presentation->getProtectionManager()->isOnlyDocumentPropertiesLoaded())) {
        $properties = $presentation->getDocumentProperties();

        echo("Author: " . $properties->getAuthor() . "\n");
        echo("Title: " . $properties->getTitle() . "\n");
        echo("Keywords: " . $properties->getKeywords() . "\n");
    } else {
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $presentation->dispose();
}
```

このモードではスライドのコンテンツはロードされません。スライド、マスター、レイアウト、シェイプ、メディア、その他のプレゼンテーション オブジェクトは利用できません。完全なプレゼンテーション オブジェクトモデルが必要な操作を行う前に、必ず [ProtectionManager::isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ja/php-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) をチェックしてください。

{{% alert color="warning" title="Warning" %}}
パブリック メタデータには、著者名、タイトル、主題、キーワード、会社情報、コメント、カスタム値が含まれる可能性があります。機密性の高いプロパティはプレゼンテーションと一緒に暗号化してください。インデックス作成、分類、検索、またはドキュメント管理システムがパスワードなしでアクセスする特別な要件がある場合のみ、パブリックのままにしてください。
{{% /alert %}}

## **暗号化されたプレゼンテーションのプロパティを更新する**

暗号化された PPTX ファイルの場合、document-properties-only モードでロードされたプレゼンテーションはパブリック メタデータの読み取りを目的としています。Aspose.Slides は、そのメタデータのみのオブジェクトから変更されたプロパティを保存できません。パブリック プロパティは暗号化されたプレゼンテーション内の対応データと一貫性が必要なため、更新には正しいオープニング パスワードと完全なロードが必要です。

以下の例では、[LoadOptions::setPassword](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/#setPassword) を使用してプレゼンテーションを開き、パブリックな組み込みプロパティを更新し、結果を保存します。その後、[PresentationInfo::isEncrypted](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#isEncrypted) を使用して暗号化が保持されていることを確認し、パスワードなしでパブリック メタデータを再度開き、新しい値を検証します。

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
    $presentation->getDocumentProperties()->setTitle("Updated Product Roadmap");
    $presentation->getDocumentProperties()->setKeywords("roadmap, planning, indexed");
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
        echo("The presentation was not loaded in document-properties-only mode.\n");
    }
} finally {
    $metadataPresentation->dispose();
}
```

アプリケーションがプレゼンテーションのコンテンツを復号またはロードできない場合、暗号化された PPTX ファイルのパブリック プロパティは読み取り専用として扱う必要があります。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties) オブジェクトが公開するプロパティは、**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（複数の作成者間で共有されているか）、**PresentationFormat**、**Subject**、**Title** です。

```php
  # プレゼンテーションを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成
    $dp = $pres->getDocumentProperties();
    # 組み込みプロパティを表示
    echo("Category : " . $dp->getCategory());
    echo("Current Status : " . $dp->getContentStatus());
    echo("Creation Date : " . $dp->getCreatedTime());
    echo("Author : " . $dp->getAuthor());
    echo("Description : " . $dp->getComments());
    echo("KeyWords : " . $dp->getKeywords());
    echo("Last Modified By : " . $dp->getLastSavedBy());
    echo("Supervisor : " . $dp->getManager());
    echo("Modified Date : " . $dp->getLastSavedTime());
    echo("Presentation Format : " . $dp->getPresentationFormat());
    echo("Last Print Date : " . $dp->getLastPrinted());
    echo("Is Shared between producers : " . $dp->getSharedDoc());
    echo("Subject : " . $dp->getSubject());
    echo("Title : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **組み込みプロパティの変更**

プレゼンテーション ファイルの組み込みプロパティの変更は、アクセスと同様に簡単です。任意のプロパティに文字列値を代入するだけで、プロパティの値が変更されます。以下の例では、Aspose.Slides for PHP via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示します。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation に関連付けられた IDocumentProperties オブジェクトへの参照を作成
    $dp = $pres->getDocumentProperties();
    # 組み込みプロパティを設定
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("Modifying Presentation Properties");
    $dp->setSubject("Aspose Subject");
    $dp->setComments("Aspose Description");
    $dp->setManager("Aspose Manager");
    # プレゼンテーションをファイルに保存
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

この例では、プレゼンテーションの組み込みプロパティを変更し、以下のように確認できます。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for PHP via Java は、開発者がプレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例では、プレゼンテーションのカスタム プロパティを設定する方法を示します。

```php
  $pres = new Presentation();
  try {
    # ドキュメント プロパティの取得
    $dProps = $pres->getDocumentProperties();
    # カスタム プロパティの追加
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # 特定のインデックスのプロパティ名を取得
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # 選択されたプロパティを削除
    $dProps->removeCustomProperty($getPropertyName);
    # プレゼンテーションを保存
    $pres->save("CustomDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

|**追加されたカスタム ドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタム プロパティへのアクセスと変更**

Aspose.Slides for PHP via Java は、開発者がカスタム プロパティの値にアクセスすることも可能です。以下の例では、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示します。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成
    $dp = $pres->getDocumentProperties();
    # カスタム プロパティにアクセスして変更
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # カスタム プロパティの名前と値を表示
      echo("Custom Property Name : " . $dp->getCustomPropertyName($i));
      echo("Custom Property Value : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # カスタム プロパティの値を変更
      $dp->set_Item($dp->getCustomPropertyName($i), "New Value " . $i + 1);
    }
    # プレゼンテーションをファイルに保存
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

この例では、[PPTX](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前後のプレゼンテーション カスタム プロパティを示します。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="info" title="Note" %}}
新しいメソッド [readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)、および [writeBindedPresentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) が [PresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo) に追加され、[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#setLastSavedTime) プロパティ セッターのロジックが変更されました。
{{% /alert %}} 

新しい 2 つのメソッド [readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) と [updateDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) が [PresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo) クラスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更や更新が可能です。

典型的なシナリオは、プロパティをロードし、値を変更してドキュメントを更新することで、以下のように実装できます。

```php
  # プレゼンテーションの情報を読み取る
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 現在のプロパティを取得
  $props = $info->readDocumentProperties();
  # Author と Title フィールドの新しい値を設定
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 新しい値でプレゼンテーションを更新
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```

特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新する別の方法があります。

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

```php

```

新しいテンプレートを最初から作成し、複数のプレゼンテーションの更新に使用できます。

```php
  $template = new DocumentProperties();
  $template->setAuthor("Template Author");
  $template->setTitle("Template Title");
  $template->setCategory("Template Category");
  $template->setKeywords("Keyword1, Keyword2, Keyword3");
  $template->setCompany("Our Company");
  $template->setComments("Created from template");
  $template->setContentType("Template Content");
  $template->setSubject("Template Subject");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);
```

## **校正言語の設定**

Aspose.Slides は、PortionFormat クラスが公開する LanguageId プロパティを提供し、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルや文法がチェックされる言語です。

この PHP コードは、PowerPoint の校正言語を設定する方法を示しています：xxx Java の PortionFormat クラスに LanguageId がないのはなぜですか？

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat->setComplexScriptFont($font);
    $portionFormat->setEastAsianFont($font);
    $portionFormat->setLatinFont($font);
    $portionFormat->setLanguageId("zh-CN");// 校正用言語の ID を設定

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **デフォルト言語の設定**

この PHP コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示します。

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # テキスト付きの新しい四角形シェイプを追加
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("New Text");
    # 最初のポーションの言語を確認
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ライブ例**

Aspose.Slides API を使用したドキュメント プロパティの操作方法を見るには、オンライン アプリ [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) をお試しください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更したり、該当するプロパティが許可する場合は空に設定したりすることは可能です。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除したりチェックしたりする必要はありません。Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい。[PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/) を使用し、続いて [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#readDocumentProperties) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを読み取れます。完全なレポート例とフォーマット固有の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/php-java/examine-presentation/) を参照してください。

**暗号化されたプレゼンテーションのオープニング パスワードなしでパブリック プロパティを読み取れますか？**

はい。ドキュメント プロパティの暗号化がプレゼンテーションの暗号化前に無効化されており、プレゼンテーションが document‑properties‑only モードでロードされている必要があります。

**document-properties-only モードで暗号化された PPTX ファイルを更新できますか？**

いいえ。パブリック プロパティと暗号化されたプロパティのデータは一貫性を保つ必要があるため、暗号化された PPTX ファイルを更新するには、正しいオープニング パスワードでプレゼンテーション全体をロードする必要があります。