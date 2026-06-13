---
title: PHP에서 PowerPoint 프레젠테이션을 Markdown으로 변환
linktitle: PowerPoint를 Markdown으로
type: docs
weight: 140
url: /ko/php-java/convert-powerpoint-to-markdown/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 MD로
- 프레젠테이션을 MD로
- 슬라이드를 MD로
- PPT를 MD로
- PPTX를 MD로
- PowerPoint를 Markdown으로 저장
- 프레젠테이션을 Markdown으로 저장
- 슬라이드를 Markdown으로 저장
- PPT를 MD로 저장
- PPTX를 MD로 저장
- PPT를 MD로 내보내기
- exportPPTX를 MD로 내보내기
- PowerPoint
- 프레젠테이션
- Markdown
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 Java를 통해 사용하여 PowerPoint 슬라이드(PPT, PPTX)를 깔끔한 Markdown으로 변환하고, 문서 자동화와 서식 유지를 가능합니다."
---
## **소개**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 Markdown으로 변환할 수 있으며, 이는 문서 워크플로, 정적 사이트 생성, 콘텐츠 마이그레이션 및 버전 관리된 텍스트 게시에 유용합니다. API는 PPT 및 PPTX 프레젠테이션을 MD 파일로 직접 내보내는 것을 지원하며, 결과 Markdown 문서에 슬라이드 내용이 어떻게 표시되는지를 제어하는 추가 옵션을 제공합니다.

프레젠테이션을 일반 Markdown으로 내보낼 수 있으며, CommonMark 및 GitHub Flavored Markdown과 같은 다양한 Markdown 변형 중에서 선택하고, 내보내기 중 이미지 처리 방식을 구성할 수 있습니다. 시각적 콘텐츠가 포함된 프레젠테이션의 경우, Aspose.Slides는 이미지를 별도 폴더에 저장하고 생성된 Markdown 파일에서 참조하도록 할 수 있습니다.

{{% alert color="warning" %}}
PowerPoint‑to‑Markdown 내보내기는 기본적으로 **이미지 없이** 진행됩니다. 이미지가 포함된 PowerPoint 문서를 내보내려면 `ExportType = MarkdownExportType::Visual`을 설정하고, Markdown 문서에서 참조되는 이미지가 저장될 `BasePath`를 지정해야 합니다.
{{% /alert %}}

## **프레젠테이션을 Markdown으로 변환**

이 섹션에서는 Aspose.Slides가 PowerPoint 및 OpenDocument 프레젠테이션(PPT, PPTX, ODP)을 깨끗한 Markdown으로 변환하는 방법을 설명합니다. 원래 슬라이드 계층 구조, 텍스트 및 핵심 형식을 유지하여 문서화 또는 버전 관리 워크플로에서 추가 수작업 없이 콘텐츠를 재사용할 수 있습니다.

1. 프레젠테이션을 나타내기 위해 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
1. [save](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/#save) 메서드를 사용하여 Markdown 파일로 내보냅니다.

다음 PHP 코드는 PowerPoint 프레젠테이션을 Markdown으로 변환하는 방법을 보여줍니다:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.md", SaveFormat::Md);
} finally {
    $presentation->dispose();
}
```

## **프레젠테이션을 Markdown 변형으로 변환**

Aspose.Slides를 사용하면 PowerPoint 프레젠테이션을 기본 구문을 사용한 Markdown으로 변환할 수 있을 뿐만 아니라 CommonMark, GitHub‑flavored Markdown, Trello, XWiki, GitLab 및 기타 17가지 Markdown 변형으로 변환할 수 있습니다.

다음 PHP 코드는 PowerPoint 프레젠테이션을 CommonMark로 변환하는 방법을 보여줍니다:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setFlavor(Flavor->CommonMark);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

지원되는 23가지 Markdown 변형은 [Flavor enumeration](https://reference.aspose.com/slides/ko/php-java/aspose.slides/flavor/)에 나열되어 있습니다.

## **이미지가 포함된 프레젠테이션을 Markdown으로 변환**

[MarkdownSaveOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownsaveoptions/) 클래스는 결과 Markdown 파일을 구성할 수 있는 속성과 열거형을 제공합니다. 예를 들어, [MarkdownExportType](https://reference.aspose.com/slides/ko/php-java/aspose.slides/markdownexporttype/) 열거형은 이미지 처리 방식을 `Sequential`, `TextOnly` 또는 `Visual` 중 하나로 지정합니다.

{{% alert color="warning" %}}
기본적으로 PowerPoint‑to‑Markdown 내보내기에는 **이미지가 포함되지 않습니다**. 이미지를 삽입하려면 `markdownSaveOptions.setExportType(MarkdownExportType::Visual)`을 호출하고, Markdown 파일에서 참조되는 이미지가 저장될 `BasePath`를 지정합니다.
{{% /alert %}}

### **이미지 순차 변환**

결과 Markdown에서 이미지가 각각 순차적으로 나타나길 원한다면 `Sequential` 옵션을 선택해야 합니다. 다음 PHP 코드는 이미지가 포함된 프레젠테이션을 Markdown으로 변환하는 방법을 보여줍니다:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setShowHiddenSlides(true);
    $saveOptions->setShowSlideNumber(true);
    $saveOptions->setFlavor(Flavor->Github);
    $saveOptions->setExportType(MarkdownExportType::Sequential);
    $saveOptions->setNewLineType(NewLineType::Windows);

    $slideIndices = array(1, 2, 3, 4);
    $presentation->save("presentation.md", $slideIndices, SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

### **이미지 시각적 변환**

결과 Markdown에 이미지가 함께 표시되길 원한다면 `Visual` 옵션을 선택해야 합니다. 이 경우, 이미지는 애플리케이션 현재 디렉터리에 저장되며 (Markdown 문서에 상대 경로가 생성됩니다), 또는 원하는 디렉터리와 폴더 이름을 지정할 수 있습니다.

다음 PHP 코드는 해당 작업을 보여줍니다:
```php
$presentation = new Presentation("presentation.pptx");
try {
    $outPath = "c:/documents";

    $saveOptions = new MarkdownSaveOptions();
    $saveOptions->setExportType(MarkdownExportType::Visual);
    $saveOptions->setImagesSaveFolderName("md-images");
    $saveOptions->setBasePath($outPath);

    $presentation->save("presentation.md", SaveFormat::Md, $saveOptions);
} finally {
    $presentation->dispose();
}
```

## **자주 묻는 질문**

**하이퍼링크가 Markdown으로 내보낼 때 유지되나요?**

예. 텍스트 [hyperlinks](/slides/ko/php-java/manage-hyperlinks/)는 표준 Markdown 링크로 보존됩니다. 슬라이드 [transitions](/slides/ko/php-java/slide-transition/) 및 [animations](/slides/ko/php-java/powerpoint-animation/)는 변환되지 않습니다.

**다중 스레드로 실행하여 변환 속도를 높일 수 있나요?**

파일별로 병렬 처리를 할 수 있지만, 스레드 간에 동일한 [Presentation](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/) 인스턴스를 [don’t share](/slides/ko/php-java/multithreading/)하지 않아야 합니다. 파일당 별도의 인스턴스/프로세스를 사용하여 경쟁을 방지하십시오.

**이미지는 어떻게 처리되나요—어디에 저장되며 경로는 상대 경로인가요?**

[Images](/slides/ko/php-java/image/)는 전용 폴더에 내보내지며, 기본적으로 Markdown 파일은 상대 경로로 이미지를 참조합니다. 기본 출력 경로 및 자산 폴더 이름을 구성하여 예측 가능한 저장소 구조를 유지할 수 있습니다.