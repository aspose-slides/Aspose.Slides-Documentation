---
title: よくある質問
type: docs
weight: 340
url: /ja/python-net/faq/
keywords:
- よくある質問
- プレゼンテーション形式
- メモリ不足エラー
- スライドサイズ
- テキスト抽出
- テキスト取得
- 段落サイズ
- テーブルの書式設定
- フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET の FAQ に対する回答を取得できます。PowerPoint と OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングについてカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for Python via .NET がサポートするファイル形式は何ですか？**

**A**: Aspose.Slides for Python via .NET は、[Supported File Formats](/slides/ja/python-net/supported-file-formats/) に記載されているファイル形式をサポートしています。

## **例外**

**Q: 画像を含む大きな PPT ファイルの読み込み中にメモリ不足の例外が発生します。Aspose.Slides にファイルサイズの制限はありますか？**

**A**: Aspose.Slides がサポートするプレゼンテーションサイズを計算するための特定の式はありません。プレゼンテーション全体の構造と画像をメモリ内に収めるだけの十分な空き領域が必要です。通常、メモリ上の画像はハードディスク上の画像よりも多くの領域を占有します。特に画像に追加効果がある場合は顕著です。  
一般に、Aspose.Slides for Python via .NET は、4 GB RAM のサーバー上で約 300 MB のプレゼンテーション ファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドサイズを変更できますか？**

**A**: `slide_size` プロパティは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスで公開されており、プレゼンテーション内のスライドサイズを定義できます。

**Q: プレゼンテーション内でサイズが異なるスライドを定義する方法はありますか？**

**A**: スライドのサイズは Microsoft PowerPoint ドキュメントでプレゼンテーションレベルで定義されているため、異なるサイズのスライドを設定する方法はありません。

**Q: Aspose.Slides for Python via .NET は、保存前にスライドのプレビューをサポートしていますか？**

**A**: プレゼンテーションのスライドを画像にレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得できますか？**

**A**: Aspose.Slides for Python via .NET は、`aspose.slides.util` 名前空間の下にある [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスを提供しており、プレゼンテーションから全文テキストを取得するためのさまざまなメソッドが用意されています。

**Q: Windows と Linux のオペレーティングシステムで段落のサイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、対象段落を表すテキストサイズの計算に基づいています。テキストサイズの算出は、PowerPoint プレゼンテーションで指定されたフォントのメトリックに依存します。指定されたフォントが存在しない場合、最も類似したフォントに置き換えられますが、このフォントのメトリックは元のフォントとは異なります。そのため、インストールされているフォントのセットが異なるシステム間では、段落サイズの計算結果も異なることになります。同じ結果を得るには、各システムに同一のフォントをインストールするか、[external fonts](/slides/ja/python-net/custom-font/) として実行時にロードする必要があります。

## **フォーマットと画像**

**Q: テーブルの枠線の色を設定するにはどうすればよいですか？**

**A**: テーブルのすべての枠線またはテーブル全体の外枠だけの色を変更できます。すべての枠線を変更する場合は、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラスの `cell_format` プロパティをご利用ください。テーブル全体の外枠を変更するには、セルを走査し外側の枠線の色を変更する必要があります。

**Q: Aspose.Slides for Python via .NET は、画像の配置にどの単位を使用しますか？**

**A**: スライド上のすべてのシェイプの座標とサイズは、ポイント (72 dpi) 単位で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されたフォントがコード実行時のオペレーティングシステムにインストールされていないことを示している可能性があります。フォントをオペレーティングシステムにインストールするか、以下のように [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスを使用して外部フォントとしてロードすべきです。

```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
