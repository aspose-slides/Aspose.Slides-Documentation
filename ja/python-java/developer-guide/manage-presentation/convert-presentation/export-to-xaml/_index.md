---
title: Python via JavaでプレゼンテーションをXAMLにエクスポート
linktitle: プレゼンテーションを XAML に変換
type: docs
weight: 30
url: /ja/python-java/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PowerPoint から XAML へ
- OpenDocument から XAML へ
- プレゼンテーションから XAML へ
- PPT を XAML に
- PPTX を XAML に
- ODP を XAML に
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを XAML にエクスポートします。既定のオプションを使用するか、非表示スライドを含めることができます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して PowerPoint および OpenDocument プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の概要を紹介し、既定設定でのエクスポート方法を示し、[XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) を使用して非表示スライドを含める方法を実演します。

例を実行するには Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。`pres.pptx` を現在の作業ディレクトリに配置してください。各例は、JVM が起動していない場合にのみ起動します。

## **XAML について**

XAML（Extensible Application Markup Language）は、ユーザーインターフェイスを記述するための XML ベースの言語です。Windows Presentation Foundation（WPF）などのフレームワークで使用されます。ビジュアルデザイナーまたはテキストエディターで XAML を作成・編集できます。

## **既定オプションでプレゼンテーションを XAML にエクスポート**

入力ファイルから [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) を作成し、[XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) を [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) に渡して、既定設定でエクスポートします：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **カスタムオプションでプレゼンテーションを XAML にエクスポート**

[XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) を使用してエクスポートを構成します。非表示スライドを含めるには、保存前に `True` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) を呼び出します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **よくある質問**

**元のフォントが利用できない場合、フォールバックフォントを選択するにはどうすればよいですか？**  
[XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) オブジェクトで [setDefaultRegularFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) を使用してフォールバックフォントを指定します。選択したフォントがエクスポート環境で利用可能であることを確認してください。

**エクスポートされたマークアップを任意の XAML フレームワークで使用できますか？**  
XAML フレームワークは、サポートする要素や機能が異なります。アプリケーションに統合する前に、ターゲットとなるフレームワークでエクスポートされたマークアップをテストしてください。

**非表示スライドは既定でエクスポートされますか？**  
いいえ。含めるには、`True` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) を呼び出します。除外する場合は `False` のままにしてください。