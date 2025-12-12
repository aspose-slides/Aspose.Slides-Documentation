---
title: Android でプレゼンテーション BLOB を管理し、メモリ使用を効率化
linktitle: BLOB を管理
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
- 大規模プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android（Java）における BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化してプレゼンテーション処理を最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、ドキュメント、またはメディア）です。  

Aspose.Slides for Android via Java は、大きなファイルが関与する場合にメモリ使用量を削減する方法でオブジェクトに BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとやり取りする際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。そのため、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。
{{% /alert %}}

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を使用してプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/ja/androidjava/) for Java は、BLOB を使用したプロセスを通じて大きなファイル（この場合は大きなビデオファイル）を追加し、メモリ使用量を削減できます。

この Java のサンプルは、BLOB プロセスを使用して大きなビデオファイルをプレゼンテーションに追加する方法を示しています:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオが追加される新しいプレゼンテーションを作成します
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // プレゼンテーションにビデオを追加します - KeepLocked 動作を選択したのは
        // "veryLargeVideo.avi" ファイルにアクセスするつもりがないためです。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
        // pres オブジェクトのライフサイクルを通じて低く保たれます
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポートする**

Aspose.Slides for Android via Java は、BLOB を使用したプロセスを通じてプレゼンテーションから大きなファイル（この場合は音声またはビデオファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディアファイルを抽出する必要があるが、そのファイルをコンピューターのメモリにロードしたくない場合があります。BLOB プロセスを通じてファイルをエクスポートすることで、メモリ使用量を抑えることができます。

この Java コードは、上記の操作を示しています:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリに読み込まない
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存します。高いメモリ使用を防ぐために、使用されるバッファが必要です。
    // プレゼンテーションのビデオストリームから新しく作成されたビデオファイル用のストリームへデータを転送するために。
    byte[] buffer = new byte[8 * 1024];

    // ビデオを反復処理します
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
        // video.BinaryData のようなプロパティは、フルビデオを含むバイト配列を返すため、
        // メモリにバイトがロードされます。video.GetStream を使用し、これは Stream を返し、メモリにロードしません
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
        // ビデオやプレゼンテーションのサイズに関わらず、メモリ消費は低く保たれます。
    }
    // 必要に応じて、音声ファイルにも同じ手順を適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **プレゼンテーションに画像を BLOB として追加する**

[IImageCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) インターフェイスおよび [ImageCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) クラスのメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱うことができます。

この Java コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています:
```java
String pathToLargeImage = "large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成します。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 画像をプレゼンテーションに追加します - KeepLocked 動作を選択したのは
		// 「largeImage.png」ファイルにアクセスするつもりがないためです。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、 
		// pres オブジェクトのライフサイクル全体でメモリ消費は低く保たれます。
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

通常、大きなプレゼンテーションを読み込むには、コンピューターは大量の一時メモリを必要とします。プレゼンテーションのすべての内容がメモリにロードされ、プレゼンテーションが読み込まれたファイルは使用されなくなります。

たとえば、1.5 GB のビデオファイルを含む large.pptx という大きな PowerPoint プレゼンテーションを考えてみてください。プレゼンテーションを読み込む標準的な方法は、次の Java コードで示されています:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


しかしこの方法では、約 1.6 GB の一時メモリが消費されます。

### **BLOB として大きなプレゼンテーションを読み込む**

BLOB を使用したプロセスにより、少ないメモリで大きなプレゼンテーションを読み込むことができます。この Java コードは、BLOB プロセスを使用して大きなプレゼンテーション ファイル（large.pptx）を読み込む実装を示しています:
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


### **一時ファイルのフォルダーを変更する**

BLOB プロセスを使用すると、コンピューターはデフォルトの一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存先設定を変更できます:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用すると、Aspose.Slides は一時ファイルを格納するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、ビデオなどの大きなバイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が行われます。これらのオブジェクトは BLOB ポリシーによって管理され、必要に応じてメモリ使用量を制御したり一時ファイルにスピルしたりできます。

**プレゼンテーションの読み込み時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限を設定したり、一時ファイルの使用を許可または禁止したり、一時ファイルのルート パスを選択したり、ソースのロック動作を選択したりできます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリに保持すると速度は最大化されますが RAM 使用量が増加します。メモリ上限を下げると、より多くの処理が一時ファイルにオフロードされ、RAM は減りますが I/O が増加します。[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) メソッドを使用して、ワークロードと環境に合わせた適切なバランスを設定してください。

**極めて大きなプレゼンテーション（例: ギガバイト規模）を開く際に BLOB オプションは役立ちますか？**

はい。そのようなシナリオ向けに設計された [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) では、一時ファイルを有効にし、ソースロックを使用することで、ピーク RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させることができます。

**ディスク ファイルではなくストリームから読み込む際にも BLOB ポリシーを使用できますか？**

はい。同じルールがストリームにも適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（選択したロックモードに依存）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。