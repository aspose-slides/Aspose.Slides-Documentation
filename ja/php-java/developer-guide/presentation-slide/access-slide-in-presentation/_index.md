---
title: PHP でプレゼンテーション スライドにアクセス
linktitle: スライドにアクセス
type: docs
weight: 20
url: /ja/php-java/access-slide-in-presentation/
keywords:
- スライドにアクセス
- スライド インデックス
- スライド ID
- スライド 位置
- 位置の変更
- スライド プロパティ
- スライド 番号
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Java 経由で PHP 用 Aspose.Slides を使用して、PowerPoint および OpenDocument プレゼンテーションのスライドにアクセスし管理する方法を学びます。コード例で生産性を向上させましょう。"
---

Aspose.Slides ではスライドに インデックス と ID の 2 つの方法でアクセスできます。

## **インデックスでスライドにアクセスする**

プレゼンテーション内のすべてのスライドは、スライド位置に基づいて 0 から始まる数値で並んでいます。最初のスライドはインデックス 0 で、2 番目のスライドはインデックス 1 で…という具合です。

プレゼンテーション ファイルを表す **Presentation** クラスは、すべてのスライドを [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)（[Slide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) オブジェクトのコレクション）として公開します。以下の PHP コードはインデックスを使ってスライドにアクセスする方法を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("demo.pptx");
  try {
    # スライドインデックスを使用してスライドにアクセスします
    $slide = $pres->getSlides()->get_Item(0);
  } finally {
    $pres->dispose();
  }
```


## **ID でスライドにアクセスする**

プレゼンテーション内の各スライドには一意の ID が割り当てられています。**Presentation** クラスが提供する [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) メソッドを使用すると、その ID を指定してスライドにアクセスできます。以下の PHP コードは有効なスライド ID を渡して [getSlideById](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getSlideById-long-) メソッドでスライドにアクセスする方法を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("demo.pptx");
  try {
    # スライド ID を取得します
    $id = $pres->getSlides()->get_Item(0)->getSlideId();
    # ID を使用してスライドにアクセスします
    $slide = $pres->getSlideById($id);
  } finally {
    $pres->dispose();
  }
```


## **スライド位置の変更**

Aspose.Slides ではスライドの位置を変更できます。たとえば「最初のスライドを 2 番目のスライドにする」ことが可能です。

1. **Presentation** クラスのインスタンスを作成する。  
1. 位置を変更したいスライドをインデックスで取得する。  
1. [setSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#setSlideNumber) メソッドで新しい位置を設定する。  
1. 変更後のプレゼンテーションを保存する。

以下の PHP コードは位置 1 のスライドを位置 2 に移動する操作を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("Presentation.pptx");
  try {
    # 位置を変更するスライドを取得します
    $sld = $pres->getSlides()->get_Item(0);
    # スライドの新しい位置を設定します
    $sld->setSlideNumber(2);
    # 変更されたプレゼンテーションを保存します
    $pres->save("helloworld_Pos.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


最初のスライドが 2 番目になり、2 番目のスライドが 1 番目になりました。スライドの位置を変更すると、他のスライドは自動的に調整されます。

## **スライド番号の設定**

**Presentation** クラスが提供する [setFirstSlideNumber](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#setFirstSlideNumber-int-) メソッドを使用すると、プレゼンテーションの最初のスライドに新しい番号を指定できます。この操作により他のスライド番号も再計算されます。

1. **Presentation** クラスのインスタンスを作成する。  
1. スライド番号を取得する。  
1. スライド番号を設定する。  
1. 変更後のプレゼンテーションを保存する。

以下の PHP コードは最初のスライド番号を 10 に設定する操作を示しています。
```php
  # プレゼンテーション ファイルを表す Presentation オブジェクトをインスタンス化します
  $pres = new Presentation("HelloWorld.pptx");
  try {
    # スライド番号を取得します
    $firstSlideNumber = $pres->getFirstSlideNumber();
    # スライド番号を設定します
    $pres->setFirstSlideNumber(10);
    # 変更されたプレゼンテーションを保存します
    $pres->save("Set_Slide_Number_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


最初のスライドをスキップしたい場合は、2 番目のスライドから番号付けを開始し（最初のスライドの番号表示は非表示に）次のように設定できます。
```php
  $presentation = new Presentation();
  try {
    $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    $presentation->getSlides()->addEmptySlide($layoutSlide);
    # 最初のプレゼンテーションスライドの番号を設定します
    $presentation->setFirstSlideNumber(0);
    # すべてのスライドのスライド番号を表示します
    $presentation->getHeaderFooterManager()->setAllSlideNumbersVisibility(true);
    # 最初のスライドのスライド番号を非表示にします
    $presentation->getSlides()->get_Item(0)->getHeaderFooterManager()->setSlideNumberVisibility(false);
    # 変更されたプレゼンテーションを保存します
    $presentation->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**ユーザーが見るスライド番号はコレクションの 0 ベース インデックスと一致しますか？**

スライドに表示される番号は任意の値（例: 10）から開始でき、インデックスと一致する必要はありません。番号とインデックスの関係はプレゼンテーションの [first slide number](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/setfirstslidenumber/) 設定で制御されます。

**非表示スライドはインデックスに影響しますか？**

はい。非表示スライドはコレクション内に残り、インデックス計算に含まれます。「非表示」は表示状態を指すもので、コレクション内での位置には影響しません。

**他のスライドが追加または削除されたときにスライドのインデックスは変わりますか？**

はい。インデックスは常にスライドの現在の順序を反映し、挿入、削除、移動が行われた際に再計算されます。