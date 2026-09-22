---
title: Python via Javaでプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/python-java/open-presentation/
keywords:
- PowerPoint を開く
- プレゼンテーションを開く
- PPTX を開く
- PPT を開く
- ODP を開く
- プレゼンテーションを読み込む
- PPTX を読み込む
- PPT を読み込む
- ODP を読み込む
- 保護されたプレゼンテーション
- 大規模プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Java
- Aspose.Slides
description: "Python via JavaでPowerPointおよびOpenDocumentプレゼンテーションを開く方法、開く際のパスワードを設定する方法、リソース読み込みを制御する方法、そしてAspose.Slides for Python via Javaを使用してメモリ使用量を削減する方法を学びます。"
---
## **はじめに**

[Aspose.Slides for Python via Java](https://products.aspose.com/slides/ja/python-java/) は、ファイルやストリームから PowerPoint および OpenDocument プレゼンテーションを読み込むことができます。プレゼンテーションが読み込まれた後は、その構造を調べたり、スライドを編集したり、リソースを管理したり、元の形式や他のサポートされている形式で保存したりできます。

読み込み動作は [LoadOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/) クラスでカスタマイズできます。たとえば、開く際のパスワードを指定したり、大きなバイナリオブジェクトを Java ヒープメモリの外に保持したり、外部リソースを制御したり、埋め込みバイナリデータを省略したりできます。

## **プレゼンテーションのオープン**

ファイルまたはストリームを読み込んだ後、[元のプレゼンテーション形式を判別](/slides/ja/python-java/detect-presentation-source-format/) して、アプリケーションでの処理方法を選択できます。

既存のプレゼンテーションを開くには、そのファイルパスを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクターに渡します。使用後はプレゼンテーションを破棄し、ファイルハンドルや一時データ、その他のリソースが速やかに解放されるようにしてください。

以下の Python サンプルは、プレゼンテーションを開いてスライド数を取得する方法を示しています。

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

## **パスワードで保護されたプレゼンテーションのオープン**

開く際のパスワードはプレゼンテーションの内容を暗号化します。完全なプレゼンテーションを読み込むには、正しいパスワードを [LoadOptions.setPassword](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setPassword) に渡し、そのオプションを [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) コンストラクターに提供します。パスワードが無い、または誤っている場合は読み込みに失敗します。

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

パスワードの検出、検証、暗号化ワークフローについては、[Password-Protect Presentations](/slides/ja/python-java/password-protected-presentation/) を参照してください。暗号化されたプレゼンテーションが意図的に公開ドキュメントプロパティと共に保存されている場合、パスワードなしでそのプロパティを読み取ることができます。詳細は [Manage Presentation Properties](/slides/ja/python-java/presentation-properties/) をご覧ください。

## **大規模プレゼンテーションのオープン**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#getBlobManagementOptions) は、画像、音声、動画などのバイナリラージオブジェクト（BLOB）の扱いを制御するオプションを返します。ソースファイルをロックしたままにしたり、一時ファイルの使用を許可したり、メモリに保持する BLOB データ量を制限したりできます。

以下の Python コードは、大規模プレゼンテーション（例: 2 GB）を読み込む方法を示しています。

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
[PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentationlockingbehavior/#KeepLocked) を使用すると、プレゼンテーションインスタンスが破棄されるまでソースファイルがロックされたままになります。そのインスタンスが存続している間は、ソースファイルを移動、上書き、削除しないでください。

Aspose.Slides は読み込み時に入力ストリームの内容をコピーすることがあります。大規模プレゼンテーションの場合、ストリームよりもファイルパスを使用した方が一般的に効率的です。追加のストレージおよびメモリ管理オプションについては、[Manage BLOBs](/slides/ja/python-java/manage-blob/) を参照してください。
{{% /alert %}}

## **外部リソースの制御**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setResourceLoadingCallback) は、Java のリソース読み込みコールバックインターフェイスを実装した JPype プロキシを受け取ります。このコールバックは置換データを提供したり、リソースのリダイレクトを行ったり、デフォルトローダーを使用したり、リソースをスキップしたりできます。プレゼンテーションに外部画像が含まれ、アプリケーション固有のセキュリティやストレージルールに従って解決する必要がある場合に有用です。

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

## **埋め込みバイナリオブジェクトなしでプレゼンテーションを読み込む**

プレゼンテーションには、アプリケーションが不要または保持したくない埋め込みバイナリデータが含まれることがあります。例としては次のようなものがあります。

- VBA プロジェクト（[Presentation.getVbaProject](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getVbaProject) で取得可能）
- 埋め込み OLE データ（[OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/ja/python-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData) で取得可能）
- ActiveX コントロールデータ（[Control.getActiveXControlBinary](https://reference.aspose.com/slides/ja/python-java/aspose.slides/control/#getActiveXControlBinary) で取得可能）

[LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/ja/python-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) を `True` に設定すると、読み込み時にこれらのバイナリデータが削除されます。読み込んだプレゼンテーションを保存すれば、サニタイズされた結果が永続化されます。

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

**ファイルが破損していて開けないことをどうやって判断できますか？**

Aspose.Slides は読み込み中にパースエラーまたは形式例外をスローします。パスワードが間違っているエラーとは別にこの失敗をハンドリングし、原因を正確に報告できるようにしてください。

**必要なフォントが欠如している場合はどうなりますか？**

プレゼンテーションは依然として読み込まれますが、レンダリングやエクスポート時にフォントが置き換えられる可能性があります。出力を予測可能にするために、[フォント置換の構成](/slides/ja/python-java/font-substitution/) または [カスタムフォントの提供](/slides/ja/python-java/custom-font/) を行ってください。

**プレゼンテーションを読み込むと、埋め込みメディアも読み込まれますか？**

埋め込みされた音声や動画はプレゼンテーションオブジェクトモデルを通じて利用可能になります。外部リソースは構成されたリソース読み込み動作に従って解決され、場所にアクセスできない場合は利用できません。