---
title: スライドの組み立て
type: docs
weight: 10
url: /ja/net/assemble-slides/
---

## **プレゼンテーションにスライドを追加する**
スライドをプレゼンテーション ファイルに追加する話をする前に、スライドに関するいくつかの事実を説明します。各 PowerPoint プレゼンテーション ファイルにはマスタ / レイアウト スライドと他の通常スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドのないプレゼンテーション ファイルは Aspose.Slides for .NET ではサポートされていないことに注意してください。各スライドには固有の Id があり、すべての通常スライドは 0 ベースのインデックスで指定された順序で配置されます。

Aspose.Slides for .NET は、開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- **Presentation** クラスのインスタンスを作成する
- **SlideCollection** クラスをインスタンス化し、Presentation オブジェクトが公開する Slides（コンテンツ スライド オブジェクトのコレクション）プロパティへの参照を設定する。
- **SlideCollection** オブジェクトが公開する **AddEmptySlide** メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加する。
- 新しく追加された空のスライドで何らかの処理を行う
- 最後に、**Presentation** オブジェクトを使用してプレゼンテーション ファイルを書き出す

``` csharp

 PresentationEx pres = new PresentationEx();

//Instantiate SlideCollection class

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Add an empty slide to the Slides collection

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Write("EmptySlide.pptx");

``` 
## **プレゼンテーションのスライドにアクセスする**
Aspose.Slides for .NET は、プレゼンテーション内の任意の目的のスライドを検索およびアクセスするために使用できる Presentation クラスを提供します。

**スライド コレクションの使用**

**Presentation** クラスはプレゼンテーション ファイルを表し、すべてのスライドを **SlideCollection** コレクション（**Slide** オブジェクトのコレクション）として公開します。これらすべてのスライドは、スライド インデックスを使用してこの **Slides** コレクションからアクセスできます。

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its slide index

SlideEx slide = pres.Slides[0];

``` 
## **スライドの削除**
**Aspose.Slides for .NET** の **Presentation** クラスがプレゼンテーション ファイルを表すことは既にご存知でしょう。Presentation クラスは、プレゼンテーションの一部であるすべてのスライドのリポジトリとして機能する **SlideCollection** をカプセル化しています。開発者はこの Slides コレクションからスライドを削除する方法として、次の 2 つがあります：

- スライド参照を使用する
- スライドインデックスを使用する

**スライド参照の使用**

スライド参照を使用してスライドを削除するには、以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- Id または Index を使用してスライドの参照を取得する
- 参照されたスライドをプレゼンテーションから削除する
- 変更されたプレゼンテーション ファイルを書き出す

``` csharp

 //Instantiate a Presentation object that represents a presentation file

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Accessing a slide using its index in the slides collection

SlideEx slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Write("modified.pptx");

``` 
## **スライドの位置を変更する**
プレゼンテーション内のスライドの位置を変更するのは非常に簡単です。以下の手順に従ってください。

- Presentation クラスのインスタンスを作成する
- Index を使用してスライドの参照を取得する
- 参照されたスライドの SlideNumber を変更する
- 変更されたプレゼンテーション ファイルを書き出す

以下の例では、プレゼンテーション内のスライド（ゼロインデックスの位置 1 にある） の位置をインデックス 1（位置 2）に変更しました。

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

//Instantiate SlideCollection class

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Add an empty slide to the Slides collection

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Save the PPTX file to the Disk

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its slide index

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Accessing a slide using its index in the slides collection

ISlide slide = pres.Slides[0];

//Removing a slide using its reference

pres.Slides.Remove(slide);

//Writing the presentation file

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instantiate Presentation class to load the source presentation file

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Get the slide whose position is to be changed

    ISlide sld = pres.Slides[0];

    //Set the new position for the slide

    sld.SlideNumber = 2;

    //Write the presentation to disk

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **サンプルコードのダウンロード**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)