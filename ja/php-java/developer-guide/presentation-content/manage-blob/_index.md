---
title: PHPでプレゼンテーション BLOB を管理して効率的なメモリ使用を実現
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/php-java/manage-blob/
keywords:
- 大きなオブジェクト
- 大きな項目
- 大きなファイル
- BLOB の追加
- BLOB のエクスポート
- 画像を BLOB として追加
- メモリ削減
- メモリ消費
- 大規模プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java で BLOB データを管理し、PowerPoint および OpenDocument のファイル操作を効率化してプレゼンテーションの取り扱いを最適化します。"
---

## **BLOB について**

**BLOB**（**Binary Large Object**）は通常、バイナリ形式で保存される大きな項目（写真、プレゼンテーション、ドキュメント、またはメディア）です。  

Aspose.Slides for PHP via Java は、大きなファイルを扱う際にメモリ使用量を削減する方法でオブジェクトに BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとのやり取りで特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。
{{% /alert %}}

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を介して大きなファイルをプレゼンテーションに追加する**

Aspose.Slides for Java は、メモリ使用量を削減するために BLOB を利用したプロセスで大きなファイル（この例では大きなビデオファイル）をプレゼンテーションに追加できるようにします。

この Java の例では、BLOB プロセスを使用して大きなビデオファイルをプレゼンテーションに追加する方法を示します：
```php
  $pathToVeryLargeVideo = "veryLargeVideo.avi";
  # ビデオが追加される新しいプレゼンテーションを作成します
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToVeryLargeVideo);
    try {
      # ビデオをプレゼンテーションに追加します - KeepLocked 動作を選択したのは、
      # 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
      $video = $pres->getVideos()->addVideo($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addVideoFrame(0, 0, 480, 270, $video);
      # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
      # プレゼンテーションオブジェクトのライフサイクル全体で低く保たれます
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

Aspose.Slides for PHP via Java は、プレゼンテーションから BLOB を利用したプロセスで大きなファイル（この例では音声またはビデオファイル）をエクスポートできるようにします。たとえば、プレゼンテーションから大きなメディアファイルを抽出したいが、ファイルをコンピューターのメモリに読み込ませたくない場合があります。BLOB プロセスでエクスポートすることで、メモリ使用量を低く抑えることができます。

このコードは上記の操作を実演します：
```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # ソースファイルをロックし、メモリに読み込まない
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 各ビデオをファイルに保存します。高いメモリ使用量を防ぐために、バッファが必要です。
    # プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するために使用します。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # ビデオを列挙します
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことにご留意ください
      # video.BinaryData のようなプロパティは、フルビデオを含むバイト配列を返すため、
      # メモリにバイトがロードされます。video.GetStream を使用すると、Stream が返され、メモリに全体をロードしません
      # メモリにビデオ全体をロードする必要がありません。
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

[**IImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/IImageCollection)インターフェイスと[**ImageCollection**](https://reference.aspose.com/slides/php-java/aspose.slides/ImageCollection)クラスのメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱うことができます。

この PHP コードは、BLOB プロセスを使用して大きな画像を追加する方法を示します：
```php
  $pathToLargeImage = "large_image.jpg";
  # 画像が追加される新しいプレゼンテーションを作成します。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # 画像をプレゼンテーションに追加します - KeepLocked 動作を選択したのは
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

通常、大きなプレゼンテーションを読み込むには、コンピューターは大量の一時メモリを必要とします。プレゼンテーションの全内容がメモリに読み込まれ、ロード元のファイルは使用されなくなります。

1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。このプレゼンテーションを読み込む標準的な方法は、以下の PHP コードで示されています。
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

### **BLOB として大きなプレゼンテーションを読み込む**

BLOB を利用したプロセスにより、少量のメモリで大きなプレゼンテーションを読み込むことができます。この PHP コードは、BLOB プロセスを使用して大きなプレゼンテーションファイル（large.pptx）を読み込む実装を示しています。
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

BLOB プロセスを使用すると、コンピューターは既定の一時ファイルフォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存先設定を変更できます。
```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```


{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用すると、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

## **よくある質問**

**Aspose.Slides のプレゼンテーションでどのデータが BLOB として扱われ、BLOB オプションで制御されますか？**  
画像、音声、ビデオなどの大きなバイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が行われます。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量を管理し、必要に応じて一時ファイルへスピル（退避）させることができます。

**プレゼンテーションの読み込み時に BLOB 処理ルールを設定するにはどこですか？**  
プレゼンテーションの読み込み時には、[LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限、一時ファイルの許可/不許可、テンポラリーファイルのルートパス、ソースロックの動作などを設定します。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**  
はい。BLOB をメモリ上に保持すると速度は最大化されますが、RAM 使用量が増加します。メモリ上限を下げると、作業の多くが一時ファイルに転送され、RAM 使用量は減りますが I/O が増加します。ワークロードや環境に合わせて最適なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) メソッドを使用してください。

**非常に大きなプレゼンテーション（例：数ギガバイト）を開く際に BLOB オプションは役立ちますか？**  
はい。[BlobManagementOptions](https://reference.aspose.com/slides/php-java/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されています。一時ファイルを有効にし、ソースロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させることができます。

**ディスクファイルではなくストリームから読み込む場合でも BLOB ポリシーを使用できますか？**  
はい。同じルールがストリームにも適用されます。プレゼンテーション インスタンスは（選択したロックモードに応じて）入力ストリームを所有およびロックでき、許可されている場合は一時ファイルが使用されるため、処理中のメモリ使用量を予測可能に保ちます。