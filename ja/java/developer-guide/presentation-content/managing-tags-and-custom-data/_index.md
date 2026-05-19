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
description: "Aspose.Slides for Java において、タグとカスタム データの追加、読み取り、更新、削除方法を学び、PowerPoint および OpenDocument プレゼンテーションの例を紹介します。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーション内のタグおよびカスタム データとどのように連携するかを説明します。データが PPTX ファイルにどのように格納されるかを簡単に概説し、プレゼンテーション固有のデータがタグやカスタム XML パーツとして存在できることに言及し、タグをキーとバリューの文字列ペアとして説明します。

さらに、タグの値を取得する方法と、プレゼンテーション、個別のスライド、またはシェイプにタグを追加する方法を示します。加えて、すべてのタグをクリアする、名前でタグを削除する、タグ名の一覧を取得するといった一般的なタグ管理タスクも取り上げます。

## **プレゼンテーション ファイルにおけるデータ格納**

.pptx 拡張子を持つ PPTX ファイルは、Office Open XML 仕様の一部である PresentationML フォーマットで保存されます。Office Open XML フォーマットは、プレゼンテーションに含まれるデータの構造を定義します。

プレゼンテーションの要素のひとつである *スライド* は、*スライド パート* に単一スライドのコンテンツが格納されます。スライド パートは、ISO/IEC 29500 によって定義された User Defined Tags など、複数のパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）やユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ITagCollection)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ICustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーとバリューのペアです。 
{{% /alert %}} 

## **タグの値を取得する**

スライドでは、タグは [IDocumentProperties.getKeywords()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IDocumentProperties#getKeywords--) および [IDocumentProperties.setKeywords()](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IDocumentProperties#setKeywords-java.lang.String-) メソッドに相当します。このサンプルコードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) のタグ値を取得する方法を示しています。

```java
Presentation pres = new Presentation("pres.pptx");
try{
    String keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) pres.dispose();
}
```

## **プレゼンテーションにタグを追加する**

Aspose.Slides ではプレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 – `MyTag`
- カスタム プロパティの値 – `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて管理したい場合、North American タグを作成し、対象国（米国、メキシコ、カナダ）を値として設定できます。

このサンプルコードは、Aspose.Slides for Java を使用して [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/Presentation) にタグを追加する方法を示しています。

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ITagCollection tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) pres.dispose();
}
```

タグは [Slide](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ISlide) に対しても設定できます。

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) pres.dispose();
}
```

あるいは個別の [Shape](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IAutoShape) に対しても設定できます。

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

`getCustomData().getTags()` を使用したカスタム データ タグ コレクションによって追加されたタグは、PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際の PDF タグ構造には **転送されません**。したがって、タグとして割り当てたカスタム識別子は、タグ付き PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例: `shape.setAlternativeText("MyId")`）にカスタム識別子を保存できます。PDF にエクスポート後、Alt Text が PDF タグ構造に現れることがあります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一度に削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/) は、すべてのキー–バリュー ペアを一括で削除する [clear](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#clear--) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一タグを削除するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#remove-java.lang.String-) 操作を使用して、キーでタグを削除できます。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/ja/java/com.aspose.slides/tagcollection/#getNamesOfTags--) を使用すると、すべてのタグ名の配列が返されます。