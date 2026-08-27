---
title: ".NET에서 PowerPoint 프레젠테이션을 Markdown으로 변환"
linktitle: "PowerPoint를 Markdown으로"
type: docs
weight: 140
url: /ko/net/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- PPTX를 MD로 내보내기
- Markdown 이미지 내보내기
- CDN 이미지 링크
- PowerPoint
- 프레젠테이션
- Markdown
- .NET
- C#
- Aspose.Slides
description: ".NET에서 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하고, 내보낸 비트맵, 메타파일 및 SVG 이미지가 저장되고 참조되는 위치를 제어합니다."
---
## **개요**

Aspose.Slides for .NET은 PPT 및 PPTX 프레젠테이션을 Markdown으로 변환하여 문서화, 정적 사이트, 콘텐츠 마이그레이션 및 버전 관리 워크플로에 활용할 수 있습니다. Markdown 형식을 선택하고 슬라이드 내용이 렌더링되는 방식을 제어하며, 내보낸 이미지가 저장되는 위치와 생성된 Markdown이 이미지를 참조하는 방식을 지정할 수 있습니다.

기본적으로 Markdown 내보내기는 텍스트 전용 출력을 사용합니다. 시각적 내용을 내보내려면 [MarkdownSaveOptions.ExportType](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/exporttype/) 속성을 [MarkdownExportType](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownexporttype/) 열거형의 `Sequential` 또는 `Visual` 값으로 설정합니다. `Sequential`은 슬라이드 항목을 개별적으로 순서대로 렌더링하고, `Visual`은 그룹화된 항목을 함께 유지하여 시각적 관계를 보존합니다. `TextOnly` 값은 이미지 리소스를 생성하지 않으므로 해당 모드에서는 이미지 저장 이벤트가 호출되지 않습니다.

## **프레젠테이션을 Markdown으로 변환**

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스로 소스 파일을 로드한 다음, [Presentation.Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 호출하고 [SaveFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/saveformat/) 열거형의 `Md` 값을 지정합니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.md", SaveFormat.Md);
```

## **Markdown 형식 선택**

[MarkdownSaveOptions.Flavor](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/flavor/) 속성은 출력에 사용할 Markdown 사양을 제어합니다. [Flavor](https://reference.aspose.com/slides/ko/net/aspose.slides.export/flavor/) 열거형에는 CommonMark, GitHub Flavored Markdown 및 기타 지원되는 변형이 포함됩니다.

다음 예제는 프레젠테이션을 CommonMark 형식으로 내보냅니다:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    Flavor = Flavor.CommonMark
};

presentation.Save("presentation.md", SaveFormat.Md, options);
```

## **기본 로컬 저장 동작을 사용하여 이미지 내보내기**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/) 클래스는 로컬에 저장되는 이미지에 대해 두 개의 속성을 제공합니다.

- [BasePath](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/basepath/) 은 Markdown 문서와 해당 리소스의 기본 디렉터리를 지정합니다.
- [ImagesSaveFolderName](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/) 은 이미지 하위 디렉터리를 지정합니다. 기본값은 `Images` 입니다.

다음 예제는 시각적 내용을 렌더링하고 이미지를 `output/assets`에 저장하며 Markdown 문서에 상대 이미지 참조를 생성합니다:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "assets"
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

이 동작은 사용자 지정 이미지 저장 핸들러가 `false`를 반환할 때 대체 동작으로도 사용됩니다.

## **이미지 저장 및 Markdown 링크 사용자 지정**

Markdown 내보내기 동안 비 SVG 비트맵 및 메타파일 리소스에 대해 [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/imagesaving/) 이벤트를 사용합니다. 해당 [MarkdownImageSavingHandler](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions.markdownimagesavinghandler/) 대리자는 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체, 그 [ImageFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/) 및 `ref string` 매개변수로 전달되는 생성된 Markdown 링크를 받습니다. 제공된 형식으로 이미지를 저장하거나 업로드하고, `link`를 Markdown 출력에 표시되어야 하는 참조로 교체합니다.

SVG 형식으로 출력되는 리소스는 별도로 처리됩니다. [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/) 이벤트에 구독하고, 해당 [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions.markdownsvgimagesavinghandler/) 대리자는 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 객체와 `ref string link` 매개변수를 받습니다. SVG에는 `ImageFormat` 매개변수가 없으므로 [ISvgImage.SvgData](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/svgdata/) 속성에서 XML 데이터를 쓰거나 업로드합니다. 내보내기 모드와 시각적 그룹화에 따라 소스 프레젠테이션의 SVG가 래스터화되거나 다른 콘텐츠와 결합될 수 있으며, 결과 비 SVG 리소스는 `ImageSaving`에 전달됩니다. 모든 내보낸 시각적 리소스에 대해 사용자 지정 처리가 필요할 경우 두 이벤트 모두에 구독하십시오.

핸들러 반환 값에 따라 이미지를 처리하는 주체가 결정됩니다:

- 이미지가 저장·업로드·변환 등으로 처리되고 `link`에 유효한 값을 할당한 경우 `true`를 반환합니다. Aspose.Slides는 해당 값을 Markdown 문서에 기록하고 기본 로컬 저장을 수행하지 않습니다.
- `false`를 반환하면 Aspose.Slides가 이미지를 로컬에 저장하고 [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/basepath/) 및 [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/)에 따라 링크를 생성합니다.

{{% alert color="warning" title="중요" %}}
`true`를 반환하는 핸들러는 이미지에 대한 책임을 집니다. 유효하고 비어 있지 않은 링크를 할당하지 않고 `true`를 반환하면 `InvalidOperationException`이 발생하여 내보내기가 실패합니다.
{{% /alert %}}

### **CDN 원본 디렉터리에 이미지 저장 및 외부 URL 사용**

다음 예제는 `cdn-origin/presentations/quarterly-report`를 마운트되거나 동기화된 CDN 원본 디렉터리로 간주합니다. 각 핸들러는 생성된 파일 이름을 추출하여 해당 사용자 지정 디렉터리에 이미지를 저장하고, 생성된 로컬 참조를 공개 CDN URL로 교체합니다. 샘플 자체는 네트워크 업로드를 수행하지 않으며, 디렉터리가 CDN 원본으로 마운트되거나 파일이 CDN에 배포된 후에만 URL이 유효합니다. 객체 스토리지를 사용하는 경우 파일 시스템 쓰기를 스토리지 SDK의 업로드 작업으로 교체하고, 업로드가 성공한 후에만 `link`를 할당합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

const string outputDirectory = "output";
const string publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
var storageDirectory = Path.Combine("cdn-origin", "presentations", "quarterly-report");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(storageDirectory);

static string GetFileNameFromLink(string generatedLink)
{
    var urlCompatibleLink = generatedLink.Replace('\\', '/');
    return urlCompatibleLink[(urlCompatibleLink.LastIndexOf('/') + 1)..];
}

static string BuildPublicUrl(string baseUrl, string fileName)
{
    return $"{baseUrl}/{Uri.EscapeDataString(fileName)}";
}

using var presentation = new Presentation("presentation.pptx");
var options = new MarkdownSaveOptions
{
    ExportType = MarkdownExportType.Visual,
    BasePath = outputDirectory,
    ImagesSaveFolderName = "fallback-images"
};

options.ImageSaving += (IImage image, ImageFormat format, ref string link) =>
{
    if (image.Width < 128 || image.Height < 128)
    {
        return false;
    }

    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    image.Save(storagePath, format);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

options.SvgImageSaving += (ISvgImage svgImage, ref string link) =>
{
    var fileName = GetFileNameFromLink(link);
    var storagePath = Path.Combine(storageDirectory, fileName);
    File.WriteAllBytes(storagePath, svgImage.SvgData);
    link = BuildPublicUrl(publicBaseUrl, fileName);
    return true;
};

var markdownPath = Path.Combine(outputDirectory, "presentation.md");
presentation.Save(markdownPath, SaveFormat.Md, options);
```

비트맵 핸들러는 128 × 128 픽셀보다 작은 이미지는 의도적으로 `false`를 반환하므로 Aspose.Slides는 이러한 이미지를 기본 동작으로 `output/fallback-images`에 저장합니다. 더 큰 비트맵 및 메타파일 리소스와 SVG 리소스는 사용자 지정 코드에서 처리됩니다. 예를 들어, `fallback-images/image1.png`와 같은 로컬 참조는 `https://cdn.example.com/presentations/quarterly-report/image1.png`으로 변환됩니다. 핸들러는 파일을 쓸 때만 운영 체제 경로를 사용하고, Markdown에 기록되는 링크는 슬래시(`/`)와 URL 인코딩된 파일 이름을 사용합니다. 상대 링크를 만들 때도 플랫폼별 디렉터리 구분자가 아닌 `/`를 사용하십시오.

## **FAQ**

**핸들러 하나가 래스터 이미지와 SVG 이미지를 모두 처리할 수 있나요?**

아니요. 비트맵 및 메타파일 리소스에는 [MarkdownSaveOptions.ImageSaving](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/imagesaving/)을 사용하고, SVG 리소스에는 [MarkdownSaveOptions.SvgImageSaving](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/svgimagesaving/)을 사용하십시오. 전자는 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체와 [ImageFormat](https://reference.aspose.com/slides/ko/net/aspose.slides/imageformat/)를 제공하고, 후자는 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 객체와 [ISvgImage.SvgData](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/svgdata/)에서 읽을 수 있는 SVG 데이터를 제공합니다. 내보내기 중에 래스터화된 소스 SVG는 `ImageSaving`에서 처리됩니다.

**이미지 저장 핸들러가 `false`를 반환하면 어떻게 되나요?**

Aspose.Slides는 기본 로컬 저장 동작을 사용합니다. 이미지 위치와 생성된 참조는 [MarkdownSaveOptions.BasePath](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/basepath/) 및 [MarkdownSaveOptions.ImagesSaveFolderName](https://reference.aspose.com/slides/ko/net/aspose.slides.export/markdownsaveoptions/imagessavefoldername/)에 따라 제어됩니다.

**핸들러가 이미지를 로컬에 저장하지 않고 URL만 제공할 수 있나요?**

예. 핸들러가 이미지를 객체 스토리지에 업로드하거나 다른 서비스에 전달하고, 결과 URL을 `link`에 할당한 뒤 `true`를 반환할 수 있습니다. 핸들러가 직접 처리를 완료해야 하며, `true`를 반환하면 기본 로컬 저장이 방지됩니다.

**핸들러에서 `InvalidOperationException`이 발생하는 이유는 무엇인가요?**

핸들러가 `true`를 반환했지만 유효한 링크를 제공하지 않을 때 발생합니다. `true`를 반환하기 전에 Markdown에 기록될 상대 경로나 외부 URL을 반드시 할당하십시오.

**이미지 링크에 어떤 경로 구분자를 사용해야 하나요?**

Markdown 링크와 URL에서는 슬래시(`/`)를 사용하십시오. 파일 시스템 경로를 만들 때는 `Path.Combine`을 사용하고, Markdown 참조는 별도로 구성하거나 정규화하십시오.

**Markdown 내보내기 시 하이퍼링크가 유지됩니까?**

예. 텍스트 [hyperlinks](/slides/ko/net/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/net/slide-transition/)와 [animations](/slides/ko/net/powerpoint-animation/)는 변환되지 않습니다.

**프레젠테이션을 병렬로 Markdown으로 변환할 수 있나요?**

다른 프레젠테이션 파일을 병렬로 처리할 수 있지만, 동일한 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 스레드 간에 공유하지 마십시오. [multithreading guidelines](/slides/ko/net/multithreading/)를 따르고 파일당 별도 인스턴스를 사용하십시오.