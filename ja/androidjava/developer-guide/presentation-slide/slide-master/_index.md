---
title: Androidでプレゼンテーションスライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/androidjava/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPTマスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Android 用 Aspose.Slides でスライドマスターを管理: PPT、PPTX、ODP にレイアウト、テーマ、プレースホルダーを作成・編集・適用する簡潔な Java サンプル"
---

## **PowerPoint のスライドマスターとは何か**

**スライドマスター** は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。会社の同じスタイルとテンプレートでプレゼンテーション（または一連のプレゼンテーション）を作成したい場合は、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの外観を一括で設定および変更できるため便利です。Aspose.Slides は PowerPoint のスライドマスター機構をサポートしています。

VBA でもスライドマスターを操作でき、PowerPoint でサポートされている操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slides は柔軟な機構を提供し、スライドマスターの利用と基本的なタスクの実行を可能にします。

これらは基本的なスライドマスター操作です：

- スライドマスターを作成または取得。
- プレゼンテーションスライドにスライドマスターを適用。
- スライドマスターの背景を変更。
- スライドマスターに画像、プレースホルダー、SmartArt などを追加。

これらはスライドマスターに関わる高度な操作です：

- スライドマスターを比較。
- スライドマスターをマージ。
- 複数のスライドマスターを適用。
- スライドマスター付きスライドを別のプレゼンテーションにコピー。
- プレゼンテーション内の重複スライドマスターを検出。
- スライドマスターをプレゼンテーションのデフォルトビューに設定。

{{% alert color="primary" %}} 
Aspose の [**オンライン PowerPoint ビューア**](https://products.aspose.app/slides/viewer) をチェックするとよいでしょう。これは、本稿で説明したコアプロセスのいくつかのライブ実装です。
{{% /alert %}} 

## **スライドマスターはどのように適用されるか**

スライドマスターを扱う前に、プレゼンテーションでの使用方法とスライドへの適用方法を理解するとよいでしょう。

* すべてのプレゼンテーションはデフォルトで少なくとも 1 つのスライドマスターを持ちます。  
* プレゼンテーションには複数のスライドマスターを含めることができ、異なる部分を異なる方法でスタイル設定できます。  

**Aspose.Slides** では、スライドマスターは [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) オブジェクトは、[**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) リストである [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) を保持し、プレゼンテーションで定義されたすべてのスライドマスターの一覧を取得できます。

CRUD 操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) インターフェイスには次の便利なメソッドが含まれます: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) と [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-)。これらは基本的なスライド複製機能から継承されていますが、スライドマスターを扱う際には複雑な設定を実装するために使用できます。

新しいスライドがプレゼンテーションに追加されると、スライドマスターが自動的に適用されます。デフォルトでは前のスライドのスライドマスターが選択されます。

**Note**: プレゼンテーションスライドは [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) リストに格納され、新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションが単一のスライドマスターしか持たない場合、そのスライドマスターがすべての新規スライドに適用されます。これにより、各新規スライドごとにスライドマスターを明示的に指定する必要がなくなります。

PowerPoint と Aspose.Slides の原理は同じです。たとえば PowerPoint では、最後のスライドの下の線をクリックすると、前のプレゼンテーションのスライドマスターを引き継いだ新しいスライドが作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) メソッドを使用して同等の操作を行えます。

## **スライド階層におけるスライドマスター**

スライドレイアウトとスライドマスターを組み合わせることで、最大限の柔軟性が得られます。スライドレイアウトはスライドマスターと同じスタイル（背景、フォント、図形など）を設定できますが、複数のスライドレイアウトがスライドマスターに組み合わさると新しいスタイルが生成されます。スライドレイアウトを単一スライドに適用すると、スライドマスターが適用したスタイルから変更できます。

スライドマスターはすべての設定項目の上位に位置します: スライドマスター → スライドレイアウト → スライド：

![todo:image_alt_text](slide-master_2)

各 [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) オブジェクトは、スライドレイアウトの一覧を持つ [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) プロパティを持ちます。スライド型は、適用されたスライドレイアウトへのリンクを持つ [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) プロパティを持ちます。スライドとスライドマスターの相互作用はスライドレイアウトを通じて行われます。

{{% alert color="info" title="Note" %}}
* Aspose.Slides では、スライドマスター、スライドレイアウト、スライド自体すべてが [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェイスを実装するスライドオブジェクトです。  
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装する可能性があり、各プロパティが [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) オブジェクトにどのように適用されるかを理解する必要があります。スライドマスターが最初に適用され、次にスライドレイアウトが適用されます。たとえば、スライドマスターとスライドレイアウトの両方に背景が設定されている場合、最終的なスライドはスライドレイアウトの背景を使用します。
{{% /alert %}}

## **スライドマスターに含まれるもの**

スライドマスターを変更する方法を理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterslide/) の主なプロパティです。

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) スライドの背景を取得/設定します。  
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) スライド本文のテキストスタイルを取得/設定します。  
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) プレースホルダー、画像枠など、スライドマスター上のすべての図形を取得/設定します。  
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) ActiveX コントロールを取得/設定します。  
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) テーママネージャーを取得します。  
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) ヘッダーとフッターマネージャーを取得します。  

スライドマスターのメソッド:

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) このスライドマスターに依存するすべてのスライドを取得します。  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) 現在のスライドマスターと新しいテーマに基づいて新しいスライドマスターを作成し、依存スライドすべてに適用します。  

## **スライドマスターを取得する**

PowerPoint では、[表示] → [スライドマスター] メニューからスライドマスターにアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides を使用すると、次のようにスライドマスターにアクセスできます：  
```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションのマスタースライドへのアクセスを取得
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


[IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) インターフェイスはスライドマスターを表します。[Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) 型に関連）には、プレゼンテーションで定義されたすべてのスライドマスターの一覧が含まれます。  

## **スライドマスターに画像を追加する**

スライドマスターに画像を追加すると、その画像はそのマスターに依存するすべてのスライドに表示されます。たとえば、会社のロゴをスライドマスターに配置すれば、プレゼンテーション内のすべてのスライドでロゴが表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides でスライドマスターに画像を追加できます：  
```java
Presentation pres = new Presentation();
try {
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    pres.getMasters().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture);

    pres.save("pres.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 
スライドへの画像追加に関する詳細は、[Picture Frame](/slides/ja/androidjava/picture-frame/#create-picture-frame) 記事をご参照ください。
{{% /alert %}}

## **スライドマスターにプレースホルダーを追加する**

次のテキストフィールドはスライドマスター上の標準プレースホルダーです:

* マスタータイトルスタイルを編集するにはクリック
* マスターテキストスタイルを編集
* 第 2 レベル
* 第 3 レベル

これらはスライドマスターに基づくスライドにも表示されます。スライドマスター上でプレースホルダーを編集すると、変更が自動的にスライドに適用されます。

PowerPoint では、[スライドマスター] → [プレースホルダーの挿入] パスを使ってプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

次に、Aspose.Slides を使用したプレースホルダーのより複雑な例を見てみましょう。スライドマスターからテンプレート化されたプレースホルダーを持つスライドです：

![todo:image_alt_text](slide-master_6.png)

以下のようにスライドマスター上でタイトルとサブタイトルの書式を変更します：

![todo:image_alt_text](slide-master_7.png)

まず、スライドマスターオブジェクトからタイトルプレースホルダーの内容を取得し、`PlaceHolder.FillFormat` フィールドを使用します：  
```java
public static void main(String[] args) {
    Presentation pres = new Presentation();
    try {
        IMasterSlide master = pres.getMasters().get_Item(0);
        IAutoShape placeHolder = findPlaceholder(master, PlaceholderType.Title);
        placeHolder.getFillFormat().setFillType(FillType.Gradient);
        placeHolder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(0, new Color(255, 0, 0));
        placeHolder.getFillFormat().getGradientFormat().getGradientStops().add(255, new Color(128, 0, 128));

        pres.save("pres.pptx", SaveFormat.Pptx);
    } finally {
        if (pres != null) pres.dispose();
    }
}

static IAutoShape findPlaceholder(IMasterSlide master, int type)
{
    for (IShape shape : master.getShapes())
    {
        IAutoShape autoShape = (IAutoShape) shape;
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


タイトルのスタイルと書式が、スライドマスターに基づくすべてのスライドで変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [プレースホルダーにプロンプトテキストを設定](https://docs.aspose.com/slides/androidjava/manage-placeholder/)  
* [テキスト書式設定](https://docs.aspose.com/slides/androidjava/text-formatting/)
{{% /alert %}}

## **スライドマスターの背景を変更する**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。この Java コードが操作を示しています：  
```java
Presentation pres = new Presentation();
try {
    IMasterSlide master = pres.getMasters().get_Item(0);
    master.getBackground().setType(BackgroundType.OwnBackground);
    master.getBackground().getFillFormat().setFillType(FillType.Solid);
    master.getBackground().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


{{% alert color="primary" title="See also" %}} 
- [プレゼンテーションの背景](https://docs.aspose.com/slides/androidjava/presentation-background/)  
- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/androidjava/presentation-theme/)
{{% /alert %}}

## **スライドマスターを別のプレゼンテーションにクローンする**

目的のプレゼンテーションからスライドマスターを別のプレゼンテーションへクローンするには、対象プレゼンテーションの [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドにスライドマスターを渡して呼び出します。この Java コードはスライドマスターを別のプレゼンテーションにクローンする方法を示しています：  
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **プレゼンテーションに複数のスライドマスターを追加する**

Aspose.Slides を使用すると、任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できます。これにより、プレゼンテーションスライドのスタイル、レイアウト、書式設定オプションを多様に設定できます。

PowerPoint では、[スライドマスターメニュー] から新しいスライドマスターとレイアウトを次のように追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、[**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出すことで新しいスライドマスターを追加できます：  
```java
// 新しいマスタースライドを追加します
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **スライドマスターを比較する**

マスタースライドは [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェイスを実装しており、[**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) メソッドでスライドを比較できます。構造と静的コンテンツが同一のマスタースライドは `true` を返します。

2 つのマスタースライドは、図形、スタイル、テキスト、アニメーションおよびその他の設定がすべて等しい場合に等しいと見なされます。比較はスライド ID などの一意識別子や日付プレースホルダーの現在の日付などの動的コンテンツは考慮しません。

## **スライドマスターをプレゼンテーションのデフォルトビューに設定する**

Aspose.Slides を使用すると、スライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューはプレゼンテーションを開いたときに最初に表示されるビューです。

このコードは Java でスライドマスターをプレゼンテーションのデフォルトビューに設定する方法を示しています：  
```java
// プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
Presentation presentation = new Presentation();
try {
    // デフォルトビューを SlideMasterView に設定します
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // プレゼンテーションを保存します
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **未使用のマスタースライドを削除する**

Aspose.Slides は [Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスの [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッドを提供し、不要なマスタースライドを削除できます。この Java コードは PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています：  
```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```


## **FAQ**

**PowerPoint のスライドマスターとは何ですか？**

スライドマスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。すべてのプレゼンテーションスライドの外観を一括で設定および変更できます。

**スライドマスターはプレゼンテーションでどのように適用されますか？**

すべてのプレゼンテーションはデフォルトで少なくとも 1 つのスライドマスターを持ちます。新しいスライドが追加されると、スライドマスターが自動的に適用され、通常は前のスライドのマスターが継承されます。複数のスライドマスターを持つことで、異なる部分を個別にスタイル設定できます。

**スライドマスターでカスタマイズできる要素は何ですか？**

スライドマスターは次の主要プロパティをカスタマイズできます：

- **Background**: スライドの背景を設定。  
- **BodyStyle**: スライド本文のテキストスタイルを定義。  
- **Shapes**: プレースホルダーや画像枠を含むすべての図形を管理。  
- **Controls**: ActiveX コントロールを操作。  
- **ThemeManager**: テーママネージャーにアクセス。  
- **HeaderFooterManager**: ヘッダーとフッターを管理。  

**スライドマスターに画像を追加する方法は？**

スライドマスターに画像を追加すると、そのマスターに依存するすべてのスライドに画像が表示されます。たとえば、会社ロゴをスライドマスターに配置すれば、プレゼンテーション内のすべてのスライドに表示されます。

**スライドマスターとスライドレイアウトの関係は？**

スライドレイアウトはスライドマスターと連携してスライドデザインに柔軟性を提供します。スライドマスターが全体的なスタイルとテーマを定義し、スライドレイアウトがコンテンツ配置のバリエーションを可能にします。階層は次のとおりです：

- **スライドマスター** → 全体スタイルを定義。  
- **スライドレイアウト** → コンテンツ配置のバリエーションを提供。  
- **スライド** → スライドレイアウトからデザインを継承。  

**1 つのプレゼンテーションに複数のスライドマスターを持てますか？**

はい。プレゼンテーションは複数のスライドマスターを含めることができ、プレゼンテーションの異なるセクションをさまざまな方法でスタイル設定でき、デザインの柔軟性が向上します。

**Aspose.Slides でスライドマスターにアクセスし、変更するには？**

Aspose.Slides では、スライドマスターは [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) インターフェイスで表されます。プレゼンテーションオブジェクトの [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) メソッドを使用してスライドマスターにアクセスできます。