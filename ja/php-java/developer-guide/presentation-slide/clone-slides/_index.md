---
title: スライドのクローン
type: docs
weight: 35
url: /php-java/clone-slides/
---


## **プレゼンテーション内のスライドをクローン**
クローンは、何かの正確なコピーや複製を作成するプロセスです。Aspose.Slides for PHP via Java は、任意のスライドのコピーまたはクローンを作成し、そのクローンを現在のプレゼンテーションまたは他の開いているプレゼンテーションに挿入することを可能にします。スライドクローンのプロセスは、元のスライドを変更することなく、開発者が修正できる新しいスライドを作成します。スライドをクローンする方法はいくつかあります。

- プレゼンテーションの末尾にクローン。
- プレゼンテーション内の別の位置にクローン。
- 別のプレゼンテーションの末尾にクローン。
- 別のプレゼンテーション内の別の位置にクローン。
- 別のプレゼンテーション内の特定の位置にクローン。

Aspose.Slides for PHP via Java では、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトによって公開された (a collection of [ISlide](https://reference.aspose.com/slides/php-java/aspose.slides/ISlide) objects) [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) クラスが、上記のタイプのスライドクローンを実行するための [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドと [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを提供します。

## **プレゼンテーションの末尾にクローン**
スライドをクローンし、その後、既存のスライドの末尾に同じプレゼンテーションファイル内で使用したい場合は、以下に示す手順に従って [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを使用してください。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトによって公開されたスライドコレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。
1. クローンするスライドをパラメータとして [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドに渡して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) オブジェクトによって公開された [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出します。
1. 修正されたプレゼンテーションファイルを書き込みます。

以下の例では、プレゼンテーションの最初の位置（ゼロインデックス）のスライドをプレゼンテーションの末尾にクローンしました。

```php
  # プレゼンテーションファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に希望のスライドをクローン
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # 修正されたプレゼンテーションをディスクに保存
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **プレゼンテーション内の別の位置にクローン**
スライドをクローンし、同じプレゼンテーションファイル内で別の位置で使用したい場合は、[insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを使用します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) オブジェクトによって公開された [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) コレクションを参照してクラスをインスタンス化します。
1. クローンするスライドと新しい位置のインデックスをパラメータとして [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドに渡して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) オブジェクトによって公開された [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドを呼び出します。
1. 修正されたプレゼンテーションを PPTX ファイルとして書き込みます。

以下の例では、プレゼンテーションのゼロインデックス（位置 1）のスライドをインデックス 1（位置 2）にクローンしました。

```php
  # プレゼンテーションファイルを表す Presentation クラスをインスタンス化
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # 同じプレゼンテーション内のスライドコレクションの末尾に希望のスライドをクローン
    $slds = $pres->getSlides();
    # 同じプレゼンテーション内で指定されたインデックスに希望のスライドをクローン
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # 修正されたプレゼンテーションをディスクに保存
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **別のプレゼンテーションの末尾にクローン**
1 つのプレゼンテーションからスライドをクローンし、別のプレゼンテーションファイルの既存のスライドの末尾で使用したい場合：

1. スライドをコピーするプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドが追加される先のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 目的のプレゼンテーションの [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) コレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) クラスをインスタンス化します。
1. [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドに、ソースプレゼンテーションからのスライドをパラメータとして渡して呼び出します。
1. 修正された目的のプレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションの最初のインデックスからスライドを目的のプレゼンテーションの末尾にクローンしました。

```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンするための目的の PPTX に対して Presentation クラスをインスタンス化
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションのスライドコレクションから希望のスライドを末尾にクローン
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # 目的のプレゼンテーションをディスクに保存
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **別のプレゼンテーション内の別の位置にクローン**
1 つのプレゼンテーションからスライドをクローンし、特定の位置に使用したい場合：

1. スライドがクローンされるソースプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 希望の位置にスライドが追加されるプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. 目的のプレゼンテーションの [**Slides**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) コレクションを参照して [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。
1. 元のプレゼンテーションからスライドとともに希望の位置をパラメータとして [insertClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) メソッドに渡して呼び出します。
1. 修正された目的のプレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスからスライドを目的のプレゼンテーションのインデックス 1（位置 2）にクローンしました。

```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # スライドをクローンするための目的の PPTX に対して Presentation クラスをインスタンス化
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションからのデスティネーションプレゼンテーション内のスライドコレクションの末尾に希望のスライドをクローン
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # デスティネーションプレゼンテーションをディスクに保存
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **別のプレゼンテーション内の特定の位置にクローン**
ソースプレゼンテーションからマスタースライドを持たないスライドをクローンし、別のプレゼンテーションに使用する必要がある場合、まずソースプレゼンテーションから目的のマスタースライドを目的のプレゼンテーションにクローンする必要があります。その後、マスタースライドを使用してマスタースライドを持つスライドをクローンします。[**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) は、ソースプレゼンテーションからではなく、目的のプレゼンテーションからのマスタースライドを期待します。マスターを持つスライドをクローンするには、以下の手順に従ってください。

1. ソースプレゼンテーションからスライドをクローンするための [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. スライドがクローンされる目的のプレゼンテーションを含む [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスのインスタンスを作成します。
1. クローンするスライドにアクセスし、マスタースライドを取得します。
1. 目的のプレゼンテーションのオブジェクトによって公開されたマスターコレクションを参照して [IMasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/IMasterSlideCollection) クラスをインスタンス化します。
1. [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出してソース PPTX からクローンされるマスターをパラメータとして渡します。
1. 目的のプレゼンテーションオブジェクトによって公開されたスライドコレクションを参照して、[ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) クラスをインスタンス化します。
1. ソースプレゼンテーションからクローンされるスライドとマスタースライドをパラメータとして [addClone](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) メソッドを呼び出します。
1. 修正された目的のプレゼンテーションファイルを書き込みます。

以下の例では、ソースプレゼンテーションのゼロインデックスに位置しているマスタースライドを持つスライドを、ソーススライドのマスタースライドを使用して目的のプレゼンテーションの末尾にクローンしました。

```php
  # ソースプレゼンテーションファイルを読み込むために Presentation クラスをインスタンス化
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # スライドをクローンするための目的のプレゼンテーションに対して Presentation クラスをインスタンス化
    $destPres = new Presentation();
    try {
      # ソースプレゼンテーションのスライドコレクションから希望のスライドとマスタースライドをインスタンス化
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # 目的のプレゼンテーションのマスターコレクションにソースプレゼンテーションから希望のマスタースライドをクローン
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # クローンしたマスタースライドを目的のプレゼンテーションのマスターコレクションに追加
      $iSlide = $masters->addClone($SourceMaster);
      # 目的のプレゼンテーションのスライドコレクションの末尾に希望のスライドを追加
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # デスティネーションプレゼンテーションをディスクに保存
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **指定されたセクションの末尾にクローン**
スライドをクローンし、同じプレゼンテーションファイル内で別のセクションで使用したい場合は、[**addClone**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) メソッドを使用します。Aspose.Slides for PHP via Java は、最初のセクションからスライドをクローンし、その後、同じプレゼンテーションの第 2 セクションにそのクローンしたスライドを挿入することができます。

以下のコードスニペットは、スライドをクローンし、クローンしたスライドを指定されたセクションに挿入する方法を示しています。

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # デスティネーションプレゼンテーションをディスクに保存
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```