---
title: よくある質問
type: docs
weight: 340
url: /ja/python-net/faq/
keywords:
- FAQ
- PowerPoint
- プレゼンテーション形式
- メモリ不足エラー
- スライドサイズ
- テキスト抽出
- テキスト取得
- 段落サイズ
- テーブルの書式設定
- フォント
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET に関する FAQ の回答を取得できます。PowerPoint および OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングについてカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for Python via .NET がサポートしているファイル形式は何ですか？**

**A**: Aspose.Slides for Python via .NET は、[Supported File Formats](/slides/ja/python-net/supported-file-formats/) に記載されているファイル形式をサポートしています。

## **例外**

**Q: 画像が含まれる大きな PPT ファイルを読み込む際にメモリ不足例外が発生します。Aspose.Slides にファイルサイズの制限はありますか？**

**A**: Aspose.Slides がサポートするプレゼンテーションサイズを計算する特定の式はありません。プレゼンテーション全体の構造と画像をメモリ上に収めるだけの十分な空き容量が必要です。通常、メモリ上の画像はハードディスク上の画像よりも多くの領域を占有し、特に画像に追加効果がある場合は顕著です。

一般的に、Aspose.Slides for Python via .NET は、4 GB RAM のサーバー上で約 300 MB のプレゼンテーションファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドサイズを変更できますか？**

**A**: プレゼンテーションのスライドサイズは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが提供する `slide_size` プロパティを使用して定義できます。

**Q: プレゼンテーション内でサイズが異なるスライドを定義する方法はありますか？**

**A**: スライドのサイズは Microsoft PowerPoint のドキュメントではプレゼンテーションレベルで定義されるため、異なるサイズのスライドを設定する方法はありません。

**Q: Aspose.Slides for Python via .NET は、保存前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションのスライドを画像にレンダリングし、その画像を使ってスライドをプレビューすることができます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for Python via .NET は、`aspose.slides.util` 名前空間にある [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスを提供しており、プレゼンテーション全体のテキストを取得するさまざまなメソッドが用意されています。

**Q: Windows と Linux のオペレーティングシステムで段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、対象の段落を表すテキストサイズの計算に基づいています。テキストサイズの算出は、PowerPoint プレゼンテーションで指定されたフォントのメトリクスに依存します。指定されたフォントが存在しない場合、最も類似したフォントで置き換えられますが、そのフォントは元のフォントとメトリクスが異なります。そのため、システムごとにインストールされているフォントセットが異なると、段落サイズの計算結果も異なります。異なる OS で同じ結果を得るには、各システムに同一のフォントをインストールするか、実行時に [external fonts](/slides/ja/python-net/custom-font/) としてロードする必要があります。

## **書式設定と画像**

**Q: テーブルの境界線の色を設定するにはどうすればよいですか？**

**A**: テーブル全体の境界線の色、またはテーブル全体を囲む外枠の色を変更できます。すべての境界線を変更する場合は、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラスの `cell_format` プロパティを使用してください。テーブル全体の外枠を変更するには、セルを列挙して外側の境界線の色を変更する必要があります。

**Q: Aspose.Slides for Python via .NET は、画像の配置にどの単位を使用しますか？**

**A**: スライド上のすべてのシェイプの座標とサイズは、ポイント（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントがコード実行時のオペレーティングシステムにインストールされていないことを示している可能性があります。フォントを OS にインストールするか、以下の例のように [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスを使用して外部フォントとしてロードしてください:

```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
