---
title: プレゼンテーションを開く
type: docs
weight: 20
url: /python-net/open-presentation/
keywords: "Open PowerPoint, PPTX, PPT, プレゼンテーションを開く, プレゼンテーションを読み込む, Python"
description: "PythonでプレゼンテーションPPT、PPTX、ODPを開くまたは読み込む"
---

ゼロからPowerPointプレゼンテーションを作成することに加えて、Aspose.Slidesを使用すると、既存のプレゼンテーションを開くことができます。プレゼンテーションを読み込むと、その情報を取得したり、プレゼンテーションを編集したり（スライドの内容）、新しいスライドを追加したり、既存のスライドを削除したりすることができます。

## プレゼンテーションを開く

既存のプレゼンテーションを開くには、単に[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスをインスタンス化し、（開きたいプレゼンテーションの）ファイルパスをコンストラクタに渡します。

このPythonコードは、プレゼンテーションを開き、含まれているスライドの数を取得する方法を示しています：

```python
import aspose.slides as slides

# Presentationクラスをインスタンス化し、ファイルパスをコンストラクタに渡す
with slides.Presentation("pres.pptx") as pres:
    # プレゼンテーションに存在する総スライド数を出力
    print(pres.slides.length)
```

## **パスワード保護されたプレゼンテーションを開く**

パスワード保護されたプレゼンテーションを開く必要がある場合は、`password`プロパティ（[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)クラスから）を介してパスワードを渡し、プレゼンテーションを復号化して読み込むことができます。このPythonコードは、その操作を示しています：

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "PASSWORD"
with slides.Presentation("pres.pptx", load_options) as pres:
    ...
```

## 大きなプレゼンテーションを開く

Aspose.Slidesは、[LoadOptions](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/)クラスの下で、大きなプレゼンテーションを読み込むためのオプション（特に`blob_management_options`プロパティ）を提供します。

このPythonコードは、大きなプレゼンテーション（例えば2GBのサイズ）を読み込む操作を示します：

```python
import aspose.slides as slides
import os

loadOptions = slides.LoadOptions()
loadOptions.blob_management_options = slides.BlobManagementOptions()
loadOptions.blob_management_options.presentation_locking_behavior = slides.PresentationLockingBehavior.KEEP_LOCKED

with slides.Presentation("pres.pptx", loadOptions) as pres:
    # 大きなプレゼンテーションが読み込まれ、使用可能ですが、メモリ消費は依然として低いです。

    # プレゼンテーションに変更を加える。
    pres.slides[0].name = "非常に大きなプレゼンテーション"

    # プレゼンテーションは別のファイルに保存されます。操作中のメモリ消費は低いままです。
    pres.save("veryLargePresentation-copy.pptx", slides.export.SaveFormat.PPTX)

    # それはできません！ファイルがロックされているためIO例外が発生します。
    os.remove("pres.pptx")

# ここでそれをするのは問題ありません。ソースファイルはpresオブジェクトによってロックされていません。
os.remove("pres.pptx")
```

{{% alert color="info" title="情報" %}}

ストリームとやり取りするときに特定の制限を回避するために、Aspose.Slidesはストリームの内容をコピーする場合があります。ストリームを介して大きなプレゼンテーションを読み込むと、プレゼンテーションの内容がコピーされ、読み込みが遅くなります。したがって、大きなプレゼンテーションを読み込む場合は、プレゼンテーションファイルのパスを使用し、ストリームは使用しないことを強くお勧めします。

大きなオブジェクト（ビデオ、オーディオ、大きな画像など）を含むプレゼンテーションを作成する場合、[Blob機能](https://docs.aspose.com/slides/python-net/manage-blob/)を使用してメモリ消費を削減できます。

{{%/alert %}} 

## プレゼンテーションを読み込む

Aspose.Slidesは、外部リソースを管理できる単一のメソッドを持つ[IResourceLoadingCallback](https://reference.aspose.com/slides/python-net/aspose.slides/iresourceloadingcallback/)を提供します。このPythonコードは、`IResourceLoadingCallback`インターフェースを使用する方法を示しています：

```python
# [TODO[not_supported_yet]: .netインターフェースのpython実装]
```

<h2>プレゼンテーションを開いて保存する</h2>

<a name="python-net-open-save-presentation"><strong>手順：Pythonでプレゼンテーションを開いて保存する</strong></a>

1. [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのインスタンスを作成し、開きたいファイルを渡します。
2. プレゼンテーションを保存します。

```python
import aspose.slides as slides

# PPTファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation() as presentation:
    
    #...ここでいくつかの作業を行います...

    # プレゼンテーションをファイルに保存
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```