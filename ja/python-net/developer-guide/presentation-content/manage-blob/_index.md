---
title: Python でプレゼンテーションの BLOB を管理し、効率的なメモリ使用を実現
linktitle: BLOB の管理
type: docs
weight: 10
url: /ja/python-net/manage-blob/
keywords:
- 大容量オブジェクト
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
description: "Aspose.Slides for Python via .NET で BLOB データを管理し、PowerPoint および OpenDocument ファイルの操作を効率化して、プレゼンテーション処理を最適化します。"
---
## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存される大きなアイテム（写真、プレゼンテーション、ドキュメント、メディア）です。

Aspose.Slides for Python via .NET を使用すると、BLOB をオブジェクトに利用でき、大容量ファイルを扱う際のメモリ使用量を削減できます。

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB 経由で大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/python-net/) for .NET は、BLOB を利用したプロセスにより大きなファイル（ここでは大容量ビデオファイル）を追加し、メモリ使用量を抑えることができます。

この Python のサンプルは、BLOB プロセスを通じて大きなビデオファイルをプレゼンテーションに追加する方法を示しています：

```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# ビデオが追加される新しいプレゼンテーションを作成します
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # ビデオをプレゼンテーションに追加します - KeepLocked 動作を選択したのは、
        # "veryLargeVideo.avi" ファイルにアクセスするつもりがないためです。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # プレゼンテーションを保存します。大きなプレゼンテーションが出力されても、
        # pres オブジェクトのライフサイクルを通じてメモリ消費は低く保たれます。
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```


### **プレゼンテーションから BLOB 経由で大きなファイルをエクスポートする**
Aspose.Slides for Python via .NET は、BLOB を利用したプロセスにより、プレゼンテーションから大きなファイル（例：音声またはビデオ）をエクスポートできます。たとえば、プレゼンテーションから大容量メディアファイルを抽出したいが、メモリに読み込むのは避けたい場合です。BLOB プロセスでエクスポートすれば、メモリ使用量を低く抑えられます。

以下の Python コードが上記操作を実演します：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 各ビデオをファイルに保存します。メモリ使用量の増加を防ぐために、バッファが必要です
	# プレゼンテーションのビデオストリームから新規作成したビデオファイル用ストリームへデータを転送します
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# ビデオを列挙します
    index = 0
    # 必要に応じて、オーディオ ファイルにも同じ手順を適用できます。 
    for video in pres.videos:
		# プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを避けたことに注意してください
		# video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
		# メモリにバイトがロードされます。そのため video.GetStream を使用し、Stream を返すようにし、メモリに全体をロードする必要はありません
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
[**ImageCollection**](https://reference.aspose.com/slides/ja/python-net/aspose.slides/imagecollection/) クラスのメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱うことができます。

この Python コードは、BLOB プロセスを通じて大きな画像を追加する方法を示しています：

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

通常、大きなプレゼンテーションをロードする際には、多くの一時メモリが必要です。プレゼンテーションのすべてのコンテンツがメモリに読み込まれ、元のファイルは使用されなくなります。

たとえば、1.5 GB のビデオファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的なロード方法は次の Python コードで示されています：

```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

しかし、この方法では約 1.6 GB の一時メモリを消費します。

### **BLOB として大きなプレゼンテーションをロードする**

BLOB プロセスを使用すれば、ほとんどメモリを使用せずに大きなプレゼンテーションをロードできます。この Python コードは、BLOB プロセスを用いて large.pptx をロードする実装例です：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation("large.pptx", loadOptions) as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```

### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、コンピューターは既定の一時フォルダーに一時ファイルを作成します。別のフォルダーに保存したい場合は、`temp_files_root_path` を使用して保存先を変更できます：

```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True
loadOptions.blob_management_options.temp_files_root_path = "temp"
```

{{% alert title="情報" color="info" %}}
`temp_files_root_path` を使用する場合、Aspose.Slides は一時ファイル用フォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **プレゼンテーションオブジェクトを破棄してメモリを解放する**

大規模プレゼンテーションを処理する際は、`Presentation` インスタンスを適切に破棄し、占有していたメモリを解放してください。推奨される方法は、上記の例で示したようにコンテキストマネージャ（`with slides.Presentation(...) as presentation:`）を使用することです。ブロックを抜けたときに自動的にプレゼンテーションが閉じられ、アンマネージドリソースが解放されます。

`with` ブロックを使用せずにプレゼンテーションを作成した場合は、使用後に明示的に `presentation.dispose()` を呼び出し、残りの参照を削除して Python のガベージコレクタがメモリを回収できるようにしてください。

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

画像、音声、ビデオなどの大きなバイナリオブジェクトが BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB 処理が関与します。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルにスピルできる BLOB ポリシーによって制御されます。

**プレゼンテーションのロード時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のインメモリ上限を設定したり、一時ファイルの使用可否、ルートパス、ソースロック動作を選択できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

影響します。BLOB をメモリに保持すると速度は最大化されますが RAM 使用量が増えます。メモリ上限を下げると、処理がより多く一時ファイルにオフロードされ、RAM は減りますが I/O が増加します。ワークロードと環境に合わせて [max_blobs_bytes_in_memory](https://reference.aspose.com/slides/ja/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) の閾値を調整し、最適なバランスを見つけてください。

**非常に大きなプレゼンテーション（数ギガバイト）を開く際に BLOB 設定は役立ちますか？**

役立ちます。[BlobManagementOptions](https://reference.aspose.com/slides/ja/python-net/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルの有効化やソースロックの使用により、ピーク時の RAM 使用量を大幅に削減し、安定した処理を実現します。

**ストリームからロードする場合でも BLOB ポリシーは使用できますか？**

使用できます。ストリームにも同じルールが適用され、プレゼンテーションインスタンスは入力ストリームを所有およびロック（ロックモードに応じて）でき、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。