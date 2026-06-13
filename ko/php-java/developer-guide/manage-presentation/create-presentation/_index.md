---
title: PHP에서 프레젠테이션 만들기
linktitle: 프레젠테이션 만들기
type: docs
weight: 10
url: /ko/php-java/create-presentation/
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
- PHP
- Aspose.Slides
description: "Java를 통해 PHP용 Aspose.Slides로 프레젠테이션을 만들고 — PPT, PPTX 및 ODP 파일을 생성하여 프로그래밍 방식으로 저장함으로써 신뢰할 수 있는 결과를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides에서 프레젠테이션을 생성하고, 슬라이드에 간단한 내용을 추가한 다음 파일로 저장하는 방법을 보여줍니다. 또한 새 프레젠테이션을 만들고 저장하는 방법, 지원되는 형식의 기존 프레젠테이션을 열고 다른 형식으로 저장하는 방법을 시연합니다. 추가로, 형식, 템플릿, 슬라이드 크기, 단위, 메모리 사용량, 스레딩, 라이선스, 디지털 서명 및 VBA 지원과 관련된 일반적인 질문을 다루는 짧은 FAQ가 포함되어 있습니다.

## **프레젠테이션 만들기**

프레젠테이션의 선택한 슬라이드에 간단한 직선을 추가하려면 아래 단계를 따르세요:

1. Presentation 클래스를 인스턴스화합니다.
1. 슬라이드의 인덱스를 사용하여 해당 슬라이드의 참조를 가져옵니다.
1. Shapes 객체가 제공하는 addAutoShape 메서드를 사용하여 Line 유형의 AutoShape을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 슬라이드에 직선을 추가했습니다.

```php
  # 프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
  $pres = new Presentation();
  try {
    # 첫 번째 슬라이드를 가져옵니다
    $slide = $pres->getSlides()->get_Item(0);
    # 라인 유형의 자동 도형을 추가합니다
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**새 프레젠테이션을 어떤 형식으로 저장할 수 있나요?**

다음 링크를 통해 [PPTX, PPT 및 ODP](/slides/ko/php-java/save-presentation/) 형식으로 저장할 수 있으며, [PDF](/slides/ko/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/ko/php-java/convert-powerpoint-to-xps/), [HTML](/slides/ko/php-java/convert-powerpoint-to-html/), [SVG](/slides/ko/php-java/convert-powerpoint-to-png/), 그리고 [이미지](/slides/ko/php-java/convert-powerpoint-to-png/) 등으로 내보낼 수 있습니다.

**템플릿(POTX/POTM)에서 시작하여 일반 PPTX로 저장할 수 있나요?**

예. 템플릿을 로드한 뒤 원하는 형식으로 저장하면 됩니다; POTX/POTM/PPTM 및 유사한 형식은 [지원됩니다](/slides/ko/php-java/supported-file-formats/).

**프레젠테이션을 만들 때 슬라이드 크기/종횡비를 어떻게 제어하나요?**

[슬라이드 크기](/slides/ko/php-java/slide-size/)를 설정하고(예: 4:3, 16:9와 같은 프리셋 또는 사용자 정의 크기), 콘텐츠가 어떻게 스케일링될지 선택합니다.

**크기와 좌표는 어떤 단위로 측정되나요?**

포인트 단위이며, 1인치는 72포인트에 해당합니다.

**많은 미디어 파일을 포함한 대용량 프레젠테이션의 메모리 사용량을 줄이려면 어떻게 해야 하나요?**

[BLOB 관리 전략](/slides/ko/php-java/manage-blob/)을 사용하고, 임시 파일을 활용하여 메모리 내 저장을 제한하며, 순수 메모리 스트림보다 파일 기반 작업 흐름을 선호합니다.

**프레젠테이션을 병렬로 생성/저장할 수 있나요?**

동일한 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/php-java/multithreading/)에서 동시에 사용할 수 없습니다. 스레드 또는 프로세스당 별도의 독립 인스턴스를 실행하십시오.

**평가판 워터마크 및 제한을 제거하려면 어떻게 해야 하나요?**

프로세스당 한 번 [라이선스를 적용](/slides/ko/php-java/licensing/)하십시오. 라이선스 XML은 수정되지 않아야 하며, 다중 스레드가 사용될 경우 라이선스 설정을 동기화해야 합니다.

**생성한 PPTX에 디지털 서명을 할 수 있나요?**

예. 프레젠테이션에 대해 [디지털 서명](/slides/ko/php-java/digital-signature-in-powerpoint/) (추가 및 검증)이 지원됩니다.

**생성된 프레젠테이션에서 매크로(VBA)가 지원되나요?**

예. [VBA 프로젝트를 생성/편집](/slides/ko/php-java/presentation-via-vba/)할 수 있으며 PPTM/PPSM과 같은 매크로 사용 파일로 저장할 수 있습니다.