---
title: Blob の管理
type: docs
weight: 10
url: /ja/nodejs-java/manage-blob/
description: JavaScript を使用して PowerPoint プレゼンテーションで Blob を管理します。JavaScript を使用して PowerPoint プレゼンテーションのメモリ使用量を削減するために Blob を使用します。JavaScript を使用して Blob 経由で大きなファイルを PowerPoint プレゼンテーションに追加します。JavaScript を使用して Blob 経由で PowerPoint プレゼンテーションから大きなファイルをエクスポートします。JavaScript を使用して大きな PowerPoint プレゼンテーションを Blob としてロードします。
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存された大きなアイテム（写真、プレゼンテーション、ドキュメント、またはメディア）です。

Aspose.Slides for Node.js via Java を使用すると、大きなファイルが関与する場合にメモリ使用量を削減する方法でオブジェクトに BLOBs を使用できます。

{{% alert title="Info" color="info" %}}
ストリームとのやり取り時の特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、ロードが遅くなります。そのため、大きなプレゼンテーションをロードする場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。
{{% /alert %}}

## **メモリ使用量の削減に BLOB を使用する**

### **BLOB を使用してプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/ja/nodejs-java/) for Node.js via Java を使用すると、BLOB を利用したプロセスで大きなファイル（この例では大きなビデオファイル）をプレゼンテーションに追加でき、メモリ使用量を削減できます。

この JavaScript は、BLOB プロセスを通じて大きなビデオファイルをプレゼンテーションに追加する方法を示しています:
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// ビデオを追加する新しいプレゼンテーションを作成します
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // ビデオをプレゼンテーションに追加します - KeepLocked 動作を選択したのは、
        // "veryLargeVideo.avi" ファイルにアクセスするつもりがないためです。
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

Aspose.Slides for Node.js via Java を使用すると、BLOB を利用したプロセスでプレゼンテーションから大きなファイル（この例では音声またはビデオファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディアファイルを抽出したいが、そのファイルをコンピューターのメモリに読み込ませたくない場合があります。BLOB プロセスを介してファイルをエクスポートすることで、メモリ使用量を低く抑えることができます。

この JavaScript コードは、上記の操作を示しています:
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// ソースファイルをロックし、メモリにロードしません
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存しましょう。メモリ使用量の増加を防ぐため、バッファが必要です
    // プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するために使用されます。
    var buffer = new byte[8 * 1024];
    // ビデオを反復処理します
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを避けていることに注意してください
        // video.BinaryData のようなプロパティは、フルビデオを含むバイト配列を返すため、
        // メモリにバイトをロードさせます。video.GetStream を使用すると、Stream が返され、メモリに全体をロードしません
        // メモリにビデオ全体をロードする必要がありません。
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
        // ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く抑えられます。
    }
    // 必要に応じて、同じ手順をオーディオファイルにも適用できます。
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```


### **プレゼンテーションに画像を BLOB として追加する**

[**ImageCollection**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) クラスおよび [**ImageCollection** ](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ImageCollection) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

この JavaScript コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています:
```javascript
var pathToLargeImage = "large_image.jpg";
// 画像を追加する新しいプレゼンテーションを作成します。
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // 画像をプレゼンテーションに追加します - KeepLocked 動作を選択したのは
        // "largeImage.png" ファイルにアクセスするつもりがないためです。
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // プレゼンテーションを保存します。大きなプレゼンテーションが出力されても、
        // pres オブジェクトのライフサイクル全体でメモリ使用量は低く保たれます
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


## **メモリと大きなプレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピューターは大量の一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリにロードされ、プレゼンテーションが読み込まれたファイルは使用されなくなります。

たとえば、1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。プレゼンテーションをロードする標準的な方法は、次の JavaScript コードで説明されています:
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


しかし、この方法は約 1.6 GB の一時メモリを消費します。

### **BLOB として大きなプレゼンテーションをロードする**

BLOB を利用したプロセスにより、少ないメモリで大きなプレゼンテーションをロードできます。この JavaScript コードは、BLOB プロセスを使用して大きなプレゼンテーションファイル（large.pptx）をロードする実装を示しています:
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


### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、コンピューターはデフォルトの一時ファイルフォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`setTempFilesRootPath` を使用してストレージ設定を変更できます:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
`setTempFilesRootPath` を使用すると、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides プレゼンテーション内で BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、ビデオなどの大容量バイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB の処理が行われます。これらのオブジェクトは BLOB ポリシーによって管理され、メモリ使用量を制御し、必要に応じて一時ファイルへ書き出すことができます。

**プレゼンテーションのロード時に BLOB の処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限を設定し、一時ファイルの使用を許可または禁止し、テンポラリーファイルのルートパスを選択し、ソースロックの動作を選択できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリ内に保持すると速度は最大化されますが、RAM の消費が増加します。メモリ上限を下げると、より多くの処理が一時ファイルにオフロードされ、RAM は減少しますが I/O が増加します。ワークロードと環境に合わせて適切なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) メソッドを使用してください。

**極めて大きなプレゼンテーション（例: 数ギガバイト）を開く際に BLOB オプションは役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blobmanagementoptions/) はこのようなシナリオ向けに設計されています。 一時ファイルを有効化し、ソースロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、極めて大きなデッキの処理を安定させることができます。

**ディスクファイルではなくストリームからロードする際に BLOB ポリシーを使用できますか？**

はい。同じルールがストリームにも適用されます。プレゼンテーションインスタンスは（選択したロックモードに応じて）入力ストリームを所有およびロックでき、許可されている場合は一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。