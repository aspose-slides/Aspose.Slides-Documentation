---
title: プレゼンテーションの印刷
type: docs
url: /ja/net/print-the-presentation/
---

Aspose.Slides for .NET は、プレゼンテーションの印刷に 4 つのオーバーロード メソッドを提供します。これらのメソッドは柔軟で、デフォルトのプリンターまたは利用可能な任意のプリンターにカスタマイズ設定で印刷できます。要件に応じて適切な印刷メソッドを選択してください。

## **デフォルトプリンターへの印刷**
Aspose.Slides for .NET でプレゼンテーションをデフォルトプリンターに印刷するのは非常に簡単です。次の手順でデフォルトプリンターに印刷します。

- 印刷するプレゼンテーションを読み込むために Presentation クラスのインスタンスを作成する
- Presentation オブジェクトが公開するパラメーターなしの Print メソッドを呼び出す

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the default printer

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");


``` 
## **特定のプリンターへの印刷**
特定のプリンターに印刷するには、Print メソッドにプリンター名を文字列パラメーターとして渡します。次の手順で目的のプリンターに印刷します。

- 印刷するプレゼンテーションを読み込むために Presentation クラスのインスタンスを作成する
- Presentation クラスの Print メソッドにプリンター名を文字列パラメーターとして渡して呼び出す

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //Load the presentation

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //Call the print method to print whole presentation to the desired printer

    asposePresentation.Print("LaserJet1100");

}

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)