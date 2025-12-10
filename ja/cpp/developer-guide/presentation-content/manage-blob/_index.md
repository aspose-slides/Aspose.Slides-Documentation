---
title: "C++でプレゼンテーションのBLOBを管理し、効率的なメモリ使用を実現"
linktitle: "BLOBの管理"
type: docs
weight: 10
url: /ja/cpp/manage-blob/
keywords:
  - "大きなオブジェクト"
  - "大きなアイテム"
  - "大きなファイル"
  - "BLOBの追加"
  - "BLOBのエクスポート"
  - "画像をBLOBとして追加"
  - "メモリ削減"
  - "メモリ消費"
  - "大規模プレゼンテーション"
  - "一時ファイル"
  - "PowerPoint"
  - "OpenDocument"
  - "プレゼンテーション"
  - "C++"
  - "Aspose.Slides"
description: "Aspose.Slides for C++ における BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化してプレゼンテーション処理を最適化します。"
---

## **BLOB の概要**

**BLOB** (**Binary Large Object**) は通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、ドキュメント、またはメディア）です。  

Aspose.Slides for C++ は、BLOB をオブジェクトに使用でき、大きなファイルが関与する場合のメモリ使用量を削減します。  

## **メモリ使用量を削減するための BLOB の使用**

### **BLOB を使用して大きなファイルをプレゼンテーションに追加**

[Aspose.Slides](/slides/ja/cpp/) for C++ は、BLOB を利用したプロセスで大きなファイル（この場合は大きな動画ファイル）を追加し、メモリ使用量を削減できます。  

この C++ コードは、BLOB プロセスを使用して大きな動画ファイルをプレゼンテーションに追加する方法を示しています:
```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// ビデオを追加する新しいプレゼンテーションを作成します
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// プレゼンテーションにビデオを追加しましょう - KeepLocked 動作を選択したのは、
// 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、
// pres オブジェクトのライフサイクル全体でメモリ使用量は低く保たれます 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **BLOB を使用してプレゼンテーションから大きなファイルをエクスポート**

Aspose.Slides for C++ は、BLOB を利用したプロセスでプレゼンテーションから大きなファイル（この場合は音声または動画ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディアファイルを抽出したいが、ファイルをコンピュータのメモリにロードしたくない場合があります。BLOB プロセスでエクスポートすることで、メモリ使用量を低く抑えることができます。  

以下の C++ コードは、上記の操作を実演しています:
```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// Presentation のインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// 各ビデオをファイルに保存しましょう。高いメモリ使用量を防ぐために、バッファが必要です
// プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するために使用されます。
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// ビデオを列挙します
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// プレゼンテーションのビデオストリームを開きます。意図的にメソッドへのアクセスを避けていることに注意してください
	// video->get_BinaryData のようなメソッドは、完全なビデオを含むバイト配列を返すため、
	// メモリにバイトをロードさせます。私たちは video->GetStream を使用し、これが Stream を返し、
	// 全ビデオをメモリにロードする必要はありません。
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// ビデオやプレゼンテーションのサイズに関係なく、メモリ消費は低く保たれます，
}

// 必要に応じて、オーディオファイルにも同じ手順を適用できます。
```


### **画像を BLOB としてプレゼンテーションに追加**

[**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) インターフェイスと [**ImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) クラスのメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱うことができます。  

この C++ コードは、BLOB プロセスを使用して大きな画像を追加する方法を示しています:
```cpp
const String pathToLargeImage = u"large_image.jpg";

// 画像が追加される新しいプレゼンテーションを作成します。
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// プレゼンテーションに画像を追加しましょう - KeepLocked 動作を選択したのは、
// 「largeImage.png」ファイルにアクセスするつもりがないためです。
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、
// pres オブジェクトのライフサイクル全体でメモリ使用量は低く保たれます
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```


## **メモリと大規模プレゼンテーション**

通常、大きなプレゼンテーションをロードするには、コンピュータは大量の一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリにロードされ、プレゼンテーションが読み込まれた元のファイルは使用されなくなります。  

たとえば、1.5 GB の動画ファイルを含む大規模な PowerPoint プレゼンテーション（large.pptx）を考えてみてください。標準的なロード方法は以下の C++ コードで示されています:
```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


しかし、この方法では約 1.6 GB の一時メモリが消費されます。  

### **BLOB として大規模プレゼンテーションをロード**

BLOB を利用したプロセスにより、少ないメモリで大規模なプレゼンテーションをロードできます。以下の C++ コードは、BLOB プロセスを使用して大規模プレゼンテーションファイル（large.pptx）をロードする実装を示しています:
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```


#### **一時ファイルのフォルダーを変更**

BLOB プロセスを使用すると、コンピュータはデフォルトの一時フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`TempFilesRootPath` を使用して保存設定を変更できます:
```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```


{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用すると、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。  
{{% /alert %}}

## **よくある質問**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**  

画像、音声、動画などの大きなバイナリオブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB の取り扱いが行われます。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量を管理し、必要に応じて一時ファイルへスピル（書き出し）できるようになっています。  

**プレゼンテーションのロード時に BLOB の取り扱いルールはどこで設定しますか？**  

[LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限を設定し、一時ファイルの使用許可・不許可、 一時ファイルのルートパス、 ソースロックの動作を選択できます。  

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**  

はい。BLOB をメモリに保持すると速度は最大化されますが RAM 使用量が増加します。メモリ上限を下げると、作業の多くが一時ファイルにオフロードされ、RAM は減りますが I/O が増加します。[set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) メソッドを使用して、ワークロードと環境に適したバランスを取ってください。  

**非常に大きなプレゼンテーション（例：ギガバイト単位）を開く際に BLOB オプションは役立ちますか？**  

はい。そのようなシナリオ向けに [BlobManagementOptions](https://reference.aspose.com/slides/cpp/aspose.slides/blobmanagementoptions/) が設計されています。 一時ファイルを有効にし、ソースロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、非常に大きな資料の処理を安定させることができます。  

**ディスクファイルではなくストリームからロードする場合でも BLOB ポリシーを使用できますか？**  

はい。同じルールがストリームにも適用されます。プレゼンテーションインスタンスは入力ストリームを所有およびロックでき（選択したロックモードに依存）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。