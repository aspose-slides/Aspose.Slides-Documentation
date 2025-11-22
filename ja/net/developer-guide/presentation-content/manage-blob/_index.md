---
title: Blob を管理する
type: docs
weight: 10
url: /ja/net/manage-blob/
keywords: "Blob の追加, Blob のエクスポート, 画像を Blob として追加, PowerPoint プレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C# または .NET で PowerPoint プレゼンテーションに Blob を追加します。Blob をエクスポートします。画像を Blob として追加します"
---

## **BLOBについて**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、文書、またはメディア）です。 

Aspose.Slides for .NET は、大きなファイルが関与する場合にメモリ使用量を削減する方法でオブジェクトに BLOB を使用できるようにします。 

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB 経由で大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/net/) for .NET は、メモリ使用量を削減するために BLOB を利用したプロセスで大きなファイル（この場合は大きなビデオファイル）を追加できるようにします。

この C# は、BLOB プロセスを通じて大きなビデオファイルをプレゼンテーションに追加する方法を示します:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // プレゼンテーションにビデオを追加します - KeepLocked 動作を選択したのは
        // 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ使用量は
        // pres オブジェクトのライフサイクル全体で低く保たれます 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```



### **BLOB 経由でプレゼンテーションから大きなファイルをエクスポートする**
Aspose.Slides for .NET は、プレゼンテーションから BLOB を利用したプロセスで大きなファイル（この場合は音声またはビデオファイル）をエクスポートできます。 たとえば、プレゼンテーションから大きなメディアファイルを抽出したいが、コンピューターのメモリにロードしたくない場合があります。BLOB プロセスでエクスポートすることで、メモリ使用量を低く抑えることができます。 

このコードは、上記の操作を C# で実演します:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// ソースファイルをロックし、メモリに読み込まないようにします
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 各ビデオをファイルに保存しましょう。メモリ使用量が増えるのを防ぐため、バッファが必要です
	// プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するためです
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
		// video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
		// メモリにバイトがロードされます。代わりに video.GetStream を使用し、Stream を返すので、 
		//  メモリ全体にビデオ全体をロードする必要はありません。
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// ビデオやプレゼンテーションのサイズに関係なく、メモリ使用量は低く保たれます
	}

	// 必要に応じて、オーディオファイルにも同じ手順を適用できます。 
}
```


### **プレゼンテーションに画像を BLOB として追加する**
[**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) インターフェイスと[**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)class のメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱わせることができます。 

この C# コードは、BLOB プロセスを通じて大きな画像を追加する方法を示します:
```c#
string pathToLargeImage = "large_image.jpg";

// 画像を追加する新しいプレゼンテーションを作成します。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// 画像をプレゼンテーションに追加します - KeepLocked 動作を選択したのは
		// 「largeImage.png」ファイルにアクセスしないためです。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、 
		// pres オブジェクトのライフサイクル全体でメモリ消費は低く保たれます
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **メモリと大規模プレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピューターに大量の一時メモリが必要です。プレゼンテーションの全コンテンツがメモリにロードされ、ロード元のファイルは使用されなくなります。 

1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。プレゼンテーションをロードする標準的な方法は、以下の C# コードで説明されています:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


ただし、この方法は約 1.6 GB の一時メモリを消費します。 

### **BLOB として大きなプレゼンテーションをロードする**

BLOB を利用したプロセスにより、少ないメモリで大きなプレゼンテーションをロードできます。この C# コードは、BLOB プロセスを使用して大きなプレゼンテーション ファイル（large.pptx）をロードする実装を示しています:
```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


### **一時ファイルのフォルダーを変更する**

BLOB プロセスを使用すると、コンピューターは既定の一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存設定を変更できます:
```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```


{{% alert title="Info" color="info" %}}

`TempFilesRootPath` を使用すると、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。 

{{% /alert %}}

## **FAQ**

**Aspose.Slides プレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、ビデオなどの大きなバイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB 処理が関与します。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量を管理し、必要に応じて一時ファイルへスピルできるようになっています。

**プレゼンテーションのロード時に BLOB 処理ルールを設定する場所はどこですか？**

[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限を設定し、一時ファイルの使用可否、ルートパス、ソースロックの動作を選択できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリに保持すると速度が最大化しますが、RAM 使用量が増えます。メモリ上限を下げると作業の多くが一時ファイルに転嫁され、RAM は削減されますが I/O が増加します。[MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) の閾値を調整して、ワークロードと環境に適したバランスを取ってください。

**非常に大きなプレゼンテーション（例：ギガバイト単位）を開く際に BLOB オプションは役立ちますか？**

はい。こうしたシナリオ向けに [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) が設計されています。一時ファイルを有効にし、ソースロックを使用すると、ピーク時の RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させます。

**ディスクファイルではなくストリームからロードする場合でも BLOB ポリシーを使用できますか？**

はい。同じルールがストリームにも適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（選択したロックモードに依存）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。