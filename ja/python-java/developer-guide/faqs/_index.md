---
title: "よくある質問"
type: docs
weight: 340
url: /ja/python-java/faqs/
keywords:
- "よくある質問"
- "プレゼンテーション形式"
- "メモリ不足エラー"
- "スライドサイズ"
- "テキスト抽出"
- "段落サイズ"
- "テーブル枠線"
- "フォント"
- "PowerPoint"
- "OpenDocument"
- "プレゼンテーション"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Python via Java に関する一般的な質問への回答を見つけましょう。ファイル形式、メモリ使用量、スライドサイズ、テキスト、テーブル、画像、フォントなどが含まれます。"
---
## **概要**

このFAQでは、サポートされているファイル形式、大規模なプレゼンテーションのメモリ使用量、スライドサイズとプレビュー、テキスト抽出、テーブル枠線、画像の配置、PDFや画像への変換時のフォントの違いについて説明します。

## **FAQ**

### **サポートされているファイル形式**

**Aspose.Slides for Python via Java がサポートしているファイル形式は何ですか？**

サポートされているプレゼンテーション、ドキュメント、画像形式およびそのインポート・エクスポート機能については、[Supported File Formats](/slides/ja/python-java/supported-file-formats/) を参照してください。

### **例外**

**画像を含む大きなプレゼンテーションを読み込むときにメモリ不足エラーが発生します。ファイルサイズの上限はありますか？**

プレゼンテーションがメモリに収まるかどうかを予測する単一のファイルサイズ閾値はありません。メモリ要件はプレゼンテーションの構造、展開された画像、エフェクト、実行する操作に依存します。画像はディスク上の圧縮サイズよりはるかに多くのメモリを占有することがあります。

Aspose.Slides for Python via Java は JPype を介して Java エンジンを使用するため、JVM ヒープに十分な領域が必要です。システムの RAM が多くても、JVM が使用できるメモリ量はそれだけで決まるわけではありません。使用後は[Presentation.dispose](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#dispose)でプレゼンテーションを解放してください。環境セットアップについては[System Requirements](/slides/ja/python-java/system-requirements/) と[Installation](/slides/ja/python-java/installation/) をご覧ください。

### **スライドの操作**

**プレゼンテーションのスライドサイズを変更できますか？**

はい。プレゼンテーションのスライドサイズ設定は[Presentation.getSlideSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getslidesize)で取得し、[SlideSize.setSize](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slidesize/#setsize)でサイズを設定して、既存コンテンツのスケーリング方法を選択できます。

**同じプレゼンテーション内のスライドでサイズを異ならせることはできますか？**

できません。Microsoft PowerPoint のドキュメントはスライドサイズをプレゼンテーションレベルで定義するため、すべてのスライドは同一サイズです。

**プレゼンテーションを保存せずにスライドをプレビューできますか？**

できます。スライドを画像としてレンダリングし、その画像をアプリケーションで表示してください。保存は必要ありません。

### **テキストの操作**

**プレゼンテーションからすべてのテキストを取得できますか？**

できます。[SlideUtil](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/) クラスは、プレゼンテーションや個々のスライドからテキストを取得するメソッドを提供しています。

**Windows と Linux で段落サイズが異なるのはなぜですか？**

段落の寸法はテキストを描画するフォントのメトリックに依存します。フォントが欠落している場合、代替フォントの文字幅や行高さが異なるため、改行や段落サイズが変わります。両方のシステムに同じフォントをインストールするか、プレゼンテーションの作成・読み込み前に[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadexternalfonts)で同じフォントファイルを読み込んでください。

### **書式設定と画像**

**テーブル枠線の色を設定するにはどうすればよいですか？**

[Cell.getCellFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/cell/#getcellformat)で各セルの枠線書式にアクセスし、該当する枠線の塗りつぶし色を設定します。すべての枠線を変更する場合はすべてのセルを処理し、テーブルの外枠だけを変更する場合はエッジにあるセルの外向き枠線のみを更新してください。

**画像の位置やサイズはどの単位で指定されますか？**

シェイプの座標とサイズはポイント単位です。1インチは 72 ポイントに相当し、ピクセル座標ではありません。

### **フォントの操作**

**プレゼンテーションを PDF や画像に変換するとフォントが変わるのはなぜですか？**

変換を行うマシンに必要なフォントがインストールされていない可能性があります。元のフォントをインストールするか、[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/ja/python-java/aspose.slides/fontsloader/#loadexternalfonts)を使用してフォントが格納されたフォルダーを追加してください。プレゼンテーションの作成または開く前に外部フォントを読み込んでください。

以下の例はフォントフォルダーを登録します。パスは実際にフォントファイルがあるフォルダーに置き換えてください。環境は[Installation](/slides/ja/python-java/installation/)で説明されているものを前提としています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontsLoader

font_folders = jpype.JArray(jpype.JString)(["path_to_a_folder_with_fonts"])
FontsLoader.loadExternalFonts(font_folders)
```

この例では、後続のプレゼンテーション操作のために JVM を実行し続けます。ノートブックでの使用や JVM のライフサイクル制限については[Limitations and API Differences](/slides/ja/python-java/limitations-and-api-differences/) を参照してください。