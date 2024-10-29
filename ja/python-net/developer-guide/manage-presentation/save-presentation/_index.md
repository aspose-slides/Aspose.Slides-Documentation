---
title: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/python-net/save-presentation/
keywords: "PowerPointの保存, PPT, PPTX, プレゼンテーションの保存, ファイル, ストリーム, Python"
description: "PythonでPowerPointプレゼンテーションをファイルまたはストリームとして保存"
---

## **プレゼンテーションの保存**
プレゼンテーションを開く方法は、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスを使用してプレゼンテーションを開く方法について説明しています。この記事では、プレゼンテーションを作成し、保存する方法について説明します。
[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスは、プレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成する場合でも、既存のプレゼンテーションを変更する場合でも、完了したらプレゼンテーションを保存したいと思います。Aspose.Slides for Python via .NETを使用すると、プレゼンテーションを**ファイル**または**ストリーム**として保存できます。この記事では、プレゼンテーションを異なる方法で保存する方法を説明します。

### **ファイルへのプレゼンテーションの保存**
[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスの[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを呼び出すことで、プレゼンテーションをファイルに保存します。ファイル名と保存形式を[save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドに渡すだけです。以下の例は、Pythonを使用してAspose.Slides for Python via .NETでプレゼンテーションを保存する方法を示しています。

```py
import aspose.slides as slides

# PPTファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation() as presentation:
    
    #...ここで作業を行う...

    # プレゼンテーションをファイルに保存
    presentation.save("Saved_out.pptx", slides.export.SaveFormat.PPTX)
```


### **ストリームへのプレゼンテーションの保存**
出力ストリームを[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスのSaveメソッドに渡すことで、プレゼンテーションをストリームに保存することが可能です。プレゼンテーションを保存できるストリームの種類は多くあります。以下の例では、新しいプレゼンテーションファイルを作成し、シェイプにテキストを追加し、プレゼンテーションをストリームに保存しています。

```py
import aspose.slides as slides

# PPTファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation() as presentation:
    
    shape = presentation.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 200, 200)

    # プレゼンテーションをストリームに保存
    with open("Save_As_Stream_out.pptx", "bw") as stream:
        presentation.save(stream, slides.export.SaveFormat.PPTX)
```


### **事前定義された表示タイプでのプレゼンテーションの保存**
Aspose.Slides for Python via .NETは、生成されたプレゼンテーションがPowerPointで開かれるときに表示タイプを設定する機能を提供します。[view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/)クラスを通じて実現されます。[last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/)プロパティは、[ViewType](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/)列挙体を使用して表示タイプを設定するために使用されます。

```py
import aspose.slides as slides

# PPTファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation() as presentation:
    
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("pres-will-open-SlideMasterView.pptx", slides.export.SaveFormat.PPTX)

```

### **厳格なOffice Open XML形式でのプレゼンテーションの保存**
Aspose.Slidesでは、プレゼンテーションを厳格なOffice Open XML形式で保存することができます。そのために、プレゼンテーションファイルを保存する際にConformanceプロパティを設定できる[**PptxOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)クラスを提供します。これをConformance.Iso29500_2008_Strictに設定すると、出力プレゼンテーションファイルは厳格なOffice Open XML形式で保存されます。

以下のサンプルコードは、プレゼンテーションを作成し、厳格なOffice Open XML形式で保存します。プレゼンテーションのSaveメソッドを呼び出す際に、**[PptxOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)**オブジェクトを渡し、[**Conformance**](https://reference.aspose.com/slides/python-net/aspose.slides.export/pptxoptions/)プロパティを[**Conformance.Iso29500_2008_Strict**](https://reference.aspose.com/slides/python-net/aspose.slides.export/conformance/)に設定します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
with slides.Presentation() as presentation:
    # 最初のスライドを取得
    slide = presentation.slides[0]

    # ライン型のオートシェイプを追加
    slide.shapes.add_auto_shape(slides.ShapeType.LINE, 50, 150, 300, 0)

    options = slides.export.PptxOptions()
    options.conformance = slides.export.Conformance.ISO29500_2008_STRICT

    # 厳格なOffice Open XML形式でプレゼンテーションを保存
    presentation.save("NewPresentation_out.pptx", slides.export.SaveFormat.PPTX, options)

```


### **進捗更新のパーセンテージでの保存**
新しい[**IProgressCallback**](https://reference.aspose.com/slides/python-net/aspose.slides/iprogresscallback/)インターフェイスが[**ISaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/isaveoptions/)インターフェイスおよび[**SaveOptions**](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/)抽象クラスに追加されました。**IProgressCallback**インターフェイスは、パーセンテージでの保存進捗更新のためのコールバックオブジェクトを表します。

以下のコードスニペットは、IProgressCallbackインターフェイスの使用方法を示しています。

```py
# [TODO[not_supported_yet]: python implementation of .net interfaces]
```

{{% alert title="情報" color="info" %}}

Asposeは独自のAPIを使用して、ユーザーがプレゼンテーションを複数のファイルに分割できる[無料のPowerPoint Splitterアプリ](https://products.aspose.app/slides/splitter)を開発しました。基本的に、このアプリは与えられたプレゼンテーションから選択したスライドを新しいPowerPoint（PPTXまたはPPT）ファイルとして保存します。

{{% /alert %}}