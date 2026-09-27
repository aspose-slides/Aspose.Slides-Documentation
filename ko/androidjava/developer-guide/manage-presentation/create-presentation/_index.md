---
title: Android에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/androidjava/create-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android을 사용하여 Java로 프레젠테이션을 생성합니다—PPT, PPTX 및 ODP 파일을 만들고, OpenDocument 지원을 활용하며, 프로그래밍 방식으로 저장하여 신뢰할 수 있는 결과를 제공합니다."
---
## **개요**

이 문서에서는 Java를 사용하여 Aspose.Slides for Android에서 프레젠테이션을 만들고, 첫 번째 슬라이드에 텍스트 상자를 추가한 다음 결과를 앱 저장소에 파일로 저장하는 방법을 보여줍니다. 기존 프레젠테이션을 열거나 다른 형식으로 저장하려면 [Open Presentation](/slides/ko/androidjava/open-presentation/) 및 [Save Presentation](/slides/ko/androidjava/save-presentation/)를 참조하십시오. 끝부분의 짧은 FAQ에서는 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원에 대한 일반적인 질문을 다룹니다.

시작하기 전에 Aspose의 Maven 저장소에서 Aspose.Slides를 Android 프로젝트에 추가하십시오. [Installation](/slides/ko/androidjava/install-aspose-slides-for-android-via-java/)을(를) 참조하십시오.

## **PowerPoint 프레젠테이션 만들기**

프레젠테이션을 만들고 첫 번째 슬라이드에 텍스트 상자를 넣으려면 다음 단계를 따르세요:

1. 새로운 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스를 인스턴스화합니다. 새 프레젠테이션에는 이미 빈 슬라이드가 하나 포함되어 있습니다.
1. [slide collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islidecollection/)에서 인덱스 0으로 해당 슬라이드를 가져옵니다.
1. [shape collection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/)의 [addAutoShape](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) 메서드를 사용하여 사각형을 추가하고, 해당 [text frame](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/)의 텍스트를 [setText](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-) 메서드로 설정합니다.
1. [save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) 메서드를 사용하여 프레젠테이션을 PPTX 파일로 저장하고, [SaveFormat.Pptx](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/saveformat/) 형식을 사용합니다.

코드는 `Activity` 내부, 예를 들어 `onCreate` 메서드에서 실행됩니다. 파일은 [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()) 메서드가 반환하는 디렉터리에 저장됩니다: 앱의 개인 저장소이며, 별도의 권한 요청 없이 쓸 수 있습니다.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

사각형의 좌상단 모서는 슬라이드 왼쪽 가장자리에서 50포인트, 위쪽 가장자리에서 50포인트 떨어져 있으며, 사각형의 너비는 400포인트, 높이는 100포인트입니다. 저장된 파일에는 해당 사각형과 텍스트가 포함된 슬라이드가 하나 들어 있습니다. 라이선스가 없을 경우 Aspose.Slides는 저장되는 모든 슬라이드에 평가용 워터마크를 추가합니다; 자세한 내용은 [Licensing](/slides/ko/androidjava/licensing/)를 참조하십시오.

파일을 확인하려면 Android Studio의 [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer)를 열고 앱의 *files* 폴더에 있는 *data/data/* 아래 *hello.pptx*를 찾으십시오. 실제 앱에서는 프레젠테이션을 백그라운드 스레드에서 처리하여 사용자 인터페이스가 응답성을 유지하도록 합니다.

## **FAQ**

### 새 프레젠테이션을 저장할 수 있는 형식은 무엇인가요?

새 프레젠테이션은 [PPTX, PPT, 및 ODP](/slides/ko/androidjava/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/ko/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/ko/androidjava/convert-powerpoint-to-html/), [SVG](/slides/ko/androidjava/render-a-slide-as-an-svg-image/), 그리고 [images](/slides/ko/androidjava/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

### 템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?

예. 템플릿을 로드한 뒤 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 및 유사 형식은 [지원됩니다](/slides/ko/androidjava/supported-file-formats/)。

### 프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?

[slide size](/slides/ko/androidjava/slide-size/)를 설정합니다(4:3, 16:9와 같은 프리셋 또는 사용자 지정 크기 포함) 그리고 콘텐츠가 어떻게 스케일링될지 선택합니다.

### 크기와 좌표는 어떤 단위로 측정되나요?

포인트 단위입니다: 1인치는 72포인트에 해당합니다.

### 메모리 사용량을 줄이기 위해 매우 큰 프레젠테이션(다수의 미디어 파일 포함)을 어떻게 처리하나요?

[BLOB 관리 전략](/slides/ko/androidjava/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 워크플로를 선호합니다.

### 프레젠테이션을 병렬로 만들거나 저장할 수 있나요?

동일한 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/androidjava/multithreading/)에서 동시에 작업할 수 없습니다. 스레드 또는 프로세스당 별개의 독립 인스턴스를 실행하십시오.

### 평가용 워터마크와 제한을 제거하려면 어떻게 해야 하나요?

프로세스당 한 번 [Apply a license](/slides/ko/androidjava/licensing/)를 적용합니다. 라이선스 XML은 수정하지 않아야 하며, 여러 스레드가 관여하는 경우 라이선스 설정을 동기화해야 합니다.

### 만든 PPTX에 디지털 서명을 할 수 있나요?

예. 프레젠테이션에 대해 [Digital signatures](/slides/ko/androidjava/digital-signature-in-powerpoint/) (추가 및 검증)을 지원합니다.

### 생성된 프레젠테이션에서 매크로(VBA)를 지원하나요?

예. [create/edit VBA projects](/slides/ko/androidjava/presentation-via-vba/)를 통해 VBA 프로젝트를 만들거나 편집할 수 있고, PPTM/PPSM과 같은 매크로 활성 파일을 저장할 수 있습니다.