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
description: "Aspose.Slides for Python via .NET を使用して、PowerPoint（.pptx、.ppt）および OpenDocument（.odp）プレゼンテーションを簡単に開くことができます—高速、信頼性が高く、フル機能。"
---

## **概要**

PowerPoint プレゼンテーションを最初から作成するだけでなく、Aspose.Slides は既存のプレゼンテーションを開くこともできます。プレゼンテーションを読み込んだ後は、その情報を取得したり、スライドの内容を編集したり、新しいスライドを追加したり、既存のスライドを削除したり、さまざまな操作が可能です。

## **プレゼンテーションのオープン**

既存のプレゼンテーションを開くには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスのインスタンスを作成し、コンストラクタにファイルパスを渡します。

次の Python の例は、プレゼンテーションを開いてスライド数を取得する方法を示しています。
```python
import aspose.slides as slides

# Presentation クラスをインスタンス化し、コンストラクタにファイルパスを渡します。
with slides.Presentation("sample.pptx") as presentation:
    # プレゼンテーション内のスライド総数を出力します。
    print(presentation.slides.length)
```


## **パスワード保護されたプレゼンテーションのオープン**

パスワード保護されたプレゼンテーションを開く必要がある場合は、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [password](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/password/) プロパティにパスワードを指定して復号し、ロードします。次の Python コードがこの操作を示しています。
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "YOUR_PASSWORD"

with slides.Presentation("sample.pptx", load_options) as presentation:
    # 復号化されたプレゼンテーションで操作を実行します。
```


## **大容量プレゼンテーションのオープン**

Aspose.Slides は、大容量プレゼンテーションのロードを支援するオプション、特に [LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/) クラスの [blob_management_options](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/blob_management_options/) プロパティを提供しています。

次の Python コードは、大容量プレゼンテーション（例: 2 GB）をロードする方法を示しています。
```python
import aspose.slides as slides
import os

file_path = "LargePresentation.pptx"

load_options = slides.LoadOptions()
# KeepLocked 動作を選択します—プレゼンテーションファイルは存続期間中ロックされたままです
# Presentation インスタンスですが、メモリにロードしたり一時ファイルにコピーする必要はありません。
load_options.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED
load_options.blob_management_options.is_temporary_files_allowed = True
load_options.blob_management_options.max_blobs_bytes_in_memory = 10 * 1024 * 1024  # 10 MB

with slides.Presentation(file_path, load_options) as presentation:
    # 大容量プレゼンテーションがロードされ、使用可能です。メモリ使用量は低く抑えられます。

    # プレゼンテーションを変更します。
    presentation.slides[0].name = "Large presentation"

    # プレゼンテーションを別ファイルに保存します。この操作中もメモリ使用量は低く抑えられます。
    presentation.save("LargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # これを実行しないでください！プレゼンテーションオブジェクトが破棄されるまでファイルがロックされているため、I/O 例外がスローされます。
    os.remove(file_path)

# ここで実行しても問題ありません。ソースファイルはプレゼンテーションオブジェクトによってロックされていません。
os.remove(file_path)
```


{{% alert color="info" title="Info" %}}
ストリームを使用する際の特定の制限を回避するため、Aspose.Slides はストリームの内容をコピーすることがあります。ストリームから大容量プレゼンテーションをロードすると、プレゼンテーションがコピーされ、ロードが遅くなる可能性があります。したがって、大容量プレゼンテーションをロードする必要がある場合は、ストリームではなくプレゼンテーションのファイルパスを使用することを強く推奨します。

動画、音声、高解像度画像などの大きなオブジェクトを含むプレゼンテーションを作成する場合は、[BLOB 管理](/slides/ja/python-net/manage-blob/) を利用してメモリ使用量を削減できます。
{{%/alert %}}

## **外部リソースの制御**

Aspose.Slides は、外部リソースを管理できる [IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/) インターフェイスを提供します。次の Python コードは、`IResourceLoadingCallback` インターフェイスの使用方法を示しています。
```python
# [TODO[not_supported_yet]: Python による .NET インターフェイスの実装]
```


## **埋め込みバイナリオブジェクトなしでプレゼンテーションをロード**

PowerPoint プレゼンテーションには、以下のタイプの埋め込みバイナリオブジェクトが含まれる可能性があります。

- VBA プロジェクト（[Presentation.vba_project](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/vba_project/) でアクセス可能）;
- OLE オブジェクトの埋め込みデータ（[OleEmbeddedDataInfo.embedded_file_data](https://reference.aspose.com/slides/python-net/aspose.slides/ioleembeddeddatainfo/embedded_file_data/) でアクセス可能）;
- ActiveX コントロールのバイナリデータ（[Control.active_x_control_binary](https://reference.aspose.com/slides/python-net/aspose.slides/control/active_x_control_binary/) でアクセス可能）。

[LoadOptions.delete_embedded_binary_objects](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/delete_embedded_binary_objects/) プロパティを使用すると、埋め込みバイナリオブジェクトを含まないプレゼンテーションをロードできます。

このプロパティは、潜在的に危険なバイナリコンテンツを除去する際に便利です。次の Python コードは、埋め込みバイナリコンテンツなしでプレゼンテーションをロードする方法を示しています。
```py
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.delete_embedded_binary_objects = True

with slides.Presentation("malware.ppt", load_options) as presentation:
    # プレゼンテーションで操作を実行します。
```


## **FAQ**

**ファイルが破損していて開けないことをどう判断できますか？**

ロード時にパース/フォーマット検証例外が発生します。エラーには、無効な ZIP 構造や破損した PowerPoint レコードが含まれることが多いです。

**開く際に必須フォントが欠落している場合はどうなりますか？**

ファイルは開きますが、後の[レンダリング/エクスポート](/slides/ja/python-net/convert-presentation/)でフォントが置き換えられる可能性があります。[フォント置き換えの構成](/slides/ja/python-net/font-substitution/)または[必須フォントの追加](/slides/ja/python-net/custom-font/)をランタイム環境に行ってください。

**開く際の埋め込みメディア（動画/音声）はどう扱われますか？**

メディアはプレゼンテーションリソースとして利用可能になります。メディアが外部パスで参照されている場合、そのパスが環境内でアクセス可能であることを確認してください。そうでないと、[レンダリング/エクスポート](/slides/ja/python-net/convert-presentation/)でメディアが省かれることがあります。