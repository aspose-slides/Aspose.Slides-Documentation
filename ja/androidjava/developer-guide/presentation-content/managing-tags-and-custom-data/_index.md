---
title: Android でのプレゼンテーションにおけるタグとカスタム データの管理
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/androidjava/managing-tags-and-custom-data
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でタグとカスタム データを追加、読み取り、更新、削除し、PowerPoint および OpenDocument プレゼンテーションの Java サンプルを提供します。"
---
## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル — 拡張子 .pptx の項目 — は PresentationML 形式で保存されており、これは Office Open XML 仕様の一部です。Office Open XML 形式は、プレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素の一つで、*スライド パート* は単一のスライドの内容を含みます。スライド パートは ISO/IEC 29500 で定義されたユーザー定義タグなど、多くのパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）やユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ITagCollection)）や CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IDocumentProperties#getKeywords--) および [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) メソッドに対応します。このサンプルコードは、Aspose.Slides for Android（Java）を使用して [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) のタグ値を取得する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、2 つの項目で構成されます:

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。例えば、北米諸国のプレゼンテーションをまとめて分類したい場合、北米タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Android（Java）を使用して [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/Presentation) にタグを追加する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

タグは [Slide](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ISlide) にも設定できます：

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

または個々の [Shape](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IAutoShape) にも設定できます：

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

### **制限事項**

`getCustomData().getTags()` を使用してカスタム データ タグ コレクションに追加されたタグは、PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートすると、これらのタグは PDF タグ構造に **転送されません**。その結果、タグとして割り当てたカスタム識別子は、タグ付けされた PDF から取得できません。

**回避策**: カスタム識別子をオブジェクトの **Alt Text**（例: `shape.setAlternativeText("MyId")`）に保存できます。PDF にエクスポートした後、Alt Text が PDF タグ構造に表示される場合があります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一度に削除できますか？**

はい。 [タグコレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/) は [clear](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/#clear--) 操作をサポートしており、すべてのキー–バリュー ペアを一括で削除できます。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[tagコレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tagコレクション](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/tagcollection/#getNamesOfTags--) を使用すると、すべてのタグ名の配列が返されます。