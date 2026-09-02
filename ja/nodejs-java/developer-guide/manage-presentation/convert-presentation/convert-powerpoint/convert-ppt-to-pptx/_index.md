---
title: Node.js で PPT を PPTX に変換
linktitle: PPT から PPTX
type: docs
weight: 20
url: /ja/nodejs-java/convert-ppt-to-pptx/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides を使用して Node.js でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換、エラーハンドリング、忠実度に関する注意点を示す JavaScript のサンプルを含みます。"
---
## **概要**

PPT はレガシーのバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for Node.js via Java は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本稿では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目を説明します。

## **PPT ファイルを PPTX に変換する**

[Presentation] クラスでソース ファイルを読み込み、[Presentation.save] を [SaveFormat.Pptx] とともに呼び出します。`finally` ブロックでプレゼンテーションを破棄し、リソースを解放します。

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// レガシー PPT プレゼンテーションをロードします。
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // プレゼンテーションを PPTX 形式で保存します。
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ファイル拡張子だけでは出力形式は決まらず、[SaveFormat.Pptx] 引数が形式を指定します。元の PPT ファイルを保持したい場合は、入力パスと出力パスを異なる場所にしてください。

## **複数の PPT ファイルを変換する**

以下の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは個別に処理されるため、1 つの変換が失敗してもバッチ全体が中断されません。

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

本番環境では、エラー全体をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行またはレビュー キューに書き込んでください。破損したファイル、必要なパスワードなしで開いたパスワード保護されたファイル、アクセスできないパス、サポートされていないコンテンツはすべて変換失敗の原因となります。暗号化されたファイルの読み込みについては、[Password-Protected Presentations](/nodejs-java/password-protected-presentation/) を参照してください。

## **忠実度とレガシ機能**

変換は通常、スライド、マスタ、レイアウト、テキスト、図形、画像、表、チャートを保持します。ただし、PPT と PPTX はすべての機能を同一に表現できるわけではありません。PPTX に対応するものがないレガシ機能や、ライブラリでサポートされていない機能は、正規化されたり、省略されたり、別の形で表示されたりする場合があります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、マイナー フォント、VBA マクロが含まれる場合は確認してください。通常の PPTX ファイルはマクロ対応形式ではないため、VBA を残す必要がある場合はマクロ対応のワークフローを使用してください。また、変換されたプレゼンテーションを開くまたはレンダリングする環境に、必須フォントや外部リソースが存在することも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数や主要コンテンツを検査し、目的のビューアでの外観やスライドショーの挙動と比較してください。成功した [Presentation.save] 呼び出しだけで、すべてのレガシ機能が正確に PPTX に変換されたとは限らないことに留意してください。

## **PPTX を使用すべきとき**

プレゼンテーションを最新の PowerPoint バージョンで編集したり、Open XML パッケージを扱うシステムとやり取りしたり、レガシのバイナリ PPT よりも検査・復元が容易な形式で保存したりする場合は PPTX を使用してください。変換後のプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS など別の出力形式が必要な場合は、すべての対象が編集可能な PowerPoint 機能を保持すると想定せず、[Convert Presentations to Multiple Formats](/nodejs-java/convert-presentation/) の形式別ガイダンスをご利用ください。

## **オンラインコンバータ**

たまにファイルを変換したり、手早く比較したりする場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換やバッチ処理、アプリケーションレベルのエラーハンドリングが必要な場合は、Node.js via Java API を使用してください。

## **関連記事**

- [PPT と PPTX](/nodejs-java/ppt-vs-pptx/)
- [Node.js でプレゼンテーションを保存する](/nodejs-java/save-presentation/)
- [サポートされているファイル形式](/nodejs-java/supported-file-formats/)
- [Node.js でプレゼンテーションを開く](/nodejs-java/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for Node.js via Java は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルの読み込みと保存を行えます。

**PPT から PPTX への変換はすべてのコンテンツを正確に保持しますか？**

一般的なプレゼンテーション コンテンツは保持しますが、すべてのレガシ機能やサポート外の機能が完全に同等に変換される保証はありません。マクロ、OLE や ActiveX オブジェクト、メディア、特殊なアニメーション、マイナーなフォントが含まれる場合は、生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルを読み込む際に正しいパスワードを指定すれば可能です。パスワードがない、または間違っている場合は読み込みに失敗します。

**変換後に PPT ファイルを削除すべきですか？**

重要なビューアやワークフローで PPTX を検証するまで、元のファイルは保持してください。レガシ機能の変換結果が異なる場合のロールバック用コピーとして役立ちます。