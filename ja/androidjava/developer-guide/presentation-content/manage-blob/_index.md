---
title: Androidでのプレゼンテーション BLOB 管理による効率的なメモリ使用
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/androidjava/manage-blob/
keywords:
- 大容量オブジェクト
- 大容量アイテム
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java で BLOB データを管理し、PowerPoint と OpenDocument ファイルの操作を効率化してプレゼンテーションの取り扱いを最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、文書、またはメディア）です。

Aspose.Slides for Android via Java は、大容量ファイルを扱う際にメモリ使用量を削減する方法でオブジェクトに BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとのやり取りで特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強くお勧めします。
{{% /alert %}}

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB 経由で大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/androidjava/) for Java は、メモリ使用量を削減するために BLOB を利用したプロセスで大きなファイル（この例では大容量ビデオファイル）をプレゼンテーションに追加できます。

この Java コードは、BLOB プロセスを使用して大きなビデオファイルをプレゼンテーションに追加する方法を示しています。
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // プレゼンテーションにビデオを追加しましょう - KeepLocked 動作を選択したのは、
        // "veryLargeVideo.avi" ファイルにアクセスするつもりがないためです。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
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


### **BLOB 経由でプレゼンテーションから大きなファイルをエクスポートする**

Aspose.Slides for Android via Java は、プレゼンテーションから BLOB を利用したプロセスで大容量ファイル（この例ではオーディオまたはビデオファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディアファイルを抽出したいが、ファイルをコンピュータのメモリにロードしたくない場合があります。BLOB プロセスでエクスポートすることで、メモリ使用量を低く抑えることができます。

この Java コードは、上記の操作を実演しています。
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリに読み込まない
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存します。高いメモリ使用量を防ぐために、バッファが必要です
    // プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するためです。
    byte[] buffer = new byte[8 * 1024];

    // Iterates through the videos
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションのビデオストリームを開きます。なお、意図的にプロパティへのアクセスを回避したことに注意してください
        // video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
        // メモリにバイトがロードされます。video.GetStream を使用すると、Stream が返され、かつ
        //   ビデオ全体をメモリにロードする必要がありません。
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
        // ビデオやプレゼンテーションのサイズに関係なく、メモリ使用量は低く保たれます。
    }
    // 必要に応じて、オーディオファイルにも同じ手順を適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **プレゼンテーションに画像を BLOB として追加する**

[**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection) インターフェイスと [**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

この Java コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています。
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

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
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


## **メモリと大容量プレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピュータは大量の一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリにロードされ、プレゼンテーションがロードされた元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。プレゼンテーションをロードする標準的な方法は、次の Java コードで説明されています。
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

BLOB を利用したプロセスにより、少量のメモリで大きなプレゼンテーションをロードできます。この Java コードは、BLOB プロセスを使用して大きなプレゼンテーションファイル（large.pptx）をロードする実装を示しています。
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

BLOB プロセスを使用すると、コンピュータは既定の一時ファイルフォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存先設定を変更できます。
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用すると、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、オーディオ、ビデオなどの大容量バイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB の取り扱いが行われます。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量を管理し、必要に応じて一時ファイルにスピル（退避）させることができます。

**プレゼンテーションのロード時に BLOB の取り扱いルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限を設定したり、一時ファイルの使用可否を指定したり、短期ファイル用のルートパスを選択したり、ソースロックの動作を選択したりできます。

**BLOB の設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリ内に保持すると速度は最大化されますが、RAM の消費が増加します。メモリ上限を下げると、より多くの処理が一時ファイルに転送され、RAM は削減されますが追加の I/O が発生します。ワークロードと環境に合わせて適切なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) メソッドを使用してください。

**非常に大きなプレゼンテーション（例：ギガバイト単位）を開く際に BLOB オプションは役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blobmanagementoptions/) はこのようなシナリオ向けに設計されています。一時ファイルを有効にし、ソースロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させることができます。

**ディスクファイルではなくストリームからロードする際に BLOB ポリシーを使用できますか？**

はい。同じルールがストリームにも適用されます。プレゼンテーションインスタンスは入力ストリームを所有およびロックでき（選択したロックモードに依存）、許可された場合は一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。