---
title: C++ を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/cpp/image/
keywords:
- 画像を追加
- 画像を追加
- ビットマップを追加
- 画像を置換
- 画像を置換
- Webから
- 背景
- PNGを追加
- JPGを追加
- SVGを追加
- 外部SVGリソース
- SVGリゾルバ
- リンクされたSVG画像
- SVGフォント
- EMFを追加
- WMFを追加
- TIFFを追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して、PowerPoint および OpenDocument の画像管理を合理化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---
## **はじめに**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPoint では、ファイル、インターネット、またはその他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides でもさまざまな方法でプレゼンテーション スライドに画像を追加できます。

{{% alert title="ヒント" color="info" %}} 
Aspose は、画像から素早くプレゼンテーションを作成できる無料コンバータ―、[JPEG to PowerPoint](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG to PowerPoint](https://products.aspose.app/slides/ja/import/png-to-ppt) を提供しています。 
{{% /alert %}} 

{{% alert title="情報" color="info" %}}
画像をピクチャ フレームとして追加したい場合—特にサイズ変更や効果の適用、標準の書式設定オプションを使用する予定がある場合は、[Picture Frame](/slides/ja/cpp/picture-frame/) をご覧ください。 
{{% /alert %}} 

{{% alert title="注記" color="warning" %}}
画像を別の形式に変換できます。以下のページをご参照ください: 変換 [image to JPG](https://products.aspose.com/slides/ja/cpp/conversion/image-to-jpg/)、[JPG to image](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-image/)、[JPG to PNG](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-png/)、[PNG to JPG](https://products.aspose.com/slides/ja/cpp/conversion/png-to-jpg/)、[PNG to SVG](https://products.aspose.com/slides/ja/cpp/conversion/png-to-svg/)、および [SVG to PNG](https://products.aspose.com/slides/ja/cpp/conversion/svg-to-png/)。 
{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的な形式の画像をサポートしています。

## **ローカルに保存された画像をスライドに追加する**

コンピューターに保存されている 1 つ以上の画像をプレゼンテーション スライドに追加できます。次の C++ サンプルコードは、画像をスライドに追加する方法を示しています。

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Web から画像をスライドに追加する**

スライドに追加したい画像がコンピューターに保存されていない場合、Web から直接追加できます。

次の C++ サンプルコードは、Web から画像をスライドに追加する方法を示しています。

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **スライド マスターに画像を追加する**

スライド マスターは、テーマやレイアウトなどの情報を保持し、マスターを使用するスライドに適用されます。スライド マスターに画像を追加すると、そのマスターに基づくすべてのスライドに画像が表示されます。

次の C++ サンプルコードは、スライド マスターに画像を追加する方法を示しています。

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **スライドの背景として画像を追加する**

1 つまたは複数のスライドの背景として画像を使用できます。詳細は *[Setting Images as Backgrounds for Slides](/slides/ja/cpp/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **SVG をプレゼンテーションに追加する**

SVG コンテンツは [SvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。生成された [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) オブジェクトは、プレゼンテーション画像コレクションに追加され、ピクチャ フレームの作成に使用できます。

次の C++ 例は、自己完結型 SVG 文字列をインポートします。SVG が使用するすべての画像、スタイル、その他のリソースは SVG コンテンツに直接埋め込まれています。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **外部リソースを含む SVG コンテンツのインポート**

デザイン ツール、ダイアグラム エディター、アイコン システム、Web パイプラインからエクスポートされた SVG ファイルは、SVG ドキュメントの外部に保存されたリソースを参照することがあります。たとえば、`images/photo.png` のような画像リンク、CSS の `url(...)` 値、またはフォント URL が含まれることがあります。

このような SVG コンテンツをインポートするには、[IExternalResourceResolver](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/iexternalresourceresolver/) 実装を作成し、ベース URI とともに適切な `SvgImage` コンストラクタに渡します。ベース URI は SVG ドキュメントの位置を示し、相対リンクの解決に使用されます。

[ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) インターフェイスは、インポートされた SVG に関する情報へのアクセスを提供します:

- `get_SvgContent()` は SVG マークアップを文字列として返します。
- `get_SvgData()` は SVG コンテンツをバイト配列として返します。
- `get_BaseUri()` は相対リンクに使用されたベース URI を返します。
- `get_ExternalResourceResolver()` は SVG 画像に割り当てられたリゾルバを返します。

### **外部リソース リゾルバの実装**

リゾルバには次の 2 つのメソッドがあります:

- [ResolveUri](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) はベース URI と相対リソースリンクを結合し、絶対 URI を返します。リンクを解決できない、または許可されていない場合は null 文字列を返してください。
- [GetEntity](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) は絶対リソース URI の読み取り可能なストリームを返します。リソースが存在しない、ブロックされている、または利用できない場合は `nullptr` を返してください。必要に応じてフォールバック ストリームを返すこともできます。

次のリゾルバは、許可されたローカル ディレクトリからのみリンクされたリソースを読み込みます。ネットワーク リソースや許可ディレクトリ外のパスはブロックされます。解決できない画像リンクにはオプションのフォールバック画像が返されます。

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // このリゾルバはローカルファイルのみを許可するよう意図されています。
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // 画像リソースに対してのみフォールバックを使用します。
        // 欠落したフォントやスタイルシートに対して画像ストリームを返すことは有効ではありません。
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **SVG インポート時のリンクされたリソースの解決**

`assets/diagram.svg` が次のような相対参照を含んでいるとします:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

次の C++ 例は、SVG ファイル URI をベース URI として渡し、カスタム リゾルバを提供します。リゾルバは相対画像リンクを絶対 URI に変換し、リンクされたリソースを含むストリームを返しながら Aspose.Slides が SVG を処理します。

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// ベース URI は SVG ドキュメントの位置を表します。
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage はソースコンテンツ、バイナリ データ、ベース URI、およびリゾルバを公開します。
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`SvgImage` クラスは、バイト配列またはストリームとして SVG データを受け取り、外部リソース リゾルバとベース URI を指定できるオーバーロードも提供します。

{{% alert title="重要" color="warning" %}}
リソース リゾルバは、Aspose.Slides が SVG を処理・レンダリング中に外部リソースを利用可能にしますが、元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。

`ISvgImage` がプレゼンテーション画像コレクションに追加されると、PPTX ファイルには元の SVG 表現とラスタ ランタイム用のフォールバック画像の両方が含まれる可能性があります。リンクされたリソースは生成されたフォールバック画像に現れますが、`images/photo.png` のような相対リンクは保存された SVG 内でそのまま保持されます。ネイティブ SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合にリンクされたコンテンツを省略することがあります。
{{% /alert %}}

### **ポータブル SVG ピクチャの作成**

外部ファイルに依存しない SVG ピクチャを作成するには、`SvgImage` を作成する前に SVG を自己完結型にしてください。たとえば、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なすべてのリソースが SVG コンテンツに埋め込まれたら、`SvgImage` を作成し、プレゼンテーション画像コレクションに追加し、前述の例と同様にピクチャ フレームに挿入します。

### **欠落またはブロックされたリソースの処理**

`ResolveUri` でリソース URI が無効、禁止、または解決不能な場合は null 文字列を返します。`GetEntity` でリソースが読み取れない場合は `nullptr` を返します。可能な限り、Aspose.Slides はそのリソースなしで SVG の処理を続行します。

欠落したリソースに対してフォールバック ストリームを返すことはできますが、その内容は要求されたリソースタイプに合致している必要があります。たとえば、画像が欠落している場合にのみ画像ストリームを返し、フォントやスタイルシートに対しては返さないでください。

{{% alert title="セキュリティ" color="warning" %}}
信頼できない SVG ファイルから任意のファイルパスや無制限のネットワーク URL を解決しないでください。許可されるスキーム、ディレクトリ、ホストを制限し、ネットワークリソースの場合は接続タイムアウト、応答サイズ制限、コンテンツ検証も適用してください。
{{% /alert %}}

## **SVG をシェイプのセットに変換する**
Aspose.Slides は、PowerPoint の同等機能と同様に、SVG をシェイプのセットに変換できます:

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/) インターフェイスの [AddGroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/) メソッドのオーバーロードで提供され、最初の引数に [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) オブジェクトを渡します。

次の C++ サンプルコードは、このメソッドを使用して SVG ファイルをシェイプのセットに変換する方法を示しています:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// ソース SVG ファイル名
auto svgFileName = System::String(u"sample.svg");

// 出力プレゼンテーション ファイル名
auto outPptxPath = System::String(u"presentation.pptx");

// 新しいプレゼンテーションを作成
auto presentation = System::MakeObject<Presentation>();

// SVG ファイルの内容を読み込む
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage オブジェクトを作成
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// スライドサイズを取得
auto slideSize = presentation->get_SlideSize()->get_Size();

// SVG 画像をシェイプのグループに変換し、スライドサイズに合わせてスケーリング
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// プレゼンテーションを PPTX 形式で保存
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **画像を EMF としてスライドに追加する**
Aspose.Slides for C++ は、Aspose.Cells で Excel ワークシートから EMF 画像を生成し、プレゼンテーション スライドに追加できます。

次の C++ サンプルコードは、その手順を示しています:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells for C++ は、その型が使用される前に起動する必要があります。
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// ワークシートを EMF としてレンダリングします。
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells はレンダリングされたページをバッファとして返し、Aspose.Slides はそれを画像として追加します。
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **画像コレクション内の画像を置換する**

Aspose.Slides は、プレゼンテーションの画像コレクションに保存されている画像（スライド シェイプが使用している画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新する複数の方法を説明します。生バイト データ、[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) インスタンス、またはコレクション内に既に存在する別の画像を使用して画像を置換できます。

手順は次のとおりです:

1. [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスを使用して画像を含むプレゼンテーション ファイルを読み込みます。
1. ファイルから新しい画像をバイト配列に読み込みます。
1. バイト配列を使用して対象画像を新しい画像に置換します。
1. 2 番目の方法では、画像を [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) オブジェクトに読み込み、そのオブジェクトで対象画像を置換します。
1. 3 番目の方法では、プレゼンテーションの画像コレクションに既に存在する画像で対象画像を置換します。
1. 修正されたプレゼンテーションを PPTX ファイルとして保存します。

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// プレゼンテーション ファイルを表す Presentation クラスのインスタンスを作成します。
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// 最初の方法。
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// 二番目の方法。
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// 三番目の方法。
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// プレゼンテーションをファイルに保存します。
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="情報" color="info" %}}
Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータ―を使用すれば、テキストをアニメーション化して GIF に簡単に変換できます。 
{{% /alert %}}

## **FAQ**

**挿入後、元の画像解像度はそのままですか？**

はい。元のピクセルは保持されますが、最終的な表示はスライド上の [picture](/slides/ja/cpp/picture-frame/) のスケーリング方法や保存時の圧縮に依存します。

**多数のスライドにわたって同じロゴを一括で置換する最良の方法は？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換すれば、該当リソースを使用しているすべての要素に自動的に反映されます。

**挿入した SVG を編集可能なシェイプに変換できますか？**

はい。SVG をシェイプのグループに変換でき、その後個々の部品は標準のシェイプ プロパティで編集可能になります。

**複数のスライドの背景に一括で画像を設定するには？**

マスタースライドまたは該当レイアウトで画像を背景として割り当てれば、そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。

**多数の画像でプレゼンテーションが大きくなりすぎるのを防ぐには？**

画像を重複せずに単一リソースを再利用し、解像度を適切に設定し、保存時に圧縮を適用し、必要に応じてマスターに繰り返し使用するグラフィックを配置してください。