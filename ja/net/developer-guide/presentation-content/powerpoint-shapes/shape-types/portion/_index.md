---
title: .NETでのプレゼンテーションにおけるテキスト部分の管理
linktitle: テキスト部分
type: docs
weight: 70
url: /ja/net/portion/
keywords:
- テキスト部分
- テキスト部
- テキスト座標
- テキスト位置
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PowerPoint プレゼンテーションのテキスト部分を管理し、パフォーマンスとカスタマイズ性を向上させる方法を学びます。"
---

## **部分の位置座標を取得**
**GetCoordinates()** メソッドが IPortion と Portion クラスに追加され、部分の開始位置の座標を取得できるようになりました:
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

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、[ハイパーリンクを割り当てる](/slides/ja/net/manage-hyperlinks/)ことが個々の部分に対して可能です。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイル継承はどのように機能しますか: Portion がオーバーライドするもの、Paragraph/TextFrame から取得するものは何ですか？**

Portion レベルのプロパティが最も高い優先順位を持ちます。プロパティが [Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) に設定されていない場合、エンジンは [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) から取得します。そこでも設定されていなければ、[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) または [theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/) スタイルから取得します。

**Portion に指定したフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント置換ルール](/slides/ja/net/font-selection-sequence/) が適用されます。テキストは再フローする可能性があり、メトリクス、ハイフネーション、幅が変わるため、正確な配置に影響します。

**段落全体とは独立して、Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/) レベルでのテキストカラー、塗りつぶし、透明度は隣接するフラグメントと異なる設定が可能です。