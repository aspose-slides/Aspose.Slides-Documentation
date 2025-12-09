---
title: .NET のフォント置換に対する警告コールバックを取得
type: docs
weight: 120
url: /ja/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告コールバック
- フォント置換
- レンダリングプロセス
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET でフォント置換に対する警告コールバックを取得し、PowerPoint と OpenDocument のプレゼンテーションを正確に表示する方法を学びます。"
---

## **概要**

Aspose.Slides for .NET は、レンダリング中に必要なフォントがマシンに存在しない場合のフォント置換に対して警告コールバックを受け取ることができます。これらのコールバックは、フォントが欠落している、またはアクセスできない問題の診断に役立ちます。

## **警告コールバックの有効化**

Aspose.Slides for .NET は、プレゼンテーション スライドのレンダリング時に警告コールバックを受け取るためのシンプルな API を提供します。警告コールバックを構成する手順は以下の通りです。

1. 警告を処理するために、[IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) インターフェイスを実装したカスタムコールバック クラスを作成します。
1. [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/)、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)、[HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) などのオプション クラスを使用して警告コールバックを設定します。
1. ターゲット マシンに存在しないフォントを使用しているプレゼンテーションをロードします。
1. スライドのサムネイルを生成するか、プレゼンテーションをエクスポートして効果を確認します。

**カスタム警告コールバック クラス:**
```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// 例の出力:
// 
// フォントは XYZ から {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```


**スライドのサムネイルを生成:**
```c#
// スライドのレンダリング中にフォント関連の警告を処理するために警告コールバックを設定します。
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// 指定されたファイルパスからプレゼンテーションをロードします。
using var presentation = new Presentation("sample.pptx");

// プレゼンテーション内の各スライドのサムネイル画像を生成します。
foreach (var slide in presentation.Slides)
{
    // 指定されたレンダリングオプションを使用してスライドのサムネイル画像を取得します。
    using var image = slide.GetImage(options);
    // ...
}
```


**PDF 形式にエクスポート:**
```c#
// PDF エクスポート中のフォント関連警告を処理するために警告コールバックを設定します。
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// 指定されたファイルパスからプレゼンテーションをロードします。
using var presentation = new Presentation("sample.pptx");

// プレゼンテーションを PDF としてエクスポートします。
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```


**HTML 形式にエクスポート:**
```c#
// HTML エクスポート中のフォント関連の警告を処理するために警告コールバックを設定します。
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// 指定されたファイルパスからプレゼンテーションをロードします。
using var presentation = new Presentation("sample.pptx");

// プレゼンテーションを HTML 形式でエクスポートします。
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```
