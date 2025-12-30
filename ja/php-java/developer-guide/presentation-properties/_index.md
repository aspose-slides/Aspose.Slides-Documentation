---
title: PHPでプレゼンテーション プロパティを管理
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
- 校正言語
- デフォルト言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint はプレゼンテーション ファイルにプロパティを追加する機能を提供します。これらのドキュメント プロパティにより、ドキュメント (プレゼンテーション ファイル) と共に有用な情報を保存できます。プロパティは次の 2 種類があります。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、文書タイトル、作者名、文書統計情報など、ドキュメントに関する一般情報を含みます。**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義するもので、名前も値もユーザーが決めます。Aspose.Slides for PHP via Java を使用すると、組み込みプロパティとカスタムプロパティの値にアクセスし、変更できます。

{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。操作は、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです（下図参照）。

{{% alert color="primary" %}} 

**Application** および **Producer** フィールドには値を設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for PHP via Java x.x.x が表示されます。

{{% /alert %}} 

|**Advanced Properties メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** メニュー項目を選択すると、以下のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
この **プロパティ ダイアログ** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブページが表示されます。これらのタブページは、PowerPoint ファイルに関するさまざまな情報の設定を可能にします。**Custom** タブはカスタム プロパティの管理に使用します。

### Aspose.Slides for PHP via Java を使用したドキュメント プロパティの操作

先に述べたように、Aspose.Slides for PHP via Java は **組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。したがって、開発者は API を使用して両方のプロパティにアクセスできます。Aspose.Slides for PHP via Java は、**Presentation.DocumentProperties** プロパティを通じてプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) を提供します。

開発者は [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) オブジェクトが公開する **IDocumentProperties** プロパティを使用して、プレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **組み込みプロパティへのアクセス**

[IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties) オブジェクトが公開するプロパティは、**Creator** (Author)、**Description**、**Keywords**、**Created** (作成日)、**Modified** (最終更新日)、**Printed** (最終印刷日)、**LastModifiedBy**、**SharedDoc** (他のプロデューサー間で共有されているか)、**PresentationFormat**、**Subject**、**Title** などがあります。
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

組み込みプロパティの変更は、アクセスと同様に簡単です。目的のプロパティに文字列値を代入するだけで、プロパティの値が変更されます。以下の例では、Aspose.Slides for PHP via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。
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


この例は、変更後の組み込みプロパティを以下のように表示します。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for PHP via Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。
```php
  $pres = new Presentation();
  try {
    # ドキュメント プロパティの取得
    $dProps = $pres->getDocumentProperties();
    # カスタム プロパティの追加
    $dProps->set_Item("New Custom", 12);
    $dProps->set_Item("My Name", "Mudassir");
    $dProps->set_Item("Custom", 124);
    # 特定インデックスのプロパティ名の取得
    $getPropertyName = $dProps->getCustomPropertyName(2);
    # 選択されたプロパティの削除
    $dProps->removeCustomProperty($getPropertyName);
    # プレゼンテーションの保存
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

Aspose.Slides for PHP via Java は、カスタム プロパティの値にアクセスすることもできます。以下の例は、プレゼンテーションのカスタム プロパティにアクセスし、すべてを変更する方法を示しています。
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


この例は [PPTX ](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は変更前後のカスタム プロパティを示しています。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="primary" %}} 

新しいメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および [WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-) が [IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo) に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) プロパティ セッターのロジックが変更されました。

{{% /alert %}} 

新しく追加された 2 つのメソッド [ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--) と [UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) は、[IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo) インターフェイスに実装されています。これらはドキュメント プロパティへの高速アクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更や更新が可能です。

典型的なシナリオは、プロパティをロードし、値を変更し、ドキュメントを更新するという流れです。以下のコードで実装できます:
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


別の方法として、特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新することも可能です:
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


新しいテンプレートを最初から作成し、複数のプレゼンテーションに適用して更新することもできます:
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

Aspose.Slides は PortionFormat クラスが公開する LanguageId プロパティにより、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルチェックおよび文法チェックが行われる言語を指します。

以下の PHP コードは、PowerPoint の校正言語を設定する方法を示しています: xxx Why is LanguageId missing from Java PortionFormat class?
```php
  $pres = new Presentation($pptxFileName);
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();
    $newPortion = new Portion();
    $font = new FontData("SimSun");
    $portionFormat = $newPortion->getPortionFormat();
    $portionFormat::setComplexScriptFont($font);
    $portionFormat::setEastAsianFont($font);
    $portionFormat::setLatinFont($font);
    $portionFormat::setLanguageId("zh-CN");// 校正言語の ID を設定

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **デフォルト言語の設定**

以下の PHP コードは、プレゼンテーション全体のデフォルト言語を設定する方法を示しています:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # 新しい矩形シェイプをテキスト付きで追加
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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/metadata) オンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更したり、該当プロパティが許可する場合は空文字列に設定したりできます。

**既に存在するカスタム プロパティを追加した場合はどうなりますか？**

既に存在するカスタム プロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的に値を更新します。

**プレゼンテーションを完全にロードせずにプロパティにアクセスできますか？**

はい、[PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) クラスの `getPresentationInfo` メソッドを使用してプレゼンテーション情報を取得し、続いて [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) クラスの `readDocumentProperties` メソッドでプロパティを効率的に読み取ることで、メモリ使用量を抑えつつパフォーマンスを向上させながらプロパティにアクセスできます。