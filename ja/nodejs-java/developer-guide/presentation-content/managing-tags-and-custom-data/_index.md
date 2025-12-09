---
title: タグとカスタムデータの管理
type: docs
weight: 300
url: /ja/nodejs-java/managing-tags-and-custom-data
---

## **プレゼンテーション ファイルのデータ ストレージ**

PPTX ファイル（.pptx 拡張子のアイテム）は、Office Open XML 仕様の一部である PresentationML フォーマットで保存されます。Office Open XML フォーマットは、プレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素の一つで、*スライド パート* は単一のスライドの内容を含みます。スライド パートは、ISO/IEC 29500 で定義されたユーザー定義タグなど、複数のパートへの明示的なリレーションシップを持つことができます。

カスタム データ（プレゼンテーション固有）やユーザーは、タグ（[TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TagCollection)）や CustomXmlParts（[CustomXmlPartCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/CustomXmlPartCollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーのペア値です。 
{{% /alert %}} 

## **タグの値を取得する**

スライドでは、タグは[DocumentProperties.getKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#getKeywords--) および[DocumentProperties.setKeywords()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/DocumentProperties#setKeywords-java.lang.String-) メソッドに対応しています。このサンプルコードは、Aspose.Slides for Node.js via Java を使用して[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) のタグの値を取得する方法を示しています：
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

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます:

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。例えば、北米諸国のプレゼンテーションをまとめてカテゴリ分けしたい場合、北米タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for Node.js via Java を使用して[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation) にタグを追加する方法を示しています：
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


タグは[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) に対しても設定できます：
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


あるいは個々の[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) に対しても設定できます：
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


## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) は、すべてのキーと値のペアを一度に削除する[clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を走査せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) の[remove(name)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのために、タグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/) で[getNamesOfTags](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tagcollection/getnamesoftags/) を使用します。これにより、すべてのタグ名の配列が返されます。