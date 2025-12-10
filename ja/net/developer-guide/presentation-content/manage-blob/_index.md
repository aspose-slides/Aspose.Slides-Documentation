---
title: .NET でプレゼンテーション BLOB を管理して効率的なメモリ使用を実現
linktitle: BLOB を管理
type: docs
weight: 10
url: /ja/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET における BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化して、プレゼンテーションの取り扱いを最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は、通常、バイナリ形式で保存された大きなアイテム（写真、プレゼンテーション、文書、またはメディア）です。

Aspose.Slides for .NET は、大きなファイルが関与する場合にメモリ使用量を削減する方法で、オブジェクトに BLOB を使用できるようにします。

## **メモリ消費を削減するための BLOB の使用**

### **BLOB を使用してプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/ja/net/) for .NET は、メモリ使用量を削減するために BLOB を介したプロセスで大きなファイル（この場合は大きなビデオ ファイル）を追加できます。

この C# は、BLOB プロセスを通じて大きなビデオ ファイルをプレゼンテーションに追加する方法を示しています:
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // ビデオをプレゼンテーションに追加します - KeepLocked 動作を選んだのは、  
        // 「veryLargeVideo.avi」ファイルにアクセスしないつもりだからです。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力されても、  
        // pres オブジェクトのライフサイクルを通じてメモリ消費は低く保たれます
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポートする**
Aspose.Slides for .NET は、プレゼンテーションから BLOB を介したプロセスで大きなファイル（この場合は音声またはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディア ファイルを抽出したいが、コンピューターのメモリに読み込ませたくない場合があります。BLOB プロセスでファイルをエクスポートすることで、メモリ消費を低く抑えることができます。

この C# コードは、上記の操作を示しています:
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// ソースファイルをロックし、メモリに読み込まないようにします
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// プレゼンテーションのインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 各ビデオをファイルに保存しましょう。メモリ使用量が高くなるのを防ぐために、バッファが必要です。
	// プレゼンテーションのビデオストリームから、新しく作成したビデオファイル用のストリームへデータを転送するためです。
	byte[] buffer = new byte[8 * 1024];

	// ビデオを列挙します
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを避けていることに注意してください。
		// video.BinaryData のようなプロパティは、フルビデオを含むバイト配列を返すため、
		// メモリにバイトがロードされます。そのため video.GetStream を使用し、//  全ビデオをメモリに読み込む必要はありません。
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

		// ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く保たれます。
	}

	// 必要に応じて、オーディオファイルにも同様の手順を適用できます。 
}
```


### **画像を BLOB としてプレゼンテーションに追加する**
[**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) インターフェイスと[**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

この C# コードは、BLOB プロセスを通じて大きな画像を追加する方法を示しています:
```c#
string pathToLargeImage = "large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成します。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// プレゼンテーションに画像を追加します - KeepLocked 動作を選択したのは、  
		// 「largeImage.png」ファイルにアクセスするつもりがないためです。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力されても、  
		// pres オブジェクトのライフサイクル全体でメモリ消費は低く保たれます。
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **メモリと大規模プレゼンテーション**

通常、大規模なプレゼンテーションを読み込むには、コンピューターは大量の一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリに読み込まれ、プレゼンテーションが読み込まれた元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大規模 PowerPoint プレゼンテーション（large.pptx）を考えてみます。プレゼンテーションを読み込む標準的な方法は、以下の C# コードで説明されています:
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


しかしこの方法は約 1.6 GB の一時メモリを消費します。

### **BLOB として大規模プレゼンテーションを読み込む**

BLOB を介したプロセスを使用すると、少ないメモリで大規模なプレゼンテーションを読み込むことができます。この C# コードは、BLOB プロセスを使用して large.pptx を読み込む実装を示しています:
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


### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、コンピューターはデフォルトの一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用してストレージ設定を変更できます:
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

**Aspose.Slides のプレゼンテーションで、どのデータが BLOB とみなされ、BLOB オプションで制御されますか？**

画像、音声、ビデオなどの大きなバイナリ オブジェクトが BLOB とみなされます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が関与します。これらのオブジェクトは BLOB ポリシーによって管理され、メモリ使用量を制御し、必要に応じて一時ファイルにスピルできます。

**プレゼンテーションの読み込み時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) を組み合わせて使用します。ここで BLOB のメモリ上限を設定し、一時ファイルの使用可否、ルート パス、ソース ロック動作を指定できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリに保持すると速度は最大化されますが RAM 使用量が増加します。メモリ上限を下げると処理の多くが一時ファイルに転送され、RAM は減りますが I/O が増加します。ワークロードと環境に合わせて [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) の閾値を調整し、最適なバランスを見つけてください。

**極めて大きなプレゼンテーション（例: 数ギガバイト）を開く際に BLOB オプションは役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化とソース ロックの使用により、ピーク RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させます。

**ディスク ファイルではなくストリームから読み込む場合でも BLOB ポリシーは使用できますか？**

はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（ロック モードによります）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。