---
title: 지원되는 파일 형식
type: docs
weight: 96
url: /ko/net/supported-file-formats/
keywords:
- 지원 파일 형식
- 프레젠테이션 로드
- PDF 가져오기
- HTML 가져오기
- 프레젠테이션 저장
- 슬라이드 렌더링
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 로드, 가져오기, 저장 및 렌더링할 수 있는 파일 형식과 각각을 읽거나 쓰는 API를 확인하십시오."
---
## **개요**

Aspose.Slides for .NET은 PowerPoint 및 OpenDocument 프레젠테이션을 열고 저장합니다. 또한 PDF 및 HTML 콘텐츠를 슬라이드에 가져오고, 프레젠테이션을 문서, 웹 및 이미지 형식으로 저장하며, 개별 슬라이드와 도형을 이미지로 렌더링합니다. 이 문서에서는 지원되는 각 형식을 나열하고 해당 형식을 읽거나 쓰는 API를 명시합니다.

Aspose.Slides.NET 및 Aspose.Slides.NET6.CrossPlatform 두 NuGet 패키지는 동일한 형식을 지원합니다; 어떤 패키지를 사용할지 선택하려면 [설치](/slides/ko/net/installation/)를 참조하세요. 편집 기능 개요를 보려면 [기능 개요](/slides/ko/net/features-overview/)를 확인하십시오.

## **지원되는 Microsoft PowerPoint 버전**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}
PowerPoint 95 및 이전 버전에서 저장된 프레젠테이션은 열 수 없습니다. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/)는 PowerPoint 95 파일을 인식하고 `LoadFormat.Ppt95`를 보고하지만, [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) 생성자는 해당 파일에 대해 [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/)을 발생시킵니다.
{{% /alert %}}

## **지원되는 파일 형식**

표에는 네 가지 작업이 사용됩니다:

- **Load**: [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) 생성자는 파일을 편집 가능한 프레젠테이션으로 엽니다. 형식은 내용에서 감지되며, [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)을 사용해 비밀번호와 같은 설정을 지정할 수 있습니다. 파일을 열기 전에 확인하려면 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/)를 호출하면 [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/) 값을 반환합니다. PowerPoint XML 파일은 `LoadFormat.Unknown`을 보고하지만 생성자는 해당 파일을 열고, 이후 [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/)이 `SourceFormat.Xml`을 반환합니다. 자세한 내용은 [프레젠테이션 열기](/slides/ko/net/open-presentation/)와 [원본 프레젠테이션 형식 결정](/slides/ko/net/detect-presentation-source-format/)을 참조하십시오.
- **Import**: [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/) 메서드는 파일의 내용을 슬라이드로 변환하여 기존 프레젠테이션에 추가합니다. Presentation 생성자는 이러한 파일을 프레젠테이션으로 로드하지 않습니다.
- **Save**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)는 프레젠테이션을 파일이나 스트림에 기록합니다. XAML을 제외한 모든 형식은 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 값을 사용해 선택됩니다.
- **Render**: 렌더링 메서드는 슬라이드 또는 도형을 이미지로 출력합니다. 렌더링 전용 형식은 SaveFormat 값이 없습니다.

|**형식**|**설명**|**로드 / 가져오기**|**저장 / 렌더링**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 프레젠테이션|로드|저장|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 템플릿|로드|저장|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 슬라이드쇼|로드|저장|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 프레젠테이션|로드|저장|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 템플릿|로드|저장|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 슬라이드쇼|로드|저장|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|매크로 사용 가능 PowerPoint 프레젠테이션|로드|저장|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|매크로 사용 가능 PowerPoint 템플릿|로드|저장|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|매크로 사용 가능 PowerPoint 슬라이드쇼|로드|저장|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 프레젠테이션|로드|저장|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|플랫 XML OpenDocument 프레젠테이션|로드|저장|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 프레젠테이션 템플릿|로드|저장|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 프레젠테이션|로드|저장|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|PDF(Portable Document Format)|가져오기|저장|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|HTML(Hypertext Markup Language)|가져오기|저장|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|저장|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|태그 이미지 파일 형식|—|저장, 렌더링|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|저장, 렌더링|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format(Flash)|—|저장|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|저장|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|저장|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|렌더링|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG 이미지|—|렌더링|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap 이미지|—|렌더링|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|렌더링|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|렌더링|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **로드 및 가져오기**

- **Load:** 파일 경로나 스트림을 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) 생성자에 전달합니다. 형식은 내용에서 자동 감지되며, [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/)을 통해 비밀번호와 같은 설정을 지정할 수 있습니다. 파일을 열기 전에 확인하려면 [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/)를 호출하면 [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/) 값을 반환합니다. PowerPoint XML 파일은 `LoadFormat.Unknown`을 보고하지만 생성자는 파일을 열고, 이후 [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/)이 `SourceFormat.Xml`을 반환합니다. 자세한 내용은 [프레젠테이션 열기](/slides/ko/net/open-presentation/)와 [원본 프레젠테이션 형식 결정](/slides/ko/net/detect-presentation-source-format/)을 참조하십시오.
- **Import:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/)은 PDF 페이지당 하나의 슬라이드를 프레젠테이션 끝에 추가합니다. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/)은 HTML에서 만든 슬라이드를 추가하고, [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/)은 지정 위치에 삽입합니다. Presentation 생성자는 가져오기를 수행하지 않으며 PDF 파일에 대해 [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/)을 발생시키고 HTML 마크업을 슬라이드 내용으로 변환하지 않습니다. 자세한 내용은 [PDF 또는 HTML에서 프레젠테이션 가져오기](/slides/ko/net/import-presentation/)를 확인하십시오.

## **저장 및 렌더링**

- **Save:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)은 [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/) 값에 따라 프레젠테이션을 파일에 기록합니다. 옵션 객체를 함께 사용하는 오버로드를 통해 출력 형식을 제어할 수 있으며, 예를 들어 [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/), [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/)이 있습니다. 슬라이드 번호 배열(1부터 시작)을 지정하는 오버로드는 해당 슬라이드만 저장하며, PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, Markdown을 지원하지만 프레젠테이션 형식이나 PowerPoint XML은 지원하지 않습니다. XAML은 [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/)을 사용하는 별도 오버로드가 있습니다. 자세한 내용은 [프레젠테이션 저장](/slides/ko/net/save-presentation/), [프레젠테이션 변환](/slides/ko/net/convert-presentation/), [XAML로 프레젠테이션 내보내기](/slides/ko/net/export-to-xaml/)를 참조하십시오.
- **Render:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/)와 [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/)는 [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/)를 반환하고, [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/)를 통해 PNG, JPEG, BMP, GIF, TIFF 등 [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) 값으로 저장합니다. [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/)는 모든 슬라이드 또는 선택된 슬라이드를 한 번에 렌더링합니다. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/)와 [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/)는 SVG를, [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/)는 EMF를 작성합니다. 자세한 내용은 [슬라이드를 이미지로 변환](/slides/ko/net/convert-slide/) 및 [슬라이드를 SVG 이미지로 렌더링](/slides/ko/net/render-a-slide-as-an-svg-image/)을 확인하십시오.

{{% alert color="warning" title="Warning" %}}
ImageFormat에도 `Emf`, `Wmf`, `Icon`, `Exif`, `MemoryBmp` 값이 있지만 IImage.Save는 해당 형식을 생성하지 않습니다: 저장되는 파일은 PNG 데이터가 포함됩니다. 슬라이드의 EMF 이미지를 얻으려면 Slide.WriteAsEmf를 사용하십시오.
{{% /alert %}}

## **FAQ**

**PPT 프레젠테이션을 PPTX 또는 ODP로 변환할 수 있나요?**

예. PPT 파일을 Presentation 생성자로 연 후 `SaveFormat.Pptx` 또는 `SaveFormat.Odp`로 저장하면 됩니다. 자세한 내용은 [PPT를 PPTX로 변환](/slides/ko/net/convert-ppt-to-pptx/)을 참조하십시오.

**PDF 또는 HTML 파일을 프레젠테이션으로 열 수 있나요?**

아니요. 프레젠테이션을 새로 만들거나 연 후, 위에서 설명한 슬라이드 컬렉션 메서드를 사용해 PDF 페이지나 HTML 콘텐츠를 가져온 다음 원하는 형식으로 저장하십시오.

**내보낸 PNG 또는 SVG 이미지를 편집 가능한 프레젠테이션으로 로드할 수 있나요?**

아니요. 이미지 출력은 슬라이드가 어떻게 보이는지를 기록할 뿐이며 텍스트, 도형, 차트 등은 포함하지 않습니다. 나중에 편집이 필요하면 원본 프레젠테이션을 보관하십시오.

**PDF/A 또는 PDF/UA 문서를 저장할 수 있나요?**

예. [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/)에 [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) 값을 설정하면 됩니다: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, PDF/UA.

**파일이 비밀번호로 보호되었는지 열기 전에 확인할 수 있나요?**

예. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/)는 Presentation 객체를 만들지 않고 파일을 검사하며, 그 [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/) 속성이 비밀번호가 필요한지 여부를 반환합니다. 자세한 내용은 [프레젠테이션 비밀번호 보호](/slides/ko/net/password-protected-presentation/)를 확인하십시오.

**두 NuGet 패키지가 지원하는 형식이 다르나요?**

아니요. Aspose.Slides.NET과 Aspose.Slides.NET6.CrossPlatform은 동일한 LoadFormat 및 SaveFormat 값과 동일한 가져오기 및 렌더링 메서드를 제공합니다. 차이점은 실행 플랫폼과 해당 플랫폼 요구 사항에 있습니다; 자세한 내용은 [설치](/slides/ko/net/installation/)를 참조하십시오.