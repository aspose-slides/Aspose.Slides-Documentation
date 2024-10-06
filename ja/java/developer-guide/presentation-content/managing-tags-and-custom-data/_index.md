---
title: タグとカスタムデータの管理
type: docs
weight: 300
url: /ja/java/managing-tags-and-custom-data

---

## プレゼンテーションファイルにおけるデータストレージ

PPTXファイル（.pptx拡張子のアイテム）は、Office Open XML仕様の一部であるPresentationML形式で保存されています。Office Open XML形式は、プレゼンテーションに含まれるデータの構造を定義します。

プレゼンテーションの要素の一つとして*スライド*があり、*スライドパート*は単一のスライドの内容を含みます。スライドパートは、ISO/IEC 29500によって定義されたユーザー定義タグなど、多くのパートに対して明示的な関係を持つことができます。

カスタムデータ（プレゼンテーションに特有のもの）やユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)）およびCustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 

タグは本質的に文字列キーのペア値です。

{{% /alert %}} 

## タグの値を取得する

スライドでは、タグは[IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--)および[IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-)メソッドに対応します。このサンプルコードは、Aspose.Slides for Javaを使用して[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)からタグの値を取得する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## プレゼンテーションにタグを追加する

Aspose.Slidesでは、プレゼンテーションにタグを追加することができます。タグは通常、次の二つのアイテムで構成されます：

- カスタムプロパティの名前 - `MyTag`
- カスタムプロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいていくつかのプレゼンテーションを分類する必要がある場合、タグを追加することでそのプレゼンテーションに利益をもたらすことができます。たとえば、北アメリカの国からのすべてのプレゼンテーションをカテゴリに分ける場合、北アメリカのタグを作成し、関連する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Javaを使用して[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)にタグを追加する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

タグは[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide)にも設定できます：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

または、任意の個別の[Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape)にも設定できます：

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