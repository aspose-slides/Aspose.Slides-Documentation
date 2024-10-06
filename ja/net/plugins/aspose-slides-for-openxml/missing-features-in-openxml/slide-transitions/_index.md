---
title: スライドトランジション
type: docs
weight: 80
url: /ja/net/slide-transitions/
---

理解を容易にするために、Aspose.Slides for .NETを使用して簡単なスライドトランジションを管理する方法を示しました。開発者はスライドに異なるスライドトランジション効果を適用するだけでなく、これらのトランジション効果の動作をカスタマイズすることもできます。簡単なスライドトランジション効果を作成するには、以下の手順に従ってください。

- Presentationクラスのインスタンスを作成する
- **TransitionType**列挙型を通じて、Aspose.Slides for .NETが提供するトランジション効果の1つからスライドにスライドトランジションタイプを適用する
- 修正されたプレゼンテーションファイルを書き出す。
## **例**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//プレゼンテーションファイルを表すPresentationクラスをインスタンス化する

using (Presentation pres = new Presentation(FileName))

{

    //スライド1に円型トランジションを適用する

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //スライド2にコンボ型トランジションを適用する

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //スライド3にズーム型トランジションを適用する

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //プレゼンテーションをディスクに書き出す

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **実行例のダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/Managing Slides Transitions/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

詳細については、[Managing Slides Transitions](/slides/ja/net/slide-transition/)をご覧ください。

{{% /alert %}}