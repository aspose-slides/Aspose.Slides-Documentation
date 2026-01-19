---
title: プレゼンテーションのサイズとレイアウトの操作
type: docs
weight: 90
url: /ja/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** と **SlideSize.Size** は、以下の例に示すように設定または取得できるプレゼンテーション クラスのプロパティです。
## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Instantiate a Presentation object that represents a presentation file 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Set the slide size of generated presentations to that of source

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Save Presentation to disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **サンプルコードをダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **実行サンプルをダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

詳細については、[Change the Presentation Slide Size in .NET](/slides/ja/net/slide-size/) をご覧ください。

{{% /alert %}}