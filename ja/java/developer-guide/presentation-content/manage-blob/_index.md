---
title: JavaでプレゼンテーションのBLOBを管理して効率的なメモリ使用を実現
linktitle: BLOBの管理
type: docs
weight: 10
url: /ja/java/manage-blob/
keywords:
- 大きなオブジェクト
- 大きなアイテム
- 大きなファイル
- BLOBの追加
- BLOBのエクスポート
- 画像をBLOBとして追加
- メモリ削減
- メモリ使用量
- 大規模プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides for JavaでBLOBデータを管理し、PowerPoint および OpenDocument ファイル操作を効率化して、プレゼンテーションの取り扱いを最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きな項目（写真、プレゼンテーション、ドキュメント、またはメディア）です。  

Aspose.Slides for Java は、大きなファイルが関わる場合にメモリ消費を抑える形でオブジェクトに BLOB を使用できるようにします。  

{{% alert title="Info" color="info" %}}
ストリームとやり取りする際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。そのため、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。  
{{% /alert %}}

## **BLOB を使用してメモリ消費を削減する**

### **BLOB を使用してプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/ja/java/) for Java は、BLOB を使用したプロセスで大きなファイル（この例では大きなビデオファイル）を追加し、メモリ消費を削減できるようにします。  

この Java のサンプルは、BLOB プロセスを使用して大きなビデオファイルをプレゼンテーションに追加する方法を示しています。  
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 新しいプレゼンテーションを作成し、ビデオを追加します
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // プレゼンテーションにビデオを追加します - KeepLocked 動作を選択したのは、
        // "veryLargeVideo.avi" ファイルにアクセスするつもりがないためです。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、
        // pres オブジェクトのライフサイクルを通じてメモリ使用量は低く保たれます。
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

Aspose.Slides for Java は、BLOB を使用したプロセスでプレゼンテーションから大きなファイル（この例ではオーディオまたはビデオファイル）をエクスポートできるようにします。たとえば、プレゼンテーションから大きなメディアファイルを抽出したいが、コンピューターのメモリにロードしたくない場合があります。BLOB プロセスを介してファイルをエクスポートすることで、メモリ消費を低く抑えることができます。  

この Java のコードは、上記の操作を示しています。  
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリに読み込まないようにします
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存しましょう。メモリ使用量が高くなるのを防ぐために、バッファが必要です
    // プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するために使用されます。
    byte[] buffer = new byte[8 * 1024];

    // ビデオを反復処理します
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを避けていることに注意してください
        // video.BinaryData のようなプロパティは、フルビデオを含むバイト配列を返すため、
        // メモリにバイトがロードされます。そこで video.GetStream を使用します。このメソッドはストリームを返し、メモリに全体をロードしません。
        //  require us to load the whole video into the memory.
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
        // ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く保たれます。
    }
    // 必要に応じて、同じ手順をオーディオファイルにも適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **プレゼンテーションに画像を BLOB として追加する**

[IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) インターフェイスと [ImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) クラスのメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱うことができます。  

この Java のコードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています。  
```java
String pathToLargeImage = "large_image.jpg";

// 新しいプレゼンテーションを作成し、画像を追加します。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// プレゼンテーションに画像を追加しましょう - KeepLocked 動作を選択したのは、
		// 「largeImage.png」ファイルにアクセスするつもりがないためです。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、
		// pres オブジェクトのライフサイクルを通じてメモリ使用量は低く保たれます。
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```


## **メモリと大きなプレゼンテーション**

通常、大きなプレゼンテーションを読み込むには、コンピューターは大量の一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリに読み込まれ、プレゼンテーションが読み込まれた元のファイルは使用されなくなります。  

たとえば、1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみてください。プレゼンテーションを読み込む標準的な方法は、次の Java コードで示されています。  
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


しかし、この方法では約 1.6 GB の一時メモリが消費されます。  

### **BLOB として大きなプレゼンテーションを読み込む**

BLOB を使用したプロセスにより、少ないメモリで大きなプレゼンテーションを読み込むことができます。  
以下の Java コードは、BLOB プロセスを使用して大きなプレゼンテーション ファイル（large.pptx）を読み込む実装例です。  
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

BLOB プロセスを使用すると、コンピューターは既定の一時フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用してストレージ設定を変更できます。  
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

**Aspose.Slides プレゼンテーションのどのデータが BLOB として扱われ、BLOB オプションで制御されますか？**  
画像、オーディオ、ビデオなどの大きなバイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB の処理が行われます。これらのオブジェクトは BLOB ポリシーによって管理され、メモリ使用量を制御したり、必要に応じて一時ファイルにスピル（退避）させることができます。  

**プレゼンテーションの読み込み時に BLOB 処理ルールをどこで設定しますか？**  
[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限の設定、一時ファイルの許可または禁止、テンポラリファイルのルートパスの選択、ソースロックの動作を設定できます。  

**BLOB 設定はパフォーマンスに影響しますか？また、速度とメモリのバランスはどう取りますか？**  
はい。BLOB をメモリに保持すると速度が最大化しますが、RAM 消費が増加します。メモリ上限を下げると、より多くの処理が一時ファイルに委譲され、RAM は削減されますが I/O が増えます。ワークロードや環境に合わせて適切なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) メソッドを使用してください。  

**極めて大きなプレゼンテーション（例：数ギガバイト）を開く際に BLOB オプションは役立ちますか？**  
はい。[BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) はこのようなシナリオ向けに設計されています。一時ファイルを有効にし、ソースロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させることができます。  

**ディスクファイルではなくストリームからロードする場合でも BLOB ポリシーは使用できますか？**  
はい。同じルールがストリームにも適用されます。プレゼンテーション インスタンスは入力ストリームを所有しロックすることができ（選択したロックモードに依存）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。