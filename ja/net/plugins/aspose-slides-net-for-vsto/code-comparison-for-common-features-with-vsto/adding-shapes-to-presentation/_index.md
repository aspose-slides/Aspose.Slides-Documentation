---  
title: プレゼンテーションに図形を追加  
type: docs  
weight: 30  
url: /ja/net/adding-shapes-to-presentation/  
---  

## **VSTO**  
以下は、線形状を追加するためのコードスニペットです：

``` csharp  

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

```  
## **Aspose.Slides**  
プレゼンテーションの選択したスライドに単純な線を追加するには、以下の手順に従ってください：

- Presentationクラスのインスタンスを作成します
- インデックスを使用してスライドの参照を取得します
- Shapesオブジェクトによって公開されたAddAutoShapeメソッドを使用して、線型のAutoShapeを追加します
- 修正されたプレゼンテーションをPPTXファイルとして書き込みます

以下の例では、プレゼンテーションの最初のスライドに線を追加しました。

``` csharp  

   //PPTXを表すPresentationクラスをインスタンス化

  Presentation pres = new Presentation();

  //最初のスライドを取得

  ISlide slide = pres.Slides[0];

  //線型のオートシェイプを追加

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

```  
## **ダウンロード実行コード**  
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)  
## **サンプルコードのダウンロード**  
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)  
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)  