---
title: JavaScript でプレゼンテーション BLOB を管理し、メモリ使用を効率化
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-blob/
keywords:
- 大きなオブジェクト
- 大きなアイテム
- 大きなファイル
- BLOB を追加
- BLOB をエクスポート
- 画像を BLOB として追加
- メモリを削減
- メモリ消費
- 大規模プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js の JavaScript で BLOB データを管理し、PowerPoint および OpenDocument ファイルの操作を効率化してプレゼンテーションの処理を最適化します。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内の大きなバイナリ データを BLOB ベースで処理し、大容量の画像、オーディオ、ビデオ、プレゼンテーション ファイルを扱う際のメモリ使用量を削減するのに役立ちます。

この記事では、BLOB ベースの処理を使用してプレゼンテーションに大きなメディアを追加する方法、プレゼンテーションから大きなメディアをエクスポートする方法、そして大規模なプレゼンテーションをより効率的に読み込む方法を示します。また、処理中に一時ファイルを使用する方法と、それらを保存するフォルダーを変更する方法についても説明します。

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存された大きな項目（写真、プレゼンテーション、ドキュメント、またはメディア）です。

Aspose.Slides for Node.js via Java は、大きなファイルが関係する場合にメモリ使用量を削減する方法でオブジェクトに BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとのやり取りで特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイル パスを使用することを強くお勧めします。
{{% /alert %}}

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を使用して大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/nodejs-java/) for Node.js via Java は、メモリ使用量を削減するために BLOB を伴うプロセスを通じて大きなファイル（この場合は大きなビデオ ファイル）を追加できるようにします。

以下の JavaScript は、BLOB プロセスを使用して大きなビデオ ファイルをプレゼンテーションに追加する方法を示します。

```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// 新しいプレゼンテーションを作成し、そこにビデオを追加します
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // ビデオをプレゼンテーションに追加します - KeepLocked 動作を選んだのは、
        // "veryLargeVideo.avi" ファイルにアクセスするつもりがないからです。
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // プレゼンテーションを保存します。大きなプレゼンテーションが出力されても、
        // pres オブジェクトのライフサイクル全体でメモリ使用量は低く保たれます
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポートする**

Aspose.Slides for Node.js via Java は、BLOB を伴うプロセスを通じてプレゼンテーションから大きなファイル（この場合はオーディオまたはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディア ファイルを抽出したいが、コンピューターのメモリにロードしたくない場合があります。BLOB プロセスを使用してファイルをエクスポートすることで、メモリ使用量を低く抑えることができます。

以下の JavaScript コードは、上記の操作を示しています。

```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// ソース ファイルをロックし、メモリに読み込まない
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存します。高いメモリ使用量を防ぐために、バッファが必要です
    // プレゼンテーションのビデオ ストリームから新しく作成したビデオ ファイル用のストリームへデータを転送します。
    var buffer = new byte[8 * 1024];
    // ビデオを順に処理します
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // プレゼンテーションのビデオ ストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
        // video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
        // メモリにバイトがロードされます。video.GetStream を使用すると、Stream が返され、メモリにロードされません
        // ビデオ全体をメモリにロードする必要がなくなります。
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // ビデオやプレゼンテーションのサイズにかかわらず、メモリ消費は低く抑えられます。
    }
    // 必要に応じて、オーディオ ファイルにも同じ手順を適用できます。
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **プレゼンテーションに画像を BLOB として追加する**

[**ImageCollection**](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) クラスおよび [**ImageCollection** ](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/ImageCollection) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

以下の JavaScript コードは、BLOB プロセスを使用して大きな画像を追加する方法を示します。

```javascript
var pathToLargeImage = "large_image.jpg";
// 画像が追加される新しいプレゼンテーションを作成します。
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // 画像をプレゼンテーションに追加します - KeepLocked 動作を選択したのは、
        // 「largeImage.png」ファイルにアクセスするつもりがないためです。
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // プレゼンテーションを保存します。大きなプレゼンテーションが出力されても、
        // pres オブジェクトのライフサイクル全体でメモリ使用量は低く保たれます。
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **メモリと大規模プレゼンテーション**

通常、大規模なプレゼンテーションを読み込むには大量の一時メモリが必要です。プレゼンテーション全体の内容がメモリに読み込まれ、読み込み元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的な読み込み方法は、以下の JavaScript コードで説明されています。

```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

しかし、この方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大規模プレゼンテーションを読み込む**

BLOB を伴うプロセスを使用すると、少量のメモリで大規模なプレゼンテーションを読み込むことができます。この JavaScript コードは、BLOB プロセスを使用して large.pptx を読み込む実装を示しています。

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **一時ファイルのフォルダーを変更する**

BLOB プロセスが使用されると、コンピューターは既定の一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`setTempFilesRootPath` を使用して保存先を変更できます。

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`setTempFilesRootPath` を使用する場合、Aspose.Slides は一時ファイル用のフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **プレゼンテーションオブジェクトを破棄してメモリを解放する**

大規模なプレゼンテーションを処理する際は、[Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) インスタンスを適切に破棄し、占有していたメモリを解放してください。プレゼンテーションの使用が完了したら `dispose()` を呼び出してアンマネージド リソースを解放します。

```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...プレゼンテーションを処理する...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// リソースを明示的に解放します。
presentation.dispose();
```

## **FAQ**

**What data in an Aspose.Slides presentation is treated as BLOB and controlled by BLOB options?**  
画像、オーディオ、ビデオなどの大容量バイナリ オブジェクトが BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理の対象となります。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量の管理や必要に応じた一時ファイルへのスピルが可能です。

**Where do I configure BLOB handling rules during presentation loading?**  
[LoadOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限、一時ファイルの有無、ルート パス、ソース ロック動作などを設定できます。

**Do BLOB settings affect performance, and how do I balance speed vs memory?**  
はい。BLOB をメモリに保持すると速度は最大化されますが RAM 使用量が増加します。メモリ上限を下げると処理の多くが一時ファイルに転送され、RAM 使用量は減りますが I/O が増加します。ワークロードと環境に合わせて最適なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) メソッドを使用してください。

**Do BLOB options help when opening extremely large presentations (e.g., gigabytes)?**  
はい。[BlobManagementOptions](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化とソース ロックの利用により、ピーク時の RAM 使用量を大幅に削減し、超大型デッキの処理を安定させます。

**Can I use BLOB policies when loading from streams instead of disk files?**  
はい。ストリームにも同じ規則が適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（ロック モードに依存）、許可された場合は一時ファイルが使用されるため、処理中のメモリ使用量を予測可能に保てます。