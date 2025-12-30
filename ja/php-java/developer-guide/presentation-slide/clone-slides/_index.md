---
title: PHPでプレゼンテーションスライドをクローン
linktitle: スライドをクローン
type: docs
weight: 35
url: /ja/php-java/clone-slides/
keywords:
- スライドをクローン
- スライドをコピー
- スライドを保存
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP を使用して PowerPoint スライドを迅速に複製します。明確なコード例に従って数秒で PPT 作成を自動化し、手作業を排除できます。"
---

## **プレゼンテーション内のスライドのクローン作成**
クローンとは、何かを正確にコピーまたは複製するプロセスです。Aspose.Slides for PHP via Java を使用すると、任意のスライドのコピーまたはクローンを作成し、現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することができます。スライドのクローン作成プロセスにより、元のスライドを変更せずに開発者が修正できる新しいスライドが生成されます。スライドをクローンする方法はいくつかあります。

- プレゼンテーションの末尾にクローンを作成する。
- プレゼンテーション内の別の位置にクローンを作成する。
- 別のプレゼンテーションの末尾にクローンを作成する。
- 別のプレゼンテーションの別の位置にクローンを作成する。
- 別のプレゼンテーションの特定の位置にクローンを作成する。

Aspose.Slides for PHP via Java では、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトが公開する (ISlide オブジェクトのコレクション) である [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) と [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを使用して、上記のスライド クローン作成タイプを実行できます。

## **プレゼンテーションの末尾にスライドをクローンする**
同じプレゼンテーション ファイル内で、既存のスライドの末尾にスライドをクローンして使用したい場合は、以下の手順に従って [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) クラスのインスタンスを取得します。  
1. [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドをパラメータとして渡します。  
1. 変更後のプレゼンテーション ファイルを書き込みます。

以下の例では、プレゼンテーションの最初の位置（インデックス 0）にあるスライドをプレゼンテーションの末尾にクローンしています。
```php
  # プレゼンテーションファイルを表す Presentation クラスをインスタンス化する
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンする
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 変更されたプレゼンテーションをディスクに保存する
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **プレゼンテーション内の別の位置にスライドをクローンする**
同じプレゼンテーション ファイル内で別の位置にスライドをクローンして使用したい場合は、[insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトが公開する **Slides** コレクションを参照してクラスをインスタンス化します。  
1. [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン対象のスライドと新しい位置のインデックスをパラメータとして渡します。  
1. 変更後のプレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、プレゼンテーションのインデックス 0（位置 1）にあるスライドをインデックス 1（位置 2）にクローンしています。
```php
  # プレゼンテーションファイルを表す Presentation クラスをインスタンス化する
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に目的のスライドをクローンする
    $slds = $pres->getSlides();
    # 同じプレゼンテーション内の指定インデックスに目的のスライドをクローンする
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 変更されたプレゼンテーションをディスクに保存する
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **別のプレゼンテーションの末尾にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーション ファイルの既存スライドの末尾に追加したい場合:

1. クローン元となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. クローン先となるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. 目的プレゼンテーションの Presentation オブジェクトが公開する **Slides** コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) クラスをインスタンス化します。  
1. [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン元プレゼンテーションから取得したスライドをパラメータとして渡します。  
1. 変更後の目的プレゼンテーション ファイルを書き込みます。

以下の例では、クローン元プレゼンテーションの最初のインデックスにあるスライドを目的プレゼンテーションの末尾にクローンしています。
```php
  # ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化する
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化する
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクションの末尾にクローンする
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 宛先プレゼンテーションをディスクに保存する
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **別のプレゼンテーションの別の位置にスライドをクローンする**
あるプレゼンテーションからスライドをクローンし、別のプレゼンテーション ファイルの特定の位置に配置したい場合:

1. クローン元プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. スライドを追加したいプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. 目的プレゼンテーションの Presentation オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。  
1. [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) オブジェクトが公開する [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出し、クローン元プレゼンテーションから取得したスライドと目的の位置インデックスをパラメータとして渡します。  
1. 変更後の目的プレゼンテーション ファイルを書き込みます。

以下の例では、クローン元プレゼンテーションのインデックス 0 にあるスライドを目的プレゼンテーションのインデックス 1（位置 2）にクローンしています。
```php
  # ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化する
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンする先の PPTX 用に Presentation クラスをインスタンス化する
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションから目的のスライドを取得し、宛先プレゼンテーションのスライドコレクションの末尾にクローンする
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # 宛先プレゼンテーションをディスクに保存する
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **別のプレゼンテーションの特定の位置にマスタースライド付きでクローンする**
マスタースライドを含むスライドをあるプレゼンテーションから別のプレゼンテーションへクローンする場合、まずソース プレゼンテーションから目的プレゼンテーションへマスタースライドをクローンする必要があります。その後、マスタースライドを使用してスライド自体をクローンします。`addClone(ISlide, IMasterSlide, boolean)` は、ソースではなく目的プレゼンテーションのマスタースライドを受け取ります。マスタースライド付きでスライドをクローンする手順は次のとおりです。

1. ソース プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. 目的プレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。  
1. クローン対象のスライドとそのマスタースライドにアクセスします。  
1. 目的プレゼンテーションの Presentation オブジェクトが公開する Masters コレクションを参照して、[IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) クラスをインスタンス化します。  
1. [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソース PPTX からクローンするマスターをパラメータとして渡します。  
1. 目的プレゼンテーションの Presentation オブジェクトが公開する Slides コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。  
1. [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) オブジェクトが公開する [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出し、ソースプレゼンテーションから取得したスライドと先ほどクローンしたマスタースライドをパラメータとして渡します。  
1. 変更後の目的プレゼンテーション ファイルを書き込みます。

以下の例では、ソースプレゼンテーションのインデックス 0 にあるスライド（マスター付き）を、ソーススライドのマスターを使用して目的プレゼンテーションの末尾にクローンしています。
```php
  # ソースプレゼンテーションファイルをロードするために Presentation クラスをインスタンス化する
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # スライドをクローンする先のプレゼンテーション用に Presentation クラスをインスタンス化する
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションのスライドコレクションから ISlide をインスタンス化し、 
      # マスタースライドも取得する
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # ソースプレゼンテーションから目的のマスタースライドを取得し、 
      # 宛先プレゼンテーションのマスターコレクションにクローンする
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # ソースプレゼンテーションから目的のマスタースライドを取得し、 
      # 宛先プレゼンテーションのマスターコレクションにクローンする
      $iSlide = $masters->addClone($SourceMaster);
      # ソースプレゼンテーションの目的のスライドを、目的のマスターと共に、 
      # 宛先プレゼンテーションのスライドコレクションの末尾にクローンする
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # 宛先プレゼンテーションをディスクに保存する
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```


## **指定セクションの末尾にスライドをクローンする**
同じプレゼンテーション内で別のセクションにスライドをクローンして使用したい場合は、[**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) メソッド（[**ISlideCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) インターフェイスが提供）を使用します。Aspose.Slides for PHP via Java を使用すると、最初のセクションからスライドをクローンし、同じプレゼンテーションの第2セクションに挿入できます。

次のコードスニペットは、スライドをクローンして指定セクションに挿入する方法を示しています。
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


## **FAQ**

**スピーカーノートやレビュアーコメントもクローンされますか？**  

はい。ノートページとレビューコメントはクローンに含まれます。不要な場合は、挿入後に[削除してください](/slides/ja/php-java/presentation-notes/)。

**チャートとそのデータソースはどのように扱われますか？**  

チャートオブジェクト、書式設定、埋め込みデータはコピーされます。チャートが外部ソース（例: OLE 埋め込みワークブック）にリンクされている場合、そのリンクは [OLE オブジェクト](/slides/ja/php-java/manage-ole/) として保持されます。ファイル間で移動した後は、データの可用性と更新動作を確認してください。

**クローンの挿入位置やセクションを制御できますか？**  

はい。特定のスライドインデックスにクローンを挿入し、任意の[セクション](/slides/ja/php-java/slide-section/)に配置できます。対象セクションが存在しない場合は、先に作成してからスライドを移動してください。