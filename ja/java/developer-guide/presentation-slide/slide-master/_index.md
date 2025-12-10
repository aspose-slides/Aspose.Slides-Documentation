---
title: Java でプレゼンテーションのスライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/java/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPT マスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドのクローン
- マスタースライドのコピー
- マスタースライドの重複
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for Java のスライドマスターを管理: 簡潔な Java の例を使って、PPT、PPTX、ODP にレイアウト、テーマ、プレースホルダーを作成、編集、適用します。"
---

## **PowerPoint のスライドマスターとは**

**Slide Master** は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、およびその他のプロパティを定義するスライドテンプレートです。会社で同じスタイルとテンプレートのプレゼンテーション（または一連のプレゼンテーション）を作成したい場合は、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの外観を一度に設定および変更できるため便利です。Aspose.Slides は PowerPoint のスライドマスター機構をサポートしています。

VBA でもスライドマスターを操作でき、PowerPoint でサポートされている同じ操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slides はスライドマスターを使用し、基本的なタスクを柔軟に実行できるメカニズムを提供します。

以下は基本的なスライドマスター操作です：

- スライドマスターの作成または取得。
- プレゼンテーションスライドへのスライドマスターの適用。
- スライドマスターの背景変更。
- スライドマスターへの画像、プレースホルダー、Smart Art などの追加。

以下はスライドマスターに関する高度な操作です：

- スライドマスターの比較。
- スライドマスターのマージ。
- 複数のスライドマスターの適用。
- スライドマスター付きスライドを別のプレゼンテーションにコピー。
- プレゼンテーション内の重複スライドマスターの検出。
- スライドマスターをプレゼンテーションのデフォルトビューとして設定。

{{% alert color="primary" %}} 
Aspose の [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) は、ここで説明したコアプロセスのライブ実装ですので、ぜひお試しください。
{{% /alert %}} 

## **スライドマスターの適用方法**

スライドマスターを操作する前に、プレゼンテーションでの使用方法とスライドへの適用方法を理解しておくとよいでしょう。

* すべてのプレゼンテーションにはデフォルトで少なくとも 1 つのスライドマスターが存在します。  
* プレゼンテーションには複数のスライドマスターを含めることができます。複数のスライドマスターを追加し、プレゼンテーションの異なる部分に異なるスタイルを適用できます。

**Aspose.Slides** では、スライドマスターは [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) オブジェクトには、[**getMasters**](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) リストとして [**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) 型が含まれ、プレゼンテーションで定義されたすべてのマスタースライドの一覧が取得できます。

CRUD 操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) インターフェイスには次の便利なメソッドがあります： [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) と [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-)。これらは基本的なスライドクローン機能から継承されたものですが、スライドマスターを扱う際には複雑な設定を実装できます。

新しいスライドがプレゼンテーションに追加されると、スライドマスターが自動的に適用されます。デフォルトでは前のスライドのスライドマスターが選択されます。

**Note**: プレゼンテーションスライドは [getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) リストに格納され、新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションに単一のスライドマスターしかない場合、そのスライドマスターがすべての新規スライドに選択されます。これにより、各新規スライドごとにスライドマスターを個別に定義する必要がなくなります。

PowerPoint と Aspose.Slides の原理は同じです。たとえば、PowerPoint では最後のスライドの下のラインをクリックすると、前のスライドのスライドマスターを継承した新しいスライドが作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスの下の [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) メソッドで同等の操作が可能です。

## **スライドマスターのスライド階層での位置付け**

スライドレイアウトとスライドマスターを組み合わせることで、最大の柔軟性が得られます。スライドレイアウトはスライドマスターと同様のスタイル（背景、フォント、図形など）を設定できますが、複数のスライドレイアウトをスライドマスターに組み合わせると新しいスタイルが生成されます。スライドレイアウトを単一のスライドに適用すると、スライドマスターが適用したスタイルから変更できます。

スライドマスターはすべての設定項目の上位にあります： Slide Master → Slide Layout → Slide：

![todo:image_alt_text](slide-master_2)

各 [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) オブジェクトは、スライドレイアウトの一覧を保持する [**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--) プロパティを持ちます。 [Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) 型には、スライドに適用されたスライドレイアウトへのリンクを保持する [**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--) プロパティがあります。スライドとスライドマスターとのやり取りはスライドレイアウトを介して行われます。

{{% alert color="info" title="Note" %}}
* Aspose.Slides では、すべてのスライド設定（スライドマスター、スライドレイアウト、スライド自体）は実際には [**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) インターフェイスを実装するスライドオブジェクトです。  
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装する可能性があり、[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide) オブジェクトにどのように適用されるかを理解する必要があります。スライドマスターが最初にスライドに適用され、次にスライドレイアウトが適用されます。たとえば、スライドマスターとスライドレイアウトの両方に背景が設定されている場合、最終的なスライドの背景はスライドレイアウトのものになります。
{{% /alert %}}

## **スライドマスターに含まれる要素**

スライドマスターがどのように変更できるかを理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/) のコアプロパティです。

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) – スライド背景の取得/設定。  
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) – スライド本文のテキストスタイルの取得/設定。  
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) – プレースホルダー、画像フレームなど、スライドマスター上のすべての図形の取得/設定。  
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) – ActiveX コントロールの取得/設定。  
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) – テーママネージャーの取得。  
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) – ヘッダーとフッターのマネージャーの取得。

スライドマスターのメソッド：

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) – スライドマスターに依存するすべてのスライドを取得。  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – 現在のスライドマスターと新しいテーマから新しいスライドマスターを作成し、依存スライドすべてに適用します。

## **スライドマスターの取得方法**

PowerPoint では、[表示] → [スライドマスター] メニューからスライドマスターにアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides では、次のようにスライドマスターにアクセスできます：  
```java
Presentation pres = new Presentation();
try {
    // Presentation のマスタースライドにアクセスできる
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


[IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide) インターフェイスがスライドマスターを表します。[Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--) プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection) 型に関連）には、プレゼンテーションで定義されたすべてのスライドマスターの一覧が含まれます。

## **スライドマスターに画像を追加する方法**

スライドマスターに画像を追加すると、その画像はマスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴやいくつかの画像をスライドマスターに配置し、スライド編集モードに戻すと、すべてのスライドに画像が表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides でスライドマスターに画像を追加するには次のようにします：  
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
スライドに画像を追加する詳細は、[Picture Frame](/slides/ja/java/picture-frame/#create-picture-frame) 記事をご参照ください。
{{% /alert %}}

## **スライドマスターにプレースホルダーを追加する方法**

スライドマスター上の標準プレースホルダーは次のとおりです：

* Master タイトルスタイルのクリックで編集
* Master テキストスタイルの編集
* 第 2 レベル
* 第 3 レベル

これらはスライドマスターに基づくスライドにも表示されます。スライドマスター上でプレースホルダーを編集すると、変更が自動的にスライドに適用されます。

PowerPoint では、[スライドマスター] → [プレースホルダーの挿入] パスからプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

以下は Aspose.Slides を使用した、プレースホルダーのより複雑な例です。スライドマスターからテンプレート化されたプレースホルダーを持つスライドを考えてみます：

![todo:image_alt_text](slide-master_6.png)

次のようにスライドマスター上でタイトルとサブタイトルの書式設定を変更します：

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


タイトルのスタイルと書式は、スライドマスターに基づくすべてのスライドで変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/java/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/java/text-formatting/)
{{% /alert %}}

## **スライドマスターの背景を変更する方法**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。以下の Java コードが操作例です：  
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
- [Presentation Background](https://docs.aspose.com/slides/java/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/java/presentation-theme/)
{{% /alert %}}

## **スライドマスターを別のプレゼンテーションへクローンする方法**

別のプレゼンテーションへスライドマスターをクローンするには、宛先プレゼンテーションの [**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出し、対象のスライドマスターを引数として渡します。以下の Java コードがクローン手順を示しています：  
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```


## **プレゼンテーションに複数のスライドマスターを追加する方法**

Aspose.Slides は、任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できます。これにより、プレゼンテーションスライドのスタイル、レイアウト、書式設定オプションを多彩に構成できます。

PowerPoint では、[スライドマスターメニュー]から新しいスライドマスターとレイアウトを次のように追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、[**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出すことで新しいスライドマスターを追加できます：  
```java
// 新しいマスタースライドを追加します
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **スライドマスターの比較方法**

マスタースライドは [IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide) インターフェイスを実装しており、[**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) メソッドでスライドを比較できます。構造と静的コンテンツが同一のマスタースライドは `true` を返します。

2 つのマスタースライドは、図形、スタイル、テキスト、アニメーション、その他設定などがすべて同等であれば等価とみなされます。比較では一意識別子（例：SlideId）や動的コンテンツ（例：日付プレースホルダーの現在の日付値）は考慮されません。

## **スライドマスターをプレゼンテーションのデフォルトビューに設定する方法**

Aspose.Slides では、スライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるビューです。

以下のコードは、Java でスライドマスターをプレゼンテーションのデフォルトビューに設定する方法を示しています：  
```java
// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
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


## **未使用のマスタースライドを削除する方法**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/) クラスの [removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッドを提供し、不要で未使用のマスタースライドを削除できます。以下の Java コードは、PowerPoint プレゼンテーションからマスタースライドを削除する手順を示しています：  
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

スライドマスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。すべてのプレゼンテーションスライドの外観を一度に設定および変更できます。

**プレゼンテーションでスライドマスターはどのように適用されますか？**

すべてのプレゼンテーションにはデフォルトで少なくとも 1 つのスライドマスターがあります。新しいスライドが追加されると、スライドマスターが自動的に適用され、通常は前のスライドのマスターを継承します。プレゼンテーションは複数のスライドマスターを含めて、異なる部分を個別にスタイル設定できます。

**スライドマスターでカスタマイズできる要素は何ですか？**

スライドマスターは複数のコアプロパティで構成され、以下をカスタマイズできます：

- **Background**：スライドの背景を設定。  
- **BodyStyle**：スライド本文のテキストスタイルを定義。  
- **Shapes**：プレースホルダーや画像フレームを含むすべての図形を管理。  
- **Controls**：ActiveX コントロールを処理。  
- **ThemeManager**：テーママネージャーにアクセス。  
- **HeaderFooterManager**：ヘッダーとフッターを管理。

**スライドマスターに画像を追加するには？**

スライドマスターに画像を追加すると、その画像はそのマスターに依存するすべてのスライドに表示されます。たとえば、会社のロゴをスライドマスターに配置すると、プレゼンテーションのすべてのスライドにロゴが表示されます。

**スライドマスターとスライドレイアウトの関係は？**

スライドレイアウトはスライドマスターと連携してスライドデザインの柔軟性を提供します。スライドマスターが全体的なスタイルとテーマを定義し、スライドレイアウトはコンテンツ配置のバリエーションを可能にします。階層は次のとおりです：

- **Slide Master** → グローバルスタイルを定義。  
- **Slide Layout** → 異なるコンテンツ配置を提供。  
- **Slide** → スライドレイアウトからデザインを継承。

**1 つのプレゼンテーションに複数のスライドマスターを持てますか？**

はい、プレゼンテーションに複数のスライドマスターを含めることができます。これにより、プレゼンテーションの異なるセクションをさまざまな方法でスタイル設定でき、デザインの柔軟性が向上します。

**Aspose.Slides でスライドマスターにアクセスし、変更する方法は？**

Aspose.Slides では、スライドマスターは [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) インターフェイスで表されます。[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) オブジェクトの [getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) メソッドでスライドマスターにアクセスできます。