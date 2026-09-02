---
title: C++ で PPT を PPTX に変換する
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

PPT はレガシーなバイナリ PowerPoint 形式であり、PPTX は新しい Open XML 形式です。Aspose.Slides for C++ は Microsoft PowerPoint を使用せずに PPT ファイルを読み込み、PPTX として保存できます。本記事では、単一ファイルまたはディレクトリ内のファイルを変換する方法と、変換後に確認すべき項目について説明します。

## **PPT ファイルを PPTX に変換する**

ソース ファイルを [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスで読み込み、[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) に [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) を指定して呼び出します。使用しなくなったらプレゼンテーションを破棄し、リソースを解放してください。

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

ファイル拡張子だけでは出力形式は決まりません。実際に使用するのは [SaveFormat::Pptx](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) 引数です。元の PPT ファイルを残す必要がある場合は、入力パスと出力パスを異なる場所に設定してください。

## **複数の PPT ファイルを変換する**

次の例は、あるディレクトリ内のすべての `.ppt` ファイルを変換します。各ファイルは独立して処理されるため、1 つの変換失敗がバッチ全体を停止させることはありません。

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

本番環境では、例外の完全な情報をログに記録し、既存の出力ファイルを上書きしてよいか判断し、失敗したファイル名を再試行またはレビュー用キューに書き出すことを推奨します。破損したファイル、必要なパスワードがないまま開いたパスワード保護ファイル、アクセスできないパス、サポートされていないコンテンツはすべて変換失敗の原因となります。暗号化されたファイルの読み込み方法については、[Password-Protected Presentations](/slides/ja/cpp/password-protected-presentation/) を参照してください。

## **忠実度とレガシー機能**

変換は通常、スライド、マスタ、レイアウト、テキスト、シェイプ、画像、テーブル、チャートを保持します。ただし、PPT と PPTX はすべての機能を同一に表現できるわけではありません。PPTX に相当するものがないレガシー機能や、ライブラリでサポートされていない機能は正規化、除外、または別の方式で表示される可能性があります。

変換後のファイルにアニメーション、トランジション、埋め込みまたはリンクされた OLE オブジェクト、ActiveX コントロール、埋め込みメディア、希少フォント、VBA マクロが含まれる場合は必ず確認してください。純粋な PPTX はマクロ対応形式ではないため、VBA を残す必要がある場合はマクロ対応のワークフローを使用してください。また、変換先のプレゼンテーションが開かれるまたはレンダリングされる環境に、必要なフォントや外部リソースが揃っていることも確認してください。

重要なドキュメントについては、生成された PPTX をプログラムから再度開き、スライド数や主要コンテンツを検査したうえで、対象ビューアでの外観やスライドショー動作を比較してください。[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) が成功したからといって、すべてのレガシー機能が完全に PPTX に変換されたことの証明にはなりません。

## **PPTX を使用すべき時**

プレゼンテーションを最新の PowerPoint で編集する、Open XML パッケージを扱うシステムとやり取りする、あるいはレガシーなバイナリ PPT よりも検査や復元が容易な形式で保存したい場合は PPTX を使用してください。変換されたプレゼンテーションが忠実度チェックを通過するまで、元の PPT をアーカイブまたはロールバック用のコピーとして保持しておきます。

PDF、HTML、画像、XPS など別の出力形式が必要な場合は、[Convert Presentations to Multiple Formats](/slides/ja/cpp/convert-presentation/) の形式別ガイダンスに従い、すべてのターゲットが編集可能な PowerPoint 機能を保持するわけではないことを前提にしてください。

## **オンライン コンバータ**

たまにファイルを変換したり、簡単に比較したりしたい場合は、[online PPT to PPTX converter](https://products.aspose.app/slides/ja/conversion/ppt-to-pptx) を利用できます。繰り返しの変換、バッチ処理、またはアプリケーションレベルのエラーハンドリングが必要な場合は、C++ API を使用してください。

## **関連記事**

- [C++ でプレゼンテーションを保存する](/slides/ja/cpp/save-presentation/)
- [サポートされているファイル形式](/slides/ja/cpp/supported-file-formats/)
- [C++ でプレゼンテーションを開く](/slides/ja/cpp/open-presentation/)

## **よくある質問**

**Microsoft PowerPoint がインストールされていなくても PPT を PPTX に変換できますか？**

はい。Aspose.Slides for C++ は Microsoft PowerPoint を必要とせずにプレゼンテーション ファイルを読み込み、保存できます。

**PPT から PPTX への変換はすべてのコンテンツを完全に保持しますか？**

一般的なプレゼンテーション コンテンツは保持されますが、すべてのレガシー機能やサポート外の機能が正確に変換される保証はありません。マクロ、OLE や ActiveX オブジェクト、メディア、特殊なアニメーション、希少フォントが含まれる場合は生成されたファイルを必ず確認してください。

**パスワード保護された PPT ファイルを変換できますか？**

はい、読み込み時に正しいパスワードを指定すれば変換できます。パスワードが不足している、または誤っている場合は読み込みが失敗します。

**変換後に PPT ファイルを削除すべきですか？**

元の PPT は、変換後の PPTX が使用するビューアやワークフローで問題なく動作することを確認するまで保持してください。これにより、レガシー機能が異なる形で変換された場合にロールバックできるコピーが残ります。