---
title: PHPでプレゼンテーションスライドをクローンする
linktitle: スライドをクローン
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
description: "Aspose.Slides for PHP を使用して PowerPoint スライドを迅速に複製します。明確なコード例に従って、数秒で PPT の作成を自動化し、手作業を排除しましょう。"
---

## **プレゼンテーション内のスライドのクローン作成**
クローン作成とは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for PHP via Java では、任意のスライドのコピーまたはクローンを作成し、そのクローン化されたスライドを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することが可能です。スライドのクローン作成プロセスにより、新しいスライドが生成され、元のスライドを変更せずに開発者が修正できます。スライドをクローンする方法はいくつかあります：

- プレゼンテーション内の末尾にクローンする。
- プレゼンテーション内の別の位置にクローンする。
- 別のプレゼンテーションの末尾にクローンする。
- 別のプレゼンテーションの別の位置にクローンする。
- 別のプレゼンテーションの特定の位置にクローンする。

In Aspose.Slides for PHP via Java、[Presentation]オブジェクトが公開する[スライド]コレクションは、上記のスライドクローン作成を実行するための[addClone]メソッドと[insertClone]メソッドを提供します。

## **プレゼンテーションの末尾にスライドをクローンする**
既存のスライドの末尾にスライドをクローンし、同じプレゼンテーションファイル内で使用したい場合は、以下の手順に従って[addClone]メソッドを使用します。

1. [Presentation] クラスのインスタンスを作成します。
2. [Presentation] オブジェクトが公開するスライドコレクションを参照して、[SlideCollection] オブジェクトを取得します。
3. [SlideCollection] オブジェクトが公開する[addClone]メソッドを呼び出し、クローン対象のスライドをパラメーターとして渡します。
4. 変更されたプレゼンテーションファイルを書き出します。

以下の例では、プレゼンテーションの最初の位置（インデックス0）にあるスライドをプレゼンテーションの末尾にクローンしました。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 変更されたプレゼンテーションをディスクに保存
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーションファイル内で別の位置にスライドをクローンして使用したい場合は、[insertClone]メソッドを使用します：

1. [Presentation] クラスのインスタンスを作成します。
2. [Presentation] オブジェクトが公開する[**Slides**]コレクションを参照して、[SlideCollection] オブジェクトを取得します。
3. [SlideCollection] オブジェクトが公開する[insertClone]メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメーターとして渡します。
4. 変更されたプレゼンテーションを PPTX ファイルとして書き出します。

以下の例では、プレゼンテーションのインデックス0（位置1）にあるスライドをインデックス1（位置2）にクローンしました。
```php
  # プレゼンテーションファイルを表す Presentation クラスのインスタンスを作成
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローン
    $slds = $pres->getSlides();
    # 同じプレゼンテーション内の指定インデックスに目的のスライドをクローン
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 変更されたプレゼンテーションをディスクに保存
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存スライドの末尾に使用する必要がある場合は、次の手順を実行します：

1. クローン元のプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
2. スライドを追加する先のプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
3. 先のプレゼンテーションの[Presentation]オブジェクトが公開する[**Slides**]コレクションを参照して、[SlideCollection] オブジェクトを取得します。
4. [SlideCollection] オブジェクトが公開する[addClone]メソッドを呼び出し、ソースプレゼンテーションのスライドをパラメーターとして渡します。
5. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス0にあるスライドを先のプレゼンテーションの末尾にクローンしました。
```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクション末尾にクローンする
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 宛先プレゼンテーションをディスクに保存
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの特定の位置に使用したい場合は、次の手順を実行します：

1. スライドをクローンする元プレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
2. スライドを追加する先のプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
3. 先のプレゼンテーションの[Presentation]オブジェクトが公開するSlidesコレクションを参照して、[SlideCollection] クラスを取得します。
4. [SlideCollection] オブジェクトが公開する[insertClone]メソッドを呼び出し、ソースプレゼンテーションのスライドと目的の位置インデックスをパラメーターとして渡します。
5. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス0にあるスライドを先のプレゼンテーションのインデックス1（位置2）にクローンしました。
```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクション末尾にクローンする
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 宛先プレゼンテーションをディスクに保存
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **別のプレゼンテーションの特定の位置にスライドをクローンする**
マスタースライドを含むスライドをあるプレゼンテーションから別のプレゼンテーションにクローンする場合、まずソースプレゼンテーションから目的のマスタースライドを先のプレゼンテーションにクローンし、そのマスタースライドを使用してスライドをクローンします。`[addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/addclone/)` は、ソースではなく先のプレゼンテーションのマスタースライドを受け取ります。マスタースライド付きでスライドをクローンする手順は以下の通りです：

1. スライドをクローンする元プレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
2. スライドをクローン先とする先のプレゼンテーションを含む[Presentation]クラスのインスタンスを作成します。
3. クローン対象のスライドとマスタースライドにアクセスします。
4. 先のプレゼンテーションの[Presentation]オブジェクトが公開する Masters コレクションを参照して、[MasterSlideCollection] クラスのインスタンスを作成します。
5. [MasterSlideCollection] オブジェクトが公開する[addClone]メソッドを呼び出し、ソース PPTX のマスターをクローンするためのパラメーターとして渡します。
6. 先のプレゼンテーションの[Presentation]オブジェクトが公開する Slides コレクションへの参照を設定して、[SlideCollection] クラスのインスタンスを作成します。
7. [SlideCollection] オブジェクトが公開する[addClone]メソッドを呼び出し、ソースプレゼンテーションのスライドとマスタースライドをパラメーターとして渡します。
8. 変更された先のプレゼンテーションファイルを書き出します。

以下の例では、ソースプレゼンテーションのインデックス0にあるマスタースライド付きスライドを、ソーススライドのマスタースライドを使用して先のプレゼンテーションの末尾にクローンしました。
```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # スライドをクローンする宛先プレゼンテーション用に Presentation クラスをインスタンス化
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションのスライドコレクションから ISlide をインスタンス化
      # マスタースライド
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # ソースプレゼンテーションから目的のマスタースライドをマスターコレクションへクローン
      # 宛先プレゼンテーションへ
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # ソースプレゼンテーションから目的のマスタースライドをマスターコレクションへクローン
      # 宛先プレゼンテーションへ
      $iSlide = $masters->addClone($SourceMaster);
      # ソースプレゼンテーションのスライドを目的のマスターと共に、末尾にクローン
      # 宛先プレゼンテーションのスライドコレクションへ
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 宛先プレゼンテーションをディスクに保存
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **指定セクションの末尾にスライドをクローンする**
同じプレゼンテーションファイル内で別のセクションにスライドをクローンして使用したい場合は、[SlideCollection] クラスが公開する [addClone] メソッドを使用します。Aspose.Slides for PHP via Java では、最初のセクションからスライドをクローンし、そのクローン化されたスライドを同じプレゼンテーションの第2セクションに挿入することが可能です。

以下のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示しています。
```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # 宛先プレゼンテーションをディスクに保存
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **よくある質問**

**スピーカーノートとレビュアーコメントはクローンされますか？**

はい。ノートページとレビュアーコメントはクローンに含まれます。不要な場合は、挿入後に[削除する](/slides/ja/php-java/presentation-notes/) を実行してください。

**チャートとそのデータソースはどのように扱われますか？**

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みのワークブック）にリンクされていた場合、そのリンクは[OLE オブジェクト](/slides/ja/php-java/manage-ole/)として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**

はい。特定のスライドインデックスでクローンを挿入し、選択した[セクション](/slides/ja/php-java/slide-section/)に配置できます。対象のセクションが存在しない場合は、先に作成してからスライドを移動してください。