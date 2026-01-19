---
title: Aspose.Slides の PPT から PPTX 形式への変換
type: docs
weight: 10
url: /ja/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---

**Aspose.Slides** for .NET は、開発者が Presentation クラスのインスタンスを使用して PPT にアクセスし、対応する PPTX 形式に変換できるようにします。現在、PPT から PPTX への部分的な変換をサポートしています。PPT から PPTX への変換でサポートされている機能とサポートされていない機能の詳細については、こちらのドキュメントリンクをご参照ください。

**Aspose.Slides** for .NET は、PPTX プレゼンテーション ファイルを表す Presentation クラスを提供します。オブジェクトをインスタンス化したときに、Presentation クラスは PPT へのアクセスも可能になりました。

``` csharp

 //Instantiate a Presentation object that represents a PPTX file

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Saving the PPTX presentation to PPTX format

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **サンプルコードのダウンロード**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)