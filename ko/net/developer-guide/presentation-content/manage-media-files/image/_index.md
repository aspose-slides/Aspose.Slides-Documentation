---
title: .NET 프레젠테이션에서 이미지 관리 최적화
linktitle: 이미지 관리
type: docs
weight: 10
url: /ko/net/image/
keywords:
- 이미지 추가
- 그림 추가
- 비트맵 추가
- 이미지 교체
- 그림 교체
- 웹에서
- 배경
- PNG 추가
- JPG 추가
- SVG 추가
- 외부 SVG 리소스
- SVG 리졸버
- 연결된 SVG 이미지
- SVG 글꼴
- EMF 추가
- WMF 추가
- TIFF 추가
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint와 OpenDocument의 이미지 관리를 효율화하고 성능을 최적화하며 워크플로를 자동화합니다."
---
## **소개**

이미지는 프레젠테이션을 보다 매력적이고 시각적으로 돋보이게 합니다. Microsoft PowerPoint에서는 파일, 인터넷 또는 기타 소스에서 사진을 슬라이드에 삽입할 수 있습니다. 마찬가지로 Aspose.Slides를 사용하면 여러 가지 방법으로 프레젠테이션 슬라이드에 이미지를 추가할 수 있습니다.

{{% alert  title="팁" color="primary" %}} 
Aspose는 무료 변환기인 [JPEG를 PowerPoint로](https://products.aspose.app/slides/ko/import/jpg-to-ppt) 및 [PNG를 PowerPoint로](https://products.aspose.app/slides/ko/import/png-to-ppt)를 제공하여 이미지를 빠르게 프레젠테이션으로 만들 수 있게 합니다. 
{{% /alert %}} 

{{% alert title="정보" color="info" %}}
이미지를 그림 프레임으로 추가하고 싶다면—특히 크기를 조정하거나 효과를 적용하거나 기타 표준 서식 옵션을 사용할 계획이라면—[그림 프레임](/slides/ko/net/picture-frame/)을 참조하십시오. 
{{% /alert %}} 

{{% alert title="참고" color="warning" %}}
이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 다음 페이지를 참조하십시오: 변환 [이미지를 JPG로](https://products.aspose.com/slides/ko/net/conversion/image-to-jpg/), [JPG를 이미지로](https://products.aspose.com/slides/ko/net/conversion/jpg-to-image/), [JPG를 PNG로](https://products.aspose.com/slides/ko/net/conversion/jpg-to-png/), [PNG를 JPG로](https://products.aspose.com/slides/ko/net/conversion/png-to-jpg/), [PNG를 SVG로](https://products.aspose.com/slides/ko/net/conversion/png-to-svg/), 및 [SVG를 PNG로](https://products.aspose.com/slides/ko/net/conversion/svg-to-png/).
{{% /alert %}}

Aspose.Slides는 JPEG, PNG, BMP, GIF 등과 같은 일반적인 형식의 이미지를 지원합니다.

## **로컬에 저장된 이미지를 슬라이드에 추가**

컴퓨터에 저장된 하나 이상의 이미지를 프레젠테이션 슬라이드에 추가할 수 있습니다. 다음 C# 샘플 코드는 슬라이드에 이미지를 추가하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **웹에서 이미지를 슬라이드에 추가**

슬라이드에 추가하려는 이미지가 컴퓨터에 저장되어 있지 않은 경우 웹에서 직접 추가할 수 있습니다. 

다음 C# 샘플 코드는 웹에서 이미지를 슬라이드에 추가하는 방법을 보여줍니다:

```c#
using System.Net;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **슬라이드 마스터에 이미지 추가**

슬라이드 마스터는 해당 마스터를 사용하는 슬라이드의 테마와 레이아웃과 같은 정보를 저장하고 제어합니다. 슬라이드 마스터에 이미지를 추가하면 해당 마스터를 기반으로 하는 모든 슬라이드에 이미지가 표시됩니다. 

다음 C# 샘플 코드는 슬라이드 마스터에 이미지를 추가하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **이미지를 슬라이드 배경으로 추가**

하나 이상의 슬라이드에 그림을 배경으로 사용할 수 있습니다. 자세한 내용은 *[슬라이드 배경으로 이미지 설정](/slides/ko/net/presentation-background/#setting-images-as-background-for-slides)*을 참조하십시오.

## **프레젠테이션에 SVG 추가**

SVG 콘텐츠는 [SvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/svgimage/) 클래스를 사용하여 프레젠테이션에 추가할 수 있습니다. 결과 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 객체는 프레젠테이션 이미지 컬렉션에 추가된 후 그림 프레임을 만드는 데 사용할 수 있습니다.

다음 C# 예제는 자체 포함된 SVG 문자열을 가져옵니다. 이 SVG에서 사용하는 모든 이미지, 스타일 및 기타 리소스가 SVG 콘텐츠에 직접 포함됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string svgContent = @"
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>";

using (Presentation presentation = new Presentation())
{
    ISvgImage svgImage = new SvgImage(svgContent);
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("self-contained-svg.pptx", SaveFormat.Pptx);
}
```

## **외부 리소스가 포함된 SVG 콘텐츠 가져오기**

디자인 도구, 다이어그램 편집기, 아이콘 시스템 및 웹 파이프라인에서 내보낸 SVG 파일은 SVG 문서 외부에 저장된 리소스를 참조할 수 있습니다. 예를 들어 SVG는 `images/photo.png`와 같은 이미지 링크, CSS `url(...)` 값 또는 글꼴 URL을 포함할 수 있습니다.

이러한 SVG 콘텐츠를 가져오려면 [IExternalResourceResolver](https://reference.aspose.com/slides/ko/net/aspose.slides.import/iexternalresourceresolver/) 구현을 만들고 기본 URI와 함께 적절한 `SvgImage` 생성자에 전달합니다. 기본 URI는 SVG 문서의 위치를 식별하고 상대 링크를 해결하는 데 사용됩니다.

[ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage/) 인터페이스는 가져온 SVG에 대한 정보를 제공합니다:

- `SvgContent`는 SVG 마크업을 문자열로 반환합니다.
- `SvgData`는 SVG 콘텐츠를 바이트 배열로 반환합니다.
- `BaseUri`는 상대 링크에 사용되는 기본 URI를 반환합니다.
- `ExternalResourceResolver`는 SVG 이미지에 할당된 리졸버를 반환합니다.

### **외부 리소스 리졸버 구현**

리졸버에는 두 가지 메서드가 있습니다:

- [ResolveUri](https://reference.aspose.com/slides/ko/net/aspose.slides.import/iexternalresourceresolver/resolveuri/)는 기본 URI와 상대 리소스 링크를 결합하여 절대 URI를 반환합니다. 링크를 해결할 수 없거나 허용되지 않은 경우 `null`을 반환합니다.
- [GetEntity](https://reference.aspose.com/slides/ko/net/aspose.slides.import/iexternalresourceresolver/getentity/)는 절대 리소스 URI에 대한 읽기 가능한 스트림을 반환합니다. 리소스가 없거나 차단되었거나 이용할 수 없는 경우 `null`을 반환합니다. 필요한 경우 대체 스트림을 반환할 수도 있습니다.

다음 리졸버는 허용된 로컬 디렉터리에서만 연결된 리소스를 로드합니다. 네트워크 리소스와 허용 디렉터리 밖의 경로는 차단됩니다. 해결되지 않은 이미지 링크에 대해 선택적인 대체 이미지가 반환됩니다.

```csharp
using System;
using System.IO;
using Aspose.Slides.Import;

internal sealed class LocalSvgResourceResolver : IExternalResourceResolver
{
    private readonly string _allowedRoot;
    private readonly byte[] _fallbackImageData;

    public LocalSvgResourceResolver(string allowedRoot, byte[] fallbackImageData = null)
    {
        _allowedRoot = Path.GetFullPath(allowedRoot);
        _fallbackImageData = fallbackImageData;
    }

    public string ResolveUri(string baseUri, string relativeUri)
    {
        if (string.IsNullOrWhiteSpace(baseUri) ||
            string.IsNullOrWhiteSpace(relativeUri))
        {
            return null;
        }

        if (!Uri.TryCreate(baseUri, UriKind.Absolute, out Uri baseAddress) ||
            !Uri.TryCreate(baseAddress, relativeUri, out Uri absoluteAddress))
        {
            return null;
        }

        // 이 리졸버는 의도적으로 로컬 파일만 허용합니다.
        if (!absoluteAddress.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(absoluteAddress.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        return absoluteAddress.AbsoluteUri;
    }

    public Stream GetEntity(string absoluteUri)
    {
        if (!Uri.TryCreate(absoluteUri, UriKind.Absolute, out Uri resourceUri) ||
            !resourceUri.IsFile)
        {
            return null;
        }

        string resourcePath = Path.GetFullPath(resourceUri.LocalPath);
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return null;
        }

        if (File.Exists(resourcePath))
        {
            return File.OpenRead(resourcePath);
        }

        // 이미지 리소스에만 대체를 사용합니다. 누락된 글꼴이나 스타일시트에 대한 이미지 스트림을 반환하는 것은 유효하지 않습니다.
        if (_fallbackImageData != null && IsImageFile(resourcePath))
        {
            return new MemoryStream(_fallbackImageData, writable: false);
        }

        return null;
    }

    private bool IsInsideAllowedRoot(string resourcePath)
    {
        string normalizedRoot = _allowedRoot.TrimEnd(
            Path.DirectorySeparatorChar,
            Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;

        string normalizedPath = Path.GetFullPath(resourcePath);
        StringComparison comparison = Path.DirectorySeparatorChar == '\\'
            ? StringComparison.OrdinalIgnoreCase
            : StringComparison.Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               string.Equals(normalizedPath, _allowedRoot, comparison);
    }

    private static bool IsImageFile(string path)
    {
        string extension = Path.GetExtension(path);

        return extension.Equals(".png", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
               extension.Equals(".bmp", StringComparison.OrdinalIgnoreCase);
    }
}
```

### **SVG 가져오기 중 연결된 리소스 해결**

`assets/diagram.svg`에 다음과 같은 상대 참조가 포함되어 있다고 가정합니다:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

다음 C# 예제는 SVG 파일 URI를 기본 URI로 전달하고 사용자 지정 리졸버를 제공합니다. 리졸버는 상대 이미지 링크를 절대 URI로 변환하고 Aspose.Slides가 SVG를 처리하는 동안 연결된 리소스를 포함하는 스트림을 반환합니다.

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;

string svgFilePath = Path.GetFullPath(Path.Combine("assets", "diagram.svg"));
string assetDirectory = Path.GetDirectoryName(svgFilePath) ?? Directory.GetCurrentDirectory();
string svgContent = File.ReadAllText(svgFilePath);

// 기본 URI는 SVG 문서의 위치를 나타냅니다.
string baseUri = new Uri(svgFilePath).AbsoluteUri;

byte[] fallbackImageData = null;
string fallbackImagePath = Path.Combine(assetDirectory, "fallback.png");
if (File.Exists(fallbackImagePath))
{
    fallbackImageData = File.ReadAllBytes(fallbackImagePath);
}

IExternalResourceResolver resolver = new LocalSvgResourceResolver(assetDirectory, fallbackImageData);
ISvgImage svgImage = new SvgImage(svgContent, resolver, baseUri);

// ISvgImage는 원본 콘텐츠, 바이너리 데이터, 기본 URI 및 리졸버를 노출합니다.
string importedContent = svgImage.SvgContent;
byte[] importedData = svgImage.SvgData;
string importedBaseUri = svgImage.BaseUri;
IExternalResourceResolver importedResolver = svgImage.ExternalResourceResolver;

using (Presentation presentation = new Presentation())
{
    IPPImage image = presentation.Images.AddImage(svgImage);

    presentation.Slides[0].Shapes.AddPictureFrame(
        ShapeType.Rectangle, 20, 20, image.Width, image.Height, image);

    presentation.Save("svg-with-linked-resources.pptx", SaveFormat.Pptx);
}
```

`SvgImage` 클래스는 외부 리소스 리졸버와 기본 URI와 함께 SVG 데이터를 바이트 배열 또는 스트림으로 받아들이는 오버로드도 제공합니다.

{{% alert title="중요" color="warning" %}}
리소스 리졸버는 Aspose.Slides가 SVG를 처리하고 렌더링하는 동안 외부 리소스를 사용할 수 있게 합니다. 원본 SVG 마크업을 수정하거나 해결된 리소스를 자동으로 삽입하지는 않습니다.

`ISvgImage`가 프레젠테이션 이미지 컬렉션에 추가될 때 PPTX 파일은 원본 SVG 표현과 래스터 대체 이미지를 모두 포함할 수 있습니다. 연결된 리소스는 생성된 대체 이미지에 나타날 수 있지만 `images/photo.png`와 같은 상대 링크는 저장된 SVG에 그대로 유지됩니다. 따라서 원본 외부 리소스를 사용할 수 없을 경우 네이티브 SVG 표현을 렌더링하는 애플리케이션은 해당 연결된 콘텐츠를 생략할 수 있습니다.
{{% /alert %}}

### **휴대용 SVG 그림 만들기**

외부 파일에 의존하지 않는 SVG 그림을 만들려면 `SvgImage`를 만들기 전에 SVG를 자체 포함하도록 구성합니다. 예를 들어, 연결된 이미지 URL을 이미지 데이터를 포함하는 `data:` URI로 교체합니다:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

필요한 모든 리소스가 SVG 콘텐츠에 포함되면 `SvgImage`를 생성하고 프레젠테이션 이미지 컬렉션에 추가한 다음 이전 예제와 같이 그림 프레임에 삽입합니다.

### **누락되거나 차단된 리소스 처리**

`ResolveUri`에서 리소스 URI가 잘못되었거나 금지되었거나 해결할 수 없는 경우 `null`을 반환합니다. `GetEntity`에서 리소스를 읽을 수 없을 때 `null`을 반환합니다. 가능한 경우 Aspose.Slides는 해당 리소스 없이 SVG 처리를 계속합니다.

누락된 리소스에 대해 대체 스트림을 반환할 수 있지만 해당 내용은 요청된 리소스 유형과 호환되어야 합니다. 예를 들어, 누락된 이미지에 대해서만 이미지 스트림을 반환하고 글꼴이나 스타일시트에 대해서는 반환하지 않습니다.

{{% alert title="보안" color="warning" %}}
신뢰할 수 없는 SVG 파일에서 임의의 파일 경로나 무제한 네트워크 URL을 해결하지 마십시오. 허용된 스킴, 디렉터리 및 호스트를 제한하십시오. 네트워크 리소스에 대해서는 연결 시간 초과, 응답 크기 제한 및 콘텐츠 검증도 적용하십시오.
{{% /alert %}}

## **SVG를 도형 집합으로 변환**

Aspose.Slides는 PowerPoint의 해당 기능과 유사하게 SVG를 도형 집합으로 변환할 수 있습니다:

![PowerPoint Popup Menu](img_01_01.png)

이 기능은 [IShapeCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection) 인터페이스의 [AddGroupShape](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/addgroupshape/methods/1) 메서드 오버로드에 의해 제공되며, 첫 번째 인수로 [ISvgImage](https://reference.aspose.com/slides/ko/net/aspose.slides/isvgimage) 객체를 받습니다.

다음 C# 샘플 코드는 이 메서드를 사용하여 SVG 파일을 도형 집합으로 변환하는 방법을 보여줍니다:

``` csharp 
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// 원본 SVG 파일 이름
string svgFileName = "sample.svg";

// 출력 프레젠테이션 파일 이름
string outPptxPath = "presentation.pptx";

// 새 프레젠테이션 생성
using (IPresentation presentation = new Presentation())
{
    // SVG 파일 내용을 읽음
    string svgContent = File.ReadAllText(svgFileName);

    // SvgImage 객체 생성
    ISvgImage svgImage = new SvgImage(svgContent);

    // 슬라이드 크기 가져오기
    SizeF slideSize = presentation.SlideSize.Size;

    // SVG 이미지를 도형 그룹으로 변환하고 슬라이드 크기에 맞게 확대/축소
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // 프레젠테이션을 PPTX 형식으로 저장
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **이미지를 EMF로 슬라이드에 추가**

Aspose.Slides for .NET을 사용하면 Aspose.Cells를 이용해 Excel 워크시트에서 EMF 이미지를 생성하고 이를 프레젠테이션 슬라이드에 추가할 수 있습니다.

다음 C# 샘플 코드는 이를 수행하는 방법을 보여줍니다:

``` csharp 
using Aspose.Slides;
using Aspose.Cells;
using Aspose.Cells.Rendering;


using (Workbook book = new Workbook("chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageType = Aspose.Cells.Drawing.ImageType.Emf;

    // 워크북을 스트림에 저장
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save("Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **이미지 컬렉션에서 이미지 교체**

Aspose.Slides를 사용하면 프레젠테이션의 이미지 컬렉션에 저장된 이미지(슬라이드 도형에서 사용하는 이미지 포함)를 교체할 수 있습니다. 이 섹션에서는 컬렉션의 이미지를 업데이트하는 여러 방법을 설명합니다. 원시 바이트 데이터, [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 인스턴스 또는 컬렉션에 이미 존재하는 다른 이미지를 사용하여 이미지를 교체할 수 있습니다.

다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 사용하여 이미지를 포함하는 프레젠테이션 파일을 로드합니다.
2. 파일에서 새 이미지를 로드하여 바이트 배열에 저장합니다.
3. 바이트 배열을 사용하여 대상 이미지를 새 이미지로 교체합니다.
4. 두 번째 방법에서는 이미지를 [IImage](https://reference.aspose.com/slides/ko/net/aspose.slides/iimage/) 객체에 로드하고 해당 객체로 대상 이미지를 교체합니다.
5. 세 번째 방법에서는 프레젠테이션의 이미지 컬렉션에 이미 존재하는 이미지를 사용하여 대상 이미지를 교체합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("sample.pptx");

// 첫 번째 방법.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// 두 번째 방법.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// 세 번째 방법.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// 프레젠테이션을 파일로 저장합니다.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="정보" color="info" %}}
Aspose의 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 사용하면 텍스트를 쉽게 애니메이션화하고 텍스트에서 GIF를 만들 수 있습니다. 
{{% /alert %}}

## **FAQ**

**삽입 후 원본 이미지 해상도가 그대로 유지됩니까?**

예. 원본 픽셀은 보존되지만 최종 외관은 슬라이드에서 [그림](/slides/ko/net/picture-frame/)가 어떻게 스케일링되는지와 저장 시 적용되는 압축에 따라 달라집니다.

**수십 개의 슬라이드에서 동일한 로고를 한 번에 교체하는 가장 좋은 방법은 무엇입니까?**

마스터 슬라이드 또는 레이아웃에 로고를 배치하고 프레젠테이션의 이미지 컬렉션에서 교체합니다—업데이트가 해당 리소스를 사용하는 모든 요소에 전파됩니다.

**삽입된 SVG를 편집 가능한 도형으로 변환할 수 있습니까?**

예. SVG를 도형 그룹으로 변환할 수 있으며, 이후 개별 부분을 표준 도형 속성으로 편집할 수 있습니다.

**여러 슬라이드에 한 번에 그림을 배경으로 설정하려면 어떻게 해야 합니까?**

[이미지를 배경으로 지정](/slides/ko/net/presentation-background/)하면 마스터 슬라이드 또는 해당 레이아웃에 적용되어 해당 마스터/레이아웃을 사용하는 모든 슬라이드가 배경을 상속합니다.

**많은 그림 때문에 프레젠테이션 파일이 너무 커지는 것을 어떻게 방지할 수 있습니까?**

중복 이미지 대신 단일 이미지 리소스를 재사용하고, 합리적인 해상도를 선택하며, 저장 시 압축을 적용하고, 반복되는 그래픽은 가능한 경우 마스터에 보관하십시오.