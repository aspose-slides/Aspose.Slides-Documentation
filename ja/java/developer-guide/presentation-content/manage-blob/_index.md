---
title: Blobを管理する
type: docs
weight: 10
url: /java/manage-blob/
description: Javaを使用してPowerPointプレゼンテーションでBlobを管理します。Javaを使用してPowerPointプレゼンテーションのメモリ消費を削減するためにBlobを使用します。Javaを使用してPowerPointプレゼンテーションにBlobを通じて大きなファイルを追加します。Javaを使用してPowerPointプレゼンテーションからBlobを通じて大きなファイルをエクスポートします。Javaを使用してBlobとして大きなPowerPointプレゼンテーションを読み込みます。
---

## **BLOBについて**

**BLOB**（**Binary Large Object**）は通常、バイナリ形式で保存された大きなアイテム（写真、プレゼンテーション、ドキュメント、メディア）です。

Aspose.Slides for Javaは、大きなファイルを扱う際にメモリ消費を削減する方法でBLOBをオブジェクトに使用することを可能にします。

{{% alert title="情報" color="info" %}}

ストリームと対話する際の特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーする場合があります。ストリームを通じて大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなる原因となります。したがって、大きなプレゼンテーションを読み込む場合は、ストリームではなくプレゼンテーションファイルのパスを使用することを強くお勧めします。

{{% /alert %}}

## **メモリ消費を削減するためにBLOBを使用する**

### **BLOBを通じてプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/java/) for Javaは、メモリ消費を削減するためにBLOBを利用して大きなファイル（この場合は大きな動画ファイル）を追加することを可能にします。

以下のJavaコードは、BLOBプロセスを通じてプレゼンテーションに大きな動画ファイルを追加する方法を示します：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 動画が追加される新しいプレゼンテーションを作成
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // プレゼンテーションに動画を追加します - "veryLargeVideo.avi"ファイルにアクセスするつもりはないため、KeepLocked動作を選択します。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力されている間、presオブジェクトのライフサイクルを通じてメモリ消費は低く保たれます 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


### **プレゼンテーションからBLOBを通じて大きなファイルをエクスポートする**
Aspose.Slides for Javaは、BLOBを通じてプレゼンテーションから大きなファイル（この場合は音声または動画ファイル）をエクスポートすることを可能にします。たとえば、プレゼンテーションから大きなメディアファイルを抽出する必要があるが、そのファイルがコンピュータのメモリに読み込まれないようにしたい場合、BLOBプロセスを通じてファイルをエクスポートすることでメモリ消費を低く保つことができます。 

以下のJavaコードは、説明した操作を示しています：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリに読み込まない
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// プレゼンテーションのインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx"ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各動画をファイルに保存します。高いメモリ使用を防ぐために、プレゼンテーションの動画ストリームから新しく作成された動画ファイルのストリームにデータを転送するために使用されるバッファが必要です。
    byte[] buffer = new byte[8 * 1024];

    // 動画を反復処理します
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションの動画ストリームを開きます。ビデオのBinaryDataなどのプロパティにアクセスすることを避けていることに注意してください - このプロパティは、完全な動画を含むバイト配列を返すため、その結果、バイトがメモリに読み込まれることになります。video.GetStreamを使用して、ストリームを返すため、動画全体をメモリに読み込む必要はありません。
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
        // 動画やプレゼンテーションのサイズに関係なく、メモリ消費は低く保たれます。
    }
    // 必要に応じて、音声ファイルについても同様の手順を適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **プレゼンテーションにBLOBとして画像を追加する**
[**IImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/IImageCollection)インターフェースと[**ImageCollection**](https://reference.aspose.com/slides/java/com.aspose.slides/ImageCollection)クラスのメソッドを使用することで、大きな画像をストリームとして追加し、BLOBとして扱うことができます。 

以下のJavaコードは、BLOBプロセスを通じて大きな画像を追加する方法を示します：

```java
String pathToLargeImage = "large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// プレゼンテーションに画像を追加します - "largeImage.png"ファイルにアクセスするつもりはないため、KeepLocked動作を選択します。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力されている間、presオブジェクトのライフサイクルを通じてメモリ消費は低く保たれます
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

通常、大きなプレゼンテーションを読み込むためには、コンピュータは多くの一時メモリを必要とします。プレゼンテーションのすべての内容がメモリに読み込まれ、プレゼンテーションが読み込まれたファイルの使用が停止します。 

1.5 GBの動画ファイルを含む大きなPowerPointプレゼンテーション（large.pptx）を考慮してください。プレゼンテーションを読み込むための標準的な方法は、以下のJavaコードに示されています：

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

しかし、この方法は約1.6 GBの一時メモリを消費します。 

### **BLOBとして大きなプレゼンテーションを読み込む**

BLOBを利用するプロセスにより、非常に少ないメモリを使用して大きなプレゼンテーションを読み込むことができます。このJavaコードは、BLOBプロセスを使用して大きなプレゼンテーションファイル（large.pptx）を読み込む実装を示しています：

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

BLOBプロセスを使用すると、コンピュータは一時ファイルを一時ファイルのデフォルトフォルダーに作成します。一時ファイルを別のフォルダーに保持したい場合は、`TempFilesRootPath`を使用してストレージの設定を変更できます：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="情報" color="info" %}}

`TempFilesRootPath`を使用すると、Aspose.Slidesは一時ファイルを保存するフォルダーを自動的には作成しません。フォルダーを手動で作成する必要があります。 

{{% /alert %}}