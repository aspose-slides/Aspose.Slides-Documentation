---
title: プレゼンテーションのサイズとレイアウトの操作
type: docs
weight: 90
url: /net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** と **SlideSize.Size** は、以下の例に示すように設定または取得できるプレゼンテーションクラスのプロパティです。
## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//生成されたプレゼンテーションのスライドサイズをソースのものに設定します

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//プレゼンテーションをディスクに保存します

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **実行例のダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Working With Size and Layout/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

詳細については、[スライドサイズとレイアウトの操作](/slides/net/adding-and-editing-slides/#working-with-slide-size-and-layout)を参照してください。

{{% /alert %}}