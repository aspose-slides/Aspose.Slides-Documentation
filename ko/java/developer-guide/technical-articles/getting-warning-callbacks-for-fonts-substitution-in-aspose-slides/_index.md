---
title: 글꼴 대체에 대한 경고 콜백 받기
type: docs
weight: 90
url: /ko/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- 경고 콜백
- 글꼴 대체
- 렌더링 프로세스
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 글꼴 대체에 대한 경고 콜백을 받는 방법을 배우고 PowerPoint 및 OpenDocument 프레젠테이션을 정확하게 표시합니다."
---
## **소개**

Aspose.Slides for Java는 렌더링 중에 필요한 글꼴이 머신에 없을 때 글꼴 대체에 대한 경고 콜백을 받을 수 있도록 합니다. 이러한 콜백은 누락되었거나 접근할 수 없는 글꼴 문제를 진단하는 데 도움이 됩니다.

## **경고 콜백 사용**

Aspose.Slides for Java는 프레젠테이션 슬라이드를 렌더링할 때 경고 콜백을 받기 위한 간단한 API를 제공합니다. 경고 콜백을 구성하려면 다음 단계를 따르세요:

1. 경고를 처리하기 위해 [IWarningCallback](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iwarningcallback/) 인터페이스를 구현하는 사용자 지정 콜백 클래스를 만듭니다.
1. [RenderingOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/htmloptions/) 등 옵션 클래스를 사용하여 경고 콜백을 설정합니다.
1. 대상 머신에 없는 글꼴을 사용하는 프레젠테이션을 로드합니다.
1. 슬라이드 썸네일을 생성하거나 프레젠테이션을 내보내어 효과를 확인합니다.

**사용자 지정 경고 콜백 클래스:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// 예시 출력:
//
// 글꼴이 XYZ에서 {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}} 로 대체됩니다.
```

**슬라이드 썸네일 생성:**

```java
// 슬라이드 렌더링 중 글꼴 관련 경고를 처리하기 위한 경고 콜백을 설정합니다.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 프레젠테이션의 각 슬라이드에 대한 썸네일 이미지를 생성합니다.
    for (ISlide slide : presentation.getSlides()) {
        // 지정된 렌더링 옵션을 사용하여 슬라이드 썸네일 이미지를 가져옵니다.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**PDF 형식으로 내보내기:**

```java
// PDF 내보내기 중 글꼴 관련 경고를 처리하기 위한 경고 콜백을 설정합니다.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 프레젠테이션을 PDF로 내보냅니다.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**HTML 형식으로 내보내기:**

```java
// HTML 내보내기 중 글꼴 관련 경고를 처리하기 위한 경고 콜백을 설정합니다.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// 지정된 파일 경로에서 프레젠테이션을 로드합니다.
Presentation presentation = new Presentation("sample.pptx");
try {
    // 프레젠테이션을 HTML 형식으로 내보냅니다.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```