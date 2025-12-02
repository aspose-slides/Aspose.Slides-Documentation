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
description: "Aspose.Slides for Python via .NETに関するFAQの回答を取得できます。PowerPoint と OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングについてカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for Python via .NET はどのファイル形式をサポートしていますか？**

**A**: Aspose.Slides for Python via .NET は、[サポートされているファイル形式](/slides/ja/python-net/supported-file-formats/)に記載されたファイル形式をサポートしています。

## **例外**

**Q: 画像付きの大容量 PPT ファイルを読み込む際にメモリ不足例外が発生します。Aspose.Slides にはファイルサイズの制限がありますか？**

**A**: Aspose.Slides がサポートできるプレゼンテーションサイズを計算する特定の式はありません。プレゼンテーション全体の構造と画像をメモリに保持できるだけの空き領域が必要です。通常、メモリ上の画像はハードディスク上のサイズよりも大きくなります。特に画像にエフェクトが付与されている場合は顕著です。

一般的に、Aspose.Slides for Python via .NET は、4 GB RAM のサーバー上で約 300 MB 程度のプレゼンテーションファイルを問題なく処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドサイズを変更できますか？**

**A**: `slide_size` プロパティを使用して、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) クラスからスライドのサイズを定義できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: Microsoft PowerPoint のドキュメントではスライドサイズはプレゼンテーション単位で定義されるため、異なるサイズのスライドを設定することはできません。

**Q: 保存前にスライドのプレビューを表示する機能はありますか？**

**A**: プレゼンテーションのスライドを画像としてレンダリングし、これらの画像をプレビューに使用できます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for Python via .NET は、`aspose.slides.util` 名前空間の [SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/) クラスを提供しており、プレゼンテーション全体のテキストを取得するさまざまなメソッドが用意されています。

**Q: Windows と Linux の OS で段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、該当段落のテキストサイズの計算に基づきます。テキストサイズは、PowerPoint プレゼンテーションで指定されたフォントのメトリックに基づいて算出されます。指定フォントが存在しない場合、最も類似したフォントに置き換えられますが、そのフォントのメトリックは元のフォントと異なります。そのため、システムごとにインストールされているフォントセットが異なると、段落サイズの計算結果も変わります。異なる OS でも同一の結果を得るには、同じフォントをシステムにインストールするか、[外部フォント](/slides/ja/python-net/custom-font/) として実行時にロードしてください。

## **書式設定と画像**

**Q: テーブルの罫線の色を設定するにはどうすればよいですか？**

**A**: テーブル全体の罫線またはテーブル全体を囲む外枠の色を変更できます。すべての罫線を変更する場合は、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) クラスの `cell_format` プロパティを使用してください。テーブル全体の外枠を変更する場合は、セルを走査し外側の罫線の色を変更します。

**Q: Aspose.Slides for Python via .NET は画像の配置にどの単位を使用しますか？**

**A**: スライド上のすべてのシェイプの座標とサイズはポイント単位（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換した際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントがコード実行環境の OS にインストールされていないことが原因である可能性があります。フォントを OS にインストールするか、以下の例のように [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) クラスを使用して外部フォントとしてロードしてください。
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```
