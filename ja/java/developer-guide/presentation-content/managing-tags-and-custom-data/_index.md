---
title: "Java を使用したプレゼンテーションでのタグとカスタムデータの管理"
linktitle: "タグとカスタムデータ"
type: docs
weight: 300
url: /ja/java/managing-tags-and-custom-data/
keywords:
- "ドキュメント プロパティ"
- "タグ"
- "カスタム データ"
- "タグの追加"
- "ペア 値"
- "PowerPoint"
- "プレゼンテーション"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java でタグとカスタムデータの追加、読み取り、更新、削除を学び、PowerPoint と OpenDocument プレゼンテーションの例をご紹介します。"
---

## プレゼンテーション ファイルのデータストレージ

PPTX ファイル（拡張子が .pptx のアイテム）は、Office Open XML 仕様の一部である PresentationML フォーマットで保存されます。Office Open XML フォーマットは、プレゼンテーションに含まれるデータの構造を定義します。

*slide* はプレゼンテーションの要素の一つであり、*slide part* は単一スライドの内容を含みます。スライドパートは、ISO/IEC 29500 で定義されたユーザー定義タグなど、多くのパートへの明示的なリレーションシップを持つことができます。

カスタムデータ（プレゼンテーション固有）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)）や CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## タグの値の取得

スライドでは、タグは [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) と [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) メソッドに対応します。このサンプルコードは、Aspose.Slides for Java の [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) でタグの値を取得する方法を示しています。
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## プレゼンテーションへのタグの追加

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、以下の 2 つの項目で構成されます：

- カスタムプロパティの名前 - `MyTag`
- カスタムプロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American タグを作成し、関連する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) にタグを追加する方法を示しています。
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


タグは [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) に対しても設定できます：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


または個々の [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) に対しても設定できます：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) は、すべてのキーと値のペアを一度に削除する [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) 操作をサポートしています。

**コレクション全体を反復せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) に対して [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作を使用し、キー（名前）でタグを削除します。

**分析やフィルタリングのためにタグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) の上で [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) を使用します。すべてのタグ名の配列が返されます。