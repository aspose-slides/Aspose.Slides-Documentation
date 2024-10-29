---
title: スライドマスター
type: docs
weight: 70
url: /ja/androidjava/slide-master/
keywords: "スライドマスターを追加, PPTマスタースライド, スライドマスターパワーポイント, 画像をスライドマスターに追加, プレースホルダー, 複数のスライドマスター, スライドマスターを比較, Java, Aspose.Slides for Android via Java"
description: "JavaでのPowerPointプレゼンテーション内のスライドマスターを追加または編集する"
---

## **PowerPointにおけるスライドマスターとは**

**スライドマスター**は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。同じスタイルとテンプレートで会社のプレゼンテーション（またはいくつかのプレゼンテーション）を作成したい場合は、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの見た目を一度に設定および変更できるため便利です。Aspose.Slidesは、PowerPointからのスライドマスター機構をサポートしています。

VBAもスライドマスターを操作し、背景の変更、形状の追加、レイアウトのカスタマイズなど、PowerPointでサポートされている同じ操作を実行できます。Aspose.Slidesは、スライドマスターを使用し、それに対して基本的な操作を実行するための柔軟なメカニズムを提供します。

これらは基本的なスライドマスターの操作です：

- スライドマスターを作成またはスライドマスター。
- プレゼンテーションスライドにスライドマスターを適用する。
- スライドマスターの背景を変更する。
- スライドマスターに画像、プレースホルダー、スマートアートなどを追加する。

これらはスライドマスターに関するより高度な操作です：

- スライドマスターを比較する。
- スライドマスターをマージする。
- 複数のスライドマスターを適用する。
- スライドマスター付きのスライドを別のプレゼンテーションにコピーする。
- プレゼンテーション内で重複したスライドマスターを見つける。
- スライドマスターをプレゼンテーションのデフォルトビューとして設定する。

{{% alert color="primary" %}} 

実際にここで説明されているいくつかのコアプロセスのライブ実装であるAspose [**オンラインPowerPointビューワー**](https://products.aspose.app/slides/viewer)を確認すると良いでしょう。

{{% /alert %}} 

## **スライドマスターの適用方法**

スライドマスターで作業する前に、プレゼンテーション内でどのように使用され、スライドに適用されるかを理解したいかもしれません。

* すべてのプレゼンテーションにはデフォルトで少なくとも1つのスライドマスターがあります。
* プレゼンテーションには複数のスライドマスターを含めることができます。複数のスライドマスターを追加し、プレゼンテーションの異なる部分に異なるスタイルを適用することができます。

**Aspose.Slides**では、スライドマスターは [**IMasterSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) タイプで表されます。

Aspose.Slidesの [プレゼンテーション](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)オブジェクトは、プレゼンテーション内で定義されているすべてのマスタースライドのリストを含む [**getMasters**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) のリストを含む [**IMasterSlideCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) 型を含んでいます。

CRUD操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) インターフェイスには、[**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) および [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) メソッドが含まれています。これらのメソッドは基本的なスライド複製機能から継承されていますが、スライドマスターを扱う場合は、これらのメソッドにより複雑な設定を実装できます。

新しいスライドがプレゼンテーションに追加されると、スライドマスターが自動的に適用されます。前のスライドのスライドマスターがデフォルトで選択されます。

**注意**: プレゼンテーションスライドは [getSlides()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) リストに保存され、すべての新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションに単一のスライドマスターが含まれている場合、そのスライドマスターはすべての新しいスライドに選択されます。これは、新しいスライドを作成する際に毎回スライドマスターを定義する必要がない理由です。

原則はPowerPointとAspose.Slidesで同じです。たとえば、PowerPointでは、新しいプレゼンテーションを追加すると、最後のスライドの下の下線を押すだけで、新しいスライド（最後のプレゼンテーションのスライドマスター付き）が作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slidesでは、[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスの [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) メソッドを使って同等の作業を行うことができます。

## **スライドの階層におけるスライドマスター**

スライドマスターを使用したスライドレイアウトは最大の柔軟性を可能にします。スライドレイアウトは、スライドマスターと同様のすべてのスタイルを設定できます（背景、フォント、形状など）。ただし、複数のスライドレイアウトがスライドマスターに結合されると、新しいスタイルが作成されます。スライドマスターによって適用されたスタイルから、スライドにスライドレイアウトを適用することで、そのスタイルを変更できます。

スライドマスターはすべての設定項目よりも優先されます：スライドマスター -> スライドレイアウト -> スライド：

![todo:image_alt_text](slide-master_2)

各 [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) オブジェクトには、スライドレイアウトのリストを持つ [**getLayoutSlides**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getLayoutSlides--) プロパティがあります。 [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) タイプには、スライドに適用されたスライドレイアウトのリンクを持つ [**getLayoutSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlide#getLayoutSlide--) プロパティがあります。スライドとスライドマスターとの相互作用はスライドレイアウトを介して行われます。

{{% alert color="info" title="注意" %}}

* Aspose.Slidesでは、すべてのスライド設定（スライドマスター、スライドレイアウト、スライド自体）は実際には [**IBaseSlide**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェイスを実装するスライドオブジェクトです。
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装する可能性があり、それらの値が [Slide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Slide) オブジェクトにどのように適用されるかを知っておく必要があります。まずスライドマスターがスライドに適用され、次にスライドレイアウトが適用されます。たとえば、スライドマスターとスライドレイアウトの両方が背景値を持つ場合、スライドはスライドレイアウトからの背景を持つことになります。

{{% /alert %}}

## **スライドマスターの構成要素**

スライドマスターがどのように変更されるかを理解するには、その構成要素を知っておく必要があります。これらは [MasterSlide](https://reference.aspose.com/slides/androidjava/aspose.slides/masterslide/) のコアプロパティです。

- [getBackground](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getBackground--) スライドの背景を取得/設定する。
- [getBodyStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getBodyStyle--) - スライドの本文のテキストスタイルを取得/設定する。
- [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getShapes--) スライドマスターのすべての形状（プレースホルダー、画像枠など）を取得/設定する。
- [getControls](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#getControls--) ActiveXコントロールを取得/設定する。
- [getThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterThemeable#getThemeManager--) - テーママネージャーを取得する。
- [getHeaderFooterManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getHeaderFooterManager--) - ヘッダーとフッターマネージャーを取得する。

スライドマスターのメソッド：

- [getDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#getDependingSlides--) - スライドマスターに依存するすべてのスライドを取得する。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - 現在のスライドマスターと新しいテーマに基づいて新しいスライドマスターを作成することを可能にします。新しいスライドマスターは、その後、すべての依存スライドに適用されます。

## **スライドマスターを取得する**

PowerPointでは、スライドマスターは表示 -> スライドマスターメニューからアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slidesを使用すると、次のようにスライドマスターにアクセスできます：

```java
Presentation pres = new Presentation();
try {
    // プレゼンテーションのマスタースライドにアクセス
    IMasterSlide masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```

[IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlide) インターフェイスはスライドマスターを表します。[Masters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#getMasters--) プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IMasterSlideCollection) タイプに関連）は、プレゼンテーション内で定義されたすべてのスライドマスターのリストを含みます。

## **スライドマスターに画像を追加する**

スライドマスターに画像を追加すると、その画像はそのスライドマスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴやいくつかの画像をスライドマスターに配置し、再びスライド編集モードに戻ることができます。すべてのスライドに画像が表示されるはずです。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slidesを使用してスライドマスターに画像を追加できます：

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

スライドに画像を追加する詳細については、[画像フレーム](/slides/ja/androidjava/picture-frame/#create-picture-frame)の記事を参照してください。
{{% /alert %}}

## **スライドマスターにプレースホルダーを追加する**

これらのテキストフィールドはスライドマスターの標準プレースホルダーです：

* マスタータイトルスタイルを編集するにはクリック
* マスターテキストスタイルを編集
* 第二レベル
* 第三レベル

これらもスライドマスターに基づくスライドに表示されます。スライドマスターでこれらのプレースホルダーを編集すると、変更がスライドに自動的に適用されます。

PowerPointでは、スライドマスター -> プレースホルダーの挿入パスを通じてプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

Aspose.Slidesでプレースホルダーのより複雑な例を検討してみましょう。スライドがスライドマスターからテンプレート化されたプレースホルダーを持つ場合を考えます：

![todo:image_alt_text](slide-master_6.png)

スライドマスターでタイトルとサブタイトルの書式を次のように変更したいとします：

![todo:image_alt_text](slide-master_7.png)

まず、スライドマスターオブジェクトからタイトルプレースホルダーの内容を取得し、`PlaceHolder.FillFormat`フィールドを使用します：

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

タイトルスタイルと書式がスライドマスターに基づくすべてのスライドで変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="関連情報" %}} 

* [プレースホルダーにプロンプトテキストを設定する](https://docs.aspose.com/slides/androidjava/manage-placeholder/)
* [テキスト書式設定](https://docs.aspose.com/slides/androidjava/text-formatting/)

{{% /alert %}}

## **スライドマスターの背景を変更する**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常のスライドが新しい色になります。このJavaコードはその操作を示しています：

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

- [プレゼンテーションの背景](https://docs.aspose.com/slides/androidjava/presentation-background/)

- [プレゼンテーションテーマ](https://docs.aspose.com/slides/androidjava/presentation-theme/)

{{% /alert %}}

## **スライドマスターを別のプレゼンテーションに複製する**

スライドマスターを別のプレゼンテーションに複製するには、宛先プレゼンテーションからの [**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出し、そこに渡すスライドマスターを指定します。このJavaコードは、スライドマスターを別のプレゼンテーションに複製する方法を示しています：

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

Aspose.Slidesを使用すると、任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できます。これにより、プレゼンテーションスライドに対してさまざまな方法でスタイル、レイアウト、および書式設定オプションを設定できます。

PowerPointでは、次のように新しいスライドマスターとレイアウトを追加できます（「スライドマスターメニュー」から）：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slidesを使用すると、[**addClone**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出すことで新しいスライドマスターを追加できます：

```java
// 新しいマスタースライドを追加
IMasterSlide secondMasterSlide = pres.getMasters().addClone(masterSlide);
```

## **スライドマスターを比較する**

マスタースライドは [IBaseSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide) インターフェイスを実装しており、[**equals**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) メソッドを含んでおり、これを使用してスライドを比較できます。構造と静的コンテンツが同一のマスタースライドについては、`true`を返します。

2つのマスタースライドが等しいのは、それらの形状、スタイル、テキスト、アニメーションおよびその他の設定が等しい場合です。比較は、固有の識別子値（例: SlideId）や動的コンテンツ（例: 日付プレースホルダーの現在の日付値）を考慮しません。

## **スライドマスターをプレゼンテーションのデフォルトビューとして設定する**

Aspose.Slidesを使用すると、スライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューは、プレゼンテーションを開いたときに最初に表示されるものです。

このコードは、Javaでスライドマスターをプレゼンテーションのデフォルトビューとして設定する方法を示しています：

```java
// プレゼンテーションファイルを表すPresentationクラスをインスタンス化
Presentation presentation = new Presentation();
try {
    // デフォルトビューをスライドマスタービューに設定
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);

    // プレゼンテーションを保存
    presentation.save("PresView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **未使用のマスタースライドを削除する**

Aspose.Slidesは、不要で未使用のマスタースライドを削除するための [removeUnusedMasterSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッド（[Compress](https://reference.aspose.com/slides/androidjava/com.aspose.slides/compress/) クラスから）を提供します。このJavaコードは、PowerPointプレゼンテーションからマスタースライドを削除する方法を示しています：

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```