---
title: パーション
type: docs
weight: 70
url: /ja/net/portion/
keywords: "Portion, PowerPoint シェイプ, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションの Portion を取得する"
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


## **FAQ**

**単一の段落内のテキストの一部だけにハイパーリンクを適用できますか？**

はい、個々の部分に[ハイパーリンクを割り当て](/slides/ja/net/manage-hyperlinks/)ることができます。そのフラグメントだけがクリック可能になり、段落全体はクリックできません。

**スタイルの継承はどのように機能しますか？ Portion が上書きするもの、 Paragraph / TextFrame から取得するものは何ですか？**

Portion レベルのプロパティが最も高い優先順位を持ちます。プロパティが[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)で設定されていない場合、エンジンは[Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/)から取得します。そこでも設定されていない場合は、[TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/)または[theme](https://reference.aspose.com/slides/net/aspose.slides.theme/theme/)のスタイルから取得します。

**Portion に指定されたフォントが対象のマシン/サーバーに存在しない場合はどうなりますか？**

[フォント代替ルール](/slides/ja/net/font-selection-sequence/)が適用されます。テキストは再フローする可能性があり、メトリクス、ハイフネーション、幅が変化することがあり、正確な位置決めに影響します。

**段落全体とは別に、 Portion 固有のテキスト塗りつぶしの透明度やグラデーションを設定できますか？**

はい、[Portion](https://reference.aspose.com/slides/net/aspose.slides/portion/)レベルでテキストの色、塗りつぶし、透明度を隣接するフラグメントと異なる設定にできます。