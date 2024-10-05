---
title: スライドレイアウト
type: docs
weight: 60
url: /php-java/slide-layout/
keyword: "スライドサイズ設定、スライドオプション設定、スライドサイズ指定、フッターの可視性、子フッター、コンテンツスケーリング、ページサイズ、Java、Aspose.Slides"
description: "PowerPointスライドのサイズとオプションを設定"
---

スライドレイアウトには、スライド上に表示されるすべてのコンテンツのプレースホルダーと書式情報が含まれています。レイアウトは、利用可能なコンテンツプレースホルダーとその配置を決定します。

スライドレイアウトを使用すると、プレゼンテーションを迅速に作成および設計できます（単純なものでも複雑なものでも）。これらは、PowerPointプレゼンテーションで使用される最も人気のあるスライドレイアウトのいくつかです：

* **タイトルスライドレイアウト**。このレイアウトは、タイトル用とサブタイトル用の2つのテキストプレースホルダーで構成されています。
* **タイトルとコンテンツレイアウト**。このレイアウトには、タイトル用の相対的に小さなプレースホルダーと、コアコンテンツ（グラフ、段落、箇条書き、番号付きリスト、画像など）用のより大きなプレースホルダーが含まれています。
* **空白レイアウト**。このレイアウトにはプレースホルダーがないため、ゼロから要素を作成できます。

スライドマスターは、スライドレイアウトについての情報を格納する最上位の階層スライドであるため、マスタースライドを使用してスライドレイアウトにアクセスし、変更を加えることができます。レイアウトスライドには、タイプや名前でアクセスできます。同様に、すべてのスライドには一意のIDがあり、それを使用してアクセスできます。

あるいは、プレゼンテーション内の特定のスライドレイアウトに直接変更を加えることもできます。

* スライドレイアウト（マスタースライド内のものを含む）で作業できるように、Aspose.Slidesは、[getLayoutSlides()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getLayoutSlides--)や[getMasters()](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getMasters--)といったプロパティを[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスの下で提供しています。
* 関連タスクを実行するために、Aspose.Slidesは[MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/)、[MasterLayoutSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterlayoutslidecollection/)、[SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/)、[BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/php-java/aspose.slides/baseslideheaderfootermanager/)など、多くの他のタイプを提供しています。

{{% alert title="情報" color="info" %}}

マスタースライドに特に関する詳細情報は、[スライドマスター](https://docs.aspose.com/slides/php-java/slide-master/)の記事を参照してください。

{{% /alert %}}

## **プレゼンテーションにスライドレイアウトを追加する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. [MasterSlideコレクション](https://reference.aspose.com/slides/php-java/aspose.slides/imasterlayoutslidecollection/)にアクセスします。
1. 既存のレイアウトスライドを確認して、必要なレイアウトスライドがレイアウトスライドコレクションに既に存在することを確認します。存在しない場合は、追加したいレイアウトスライドを追加します。
1. 新しいレイアウトスライドに基づいて空のスライドを追加します。
1. プレゼンテーションを保存します。

このPHPコードは、PowerPointプレゼンテーションにスライドレイアウトを追加する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationクラスのインスタンスを生成
  $pres = new Presentation("AccessSlides.pptx");
  try {
    # レイアウトスライドの種類を確認
    $layoutSlides = $pres->getMasters()->get_Item(0)->getLayoutSlides();
    $layoutSlide = null;
    if (!java_is_null($layoutSlides->getByType(SlideLayoutType::TitleAndObject))) {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::TitleAndObject);
    } else {
      $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Title);
    }
    if (java_is_null($layoutSlide)) {
      # プレゼンテーションに一部のレイアウトタイプが含まれない状況。
      # プレゼンテーションファイルには空白とカスタムレイアウトタイプのみが含まれる。
      # しかし、カスタムタイプのレイアウトスライドには異なるスライド名があり、
      # "タイトル"、"タイトルとコンテンツ"などの名前を使用してレイアウトスライドを選択することが可能。
      # プレースホルダー形状タイプのセットも使用できます。たとえば、
      # タイトルスライドは、タイトルプレースホルダータイプのみを持つ必要があります。
      foreach($layoutSlides as $titleAndObjectLayoutSlide) {
        if (java_values($titleAndObjectLayoutSlide->getName()) == "Title and Object") {
          $layoutSlide = $titleAndObjectLayoutSlide;
          break;
        }
      }
      if (java_is_null($layoutSlide)) {
        foreach($layoutSlides as $titleLayoutSlide) {
          if (java_values($titleLayoutSlide->getName()) == "Title") {
            $layoutSlide = $titleLayoutSlide;
            break;
          }
        }
        if (java_is_null($layoutSlide)) {
          $layoutSlide = $layoutSlides->getByType(SlideLayoutType::Blank);
          if (java_is_null($layoutSlide)) {
            $layoutSlide = $layoutSlides->add(SlideLayoutType::TitleAndObject, "Title and Object");
          }
        }
      }
    }
    # 追加されたレイアウトスライドを使用して空のスライドを追加
    $pres->getSlides()->insertEmptySlide(0, $layoutSlide);
    # プレゼンテーションをディスクに保存
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **未使用のレイアウトスライドを削除する**

Aspose.Slidesは、[removeUnusedLayoutSlides](https://reference.aspose.com/slides/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-)メソッドを[Compress](https://reference.aspose.com/slides/php-java/aspose.slides/compress/)クラスから提供し、不要かつ未使用のレイアウトスライドを削除できるようにしています。このPHPコードは、PowerPointプレゼンテーションからレイアウトスライドを削除する方法を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **スライドレイアウトのサイズとタイプを設定する**

特定のレイアウトスライドのサイズとタイプを設定できるように、Aspose.Slidesは、[getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--)および[getSize()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getSize--)プロパティを[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスから提供しています。これに関するJavaの操作を示します：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトを生成
  $presentation = new Presentation("demo.pptx");
  try {
    $auxPresentation = new Presentation();
    try {
      # 生成されたプレゼンテーションのスライドサイズをソースのものに設定
      $auxPresentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit);
      # getType());
      $auxPresentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize);
      # 必要なスライドをクローン
      $auxPresentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
      $auxPresentation->getSlides()->removeAt(0);
      # プレゼンテーションをディスクに保存
      $auxPresentation->save("size.pptx", SaveFormat::Pptx);
    } finally {
      $auxPresentation->dispose();
    }
  } finally {
    $presentation->dispose();
  }
```

## **スライド内のフッターの可視性を設定する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてスライドの参照を取得します。
1. スライドフッタープレースホルダーを表示可能に設定します。
1. 日時プレースホルダーを表示可能に設定します。
1. プレゼンテーションを保存します。

このPHPコードは、スライドフッターの可視性を設定する方法を示しています（および関連タスクを実行）：

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getSlides()->get_Item(0)->getHeaderFooterManager();
    # isFooterVisibleメソッドは、スライドフッタープレースホルダーが欠如していることを示すために使用
    if (!$headerFooterManager->isFooterVisible()) {
      $headerFooterManager->setFooterVisibility(true); // setFooterVisibilityメソッドは、スライドフッタープレースホルダーを表示可能に設定

    }
    # isSlideNumberVisibleメソッドは、スライドページ番号プレースホルダーが欠如していることを示すために使用
    if (!$headerFooterManager->isSlideNumberVisible()) {
      $headerFooterManager->setSlideNumberVisibility(true); // setSlideNumberVisibilityメソッドは、スライドページ番号プレースホルダーを表示可能に設定

    }
    # isDateTimeVisibleメソッドは、スライド日時プレースホルダーが欠如していることを示すために使用
    if (!$headerFooterManager->isDateTimeVisible()) {
      $headerFooterManager->setDateTimeVisibility(true); // SetFooterVisibilityメソッドは、スライド日時プレースホルダーを表示可能に設定

    }
    $headerFooterManager->setFooterText("フッターのテキスト"); // SetFooterTextメソッドは、スライドフッタープレースホルダーのテキストを設定

    $headerFooterManager->setDateTimeText("日付と時刻のテキスト"); // SetDateTimeTextメソッドは、スライド日時プレースホルダーのテキストを設定

  } finally {
    $presentation->dispose();
  }
```

## **スライド内の子フッターの可視性を設定する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じてマスタースライドの参照を取得します。
1. マスタースライドとすべての子フッタープレースホルダーを表示可能に設定します。
1. マスタースライドとすべての子フッタープレースホルダーのテキストを設定します。
1. マスタースライドとすべての子の日時プレースホルダーのテキストを設定します。
1. プレゼンテーションを保存します。

このPHPコードは、その操作を示しています：

```php
  $presentation = new Presentation("presentation.ppt");
  try {
    $headerFooterManager = $presentation->getMasters()->get_Item(0)->getHeaderFooterManager();
    $headerFooterManager->setFooterAndChildFootersVisibility(true); // setFooterAndChildFootersVisibilityメソッドは、マスタースライドとすべての子フッタープレースホルダーを表示可能に設定

    $headerFooterManager->setSlideNumberAndChildSlideNumbersVisibility(true); // setSlideNumberAndChildSlideNumbersVisibilityメソッドは、マスタースライドとすべての子ページ番号プレースホルダーを表示可能に設定

    $headerFooterManager->setDateTimeAndChildDateTimesVisibility(true); // setDateTimeAndChildDateTimesVisibilityメソッドは、マスタースライドとすべての子日時プレースホルダーを表示可能に設定

    $headerFooterManager->setFooterAndChildFootersText("フッターのテキスト"); // setFooterAndChildFootersTextメソッドは、マスタースライドとすべての子フッタープレースホルダーのテキストを設定

    $headerFooterManager->setDateTimeAndChildDateTimesText("日付と時刻のテキスト"); // setDateTimeAndChildDateTimesTextメソッドは、マスタースライドとすべての子日時プレースホルダーのテキストを設定

  } finally {
    $presentation->dispose();
  }
```

## **コンテンツスケーリングに関するスライドサイズを設定する**

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成し、サイズを設定したいスライドを含むプレゼンテーションを読み込みます。
1. 新しいプレゼンテーションを生成するために、別の[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスのインスタンスを作成します。
1. インデックスを通じて（最初のプレゼンテーションから）スライドの参照を取得します。
1. スライドフッタープレースホルダーを表示可能に設定します。
1. 日時プレースホルダーを表示可能に設定します。
1. プレゼンテーションを保存します。

このPHPコードは、その操作を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトを生成
  $presentation = new Presentation("demo.pptx");
  try {
    # 生成されたプレゼンテーションのスライドサイズをソースのものに設定
    $presentation->getSlideSize()->setSize(540, 720, SlideSizeScaleType::EnsureFit); // SetSizeメソッドは、スライドサイズをコンテンツに合わせてスケールするために使用

    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::Maximize); // SetSizeメソッドは、コンテンツの最大サイズに合わせてスライドサイズを設定するために使用

    # プレゼンテーションをディスクに保存
    $presentation->save("Set_Size&Type_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **PDF生成時のページサイズを設定する**

特定のプレゼンテーション（ポスターなど）は、しばしばPDF文書に変換されます。PowerPointをPDFに変換して、最適な印刷とアクセシビリティオプションにアクセスしたい場合は、スライドをPDF文書に適したサイズ（例えばA4）に設定する必要があります。

Aspose.Slidesは、スライドに対して好みの設定を指定できるように[SlideSize](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/)クラスを提供します。このPHPコードは、プレゼンテーション内のスライドの特定の用紙サイズを設定するために、`SlideSize`クラスから[getType()](https://reference.aspose.com/slides/php-java/aspose.slides/slidesize/#getType--)プロパティを使用する方法を示しています：

```php
  # プレゼンテーションファイルを表すPresentationオブジェクトを生成
  $presentation = new Presentation();
  try {
    # SlideSize.Typeプロパティを設定
    $presentation->getSlideSize()->setSize(SlideSizeType::A4Paper, SlideSizeScaleType::EnsureFit);
    # PDFオプションの異なるプロパティを設定
    $opts = new PdfOptions();
    $opts->setSufficientResolution(600);
    # プレゼンテーションをディスクに保存
    $presentation->save("SetPDFPageSize_out.pdf", SaveFormat::Pdf, $opts);
  } finally {
    $presentation->dispose();
  }
```