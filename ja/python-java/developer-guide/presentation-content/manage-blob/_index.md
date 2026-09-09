---
title: "Python via Java でプレゼンテーション BLOB を管理し、効率的なメモリ使用を実現"
linktitle: "BLOB の管理"
type: docs
weight: 10
url: /ja/python-java/manage-blob/
keywords:
- "大規模オブジェクト"
- "大規模項目"
- "大きなファイル"
- "BLOB の追加"
- "BLOB のエクスポート"
- "画像を BLOB として追加"
- "メモリ削減"
- "メモリ消費"
- "大規模プレゼンテーション"
- "一時ファイル"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Python via Java 用 Aspose.Slides で BLOB データを管理し、PowerPoint および OpenDocument ファイル操作を効率化して、プレゼンテーションの取り扱いを最適化します。"
---
## **概要**

Aspose.Slides は、プレゼンテーション内の大容量バイナリ データを BLOB ベースで処理し、大きな画像、音声、動画、プレゼンテーション ファイルを扱う際のメモリ使用量を削減します。

本記事では、BLOB ベースの処理を使用してプレゼンテーションに大容量メディアを追加する方法、プレゼンテーションから大容量メディアをエクスポートする方法、そして大きなプレゼンテーションをより効率的に読み込む方法を説明します。また、処理中に一時ファイルを使用する方法と、保存フォルダーを変更する方法についても解説します。

## **BLOB について**

**BLOB**（**Binary Large Object**）は、通常、バイナリ形式で保存された大容量の項目（写真、プレゼンテーション、ドキュメント、メディアなど）を指します。

Aspose.Slides for Python via Java は、大容量ファイルを扱う際のメモリ消費を抑えるために、オブジェクトに対して BLOB を使用できるようにします。

{{% alert color="info" title="Note" %}}
ストリームとのやり取りで特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量のプレゼンテーションをロードすると、プレゼンテーションの内容がコピーされ、ロードが遅くなります。したがって、大容量のプレゼンテーションをロードする場合は、ストリームではなくプレゼンテーション ファイル パスを使用することを強く推奨します。
{{% /alert %}}

## **BLOB を使用してメモリ消費を削減する**

### **BLOB を使用してプレゼンテーションに大容量ファイルを追加する**

[Aspose.Slides](/slides/ja/python-java/) for Python via Java は、BLOB を利用したプロセスで大容量ファイル（ここでは大きな動画ファイル）を追加し、メモリ消費を抑えることができます。

以下の Python コードは、BLOB プロセスを通じて大容量動画ファイルをプレゼンテーションに追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat
from java.io import FileInputStream

path_to_very_large_video = "veryLargeVideo.avi"

# ビデオを追加する新しいプレゼンテーションを作成します。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_very_large_video)
    try:
        # ビデオファイルにアクセスしないため、ストリームをロックしたままにします。
        video = presentation.getVideos().addVideo(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video)

        # メモリ消費を抑えたままプレゼンテーションを保存します。
        presentation.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

### **BLOB を使用してプレゼンテーションから大容量ファイルをエクスポートする**

Aspose.Slides for Python via Java は、BLOB を利用したプロセスでプレゼンテーションから大容量ファイル（音声または動画ファイル）をエクスポートできます。たとえば、プレゼンテーションから大容量メディア ファイルを抽出したいが、ファイルをコンピューターのメモリに読み込みたくない場合があります。BLOB プロセスでエクスポートすれば、メモリ使用量を低く抑えることができます。

以下の Python コードは、上記の操作を実演しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior

huge_presentation_file = "LargeVideoFileTest.pptx"

load_options = LoadOptions()
# メモリにロードする代わりに、ソース ファイルをロックします。
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)

presentation = Presentation(huge_presentation_file, load_options)
try:
    # バッファを介して動画データを転送し、メモリ消費を抑えます。
    buffer = jpype.JArray(jpype.JByte)(8 * 1024)

    for index in range(presentation.getVideos().size()):
        video = presentation.getVideos().get_Item(index)

        # 動画全体をバイト配列にロードする代わりに、ストリームを使用します。
        video_stream = video.getStream()
        try:
            with open(f"video{index}.avi", "wb") as output_stream:
                bytes_read = video_stream.read(buffer, 0, len(buffer))
                while bytes_read > 0:
                    chunk = bytes(buffer[:bytes_read])
                    output_stream.write(chunk)
                    bytes_read = video_stream.read(buffer, 0, len(buffer))
        finally:
            video_stream.close()
    # 必要に応じて、オーディオ ファイルにも同じ手順を適用します。
finally:
    presentation.dispose()
```

### **画像を BLOB としてプレゼンテーションに追加する**

[ImageCollection](https://reference.aspose.com/slides/ja/python-java/aspose.slides/imagecollection/) クラスのメソッドを使用すると、ストリームとして大容量画像を追加し、BLOB として扱うことができます。

以下の Python コードは、BLOB プロセスを通じて大容量画像を追加する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadingStreamBehavior, Presentation, SaveFormat, ShapeType
from java.io import FileInputStream

path_to_large_image = "large_image.jpg"

# 画像を追加する新しいプレゼンテーションを作成します。
presentation = Presentation()
try:
    file_stream = FileInputStream(path_to_large_image)
    try:
        # 画像ファイルにアクセスしないため、ストリームをロックしたままにします。
        image = presentation.getImages().addImage(file_stream, LoadingStreamBehavior.KeepLocked)
        presentation.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, image)

        # メモリ消費を抑えたままプレゼンテーションを保存します。
        presentation.save("presentationWithLargeImage.pptx", SaveFormat.Pptx)
    finally:
        file_stream.close()
finally:
    presentation.dispose()
```

## **メモリと大容量プレゼンテーション**

通常、大容量プレゼンテーションをロードするには、多くの一時メモリが必要です。プレゼンテーション全体の内容がメモリに読み込まれ、ロード元のファイルは使用されなくなります。

たとえば、1.5 GB の動画ファイルを含む大きな PowerPoint プレゼンテーション（large.pptx）を考えてみましょう。標準的なロード方法は、以下の Python コードで示されています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

しかし、この方法では約 1.6 GB の一時メモリが消費されます。

### **BLOB として大容量プレゼンテーションをロードする**

BLOB 処理を使用すれば、少ないメモリで大容量プレゼンテーションをロードできます。以下の Python コードは、BLOB 処理を使用して large.pptx をロードする方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)

presentation = Presentation("large.pptx", load_options)
try:
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

### **一時ファイル用フォルダーを変更する**

BLOB プロセスを使用すると、コンピューターは既定の一時ファイル フォルダーに一時ファイルを作成します。別のフォルダーに一時ファイルを保存したい場合は、[BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) を使用して保存先を変更できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, PresentationLockingBehavior

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setTempFilesRootPath("temp")
```

{{% alert color="info" title="Note" %}}
[BlobManagementOptions.setTempFilesRootPath](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/#setTempFilesRootPath) を使用すると、Aspose.Slides は一時ファイル用のフォルダーを自動的に作成しません。フォルダーは手動で作成する必要があります。
{{% /alert %}}

### **Presentation オブジェクトを破棄してメモリを解放する**

大容量プレゼンテーションを処理する際は、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスを適切に破棄し、占有していたメモリを解放してください。プレゼンテーションの使用が終わったら [Presentation.dispose](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#dispose) を呼び出して、アンマネージド リソースを解放します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("large.pptx")
try:
    # ...プレゼンテーションを処理する...
    presentation.save("large.pdf", SaveFormat.Pdf)
finally:
    # リソースを明示的に解放します。
    presentation.dispose()
```

## **FAQ**

**Aspose.Slides のプレゼンテーションで BLOB として扱われ、BLOB オプションで制御されるデータは何ですか？**

画像、音声、動画などの大容量バイナリ オブジェクトが BLOB として扱われます。プレゼンテーション ファイル全体も、ロードまたは保存時に BLOB 処理が関与します。これらのオブジェクトは、メモリ使用量を管理し、必要に応じて一時ファイルにスピルするための BLOB ポリシーによって制御されます。

**プレゼンテーションのロード時に BLOB 処理ルールはどこで設定しますか？**

[LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) と [BlobManagementOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/) を組み合わせて使用します。ここで BLOB のメモリ内上限を設定し、一時ファイルの許可/不許可、ルート パス、ソース ロック動作などを指定できます。

**BLOB 設定はパフォーマンスに影響しますか？速度とメモリのバランスはどう取りますか？**

はい。BLOB をメモリに保持すれば速度は最大化しますが RAM 消費が増加します。メモリ上限を下げれば、作業の多くが一時ファイルにオフロードされ、RAM は削減されますが I/O が増加します。ワークロードと環境に適したバランスを取るために、[setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory) メソッドを使用してください。

**極めて大きなプレゼンテーション（数ギガバイト規模）を開く際に BLOB オプションは役立ちますか？**

はい。[BlobManagementOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/blobmanagementoptions/) はそのようなシナリオ向けに設計されており、一時ファイルを有効化し、ソース ロックを使用することで、ピーク RAM 使用量を大幅に削減し、非常に大きなスライド デッキの処理を安定させます。

**ストリームから読み込む場合でも BLOB ポリシーは使用できますか？**

はい。ストリームにも同じルールが適用されます。プレゼンテーション インスタンスは入力ストリームを所有およびロックでき（ロックモードによります）、許可されていれば一時ファイルが使用され、処理中のメモリ使用量を予測可能に保ちます。