---
title: PowerPointをWordに変換
type: docs
weight: 110
url: /net/convert-powerpoint-to-word/
keywords:
- PowerPointを変換
- PPT
- PPTX
- プレゼンテーション
- Word
- DOCX
- DOC
- PPTXをDOCXへ
- PPTをDOCへ
- PPTXをDOCへ
- PPTをDOCXへ
- C#
- Csharp
- .NET
- Aspose.Slides
description: "C#または.NETでPowerPointプレゼンテーションをWordに変換"
---

プレゼンテーション（PPTまたはPPTX）からのテキストコンテンツや情報を新しい方法で使用する予定がある場合、プレゼンテーションをWord（DOCまたはDOCX）に変換することで利益を得られるかもしれません。

* Microsoft PowerPointと比較して、Microsoft Wordアプリはコンテンツのためのツールや機能がより充実しています。
* Wordの編集機能に加えて、コラボレーション、印刷、共有機能の向上も期待できます。

{{% alert color="primary" %}}

スライドからのテキストコンテンツを使用することで得られるものを確認するために、[**プレゼンテーションをWordにオンライン変換するツール**](https://products.aspose.app/slides/conversion/ppt-to-word)を試してみてください。

{{% /alert %}}

### **Aspose.SlidesとAspose.Words**

PowerPointファイル（PPTXまたはPPT）をWord（DOCXまたはDOC）に変換するには、[Aspose.Slides for .NET](https://products.aspose.com/slides/net/)と[Aspose.Words for .NET](https://products.aspose.com/words/net/)の両方が必要です。

スタンドアロンAPIとして、[Aspose.Slides](https://products.aspose.app/slides) for .NETは、プレゼンテーションからテキストを抽出するための機能を提供します。

[Aspose.Words](https://docs.aspose.com/words/net/)は、アプリケーションがファイルを生成、変更、変換、レンダリング、印刷、その他のドキュメント操作をMicrosoft Wordを利用せずに行うことを可能にする高度なドキュメント処理APIです。

## **PowerPointをWordに変換**

1. program.csファイルにこれらの名前空間を追加します：

```c#
using Aspose.Slides;
using Aspose.Words;
using System.IO;
```

2. このコードスニペットを使用して、PowerPointをWordに変換します：

```c#
using var presentation = new Presentation("sample.pptx");

var doc = new Document();
var builder = new DocumentBuilder(doc);

foreach (var slide in presentation.Slides)
{
    // スライドの画像を生成し、メモリストリームに保存します
    using var image = slide.GetImage(1, 1);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray());

    // スライドのテキストを挿入します
    foreach (var shape in slide.Shapes)
    {
        if (shape is AutoShape autoShape)
        {
            builder.Writeln(autoShape.TextFrame.Text);
        }
    }

    builder.InsertBreak(BreakType.PageBreak);
}

doc.Save("output.docx");
```