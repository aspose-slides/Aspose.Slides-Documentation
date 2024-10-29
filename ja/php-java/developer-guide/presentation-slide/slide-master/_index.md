---
title: スライド マスター
type: docs
weight: 70
url: /ja/php-java/slide-master/
keywords: "スライド マスターの追加, PPTマスター スライド, スライド マスター PowerPoint, スライド マスターへの画像追加, プレースホルダー, 複数のスライド マスター, スライド マスターの比較, Java, Aspose.Slides for PHP via Java"
description: "PowerPoint プレゼンテーションのスライド マスターを追加または編集する"
---

## **PowerPoint におけるスライド マスターとは**

**スライド マスター**は、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するスライド テンプレートです。同じスタイルとテンプレートで会社のためにプレゼンテーション (またはシリーズ) を作成したい場合、スライド マスターを使用できます。

スライド マスターは、すべてのプレゼンテーション スライドの外観を一度に設定および変更できるため便利です。Aspose.Slidesは、PowerPointのスライド マスター メカニズムをサポートしています。

VBAもスライド マスターを操作し、背景の変更、図形の追加、レイアウトのカスタマイズなど、PowerPointでサポートされているのと同じ操作を実行することができます。Aspose.Slidesは、スライド マスターを使用し、基本的なタスクを実行するための柔軟なメカニズムを提供します。

これらは基本的なスライド マスター操作です：

- スライド マスターの作成または追加。
- プレゼンテーション スライドにスライド マスターを適用する。
- スライド マスターの背景を変更する。
- スライド マスターに画像、プレースホルダー、スマート アートなどを追加する。

これらはスライド マスターに関するより高度な操作です：

- スライド マスターの比較。
- スライド マスターのマージ。
- 複数のスライド マスターを適用する。
- スライドとスライド マスターを別のプレゼンテーションにコピーする。
- プレゼンテーション内の重複したスライド マスターを特定する。
- スライド マスターをプレゼンテーションのデフォルト ビューとして設定する。

{{% alert color="primary" %}} 

Asposeの[**オンライン PowerPoint ビューア**](https://products.aspose.app/slides/viewer)をチェックしてみることをお勧めします。これは、ここで説明したいくつかのコア プロセスのライブ実装です。

{{% /alert %}} 


## **スライド マスターの適用方法**

スライド マスターで作業する前に、それらがプレゼンテーションでどのように使用され、スライドに適用されるかを理解しておくと良いでしょう。

* すべてのプレゼンテーションには、デフォルトで少なくとも1つのスライド マスターがあります。 
* プレゼンテーションには複数のスライド マスターを含めることができます。複数のスライド マスターを追加し、異なる方法でプレゼンテーションのさまざまな部分のスタイルを設定できます。

**Aspose.Slides**では、スライド マスターは [**IMasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslide/)タイプで表されます。

Aspose.Slidesの[プレゼンテーション ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)オブジェクトには、プレゼンテーション内に定義されたすべてのマスタースライドのリストを含む[**getMasters** ](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--)の [**IMasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/)タイプが含まれています。

CRUD操作に加え、[IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/)インターフェイスには、[**addClone(ILayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-)および[**insertClone(int index, IMasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/imasterslidecollection/#insertClone-int-com.aspose.slides.IMasterSlide-)メソッドなどの便利なメソッドが含まれています。これらのメソッドは、基本的なスライド クローン機能から継承されます。しかし、スライド マスターを扱う際には、これらのメソッドを使用して複雑なセットアップを実装できるようになります。

プレゼンテーションに新しいスライドが追加されると、スライド マスターが自動的に適用されます。前のスライドのスライド マスターがデフォルトで選択されます。

**注**: プレゼンテーションスライドは[getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides--)リストに格納され、新しいスライドはデフォルトでコレクションの最後に追加されます。プレゼンテーションに単一のスライド マスターが含まれている場合、そのスライド マスターはすべての新しいスライドに選択されます。これは、作成する新しいスライドごとにスライド マスターを定義する必要がない理由です。

この原則は、PowerPointとAspose.Slidesで同じです。たとえば、PowerPointで新しいプレゼンテーションを追加するとき、最後のスライドの下のボトムラインを押すだけで、新しいスライド (最後のプレゼンテーションのスライド マスターを使用) が作成されます。

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slidesでは、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスの下で[addClone(ISlide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-)メソッドを使用して同等のタスクを実行できます。


## **スライド階層におけるスライド マスター**

スライド マスターを使用したスライド レイアウトにより、最大限の柔軟性が得られます。スライド レイアウトでは、スライド マスターと同じスタイル (背景、フォント、図形など) をすべて設定できます。ただし、複数のスライド レイアウトがスライド マスターに組み合わされると、新しいスタイルが作成されます。スライド マスターによって適用されたスタイルから、異なるスタイルに変更できるのは、単一のスライドにスライド レイアウトを適用したときです。

スライド マスターは、すべてのセットアップアイテムよりも優先されます: スライド マスター -> スライド レイアウト -> スライド:

![todo:image_alt_text](slide-master_2)

各[IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide)オブジェクトには、スライド レイアウトのリストを持つ[**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getLayoutSlides--)プロパティがあります。[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)タイプには、スライドに適用されるスライド レイアウトへのリンクを持つ[**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide#getLayoutSlide--)プロパティがあります。スライドとスライド マスターの相互作用は、スライド レイアウトを介して発生します。

{{% alert color="info" title="注" %}}

* Aspose.Slidesでは、すべてのスライドのセットアップ (スライド マスター、スライド レイアウト、およびスライド自体) は、実際には[**IBaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)インターフェイスを実装したスライドオブジェクトです。
* そのため、スライド マスターとスライド レイアウトは同じプロパティを実装する可能性があり、これらの値が[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide)オブジェクトにどのように適用されるかを知っておく必要があります。スライド マスターは、スライドに先に適用され、その後にスライド レイアウトが適用されます。たとえば、スライド マスターとスライド レイアウトの両方に背景値がある場合、スライドはスライド レイアウトからの背景を最終的に持ちます。

{{% /alert %}}


## **スライド マスターの構成要素**

スライド マスターを変更する方法を理解するためには、その構成要素を知っておく必要があります。これらは[MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)のコアプロパティです。

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getBackground--) スライドの背景を取得/設定します。
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getBodyStyle--) - スライドの本文スタイルを取得/設定します。
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getShapes--) スライド マスターのすべての図形 (プレースホルダー、画像フレームなど) を取得/設定します。
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#getControls--) アクティブXコントロールを取得/設定します。
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterThemeable#getThemeManager--) - テーママネージャを取得します。
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getHeaderFooterManager--) - ヘッダーおよびフッターマネージャを取得します。

スライド マスターのメソッド：

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#getDependingSlides--) - スライド マスターに依存するすべてのスライドを取得します。
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide#applyExternalThemeToDependingSlides-java.lang.String-) - 現在のスライド マスターと新しいテーマに基づいて新しいスライド マスターを作成することを可能にします。新しいスライド マスターは、その後、すべての依存スライドに適用されます。


## **スライド マスターの取得**

PowerPointでは、スライド マスターは「表示」->「スライド マスター」メニューからアクセスできます。

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slidesを使用すると、スライド マスターに次のようにアクセスできます：

```php
  $pres = new Presentation();
  try {
    # プレゼンテーションのマスタースライドにアクセス
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```

[IMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlide)インターフェイスはスライド マスターを表します。[Masters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getMasters--)プロパティ（[IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection)タイプに関連）には、プレゼンテーションに含まれるすべてのスライド マスターのリストが格納されています。


## **スライド マスターに画像を追加**

スライド マスターに画像を追加すると、その画像はそのスライド マスターに依存するすべてのスライドに表示されます。

たとえば、会社のロゴといくつかの画像をスライド マスターに配置し、その後、スライド編集モードに戻ることができます。すべてのスライドで画像が表示されるはずです。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slidesを使用してスライド マスターに画像を追加できます：

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

{{% alert color="primary" title="参照" %}} 

スライドに画像を追加する方法の詳細については、[Picture Frame](/slides/ja/php-java/picture-frame/#create-picture-frame)の記事を参照してください。
{{% /alert %}}


## **スライド マスターにプレースホルダーを追加**

これらのテキストフィールドは、スライド マスターに標準のプレースホルダーです：

* マスターデザインスタイルの編集をクリック

* マスター テキスト スタイルの編集

* 第二レベル

* 第三レベル 

これらは、スライド マスターに基づくスライドにも表示されます。スライド マスター上のプレースホルダーを編集すると、変更が自動的にスライドに適用されます。

PowerPointでは、「スライド マスター」->「プレースホルダーの挿入」という手順でプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

Aspose.Slidesでのプレースホルダーのより複雑な例を見てみましょう。スライド マスターからテンプレート化されたプレースホルダーを持つスライドを考えます：

![todo:image_alt_text](slide-master_6.png)

スライド マスターでタイトルとサブタイトルのフォーマットを次のように変更したいとします：

![todo:image_alt_text](slide-master_7.png)

まず、スライド マスター オブジェクトからタイトル プレースホルダーの内容を取得し、次に`PlaceHolder.FillFormat`フィールドを使用します：

```php

```

タイトルスタイルとフォーマットは、スライド マスターに基づくすべてのスライドに変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="参照" %}} 

* [プレースホルダーにプロンプト テキストを設定](https://docs.aspose.com/slides/php-java/manage-placeholder/)
* [テキストのフォーマット](https://docs.aspose.com/slides/php-java/text-formatting/)

{{% /alert %}}


## **スライド マスターの背景を変更**

マスター スライドの背景色を変更すると、プレゼンテーション内の通常のスライドはすべて新しい色を取得します。このPHPコードはその操作を示しています：

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

{{% alert color="primary" title="参照" %}} 

- [プレゼンテーションの背景](https://docs.aspose.com/slides/php-java/presentation-background/)

- [プレゼンテーションのテーマ](https://docs.aspose.com/slides/php-java/presentation-theme/)

  {{% /alert %}}

## **スライド マスターを別のプレゼンテーションにクローンする**

スライド マスターを別のプレゼンテーションにクローンするには、スライド マスターを引数として渡し、宛先プレゼンテーションから[**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)メソッドを呼び出します。このPHPコードは、スライド マスターを別のプレゼンテーションにクローンする方法を示しています：

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


## **プレゼンテーションに複数のスライド マスターを追加**

Aspose.Slidesを使用すると、任意のプレゼンテーションに複数のスライド マスターやスライド レイアウトを追加できます。これにより、プレゼンテーション スライドのスタイル、レイアウト、フォーマット オプションをさまざまな方法で設定できます。

PowerPointでは、「スライド マスター」メニューから新しいスライド マスターやレイアウトを追加することができます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slidesを使用すると、[**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)メソッドを呼び出して新しいスライド マスターを追加できます：

```php
  # 新しいマスタースライドを追加
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);

```


## **スライド マスターを比較する**

マスタースライドは、[IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)インターフェイスを実装しており、[**equals**](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide#equals-com.aspose.slides.IBaseSlide-)メソッドを含んでいます。このメソッドはスライドを比較するために使用でき、構造とスタティック コンテンツが同一のマスター スライドに対しては`true`を返します。

2つのマスタースライドが平等であるためには、それらの図形、スタイル、テキスト、アニメーション、その他の設定などが等しい必要があります。比較は、一意の識別子値 (例: SlideId) や動的コンテンツ (例: 日付プレースホルダーの現在の日付値) を考慮に入れません。 


## **スライド マスターをプレゼンテーションのデフォルトビューとして設定する**

Aspose.Slidesでは、スライド マスターをプレゼンテーションのデフォルト ビューとして設定できます。デフォルト ビューは、プレゼンテーションを開いたときに最初に表示されるものです。

このコードは、スライド マスターをプレゼンテーションのデフォルト ビューとして設定する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationクラスをインスタンス化
  $presentation = new Presentation();
  try {
    # デフォルトビューをSlideMasterViewに設定
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # プレゼンテーションを保存
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **未使用のマスタースライドを削除**

Aspose.Slidesは、不要かつ未使用のマスタースライドを削除するための[removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-)メソッドを提供しています（[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)クラスから）。このPHPコードは、PowerPointプレゼンテーションからマスタースライドを削除する方法を示しています：

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