---
title: PHPでプレゼンテーションにスライドを追加
linktitle: スライドを追加
type: docs
weight: 10
url: /ja/php-java/add-slide-to-presentation/
keywords:
- スライドを追加
- スライドを作成
- 空のスライド
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションにスライドを簡単に追加できます — シームレスで効率的なスライド挿入が数秒で可能です。"
---

## **プレゼンテーションにスライドを追加する**
{{% alert color="primary" %}} 

プレゼンテーション ファイルにスライドを追加することについて説明する前に、スライドに関するいくつかの事実を確認しましょう。各 PowerPoint プレゼンテーション ファイルには **Master / Layout** スライドとその他の **Normal** スライドが含まれています。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドがないプレゼンテーション ファイルは Aspose.Slides for PHP via Java ではサポートされていないことに注意してください。各スライドには固有の Id があり、すべての Normal スライドはゼロベースのインデックスで指定された順序で配置されます。

{{% /alert %}} 

Aspose.Slides for PHP via Java は開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください。

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) オブジェクトが公開する [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (コンテンツ スライド オブジェクトのコレクション) プロパティへの参照を設定して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) クラスのインスタンスを作成します。
- [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) オブジェクトが公開する [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) メソッドを呼び出し、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加します。
- 追加された空のスライドで必要な処理を行います。
- 最後に、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) オブジェクトを使用してプレゼンテーション ファイルを書き出します。
```php
  # プレゼンテーション ファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation();
  try {
    # SlideCollection クラスをインスタンス化
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Slides コレクションに空のスライドを追加
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # 新しく追加されたスライドで処理を行う
    # PPTX ファイルをディスクに保存
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **FAQ**

**特定の位置に新しいスライドを挿入できますか、末尾だけではなく？**

はい。ライブラリはスライド コレクションと [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/) 操作をサポートしているため、末尾だけでなく、必要なインデックスにスライドを追加できます。

**レイアウトに基づいてスライドを追加する際、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択されたレイアウトとそれに関連付けられたマスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションには、インデックス 0 の空白スライドが既に 1 枚含まれています。これは挿入インデックスを計算する際に重要です。

**マスターに多数のオプションがある場合、新しいスライドに適切なレイアウトをどのように選択しますか？**

通常は、必要な構造（[Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) を選択します。そのようなレイアウトが存在しない場合は、[add it to the master](/slides/ja/php-java/slide-layout/) でマスターに追加し、使用してください。