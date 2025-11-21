---
title: よくある質問
type: docs
weight: 340
url: /ja/net/faqs/
keywords:
- よくある質問
- PowerPoint
- プレゼンテーション形式
- メモリ不足エラー
- スライドサイズ
- テキスト抽出
- テキスト取得
- 段落サイズ
- テーブルの書式設定
- フォント
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET に関するFAQの回答を取得できます。PowerPoint と OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングをカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for .NET がサポートするファイル形式は何ですか？**
**A**: Aspose.Slides for .NET は、[Supported File Formats](/slides/ja/net/supported-file-formats/) に記載されているファイル形式をサポートします。

## **例外**

**Q: 画像を含む大きな PPT ファイルの読み込み中に OutOfMemoryException が発生します。Aspose.Slides にはファイルサイズの制限がありますか？**
**A**: Aspose.Slides がサポートするプレゼンテーションサイズを計算する特定の式はありません。プレゼンテーション全体の構造と画像をメモリ上に収めるだけの十分な空き容量が必要です。通常、メモリ上の画像はハードディスク上よりも多くの領域を占有し、特に画像にエフェクトが追加されている場合は顕著です。

一般に、Aspose.Slides for .NET は、4 GB の RAM を搭載したサーバー上で約 300 MB のプレゼンテーションファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドのサイズを変更できますか？**
**A**: [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスが提供する `SlideSize` プロパティを使用して、プレゼンテーション内のスライドのサイズを定義できます。

**Q: プレゼンテーション内でサイズが異なるスライドを定義する方法はありますか？**
**A**: Microsoft PowerPoint のドキュメントではスライドのサイズはプレゼンテーション レベルで定義されるため、これを実現する方法はありません。

**Q: Aspose.Slides for .NET は、保存前にスライドのプレビューをサポートしていますか？**
**A**: プレゼンテーションのスライドを画像にレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得できますか？**
**A**: Aspose.Slides for .NET は、`Aspose.Slides.Util` 名前空間にある [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) クラスを提供しており、プレゼンテーションから全テキストを取得するさまざまなメソッドが用意されています。

**Q: Windows と Linux の OS で段落サイズが異なるのはなぜですか？**
**A**: 段落サイズの計算は、対象段落を表すテキストサイズの計算に基づきます。テキストサイズは、PowerPoint プレゼンテーションで指定されたフォントのメトリックを基に算出されます。指定されたフォントが存在しない場合、最も類似したフォントに置き換えられますが、そのフォントのメトリックは元のものと異なります。そのため、システムごとのインストールフォントのセットに応じて、異なる OS での段落サイズ計算結果が変わります。異なる OS でも同じ結果を得るには、各システムに同じフォントをインストールするか、[external fonts](/slides/ja/net/custom-font/) として実行時に読み込む必要があります。

## **書式設定と画像**

**Q: 表の枠線の色を設定するにはどうすればよいですか？**
**A**: 表全体の枠線またはテーブル全体の外枠だけの色を変更できます。すべての枠線を変更する場合は、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) インターフェイスの `CellFormat` プロパティを使用してください。テーブル全体の外枠を変更するには、セルを列挙し、外側の枠線の色を変更する必要があります。

**Q: Aspose.Slides for .NET は画像の配置にどの単位を使用しますか？**
**A**: スライド上のすべての図形の座標とサイズはポイント単位（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換すると、出力ドキュメントのフォントが異なるのはなぜですか？**
**A**: この問題は、プレゼンテーションで使用されたフォントがコード実行時のオペレーティング システムにインストールされていないことを示している可能性があります。フォントを OS にインストールするか、以下の例のように [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) クラスを使用して外部フォントとして読み込む必要があります。
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
