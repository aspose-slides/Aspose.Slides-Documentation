---
title: C++ でプレゼンテーションの警告を処理する
type: docs
weight: 70
url: /ja/cpp/presentation-warnings/
aliases:
- /cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 警告コールバック
- 警告ポリシー
- データ損失
- ソース破損
- 互換性問題
- フォント置換
- デジタル署名
- プレゼンテーションの読み込み
- プレゼンテーションのレンダリング
- プレゼンテーションの変換
- プレゼンテーションの保存
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用してプレゼンテーションを読み込み、レンダリング、変換、保存する際に、警告を収集・分類・対処する方法を学びます。"
---
## **概要**

Aspose.Slides は、プレゼンテーションの読み込み、レンダリング、変換、または保存中に回復可能な問題を報告できます。例として、破損したソースレコード、保存できないコンテンツ、フォント置換、ターゲット形式の制限などがあります。警告コールバックを使用すると、アプリケーションはこれらの状態を記録し、現在の操作を継続できるかどうかを判断できます。

[IWarningCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides.warnings/iwarningcallback/) インターフェイスを実装し、[IWarningInfo::get_WarningType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) と [IWarningInfo::get_Description](https://reference.aspose.com/slides/ja/cpp/aspose.slides.warnings/iwarninginfo/get_description/) メソッドで提供される情報を確認します。警告を受け入れる場合は [ReturnAction::Continue](https://reference.aspose.com/slides/ja/cpp/aspose.slides.warnings/returnaction/) を、操作を中止する場合は `ReturnAction::Abort` を返します。

プレゼンテーションの読み込み時に発生する警告には [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides/loadoptions/set_warningcallback/) を使用します。レンダリングおよびエクスポートオプションクラスは [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveoptions/set_warningcallback/) を継承しており、スライドのレンダリング、変換、保存時の警告を受け取ります。警告自体はアプリケーションの操作を特定しないため、結合レポートを作成する際は各コールバックインスタンスに操作ステージを関連付けてください。

## **警告と例外**

警告は、コールバックが `ReturnAction::Continue` を返した場合に Aspose.Slides が回復できる状態を表します。例外は要求された操作が正常に完了できないことを意味し、例外は警告に変換されず、警告ポリシーで処理することはできません。

`ReturnAction::Abort` を返すと、警告ディスパッチャは例外をスローして現在の操作を終了させます。スローされる例外は操作およびプレゼンテーション形式に依存します。たとえば、読み込み時には [PptxReadException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxreadexception/) や [PptReadException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptreadexception/) が発生し、保存またはエクスポート時には [PptxException](https://reference.aspose.com/slides/ja/cpp/aspose.slides/pptxexception/) が発生する可能性があります。操作の境界で例外を捕捉し、警告レポートを使用してアプリケーションポリシーが終了の原因であるかを判断してください。コールバックは `ReturnAction::Abort` を返す前に警告を記録するため、理由はアプリケーションに引き続き提供されます。

## **警告のカテゴリ**

[WarningType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.warnings/warningtype/) 列挙体は以下のカテゴリを提供します。

| 警告タイプ | 意味 | 典型的なポリシー |
| --- | --- | --- |
| `SourceFileCorruption` | ソースプレゼンテーションに破損が含まれており、元の形式で保存されたドキュメントが使用不能になる可能性があります。 | 中止 |
| `DataLoss` | 読み込みまたは保存後にテキスト、チャート、画像などのデータが欠落している可能性があります。 | 中止 |
| `MajorFormattingLoss` | 重要な書式情報が失われる可能性があります。 | 厳密な検証モードでは中止、それ以外は記録して継続 |
| `MinorFormattingLoss` | 限定的な書式差異が発生する可能性があります。 | 診断用に記録し継続 |
| `CompatibilityIssue` | 結果が一部のアプリケーションや旧バージョンで正しく開けない、または正しく動作しない可能性があります。 | 必要でなければログに記録して継続 |
| `UnexpectedContent` | ソースに未サポートまたは未認識のコンテンツが含まれており、その影響が不明です。 | 記録して継続、または厳格なポリシーではエラーとして扱う |

カテゴリはポリシー判断の指針となります。診断のために警告の説明は保存してください。ただし、メッセージテキストは警告シナリオや製品バージョンにより変わるため、アプリケーションロジックでその文言に依存しないでください。

## **警告の収集と分類**

以下の例は、全体の処理パイプライン用に 1 つのアプリケーションレベルレポートを使用します。個別のコールバックインスタンスが読み込み、レンダリング、PDF 変換、PPTX 保存からの警告にラベル付けします。ポリシーはソース破損またはデータ損失で中止し、必要に応じて主要な書式損失でも中止し、他の警告は継続します。

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

主要な書式差異が許容できる場合は `abortOnMajorFormattingLoss` を `false` に設定します。互換性の問題、軽微な書式損失、予期しないコンテンツは、操作が継続してもレポートに残ります。これらのカテゴリのいずれかをアプリケーションが拒否すべき場合は `WarningPolicy::GetAction` を拡張してください。

## **一般的な警告シナリオ**

警告はワークフローのさまざまな段階で発生する可能性があります。

- **デジタル署名:** 署名されたプレゼンテーションを読み込むと、処理中に署名が失われるという警告が出ることがあります。Aspose.Slides はこの `DataLoss` 状態を [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/) を通じて報告します。読み込み段階のコールバックでファイルを拒否するか、報告された損失を明示的に受け入れるかを決定できます。
- **フォント置換:** 利用できないフォントはスライドのレンダリングまたはエクスポート時に置換されます。フォント置換警告は `DataLoss` として報告されるため、上記の厳格なポリシーではアプリケーションが視覚的に許容できても中止します。この動作を確認するには、実行時に利用できないフォントでテキストが書かれたプレゼンテーションを使用してください。警告の説明に置換情報が含まれますので、必要なフォントを用意するか、[フォント置換ルール](/slides/ja/cpp/font-substitution/) を設定してから再試行してください。
- **未サポートまたは予期しないコンテンツ:** ローダーが認識できないプレゼンテーションレコードや機能に遭遇することがあります。そのような警告は `UnexpectedContent`、またはデータ・書式への影響が明らかな場合はより重大なカテゴリになることがあります。
- **形式の互換性:** 別のプレゼンテーション形式に保存すると、機能が省略されたり、一部のアプリケーションで動作が異なる結果になることがあります。たとえば、水平または垂直の描画ガイドが 8 本を超えるプレゼンテーションを旧版 PPT に保存すると `CompatibilityIssue` が報告されます。保存段階のコールバックで損失を記録して継続するか、すべてのガイドを保持する必要がある場合は拒否できます。
- **読み込み動作:** 読み込みオプションやレガシー動作も警告を生成します。例として、[IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/ja/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) は、廃止されたプレゼンテーションロック動作の使用を `CompatibilityIssue` として示します。

警告はソース文書、ターゲット形式、操作、Aspose.Slides のバージョンに依存します。すべてのファイルが警告を出すとは限らず、シナリオが必ずしも 1 つのカテゴリにだけマップされるわけでもないことに注意してください。

## **中止した操作の安全な取り扱い**

コールバックが `ReturnAction::Abort` を返した場合、ロードに失敗したオブジェクトを使用しないでください。また、レンダリングや保存の出力が完了していると想定しないでください。操作は出力ファイルを作成した直後、しかし完全に書き込みが終わる前に終了することがあります。

検証済みの結果は `validated-output.pptx` のような別パスに保存し、操作が正常に完了し、警告レポートがポリシーに合致し、出力が開いてチェックできることを確認してから既存のプレゼンテーションと置き換えてください。これにより、部分的または拒否された結果で有効なソースファイルを上書きするリスクを回避できます。

空の警告レポートは、すべてのソース機能が保存されたことを保証するものではありません。アプリケーションが要求する追加のコンテンツチェックやビジュアルチェックを実施してください。関連情報は [Open Presentations](/slides/ja/cpp/open-presentation/) と [Save Presentations](/slides/ja/cpp/save-presentation/) も参照してください。

## **FAQ**

**警告コールバックは Aspose.Slides のすべてのエラーを処理できますか？**

いいえ。回復可能な条件として警告が報告された場合にのみ処理できます。コールバックとは無関係に発生する例外は、ロード、レンダリング、変換、保存呼び出しを囲むアプリケーション側で処理する必要があります。

**`ReturnAction::Continue` を返すことで同一の出力が保証されますか？**

保証されません。処理を継続できるだけで、報告された状態によりデータ、書式、互換性の差異が生じる可能性があります。収集した警告タイプと説明を確認してください。

**アプリケーションは警告を発生させた操作をどのように特定できますか？**

各操作ごとにコールバックインスタンスを作成し、警告タイプと説明に加えてアプリケーション独自のステージ情報を保持します。例は上記のサンプルをご参照ください。