---
title: Python でプレゼンテーションを開く
linktitle: プレゼンテーションを開く
type: docs
weight: 20
url: /ja/python-net/open-presentation/
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
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint (.pptx、.ppt) および OpenDocument (.odp) プレゼンテーションを手軽に開く—高速で信頼性が高く、機能が充実しています。"
---

## **概要**

PowerPoint プレゼンテーションをゼロから作成するだけでなく、Aspose.Slides では既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、さまざまな操作が可能です。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスをインスタンス化し、コンストラクターにファイルパスを渡します。

次の Python の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています:
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、コンストラクタにファイルパスを渡す。
with slides.Presentation("sample.pptx") as presentation:
    # プレゼンテーション内のスライド総数を出力する。
    print(presentation.slides.length)
```


## **パスワード保護されたプレゼンテーションのオープン**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) プロパティにパスワードを指定して復号し、読み込みます。以下の Python コードがこの操作を示しています:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 復号化されたプレゼンテーションで操作を実行します。
```


## **大容量プレゼンテーションのオープン**

Aspose.Slides は、大容量プレゼンテーションの読み込みを支援するオプションを提供します。特に、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) プロパティが使用できます。

次の Python コードは、たとえば 2 GB の大容量プレゼンテーションを読み込む方法を示しています:
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked 動作を選択します—プレゼンテーション ファイルは Presentation インスタンスの存続期間中ロックされたままになります
# ただし、メモリに読み込む必要も、一時ファイルにコピーする必要もありません。
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 大容量プレゼンテーションが読み込まれ、使用可能です。メモリ使用量は低く抑えられます。

    # プレゼンテーションを変更します。
    presentation.slides[0].name = "Large presentation"

    # プレゼンテーションを別ファイルに保存します。この操作中もメモリ使用量は低く保たれます。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # これを行わないでください！プレゼンテーションオブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    os.remove(file_path)

# ここで実行しても問題ありません。ソースファイルはプレゼンテーションオブジェクトによるロックが解除されています。
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際の特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーする場合があります。ストリームから大容量プレゼンテーションを読み込むと、プレゼンテーションがコピーされ、読み込みが遅くなる可能性があります。そのため、大容量プレゼンテーションを読み込む必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

大きなオブジェクト（動画、音声、高解像度画像など）を含むプレゼンテーションを作成する際は、[BLOB 管理](/slides/ja/python-net/manage-blob/) を利用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。次の Python コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています:
```python
# [TODO[not_supported_yet]: .NET インターフェイスの Python 実装]
```


## **埋め込みバイナリ オブジェクトなしでプレゼンテーションを読み込む**

PowerPoint プレゼンテーションには、次の種類の埋め込みバイナリ オブジェクトが含まれることがあります。

- VBA プロジェクト（[Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) からアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) からアクセス可能）;
- ActiveX コントロールのバイナリ データ（[Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/) からアクセス可能）。

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) プロパティを使用すると、埋め込みバイナリ オブジェクトを含まない状態でプレゼンテーションを読み込むことができます。

このプロパティは、潜在的に悪意のあるバイナリ コンテンツを除去するのに有用です。次の Python コードは、埋め込みバイナリ コンテンツなしでプレゼンテーションを読み込む方法を示しています:
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # プレゼンテーションに対して操作を行います。
```


## **FAQ**

**ファイルが破損していて開けないことはどのように判断できますか？**

読み込み時にパース/フォーマット検証例外がスローされます。このエラーは、無効な ZIP 構造や破損した PowerPoint レコードに言及することが多いです。

**開く際に必要なフォントが欠落している場合はどうなりますか？**

ファイルは開きますが、後の[レンダリング/エクスポート](/slides/ja/python-net/convert-presentation/)時にフォントが代替される可能性があります。ランタイム環境に[フォント代替の設定](/slides/ja/python-net/font-substitution/)を行うか、[必要なフォントを追加](/slides/ja/python-net/custom-font/)してください。

**開く際の埋め込みメディア（動画/音声）はどう扱われますか？**

メディアはプレゼンテーション リソースとして利用可能になります。メディアが外部パスで参照されている場合、そのパスが環境でアクセス可能であることを確認してください。そうでないと、[レンダリング/エクスポート](/slides/ja/python-net/convert-presentation/)でメディアが省略される可能性があります。