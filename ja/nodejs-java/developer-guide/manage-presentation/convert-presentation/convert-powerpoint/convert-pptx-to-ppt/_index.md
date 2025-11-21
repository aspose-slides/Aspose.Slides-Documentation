---
title: JavaScript で PPTX を PPT に変換
linktitle: PPTX を PPT に変換
type: docs
weight: 21
url: /ja/nodejs-java/convert-pptx-to-ppt/
keywords: "Java PPTX を PPT に変換, PowerPoint プレゼンテーションの変換, PPTX から PPT, Java, Aspose.Slides"
description: "JavaScript で PowerPoint PPTX を PPT に変換"
---

## **概要**

この記事では、JavaScript を使用して PPTX 形式の PowerPoint プレゼンテーションを PPT 形式に変換する方法を説明します。以下のトピックがカバーされています。

- JavaScript で PPTX を PPT に変換

## **JavaScript で PPTX を PPT に変換**

PPTX を PPT に変換する JavaScript のサンプルコードについては、以下のセクション [Convert PPTX to PPT](#convert-pptx-to-ppt) を参照してください。これは PPTX ファイルを読み込み、PPT 形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTML などの多くの形式でも PPTX ファイルを保存できます。これらの記事で説明されています。

- [Java で PPTX を PDF に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-pdf/)
- [Java で PPTX を XPS に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-xps/)
- [Java で PPTX を HTML に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-html/)
- [Java で PPTX を ODP に変換](https://docs.aspose.com/slides/nodejs-java/save-presentation/)
- [Java で PPTX を Image に変換](https://docs.aspose.com/slides/nodejs-java/convert-powerpoint-to-png/)

## **PPTX を PPT に変換**

PPTX を PPT に変換するには、ファイル名と保存形式を **Save** メソッドに渡すだけです。**Presentation** クラス ([**Presentation**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)) を使用します。以下の JavaScript コードサンプルは、デフォルトオプションで PPTX から PPT にプレゼンテーションを変換します。
```javascript
// PPTX ファイルを表す Presentation オブジェクトをインスタンス化
var presentation = new aspose.slides.Presentation("template.pptx");
// プレゼンテーションを PPT として保存
presentation.save("output.ppt", aspose.slides.SaveFormat.Ppt);
```


## **FAQ**

**PPTX のすべての効果と機能は、レガシー PPT（97–2003）形式で保存するときに維持されますか？**

必ずしもそうではありません。PPT 形式には newer capabilities (例: 特定の効果、オブジェクト、挙動) が欠けているため、変換時に機能が簡略化されたりラスタライズされたりする可能性があります。

**プレゼンテーション全体ではなく、選択したスライドだけを PPT に変換できますか？**

直接保存はプレゼンテーション全体を対象とします。特定のスライドだけを変換するには、そのスライドだけで構成された新しいプレゼンテーションを作成し、PPT として保存します。あるいは、スライド単位の変換パラメータをサポートするサービス/APIを使用してください。

**パスワードで保護されたプレゼンテーションはサポートされていますか？**

はい。ファイルが保護されているかを検出し、パスワードで開くことができます。また、保存された PPT のために [configure protection/encryption settings](/slides/ja/nodejs-java/password-protected-presentation/) を設定することも可能です。