---
title: Java で PPT を PPTX に変換する
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/java/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPT から PPTX へ
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Java でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換の Java サンプル、エラーハンドリング、忠実度に関する注記を含みます。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for Java は Microsoft PowerPoint がなくても PPT ファイルを読み込み、PPTX として保存できます。この記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換する**

[Presentation] クラスでソース ファイルをロードし、[SaveFormat.Pptx] を指定して [Presentation.save] を呼び出します。`finally` ブロックはプレゼンテーションを破棄し、リソースを解放します。

```java
// レガシー PPT プレゼンテーションをロードします。
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // プレゼンテーションを PPTX 形式で保存します。
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ファイル拡張子だけでは出力形式は決まりません。出力形式は [SaveFormat.Pptx] 引数で指定します。元の PPT ファイルを保持する必要がある場合は、入力パスと出力パスを別々にしてください。

## **複数の PPT ファイルを変換する**

次の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換失敗がバッチ全体を中断することはありません。

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

本番環境では、例外の全内容をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行またはレビューキューに書き出してください。破損したファイル、必要なパスワードなしで開いたパスワード保護ファイル、アクセスできないパス、サポートされていないコンテンツが原因で変換が失敗することがあります。暗号化されたファイルの読み込みについては [Password-Protected Presentations](/slides/ja/java/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換は通常、スライド、マスタ、レイアウト、テキスト、シェイプ、画像、表、チャートを保持します。ただし、PPT と PPTX はすべての機能を同一に表現できるわけではありません。PPTX に対応するものがないレガシー機能や、ライブラリでサポートされていない機能は、正規化、除外、または別の形で表示されることがあります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、珍しいフォント、VBA マクロが含まれる場合は確認してください。普通の PPTX ファイルはマクロ対応形式ではないため、VBA を残す必要がある場合は適切なマクロ対応ワークフローを使用してください。また、変換されたプレゼンテーションが開かれるまたはレンダリングされる環境に、必要なフォントや外部リソースが存在することも確認してください。

重要なドキュメントの場合、生成された PPTX をプログラムから再度開き、スライド数やコンテンツを検証し、意図したビューアでの外観やスライドショーの動作と比較してください。成功した [Presentation.save] 呼び出しを、すべてのレガシー機能が正確に PPTX に変換された証拠とみなさないでください。

## **PPTX を使用すべきとき**

プレゼンテーションが現在の PowerPoint バージョンで編集される、Open XML パッケージと連携するシステムとやり取りされる、またはレガシーなバイナリ PPT よりも検査・復元が容易な形式で保存される場合は PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックをクリアするまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS、またはその他の出力形式が必要な場合は、すべてのターゲットが編集可能な PowerPoint 機能を保持すると推測せず、[Convert Presentations to Multiple Formats](/slides/ja/java/convert-presentation/) のフォーマット別ガイドラインを使用してください。

## **オンライン コンバータ**

たまにファイルを変換する場合や簡単に比較したい場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換やバッチ処理、アプリケーションレベルのエラーハンドリングが必要な場合は、Java API を使用してください。

## **関連記事**

- [PPT vs PPTX](/slides/ja/java/ppt-vs-pptx/)
- [Save Presentations in Java](/slides/ja/java/save-presentation/)
- [Supported File Formats](/slides/ja/java/supported-file-formats/)
- [Open Presentations in Java](/slides/ja/java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Java は Microsoft PowerPoint を必要とせずにプレゼンテーションファイルの読み込みと保存が可能です。

**PPT から PPTX への変換はすべてのコンテンツを正確に保持しますか？**

一般的なプレゼンテーションコンテンツは保持されますが、すべてのレガシー機能や未サポート機能が正確に保持される保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特殊なアニメーション、珍しいフォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルを読み込む際に正しいパスワードを指定すれば可能です。パスワードがない、または間違っている場合は読み込みが失敗します。

**変換後に PPT ファイルを削除すべきですか？**

重要なビューアやワークフローで PPTX を確認するまで、元のファイルは保持してください。レガシー機能が異なる形で変換された場合のロールバック用コピーとして役立ちます。