---
title: C++에서 프레젠테이션을 XAML로 내보내기
linktitle: 프레젠테이션을 XAML로
type: docs
weight: 30
url: /ko/cpp/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML로
- OpenDocument를 XAML로
- 프레젠테이션을 XAML로
- PPT를 XAML로
- PPTX를 XAML로
- ODP를 XAML로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML로 내보내기
- PPTX를 XAML로 내보내기
- ODP를 XAML로 내보내기
- C++
- Aspose.Slides
description: "Aspose.Slides를 사용하여 C++에서 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환—빠르고 Office가 필요 없는 솔루션으로 레이아웃을 그대로 유지합니다."
---
## **개요**

이 문서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개를 포함하고, 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/)를 통해 내보내기를 사용자 지정하는 방법을 시연합니다(숨겨진 슬라이드 내보내기 포함). 또한 폰트 대체, XAML 스택 호환성 및 숨긴 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에도 답변합니다.

## **XAML에 대해**

XAML은 설명형 프로그래밍 언어로, 특히 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin Forms를 사용하는 앱의 사용자 인터페이스를 구축하거나 작성할 수 있게 해줍니다.

XML 기반 언어인 XAML은 GUI를 설명하기 위한 Microsoft의 변형입니다. 대부분의 경우 디자이너를 사용하여 XAML 파일을 작업하게 되지만, 여전히 직접 GUI를 작성하고 편집할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 C++ 코드는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

내보내기 프로세스를 제어하고 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 결정하는 옵션을 [IXamlOptions](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.xaml.i_xaml_options) 인터페이스에서 선택할 수 있습니다.

예를 들어, XAML로 내보낼 때 프레젠테이션의 숨겨진 슬라이드를 포함하려면 [set_ExportHiddenSlides()](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313) 메서드에 true 값을 전달하면 됩니다. 아래 샘플 C++ 코드를 확인하십시오:

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```

## **자주 묻는 질문**

**원본 폰트가 시스템에 없을 때 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[set_DefaultRegularFont](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/)을 [XamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/)에 사용하면 원본이 없을 때 대체 폰트로 사용됩니다. 이를 통해 예상치 못한 대체를 방지할 수 있습니다.

**내보낸 XAML이 WPF에서만 사용하도록 의도된 것인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

XAML은 WPF, UWP 및 Xamarin.Forms에서 사용되는 일반 UI 마크업 언어입니다. 내보내기는 Microsoft XAML 스택과의 호환성을 목표로 하며, 특정 구문에 대한 정확한 동작 및 지원 여부는 대상 플랫폼에 따라 달라집니다. 사용 중인 환경에서 마크업을 테스트하십시오.

**숨겨진 슬라이드가 지원되나요, 그리고 기본적으로 내보내지 않도록 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. [XamlOptions](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/)의 [set_ExportHiddenSlides](https://reference.aspose.com/slides/ko/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/)를 통해 이 동작을 제어할 수 있습니다 — 내보낼 필요가 없으면 비활성화 상태로 유지하십시오.