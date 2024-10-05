---
title: タグとカスタムデータの管理
type: docs
weight: 300
url: /net/managing-tags-and-custom-data
keywords: "タグ, カスタムデータ, タグの値, タグを追加, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションにタグとカスタムデータを追加します"
---

## プレゼンテーションファイルのデータストレージ

PPTXファイル（.pptx拡張子を持つアイテム）は、Office Open XML仕様の一部であるPresentationML形式で保存されます。Office Open XML形式は、プレゼンテーションに含まれるデータの構造を定義しています。 

*スライド*はプレゼンテーションの要素の1つであり、*スライドパート*は1つのスライドの内容を含んでいます。スライドパートは、ISO/IEC 29500によって定義された多くのパート—ユーザー定義タグなど—との明示的な関係を持つことが許可されています。

プレゼンテーションに特有のカスタムデータまたはユーザーは、タグ（[ITagCollection](https://reference.aspose.com/slides/net/aspose.slides/itagcollection)）およびCustomXmlParts（[ICustomXmlPartCollection](https://reference.aspose.com/slides/net/aspose.slides/icustomxmlpartcollection)）として存在することができます。

{{% alert color="primary" %}} 

タグは本質的に文字列-キーのペア値です。 

{{% /alert %}} 

## タグの値を取得する

スライドでは、タグはIDocumentProperties.Keywordsプロパティに対応します。このサンプルコードは、Aspose.Slides for .NETを使用して[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)のタグの値を取得する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## プレゼンテーションにタグを追加する

Aspose.Slidesを使用すると、プレゼンテーションにタグを追加することができます。タグは通常、2つの項目で構成されます：

- カスタムプロパティの名前 - `MyTag` 
- カスタムプロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいていくつかのプレゼンテーションを分類する必要がある場合は、それらのプレゼンテーションにタグを追加することでメリットを得ることができます。たとえば、北米の国々からのすべてのプレゼンテーションをカテゴリ化またはまとめたい場合は、北米タグを作成し、関連する国（アメリカ、メキシコ、カナダ）を値として割り当てることができます。 

このサンプルコードは、Aspose.Slides for .NETを使用して[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)にタグを追加する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

タグは[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide)にも設定できます：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

または、個々の[Shape](https://reference.aspose.com/slides/net/aspose.slides/shape)にも：

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```