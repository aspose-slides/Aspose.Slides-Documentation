---
title: AndroidでPPTをPPTXに変換
linktitle: PPT から PPTX
type: docs
weight: 20
url: /ja/androidjava/convert-ppt-to-pptx/
keywords:
- PowerPoint を変換
- プレゼンテーション を変換
- スライド を変換
- PPT を変換
- PPT から PPTX
- PPT を PPTX として保存
- PPT を PPTX にエクスポート
- PowerPoint
- プレゼンテーション
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して Android 上でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換の Java 例、エラーハンドリング、忠実度に関する注意点が含まれています。"
---
## **概要**

PPT はレガシーのバイナリ PowerPoint フォーマットで、PPTX は新しい Open XML フォーマットです。Aspose.Slides for Android via Java は Microsoft PowerPoint がなくても PPT ファイルを読み込み、PPTX として保存できます。この記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき事項を説明します。

## **PPT ファイルを PPTX に変換する**

ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/) クラスで読み込み、次に [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/#Pptx) と共に呼び出します。`finally` ブロックはプレゼンテーションを破棄し、そのリソースを解放します。

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

ファイル拡張子だけでは出力フォーマットは選択されません。[SaveFormat.Pptx](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/saveformat/#Pptx) 引数がそれを指定します。元の PPT ファイルを保持する必要がある場合は、入力パスと出力パスを別々にしてください。

## **複数の PPT ファイルを変換する**

以下の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、変換に失敗してもバッチの残りは続行されます。

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

本番環境では、例外の全内容をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行またはレビューキューに書き込んでください。破損したファイル、必要なパスワードなしで開いたパスワード保護ファイル、アクセスできないパス、サポートされていないコンテンツはすべて変換失敗の原因となります。暗号化ファイルの読み込みについては [Password-Protected Presentations](/androidjava/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換は通常、スライド、マスター、レイアウト、テキスト、シェイプ、画像、テーブル、チャートを保持します。ただし、PPT と PPTX はすべての機能を完全に同一に表現できるわけではありません。PPTX に対応するものがなく、ライブラリでもサポートされていないレガシー機能は、正規化されたり、除外されたり、別の形で表示されたりすることがあります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、マイナーなフォント、VBA マクロが含まれる場合は確認してください。普通の PPTX ファイルはマクロ有効形式ではないため、VBA を保持する必要がある場合は適切なマクロ有効ワークフローを使用してください。また、変換されたプレゼンテーションが開かれるまたはレンダリングされる環境に必要なフォントや外部リソースが存在することも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、主要なスライド数やコンテンツを検査し、意図したビューアでの外観やスライドショーの動作と比較してください。成功した [Presentation.save](https://reference.aspose.com/slides/ja/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 呼び出しが、すべてのレガシー機能が正確に PPTX に変換されたことの証明になるとはみなさないでください。

## **PPTX を使用すべき時**

現在の PowerPoint バージョンで編集される、Open XML パッケージを扱うシステムとやり取りされる、またはレガシーのバイナリ PPT よりも検査や復元が容易な形式で保存される場合は PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブやロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS、またはその他の出力形式が必要な場合は、すべてのターゲットが編集可能な PowerPoint 機能を保持すると仮定せずに、[Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) の形式別ガイダンスを使用してください。

## **オンライン コンバータ**

たまにファイルを変換する、またはすばやく比較したい場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換やバッチ処理、アプリケーションレベルのエラーハンドリングが必要な場合は、Android via Java API を使用してください。

## **関連記事**

- [PPT と PPTX](/androidjava/ppt-vs-pptx/)
- [Android でプレゼンテーションを保存](/androidjava/save-presentation/)
- [サポートされているファイル形式](/androidjava/supported-file-formats/)
- [Android でプレゼンテーションを開く](/androidjava/open-presentation/)

## **よくある質問**

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Android via Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルの読み込みと保存が可能です。

**PPT から PPTX への変換はすべてのコンテンツを正確に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能や未サポート機能が正確に再現される保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特殊なアニメーション、マイナーなフォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルの読み込み時に正しいパスワードを提供すれば可能です。パスワードがない、または間違っていると読み込み操作は失敗します。

**変換後に PPT ファイルを削除すべきですか？**

重要なビューアやワークフローで PPTX を確認するまで、元のファイルは保持してください。レガシー機能が異なる形で変換された場合のロールバック コピーとして役立ちます。