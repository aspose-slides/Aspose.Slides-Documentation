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
description: "Aspose.Slides for PHP via Java でプレゼンテーション プロパティをマスターし、PowerPoint や OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---

{{% alert color="primary" %}} 

Microsoft PowerPoint には、プレゼンテーション ファイルにプロパティを追加する機能があります。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）と一緒に有用な情報を保存できます。ドキュメント プロパティは次の 2 種類に分類されます。

- システム定義 (組み込み) プロパティ
- ユーザー定義 (カスタム) プロパティ

**組み込み** プロパティは、ドキュメント タイトル、作者名、ドキュメント統計情報など、ドキュメントに関する一般的な情報を保持します。**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義するもので、名前も値もユーザーが指定します。Aspose.Slides for PHP via Java を使用すると、開発者は組み込みプロパティとカスタムプロパティの両方の値にアクセスし、変更できます。

{{% /alert %}} 

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。操作は、Office アイコンをクリックし、さらに **Prepare | Properties | Advanced Properties** メニュー項目を選択するだけです（下図参照）。

{{% alert color="primary" %}} 

**Application** と **Producer** フィールドには値を設定できません。これらのフィールドには Aspose Ltd. と Aspose.Slides for PHP via Java x.x.x が表示されますのでご注意ください。

{{% /alert %}} 

|**Advanced Properties メニュー項目の選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** メニュー項目を選択すると、以下のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**プロパティ ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |

上記の **プロパティ ダイアログ** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった複数のタブページが確認できます。各タブページは PowerPoint ファイルに関連するさまざまな情報を設定できます。**Custom** タブはカスタム プロパティの管理に使用します。

Aspose.Slides for PHP via Java を使用したドキュメント プロパティの操作

前述のとおり、Aspose.Slides for PHP via Java は **組み込み** プロパティと **カスタム** プロパティの 2 種類をサポートしています。したがって、開発者は Aspose.Slides for PHP via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for PHP via Java では、プレゼンテーション ファイルに関連付けられたドキュメント プロパティを表すクラス [DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) が提供されており、**Presentation.DocumentProperties** プロパティから取得できます。

開発者は [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) オブジェクトが公開する **DocumentProperties** プロパティを使用して、プレゼンテーション ファイルのドキュメント プロパティにアクセスできます。以下に使用例を示します。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties) オブジェクトが提供する組み込みプロパティには、**Creator**（作者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（更新日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（複数プロデューサー間で共有されているか）、**PresentationFormat**、**Subject**、**Title** などがあります。
```php
  # プレゼンテーションを表す Presentation クラスのインスタンス化
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

組み込みプロパティの変更は、取得と同様に簡単です。任意のプロパティに文字列値を代入するだけで、プロパティ値が更新されます。以下の例では、Aspose.Slides for PHP via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示しています。
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


この例では、プレゼンテーションの組み込みプロパティが以下のように変更されます。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for PHP via Java は、プレゼンテーションのカスタム プロパティに値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示しています。
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
    # 選択したプロパティを削除
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

## **カスタム プロパティのアクセスと変更**

Aspose.Slides for PHP via Java は、カスタム プロパティの値にアクセスすることもできます。以下の例では、プレゼンテーションのすべてのカスタム プロパティにアクセスし、変更する方法を示しています。
```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentation に関連付けられた DocumentProperties オブジェクトへの参照を作成
    $dp = $pres->getDocumentProperties();
    # カスタム プロパティにアクセスし、変更
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


この例は [PPTX ](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。変更前後のプロパティは以下の図に示されています。

|**変更前のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**変更後のカスタム プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度なドキュメント プロパティ**

{{% alert color="primary" %}} 

新しいメソッド [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties)、[updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties)、および [writeBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#writeBindedPresentation) が [PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) に追加され、[DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/documentproperties/#setLastSavedTime) プロパティ セッターのロジックが変更されました。

{{% /alert %}} 

新たに追加された 2 つのメソッド [readDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) と [updateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) は、[PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/PresentationInfo) クラスに実装されています。これらはドキュメント プロパティへの高速アクセスを提供し、プレゼンテーション全体をロードせずにプロパティの取得・変更が可能です。

典型的なシナリオは、プロパティをロードし、いくつかの値を変更してからドキュメントを更新することで、次のように実装できます。
```php
  # プレゼンテーションの情報を読み取る
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 現在のプロパティを取得する
  $props = $info->readDocumentProperties();
  # Author と Title フィールドの新しい値を設定する
  $props->setAuthor("New Author");
  $props->setTitle("New Title");
  # 新しい値でプレゼンテーションを更新する
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");
```


特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新する別の方法もあります。
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


新しいテンプレートを最初から作成し、複数のプレゼンテーションを更新することも可能です。
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

Aspose.Slides は PortionFormat クラスが提供する LanguageId プロパティを使用して、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、スペルチェックと文法チェックが行われる対象言語です。

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

以下の PHP コードは、PowerPoint プレゼンテーション全体のデフォルト言語を設定する方法を示しています。
```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # テキスト付きの新しい矩形シェイプを追加
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

Aspose.Slides Metadata オンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**プレゼンテーションから組み込みプロパティを削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティが許可する場合は、値を変更するか空に設定できます。

**既に存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的にプロパティの値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい、[PresentationFactory](https://reference.aspose.com/slides/php-java/aspose.slides/presentationfactory/) クラスの `getPresentationInfo` メソッドを使用し、[PresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/presentationinfo/) クラスの `readDocumentProperties` メソッドでプロパティを効率的に読み取ることで、メモリ使用量を抑えながら高速にプロパティにアクセスできます。