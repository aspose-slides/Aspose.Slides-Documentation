---
title: よくある質問
type: docs
weight: 340
url: /ja/python-net/faq/
keywords:
- FAQ
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
description: "Aspose.Slides for Python via .NET に関する FAQ の回答を取得できます。PowerPoint および OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングについてカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for Python via .NET がサポートしているファイル形式は何ですか？**

**A**: Aspose.Slides for Python via .NET は、[Supported File Formats](/slides/ja/python-net/supported-file-formats/) に記載されているファイル形式をサポートしています。

## **例外**

**Q: 画像付きの大きな PPT ファイルを読み込む際にメモリ不足例外が発生します。Aspose.Slides にはファイルサイズの制限がありますか？**

**A**: Aspose.Slides がサポートできるプレゼンテーションのサイズを計算する特定の式はありません。プレゼンテーション全体の構造と画像をメモリに収める十分な空き領域が必要です。通常、メモリ上の画像はハードディスク上のサイズよりも大きくなります。特に画像に追加効果がある場合は顕著です。

一般的に、Aspose.Slides for Python via .NET は、4 GB RAM のサーバー上で約 300 MB のプレゼンテーション ファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドのサイズを変更できますか？**

**A**: [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスが公開している `slide_size` プロパティを使用して、プレゼンテーション内のスライドのサイズを定義できます。

**Q: プレゼンテーション内でサイズが異なるスライドを定義する方法はありますか？**

**A**: スライドのサイズは Microsoft PowerPoint のプレゼンテーションレベルで定義されるため、異なるサイズを設定する方法はありません。

**Q: Aspose.Slides for Python via .NET は、保存前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションのスライドを画像としてレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for Python via .NET は、`aspose.slides.util` 名前空間の下にある [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスを提供しており、プレゼンテーションから全テキストを取得するさまざまなメソッドが用意されています。

**Q: なぜ Windows と Linux のオペレーティングシステムで段落サイズが異なるのですか？**

**A**: 段落サイズの計算は、該当段落のテキストサイズの計算に基づきます。テキストサイズの計算は、PowerPoint プレゼンテーションで指定されたフォントのメトリックに基づきます。指定されたフォントが存在しない場合、最も類似したフォントに置き換えられますが、このフォントのメトリックは元のフォントとは異なります。その結果、インストールされているフォントのセットに依存して、異なるシステムで段落サイズの計算結果が異なることになります。異なる OS でも同じ結果を得るには、システムに同じフォントをインストールするか、実行時に [external fonts](/slides/ja/python-net/custom-font/) としてロードする必要があります。

## **書式設定と画像**

**Q: テーブルの枠線の色を設定するにはどうすればよいですか？**

**A**: テーブル全体の枠線またはテーブル全体の外枠だけの色を変更できます。すべての枠線を変更する場合は、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラスの `cell_format` プロパティを使用してください。テーブル全体の外枠の場合は、セルを反復処理して外側の枠線の色を変更する必要があります。

**Q: Aspose.Slides for Python via .NET は、画像の配置にどの単位を使用しますか？**

**A**: スライド上のすべてのシェイプの座標とサイズはポイント (72 dpi) 単位で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントがコードを実行したオペレーティングシステムにインストールされていないことを示している可能性があります。フォントをオペレーティングシステムにインストールするか、以下に示すように [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスを使用して外部フォントとしてロードしてください。
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
