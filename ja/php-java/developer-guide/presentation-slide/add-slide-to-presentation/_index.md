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
description: "Aspose.Slides for PHP via Java を使用して、PowerPoint と OpenDocument のプレゼンテーションにスライドを簡単に追加できます。シームレスで効率的なスライド挿入を数秒で実現します。"
---

## **プレゼンテーションにスライドを追加する**
{{% alert color="primary" %}} 

スライドをプレゼンテーション ファイルに追加することについて説明する前に、スライドに関するいくつかの事実を説明します。各 PowerPoint プレゼンテーション ファイルには **Master / Layout** スライドとその他の **Normal** スライドが含まれます。つまり、プレゼンテーション ファイルには少なくとも 1 つ以上のスライドが含まれます。スライドがないプレゼンテーション ファイルは Aspose.Slides for PHP via Java ではサポートされていないことに注意してください。各スライドには固有の Id があり、すべての Normal スライドは 0 ベースのインデックスで指定された順序で配置されます。

{{% /alert %}} 

Aspose.Slides for PHP via Java は開発者がプレゼンテーションに空のスライドを追加できるようにします。プレゼンテーションに空のスライドを追加するには、以下の手順に従ってください：

- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) クラスのインスタンスを作成します。
- [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) オブジェクトを、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) オブジェクトが提供する [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (コンテンツ スライド オブジェクトのコレクション) メソッドを使用して取得します。
- [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) オブジェクトが提供する [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addEmptySlide) メソッドを呼び出して、コンテンツ スライド コレクションの末尾に空のスライドをプレゼンテーションに追加します。
- 新しく追加された空のスライドで何らかの処理を行います。
- [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) オブジェクトを使用してプレゼンテーション ファイルを書き込みます。
```php
  # プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation();
  try {
    # SlideCollection クラスのインスタンスを作成
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # 空のスライドを Slides コレクションに追加
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # 新しく追加されたスライドで何らかの処理を行う
    # PPTX ファイルをディスクに保存
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **よくある質問**

**特定の位置に新しいスライドを挿入できますか？（末尾だけでなく）**

はい。このライブラリはスライド コレクションおよび [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/) 操作をサポートしているため、末尾だけでなく任意のインデックスにスライドを追加できます。

**レイアウトに基づくスライドを追加する際、テーマ/スタイルは保持されますか？**

はい。レイアウトはマスターから書式設定を継承し、新しいスライドは選択されたレイアウトとその関連マスターから継承します。

**スライドを追加する前の新しい「空」プレゼンテーションにはどのスライドが存在しますか？**

新しく作成されたプレゼンテーションには、インデックス 0 の空白スライドが 1 枚すでに含まれています。これを挿入インデックス計算時に考慮することが重要です。

**マスターに多数のオプションがある場合、新しいスライドに適切なレイアウトをどのように選択しますか？**

通常は、必要な構造（[Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)）に一致する [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) を選択します。該当するレイアウトがない場合は、[add it to the master](/slides/ja/php-java/slide-layout/) でマスターに追加し、使用できます。