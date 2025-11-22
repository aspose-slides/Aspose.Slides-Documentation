---
title: タグとカスタム データの管理
type: docs
weight: 300
url: /ja/net/managing-tags-and-custom-data
keywords: "タグ, カスタム データ, タグの値, タグの追加, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにタグとカスタム データを追加する"
---

## **プレゼンテーション ファイルのデータ保存**

PPTX ファイル（.pptx 拡張子のアイテム）は PresentationML フォーマットで保存されており、これは Office Open XML 仕様の一部です。Office Open XML フォーマットはプレゼンテーションに含まれるデータの構造を定義します。

スライドはプレゼンテーションの要素の一つであり、*スライド パート* は単一のスライドのコンテンツを含みます。スライド パートは ISO/IEC 29500 で定義されたユーザー定義タグなど、複数のパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）やユーザーはタグ（[ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)）および CustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは IDocumentProperties.Keywords プロパティに対応します。このサンプルコードは、Aspose.Slides for .NET の [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) でタグの値を取得する方法を示しています：
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```


## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、2 つの項目で構成されます:

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米の国々のプレゼンテーションをまとめて分類したい場合、北米タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for .NET を使用して [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) にタグを追加する方法を示しています：
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


## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) は [clear](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/clear/) 操作をサポートしており、すべてのキーと値のペアを一度に削除します。

**コレクション全体を反復処理せずに、名前で単一のタグを削除するにはどうすればよいですか？**

タグのキーで削除するには、[TagCollection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/remove/) 操作を使用します。

**分析やフィルタリングのためにタグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/) で [GetNamesOfTags](https://reference.aspose.com/slides/net/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。