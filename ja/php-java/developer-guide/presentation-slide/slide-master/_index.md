---
title: PHPでプレゼンテーションのスライド マスターを管理
linktitle: スライド マスター
type: docs
weight: 70
url: /ja/php-java/slide-master/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Javaでスライド マスターを管理: PPT、PPTX、ODPにレイアウト、テーマ、プレースホルダーを作成、編集、適用する簡潔な例。"
---

## **PowerPoint のスライド マスターとは何か**

**Slide Master** はスライド テンプレートで、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義します。会社向けに同じスタイルとテンプレートのプレゼンテーション（または複数のプレゼンテーション）を作成したい場合は、スライド マスターを使用できます。

スライド マスターは、すべてのプレゼンテーション スライドの外観を一度に設定および変更できるため便利です。Aspose.Slides は PowerPoint のスライド マスター機構をサポートしています。

VBA でもスライド マスターを操作し、PowerPoint でサポートされている同じ操作（背景の変更、図形の追加、レイアウトのカスタマイズなど）を実行できます。Aspose.Slides はスライド マスターを利用して基本的なタスクを実行できる柔軟な機構を提供します。

これらは基本的なスライド マスター操作です:
- スライド マスターを作成する。
- スライド マスターをプレゼンテーションのスライドに適用する。
- スライド マスターの背景を変更する。
- スライド マスターに画像、プレースホルダー、SmartArt などを追加する。

これらはスライド マスターに関わる高度な操作です:
- スライド マスターを比較する。
- スライド マスターをマージする。
- 複数のスライド マスターを適用する。
- スライド マスター付きスライドを別のプレゼンテーションにコピーする。
- プレゼンテーション内の重複するスライド マスターを検出する。
- スライド マスターをプレゼンテーションのデフォルトビューに設定する。

{{% alert color="primary" %}} 
ここで説明している主要なプロセスのライブ実装であるため、Aspose の [**Online PowerPoint Viewer**](https://products.aspose.app/slides/viewer) をご確認いただくと良いでしょう。  
{{% /alert %}} 

## **スライド マスターはどのように適用されるか**

スライド マスターを操作する前に、プレゼンテーションでの使用方法とスライドへの適用方法を理解しておくと便利です。

* すべてのプレゼンテーションにはデフォルトで少なくとも 1 つのスライド マスターがあります。  
* プレゼンテーションは複数のスライド マスターを含めることができます。複数のスライド マスターを追加し、プレゼンテーションの異なる部分を異なる方法で装飾できます。  

**Aspose.Slides** では、スライド マスターは [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトは、[**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--) リストを含む [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) 型を保持し、プレゼンテーションで定義されたすべてのマスター スライドのリストが格納されています。

CRUD 操作に加えて、[IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/) インターフェイスは、[**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) と [**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-) メソッドを提供します。これらのメソッドは基本的なスライド複製機能から継承されていますが、スライド マスターを扱う際には複雑な設定を実装するために使用できます。

プレゼンテーションに新しいスライドを追加すると、スライド マスターが自動的に適用されます。デフォルトでは、直前のスライドのスライド マスターが選択されます。

**注**: プレゼンテーション スライドは [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--) リストに格納され、新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションに単一のスライド マスターしかない場合、そのスライド マスターがすべての新しいスライドに適用されます。これが、各新規スライドでスライド マスターを個別に指定する必要がない理由です。

PowerPoint と Aspose.Slides の原理は同じです。たとえば、PowerPoint では新しいスライドを追加する際、最後のスライドの下の行をクリックすると、前のプレゼンテーションのスライド マスターを使用した新しいスライドが作成されます。

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスの [addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) メソッドを使用して同等の操作を実行できます。

## **スライド階層におけるスライド マスター**

スライド レイアウトとスライド マスターを組み合わせることで、最大の柔軟性が得られます。スライド レイアウトは、スライド マスターと同じスタイル（背景、フォント、図形など）を設定できます。ただし、スライド マスター上で複数のスライド レイアウトが組み合わされると、新しいスタイルが生成されます。スライドにスライド レイアウトを適用すると、スライド マスターが適用したスタイルから変更できます。

スライド マスターはすべての設定項目の上位に位置します: スライド マスター → スライド レイアウト → スライド:

![todo:image_alt_text](slide-master_2)

各 [IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) オブジェクトは、スライド レイアウトのリストを保持する [**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--) プロパティを持ちます。[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) 型は、スライドに適用されたスライド レイアウトへの参照を保持する [**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--) プロパティを持ちます。スライドとスライド マスターのやり取りはスライド レイアウトを介して行われます。

{{% alert color="info" title="Note" %}} 
* Aspose.Slides では、すべてのスライド設定（スライド マスター、スライド レイアウト、スライド自体）は、実際には [**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) インターフェイスを実装したスライド オブジェクトです。  
* したがって、スライド マスターとスライド レイアウトは同じプロパティを実装している可能性があり、それらの値が [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) オブジェクトにどのように適用されるかを理解する必要があります。スライド マスターが最初にスライドに適用され、その後スライド レイアウトが適用されます。たとえば、スライド マスターとスライド レイアウトの両方に背景が設定されている場合、最終的にスライドはスライド レイアウトの背景を使用します。  
{{% /alert %}}

## **スライド マスターに含まれるもの**

スライド マスターを変更する方法を理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) の主要プロパティです。

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) スライドの背景を取得/設定します。  
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) スライド本体のテキストスタイルを取得/設定します。  
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) スライド マスターのすべての図形（プレースホルダー、画像フレームなど）を取得/設定します。  
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) ActiveX コントロールを取得/設定します。  
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) テーママネージャーを取得します。  
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) ヘッダーおよびフッターマネージャーを取得します。  

スライド マスターのメソッド:
- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) スライド マスターに依存するすべてのスライドを取得します。  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) 現在のスライド マスターと新しいテーマに基づいて新しいスライド マスターを作成し、依存するすべてのスライドに適用できます。  

## **スライド マスターの取得**

PowerPoint では、[表示] → [スライド マスター] メニューからスライド マスターにアクセスできます。

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides を使用すると、次のようにスライド マスターにアクセスできます:  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションのマスタースライドにアクセスします
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


[IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide) インターフェイスはスライド マスターを表します。[Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--) プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) 型に関連）には、プレゼンテーションで定義されたすべてのスライド マスターのリストが含まれています。  

## **スライド マスターに画像を追加する**

スライド マスターに画像を追加すると、その画像はそのマスターに依存するすべてのスライドに表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides でスライド マスターに画像を追加できます:  
```php
  $pres = new Presentation();
  try {
    $picture;
    $image = Images->fromFile("image.png");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $pres->getMasters()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 10, 10, 100, 100, $picture);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="See also" %}} 
スライドへの画像追加に関する詳細は、[Picture Frame](/slides/ja/php-java/picture-frame/#create-picture-frame) 記事をご覧ください。  
{{% /alert %}}

## **スライド マスターにプレースホルダーを追加する**

以下のテキスト フィールドはスライド マスターの標準プレースホルダーです。

* マスター タイトル スタイルの編集をクリック  
* マスターテキスト スタイルの編集  
* 第2レベル  
* 第3レベル  

これらはスライド マスターに基づくスライドにも表示されます。スライド マスター上でプレースホルダーを編集すると、変更がスライドに自動的に適用されます。

PowerPoint では、[スライド マスター] → [プレースホルダーの挿入] パスを使用してプレースホルダーを追加できます:

![todo:image_alt_text](slide-master_5.png)

Aspose.Slides を使用したプレースホルダーのより複雑な例を見てみましょう。スライド マスターからテンプレート化されたプレースホルダーを含むスライドを考えます。

![todo:image_alt_text](slide-master_6.png)

スライド マスター上でタイトルとサブタイトルの書式を次のように変更したいとします:

![todo:image_alt_text](slide-master_7.png)

まず、スライド マスターオブジェクトからタイトル プレースホルダーの内容を取得し、`PlaceHolder.FillFormat` フィールドを使用します:  
```php

```


タイトルのスタイルと書式は、スライド マスターに基づくすべてのスライドで変更されます:

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [プレースホルダーでプロンプト テキストを設定](https://docs.aspose.com/slides/php-java/manage-placeholder/)  
* [テキスト書式設定](https://docs.aspose.com/slides/php-java/text-formatting/)  
{{% /alert %}}

## **スライド マスターの背景を変更する**

マスター スライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。この PHP コードはその操作を示しています。

```php
  $pres = new Presentation();
  try {
    $master = $pres->getMasters()->get_Item(0);
    $master->getBackground()->setType(BackgroundType::OwnBackground);
    $master->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $master->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert color="primary" title="See also" %}} 
- [プレゼンテーションの背景]  
- [プレゼンテーションのテーマ]  
{{% /alert %}}

## **スライド マスターを別のプレゼンテーションにクローンする**

スライド マスターを別のプレゼンテーションにクローンするには、宛先プレゼンテーションから [**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出し、対象のスライド マスターを渡します。この PHP コードはスライド マスターを別のプレゼンテーションにクローンする方法を示しています。

```php
  $presSource = new Presentation();
  $presTarget = new Presentation();
  try {
    $master = $presTarget->getMasters()->addClone($presSource->getMasters()->get_Item(0));
  } finally {
    if (!java_is_null($presSource)) {
      $presSource->dispose();
    }
  }
```


## **プレゼンテーションに複数のスライド マスターを追加する**

Aspose.Slides を使用すると、任意のプレゼンテーションに複数のスライド マスターとスライド レイアウトを追加できます。これにより、プレゼンテーション スライドのスタイル、レイアウト、書式設定オプションを多様に設定できます。

PowerPoint では、次のようにして新しいスライド マスターとレイアウト（[スライド マスターメニュー]）を追加できます。

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、[**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) メソッドを呼び出して新しいスライド マスターを追加できます。  
```php
  # 新しいマスタースライドを追加
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```


## **スライド マスターを比較する**

マスター スライドは [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) インターフェイスを実装しており、[**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-) メソッドが提供されます。このメソッドを使用してスライドを比較でき、構造と静的コンテンツが同一のマスター スライドに対しては `true` を返します。

2 つのマスター スライドは、図形、スタイル、テキスト、アニメーションなどの設定がすべて同じ場合に等しいとみなされます。比較では、固有の識別子（例: SlideId）や動的コンテンツ（例: 日付プレースホルダーの現在の日付値）は考慮されません。

## **スライド マスターをプレゼンテーションのデフォルトビューに設定する**

Aspose.Slides では、スライド マスターをプレゼンテーションのデフォルトビューに設定できます。デフォルトビューとは、プレゼンテーションを開いたときに最初に表示されるビューです。

以下のコードは、スライド マスターをプレゼンテーションのデフォルトビューに設定する方法を示しています。

```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します
  $presentation = new Presentation();
  try {
    # デフォルトのビューを SlideMasterView に設定します
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # プレゼンテーションを保存します
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **未使用のマスター スライドを削除する**

Aspose.Slides は、不要または未使用のマスター スライドを削除できるように、[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) クラスの [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) メソッドを提供しています。この PHP コードは、PowerPoint プレゼンテーションからマスター スライドを削除する方法を示しています。

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**PowerPoint のスライド マスターとは何ですか？**  
スライド マスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライド テンプレートです。すべてのプレゼンテーション スライドの外観を一括で設定および変更できるようにします。

**スライド マスターはプレゼンテーションでどのように適用されますか？**  
すべてのプレゼンテーションにはデフォルトで少なくとも 1 つのスライド マスターがあります。新しいスライドが追加されると、スライド マスターが自動的に適用され、通常は前のスライドのマスターが継承されます。プレゼンテーションは複数のスライド マスターを持ち、異なる部分を個別に装飾できます。

**スライド マスターでカスタマイズできる要素は何ですか？**  
スライド マスターは以下の主要プロパティをカスタマイズできます:

- **Background**: スライドの背景を設定します。  
- **BodyStyle**: スライド本体のテキストスタイルを定義します。  
- **Shapes**: プレースホルダーや画像フレームなど、スライド マスター上のすべての図形を管理します。  
- **Controls**: ActiveX コントロールを処理します。  
- **ThemeManager**: テーママネージャーにアクセスします。  
- **HeaderFooterManager**: ヘッダーとフッターを管理します。  

**スライド マスターに画像を追加するにはどうすればよいですか？**  
スライド マスターに画像を追加すると、その画像はそのマスターに依存するすべてのスライドに表示されます。たとえば、会社のロゴをスライド マスターに配置すると、プレゼンテーション内のすべてのスライドにロゴが表示されます。

**スライド マスターとスライド レイアウトの関係は？**  
スライド レイアウトはスライド マスターと連携してスライド デザインの柔軟性を提供します。スライド マスターが全体的なスタイルとテーマを定義し、スライド レイアウトがコンテンツ配置のバリエーションを可能にします。階層は次のとおりです:

- **スライド マスター** → グローバルスタイルを定義  
- **スライド レイアウト** → 異なるコンテンツ配置を提供  
- **スライド** → そのスライド レイアウトからデザインを継承  

**1つのプレゼンテーションに複数のスライド マスターを持てますか？**  
はい、プレゼンテーションは複数のスライド マスターを保持できます。これにより、プレゼンテーションの異なるセクションを様々な方法で装飾でき、デザインの柔軟性が向上します。

**Aspose.Slides でスライド マスターにアクセスし、変更するには？**  
Aspose.Slides では、スライド マスターは [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) クラスで表されます。プレゼンテーション オブジェクトの [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) メソッドを使用してスライド マスターにアクセスできます。