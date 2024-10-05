---
title: ノート付きPowerPointをTIFFに変換する
type: docs
weight: 100
url: /python-net/convert-powerpoint-to-tiff-with-notes/
keywords: "ノート付きPowerPointをTIFFに変換する"
description: "Aspose.Slidesを使用して、ノート付きのPowerPointをTIFFに変換します。"
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