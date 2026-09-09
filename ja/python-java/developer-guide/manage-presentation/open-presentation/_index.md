---
title: "Java 経由の Python でプレゼンテーションを開く"
linktitle: "プレゼンテーションを開く"
type: docs
weight: 20
url: /ja/python-java/open-presentation/
keywords:
- "PowerPoint を開く"
- "プレゼンテーションを開く"
- "PPTX を開く"
- "PPT を開く"
- "ODP を開く"
- "プレゼンテーションを読み込む"
- "PPTX を読み込む"
- "PPT を読み込む"
- "ODP を読み込む"
- "保護されたプレゼンテーション"
- "大容量プレゼンテーション"
- "外部リソース"
- "バイナリオブジェクト"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Python (via Java) で PowerPoint および OpenDocument のプレゼンテーションを開く方法、開く際のパスワードの指定、リソース読み込みの制御、そして Aspose.Slides for Python via Java を使用したメモリ使用量の削減方法を学びます。"
---
## **Introduction**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ja/python-java/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションを読み込んだ後、その構造を検査したり、スライドを編集したり、リソースを管理したり、元の形式または他のサポートされている形式で保存したりできます。

読み込み動作は、[LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) クラスを使ってカスタマイズできます。たとえば、開くパスワードを指定したり、大きなバイナリオブジェクトを Java ヒープメモリの外部に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **Open Presentations**

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクタに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドル、テンポラリデータ、その他のリソースが速やかに解放されるようにしてください。

以下の Python の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Open Password-Protected Presentations**

開くパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setPassword) に渡し、オプションを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクタに提供します。パスワードがない、または正しくない場合、読み込みは失敗します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-presentation.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

パスワードの検出、検証、暗号化ワークフローについては、[Password‑Protect Presentations](/slides/ja/python-java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティとともに保存されている場合、それらのプロパティはパスワードなしで読み取ることができます。詳細は [Manage Presentation Properties](/slides/ja/python-java/presentation-properties/) をご覧ください。

## **Open Large Presentations**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) は、画像、音声、動画などのバイナリ大容量オブジェクト（BLOB）を Aspose.Slides がどのように扱うかを制御するオプションを返します。ソースファイルをロックしたままにしたり、テンポラリファイルを許可したり、メモリに保持する BLOB データ量を制限したりできます。

以下の Python コードは、大容量プレゼンテーション（例: 2 GB）を読み込む方法を示しています：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationLockingBehavior, SaveFormat

file_path = "large-presentation.pptx"

load_options = LoadOptions()
load_options.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked)
load_options.getBlobManagementOptions().setTemporaryFilesAllowed(True)
load_options.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024)

presentation = Presentation(file_path, load_options)
try:
    presentation.getSlides().get_Item(0).setName("Large presentation")
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーションインスタンスが破棄されるまでソースファイルはロックされたままになります。そのインスタンスが存在する間は、ソースファイルを移動、上書き、または削除しないでください。

Aspose.Slides は読み込み中に入力ストリームの内容をコピーすることがあります。大容量プレゼンテーションの場合、ファイルパスの方が通常ストリームよりも効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/python-java/manage-blob/) を参照してください。
{{% /alert %}}

## **Control External Resources**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) は、Java のリソース読み込みコールバックインターフェイスを実装した JPype プロキシを受け入れます。コールバックは置換データを提供したり、リソースをリダイレクトしたり、デフォルトローダーを使用したり、リソースをスキップしたりできます。これは、プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティやストレージポリシーに従って解決する必要がある場合に有用です。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadOptions, Presentation, ResourceLoadingAction

class ImageLoadingHandler:
    def resourceLoading(self, resource_loading_arguments):
        is_jpeg = str(resource_loading_arguments.getOriginalUri()).lower().endswith(".jpg")
        approved_image_path = Path("approved-image.jpg")
        if not is_jpeg or not approved_image_path.exists():
            return ResourceLoadingAction.Skip

        try:
            image_data = approved_image_path.read_bytes()
            java_image_data = jpype.JArray(jpype.JByte)(image_data)
            resource_loading_arguments.setData(java_image_data)
            return ResourceLoadingAction.UserProvided
        except OSError:
            print("The approved replacement image could not be read.")
            return ResourceLoadingAction.Skip

load_options = LoadOptions()
image_loading_handler = ImageLoadingHandler()
callback = jpype.JProxy("com.aspose.slides.IResourceLoadingCallback", inst=image_loading_handler)
load_options.setResourceLoadingCallback(callback)

presentation = Presentation("presentation-with-external-images.pptx", load_options)
try:
    print("Slide count:", presentation.getSlides().size())
finally:
    presentation.dispose()
```

## **Load Presentations without Embedded Binary Objects**

プレゼンテーションには、アプリケーションが必要としない、あるいは保持したくない埋め込みバイナリデータが含まれていることがあります。例としては、

- VBA プロジェクトは [Presentation.getVbaProject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getVbaProject) で取得できます;
- 埋め込み OLE データは [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) で取得できます;
- ActiveX コントロールデータは [Control.getActiveXControlBinary](https://reference.aspose.com/slides/ja/python-java/aspose.slides/control/#getActiveXControlBinary) で取得できます。

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) を `True` に設定すると、読み込み時にこれらのバイナリデータが削除されます。サニタイズされた結果を保持するには、読み込んだプレゼンテーションを保存してください。

このオプションは不要な埋め込みペイロードへの露出を減らしますが、完全なマルウェア検出やコンテンツサニタイズシステムではありません。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setDeleteEmbeddedBinaryObjects(True)

presentation = Presentation("presentation-with-embedded-data.pptx", load_options)
try:
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**ファイルが破損していて開けないことをどのように判断できますか？**

Aspose.Slides は読み込み時に解析エラーまたは形式エラーの例外をスローします。この失敗をパスワードが間違っているエラーとは別に処理し、アプリケーションが原因を正確に報告できるようにしてください。

**必要なフォントが欠落している場合はどうなりますか？**

プレゼンテーションは依然として読み込めますが、レンダリングやエクスポート時にフォントが置き換えられることがあります。出力をより予測可能にするために、[configure font substitution](/slides/ja/python-java/font-substitution/) または [provide custom fonts](/slides/ja/python-java/custom-font/) を利用できます。

**プレゼンテーションの読み込みは埋め込みメディアも読み込むのでしょうか？**

埋め込みの音声および動画はプレゼンテーションのオブジェクトモデルを通じて利用可能になります。外部リソースは設定されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できないことがあります。