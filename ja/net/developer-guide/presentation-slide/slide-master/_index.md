---
title: スライドマスター
type: docs
weight: 80
url: /net/slide-master/
keywords: "スライドマスターの追加, PPT マスタースライド, スライドマスターパワーポイント, スライドマスターへの画像, プレースホルダー, 複数のスライドマスター, スライドマスターの比較, C#, Csharp, .NET, Aspose.Slides"
description: "C# または .NET で PowerPoint プレゼンテーションのスライドマスターを追加または編集します"
---


## **PowerPoint におけるスライドマスターとは**
**スライドマスター**は、プレゼンテーションのスライドのレイアウト、スタイル、テーマ、フォント、背景、およびその他のプロパティを定義するスライドテンプレートです。同じスタイルとテンプレートで会社のプレゼンテーション（または一連のプレゼンテーション）を作成したい場合は、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの外観を一度に設定および変更できるため便利です。Aspose.Slidesは、PowerPoint のスライドマスター機構をサポートしています。

VBAを使用すると、スライドマスターを操作し、PowerPoint でサポートされているのと同じ操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slidesは、スライドマスターを使用し、基本的なタスクを実行するための柔軟なメカニズムを提供します。

これらは基本的なスライドマスター操作です：

- スライドマスターの作成または追加。
- プレゼンテーションスライドにスライドマスターを適用。
- スライドマスターの背景を変更。
- スライドマスターに画像、プレースホルダー、スマートアートなどを追加。

これらはスライドマスターに関連するより高度な操作です：

- スライドマスターの比較。
- スライドマスターのマージ。
- 複数のスライドマスターの適用。
- スライドをスライドマスター付きで別のプレゼンテーションにコピー。
- プレゼンテーション内の重複するスライドマスターを見つける。
- スライドマスターをプレゼンテーションのデフォルトビューとして設定。

{{% alert color="primary" %}} 

Asposeの[**オンラインPowerPointビューワー**](https://products.aspose.app/slides/viewer)を確認してみてください。ここで説明したコアプロセスの一部をライブで実装しています。

{{% /alert %}} 


## **スライドマスターの適用方法**
スライドマスターで作業する前に、プレゼンテーションでどのように使用され、スライドに適用されるのかを理解しておくと良いでしょう。

* すべてのプレゼンテーションには、デフォルトで少なくとも1つのスライドマスターがあります。
* プレゼンテーションには複数のスライドマスターが含まれることがあります。複数のスライドマスターを追加して、プレゼンテーションの異なる部分を異なる方法でスタイル設定することができます。

**Aspose.Slides**では、スライドマスターは[**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide)型で表されます。

Aspose.Slidesの[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)オブジェクトには、プレゼンテーション内で定義されたすべてのマスタースライドのリストを含む[**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters)のリストが含まれる[**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)型があります。

CRUD操作の他に、[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)インターフェイスには、次の便利なメソッドが含まれています：[**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone)および[**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone)メソッドです。これらのメソッドは、基本的なスライドのクローン機能から継承されたものです。ただし、スライドマスターを扱う際に、これらのメソッドを使用することで複雑な設定を実装できます。

新しいスライドがプレゼンテーションに追加されると、スライドマスターが自動的に適用されます。前のスライドのスライドマスターがデフォルトで選択されます。

**注**：プレゼンテーションスライドは[Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides)リストに保存され、デフォルトでは各新しいスライドはコレクションの最後に追加されます。プレゼンテーションに1つのスライドマスターが含まれている場合、そのスライドマスターがすべての新しいスライドに選択されます。これが、新しいスライドを作成するたびにスライドマスターを定義する必要がない理由です。

原則はPowerPointとAspose.Slidesで同じです。たとえば、PowerPointでは、新しいプレゼンテーションを追加するときに、最後のスライドの下の下線をクリックするだけで新しいスライド（最後のプレゼンテーションのスライドマスター付き）が作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slidesでは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスの下で[AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone)メソッドを使用して同等のタスクを実行できます。


## **スライド階層におけるスライドマスター**
スライドマスターを使用すると、スライドレイアウトの最大限の柔軟性を得ることができます。スライドレイアウトは、スライドマスターと同じスタイル（背景、フォント、図形など）をすべて設定できます。ただし、複数のスライドレイアウトがスライドマスター上で組み合わされると、新しいスタイルが作成されます。スライドレイアウトを単一のスライドに適用すると、スライドマスターによって適用されたスタイルから変更することができます。

スライドマスターは、すべての設定項目に優先されます：スライドマスター -> スライドレイアウト -> スライド：

![todo:image_alt_text](slide-master_2)

各[IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide)オブジェクトには、スライドレイアウトのリストを持つ[**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides)プロパティがあります。[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide)型には、スライドに適用されたスライドレイアウトへのリンクを持つ[**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide)プロパティがあります。スライドとスライドマスター間の相互作用は、スライドレイアウトを介して行われます。

{{% alert color="info" title="注" %}}

* 
   Aspose.Slidesでは、すべてのスライド設定（スライドマスター、スライドレイアウト、およびスライド自体）は、実際には[**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)インターフェイスを実装するスライドオブジェクトです。
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装する場合があり、その値がどのように[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/)オブジェクトに適用されるかを知っておく必要があります。スライドには最初にスライドマスターが適用され、その後スライドレイアウトが適用されます。たとえば、スライドマスターとスライドレイアウトの両方が背景値を持っている場合、スライドはスライドレイアウトの背景を持つことになります。

{{% /alert %}}


## **スライドマスターの構成要素**
スライドマスターを変更する方法を理解するには、その構成要素を知っておく必要があります。これらは[MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/)のコアプロパティです。

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - スライドの背景を取得/設定します。
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - スライドの本文のスタイルを取得/設定します。
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - スライドマスターのすべての図形（プレースホルダー、画像フレームなど）を取得/設定します。
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - ActiveX コントロールを取得/設定します。
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - テーママネージャーを取得します。
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - ヘッダーおよびフッターマネージャーを取得します。

スライドマスターのメソッド：

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - スライドマスターに依存するすべてのスライドを取得します。
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - 現在のスライドマスターと新しいテーマに基づいて新しいスライドマスターを作成することを可能にします。新しいスライドマスターは、すべての依存スライドに適用されます。


## **スライドマスターの取得**
PowerPointでは、スライドマスターにアクセスするには、[表示] -> [スライドマスター]メニューからアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slidesを使用して、次のようにスライドマスターにアクセスできます：

```c#
IMasterSlide master = pres.Masters[0];
```

[IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide)インターフェイスはスライドマスターを表します。[Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/)プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection)型に関連）には、プレゼンテーション内で定義されたすべてのスライドマスターのリストが含まれています。 


## **スライドマスターに画像を追加**
スライドマスターに画像を追加すると、その画像はそのスライドマスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴといくつかの画像をスライドマスターに配置し、その後スライド編集モードに戻ります。すべてのスライドに画像が表示されるはずです。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slidesを使用して、スライドマスターに画像を追加できます：

```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="関連資料" %}} 

スライドに画像を追加する詳細については、[画像フレーム](/slides/net/picture-frame/#create-picture-frame)の記事をご覧ください。
{{% /alert %}}


## **スライドマスターにプレースホルダーを追加**
これらのテキストフィールドは、スライドマスターの標準プレースホルダーです：

* マスターのタイトルスタイルの編集をクリック

* マスターのテキストスタイルの編集

* 第二レベル

* 第三レベル 

これらはスライドマスターに基づいたスライドにも表示されます。スライドマスターでこれらのプレースホルダーを編集すると、変更が自動的にスライドに適用されます。

PowerPointでは、[スライドマスター] -> [プレースホルダーの挿入]のパスを介してプレースホルダーを追加できます：



![todo:image_alt_text](slide-master_5.png)



Aspose.Slidesを使用して、スライドマスターからテンプレート化されたプレースホルダーを持つスライドのより複雑な例を考えてみましょう：



![todo:image_alt_text](slide-master_6.png)



スライドマスターでタイトルとサブタイトルの書式を次のように変更したいとします：

![todo:image_alt_text](slide-master_7.png)



まず、スライドマスターオブジェクトからタイトルプレースホルダーの内容を取得し、次に`PlaceHolder.FillFormat`フィールドを使用します： 

```c#
public static void Main()
{
    using (var pres = new Presentation())
    {
        IMasterSlide master = pres.Masters[0];
        IAutoShape placeHolder = FindPlaceholder(master, PlaceholderType.Title);
        placeHolder.FillFormat.FillType = FillType.Gradient;
        placeHolder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(0, Color.FromArgb(255, 0, 0));
        placeHolder.FillFormat.GradientFormat.GradientStops.Add(255, Color.FromArgb(128, 0, 128));
        
        pres.Save("pres.pptx", SaveFormat.Pptx);
    }
}

static IAutoShape FindPlaceholder(IMasterSlide master, PlaceholderType type)
{
    foreach (IShape shape in master.Shapes)
    {
        IAutoShape autoShape = shape as IAutoShape;
        if (autoShape != null)
        {
            if (autoShape.Placeholder.Type == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```

スライドマスターに基づくすべてのスライドのタイトルスタイルと書式が変更されます：



![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="関連資料" %}} 

* [プレースホルダーにプロンプトテキストを設定](https://docs.aspose.com/slides/net/manage-placeholder/)
* [テキストの書式設定](https://docs.aspose.com/slides/net/text-formatting/)

{{% /alert %}}


## **スライドマスターの背景を変更する**
マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。このC#コードは、その操作を示しています：

```c#
using (var pres = new Presentation())
{
    IMasterSlide master = pres.Masters[0];
    master.Background.Type = BackgroundType.OwnBackground;
    master.Background.FillFormat.FillType = FillType.Solid;
    master.Background.FillFormat.SolidFillColor.Color = Color.Green;
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

{{% alert color="primary" title="関連資料" %}} 
- [プレゼンテーションの背景](https://docs.aspose.com/slides/net/presentation-background/)

- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/net/presentation-theme/)

  {{% /alert %}}

## **スライドマスターを別のプレゼンテーションにクローン**
スライドマスターを別のプレゼンテーションにクローンするには、目的のプレゼンテーションから[**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2)メソッドを呼び出し、そこにスライドマスターを渡します。このC#コードは、スライドマスターを別のプレゼンテーションにクローンする方法を示しています：

```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **プレゼンテーションに複数のスライドマスターを追加**
Aspose.Slidesでは、任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できます。これにより、プレゼンテーションスライドに対してスタイル、レイアウト、書式設定オプションを多様に設定できます。

PowerPointでは、次のように「スライドマスターメニュー」から新しいスライドマスターとレイアウトを追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slidesを使用すると、次のように[AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/)メソッドを呼び出して新しいスライドマスターを追加できます：

```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **スライドマスターを比較**
マスタースライドは、[IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide)インターフェイスを実装しており、[Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals)メソッドを含んでいます。これにより、スライドを比較することができます。これは、構造と静的コンテンツが同一のマスタースライドに対して`true`を返します。

二つのマスタースライドが等しいのは、その形状、スタイル、テキスト、アニメーション、およびその他の設定が等しい場合です。比較は、ユニークな識別子の値（例：SlideId）や動的コンテンツ（例：日付プレースホルダーの現在の日付の値）を考慮に入れません。 


## **スライドマスターをプレゼンテーションのデフォルトビューに設定**
Aspose.Slidesでは、スライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるものです。

このコードは、C#でスライドマスターをプレゼンテーションのデフォルトビューとして設定する方法を示しています：

```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```

## **未使用のマスタースライドを削除**
Aspose.Slidesは、不要で未使用のマスタースライドを削除するために[RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/)メソッド（[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/)クラスから）を提供します。このC#コードは、PowerPointプレゼンテーションからマスタースライドを削除する方法を示しています：

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```