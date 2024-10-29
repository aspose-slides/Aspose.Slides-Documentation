---
title: BLOBの管理
type: docs
weight: 10
url: /ja/php-java/manage-blob/
description: PHPを使用してPowerPointプレゼンテーション内のBLOBを管理します。PHPを使用してPowerPointプレゼンテーションのメモリ消費を削減するためにBLOBを使用してください。PHPを使用してBLOBを介してPowerPointプレゼンテーションに大きなファイルを追加します。PHPを使用してBLOBを介してPowerPointプレゼンテーションから大きなファイルをエクスポートします。PHPを使用してBLOBとして大きなPowerPointプレゼンテーションをロードします。
---

## **BLOBについて**

**BLOB**（**バイナリ大オブジェクト**）は通常、バイナリ形式で保存された大きなアイテム（写真、プレゼンテーション、ドキュメント、メディア）です。 

Aspose.Slides for PHP via Javaは、大きなファイルが関与する場合にメモリ消費を削減する方法でBLOBをオブジェクトに使用することを可能にします。

{{% alert title="情報" color="info" %}}

ストリームとの相互作用時に特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーすることがあります。そのため、ストリームを介して大きなプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、読み込みが遅くなる場合があります。したがって、大きなプレゼンテーションをロードする予定がある場合は、ストリームではなくプレゼンテーションファイルのパスを使用することを強く推奨します。

{{% /alert %}}

## **BLOBを使用してメモリ消費を削減**

### **BLOBを介してプレゼンテーションに大きなファイルを追加**

[Aspose.Slides](/slides/ja/php-java/) for Javaは、BLOBを介したプロセスを通じて大きなファイル（この場合、大きなビデオファイル）を追加することでメモリ消費を削減することを可能にします。

このJavaは、BLOBプロセスを通じてプレゼンテーションに大きなビデオファイルを追加する方法を示しています：

```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # ビデオが追加される新しいプレゼンテーションを作成
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # プレゼンテーションにビデオを追加します - "veryLargeVideo.avi"ファイルにアクセスするつもりがないため、KeepLocked動作を選択しました。
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費はpresオブジェクトのライフサイクルを通じて低く保たれます。
      $pres->save("presentationWithLargeVideo.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


### **プレゼンテーションからBLOBを介して大きなファイルをエクスポート**
Aspose.Slides for PHP via Javaは、プレゼンテーションからBLOBを介したプロセスを使って大きなファイル（この場合、音声またはビデオファイル）をエクスポートすることを可能にします。たとえば、プレゼンテーションから大きなメディアファイルを抽出する必要があるが、そのファイルをコンピュータのメモリにロードしたくない場合があります。BLOBプロセスを介してファイルをエクスポートすることで、メモリ消費を低く抑えることができます。

このコードは、記述された操作を示しています：

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # ソースファイルをロックし、メモリにロードしません
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # プレゼンテーションのインスタンスを作成し、「hugePresentationWithAudiosAndVideos.pptx」ファイルをロックします。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 各ビデオをファイルに保存します。メモリ使用量を高くしないために、プレゼンテーションのビデオストリームから新しく作成するビデオファイル用のストリームにデータを転送するためのバッファが必要です。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # ビデオを通過して反復します
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # プレゼンテーションビデオストリームを開きます。ビデオの.BinaryDataのようなプロパティにアクセスすることを意図的に避けていることに注意してください - このプロパティは、フルビデオを含むバイト配列を返し、その後、バイトがメモリにロードされるからです。video.GetStreamを使用すると、Streamが返され、ビデオ全体をメモリにロードする必要がありません。
      $presVideoStream = $video->getStream();
      try {
        $outputFileStream = new Java("java.io.FileOutputStream", "video" . $index . ".avi");
        try {
          $bytesRead;
          while ($bytesRead = $presVideoStream->read($buffer, 0, java_values($Array->getLength($buffer))) > 0) {
            $outputFileStream->write($buffer, 0, $bytesRead);
          } 
        } finally {
          $outputFileStream->close();
        }
      } finally {
        $presVideoStream->close();
      }
      # メモリ消費は、ビデオまたはプレゼンテーションのサイズに関係なく低く保たれます。
    }
    # 必要に応じて、音声ファイルにも同じ手順を適用できます。
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **プレゼンテーションにBLOBとして画像を追加**
[**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection)インターフェースと[**ImageCollection** ](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection)クラスのメソッドを使用して、大きな画像をストリームとして追加し、BLOBとして扱うことができます。

このPHPコードは、BLOBプロセスを通じて大きな画像を追加する方法を示しています：

```php
  $pathToLargeImage = "large_image.jpg";
  # 画像が追加される新しいプレゼンテーションを作成します。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # プレゼンテーションに画像を追加します - "largeImage.png"ファイルにアクセスする意図がないため、KeepLocked動作を選択しました。
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費はpresオブジェクトのライフサイクルを通じて低く保たれます。
      $pres->save("presentationWithLargeImage.pptx", SaveFormat::Pptx);
    } finally {
      if (!java_is_null($fileStream)) {
        $fileStream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **メモリと大きなプレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピュータは大量の一時メモリを必要とします。すべてのプレゼンテーションの内容がメモリにロードされ、プレゼンテーションがロードされたファイルの使用が停止します。

1.5 GBのビデオファイルを含む大きなPowerPointプレゼンテーション（large.pptx）を考えてみてください。プレゼンテーションをロードする標準的な方法は、以下のPHPコードに記述されています：

```php
  $pres = new Presentation("large.pptx");
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

しかし、この方法では約1.6GBの一時メモリが消費されます。

### **BLOBとして大きなプレゼンテーションをロード**

BLOBを利用するプロセスを介して、少ないメモリを使用しながら大きなプレゼンテーションをロードできます。このPHPコードは、BLOBプロセスを使用して大きなプレゼンテーションファイル（large.pptx）をロードする実装を示しています：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $pres = new Presentation("large.pptx", $loadOptions);
  try {
    $pres->save("large.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **一時ファイルのフォルダを変更する**

BLOBプロセスが使用されると、コンピュータは一時ファイルを一時ファイル用のデフォルトフォルダに作成します。一時ファイルを別のフォルダに保持したい場合は、`TempFilesRootPath`を使用してストレージの設定を変更できます：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="情報" color="info" %}}

`TempFilesRootPath`を使用すると、Aspose.Slidesは一時ファイルを保存するフォルダを自動的に作成しません。フォルダを手動で作成する必要があります。 

{{% /alert %}}