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
- プレゼンテーションをロード
- PPTX をロード
- PPT をロード
- ODP をロード
- 保護されたプレゼンテーション
- 大容量プレゼンテーション
- 外部リソース
- バイナリオブジェクト
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを簡単に開くことができます—高速で信頼性が高く、機能が豊富です。"
---

## **概要**

最初から PowerPoint プレゼンテーションを作成するだけでなく、Aspose.Slides は既存のプレゼンテーションのオープンも可能にします。プレゼンテーションをロードした後、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、その他さまざまな操作が行えます。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。

以下の Python サンプルは、プレゼンテーションを開いてスライド数を取得する方法を示しています。
```python
import aspose.slides as slides

# Presentation クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。
with slides.Presentation("sample.pptx") as presentation:
    # プレゼンテーション内のスライド総数を出力します。
    print(presentation.slides.length)
```


## **パスワードで保護されたプレゼンテーションのオープン**

パスワードで保護されたプレゼンテーションを開く必要がある場合、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) プロパティにパスワードを渡して復号し、ロードします。以下の Python コードはこの操作を示しています。
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 復号化されたプレゼンテーションで操作を実行します。
```


## **大容量プレゼンテーションのオープン**

Aspose.Slides は、特に [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) プロパティなどのオプションを提供し、大容量のプレゼンテーションのロードを支援します。

以下の Python コードは、大容量プレゼンテーション（例: 2 GB）をロードする方法を示しています。
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked 動作を選択します — プレゼンテーション ファイルは存続期間中ロックされたままです
# プレゼンテーション インスタンスですが、メモリにロードしたり一時ファイルにコピーしたりする必要はありません。
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 大容量プレゼンテーションがロードされ、使用できます。メモリ使用量は低く抑えられます。

    # プレゼンテーションを変更します。
    presentation.slides[0].name = "Large presentation"

    # プレゼンテーションを別ファイルに保存します。この操作中もメモリ使用量は低く保たれます。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # こうしないでください！プレゼンテーション オブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    os.remove(file_path)

# ここで実行しても問題ありません。ソース ファイルはプレゼンテーション オブジェクトによってロックされていません。
os.remove(file_path)
```


{{% alert color="info" title="情報" %}}
ストリームを使用する際の特定の制限を回避するために、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量のプレゼンテーションをロードすると、プレゼンテーションがコピーされ、ロードが遅くなる可能性があります。したがって、大容量のプレゼンテーションをロードする必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強くお勧めします。

動画、音声、高解像度画像などの大きなオブジェクトを含むプレゼンテーションを作成する場合は、[BLOB management](/slides/ja/python-net/manage-blob/) を使用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。以下の Python コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています。
```python
# [TODO[not_supported_yet]: .NET インターフェイスの Python 実装]
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロード**

PowerPoint プレゼンテーションには、次のタイプの埋め込みバイナリオブジェクトが含まれることがあります。

- VBA プロジェクト ( [Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) でアクセス可能);
- OLE オブジェクト埋め込みデータ ( [OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) でアクセス可能);
- ActiveX コントロールバイナリデータ ( [Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/) でアクセス可能).

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) プロパティを使用すると、埋め込みバイナリオブジェクトなしでプレゼンテーションをロードできます。

このプロパティは、潜在的に悪意のあるバイナリコンテンツを除去するのに有用です。以下の Python コードは、埋め込みバイナリコンテンツなしでプレゼンテーションをロードする方法を示しています。
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # プレゼンテーションに対して操作を実行します。
```


## **よくある質問**

**ファイルが破損していて開けないことはどのように判断できますか？**

ロード時に解析/形式検証例外が発生します。このようなエラーは、無効な ZIP 構造や破損した PowerPoint レコードに言及することが多いです。

**開く際に必要なフォントが見つからない場合はどうなりますか？**

ファイルは開きますが、後で [rendering/export](/slides/ja/python-net/convert-presentation/) 時にフォントが置き換えられる可能性があります。ランタイム環境に [Configure font substitutions](/slides/ja/python-net/font-substitution/) や [add the required fonts](/slides/ja/python-net/custom-font/) を追加してください。

**開く際の埋め込みメディア（動画/音声）はどうなりますか？**

それらはプレゼンテーションリソースとして利用可能になります。メディアが外部パスで参照されている場合は、そのパスが環境でアクセス可能であることを確認してください。そうでないと、[rendering/export](/slides/ja/python-net/convert-presentation/) 時にメディアが省略される可能性があります。