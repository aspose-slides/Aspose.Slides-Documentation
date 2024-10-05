---
title: C++でPPTXをPPTに変換する
linktitle: PPTXをPPTに変換する
type: docs
weight: 21
url: /cpp/convert-pptx-to-ppt/
keywords: "C++ PPTXをPPTに変換, PowerPointプレゼンテーションを変換, PPTXをPPT, Python, Aspose.Slides"
description: "C++でPowerPoint PPTXをPPTに変換する"
---

## **概要**

この記事では、PPTX形式のPowerPointプレゼンテーションをC++を使用してPPT形式に変換する方法を説明します。以下のトピックがカバーされています。

- C++でPPTXをPPTに変換する

## **C++でPPTXをPPTに変換する**

PPTXをPPTに変換するためのC++サンプルコードについては、以下のセクション、すなわち[Convert PPTX to PPT](#convert-pptx-to-ppt)を参照してください。これは、PPTXファイルを読み込み、PPT形式で保存するだけです。異なる保存形式を指定することで、PPTXファイルをPDF、XPS、ODP、HTMLなど、これらの記事で説明されているように他の多くの形式に保存することもできます。

- [C++でPPTXをPDFに変換する](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)
- [C++でPPTXをXPSに変換する](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)
- [C++でPPTXをHTMLに変換する](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)
- [C++でPPTXをODPに変換する](https://docs.aspose.com/slides/cpp/save-presentation/)
- [C++でPPTXを画像に変換する](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)

## **PPTXをPPTに変換する**
PPTXをPPTに変換するには、ファイル名と保存形式を[**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)クラスの**Save**メソッドに渡すだけです。以下のC++コードサンプルでは、デフォルトオプションを使用してPPTXからPPTにプレゼンテーションを変換します。

```cpp
// PPTXをロードします。
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");

// PPT形式で保存します。
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);
```