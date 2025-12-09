---
title: .NET で PPTX を PPT に変換
linktitle: PPTX から PPT へ
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
description: "Aspose.Slides for .NET を使用して PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を保ちます。"
---

## **概要**

この記事では、C# を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックが取り上げられます。

- C# で PPTX を PPT に変換する

## **C# で PPTX を PPT に変換する**

C# のサンプルコードについては、以下のセクション、すなわち[Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。これは PPTX ファイルをロードし、PPT 形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTML など、これらの記事で説明されている多数の形式に PPTX ファイルを保存することもできます。

- [C# で PPTX を PDF に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C# で PPTX を XPS に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C# で PPTX を HTML に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C# で PPTX を ODP に変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C# で PPTX を画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**

PPTX を PPT に変換するには、ファイル名と保存形式を[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドに渡すだけです。このメソッドは[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスのものです。以下の C# コードサンプルは、デフォルトオプションを使用して PPTX から PPT にプレゼンテーションを変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("presentation.pptx");

// PPTX プレゼンテーションを PPT 形式で保存します
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**PPTX のすべてのエフェクトや機能は、レガシー PPT (97–2003) 形式で保存するときに保持されますか？**

必ずしもそうではありません。PPT 形式にはいくつかの新しい機能（例：特定のエフェクト、オブジェクト、動作）が欠けているため、変換時に機能が簡略化されたりラスター化されたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換するには、目的のスライドだけを含む新しいプレゼンテーションを作成し、PPT として保存します。あるいは、スライド単位の変換パラメータをサポートするサービス/APIを使用します。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができ、保存される PPT の[保護/暗号化設定](/slides/ja/net/password-protected-presentation/)も構成できます。