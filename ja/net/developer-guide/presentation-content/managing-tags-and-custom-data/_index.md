---
title: .NET でプレゼンテーションのタグとカスタム データを管理する
linktitle: タグとカスタム データ
type: docs
weight: 300
url: /ja/net/managing-tags-and-custom-data/
keywords:
- ドキュメント プロパティ
- タグ
- カスタム データ
- タグの追加
- ペア値
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でタグとカスタム データの追加、読み取り、更新、削除方法を学び、PowerPoint および OpenDocument プレゼンテーションの例を確認できます。"
---

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル（.pptx 拡張子のアイテム）は、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML 形式は、プレゼンテーションに含まれるデータの構造を定義します。

*スライド* はプレゼンテーションの要素のひとつであり、*スライド パート* は単一のスライドのコンテンツを含みます。スライド パートは、ISO/IEC 29500 で定義されたユーザー定義タグなど、複数のパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）またはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは IDocumentProperties.Keywords プロパティに対応します。このサンプルコードは、Aspose.Slides for .NET を使用して [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) のタグ値を取得する方法を示します：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます：

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加することで役立ちます。例えば、北米諸国のプレゼンテーションをまとめて分類したい場合、北米タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for .NET を使用して [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) にタグを追加する方法を示します：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```


タグは [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) に対しても設定できます：
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```


または個々の [Shape](https://reference.aspose.com/slides/net/aspose.slides/shape) に対しても設定できます：
```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```


## **よくある質問**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。 [tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) は、すべてのキーと値のペアを一度に削除する [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) 操作をサポートしています。

**コレクション全体を反復せずに、名前で単一のタグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) の上で [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) 操作を使用して、キーでタグを削除します。

**分析やフィルタリングのためにタグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) に対して [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) を使用します。すべてのタグ名の配列が返されます。