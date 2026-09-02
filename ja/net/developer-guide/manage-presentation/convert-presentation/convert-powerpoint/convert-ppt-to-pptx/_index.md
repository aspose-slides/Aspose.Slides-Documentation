---
title: .NET で PPT を PPTX に変換
linktitle: PPT から PPTX
type: docs
weight: 20
url: /ja/net/convert-ppt-to-pptx/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換、エラーハンドリング、正確性に関する注意点を含む C# サンプルが掲載されています。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint 形式であり、PPTX は新しい Open XML 形式です。Aspose.Slides for .NET は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本稿では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換**

ソースファイルは [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスでロードし、[IPresentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/save/) を [SaveFormat.Pptx](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) とともに呼び出します。`using` 宣言により、スコープが終了したときにプレゼンテーションが破棄され、リソースが解放されます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

// レガシー PPT プレゼンテーションをロードします。
using var presentation = new Presentation("presentation.ppt");

// プレゼンテーションを PPTX 形式で保存します。
presentation.Save("presentation.pptx", SaveFormat.Pptx);
```

ファイル拡張子だけでは出力形式は決まらず、[SaveFormat.Pptx](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveformat/) 引数で指定します。元の PPT ファイルを保持したい場合は、入力パスと出力パスを異なる場所に設定してください。

## **複数の PPT ファイルを変換**

以下のサンプルは、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは独立して処理されるため、1 つの変換が失敗してもバッチ全体は中断されません。

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var inputDirectory = "input";
var outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

foreach (var inputPath in Directory.EnumerateFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly))
{
    var outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pptx";
    var outputPath = Path.Combine(outputDirectory, outputFileName);

    try
    {
        using var presentation = new Presentation(inputPath);
        presentation.Save(outputPath, SaveFormat.Pptx);
        Console.WriteLine($"Converted: {inputPath}");
    }
    catch (Exception exception)
    {
        Console.Error.WriteLine($"Failed: {inputPath} ({exception.Message})");
    }
}
```

本番環境では、例外を完全にログに記録し、既存の出力ファイルを上書きして良いかを判断し、失敗したファイル名をリトライまたはレビューキューに書き込んでください。破損したファイル、必要なパスワードなしで開かれたパスワード保護ファイル、アクセスできないパス、サポートされていないコンテンツはすべて変換失敗の原因となります。暗号化されたファイルの読み込みについては、[Password-Protected Presentations](/slides/ja/net/password-protected-presentation/) を参照してください。

## **正確性とレガシー機能**

変換では通常、スライド、マスタ、レイアウト、テキスト、シェイプ、画像、表、チャートが保持されます。ただし、PPT と PPTX はすべての機能を同一に表現できるわけではありません。PPTX に対応するものがなく、ライブラリでもサポートされていないレガシー機能は、正規化されたり、省略されたり、別の形で表示されたりします。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、特殊なフォント、VBA マクロが含まれる場合は必ず確認してください。標準の PPTX はマクロ対応形式ではないため、VBA を保持する必要がある場合はマクロ対応のワークフローを使用してください。また、変換されたプレゼンテーションを開く・レンダリングする環境に、必要なフォントや外部リソースが揃っていることも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数やコンテンツなどの重要項目を検査し、意図したビューアでの外観やスライドショーの挙動と比較してください。[IPresentation.Save](https://reference.aspose.com/slides/ja/net/aspose.slides/ipresentation/save/) の呼び出しが成功したからといって、すべてのレガシー機能が正確に PPTX に変換されたことの証明とはみなさないでください。

## **PPTX を使用すべき時**

プレゼンテーションを現在の PowerPoint バージョンで編集する、Open XML パッケージを扱うシステムとやり取りする、またはレガシーなバイナリ PPT よりも検査・復元が容易な形式で保存する場合は PPTX を使用してください。変換後のプレゼンテーションが正確性チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS、または他の出力形式が必要な場合は、[Convert Presentations to Multiple Formats](/slides/ja/net/convert-presentation/) の形式別ガイドラインに従い、すべてのターゲットが編集可能な PowerPoint 機能を保持するとは限らないことを留意してください。

## **オンラインコンバーター**

たまにファイルを変換したり簡易比較を行う場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換やバッチ処理、アプリケーションレベルのエラーハンドリングが必要な場合は .NET API を使用してください。

## **関連記事**

- [PPT と PPTX の比較](/slides/ja/net/ppt-vs-pptx/)
- [.NET でプレゼンテーションを保存](/slides/ja/net/save-presentation/)
- [サポートされているファイル形式](/slides/ja/net/supported-file-formats/)
- [.NET でプレゼンテーションを開く](/slides/ja/net/open-presentation/)

## **FAQ**

**Microsoft PowerPoint をインストールせずに PPT を PPTX に変換できますか？**

はい。Aspose.Slides for .NET は Microsoft PowerPoint を必要とせずにプレゼンテーションファイルの読み込みと保存が可能です。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーションコンテンツは保持しますが、すべてのレガシー機能やサポートされていない機能が完全に同等に変換できる保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特殊なアニメーション、珍しいフォントが含まれる場合は生成されたファイルを確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ファイルをロードする際に正しいパスワードを指定すれば変換可能です。パスワードが不足または誤っているとロードに失敗します。

**変換後に PPT ファイルを削除すべきですか？**

元の PPT を、PPTX がビューアやワークフローで確認・検証できるまで保持してください。これにより、レガシー機能が異なる結果になる場合のロールバックコピーが確保できます。