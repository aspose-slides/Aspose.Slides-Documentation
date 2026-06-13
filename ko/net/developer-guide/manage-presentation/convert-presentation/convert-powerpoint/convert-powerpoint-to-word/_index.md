---
title: PowerPoint 프레젠테이션을 .NET에서 Word 문서로 변환
linktitle: PowerPoint에서 Word로
type: docs
weight: 110
url: /ko/net/convert-powerpoint-to-word/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint에서 Word로
- 프레젠테이션을 Word로
- 슬라이드를 Word로
- PPT를 Word로
- PPTX를 Word로
- PowerPoint에서 DOCX로
- 프레젠테이션을 DOCX로
- 슬라이드를 DOCX로
- PPT를 DOCX로
- PPTX를 DOCX로
- PowerPoint에서 DOC로
- 프레젠테이션을 DOC로
- 슬라이드를 DOC로
- PPT를 DOC로
- PPTX를 DOC로
- PPT를 DOCX로 저장
- PPTX를 DOCX로 저장
- PPT를 DOCX로 내보내기
- PPTX를 DOCX로 내보내기
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 C#에서 PowerPoint PPT 및 PPTX 슬라이드를 편집 가능한 Word 문서로 변환하며 정확한 레이아웃, 이미지 및 서식을 보존합니다."
---
## **개요**

이 문서는 개발자를 위해 Aspose.Slides for .NET 및 Aspose.Words for .NET을 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하는 솔루션을 제공합니다. 단계별 가이드를 통해 변환 과정의 모든 단계를 안내합니다.

## **프레젠테이션을 Word 문서로 변환**

아래 지침을 따라 PowerPoint 또는 OpenDocument 프레젠테이션을 Word 문서로 변환합니다:

1. 프레젠테이션 파일을 로드하기 위해 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스를 인스턴스화합니다.
2. Word 문서를 생성하기 위해 [Document](https://reference.aspose.com/words/net/aspose.words/document/) 및 [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) 클래스를 인스턴스화합니다.
3. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) 속성을 사용하여 Word 문서의 페이지 크기를 프레젠테이션과 일치하도록 설정합니다.
4. [DocumentBuilder.PageSetup](https://reference.aspose.com/words/net/aspose.words/documentbuilder/pagesetup/) 속성을 사용하여 Word 문서의 여백을 설정합니다.
5. [Presentation.Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/slides/ko/) 속성을 사용하여 모든 프레젠테이션 슬라이드를 순회합니다.
    - [ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/) 인터페이스의 `GetImage` 메서드를 사용하여 슬라이드 이미지를 생성하고 메모리 스트림에 저장합니다.
    - [DocumentBuilder](https://reference.aspose.com/words/net/aspose.words/documentbuilder/) 클래스의 `InsertImage` 메서드를 사용하여 슬라이드 이미지를 Word 문서에 추가합니다.
6. Word 문서를 파일로 저장합니다.

예를 들어, 다음과 같은 프레젠테이션 **sample.pptx**가 있다고 가정해 보겠습니다:

![PowerPoint 프레젠테이션](PowerPoint.png)

다음 C# 코드 예제는 PowerPoint 프레젠테이션을 Word 문서로 변환하는 방법을 보여줍니다:

```cs
// 프레젠테이션 파일을 로드합니다.
using var presentation = new Presentation("sample.pptx");

// Document 및 DocumentBuilder 객체를 생성합니다.
var document = new Document();
var builder = new DocumentBuilder(document);

// Word 문서의 페이지 크기를 설정합니다.
var slideSize = presentation.SlideSize.Size;
builder.PageSetup.PageWidth = slideSize.Width;
builder.PageSetup.PageHeight = slideSize.Height;

// Word 문서의 여백을 설정합니다.
builder.PageSetup.LeftMargin = 0;
builder.PageSetup.RightMargin = 0;
builder.PageSetup.TopMargin = 0;
builder.PageSetup.BottomMargin = 0;

const float scaleX = 2, scaleY = 2;

// 모든 프레젠테이션 슬라이드를 순회합니다.
foreach (var slide in presentation.Slides)
{
    // 슬라이드 이미지를 생성하고 메모리 스트림에 저장합니다.
    using var image = slide.GetImage(scaleX, scaleY);
    using var imageStream = new MemoryStream();
    image.Save(imageStream, ImageFormat.Png);

    // 슬라이드 이미지를 Word 문서에 추가합니다.
    imageStream.Seek(0, SeekOrigin.Begin);
    builder.InsertImage(imageStream.ToArray(), builder.PageSetup.PageWidth, builder.PageSetup.PageHeight);

    builder.InsertBreak(BreakType.PageBreak);
}

// Word 문서를 파일에 저장합니다.
document.Save("output.docx");
```

결과:

![Word 문서](Word.png)

{{% alert color="primary" %}} 

PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하여 얻을 수 있는 이점을 확인하려면 **온라인 PPT to Word 변환기**[**Online PPT to Word Converter**](https://products.aspose.app/slides/ko/conversion/ppt-to-word)를 사용해 보세요. 

{{% /alert %}}

## **자주 묻는 질문**

**PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하려면 어떤 구성 요소를 설치해야 합니까?**

C# 프로젝트에 [Aspose.Slides for .NET](https://www.nuget.org/packages/Aspose.Slides.NET) 및 [Aspose.Words for .NET](https://www.nuget.org/packages/Aspose.Words/)에 해당하는 NuGet 패키지만 추가하면 됩니다. 두 라이브러리는 독립 실행형 API로 동작하며 Microsoft Office를 설치할 필요가 없습니다.

**모든 PowerPoint 및 OpenDocument 프레젠테이션 형식이 지원됩니까?**

Aspose.Slides for .NET은 PPT, PPTX, ODP 및 기타 일반 파일 형식을 포함한 모든 프레젠테이션 형식을 [지원합니다](/slides/ko/net/supported-file-formats/). 이를 통해 다양한 Microsoft PowerPoint 버전에서 만든 프레젠테이션을 작업할 수 있습니다.