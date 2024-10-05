---
title: FAQs
type: docs
weight: 340
url: /androidjava/faqs/
keywords:
- FAQ
- PowerPoint
- プレゼンテーション形式
- メモリ不足エラー
- スライドサイズ
- テキスト抽出
- テキスト取得
- 段落サイズ
- 表のフォーマット
- フォント
- Android
- Java
- Aspose.Slides for Android via Java
---

## **サポートされているファイル形式**

**Q: Aspose.Slides for Android via Javaはどのファイル形式をサポートしていますか？**

**A**: Aspose.Slides for Android via Javaは[サポートされているファイル形式](/slides/androidjava/supported-file-formats/)で説明されているファイル形式をサポートしています。

## **例外**

**Q: 大きなPPTファイルを画像付きで読み込むとメモリ不足の例外が発生します。Aspose.Slidesにはファイルサイズに制限がありますか？**

**A**: Aspose.Slidesがサポートするプレゼンテーションサイズを計算する特定の公式はありません。プレゼンテーションの構造全体と画像をメモリに収容するのに十分なスペースが必要です。通常、メモリ内の画像はハードディスクよりも多くのスペースを占有します、特に画像に追加のエフェクトがある場合は特にそうです。

一般的に、Aspose.Slides for Android via Javaは、4 GBのRAMを搭載したサーバー上で約300 MBのプレゼンテーションファイルを容易に処理できます。

## **スライドの操作**

**Q: プレゼンテーションのスライドのサイズを変更できますか？**

**A**: [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/)クラスの`getSlideSize`メソッドを使用して、プレゼンテーション内のスライドのサイズを定義できます。

**Q: プレゼンテーション内で異なるサイズのスライドを定義する方法はありますか？**

**A**: Microsoft PowerPoint文書ではスライドのサイズがプレゼンテーションレベルで定義されるため、これを行う方法はありません。

**Q: Aspose.Slides for Android via Javaは、保存前にスライドをプレビューすることをサポートしていますか？**

**A**: プレゼンテーションのスライドを画像としてレンダリングし、これらの画像を使用してスライドをプレビューできます。

## **テキストの操作**

**Q: プレゼンテーションからすべてのテキストを取得することはできますか？**

**A**: Aspose.Slides for Android via Javaは、プレゼンテーションから全テキストを取得するためのさまざまなメソッドを提供する[SlideUtil](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slideutil/)クラスを提供しています。

**Q: なぜPCとAndroidで段落サイズが異なるのですか？**

**A**: 段落サイズの計算は、特定の段落を表すテキストサイズの計算に基づいています。テキストサイズの計算は、PowerPointプレゼンテーションで指定されたフォントのメトリックに基づいています。指定されたフォントが存在しない場合、それは最も類似したフォントに置き換えられますが、このフォントは元のものとは異なるメトリックを持っています。その結果、異なるシステムでの段落サイズの計算は、インストールされたフォントのセットに応じて異なる結果をもたらします。異なるオペレーティングシステムで同じ結果を得るには、システムに同じフォントをインストールするか、[外部フォント](/slides/androidjava/custom-font/)としてランタイム時に読み込む必要があります。

## **フォーマットと画像**

**Q: テーブルの境界線の色を設定するにはどうすればよいですか？**

**A**: すべてのテーブルの境界線またはテーブル全体の境界線の色を変更できます。すべての境界線を変更するには、[ICell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/)インターフェースの`getCellFormat`メソッドを使用してください。テーブル全体の境界線については、セルを反復処理して外側の境界線の色を変更する必要があります。

**Q: Aspose.Slides for Android via Javaは、画像を配置するためにどのような尺度を使用しますか？**

**A**: スライド上のすべての図形の座標とサイズはポイント（72 dpi）で測定されます。

## **フォントの操作**

**Q: PPTをPDFや画像に変換する際、出力ドキュメントのフォントが異なる理由は何ですか？**

**A**: この問題は、プレゼンテーションで使用されているフォントがコードが実行されたオペレーティングシステムに存在しないことを示している可能性があります。オペレーティングシステムにフォントをインストールするか、以下のように[FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/)クラスを使用して外部フォントとして読み込む必要があります。
```java
String[] folders = new String[] { "path_to_a_folder_with_fonts" };
FontsLoader.loadExternalFonts(folders);
```