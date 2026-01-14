---
title: PHPでプレゼンテーションBLOBを管理してメモリ使用を効率化
linktitle: BLOBの管理
type: docs
weight: 10
url: /ja/php-java/manage-blob/
keywords:
- 大きなオブジェクト
- 大きな項目
- 大きなファイル
- BLOBの追加
- BLOBのエクスポート
- 画像をBLOBとして追加
- メモリ削減
- メモリ消費
- 大規模プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java における BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化してプレゼンテーション処理を最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、ドキュメント、またはメディア）です。

Aspose.Slides for PHP via Java は、大きなファイルを扱う際にメモリ消費を抑える方法でオブジェクトに BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとのやり取りで特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリーム経由で大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。
{{% /alert %}}

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を介して大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/php-java/) for Java は、BLOB を利用したプロセスで大きなファイル（この例では大きなビデオファイル）を追加し、メモリ使用量を削減できます。

この Java は、BLOB プロセスを使用して大きなビデオファイルをプレゼンテーションに追加する方法を示しています:
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # ビデオを追加するための新しいプレゼンテーションを作成します
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # プレゼンテーションにビデオを追加しましょう - KeepLocked 動作を選択したのは、
      # 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
      # pres オブジェクトのライフサイクル全体で低く保たれます
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


### **BLOB を介してプレゼンテーションから大きなファイルをエクスポートする**
Aspose.Slides for PHP via Java は、BLOB を利用したプロセスで大きなファイル（この例では音声またはビデオファイル）をプレゼンテーションからエクスポートできます。たとえば、プレゼンテーションから大容量メディアファイルを抽出したいが、コンピュータのメモリに読み込ませたくない場合があります。BLOB プロセスを介してエクスポートすれば、メモリ使用量を低く抑えることができます。

このコードは上記の操作を示しています:
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # ソースファイルをロックし、メモリに読み込まないようにします
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 各ビデオをファイルに保存しましょう。メモリ使用量の増加を防ぐため、使用されるバッファが必要です
    # プレゼンテーションのビデオストリームから新規作成したビデオファイル用のストリームへデータを転送するためです。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # ビデオを反復処理します
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことに留意してください
      # video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
      # メモリにバイトが読み込まれます。video.GetStream を使用すると、Stream が返され、メモリに全体を読み込むことはありません
      # ビデオ全体をメモリに読み込む必要がありません。
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
      # ビデオやプレゼンテーションのサイズに関わらず、メモリ消費は低く保たれます。
    }
    # 必要に応じて、オーディオファイルにも同様の手順を適用できます。
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```


### **画像を BLOB としてプレゼンテーションに追加する**
[ImageCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagecollection/) クラスのメソッドを使用すると、画像をストリームとして追加し、BLOB として扱うことができます。

この PHP コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています:
```php
  $pathToLargeImage = "large_image.jpg";
  # 画像を追加する新しいプレゼンテーションを作成します。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # プレゼンテーションに画像を追加しましょう - KeepLocked 動作を選択したのは、
      # 「largeImage.png」ファイルにアクセスするつもりがないためです。
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
      # pres オブジェクトのライフサイクル全体で低く保たれます。
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


## **メモリと大規模プレゼンテーション**

通常、大規模なプレゼンテーションを読み込むには多くの一時メモリが必要です。プレゼンテーション全体の内容がメモリにロードされ、元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。そのプレゼンテーションを読み込む標準的な方法は次の PHP コードで示されています:
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


しかし、この方法は約 1.6 GB の一時メモリを消費します。

### **BLOB として大規模プレゼンテーションを読み込む**

BLOB を利用することで、少量のメモリで大規模プレゼンテーションを読み込むことができます。この PHP コードは、BLOB プロセスを使用して large.pptx を読み込む実装例です:
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


### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、コンピュータはデフォルトの一時フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`setTempFilesRootPath` を使用して保存先を変更できます:
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
`setTempFilesRootPath` を使用すると、Aspose.Slides は自動的にフォルダーを作成しません。フォルダーは自分で作成する必要があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB とみなされ、BLOB オプションで制御されるデータは何ですか？**  
画像、音声、ビデオなどの大容量バイナリオブジェクトが BLOB とみなされます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理の対象となります。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量の管理や必要に応じた一時ファイルへのスピルが可能です。

**プレゼンテーションの読み込み時に BLOB 処理のルールはどこで設定しますか？**  
[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限や一時ファイルの使用可否、ルートパス、ソースロックの動作などを設定します。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**  
はい。BLOB をメモリに保持すると速度は最大化しますが RAM 消費が増加します。メモリ上限を下げれば、より多くの処理が一時ファイルにオフロードされ、RAM は減りますが I/O が増加します。`setMaxBlobsBytesInMemory` メソッドで適切なバランスを設定してください。

**非常に大きなプレゼンテーション（数 GB）を開く際に BLOB オプションは役立ちますか？**  
はい。[BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化やソースロックの使用により、ピーク RAM 使用量を大幅に削減し、安定した処理を実現します。

**ストリームから読み込む場合でも BLOB ポリシーは適用できますか？**  
はい。ストリームにも同じルールが適用されます。プレゼンテーションインスタンスは入力ストリームを所有およびロックでき（ロックモードに依存）、許可された場合は一時ファイルが使用され、処理中のメモリ使用量が予測可能になります。