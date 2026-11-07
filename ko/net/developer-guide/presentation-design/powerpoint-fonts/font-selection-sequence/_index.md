---
title: Aspose.Slides for .NET에서 글꼴 선택 순서
linktitle: 글꼴 선택
type: docs
weight: 80
url: /ko/net/font-selection-sequence/
keywords:
- 글꼴 선택
- 글꼴 대체
- 글꼴 교체
- 대체 규칙
- 사용 가능한 글꼴
- 누락된 글꼴
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET이 글꼴을 선택하는 방식을 알아보고, PPT, PPTX 및 ODP 파일을 선명하고 일관되게 표시하도록 하여 지금 바로 슬라이드를 개선하십시오."
---
## **개요**

프레젠테이션이 로드되거나 렌더링되거나 다른 형식으로 변환될 때, Aspose.Slides는 포함된 글꼴과 애플리케이션에서 사용할 수 있는 글꼴을 고려합니다. 필요한 글꼴을 사용할 수 없는 경우, Aspose.Slides는 PowerPoint가 사용할 글꼴에 최대한 가깝게 대체 글꼴을 선택합니다.

사용 가능한 글꼴에는 시스템 글꼴, 애플리케이션에서 로드된 글꼴 및 프레젠테이션에 포함된 글꼴이 포함될 수 있습니다. 일치하는 포함 글꼴과 등록된 글꼴의 경우, 아래에 설명된 .NET 26.11 기본 설정이 우선 순위를 제어합니다. [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)을 통해 정의된 글꼴 대체 규칙은 별도의 메커니즘입니다.

애플리케이션 실행 시간에 글꼴을 추가하거나, 프레젠테이션에 포함된 글꼴을 사용하거나, PDF 파일과 같은 출력 문서를 위해 외부 글꼴을 로드할 수도 있습니다.

## **글꼴 선택**

텍스트는 명시적인 패밀리 이름 대신 `+mn-lt`와 같은 테마 글꼴을 참조할 수 있습니다. 적용 가능한 테마가 지정한 패밀리를 얻으려면 [테마 글꼴 참조 해결](/slides/ko/net/presentation-theme/#resolve-theme-font-references)을 참조하십시오. 해당 참조를 해결하는 것은 글꼴 가용성을 확인하고 렌더링 시간 대체 또는 글리프 폴백을 적용하는 것과 별개이며, 텍스트를 실제로 렌더링하는 데 최종적으로 사용되는 글꼴 파일을 식별하지 않습니다.

슬라이드를 렌더링하거나 프레젠테이션을 변환할 때, 요청된 글꼴이 포함되어 있거나 등록된 소스에서 사용할 수 있는지 확인하십시오. 누락된 글꼴은 교체 또는 대체가 필요할 수 있습니다; [**글꼴 교체**](/slides/ko/net/font-replacement/) 및 [**글꼴 대체**](/slides/ko/net/font-substitution/)를 참조하십시오.

글꼴 선택을 조사할 때:
1. 요청된 패밀리와 스타일을 해결하고, 모든 테마 참조를 포함합니다.
2. 시스템 글꼴 및 애플리케이션에서 로드된 글꼴을 포함한 포함 글꼴과 등록된 소스를 확인합니다. 일치하는 포함 및 등록 버전이 경쟁할 경우 아래 기본 설정을 사용하십시오.
3. 요청된 글꼴이나 문자가 사용 불가능한 경우 [글꼴 대체 규칙](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/)와 글리프 폴백을 검토하십시오.

Aspose.Slides를 사용하면 애플리케이션 실행 시간에 글꼴을 추가하고 해당 글꼴을 사용할 수 있습니다. [**맞춤형 글꼴**](/slides/ko/net/custom-font/)을 참조하십시오.

프레젠테이션에 추가 글꼴을 배치하면 이를 [**포함된 글꼴**](/slides/ko/net/embedded-font/)이라고 합니다.

Aspose.Slides는 *오직* 출력 문서에만 적용되는 글꼴을 추가할 수 있게 합니다. 예를 들어, PDF로 변환하려는 프레젠테이션에 시스템 및 포함된 글꼴에 없는 글꼴이 포함되어 있으면 필요한 글꼴을 **외부 글꼴**로 추가하거나 로드할 수 있습니다.

{{% alert title="Note" color="info" %}} 
우리는 유료든 무료든 어떠한 글꼴도 배포하지 않습니다. 우리의 API를 통해 외부 글꼴을 로드하고 문서에 포함시킬 수 있지만, 이는 사용자의 재량과 책임하에 수행되어야 합니다.
{{% /alert %}}

## **등록된 글꼴을 포함된 글꼴보다 우선**

.NET 26.11부터, [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/)을 사용하면 일치하는 등록된 글꼴이 내보내기 시 포함된 글꼴보다 우선 순위를 가집니다. 기본값은 `false`입니다. 일치는 글꼴 이름과 스타일을 사용하며, 다른 패밀리 이름은 교체 일치가 아닙니다. 등록된 글꼴은 시스템 또는 [명시적으로 로드된 글꼴 소스](/slides/ko/net/custom-font/)에서 올 수 있습니다.

다음 예제는 .NET 8에서 **Aspose.Slides.NET6.CrossPlatform 26.11** 패키지를 사용합니다. 환경에 맞는 [설치 가이드](/slides/ko/net/installation/)를 따르십시오. 포함된 글꼴이 들어 있는 `embedded-fonts.pptx`와 동일한 패밀리 이름 및 스타일을 가진 `preferred.ttf`를 제공하십시오. 두 글꼴 파일은 출력을 비교하려면 눈에 띄게 달라야 합니다.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

이 설정은 내보내기 중에 글꼴 우선 순위를 변경하지만, 텍스트의 글꼴 이름을 바꾸거나 포함된 글꼴 데이터를 제거하거나 등록된 파일을 다시 포함하지는 않습니다. 이는 실행 시간 설정이며, 프레젠테이션을 다시 연 후에도 다시 설정해야 합니다. 일치하는 등록된 글꼴이 없을 경우, 기본 설정을 활성화해도 제공되지 않으며, 대상 환경에서 결과 글꼴 및 레이아웃을 확인해야 합니다.

위 구성에 대해 명시적으로 로드된 일반 글꼴을 사용한 PNG 및 PDF 출력이 확인되었습니다. 동일한 결과에 의존하기 전에 자신의 글꼴 파일, 스타일, SDK 빌드 및 출력 형식을 확인하십시오. 글꼴 메트릭은 줄 바꿈 및 위치에 영향을 줄 수 있습니다. 다른 패밀리가 필요할 때는 [글꼴 교체](/slides/ko/net/font-replacement/) 또는 [대체](/slides/ko/net/font-substitution/)를 사용하고, 프레젠테이션에 저장된 글꼴을 변경해야 할 때는 [포함된 글꼴 작업](/slides/ko/net/embedded-font/)를 사용하십시오.

## **FAQ**

**변환 전에 프레젠테이션에서 실제로 사용되는 글꼴을 어떻게 확인할 수 있습니까?**

Aspose.Slides는 [글꼴 관리자](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/)를 통해 사용된 글꼴을 검사할 수 있게 하므로, [포함](/slides/ko/net/embedded-font/), [교체](/slides/ko/net/font-replacement/), 또는 [외부 소스](/slides/ko/net/custom-font/)를 추가할지 결정할 수 있습니다. 이는 렌더링 및 내보내기 중 원하지 않는 대체를 방지하는 데 도움이 됩니다.

**운영 체제에 설치하지 않고 추가 글꼴 디렉터리를 추가할 수 있나요?**

예. 폴더나 메모리 스트림과 같은 [외부 글꼴 소스](/slides/ko/net/custom-font/)를 등록하여 렌더링 및 내보내기에 사용할 수 있습니다. 이렇게 하면 호스트 시스템 글꼴에 대한 종속성이 제거되고 레이아웃을 예측 가능하게 유지할 수 있습니다.

**문자가 없을 때 부적절한 글꼴로 조용히 폴백되는 것을 어떻게 방지할 수 있나요?**

사전에 명시적인 [글꼴 교체](/slides/ko/net/font-replacement/) 및 글꼴 [폴백 규칙](/slides/ko/net/fallback-font/)를 정의하십시오. 사용된 글꼴을 분석하고 대체 글꼴에 대한 제어된 우선 순위를 설정함으로써 일관된 타이포그래피를 보장하고 예상치 못한 결과를 방지할 수 있습니다.