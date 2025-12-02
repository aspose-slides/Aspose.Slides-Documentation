---
title: "よくある質問"
type: docs
weight: 340
url: /ja/java/faqs/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java に関する FAQ の回答を取得できます。PowerPoint と OpenDocument のサポート、インストール手順、ライセンス、トラブルシューティングをカバーしています。"
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for Java がサポートするファイル形式は何ですか？**

**A**: Aspose.Slides for Java は、[サポートされているファイル形式](/slides/ja/java/supported-file-formats/) に記載されたファイル形式をサポートしています。

## **例外**

**Q: 大きな画像付き PPT ファイルを読み込む際にメモリ不足例外が発生します。Aspose.Slides にファイルサイズの制限はありますか？**

**A**: Aspose.Slides がサポートするプレゼンテーションサイズを計算するための特定の式はありません。プレゼンテーション全体の構造と画像をメモリに収めるだけの十分な空き容量が必要です。通常、メモリ上の画像はハードディスク上の画像よりも多くの領域を占有します。特に画像に追加効果がある場合は顕著です。

一般に、Aspose.Slides for Java は、4 GB の RAM を搭載したサーバー上で約 300 MB のプレゼンテーション ファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーションのスライドサイズを変更できますか？**

**A**: プレゼンテーション内のスライドサイズを定義するには、[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) クラスが提供する `getSlideSize` メソッドを使用できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: スライドのサイズは Microsoft PowerPoint のドキュメントではプレゼンテーションレベルで定義されるため、これを実現する方法はありません。

**Q: Aspose.Slides for Java は、保存前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションのスライドを画像としてレンダリングし、これらの画像をスライドのプレビューに使用できます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for Java は、プレゼンテーション全体のテキストを取得するためのさまざまなメソッドを提供する [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/slideutil/) クラスを提供しています。

**Q: Windows と Linux の OS で段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、その段落を表すテキストサイズの計算に基づきます。テキストサイズの計算は、PowerPoint プレゼンテーションで指定されたフォントのメトリックに基づいて行われます。指定されたフォントが存在しない場合、最も類似したフォントに置き換えられますが、そのフォントのメトリックは元のフォントとは異なります。その結果、インストールされているフォントのセットが異なるシステム間では、段落サイズの計算結果が異なることになります。異なる OS でも同じ結果を得るには、システムに同じフォントをインストールするか、実行時に[外部フォント](/slides/ja/java/custom-font/)としてロードする必要があります。

## **書式設定と画像**

**Q: テーブルの枠線の色を設定するにはどうすればよいですか？**

**A**: テーブル全体の枠線の色、またはテーブル全体を囲む枠線の色を変更できます。すべての枠線を変更する場合は、[ICell](https://reference.aspose.com/slides/java/com.aspose.slides/icell/) インターフェイスの `getCellFormat` メソッドを使用してください。テーブル全体の枠線を変更するには、セルを列挙して外側の枠線の色を変更する必要があります。

**Q: Aspose.Slides for Java は画像の配置にどの測定単位を使用しますか？**

**A**: スライド上のすべての図形の座標とサイズはポイント（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPT を PDF または画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントがコード実行時のオペレーティングシステムにインストールされていないことが原因である可能性があります。フォントをオペレーティングシステムにインストールするか、[FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) クラスを使用して外部フォントとしてロードしてください。以下に例を示します:
```cs
var folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```
