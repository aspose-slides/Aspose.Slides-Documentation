---
title: C++를 사용하여 프레젠테이션 차트의 오류 표시줄 사용자 지정
linktitle: 오류 표시줄
type: docs
url: /ko/cpp/error-bar/
keywords:
- 오류 표시줄
- 사용자 지정 값
- PowerPoint
- 프레젠테이션
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 차트에 오류 표시줄을 추가하고 사용자 지정하는 방법을 배우고, PowerPoint 프레젠테이션에서 데이터 시각화를 최적화하십시오."
---
## **Overview**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션 차트에서 오류 표시줄을 사용하는 방법을 설명합니다. 차트 시리즈에 오류 표시줄을 추가하고, X 및 Y 오류 표시줄 설정을 구성하며, 고정값, 백분율 및 사용자 지정 값과 같은 다양한 값 유형을 적용하는 방법을 보여줍니다.

또한 해당 데이터 포인트 컬렉션을 사용하여 시리즈의 개별 데이터 포인트에 사용자 지정 오류 표시줄 값을 할당하는 방법을 시연합니다. 추가로, 오류 표시줄이 내보내기 시 어떻게 동작하는지, 마커 및 데이터 레이블과의 호환성, 그리고 관련 API 참조 클래스와 열거형을 찾을 수 있는 위치에 대한 간략한 참고 사항도 포함되어 있습니다.

## **Add Error Bars**
Aspose.Slides for C++는 오류 표시줄 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 사용자 지정 값 유형을 사용할 때 적용됩니다. 값을 지정하려면 시리즈의 **DataPoints** 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 원하는 슬라이드에 버블 차트를 추가합니다.
3. 첫 번째 차트 시리즈에 접근하고 오류 표시줄 X 형식을 설정합니다.
4. 첫 번째 차트 시리즈에 접근하고 오류 표시줄 Y 형식을 설정합니다.
5. 막대 값을 설정하고 형식을 지정합니다.
6. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddErrorBars-AddErrorBars.cpp" >}}

## **Add Custom Error Bars**
Aspose.Slides for C++는 사용자 지정 오류 표시줄 값을 관리하기 위한 간단한 API를 제공합니다. 샘플 코드는 **IErrorBarsFormat.ValueType** 속성이 **Custom**인 경우에 적용됩니다. 값을 지정하려면 시리즈의 **DataPoints** 컬렉션에 있는 특정 데이터 포인트의 **ErrorBarCustomValues** 속성을 사용합니다:

1. [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 원하는 슬라이드에 버블 차트를 추가합니다.
3. 첫 번째 차트 시리즈에 접근하고 오류 표시줄 X 형식을 설정합니다.
4. 첫 번째 차트 시리즈에 접근하고 오류 표시줄 Y 형식을 설정합니다.
5. 차트 시리즈의 개별 데이터 포인트에 접근하고 해당 데이터 포인트에 대한 오류 표시줄 값을 설정합니다.
6. 막대 값을 설정하고 형식을 지정합니다.
7. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddCustomError-AddCustomError.cpp" >}}

## **FAQ**

**What happens to error bars when exporting a presentation to PDF or images?**  
오류 표시줄은 차트의 일부로 렌더링되며, 호환 가능한 버전 또는 렌더러가 사용되는 경우 차트 서식과 함께 변환 중에 보존됩니다.

**Can error bars be combined with markers and data labels?**  
예. 오류 표시줄은 별개의 요소이며 마커 및 데이터 레이블과 호환됩니다. 요소가 겹치는 경우 서식을 조정해야 할 수 있습니다.

**Where can I find the list of properties and enums for working with error bars in the API?**  
API 참조에서 확인할 수 있습니다: [ErrorBarsFormat](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/errorbarsformat/) 클래스와 관련 열거형인 [ErrorBarType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/errorbartype/) 및 [ErrorBarValueType](https://reference.aspose.com/slides/ko/cpp/aspose.slides.charts/errorbarvaluetype/).