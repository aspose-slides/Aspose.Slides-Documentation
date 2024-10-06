---
title: Blobの管理
type: docs
weight: 10
url: /ja/androidjava/manage-blob/
description: Javaを使用してPowerPointプレゼンテーションでBlobを管理します。Blobを使用してJavaでのPowerPointプレゼンテーションのメモリ消費を削減します。Javaを使用してBlobを介してPowerPointプレゼンテーションに大きなファイルを追加します。Javaを使用してBlobを介してPowerPointプレゼンテーションから大きなファイルをエクスポートします。Javaを使用してBlobとして大きなPowerPointプレゼンテーションをロードします。
---

## **BLOBについて**

**BLOB** (**Binary Large Object**)は通常、バイナリ形式で保存された大きなアイテム（写真、プレゼンテーション、文書、またはメディア）です。

Aspose.Slides for Android via Javaを使用すると、大きなファイルが関与する場合のメモリ消費を削減する方法でBLOBをオブジェクトに使用できます。

{{% alert title="情報" color="info" %}}

ストリームと対話する際の特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーする場合があります。ストリームを介して大きなプレゼンテーションをロードすると、プレゼンテーションの内容のコピーが行われ、ロードが遅くなります。したがって、大きなプレゼンテーションをロードする際には、ストリームではなくプレゼンテーションファイルのパスを使用することを強くお勧めします。

{{% /alert %}}

## **BLOBを使用してメモリ消費を削減する**

### **BLOBを介してプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/ja/androidjava/) for Javaを使用すると、BLOBを介したプロセスで大きなファイル（この場合、大きなビデオファイル）を追加することで、メモリ消費を削減できます。

このJavaコードは、BLOBプロセスを介してプレゼンテーションに大きなビデオファイルを追加する方法を示しています：

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// 新しいプレゼンテーションを作成し、そこにビデオを追加します
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // プレゼンテーションにビデオを追加します - "veryLargeVideo.avi"ファイルにアクセスするつもりはないため、KeepLocked動作を選択します。
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、presオブジェクトのライフサイクルを通じてメモリ消費は低く保たれます
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **プレゼンテーションからBLOBを介して大きなファイルをエクスポートする**
Aspose.Slides for Android via Javaを使用すると、プレゼンテーションからBLOBを介したプロセスで大きなファイル（この場合、音声またはビデオファイル）をエクスポートできます。たとえば、大きなメディアファイルをプレゼンテーションから抽出する必要があるが、そのファイルをコンピューターのメモリにロードしたくない場合があります。BLOBプロセスを介してファイルをエクスポートすることにより、メモリ消費を低く保つことができます。

このJavaコードは、前述の操作を示しています：

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// ソースファイルをロックし、メモリにロードしません
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// プレゼンテーションのインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx"ファイルをロックします。
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // 各ビデオをファイルに保存します。メモリ使用量を抑えるためには、プレゼンテーションのビデオストリームから新しく作成されたビデオファイル用のストリームにデータを転送するためのバッファが必要です。
    byte[] buffer = new byte[8 * 1024];

    // ビデオを反復処理します
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // プレゼンテーションのビデオストリームを開きます。video.BinaryDataのようなプロパティに意図的にアクセスするのを避けたことに注意してください - このプロパティは完全なビデオを含むバイト配列を返し、それによってバイトがメモリにロードされる原因となります。video.GetStreamを使用すると、Streamが返され、全体のビデオをメモリにロードする必要がありません。
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
        // ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低いままです。
    }
    // 必要に応じて、音声ファイルについても同じ手順を適用できます。 
} catch (IOException e) {
} finally {
    pres.dispose();
}

```

### **プレゼンテーションにBLOBとして画像を追加する**
[**IImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IImageCollection)インターフェースと[**ImageCollection**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ImageCollection)クラスのメソッドを使用すると、ストリームとして大きな画像を追加してBLOBとして扱うことができます。

このJavaコードは、BLOBプロセスを介して大きな画像を追加する方法を示しています：

```java
String pathToLargeImage = "large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成します。
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// プレゼンテーションに画像を追加します - "largeImage.png"ファイルにアクセスするつもりはないため、KeepLocked動作を選択します。
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、presオブジェクトのライフサイクルを通じてメモリ消費は低く保たれます
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

通常、大きなプレゼンテーションをロードするためには、コンピューターは多くの一時メモリを必要とします。すべてのプレゼンテーションの内容がメモリにロードされ、プレゼンテーションをロードしたファイルの使用が停止します。

例えば、1.5 GBのビデオファイルを含む大きなPowerPointプレゼンテーション（large.pptx）を考えてみましょう。プレゼンテーションをロードする標準的な方法は、このJavaコードで説明されています：

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

しかし、この方法では約1.6 GBの一時メモリを消費します。

### **BLOBとして大きなプレゼンテーションをロードする**

BLOBを介したプロセスを通じて、少ないメモリを使用して大きなプレゼンテーションをロードできます。このJavaコードは、BLOBプロセスを使用して大きなプレゼンテーションファイル（large.pptx）をロードする実装を説明しています：

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

BLOBプロセスを使用すると、コンピューターは一時ファイルを一時ファイル用のデフォルトフォルダーに作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath`を使用してストレージの設定を変更できます：

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="情報" color="info" %}}

`TempFilesRootPath`を使用する場合、Aspose.Slidesは一時ファイルを保存するフォルダーを自動的には作成しません。フォルダーを手動で作成する必要があります。

{{% /alert %}}