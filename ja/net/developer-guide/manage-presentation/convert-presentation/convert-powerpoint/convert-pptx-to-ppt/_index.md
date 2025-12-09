---
title: .NET で PPTX を PPT に変換
linktitle: PPTX から PPT
type: docs
weight: 21
url: /ja/net/convert-pptx-to-ppt/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPTX を変換
- PPTX から PPT
- PPTX を PPT として保存
- PPTX を PPT にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を保持します。"
---

## **概要**

この記事では、C# を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法について説明します。以下のトピックがカバーされています。

- C# で PPTX を PPT に変換

## **C# で PPTX を PPT に変換**

C# のサンプルコードについては、以下のセクション[Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。これは PPTX ファイルを読み込み、PPT 形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの他の多数の形式でも PPTX ファイルを保存できます。これらの記事で説明されています。

- [C# で PPTX を PDF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# で PPTX を XPS に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# で PPTX を HTML に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# で PPTX を ODP に変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C# で PPTX を画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**
PPTX を PPT に変換するには、ファイル名と保存形式を[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)メソッドに、[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスのインスタンスに渡すだけです。以下の C# コードサンプルは、デフォルトオプションを使用して PPTX から PPT へプレゼンテーションを変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトを作成します
Presentation pres = new Presentation("presentation.pptx");

// PPTX プレゼンテーションを PPT 形式で保存します
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**PPTX のすべてのエフェクトや機能は、レガシー PPT（97–2003）形式で保存しても保持されますか？**

必ずしもそうではありません。PPT 形式には新しい機能の一部（例: 特定のエフェクト、オブジェクト、動作）が欠けているため、変換時に機能が簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存するとプレゼンテーション全体が対象となります。特定のスライドだけを変換するには、そのスライドだけを含む新しいプレゼンテーションを作成して PPT として保存します。あるいは、スライド単位の変換パラメータをサポートするサービス／API を利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存する PPT の保護／暗号化設定を[保護/暗号化設定の構成](/slides/ja/net/password-protected-presentation/)で構成することもできます。