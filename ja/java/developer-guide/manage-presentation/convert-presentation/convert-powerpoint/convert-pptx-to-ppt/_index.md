---
title: PPTXをJavaでPPTに変換する
linktitle: PPTXをPPTに変換
type: docs
weight: 21
url: /ja/java/convert-pptx-to-ppt/
keywords: "Java PPTXをPPTに変換する, PowerPointプレゼンテーションの変換, PPTXからPPT, Java, Aspose.Slides"
description: "JavaでPowerPoint PPTXをPPTに変換する"
---

## **概要**

この記事では、PPTX形式のPowerPointプレゼンテーションをJavaを使用してPPT形式に変換する方法を説明します。以下のトピックが取り上げられています。

- JavaでPPTXをPPTに変換

## **JavaでPPTXをPPTに変換する**

PPTXをPPTに変換するためのJavaサンプルコードについては、以下のセクション[Convert PPTX to PPT](#convert-pptx-to-ppt)をご覧ください。これはPPTXファイルを読み込み、PPT形式で保存するだけです。異なる保存形式を指定することで、PPTXファイルをPDF、XPS、ODP、HTMLなどの多くの他の形式に保存することもできます。これらの記事で説明されています。

- [JavaでPPTXをPDFに変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-pdf/)
- [JavaでPPTXをXPSに変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-xps/)
- [JavaでPPTXをHTMLに変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-html/)
- [JavaでPPTXをODPに変換](https://docs.aspose.com/slides/java/save-presentation/)
- [JavaでPPTXを画像に変換](https://docs.aspose.com/slides/java/convert-powerpoint-to-png/)

## **PPTXをPPTに変換する**
PPTXをPPTに変換するには、**Presentation**クラスの**Save**メソッドにファイル名と保存形式を渡すだけです。以下のJavaコードサンプルは、デフォルトオプションを使用してPPTXからPPTにプレゼンテーションを変換します。

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化
Presentation presentation = new Presentation("template.pptx");

// プレゼンテーションをPPTとして保存
presentation.save("output.ppt", SaveFormat.Ppt);  
```