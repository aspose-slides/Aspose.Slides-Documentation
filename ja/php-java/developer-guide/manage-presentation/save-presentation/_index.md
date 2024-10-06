---
title: プレゼンテーションを保存
type: docs
weight: 80
url: /ja/php-java/save-presentation/
---

## **概要**
{{% alert color="primary" %}} 

[プレゼンテーションを開く](/slides/ja/php-java/open-presentation/)では、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスを使用してプレゼンテーションを開く方法について説明します。この記事では、プレゼンテーションを作成し、保存する方法について説明します。

{{% /alert %}} 

[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスは、プレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のプレゼンテーションを変更する場合でも、作業が完了したらプレゼンテーションを保存したいと思うでしょう。Aspose.Slides for PHP via Javaを使用すると、プレゼンテーションは**ファイル**または**ストリーム**として保存できます。この記事では、プレゼンテーションを異なる方法で保存する方法を説明します。

## **ファイルにプレゼンテーションを保存**
[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスの[**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドを呼び出して、プレゼンテーションをファイルに保存します。ファイル名と[**SaveFormat**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveFormat)を[**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドに渡してください。

次に示す例では、Aspose.Slides for PHP via Javaを使用してプレゼンテーションを保存する方法を示します。

```php
  # PPTファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation();
  try {
    # ...ここで作業を行う...
    # プレゼンテーションをファイルに保存
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ストリームにプレゼンテーションを保存**
[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスの[**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.io.OutputStream-int-)メソッドに出力ストリームを渡すことで、プレゼンテーションをストリームに保存できます。プレゼンテーションを保存できるストリームの種類は多数あります。以下の例では、新しいプレゼンテーションファイルを作成し、図形にテキストを追加して、プレゼンテーションをストリームに保存しています。

```php
  # PPTファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation();
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 200, 200, 200);
    # 図形にテキストを追加
    $shape->getTextFrame()->setText("このデモでは、PowerPointファイルを作成し、それをストリームに保存する方法を示します。");
    $os = new Java("java.io.FileOutputStream", "Save_As_Stream_out.pptx");
    $pres->save($os, SaveFormat::Pptx);
    $os->close();
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **既定のビュータイプでプレゼンテーションを保存**
Aspose.Slides for PHP via Javaは、[ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties)クラスを通じて、生成されたプレゼンテーションがPowerPointで開かれる際のビュータイプを設定する機能を提供します。[**setLastView**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewProperties#setLastView-int-)プロパティを使用して、[**ViewType**](https://reference.aspose.com/slides/php-java/aspose.slides/ViewType)列挙体を使用してビュータイプを設定します。

```php
  # プレゼンテーションファイルを開く
  $pres = new Presentation();
  try {
    # ビュータイプを設定
    $pres->getViewProperties()->setLastView(ViewType::SlideMasterView);
    # プレゼンテーションを保存
    $pres->save("newDemo.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **厳格なOffice Open XML形式でプレゼンテーションを保存**
Aspose.Slidesは、プレゼンテーションを厳格なOffice Open XML形式で保存することを許可します。その目的のために、プレゼンテーションファイルを保存する際にConformanceプロパティを設定できる[**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions)クラスを提供します。その値を[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict)に設定すると、出力プレゼンテーションファイルは厳格なOpen XML形式で保存されます。

以下のサンプルコードでは、プレゼンテーションを作成し、厳格なOffice Open XML形式で保存します。[**Save**](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)メソッドを呼び出す際に、[**PptxOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/pptxoptions)オブジェクトを渡し、Conformanceプロパティを[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/php-java/aspose.slides/Conformance#Iso29500_2008_Strict)に設定します。

```php
  # PPTファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation();
  try {
    # 最初のスライドを取得
    $slide = $pres->getSlides()->get_Item(0);
    # タイプラインの自動図形を追加
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # 厳格なOffice Open XML形式の保存オプションを設定
    $options = new PptxOptions();
    $options->setConformance(Conformance->Iso29500_2008_Strict);
    # プレゼンテーションをファイルに保存
    $pres->save("demoPass.pptx", SaveFormat::Pptx, $options);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Zip64モードでOffice Open XML形式にプレゼンテーションを保存**
Office Open XMLファイルは、圧縮サイズとファイルの合計サイズ、アーカイブ内のファイル数の最大限度がそれぞれ4GB（2^32バイト）であるZIP-アーカイブです。また、アーカイブ内に含めることができるファイルの数の上限は65,535（2^16-1）です。ZIP64形式の拡張により上限が2^64に増加します。

新しい[**IPptxOptions.Zip64Mode**](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/)プロパティを使用すると、保存されたOffice Open XMLファイルにZIP64形式の拡張を使用するタイミングを選択できます。

このプロパティには以下のモードがあります：

- [Zip64Mode.IfNecessary](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#IfNecessary)は、プレゼンテーションが上記の制限を超える場合にのみZIP64形式の拡張が使用されることを意味します。これはデフォルトのモードです。
- [Zip64Mode.Never](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Never)は、ZIP64形式の拡張が使用されないことを意味します。 
- [Zip64Mode.Always](https://reference.aspose.com/slides/php-java/aspose.slides/zip64mode/#Always)は、ZIP64形式の拡張が常に使用されることを意味します。

以下のコードは、ZIP64形式の拡張を使用してPPTX形式でプレゼンテーションを保存する方法を示しています。

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $pptxOptions = new PptxOptions();
    $pptxOptions->setZip64Mode(Zip64Mode::Always);
    
    $pres->save("Sample-zip64.pptx", SaveFormat::Pptx, $pptxOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="注意" color="warning" %}}

Zip64Mode.Neverモードで保存した場合、プレゼンテーションがZIP32形式で保存できない場合は、[PptxException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxexception/)がスローされます。

{{% /alert %}}

## **パーセントでの進行状況更新を保存**
新しい[**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback)インターフェースが[**ISaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/ISaveOptions)インターフェースおよび[**SaveOptions**](https://reference.aspose.com/slides/php-java/aspose.slides/SaveOptions)抽象クラスに追加されました。[**IProgressCallback**](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback)インターフェースは、進行状況の更新をパーセントで保存するためのコールバックオブジェクトを表します。

以下のコードスニペットは、[IProgressCallback](https://reference.aspose.com/slides/php-java/aspose.slides/IProgressCallback)インターフェースの使用方法を示しています。

```php
  class ExportProgressHandler {
    function reporting($progressValue) {
      # ここで進行状況のパーセント値を使用
      $progress = java("java.lang.Double")->valueOf($progressValue)->intValue();
      echo($progress . "% ファイルが変換されました");
    }
  }

  # プレゼンテーションファイルを開く
  $pres = new Presentation("ConvertToPDF.pptx");
  try {
    $saveOptions = new PdfOptions();
    $progressHandler = java_closure(new ExportProgressHandler(), null, java("com.aspose.slides.IProgressCallback"));
    $saveOptions->setProgressCallback($progressHandler);
    $pres->save("ConvertToPDF.pdf", SaveFormat::Pdf, $saveOptions);
  } finally {
    $pres->dispose();
  }
```

{{% alert title="情報" color="info" %}}

独自のAPIを使用して、Asposeはユーザーがプレゼンテーションを複数のファイルに分割できる[無料のPowerPointスプリッターアプリ](https://products.aspose.app/slides/splitter)を開発しました。基本的に、このアプリは、特定のプレゼンテーションから選択したスライドを新しいPowerPoint（PPTXまたはPPT）ファイルとして保存します。

{{% /alert %}}