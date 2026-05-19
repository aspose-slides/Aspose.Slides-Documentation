---
title: ".NET でプレゼンテーション BLOB を管理し、メモリ使用を効率化"
linktitle: "BLOB を管理"
type: docs
weight: 10
url: /ja/net/manage-blob/
keywords:
- 大容量オブジェクト
- 大容量アイテム
- 大容量ファイル
- BLOB の追加
- BLOB のエクスポート
- 画像を BLOB として追加
- メモリ削減
- メモリ消費
- 大容量プレゼンテーション
- 一時ファイル
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET で BLOB データを管理し、PowerPoint および OpenDocument ファイルの操作を合理化して、プレゼンテーションの効率的な処理を実現します。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内の大容量バイナリ データ（画像、オーディオ、ビデオ、プレゼンテーション ファイル）を BLOB で処理できるようにし、メモリ使用量の削減に寄与します。

本稿では、BLOB ベースの処理を使用してプレゼンテーションに大容量メディアを追加する方法、プレゼンテーションから大容量メディアをエクスポートする方法、そして大容量プレゼンテーションをより効率的に読み込む方法を示します。また、処理中に一時ファイルを利用する方法と、一時ファイルの保存先フォルダーを変更する方法についても説明します。

## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存された大容量項目（写真、プレゼンテーション、文書、メディア）を指します。

Aspose.Slides for .NET は、ファイルが大きくなる場合にメモリ消費を抑える形で BLOB をオブジェクトに使用できるようにします。

## **BLOB を使用してメモリ消費を削減する**

### **BLOB を通じて大容量ファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/net/) for .NET は、メモリ使用量を削減するために BLOB を介したプロセスで大容量ファイル（ここでは大きなビデオ ファイル）を追加できます。

この C# サンプルは、BLOB プロセスを使用して大容量ビデオ ファイルをプレゼンテーションに追加する方法を示しています。

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

        // プレゼンテーションを保存します。大容量のプレゼンテーションが出力される間、
        // pres オブジェクトのライフサイクル全体でメモリ使用量は低く保たれます 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **BLOB を通じてプレゼンテーションから大容量ファイルをエクスポートする**
Aspose.Slides for .NET は、BLOB を介したプロセスでプレゼンテーションから大容量ファイル（オーディオまたはビデオ）をエクスポートできます。たとえば、プレゼンテーションから大容量メディア ファイルを抽出したいが、コンピューターのメモリに読み込ませたくない場合があります。BLOB プロセスでエクスポートすれば、メモリ消費を低く抑えることができます。

以下の C# コードは、上述の操作を実演しています。

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// ソース ファイルをロックし、メモリに読み込まない
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 各ビデオをファイルに保存します。メモリ使用量の増加を防ぐために、使用されるバッファが必要です
	// プレゼンテーションのビデオ ストリームから新しく作成したビデオ ファイルのストリームへデータを転送します。
	byte[] buffer = new byte[8 * 1024];

	// ビデオを列挙します
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// プレゼンテーションのビデオ ストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください
		// video.BinaryData のようなプロパティは、フル ビデオを含むバイト配列を返すため、
		// メモリにバイトがロードされます。video.GetStream を使用すれば、Stream を返し、メモリにロードする必要はありません
		//  ビデオ全体をメモリにロードする必要がありません。
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

		// ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く保たれます、
	}

	// 必要に応じて、オーディオ ファイルにも同じ手順を適用できます。 
}
```

### **画像を BLOB としてプレゼンテーションに追加する**
[IImageCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/iimagecollection) インターフェイスおよび [ImageCollection](https://reference.aspose.com/slides/ja/net/aspose.slides/imagecollection) クラスのメソッドを使用すると、ストリームとして大容量画像を追加し、BLOB として扱うことができます。

この C# コードは、BLOB プロセスを使用して大容量画像を追加する方法を示しています。

```c#
string pathToLargeImage = "large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成します。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// 画像をプレゼンテーションに追加します - KeepLocked 動作を選択したのは、
		// 「largeImage.png」ファイルにアクセスするつもりがないためです。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大容量のプレゼンテーションが出力される間、メモリ消費は
		// pres オブジェクトのライフサイクル全体で低く保たれます
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **メモリと大容量プレゼンテーション**

通常、大容量プレゼンテーションを読み込むには、一時メモリが大量に必要になります。プレゼンテーションの全コンテンツがメモリにロードされ、元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大容量 PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。このプレゼンテーションを読み込む標準的な方法は、次の C# コードで示されています。

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

しかし、この方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大容量プレゼンテーションを読み込む**

BLOB を介したプロセスを利用すれば、少量のメモリで大容量プレゼンテーションを読み込むことができます。以下の C# コードは、BLOB プロセスを使用して large.pptx を読み込む実装例です。

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

BLOB プロセスを使用すると、既定の一時ファイル フォルダーに一時ファイルが作成されます。別のフォルダーに保存したい場合は、`TempFilesRootPath` を使用して保存先を変更できます。

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
`TempFilesRootPath` を使用する場合、Aspose.Slides は一時ファイル用フォルダーを自動で作成しません。フォルダーは手動で作成してください。
{{% /alert %}}

### **Presentation オブジェクトを破棄してメモリを解放する**

大容量プレゼンテーションを処理する際は、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) インスタンスを適切に破棄して、使用していたメモリを解放してください。推奨される方法は、上記サンプルのように `using` 文または宣言を使用することです。これによりブロック終了時に自動でプレゼンテーションが破棄され、アンマネージド リソースが解放されます。

`using` ブロックを使用しないでプレゼンテーションを作成した場合は、使用後に明示的に `Dispose()` を呼び出してください。

```cs
Presentation presentation = new Presentation("large.pptx");

// ...プレゼンテーションを処理...
presentation.Save("large.pdf", SaveFormat.Pdf);

// リソースを明示的に解放します。
presentation.Dispose();
```

## **FAQ**

**Aspose.Slides のプレゼンテーション内で、どのデータが BLOB とみなされ、BLOB オプションで制御されますか？**

画像、オーディオ、ビデオなどの大容量バイナリ オブジェクトが BLOB とみなされます。プレゼンテーション全体のファイル自体も、読み込みや保存時に BLOB 処理の対象となります。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルにスピルさせるための BLOB ポリシーで制御されます。

**プレゼンテーションの読み込み時に BLOB の処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/loadoptions/) と共に [BlobManagementOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限や一時ファイルの使用可否、保存先ルート パス、ソース ロックの動作などを設定します。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

影響します。BLOB をメモリに保持すれば速度は最大化しますが RAM 使用量が増えます。メモリ上限を下げれば作業の多くが一時ファイルにオフロードされ、RAM 使用量は減りますが I/O が増加します。ワークロードと環境に合わせて [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ja/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) の閾値を調整し、最適なバランスを見つけてください。

**極端に大きなプレゼンテーション（数ギガバイト）を開く際に BLOB オプションは役立ちますか？**

役立ちます。[BlobManagementOptions](https://reference.aspose.com/slides/ja/net/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化やソース ロックの使用により、ピーク RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させます。

**ディスク ファイルではなくストリームから読み込む場合でも BLOB ポリシーは使用できますか？**

使用できます。ストリームにも同じルールが適用され、プレゼンテーション インスタンスは選択したロック モードに応じて入力ストリームを所有・ロックでき、許可された場合は一時ファイルが利用されるため、処理中のメモリ使用量を予測可能な状態に保てます。