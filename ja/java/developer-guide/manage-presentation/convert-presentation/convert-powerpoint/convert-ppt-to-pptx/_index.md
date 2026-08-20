---
title: JavaでPPTをPPTXに変換
linktitle: PPTからPPTXへ
type: docs
weight: 20
url: /ja/java/convert-ppt-to-pptx/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- スライドを変換
- PPTを変換
- PPTからPPTXへ
- PPTをPPTXとして保存
- PPTをPPTXにエクスポート
- PowerPoint
- プレゼンテーション
- Java
- Aspose.Slides
description: "JavaとAspose.Slidesを使用してレガシーなPPTファイルをPPTXに変換します。単一ファイルおよびバッチ変換、エラーハンドリング、忠実度に関する注記のJava例を含みます。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint フォーマットで、PPTX は新しい Open XML フォーマットです。Aspose.Slides for Java は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換**

ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/) クラスで読み込み、次に [Presentation.save](https://reference.aspose.com/slides/ja/java/com.aspose.slides/presentation/#save-java.lang.String-int-) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/#Pptx) とともに呼び出します。`finally` ブロックでプレゼンテーションを破棄し、リソースを解放します。

```java
// レガシーな PPT プレゼンテーションを読み込みます。
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // プレゼンテーションを PPTX 形式で保存します。
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ファイル拡張子だけでは出力形式は決定されません。出力形式は [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/java/com.aspose.slides/saveformat/#Pptx) 引数で指定します。元の PPT ファイルを保持したい場合は、入力パスと出力パスを異なる場所に設定してください。

## **複数の PPT ファイルを変換**

次の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換が失敗してもバッチ全体は停止しません。

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

本番環境では、例外全体をログに記録し、既存の出力ファイルを上書きしてよいかを判断し、失敗したファイル名を再試行またはレビュー キューに書き込みます。破損したファイル、必要なパスワードなしで開かれたパスワード保護されたファイル、アクセスできないパス、サポートされていないコンテンツは、いずれも変換失敗の原因となります。暗号化されたファイルの読み込みについては、[Password-Protected Presentations](/java/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換は通常、スライド、マスタ、レイアウト、テキスト、シェイプ、画像、テーブル、チャートを保持します。ただし、PPT と PPTX はすべての機能を完全に同じ方法で表現できるわけではありません。PPTX に対応するものがないレガシー機能や、ライブラリでサポートされていない機能は、正規化、除外、または別の表示になる場合があります。

アニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、特殊フォント、VBA マクロが含まれる場合は、変換後のファイルを確認してください。標準の PPTX ファイルはマクロ対応形式ではないため、VBA を残す必要がある場合は、適切なマクロ対応ワークフローを使用してください。また、変換されたプレゼンテーションを開くまたはレンダリングする環境に、必要なフォントや外部リソースが揃っていることも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数やコンテンツを検査し、意図したビューアでの外観やスライドショーの動作と比較してください。`Presentation.save` の呼び出しが成功したからといって、すべてのレガシー機能が PPTX に正確に変換されたことの証明にはなりません。

## **PPTX を使用すべき時**

プレゼンテーションを現在の PowerPoint バージョンで編集する予定がある場合、Open XML パッケージを扱えるシステムとやり取りする場合、またはレガシーなバイナリ PPT よりも検査や復元が容易な形式で保存したい場合は PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック 用のコピーとして保持してください。

PDF、HTML、画像、XPS、その他の出力形式が必要な場合は、[Convert Presentations to Multiple Formats](/java/convert-presentation/) のフォーマット固有のガイダンスを参照し、すべてのターゲットが編集可能な PowerPoint 機能を保持するものと想定しないでください。

## **オンラインコンバータ**

たまにファイルを変換したり、簡単に比較したりする場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返し変換、バッチ処理、アプリケーションレベルのエラーハンドリングが必要な場合は、Java API を使用してください。

## **関連記事**

- [PPT と PPTX の比較](/java/ppt-vs-pptx/)
- [Java でプレゼンテーションを保存](/java/save-presentation/)
- [サポートされているファイル形式](/java/supported-file-formats/)
- [Java でプレゼンテーションを開く](/java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルの読み込みと保存が可能です。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持しますが、すべてのレガシー機能やサポート外の機能が正確に変換される保証はありません。マクロ、OLE や ActiveX オブジェクト、メディア、特殊なアニメーション、特殊フォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルを読み込む際に正しいパスワードを指定すれば変換できます。パスワードが不足または誤っている場合、読み込み操作は失敗します。

**変換後に PPT ファイルを削除すべきですか？**

変換後にビューアやワークフローで PPTX を検証するまで、元のファイルは残しておいてください。これにより、レガシー機能の変換結果が異なる場合にロールバック コピーとして利用できます。