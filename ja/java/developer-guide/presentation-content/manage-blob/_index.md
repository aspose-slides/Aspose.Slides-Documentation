---
title: Java でプレゼンテーション BLOB を管理して効率的なメモリ使用
linktitle: BLOB を管理
type: docs
weight: 10
url: /ja/java/manage-blob/
keywords:
- 大きなオブジェクト
- 大きなアイテム
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
- Java
- Aspose.Slides
description: "Java 用 Aspose.Slides で BLOB データを管理し、PowerPoint および OpenDocument ファイルの操作を効率化して、プレゼンテーションの処理を最適化します。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内の大きなバイナリ データを BLOB ベースで処理し、大きな画像、オーディオ、ビデオ、プレゼンテーション ファイルを扱う際のメモリ消費を削減するのに役立ちます。

この記事では、BLOB ベースの処理を使用してプレゼンテーションに大容量メディアを追加する方法、プレゼンテーションから大容量メディアをエクスポートする方法、そして大規模なプレゼンテーションをより効率的に読み込む方法を示します。また、処理中に一時ファイルを使用する方法と、保存先フォルダーを変更する方法も説明します。

## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存された大きな項目（写真、プレゼンテーション、文書、またはメディア）です。

Aspose.Slides for Java は、サイズの大きいファイルが関係する場合にメモリ消費を抑える形でオブジェクトに対して BLOB を使用できるようにします。

{{% alert title="Info" color="info" %}}
ストリームとのやり取りで特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションのファイル パスを使用することを強くお勧めします。
{{% /alert %}}

## **BLOB を使用してメモリ消費を削減する**

### **BLOB を使用して大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/java/) for Java は、メモリ消費を削減するために BLOB を介して大きなファイル（この例では大きなビデオ ファイル）を追加できるようにします。

この Java は、BLOB プロセスを通じて大きなビデオ ファイルをプレゼンテーションに追加する方法を示しています：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // ビデオをプレゼンテーションに追加しましょう - KeepLocked 動作を選択したのは
        // "veryLargeVideo.avi" ファイルにアクセスするつもりがありません。
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

### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポートする**
Aspose.Slides for Java は、BLOB を介したプロセスでプレゼンテーションから大きなファイル（この例では音声またはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大容量メディア ファイルを抽出したいが、コンピューターのメモリにロードしたくない場合があります。BLOB プロセスでエクスポートすれば、メモリ消費を低く抑えることができます。

この Java のコードは、上記の操作を実演しています：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリに読み込まないようにします
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存します。高いメモリ使用量を防ぐために、使用されるバッファが必要です
    // プレゼンテーションのビデオストリームから新規作成したビデオファイル用ストリームへデータを転送するために使用されます。
    byte[] buffer = new byte[8 * 1024];

    // ビデオを列挙します
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
        // video.BinaryData のようなプロパティは、フルビデオを含むバイト配列を返すため、
        // メモリにバイトがロードされます。video.GetStream を使用すると、Stream を返し、メモリにロードしません
        //  メモリ全体にビデオ全体をロードする必要がありません。
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
        // ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く抑えられます。
    }
    // 必要に応じて、オーディオ ファイルにも同じ手順を適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **画像を BLOB としてプレゼンテーションに追加する**
[**IImageCollection**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/IImageCollection) インターフェイスおよび [**ImageCollection**](https://reference.aspose.com/slides/ja/java/com.aspose.slides/ImageCollection) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

この Java コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています：

```java
String pathToLargeImage = "large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成します。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// プレゼンテーションに画像を追加しましょう - KeepLocked 動作を選択したのは
		// 「largeImage.png」ファイルにアクセスするつもりがないからです。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
		// pres オブジェクトのライフサイクル全体で低く保たれます。
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

通常、大きなプレゼンテーションを読み込むには、コンピューターに大量の一時メモリが必要です。プレゼンテーションのすべての内容がメモリにロードされ、読み込み元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大規模 PowerPoint プレゼンテーション（large.pptx）を考えてみてください。標準的な読み込み方法は、次の Java コードで示されています：

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

BLOB を介したプロセスを使用すれば、ほとんどメモリを使用せずに大きなプレゼンテーションをロードできます。以下の Java コードは、BLOB プロセスを利用して large.pptx をロードする実装例です：

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

BLOB プロセスを使用すると、コンピューターは既定の一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存先を変更できます：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用すると、Aspose.Slides は一時ファイル用のフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **Presentation オブジェクトを破棄してメモリを解放する**

大規模なプレゼンテーションを処理する際は、[Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) インスタンスを適切に破棄し、占有していたメモリを解放してください。プレゼンテーションの使用が終わったら `dispose()` を呼び出してアンマネージド リソースを解放します。

```java
Presentation presentation = new Presentation("large.pptx");

// ...プレゼンテーションを処理...
presentation.save("large.pdf", SaveFormat.Pdf);

// リソースを明示的に解放します。
presentation.dispose();
```

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**  
画像、音声、ビデオなどの大容量バイナリ オブジェクトが BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が行われます。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルにスピルするための BLOB ポリシーによって制御されます。

**プレゼンテーションの読み込み時に BLOB の取り扱いルールを設定する場所はどこですか？**  
[LoadOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/loadoptions/) と組み合わせて [BlobManagementOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限や一時ファイルの使用可否、ルート パス、ソース ロックの動作を設定できます。

**BLOB 設定はパフォーマンスに影響しますか？また、速度とメモリのバランスはどう取りますか？**  
はい。BLOB をメモリに保持すると速度は最高になりますが RAM 消費が増加します。メモリ上限を下げると処理が一時ファイルにシフトし、RAM 使用量は減りますが I/O が増えて速度が低下します。ワークロードと環境に合わせて最適なバランスを取るには、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ja/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) メソッドを使用してください。

**極めて大きなプレゼンテーション（例: ギガバイト単位）を開く際に BLOB オプションは役立ちますか？**  
はい。[BlobManagementOptions](https://reference.aspose.com/slides/ja/java/com.aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化やソース ロックの使用により、ピーク RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させます。

**ディスク ファイルではなくストリームから読み込む場合でも BLOB ポリシーを使用できますか？**  
はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは入力ストリームを所有・ロックでき（ロック モードに依存）、許可された場合は一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。