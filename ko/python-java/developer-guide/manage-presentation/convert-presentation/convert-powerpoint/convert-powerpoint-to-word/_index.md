---
title: Python을 통한 Java에서 PowerPoint 프레젠테이션을 Word 문서로 변환
linktitle: PowerPoint를 Word로
type: docs
weight: 110
url: /ko/python-java/convert-powerpoint-to-word/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PowerPoint를 Word로
- 프레젠테이션을 Word로
- PPT를 Word로
- PPTX를 Word로
- ODP를 Word로
- PowerPoint를 DOCX로
- PPT를 DOCX로
- PPTX를 DOCX로
- PowerPoint를 DOC로
- PPT를 DOCX로 저장
- PPTX를 DOCX로 저장
- PPT를 DOCX로 내보내기
- PPTX를 DOCX로 내보내기
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides와 Aspose.Words를 사용하여 Python을 통한 Java에서 PowerPoint 및 OpenDocument 프레젠테이션을 Word로 변환하고, 슬라이드 이미지를 편집 가능한 텍스트와 결합합니다."
---
## **개요**

이 문서는 Aspose.Slides for Python via Java와 Aspose.Words for Java를 함께 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 Word 문서로 변환하는 방법을 설명합니다. Aspose.Slides는 각 슬라이드를 렌더링하고 텍스트를 읽으며, Aspose.Words는 JPype을 통해 Word 문서를 생성합니다. Microsoft Office는 필요하지 않습니다.

결과 문서는 슬라이드 이미지를 포함하고, 그 아래에 해당 슬라이드의 최상위 자동 도형에서 추출한 편집 가능한 텍스트가 들어갑니다. 이미지는 슬라이드의 시각적 모습을 유지하지만, 개별 도형, 차트, 표는 편집 가능한 Word 개체로 변환되지 않습니다. 추출된 텍스트는 원본 텍스트 서식이나 위치를 유지하지 않습니다.

## **PowerPoint를 Word로 변환**

1. [Aspose.Slides for Python via Java](/slides/ko/python-java/installation/)와 호환되는 Java 런타임을 설치합니다.
2. [Aspose.Words for Java](https://releases.aspose.com/words/java/)를 다운로드합니다. 메인 JAR 파일을 스크립트 옆의 `lib` 디렉터리에 두고 `aspose-words.jar`로 이름을 바꾸거나 예제의 경로를 다운로드한 파일에 맞게 조정합니다.
3. 입력 프레젠테이션 `sample.pptx`를 작업 디렉터리에 배치합니다. `lib/aspose-words.jar` 경로도 해당 디렉터리를 기준으로 상대 경로입니다.
4. 다음 Python 코드를 실행하여 `output.docx`를 생성합니다.

예제는 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)으로 소스를 로드하고 [Slide.getImage](https://reference.aspose.com/slides/ko/python-java/aspose.slides/slide/#getImage)로 슬라이드를 렌더링합니다. Aspose.Words의 [DocumentBuilder](https://reference.aspose.com/words/java/com.aspose.words/documentbuilder/)를 사용하여 이미지와 텍스트를 Word 문서에 삽입합니다.

```python
from pathlib import Path

import jpype
import asposeslides

words_jar = Path("lib/aspose-words.jar").resolve()
jpype.addClassPath(str(words_jar))
if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, ImageFormat, Presentation

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")
Document = jpype.JClass("com.aspose.words.Document")
DocumentBuilder = jpype.JClass("com.aspose.words.DocumentBuilder")
BreakType = jpype.JClass("com.aspose.words.BreakType")

presentation = Presentation("sample.pptx")
try:
    document = Document()
    builder = DocumentBuilder(document)
    page_setup = builder.getPageSetup()
    content_width = page_setup.getPageWidth() - page_setup.getLeftMargin() - page_setup.getRightMargin()
    slide_size = presentation.getSlideSize().getSize()
    image_height = content_width * slide_size.getHeight() / slide_size.getWidth()
    slide_count = presentation.getSlides().size()

    for slide_index in range(slide_count):
        if slide_index > 0:
            builder.insertBreak(BreakType.PAGE_BREAK)

        slide = presentation.getSlides().get_Item(slide_index)
        image = slide.getImage(1.0, 1.0)
        try:
            image_stream = ByteArrayOutputStream()
            try:
                image.save(image_stream, ImageFormat.Png)
                image_bytes = image_stream.toByteArray()
            finally:
                image_stream.close()
        finally:
            image.dispose()

        # 슬라이드 이미지를 텍스트 영역 너비에 맞추고, 종횡비를 유지합니다.
        builder.insertImage(image_bytes, content_width, image_height)
        builder.writeln()

        # 텍스트 상자를 포함한 최상위 자동 도형에서 일반 텍스트를 추가합니다.
        for shape in slide.getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None:
                    text = str(text_frame.getText())
                    if text.strip():
                        builder.writeln(text)

    document.save("output.docx")
finally:
    presentation.dispose()
```

각 슬라이드는 새 페이지에서 시작합니다. 추출된 텍스트가 길거나 슬라이드 이미지가 비정상적으로 높을 경우 추가 페이지가 필요할 수 있습니다. 코드는 슬라이드 사이에만 페이지 나누기를 추가하고 `finally` 블록에서 프레젠테이션과 렌더링된 이미지를 해제합니다. JVM은 동일한 Python 프로세스 내에서 이후 변환에도 계속 사용할 수 있습니다.

## **FAQ**

**필요한 라이브러리는 무엇인가요?**

Aspose.Slides for Python via Java, JPype, 호환 가능한 Java 런타임, 그리고 Aspose.Words for Java를 사용합니다. 두 Aspose 라이브러리는 동일한 JVM에서 실행됩니다. Aspose.Slides가 프레젠테이션을 처리하고, Aspose.Words가 Word 문서를 작성합니다.

**PPT 및 ODP 파일도 PPTX와 같이 변환할 수 있나요?**

예. `sample.pptx`를 PPT 또는 ODP 파일로 교체하면 됩니다. 프레젠테이션 입력 형식에 대해서는 [Supported File Formats](/slides/ko/python-java/supported-file-formats/)를 참고하세요.

**슬라이드 내용이 모두 Word에서 편집 가능하나요?**

아니요. 각 슬라이드는 정적 이미지로 삽입되고, 최상위 자동 도형의 일반 텍스트만 아래에 추가됩니다. 그룹 내부, 표, SmartArt, 차트 및 발표자 메모에 있는 텍스트는 이 예제에서 추출되지 않습니다. 애니메이션과 전환 효과도 Word 문서에 재현되지 않습니다.

**DOC 대신 DOCX가 아닌 DOC 형식으로 저장할 수 있나요?**

예. 출력 파일 이름을 `output.doc`으로 변경하면 됩니다. Aspose.Words는 저장 오버로드를 사용할 때 파일 확장자를 기준으로 출력 형식을 선택합니다.