---
title: PHP에서 PowerPoint 프레젠테이션을 SWF Flash로 변환
linktitle: PowerPoint에서 SWF로
type: docs
weight: 80
url: /ko/php-java/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint에서 SWF로
- 프레젠테이션을 SWF로
- 슬라이드를 SWF로
- PPT를 SWF로
- PPTX를 SWF로
- PowerPoint에서 Flash로
- 프레젠테이션을 Flash로
- 슬라이드를 Flash로
- PPT를 Flash로
- PPTX를 Flash로
- PPT를 SWF로 저장
- PPTX를 SWF로 저장
- PPT를 SWF로 내보내기
- PPTX를 SWF로 내보내기
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides를 사용하여 PHP에서 PowerPoint(PPT/PPTX)를 SWF Flash로 변환합니다. 단계별 코드 샘플, 빠른 품질 출력, PowerPoint 자동화 없이."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 SWF로 변환하는 방법을 설명합니다. 프레젠테이션을 [Presentation::save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/save/) 메서드로 SWF 파일로 저장하고, [SwfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/) 를 사용하여 내보내기를 구성하는 방법(뷰어 설정 및 노트 또는 댓글 레이아웃 포함)을 보여줍니다.

## **프레젠테이션을 Flash로 변환**

[Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스가 제공하는 [save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/save/) 메서드를 사용하면 전체 프레젠테이션을 **SWF** 문서로 변환할 수 있습니다. 다음 예제는 [SWFOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/) 클래스에서 제공하는 옵션을 사용하여 프레젠테이션을 **SWF** 문서로 변환하는 방법을 보여줍니다. 또한 [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/notescommentslayoutingoptions/) 클래스를 사용하여 생성된 SWF에 댓글을 포함시킬 수 있습니다.

```php
  $pres = new Presentation("Sample.pptx");
  try {
    $swfOptions = new SwfOptions();
    $swfOptions->setViewerIncluded(false);
    $swfOptions->getNotesCommentsLayouting()->setNotesPosition(NotesPositions::BottomFull);
    # 프레젠테이션 저장
    $pres->save("Sample.swf", SaveFormat::Swf, $swfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**숨겨진 슬라이드를 SWF에 포함시킬 수 있나요?**

예. [SwfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/) 에서 [setShowHiddenSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/setshowhiddenslides/) 메서드를 사용하여 숨겨진 슬라이드를 활성화합니다. 기본적으로 숨겨진 슬라이드는 내보내지 않습니다.

**압축 및 최종 SWF 파일 크기를 어떻게 제어할 수 있나요?**

[setCompressed](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/setcompressed/) 메서드와 [adjust JPEG quality](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/setjpegquality/) 를 사용하여 파일 크기와 이미지 품질 사이의 균형을 맞출 수 있습니다.

**'setViewerIncluded'는 무엇이며, 언제 비활성화해야 하나요?**

[setViewerIncluded](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/setviewerincluded/) 은 내장 플레이어 UI(네비게이션 컨트롤, 패널, 검색)를 추가합니다. 자체 플레이어를 사용하거나 UI 없이 순수한 SWF 프레임이 필요할 경우 비활성화하십시오.

**내보내기 환경에 소스 폰트가 없으면 어떻게 되나요?**

Aspose.Slides는 [SwfOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/swfoptions/) 에서 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) 로 지정한 폰트를 대신 사용하여 의도하지 않은 폰트 대체를 방지합니다.