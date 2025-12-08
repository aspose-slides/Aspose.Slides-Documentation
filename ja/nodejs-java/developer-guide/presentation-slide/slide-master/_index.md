---
title: スライド マスター
type: docs
weight: 70
url: /ja/nodejs-java/slide-master/
keywords: "スライド マスターの追加, PPT マスタースライド, PowerPoint のスライド マスター, スライド マスターへの画像, プレースホルダー, 複数のスライド マスター, スライド マスターの比較, Java, Java を介した Node.js 用 Aspose.Slides"
description: "JavaScript で PowerPoint プレゼンテーションのスライド マスターを追加または編集"
---

## **PowerPoint のスライド マスターとは**

**スライド マスター** は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライド テンプレートです。会社向けに同じスタイルとテンプレートのプレゼンテーション（または複数のプレゼンテーション）を作成したい場合は、スライド マスターを使用できます。

スライド マスターは、すべてのスライドの外観を一括で設定・変更できるため便利です。Aspose.Slides は PowerPoint のスライド マスター機構をサポートしています。

VBA でもスライド マスターを操作でき、PowerPoint でサポートされている背景変更、図形追加、レイアウトカスタマイズなどの操作を実行できます。Aspose.Slides は柔軟な機構を提供し、スライド マスターの使用と基本的なタスクの実行を可能にします。

以下は基本的なスライド マスター操作です。

- スライド マスターの作成または取得。
- プレゼンテーション スライドへのスライド マスターの適用。
- スライド マスターの背景変更。 
- スライド マスターへの画像、プレースホルダー、SmartArt などの追加。

以下はスライド マスターに関する高度な操作です。

- スライド マスターの比較。
- スライド マスターのマージ。
- 複数のスライド マスターの適用。
- スライド マスター付きスライドを別のプレゼンテーションにコピー。
- プレゼンテーション内の重複スライド マスターの検出。
- スライド マスターをプレゼンテーションのデフォルト ビューに設定。

{{% alert color="primary" %}} 
Aspose の [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) を確認すると、ここで説明した主要プロセスのライブ実装を見ることができます。 
{{% /alert %}} 


## **スライド マスターの適用方法**

スライド マスターを操作する前に、プレゼンテーションでの使用方法とスライドへの適用方法を理解しておくとよいでしょう。

* すべてのプレゼンテーションにはデフォルトで少なくとも 1 つのスライド マスターが存在します。 
* プレゼンテーションは複数のスライド マスターを含めることができ、異なる部分に異なるスタイルを適用できます。 

**Aspose.Slides** では、スライド マスターは [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) オブジェクトは、[**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) リストとして [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 型を保持し、プレゼンテーション内で定義されたすべてのマスター スライドの一覧を提供します。

CRUD 操作に加えて、[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) クラスは次の便利なメソッドを提供します: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) と [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-)。これらは基本的なスライド クローン機能から継承されていますが、スライド マスターに対して使用すると複雑な設定を実装できます。

新しいスライドがプレゼンテーションに追加されると、スライド マスターが自動的に適用されます。既定では前のスライドのスライド マスターが選択されます。

**注**: プレゼンテーション スライドは [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--) リストに格納され、新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションに単一のスライド マスターしかない場合、そのスライド マスターがすべての新規スライドに適用されます。このため、各新規スライドでスライド マスターを個別に定義する必要はありません。

PowerPoint と Aspose.Slides での原理は同じです。たとえば PowerPoint では、最後のスライドの下の行をクリックすると、前のスライドと同じスライド マスターを持つ新しいスライドが作成されます。

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) クラスの [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) メソッドを使用して同等の操作を実行できます。


## **スライド マスターの階層構造**

スライド レイアウトとスライド マスターを組み合わせることで、最大限の柔軟性が得られます。スライド レイアウトはスライド マスターと同じスタイル（背景、フォント、図形など）を設定できますが、複数のスライド レイアウトがスライド マスター上に組み合わさると新しいスタイルが生成されます。スライド レイアウトを単一のスライドに適用すると、スライド マスターが適用したスタイルから変更できます。

スライド マスターはすべての設定項目の上位にあります: スライド マスター → スライド レイアウト → スライド:

![todo:image_alt_text](slide-master_2)

各 [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) オブジェクトは、スライド レイアウトの一覧を保持する [**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) プロパティを持ちます。 [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 型は、スライドに適用されたスライド レイアウトへのリンクを保持する [**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) プロパティを持ちます。スライドとスライド マスターの相互作用はスライド レイアウトを介して行われます。

{{% alert color="info" title="Note" %}}
* Aspose.Slides では、すべてのスライド設定（スライド マスター、スライド レイアウト、スライド 本体）は実際には [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) クラスを実装するスライド オブジェクトです。  
* したがって、スライド マスターとスライド レイアウトは同じプロパティを実装しており、[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) オブジェクトにどのように適用されるかを理解する必要があります。スライド マスターが最初に適用され、次にスライド レイアウトが適用されます。たとえば、スライド マスターとスライド レイアウトの両方に背景が設定されている場合、最終的なスライドはスライド レイアウトの背景を使用します。 
{{% /alert %}}


## **スライド マスターの構成要素**

スライド マスターを変更する方法を理解するには、構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) のコア プロパティです。

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) : スライド背景の取得/設定。  
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) : スライド本文のテキストスタイルの取得/設定。  
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) : スライド マスター上のすべての図形（プレースホルダー、画像枠など）の取得/設定。  
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) : ActiveX コントロールの取得/設定。  
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterThemeable#getThemeManager--) : テーマ マネージャの取得。  
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) : ヘッダーとフッターのマネージャ取得。

スライド マスターのメソッド:

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) : スライド マスターに依存するすべてのスライドを取得。  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) : 現在のスライド マスターと新しいテーマから新しいスライド マスターを作成し、依存スライドすべてに適用します。  


## **スライド マスターの取得**

PowerPoint では、ビュー → スライド マスター メニューからスライド マスターにアクセスできます。

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides では、次のようにスライド マスターにアクセスできます:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションのマスタースライドへのアクセスを取得します
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


[MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) クラスはスライド マスターを表します。[Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) プロパティ（[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) 型）には、プレゼンテーションで定義されたすべてのスライド マスターの一覧が含まれます。  


## **スライド マスターへの画像追加**

スライド マスターに画像を追加すると、そのマスターに依存するすべてのスライドに画像が表示されます。

たとえば、会社のロゴや複数の画像をスライド マスターに配置し、スライド 編集モードに戻すと、すべてのスライドに画像が表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides でスライド マスターに画像を追加する方法:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 10, 10, 100, 100, picture);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
画像の追加に関する詳細は、[Picture Frame](/slides/ja/nodejs-java/picture-frame/#create-picture-frame) 記事をご参照ください。 
{{% /alert %}}


## **スライド マスターへのプレースホルダー追加**

スライド マスター上の標準プレースホルダー:

* Master タイトルスタイルをクリックして編集
* Master テキストスタイルを編集
* 第 2 レベル
* 第 3 レベル

これらはスライド マスターに基づくスライドにも表示されます。プレースホルダーをスライド マスターで編集すると、変更が自動的にスライドに適用されます。

PowerPoint では、スライド マスター → プレースホルダー挿入 のパスでプレースホルダーを追加できます:

![todo:image_alt_text](slide-master_5.png)

Aspose.Slides でのプレースホルダーのより複雑な例を見てみましょう。スライド マスターからテンプレート化されたプレースホルダーを持つスライドです:

![todo:image_alt_text](slide-master_6.png)

次のようにスライド マスター上のタイトルとサブタイトルの書式設定を変更します:

![todo:image_alt_text](slide-master_7.png)

まず、スライド マスター オブジェクトからタイトルプレースホルダーの内容を取得し、`PlaceHolder.FillFormat` フィールドを使用します:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    var placeHolder = findPlaceholder(master, aspose.slides.PlaceholderType.Title);
    placeHolder.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    placeHolder.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    var awtColor = java.import('java.awt.Color');
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, java.newInstanceSync('java.awt.Color', 255, 0, 0));
    placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, java.newInstanceSync('java.awt.Color', 128, 0, 128));

    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}

function findPlaceholder(master, type)
{    
    for (var i = 0 ; i < master.getShapes().size(); i++)
    {
        var autoShape = master.getShapes().get_Item(i);
        if (autoShape != null)
        {
            if (autoShape.getPlaceholder().getType() == type)
            {
                return autoShape;
            }
        }
    }

    return null;
}
```


タイトルのスタイルと書式が、スライド マスターに基づくすべてのスライドで変更されます:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [プレースホルダーへのプロンプト テキスト設定](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)  
* [テキスト書式設定](https://docs.aspose.com/slides/nodejs-java/text-formatting/) 
{{% /alert %}}


## **スライド マスターの背景変更**

マスター スライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。以下の JavaScript コードが操作例です:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    var master = pres.getMasters().get_Item(0);
    master.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    master.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert color="primary" title="See also" %}} 
- [Presentation Background](https://docs.aspose.com/slides/nodejs-java/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/nodejs-java/presentation-theme/) 
{{% /alert %}}


## **スライド マスターを別のプレゼンテーションにクローン**

スライド マスターを別のプレゼンテーションにクローンするには、対象プレゼンテーションの [**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) メソッドを呼び出し、クローンしたいスライド マスターを引数として渡します。以下の JavaScript コードが例です:  
```javascript
var presSource = new aspose.slides.Presentation();
var presTarget = new aspose.slides.Presentation();
try {
    var master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) {
        presSource.dispose();
    }
}
```



## **プレゼンテーションへの複数スライド マスター追加**

Aspose.Slides では、任意のプレゼンテーションに複数のスライド マスターとスライド レイアウトを追加できます。これにより、スライドのスタイル、レイアウト、書式設定オプションを多様に設定できます。

PowerPoint では、スライド マスター メニューから新しいスライド マスターとレイアウトを追加できます:

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、[**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) メソッドを呼び出して新しいスライド マスターを追加します:  
```javascript
// 新しいマスタースライドを追加します
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **スライド マスターの比較**

マスター スライドは [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) クラスを実装し、[**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-) メソッドを提供します。このメソッドでスライドを比較でき、構造と静的コンテンツが同一のマスター スライドに対して `true` を返します。

2 つのマスター スライドは、形状、スタイル、テキスト、アニメーション、その他の設定などがすべて等しい場合に等しいと見なされます。比較では一意の識別子 (例: SlideId) や動的コンテンツ (例: 日付プレースホルダーの現在の日付) は考慮されません。 


## **スライド マスターをプレゼンテーションのデフォルト ビューに設定**

Aspose.Slides では、スライド マスターをプレゼンテーションのデフォルト ビューとして設定できます。デフォルト ビューは、プレゼンテーションを開いたときに最初に表示されるものです。

以下のコードは、JavaScript でスライド マスターをプレゼンテーションのデフォルト ビューに設定する方法を示しています:  
```javascript
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
var presentation = new aspose.slides.Presentation();
try {
    // デフォルト表示を SlideMasterView に設定します
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // プレゼンテーションを保存します
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```



## **未使用のマスター スライドの削除**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) クラスの [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) メソッドを提供し、不要なマスター スライドを削除できます。以下の JavaScript コードが PowerPoint プレゼンテーションからマスター スライドを削除する例です:  
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**PowerPoint のスライド マスターとは何ですか？**

スライド マスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライド テンプレートです。すべてのスライドの外観を一括で設定・変更できます。  

**スライド マスターはプレゼンテーションでどのように適用されますか？**

すべてのプレゼンテーションはデフォルトで少なくとも 1 つのスライド マスターを持ちます。新しいスライドが追加されると、そのスライドにスライド マスターが自動的に適用され、通常は前のスライドのマスターが継承されます。複数のスライド マスターを使用して、異なる部分を個別にスタイル設定できます。  

**スライド マスターでカスタマイズできる要素は何ですか？**

スライド マスターは次のコア プロパティで構成され、カスタマイズ可能です:

- **Background**: スライド背景の設定。  
- **BodyStyle**: スライド本文のテキストスタイルの定義。  
- **Shapes**: プレースホルダーや画像枠など、スライド マスター上のすべての図形の管理。  
- **Controls**: ActiveX コントロールの操作。  
- **ThemeManager**: テーマ マネージャへのアクセス。  
- **HeaderFooterManager**: ヘッダーとフッターの管理。  

**スライド マスターに画像を追加するには？**

スライド マスターに画像を追加すると、そのマスターに依存するすべてのスライドに画像が表示されます。たとえば会社ロゴをスライド マスターに配置すると、プレゼンテーションのすべてのスライドにロゴが表示されます。  

**スライド マスターとスライド レイアウトの関係は？**

スライド レイアウトはスライド マスターと連携して柔軟なスライド デザインを実現します。スライド マスターが全体的なスタイルとテーマを定義し、スライド レイアウトがコンテンツ配置のバリエーションを提供します。階層は次のとおりです:

- **Slide Master** → グローバル スタイルを定義。  
- **Slide Layout** → コンテンツ配置のバリエーションを提供。  
- **Slide** → スライド レイアウトからデザインを継承。  

**1 つのプレゼンテーションで複数のスライド マスターを使用できますか？**

はい。プレゼンテーションは複数のスライド マスターを含めることができ、異なるセクションをさまざまな方法でスタイル設定でき、デザインの柔軟性が向上します。  

**Aspose.Slides でスライド マスターにアクセスし、変更するには？**

Aspose.Slides では、スライド マスターは [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション オブジェクトの [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) メソッドを使用してスライド マスターにアクセスできます。