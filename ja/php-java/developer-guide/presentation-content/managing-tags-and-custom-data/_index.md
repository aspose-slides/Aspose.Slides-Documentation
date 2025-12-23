---
title: "プレゼンテーションでタグとカスタムデータをPHPで管理する"
linktitle: "タグとカスタムデータ"
type: docs
weight: 300
url: /ja/php-java/managing-tags-and-custom-data/
keywords:
- "ドキュメント プロパティ"
- "タグ"
- "カスタム データ"
- "タグの追加"
- "ペア値"
- "PowerPoint"
- "プレゼンテーション"
- "PHP"
- "Aspose.Slides"
description: "Aspose.Slides for PHP via Java で、PowerPoint と OpenDocument のプレゼンテーションの例を用いて、タグとカスタムデータの追加、読み取り、更新、削除方法を学びます。"
---

## **プレゼンテーション ファイルのデータ ストレージ**

PPTX ファイル（拡張子が .pptx の項目）は、Office Open XML 仕様の一部である PresentationML フォーマットで保存されます。Office Open XML フォーマットは、プレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素の一つであり、*スライド パート* は単一のスライドの内容を保持します。スライド パートは、ISO/IEC 29500 で定義されたユーザー定義タグなど、多くのパートへの明示的な関連付けを持つことができます。

カスタム データ（プレゼンテーション固有）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ITagCollection)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#getKeywords--) および [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/php-java/aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) メソッドに対応します。このサンプル コードは、Aspose.Slides for PHP via Java を使用して [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) のタグの値を取得する方法を示しています：
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


## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、2 つの項目で構成されます:
- カスタム プロパティの名前 – `MyTag`
- カスタム プロパティの値 – `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをすべてまとめて分類したい場合、北米タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプル コードは、Aspose.Slides for PHP via Java を使用して [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) にタグを追加する方法を示しています：
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


タグは [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) に対しても設定できます：
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


または任意の個別 [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/IAutoShape) に対しても設定できます：
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


## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一度に削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) は、すべてのキーと値のペアを一度に削除する [clear](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのためにタグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/) 上で [getNamesOfTags](https://reference.aspose.com/slides/php-java/aspose.slides/tagcollection/getnamesoftags/) を使用します。すべてのタグ名の配列が返されます。