---
title: FAQ
type: docs
weight: 340
url: /ja/cpp/faqs/
keywords:
- FAQ
- PowerPoint
- プレゼンテーション形式
- メモリ不足例外
- スライドサイズ
- テキスト抽出
- テキスト取得
- 段落サイズ
- 表の書式設定
- フォント
- С++
- Aspose.Slides for С++
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for C++はどのファイル形式をサポートしていますか？**

**A**: Aspose.Slides for C++は、[サポートされているファイル形式](/slides/ja/cpp/supported-file-formats/)に記載されているファイル形式をサポートしています。

## **例外**

**Q: 大きなPPTファイルを画像付きで読み込むとメモリ不足例外が発生します。Aspose.Slidesにファイルサイズに関する制限はありますか？**

**A**: Aspose.Slidesがサポートするプレゼンテーションサイズを計算するための特定の公式はありません。プレゼンテーション全体の構造と画像をメモリに収容するための十分なスペースが必要です。通常、メモリ内の画像はハードディスクよりも多くのスペースを占め、特に画像に追加の効果がある場合はその傾向が強いです。

一般に、Aspose.Slides for C++は4GBのRAMを持つサーバーで約300MBのプレゼンテーションファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーションのスライドのサイズを変更できますか？**

**A**: プレゼンテーション内のスライドのサイズを定義するために、[Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)クラスによって公開されている`get_SlideSize`メソッドを使用できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: Microsoft PowerPoint文書ではスライドのサイズがプレゼンテーションレベルで定義されるため、これを行う方法はありません。

**Q: Aspose.Slides for C++は、保存する前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションスライドを画像としてレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for C++は、プレゼンテーションから全体のテキストを取得するためのさまざまなメソッドを提供する`Aspose::Slides::Util`名前空間の下にある[SlideUtil](https://reference.aspose.com/slides/cpp/aspose.slides.util/slideutil/)クラスを提供します。

**Q: WindowsとLinuxオペレーティングシステムで段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、特定の段落を表すテキストサイズの計算に基づいています。テキストサイズの計算は、PowerPointプレゼンテーションに指定されたフォントのメトリクスに基づいています。指定されたフォントが欠落している場合、最も類似したフォントに置き換えられますが、このフォントのメトリクスは元のものと異なります。その結果、異なるシステムでの段落サイズの計算は、インストールされたフォントのセットに応じて異なる結果をもたらします。異なるオペレーティングシステムで同じ結果を得るには、システムに同じフォントをインストールするか、[外部フォント](/slides/ja/cpp/custom-font/)をランタイムで読み込む必要があります。

## **書式設定と画像**

**Q: テーブルの境界線の色を設定するにはどうすればいいですか？**

**A**: すべてのテーブルの境界線の色またはテーブル全体の外側の境界線の色を変更できます。すべての境界線を変更するには、[ICell](https://reference.aspose.com/slides/cpp/aspose.slides/icell/)インターフェイスの`get_CellFormat`メソッドを使用してください。テーブル全体の境界線については、セルを反復処理して外側の境界線の色を変更する必要があります。

**Q: Aspose.Slides for C++は、画像を配置するためにどのような測定単位を使用しますか？**

**A**: スライド上のすべての図形の座標とサイズは、ポイント（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPTをPDFまたは画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントが、コードが実行されているオペレーティングシステムに存在しないことを示している可能性があります。オペレーティングシステムにフォントをインストールするか、[FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/)クラスを使用して外部フォントとして読み込む必要があります。以下のように：
```cpp
auto folders = MakeObject<Array<String>>(1, "path_to_a_folder_with_fonts");
FontsLoader::LoadExternalFonts(folders);
```