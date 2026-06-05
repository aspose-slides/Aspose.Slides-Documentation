---
title: 外部リンク画像でプレゼンテーションを HTML にエクスポート
type: docs
weight: 50
url: /ja/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
  - PowerPoint をエクスポート
  - OpenDocument をエクスポート
  - プレゼンテーションをエクスポート
  - スライドをエクスポート
  - PPT をエクスポート
  - PPTX をエクスポート
  - ODP をエクスポート
  - PowerPoint から HTML へ
  - OpenDocument から HTML へ
  - プレゼンテーションから HTML へ
  - スライドから HTML へ
  - PPT から HTML へ
  - PPTX から HTML へ
  - ODP から HTML へ
  - リンクされた画像
  - 外部リンクされた画像
  - リンクされたリソース
  - 外部リソース
  - C++
  - Aspose.Slides
description: "Aspose.Slides を使用して、PowerPoint および OpenDocument のプレゼンテーションを C++ で HTML にエクスポートし、画像やその他のリソースを外部リンクファイルとして保存します。"
---
## **概要**

既定では、Aspose.Slides はプレゼンテーションを単一の HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接埋め込まれます。これは 1 つのポータブルファイルが必要な場合に便利ですが、Web サイトや CMS、サーバー側の変換パイプラインにとって常に最適な形式というわけではありません。

外部リンクされたリソースを使用したい場合は、次の目的で：
- HTML ドキュメントのサイズを削減する;
- ブラウザーや CDN で画像、フォント、オーディオ、ビデオを個別にキャッシュする;
- エクスポート後に生成されたリソースを検査、置換、圧縮、またはポストプロセスする;
- 出力構造を Web アプリケーションが期待する形に近づける。

一般的な HTML 変換ワークフローについては、[PowerPoint プレゼンテーションを HTML に変換](/slides/ja/cpp/convert-powerpoint-to-html/) を参照してください。この記事はエクスポート時のリソースリンク部分に焦点を当てています。

## **外部リンクリソースのエクスポート方法**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/) は、アプリケーションがリソースごとに、エクスポート時にデータを HTML に埋め込むか外部に保存してリンクを書き込むかを決定できるようにします。

このインターフェイスには 3 つのメソッドがあります：
- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) は、リソースをリンクするか埋め込むかを決定します。
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) は、生成された HTML または別のリンクリソースに書き込まれる URL を返します。
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) は、リンクされたリソースデータをディスクまたは別のストレージ先に書き込みます。

ファイルシステムのパスとブラウザーの URL は別々に扱われます。たとえば、以下のサンプルはリソースファイルをディスク上の `html-output/assets` に書き込み、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザーはリンクを含むファイルに対して相対的にこれらの URL を解決します。したがって、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` を使用し、同じ `assets` フォルダーに保存された画像へのリンクは SVG ファイル内で `resource-4.jpg` を使用します。

## **リンクされたリソースで HTML をエクスポート**

以下の C++ の例は、出力ディレクトリを作成し、HTML ファイルをその中に保存し、リンクされたリソースを `assets` サブディレクトリに格納します。コントローラーは、Aspose.Slides が安全なファイル拡張子を提供または推測できる場合、一般的な画像、フォント、オーディオ、ビデオ、CSS リソースにリンクします。認識できないリソースは埋め込まれたままです。

```cpp
class ExternalResourceController : public ILinkEmbedController
{
public:
    ExternalResourceController(String assetDirectory, String assetUrlPrefix)
    {
        if (IsNullOrWhiteSpace(assetDirectory))
        {
            throw Exception(u"The asset output directory must not be empty.");
        }

        m_assetDirectory = assetDirectory;
        m_assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
        m_fileNamesByResourceId = MakeObject<Dictionary<int, String>>();
    }

    LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        ArrayPtr<uint8_t> entityData,
        String semanticName,
        String contentType,
        String recommendedExtension) override
    {
        auto extension = ResolveExtension(contentType, recommendedExtension);
        if (String::IsNullOrEmpty(extension))
        {
            return LinkEmbedDecision::Embed;
        }

        auto fileName = String::Format(u"resource-{0}{1}", resourceId, extension);
        m_fileNamesByResourceId->Add(resourceId, fileName);
        return LinkEmbedDecision::Link;
    }

    String GetUrl(int resourceId, int referrer) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            return nullptr;
        }

        if (m_fileNamesByResourceId->ContainsKey(referrer))
        {
            return fileName;
        }

        return m_assetUrlPrefix + fileName;
    }

    void SaveExternal(int resourceId, ArrayPtr<uint8_t> entityData) override
    {
        String fileName;
        if (!m_fileNamesByResourceId->TryGetValue(resourceId, fileName))
        {
            auto message = String::Format(u"Resource {0} was not registered for external storage.", resourceId);
            throw Exception(message);
        }

        if (entityData == nullptr || entityData->get_Length() == 0)
        {
            auto message = String::Format(u"Resource {0} contains no data and cannot be saved.", resourceId);
            throw Exception(message);
        }

        Directory::CreateDirectory_(m_assetDirectory);

        auto filePath = Path::Combine(m_assetDirectory, fileName);
        auto fileStream = MakeObject<FileStream>(filePath, FileMode::Create, FileAccess::Write);
        fileStream->Write(entityData, 0, entityData->get_Length());
        fileStream->Close();
    }

private:
    String m_assetDirectory;
    String m_assetUrlPrefix;
    SharedPtr<Dictionary<int, String>> m_fileNamesByResourceId;

    static SharedPtr<Dictionary<String, String>> GetExtensionsByContentType()
    {
        auto extensionsByContentType = MakeObject<Dictionary<String, String>>();
        extensionsByContentType->Add(u"image/jpeg", u".jpg");
        extensionsByContentType->Add(u"image/png", u".png");
        extensionsByContentType->Add(u"image/gif", u".gif");
        extensionsByContentType->Add(u"image/bmp", u".bmp");
        extensionsByContentType->Add(u"image/svg+xml", u".svg");
        extensionsByContentType->Add(u"image/tiff", u".tiff");
        extensionsByContentType->Add(u"image/x-emf", u".emf");
        extensionsByContentType->Add(u"image/x-wmf", u".wmf");
        extensionsByContentType->Add(u"font/woff", u".woff");
        extensionsByContentType->Add(u"font/woff2", u".woff2");
        extensionsByContentType->Add(u"font/ttf", u".ttf");
        extensionsByContentType->Add(u"application/font-woff", u".woff");
        extensionsByContentType->Add(u"application/vnd.ms-fontobject", u".eot");
        extensionsByContentType->Add(u"application/x-font-ttf", u".ttf");
        extensionsByContentType->Add(u"text/css", u".css");
        extensionsByContentType->Add(u"audio/mpeg", u".mp3");
        extensionsByContentType->Add(u"audio/mp4", u".m4a");
        extensionsByContentType->Add(u"audio/wav", u".wav");
        extensionsByContentType->Add(u"video/mp4", u".mp4");
        extensionsByContentType->Add(u"video/webm", u".webm");
        return extensionsByContentType;
    }

    static String ResolveExtension(String contentType, String recommendedExtension)
    {
        auto normalizedContentType = NormalizeContentType(contentType);
        auto extensionsByContentType = GetExtensionsByContentType();

        String mappedExtension;
        if (!String::IsNullOrEmpty(normalizedContentType) &&
            extensionsByContentType->TryGetValue(normalizedContentType, mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(normalizedContentType))
        {
            return nullptr;
        }

        return NormalizeExtension(recommendedExtension);
    }

    static bool IsSupportedContentType(String contentType)
    {
        return !String::IsNullOrEmpty(contentType) &&
            (contentType.StartsWith(u"image/") ||
                contentType.StartsWith(u"font/") ||
                contentType.StartsWith(u"audio/") ||
                contentType.StartsWith(u"video/"));
    }

    static String NormalizeContentType(String contentType)
    {
        if (IsNullOrWhiteSpace(contentType))
        {
            return nullptr;
        }

        return contentType.Trim().ToLowerInvariant();
    }

    static String NormalizeExtension(String extension)
    {
        if (IsNullOrWhiteSpace(extension))
        {
            return nullptr;
        }

        auto extensionCharacters = extension.Trim();
        if (extensionCharacters.StartsWith(u"."))
        {
            extensionCharacters = extensionCharacters.Substring(1);
        }

        if (String::IsNullOrEmpty(extensionCharacters))
        {
            return nullptr;
        }

        auto extensionLength = extensionCharacters.get_Length();
        for (int index = 0; index < extensionLength; index++)
        {
            auto character = extensionCharacters[index];
            if (!Char::IsLetterOrDigit(character))
            {
                return nullptr;
            }
        }

        return u"." + extensionCharacters.ToLowerInvariant();
    }

    static String NormalizeUrlPrefix(String urlPrefix)
    {
        if (String::IsNullOrEmpty(urlPrefix))
        {
            return String::Empty;
        }

        auto normalizedUrlPrefix = urlPrefix.Replace(u"\\", u"/");
        if (normalizedUrlPrefix.EndsWith(u"/"))
        {
            return normalizedUrlPrefix;
        }

        return normalizedUrlPrefix + u"/";
    }

    static bool IsNullOrWhiteSpace(String value)
    {
        return String::IsNullOrEmpty(value) || String::IsNullOrEmpty(value.Trim());
    }
};
```
```cpp
auto inputFilePath = String(u"presentation.pptx");
auto outputDirectory = String(u"html-output");
auto assetDirectoryName = String(u"assets");
auto assetDirectory = Path::Combine(outputDirectory, assetDirectoryName);

Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(assetDirectory);

auto assetUrlPrefix = assetDirectoryName + u"/";
auto controller = MakeObject<ExternalResourceController>(assetDirectory, assetUrlPrefix);
auto svgOptions = MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(HtmlFormatter::CreateDocumentFormatter(String::Empty, false));
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto presentation = MakeObject<Presentation>(inputFilePath);

auto htmlFilePath = Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);
presentation->Dispose();
```

エクスポート後、出力フォルダーは次の構造になります：

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

正確なファイルはプレゼンテーションの内容とエクスポートオプションに依存します。たとえば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、ソースプレゼンテーションで使用されたものとは異なる画像コーデックを選択することがあり、サイズが小さく、より適切な場合があります。透過性を持つ画像は PNG としてエクスポートされます。

## **デプロイ用 URL の選択**

サンプルは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` が `html-output/presentation.html` から開かれる場合、ブラウザーは `html-output/assets/resource-1.svg` を読み込みます。

リンクされたリソースが別のリンクされたリソースを参照する場合、サンプルは [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) の `referrer` パラメーターを使用し、ファイル名のみを返します。例えば、`resource-1.svg` と `resource-4.jpg` が同じ `assets` フォルダーにある場合、SVG ファイルは `assets/resource-4.jpg` ではなく `resource-4.jpg` を参照すべきです。

ファイルが別の場所に展開される場合は、異なる URL プレフィックスを使用します：
- `assets/` を使用するのは、アセットディレクトリが HTML ファイルの隣にある場合です。
- `../assets/` を使用するのは、アセットディレクトリが HTML ファイルの 1 レベル上にある場合です。
- `https://cdn.example.com/presentations/job-123/assets/` を使用するのは、ファイルが CDN や静的ファイルサーバーにアップロードされる場合です。

[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) が返す URL は、[ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) が書き込むファイルの最終的な配置先と一致する必要があります。サーバーアプリケーションでは、別のエクスポートのファイルが上書きされないように、変換ジョブごとに固有の出力ディレクトリまたはオブジェクトストレージのプレフィックスを使用してください。

## **埋め込みにすべき場合**

埋め込みの Base64 HTML は、出力がメール添付、オフラインプレビュー、または資産フォルダーなしで移動されるドキュメントなど、単一ファイルである必要がある場合に依然として有用です。HTML が Web アプリケーションで提供されたり、CMS に保存されたり、ビルドパイプラインで最適化されたり、ブラウザーが HTML とは別にキャッシュしたりする場合は、リンクされたリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込んだままにできますか？**

はい。[ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) で、別ファイルとして保存したいコンテンツタイプに対してのみ `LinkEmbedDecision::Link` を返し、それ以外は `LinkEmbedDecision::Embed` を返すようにします。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は、サイズやブラウザー互換性を向上させるために HTML エクスポート時にラスタ画像を再エンコードすることがあります。例えば、元ファイルの画像がレンダリング結果に応じて JPEG または PNG として書き込まれることがあります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL は、同じ相対フォルダー構造が維持されている場合にのみ機能します。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残っている必要があります（別の URL プレフィックスを生成しない限り）。

**サーバーアプリケーションは同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに固有の出力ディレクトリまたはストレージプレフィックスを使用してください。これにより、ファイル名の衝突を防ぎ、あるエクスポートが別のエクスポートで生成されたリソースを上書きすることを防止できます。