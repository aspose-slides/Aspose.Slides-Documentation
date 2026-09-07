---
title: Python で ODP を PPTX に変換
linktitle: ODP から PPTX へ
type: docs
weight: 10
url: /ja/python-java/convert-odp-to-pptx/
keywords:
- OpenDocument を変換
- プレゼンテーションを変換
- スライドを変換
- ODP を変換
- OpenDocument から PPTX へ
- ODP から PPTX へ
- ODP を PPTX として保存
- ODP を PPTX にエクスポート
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して ODP プレゼンテーションを PPTX に変換します。PowerPoint や LibreOffice をインストールせずに、完全な Python のサンプルを利用できます。"
---
## **Overview**

このガイドでは、Aspose.Slides for Python via Java を使用して OpenDocument (ODP) プレゼンテーションを PowerPoint (PPTX) 形式に変換する方法を説明します。

## **Convert ODP to PPTX**

[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスは ODP ファイルを直接読み込むことができます。[SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) を使用して、読み込んだプレゼンテーションを PPTX 形式で保存します。

例を実行する前に[インストール手順](/slides/ja/python-java/installation/)に従ってください。作業ディレクトリに `AccessOpenDoc.odp` という名前の ODP プレゼンテーションを配置します。以下のコードは必要に応じて JVM を起動し、ODP ファイルを開いて `AccessOpenDoc_out.pptx` として保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("AccessOpenDoc.odp")
try:
    # ODP プレゼンテーションを PPTX 形式で保存します。
    presentation.save("AccessOpenDoc_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Live Example**

[Aspose.Slides Conversion](https://products.aspose.app/slides/ja/conversion/) ウェブアプリを試して、Aspose.Slides が提供する ODP から PPTX への変換をご確認ください。

## **FAQ**

**Do I need to install Microsoft PowerPoint or LibreOffice to convert ODP to PPTX?**

いいえ。Aspose.Slides for Python via Java は、Microsoft PowerPoint や LibreOffice を使用せずにプレゼンテーション ファイルの読み書きが可能です。必要なのは Python パッケージと互換性のある Java ランタイムだけです。

**Are master slides, layouts, and themes preserved during conversion?**

Aspose.Slides は元のプレゼンテーションの構造と書式設定を PPTX にマッピングします。ただし、ODP と PPTX はサポートする機能が異なるため、変換後に一部の要素が異なる表示になることがあります。必要なフォントを用意し、複雑な書式設定のプレゼンテーションは必ず確認してください。[OpenDocument conversion](/slides/ja/python-java/convert-openoffice-odp/) に互換性の考慮事項が記載されています。

**Can I convert password-protected ODP files?**

はい、ファイルを開くために必要なパスワードを指定すれば変換できます。保護されたファイルを別の形式で保存する手順の詳細は、[password-protected presentations](/slides/ja/python-java/password-protected-presentation/) をご覧ください。

**Is Aspose.Slides suitable for cloud or REST-based conversion services?**

はい。バックエンドで必要な Java ランタイムとともに Aspose.Slides for Python via Java を使用できます。REST API については、[Aspose.Slides Cloud](https://products.aspose.cloud/slides/ja/family/) を参照してください。