---
title: Node.js で PPT を PPTX に変換
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して Node.js でレガシーな PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換の JavaScript サンプル、エラーハンドリング、忠実度に関する注意事項を含みます。"
---
## **概要**

PPT は従来のバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for Node.js via Java は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目を説明します。

## **PPT ファイルを PPTX に変換**

ソース ファイルは [Presentation](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/) クラスで読み込み、[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) とともに呼び出します。`finally` ブロックはプレゼンテーションを破棄し、リソースを解放します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// レガシー PPT プレゼンテーションを読み込む。
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // プレゼンテーションを PPTX 形式で保存する。
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ファイル拡張子だけでは出力形式は決定されません。出力形式は [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/saveformat/) 引数で指定します。元の PPT ファイルを保持する必要がある場合は、入力パスと出力パスを異なる場所に設定してください。

## **複数の PPT ファイルを変換**

以下の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは独立して処理されるため、1 つの変換が失敗してもバッチ全体が中断されることはありません。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

本番環境では、エラー全体をログに記録し、既存の出力ファイルを上書きするかどうかを判断し、失敗したファイル名を再試行またはレビュー キューに書き出します。破損したファイル、必要なパスワードなしで開いたパスワード保護されたファイル、アクセスできないパス、サポートされていないコンテンツは、いずれも変換失敗の原因となります。暗号化ファイルの読み込みについては、[Password-Protected Presentations](/slides/ja/nodejs-java/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換では通常、スライド、マスタ、レイアウト、テキスト、図形、画像、表、チャートが保持されます。しかし、PPT と PPTX はすべての機能を全く同じ形で表現できるわけではありません。PPTX に対応するものがなく、かつライブラリでサポートされていないレガシー機能は、正規化されたり、省略されたり、別の形で表示されたりする可能性があります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、マイナーなフォント、VBA マクロが含まれる場合は、必ず確認してください。通常の PPTX ファイルはマクロ有効形式ではないため、VBA を保持する必要がある場合は、マクロ有効なワークフローを使用してください。また、変換されたプレゼンテーションが開かれるまたはレンダリングされる環境に、必要なフォントや外部リソースが存在することも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数や主要なコンテンツを検査し、対象のビューアでの見た目やスライドショーの挙動と比較してください。[Presentation.save](https://reference.aspose.com/slides/ja/nodejs-java/aspose.slides/presentation/#save) 呼び出しが成功したことを、すべてのレガシー機能が正確に PPTX に変換された証拠とみなさないでください。

## **PPTX を使用すべき場面**

現在の PowerPoint バージョンで編集する、Open XML パッケージを扱うシステムとやり取りする、またはレガシーなバイナリ PPT よりも検査や復元が容易な形式で保存する場合は、PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

代わりに PDF、HTML、画像、XPS、または他の出力形式が必要な場合は、すべての対象が編集可能な PowerPoint 機能を保持すると決めつけず、[Convert Presentations to Multiple Formats](/slides/ja/nodejs-java/convert-presentation/) にある形式別ガイダンスを参照してください。

## **オンライン コンバータ**

たまにファイルを変換する、または簡単に比較したい場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換やバッチ処理、アプリケーションレベルのエラーハンドリングが必要な場合は、Node.js via Java API を使用してください。

## **関連記事**

- [PPT と PPTX の違い](/slides/ja/nodejs-java/ppt-vs-pptx/)
- [Node.js でプレゼンテーションを保存](/slides/ja/nodejs-java/save-presentation/)
- [サポートされているファイル形式](/slides/ja/nodejs-java/supported-file-formats/)
- [Node.js でプレゼンテーションを開く](/slides/ja/nodejs-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Node.js via Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルを読み込み、保存できます。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能やサポートされていない機能が正確に保持される保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特殊なアニメーション、マイナーなフォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルを読み込む際に正しいパスワードを指定すれば変換できます。パスワードが無い、または誤っている場合は読み込みが失敗します。

**変換後に PPT ファイルを削除すべきですか？**

重要なビューアやワークフローで PPTX を確認するまで、元のファイルは保持してください。レガシー機能が異なる形で変換された場合のロールバック コピーとして役立ちます。