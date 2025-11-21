---
title: .NET で PPTX を PPT に変換
linktitle: PPTX から PPT
type: docs
weight: 21
url: /ja/net/convert-pptx-to-ppt/
keywords:
- PowerPoint の変換
- プレゼンテーションの変換
- スライドの変換
- PPTX の変換
- PPTX から PPT
- PPTX を PPT として保存
- PPTX を PPT にエクスポート
- PowerPoint
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET を使用して PPTX を PPT に簡単に変換し、PowerPoint 形式とのシームレスな互換性を確保しながら、プレゼンテーションのレイアウトと品質を維持します。"
---

## **概要**

この記事では、C# を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックを扱います。

- C#でPPTXをPPTに変換

## **C#でPPTXをPPTに変換**

C# のサンプルコードで PPTX を PPT に変換する方法については、以下のセクション [PPTXをPPTに変換](#convert-pptx-to-ppt) を参照してください。コードは PPTX ファイルを読み込み、PPT 形式で保存するだけです。保存形式を変更すれば、PDF、XPS、ODP、HTML などの他形式にも保存できます。これらの形式については、以下の記事をご覧ください。

- [C#でPPTXをPDFに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-pdf/)
- [C#でPPTXをXPSに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-xps/)
- [C#でPPTXをHTMLに変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-html/)
- [C#でPPTXをODPに変換](https://docs.aspose.com/slides/net/save-presentation/)
- [C#でPPTXを画像に変換](https://docs.aspose.com/slides/net/convert-powerpoint-to-png/)

## **PPTXをPPTに変換**
PPTX を PPT に変換するには、ファイル名と保存形式を [**保存**](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドに渡します。対象クラスは [**Presentation**](https://reference.aspose.com/slides/net/aspose.slides/presentation/) です。以下の C# コードサンプルは、デフォルトオプションで PPTX から PPT に変換します。
```c#
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化します
Presentation pres = new Presentation("presentation.pptx");

// PPTX プレゼンテーションを PPT 形式で保存します
pres.Save("presentation.ppt", SaveFormat.Ppt);
```


## **FAQ**

**すべての PPTX のエフェクトや機能は、レガシー PPT（97–2003）形式に保存したときに保持されますか？**

必ずしも保持されません。PPT 形式は新しい機能（特定のエフェクト、オブジェクト、動作など）をサポートしていないため、変換時に簡略化されたりラスタライズされたりすることがあります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換したい場合は、対象スライドだけで新しいプレゼンテーションを作成し、PPT として保存します。または、スライド単位の変換パラメータをサポートするサービスや API を利用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているか検出し、パスワードを指定して開くことができます。また、保存する PPT の [保護/暗号化設定を構成](/slides/ja/net/password-protected-presentation/) することも可能です。