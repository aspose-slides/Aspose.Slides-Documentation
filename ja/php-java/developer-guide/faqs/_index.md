---
title: よくある質問
type: docs
weight: 340
url: /ja/php-java/faqs/
keywords:
- FAQ
- PowerPoint
- プレゼンテーション形式
- メモリ不足エラー
- スライドサイズ
- テキスト抽出
- テキスト取得
- 段落サイズ
- テーブルのフォーマット
- フォント
- PHP
- Java
- Aspose.Slides for PHP via Java
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for PHP via Javaはどのファイル形式をサポートしていますか？**

**A**: Aspose.Slides for PHP via Javaは、[サポートされているファイル形式](/slides/ja/php-java/supported-file-formats/)で説明されているファイル形式をサポートしています。

## **例外**

**Q: 画像付きの大きなPPTファイルを読み込むと、メモリ不足の例外が発生します。Aspose.Slidesにはファイルサイズに関する制限がありますか？**

**A**: Aspose.Slidesによってサポートされるプレゼンテーションサイズを計算する明確な式はありません。プレゼンテーションの全構造と画像をメモリに格納するのに十分なスペースが必要です。通常、メモリ内の画像はハードディスクよりも多くのスペースを占有し、特に画像に追加の効果がある場合はそうです。

一般に、Aspose.Slides for PHP via Javaは4 GB RAMのサーバーで約300 MBのプレゼンテーションファイルを簡単に処理できます。

## **スライドの操作**

**Q: プレゼンテーションのスライドサイズを変更できますか？**

**A**: プレゼンテーション内のスライドのサイズを定義するには、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/)クラスが提供する`getSlideSize`メソッドを使用できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: Microsoft PowerPointドキュメントでは、スライドのサイズがプレゼンテーションレベルで定義されているため、これを行う方法はありません。

**Q: Aspose.Slides for PHP via Javaは保存前にスライドのプレビューをサポートしていますか？**

**A**: プレゼンテーションスライドを画像にレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for PHP via Javaは、プレゼンテーションから全テキストを取得するためのさまざまなメソッドを提供する[SlideUtil](https://reference.aspose.com/slides/php-java/aspose.slides/slideutil/)クラスを提供しています。

**Q: WindowsとLinuxオペレーティングシステムで段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、指定された段落を表すテキストサイズの計算に基づいています。テキストサイズの計算は、PowerPointプレゼンテーションで指定されたフォントのメトリックに基づいています。指定されたフォントが欠けている場合、最も類似したフォントに置き換えられますが、このフォントのメトリックは元のものとは異なります。その結果、異なるシステムにおける段落サイズの計算は、インストールされたフォントのセットによって異なる結果をもたらします。異なるオペレーティングシステムで同じ結果を得るには、システムに同じフォントをインストールするか、[外部フォント](/slides/ja/php-java/custom-font/)としてランタイム中にロードする必要があります。

## **フォーマットと画像**

**Q: テーブル境界の色を設定するにはどうすればよいですか？**

**A**: すべてのテーブルの境界または全体のテーブルの周囲の境界の色を変更できます。すべての境界を変更するには、[Cell](https://reference.aspose.com/slides/php-java/aspose.slides/cell/)クラスの`getCellFormat`メソッドを使用してください。全体のテーブルの境界の場合、セルを反復処理し、外部境界の色を変更する必要があります。

**Q: Aspose.Slides for PHP via Javaは画像を配置するためにどのような測定を使用しますか？**

**A**: スライド上のすべての図形の座標とサイズはポイント（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPTをPDFまたは画像に変換する際、出力文書のフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されるフォントがコードが実行されたオペレーティングシステムに存在しないことを示している可能性があります。オペレーティングシステムにフォントをインストールするか、[FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/)クラスを使用して外部フォントとしてロードする必要があります。以下のようにします：
```cs
$folders = ["path_to_a_folder_with_fonts"];
FontsLoader::loadExternalFonts($folders);
```