---
title: PHP에서 XAML으로 프레젠테이션 내보내기
linktitle: 프레젠테이션을 XAML으로
type: docs
weight: 30
url: /ko/php-java/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint에서 XAML으로
- OpenDocument에서 XAML으로
- 프레젠테이션에서 XAML으로
- PPT에서 XAML으로
- PPTX에서 XAML으로
- ODP에서 XAML으로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML로 내보내기
- PPTX를 XAML로 내보내기
- ODP를 XAML로 내보내기
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 Java를 통해 사용하여 PowerPoint와 OpenDocument 슬라이드를 XAML으로 변환합니다 — 레이아웃을 그대로 유지하는 빠르고 Office 없이 사용할 수 있는 솔루션."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML에 저장하는 방법, 그리고 [XamlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/)을 통해 내보내기를 사용자 지정하는 방법(숨겨진 슬라이드 내보내기 포함)을 보여줍니다. 또한 폰트 대체, XAML 스택 호환성 및 숨겨진 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에 답합니다.

## **XAML 소개**

XAML은 앱용 사용자 인터페이스를 구축하거나 작성할 수 있게 해주는 기술적 설명 언어이며, 특히 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform) 및 Xamarin Forms와 같은 환경에서 사용됩니다.

XML 기반 언어인 XAML은 GUI를 설명하기 위한 Microsoft의 변형입니다. 대부분의 경우 디자이너를 사용해 XAML 파일을 작업하지만, 직접 GUI를 작성하고 편집할 수도 있습니다.

## **기본 옵션으로 XAML에 프레젠테이션 내보내기**

다음 PHP 코드는 기본 설정으로 프레젠테이션을 XAML에 내보내는 방법을 보여줍니다.

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **맞춤 옵션을 사용한 XAML에 프레젠테이션 내보내기**

[XamlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/) 클래스에서 내보내기 프로세스를 제어하고 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 결정하는 옵션을 선택할 수 있습니다.

예를 들어, XAML로 내보낼 때 프레젠테이션의 숨겨진 슬라이드를 포함하도록 하려면 `true` 값을 사용하여 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/setexporthiddenslides/) 메서드를 호출하면 됩니다. 다음은 샘플 PHP 코드입니다.

```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**원본 폰트가 머신에 없을 경우 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/)에 [기본 일반 폰트](https://reference.aspose.com/slides/ko/php-java/aspose.slides/saveoptions/#setDefaultRegularFont)를 설정하면 원본 폰트가 없을 때 대체 폰트로 사용됩니다. 이를 통해 예기치 않은 대체를 방지할 수 있습니다.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

XAML은 WPF, UWP 및 Xamarin.Forms에서 사용되는 일반 UI 마크업 언어입니다. 내보내기는 Microsoft XAML 스택과의 호환성을 목표로 하며, 정확한 동작 및 특정 구문 지원은 대상 플랫폼에 따라 다릅니다. 사용 중인 환경에서 마크업을 테스트하십시오.

**숨겨진 슬라이드가 지원되나요? 기본적으로 숨겨진 슬라이드가 내보내지지 않도록 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. [XamlOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/)에서 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/php-java/aspose.slides/xamloptions/setexporthiddenslides/)를 비활성화 상태로 유지하면 숨겨진 슬라이드가 내보내지지 않습니다.