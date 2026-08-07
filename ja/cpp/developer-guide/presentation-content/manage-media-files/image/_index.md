---
title: C++ を使用したプレゼンテーションの画像管理の最適化
linktitle: 画像の管理
type: docs
weight: 10
url: /ja/cpp/image/
keywords:
- 画像の追加
- ピクチャの追加
- ビットマップの追加
- 画像の置換
- ピクチャの置換
- Web から
- 背景
- PNG の追加
- JPG の追加
- SVG の追加
- 外部 SVG リソース
- SVG リゾルバ
- リンクされた SVG 画像
- SVG フォント
- EMF の追加
- WMF の追加
- TIFF の追加
- PowerPoint
- OpenDocument
- プレゼンテーション
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ を使用して PowerPoint および OpenDocument の画像管理を効率化し、パフォーマンスを最適化し、ワークフローを自動化します。"
---
## **はじめに**

画像はプレゼンテーションをより魅力的で視覚的に訴えるものにします。Microsoft PowerPointでは、ファイル、インターネット、またはその他のソースからスライドに画像を挿入できます。同様に、Aspose.Slides を使用すると、さまざまな方法でプレゼンテーション スライドに画像を追加できます。 

{{% alert title="Tip" color="primary" %}} 

Aspose は無料コンバータ—[JPEG から PowerPoint へ](https://products.aspose.app/slides/ja/import/jpg-to-ppt) と [PNG から PowerPoint へ](https://products.aspose.app/slides/ja/import/png-to-ppt)—を提供しており、画像からすばやくプレゼンテーションを作成できます。 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

画像をピクチャーフレームとして追加したい場合—特にサイズ変更やエフェクト適用、その他標準の書式設定オプションを使用する場合—は、[ピクチャーフレーム](/slides/ja/cpp/picture-frame/) を参照してください。 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

画像をある形式から別の形式に変換できます。以下のページをご覧ください: convert [画像をJPGに変換](https://products.aspose.com/slides/ja/cpp/conversion/image-to-jpg/), [JPGを画像に変換](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-image/), [JPGをPNGに変換](https://products.aspose.com/slides/ja/cpp/conversion/jpg-to-png/), [PNGをJPGに変換](https://products.aspose.com/slides/ja/cpp/conversion/png-to-jpg/), [PNGをSVGに変換](https://products.aspose.com/slides/ja/cpp/conversion/png-to-svg/), and [SVGをPNGに変換](https://products.aspose.com/slides/ja/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides は JPEG、PNG、BMP、GIF などの一般的なフォーマットの画像をサポートしています。 

## **ローカルに保存された画像をスライドに追加**

コンピュータに保存された画像を1枚または複数枚、プレゼンテーション スライドに追加できます。以下の C++ サンプルコードは、スライドに画像を追加する方法を示しています：

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



## **Web から画像をスライドに追加**

スライドに追加したい画像がコンピュータに保存されていない場合、Web から直接追加できます。 

以下の C++ サンプルコードは、Web から画像を取得してスライドに追加する方法を示しています：

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

## **スライドマスターに画像を追加**

スライドマスターは、使用するスライドのテーマやレイアウトなどの情報を保存・管理します。スライドマスターに画像を追加すると、そのマスターを基にしたすべてのスライドに画像が表示されます。 

以下の C++ サンプルコードは、スライドマスターに画像を追加する方法を示しています：

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

## **画像をスライドの背景として追加**

画像を1枚または複数枚のスライドの背景として使用できます。詳細については、*[スライドの背景として画像を設定](/slides/ja/cpp/presentation-background/#setting-images-as-background-for-slides)* を参照してください。

## **プレゼンテーションに SVG を追加**

SVG コンテンツは、[SvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/svgimage/) クラスを使用してプレゼンテーションに追加できます。結果として得られる [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) オブジェクトは、プレゼンテーションの画像コレクションに追加でき、ピクチャーフレームの作成に使用できます。 

以下の C++ の例は、自己完結型の SVG 文字列をインポートします。この SVG で使用されるすべての画像、スタイル、その他のリソースは、SVG コンテンツに直接埋め込まれます。

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

デザインツール、図表エディタ、アイコンシステム、Web パイプラインからエクスポートされた SVG ファイルは、SVG ドキュメントの外部に保存されたリソースを参照することがあります。例えば、SVG には `images/photo.png` のような画像リンクや、CSS の `url(...)` 値、フォントの URL が含まれることがあります。 

このような SVG コンテンツをインポートするには、[IExternalResourceResolver](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/iexternalresourceresolver/) の実装を作成し、ベース URI と共に適切な `SvgImage` コンストラクタに渡します。ベース URI は SVG ドキュメントの場所を示し、相対リンクの解決に使用されます。 

[ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) インターフェイスは、インポートされた SVG に関する情報へのアクセスを提供します: 

- `get_SvgContent()` は SVG のマークアップを文字列として返します。 
- `get_SvgData()` は SVG コンテンツをバイト配列として返します。 
- `get_BaseUri()` は相対リンクに使用されるベース URI を返します。 
- `get_ExternalResourceResolver()` は SVG 画像に割り当てられたリゾルバを返します。 

### **外部リソースリゾルバの実装**

リゾルバには 2 つのメソッドがあります。 

- [ResolveUri](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) はベース URI と相対リソースリンクを結合し、絶対 URI を返します。リンクを解決できない、または許可されていない場合は null 文字列を返します。 
- [GetEntity](https://reference.aspose.com/slides/ja/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) は絶対リソース URI の読み取り可能なストリームを返します。リソースが存在しない、ブロックされている、または利用できない場合は `nullptr` を返します。必要に応じて代替ストリームを返すこともできます。 

以下のリゾルバは、許可されたローカルディレクトリからのみリンクされたリソースを読み込みます。ネットワークリソースや許可ディレクトリ外のパスはブロックされます。解決できない画像リンクにはオプションで代替画像が返されます。

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

        // このリゾルバは意図的にローカル ファイルのみを許可します。
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

        // フォールバックは画像リソースに対してのみ使用します。画像ストリームを返す
        // 欠落したフォントやスタイルシートに対しては有効ではありません。
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

### **SVG インポート時のリンクリソースの解決**

`assets/diagram.svg` に次のような相対参照が含まれているとします: 

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

以下の C++ の例は、SVG ファイルの URI をベース URI として渡し、カスタムリゾルバを提供します。リゾルバは相対画像リンクを絶対 URI に変換し、Aspose.Slides が SVG を処理している間にリンクされたリソースを含むストリームを返します。 

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

// ベース URI は SVG ドキュメントの場所を表します。
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage はソースコンテンツ、バイナリデータ、ベース URI、リゾルバを公開します。
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

`SvgImage` クラスは、SVG データをバイト配列またはストリームとして受け取り、外部リソースリゾルバとベース URI を指定できるオーバーロードも提供します。 

{{% alert title="Important" color="warning" %}}

リソースリゾルバは、Aspose.Slides が SVG を処理・レンダリングする間、外部リソースを利用可能にします。元の SVG マークアップを変更したり、解決されたリソースを自動的に埋め込んだりはしません。 

`ISvgImage` がプレゼンテーションの画像コレクションに追加されると、PPTX ファイルには元の SVG 表現とラスタライズされた代替画像の両方が含まれる可能性があります。リンクされたリソースは生成された代替画像に表示される一方、`images/photo.png` のような相対リンクは保存された SVG では変更されません。そのため、ネイティブ SVG 表現をレンダリングするアプリケーションは、元の外部リソースが利用できない場合にリンクされたコンテンツを省略することがあります。 

{{% /alert %}}

### **ポータブルな SVG 画像の作成**

外部ファイルに依存しない SVG 画像を作成するには、`SvgImage` を作成する前に SVG を自己完結型にします。例えば、リンクされた画像 URL を画像データを含む `data:` URI に置き換えます: 

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

必要なすべてのリソースが SVG コンテンツに埋め込まれたら、`SvgImage` を作成し、プレゼンテーションの画像コレクションに追加し、前の例と同様にピクチャーフレームに挿入します。 

### **欠損またはブロックされたリソースの処理**

`ResolveUri` では、リソース URI が無効、禁止、または解決できない場合に null 文字列を返します。`GetEntity` では、リソースを読み取れない場合に `nullptr` を返します。可能な限り、Aspose.Slides はそのリソースがなくても SVG の処理を続行します。 

欠損リソースに対して代替ストリームを返すことができますが、その内容は要求されたリソースタイプと互換性がある必要があります。例えば、フォントやスタイルシートではなく、欠損画像に対してのみ画像ストリームを返してください。 

{{% alert title="Security" color="warning" %}}

信頼できない SVG ファイルから任意のファイルパスや無制限のネットワーク URL を解決しないでください。許可されたスキーム、ディレクトリ、ホストを制限します。ネットワークリソースの場合、接続タイムアウト、応答サイズ制限、コンテンツ検証も適用してください。 

{{% /alert %}}

## **SVG を形状のセットに変換**

Aspose.Slides は、PowerPoint の同等機能と同様に、SVG を形状のセットに変換できます： 

![PowerPoint Popup Menu](img_01_01.png)

この機能は、[IShapeCollection](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/) インターフェイスの [AddGroupShape](https://reference.aspose.com/slides/ja/cpp/aspose.slides/ishapecollection/) メソッドのオーバーロードで提供され、最初の引数に [ISvgImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/isvgimage/) オブジェクトを受け取ります。 

以下の C++ サンプルコードは、このメソッドを使用して SVG ファイルを形状のセットに変換する方法を示しています： 

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

// SVG ファイルの内容を読み取る
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage オブジェクトを作成
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// スライドサイズを取得
auto slideSize = presentation->get_SlideSize()->get_Size();

// SVG 画像を形状のグループに変換し、スライドサイズに合わせてスケール
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// プレゼンテーションを PPTX 形式で保存
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **画像を EMF としてスライドに追加**

Aspose.Slides for C++ は、Aspose.Cells を使用して Excel ワークシートから EMF 画像を生成し、プレゼンテーション スライドに追加することができます。 

以下の C++ サンプルコードは、その手順を示しています： 

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

// Aspose.Cells for C++ は、そのタイプを使用する前に開始する必要があります。
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
    // Aspose.Cells はレンダリングされたページをバッファとして返し、Aspose.Slides がそれを画像として追加します。
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

## **画像コレクション内の画像を置換**

Aspose.Slides は、プレゼンテーションの画像コレクションに保存された画像（スライドのシェイプで使用されている画像を含む）を置換できます。このセクションでは、コレクション内の画像を更新するいくつかの方法を説明します。生のバイト データ、[IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) インスタンス、またはコレクション内にすでに存在する別の画像を使用して画像を置換できます。 

以下の手順に従ってください： 

1. 画像を含むプレゼンテーション ファイルを [Presentation](https://reference.aspose.com/slides/ja/cpp/aspose.slides/presentation/) クラスでロードします。 
2. ファイルから新しい画像をロードし、バイト配列に格納します。 
3. バイト配列を使用して対象画像を新しい画像に置換します。 
4. 2 番目の方法では、画像を [IImage](https://reference.aspose.com/slides/ja/cpp/aspose.slides/iimage/) オブジェクトにロードし、そのオブジェクトで対象画像を置換します。 
5. 3 番目の方法では、プレゼンテーションの画像コレクションにすでに存在する画像で対象画像を置換します。 
6. 変更したプレゼンテーションを PPTX ファイルとして書き出します。 

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

{{% alert title="Info" color="info" %}}

Aspose の無料 [Text to GIF](https://products.aspose.app/slides/ja/text-to-gif) コンバータを使用すれば、テキストを簡単にアニメーション化し、GIF を作成できます。 

{{% /alert %}}

## **よくある質問**

**挿入後も元の画像解像度は保持されますか？**

はい。ソースのピクセルは保持されますが、最終的な見た目はスライド上で [画像](/slides/ja/cpp/picture-frame/) がどのようにスケーリングされるかや、保存時に適用される圧縮に依存します。 

**多数のスライドで同じロゴを一括置換する最適な方法は何ですか？**

ロゴをマスタースライドまたはレイアウトに配置し、プレゼンテーションの画像コレクションで置換します。これにより、そのリソースを使用しているすべての要素に更新が反映されます。 

**挿入した SVG を編集可能な形状に変換できますか？**

はい。SVG を形状のグループに変換でき、その後個々のパーツは標準の形状プロパティで編集可能になります。 

**複数のスライドに同時に画像を背景として設定するにはどうすればよいですか？**

マスタースライドまたは該当レイアウトで [画像を背景として割り当て](/slides/ja/cpp/presentation-background/) すると、そのマスター/レイアウトを使用しているすべてのスライドが背景を継承します。 

**多数の画像が原因でプレゼンテーションが大きくなりすぎるのを防ぐには？**

画像を重複させずに単一リソースを再利用し、適切な解像度を選び、保存時に圧縮を適用し、繰り返し使用するグラフィックは可能な限りマスターに配置してください。