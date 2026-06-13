---
title: 외부 연결된 이미지로 프레젠테이션을 HTML로 내보내기
type: docs
weight: 50
url: /ko/cpp/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- 슬라이드 내보내기
- PPT 내보내기
- PPTX 내보내기
- ODP 내보내기
- PowerPoint to HTML
- OpenDocument to HTML
- 프레젠테이션 to HTML
- 슬라이드 to HTML
- PPT to HTML
- PPTX to HTML
- ODP to HTML
- 링크된 이미지
- 외부 연결된 이미지
- 링크된 리소스
- 외부 리소스
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보내며 이미지 및 기타 리소스를 외부 링크 파일로 저장합니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 자체 포함된 HTML 파일로 내보냅니다. 이미지와 기타 리소스는 일반적으로 Base64 데이터로 HTML에 직접 기록됩니다. 하나의 휴대용 파일이 필요할 때는 편리하지만, 웹사이트, CMS, 또는 서버 측 변환 파이프라인에 항상 최적의 형식은 아닙니다.

외부 링크 리소스를 사용해야 하는 경우:

- HTML 문서 크기 감소;
- 이미지, 글꼴, 오디오 또는 비디오를 브라우저나 CDN에 별도로 캐시;
- 내보낸 후 생성된 리소스를 검사, 교체, 압축 또는 후처리;
- 출력 구조를 웹 애플리케이션이 기대하는 형태에 가깝게 유지.

일반적인 HTML 변환 워크플로우는 [PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/cpp/convert-powerpoint-to-html/)을 참조하십시오. 이 문서는 내보내기의 리소스 연결 부분에 중점을 둡니다.

## **링크된 리소스 내보내기 작동 방식**

[ILinkEmbedController](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/)는 애플리케이션이 리소스별로 데이터를 HTML에 삽입할지 외부에 저장하고 링크를 쓸지 결정하도록 합니다.

인터페이스에는 세 개의 메서드가 있습니다:

- [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)은 리소스를 링크할지 임베드할지를 결정합니다.
- [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/geturl/)은 생성된 HTML이나 다른 링크된 리소스에 기록될 URL을 반환합니다.
- [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/)은 링크된 리소스 데이터를 디스크나 다른 저장 대상에 씁니다.

파일 시스템 경로와 브라우저 URL은 별개의 개념입니다. 예를 들어 아래 샘플은 리소스 파일을 디스크의 `html-output/assets`에 쓰고, HTML에는 `assets/resource-1.svg`와 같은 상대 URL을 포함합니다. 브라우저는 링크가 포함된 파일을 기준으로 해당 URL을 해석합니다. 따라서 `presentation.html`에서 SVG 파일로의 링크는 `assets/resource-1.svg`를 사용하고, 그 SVG 파일이 동일 `assets` 폴더에 저장된 이미지로 연결될 때는 `resource-4.jpg`를 사용합니다.

## **링크된 리소스로 HTML 내보내기**

다음 C++ 예제는 출력 디렉터리를 생성하고, HTML 파일을 그곳에 저장하며, 링크된 리소스를 `assets` 하위 디렉터리에 보관합니다. 컨트롤러는 Aspose.Slides가 안전한 파일 확장자를 제공하거나 추론할 수 있는 경우 일반 이미지, 글꼴, 오디오, 비디오 및 CSS 리소스를 링크합니다. 인식되지 않는 리소스는 계속 임베드됩니다.

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

내보낸 후, 출력 폴더는 다음과 같은 구조를 가집니다:

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

정확한 파일은 프레젠테이션 내용과 내보내기 옵션에 따라 달라집니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG로 내보내집니다. Aspose.Slides는 더 작거나 더 적합한 파일을 만들기 위해 원본 프레젠테이션에서 사용된 이미지 코덱과 다른 코덱을 선택할 수 있습니다. 투명도가 있는 이미지는 PNG로 내보내집니다.

## **배포를 위한 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html`을 `html-output/presentation.html`에서 열면 브라우저는 `html-output/assets/resource-1.svg`를 로드합니다.

하나의 링크된 리소스가 다른 링크된 리소스를 참조할 때, 샘플은 [ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/geturl/)의 `referrer` 매개변수를 사용하고 파일 이름만 반환합니다. 예를 들어 `resource-1.svg`와 `resource-4.jpg`가 모두 `assets` 폴더에 있다면, SVG 파일은 `assets/resource-4.jpg`가 아니라 `resource-4.jpg`를 참조해야 합니다.

파일이 다른 위치에 배포될 때는 다른 URL 접두사를 사용하십시오:

- 자산 디렉터리가 HTML 파일과 같은 위치에 있을 때 `assets/`를 사용합니다.
- 자산 디렉터리가 HTML 파일보다 한 단계 위에 있을 때 `../assets/`를 사용합니다.
- 파일이 CDN 또는 정적 파일 서버에 업로드될 때 `https://cdn.example.com/presentations/job-123/assets/`를 사용합니다.

[ILinkEmbedController::GetUrl](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/geturl/)이 반환한 URL은 [ILinkEmbedController::SaveExternal](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/saveexternal/)이 기록한 파일의 최종 배포 위치와 일치해야 합니다. 서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리나 객체 저장 접두사를 사용하여 다른 내보내기의 파일이 덮어써지는 것을 방지하십시오.

## **대신 임베드해야 할 경우**

임베드된 Base64 HTML은 출력이 이메일 첨부 파일, 오프라인 미리보기, 또는 지원 자산 폴더 없이 이동될 문서와 같이 단일 파일이어야 할 때 여전히 유용합니다. HTML이 웹 애플리케이션에 의해 제공되거나, CMS에 저장되거나, 빌드 파이프라인에서 최적화되거나, 브라우저가 HTML과 독립적으로 캐시할 때는 링크된 리소스가 더 적합합니다.

## **FAQ**

**이미지만 외부화하고 다른 리소스는 임베드된 상태로 유지할 수 있나요?**

예. [ILinkEmbedController::GetObjectStoringLocation](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)에서 별도 파일로 저장하려는 콘텐츠 유형에 대해서만 `LinkEmbedDecision::Link`를 반환하고, 나머지는 `LinkEmbedDecision::Embed`를 반환하십시오.

**내보낸 이미지 확장자가 원본 프레젠테이션과 다른 이유는 무엇인가요?**

Aspose.Slides는 HTML 내보내기 시 크기나 브라우저 호환성을 높이기 위해 래스터 이미지를 재인코딩할 수 있습니다. 예를 들어 원본 파일의 이미지는 렌더링 결과에 따라 JPEG 또는 PNG로 기록될 수 있습니다.

**HTML 파일을 이동한 후에도 상대 URL이 작동하나요?**

상대 URL은 동일한 상대 폴더 구조가 유지될 때만 작동합니다. HTML이 `assets/resource-1.png`를 참조한다면 `assets` 폴더는 HTML 파일 옆에 그대로 존재해야 하며, 다른 URL 접두사를 사용하지 않는 한 구조가 바뀌면 동작하지 않습니다.

**서버 애플리케이션이 동일한 출력 폴더를 재사용해야 하나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리나 저장 접두사를 사용하십시오. 이렇게 하면 파일 이름 충돌을 방지하고 한 내보내기가 다른 내보내기의 리소스를 덮어쓰는 것을 막을 수 있습니다.