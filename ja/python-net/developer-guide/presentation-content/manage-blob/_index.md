---
title: Python を使用したプレゼンテーションの BLOB 管理による効率的なメモリ使用
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/python-net/manage-blob/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET における BLOB データの管理により、PowerPoint および OpenDocument ファイルの操作を効率化し、プレゼンテーションの取り扱いを最適化します。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内の大きなバイナリ データを BLOB ベースで処理し、大きな画像、音声、動画、プレゼンテーション ファイルを扱う際のメモリ使用量を削減することができます。  
この記事では、BLOB ベースの処理を使用してプレゼンテーションに大容量メディアを追加したり、プレゼンテーションから大容量メディアをエクスポートしたり、大規模なプレゼンテーションをより効率的に読み込む方法を示します。また、処理中に一時ファイルを使用する方法と、保存先フォルダーを変更する方法についても説明します。

## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存された大容量の項目（写真、プレゼンテーション、ドキュメント、メディアなど）を指します。  

Aspose.Slides for Python via .NET を使用すると、大容量ファイルを扱う際にメモリ使用量を削減する形でオブジェクトに BLOB を利用できます。

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を介して大容量ファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/python-net/) for .NET を使用すると、BLOB を利用した処理により大容量ファイル（この例では大きなビデオ ファイル）をプレゼンテーションに追加し、メモリ使用量を削減できます。  

以下の Python の例では、BLOB プロセスを使用して大容量ビデオ ファイルをプレゼンテーションに追加する方法を示します。

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ビデオが追加される新しいプレゼンテーションを作成します
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # ビデオをプレゼンテーションに追加します - KeepLocked 動作を選択したのは
        # 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # プレゼンテーションを保存します。大きなプレゼンテーションが出力されても、
        # pres オブジェクトのライフサイクル全体でメモリ消費は低く保たれます 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```

### **BLOB を介してプレゼンテーションから大容量ファイルをエクスポートする**

Aspose.Slides for Python via .NET を使用すると、BLOB を利用した処理によりプレゼンテーションから大容量ファイル（この例では音声または動画ファイル）をエクスポートできます。たとえば、プレゼンテーションから大容量メディア ファイルを抽出したいが、ファイルをコンピューターのメモリに読み込ませたくない場合があります。BLOB プロセスを通じてファイルをエクスポートすれば、メモリ使用量を抑えることができます。  

以下の Python コードは、上記の操作を実演しています。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 各ビデオをファイルに保存します。メモリ使用量の増加を防ぐために、バッファが必要です
	# プレゼンテーションのビデオ ストリームから新しく作成したビデオ ファイル用のストリームへデータを転送するために使用されます。
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# ビデオを列挙します
    index = 0
    # 必要に応じて、オーディオ ファイルにも同じ手順を適用できます。 
    for video in pres.videos:
		# プレゼンテーションのビデオ ストリームを開きます。意図的にプロパティへのアクセスを回避したことに注意してください。
		# video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
		# メモリにバイトがロードされます。video.GetStream を使用すると、Stream が返され、 
		#  メモリにビデオ全体をロードする必要はありません。
        with video.get_stream() as presVideoStream:
            with open("video{index}.avi".format(index = index), "wb") as outputFileStream:
                buffer = presVideoStream.read(8 * 1024)
                bytesRead = len(buffer)
                while bytesRead > 0:
                    outputFileStream.write(buffer)
                    buffer = presVideoStream.read(8 * 1024)
                    bytesRead = len(buffer)
                    
        index += 1
```

### **プレゼンテーションに画像を BLOB として追加する**

[**ImageCollection**](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) クラスのメソッドを使用すると、大容量画像をストリームとして追加し、BLOB として扱うことができます。  

以下の Python コードは、BLOB プロセスを使用して大容量画像を追加する方法を示します。

```py
import aspose.slides as slides

# 画像が追加される新しいプレゼンテーションを作成します。
with slides.Presentation() as pres:
    with open("img.jpeg", "br") as fileStream:
        img = pres.images.add_image(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 0, 0, 300, 200, img)
    pres.save("presentationWithLargeImage.pptx", slides.export.SaveFormat.PPTX)
```

## **メモリと大規模プレゼンテーション**

通常、大規模なプレゼンテーションを読み込むには、コンピューターは大量の一時メモリを必要とします。プレゼンテーションのすべてのコンテンツがメモリにロードされ、ロード元のファイルは使用されなくなります。  

たとえば、1.5 GB のビデオ ファイルを含む大規模 PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。プレゼンテーションを読み込む標準的な方法は、以下の Python コードで示されています。

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

しかし、この方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大規模プレゼンテーションを読み込む**

BLOB を利用した処理により、少ないメモリで大規模プレゼンテーションを読み込むことができます。以下の Python コードは、BLOB プロセスを使用して大規模プレゼンテーション ファイル（large.pptx）を読み込む実装例です。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **一時ファイルのフォルダーを変更する**

BLOB プロセスを使用すると、コンピューターはデフォルトの一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`temp_files_root_path` を使用して保存先設定を変更できます。

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="Info" color="info" %}}
`temp_files_root_path` を使用すると、Aspose.Slides は一時ファイルを保存するフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **Presentation オブジェクトを破棄してメモリを解放する**

大規模なプレゼンテーションを処理する場合、[Presentation](https://reference.aspose.com/slides/ja/python-net/aspose.slides/presentation/) インスタンスが適切に破棄され、占有していたメモリが解放されるようにしてください。推奨される方法は、上記の例にあるようにコンテキストマネージャ（`with slides.Presentation(...) as presentation:`）を使用することです。ブロックを抜けると自動的にプレゼンテーションが閉じられ、アンマネージド リソースが解放されます。  

`with` ブロックを使用せずにプレゼンテーションを作成した場合は、使用後に明示的に `presentation.dispose()` を呼び出し、残っている参照をすべて削除して Python のガベージコレクタがメモリを回収できるようにしてください。

```py
import aspose.slides as slides

presentation = slides.Presentation("large.pptx")

# ...プレゼンテーションを処理...
presentation.save("large.pdf", slides.export.SaveFormat.PDF)

# 明示的にリソースを解放します。
presentation.dispose()
```

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**  
画像、音声、動画などの大容量バイナリ オブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、読み込みや保存時に BLOB 処理が行われます。これらのオブジェクトは BLOB ポリシーに従い、メモリ使用量を管理し、必要に応じて一時ファイルにスピル（転送）できるようになっています。

**プレゼンテーションの読み込み時に BLOB 処理ルールを設定する場所はどこですか？**  
[LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ内上限を設定したり、一時ファイルの使用可否を指定したり、一時ファイルのルートパスを選択したり、ソースロックの動作を選択したりできます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**  
はい。BLOB をメモリ内に保持すると速度は最大化されますが、RAM の使用量が増加します。メモリ上限を下げると、より多くの処理が一時ファイルにオフロードされ、RAM の使用は減りますが I/O が増加します。ワークロードと環境に合わせて、[max_blobs_bytes_in_memory](https://reference.aspose.com/slides/ja/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) の閾値を調整し、適切なバランスを取ってください。

**非常に大容量のプレゼンテーション（例：ギガバイト単位）を開く際に、BLOB オプションは役立ちますか？**  
はい。[BlobManagementOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/blobmanagementoptions/) はこのようなシナリオ向けに設計されています。 一時ファイルを有効にし、ソースロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させることができます。

**ディスクファイルではなくストリームから読み込む場合でも、BLOB ポリシーを使用できますか？**  
はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは、選択したロックモードに応じて入力ストリームを所有およびロックでき、許可されている場合は一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。