---
title: ".NET のプレゼンテーションにおけるタグとカスタム データの管理"
linktitle: "タグとカスタム データ"
type: docs
weight: 300
url: /ja/net/managing-tags-and-custom-data/
keywords:
- "ドキュメント プロパティ"
- "タグ"
- "カスタム データ"
- "タグの追加"
- "ペア値"
- "PowerPoint"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でタグとカスタム データを追加、読み取り、更新、削除する方法を学び、PowerPoint および OpenDocument プレゼンテーションの例を示します。"
---
## **概要**

この記事では、Aspose.Slides が PowerPoint プレゼンテーションのタグとカスタム データでどのように機能するかを説明します。PPTX ファイルにデータがどのように保存されるかを簡単に概説し、プレゼンテーション固有のデータがタグやカスタム XML パーツとして存在できることに言及し、タグをキーと値の文字列ペアとして説明します。

また、タグの値を取得する方法と、プレゼンテーション、個々のスライド、またはシェイプにタグを追加する方法を示します。さらに、すべてのタグをクリアする、名前でタグを削除する、タグ名の一覧を取得するなど、一般的なタグ管理タスクについても取り上げます。

## **プレゼンテーション ファイル内のデータ保存**

.pptx 拡張子の付いた PPTX ファイルは、Office Open XML 仕様の一部である PresentationML 形式で保存されます。Office Open XML 形式は、プレゼンテーション内のデータ構造を定義します。

*スライド* はプレゼンテーションの要素のひとつであり、*スライド パート* は単一スライドのコンテンツを保持します。スライド パートは、ISO/IEC 29500 によって定義されたユーザー定義タグなど、複数のパートへの明示的なリレーションシップを持つことが許可されています。

カスタム データ（プレゼンテーション固有）またはユーザー定義データは、タグ（[ITagCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/itagcollection)）およびカスタム XML パーツ（[ICustomXmlPartCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/icustomxmlpartcollection)）として存在できます。

{{% alert color="primary" %}} 
タグは本質的に文字列キーと値のペアです。 
{{% /alert %}} 

## **タグの値の取得**

スライドでは、タグは `IDocumentProperties.Keywords` プロパティに対応します。このサンプルコードは、Aspose.Slides for .NET の [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) でタグの値を取得する方法を示しています。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **プレゼンテーションへのタグの追加**

Aspose.Slides を使用すると、プレゼンテーションにタグを追加できます。タグは通常、次の 2 つの項目で構成されます。

- カスタム プロパティの名前 - `MyTag`
- カスタム プロパティの値 - `My Tag Value`

特定のルールやプロパティに基づいてプレゼンテーションを分類する必要がある場合、タグを追加すると便利です。たとえば、北米諸国のプレゼンテーションをまとめて分類したい場合、North American タグを作成し、該当する国（米国、メキシコ、カナダ）を値として割り当てることができます。

このサンプルコードは、Aspose.Slides for .NET で [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation) にタグを追加する方法を示しています。

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

タグは [Slide](https://reference.aspose.com/slides/ja/net/aspose.slides/slide) に対しても設定できます。

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

あるいは個別の [Shape](https://reference.aspose.com/slides/ja/net/aspose.slides/shape) に対しても設定できます。

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **制限事項**

`CustomData.Tags` コレクションを介して追加されたタグは PowerPoint ファイル内にのみ保存されます。プレゼンテーションを PDF にエクスポートした際、PDF のタグ構造へは **転送されません**。したがって、タグとして割り当てたカスタム識別子はタグ付き PDF から取得できません。

**回避策**: オブジェクトの **Alt Text**（例: `shape.AlternativeText = "MyId"`）にカスタム識別子を保存できます。PDF にエクスポートした後、Alt Text が PDF のタグ構造に現れる可能性があります。

## **FAQ**

**プレゼンテーション、スライド、またはシェイプからすべてのタグを一括で削除できますか？**

はい。[tag collection](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) は、すべてのキー‑バリュー ペアを一度に削除する [clear](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/clear/) 操作をサポートします。

**コレクション全体を走査せずに、名前で単一タグを削除するにはどうすればよいですか？**

[TagCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) の [Remove(name)](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/remove/) 操作を使用して、キー（名前）でタグを削除します。

**分析やフィルタリングのためにタグ名の完全なリストを取得するにはどうすればよいですか？**

[tag collection](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/) の [GetNamesOfTags](https://reference.aspose.com/slides/ja/net/aspose.slides/tagcollection/getnamesoftags/) を使用すると、すべてのタグ名の配列が返されます。