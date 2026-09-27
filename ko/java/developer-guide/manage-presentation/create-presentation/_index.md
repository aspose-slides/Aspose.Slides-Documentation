---
title: Java에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/java/create-presentation/
keywords:
- 프레젠테이션 만들기
- 새 프레젠테이션
- PPT 만들기
- 새 PPT
- PPTX 만들기
- 새 PPTX
- ODP 만들기
- 새 ODP
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 프레젠테이션을 만들고—PPT, PPTX 및 ODP 파일을 생성하며, OpenDocument 지원을 활용하고, 프로그래밍 방식으로 저장하여 신뢰할 수 있는 결과를 얻으세요."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 만드는 방법, 첫 번째 슬라이드에 텍스트가 포함된 도형을 추가하는 방법, 그리고 결과를 PPTX 파일로 저장하는 방법을 보여줍니다. 기존 프레젠테이션을 열고 다른 형식으로 저장하려면 [프레젠테이션 열기](/slides/ko/java/open-presentation/) 및 [프레젠테이션 저장](/slides/ko/java/save-presentation/)를 참조하십시오. 마지막 FAQ에서는 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원에 대한 일반적인 질문을 다룹니다.

시작하기 전에 Aspose의 Maven 저장소에서 Aspose.Slides for Java를 프로젝트에 추가하십시오. Maven 설정 및 Linux에 필요한 추가 사항은 [설치](/slides/ko/java/installation/)을 참조하십시오.

## **프레젠테이션 만들기**

Aspose.Slides for Java에서 처음부터 PowerPoint 파일을 만들려면 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스로 시작합니다. 생성자는 단일 슬라이드가 포함된 빈 프레젠테이션을 제공하며, 도형, 텍스트, 차트 또는 애플리케이션이 필요로 하는 모든 콘텐츠를 추가할 준비가 되어 있습니다. 해당 슬라이드를 수정하거나 새 슬라이드를 추가한 후에는 결과를 PPTX, 기존 PPT 또는 OpenDocument 형식으로 저장할 수 있습니다.

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트가 포함된 도형을 추가하려면 다음 단계에 따라 진행하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다. 새 프레젠테이션에는 이미 빈 슬라이드가 하나 포함되어 있습니다.
2. 해당 슬라이드를 인덱스 0으로, [getSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSlides--)가 반환하는 컬렉션에서 가져옵니다.
3. `Cloud` 유형의 [IAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iautoshape/)을 [addAutoShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 메서드로 추가하고, [setText](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextframe/#setText-java.lang.String-)으로 텍스트를 설정합니다.
4. [save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용해 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제는 전체 프로그램입니다. [설치](/slides/ko/java/installation/)에서 Maven 프로젝트에 *src/main/java/HelloSlides.java* 파일로 저장하고 `mvn compile exec:java`를 실행하십시오.

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // 프레젠테이션을 생성합니다. 이미 빈 슬라이드가 하나 포함되어 있습니다.
        Presentation presentation = new Presentation();
        try {
            // 첫 번째 슬라이드를 가져옵니다.
            ISlide slide = presentation.getSlides().get_Item(0);

            // 클라우드 모양을 추가하고 텍스트를 넣습니다.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // 프레젠테이션을 PPTX 파일로 저장합니다.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

클라우드의 좌상단 모서는 슬라이드의 왼쪽 가장자리에서 20포인트, 위쪽 가장자리에서 20포인트 떨어져 있으며, 도형은 가로 200포인트, 세로 80포인트입니다. 프로그램은 클라우드와 텍스트가 포함된 하나의 슬라이드를 *new_presentation.pptx*에 저장합니다. 라이선스가 없을 경우 Aspose.Slides는 저장되는 모든 슬라이드에 평가 워터마크를 추가합니다; 자세한 내용은 [라이선스](/slides/ko/java/licensing/)을 참고하십시오.

결과:

![새 프레젠테이션](new_presentation.png)

## **자주 묻는 질문**

### 새 프레젠테이션을 어느 형식으로 저장할 수 있나요?

다음으로 저장할 수 있습니다: [PPTX, PPT, 및 ODP](/slides/ko/java/save-presentation/), 그리고 [PDF](/slides/ko/java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/java/convert-powerpoint-to-xps/), [HTML](/slides/ko/java/convert-powerpoint-to-html/), [SVG](/slides/ko/java/render-a-slide-as-an-svg-image/), [이미지](/slides/ko/java/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

### 템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?

예. 템플릿을 로드한 후 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 및 유사한 형식은 [지원됩니다](/slides/ko/java/supported-file-formats/).

### 프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?

슬라이드 크기([슬라이드 크기](/slides/ko/java/slide-size/))를 설정하고(4:3 및 16:9와 같은 프리셋 또는 사용자 정의 크기 포함) 콘텐츠가 어떻게 스케일될지 선택합니다.

### 크기와 좌표는 어떤 단위로 측정되나요?

포인트 단위이며, 1인치는 72포인트에 해당합니다.

### 메모리 사용량을 줄이기 위해 매우 큰 프레젠테이션(많은 미디어 파일 포함)을 어떻게 처리하나요?

BLOB 관리 전략([BLOB 관리 전략](/slides/ko/java/manage-blob/))을 사용하고, 임시 파일을 활용해 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

### 프레젠테이션을 병렬로 만들거나 저장할 수 있나요?

동일한 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 [다중 스레드](/slides/ko/java/multithreading/)에서 동시에 사용할 수 없습니다. 스레드나 프로세스당 별도의 독립 인스턴스를 실행하십시오.

### 평가 워터마크와 제한을 어떻게 제거하나요?

[라이선스 적용](/slides/ko/java/licensing/)을 프로세스당 한 번 수행합니다. 라이선스 XML은 수정되지 않아야 하며, 여러 스레드가 관여할 경우 라이선스 설정을 동기화해야 합니다.

### 만든 PPTX에 디지털 서명을 할 수 있나요?

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/java/digital-signature-in-powerpoint/) (추가 및 검증)이 지원됩니다.

### 생성된 프레젠테이션에서 매크로(VBA)가 지원되나요?

예. [VBA 프로젝트 만들기/편집](/slides/ko/java/presentation-via-vba/)을 수행하고 PPTM/PPSM과 같은 매크로 사용 파일을 저장할 수 있습니다.