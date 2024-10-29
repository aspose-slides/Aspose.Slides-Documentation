---
title: タグとカスタムデータの管理
type: docs
weight: 300
url: /ja/php-java/managing-tags-and-custom-data

---

## プレゼンテーションファイルのデータストレージ

PPTXファイル（拡張子.pptxのアイテム）は、Office Open XML仕様の一部であるPresentationML形式で保存されます。Office Open XML形式は、プレゼンテーションに含まれるデータの構造を定義します。

*スライド*はプレゼンテーションの要素の1つであり、*スライド部分*は単一のスライドの内容を含んでいます。スライド部分は、ISO/IEC 29500によって定義された多数の部分（ユーザー定義タグなど）との明示的な関係を持つことができます。

カスタムデータ（プレゼンテーション特有）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)）やCustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 

タグは本質的に文字列キーと値のペアです。

{{% /alert %}} 

## タグの値を取得する

スライドでは、タグは[IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--)および[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-)メソッドに対応します。このサンプルコードは、Aspose.Slides for PHPを使用してJava経由で[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)からタグの値を取得する方法を示しています。

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

## プレゼンテーションにタグを追加する

Aspose.Slidesは、プレゼンテーションにタグを追加することを許可します。タグは通常、以下の2つの項目で構成されます。

- カスタムプロパティの名前 - `MyTag`
- カスタムプロパティの値 - `My Tag Value`

特定のルールまたはプロパティに基づいて複数のプレゼンテーションを分類する必要がある場合、これらのプレゼンテーションにタグを追加することで利益を得ることができます。たとえば、北米の国々からのすべてのプレゼンテーションをカテゴリー化またはまとめたい場合、北米タグを作成し、関連する国（アメリカ、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for PHPを使用してJava経由で[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)にタグを追加する方法を示しています。

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

タグは[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide)にも設定できます。

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

また、個々の[Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape)にも設定できます。

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