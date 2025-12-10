---
title: .NET のプレゼンテーションでテキスト部分を管理する
linktitle: テキスト部分
type: docs
weight: 70
url: /ja/net/portion/
keywords:
- テキスト部分
- テキストパート
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **テキスト部分の座標取得**
**GetCoordinates()** メソッドが IPortion および Portion クラスに追加され、部分の開始位置の座標を取得できるようになりました:
```c#
using (Presentation presentation = new Presentation("Shapes.pptx"))
{
    IAutoShape shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var textFrame = (ITextFrame)shape.TextFrame;

    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (Portion portion in paragraph.Portions)
        {
            PointF point = portion.GetCoordinates();
            Console.Write(Environment.NewLine + "Corrdinates X =" + point.X + " Corrdinates Y =" + point.Y);
        }
    }
}
```


## **よくある質問**

**単一の段落内のテキストの一部にだけハイパーリンクを適用できますか？**

はい、個別の部分に対して[ハイパーリンクを割り当て](/slides/ja/net/manage-hyperlinks/)することができます。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイルの継承はどのように機能しますか：Portion が上書きするものは何で、Paragraph/TextFrame から取得されるものは何ですか？**

Portion レベルのプロパティが最も優先されます。プロパティが [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) で設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) から取得します。そこでも設定されていない場合は、[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/) のスタイルから取得されます。

**Portion 用に指定されたフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/net/font-selection-sequence/) が適用されます。テキストは再フローする可能性があり、メトリクス、ハイフネーション、幅が変わることがあり、正確な位置決めに影響します。

**段落全体とは独立して、Portion 固有のテキスト塗りつぶしの透過性やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) レベルでテキストカラー、塗りつぶし、透過性を隣接するフラグメントとは異なる設定にできます。