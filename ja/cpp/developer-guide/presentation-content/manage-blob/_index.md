---
title: BLOBの管理
type: docs
weight: 10
url: /cpp/manage-blob/
keywords: "BLOBの追加, BLOBのエクスポート, 画像をBLOBとして追加, PowerPointプレゼンテーション, C++, Aspose.Slides for C++"
description: "C++でPowerPointプレゼンテーションにBLOBを追加。BLOBをエクスポート。画像をBLOBとして追加"
---

## **BLOBについて**

**BLOB**（**Binary Large Object**）とは、通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、ドキュメント、メディア）を指します。

Aspose.Slides for C++では、大きなファイルが関与する場合にメモリ消費を抑える形でBLOBをオブジェクトに使用することができます。

## **メモリ消費を抑えるためのBLOBの使用**

### **BLOBを通じて大きなファイルをプレゼンテーションに追加**

[C++用Aspose.Slides](/slides/cpp/)では、メモリ消費を抑えるためにBLOBを利用したプロセスを通じて大きなファイル（この場合、大きな動画ファイル）を追加することができます。

このC++のコードは、BLOBプロセスを通じて大きな動画ファイルをプレゼンテーションに追加する方法を示しています：

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// プレゼンテーションにビデオを追加します - "veryLargeVideo.avi"ファイルにアクセスするつもりはないため
// KeepLockedの動作を選択します。
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
// presオブジェクトのライフサイクルを通じて低く保たれます
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **プレゼンテーションからBLOBを通じて大きなファイルをエクスポート**
Aspose.Slides for C++では、プレゼンテーションからBLOBを使ったプロセスを通じて大きなファイル（この場合、音声または動画ファイル）をエクスポートすることができます。たとえば、プレゼンテーションから大きなメディアファイルを抽出する必要があるが、そのファイルをコンピュータのメモリに読み込むことを望まない場合があります。BLOBプロセスを通じてファイルをエクスポートすることで、メモリ消費を低く保つことができます。

このC++のコードは、説明された操作を示しています：

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// プレゼンテーションのインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx"ファイルをロックします。

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// 各ビデオをファイルに保存します。高メモリ使用を防ぐため、プレゼンテーションのビデオストリームから
// 新しく作成された動画ファイル用のストリームにデータを転送するためのバッファが必要です。
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// ビデオを反復処理
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// プレゼンテーションのビデオストリームを開きます。注意してください、私たちは意図的に
	// video->get_BinaryDataなどのメソッドへのアクセスを避けました - なぜなら、このメソッドは
	// 完全なビデオを含むバイト配列を返すため、バイトがメモリに読み込まれるからです。私たちは
	// video->GetStreamを使用し、これはStreamを返します - そして全ビデオをメモリに読み込むことを
	// 要求しません。

	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// ビデオやプレゼンテーションのサイズに関わらず、メモリ消費は低いままです
}

// 必要に応じて、音声ファイルにも同じ手順を適用できます。
```

### **プレゼンテーションに画像をBLOBとして追加**
[**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection)インターフェイスおよび[**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection)クラスのメソッドを使用して、大きな画像をストリームとして追加し、BLOBとして扱うことができます。

このC++のコードは、BLOBプロセスを通じて大きな画像を追加する方法を示しています：

```cpp
const String pathToLargeImage = u"large_image.jpg";

// 画像を追加する新しいプレゼンテーションを作成します。
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// プレゼンテーションに画像を追加します - "largeImage.png"ファイルにアクセスするつもりはないため
// KeepLockedの動作を選択します。
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費 
// はpresオブジェクトのライフサイクルを通じて低く保たれます
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **メモリと大きなプレゼンテーション**

通常、大きなプレゼンテーションを読み込むためには、コンピュータは多くの一時メモリを必要とします。すべてのプレゼンテーションの内容はメモリに読み込まれ、（プレゼンテーションが読み込まれた）ファイルはもはや使用されません。

1.5 GBの動画ファイルを含む大きなPowerPointプレゼンテーション（large.pptx）を考えてみてください。プレゼンテーションを読み込むための標準的な方法は、このC++のコードで説明されています：

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

しかし、この方法では約1.6 GBの一時メモリを消費します。

### **BLOBとして大きなプレゼンテーションを読み込む**

BLOBを使用したプロセスを通じて、大きなプレゼンテーションを少ないメモリで読み込むことができます。このC++のコードは、BLOBプロセスを使用して大きなプレゼンテーションファイル（large.pptx）を読み込む実装を説明しています：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **一時ファイルのフォルダを変更する**

BLOBプロセスを使用するとき、コンピュータは一時ファイルをデフォルトの一時ファイルフォルダに作成します。一時ファイルを別のフォルダに保持したい場合は、`TempFilesRootPath`を使用してストレージの設定を変更できます：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="情報" color="info" %}}

`TempFilesRootPath`を使用すると、Aspose.Slidesは一時ファイルを保存するフォルダを自動的に作成しません。フォルダを手動で作成する必要があります。

{{% /alert %}}