---
title: よくある質問
type: docs
weight: 340
url: /ja/net/faqs/
keywords:
- FAQ
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
description: "Aspose.Slides for .NET の FAQ に対する回答を取得できます。PowerPoint と OpenDocument のサポート、インストールガイド、ライセンス、トラブルシューティングをカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for .NET はどのファイル形式をサポートしていますか？**

**A**: Aspose.Slides for .NET は[Supported File Formats](/slides/ja/net/supported-file-formats/)に記載されているファイル形式をサポートしています。

## **例外**

**Q: 画像付きの大きな PPT ファイルをロード中に OutOfMemoryException が発生します。Aspose.Slides にはファイルサイズに関する制限がありますか？**

**A**: Aspose.Slides がサポートするプレゼンテーションサイズを計算するための特定の式はありません。プレゼンテーション全体の構造と画像をメモリに保持できるだけの十分な空き領域が必要です。通常、メモリ上の画像はハードディスク上のサイズよりも大きく、特に画像にエフェクトが追加されている場合は顕著です。

一般的に、4 GB の RAM を搭載したサーバー上では、Aspose.Slides for .NET は約 300 MB のプレゼンテーション ファイルを問題なく処理できます。

## **スライドの操作**

**Q: プレゼンテーション内のスライドのサイズを変更できますか？**

**A**: `SlideSize` プロパティは[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスで公開されており、プレゼンテーション内のスライドのサイズを定義できます。

**Q: プレゼンテーション内でサイズが異なるスライドを定義する方法はありますか？**

**A**: Microsoft PowerPoint のドキュメントではスライドサイズはプレゼンテーションレベルで定義されるため、サイズが異なるスライドを設定することはできません。

**Q: Aspose.Slides for .NET は保存前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションのスライドを画像としてレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for .NET は`Aspose.Slides.Util`名前空間にある[SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/)クラスを提供しており、プレゼンテーション全体のテキストを取得するさまざまなメソッドが用意されています。

**Q: Windows と Linux のオペレーティング システムで段落サイズが異なる理由は何ですか？**

**A**: 段落サイズの計算は、該当段落を表すテキストサイズの計算に基づいています。テキストサイズの計算は、PowerPoint プレゼンテーションで指定されたフォントのメトリクスに依存します。指定されたフォントが存在しない場合、最も類似したフォントに置き換えられますが、そのフォントのメトリクスは元のフォントと異なります。そのため、インストールされているフォントのセットがシステムごとに異なると、異なる OS で段落サイズの計算結果が変わります。異なるオペレーティングシステムで同一の結果を得るには、システムに同じフォントをインストールするか、実行時に[external fonts](/slides/ja/net/custom-font/)としてロードする必要があります。

## **書式設定と画像**

**Q: テーブルの枠線の色を設定するにはどうすればよいですか？**

**A**: テーブルのすべての枠線の色、またはテーブル全体を囲む枠線の色だけを変更できます。すべての枠線を変更する場合は、[ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)インターフェイスの`CellFormat`プロパティを使用してください。テーブル全体の枠線を変更するには、セルを走査して外側の枠線の色を変更する必要があります。

**Q: Aspose.Slides for .NET が画像の配置に使用する単位は何ですか？**

**A**: スライド上のすべての図形の座標とサイズはポイント (72 dpi) 単位で測定されます。

## **フォントの操作**

**Q: PPT を PDF や画像に変換した際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントがコード実行時のオペレーティングシステムに存在しないことを示している可能性があります。フォントを OS にインストールするか、下記のように[FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/)クラスを使用して外部フォントとしてロードしてください：
```cs
var folders = new string[] { "path_to_a_folder_with_fonts" };
FontsLoader.LoadExternalFonts(folders);
```
