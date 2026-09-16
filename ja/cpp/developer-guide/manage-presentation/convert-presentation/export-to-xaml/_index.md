---
title: C++でプレゼンテーションをXAMLにエクスポート
linktitle: プレゼンテーションからXAMLへ
type: docs
weight: 30
url: /ja/cpp/export-to-xaml/
keywords:
- PowerPointをエクスポート
- OpenDocumentをエクスポート
- プレゼンテーションをエクスポート
- PowerPointを変換
- OpenDocumentを変換
- プレゼンテーションを変換
- PowerPointからXAMLへ
- OpenDocumentからXAMLへ
- プレゼンテーションからXAMLへ
- PPTからXAMLへ
- PPTXからXAMLへ
- ODPからXAMLへ
- PPTをXAMLとして保存
- PPTXをXAMLとして保存
- ODPをXAMLとして保存
- PPTをXAMLにエクスポート
- PPTXをXAMLにエクスポート
- ODPをXAMLにエクスポート
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して C++ で PowerPoint と OpenDocument のスライドを XAML に変換します—レイアウトをそのまま保つ、迅速で Office 不要のソリューションです。"
---
## **概要**

この記事では、Aspose.Slides を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な概要、デフォルト設定でプレゼンテーションを XAML に保存する方法、および [XamlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/) を使用してエクスポートをカスタマイズする方法（非表示スライドのエクスポートを含む）を示します。また、フォントのフォールバック、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも回答します。

## **XAML について**

XAML は XML ベースのマークアップ言語で、WPF（Windows Presentation Foundation）、UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するために使用されます。

XAML ファイルはビジュアルデザイナーで操作することも、直接マークアップを記述・編集することもできます。

## **デフォルトオプションでプレゼンテーションを XAML にエクスポートする**

次の C++ サンプルは、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示しています。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

既定では、エクスポートされたスライドはプロセスのカレントディレクトリ（[Directory::GetCurrentDirectory](https://reference.aspose.com/slides/ja/cpp/system.io/directory/getcurrentdirectory/) が返す場所）の `pres` サブフォルダーに保存されます。フォルダーは自動的に作成され、必要な画像も同じフォルダーに保存されます。

出力フォルダー名は、拡張子を除いたソースファイル名から取得されます。たとえば `pres.pptx` の場合、出力ファイルは `pres/Slide_1.xaml`、`pres/Slide_2.xaml` という名前になります。入力プレゼンテーションに絶対パスを指定した場合でも、出力フォルダーはカレントディレクトリを基準に作成され、入力ファイルと同じ場所には作成されません。

## **カスタムオプションでプレゼンテーションを XAML にエクスポートする**

[IXamlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/ixamloptions/) インターフェイスを使用して、Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法を制御できます。

出力先をカスタマイズするには、[IXamlOutputSaver](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/ixamloutputsaver/) を実装し、そのインスタンスを [XamlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/) の [set_OutputSaver](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) メソッドに渡します。

非表示スライドを XAML 出力に含めるには、以下の C++ サンプルのように [set_ExportHiddenSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) メソッドに `true` を渡します。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **生成されたすべての XAML アーティファクトを取得する**

XAML エクスポートは、エクスポートされた各スライドごとに XAML 文書を生成し、個別の画像や補助リソースを出力します。デフォルトのファイルシステムセーバーの代わりにカスタム [IXamlOutputSaver](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/ixamloutputsaver/) を [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) に渡すことで、これらのアーティファクトを受け取れます。エクスポートは XAML 固有の [Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) オーバーロードを使用して開始します。

### **コールバックのライフサイクルを理解する**

エクスポーターは生成された各アーティファクトに対して [IXamlOutputSaver::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) を個別に呼び出します。

- `path` はアーティファクトを識別し、相対ディレクトリを含むことがあります。XAML が相対パスでリソースを参照する可能性があるため、この情報は保持してください。
- `data` はアーティファクトのバイト列です。画像やその他のバイナリリソースをテキストとしてデコードしないでください。
- セーバーはデータを保持または永続化した上で制御を戻す責任があります。サンプルでは各バイト配列をアプリケーション所有のメモリにコピーしています。
- プレゼンテーションの保存操作が完了し、すべてのコールバックが正常に終了したときだけエクスポートを成功と見なしてください。ストレージエラーを無視したり、バックグラウンド書き込みを開始したりしないでください。永続化が後続で行われる場合は、そのステップが成功した後に全体の成功を報告してください。

[ XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) はカスタムセーバーにも適用されます。デフォルト設定 `false` は非表示スライドの XAML 文書を除外します。`true` に設定すると、非表示スライドとそれらのエクスポートに必要なリソースが含まれます。リソース数はプレゼンテーションに依存するため、スライドごとに 1 回のコールバックがあると仮定したり、固定のコールバック順序を前提にしたりしないでください。

### **メモリにエクスポートしてアーティファクトを検査する**

以下の完全例は `pres.pptx` を読み込み、すべてのアーティファクトを [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/ja/cpp/system.collections.generic/dictionary/) に収集し、名前・型・バイト数を出力します。提供された名前は正確に保持されます。重複名があると、上書きせずにコレクションが失敗します。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // XAML のみをデコードし、テキストの検査が必要なときだけ実行します。
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

アプリケーションから `InMemoryXamlExample::Run` を呼び出してください。拡張子チェックは検査に便利です。すべてのアーティファクト（見慣れないリソース種別も含む）を保持し、バイト列は変更せずに保存または転送してください。テキスト処理が必要な XAML のみ、UTF-8 エンコーディングで [Encoding::GetString](https://reference.aspose.com/slides/ja/cpp/system.text/encoding/getstring/) を使用してください。

### **収集したアーティファクトを ZIP アーカイブにパッケージ化する**

この独立した例はエクスポートを収集し、名前を検証した上で元のバイト列を ZIP アーカイブに書き込みます。ユニークなアーカイブ名により同時実行エクスポートジョブが分離されます。ZIP エントリはスラッシュ（/）を使用し、相対ディレクトリ構造を保持します。正規化後に衝突する名前や安全でない名前は、書き込み前にパッケージ全体を拒否します。

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Save は ZIP ディレクトリを確定します。成功を報告する前にファイルを閉じます。
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

アプリケーションから `ZipXamlExample::Run` を呼び出してください。例は C++ ランタイムの `Aspose::Zip::ZipFile` を使用してローカルアーカイブを書き込んでいます。エクスポーター自体は緩い XAML や画像ファイルを書き出しません。リモートストレージ向けには、アーカイブ作成ステージを収集したバイト配列のアップロードに置き換えてください。エクスポートジョブ ID と完全な相対アーティファクト名をブロブキーとして使用するか、ジョブ ID、相対名、およびバイナリデータをデータベース行に格納してください。すべてのアップロードが完了または DB トランザクションがコミットされた後にジョブを公開し、永続化が失敗した場合は部分出力をクリーンアップしてください。

大規模なプレゼンテーションの場合、カスタムセーバーで各アーティファクトを直接アプリケーションストレージに永続化すれば、エクスポート全体をメモリに保持する必要がなくなります。エクスポーターはセーバー呼び出し前にすべてのアーティファクトをメモリに収集します。エクスポーターの観点からは各コールバックを同期的に扱い、バイトが受け入れられた後にのみ制御を戻し、失敗は呼び出し元に伝播させてください。

### **リソース名を保持し参照を検証する**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持してください。すべての生成名が一意でありリソース参照が有効であると確信できない限り、[Path::GetFileName](https://reference.aspose.com/slides/ja/cpp/system.io/path/getfilename/) のみを使用しないでください。
- 宛先固有の名前検証を実施します。緩いファイルを書き込む際は、ルートパスやトラバーサルセグメントを拒否し、[Path::GetFullPath](https://reference.aspose.com/slides/ja/cpp/system.io/path/getfullpath/) で宛先を解決し、意図したエクスポートディレクトリ以下に収まっていることを確認します。シンボリックリンクでリダイレクトされない、アプリケーション管理ディレクトリを使用してください。
- エクスポートジョブごとに別々のセーバーとストレージ名前空間を使用し、区切り文字正規化後や宛先の大文字小文字規則に従って衝突を検出してください。
- 公開前に各 XAML 文書を XML として解析し、`Source` や `ImageSource` 属性などのファイルベースのリソース参照を検査してください。各相対 URI を含む XAML アーティファクトのディレクトリに対して解決し、正規化されたストレージ名を得て、対応する辞書キー、ZIP エントリ、または保存オブジェクトが存在することを確認します。外部 URI や XAML マークアップ式は相対ファイル名とは別に扱います。

例として、`pres/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `pres/images/image1.png` として利用可能でなければなりません。単に `image1.png` だけを保持すると関係が壊れます。オブジェクトストレージの場合は、ジョブプレフィックス以下に同じレイアウトを保持し、これらのリソース URL を XAML コンシューマがアクセスできるようにしてください。完成した ZIP を再度開き、エントリ名とリソースバイトを検証し、対象 XAML 環境で代表スライドを読み込んで画像解決が正しく行われていることを確認してください。

## **FAQ**

**元のフォントがマシンに存在しない場合、フォントを確実に予測できるようにするにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/) の [set_DefaultRegularFont](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) を使用します。エクスポート時に元フォントが見つからない場合のフォールバックフォントとして使用されますが、生成された XAML が必ずフォールバックフォントを参照するか、ターゲットマシンにフォントが存在することを保証するものではありません。XAML が参照するフォントが表示環境に存在することを確認してください。

**エクスポートされた XAML は WPF のみを対象としていますか？それとも他の XAML スタックでも使用できますか？**

Aspose.Slides はパブリック API を通じて WPF 用 XAML をエクスポートします。UWP や Xamarin.Forms など他の XAML スタックとの互換性は保証されていません。対象環境で生成されたマークアップをテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにするにはどうすればよいですか？**

デフォルトでは非表示スライドは含まれません。 [XamlOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/) の [set_ExportHiddenSlides](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) でこの動作を制御できます。エクスポートが不要な場合は無効のままにしてください。