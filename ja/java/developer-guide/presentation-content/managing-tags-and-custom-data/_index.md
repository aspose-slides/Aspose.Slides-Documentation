---
title: Java を使用したプレゼンテーションでのタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/java/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java におけるタグとカスタム データの追加、読み取り、更新、削除方法を学び、PowerPoint と OpenDocument のプレゼンテーション例を紹介します。"
---

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル（拡張子 .pptx のアイテム）は、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML 形式は、プレゼンテーションに含まれるデータの構造を定義します。

プレゼンテーションの要素のひとつである*スライド*は、*スライド パート*として単一のスライドの内容を保持します。スライド パートは、ISO/IEC 29500 によって定義されたユーザー定義タグなど、複数のパートへの明示的な関係を持つことが許可されています。

カスタム データ（プレゼンテーション固有）やユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ITagCollection)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値を取得する**

スライド内のタグは、[IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#getKeywords--) および [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) メソッドに対応します。このサンプルコードは、Aspose.Slides for Java の [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) でタグの値を取得する方法を示します:
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレゼンテーションにタグを追加する**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 – `MyTag` 
- カスタム プロパティの値 – `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American というタグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) にタグを追加する方法を示します:
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


タグは [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide) に対しても設定できます:
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


または個々の [Shape](https://reference.aspose.com/slides/java/com.aspose.slides/IAutoShape) に対しても設定できます:
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

はい。[tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) は、すべてのキー–バリュー ペアを一度に削除する [clear](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#clear--) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作を使用して、キーでタグを削除できます。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/java/com.aspose.slides/tagcollection/#getNamesOfTags--) を使用すると、すべてのタグ名を含む配列が返されます。