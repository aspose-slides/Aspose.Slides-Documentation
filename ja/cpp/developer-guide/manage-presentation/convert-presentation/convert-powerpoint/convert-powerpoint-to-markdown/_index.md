---
title: C++ で PowerPoint プレゼンテーションを Markdown に変換
linktitle: PowerPoint を Markdown に変換
type: docs
weight: 140
url: /ja/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- スライドを変換
- PPT を変換
- PPTX を変換
- PowerPoint を MD に変換
- プレゼンテーションを MD に変換
- スライドを MD に変換
- PPT を MD に変換
- PPTX を MD に変換
- PowerPoint を Markdown として保存
- プレゼンテーションを Markdown として保存
- スライドを Markdown として保存
- PPT を MD として保存
- PPTX を MD として保存
- PPT を MD にエクスポート
- PPTX を MD にエクスポート
- Markdown 画像エクスポート
- CDN 画像リンク
- PowerPoint
- プレゼンテーション
- Markdown
- C++
- Aspose.Slides
description: "C++ で PPT および PPTX プレゼンテーションを Markdown に変換し、エクスポートされたビットマップ、メタファイル、SVG 画像の保存場所と参照先を制御します。"
---
## **概要**

Aspose.Slides for C++ は PPT と PPTX プレゼンテーションを Markdown に変換でき、ドキュメント作成、静的サイト、コンテンツ移行、バージョン管理のワークフローで使用できます。Markdown のフレーバーを選択したり、スライドコンテンツの描画方法を制御したり、エクスポートされた画像の保存場所や生成された Markdown がそれらを参照する方法を決定したりできます。

既定では、Markdown エクスポートはテキストのみの出力を使用します。ビジュアルコンテンツをエクスポートするには、[MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) メソッドを [MarkdownExportType](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownexporttype/) 列挙体の `Sequential` または `Visual` 値に設定します。`Sequential` はスライド項目を個別かつ順番通りにレンダリングし、`Visual` はグループ化された項目を一緒に保持して視覚的な関係を保ちます。`TextOnly` 値は画像リソースを出力しないため、このモードでは画像保存イベントは呼び出されません。

## **プレゼンテーションを Markdown に変換**

ソースファイルは[Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスでロードし、次に[Presentation::Save](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/save/) メソッドを呼び出して、[SaveFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/saveformat/) 列挙体の `Md` 値を指定します。

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **Markdown フレーバーの選択**

[MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) メソッドは出力に使用する Markdown 仕様を制御します。[Flavor](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/flavor/) 列挙体には CommonMark、GitHub Flavored Markdown、その他のサポートされているバリアントが含まれます。

以下の例はプレゼンテーションを CommonMark としてエクスポートします:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **デフォルトのローカル保存動作で画像をエクスポート**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/) クラスはローカルに保存される画像を構成するための 2 つのメソッドを提供します：

- [set_BasePath](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) は Markdown ドキュメントとそのリソースのベースディレクトリを指定します。
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) は画像サブディレクトリを指定します。その既定値は `Images` です。

以下の例はビジュアルコンテンツをレンダリングし、画像を `output/assets` に書き込み、Markdown ドキュメントに相対画像参照を作成します:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

この動作はカスタム画像保存ハンドラが `false` を返したときのフォールバックとしても機能します。

## **画像保存と Markdown リンクをカスタマイズ**

Markdown エクスポート中に出力される非 SVG ビットマップおよびメタファイルリソースに対しては `MarkdownSaveOptions::ImageSaving` イベントを使用します。その [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) デリゲートは [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) オブジェクト、その [ImageFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imageformat/) および生成された Markdown リンクを `System::String&` パラメータとして受け取ります。指定された形式で画像を保存またはアップロードし、`link` を Markdown 出力に記載すべき参照に置き換えます。

SVG 形式で出力されるリソースは別途処理されます。`MarkdownSaveOptions::SvgImageSaving` イベントに登録し、その [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) デリゲートは [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) オブジェクトと `System::String& link` パラメータを受け取ります。SVG には `ImageFormat` 引数がないため、代わりに [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/get_svgdata/) メソッドから XML データを書き込むかアップロードします。エクスポートモードやビジュアルのグルーピングに応じて、ソースプレゼンテーションの SVG がラスタライズまたは他のコンテンツと結合されることがあり、その結果得られた非 SVG リソースは `ImageSaving` に渡されます。すべてのエクスポートされたビジュアルリソースにカスタム処理が必要な場合は両方のイベントに登録してください。

ハンドラの戻り値は画像を処理する側を決定します：

- ハンドラが画像を保存、アップロード、変換、またはその他の方法で処理し、`link` に有効な値を割り当てた後に `true` を返します。Aspose.Slides はその値を書き込み、デフォルトのローカル保存は行いません。
- `false` を返すと、Aspose.Slides がローカルに画像を保存し、[MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) と [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) に従ってリンクを生成します。

{{% alert color="warning" title="重要" %}}

`true` を返すハンドラは画像の責任を負います。有効で非空のリンクを割り当てずに `true` を返すと、`InvalidOperationException` が発生してエクスポートが失敗します。

{{% /alert %}}

### **画像を CDN オリジンディレクトリに保存し、外部 URL を使用**

以下の例は `cdn-origin/presentations/quarterly-report` をマウントまたは同期された CDN オリジンディレクトリとして扱います。各ハンドラは生成されたファイル名を取得し、画像をそのカスタムディレクトリに保存し、生成されたローカル参照を公開 CDN URL に置き換えます。サンプル自体はネットワークアップロードを行いません。URL はディレクトリが CDN オリジンとしてマウントされるか、ファイルが CDN に公開された後に有効になります。オブジェクトストレージを使用する場合は、ファイルシステムへの書き込みをストレージ SDK のアップロード操作に置き換え、アップロードが成功した後にのみ `link` に割り当てます。

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

ビットマップハンドラは 128 × 128 ピクセル未満の画像に対して意図的に `false` を返すため、Aspose.Slides はそれらの画像を既定の動作で `output/fallback-images` に保存します。サイズが大きいビットマップおよびメタファイル、SVG リソースはカスタムコードで処理されます。たとえば、生成されたローカル参照 `fallback-images/image1.png` は `https://cdn.example.com/presentations/quarterly-report/image1.png` に置き換えられます。ハンドラはファイルを書き込むときだけ OS 固有のパスを使用し、Markdown に書き込むリンクはスラッシュと URL エスケープされたファイル名を使用します。相対リンクを作成するときも同様に `/` を使用し、プラットフォーム固有のディレクトリ区切り文字は使用しません。

## **FAQ**

**ハンドラはラスタ画像と SVG 画像の両方を処理できますか？**

いいえ。ビットマップおよびメタファイルリソースには `MarkdownSaveOptions::ImageSaving` を、SVG として出力されるリソースには `MarkdownSaveOptions::SvgImageSaving` を使用してください。前者は [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) オブジェクトと [ImageFormat](https://reference.aspose.com/slides/ja/cpp/aspose.slides/imageformat/) を提供し、後者は SVG データを [ISvgImage::get_SvgData](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/get_svgdata/) で取得できる [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) オブジェクトを提供します。エクスポート中にラスタライズされたソース SVG は `ImageSaving` で処理されます。

**画像保存ハンドラが `false` を返した場合はどうなりますか？**

Aspose.Slides は既定のローカル保存動作を使用します。画像の保存場所と生成された参照は [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) と [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) によって制御されます。

**ハンドラは画像をローカルに保存せずに URL を提供できますか？**

はい。ハンドラは画像をオブジェクトストレージにアップロードするか別サービスに渡し、得られた URL を `link` に割り当てて `true` を返すことができます。ハンドラ自身が処理を完了する必要があり、`true` を返すと既定のローカル保存は行われません。

**ハンドラから `InvalidOperationException` がスローされるのはなぜですか？**

ハンドラが `true` を返したにもかかわらず有効なリンクを提供しなかったときにこの例外が発生します。`true` を返す前に、Markdown に書き込むべき相対パスまたは外部 URL を `link` に設定してください。

**画像リンクはどのパス区切り文字を使用すべきですか？**

Markdown リンクと URL ではスラッシュ（/）を使用します。ファイルシステムパスの構築には `Path::Combine` を使用し、Markdown 参照は別途作成または正規化してください。

**Markdown エクスポート時にハイパーリンクは保持されますか？**

はい。テキストの[ハイパーリンク](/slides/ja/cpp/manage-hyperlinks/)は標準的な Markdown リンクとして保持されます。スライドの[トランジション](/slides/ja/cpp/slide-transition/)や[アニメーション](/slides/ja/cpp/powerpoint-animation/)は変換されません。

**プレゼンテーションを並列で Markdown に変換できますか？**

異なるプレゼンテーション ファイルを並列に処理できますが、同一の[Presentation]インスタンスをスレッド間で共有しないでください。[マルチスレッド ガイドライン](/slides/ja/cpp/multithreading/)に従い、ファイルごとに別々のインスタンスを使用してください。