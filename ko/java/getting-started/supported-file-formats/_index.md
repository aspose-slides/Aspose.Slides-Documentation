---
title: 지원 파일 형식
type: docs
weight: 106
url: /ko/java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java가 로드, 가져오기, 저장 및 렌더링할 수 있는 파일 형식과 각각을 읽거나 쓰는 API를 확인하십시오."
---
## **개요**

Aspose.Slides for Java은 PowerPoint 및 OpenDocument 프레젠테이션을 열고 저장합니다. 또한 PDF와 HTML 콘텐츠를 슬라이드로 가져오고, 프레젠테이션을 문서, 웹 및 이미지 형식으로 저장하며, 개별 슬라이드와 도형을 이미지로 렌더링합니다. 이 기사에서는 지원되는 각 형식을 나열하고 해당 형식을 읽거나 쓰는 API를 명시합니다.

편집 기능에 대한 개요는 [Features Overview](/slides/ko/java/features-overview/)를 참조하십시오.

## **Supported Microsoft PowerPoint Versions**

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
PowerPoint 95 및 이전 버전으로 저장된 프레젠테이션은 열 수 없습니다. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)은 PowerPoint 95 파일을 인식하고 `LoadFormat.Ppt95`를 보고하지만, [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 생성자는 해당 파일에 대해 [PptUnsupportedFormatException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pptunsupportedformatexception/)을 발생시킵니다.
{{% /alert %}}

## **Supported File Formats**

표는 네 가지 작업을 사용합니다:

- **Load**: [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 생성자가 파일을 편집 가능한 프레젠테이션으로 엽니다.
- **Import**: [SlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/) 메서드가 파일의 콘텐츠에서 슬라이드를 생성하고 기존 프레젠테이션에 추가합니다. Presentation 생성자는 이러한 파일을 슬라이드로 변환하지 않습니다.
- **Save**: [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드가 프레젠테이션을 파일 또는 스트림에 기록합니다. XAML을 제외한 모든 형식은 [SaveFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/) 값으로 선택됩니다.
- **Render**: 렌더링 메서드가 슬라이드 또는 도형을 이미지로 그립니다. 렌더링 전용 형식은 SaveFormat 값이 없습니다.

|**형식**|**설명**|**로드 / 가져오기**|**저장 / 렌더링**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 프레젠테이션|로드|저장|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 템플릿|로드|저장|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 슬라이드 쇼|로드|저장|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint 프레젠테이션|로드|저장|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint 템플릿|로드|저장|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint 슬라이드 쇼|로드|저장|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint 매크로 사용 프레젠테이션|로드|저장|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint 매크로 사용 템플릿|로드|저장|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint 매크로 사용 슬라이드 쇼|로드|저장|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument 프레젠테이션|로드|저장|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat XML OpenDocument 프레젠테이션|로드|저장|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument 프레젠테이션 템플릿|로드|저장|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML 프레젠테이션|로드|저장|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|가져오기|저장|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|가져오기|저장|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|저장|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|저장, 렌더링|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|저장, 렌더링|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|저장|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|저장|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|저장|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|렌더링|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG Image|—|렌더링|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap Image|—|렌더링|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|렌더링|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|렌더링|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Load and Import**

- **Load:** 파일 경로 또는 스트림을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) 생성자에 전달합니다. 형식은 내용에서 감지되며, [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/)를 사용해 비밀번호와 같은 설정을 지정할 수 있습니다. 파일을 열기 전에 확인하려면 [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)를 호출하면 [LoadFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadformat/) 값을 반환합니다. PowerPoint XML 파일은 `LoadFormat.Unknown`을 보고하지만 생성자는 해당 파일을 열 수 있으며, 이후 [Presentation.getSourceFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSourceFormat--)가 `SourceFormat.Xml`을 반환합니다. 자세한 내용은 [Open Presentations](/slides/ko/java/open-presentation/) 및 [Determine the Original Presentation Format](/slides/ko/java/detect-presentation-source-format/)를 참조하십시오.
- **Import:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-)는 PDF 페이지당 한 슬라이드를 프레젠테이션 끝에 추가합니다. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-)은 HTML에서 만든 슬라이드를 추가하고, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-)는 지정 위치에 삽입합니다. Presentation 생성자는 가져오기를 수행하지 않으며, PDF 파일에 대해 [PptUnsupportedFormatException](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pptunsupportedformatexception/)을 발생시키고 HTML 마크업을 슬라이드 콘텐츠로 변환하지 않습니다. 자세한 내용은 [Import Presentations from PDF or HTML](/slides/ko/java/import-presentation/)를 참조하십시오.

## **Save and Render**

- **Save:** [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드는 [SaveFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveformat/) 값에 따라 프레젠테이션을 저장합니다. 옵션 객체를 추가로 받는 오버로드를 사용해 출력 형식을 제어할 수 있으며, 예를 들어 [PdfOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/tiffoptions/), [GifOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/gifoptions/)가 있습니다. 슬라이드 번호 배열(1부터 시작)을 인수로 받는 오버로드는 해당 슬라이드만 저장합니다; 이 기능은 PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, Markdown에 대해 지원하지만 프레젠테이션 형식이나 PowerPoint XML에는 지원되지 않습니다. XAML은 별도의 오버로드인 [Presentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-)를 사용하며, 여기서는 [IXamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ixamloptions/)를 전달합니다. 자세한 내용은 [Save Presentations](/slides/ko/java/save-presentation/), [Convert Presentations](/slides/ko/java/convert-presentation/), 그리고 [Export Presentations to XAML](/slides/ko/java/export-to-xaml/)를 참조하십시오.
- **Render:** [Slide.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#getImage-float-float-)와 [Shape.getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#getImage--)는 [IImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/)를 반환하고, [IImage.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 메서드가 PNG, JPEG, BMP, GIF, TIFF 중 하나로 저장합니다. 저장 형식은 [ImageFormat](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imageformat/) 값으로 선택됩니다. [Presentation.getImages](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-)는 모든 슬라이드 또는 선택된 슬라이드를 한 번에 렌더링합니다. [Slide.writeAsSvg](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-)와 [Shape.writeAsSvg](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-)는 SVG를, [Slide.writeAsEmf](https://reference.aspose.com/slides/ko/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-)는 EMF를 기록합니다. 자세한 내용은 [Convert Presentation Slides to Images](/slides/ko/java/convert-slide/) 및 [Render Presentation Slides as SVG Images](/slides/ko/java/render-a-slide-as-an-svg-image/)를 참조하십시오.

{{% alert color="warning" title="Warning" %}}
ImageFormat에도 `Emf`, `Wmf`, `Icon`, `Exif`, `MemoryBmp` 값이 있지만, IImage.save는 이러한 형식을 생성하지 않습니다. 파일에 기록되는 데이터는 PNG 형식입니다. 슬라이드의 EMF 이미지를 얻으려면 Slide.writeAsEmf를 사용하십시오.
{{% /alert %}}

## **FAQ**

**PPT 프레젠테이션을 PPTX 또는 ODP로 변환할 수 있나요?**

예. PPT 파일을 Presentation 생성자로 열고 `SaveFormat.Pptx` 또는 `SaveFormat.Odp`로 저장하면 됩니다. 자세한 내용은 [Convert PPT to PPTX](/slides/ko/java/convert-ppt-to-pptx/)를 참조하십시오.

**PDF 또는 HTML 파일을 프레젠테이션으로 열 수 있나요?**

아니요. Presentation 생성자는 PDF 파일에 대해 PptUnsupportedFormatException을 발생시키고 HTML 마크업을 슬라이드로 변환하지 않습니다. 프레젠테이션을 생성하거나 연 후, 위에 설명된 슬라이드 컬렉션 메서드로 PDF 페이지 또는 HTML 콘텐츠를 가져온 뒤 지원되는 형식으로 저장하십시오.

**내보낸 PNG 또는 SVG 이미지를 편집 가능한 프레젠테이션으로 로드할 수 있나요?**

아니요. 이미지 출력은 슬라이드의 시각적 형태만 기록하며 텍스트, 도형, 차트 등은 포함하지 않습니다. 나중에 편집이 필요하면 원본 프레젠테이션을 보관하십시오.

**PDF/A 또는 PDF/UA 문서를 저장할 수 있나요?**

예. [PdfCompliance](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfcompliance/) 값을 [PdfOptions.setCompliance](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfoptions/#setCompliance-int-)에 전달하면 됩니다. 지원되는 옵션은 PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, PDF/UA입니다.

**파일이 암호로 보호되어 있는지 열기 전에 확인할 수 있나요?**

예. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)는 Presentation 객체를 만들지 않고 파일을 검사하며, [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)가 암호가 필요한지 여부를 반환합니다. 자세한 내용은 [Password-Protect Presentations](/slides/ko/java/password-protected-presentation/)를 참조하십시오.