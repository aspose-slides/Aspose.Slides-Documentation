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
- テーブル書式設定
- フォント
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET の FAQ の回答を取得できます。PowerPoint と OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングを網羅しています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for .NET がサポートするファイル形式は何ですか？**

**A**: Aspose.Slides for .NET は、[Supported File Formats](/slides/ja/net/supported-file-formats/) に記載されているファイル形式をサポートしています。

## **例外**

**Q: 画像付きの大きな PPT ファイルを読み込む際に OutOfMemoryException が発生します。Aspose.Slides にはファイルサイズに制限がありますか？**

**A**: Aspose.Slides がサポートするプレゼンテーションのサイズを算出する特定の公式はありません。プレゼンテーション全体の構造と画像をメモリに収めるだけの十分な空き領域が必要です。通常、画像はハードディスク上のサイズよりもメモリ上で多くの領域を占有します。特に画像にエフェクトが付加されている場合は顕著です。

一般に、Aspose.Slides for .NET は、4 GB RAM のサーバー上で約 300 MB 程度のプレゼンテーションファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドのサイズを変更できますか？**

**A**: プレゼンテーションのスライドサイズは、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスが提供する `SlideSize` プロパティを使用して定義できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: Microsoft PowerPoint のドキュメントでは、スライドのサイズはプレゼンテーション単位で定義されるため、異なるサイズのスライドを設定することはできません。

**Q: Aspose.Slides for .NET でスライドを保存前にプレビューすることはサポートされていますか？**

**A**: プレゼンテーションのスライドを画像としてレンダリングし、その画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for .NET は、`Aspose.Slides.Util` 名前空間の下にある [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/) クラスを提供しており、プレゼンテーション全体のテキストを取得するさまざまなメソッドが利用できます。

**Q: Windows と Linux のオペレーティングシステムで段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、対象段落を表すテキストサイズの計算に基づいています。テキストサイズの計算は、PowerPoint プレゼンテーションで指定されたフォントのメトリックに基づきます。指定されたフォントが存在しない場合、最も類似したフォントに置き換えられますが、そのフォントは元のフォントとは異なるメトリックを持ちます。その結果、異なるシステム上での段落サイズの計算は、インストールされているフォントセットの違いにより異なる結果となります。同一の結果を得るには、各システムに同じフォントをインストールするか、[external fonts](/slides/ja/net/custom-font/) として実行時にロードする必要があります。

## **書式設定と画像**

**Q: 表の罫線の色を設定するにはどうすればよいですか？**

**A**: 表全体の罫線すべて、または表全体を囲む外枠の罫線の色を変更できます。すべての罫線を変更する場合は、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) インターフェイスの `CellFormat` プロパティを使用してください。表全体の外枠罫線を変更するには、セルを走査して外側の罫線の色を変更する必要があります。

**Q: Aspose.Slides for .NET は画像を配置する際、どの単位で測定しますか？**

**A**: スライド上のすべてのシェイプの座標とサイズはポイント単位（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントがコード実行時のオペレーティングシステムに存在しないことを示している可能性があります。フォントをオペレーティングシステムにインストールするか、以下の例のように [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/) クラスを使用して外部フォントとしてロードしてください。

```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
