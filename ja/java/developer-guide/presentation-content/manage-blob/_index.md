---
title: JavaでプレゼンテーションBLOBを管理し、メモリ使用を効率化
linktitle: BLOB管理
type: docs
weight: 10
url: /ja/java/manage-blob/
keywords:
- 大規模オブジェクト
- 大規模項目
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
- Java
- Aspose.Slides
description: "Java用Aspose.SlidesでBLOBデータを管理し、PowerPointおよびOpenDocumentファイルの操作を効率化してプレゼンテーション処理を最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きな項目（写真、プレゼンテーション、ドキュメント、またはメディア）です。

Aspose.Slides for Java は、大きなファイルが関与する場合にメモリ使用量を削減する方法で、オブジェクトに BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとやり取りする際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリーム経由で大きなプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、ロードが遅くなります。そのため、大きなプレゼンテーションをロードする場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。
{{% /alert %}}

## **メモリ使用量を削減するための BLOB の使用**

### **BLOB を使用して大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/java/) for Java は、メモリ使用量を削減するために BLOB を利用して大きなファイル（この例では大きなビデオ ファイル）をプレゼンテーションに追加できるようにします。

この Java サンプルは、BLOB プロセスを使用して大きなビデオ ファイルをプレゼンテーションに追加する方法を示しています:
```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // ビデオをプレゼンテーションに追加します - KeepLocked 動作を選択したのは、
        // 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
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
Aspose.Slides for Java は、BLOB を利用したプロセスでプレゼンテーションから大きなファイル（音声またはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディア ファイルを抽出したいが、ファイルをコンピュータのメモリに読み込ませたくない場合があります。BLOB プロセスでエクスポートすれば、メモリ使用量を低く抑えることができます。

この Java コードは、前述の操作を実演しています:
```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリにロードしません
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存しましょう。メモリ使用量の増加を防ぐために、バッファが必要です
    // そのバッファは、プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するために使用されます。
    byte[] buffer = new byte[8 * 1024];

    // ビデオを反復処理します
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションのビデオストリームを開きます。ご注意ください、意図的にプロパティへのアクセスを避けています
        // video.BinaryData のようなプロパティ - これはフルビデオを含むバイト配列を返すため、メモリに読み込まれます
        // そのため、video.GetStream を使用します。これは Stream を返し、メモリにビデオ全体をロードする必要はありません
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
    // 必要に応じて、同様の手順をオーディオファイルにも適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```


### **画像を BLOB としてプレゼンテーションに追加する**
[IImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection) インターフェイスおよび [ImageCollection](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

この Java コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています:
```java
String pathToLargeImage = "large_image.jpg";

// 新しいプレゼンテーションを作成し、画像を追加します。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// 画像をプレゼンテーションに追加しましょう - KeepLocked 動作を選択したのは
		// 「largeImage.png」ファイルにアクセスするつもりがないためです。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
		// pres オブジェクトのライフサイクルを通じて低く保たれます。
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

通常、大きなプレゼンテーションをロードするには、一時メモリが大量に必要です。プレゼンテーションのすべてのコンテンツがメモリに読み込まれ、プレゼンテーションがロードされた元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的なロード方法は、次の Java コードで示されています:
```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```


しかしこの方法では、約 1.6 GB の一時メモリを消費します。

### **BLOB として大きなプレゼンテーションをロードする**

BLOB を利用したプロセスにより、少ないメモリで大きなプレゼンテーションをロードできます。この Java コードは、BLOB プロセスを使用して large.pptx をロードする実装例です:
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

BLOB プロセスを使用すると、既定の一時ファイル フォルダーに一時ファイルが作成されます。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存先を変更できます:
```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```


{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用すると、Aspose.Slides は一時ファイル用のフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、ビデオなどの大きなバイナリ オブジェクトが BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB 処理が関与します。これらのオブジェクトは、メモリ使用量や一時ファイルへのスピルを管理できる BLOB ポリシーで制御されます。

**プレゼンテーションのロード時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限を設定したり、一時ファイルの使用可否、ルート パス、ソース ロック動作を指定できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

影響します。BLOB をメモリに保持すると速度は最大化しますが RAM 消費が増えます。メモリ上限を下げると処理が一時ファイルにシフトし、RAM は減りますが I/O が増加します。[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) メソッドを使って、ワークロードと環境に合わせたバランスを調整してください。

**非常に大きなプレゼンテーション（数ギガバイト）を開く際に BLOB オプションは役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/java/com.aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルとソース ロックを有効にすることで、ピーク RAM 使用量を大幅に削減し、極大サイズのデッキでも安定した処理が可能になります。

**ストリームからロードする場合でも BLOB ポリシーは使用できますか？**

はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（ロック モードに依存）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。