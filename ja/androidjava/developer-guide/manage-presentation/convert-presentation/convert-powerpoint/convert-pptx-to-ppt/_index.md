---
title: JavaでPPTXをPPTに変換する
linktitle: PPTXをPPTに変換する
type: docs
weight: 21
url: /ja/androidjava/convert-pptx-to-ppt/
keywords: "Java PPTXをPPTに変換, PowerPointプレゼンテーションを変換, PPTXをPPT, Java, Aspose.Slides"
description: "JavaでPowerPoint PPTXをPPTに変換する"
---

## **概要**

この記事では、PPTX形式のPowerPointプレゼンテーションをJavaを使用してPPT形式に変換する方法について説明します。以下のトピックがカバーされています。

- JavaでPPTXをPPTに変換する

## **JavaでPPTXをPPTに変換する**

PPTXをPPTに変換するためのJavaサンプルコードについては、以下のセクション、すなわち[Convert PPTX to PPT](#convert-pptx-to-ppt)を参照してください。これはPPTXファイルを読み込み、PPT形式で保存するだけです。異なる保存形式を指定することで、PDF、XPS、ODP、HTMLなど、他の多くの形式にPPTXファイルを保存することもできます。

- [JavaでPPTXをPDFに変換する](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-pdf/)
- [JavaでPPTXをXPSに変換する](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-xps/)
- [JavaでPPTXをHTMLに変換する](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-html/)
- [JavaでPPTXをODPに変換する](https://docs.aspose.com/slides/androidjava/save-presentation/)
- [JavaでPPTXを画像に変換する](https://docs.aspose.com/slides/androidjava/convert-powerpoint-to-png/)

## **PPTXをPPTに変換する**
PPTXをPPTに変換するには、ファイル名と保存形式を[**Presentation**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation)クラスの**Save**メソッドに渡します。以下のJavaコードサンプルは、デフォルトのオプションを使用してPPTXからPPTにプレゼンテーションを変換します。

```java
// PPTXファイルを表すPresentationオブジェクトをインスタンス化する
Presentation presentation = new Presentation("template.pptx");

// プレゼンテーションをPPTとして保存する
presentation.save("output.ppt", SaveFormat.Ppt);  
```