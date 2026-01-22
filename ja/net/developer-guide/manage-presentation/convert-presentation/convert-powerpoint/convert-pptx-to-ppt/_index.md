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
description: "Aspose.Slides for .NET を使用して PPTX を簡単に PPT に変換—PowerPoint 形式とのシームレスな互換性を確保し、プレゼンテーションのレイアウトと品質を維持します。"
---

## **概要**

この記事では、C# を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックが取り上げられています。

- C# で PPTX を PPT に変換する

## **.NET で PPTX を PPT に変換する**

以下のセクション、つまり[Convert PPTX to PPT](#convert-pptx-to-ppt)をご覧ください。サンプルコードは PPTX ファイルをロードし、PPT 形式で保存します。異なる保存形式を指定することで、PPTX ファイルを PDF、XPS、ODP、HTML など多くの形式にも保存できます。これらの記事で説明されています。

- [.NET で PPTX を PDF に変換](/slides/ja/net/convert-powerpoint-to-pdf/)
- [.NET で PPTX を XPS に変換](/slides/ja/net/convert-powerpoint-to-xps/)
- [.NET で PPTX を HTML に変換](/slides/ja/net/convert-powerpoint-to-html/)
- [.NET で PPTX を ODP に変換](/slides/ja/net/save-presentation/)
- [.NET で PPTX を PNG に変換](/slides/ja/net/convert-powerpoint-to-png/)

## **PPTX を PPT に変換する**
PPTX を PPT に変換するには、ファイル名と保存形式を[**Save**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)メソッドに、[**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスに渡すだけです。以下の C# コードサンプルは、デフォルトオプションを使用して PPTX から PPT にプレゼンテーションを変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化する
Presentation pres = new Presentation("presentation.pptx");

// PPTX プレゼンテーションを PPT 形式で保存する
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**PPT (97–2003) 形式に保存する際、すべての PPTX のエフェクトや機能は維持されますか？**

必ずしも維持されるわけではありません。PPT 形式は一部の新機能（特定のエフェクト、オブジェクト、動作など）に対応していないため、変換時に機能が簡素化されたりラスター化されたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換する場合は、対象スライドだけの新しいプレゼンテーションを作成して PPT として保存するか、スライド単位の変換パラメータに対応したサービス/API を使用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができ、保存された PPT に対しても[保護/暗号化設定を構成](/slides/ja/net/password-protected-presentation/)できます。