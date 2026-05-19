---
title: Android でプレゼンテーション BLOB を管理して効率的にメモリを使用する
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/androidjava/manage-blob/
keywords:
- 大きなオブジェクト
- 大きな項目
- 大きなファイル
- BLOB の追加
- BLOB のエクスポート
- 画像を BLOB として追加
- メモリ削減
- メモリ消費
- 大きなプレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Java を通じて Android 用 Aspose.Slides の BLOB データを管理し、PowerPoint および OpenDocument ファイルの操作を効率化して、プレゼンテーション処理を効率的に行います。"
---
## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きな項目（写真、プレゼンテーション、ドキュメント、またはメディア）です。  

Aspose.Slides for Android via Java は、大きなファイルを扱う際にメモリ消費を抑える方法で、オブジェクトに対して BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとのやり取りで生じる特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。
{{% /alert %}}

## **メモリ消費を削減するための BLOB の使用**

### **BLOB を使用して大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/androidjava/) for Java は、BLOB を使用したプロセスで大きなファイル（この例では大容量のビデオファイル）を追加し、メモリ消費を削減できます。

この Java のサンプルは、BLOB プロセスを使用して大きなビデオファイルをプレゼンテーションに追加する方法を示します：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // ビデオをプレゼンテーションに追加しましょう - KeepLocked 動作を選択したのは、
        //「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
        // pres オブジェクトのライフサイクル全体で低く保たれます 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **プレゼンテーションから BLOB を使用して大きなファイルをエクスポートする**

Aspose.Slides for Android via Java は、BLOB を使用したプロセスでプレゼンテーションから大きなファイル（この例では音声またはビデオファイル）をエクスポートできるようにします。たとえば、プレゼンテーションから大容量のメディアファイルを抽出したいが、コンピューターのメモリにロードしたくない場合があります。BLOB プロセスを通じてファイルをエクスポートすることで、メモリ消費を低く抑えることができます。

この Java のコードは、上記の操作を示しています：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリにロードしません
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存しましょう。メモリ使用量が高くなるのを防ぐため、バッファが必要です
    // プレゼンテーションのビデオストリームから新しく作成したビデオファイル用ストリームへデータを転送するためです。
    byte[] buffer = new byte[8 * 1024];

    // ビデオを順に処理します
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
        // video.BinaryData のようなプロパティは、全ビデオを含むバイト配列を返すため、
        //  メモリに全ビデオをロードする必要はありません。
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く保たれます
    }
    // 必要に応じて、オーディオファイルにも同じ手順を適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **プレゼンテーションに画像を BLOB として追加する**

[**IImageCollection**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/IImageCollection) インターフェイスと [**ImageCollection**](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/ImageCollection) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

この Java のコードは、BLOB プロセスを使用して大きな画像を追加する方法を示します：

```java
String pathToLargeImage = "large_image.jpg";

// 画像を追加する新しいプレゼンテーションを作成します。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// プレゼンテーションに画像を追加しましょう - KeepLocked 動作を選択したのは、
		// 「largeImage.png」ファイルにアクセスするつもりがないためです。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
		// pres オブジェクトのライフサイクル全体で低く保たれます
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **メモリと大規模プレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピューターに大量の一時メモリが必要です。プレゼンテーションのすべてのコンテンツがメモリにロードされ、ロード元のファイルは使用されなくなります。  

たとえば、1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的なロード方法は、次の Java コードで示されています：

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

しかし、この方法では約 1.6 GB の一時メモリが消費されます。  

### **BLOB として大きなプレゼンテーションをロードする**

BLOB を使用したプロセスにより、少ないメモリで大きなプレゼンテーションをロードできます。この Java のコードは、BLOB プロセスを使用して large.pptx をロードする実装例を示しています：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、コンピューターは既定の一時ファイルフォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存先を変更できます：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用する場合、Aspose.Slides は一時ファイル用フォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **プレゼンテーションオブジェクトを破棄してメモリを解放する**

大規模なプレゼンテーションを処理するときは、[Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) インスタンスが適切に破棄され、使用していたメモリが解放されるようにしてください。プレゼンテーションの使用が終わったら `dispose()` を呼び出してアンマネージドリソースを解放します。

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **FAQ**

**Aspose.Slides のプレゼンテーションでどのデータが BLOB として扱われ、BLOB オプションで制御されますか？**  
画像、音声、ビデオなどの大容量バイナリオブジェクトが BLOB として扱われます。プレゼンテーション全体のファイル自体も、ロードまたは保存時に BLOB 処理の対象となります。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルにスピルできる BLOB ポリシーによって制御されます。

**プレゼンテーションのロード時に BLOB 処理ルールはどこで設定しますか？**  
[LoadOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限や一時ファイルの使用可否、ルートパス、ソースロック動作などを設定できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**  
はい。BLOB をメモリ内に保持すると速度は最大化しますが RAM 消費が増えます。メモリ上限を下げると作業が一時ファイルにシフトし、RAM 使用量は減りますが I/O が増えて速度が低下します。`setMaxBlobsBytesInMemory` メソッドでワークロードと環境に合わせたバランスを調整してください。

**非常に大きなプレゼンテーション（数ギガバイト）を開く際に BLOB オプションは役立ちますか？**  
はい。[BlobManagementOptions] はそのようなシナリオ向けに設計されており、一時ファイルの有効化やソースロックの使用により、ピーク RAM 使用量を大幅に削減し、極大サイズのデッキでも安定した処理が可能です。

**ストリームからロードする場合でも BLOB ポリシーを使用できますか？**  
はい。ストリームにも同じルールが適用されます。プレゼンテーションインスタンスは入力ストリームを所有およびロックでき（ロックモードに依存）、許可された場合は一時ファイルが使用され、処理中のメモリ使用量が予測可能になります。