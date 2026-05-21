---
title: "JavaScript を使用したプレゼンテーションのタグとカスタム データの管理"
linktitle: "タグとカスタム データ"
type: docs
weight: 300
url: /ja/nodejs-java/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア 値
- PowerPoint
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js でタグとカスタム データを追加、読み取り、更新、削除する方法を学び、PowerPoint および OpenDocument プレゼンテーションの例を示します。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションでタグとカスタム データをどのように扱うかを説明します。PPTX ファイルにデータがどのように保存されるかを簡潔に概説し、プレゼンテーション固有のデータがタグやカスタム XML パーツとして存在できることに触れ、タグをキーとバリューの文字列ペアとして説明します。

また、タグの値を取得する方法と、プレゼンテーション、個々のスライド、またはシェイプにタグを追加する方法を示します。さらに、すべてのタグをクリアする、名前でタグを削除する、タグ名の一覧を取得するなど、一般的なタグ管理タスクについてもカバーしています。

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル（拡張子 .pptx のアイテム）は PresentationML 形式で保存されており、これは Office Open XML 仕様の一部です。Office Open XML 形式は、プレゼンテーションに含まれるデータの構造を定義しています。

プレゼンテーションの要素の一つである *スライド* に対し、*スライド パート* は単一スライドの内容を保持します。スライド パートは、ISO/IEC 29500 によって定義された User Defined Tags など、多くのパートへの明示的なリレーションシップを持つことが許容されています。

カスタム データ（プレゼンテーション固有）またはユーザーは、タグ（[TagCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/TagCollection)）や CustomXmlParts（[CustomXmlPartCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/CustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーとバリューのペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは [DocumentProperties.getKeywords()](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) および [DocumentProperties.setKeywords()](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) メソッドに対応します。このサンプルコードは、Aspose.Slides for Node.js via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) のタグ値を取得する方法を示します。

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var keywords = pres.getDocumentProperties().getKeywords();
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 – `MyTag`
- カスタム プロパティの値 – `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American タグを作成し、対象となる国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Node.js via Java を使用して [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Presentation) にタグを追加する方法を示します。

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tags = pres.getCustomData().getTags();
    pres.getCustomData().getTags().set_Item("MyTag", "My Tag Value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

タグは [Slide](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/Slide) に対しても設定できます。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    slide.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

または個々の [Shape](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/AutoShape) に対しても設定できます。

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 50);
    shape.getTextFrame().setText("My text");
    shape.getCustomData().getTags().set_Item("tag", "value");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **制限事項**

`getCustomData().getTags()` を使用したカスタム データ タグ コレクションに追加されたタグは、PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際、タグ構造へは **転送されません**。したがって、タグとして割り当てたカスタム 識別子は、タグ付けされた PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例：`shape.setAlternativeText("MyId")`）にカスタム 識別子を保存できます。PDF にエクスポート後、Alt Text が PDF のタグ構造に現れる可能性があります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一度に削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/) は [clear](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/clear/) 操作をサポートしており、すべてのキー–バリュー ペアを一括で削除できます。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/) の [remove(name)](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除できます。

**分析やフィルタリングのために、タグ名の完全な一覧を取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/) の [getNamesOfTags](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。