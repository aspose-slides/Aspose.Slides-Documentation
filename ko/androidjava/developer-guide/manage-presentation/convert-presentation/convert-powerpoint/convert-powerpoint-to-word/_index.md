---
title: Android에서 PowerPoint 프레젠테이션을 Word 문서로 변환하기
linktitle: PowerPoint에서 Word로
type: docs
weight: 110
url: /ko/androidjava/convert-powerpoint-to-word/
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
- Android
- Java
- Aspose.Slides
description: Aspose.Slides for Android를 사용하여 Java에서 PowerPoint PPT 및 PPTX 슬라이드를 정확한 레이아웃, 이미지 및 서식이 유지된 편집 가능한 Word 문서로 변환합니다.
---
## **개요**

이 문서는 개발자를 위해 Aspose.Slides와 Aspose.Words를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하는 솔루션을 제공합니다. 단계별 가이드는 변환 과정의 모든 단계를 안내합니다.

## **Aspose.Slides와 Aspose.Words**

PowerPoint 파일(PPTX 또는 PPT)을 Word(DOCX 또는 DOCX)로 변환하려면 [Aspose.Slides for Android via Java](https://products.aspose.com/slides/ko/androidjava/)와 [Aspose.Words for Android via Java](https://products.aspose.com/words/android-java/) 두 가지 모두가 필요합니다.

독립형 API인 [Aspose.Slides](https://products.aspose.app/slides) for java는 프레젠테이션에서 텍스트를 추출할 수 있는 기능을 제공합니다.

[Aspose.Words](https://docs.aspose.com/words/androidjava/)는 Microsoft Word를 사용하지 않고도 응용 프로그램이 파일을 생성, 수정, 변환, 렌더링, 인쇄하고 문서와 관련된 기타 작업을 수행할 수 있게 하는 고급 문서 처리 API입니다.

## **PowerPoint를 Word로 변환**

1. 다음 링크에서 [Aspose.Slides for Android via Java](https://downloads.aspose.com/slides/ko/java) 및 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 라이브러리를 다운로드합니다.
2. *aspose-slides-x.x-jdk16.jar*와 *aspose-words-x.x-jdk16.jar*를 CLASSPATH에 추가합니다.
3. 다음 코드 스니펫을 사용하여 PowerPoint를 Word로 변환합니다:

```java
Presentation pres = new Presentation("sample.pptx");

Document doc = new Document();
DocumentBuilder builder = new DocumentBuilder(doc);

for (ISlide slide : pres.getSlides()) {
    // 슬라이드 이미지를 바이트 배열 스트림으로 생성합니다
    IImage image = slide.getImage(1, 1);
    ByteArrayOutputStream imageStream = new ByteArrayOutputStream();
    image.save(imageStream, ImageFormat.Png);
    image.dispose();

    builder.insertImage(imageStream.toByteArray());

    // 슬라이드의 텍스트를 삽입합니다
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof AutoShape) {
            builder.writeln(((AutoShape) shape).getTextFrame().getText());
        }
    }

    builder.insertBreak(BreakType.PAGE_BREAK);
}

doc.save("output.docx");
pres.dispose();
```

## **FAQ**

**PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하려면 어떤 구성 요소를 설치해야 합니까?**

프로젝트에 [Aspose.Slides for Android via Java](https://releases.aspose.com/slides/ko/androidjava/)와 [Aspose.Words for Android via Java](https://releases.aspose.com/words/androidjava/) 해당 패키지만 추가하면 됩니다. 두 라이브러리는 독립형 API로 동작하며 Microsoft Office를 설치할 필요가 없습니다.

**모든 PowerPoint 및 OpenDocument 프레젠테이션 형식을 지원합니까?**

Aspose.Slides는 PPT, PPTX, ODP 및 기타 일반 파일 유형을 포함한 모든 프레젠테이션 형식을 [지원합니다](/slides/ko/androidjava/supported-file-formats/). 이를 통해 다양한 버전의 Microsoft PowerPoint로 만든 프레젠테이션을 작업할 수 있습니다.