---
title: Xuất bản trình chiếu sang HTML với hình ảnh được liên kết bên ngoài
type: docs
weight: 50
url: /vi/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình chiếu
- xuất slide
- xuất PPT
- xuất PPTX
- xuất ODP
- PowerPoint sang HTML
- OpenDocument sang HTML
- bản trình chiếu sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- ODP sang HTML
- hình ảnh được liên kết
- hình ảnh được liên kết bên ngoài
- tài nguyên được liên kết
- tài nguyên bên ngoài
- C++
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint và OpenDocument sang HTML trong C++ bằng Aspose.Slides với hình ảnh và các tài nguyên khác được lưu dưới dạng tệp liên kết bên ngoài."
---
## **Tổng quan**

Mặc định, Aspose.Slides xuất một bản trình chiếu ra một tệp HTML độc lập. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này thuận tiện khi bạn cần một tệp duy nhất có thể di động, nhưng không luôn là định dạng tốt nhất cho một trang web, một CMS, hoặc một quy trình chuyển đổi phía máy chủ.

Sử dụng các tài nguyên được liên kết bên ngoài khi bạn muốn:

- giảm kích thước của tài liệu HTML;
- lưu bộ nhớ đệm hình ảnh, phông chữ, âm thanh hoặc video riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén hoặc xử lý hậu kỳ các tài nguyên đã tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Chuyển đổi Bản trình chiếu PowerPoint sang HTML](/slides/vi/cpp/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết tài nguyên của quá trình xuất.

## **Cách hoạt động của xuất tài nguyên có liên kết**

[ILinkEmbedController](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/) cho phép ứng dụng của bạn quyết định, từng tài nguyên một, liệu bộ xuất có nhúng dữ liệu vào HTML hay lưu nó bên ngoài và ghi một liên kết.

Giao diện có ba phương thức:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/) quyết định liệu một tài nguyên nên được liên kết hay nhúng.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) trả về URL sẽ được ghi vào HTML đã tạo hoặc vào một tài nguyên có liên kết khác.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) ghi dữ liệu tài nguyên đã liên kết vào đĩa hoặc vào một mục lưu trữ khác.

Đường dẫn hệ thống tệp và URL của trình duyệt là hai vấn đề riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp tài nguyên vào `html-output/assets` trên đĩa, trong khi HTML chứa các URL tương đối như `assets/resource-1.svg`. Trình duyệt giải quyết các URL này dựa trên tệp chứa liên kết. Do đó, một liên kết từ `presentation.html` tới tệp SVG sử dụng `assets/resource-1.svg`, trong khi một liên kết từ tệp SVG đó tới hình ảnh được lưu trong cùng thư mục `assets` sử dụng `resource-4.jpg`.

## **Xuất HTML với tài nguyên có liên kết**

Ví dụ C++ dưới đây tạo một thư mục đầu ra, lưu tệp HTML vào đó và lưu các tài nguyên có liên kết trong một thư mục con `assets`. Bộ điều khiển liên kết các tài nguyên hình ảnh, phông chữ, âm thanh, video và CSS phổ biến khi Aspose.Slides cung cấp hoặc có thể suy ra phần mở rộng tệp an toàn. Các tài nguyên không được nhận dạng sẽ vẫn được nhúng.

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

Sau khi xuất, thư mục đầu ra có cấu trúc sau:

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

Các tệp chính xác phụ thuộc vào nội dung bản trình chiếu và các tùy chọn xuất. Ví dụ, hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn một bộ mã hình ảnh khác với bộ được sử dụng trong bản trình chiếu nguồn nếu điều đó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Các hình ảnh có độ trong suốt sẽ được xuất dưới dạng PNG.

## **Chọn URL để triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.svg`.

Khi một tài nguyên có liên kết tham chiếu tới một tài nguyên có liên kết khác, mẫu sử dụng tham số `referrer` trong [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) và chỉ trả về tên tệp. Ví dụ, nếu `resource-1.svg` và `resource-4.jpg` đều nằm trong thư mục `assets`, tệp SVG nên tham chiếu đến `resource-4.jpg`, không phải `assets/resource-4.jpg`.

Sử dụng một tiền tố URL khác khi các tệp được triển khai ở nơi khác:

- Sử dụng `assets/` khi thư mục tài sản nằm cạnh tệp HTML.
- Sử dụng `../assets/` khi thư mục tài sản nằm một cấp trên tệp HTML.
- Sử dụng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tệp tĩnh.

URL trả về bởi [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/geturl/) phải khớp với vị trí triển khai cuối cùng của tệp do [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/) ghi. Trong các ứng dụng máy chủ, sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ đối tượng cho mỗi công việc chuyển đổi để tránh ghi đè các tệp từ một lần xuất khác.

## **Khi nào nên nhúng thay vì liên kết**

HTML nhúng Base64 vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như tệp đính kèm email, bản xem trước offline, hoặc tài liệu sẽ được chuyển mà không có thư mục tài sản hỗ trợ. Các tài nguyên có liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trữ trong CMS, được tối ưu hoá bởi quy trình xây dựng, hoặc được trình duyệt lưu vào bộ nhớ đệm một cách độc lập với HTML.

## **Câu hỏi thường gặp**

**Tôi có thể chỉ tách ra các hình ảnh và giữ các tài nguyên khác được nhúng không?**

Đúng. Trong [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/), trả về `LinkEmbedDecision::Link` chỉ cho các kiểu nội dung bạn muốn lưu dưới dạng các tệp riêng, và trả về `LinkEmbedDecision::Embed` cho mọi thứ còn lại.

**Tại sao phần mở rộng hình ảnh xuất ra khác với bản trình chiếu nguồn?**

Aspose.Slides có thể mã hoá lại các hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc khả năng tương thích với trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy vào kết quả hiển thị.

**Các URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

Các URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối được giữ nguyên. Nếu HTML tham chiếu đến `assets/resource-1.png`, thư mục `assets` phải ở cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Các ứng dụng máy chủ có nên tái sử dụng cùng một thư mục đầu ra không?**

Không. Sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ cho mỗi công việc chuyển đổi. Điều này tránh va chạm tên tệp và ngăn một lần xuất ghi đè lên tài nguyên do lần xuất khác tạo.