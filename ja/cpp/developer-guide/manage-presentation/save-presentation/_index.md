---
title: プレゼンテーションの保存 - C++ PowerPointライブラリ
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/cpp/save-presentation/
description: C++ PowerPoint APIまたはライブラリを使用すると、プレゼンテーションをファイルまたはストリームに保存できます。ゼロからプレゼンテーションを作成するか、既存のものを修正できます。
---

{{% alert title="情報" color="info" %}}

プレゼンテーションを開く方法やロードする方法については、[*プレゼンテーションのオープン*](https://docs.aspose.com/slides/cpp/open-presentation/)の記事を参照してください。

{{% /alert %}}

この記事では、プレゼンテーションを保存する方法について説明します。

[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)クラスは、プレゼンテーションの内容を保持します。ゼロからプレゼンテーションを作成するか、既存のものを修正した場合、完了したらプレゼンテーションを保存したいと思います。Aspose.Slides for C++を使用すると、プレゼンテーションを**ファイル**または**ストリーム**として保存できます。この記事では、さまざまな方法でプレゼンテーションを保存する方法を説明します。

## **ファイルへのプレゼンテーションの保存**
**Presentation**クラスの[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドを呼び出すことで、プレゼンテーションをファイルに保存します。ファイル名と保存形式を[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドに渡すだけです。以下の例は、Aspose.Slides for C++を使用してプレゼンテーションを保存する方法を示しています。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **ストリームへのプレゼンテーションの保存**
出力ストリームを[Presentation]()クラスのSaveメソッドに渡すことで、プレゼンテーションをストリームに保存することが可能です。プレゼンテーションを保存できるストリームの種類は多くあります。以下の例では、新しいプレゼンテーションファイルを作成し、形状にテキストを追加し、プレゼンテーションをストリームに保存します。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}


## **事前定義されたビュータイプを使用したプレゼンテーションの保存**
Aspose.Slides for C++は、PowerPointで開くときに生成されたプレゼンテーションのビュータイプを設定するための機能を提供します。この機能は、[ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties)クラスを通じて使用します。[LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index)プロパティは、[ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype)列挙体を使用してビュータイプを設定するために使用されます。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **厳密なOffice Open XML形式でのプレゼンテーションの保存**
Aspose.Slidesは、プレゼンテーションを厳密なOffice Open XML形式で保存することを許可します。この目的のために、プレゼンテーションファイルを保存する際にConformanceプロパティを設定することができる**PptxOptions**クラスを提供します。値を**Conformance.Iso29500_2008_Strict**に設定すると、出力プレゼンテーションファイルは厳密なOffice Open XML形式で保存されます。

以下のサンプルコードは、プレゼンテーションを作成し、厳密なOffice Open XML形式で保存します。プレゼンテーションのSaveメソッドを呼び出す際、**PptxOptions**オブジェクトがConformanceプロパティを**Conformance.Iso29500_2008_Strict**に設定して渡されます。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}


## **パーセンテージでの進捗更新の保存**
新しい**IProgressCallback**インターフェースが**ISaveOptions**インターフェースおよび**SaveOptions**抽象クラスに追加されました。**IProgressCallback**インターフェースは、パーセンテージでの保存進捗更新のためのコールバックオブジェクトを表します。

以下のコードスニペットは、IProgressCallbackインターフェースの使用方法を示しています。

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="情報" color="info" %}}

Asposeは独自のAPIを使用して、ユーザーがプレゼンテーションを複数のファイルに分割できる[無料のPowerPointスプリッターアプリ](https://products.aspose.app/slides/splitter)を開発しました。本質的に、このアプリは、指定されたプレゼンテーションから選択したスライドを新しいPowerPoint（PPTXまたはPPT）ファイルとして保存します。

{{% /alert %}}