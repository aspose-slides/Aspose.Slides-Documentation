---
title: "C++でプレゼンテーション BLOB を管理し、メモリ使用を効率化"
linktitle: "BLOB の管理"
type: docs
weight: 10
url: /ja/cpp/manage-blob/
keywords:
- 大規模オブジェクト
- 大規模アイテム
- 大容量ファイル
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ で BLOB データを管理し、PowerPoint および OpenDocument ファイルの操作を効率化してプレゼンテーションの処理を最適化します。"
---
## **概要**

Aspose.Slides はプレゼンテーション内の大容量バイナリ データを BLOB ベースで処理し、大きな画像、音声、動画、プレゼンテーション ファイルを扱う際のメモリ消費を抑えることができます。

本記事では、BLOB ベースの処理を使用してプレゼンテーションに大容量メディアを追加する方法、プレゼンテーションから大容量メディアをエクスポートする方法、および大容量プレゼンテーションをより効率的に読み込む方法を示します。また、処理中に一時ファイルを使用する方法と、一時ファイルの保存先フォルダーを変更する方法についても説明します。

## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存される大容量の項目（写真、プレゼンテーション、ドキュメント、メディアなど）を指します。

Aspose.Slides for C++ は、巨大ファイルを扱う際にメモリ消費を削減できるよう、オブジェクトに対して BLOB を使用することを可能にします。

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB 経由で大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/cpp/) for C++ は、メモリ使用量を抑えるために BLOB を介して大きなファイル（この例では大容量ビデオ ファイル）を追加できるようにします。

この C++ コードは、BLOB プロセスを介して大容量ビデオ ファイルをプレゼンテーションに追加する方法を示しています:

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// ビデオが追加される新しいプレゼンテーションを作成します
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// プレゼンテーションにビデオを追加しましょう - KeepLocked 動作を選択したのは、//not intend to access the "veryLargeVideo.avi" file.
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は// stays low through the pres object's lifecycle 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **BLOB 経由でプレゼンテーションから大きなファイルをエクスポートする**

Aspose.Slides for C++ は、BLOB を介してプレゼンテーションから大容量ファイル（音声または動画ファイル）をエクスポートできるようにします。たとえば、プレゼンテーションから大容量メディア ファイルを抽出したいが、ファイルをコンピューターのメモリにロードしたくない場合があります。BLOB プロセスを使用してエクスポートすれば、メモリ消費を低く抑えることができます。

この C++ のコードは、上記の操作を実演しています:

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// プレゼンテーションのインスタンスを作成し、"hugePresentationWithAudiosAndVideos.pptx" ファイルをロックします。

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// 各ビデオをファイルに保存します。メモリ使用量の増加を防ぐために、使用されるバッファが必要です
// プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送するために
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// ビデオを列挙します
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
    auto video = pres->get_Videos()->idx_get(index);

    // プレゼンテーションのビデオストリームを開きます。意図的にメソッドへのアクセスを回避したことにご注意ください
    // video->get_BinaryData のようなメソッドは、フルビデオを含むバイト配列を返すため
    // メモリにバイトをロードします。video->GetStream を使用すると、Stream が返され、メモリにロードする必要はありません
    // 全ビデオをメモリにロードする必要がありません
    
    auto presVideoStream = video->GetStream();

    auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
    int32_t bytesRead;
    while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
    {
        outputFileStream->Write(buffer, 0, bytesRead);
    }
        
    // ビデオやプレゼンテーションのサイズにかかわらず、メモリ消費は低く保たれます
}

// 必要に応じて、同じ手順を音声ファイルにも適用できます。
```

### **画像を BLOB としてプレゼンテーションに追加する**

[**IImageCollection**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.i_image_collection) インターフェイスおよび [**ImageCollection**](https://reference.aspose.com/slides/ja/cpp/class/aspose.slides.image_collection) クラスのメソッドを使用すると、画像をストリームとして追加し、BLOB として扱うことができます。

この C++ コードは、BLOB プロセスを使用して大容量画像を追加する方法を示しています:

```cpp
const String pathToLargeImage = u"large_image.jpg";

// 新しいプレゼンテーションを作成し、画像を追加します。
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// プレゼンテーションに画像を追加しましょう - KeepLocked 動作を選択したのは、
// 「largeImage.png」ファイルにアクセスするつもりがないためです。
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
// プレゼンテーション オブジェクトのライフサイクル全体で低く保たれます
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **メモリと大容量プレゼンテーション**

通常、大容量プレゼンテーションを読み込むには、一時メモリが大量に必要です。プレゼンテーションのすべてのコンテンツがメモリにロードされ、元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオ ファイルを含む大容量 PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的な読み込み方法は次の C++ コードで示されています:

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

しかしこの方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大容量プレゼンテーションを読み込む**

BLOB を利用したプロセスにより、少ないメモリで大容量プレゼンテーションを読み込むことができます。この C++ のコードは、BLOB プロセスを使用して large.pptx を読み込む実装例を示しています:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、デフォルトの一時ファイル フォルダーに一時ファイルが作成されます。別のフォルダーに保存したい場合は、`TempFilesRootPath` を使用して保存先を変更できます:

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
`TempFilesRootPath` を使用する場合、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **プレゼンテーション オブジェクトを破棄してメモリを解放する**

大容量プレゼンテーションを処理する際は、[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) インスタンスを適切に破棄し、占有していたメモリを解放してください。プレゼンテーションの使用が終了したら `Dispose()` を呼び出し、アンマネージド リソースを解放します。

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **FAQ**

**Aspose.Slides のプレゼンテーション内でどのデータが BLOB として扱われ、BLOB オプションで制御されますか？**

画像、音声、動画などの大容量バイナリ オブジェクトが BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が適用されます。これらのオブジェクトは、メモリ使用量を管理し必要に応じて一時ファイルにスピルさせる BLOB ポリシーの対象です。

**プレゼンテーションの読み込み時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides/blobmanagementoptions/) を組み合わせて使用します。ここで BLOB のメモリ上限を設定したり、一時ファイルの使用可否、ルート パス、ソース ロック動作などを指定します。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

影響します。BLOB をメモリ内に保持すると速度は最大化しますが RAM 使用量が増加します。メモリ上限を下げると作業の一部が一時ファイルにオフロードされ、RAM は削減されますが I/O が増加します。ワークロードと環境に合わせて適切なバランスを取るには、[set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/ja/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) メソッドを使用してください。

**極めて大容量のプレゼンテーション（例えば数ギガバイト）を開く際に BLOB オプションは役立ちますか？**

はい。`BlobManagementOptions` はそのようなシナリオ向けに設計されており、一時ファイルの有効化やソース ロックの使用により、ピーク RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させます。

**ストリームから読み込む場合でも BLOB ポリシーは使用できますか？**

はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（ロックモードに依存）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。