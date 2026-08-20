---
title: C++ で PPT を PPTX に変換
linktitle: PPT から PPTX へ
type: docs
weight: 20
url: /ja/cpp/convert-ppt-to-pptx/
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
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ でレガシー PPT ファイルを PPTX に変換します。単一ファイルおよびバッチ変換の C++ サンプル、エラーハンドリング、忠実度に関する注意点を含みます。"
---
## **概要**

PPT はレガシーなバイナリ PowerPoint 形式で、PPTX は新しい Open XML 形式です。Aspose.Slides for C++ は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。この記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき点を説明します。

## **PPT ファイルを PPTX に変換する**

ソース ファイルは[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスでロードし、[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) を [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) と共に呼び出します。不要になったらプレゼンテーションを破棄してリソースを解放してください。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Load the legacy PPT presentation.
auto presentation = System::MakeObject<Presentation>(u"presentation.ppt");

// Save the presentation in PPTX format.
presentation->Save(u"presentation.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

ファイル拡張子だけで出力形式が決まるわけではなく、[SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) 引数がそれを指定します。元の PPT ファイルを残す必要がある場合は、入力パスと出力パスを別々にしてください。

## **複数の PPT ファイルを変換する**

次の例は、1 つのディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは独立して処理されるため、1 つの変換失敗がバッチ全体を停止させることはありません。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/object_ext.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

String inputDirectory = u"input";
String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto inputPaths = Directory::GetFiles(inputDirectory, u"*.ppt", SearchOption::TopDirectoryOnly);
for (const auto& inputPath : inputPaths)
{
    auto outputFileName = Path::GetFileNameWithoutExtension(inputPath) + u".pptx";
    auto outputPath = Path::Combine(outputDirectory, outputFileName);

    try
    {
        auto presentation = MakeObject<Presentation>(inputPath);
        presentation->Save(outputPath, SaveFormat::Pptx);
        presentation->Dispose();
        Console::WriteLine(String::Format(u"Converted: {0}", inputPath));
    }
    catch (Exception& exception)
    {
        Console::get_Error()->WriteLine(String::Format(u"Failed: {0} ({1})", inputPath, exception->get_Message()));
    }
}
```

本番環境では、例外全文をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行またはレビュー キューに書き出してください。破損ファイルやパスワード保護されたファイルをパスワードなしで開くケース、アクセス不能なパス、サポートされていないコンテンツはすべて変換失敗の原因となります。暗号化ファイルの読み込み方法については[Password-Protected Presentations](/cpp/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換では通常、スライド、マスター、レイアウト、テキスト、シェイプ、画像、テーブル、チャートが保持されます。ただし、PPT と PPTX はすべての機能を同一の方法で表現できるわけではありません。PPTX に対応する等価物がないレガシー機能や、ライブラリでサポートされていない機能は正規化、除外、または異なる表示になることがあります。

アニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、特殊フォント、VBA マクロを含む場合は、変換後のファイルを必ず確認してください。標準の PPTX はマクロ対応形式ではないため、VBA を使用し続ける必要がある場合は、適切なマクロ対応ワークフローを利用してください。また、変換されたプレゼンテーションを開く環境に必要なフォントや外部リソースが揃っていることも確認してください。

重要な文書については、生成された PPTX をプログラムから再度開き、スライド数や主要コンテンツを検査し、意図したビューアでの外観とスライドショー 動作を比較してください。[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) の呼び出しが成功したからといって、すべてのレガシー機能が完全に PPTX に変換されたという証拠にはなりません。

## **PPTX を使用すべきとき**

プレゼンテーションを最新の PowerPoint 版で編集したり、Open XML パッケージを扱うシステムとやり取りしたり、レガシーなバイナリ PPT よりも検査や復元が容易な形式で保存したりする場合は PPTX を使用してください。変換後のプレゼンテーションが忠実度チェックを通過するまで、元の PPT はアーカイブまたはロールバック用のコピーとして保持してください。

PDF、HTML、画像、XPS など別の出力形式が必要な場合は、[Convert Presentations to Multiple Formats](/cpp/convert-presentation/) に記載された形式別ガイダンスに従い、すべてのターゲットが編集可能な PowerPoint 機能を保持する前提で変換しないでください。

## **オンラインコンバータ**

たまにファイルを変換したり簡単に比較したりする場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返し変換やバッチ処理、アプリケーションレベルのエラー処理が必要な場合は C++ API を使用してください。

## **関連記事**

- [C++ でプレゼンテーションを保存する](/cpp/save-presentation/)
- [サポートされているファイル形式](/cpp/supported-file-formats/)
- [C++ でプレゼンテーションを開く](/cpp/open-presentation/)

## **FAQ**

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for C++ は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルを読み込み・保存できます。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能や未サポート機能が正確に再現される保証はありません。マクロ、OLE または ActiveX オブジェクト、メディア、特殊なアニメーション、特殊フォントが含まれる場合は、生成されたファイルを必ず確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、ロード時に正しいパスワードを指定すれば変換できます。パスワードが不足しているか誤っていると、ロード操作は失敗します。

**変換後に PPT ファイルを削除すべきですか？**

元のファイルは、対象のビューアやワークフローで PPTX を検証し終えるまで保持してください。レガシー機能が異なる形で変換された場合にロールバックできるコピーとして残しておくことが重要です。