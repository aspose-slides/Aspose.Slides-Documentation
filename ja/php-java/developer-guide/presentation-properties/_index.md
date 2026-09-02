---
title: PHP でプレゼンテーション プロパティの管理
linktitle: プレゼンテーション プロパティ
type: docs
weight: 70
url: /ja/php-java/presentation-properties/
keywords:
- PowerPoint のプロパティ
- プレゼンテーションのプロパティ
- ドキュメント プロパティ
- 組み込みプロパティ
- カスタム プロパティ
- 高度なプロパティ
- プロパティの管理
- プロパティの変更
- ドキュメント メタデータ
- メタデータの編集
- 校正言語
- 既定言語
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java でプレゼンテーション プロパティをマスターし、PowerPoint および OpenDocument ファイルの検索、ブランディング、ワークフローを効率化します。"
---
## **はじめに**

Aspose.Slides は 2 種類のドキュメント プロパティをサポートします: **組み込み** と **カスタム**。これらのプロパティはどちらも Aspose.Slides API を使用して簡単に取得および管理できます。

Aspose.Slides は [DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/) クラスを通じてプレゼンテーション ドキュメント プロパティを操作できるようにします。このクラスのインスタンスは [Presentation::getDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/#getDocumentProperties) メソッドから取得されます。以下の例では、これらのプロパティの読み取り、変更、管理方法を示します。

{{% alert color="info" title="Note" %}}
**Application** および **AppVersion** フィールドは変更できないことに注意してください。Aspose.Slides は保存のたびにこれらを書き換えるため、保存されたプレゼンテーションは常に「Aspose.Slides for PHP via Java」およびライブラリのバージョンを報告します。`setNameOfApplication` に渡された値は、プレゼンテーションを書き出す際に破棄されます。
{{% /alert %}} 

## **プレゼンテーション プロパティの管理**

Microsoft PowerPoint には、プレゼンテーション ファイルにいくつかのプロパティを追加する機能があります。これらのドキュメント プロパティにより、ドキュメント（プレゼンテーション ファイル）と一緒に有用な情報を格納できます。プロパティは次の 2 種類に分かれます。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み** プロパティは、ドキュメント タイトル、作成者名、統計情報など、ドキュメント全般に関する情報を含みます。**カスタム** プロパティは、ユーザーが **名前/値** のペアとして定義するものです。Aspose.Slides for PHP via Java を使用すると、組み込みプロパティとカスタムプロパティの両方の値にアクセスし、変更できます。

## **PowerPoint のドキュメント プロパティ**

Microsoft PowerPoint 2007 では、プレゼンテーション ファイルのドキュメント プロパティを管理できます。操作手順は、Office アイコンをクリックし、**Prepare | Properties | Advanced Properties** を選択するだけです（下図参照）。

|**Advanced Properties メニューの選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
Advanced Properties を選択すると、以下のように PowerPoint ファイルのドキュメント プロパティを管理できるダイアログが表示されます。

|**Properties ダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
この **Properties ダイアログ** では、**General**、**Summary**、**Statistics**、**Contents**、**Custom** といった多数のタブが表示されます。各タブは PowerPoint ファイルに関するさまざまな情報の設定を行うためのものです。**Custom** タブはカスタム プロパティの管理に使用します。

### Aspose.Slides for PHP via Java を使用したドキュメント プロパティの操作

前述のとおり、Aspose.Slides for PHP via Java は **組み込み** と **カスタム** の 2 種類のドキュメント プロパティをサポートしています。したがって、開発者は Aspose.Slides for PHP via Java API を使用して両方のプロパティにアクセスできます。Aspose.Slides for PHP via Java は、**Presentation.DocumentProperties** プロパティを介してプレゼンテーション ファイルに関連付けられたドキュメント プロパティを表す [DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties) クラスを提供します。

開発者は [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation) オブジェクトが公開する **DocumentProperties** プロパティを使用して、下記のようにプレゼンテーション ファイルのドキュメント プロパティにアクセスできます。

## **組み込みプロパティへのアクセス**

[DocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties) オブジェクトが提供する組み込みプロパティには、**Creator**（作成者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（変更日）、**Printed**（最終印刷日）、**LastModifiedBy**、**SharedDoc**（共有ドキュメントか）、**PresentationFormat**、**Subject**、**Title** などがあります。

```php
  # プレゼンテーションを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("Presentation.pptx");
  try {
    # プレゼンテーションに関連付けられた IDocumentProperties オブジェクトへの参照を作成
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

組み込みプロパティの変更は、取得と同じくらい簡単です。目的のプロパティに文字列値を代入すれば、プロパティの値が更新されます。以下の例では、Aspose.Slides for PHP via Java を使用してプレゼンテーション ファイルの組み込みドキュメント プロパティを変更する方法を示します。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # プレゼンテーションに関連付けられた IDocumentProperties オブジェクトへの参照を作成
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

この例の実行結果は、次のように組み込みプロパティが変更されたことを示します。

|**変更後の組み込みドキュメント プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム ドキュメント プロパティの追加**

Aspose.Slides for PHP via Java は、プレゼンテーションのドキュメント プロパティにカスタム値を追加することも可能です。以下の例は、プレゼンテーションにカスタム プロパティを設定する方法を示します。

```php
  $pres = new Presentation();
  try {
    # ドキュメント プロパティを取得
    $dProps = $pres->getDocumentProperties();
    # カスタム プロパティを追加
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

## **カスタムプロパティの取得と変更**

Aspose.Slides for PHP via Java は、カスタム プロパティの値へのアクセスも提供します。以下の例は、プレゼンテーションのすべてのカスタム プロパティに対して取得と変更を行う方法を示します。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # プレゼンテーションに関連付けられた DocumentProperties オブジェクトへの参照を作成
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

この例は [PPTX ](https://docs.fileformat.com/presentation/pptx/) プレゼンテーションのカスタム プロパティを変更します。以下の図は、変更前後のカスタム プロパティの状態を示しています。

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

新しいメソッド [readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo/#readDocumentProperties) と [updateDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo/#updateDocumentProperties) が [PresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PresentationInfo) クラスに追加されました。これらはドキュメント プロパティへの迅速なアクセスを提供し、プレゼンテーション全体をロードせずにプロパティの変更・更新が可能です。

典型的なシナリオとして、プロパティをロードし、値を変更して、ドキュメントを更新する処理は以下のように実装できます。

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

別の方法として、特定のプレゼンテーションのプロパティをテンプレートとして使用し、他のプレゼンテーションのプロパティを更新することができます。

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

新しいテンプレートをゼロから作成し、複数のプレゼンテーションを更新する際に使用できます。

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

Aspose.Slides は PortionFormat クラスが公開する LanguageId プロパティを使用して、PowerPoint ドキュメントの校正言語を設定できます。校正言語は、PowerPoint のスペルチェックや文法チェックが行われる言語を指します。

この PHP コードは、PowerPoint の校正言語を設定する方法を示します: xxx Why is LanguageId missing from Java PortionFormat class?

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
    $portionFormat->setLanguageId("zh-CN");// 校正言語の ID を設定

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **既定言語の設定**

この PHP コードは、プレゼンテーション全体の既定言語を設定する方法を示します。

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

[**Aspose.Slides Metadata**](https://products.aspose.app/slides/ja/metadata) のオンライン アプリを試して、Aspose.Slides API を使用したドキュメント プロパティの操作方法をご確認ください。

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ja/metadata)

## **FAQ**

**組み込みプロパティをプレゼンテーションから削除するにはどうすればよいですか？**

組み込みプロパティはプレゼンテーションの不可欠な部分であり、完全に削除することはできません。ただし、プロパティの値を変更したり、該当プロパティが許可する場合は空文字列に設定したりできます。

**すでに存在するカスタムプロパティを追加した場合はどうなりますか？**

既に存在するカスタムプロパティを追加すると、既存の値は新しい値で上書きされます。事前に削除やチェックを行う必要はなく、Aspose.Slides が自動的に値を更新します。

**プレゼンテーション全体をロードせずにプロパティにアクセスできますか？**

はい。まず [PresentationFactory::getPresentationInfo](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationfactory/) を使用し、次に [PresentationInfo::readDocumentProperties](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentationinfo/#readDocumentProperties) を呼び出すことで、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを作成せずに保存されたドキュメント メタデータを取得できます。完全なレポート例とフォーマット別の制限については、[Build a Lightweight Presentation Inventory](/slides/ja/php-java/examine-presentation/) を参照してください。