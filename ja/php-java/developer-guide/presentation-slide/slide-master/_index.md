---
title: PHPでプレゼンテーションのスライドマスターを管理する
linktitle: スライドマスター
type: docs
weight: 70
url: /ja/php-java/slide-master/
keywords:
- スライドマスター
- マスタースライド
- PPTマスタースライド
- 複数のマスタースライド
- マスタースライドの比較
- 背景
- プレースホルダー
- マスタースライドをクローン
- マスタースライドをコピー
- マスタースライドの重複
- 未使用のマスタースライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides のスライドマスターを管理します：レイアウト、テーマ、プレースホルダーを PPT、PPTX、ODP に作成、編集、適用する簡潔な例を示します。"
---

## **PowerPoint のスライドマスターとは**

**Slide Master** は、スライドのレイアウト、スタイル、テーマ、フォント、背景、およびその他のプロパティを定義するスライドテンプレートです。会社向けに同じスタイルとテンプレートのプレゼンテーション（または複数のプレゼンテーション）を作成したい場合は、スライドマスターを使用できます。

スライドマスターは、すべてのプレゼンテーションスライドの外観を一括で設定および変更できるため便利です。Aspose.Slides は PowerPoint のスライドマスター機構をサポートしています。

VBA でもスライドマスターを操作でき、PowerPoint と同様の操作 (背景の変更、図形の追加、レイアウトのカスタマイズなど) が実行可能です。Aspose.Slides はスライドマスターを使用するための柔軟なメカニズムを提供し、基本的なタスクを実行できます。

以下は基本的なスライドマスター操作です。

- スライドマスターの作成または取得。
- プレゼンテーションのスライドにスライドマスターを適用。
- スライドマスターの背景を変更。
- スライドマスターに画像、プレースホルダー、SmartArt などを追加。

以下はスライドマスターに関する高度な操作です。

- スライドマスターの比較。
- スライドマスターの統合。
- 複数のスライドマスターの適用。
- スライドマスター付きのスライドを別のプレゼンテーションにコピー。
- プレゼンテーション内の重複スライドマスターを検索。
- スライドマスターをプレゼンテーションのデフォルトビューに設定。

{{% alert color="primary" %}} 
Aspose の **[Online PowerPoint Viewer](https://products.aspose.app/slides/viewer)** を確認すると、ここで説明した主要プロセスのライブ実装を見ることができます。 
{{% /alert %}} 

## **スライドマスターの適用方法**

スライドマスターを操作する前に、プレゼンテーションでの使い方とスライドへの適用方法を理解しておくとよいでしょう。

* すべてのプレゼンテーションにはデフォルトで少なくとも 1 つの Slide Master が存在します。  
* プレゼンテーションは複数の Slide Master を含めることができます。複数の Slide Master を追加して、プレゼンテーションの異なる部分を別々のスタイルで装飾できます。

**Aspose.Slides** では、スライドマスターは [**MasterSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) 型で表されます。

Aspose.Slides の [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトは、[**getMasters**](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters) によって取得できる [**MasterSlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) のリストを保持しており、プレゼンテーション内で定義されたすべてのマスタースライドを取得できます。

CRUD 操作に加えて、[MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) クラスは次の便利なメソッドを提供します: [**addClone(LayoutSlide sourceLayout)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/#addClone) および [**insertClone(int index, MasterSlide sourceMaster)**](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/#insertClone)。これらは基本的なスライド複製機能から継承されますが、スライドマスターに対して使用すると、複雑な設定を実装できます。

新しいスライドがプレゼンテーションに追加されると、スライドマスターが自動的に適用されます。既定では前のスライドのスライドマスターが選択されます。

**Note**: プレゼンテーションのスライドは [getSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlides) リストに格納され、新しいスライドはデフォルトでコレクションの末尾に追加されます。プレゼンテーションに単一の Slide Master が含まれる場合、そのスライドマスターがすべての新規スライドに適用されます。これにより、各スライドごとにスライドマスターを個別に指定する必要がなくなります。

PowerPoint と Aspose.Slides の原理は同じです。たとえば PowerPoint では、最後のスライドの下のラインをクリックすると、前のスライドと同じスライドマスターを持つ新しいスライドが作成されます：

![todo:image_alt_text](slide-master_1.jpg)

Aspose.Slides では、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスの [addClone(Slide sourceSlide)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addClone) メソッドを使用して同等の操作を行えます。

## **スライドマスターとスライド階層**

スライドレイアウトとスライドマスターを組み合わせることで、最大限の柔軟性が得られます。スライドレイアウトはスライドマスターと同じスタイル（背景、フォント、図形など）を設定できますが、複数のスライドレイアウトをスライドマスターに組み込むと新しいスタイルが生成されます。スライドレイアウトを単一のスライドに適用すると、スライドマスターが適用したスタイルを上書きできます。

スライドマスターはすべての設定項目の上位に位置します: **Slide Master → Slide Layout → Slide**:

![todo:image_alt_text](slide-master_2)

各 [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) オブジェクトは、[**getLayoutSlides**](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getLayoutSlides) プロパティでスライドレイアウトのリストを取得できます。[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) 型は、[**getLayoutSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/Slide/#getLayoutSlide) プロパティで適用されているスライドレイアウトへの参照を保持します。スライドとスライドマスターの相互作用はスライドレイアウトを介して行われます。

{{% alert color="info" title="Note" %}}
* Aspose.Slides では、スライド設定 (Slide Master、Slide Layout、スライド自体) はすべて [**BaseSlide**](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) クラスを継承したスライドオブジェクトです。  
* したがって、Slide Master と Slide Layout は同じプロパティを実装していることがあり、どの値が [Slide](https://reference.aspose.com/slides/php-java/aspose.slides/Slide) オブジェクトに適用されるかを把握する必要があります。Slide Master が先に適用され、次に Slide Layout が適用されます。たとえば、両方に背景が設定されている場合、最終的なスライドの背景は Slide Layout のものになります。  
{{% /alert %}}

## **スライドマスターに含まれる要素**

スライドマスターの変更方法を理解するには、その構成要素を把握する必要があります。以下は [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) の主なプロパティです。

- [getBackground](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getBackground) – スライド背景の取得/設定。  
- [getBodyStyle](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getBodyStyle) – スライド本文のテキストスタイルの取得/設定。  
- [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getShapes) – スライドマスター上のすべての図形（プレースホルダー、画像フレームなど）の取得/設定。  
- [getControls](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide/#getControls) – ActiveX コントロールの取得/設定。  
- [getThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/#getThemeManager) – テーママネージャの取得。  
- [getHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getHeaderFooterManager) – ヘッダー・フッターマネージャの取得。

スライドマスターのメソッド:

- [getDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#getDependingSlides) – スライドマスターに依存するすべてのスライドを取得。  
- [applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide/#applyExternalThemeToDependingSlides) – 現在のスライドマスターと新しいテーマを組み合わせて新しいスライドマスターを作成し、依存スライドに適用します。

## **スライドマスターの取得方法**

PowerPoint では、[表示] → [スライドマスター] メニューからスライドマスターにアクセスできます：

![todo:image_alt_text](slide-master_3.jpg)

Aspose.Slides では、次のようにスライドマスターにアクセスできます。  
```php
  $pres = new Presentation();
  try {
    # プレゼンテーションのマスタースライドにアクセスできます
    $masterSlide = $pres->getMasters()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


[MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlide) クラスはスライドマスターを表します。[getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation/#getMasters) メソッド（[MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/MasterSlideCollection) 型）は、プレゼンテーション内で定義されたすべてのスライドマスターのリストを返します。

## **スライドマスターに画像を追加する方法**

スライドマスターに画像を追加すると、そのマスターに依存するすべてのスライドに画像が表示されます。

たとえば、会社のロゴやいくつかの画像をスライドマスターに配置すれば、スライド編集モードに戻ったときにすべてのスライドにロゴが表示されます。

![todo:image_alt_text](slide-master_4.png)

Aspose.Slides を使用してスライドマスターに画像を追加できます。  
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
画像の追加に関する詳細は、[Picture Frame](/slides/ja/php-java/picture-frame/#create-picture-frame) 記事をご覧ください。  
{{% /alert %}}

## **スライドマスターにプレースホルダーを追加する方法**

スライドマスター上の標準プレースホルダー例:

* Click to edit Master title style  
* Edit Master text styles  
* Second level  
* Third level  

これらはスライドマスターに基づくスライドでも表示されます。プレースホルダーをスライドマスターで編集すると、変更は自動的にスライドへ反映されます。

PowerPoint では、[スライドマスター] → [プレースホルダーの挿入] パスでプレースホルダーを追加できます：

![todo:image_alt_text](slide-master_5.png)

以下は Aspose.Slides でのプレースホルダーの複雑な例です。スライドマスターからテンプレート化されたプレースホルダーを持つスライドを考えてみましょう：

![todo:image_alt_text](slide-master_6.png)

次のようにスライドマスター上でタイトルとサブタイトルの書式設定を変更したいとします：

![todo:image_alt_text](slide-master_7.png)

まず、スライドマスターオブジェクトからタイトルプレースホルダーの内容を取得し、`PlaceHolder.FillFormat` フィールドを使用します：  
```php

```


これにより、スライドマスターに基づくすべてのスライドのタイトルスタイルと書式が変更されます：

![todo:image_alt_text](slide-master_8.png)

{{% alert color="primary" title="See also" %}} 
* [Set Prompt Text in Placeholder](https://docs.aspose.com/slides/php-java/manage-placeholder/)  
* [Text Formatting](https://docs.aspose.com/slides/php-java/text-formatting/)  
{{% /alert %}}

## **スライドマスターの背景を変更する方法**

マスタースライドの背景色を変更すると、プレゼンテーション内のすべての通常スライドが新しい色になります。以下の PHP コードが操作例です：  
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
- [Presentation Background](https://docs.aspose.com/slides/php-java/presentation-background/)  
- [Presentation Theme](https://docs.aspose.com/slides/php-java/presentation-theme/)  
{{% /alert %}}

## **スライドマスターを別プレゼンテーションにクローンする方法**

別のプレゼンテーションにスライドマスターをクローンするには、宛先プレゼンテーションの `addClone` メソッドにスライドマスターを渡します。以下の PHP コードがクローン手順を示しています：  
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


## **プレゼンテーションに複数のスライドマスターを追加する方法**

Aspose.Slides では、任意のプレゼンテーションに複数のスライドマスターとスライドレイアウトを追加できます。これにより、さまざまなスタイル、レイアウト、書式設定オプションを柔軟に構成できます。

PowerPoint では、[スライドマスターメニュー] から新しいスライドマスターとレイアウトを追加できます：

![todo:image_alt_text](slide-master_9.jpg)

Aspose.Slides では、`addClone` メソッドを呼び出すことで新しいスライドマスターを追加できます：  
```php
  # 新しいマスタースライドを追加します
  $secondMasterSlide = $pres->getMasters()->addClone($masterSlide);
```


## **スライドマスターの比較方法**

マスタースライドは [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) クラスを継承しており、`equals` メソッドでスライドを比較できます。構造と静的コンテンツが同一の場合に `true` を返します。

2 つのマスタースライドは、図形、スタイル、テキスト、アニメーション、その他の設定がすべて同じであれば等価とみなされます。スライド ID などの一意識別子や動的コンテンツ（例: 日付プレースホルダーの現在の日付）は比較対象外です。

## **スライドマスターをプレゼンテーションのデフォルトビューに設定する方法**

Aspose.Slides でスライドマスターをプレゼンテーションのデフォルトビューとして設定できます。デフォルトビューはプレゼンテーションを開いたときに最初に表示されるビューです。

以下のコードがスライドマスターをプレゼンテーションのデフォルトビューに設定する手順を示しています：  
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $presentation = new Presentation();
  try {
    # デフォルトビューを SlideMasterView に設定
    $presentation->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # プレゼンテーションを保存
    $presentation->save("PresView.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```


## **未使用のマスタースライドを削除する方法**

Aspose.Slides は [removeUnusedMasterSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedMasterSlides) メソッド（[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/) クラス）を提供し、不要なマスタースライドを削除できます。以下の PHP コードが PowerPoint プレゼンテーションからマスタースライドを削除する例です：  
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

**PowerPoint のスライドマスターとは何ですか？**

スライドマスターは、プレゼンテーション内のスライドのレイアウト、スタイル、テーマ、フォント、背景、その他のプロパティを定義するテンプレートです。一括ですべてのスライドの外観を設定・変更できます。

**スライドマスターはプレゼンテーションでどのように適用されますか？**

すべてのプレゼンテーションにはデフォルトで少なくとも 1 つの Slide Master が存在します。新しいスライドが追加されると、自動的にスライドマスターが適用され、通常は前のスライドのマスターが継承されます。複数のスライドマスターを使用して、プレゼンテーションの異なる部分を個別に装飾することも可能です。

**スライドマスターでカスタマイズできる要素は何ですか？**

スライドマスターは次の主要プロパティをカスタマイズできます:

- **Background**: スライドの背景を設定。  
- **BodyStyle**: スライド本文のテキストスタイルを定義。  
- **Shapes**: プレースホルダーや画像フレームなど、すべての図形を管理。  
- **Controls**: ActiveX コントロールを操作。  
- **ThemeManager**: テーママネージャにアクセス。  
- **HeaderFooterManager**: ヘッダーとフッターを管理。  

**スライドマスターに画像を追加するには？**

スライドマスターに画像を追加すると、そのマスターに依存するすべてのスライドに画像が表示されます。たとえば会社ロゴをスライドマスターに配置すれば、プレゼンテーション全体のスライドにロゴが表示されます。

**スライドマスターとスライドレイアウトの関係は？**

スライドレイアウトはスライドマスターと連携してスライドデザインに柔軟性をもたらします。スライドマスターが全体的なスタイルとテーマを定義し、スライドレイアウトがコンテンツ配置のバリエーションを提供します。階層は次の通りです:

- **Slide Master** → 全体的なスタイルを定義。  
- **Slide Layout** → コンテンツ配置のバリエーションを提供。  
- **Slide** → スライドレイアウトからデザインを継承。  

**1 つのプレゼンテーションに複数のスライドマスターを持てますか？**

はい。プレゼンテーションに複数のスライドマスターを含めることができ、セクションごとに異なるデザインを適用して柔軟に装飾できます。

**Aspose.Slides でスライドマスターを取得・変更するには？**

Aspose.Slides では、スライドマスターは [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) クラスで表されます。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) オブジェクトの [getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getmasters/) メソッドでスライドマスターにアクセスできます。