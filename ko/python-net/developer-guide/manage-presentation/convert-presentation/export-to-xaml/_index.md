---
title: Python으로 XAML에 프레젠테이션 내보내기
linktitle: XAML로 내보내기
type: docs
weight: 30
url: /ko/python-net/export-to-xaml/
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
- Python
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Python에서 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환—빠르고 Office가 필요 없는 솔루션으로 레이아웃을 그대로 유지합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법, [XamlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/)을 통해 내보내기를 사용자 지정하는 방법(숨겨진 슬라이드 내보내기 포함)을 다룹니다. 또한 폰트 대체, XAML 스택 호환성, 숨겨진 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에 답변합니다.

## **XAML에 대하여**

XAML은 설명형 프로그래밍 언어로, 특히 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform), Xamarin Forms와 같은 앱의 사용자 인터페이스를 구축하거나 작성할 수 있게 해줍니다.  

XML 기반 언어인 XAML은 GUI를 설명하기 위한 Microsoft의 변형입니다. 대부분의 경우 디자이너를 사용해 XAML 파일을 작업하게 되지만, 여전히 직접 GUI를 작성하고 편집할 수도 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 Python 코드는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## **맞춤 옵션으로 프레젠테이션을 XAML로 내보내기**

[XamlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/) 클래스에서 내보내기 프로세스를 제어하고 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 결정하는 옵션을 선택할 수 있습니다.  

예를 들어, XAML로 내보낼 때 프레젠테이션의 숨겨진 슬라이드를 포함하려면 [export_hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) 속성을 `True` 로 설정하면 됩니다. 다음은 샘플 Python 코드입니다: 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```

## **FAQ**

**원본 폰트가 시스템에 없을 경우 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/)의 [default_regular_font](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/)을 설정합니다 — 원본 폰트가 없을 때 대체 폰트로 사용됩니다. 이를 통해 예상치 못한 폰트 대체를 방지할 수 있습니다.

**내보낸 XAML은 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

XAML은 WPF, UWP, Xamarin.Forms에서 사용되는 일반 UI 마크업 언어입니다. 내보내기는 Microsoft XAML 스택과의 호환성을 목표로 하며, 특정 구문에 대한 동작 및 지원 여부는 대상 플랫폼에 따라 다릅니다. 사용 환경에서 마크업을 테스트해 보세요.

**숨겨진 슬라이드가 지원되나요? 기본적으로 내보내지 않도록 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. 이 동작은 [XamlOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/)의 [export_hidden_slides](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/)를 통해 제어할 수 있습니다 — 슬라이드를 내보낼 필요가 없으면 해당 옵션을 비활성화 상태로 두세요.