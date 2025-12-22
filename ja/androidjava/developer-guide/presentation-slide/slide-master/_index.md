---
title: Android でプレゼンテーション スライド マスターを管理
linktitle: スライド マスター
type: docs
weight: 70
url: /ja/androidjava/slide-master/
keywords:
- スライド マスター
- マスター スライド
- PPT マスター スライド
- 複数のマスター スライド
- マスター スライドの比較
- 背景
- プレースホルダー
- マスター スライドのクローン
- マスター スライドのコピー
- マスター スライドの重複
- 未使用のマスター スライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android でスライド マスターを管理します：レイアウト、テーマ、プレースホルダーを PPT、PPTX、ODP に作成、編集、適用し、簡潔な Java サンプルで示します。"
---

## **PowerPoint のスライド マスターとは**

**スライド マスター** は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、およびその他のプロパティを定義するスライド テンプレートです。会社の同一スタイルやテンプレートでプレゼンテーション（または一連のプレゼンテーション）を作成したい場合は、スライド マスターを使用できます。

スライド マスターは、すべてのプレゼンテーション スライドの外観を一括で設定および変更できるため便利です。Aspose.Slides は PowerPoint のスライド マスター機構をサポートしています。

VBA でもスライド マスターを操作でき、PowerPoint でサポートされている操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slides はスライド マスターを使用し、基本的なタスクを柔軟に実行できるメカニズムを提供します。

基本的なスライド マスター操作は次のとおりです：

- スライド マスターの作成または取得。
- スライド マスターをプレゼンテーション スライドに適用。
- スライド マスターの背景を変更。
- スライド マスターに画像、プレースホルダー、SmartArt などを追加。

より高度なスライド マスター操作は次のとおりです：

- スライド マスターの比較。
- スライド マスターの結合。
- 複数のスライド マスターの適用。
- スライド マスター付きのスライドを別のプレゼンテーションにコピー。
- プレゼンテーション内の重複スライド マスターを検出。
- スライド マスターをプレゼンテーションのデフォルト表示として設定。

{{% alert color="primary" %}} 
Aspose の[**オンライン PowerPoint ビューア**](https://products.aspose.app/slides/viewer)は、ここで説明した主要プロセスの実装例として確認できます。
{{% /alert %}} 


## **スライド マスターの適用方法**

スライド マスターを操作する前に、プレゼンテーションでの使用方法とスライドへの適用方法を理解しておくとよいでしょう。

* すべてのプレゼンテーションには、デフォルトで少なくとも 1 つのスライド マスターがあります。
* プレゼンテーションには複数のスライド マスターを含めることができ、異なる部分を別々のスタイルで装飾できます。

**Aspose.Slides** では、スライド マスターは [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) オブジェクトは、[**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) リストとして [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) 型を保持し、プレゼンテーションで定義されたすべてのマスター スライドの一覧を提供します。

CRUD 操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) インターフェイスは次の便利なメソッドを備えています： [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) および [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-)。これらは基本的なスライド クローン機能から継承されますが、スライド マスターに対して使用すると複雑な設定を実装できます。

新しいスライドがプレゼンテーションに追加されると、スライド マスターが自動的に適用されます。既定では前のスライドのマスターが選択されます。

**注**: プレゼンテーション スライドは [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) リストに格納され、新しいスライドは既定でコレクションの末尾に追加されます。プレゼンテーションに単一のスライド マスターしかない場合、そのマスターがすべての新規スライドに適用されます。このため、各スライドごとにスライド マスターを指定する必要はありません。

PowerPoint と Aspose.Slides では原理が同じです。たとえば PowerPoint では、最後のスライドの下にある線をクリックすると、直前のスライドのマスターが適用された新しいスライドが作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) メソッドを使用して同等の操作が可能です。


## **スライド マスターとスライド階層**

スライド レイアウトとスライド マスターを組み合わせて使用すると、最大の柔軟性が得られます。スライド レイアウトはスライド マスターと同じスタイル（背景、フォント、図形など）を設定できますが、複数のレイアウトがマスター上に組み合わさると新たなスタイルが生成されます。スライド レイアウトを単一のスライドに適用すると、マスターが設定したスタイルから上書きされます。

スライド マスターはすべての設定項目の上位に位置します： スライド マスター → スライド レイアウト → スライド：

![todo:image_alt_text](slide-master_2)

各 [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) オブジェクトは、スライド レイアウトの一覧を保持する [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) プロパティを持ちます。[Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) 型は、適用されたスライド レイアウトへのリンクを保持する [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) プロパティを持ちます。スライドとスライド マスターの相互作用はスライド レイアウトを介して行われます。

{{% alert color="info" title="注" %}}
* Aspose.Slides では、スライドのすべての設定（スライド マスター、スライド レイアウト、スライド自体）は、[**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェイスを実装したスライド オブジェクトです。
* したがって、スライド マスターとスライド レイアウトは同じプロパティを実装する可能性があり、どの値が最終的に [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) オブジェクトに適用されるかを理解する必要があります。スライド マスターがまず適用され、次にスライド レイアウトが適用されます。たとえば、両方に背景が設定されている場合、最終的なスライドの背景はスライド レイアウト側のものになります。
{{% /alert %}}


## **スライド マスターの構成要素**

スライド マスターを変更する方法を理解するには、構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/) の主要プロパティです。

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) – スライドの背景を取得/設定。
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) – スライド本体のテキストスタイルを取得/設定。
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) – スライド マスター上のすべての図形（プレースホルダー、画像フレームなど）を取得/設定。
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) – ActiveX コントロールを取得/設定。
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) – テーマ マネージャーを取得。
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) – ヘッダーとフッターのマネージャーを取得。

スライド マスターのメソッド：

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) – マスターに依存するすべてのスライドを取得。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – 現在のスライド マスターと新しいテーマから新しいスライド マスターを作成し、依存スライドすべてに適用します。


## **スライド マスターの取得方法**

PowerPoint では、[表示] → [スライド マスター] メニューからスライド マスターにアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides を使用すると、次のようにスライド マスターにアクセスできます：
```java
Presentation pres = new Presentation();
try {
    // Presentation のマスタースライドにアクセスします
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


[IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) インターフェイスがスライド マスターを表します。Presentation の [Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) 型）は、プレゼンテーションで定義されたすべてのスライド マスターの一覧を保持します。


## **スライド マスターに画像を追加する方法**

スライド マスターに画像を追加すると、そのマスターに依存するすべてのスライドに同じ画像が表示されます。

たとえば、会社のロゴや数枚の画像をスライド マスターに配置すれば、スライド編集モードに戻したときにすべてのスライドで画像が表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides でスライド マスターに画像を追加する方法：
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


{{% alert color="primary" title="関連項目" %}} 
スライドへの画像追加に関する詳細は、[Picture Frame](/slides/ja/androidjava/picture-frame/#create-picture-frame) 記事をご参照ください。
{{% /alert %}}


## **スライド マスターにプレースホルダーを追加する方法**

スライド マスター上の標準プレースホルダー例：

* マスター タイトル スタイルの編集
* マスターテキスト スタイルの編集
* 第 2 レベル
* 第 3 レベル

これらはスライド マスターに基づくスライドにも表示されます。スライド マスター上でプレースホルダーを編集すると、スライドに自動的に反映されます。

PowerPoint では、[スライド マスター] → [プレースホルダーの挿入] パスでプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

Aspose.Slides でのプレースホルダーの複雑な例を見てみましょう。次のスライドはスライド マスターからテンプレート化されたプレースホルダーを持ちます：

![todo:image_alt_text](slide-master_6.png)

次のようにスライド マスター上でタイトルとサブタイトルの書式を変更したいとします：

![todo:image_alt_text](slide-master_7.png)

まず、スライド マスター オブジェクトからタイトル プレースホルダーのコンテンツを取得し、`PlaceHolder.FillFormat` フィールドを使用します：
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


タイトルのスタイルと書式が、スライド マスターに基づくすべてのスライドで変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="関連項目" %}} 
* [プレースホルダーへのプロンプト テキストの設定](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [テキストの書式設定](https://docs.aspose.com/slides/androidjava/text-formatting/)
{{% /alert %}}


## **スライド マスターの背景を変更する方法**

マスター スライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。以下の Java コードがその操作例です：
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


{{% alert color="primary" title="関連項目" %}} 
- [Presentation Background](https://docs.aspose.com/slides/androidjava/presentation-background/)
- [Presentation Theme](https://docs.aspose.com/slides/androidjava/presentation-theme/)
{{% /alert %}}

## **スライド マスターを別のプレゼンテーションにクローンする方法**

スライド マスターを別のプレゼンテーションにクローンするには、対象プレゼンテーションの [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出し、クローンしたいスライド マスターを引数に渡します。以下の Java コードがその手順を示しています：
```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```



## **プレゼンテーションに複数のスライド マスターを追加する方法**

Aspose.Slides では、任意のプレゼンテーションに複数のスライド マスターとスライド レイアウトを追加できます。これにより、スライドのスタイル、レイアウト、書式設定オプションを多様に構成できます。

PowerPoint では、[スライド マスター] メニューから新しいスライド マスターとレイアウトを次のように追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、[**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出すことで新しいスライド マスターを追加できます：
```java
// 新しいマスタースライドを追加します
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```



## **スライド マスターの比較方法**

マスター スライドは [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェイスを実装し、[**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) メソッドを提供します。このメソッドを使用してスライドを比較できます。構造と静的コンテンツが同一のマスター スライドは `true` を返します。

2 つのマスター スライドは、形状、スタイル、テキスト、アニメーション、その他の設定がすべて一致している場合に等しいとみなされます。比較は SlideId などの一意識別子や、日付プレースホルダーの現在日のような動的コンテンツは考慮しません。


## **スライド マスターをプレゼンテーションのデフォルト表示に設定する方法**

Aspose.Slides では、スライド マスターをプレゼンテーションのデフォルト表示として設定できます。デフォルト表示は、プレゼンテーションを開いたときに最初に表示されるビューです。

以下のコードは、Java でスライド マスターをプレゼンテーションのデフォルト表示に設定する方法を示しています：
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



## **未使用のマスター スライドを削除する方法**

Aspose.Slides は、[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスの [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッドを提供し、不要なマスター スライドを削除できます。以下の Java コードが PowerPoint プレゼンテーションからマスター スライドを削除する手順を示しています：
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

**PowerPoint のスライド マスターとは何ですか？**

スライド マスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライド テンプレートです。すべてのスライドの外観を一括で設定および変更できます。

**スライド マスターはプレゼンテーションでどのように適用されますか？**

すべてのプレゼンテーションにはデフォルトで最低 1 つのスライド マスターがあります。新しいスライドが追加されると、スライド マスターが自動的に適用され、通常は前のスライドのマスターが継承されます。複数のスライド マスターを持つことで、プレゼンテーションの異なる部分を個別に装飾できます。

**スライド マスターでカスタマイズできる要素は何ですか？**

スライド マスターは以下の主要プロパティをカスタマイズできます：

- **Background**：スライドの背景を設定。
- **BodyStyle**：スライド本体のテキストスタイルを定義。
- **Shapes**：プレースホルダーや画像フレームを含むすべての図形を管理。
- **Controls**：ActiveX コントロールを扱う。
- **ThemeManager**：テーマ マネージャーにアクセス。
- **HeaderFooterManager**：ヘッダーとフッターを管理。

**スライド マスターに画像を追加するには？**

スライド マスターに画像を追加すると、そのマスターに依存するすべてのスライドに画像が表示されます。たとえば、会社のロゴをスライド マスターに配置すれば、プレゼンテーション内のすべてのスライドに表示されます。

**スライド マスターとスライド レイアウトの関係は？**

スライド レイアウトはスライド マスターと連携してスライド デザインに柔軟性を提供します。スライド マスターが全体的なスタイルとテーマを定義し、スライド レイアウトがコンテンツ配置のバリエーションを可能にします。階層は以下の通りです：

- **Slide Master** → グローバルスタイルを定義。
- **Slide Layout** → 異なるコンテンツ配置を提供。
- **Slide** → スライド レイアウトからデザインを継承。

**1 つのプレゼンテーションに複数のスライド マスターを持てますか？**

はい。プレゼンテーションは複数のスライド マスターを含めることができ、セクションごとに異なるデザインを適用して柔軟に装飾できます。

**Aspose.Slides でスライド マスターにアクセスし、変更するには？**

Aspose.Slides では、スライド マスターは [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) インターフェイスで表されます。Presentation オブジェクトの [getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) メソッドを使用してスライド マスターにアクセスできます。