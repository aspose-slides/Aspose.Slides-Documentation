---
title: BLOBの管理
type: docs
weight: 10
url: /net/manage-blob/
keywords: "BLOBを追加, BLOBをエクスポート, BLOBとして画像を追加, PowerPointプレゼンテーション, C#, Csharp, Aspose.Slides for .NET"
description: "C#または.NETでPowerPointプレゼンテーションにBLOBを追加します。BLOBをエクスポートします。画像をBLOBとして追加します。"
---

## **BLOBについて**

**BLOB** (**Binary Large Object**)は、通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、文書、またはメディア）のことです。

Aspose.Slides for .NETは、大きなファイルが関与する場合にメモリ消費を抑える方法でオブジェクトにBLOBを使用することを可能にします。

## **BLOBを使用してメモリ消費を削減する**

### **プレゼンテーションにBLOBを介して大きなファイルを追加する**

[Aspose.Slides](/slides/net/) for .NETは、メモリ消費を減らすためにBLOBを介したプロセスで大きなファイル（この場合は大きなビデオファイル）を追加することを可能にします。

このC#コードは、BLOBプロセスを介してプレゼンテーションに大きなビデオファイルを追加する方法を示しています：

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// ビデオが追加される新しいプレゼンテーションを作成します
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // プレゼンテーションにビデオを追加しましょう - "veryLargeVideo.avi"ファイルにアクセスするつもりはないので
        // KeepLockedビヘイビアを選択します。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // プレゼンテーションを保存します。大きなプレゼンテーションが出力される際、presオブジェクトのライフサイクルを通してメモリ消費は低いままです
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **プレゼンテーションからBLOBを介して大きなファイルをエクスポートする**
Aspose.Slides for .NETは、プレゼンテーションからBLOBを介したプロセスで大きなファイル（この場合は音声またはビデオファイル）をエクスポートすることを可能にします。 例えば、プレゼンテーションから大きなメディアファイルを抽出する必要があるが、そのファイルをコンピュータのメモリに読み込みたくない場合があります。BLOBプロセスを介してファイルをエクスポートすることで、メモリ消費を低く抑えることができます。

このC#コードは、説明した操作を示しています：

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// ソースファイルをロックし、メモリに読み込まない
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// プレゼンテーションのインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx"ファイルをロックします。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 各ビデオをファイルに保存しましょう。高いメモリ使用量を防ぐために、プレゼンテーションのビデオストリームから新しく作成するビデオファイルへのデータ転送に使用するバッファが必要です。
	byte[] buffer = new byte[8 * 1024];

	// ビデオをイテレートします
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// プレゼンテーションのビデオストリームを開きます。ビデオ.BinaryDataのようなプロパティには意図的にアクセスしないことに注意してください - このプロパティは、完全なビデオを含むバイト配列を返し、その後、バイトがメモリに読み込まれることになります。我々はvideo.GetStreamを使用し、Streamを返します - そして、ビデオ全体をメモリに読み込む必要はありません。
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

		// ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低いままとなります。
	}

	// 必要に応じて、音声ファイルに対しても同様の手順を適用できます。
}
```

### **プレゼンテーションにBLOBとして画像を追加する**
[**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection)インターフェースや [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection)クラスのメソッドを使用して、BLOBとして扱われるように大きな画像をストリームとして追加できます。

このC#コードは、BLOBプロセスを介して大きな画像を追加する方法を示しています：

```c#
string pathToLargeImage = "large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成します。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// プレゼンテーションに画像を追加しましょう - "largeImage.png"ファイルにアクセスするつもりはないので
		// KeepLockedビヘイビアを選択します。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// プレゼンテーションを保存します。大きなプレゼンテーションが出力される際、presオブジェクトのライフサイクルを通してメモリ消費は低いまま
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **メモリと大きなプレゼンテーション**

通常、大きなプレゼンテーションを読み込むためには、コンピュータは大量の一時メモリを必要とします。すべてのプレゼンテーションの内容がメモリに読み込まれ、プレゼンテーションが読み込まれたファイルは使用しなくなります。

例えば、1.5 GBのビデオファイルを含む大きなPowerPointプレゼンテーション（large.pptx）を考えてみてください。プレゼンテーションを読み込む標準的な方法は、以下のC#コードに示されています：

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

しかし、この方法は約1.6 GBの一時メモリを消費します。

### **BLOBとして大きなプレゼンテーションを読み込む**

BLOBを介してプロセスを使用することで、少ないメモリで大きなプレゼンテーションを読み込むことができます。このC#コードは、BLOBプロセスを使用して大きなプレゼンテーションファイル（large.pptx）を読み込む実装を説明しています：

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

BLOBプロセスが使用されると、コンピュータはデフォルトの一時ファイルフォルダーに一時ファイルを作成します。一時ファイルを別のフォルダーに保持したい場合は、`TempFilesRootPath`を使用してストレージの設定を変更できます：

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

{{% alert title="情報" color="info" %}}

`TempFilesRootPath`を使用する際、Aspose.Slidesは一時ファイルを保存するためのフォルダーを自動的に作成しません。フォルダーを手動で作成する必要があります。

{{% /alert %}}