---
title: PHP を使用したプレゼンテーションでのタグとカスタムデータの管理
linktitle: タグとカスタムデータ
type: docs
weight: 300
url: /ja/php-java/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア 値
- PowerPoint
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java におけるタグとカスタムデータの追加、取得、更新、削除方法を学び、PowerPoint と OpenDocument プレゼンテーションの例を通じて理解します。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションにおけるタグとカスタムデータをどのように扱うかを説明します。PPTX ファイルへのデータの保存方法を簡単に概説し、プレゼンテーション固有のデータがタグやカスタム XML パーツとして存在し得ること、タグがキーと値の文字列ペアであることを説明します。

また、タグの値を取得する方法や、プレゼンテーション、個々のスライド、またはシェイプにタグを追加する方法も示します。さらに、すべてのタグをクリアする、名前でタグを削除する、タグ名の一覧を取得するなど、一般的なタグ管理タスクについても説明します。

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル（.pptx 拡張子のアイテム）は、Office Open XML 仕様の一部である PresentationML 形式で保存されています。Office Open XML 形式は、プレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素の一つであり、*スライド パート* は単一のスライドの内容を保持します。スライド パートは、ISO/IEC 29500 によって定義されたユーザー定義タグなど、多くのパーツへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）やユーザーは、タグ（[TagCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/)) および CustomXmlParts（[CustomXmlPartCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/customxmlpartcollection/)) として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値を取得する**

スライドでは、タグは [DocumentProperties::getKeywords()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#getKeywords) および [DocumentProperties::setKeywords()](https://reference.aspose.com/slides/ja/php-java/aspose.slides/documentproperties/#setKeywords) メソッドに対応しています。このサンプルコードは、Aspose.Slides for PHP via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) のタグ値を取得する方法を示しています。

```php
  $pres = new Presentation("pres.pptx");
  try {
    $keywords = $pres->getDocumentProperties()->getKeywords();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides では、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。例えば、北米の国々のプレゼンテーションをすべてまとめて分類したい場合、北米タグを作成し、該当する国（米国、メキシコ、カナダ）をその値として割り当てることができます。

このサンプルコードは、Aspose.Slides for PHP via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) にタグを追加する方法を示しています。

```php
  $pres = new Presentation("pres.pptx");
  try {
    $tags = $pres->getCustomData()->getTags();
    $pres->getCustomData()->getTags()->set_Item("MyTag", "My Tag Value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

タグは [Slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/slide/) に対しても設定できます：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $slide->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

あるいは個々の [Shape](https://reference.aspose.com/slides/ja/php-java/aspose.slides/shape/) に対しても設定できます：

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 50);
    $shape->getTextFrame()->setText("My text");
    $shape->getCustomData()->getTags()->set_Item("tag", "value");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **制限事項**

`getCustomData()->getTags()` を使用してカスタム データ タグ コレクションに追加されたタグは、PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際、これらのタグは PDF のタグ構造に **転送されません**。したがって、タグとして割り当てられたカスタム識別子は、タグ付き PDF から取得できません。

**回避策**: カスタム識別子をオブジェクトの **Alt Text**（例: `$shape->setAlternativeText("MyId")`）に保存できます。PDF にエクスポートした後、Alt Text が PDF のタグ構造に表示される場合があります。

## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/) は、すべてのキーと値のペアを一度に削除する [clear](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全な一覧を取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/ja/php-java/aspose.slides/tagcollection/getnamesoftags/) を使用します。これにより、すべてのタグ名が配列で返されます。