---
title: Python で PowerPoint プレゼンテーションを XPS に変換
linktitle: PowerPoint から XPS へ
type: docs
weight: 70
url: /ja/python-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PPT を変換
- PPTX を変換
- PowerPoint から XPS へ
- プレゼンテーションを XPS へ
- PPT を XPS へ
- PPTX を XPS へ
- PPT を XPS として保存
- PPTX を XPS として保存
- PPT を XPS にエクスポート
- PPTX を XPS にエクスポート
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、Python で PowerPoint の PPT および PPTX プレゼンテーションを XPS に変換します。既定またはカスタムのエクスポート設定が利用可能です。"
---
## **概要**

Aspose.Slides for Python via Java を使用すると、PowerPoint プレゼンテーションを XPS に変換できます。PPT または PPTX ファイルを XPS 形式で保存することで実現します。本記事では XPS が有用となるケースを説明し、既定設定またはカスタム [XpsOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xpsoptions/) 設定のいずれかを使用してプレゼンテーションをエクスポートする方法を示します。

## **XPS について**

XPS (XML Paper Specification) は、Microsoft が開発した XML ベースのドキュメント形式です。固定ページを記述し、テキストやグラフィックのレイアウトを保持したまま、対応ソフトウェアでの閲覧および印刷を可能にします。

## **Microsoft XPS 形式を使用すべき時**

文書ワークフローで固定レイアウトのファイルが必要で、XPS 対応ツールを介して共有または印刷する場合に XPS を使用します。受信者は XPS をサポートするソフトウェアが必要です。ワークフローで PDF が必要な場合は、[Convert PowerPoint to PDF](/slides/ja/python-java/convert-powerpoint-to-pdf/) を参照してください。

{{% alert color="info" title="Note" %}}
PPT または PPTX プレゼンテーションを XPS に変換してみるには、[free online converter](https://products.aspose.app/slides/ja/conversion) を使用してください。
{{% /alert %}}

| 入力 PowerPoint プレゼンテーション | 出力 XPS ドキュメント |
| --- | --- |
| ![元の PowerPoint プレゼンテーション](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![XPS に変換されたプレゼンテーション](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Aspose.Slides を使用した XPS 変換**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスの [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに [SaveFormat.Xps](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/#Xps) を指定してプレゼンテーションをエクスポートします。既定のエクスポート設定を使用するか、[XpsOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xpsoptions/) を指定して出力をカスタマイズできます。

以下の各例は、必要に応じて Java 仮想マシンを起動し、使用後にプレゼンテーションを解放します。入力ファイル名は PPT または PPTX ファイルへのパスに置き換えてください。

### **デフォルト設定を使用してプレゼンテーションを XPS に変換**

以下の Python コードは、既定設定を使用してプレゼンテーションを XPS に変換します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # プレゼンテーションを XPS ドキュメントとして保存します。
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **カスタム設定を使用してプレゼンテーションを XPS に変換**

以下の例は、[XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) を使用して、メタファイルを PNG 画像として XPS ドキュメントに保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # カスタム XPS 設定でプレゼンテーションを保存します。
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **FAQ**

**XPS をファイルではなくストリームに保存できますか？**

はい。[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドには、Java の出力ストリームを受け取るオーバーロードがあります。Python via Java では、JPype を介して Java のバイト配列出力ストリームなどの互換ストリームを使用し、エクスポートデータをメモリ内に保持できます。

**非表示スライドは XPS 出力に含まれますか？**

非表示スライドは既定で除外されます。含める場合は、保存前に [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides) を `True` に設定してください。

**アニメーションやスライド遷移は XPS に保持されますか？**

保持されません。XPS は固定ページを含むため、エクスポートされたスライドはアニメーションや遷移効果を再生しません。