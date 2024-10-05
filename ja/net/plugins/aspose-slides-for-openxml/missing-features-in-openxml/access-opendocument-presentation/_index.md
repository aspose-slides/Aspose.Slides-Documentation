---
title: OpenDocumentプレゼンテーションにアクセス
type: docs
weight: 10
url: /net/access-opendocument-presentation/
---

Aspose.Slides for .NETは、プレゼンテーションファイルを表す**Presentation**クラスを提供します。**Presentation**クラスは、オブジェクトがインスタンス化されるときに**Presentation**コンストラクターを通じて**ODP**にもアクセスできるようになりました。
## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化する

using (Presentation pres = new Presentation(srcFileName))

{

    //PPTX形式でPPTXプレゼンテーションを保存する

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **実行例のダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)