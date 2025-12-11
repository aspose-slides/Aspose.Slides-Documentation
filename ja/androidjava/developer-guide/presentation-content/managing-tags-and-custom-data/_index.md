---
title: Androidでのプレゼンテーションにおけるタグとカスタムデータの管理
linktitle: タグとカスタムデータ
type: docs
weight: 300
url: /ja/androidjava/managing-tags-and-custom-data
keywords:
- ドキュメントプロパティ
- タグ
- カスタムデータ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Androidでタグとカスタムデータを追加、読み取り、更新、削除します。PowerPointおよびOpenDocumentプレゼンテーションのJava例付き。"
---

## **プレゼンテーション ファイルのデータ格納**

PPTX ファイル（.pptx 拡張子のアイテム）は、Office Open XML 仕様の一部である PresentationML フォーマットで保存されます。Office Open XML フォーマットは、プレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素の一つであり、*スライド パート* は単一のスライドの内容を含みます。スライド パートは、ISO/IEC 29500 で定義されたユーザー定義タグなど、多くのパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）やユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ITagCollection)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) および [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) メソッドに対応します。このサンプルコードは、Aspose.Slides for Android via Java を使用して [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) のタグ値を取得する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```


## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいていくつかのプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。例えば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American タグを作成し、該当する国（米国、メキシコ、カナダ）をその値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Android via Java を使用して [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) にタグを追加する方法を示しています：
```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```


タグは [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide) に対しても設定できます：
```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```


または個々の [Shape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IAutoShape) に対しても設定できます：
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

はい。 [tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) は、すべてのキーと値のペアを一度に削除する [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#clear--) 操作をサポートしています。

**コレクション全体を反復処理せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) を使用します。すべてのタグ名の配列が返されます。