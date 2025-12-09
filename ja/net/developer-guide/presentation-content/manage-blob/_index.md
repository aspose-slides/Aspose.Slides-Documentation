---
title: .NET でプレゼンテーション BLOB を管理し、メモリ使用を効率化する
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/net/manage-blob/
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
- .NET
- C#
- Aspose.Slides
description: ".NET 用 Aspose.Slides の BLOB データを管理し、PowerPoint および OpenDocument ファイルの操作を効率化してプレゼンテーションの取り扱いを最適化します。"
---

## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存された大きなアイテム（写真、プレゼンテーション、ドキュメント、またはメディア）です。

Aspose.Slides for .NET は、大きなファイルが関与する場合にメモリ使用量を削減する方法で、オブジェクトに対して BLOB を使用できるようにします。

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を使用してプレゼンテーションに大きなファイルを追加する**

[Aspose.Slides](/slides/ja/net/) for .NET は、BLOB を介したプロセスで大きなファイル（この場合は大きなビデオ ファイル）を追加し、メモリ使用量を削減できます。

以下の C# は、BLOB プロセスを使用して大きなビデオ ファイルをプレゼンテーションに追加する方法を示しています。
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // プレゼンテーションにビデオを追加します - KeepLocked 動作を選択したのは、 
        // 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
        // pres オブジェクトのライフサイクルを通じて低く保たれます 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポートする**
Aspose.Slides for .NET は、プレゼンテーションから BLOB を介したプロセスで大きなファイル（この場合はオーディオまたはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディア ファイルを抽出したいが、そのファイルをコンピューターのメモリにロードしたくない場合があります。BLOB プロセスを通じてファイルをエクスポートすることで、メモリ使用量を低く抑えることができます。

以下の C# コードは、上記の操作を示しています。
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// ソースファイルをロックし、メモリに読み込まない
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 各ビデオをファイルに保存します。メモリ使用量が増えるのを防ぐために、バッファが必要です
	// プレゼンテーションのビデオストリームから新しく作成したビデオファイル用ストリームへデータを転送するためのものです。
	byte[] buffer = new byte[8 * 1024];

	// ビデオを列挙します
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
		// video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため
		// メモリにバイトを読み込んでしまいます。代わりに video.GetStream を使用し、これにより Stream が返され、メモリに全体を読み込む必要はありません。
		//  require us to load the whole video into the memory.
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

		// ビデオやプレゼンテーションのサイズに関わらず、メモリ消費は低く保たれます、
	}

	// 必要に応じて、オーディオファイルにも同じ手順を適用できます。 
}
```


### **プレゼンテーションに画像を BLOB として追加する**
[IImageCollection](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) インターフェイスと[ImageCollection](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) クラスのメソッドを使用すると、ストリームとして大きな画像を追加し、BLOB として扱うことができます。

以下の C# コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています。
```c#
string pathToLargeImage = "large_image.jpg";

// 画像を追加する新しいプレゼンテーションを作成します。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// 画像をプレゼンテーションに追加しましょう - KeepLocked 動作を選択したのは、
		// 「largeImage.png」ファイルにアクセスするつもりがないためです。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
		// pres オブジェクトのライフサイクルを通じて低く保たれます
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **メモリと大きなプレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピューターは多くの一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリにロードされ、プレゼンテーションがロードされた元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的なロード方法は以下の C# コードに示されています。
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


しかし、この方法は約 1.6 GB の一時メモリを消費します。

### **BLOB として大きなプレゼンテーションをロードする**

BLOB を介したプロセスを使用すると、メモリ使用量を抑えながら大きなプレゼンテーションをロードできます。以下の C# コードは、BLOB プロセスを使用して大きなプレゼンテーション ファイル（large.pptx）をロードする実装を示しています。
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

BLOB プロセスを使用すると、コンピューターはデフォルトの一時フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用してストレージ設定を変更できます。
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

**Aspose.Slides のプレゼンテーションでどのデータが BLOB と見なされ、BLOB オプションで制御されますか？**

画像、オーディオ、ビデオなどの大きなバイナリ オブジェクトが BLOB と見なされます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB 処理が関与します。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルにスピルできるようにする BLOB ポリシーによって制御されます。

**プレゼンテーションのロード時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限を設定し、一時ファイルの使用可否、ルート パス、ソース ロック動作を指定できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリに保持すると速度は最大化されますが RAM 使用量が増加します。メモリ上限を下げると処理が一時ファイルにシフトし、RAM は削減されますが I/O が増加します。作業負荷と環境に合わせて [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) の閾値を調整し、最適なバランスを見つけてください。

**非常に大きなプレゼンテーション（例: ギガバイト規模）を開く際に BLOB オプションは役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化とソース ロックの使用により、ピーク RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させます。

**ディスク ファイルではなくストリームからロードする場合にも BLOB ポリシーは使用できますか？**

はい。同じルールがストリームにも適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（選択したロック モードに依存）、許可されている場合は一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。