---
title: Android で PPT を PPTX に変換
linktitle: PPT から PPTX
type: docs
weight: 20
url: /ja/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Android でレガシー PPT ファイルを PPTX に変換します。単一ファイルとバッチ変換の Java サンプル、エラーハンドリング、忠実度に関する注意点を含みます。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for Android via Java は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換する**

ソースファイルは [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスでロードし、次に [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) に [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/#Pptx) を指定して呼び出します。`finally` ブロックでプレゼンテーションを破棄し、リソースを解放します。

```java
// レガシー PPT プレゼンテーションを読み込みます。
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // プレゼンテーションを PPTX 形式で保存します。
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ファイル拡張子だけでは出力形式は決定されません。[SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/#Pptx) 引数が形式を指定します。元の PPT ファイルを保持する必要がある場合は、入力パスと出力パスを別々にしてください。

## **複数の PPT ファイルを変換する**

以下の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換が失敗してもバッチ全体は停止しません。

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

本番環境では、例外全文をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行キューまたはレビューキューに書き出してください。破損したファイル、必要なパスワードなしで開いたパスワード保護ファイル、アクセスできないパス、サポートされていないコンテンツは、すべて変換失敗の原因となります。暗号化されたファイルの読み込みについては、[Password-Protected Presentations](/androidjava/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換では通常、スライド、マスタ、レイアウト、テキスト、シェイプ、画像、テーブル、チャートが保持されます。ただし、PPT と PPTX はすべての機能を同一の形で表現しているわけではありません。PPTX に対応するものがないレガシー機能や、ライブラリがサポートしていない機能は、正規化、除外、または別の表示になる可能性があります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、特殊なフォント、VBA マクロが含まれる場合は確認してください。標準の PPTX ファイルはマクロ有効形式ではないため、VBA を保持する必要がある場合はマクロ有効なワークフローを使用してください。また、変換されたプレゼンテーションが開かれるまたはレンダリングされる環境に、必要なフォントや外部リソースが存在することも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムで再度開き、スライド数や主要コンテンツを確認したうえで、目的のビューアでの外観やスライドショーの動作と比較してください。成功した [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 呼び出しだけで、すべてのレガシー機能が正確に PPTX に変換されたと判断しないでください。

## **PPTX を使用すべきとき**

現在の PowerPoint バージョンで編集する場合、Open XML パッケージを扱うシステムとやり取りする場合、またはレガシーなバイナリ PPT よりも検査や復元が容易な形式で保存する場合は、PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS など別の出力形式が必要な場合は、すべてのターゲットが編集可能な PowerPoint 機能を保持すると仮定せず、[Convert Presentations to Multiple Formats](/slides/ja/androidjava/convert-presentation/) の形式別ガイダンスを利用してください。

## **オンラインコンバータ**

たまにファイルを変換したり簡単に比較したい場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を使用できます。繰り返しの変換、バッチ処理、またはアプリケーションレベルのエラーハンドリングが必要な場合は、Android via Java API を使用してください。

## **関連記事**

- [PPT と PPTX](/slides/ja/androidjava/ppt-vs-pptx/)
- [Android でプレゼンテーションを保存する](/slides/ja/androidjava/save-presentation/)
- [サポートされているファイル形式](/slides/ja/androidjava/supported-file-formats/)
- [Android でプレゼンテーションを開く](/slides/ja/androidjava/open-presentation/)

## **よくある質問**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Android via Java は Microsoft PowerPoint を必要とせずにプレゼンテーションファイルを読み込み、保存できます。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーションコンテンツは保持されますが、すべてのレガシー機能やサポート外の機能が正確に保持される保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特殊なアニメーション、特殊フォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルを読み込む際に正しいパスワードを指定すれば変換できます。パスワードが欠如しているか誤っている場合、読み込み操作は失敗します。

**変換後に PPT ファイルを削除すべきですか？**

対象のビューアやワークフローで PPTX を確認できるまで、元のファイルは保持してください。レガシー機能が異なる形で変換された場合に備えて、ロールバック用のコピーとして残しておくことが重要です。