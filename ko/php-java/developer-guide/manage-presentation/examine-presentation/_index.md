---
title: PHP에서 프레젠테이션 정보를 검색하고 업데이트하기
linktitle: 프레젠테이션 정보
type: docs
weight: 30
url: /ko/php-java/examine-presentation/
keywords:
- 프레젠테이션 형식
- 프레젠테이션 속성
- 문서 속성
- 속성 가져오기
- 속성 읽기
- 속성 변경
- 속성 수정
- 속성 업데이트
- PPTX 검사
- PPT 검사
- ODP 검사
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션의 슬라이드, 구조 및 메타데이터를 탐색하고, 빠른 인사이트와 스마트한 콘텐츠 감사를 제공합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 프레젠테이션 정보를 검사하는 방법을 보여줍니다. 전체 파일을 로드하지 않고 프레젠테이션의 현재 형식을 결정하고, 문서 속성을 읽으며, 필요할 때 해당 속성을 업데이트하는 방법을 설명합니다.

예제는 [PresentationInfo](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentationinfo/) 및 [DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/) API를 기반으로 하며 프레젠테이션 메타데이터를 작업하는 일반적인 작업을 시연합니다.

## **프레젠테이션 형식 확인**

프레젠테이션 작업을 시작하기 전에 현재 프레젠테이션이 어떤 형식(PPT, PPTX, ODP 등)인지 확인하고 싶을 수 있습니다.

프레젠테이션을 로드하지 않고도 형식을 확인할 수 있습니다. 다음 PHP 코드를 참고하세요:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  echo($info->getLoadFormat());// PPTX

  $info2 = PresentationFactory->getInstance()->getPresentationInfo("pres.ppt");
  echo($info2->getLoadFormat());// PPT

  $info3 = PresentationFactory->getInstance()->getPresentationInfo("pres.odp");
  echo($info3->getLoadFormat());// ODP


```

## **프레젠테이션 속성 가져오기**

다음 PHP 코드는 프레젠테이션 속성(프레젠테이션에 대한 정보)을 가져오는 방법을 보여줍니다:

```php
  $info = PresentationFactory->getInstance()->getPresentationInfo("pres.pptx");
  $props = $info->readDocumentProperties();
  echo($props->getCreatedTime());
  echo($props->getSubject());
  echo($props->getTitle());
  # ..
```

[DocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/documentproperties/#DocumentProperties--) 클래스 아래의 속성을 확인하고 싶을 수도 있습니다.

## **프레젠테이션 속성 업데이트**

Aspose.Slides는 프레젠테이션 속성을 변경할 수 있는 [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/ko/php-java/aspose.slides/PresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-) 메서드를 제공합니다.

예를 들어 아래와 같이 문서 속성이 표시된 PowerPoint 프레젠테이션이 있다고 가정해 보겠습니다.

![PowerPoint 프레젠테이션의 원본 문서 속성](input_properties.png)

다음 코드 예제는 일부 프레젠테이션 속성을 편집하는 방법을 보여줍니다:

```php
$fileName = "sample.pptx";

$info = PresentationFactory::getInstance()->getPresentationInfo($fileName);

$properties = $info->readDocumentProperties();
$properties->setTitle("My title");
$properties->setLastSavedTime(new Java("java.util.Date"));

$info->updateDocumentProperties($properties);
$info->writeBindedPresentation($fileName);
```

문서 속성을 변경한 결과는 아래와 같습니다.

![PowerPoint 프레젠테이션의 변경된 문서 속성](output_properties.png)

## **유용한 링크**

프레젠테이션 및 보안 속성에 대한 자세한 정보를 얻으려면 다음 링크가 도움이 될 수 있습니다:

- [프레젠테이션이 암호화되었는지 확인](https://docs.aspose.com/slides/ko/php-java/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [프레젠테이션이 쓰기 방지(읽기 전용)인지 확인](https://docs.aspose.com/slides/ko/php-java/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [로드하기 전에 프레젠테이션이 비밀번호 보호되는지 확인](https://docs.aspose.com/slides/ko/php-java/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [프레젠테이션을 보호하는데 사용된 비밀번호 확인](https://docs.aspose.com/slides/ko/php-java/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**폰트가 포함되어 있는지 및 어떤 폰트가 포함되어 있는지 어떻게 확인하나요?**

프레젠테이션 수준에서 [embedded-font information](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/getembeddedfonts/)을 찾은 다음, 해당 항목을 [fonts actually used across content](https://reference.aspose.com/slides/ko/php-java/aspose.slides/fontsmanager/getfonts/)와 비교하여 렌더링에 중요한 폰트를 식별합니다.

**파일에 숨겨진 슬라이드가 있는지와 개수를 어떻게 빠르게 확인할 수 있나요?**

[slide collection](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slidecollection/)을 반복하고 각 슬라이드의 [visibility flag](https://reference.aspose.com/slides/ko/php-java/aspose.slides/slide/gethidden/)을 검사합니다.

**사용자 지정 슬라이드 크기와 방향이 사용되는지, 기본값과 다른지 감지할 수 있나요?**

예. 현재 [slide size](https://reference.aspose.com/slides/ko/php-java/aspose.slides/presentation/getslidesize/) 및 방향을 표준 설정과 비교합니다. 이는 인쇄 및 내보내기 동작을 예측하는 데 도움이 됩니다.

**차트가 외부 데이터 소스를 참조하는지 빠르게 확인할 방법이 있나요?**

예. 모든 [charts](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chart/)를 탐색하고 해당 [data source](https://reference.aspose.com/slides/ko/php-java/aspose.slides/chartdata/getdatasourcetype/)를 확인하여 데이터가 내부인지 링크 기반인지, 깨진 링크가 있는지 등을 기록합니다.

**렌더링이나 PDF 내보내기를 느리게 할 수 있는 '무겁기' 슬라이드를 어떻게 평가하나요?**

각 슬라이드마다 객체 수를 집계하고 큰 이미지, 투명도, 그림자, 애니메이션, 멀티미디어 등을 찾아 대략적인 복잡도 점수를 부여하여 잠재적인 성능 병목 현상을 표시합니다.