---
title: "PHPでプレゼンテーションスライドをクローン"
linktitle: "スライドのクローン"
type: docs
weight: 35
url: /ja/php-java/clone-slides/
keywords:
- スライドのクローン
- スライドのコピー
- スライドの保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使って PowerPoint スライドをすぐに複製できます。明確なコード例に従って、数秒で PPT の作成を自動化し、手作業をなくしましょう。"
---
## **はじめに**

クローン作成は、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for PHP via Java を使用すると、任意のスライドのコピーまたはクローンを作成し、そのクローンしたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスにより、元のスライドを変更せずに開発者が変更できる新しいスライドが作成されます。スライドをクローンする方法はいくつかあります：

- プレゼンテーション内の末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

Aspose.Slides for PHP via Java では、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) オブジェクトが公開する（[Slide](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Slide) オブジェクトのコレクション）に、上記のスライドクローン作成タイプを実行するための [addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SlideCollection/#addClone) および [insertClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SlideCollection/#insertClone) メソッドが提供されています。

## **プレゼンテーションの末尾にスライドをクローンする**
既存のスライドの末尾に同じプレゼンテーションファイル内でスライドをクローンして使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SlideCollection/#addClone) メソッドを使用します。

1. [Presentation] クラスのインスタンスを作成します。
2. [Presentation] オブジェクトが公開するスライドコレクションを参照して、[SlideCollection] オブジェクトを取得します。
3. [SlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。
4. 変更されたプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの最初の位置（0 インデックス）にあるスライドをプレゼンテーションの末尾にクローンしています。

```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 変更されたプレゼンテーションをディスクに書き込みます
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーションファイル内で異なる位置にスライドをクローンして使用したい場合は、[insertClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SlideCollection/#insertClone) メソッドを使用します。

1. [Presentation] クラスのインスタンスを作成します。
2. [Presentation] オブジェクトが公開する [**Slides**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation/#getSlides) コレクションを参照して、[SlideCollection] オブジェクトを取得します。
3. [SlideCollection] オブジェクトが公開する [insertClone] メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。
4. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのゼロインデックス（位置 1）にあるスライドをインデックス 1（位置 2）にクローンしています。

```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成します
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンします
    $slds = $pres->getSlides();
    # 同じプレゼンテーション内の指定インデックスに目的のスライドをクローンします
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 変更されたプレゼンテーションをディスクに書き込みます
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に使用する必要がある場合は、次の手順を実行します。

1. スライドのクローン元となるプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
2. スライドを追加する先のプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
3. 先のプレゼンテーションの [Presentation] オブジェクトが公開する [**Slides**](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation/#getSlides) コレクションを参照して、[SlideCollection] オブジェクトを取得します。
4. [SlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、元プレゼンテーションからのスライドをパラメーターとして渡します。
5. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、元プレゼンテーションの最初のインデックスにあるスライドを先のプレゼンテーションの末尾にクローンしています。

```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスのインスタンスを作成します
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成します
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションから目的のスライドを先のプレゼンテーションのスライドコレクションの末尾にクローンします
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 先のプレゼンテーションをディスクに書き込みます
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に使用する必要がある場合は、次の手順を実行します。

1. スライドのクローン元となるソースプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
2. スライドを追加する先のプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
3. 先のプレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションを参照して、[SlideCollection] クラスを取得します。
4. [SlideCollection] オブジェクトが公開する [insertClone] メソッドを呼び出し、ソースプレゼンテーションからのスライドと希望の位置をパラメーターとして渡します。
5. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるスライドを先のプレゼンテーションのインデックス 1（位置 2）にクローンしています。

```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスのインスタンスを作成します
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンする先の PPTX 用に Presentation クラスのインスタンスを作成します
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションから目的のスライドを先のプレゼンテーションのスライドコレクションの末尾にクローンします
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 先のプレゼンテーションをディスクに書き込みます
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **別のプレゼンテーションの特定の位置にスライドをクローンする**
別のプレゼンテーションからマスタースライドを持つスライドをクローンして別のプレゼンテーションで使用する場合、まずソースプレゼンテーションから先のプレゼンテーションへ目的のマスタースライドをクローンする必要があります。その後、マスタースライドを使用してスライドをクローンします。[addClone(Slide, MasterSlide, boolean)] メソッドは、ソースプレゼンテーションではなく先のプレゼンテーションのマスタースライドを受け取ります。マスタースライド付きでスライドをクローンするには、以下の手順に従ってください：

1. スライドのクローン元となるソースプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
2. スライドをクローン先とする先のプレゼンテーションを含む [Presentation] クラスのインスタンスを作成します。
3. クローン対象のスライドとマスタースライドにアクセスします。
4. 先のプレゼンテーションの [Presentation] オブジェクトが公開する Masters コレクションを参照して、[MasterSlideCollection] クラスのインスタンスを作成します。
5. [MasterSlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメーターとして渡します。
6. 先のプレゼンテーションの [Presentation] オブジェクトが公開する Slides コレクションへの参照を設定して、[SlideCollection] クラスのインスタンスを作成します。
7. [SlideCollection] オブジェクトが公開する [addClone] メソッドを呼び出し、ソースプレゼンテーションからクローンするスライドとマスタースライドをパラメーターとして渡します。
8. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのゼロインデックスにあるマスター付きスライドを、ソーススライドのマスターを使用して先のプレゼンテーションの末尾にクローンしています。

```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスのインスタンスを作成します
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # スライドをクローンする先のプレゼンテーション用に Presentation クラスのインスタンスを作成します
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションのスライドコレクションから ISlide を取得し、
      # マスタースライドも取得します
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # ソースプレゼンテーションから目的のマスタースライドを先のプレゼンテーションのマスターコレクションにクローンします
      # （先のプレゼンテーション）
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # ソースプレゼンテーションから目的のマスタースライドを先のプレゼンテーションのマスターコレクションにクローンします
      # （先のプレゼンテーション）
      $iSlide = $masters->addClone($SourceMaster);
      # ソースプレゼンテーションの目的のスライドを、取得したマスターと共に先のプレゼンテーションのスライドコレクションの末尾にクローンします
      # （先のプレゼンテーションのスライドコレクション）
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 先のプレゼンテーションをディスクに保存します
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **指定セクションの末尾にスライドをクローンする**
同じプレゼンテーションファイル内で別のセクションにスライドをクローンして使用したい場合は、[SlideCollection] クラスが公開する [addClone](https://reference.aspose.com/slides/ja/php-java/aspose.slides/SlideCollection/#addClone) メソッドを使用します。Aspose.Slides for PHP via Java を使用すると、最初のセクションからスライドをクローンし、そのクローンしたスライドを同じプレゼンテーションの第二セクションに挿入することが可能です。

以下のコードスニペットは、スライドをクローンし、クローンしたスライドを指定したセクションに挿入する方法を示しています。

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 先のプレゼンテーションをディスクに保存します
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **スライドサイズの一致を確保する**

スライドを別のプレゼンテーションにクローンする際は、先のプレゼンテーションがソースと同じスライドサイズであることを確認してください。スライドサイズが異なる場合、Aspose.Slides はクローンされた図形のサイズを自動的に再スケーリングせず、元の座標と寸法が保持されるため、コンテンツがずれたりスライドの境界を超えて表示されることがあります。

マスターとスライドをクローンする前に、先のプレゼンテーションのスライドサイズをソースに合わせて設定できます。

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

マスターとスライドをクローンする前に実行してください。

## **FAQ**

**スピーカーノートとレビュアーコメントはクローンされますか？**

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に [remove them](/slides/ja/php-java/presentation-notes/) を実行してください。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、および埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは [OLE object](/slides/ja/php-java/manage-ole/) として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。クローンを特定のスライドインデックスに挿入し、選択した [section](/slides/ja/php-java/slide-section/) に配置できます。対象のセクションが存在しない場合は、まずセクションを作成し、その後スライドを移動してください。