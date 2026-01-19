---
title: XPSへの変換
type: docs
weight: 40
url: /ja/net/conversion-to-xps/
---

**XPS** フォーマットはデータのやり取りでも広く使用されています。Aspose.Slides for .NET はその重要性に配慮し、プレゼンテーションを XPS ドキュメントに変換するための組み込みサポートを提供します。

Presentation クラスで提供される **Save** メソッドを使用して、プレゼンテーション全体を **XPS** ドキュメントに変換できます。さらに、**XpsOptions** クラスは **SaveMetafileAsPng** プロパティを公開しており、必要に応じて true または false に設定できます。

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)