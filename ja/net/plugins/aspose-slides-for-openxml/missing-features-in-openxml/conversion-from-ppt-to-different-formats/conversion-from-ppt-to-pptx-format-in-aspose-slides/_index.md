---  
title: Aspose.Slidesを使用したPPTからPPTX形式への変換  
type: docs  
weight: 10  
url: /ja/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/  
---  

**Aspose.Slides** for .NETは、開発者がPresentationクラスのインスタンスを使用してPPTにアクセスし、それを対応するPPTX形式に変換できるようにします。現在、PPTからPPTXへの部分的な変換をサポートしています。PPTからPPTXへの変換でサポートされている機能とサポートされていない機能の詳細については、このドキュメントリンクに進んでください。

**Aspose.Slides** for .NETは、PPTXプレゼンテーションファイルを表すPresentationクラスを提供します。Presentationクラスは、オブジェクトがインスタンス化されると、PPTにもアクセスできるようになりました。

``` csharp

 //PPTXファイルを表すPresentationオブジェクトをインスタンス化する

PresentationEx pres = new PresentationEx("Conversion.ppt");

//PPTXプレゼンテーションをPPTX形式で保存する

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

```  
## **サンプルコードのダウンロード**  
- [Codeplex](http://goo.gl/LklO0x)  
- [Github](https://github.com/asposemarketplace/Aspose_for_OpenXML/releases/download/6/Conversion.PPT.to.PPTX.Aspose.Slides.zip)  
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)  