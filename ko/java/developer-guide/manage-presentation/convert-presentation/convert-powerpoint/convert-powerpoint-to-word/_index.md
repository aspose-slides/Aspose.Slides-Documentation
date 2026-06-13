---
title: Java에서 PowerPoint 프레젠테이션을 Word 문서로 변환
linktitle: PowerPoint를 Word로
type: docs
weight: 110
url: /ko/java/convert-powerpoint-to-word/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 Word로
- 프레젠테이션을 Word로
- 슬라이드를 Word로
- PPT를 Word로
- PPTX를 Word로
- PowerPoint를 DOCX로
- 프레젠테이션을 DOCX로
- 슬라이드를 DOCX로
- PPT를 DOCX로
- PPTX를 DOCX로
- PowerPoint를 DOC로
- 프레젠테이션을 DOC로
- 슬라이드를 DOC로
- PPT를 DOC로
- PPTX를 DOC로
- PPT를 DOCX로 저장
- PPTX를 DOCX로 저장
- PPT를 DOCX로 내보내기
- PPTX를 DOCX로 내보내기
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint PPT 및 PPTX 슬라이드를 편집 가능한 Word 문서로 변환하며 레이아웃, 이미지 및 서식이 정확히 보존됩니다."
---
## **개요**

이 문서에서는 Aspose.Slides와 Aspose.Words를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하는 솔루션을 제공합니다. 단계별 가이드를 통해 변환 과정의 모든 단계를 안내합니다.

## **PowerPoint를 Word로 변환**

아래 지침에 따라 PowerPoint 또는 OpenDocument 프레젠테이션을 Word 문서로 변환하십시오:

1. [Aspose.Slides for Java](https://downloads.aspose.com/slides/ko/java) 및 [Aspose.Words for Java](https://downloads.aspose.com/words/java) 라이브러리를 다운로드합니다.
2. *aspose-slides-x.x-jdk16.jar* 및 *aspose-words-x.x-jdk16.jar* 를 CLASSPATH에 추가합니다.
3. 이 코드 스니펫을 사용하여 PowerPoint를 Word로 변환합니다:

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

프로젝트에 [Aspose.Slides for Java](https://releases.aspose.com/slides/ko/java/) 및 [Aspose.Words for Java](https://releases.aspose.com/words/java/) 패키지를 추가하기만 하면 됩니다. 두 라이브러리는 독립형 API로 동작하며 Microsoft Office를 설치할 필요가 없습니다.

**모든 PowerPoint 및 OpenDocument 프레젠테이션 형식을 지원합니까?**

Aspose.Slides는 [모든 프레젠테이션 형식을 지원](/slides/ko/java/supported-file-formats/)하며, PPT, PPTX, ODP 및 기타 일반 파일 형식을 포함합니다. 이를 통해 다양한 버전의 Microsoft PowerPoint로 만든 프레젠테이션을 작업할 수 있습니다.