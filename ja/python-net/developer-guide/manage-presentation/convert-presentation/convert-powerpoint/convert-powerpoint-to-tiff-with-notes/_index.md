---
title: Python でノート付き PowerPoint プレゼンテーションを TIFF に変換する
linktitle: ノート付き TIFF 変換
type: docs
weight: 100
url: /ja/python-net/convert-powerpoint-to-tiff-with-notes/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を TIFF に
- プレゼンテーションを TIFF に
- スライドを TIFF に
- PPT を TIFF に
- PPTX を TIFF に
- ノート付き PowerPoint
- ノート付きプレゼンテーション
- ノート付きスライド
- ノート付き PPT
- ノート付き PPTX
- ノート付き TIFF
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET を使用して、ノート付き PowerPoint プレゼンテーションを TIFF に変換する方法を学びます。スピーカーノート付きスライドのエクスポートを効率的に行う方法を紹介します。"
---

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料のPowerPointからポスターへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックすることをお勧めします。

{{% /alert %}}

TIFFは、Aspose.Slides for Python via .NETがノート付きのPowerPoint PPTおよびPPTXプレゼンテーションを画像に変換するためにサポートしている広く使用される画像フォーマットの1つです。また、ノートスライドビューでスライドのサムネイルを生成することもできます。Presentationクラスによって公開された[Save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)メソッドを使用して、ノートスライドビューの全体のプレゼンテーションをTIFFに変換できます。Aspose.Slides for Python via .NETを使用してMicrosoft PowerPointプレゼンテーションをTIFFノートに保存するのは、2行のプロセスです。プレゼンテーションを開き、TIFFノートとして保存するだけです。また、各スライドに対してノートスライドビューのサムネイルを生成することもできます。以下のコードスニペットは、サンプルプレゼンテーションをノートスライドビューのTIFF画像に更新します。

```py
import aspose.slides as slides

# プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化
presentation = slides.Presentation("pres.pptx")

# プレゼンテーションをTIFFノートに保存
presentation.save("Notes_In_Tiff_out.tiff", slides.export.SaveFormat.TIFF)
```