---
title: プレゼンテーションのファイル形式を取得する
type: docs
weight: 50
url: /ja/net/get-the-file-format-of-presentation/
---

ファイル形式を取得するには、以下の手順に従ってください。

- **IPresentationInfo** クラスのインスタンスを作成する
- プレゼンテーションに関する情報を取得する

以下の例では、ファイル形式を取得しています。
## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Getting the format of a file.pptx";

IPresentationInfo info;

info = PresentationFactory.Instance.GetPresentationInfo(FileName);


switch (info.LoadFormat)

{

    case LoadFormat.Pptx:

        {

            break;

        }

    case LoadFormat.Unknown:

        {

            break;

        }

}

``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **実行例のダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Getting%20the%20format%20of%20a%20file)