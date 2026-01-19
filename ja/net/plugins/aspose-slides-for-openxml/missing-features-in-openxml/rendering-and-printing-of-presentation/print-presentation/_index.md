---
title: プレゼンテーションの印刷
type: docs
url: /ja/net/print-the-presentation/
---

Aspose.Slides for .NET はプレゼンテーションの印刷用に 4 つのオーバーロード メソッドを提供します。これらのメソッドは、既定のプリンターまたはカスタマイズされた設定で利用可能な任意のプリンターへ印刷できる柔軟性があります。要件に応じて適切な印刷メソッドを選択するだけです。
## **既定のプリンターへ印刷**
プレゼンテーションを既定のプリンターに印刷するのは Aspose.Slides for .NET では非常に簡単です。既定のプリンターに印刷するには、次の手順を実行します。

- プレゼンテーションを読み込むために Presentation クラスのインスタンスを作成する
- Presentation オブジェクトが提供するパラメータなしの Print メソッドを呼び出す

``` csharp
 PrintByDefaultPrinter();

    PrintBySpecificPrinter();

}

public static void PrintByDefaultPrinter()
{
    string MyDir = @"..\..\..\Sample Files\";
    //プレゼンテーションをロード
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");
    //Print メソッドを呼び出して、プレゼンテーション全体を既定のプリンターに印刷
    asposePresentation.Print();
}

public static void PrintBySpecificPrinter()
{
    string MyDir = @"..\..\..\Sample Files\";
    //プレゼンテーションをロード
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");
    //Print メソッドを呼び出して、プレゼンテーション全体を目的のプリンターに印刷
    asposePresentation.Print("LaserJet1100");
}
``` 
## **特定のプリンターへ印刷**
特定のプリンターへ印刷するには、Print メソッドにプリンター名を文字列パラメータとして指定します。目的のプリンターに印刷するには、次の手順を実行します。

- プレゼンテーションを読み込むために Presentation クラスのインスタンスを作成する
- Presentation クラスの Print メソッドをプリンター名の文字列パラメータ付きで呼び出す

``` csharp
 public static void PrintBySpecificPrinter()
{
    string MyDir = @"..\..\..\Sample Files\";
    //プレゼンテーションをロード
    Presentation asposePresentation = new Presentation(MyDir + "Print.pptx");
    //Print メソッドを呼び出して、プレゼンテーション全体を目的のプリンターに印刷
    asposePresentation.Print("LaserJet1100");
}
``` 
## **サンプルコードのダウンロード**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Print%20Presentation%20%28Aspose.Slides%29.zip)