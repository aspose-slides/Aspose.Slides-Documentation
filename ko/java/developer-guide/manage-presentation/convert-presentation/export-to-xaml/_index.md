---
title: Java에서 XAML으로 프레젠테이션 내보내기
linktitle: 프레젠테이션에서 XAML으로
type: docs
weight: 30
url: /ko/java/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML으로
- OpenDocument를 XAML으로
- 프레젠테이션을 XAML으로
- PPT를 XAML으로
- PPTX를 XAML으로
- ODP를 XAML으로
- PPT를 XAML로 저장
- PPTX를 XAML로 저장
- ODP를 XAML로 저장
- PPT를 XAML으로 내보내기
- PPTX를 XAML으로 내보내기
- ODP를 XAML으로 내보내기
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 PowerPoint 및 OpenDocument 슬라이드를 XAML으로 변환합니다—빠르고 Office 없이 레이아웃을 그대로 유지하는 솔루션입니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML에 대한 간단한 소개를 포함하고, 기본 설정으로 프레젠테이션을 XAML로 저장하는 방법을 보여주며, [XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/)를 통해 내보내기를 맞춤 설정할 수 있으며, 숨겨진 슬라이드 내보내기도 포함됩니다. 또한 폰트 대체, XAML 스택 호환성 및 숨겨진 슬라이드 내보내기 동작과 관련된 일반적인 몇 가지 질문에 답변합니다.

## **XAML 소개**

XAML은 WPF(Windows Presentation Foundation), UWP(Universal Windows Platform) 및 Xamarin Forms와 같은 앱용 사용자 인터페이스를 구축하거나 작성할 수 있게 해주는 선언형 프로그래밍 언어입니다.  
XML 기반 언어인 XAML은 GUI를 설명하기 위한 Microsoft의 변형입니다. 대부분의 경우 디자이너를 사용해 XAML 파일을 작업하게 되지만, 여전히 직접 GUI를 작성하고 편집할 수도 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

다음 Java 코드는 기본 설정으로 프레젠테이션을 XAML로 내보내는 방법을 보여줍니다:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## **맞춤 옵션으로 프레젠테이션을 XAML로 내보내기**

[IXamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IXamlOptions) 인터페이스에서 옵션을 선택하여 내보내기 프로세스를 제어하고 Aspose.Slides가 프레젠테이션을 XAML로 내보내는 방식을 결정할 수 있습니다.  

예를 들어, XAML로 내보낼 때 프레젠테이션의 숨겨진 슬라이드를 포함하려면 [ExportHiddenSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) 속성을 true로 설정하면 됩니다. 다음 예제 Java 코드를 참조하세요:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

## **FAQ**

**원본 폰트가 머신에 없을 경우 예측 가능한 폰트를 보장하려면 어떻게 해야 하나요?**

[XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/)에서 [기본 일반 폰트](https://reference.aspose.com/slides/ko/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-)를 설정하십시오 — 원본 폰트가 없을 경우 대체 폰트로 사용됩니다. 이는 예상치 못한 대체를 방지하는 데 도움이 됩니다.

**내보낸 XAML이 WPF 전용인가요, 아니면 다른 XAML 스택에서도 사용할 수 있나요?**

XAML은 WPF, UWP 및 Xamarin.Forms에서 사용되는 일반 UI 마크업 언어입니다. 내보내기는 Microsoft XAML 스택과의 호환성을 목표로 하며, 구체적인 동작 및 특정 구성 요소에 대한 지원은 대상 플랫폼에 따라 달라집니다. 사용 환경에서 마크업을 테스트하십시오.

**숨겨진 슬라이드가 지원되나요, 그리고 기본적으로 내보내지 않도록 하려면 어떻게 해야 하나요?**

기본적으로 숨겨진 슬라이드는 포함되지 않습니다. 이 동작은 [XamlOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/xamloptions/)의 setExportHiddenSlides를 통해 제어할 수 있습니다 — 숨겨진 슬라이드를 내보낼 필요가 없으면 비활성화 상태로 두십시오.