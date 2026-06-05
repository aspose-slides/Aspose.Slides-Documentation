---
title: 外部リンク画像でプレゼンテーションをHTMLにエクスポート
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
- PowerPoint を HTML に変換
- OpenDocument を HTML に変換
- プレゼンテーションを HTML に変換
- スライドを HTML に変換
- PPT を HTML に変換
- PPTX を HTML に変換
- ODP を HTML に変換
- リンク画像
- 外部リンク画像
- リンクリソース
- 外部リソース
- C++
- Aspose.Slides
description: "Aspose.Slides を使用して、PowerPoint と OpenDocument プレゼンテーションを C++ で HTML にエクスポートし、画像やその他のリソースを外部リンクファイルとして保存します。"
---
## **概要**

デフォルトでは、Aspose.Slides はプレゼンテーションを自己完結型の HTML ファイルとしてエクスポートします。画像やその他のリソースは通常 Base64 データとして HTML に直接書き込まれます。これは 1 つのポータブルファイルが必要な場合に便利ですが、Web サイト、CMS、またはサーバー側の変換パイプラインに最適な形式とは限りません。

外部リソースへのリンクを使用するのは、次のような場合です。

- HTML ドキュメントのサイズを削減したいとき  
- ブラウザや CDN で画像、フォント、音声、動画を個別にキャッシュしたいとき  
- エクスポート後に生成されたリソースを検査、置換、圧縮、または後処理したいとき  
- 出力構造を Web アプリケーションが期待する形に近づけたいとき  

一般的な HTML 変換ワークフローについては、[Convert PowerPoint Presentations to HTML](/slides/ja/cpp/convert-powerpoint-to-html/) を参照してください。本記事はエクスポート時のリソースリンク付けに焦点を当てています。

## **リンクリソース エクスポートの仕組み**

[ILinkEmbedController](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/) を使用すると、リソースごとにデータを HTML に埋め込むか外部に保存してリンクを書くかをアプリケーション側で決定できます。

インターフェイスには次の 3 つのメソッドがあります。

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) でリソースをリンク化するか埋め込むかを判断します。  
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) は生成された HTML または他のリンクリソースに書き込まれる URL を返します。  
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) はリンクリソースのデータをディスクまたは別の保存先に書き込みます。

ファイルシステム上のパスとブラウザ URL は別個に扱われます。例えば、以下のサンプルはリソースファイルをディスク上の `html-output/assets` に書き出し、HTML には `assets/resource-1.svg` のような相対 URL が含まれます。ブラウザはリンクを含むファイルを基準にこれらの URL を解決します。そのため、`presentation.html` から SVG ファイルへのリンクは `assets/resource-1.svg` となり、同じ `assets` フォルダーに保存された画像へのリンクは `resource-4.jpg` となります。

## **リンクリソース付き HTML のエクスポート**

以下の C++ サンプルは出力ディレクトリを作成し、HTML ファイルをその中に保存し、リンクされたリソースを `assets` サブディレクトリに格納します。コントローラーは Aspose.Slides が提供または安全と判断できる拡張子を持つ共通の画像、フォント、音声、動画、CSS リソースをリンク化します。認識できないリソースは埋め込まれたままです。

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

エクスポート後、出力フォルダーは以下のような構成になります。

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

正確なファイルはプレゼンテーションの内容とエクスポート オプションに依存します。たとえば、ラスタ画像は一般的に JPEG または PNG としてエクスポートされます。Aspose.Slides は、サイズが小さくなる、またはより適切なファイルになる場合に、元のプレゼンテーションで使用されていたものとは異なる画像コーデックを選択することがあります。透過を含む画像は PNG としてエクスポートされます。

## **デプロイ用 URL の選択**

サンプルでは相対 URL プレフィックス `assets/` を使用しています。`presentation.html` を `html-output/presentation.html` から開くと、ブラウザは `html-output/assets/resource-1.svg` を読み込みます。

あるリンクリソースが別のリンクリソースを参照する場合、サンプルは [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) の `referrer` パラメーターを利用し、ファイル名だけを返します。たとえば、`resource-1.svg` と `resource-4.jpg` が同じ `assets` フォルダーにある場合、SVG ファイルは `resource-4.jpg` を参照すべきであり、`assets/resource-4.jpg` ではありません。

ファイルを別の場所にデプロイする場合は、URL プレフィックスを変更します。

- HTML ファイルと同じディレクトリにアセットがある場合は `assets/` を使用  
- アセットが HTML ファイルの 1 つ上の階層にある場合は `../assets/` を使用  
- CDN や静的ファイルサーバーにアップロードする場合は `https://cdn.example.com/presentations/job-123/assets/` を使用  

[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) が返す URL は、[ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) が書き込むファイルの最終デプロイ先と一致する必要があります。サーバー アプリケーションでは、変換ジョブごとに一意の出力ディレクトリまたはオブジェクト ストレージ プレフィックスを使用して、別のエクスポートによるファイル上書きを防止してください。

## **埋め込みにすべきケース**

埋め込み Base64 HTML は、メール添付やオフライン プレビュー、資産フォルダーなしで移動されるドキュメントなど、単一ファイルである必要がある場合に依然として有用です。HTML が Web アプリケーションで配信される、CMS に格納される、ビルド パイプラインで最適化される、またはブラウザが HTML と独立してキャッシュする場合は、リンクリソースの方が適しています。

## **FAQ**

**画像だけを外部化し、他のリソースは埋め込みのままにできますか？**

はい。[ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ja/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) で、別ファイルとして保存したいコンテンツタイプに対してだけ `LinkEmbedDecision::Link` を返し、その他は `LinkEmbedDecision::Embed` を返します。

**エクスポートされた画像の拡張子が元のプレゼンテーションと異なるのはなぜですか？**

Aspose.Slides は HTML エクスポート時にラスタ画像を再エンコードし、サイズ削減やブラウザ互換性を向上させることがあります。たとえば、元ファイルの画像が JPEG または PNG のいずれかで書き出されることがあります。

**HTML ファイルを移動した後でも相対 URL は機能しますか？**

相対 URL が機能するのは、同じ相対フォルダー構造が保持されている場合のみです。HTML が `assets/resource-1.png` を参照している場合、`assets` フォルダーは HTML ファイルの隣に残すか、別の URL プレフィックスを生成する必要があります。

**サーバー アプリケーションで同じ出力フォルダーを再利用すべきですか？**

いいえ。変換ジョブごとに一意の出力ディレクトリまたはストレージ プレフィックスを使用してください。これによりファイル名の衝突を防ぎ、別のエクスポートが生成したリソースを上書きすることを防止できます。