---
title: JavaScript でプレゼンテーション スライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/nodejs-java/slide-master/
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
- マスタースライドの複製
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js のスライドマスターを管理: 簡潔な例で PPT、PPTX、ODP にレイアウト、テーマ、プレースホルダーを作成、編集、適用する。"
---

## **PowerPoint のスライドマスターとは**

**Slide Master** は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。企業で同じスタイルとテンプレートのプレゼンテーション（またはシリーズ）を作成したい場合は、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの外観を一括で設定および変更できるため便利です。Aspose.Slides は PowerPoint のスライドマスター機構をサポートしています。

VBA でもスライドマスターを操作でき、PowerPoint でサポートされている同様の操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slides はスライドマスターを使用し、基本的なタスクを柔軟に実行できるメカニズムを提供します。

これらは基本的なスライドマスター操作です：

- スライドマスターを作成または取得。
- スライドマスターをプレゼンテーションのスライドに適用。
- スライドマスターの背景を変更。
- スライドマスターに画像、プレースホルダー、Smart Art などを追加。

これらはスライドマスターに関わる高度な操作です：

- スライドマスターを比較。
- スライドマスターをマージ。
- 複数のスライドマスターを適用。
- スライドマスター付きのスライドを別のプレゼンテーションにコピー。
- プレゼンテーション内の重複スライドマスターを検出。
- スライドマスターをプレゼンテーションのデフォルトビューとして設定。

{{% alert color="primary" %}} 
Aspose の [**オンライン PowerPoint ビューア**](https://products.aspose.app/slides/viewer) を確認すると便利です。これは、ここで説明した主要なプロセスの実装例です。
{{% /alert %}} 

## **スライドマスターはどのように適用されるか**

スライドマスターを操作する前に、プレゼンテーションでの使用方法とスライドへの適用方法を理解しておくとよいでしょう。

* すべてのプレゼンテーションにはデフォルトで少なくとも 1 つのスライドマスターがあります。  
* プレゼンテーションは複数のスライドマスターを含めることができます。複数のスライドマスターを追加して、プレゼンテーションの異なる部分を異なる方法でスタイル設定できます。

**Aspose.Slides** では、スライドマスターは [**MasterSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) オブジェクトは、[**getMasters**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters--) プロパティで [**MasterSlideCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) 型のリストを保持し、プレゼンテーションで定義されたすべてのマスタースライドの一覧を取得できます。

CRUD 操作に加えて、[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/) クラスは次の便利なメソッドを提供します： [**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterlayoutslidecollection/#addClone-aspose.slides.ILayoutSlide-) と [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslidecollection/#insertClone-int-aspose.slides.IMasterSlide-)。これらのメソッドは基本的なスライドクローン機能から継承されますが、スライドマスターを扱う場合は複雑な設定を実装するために利用できます。

新しいスライドがプレゼンテーションに追加されると、スライドマスターが自動的に適用されます。デフォルトでは前のスライドのスライドマスターが選択されます。

**注**: プレゼンテーションのスライドは [getSlides()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides--) リストに格納され、新しいスライドは既定でコレクションの末尾に追加されます。プレゼンテーションに単一のスライドマスターしか存在しない場合、そのスライドマスターがすべての新規スライドに適用されます。これが、各スライドごとにスライドマスターを明示的に定義する必要がない理由です。

PowerPoint と Aspose.Slides の原理は同じです。たとえば PowerPoint では、最後のスライドの下側の線をクリックすると、前のスライドのスライドマスターを継承した新しいスライドが作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) メソッドを使用して同等の操作を実行できます。

## **スライド階層におけるスライドマスター**

スライドレイアウトとスライドマスターを組み合わせることで、最大限の柔軟性が得られます。スライドレイアウトはスライドマスターと同じスタイル（背景、フォント、図形など）を設定できますが、スライドマスター上に複数のスライドレイアウトが組み合わさると新しいスタイルが生成されます。スライドレイアウトを単一のスライドに適用すると、スライドマスターが適用したスタイルから変更できます。

スライドマスターはすべての設定項目の上位にあります： スライドマスター → スライドレイアウト → スライド：

![todo:image_alt_text](slide-master_2)

各 [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) オブジェクトは、[**getLayoutSlides**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getLayoutSlides--) プロパティでスライドレイアウトの一覧を取得できます。[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) 型は、[**getLayoutSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide#getLayoutSlide--) プロパティでスライドに適用されたレイアウトへの参照を保持します。スライドとスライドマスターの相互作用はスライドレイアウトを介して行われます。

{{% alert color="info" title="注" %}}
* Aspose.Slides では、すべてのスライド設定（スライドマスター、スライドレイアウト、スライド自体）は実際には [**BaseSlide**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) クラスを実装するスライドオブジェクトです。  
* したがって、スライドマスターとスライドレイアウトは同じプロパティを実装している可能性があり、どの値が [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Slide) オブジェクトに適用されるかを理解する必要があります。スライドマスターが最初に適用され、その後にスライドレイアウトが適用されます。たとえば、スライドマスターとスライドレイアウトの両方に背景が設定されている場合、最終的なスライドはスライドレイアウトの背景を使用します。
{{% /alert %}}

## **スライドマスターの構成要素**

スライドマスターを変更する方法を理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) のコアプロパティです。

- [getBackground](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getBackground--) – スライドの背景を取得/設定。  
- [getBodyStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getBodyStyle--) – スライド本文のテキストスタイルを取得/設定。  
- [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getShapes--) – スライドマスター上のすべての図形（プレースホルダー、画像フレームなど）を取得/設定。  
- [getControls](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getControls--) – ActiveX コントロールを取得/設定。  
- [getThemeManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getThemeManager) – テーママネージャーを取得。  
- [getHeaderFooterManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getHeaderFooterManager--) – ヘッダーとフッターのマネージャーを取得。

スライドマスターのメソッド：

- [getDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#getDependingSlides--) – このスライドマスターに依存するすべてのスライドを取得。  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) – 現在のスライドマスターと新しいテーマから新しいスライドマスターを作成し、依存スライドすべてに適用します。

## **スライドマスターの取得**

PowerPoint では、[ビュー] → [スライドマスター] メニューからスライドマスターにアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides を使用すると、次のようにスライドマスターにアクセスできます：  
```javascript
var pres = new aspose.slides.Presentation();
try {
    // プレゼンテーションのマスタースライドへのアクセスを提供します
    var masterSlide = pres.getMasters().get_Item(0);
} finally {
    pres.dispose();
}
```


[MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlide) クラスはスライドマスターを表します。[Masters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getMasters--) プロパティ（[MasterSlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/MasterSlideCollection) 型）は、プレゼンテーションで定義されたすべてのスライドマスターの一覧を保持します。

## **スライドマスターへの画像追加**

スライドマスターに画像を追加すると、その画像はマスターに依存するすべてのスライドに表示されます。

たとえば、企業ロゴやいくつかの画像をスライドマスターに配置すると、スライド編集モードに戻ったときにすべてのスライドでロゴが表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides を使用してスライドマスターに画像を追加できます：  
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


{{% alert color="primary" title="参照" %}} 
スライドへの画像追加の詳細は、[画像フレーム](/slides/ja/nodejs-java/picture-frame/#create-picture-frame) 記事をご参照ください。
{{% /alert %}}

## **スライドマスターへのプレースホルダー追加**

これらのテキストフィールドはスライドマスター上の標準プレースホルダーです：

* マスタータイトルスタイルを編集するにはクリック
* マスターテキストスタイルを編集
* 第2レベル
* 第3レベル

これらはスライドマスターに基づくスライドにも表示されます。プレースホルダーをスライドマスター上で編集すると、変更は自動的にスライドに反映されます。

PowerPoint では、[スライドマスター] → [プレースホルダーの挿入] パスからプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

Aspose.Slides でのプレースホルダーのより複雑な例を見てみましょう。スライドマスターからテンプレート化されたプレースホルダーを含むスライドの例です：

![todo:image_alt_text](slide-master_6.png)

次のようにスライドマスター上でタイトルとサブタイトルの書式設定を変更します：

![todo:image_alt_text](slide-master_7.png)

まず、スライドマスターオブジェクトからタイトルプレースホルダーの内容を取得し、`PlaceHolder.FillFormat` フィールドを使用します：  
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


タイトルのスタイルと書式が、スライドマスターに基づくすべてのスライドで変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="参照" %}} 
* [プレースホルダーへのプロンプトテキストの設定](https://docs.aspose.com/slides/nodejs-java/manage-placeholder/)  
* [テキストの書式設定](https://docs.aspose.com/slides/nodejs-java/text-formatting/)
{{% /alert %}}

## **スライドマスターの背景変更**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。この JavaScript コードはその操作を示しています：  
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


{{% alert color="primary" title="参照" %}} 
- [プレゼンテーションの背景](https://docs.aspose.com/slides/nodejs-java/presentation-background/)  
- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/nodejs-java/presentation-theme/)
{{% /alert %}}

## **スライドマスターを別のプレゼンテーションにクローンする**

目的のプレゼンテーションからスライドマスターを渡し、[**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) メソッドを呼び出すことで、スライドマスターを別のプレゼンテーションにクローンできます。この JavaScript コードはクローン方法を示しています：  
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


## **プレゼンテーションに複数のスライドマスターを追加**

Aspose.Slides は任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できるため、スライドのスタイル、レイアウト、書式設定オプションを多様に構成できます。

PowerPoint では、[スライドマスターメニュー] から新しいスライドマスターとレイアウトを次のように追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、[**addClone**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) メソッドを呼び出して新しいスライドマスターを追加できます：  
```javascript
// 新しいマスタースライドを追加します
var secondMasterSlide = pres.getMasters().addClone(masterSlide);
```


## **スライドマスターの比較**

MasterSlide は [BaseSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide) クラスを実装し、[**equals**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#equals-aspose.slides.IBaseSlide-) メソッドを提供します。このメソッドを使用してスライドを比較できます。構造と静的コンテンツが同一のマスタースライドに対しては `true` が返されます。

2 つのマスタースライドは、形状、スタイル、テキスト、アニメーション、その他の設定がすべて等しい場合に等価とみなされます。比較はスライド ID などの固有識別子や、日付プレースホルダーの現在の日付といった動的コンテンツは考慮しません。

## **スライドマスターをプレゼンテーションのデフォルトビューに設定**

Aspose.Slides はスライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューはプレゼンテーションを開いたときに最初に表示されるビューです。

このコードは JavaScript でスライドマスターをプレゼンテーションのデフォルトビューに設定する方法を示しています：  
```javascript
// プレゼンテーションファイルを表す Presentation クラスをインスタンス化します
var presentation = new aspose.slides.Presentation();
try {
    // デフォルトビューを SlideMasterView に設定します
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    // プレゼンテーションを保存します
    presentation.save("PresView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```


## **未使用のマスタースライドの削除**

Aspose.Slides は [Compress](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/) クラスの [removeUnusedMasterSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) メソッドを提供し、不要または未使用のマスタースライドを削除できます。この JavaScript コードは PowerPoint プレゼンテーションからマスタースライドを削除する方法を示しています：  
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

**PowerPoint のスライドマスターとは何ですか？**

スライドマスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライドテンプレートです。これにより、すべてのプレゼンテーションスライドの外観を一括で設定および変更できます。

**スライドマスターはプレゼンテーションでどのように適用されますか？**

すべてのプレゼンテーションにはデフォルトで少なくとも 1 つのスライドマスターがあります。新しいスライドが追加されると、スライドマスターが自動的に適用され、通常は前のスライドのマスターを継承します。プレゼンテーションは複数のスライドマスターを含めて、異なる部分を個別にスタイル設定できます。

**スライドマスターでカスタマイズできる要素は何ですか？**

スライドマスターは次のコアプロパティで構成され、カスタマイズ可能です：

- **Background**：スライドの背景を設定。  
- **BodyStyle**：スライド本文のテキストスタイルを定義。  
- **Shapes**：プレースホルダーや画像フレームを含む、スライドマスター上のすべての図形を管理。  
- **Controls**：ActiveX コントロールを処理。  
- **ThemeManager**：テーママネージャーにアクセス。  
- **HeaderFooterManager**：ヘッダーとフッターを管理。

**スライドマスターに画像を追加するにはどうすればよいですか？**

スライドマスターに画像を追加すると、その画像はマスターに依存するすべてのスライドに表示されます。たとえば、会社ロゴをスライドマスターに配置すると、プレゼンテーション内のすべてのスライドにロゴが表示されます。

**スライドマスターとスライドレイアウトの関係は？**

スライドレイアウトはスライドマスターと連携してスライドデザインの柔軟性を提供します。スライドマスターが全体的なスタイルとテーマを定義し、スライドレイアウトがコンテンツ配置のバリエーションを可能にします。階層は次のとおりです：

- **Slide Master** → グローバルスタイルを定義。  
- **Slide Layout** → 異なるコンテンツ配置を提供。  
- **Slide** → Slide Layout からデザインを継承。

**1 つのプレゼンテーションに複数のスライドマスターを持つことはできますか？**

はい、プレゼンテーションは複数のスライドマスターを含められます。これにより、プレゼンテーションの異なるセクションを様々な方法でスタイル設定でき、デザインの柔軟性が向上します。

**Aspose.Slides でスライドマスターにアクセスして変更するには？**

Aspose.Slides では、スライドマスターは [MasterSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーションオブジェクトの [getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/getmasters/) メソッドを使用してスライドマスターにアクセスできます。