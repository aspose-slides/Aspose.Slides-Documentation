---
title: スライドの組み立て
type: docs
weight: 10
url: /ja/net/assemble-slides/
---

## **プレゼンテーションにスライドを追加する**
プレゼンテーション ファイルにスライドを追加することについて説明する前に、スライドに関するいくつかの事実を確認しましょう。各 PowerPoint プレゼンテーション ファイルにはマスター/レイアウト スライドとその他の通常スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドがないプレゼンテーション ファイルは Aspose.Slides for .NET ではサポートされていないことを知っておくことが重要です。各スライドには固有の Id があり、すべての通常スライドはゼロベースのインデックスで指定された順序で配置されます。

Aspose.Slides for .NET は開発者がプレゼンテーションに空のスライドを追加できるようにします。空のスライドをプレゼンテーションに追加するには、以下の手順に従ってください。

- **Presentation** クラスのインスタンスを作成する
- Presentation オブジェクトが公開する Slides（コンテンツ スライド オブジェクトのコレクション）プロパティへの参照を設定して **SlideCollection** クラスをインスタンス化する
- **SlideCollection** オブジェクトが提供する **AddEmptySlide** メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加する
- 新しく追加された空のスライドで何らかの処理を行う
- 最後に、**Presentation** オブジェクトを使用してプレゼンテーション ファイルを書き出す

``` csharp
 PresentationEx pres = new PresentationEx();

 // SlideCollection クラスをインスタンス化する
 SlideExCollection slds = pres.Slides;

 for (int i = 0; i < pres.LayoutSlides.Count; i++)
 {
     // Slides コレクションに空のスライドを追加する
     slds.AddEmptySlide(pres.LayoutSlides[i]);
 }

 // PPTX ファイルをディスクに保存する
 pres.Write("EmptySlide.pptx");
``` 
## **プレゼンテーションのスライドにアクセスする**
Aspose.Slides for .NET は、プレゼンテーション内の任意のスライドを検索しアクセスできる **Presentation** クラスを提供します。

**スライド コレクションの使用**

**Presentation** クラスはプレゼンテーション ファイルを表し、すべてのスライドを **SlideCollection** コレクション（**Slide** オブジェクトのコレクション）として公開します。これらのスライドはスライド インデックスを使用して **Slides** コレクションからアクセスできます。

``` csharp
 // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
 PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

 // スライド インデックスを使用してスライドにアクセスする
 SlideEx slide = pres.Slides[0];
``` 
## **スライドの削除**
**Aspose.Slides for .NET** の **Presentation** クラスはプレゼンテーション ファイルを表すことは既にご存知かと思います。Presentation クラスは、プレゼンテーションの一部であるすべてのスライドを格納するリポジトリとして機能する **SlideCollection** をカプセル化します。開発者はこの Slides コレクションからスライドを次の 2 つの方法で削除できます。

- スライド参照を使用する
- スライド インデックスを使用する

**スライド参照の使用**

スライド参照を使用してスライドを削除するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- Id または Index を使用してスライドの参照を取得する
- 参照されたスライドをプレゼンテーションから削除する
- 変更されたプレゼンテーション ファイルを書き出す

``` csharp
 // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
 PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

 // スライド コレクション内のインデックスを使用してスライドにアクセスする
 SlideEx slide = pres.Slides[0];

 // 参照を使用してスライドを削除する
 pres.Slides.Remove(slide);

 // プレゼンテーション ファイルを書き出す
 pres.Write("modified.pptx");
``` 
## **スライドの位置を変更する**
プレゼンテーション内のスライドの位置を変更するのは非常に簡単です。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- Index を使用してスライドの参照を取得する
- 参照されたスライドの SlideNumber を変更する
- 変更されたプレゼンテーション ファイルを書き出す

以下の例では、プレゼンテーション内のスライド（ゼロインデックス位置 1 にあるもの）の位置をインデックス 1（位置 2）に変更しました。

``` csharp
 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)
{
    AddingSlidetoPresentation();
    AccessingSlidesOfPresentation();
    RemovingSlides();
    ChangingPositionOfSlide();
}

public static void AddingSlidetoPresentation()
{
    Presentation pres = new Presentation();

    // SlideCollection クラスをインスタンス化する
    ISlideCollection slds = pres.Slides;

    for (int i = 0; i < pres.LayoutSlides.Count; i++)
    {
        // Slides コレクションに空のスライドを追加する
        slds.AddEmptySlide(pres.LayoutSlides[i]);
    }

    // PPTX ファイルをディスクに保存する
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void AccessingSlidesOfPresentation()
{
    // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

    // スライド インデックスを使用してスライドにアクセスする
    ISlide slide = pres.Slides[0];
}

public static void RemovingSlides()
{
    // プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化する
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

    // スライド コレクション内のインデックスを使用してスライドにアクセスする
    ISlide slide = pres.Slides[0];

    // 参照を使用してスライドを削除する
    pres.Slides.Remove(slide);

    // プレゼンテーション ファイルを書き出す
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void ChangingPositionOfSlide()
{
    // ソース プレゼンテーション ファイルをロードするために Presentation クラスをインスタンス化する
    Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
    {
        // 位置を変更するスライドを取得する
        ISlide sld = pres.Slides[0];

        // スライドの新しい位置を設定する
        sld.SlideNumber = 2;

        // プレゼンテーションをディスクに保存する
        pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
    }
}
``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)