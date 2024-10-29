---
title: スライドマスタ
type: docs
weight: 70
url: /ja/java/slide-master/
keywords: "スライドマスタの追加, PPTマスタスライド, スライドマスタのPowerPoint, スライドマスタへの画像, プレースホルダ, 複数のスライドマスタ, スライドマスタの比較, Java, Aspose.Slides for Java"
description: "JavaでPowerPointプレゼンテーションのスライドマスタを追加または編集する"
---

## **PowerPointにおけるスライドマスタとは**

**スライドマスタ**は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。同じスタイルとテンプレートで会社向けにプレゼンテーション（または一連のプレゼンテーション）を作成したい場合、スライドマスタを使用できます。

スライドマスタは、すべてのプレゼンテーションスライドの外観を一度に設定および変更できるため便利です。Aspose.Slidesは、PowerPointからのスライドマスタメカニズムをサポートしています。

VBAを使用すると、スライドマスタを操作し、背景を変更したり、図形を追加したり、レイアウトをカスタマイズしたりなど、PowerPointでサポートされている同じ操作を実行できます。Aspose.Slidesは、スライドマスタを使用し、それらを使用して基本的なタスクを実行するための柔軟なメカニズムを提供します。

これが基本的なスライドマスタ操作です：

- スライドマスタの作成またはスライドマスタ。
- プレゼンテーションスライドへのスライドマスタの適用。
- スライドマスタの背景の変更。
- スライドマスタに画像、プレースホルダ、スマートアートなどを追加する。

これがスライドマスタに関するより高度な操作です：

- スライドマスタの比較。
- スライドマスタのマージ。
- 複数のスライドマスタの適用。
- スライドマスタを持つスライドを別のプレゼンテーションにコピーする。
- プレゼンテーション内の重複スライドマスタを特定する。
- プレゼンテーションのデフォルトビューとしてスライドマスタを設定する。

{{% alert color="primary" %}} 

Asposeの[**オンラインPowerPointビューワー**](https://products.aspose.app/slides/viewer)をチェックすることをお勧めします。これは、ここで説明したいくつかのコアプロセスのライブ実装です。

{{% /alert %}} 


## **スライドマスタの適用方法**

スライドマスタを操作する前に、それらがプレゼンテーションでどのように使用され、スライドに適用されるかを理解したい場合があります。

* プレゼンテーションには、デフォルトで少なくとも1つのスライドマスタがあります。
* プレゼンテーションには複数のスライドマスタを含めることができます。複数のスライドマスタを追加し、異なる方法でプレゼンテーションの異なる部分をスタイル設定するために使用できます。

**Aspose.Slides**では、スライドマスタは [**IMasterSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) タイプで表されます。

Aspose.Slidesの[プレゼンテーション ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)オブジェクトには、[**getMasters** ](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--)メソッドがあり、[**IMasterSlideCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) タイプのリストを返します。これには、プレゼンテーションで定義されているすべてのマスタースライドのリストが含まれています。

CRUD操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/)インターフェースには、次のような便利なメソッドがあります: [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) および[**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) メソッド。これらのメソッドは、基本的なスライドクローン機能が継承されています。しかし、スライドマスタを扱うときは、これらのメソッドを使用して複雑な設定を実装できます。

プレゼンテーションに新しいスライドが追加されると、自動的にスライドマスタが適用されます。デフォルトでは、前のスライドのスライドマスタが選択されます。

**注**: プレゼンテーションスライドは[getSlides()](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--)リストに保存され、新しいスライドはデフォルトでコレクションの最後に追加されます。プレゼンテーションに単一のスライドマスタが含まれている場合、そのスライドマスタはすべての新しいスライドに対して選択されます。これが、作成する新しいスライドに対してスライドマスタを定義する必要がない理由です。

原則はPowerPointとAspose.Slidesで同じです。例えば、PowerPointでは、新しいプレゼンテーションを追加する際に、最後のスライドの下のボトムラインを単に押すことで、新しいスライド（最後のプレゼンテーションのスライドマスタ付き）が作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slidesでは、[addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)メソッドを使用して同等の作業を行うことができます。

## **スライド階層におけるスライドマスタ**

スライドマスタを使用したスライドレイアウトは、最大の柔軟性を可能にします。スライドレイアウトは、スライドマスタと同じスタイルをすべて設定できるようにします（背景、フォント、図形など）。ただし、複数のスライドレイアウトがスライドマスタに組み合わさると、新しいスタイルが作成されます。スライドレイアウトを単一のスライドに適用すると、スライドマスタによって適用されたスタイルから変更できるようになります。

スライドマスタはすべてのセットアップ項目の優先度が高くなります: スライドマスタ -> スライドレイアウト -> スライド:

![todo:image_alt_text](slide-master_2)

各[IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)オブジェクトには、スライドレイアウトのリストが含まれる[**getLayoutSlides**](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getLayoutSlides--)プロパティがあります。[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide)タイプには、スライドに適用されるスライドレイアウトへのリンクを持つ[**getLayoutSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlide#getLayoutSlide--)プロパティがあります。スライドとスライドマスタの間の相互作用は、スライドレイアウトを通じて発生します。

{{% alert color="info" title="注" %}}

* Aspose.Slidesでは、すべてのスライドのセットアップ（スライドマスタ、スライドレイアウト、スライドそのもの）は実際には[**IBaseSlide**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide)インターフェースを実装するスライドオブジェクトです。
* したがって、スライドマスタとスライドレイアウトは同じプロパティを実装することがあり、その値が[Slide](https://reference.aspose.com/slides/java/com.aspose.slides/Slide)オブジェクトにどのように適用されるかを理解する必要があります。スライドマスタは最初にスライドに適用され、その後スライドレイアウトが適用されます。たとえば、スライドマスタとスライドレイアウトの両方に背景値がある場合、スライドはスライドレイアウトからの背景になります。

{{% /alert %}}

## **スライドマスタの構成要素**

スライドマスタがどのように変更されるかを理解するためには、その構成要素を知る必要があります。これらは[MasterSlide](https://reference.aspose.com/slides/java/aspose.slides/masterslide/)のコアプロパティです。

- [getBackground](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getBackground--) スライドの背景を取得/設定します。
- [getBodyStyle](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getBodyStyle--) - スライドの本文のテキストスタイルを取得/設定します。
- [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getShapes--) スライドマスタのすべての形状を取得/設定します（プレースホルダ、画像フレームなど）。
- [getControls](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#getControls--) ActiveXコントロールを取得/設定します。
- [getThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterThemeable#getThemeManager--) - テーママネージャを取得します。
- [getHeaderFooterManager](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - ヘッダーとフッターのマネージャを取得します。

スライドマスタのメソッド：

- [getDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#getDependingSlides--) - スライドマスタに依存するすべてのスライドを取得します。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - 現在のスライドマスタと新しいテーマに基づいて新しいスライドマスタを作成できるようにします。新しいスライドマスタは、すべての依存スライドに適用されます。

## **スライドマスタの取得**

PowerPointでは、スライドマスタにアクセスするには、[表示] -> [スライドマスタ]メニューからアクセスします：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slidesを使用すると、次のようにスライドマスタにアクセスできます： 

```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションのマスタースライドにアクセスを提供
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

[IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlide)インターフェースはスライドマスタを表します。[Masters](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#getMasters--)プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IMasterSlideCollection)タイプに関連）は、プレゼンテーションで定義されているすべてのスライドマスタのリストを含みます。

## **スライドマスタに画像を追加**

スライドマスタに画像を追加すると、その画像はそのスライドマスタに依存するすべてのスライドに表示されます。

たとえば、スライドマスタに会社のロゴといくつかの画像を配置し、その後スライド編集モードに戻ると、すべてのスライドに画像を見ることができるはずです。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slidesを使用してスライドマスタに画像を追加できます：

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

{{% alert color="primary" title="関連情報" %}} 

スライドに画像を追加する方法の詳細については、[画像フレーム](/slides/ja/java/picture-frame/#create-picture-frame)の記事を参照してください。
{{% /alert %}}

## **スライドマスタにプレースホルダを追加**

これらのテキストフィールドは、スライドマスタ上の標準的なプレースホルダです： 

* マスタタイトルスタイルを編集するためにクリック 

* マスタテキストスタイルの編集 

* 第二レベル 

* 第三レベル 

  これらは、スライドマスタに基づくスライドにも表示されます。スライドマスタ上のこれらのプレースホルダを編集すると、変更が自動的にスライドに適用されます。

PowerPointでは、スライドマスタ -> プレースホルダの挿入パスを通じてプレースホルダを追加できます：

![todo:image_alt_text](slide-master_5.png)

Aspose.Slidesを使用したプレースホルダのより複雑な例を見てみましょう。スライドマスタからテンプレート化されたプレースホルダを持つスライドを考えてみてください：

![todo:image_alt_text](slide-master_6.png)

次のようにスライドマスタでタイトルとサブタイトルのフォーマットを変更したいと思います：

![todo:image_alt_text](slide-master_7.png)

最初に、スライドマスタオブジェクトからタイトルプレースホルダの内容を取得し、次に`PlaceHolder.FillFormat`フィールドを使用します： 

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

スライドマスタに基づくすべてのスライドに対して、タイトルスタイルとフォーマットが変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="関連情報" %}} 

* [プレースホルダにプロンプトテキストを設定](https://docs.aspose.com/slides/java/manage-placeholder/)
* [テキストフォーマット](https://docs.aspose.com/slides/java/text-formatting/)

{{% /alert %}}

## **スライドマスタの背景を変更する**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドに新しい色が適用されます。このJavaコードはその操作を示しています：

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

{{% alert color="primary" title="関連情報" %}} 

- [プレゼンテーションの背景](https://docs.aspose.com/slides/java/presentation-background/)

- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/java/presentation-theme/)

  {{% /alert %}}

## **スライドマスタを別のプレゼンテーションにクローン**

スライドマスタを別のプレゼンテーションにクローンするには、目的のプレゼンテーションから[**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)メソッドを呼び出します。このJavaコードは、スライドマスタを別のプレゼンテーションにクローンする方法を示しています：

```java
Presentation presSource = new Presentation();
Presentation presTarget = new Presentation();
try {
    IMasterSlide master = presTarget.getMasters().addClone(presSource.getMasters().get_Item(0));
} finally {
    if (presSource != null) presSource.dispose();
}
```

## **プレゼンテーションに複数のスライドマスタを追加**

Aspose.Slidesでは、任意のプレゼンテーションに複数のスライドマスタとスライドレイアウトを追加できます。これにより、プレゼンテーションスライドのスタイル、レイアウト、およびフォーマットオプションをさまざまな方法で設定できます。

PowerPointでは、新しいスライドマスタとレイアウトを（「スライドマスタメニュー」から）次のように追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slidesを使用すると、[**addClone**](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)メソッドを呼び出して新しいスライドマスタを追加できます：

```java
// 新しいマスタースライドを追加
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```

## **スライドマスタの比較**

マスタースライドは、スライドを比較するために使用できる[**equals**](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)メソッドを含む[IBaseSlide](https://reference.aspose.com/slides/java/com.aspose.slides/IBaseSlide)インターフェースを実装しています。このメソッドは、構造と静的コンテンツが同一のマスタースライドに対して`true`を返します。

2つのマスタースライドは、形状、スタイル、テキスト、アニメーション、その他の設定などが等しい場合に等しいと見なされます。比較には、ユニーク識別子値（例: SlideId）や動的コンテンツ（例: 日付プレースホルダ内の現在の日付の値）は考慮されません。

## **スライドマスタをプレゼンテーションのデフォルトビューとして設定**

Aspose.Slidesでは、スライドマスタをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるものです。このコードは、Javaでスライドマスタをプレゼンテーションのデフォルトビューとして設定する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化します
Presentation presentation = new Presentation();
try {
    // デフォルトビューをスライドマスタービューとして設定します
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // プレゼンテーションを保存します
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **未使用のマスタースライドを削除**

Aspose.Slidesは、不要で未使用のマスタースライドを削除できる[removeUnusedMasterSlides](https://reference.aspose.com/slides/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-)メソッド（[Compress](https://reference.aspose.com/slides/java/com.aspose.slides/compress/)クラスから）を提供します。このJavaコードは、PowerPointプレゼンテーションからマスタースライドを削除する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```