---
title: 將簡報匯出為具外部連結影像的 HTML
type: docs
weight: 50
url: /zh-hant/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- 匯出 PowerPoint
- 匯出 OpenDocument
- 匯出簡報
- 匯出投影片
- 匯出 PPT
- 匯出 PPTX
- 匯出 ODP
- PowerPoint 轉 HTML
- OpenDocument 轉 HTML
- 簡報轉 HTML
- 投影片轉 HTML
- PPT 轉 HTML
- PPTX 轉 HTML
- ODP 轉 HTML
- 連結影像
- 外部連結影像
- 連結資源
- 外部資源
- C++
- Aspose.Slides
description: "使用 Aspose.Slides 在 C++ 中將 PowerPoint 與 OpenDocument 簡報匯出為 HTML，並將影像與其他資源儲存為外部連結檔案。"
---
## **概述**

預設情況下，Aspose.Slides 將簡報匯出為單一的 HTML 檔案。影像與其他資源直接寫入 HTML，通常以 Base64 資料的形式。這在需要單一可攜檔案時很方便，但對於網站、CMS 或伺服器端的轉換流程而言，並不總是最佳格式。

當您希望：

- 減少 HTML 文件的大小；
- 在瀏覽器或 CDN 中分別快取影像、字型、音訊或影片；
- 在匯出後檢查、取代、壓縮或後處理產生的資源；
- 使輸出結構更貼近 Web 應用程式的需求。

若需一般的 HTML 轉換工作流程，請參閱 [Convert PowerPoint Presentations to HTML](/slides/zh-hant/cpp/convert-powerpoint-to-html/)。本文聚焦於匯出的資源連結部分。

## **連結資源匯出的運作方式**

[ILinkEmbedController](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/) 讓您的應用程式可逐一資源決定匯出程式是將資料嵌入 HTML 中，還是另存為外部檔案並寫入連結。

此介面包含三個方法：

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 決定資源應該被連結或嵌入。
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 回傳將寫入產生的 HTML 或其他連結資源的 URL。
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) 將連結資源資料寫入磁碟或其他儲存目標。

檔案系統路徑與瀏覽器 URL 是分開的考量。例如，下列範例將資源檔寫入磁碟上的 `html-output/assets`，而 HTML 內含的相對 URL 如 `assets/resource-1.svg`。瀏覽器會以包含連結的檔案為基礎解析這些 URL。因此，從 `presentation.html` 連結到 SVG 檔案時使用 `assets/resource-1.svg`，而該 SVG 檔案若要連結同一 `assets` 資料夾內的影像，則使用 `resource-4.jpg`。

## **使用連結資源匯出 HTML**

以下 C++ 範例會建立輸出目錄，將 HTML 檔儲存於其中，並將連結資源存放於 `assets` 子目錄。當 Aspose.Slides 提供或可推斷安全的副檔名時，控制項會連結常見的影像、字型、音訊、影片與 CSS 資源。未被識別的資源則維持嵌入。

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

匯出完成後，輸出資料夾的結構如下：

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

實際產生的檔案取決於簡報內容與匯出選項。例如，點陣圖通常會以 JPEG 或 PNG 匯出。當產生較小或較適合的檔案時，Aspose.Slides 可能會選擇不同於來源簡報的影像編碼方式。具有透明度的影像會以 PNG 匯出。

## **選擇部署用的 URL**

範例使用相對 URL 前綴：`assets/`。如果從 `html-output/presentation.html` 開啟 `presentation.html`，瀏覽器將載入 `html-output/assets/resource-1.svg`。

當一個連結資源引用另一個連結資源時，範例在 [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 中使用 `referrer` 參數，僅回傳檔名。例如，若 `resource-1.svg` 與 `resource-4.jpg` 均位於 `assets` 資料夾，SVG 檔案應該引用 `resource-4.jpg`，而非 `assets/resource-4.jpg`。

當檔案部署於其他位置時，請使用不同的 URL 前綴：

- 當資產目錄與 HTML 檔相鄰時，使用 `assets/`。
- 當資產目錄位於 HTML 檔上層一層時，使用 `../assets/`。
- 當檔案上傳至 CDN 或靜態檔案伺服器時，使用 `https://cdn.example.com/presentations/job-123/assets/`。

由 [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) 回傳的 URL 必須與 [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) 所寫入檔案的最終部署位置相吻合。在伺服器應用程式中，請為每個轉換作業使用唯一的輸出目錄或物件儲存前綴，以避免覆寫其他匯出的檔案。

## **何時改為嵌入**

嵌入 Base64 的 HTML 在輸出必須為單一檔案時仍然有用，例如作為電子郵件附件、離線預覽，或會在沒有資產資料夾的情況下移動的文件。當 HTML 由 Web 應用程式提供、存放於 CMS、經由建置流程優化，或由瀏覽器獨立快取時，使用連結資源比較合適。

## **FAQ**

**我可以只將影像外部化，而保持其他資源嵌入嗎？**

可以。於 [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) 中，對您想要另存為獨立檔案的內容類型回傳 `LinkEmbedDecision::Link`，其餘則回傳 `LinkEmbedDecision::Embed`。

**為什麼匯出的影像副檔名與來源簡報不同？**

Aspose.Slides 可能會在 HTML 匯出過程中重新編碼點陣圖，以縮小檔案大小或提升瀏覽器相容性。例如，來源檔案中的影像可能會根據最終呈現結果寫成 JPEG 或 PNG。

**在我移動 HTML 檔案後，相對 URL 仍然可用嗎？**

相對 URL 僅在保留相同的相對資料夾結構時才有效。若 HTML 引用 `assets/resource-1.png`，則 `assets` 資料夾必須與 HTML 檔同在，除非您產生不同的 URL 前綴。

**伺服器應用程式應該重複使用相同的輸出資料夾嗎？**

不應。請為每個轉換作業使用唯一的輸出目錄或儲存前綴，以避免檔名衝突，防止一個匯出覆寫其他匯出的資源。