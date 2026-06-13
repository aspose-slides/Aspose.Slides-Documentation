---
title: 외부 링크된 이미지와 함께 프레젠테이션을 HTML로 내보내기
type: docs
weight: 100
url: /ko/net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- 슬라이드 내보내기
- PPT 내보내기
- PPTX 내보내기
- ODP 내보내기
- PowerPoint를 HTML로
- OpenDocument를 HTML로
- 프레젠테이션을 HTML로
- 슬라이드를 HTML로
- PPT를 HTML로
- PPTX를 HTML로
- ODP를 HTML로
- 링크된 이미지
- 외부 링크된 이미지
- 링크된 리소스
- 외부 리소스
- .NET
- C#
- Aspose.Slides
description: ".NET에서 Aspose.Slides를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 HTML로 내보내고 이미지와 기타 리소스를 외부 링크 파일로 저장합니다."
---
## **개요**

기본적으로 Aspose.Slides는 프레젠테이션을 단일 HTML 파일로 내보냅니다. 이미지와 기타 리소스는 일반적으로 Base64 데이터로 HTML에 직접 기록됩니다. 이는 하나의 휴대용 파일이 필요할 때 편리하지만, 웹 사이트, CMS 또는 서버‑사이드 변환 파이프라인에 항상 최적의 형식은 아닙니다.

다음과 같은 경우 외부 링크된 리소스를 사용합니다:

- HTML 문서 크기 감소
- 브라우저나 CDN에서 이미지, 글꼴, 오디오, 비디오를 별도로 캐시
- 내보낸 후 생성된 리소스를 검사, 교체, 압축 또는 후처리
- 웹 애플리케이션이 기대하는 구조에 더 가깝게 출력 유지

일반적인 HTML 변환 워크플로는 [PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/net/convert-powerpoint-to-html/)을 참고하세요. 이 문서는 내보내기의 리소스‑링크 부분에 중점을 둡니다.

## **연결된 리소스 내보내기 작동 방식**

[ILinkEmbedController](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/)를 사용하면 애플리케이션이 리소스별로 데이터를 HTML에 포함할지 외부에 저장하고 링크를 작성할지 결정할 수 있습니다.

이 인터페이스에는 세 가지 메서드가 있습니다:

- [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)는 리소스를 링크할지 임베드할지 결정합니다.
- [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/geturl/)은 생성된 HTML 또는 다른 링크된 리소스에 기록될 URL을 반환합니다.
- [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/saveexternal/)은 링크된 리소스 데이터를 디스크 또는 다른 저장 대상에 씁니다.

파일 시스템 경로와 브라우저 URL은 별개의 개념입니다. 예를 들어 아래 샘플은 리소스 파일을 `html-output/assets` 폴더에 저장하고, HTML에는 `assets/resource-1.svg`와 같은 상대 URL을 포함합니다. 브라우저는 해당 링크가 포함된 파일을 기준으로 URL을 해석합니다. 따라서 `presentation.html`에서 SVG 파일로 연결할 때는 `assets/resource-1.svg`를 사용하고, 그 SVG 파일이 동일한 `assets` 폴더에 저장된 이미지로 연결할 때는 `resource-4.jpg`를 사용합니다.

## **링크된 리소스로 HTML 내보내기**

다음 C# 예제는 출력 디렉터리를 만들고 HTML 파일을 그곳에 저장하며, 링크된 리소스를 `assets` 하위 디렉터리에 저장합니다. 컨트롤러는 Aspose.Slides가 제공하거나 안전한 파일 확장자를 추론할 수 있는 일반적인 이미지, 글꼴, 오디오, 비디오 및 CSS 리소스를 링크합니다. 인식되지 않은 리소스는 그대로 임베드됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.Collections.Generic;
using System.IO;

var inputFilePath = "presentation.pptx";
var outputDirectory = "html-output";
var assetDirectoryName = "assets";
var assetDirectory = Path.Combine(outputDirectory, assetDirectoryName);

Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(assetDirectory);

var assetUrlPrefix = assetDirectoryName + "/";
var controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = HtmlFormatter.CreateDocumentFormatter(string.Empty, false),
    SlideImageFormat = slideImageFormat
};

using var presentation = new Presentation(inputFilePath);

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);

public sealed class ExternalResourceController : ILinkEmbedController
{
    private static readonly Dictionary<string, string> ExtensionsByContentType = new(StringComparer.OrdinalIgnoreCase)
    {
        ["image/jpeg"] = ".jpg",
        ["image/png"] = ".png",
        ["image/gif"] = ".gif",
        ["image/bmp"] = ".bmp",
        ["image/svg+xml"] = ".svg",
        ["image/tiff"] = ".tiff",
        ["image/x-emf"] = ".emf",
        ["image/x-wmf"] = ".wmf",
        ["font/woff"] = ".woff",
        ["font/woff2"] = ".woff2",
        ["font/ttf"] = ".ttf",
        ["application/font-woff"] = ".woff",
        ["application/vnd.ms-fontobject"] = ".eot",
        ["application/x-font-ttf"] = ".ttf",
        ["text/css"] = ".css",
        ["audio/mpeg"] = ".mp3",
        ["audio/mp4"] = ".m4a",
        ["audio/wav"] = ".wav",
        ["video/mp4"] = ".mp4",
        ["video/webm"] = ".webm"
    };

    private readonly string assetDirectory;
    private readonly string assetUrlPrefix;
    private readonly Dictionary<int, string> fileNamesByResourceId = new();

    public ExternalResourceController(string assetDirectory, string assetUrlPrefix)
    {
        if (string.IsNullOrWhiteSpace(assetDirectory))
        {
            throw new ArgumentException("The asset output directory must not be empty.", nameof(assetDirectory));
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = NormalizeUrlPrefix(assetUrlPrefix);
    }

    public LinkEmbedDecision GetObjectStoringLocation(
        int resourceId,
        byte[] entityData,
        string semanticName,
        string contentType,
        string recommendedExtension)
    {
        var extension = ResolveExtension(contentType, recommendedExtension);
        if (extension == null)
        {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId[resourceId] = $"resource-{resourceId}{extension}";
        return LinkEmbedDecision.Link;
    }

    public string GetUrl(int resourceId, int referrer)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            return null;
        }

        if (fileNamesByResourceId.ContainsKey(referrer))
        {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    public void SaveExternal(int resourceId, byte[] entityData)
    {
        if (!fileNamesByResourceId.TryGetValue(resourceId, out var fileName))
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} was not registered for external storage.");
        }

        if (entityData == null || entityData.Length == 0)
        {
            throw new InvalidOperationException(
                $"Resource {resourceId} contains no data and cannot be saved.");
        }

        Directory.CreateDirectory(assetDirectory);

        var filePath = Path.Combine(assetDirectory, fileName);
        File.WriteAllBytes(filePath, entityData);
    }

    private static string ResolveExtension(string contentType, string recommendedExtension)
    {
        if (!string.IsNullOrWhiteSpace(contentType) &&
            ExtensionsByContentType.TryGetValue(contentType, out var mappedExtension))
        {
            return mappedExtension;
        }

        if (!IsSupportedContentType(contentType))
        {
            return null;
        }

        return NormalizeExtension(recommendedExtension);
    }

    private static bool IsSupportedContentType(string contentType)
    {
        return contentType != null &&
            (contentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("font/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("audio/", StringComparison.OrdinalIgnoreCase) ||
             contentType.StartsWith("video/", StringComparison.OrdinalIgnoreCase));
    }

    private static string NormalizeExtension(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return null;
        }

        var extensionCharacters = extension.Trim().TrimStart('.');
        foreach (var character in extensionCharacters)
        {
            if (!char.IsLetterOrDigit(character))
            {
                return null;
            }
        }

        return "." + extensionCharacters.ToLowerInvariant();
    }

    private static string NormalizeUrlPrefix(string urlPrefix)
    {
        if (string.IsNullOrEmpty(urlPrefix))
        {
            return string.Empty;
        }

        var normalizedUrlPrefix = urlPrefix.Replace('\\', '/');
        return normalizedUrlPrefix.EndsWith("/")
            ? normalizedUrlPrefix
            : normalizedUrlPrefix + "/";
    }
}
```

내보낸 후 출력 폴더 구조는 다음과 같습니다:

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

구체적인 파일은 프레젠테이션 내용 및 내보내기 옵션에 따라 달라집니다. 예를 들어 래스터 이미지는 일반적으로 JPEG 또는 PNG 형식으로 내보내집니다. Aspose.Slides는 더 작거나 적합한 파일을 만들기 위해 소스 프레젠테이션과 다른 이미지 코덱을 선택할 수 있습니다. 투명도가 포함된 이미지는 PNG로 내보냅니다.

## **배포를 위한 URL 선택**

샘플은 상대 URL 접두사 `assets/`를 사용합니다. `presentation.html`이 `html-output/presentation.html`에서 열리면 브라우저는 `html-output/assets/resource-1.svg`를 로드합니다.

하나의 링크된 리소스가 다른 링크된 리소스를 참조할 때는 [ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/geturl/)의 `referrer` 파라미터를 이용해 파일 이름만 반환합니다. 예를 들어 `resource-1.svg`와 `resource-4.jpg`가 모두 `assets` 폴더에 있다면 SVG 파일은 `resource-4.jpg`를 참조해야 하며 `assets/resource-4.jpg`를 참조하면 안 됩니다.

파일을 다른 위치에 배포할 경우 다른 URL 접두사를 사용합니다:

- HTML 파일 옆에 자산 디렉터리가 있을 때는 `assets/` 사용
- 자산 디렉터리가 HTML 파일보다 한 단계 위에 있을 때는 `../assets/` 사용
- 파일을 CDN이나 정적 파일 서버에 업로드할 때는 `https://cdn.example.com/presentations/job-123/assets/` 사용

[ILinkEmbedController.GetUrl](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/geturl/)이 반환하는 URL은 [ILinkEmbedController.SaveExternal](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/saveexternal/)이 실제로 파일을 저장하는 최종 배포 위치와 일치해야 합니다. 서버 애플리케이션에서는 각 변환 작업마다 고유한 출력 디렉터리나 객체 저장소 접두사를 사용해 다른 내보내기의 파일이 덮어쓰기되지 않도록 합니다.

## **대신 임베드해야 할 때**

단일 파일이어야 하는 경우(예: 이메일 첨부 파일, 오프라인 미리보기, 별도 자산 폴더 없이 이동되는 문서)에는 Base64 임베드 HTML이 여전히 유용합니다. 웹 애플리케이션이 HTML을 제공하거나 CMS에 저장하고, 빌드 파이프라인에서 최적화하거나 브라우저가 HTML과 독립적으로 캐시해야 하는 경우에는 링크된 리소스가 더 적합합니다.

## **FAQ**

**이미지만 외부화하고 다른 리소스는 임베드 상태로 유지할 수 있나요?**

예. [ILinkEmbedController.GetObjectStoringLocation](https://reference.aspose.com/slides/ko/net/aspose.slides.export/ilinkembedcontroller/getobjectstoringlocation/)에서 별도 파일로 저장하고 싶은 콘텐츠 유형에 대해 `LinkEmbedDecision.Link`를 반환하고, 그 외에는 `LinkEmbedDecision.Embed`를 반환하면 됩니다.

**내보낸 이미지 확장자가 원본 프레젠테이션과 다른 이유는 무엇인가요?**

Aspose.Slides는 HTML 내보내기 과정에서 크기 감소나 브라우저 호환성을 위해 래스터 이미지를 재인코딩할 수 있습니다. 예를 들어 소스 파일의 이미지는 렌더링 결과에 따라 JPEG 또는 PNG로 기록될 수 있습니다.

**HTML 파일을 이동한 뒤에도 상대 URL이 동작하나요?**

상대 URL은 동일한 상대 폴더 구조가 유지될 때만 동작합니다. HTML이 `assets/resource-1.png`를 참조한다면 `assets` 폴더가 HTML 파일 옆에 그대로 존재해야 하며, 다른 URL 접두사를 생성하지 않는 한 반드시 유지해야 합니다.

**서버 애플리케이션에서 동일한 출력 폴더를 재사용해도 되나요?**

아니요. 각 변환 작업마다 고유한 출력 디렉터리나 저장 접두사를 사용하세요. 이렇게 하면 파일 이름 충돌을 방지하고 한 내보내기가 다른 내보내기의 리소스를 덮어쓰는 일을 방지할 수 있습니다.