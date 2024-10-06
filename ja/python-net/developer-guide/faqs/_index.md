---
title: FAQs
type: docs
weight: 340
url: /ja/python-net/faqs/
keywords:
- FAQ
- PowerPoint
- プレゼンテーション形式
- メモリ不足エラー
- スライドサイズ
- テキスト抽出
- テキスト取得
- 段落サイズ
- テーブルフォーマット
- フォント
- Python
- Aspose.Slides for Python via .NET
---

## **対応するファイル形式**

**Q: Aspose.Slides for Python via .NETはどのファイル形式をサポートしていますか？**

**A**: Aspose.Slides for Python via .NETは、[対応するファイル形式](/slides/ja/python-net/supported-file-formats/)で説明されているファイル形式をサポートしています。

## **例外**

**Q: 画像を含む大きなPPTファイルを読み込んでいると、メモリ不足の例外が発生します。Aspose.Slidesにはファイルサイズに関する制限がありますか？**

**A**: Aspose.Slidesがサポートするプレゼンテーションサイズを計算するための特定の公式はありません。プレゼンテーション全体の構造と画像がメモリに収容できるだけの十分なスペースが必要です。通常、メモリ内の画像はハードディスクよりも多くのスペースを占有します。特に、画像に追加の効果がある場合はその傾向が強まります。

一般的に、Aspose.Slides for Python via .NETは、4 GB RAMのサーバー上で約300 MBのプレゼンテーションファイルを簡単に処理できます。

## **スライドの操作**

**Q: プレゼンテーションのスライドのサイズを変更できますか？**

**A**: プレゼンテーションのスライドのサイズを定義するには、[Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)クラスが公開している`slide_size`プロパティを使用できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: Microsoft PowerPointドキュメントではスライドのサイズがプレゼンテーションレベルで定義されているため、これを実行することはできません。

**Q: Aspose.Slides for Python via .NETは保存前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションスライドを画像としてレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することは可能ですか？**

**A**: Aspose.Slides for Python via .NETは、プレゼンテーションから全テキストを取得するためのさまざまなメソッドを提供する`aspose.slides.util`名前空間の[SlideUtil](https://reference.aspose.com/slides/python-net/aspose.slides.util/slideutil/)クラスを提供しています。

**Q: WindowsとLinuxのオペレーティングシステムで段落サイズが異なるのはなぜですか？**

**A**: 段落サイズの計算は、特定の段落を表すテキストサイズの計算に基づいています。テキストサイズの計算は、PowerPointプレゼンテーションで指定されたフォントのメトリクスに基づいています。指定されたフォントが欠けている場合、最も類似したフォントに置き換えられますが、このフォントは元のメトリクスと異なるものになります。その結果、異なるシステムでの段落サイズの計算は、インストールされたフォントのセットに応じて異なる結果をもたらします。異なるオペレーティングシステムで同じ結果を得るには、システムに同じフォントをインストールするか、[外部フォント](/slides/ja/python-net/custom-font/)としてランタイム中に読み込む必要があります。

## **フォーマットと画像**

**Q: テーブルのボーダーの色を設定するにはどうすればよいですか？**

**A**: テーブルのすべてのボーダーまたはテーブル全体のボーダーの色を変更できます。すべてのボーダーを変更するには、[Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)クラスからの`cell_format`プロパティを使用してください。テーブル全体のボーダーの場合、セルをループして外部ボーダーの色を変更する必要があります。

**Q: Aspose.Slides for Python via .NETは画像を配置するためにどのような測定を使用しますか？**

**A**: スライド上のすべての図形の座標とサイズはポイント（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPTをPDFまたは画像に変換する際、出力ドキュメントのフォントが異なるのはなぜですか？**

**A**: この問題は、プレゼンテーションで使用されるフォントが、コードが実行されたオペレーティングシステムに存在しないことを示している可能性があります。オペレーティングシステムにフォントをインストールするか、[FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/)クラスを使用して外部フォントとして読み込む必要があります。以下のように使用します：
```cs
folders = [ "path_to_a_folder_with_fonts" ]
aspose.slides.FontsLoader.load_external_fonts(folders)
```