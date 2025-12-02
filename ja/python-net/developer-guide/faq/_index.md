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
- テーブル書式設定
- フォント
- PowerPoint
- OpenDocument
- プレゼンテーション
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET の FAQ に対する回答を取得できます。PowerPoint および OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングについてカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for Python via .NET がサポートしているファイル形式は何ですか？**

**A**: Aspose.Slides for Python via .NET は、[Supported File Formats](/slides/ja/python-net/supported-file-formats/)で説明されているファイル形式をサポートしています。

## **例外**

**Q: 画像付きの大きな PPT ファイルを読み込む際にメモリ不足例外が発生します。Aspose.Slides にはファイルサイズに制限がありますか？**

**A**: Aspose.Slides がサポートするプレゼンテーション サイズを算出する具体的な式はありません。プレゼンテーション全体の構造と画像をメモリ上に収めるだけの十分な空き領域が必要です。通常、メモリ上の画像はハードディスク上のサイズよりも大きくなります。特に画像にエフェクトが付加されている場合は顕著です。  
一般的に、Aspose.Slides for Python via .NET は、4 GB RAM のサーバー上で約 300 MB のプレゼンテーションファイルを問題なく処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドサイズを変更できますか？**

**A**: `slide_size` プロパティは、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスで公開されており、プレゼンテーション内のスライドサイズを定義できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: Microsoft PowerPoint のドキュメントではスライドサイズはプレゼンテーションレベルで定義されるため、異なるサイズのスライドを設定することはできません。

**Q: Aspose.Slides for Python via .NET は、保存前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションのスライドを画像としてレンダリングし、これらの画像を使用してスライドのプレビューを行うことができます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for Python via .NET は、`aspose.slides.util` 名前空間にある[SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスを提供しており、プレゼンテーション全体のテキストを取得するさまざまなメソッドがあります。

**Q: Windows と Linux の OS で段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、対象段落を表すテキストサイズの計算に基づいています。テキストサイズの算出は、PowerPoint プレゼンテーションで指定されたフォントのメトリクスに依存します。指定されたフォントが存在しない場合、最も類似したフォントに置き換えられますが、そのフォントは元のフォントとはメトリクスが異なります。そのため、インストールされているフォントのセットに応じて、異なる OS での段落サイズ計算結果が変わります。異なる OS 間で同じ結果を得るには、システムに同じフォントをインストールするか、実行時に[external fonts](/slides/ja/python-net/custom-font/) としてロードする必要があります。

## **書式設定と画像**

**Q: テーブルの罫線の色を設定するにはどうすればよいですか？**

**A**: テーブル全体の罫線の色を変更することも、テーブル全体を囲む外枠だけを変更することも可能です。すべての罫線を変更する場合は、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラスの `cell_format` プロパティを使用してください。テーブル全体の外枠を変更する場合は、セルを列挙し、外側の罫線の色を変更する必要があります。

**Q: Aspose.Slides for Python via .NET は、画像の配置にどの単位を使用しますか？**

**A**: スライド上のすべてのシェイプの座標とサイズはポイント (72 dpi) 単位で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されたフォントがコードを実行したオペレーティングシステムにインストールされていないことを示している可能性があります。フォントを OS にインストールするか、以下のように[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスを使用して外部フォントとしてロードしてください。
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
