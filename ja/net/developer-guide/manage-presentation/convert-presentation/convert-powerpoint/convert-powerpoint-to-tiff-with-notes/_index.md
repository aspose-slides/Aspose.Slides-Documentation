---
title: ノート付きPowerPointをTIFFに変換
type: docs
weight: 100
url: /net/convert-powerpoint-to-tiff-with-notes/
keywords: "ノート付きPowerPointをTIFFに変換"
description: "Aspose.Slidesを使用してノート付きPowerPointをTIFFに変換します。"
---

{{% alert title="ヒント" color="primary" %}}

Asposeの[無料PowerPointからポスターへの変換ツール](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online)をチェックしてみてください。

{{% /alert %}}

TIFFは、Aspose.Slides for .NETがノート付きのPowerPoint PPTおよびPPTXプレゼンテーションを画像に変換するためにサポートしている広く使用されている画像フォーマットの1つです。また、ノートスライド表示でスライドのサムネイルを生成することもできます。[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index)メソッドはPresentationクラスによって公開されており、ノートスライド表示でプレゼンテーション全体をTIFFに変換するために使用できます。Microsoft PowerPointプレゼンテーションをAspose.Slides for .NETを使用してTIFFノートに保存するプロセスは2行です。プレゼンテーションを開き、TIFFノートとして保存するだけです。また、個々のスライドに対してノートスライド表示でスライドのサムネイルを生成することもできます。以下のコードスニペットは、ノートスライド表示でTIFF画像に更新されたサンプルプレゼンテーションを示しています：

```c#
// プレゼンテーションファイルを表すPresentationオブジェクトをインスタンス化します
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
    // プレゼンテーションをTIFFノートとして保存します
    presentation.Save("Notes_In_Tiff_out.tiff", SaveFormat.Tiff);
}
```