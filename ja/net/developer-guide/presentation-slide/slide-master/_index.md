---
title: ".NET でプレゼンテーション スライド マスターを管理"
linktitle: "スライド マスター"
type: docs
weight: 80
url: /ja/net/slide-master/
keywords:
- "スライド マスター"
- "マスタースライド"
- "PPT マスタースライド"
- "複数のマスタースライド"
- "マスタースライドの比較"
- "背景"
- "プレースホルダー"
- "マスタースライドのクローン"
- "マスタースライドのコピー"
- "マスタースライドの重複"
- "未使用のマスタースライド"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET でスライド マスターを管理: PPT、PPTX、ODP にレイアウト、テーマ、プレースホルダーを作成、編集、適用する簡潔な C# サンプルです。"
---

## **PowerPoint のスライド マスターとは**
**スライド マスター**は、PowerPoint の機能で、複数のスライドにわたってレイアウト、フォント、スタイルを制御します。プレゼンテーションの一貫性とブランド維持に役立ちます。会社向けに同じスタイルとテンプレートのプレゼンテーション（または一連のプレゼンテーション）を作成したい場合は、スライド マスターを使用できます。

スライド マスターは、すべてのプレゼンテーション スライドの外観を一度に設定・変更できるため便利です。Aspose.Slides は PowerPoint のスライド マスター機構をサポートしています。

VBA でもスライド マスターを操作し、PowerPoint がサポートする同様の操作（背景の変更、図形の追加、レイアウトのカスタマイズ等）を実行できます。Aspose.Slides はスライド マスターを使用して基本的なタスクを実行できる柔軟な機構を提供します。

これらは基本的なスライド マスター操作です:

- スライド マスターを作成または取得する。
- スライド マスターをプレゼンテーション スライドに適用する。
- スライド マスターの背景を変更する。
- 画像、プレースホルダー、SmartArt 等をスライド マスターに追加する。

これらはスライド マスターに関する高度な操作です:

- スライド マスターを比較する。
- スライド マスターをマージする。
- 複数のスライド マスターを適用する。
- スライド マスター付きスライドを別のプレゼンテーションにコピーする。
- プレゼンテーション内の重複スライド マスターを検索する。
- スライド マスターをプレゼンテーションのデフォルトビューとして設定する。

{{% alert color="primary" %}} 
ここで説明した主要プロセスのライブ実装である Aspose [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) を確認するとよいでしょう。
{{% /alert %}} 

## **スライド マスターはどのように適用されるか**
スライド マスターを操作する前に、プレゼンテーションでの使用方法とスライドへの適用方法を理解するとよいでしょう。

* すべてのプレゼンテーションはデフォルトで少なくとも1つのスライド マスターを持ちます。  
* プレゼンテーションは複数のスライド マスターを含めることができます。複数のスライド マスターを追加し、プレゼンテーションの異なる部分を異なる方法でスタイル設定できます。

**Aspose.Slides** では、スライド マスターは [**IMasterSlide**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) オブジェクトは、[**Masters**](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/masters) リスト（[**IMasterSlideCollection**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 型）を保持し、プレゼンテーションで定義されたすべてのマスタースライドの一覧が格納されています。

CRUD 操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) インターフェイスは次の便利なメソッドを提供します: [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/addclone) と [**InsertClone**](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/methods/insertclone)。これらのメソッドは基本的なスライド クローン機能から継承されていますが、スライド マスターを扱う場合は複雑な設定を実装するために利用できます。

プレゼンテーションに新しいスライドを追加すると、スライド マスターが自動的に適用されます。既定では直前のスライドのスライド マスターが選択されます。

**Note**: プレゼンテーション スライドは [Slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/slides) リストに格納され、デフォルトで新しいスライドはコレクションの末尾に追加されます。プレゼンテーションに単一のスライド マスターしかない場合、そのスライド マスターがすべての新しいスライドに適用されます。これが、各新規スライドでスライド マスターを個別に定義する必要がない理由です。

PowerPoint と Aspose.Slides の原理は同じです。たとえば PowerPoint では、最後のスライドの下のラインをクリックするだけで（最後のプレゼンテーションのスライド マスターを使用した）新しいスライドが作成されます:

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) クラスの [AddClone(ISlide)](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/methods/addclone) メソッドを使用して同等の操作を実行できます。

## **スライド階層におけるスライド マスター**
スライド レイアウトとスライド マスターを組み合わせて使用すると、最大の柔軟性が得られます。スライド レイアウトはスライド マスターと同じスタイル（背景、フォント、図形等）を設定できますが、複数のスライド レイアウトがスライド マスター上に組み合わさると新しいスタイルが生成されます。単一のスライドにスライド レイアウトを適用すると、スライド マスターが適用したスタイルとは別にそのスライドのスタイルを変更できます。

スライド マスターはすべての設定項目より上位です: Slide Master -> Slide Layout -> Slide:

![todo:image_alt_text](slide-master_2)

各 [IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) オブジェクトは、スライド レイアウトの一覧を保持する [**LayoutSlides**](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/layoutslides) プロパティを持ちます。 [Slide](https://reference.aspose.com/slides/net/aspose.slides/slide) 型は、スライド に適用されたスライド レイアウトへのリンクを保持する [**LayoutSlide**](https://reference.aspose.com/slides/net/aspose.slides/islide/properties/layoutslide) プロパティを持ちます。スライド とスライド マスターの相互作用はスライド レイアウトを介して行われます。

{{% alert color="info" title="Note" %}}
* Aspose.Slides では、すべてのスライド設定（Slide Master、Slide Layout、スライドそのもの）が実際には [**IBaseSlide**](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) インターフェイスを実装したスライド オブジェクトです。  
* したがって、Slide Master と Slide Layout は同じプロパティを実装する可能性があり、[Slide](https://reference.aspose.com/slides/net/aspose.slides/slide/) オブジェクトにどのように適用されるかを理解する必要があります。Slide Master がまずスライドに適用され、続いて Slide Layout が適用されます。たとえば、Slide Master と Slide Layout の両方に背景が設定されている場合、最終的なスライドは Slide Layout の背景を使用します。
{{% /alert %}}

## **スライド マスターに含まれるもの**
スライド マスターを変更する方法を理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) のコアプロパティです。

- [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/background) - スライドの背景を取得/設定します。  
- [BodyStyle](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/bodystyle) - スライド本体のテキストスタイルを取得/設定します。  
- [Shapes](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/shapes) - スライド マスター上のすべての図形（プレースホルダー、画像フレーム等）を取得/設定します。  
- [Controls](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/properties/controls) - ActiveX コントロールを取得/設定します。  
- [ThemeManager](https://reference.aspose.com/slides/net/aspose.slides.theme/imasterthemeable/properties/thememanager) - テーママネージャーを取得します。  
- [HeaderFooterManager](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/properties/headerfootermanager) - ヘッダーとフッターのマネージャーを取得します。

スライド マスターのメソッド:

- [GetDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/getdependingslides) - スライド マスターに依存しているすべてのスライドを取得します。  
- [ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/net/aspose.slides/imasterslide/methods/applyexternalthemetodependingslides) - 現在のスライド マスターと新しいテーマに基づいて新しいスライド マスターを作成し、依存するすべてのスライドに適用します。

## **スライド マスターの取得**
PowerPoint では、[View] → [Slide Master] メニューからスライド マスターにアクセスできます:

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides を使用すると、次のようにスライド マスターにアクセスできます:
```c#
IMasterSlide master = pres.Masters[0];
```


[IMasterSlide](https://reference.aspose.com/slides/net/aspose.slides/imasterslide) インターフェイスはスライド マスターを表します。 [Masters](https://reference.aspose.com/slides/net/aspose.slides/presentation/masters/) プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection) 型に関連）には、プレゼンテーションで定義されたすべてのスライド マスターのリストが含まれます。

## **スライド マスターに画像を追加する**
スライド マスターに画像を追加すると、その画像はそのマスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴやいくつかの画像をスライド マスターに配置し、スライド編集モードに戻すと、すべてのスライドで画像が表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides を使用してスライド マスターに画像を追加できます:
```c#
using (Presentation pres = new Presentation())
{
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    pres.Masters[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" title="See also" %}} 
スライドへの画像追加に関する詳細は、[Picture Frame](/slides/ja/net/picture-frame/#create-picture-frame) 記事をご参照ください。
{{% /alert %}}

## **スライド マスターにプレースホルダーを追加する**
これらのテキスト領域はスライド マスター上の標準プレースホルダーです:

* クリックしてマスタータイトルスタイルを編集
* マスターテキストスタイルを編集
* 第2レベル
* 第3レベル

これらはスライド マスターに基づくスライドでも表示されます。スライド マスター上でプレースホルダーを編集すると、変更は自動的にスライドに反映されます。

PowerPoint では、Slide Master → Insert Placeholder パスからプレースホルダーを追加できます:

![todo:image_alt_text](slide-master_5.png)

Aspose.Slides を使用したプレースホルダーのより複雑な例を見てみましょう。以下はスライド マスターからテンプレート化されたプレースホルダーを持つスライドの例です:

![todo:image_alt_text](slide-master_6.png)

次のようにスライド マスター上でタイトルとサブタイトルの書式を変更したいとします:

![todo:image_alt_text](slide-master_7.png)

まず、スライド マスター オブジェクトからタイトルプレースホルダーの内容を取得し、`PlaceHolder.FillFormat` フィールドを使用します:
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


タイトルのスタイルと書式は、スライド マスターに基づくすべてのスライドで変更されます:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/net/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/net/text-formatting/)
{{% /alert %}}

## **スライド マスターの背景を変更する**
マスタースライドの背景色を変更すると、プレゼンテーション内の通常スライドすべてが新しい色になります。この C# コードは操作例を示しています:
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


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/net/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/net/presentation-theme/)
{{% /alert %}}

## **スライド マスターを別のプレゼンテーションにクローンする**
スライド マスターを別のプレゼンテーションにクローンするには、宛先プレゼンテーションの [**AddClone**](https://reference.aspose.com/slides/net/aspose.slides.islidecollection/addclone/methods/2) メソッドを呼び出し、対象のスライド マスターを渡します。この C# コードはクローン方法を示しています:
```c#
using (Presentation presSource = new Presentation(), presTarget = new Presentation())
{
    IMasterSlide master = presTarget.Masters.AddClone(presSource.Masters[0]);
}
```


## **プレゼンテーションに複数のスライド マスターを追加する**
Aspose.Slides を使用すると、任意のプレゼンテーションに複数のスライド マスターとスライド レイアウトを追加できます。これにより、プレゼンテーション スライドのスタイル、レイアウト、書式設定オプションを多様に構成できます。

PowerPoint では、[Slide Master] メニューから新しいスライド マスターとレイアウトを追加できます:

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides を使用して、[AddClone](https://reference.aspose.com/slides/net/aspose.slides/imasterslidecollection/addclone/) メソッドを呼び出すことで新しいスライド マスターを追加できます:
```c#
pres.Masters.AddClone(pres.Masters[0]);
```


## **スライド マスターを比較する**
マスタースライドは [IBaseSlide](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide) インターフェイスを実装しており、[Equals](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/methods/equals) メソッドで比較できます。構造と静的コンテンツが同一のマスタースライドは `true` を返します。

形状、スタイル、テキスト、アニメーション、その他の設定が同等であればマスタースライドは等価とみなされます。比較では一意の識別子（例: SlideId）や動的コンテンツ（例: 日付プレースホルダーの現在の日付値）は考慮されません。

## **スライド マスターをプレゼンテーションのデフォルトビューとして設定する**
Aspose.Slides では、スライド マスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューはプレゼンテーションを開いたときに最初に表示されるビューです。

このコードは C# でスライド マスターをプレゼンテーションのデフォルトビューに設定する方法を示しています:
```c#
pres.ViewProperties.LastView = ViewType.SlideMasterView;
```


## **未使用のマスタースライドを削除する**
Aspose.Slides は、[Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) クラスの [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) メソッドを提供し、不要かつ未使用のマスタースライドを削除できます。この C# コードは PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**PowerPoint のスライド マスターとは何ですか？**  
スライド マスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライド テンプレートです。すべてのプレゼンテーション スライドの外観を一括で設定・変更できます。

**スライド マスターはプレゼンテーションでどのように適用されますか？**  
すべてのプレゼンテーションはデフォルトで少なくとも1つのスライド マスターを持ちます。新しいスライドが追加されると自動的にスライド マスターが適用され、通常は前のスライドのマスターが継承されます。プレゼンテーションは複数のスライド マスターを含めて、異なる部分を個別にスタイル設定できます。

**スライド マスターでカスタマイズできる要素は何ですか？**  
スライド マスターは以下のコアプロパティをカスタマイズできます:

- **Background**：スライドの背景を設定  
- **BodyStyle**：スライド本体のテキストスタイルを設定  
- **Shapes**：プレースホルダーや画像フレームなど、マスター上のすべての図形を管理  
- **Controls**：ActiveX コントロールを管理  
- **ThemeManager**：テーママネージャーにアクセス  
- **HeaderFooterManager**：ヘッダーとフッターを管理  

**スライド マスターに画像を追加するにはどうすればよいですか？**  
スライド マスターに画像を追加すると、その画像はマスターに依存するすべてのスライドに表示されます。たとえば、会社のロゴをスライド マスターに配置すれば、プレゼンテーション内のすべてのスライドにロゴが表示されます。

**スライド マスターとスライド レイアウトの関係は？**  
スライド レイアウトはスライド マスターと連携してスライド デザインの柔軟性を提供します。スライド マスターが全体的なスタイルとテーマを定義し、スライド レイアウトはコンテンツ配置のバリエーションを可能にします。階層は次の通りです:

- **Slide Master** → グローバルなスタイルを定義  
- **Slide Layout** → 異なるコンテンツ配置を提供  
- **Slide** → そのスライド レイアウトからデザインを継承  

**1 つのプレゼンテーションに複数のスライド マスターを持てますか？**  
はい、プレゼンテーションは複数のスライド マスターを含めることができ、セクションごとに異なるスタイルを設定してデザインの柔軟性を高められます。

**Aspose.Slides でスライド マスターにアクセスし、変更するには？**  
Aspose.Slides では、`IMasterSlide` インターフェイスがスライド マスターを表します。`Presentation` オブジェクトの `Masters` プロパティを使用してスライド マスターにアクセスできます。