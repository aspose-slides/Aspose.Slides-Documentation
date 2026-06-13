---
title: C++에서 PowerPoint 프레젠테이션을 애니메이션 GIF로 변환
linktitle: PowerPoint를 GIF로
type: docs
weight: 65
url: /ko/cpp/convert-powerpoint-to-animated-gif/
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
- 사용자 정의 설정
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 PowerPoint 프레젠테이션(PPT, PPTX)을 손쉽게 애니메이션 GIF로 변환합니다. 빠르고 고품질 결과를 제공합니다."
---
## **개요**

Aspose.Slides는 몇 줄의 코드만으로 PowerPoint 프레젠테이션을 애니메이션 GIF 파일로 변환할 수 있습니다. 웹 페이지, 메신저 또는 문서에 삽입할 수 있는 가볍고 널리 지원되는 애니메이션 형식으로 슬라이드 내용을 공유해야 할 때 유용합니다. 이 문서에서는 기본 설정을 사용하여 프레젠테이션을 GIF로 내보내는 방법과 프레임 크기, 슬라이드 지연 시간, 전환 프레임 속도와 같은 옵션을 [GifOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/gifoptions/)를 통해 구성하여 출력을 사용자 정의하는 방법을 설명합니다.

## **기본 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환**

C++ 샘플 코드는 표준 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

애니메이션 GIF는 기본 매개변수로 생성됩니다. 

{{%  alert  title="TIP"  color="primary"  %}} 

GIF 매개변수를 사용자 정의하려면 [GifOptions](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.gif_options) 클래스를 사용할 수 있습니다. 아래 샘플 코드를 확인하세요. 

{{% /alert %}} 

## **사용자 정의 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환**

C++에서 사용자 정의 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하는 방법을 보여주는 샘플 코드입니다:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// 결과 GIF의 크기 
gifOptions->set_FrameSize(Size(960, 720));
// 각 슬라이드가 다음 슬라이드로 전환될 때까지 표시되는 시간
gifOptions->set_DefaultDelay(2000);
// 전환 애니메이션 품질을 높이기 위해 FPS 증가
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

Aspose에서 개발한 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 확인해 보세요. 

{{% /alert %}}

## **FAQ**

**프레젠테이션에 사용된 글꼴이 시스템에 설치되지 않은 경우는 어떻게 해야 하나요?**

누락된 글꼴을 설치하거나 [fallback 글꼴을 구성](/slides/ko/cpp/powerpoint-fonts/)하세요. Aspose.Slides가 대체해 주지만 외관이 다를 수 있습니다. 브랜드 일관성을 위해서는 필요한 글꼴을 명시적으로 사용 가능하도록 항상 확보하십시오.

**GIF 프레임에 워터마크를 오버레이할 수 있나요?**

예. 내보내기 전에 마스터 슬라이드나 개별 슬라이드에 반투명 객체/로고를 추가하면 워터마크가 모든 프레임에 표시됩니다.