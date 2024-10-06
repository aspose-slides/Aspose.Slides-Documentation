---
title: タグとカスタムデータの管理
type: docs
weight: 300
url: /ja/androidjava/managing-tags-and-custom-data

---

## プレゼンテーションファイルにおけるデータストレージ

PPTXファイル（.pptx拡張子を持つアイテム）は、Office Open XML仕様の一部であるPresentationML形式で保存されます。Office Open XML形式は、プレゼンテーションに含まれるデータの構造を定義します。

*スライド*はプレゼンテーションの要素の一つであり、*スライドパート*は単一スライドの内容を含みます。スライドパートは、ISO/IEC 29500によって定義された多くのパート（ユーザー定義タグなど）との明示的な関係を持つことができます。

カスタムデータ（プレゼンテーション特有のもの）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)）やCustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)）として存在することができます。

{{% alert color="primary" %}} 

タグは本質的に文字列キー対値のペアです。 

{{% /alert %}} 

## タグの値を取得する

スライド内で、タグは[IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--)および[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-)メソッドに対応します。このサンプルコードは、Aspose.Slides for Androidを使用してJava経由で[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)からタグの値を取得する方法を示しています。

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## プレゼンテーションにタグを追加する

Aspose.Slidesを使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の2つのアイテムで構成されています：

- カスタムプロパティの名前 - `MyTag` 
- カスタムプロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいていくつかのプレゼンテーションを分類する必要がある場合は、それらのプレゼンテーションにタグを追加することが利益になるかもしれません。例えば、北米諸国のすべてのプレゼンテーションをまとめてカテゴリ分けしたい場合、北米タグを作成し、関連する国（アメリカ、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Androidを使用してJava経由で[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)にタグを追加する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

タグは[Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide)にも設定できます：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

または、任意の個別の[Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape)にも設定できます：

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