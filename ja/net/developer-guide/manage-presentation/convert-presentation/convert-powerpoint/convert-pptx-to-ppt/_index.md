---
title: C#でPPTXをPPTに変換
linktitle: PPTXをPPTに変換
type: docs
weight: 21
url: /ja/net/convert-pptx-to-ppt/
keywords: "C# PPTXをPPTに変換, PowerPointプレゼンテーションを変換, PPTXからPPT, C#, Aspose.Slides"
description: "C#でPowerPoint PPTXをPPTに変換"
---

## **概要**

この記事では、C# を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックが取り上げられています。

- C# で PPTX を PPT に変換する

## **C# で PPTX を PPT に変換**

C# のサンプルコードで PPTX を PPT に変換する方法については、以下のセクション[Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。これは PPTX ファイルを読み込み、PPT 形式で保存するだけです。異なる保存形式を指定すれば、PDF、XPS、ODP、HTML などのさまざまな形式でも PPTX ファイルを保存できます。これらの記事で詳しく説明しています。

- [C# PPTX を PDF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# PPTX を XPS に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# PPTX を HTML に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# PPTX を ODP に変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C# PPTX を Image に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**
PPTX を PPT に変換するには、ファイル名と保存形式を [**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドに渡すだけです。このメソッドは [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスにあります。以下の C# コードサンプルは、デフォルトオプションを使用して PPTX から PPT にプレゼンテーションを変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("presentation.pptx");

// PPTX プレゼンテーションを PPT 形式で保存します
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **よくある質問**

**PPTX のすべてのエフェクトや機能は、レガシー PPT (97–2003) 形式に保存したときに保持されますか？**

必ずしもそうではありません。PPT 形式には新しい機能のいくつか（例: 特定のエフェクト、オブジェクト、動作）が欠如しているため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換するには、必要なスライドだけで新しいプレゼンテーションを作成して PPT として保存します。あるいは、スライド単位の変換パラメータをサポートするサービス/API を使用します。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存する PPT の[保護/暗号化設定を構成する](/slides/ja/net/password-protected-presentation/)も設定できます。