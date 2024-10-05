---
title: プレゼンテーションの印刷
type: docs
url: /net/print-the-presentation/
---

Aspose.Slides for .NETは、プレゼンテーションの印刷のための4つのオーバーロードメソッドを提供します。これらのメソッドは、デフォルトのプリンターやカスタマイズ設定のある任意の利用可能なプリンターに印刷するために十分に柔軟です。要件に応じて適切な印刷メソッドを選択するだけで済みます。
## **デフォルトプリンターへの印刷**
Aspose.Slides for .NETでプレゼンテーションをデフォルトプリンターに印刷するのは非常に簡単です。デフォルトプリンターにプレゼンテーションを印刷するためには、以下のステップを実行します：

- 印刷するプレゼンテーションをロードするためにPresentationクラスのインスタンスを作成します
- Presentationオブジェクトが公開しているパラメータなしのPrintメソッドを呼び出します

``` csharp

 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //プレゼンテーションをロードします

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //デフォルトプリンターにプレゼンテーション全体を印刷するために印刷メソッドを呼び出します

    asposePresentation.Print();

}

public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //プレゼンテーションをロードします

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //指定されたプリンターにプレゼンテーション全体を印刷するために印刷メソッドを呼び出します

    asposePresentation.Print("LaserJet1100");


``` 
## **特定のプリンターへの印刷**
特定のプリンターへのプレゼンテーションの印刷には、PresentationのPrintメソッドのパラメータとしてプリンターの名前が必要です。望むプリンターにプレゼンテーションを印刷するためには、以下のステップを実行します：

- 印刷するプレゼンテーションをロードするためにPresentationクラスのインスタンスを作成します
- Printメソッドへの文字列パラメータとしてプリンター名を使用してPresentationクラスのPrintメソッドを呼び出します

``` csharp

 public static void PrintBySpecificPrinter()

{

    string MyDir = @"..\..\..\Sample Files\";

    //プレゼンテーションをロードします

    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");

    //指定されたプリンターにプレゼンテーション全体を印刷するために印刷メソッドを呼び出します

    asposePresentation.Print("LaserJet1100");

}

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)