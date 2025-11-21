---
title: Python でプレゼンテーションの BLOB を管理し、効率的なメモリ使用を実現
linktitle: BLOB 管理
type: docs
weight: 10
url: /ja/python-net/manage-blob/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET における BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化して、プレゼンテーションの取り扱いを最適化します。"
---

## **BLOB について**

**BLOB** (**Binary Large Object**) は通常、バイナリ形式で保存される大きな項目（写真、プレゼンテーション、文書、またはメディア）です。 

Aspose.Slides for Python via .NET を使用すると、大きなファイルが関与する場合にメモリ使用量を削減する方法でオブジェクトに BLOB を使用できます。 

## **BLOB を使用してメモリ使用量を削減する**

### **BLOB を介して大きなファイルをプレゼンテーションに追加する**

[Aspose.Slides](/slides/ja/python-net/) for .NET を使用すると、BLOB を介したプロセスで大きなファイル（この場合は大きなビデオ ファイル）を追加し、メモリ使用量を削減できます。

この Python の例では、BLOB プロセスを使用して大きなビデオ ファイルをプレゼンテーションに追加する方法を示します：
```py
import aspose.slides as slides

pathToVeryLargeVideo = "veryLargeVideo.avi"

# 動画を追加する新しいプレゼンテーションを作成します
with slides.Presentation() as pres:
    with open(pathToVeryLargeVideo, "br") as fileStream:
        # 動画をプレゼンテーションに追加します - KeepLocked 動作を選択したのは
        # 「veryLargeVideo.avi」ファイルにアクセスするつもりがないためです。
        video = pres.videos.add_video(fileStream, slides.LoadingStreamBehavior.KEEP_LOCKED)
        pres.slides[0].shapes.add_video_frame(0, 0, 480, 270, video)

        # プレゼンテーションを保存します。大きなプレゼンテーションが出力される間、メモリ消費は
        # pres オブジェクトのライフサイクル全体で低く保たれます 
        pres.save("presentationWithLargeVideo.pptx", slides.export.SaveFormat.PPTX)
```



### **BLOB を介してプレゼンテーションから大きなファイルをエクスポートする**
Aspose.Slides for Python via .NET を使用すると、BLOB を介したプロセスでプレゼンテーションから大きなファイル（この場合はオーディオまたはビデオ ファイル）をエクスポートできます。たとえば、プレゼンテーションから大きなメディア ファイルを抽出する必要があるが、そのファイルをコンピュータのメモリに読み込ませたくない場合です。BLOB プロセスを通じてファイルをエクスポートすることで、メモリ使用量を低く抑えることができます。 

以下の Python コードは、上記の操作を実演しています：
```py
import aspose.slides as slides

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
loadOptions.blob_management_options.is_temporary_files_allowed = True

with slides.Presentation(path + "Video.pptx", loadOptions) as pres:
	# 各ビデオをファイルに保存します。メモリ使用量が高くなるのを防ぐため、バッファが必要です
	# プレゼンテーションのビデオストリームから新しく作成したビデオファイル用のストリームへデータを転送します
	# byte[] buffer = new byte[8 * 1024];
    bufferSize = 8 * 1024

	# ビデオを反復処理します
    index = 0
    # 必要に応じて、同じ手順をオーディオファイルにも適用できます 
    for video in pres.videos:
		# プレゼンテーションのビデオストリームを開きます。意図的にプロパティへのアクセスを避けたことに注意してください
		# video.BinaryData のようなプロパティは、完全なビデオを含むバイト配列を返すため、
		# メモリにバイトがロードされます。video.GetStream を使用すると、Stream が返され、 
		#  メモリにビデオ全体をロードする必要はありません
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
インターフェイス [**IImageCollection**](https://reference.aspose.com/slides/python-net/aspose.slides/iimagecollection/) とクラス [**ImageCollection** ](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/) のメソッドを使用すると、大きな画像をストリームとして追加し、BLOB として扱うことができます。 

この Python コードは、BLOB プロセスを介して大きな画像を追加する方法を示しています：
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

通常、大規模なプレゼンテーションをロードするには、コンピュータに大量の一時メモリが必要です。プレゼンテーションのすべての内容がメモリに読み込まれ、プレゼンテーションがロードされた元のファイルは使用されなくなります。 

たとえば、1.5 GB のビデオ ファイルを含む大規模な PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。プレゼンテーションをロードする標準的な方法は、以下の Python コードで説明されています：
```py
import aspose.slides as slides

with slides.Presentation("large.pptx") as pres:
	pres.save("large.pdf", slides.export.SaveFormat.PDF)
```


しかし、この方法は約 1.6 GB の一時メモリを消費します。 

### **BLOB として大規模プレゼンテーションをロードする**
BLOB を使用したプロセスにより、少量のメモリで大規模なプレゼンテーションをロードできます。この Python コードは、BLOB プロセスを使用して大規模プレゼンテーション ファイル（large.pptx）をロードする実装を示しています：
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
BLOB プロセスを使用すると、コンピュータは既定の一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、`temp_files_root_path` を使用して保存設定を変更できます：
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

## **よくある質問**

**Aspose.Slides のプレゼンテーション内でどのデータが BLOB とみなされ、BLOB オプションで制御されますか？**
画像、音声、ビデオなどの大きなバイナリ オブジェクトは BLOB として扱われます。プレゼンテーション全体のファイルも、ロードまたは保存時に BLOB の取り扱いが行われます。これらのオブジェクトは BLOB ポリシーにより管理され、メモリ使用量を制御し、必要に応じて一時ファイルにスピルできるようになります。

**プレゼンテーションのロード時に BLOB の取り扱いルールはどこで設定しますか？**
[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) を使用します。ここで BLOB のメモリ上限を設定し、一時ファイルの使用許可・不許可、一次ファイルのルート パス、ソース ロック動作を選択できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**
はい。BLOB をメモリに保持すると速度は最大化されますが、RAM 使用量が増加します。メモリ上限を下げると、作業の多くが一時ファイルにオフロードされ、RAM は削減されますが追加の I/O が発生します。ワークロードと環境に合わせて、[max_blobs_bytes_in_memory](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/max_blobs_bytes_in_memory/) の閾値を調整し、適切なバランスを取ってください。

**極めて大きなプレゼンテーション（例：数ギガバイト）を開く際に BLOB オプションは役立ちますか？**
はい。[BlobManagementOptions](https://reference.aspose.com/slides/python-net/aspose.slides/blobmanagementoptions/) はこのようなシナリオ向けに設計されています。一時ファイルを有効にし、ソース ロックを使用することで、ピーク時の RAM 使用量を大幅に削減し、非常に大きなデッキの処理を安定させることができます。

**ディスク ファイルではなくストリームからロードする際にも BLOB ポリシーを使用できますか？**
はい。同じルールがストリームにも適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（選択したロック モードに依存）、許可されている場合は一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。