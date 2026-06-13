---
title: JavaScript에서 프레젠테이션을 XAML로 내보내기
linktitle: 프레젠테이션을 XAML로
type: docs
weight: 30
url: /ko/nodejs-java/export-to-xaml/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 JavaScript에서 PowerPoint 및 OpenDocument 슬라이드를 XAML로 변환합니다—빠르고 Office가 필요 없는 솔루션으로 레이아웃을 그대로 유지합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간략한 소개와 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/)를 통해 내보내기를 사용자 지정하는 방법(숨겨진 슬라이드 내보내기 포함)을 시연합니다. 또한 대체 폰트, XAML 스택 호환성 및 숨겨진 슬라이드 내보내기 동작과 관련된 몇 가지 일반적인 질문에 답변합니다.

## **XAML에 대하여**

XAML은 앱용 사용자 클래스(특히 WPF, UWP 및 Xamarin Forms를 사용하는 앱)를 구축하거나 작성할 수 있는 설명형 프로그래밍 언어입니다.

XML 기반 언어인 XAML은 GUI를 설명하기 위한 Microsoft의 변형입니다. 대부분의 경우 디자이너를 사용하여 XAML 파일을 작업하게 되지만, 여전히 GUI를 직접 작성하고 편집할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 JavaScript 코드는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

[XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/XamlOptions) 클래스를 사용하여 내보내기 프로세스를 제어하고 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 지정할 수 있습니다.

예를 들어, XAML로 내보낼 때 프레젠테이션의 숨겨진 슬라이드를 포함하려면 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) 메서드를 true로 설정하면 됩니다. 다음은 해당 JavaScript 샘플입니다:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**원본 폰트가 머신에 없을 경우 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/)에서 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont)를 사용하세요 — 원본이 없을 때 대체 폰트로 사용됩니다. 이는 예상치 못한 대체를 방지하는 데 도움이 됩니다.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

XAML은 WPF, UWP 및 Xamarin.Forms에서 사용되는 일반 UI 마크업 언어입니다. 내보내기는 Microsoft XAML 스택과의 호환성을 목표로 하며, 정확한 동작 및 특정 구문에 대한 지원은 대상 플랫폼에 따라 다릅니다. 환경에서 마크업을 테스트하세요.

**숨겨진 슬라이드가 지원되나요? 기본적으로 내보내지 않도록 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. [setExportHiddenSlides]를 [XamlOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/xamloptions/)에서 비활성화하면 됩니다 — 필요하지 않다면 끄세요.