---
title: プレゼンテーションプロパティ
type: docs
weight: 70
url: /ja/php-java/presentation-properties/
---

{{% alert color="primary" %}} 

Microsoft PowerPointは、プレゼンテーションファイルにいくつかのプロパティを追加する機能を提供しています。これらの文書プロパティは、文書（プレゼンテーションファイル）とともに有用な情報を保存できるようにします。文書プロパティは以下の2種類があります。

- システム定義（組み込み）プロパティ
- ユーザー定義（カスタム）プロパティ

**組み込み**プロパティは、文書タイトル、著者名、文書統計など、文書に関する一般的な情報を含みます。 **カスタム**プロパティは、ユーザーによって**名前/値**ペアとして定義されるプロパティであり、名前と値の両方がユーザーによって定義されます。Aspose.Slides for PHP via Javaを使用することで、開発者は組み込みプロパティの値とカスタムプロパティの値にアクセスして変更できます。

{{% /alert %}} 

## **PowerPointの文書プロパティ**
Microsoft PowerPoint 2007は、プレゼンテーションファイルの文書プロパティを管理することを可能にします。以下に示すように、Officeアイコンをクリックし、さらに**準備 | プロパティ | 詳細プロパティ**メニュー項目を選択するだけです。

{{% alert color="primary" %}} 

**アプリケーション**および**プロデューサー**フィールドに対して値を設定できないことに注意してください。なぜなら、これらのフィールドにはAspose Ltd.およびAspose.Slides for PHP via Java x.x.xが表示されるからです。

{{% /alert %}} 

|**詳細プロパティメニュー項目を選択**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**詳細プロパティ**メニュー項目を選択すると、以下の図に示すように、PowerPointファイルの文書プロパティを管理できるダイアログが表示されます。

|**プロパティダイアログ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
上記の**プロパティダイアログ**では、**一般**、**要約**、**統計**、**コンテンツ**、および**カスタム**のような多くのタブページがあることがわかります。これらのタブページはすべて、PowerPointファイルに関連するさまざまな情報を構成することを可能にします。 **カスタム**タブは、PowerPointファイルのカスタムプロパティを管理するために使用されます。

Aspose.Slides for PHP via Javaを使用した文書プロパティとの作業

前述のとおり、Aspose.Slides for PHP via Javaは**組み込み**プロパティと**カスタム**プロパティの2種類の文書プロパティをサポートしています。したがって、開発者はAspose.Slides for PHP via Java APIを使用して、両方の種類のプロパティにアクセスできます。Aspose.Slides for PHP via Javaは、プレゼンテーションファイルに関連する文書プロパティを表すクラス[IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties)を提供しています。このクラスは、**Presentation.DocumentProperties**プロパティを介してアクセスされます。

開発者は、以下に説明するように、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)オブジェクトによって公開される**IDocumentProperties**プロパティを使用して、プレゼンテーションファイルの文書プロパティにアクセスできます。

## **組み込みプロパティにアクセスする**
[IDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties)オブジェクトによって公開されるこれらのプロパティには、**Creator**（著者）、**Description**、**Keywords**、**Created**（作成日）、**Modified**（修正日）、**Printed**（最終印刷日）、**LastModifiedBy**、**Keywords**、**SharedDoc**（異なるプロデューサー間で共有されていますか？）、**PresentationFormat**、**Subject**および**Title**が含まれます。

```php
  # プレゼンテーションを表すPresentationクラスをインスタンス化
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentationに関連するIDocumentPropertiesオブジェクトへの参照を作成
    $dp = $pres->getDocumentProperties();
    # 組み込みプロパティを表示
    echo("カテゴリ : " . $dp->getCategory());
    echo("現在のステータス : " . $dp->getContentStatus());
    echo("作成日 : " . $dp->getCreatedTime());
    echo("著者 : " . $dp->getAuthor());
    echo("説明 : " . $dp->getComments());
    echo("キーワード : " . $dp->getKeywords());
    echo("最終修正者 : " . $dp->getLastSavedBy());
    echo("監督者 : " . $dp->getManager());
    echo("修正日 : " . $dp->getLastSavedTime());
    echo("プレゼンテーション形式 : " . $dp->getPresentationFormat());
    echo("最終印刷日 : " . $dp->getLastPrinted());
    echo("プロデューサー間で共有されていますか : " . $dp->getSharedDoc());
    echo("件名 : " . $dp->getSubject());
    echo("タイトル : " . $dp->getTitle());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **組み込みプロパティを修正する**
プレゼンテーションファイルの組み込みプロパティを修正するのは、アクセスするのと同じくらい簡単です。必要なプロパティに文字列値を割り当てるだけで、そのプロパティの値が修正されます。以下の例では、Aspose.Slides for PHP via Javaを使用して、プレゼンテーションファイルの組み込み文書プロパティを修正する方法を示します。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentationに関連するIDocumentPropertiesオブジェクトへの参照を作成
    $dp = $pres->getDocumentProperties();
    # 組み込みプロパティを設定
    $dp->setAuthor("Aspose.Slides for PHP via Java");
    $dp->setTitle("プレゼンテーションプロパティの修正");
    $dp->setSubject("Aspose件名");
    $dp->setComments("Asposeの説明");
    $dp->setManager("Asposeマネージャ");
    # プレゼンテーションをファイルに保存
    $pres->save("DocProps.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

この例では、以下に示すように、変更後のプレゼンテーションの組み込みプロパティが修正されます。

|**修正後の組み込み文書プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **カスタム文書プロパティを追加する**
Aspose.Slides for PHP via Javaは、開発者がプレゼンテーション文書プロパティにカスタム値を追加することも許可しています。以下は、プレゼンテーションのカスタムプロパティを設定する方法を示す例です。

```php
  $pres = new Presentation();
  try {
    # 文書プロパティを取得
    $dProps = $pres->getDocumentProperties();
    # カスタムプロパティを追加
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

|**追加されたカスタム文書プロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **カスタムプロパティにアクセスして修正する**
Aspose.Slides for PHP via Javaは、開発者がカスタムプロパティの値にアクセスすることも許可しています。以下は、プレゼンテーションのすべてのカスタムプロパティにアクセスして変更する方法を示す例です。

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Presentationに関連するDocumentPropertiesオブジェクトへの参照を作成
    $dp = $pres->getDocumentProperties();
    # カスタムプロパティにアクセスして修正
    for($i = 0; $i < java_values($dp->getCountOfCustomProperties()) ; $i++) {
      # カスタムプロパティの名前と値を表示
      echo("カスタムプロパティ名 : " . $dp->getCustomPropertyName($i));
      echo("カスタムプロパティ値 : " . $dp->get_Item($dp->getCustomPropertyName($i)));
      # カスタムプロパティの値を修正
      $dp->set_Item($dp->getCustomPropertyName($i), "新しい値 " . $i + 1);
    }
    # プレゼンテーションをファイルに保存
    $pres->save("CustomDemoModified.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

この例では、[PPTX](https://docs.fileformat.com/presentation/pptx/)プレゼンテーションのカスタムプロパティが修正されます。以下の図は、修正前と修正後のプレゼンテーションのカスタムプロパティを示します。

|**修正前のカスタムプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |


|**修正後のカスタムプロパティ**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **高度な文書プロパティ**
{{% alert color="primary" %}} 

新しいメソッド[ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--)、[UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)、および[WriteBindedPresentation](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)が[IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo)に追加され、[IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/php-java/aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-)プロパティセッターのロジックが変更されました。

{{% /alert %}} 

新しい2つのメソッド[ReadDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#readDocumentProperties--)と[UpdateDocumentProperties](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)が[IPresentationInfo](https://reference.aspose.com/slides/php-java/aspose.slides/IPresentationInfo)インターフェースに追加されました。これらは、文書プロパティに迅速にアクセスし、プレゼンテーション全体を読み込まずにプロパティを変更および更新することを可能にします。

典型的なシナリオは、プロパティを読み込み、一部の値を変更し、文書を更新することが次のように実装できます。

```php
  # プレゼンテーションの情報を読み取る
  $info = PresentationFactory->getInstance()->getPresentationInfo("presentation.pptx");
  # 現在のプロパティを取得
  $props = $info->readDocumentProperties();
  # 著者とタイトルフィールドの新しい値を設定
  $props->setAuthor("新しい著者");
  $props->setTitle("新しいタイトル");
  # 新しい値でプレゼンテーションを更新
  $info->updateDocumentProperties($props);
  $info->writeBindedPresentation("presentation.pptx");

```

特定のプレゼンテーションのプロパティをテンプレートとして使用して、他のプレゼンテーションのプロパティを更新する別の方法があります。

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("template.pptx");
  $template = $info->readDocumentProperties();
  $template->setAuthor("テンプレートの著者");
  $template->setTitle("テンプレートのタイトル");
  $template->setCategory("テンプレートのカテゴリ");
  $template->setKeywords("キーワード1, キーワード2, キーワード3");
  $template->setCompany("私たちの会社");
  $template->setComments("テンプレートから作成");
  $template->setContentType("テンプレートのコンテンツ");
  $template->setSubject("テンプレートの件名");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

新しいテンプレートを一から作成し、複数のプレゼンテーションを更新するために使用することができます。

```php
  $template = new DocumentProperties();
  $template->setAuthor("テンプレートの著者");
  $template->setTitle("テンプレートのタイトル");
  $template->setCategory("テンプレートのカテゴリ");
  $template->setKeywords("キーワード1, キーワード2, キーワード3");
  $template->setCompany("私たちの会社");
  $template->setComments("テンプレートから作成");
  $template->setContentType("テンプレートのコンテンツ");
  $template->setSubject("テンプレートの件名");
  updateByTemplate("doc1.pptx", $template);
  updateByTemplate("doc2.odp", $template);
  updateByTemplate("doc3.ppt", $template);

```

```php

```

## **プレゼンテーションが変更または作成されたかを確認する**
Aspose.Slides for PHP via Javaは、プレゼンテーションが変更されたか作成されたかを確認する機能を提供します。以下は、プレゼンテーションが作成または変更されたかを確認する方法を示す例です。

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("props.pptx");
  $props = $info->readDocumentProperties();
  $app = $props->getNameOfApplication();
  $ver = $props->getAppVersion();
  echo("アプリケーション名: " . $app);
  echo("アプリケーションバージョン: " . $ver);

```

## **校正言語を設定する**

Aspose.Slidesは、PowerPoint文書の校正言語を設定できるLanguageIdプロパティ（PortionFormatクラスによって公開）を提供しています。校正言語は、PowerPoint内でスペルと文法がチェックされる言語です。

このPHPコードは、PowerPointの校正言語を設定する方法を示しています：xxx なぜLanguageIdがJava PortionFormatクラスに存在しないのか？

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
    $portionFormat::setLanguageId("zh-CN");// 校正言語のIDを設定

    $newPortion->setText("1。");
    $paragraph->getPortions()->add($newPortion);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **デフォルト言語を設定する**

このPHPコードは、PowerPointプレゼンテーション全体のデフォルト言語を設定する方法を示しています：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setDefaultTextLanguage("en-US");
  $pres = new Presentation($loadOptions);
  try {
    # テキストを含む新しい矩形形状を追加
    $shp = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    $shp->getTextFrame()->setText("新しいテキスト");
    # 最初の部分の言語を確認
    echo($shp->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->getLanguageId());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```