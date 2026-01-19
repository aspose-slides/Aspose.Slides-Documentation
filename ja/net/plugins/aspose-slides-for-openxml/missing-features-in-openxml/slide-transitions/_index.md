---
title: スライド遷移
type: docs
weight: 80
url: /ja/net/slide-transitions/
---

わかりやすくするために、Aspose.Slides for .NET を使用して簡単なスライド遷移を管理する方法を実演しました。開発者はスライドにさまざまな遷移効果を適用できるだけでなく、これらの遷移効果の動作をカスタマイズすることもできます。シンプルなスライド遷移効果を作成するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- **TransitionType** 列挙体を使用して、Aspose.Slides for .NET が提供する遷移効果のいずれかをスライドに適用する
- 変更したプレゼンテーション ファイルを書き込む

## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantiate Presentation class that represents a presentation file

using (Presentation pres = new Presentation(FileName))

{

    //Apply circle type transition on slide 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Apply comb type transition on slide 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Apply zoom type transition on slide 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Write the presentation to disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **実行サンプルのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
詳細については、[スライド遷移の管理](/slides/ja/net/slide-transition/)をご覧ください。
{{% /alert %}}