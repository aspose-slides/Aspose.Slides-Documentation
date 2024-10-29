---
title: スライドを組み立てる
type: docs
weight: 10
url: /ja/net/assemble-slides/
---

以下の機能をカバーしています：
## **プレゼンテーションにスライドを追加する**
プレゼンテーションファイルにスライドを追加する前に、スライドについてのいくつかの事実を考察しましょう。各PowerPointプレゼンテーションファイルには、マスター/レイアウトスライドとその他のノーマルスライドが含まれています。つまり、プレゼンテーションファイルには1つ以上のスライドが含まれています。スライドのないプレゼンテーションファイルはAspose.Slides for .NETにサポートされていないことを知っておくことが重要です。各スライドにはユニークなIDがあり、すべてのノーマルスライドはゼロベースのインデックスで指定された順序に配置されています。

Aspose.Slides for .NETでは、開発者がプレゼンテーションに空のスライドを追加することができます。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください：

- **Presentation**クラスのインスタンスを作成します。
- Presentationオブジェクトによって公開されるスライド（コンテンツスライドオブジェクトのコレクション）プロパティへの参照を設定して、**SlideCollection**クラスをインスタンス化します。
- **SlideCollection**オブジェクトによって公開される**AddEmptySlide**メソッドを呼び出して、コンテンツスライドコレクションの最後に空のスライドを追加します。
- 新しく追加した空のスライドに対して何らかの作業を行います。
- 最後に、**Presentation**オブジェクトを使用してプレゼンテーションファイルを書き込みます。

``` csharp

 PresentationEx pres = new PresentationEx();

//SlideCollectionクラスをインスタンス化

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Slidesコレクションに空のスライドを追加

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//PPTXファイルをディスクに保存する

pres.Write("EmptySlide.pptx");

``` 
## **プレゼンテーションのスライドにアクセスする**
Aspose.Slides for .NETは、プレゼンテーションに存在する任意のスライドを見つけてアクセスするために使用できるPresentationクラスを提供します。

**スライドコレクションを使用する**

**Presentation**クラスはプレゼンテーションファイルを表し、その中のすべてのスライドを**SlideCollection**コレクション（**Slide**オブジェクトのコレクション）として公開します。これらのすべてのスライドは、スライドインデックスを使用してこの**Slides**コレクションからアクセスできます。

``` csharp

 //プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//スライドインデックスを使用してスライドにアクセス

SlideEx slide = pres.Slides[0];

``` 
## **スライドの削除**
**Aspose.Slides for .NET**のPresentationクラスは、プレゼンテーションファイルを表します。Presentationクラスは、プレゼンテーションの一部であるすべてのスライドのリポジトリとして機能する**SlideCollection**をカプセル化しています。開発者は、このSlidesコレクションからスライドを2つの方法で削除できます：

- スライド参照を使用
- スライドインデックスを使用

**スライド参照を使用**

参照を使用してスライドを削除するには、以下の手順に従ってください：

- Presentationクラスのインスタンスを作成します。
- IDまたはインデックスを使用してスライドの参照を取得します。
- プレゼンテーションから参照されたスライドを削除します。
- 修正されたプレゼンテーションファイルを書き込みます。

``` csharp

 //プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//スライドコレクション内でインデックスを使用してスライドにアクセス

SlideEx slide = pres.Slides[0];

//参照を使用してスライドを削除

pres.Slides.Remove(slide);

//プレゼンテーションファイルを書き込む

pres.Write("modified.pptx");

``` 
## **スライドの位置を変更する：**
プレゼンテーション内のスライドの位置を変更するのは非常に簡単です。以下の手順に従ってください：

- Presentationクラスのインスタンスを作成します。
- インデックスを使用してスライドの参照を取得します。
- 参照されたスライドのSlideNumberを変更します。
- 修正されたプレゼンテーションファイルを書き込みます。

以下の例では、プレゼンテーションのスライド（ゼロインデックス位置1にあるスライド）の位置をインデックス1（位置2）に変更しました。

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

//SlideCollectionクラスをインスタンス化

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Slidesコレクションに空のスライドを追加

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//PPTXファイルをディスクに保存する

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//スライドインデックスを使用してスライドにアクセス

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//スライドコレクション内でインデックスを使用してスライドにアクセス

ISlide slide = pres.Slides[0];

//参照を使用してスライドを削除

pres.Slides.Remove(slide);

//プレゼンテーションファイルを書き込む

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//ソースプレゼンテーションファイルをロードするためにPresentationクラスをインスタンス化

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //位置を変更するスライドを取得

    ISlide sld = pres.Slides[0];

    //スライドの新しい位置を設定

    sld.SlideNumber = 2;

    //プレゼンテーションをディスクに書き込む

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **サンプルコードのダウンロード**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)