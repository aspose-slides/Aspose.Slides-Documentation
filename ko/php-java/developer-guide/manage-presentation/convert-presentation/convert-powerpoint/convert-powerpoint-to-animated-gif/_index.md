---
title: PHP에서 PowerPoint 프레젠테이션을 애니메이션 GIF로 변환
linktitle: PowerPoint를 GIF로
type: docs
weight: 65
url: /ko/php-java/convert-powerpoint-to-animated-gif/
keywords:
- 애니메이션 GIF
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 GIF로
- 프레젠테이션을 GIF로
- 슬라이드를 GIF로
- PPT를 GIF로
- PPTX를 GIF로
- PPT를 GIF로 저장
- PPTX를 GIF로 저장
- PPT를 GIF로 내보내기
- PPTX를 GIF로 내보내기
- 기본 설정
- 사용자 지정 설정
- PowerPoint
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP via Java을 사용하여 PowerPoint 프레젠테이션(PPT, PPTX)을 손쉽게 애니메이션 GIF로 변환합니다. 빠르고 고품질의 결과."
---
## **개요**

Aspose.Slides를 사용하면 몇 줄의 코드만으로 PowerPoint 프레젠테이션을 애니메이션 GIF 파일로 변환할 수 있습니다. 이는 웹 페이지, 메신저 또는 문서에 삽입할 수 있는 가볍고 널리 지원되는 애니메이션 형식으로 슬라이드 내용을 공유해야 할 때 유용합니다. 이 문서에서는 기본 설정을 사용하여 프레젠테이션을 GIF로 내보내는 방법과 [GifOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/gifoptions/)을 통해 프레임 크기, 슬라이드 지연 시간, 전환 프레임 레이트와 같은 옵션을 구성하여 출력을 사용자 지정하는 방법을 설명합니다.

## **기본 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하기**

이 샘플 코드는 표준 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하는 방법을 보여줍니다:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

애니메이션 GIF는 기본 매개변수로 생성됩니다.

{{%  alert  title="TIP"  color="primary"  %}} 
GIF 매개변수를 사용자 지정하려면 [GifOptions](https://reference.aspose.com/slides/ko/php-java/aspose.slides/GifOptions) 클래스를 사용할 수 있습니다. 아래 샘플 코드를 참고하십시오.
{{% /alert %}} 

## **사용자 지정 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하기**
이 샘플 코드는 사용자 지정 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하는 방법을 보여줍니다 :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// 결과 GIF의 크기

    $gifOptions->setDefaultDelay(2000);// 각 슬라이드가 다음 슬라이드로 전환될 때까지 표시되는 시간

    $gifOptions->setTransitionFps(35);// 전환 애니메이션 품질을 높이기 위해 FPS를 증가시킵니다

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Aspose에서 개발한 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 확인해 보세요. 
{{% /alert %}}

## **자주 묻는 질문**

**프레젠테이션에 사용된 글꼴이 시스템에 설치되어 있지 않은 경우는 어떻게 해야 하나요?**

누락된 글꼴을 설치하거나 [fallback 글꼴 구성](/slides/ko/php-java/powerpoint-fonts/)을 수행하십시오. Aspose.Slides가 대체하지만 외형이 다를 수 있습니다. 브랜드 일관성을 위해 필요한 서체가 명시적으로 사용 가능하도록 항상 확인하십시오.

**GIF 프레임에 워터마크를 오버레이할 수 있나요?**

예. 내보내기 전에 마스터 슬라이드 또는 개별 슬라이드에 [반투명 객체/로고 추가](/slides/ko/php-java/watermark/)를 하면 워터마크가 모든 프레임에 표시됩니다.