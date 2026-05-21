---
title: PHPでプレゼンテーションの BLOB を管理し、メモリ使用を効率化する
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/php-java/manage-blob/
keywords:
- 大規模オブジェクト
- 大規模アイテム
- 大容量ファイル
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
description: "Aspose.Slides for PHP via Java で BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化してプレゼンテーションの処理を最適化します。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内の大きなバイナリ データ（画像、音声、動画、プレゼンテーション ファイル）を扱う際のメモリ使用量を削減するために、BLOB ベースの処理を提供します。

本記事では、BLOB ベースの処理を使用してプレゼンテーションに大容量メディアを追加する方法、プレゼンテーションから大容量メディアをエクスポートする方法、そして大規模なプレゼンテーションをより効率的にロードする方法を示します。また、処理中に一時ファイルを使用する方法と、保存先フォルダーを変更する方法についても説明します。

## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存される大きな項目（写真、プレゼンテーション、ドキュメント、メディア）を指します。

Aspose.Slides for PHP via Java は、巨大ファイルを扱う際のメモリ使用量を削減する方法として、オブジェクトに BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとのやり取りで特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大規模なプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、ロードが遅くなります。したがって、大規模なプレゼンテーションをロードする場合は、ストリームではなくプレゼンテーション ファイル パスを使用することを強く推奨します。
{{% /alert %}}

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を使用して大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/php-java/) for Java は、メモリ使用量を削減するために BLOB を利用したプロセスで大きなファイル（この例では大容量ビデオ ファイル）を追加できるようにします。

この Java のサンプルは、BLOB プロセスを介して大容量ビデオ ファイルをプレゼンテーションに追加する方法を示しています：

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
      # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
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

### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポートする**

Aspose.Slides for PHP via Java は、プレゼンテーションから BLOB を利用したプロセスで大容量ファイル（この例では音声またはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大容量メディア ファイルを抽出したいが、ファイルをコンピューターのメモリにロードしたくない場合があります。BLOB プロセスを介してエクスポートすることで、メモリ使用量を低く抑えることができます。

このコードは、上記の操作を実演しています：

```php
  $hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
  $loadOptions = new LoadOptions();
  # ソース ファイルをロックし、メモリにロードしません
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  # Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
  $pres = new Presentation($hugePresentationWithAudiosAndVideosFile, $loadOptions);
  try {
    # 各ビデオをファイルに保存します。メモリ使用量が高くなるのを防ぐために、バッファが必要です
    # プレゼンテーションのビデオ ストリームから新しく作成したビデオ ファイル用のストリームへデータを転送するために使用します。
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = new JavaClass("java.lang.Byte");
    $buffer = $Array->newInstance($Byte, 8 * 1024);
    # ビデオを走査します
    for($index = 0; $index < java_values($pres->getVideos()->size()) ; $index++) {
      $video = $pres->getVideos()->get_Item($index);
      # プレゼンテーションのビデオ ストリームを開きます。意図的にプロパティへのアクセスを避けたことにご注意ください
      # video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
      # メモリにバイトをロードします。video.GetStream を使用すれば、Stream が返され、かつ
      # ビデオ全体をメモリにロードする必要はありません
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
      # ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く抑えられます
    }
    # 必要に応じて、オーディオ ファイルにも同じ手順を適用できます
  } catch (JavaException $e) {
  } finally {
    $pres->dispose();
  }
```

### **画像を BLOB としてプレゼンテーションに追加する**

[ImageCollection](https://reference.aspose.com/slides/ja/php-java/aspose.slides/imagecollection/) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

この PHP のサンプルは、BLOB プロセスを介して大容量画像を追加する方法を示しています：

```php
  $pathToLargeImage = "large_image.jpg";
  # 画像が追加される新しいプレゼンテーションを作成します。
  $pres = new Presentation();
  try {
    $fileStream = new Java("java.io.FileInputStream", $pathToLargeImage);
    try {
      # 画像をプレゼンテーションに追加します - KeepLocked 動作を選択したのは、
      # 「largeImage.png」ファイルにアクセスするつもりがないためです。
      $img = $pres->getImages()->addImage($fileStream, LoadingStreamBehavior->KeepLocked);
      $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 0, 0, 300, 200, $img);
      # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
      # pres オブジェクトのライフサイクル全体で低く保たれます
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

通常、大規模なプレゼンテーションをロードするには、多くの一時メモリが必要です。プレゼンテーションの全コンテンツがメモリに読み込まれ、ロード元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大容量 PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的なロード方法は、次の PHP コードで示されています：

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

しかし、この方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大規模プレゼンテーションを読み込む**

BLOB を利用したプロセスにより、ほとんどメモリを使用せずに大規模プレゼンテーションをロードできます。この PHP コードは、BLOB プロセスを使用して large.pptx をロードする実装例を示しています：

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

### **一時ファイルのフォルダーを変更する**

BLOB プロセスが使用されると、コンピューターはデフォルトの一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`setTempFilesRootPath` を使用して保存先を変更できます：

```php
  $loadOptions = new LoadOptions();
  $loadOptions->getBlobManagementOptions()->setPresentationLockingBehavior(PresentationLockingBehavior->KeepLocked);
  $loadOptions->getBlobManagementOptions()->setTemporaryFilesAllowed(true);
  $loadOptions->getBlobManagementOptions()->setTempFilesRootPath("temp");

```

{{% alert title="Info" color="info" %}}
`setTempFilesRootPath` を使用する場合、Aspose.Slides は一時ファイル用フォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **プレゼンテーションオブジェクトを破棄してメモリを解放する**

大規模プレゼンテーションを処理する際は、[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/presentation/) インスタンスを適切に破棄し、占有していたメモリを解放してください。プレゼンテーションの使用が終了したら `dispose()` を呼び出して、アンマネージド リソースを解放します。

```php
$presentation = new Presentation("large.pptx");

# ...プレゼンテーションを処理します...
$presentation->save("large.pdf", SaveFormat::Pdf);

# リソースを明示的に解放します。
$presentation->dispose();
```

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、動画などの大型バイナリ オブジェクトが BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB 処理の対象となります。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルにスピルできるようにする BLOB ポリシーによって制御されます。

**プレゼンテーションのロード時に BLOB 処理ルールを設定する場所はどこですか？**

[LoadOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/blobmanagementoptions/) を組み合わせて使用します。ここで BLOB のメモリ上限を設定したり、一時ファイルの使用可否を指定したり、テンポラリ ファイルのルート パスを選択したり、ソース ロックの動作を選択できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取ればよいですか？**

はい。BLOB をメモリに保持すると速度は最大化されますが RAM 使用量が増加します。メモリ上限を下げると、処理の一部が一時ファイルに転嫁され、RAM は削減されますが I/O が増加します。ワークロードと環境に合わせて最適なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ja/php-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) メソッドを使用してください。

**極めて大容量のプレゼンテーション（数ギガバイト規模）を開く際に BLOB オプションは役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されています。一時ファイルを有効化し、ソース ロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させることができます。

**ディスク ファイルではなくストリームからロードする場合にも BLOB ポリシーを使用できますか？**

はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは、選択したロック モードに応じて入力ストリームを所有およびロックでき、許可されている場合は一時ファイルが使用されるため、処理中のメモリ使用量を予測可能に保てます。