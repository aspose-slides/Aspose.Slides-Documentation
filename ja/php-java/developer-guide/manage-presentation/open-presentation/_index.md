---
title: プレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /php-java/open-presentation/
keywords: "PowerPointを開く, PPTX, PPT, プレゼンテーションを開く, プレゼンテーションをロード, Java"
description: "プレゼンテーションPPT、PPTX、ODPを開くまたはロードする"
---

ゼロからPowerPointプレゼンテーションを作成することに加えて、Aspose.Slidesを使用すると、既存のプレゼンテーションを開くことができます。プレゼンテーションをロードすると、そのプレゼンテーションに関する情報を取得したり、プレゼンテーションを編集したり（スライドの内容）、新しいスライドを追加したり既存のスライドを削除したりできます。

## プレゼンテーションを開く

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスをインスタンス化し、コンストラクタにファイルパス（開きたいプレゼンテーションの）を渡すだけです。

以下のPHPコードは、プレゼンテーションを開く方法と、そのスライド数を取得する方法を示しています：

```php
  # Presentationクラスをインスタンス化し、そのコンストラクタにファイルパスを渡します
  $pres = new Presentation("Presentation.pptx");
  try {
    # プレゼンテーションに存在するスライドの合計数を出力します
    echo($pres->getSlides()->size());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[Password](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#getPassword--)プロパティ（[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/)クラスから）を介してパスワードを渡すことで、プレゼンテーションを復号化し、ロードすることができます。このPHPコードはその操作を示しています：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->setPassword("YOUR_PASSWORD");
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
    # 復号化されたプレゼンテーションで何らかの作業を行います
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## 大きなプレゼンテーションを開く

Aspose.Slidesは、[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions)クラスの下に、特に[BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setBlobManagementOptions-com.aspose.slides.IBlobManagementOptions-)プロパティを提供しており、大きなプレゼンテーションをロードできるようにしています。

以下のJavaコードは、大きなプレゼンテーション（サイズが2GB程度）のロード操作を示しています：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setMaxBlobsBytesInMemory(0);
  $pres = new Presentation("veryLargePresentation.pptx", $loadOptions);
  try {
    # 大きなプレゼンテーションがロードされ、使用可能ですが、メモリ使用量はまだ低いです。
    # プレゼンテーションに変更を加えます。
    $pres->getSlides()->get_Item(0)->setName("非常に大きなプレゼンテーション");
    # プレゼンテーションは別のファイルに保存されます。操作中のメモリ使用量は低いままです。
    $pres->save("veryLargePresentation-copy.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="info" title="情報" %}}

ストリームとの相互作用で特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーする場合があります。ストリームを介して大きなプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、遅い読み込みを引き起こすことになります。したがって、大きなプレゼンテーションをロードする予定がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強くお勧めします。

大きなオブジェクト（動画、音声、大きな画像など）を含むプレゼンテーションを作成したい場合は、[Blob機能](https://docs.aspose.com/slides/php-java/manage-blob/)を使用してメモリ使用量を減らすことができます。

{{%/alert %}} 

## プレゼンテーションをロードする

Aspose.Slidesは、外部リソースを管理するための単一メソッドを持つ[IResourceLoadingCallback](https://reference.aspose.com/slides/php-java/aspose.slides/iresourceloadingcallback/)を提供します。このPHPコードは、`IResourceLoadingCallback`インターフェースを使用する方法を示しています：

```php

class ImageLoadingHandler {
    function resourceLoading($args) {
      if (java_values($args->getOriginalUri()->endsWith(".jpg"))) {
        # 代替画像をロードします
        $file = new Java("java.io.File", "aspose-logo.jpg");
        $Array = new JavaClass("java.lang.reflect.Array");
        $Byte = new JavaClass("java.lang.Byte");
        $imageBytes = $Array->newInstance($Byte, $Array->getLength($file));
        try {
            $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", $file));
            $dis->readFully($imageBytes);
        } finally {
            if (!java_is_null($dis)) $dis->close();
        }
          $args->setData($imageBytes);
          return ResourceLoadingAction::UserProvided;
      } else if (java_values($args->getOriginalUri()->endsWith(".png"))) {
        # 代替URLを設定します
        $args->setUri("http://www.google.com/images/logos/ps_logo2.png");
        return ResourceLoadingAction::Default;
      }
      # その他の画像はスキップします
      return ResourceLoadingAction::Skip;
    }
  }

  $opts = new LoadOptions();
  $loadingHandler = java_closure(new ImageLoadingHandler(), null, java("com.aspose.slides.IResourceLoadingCallback"));
  $opts->setResourceLoadingCallback($loadingHandler);
  $pres = new Presentation("presentation.pptx", $opts);
```

## 埋め込まれたバイナリオブジェクトなしでプレゼンテーションをロードする

PowerPointプレゼンテーションには、以下の種類の埋め込まれたバイナリオブジェクトが含まれている可能性があります：

- VBAプロジェクト ([IPresentation.VbaProject](https://reference.aspose.com/slides/java/com.aspose.slides/vbaproject/));
- 埋め込まれたOLEオブジェクトデータ ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- ActiveXコントロールのバイナリデータ ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/java/com.aspose.slides/icontrol/#getActiveXControlBinary--));

[ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-)プロパティを使用すると、埋め込まれたバイナリオブジェクトなしでプレゼンテーションをロードできます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを削除するのに役立ちます。

以下のコードは、悪意のあるコンテンツなしでプレゼンテーションをロードおよび保存する方法を示しています：

```java
  $loadOptions = new LoadOptions();
  $loadOptions->setDeleteEmbeddedBinaryObjects(true);

  $pres = new Presentation("malware.ppt", $loadOptions);
  try {
    $pres->save("clean.ppt", SaveFormat::Ppt);
  } finally {
    if (!java_is_null(pres)) { 
      $pres->dispose();
    }
  }
```

## プレゼンテーションを開いて保存する

プレゼンテーションを開いて保存するための手順：

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスのインスタンスを作成し、開きたいファイルを渡します。
2. プレゼンテーションを保存します。  

```php
  # PPTファイルを表すPresentationオブジェクトをインスタンス化します
  $pres = new Presentation();
  try {
    # ...ここで作業を行います...
    # プレゼンテーションをファイルに保存します
    $pres->save("demoPass.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```