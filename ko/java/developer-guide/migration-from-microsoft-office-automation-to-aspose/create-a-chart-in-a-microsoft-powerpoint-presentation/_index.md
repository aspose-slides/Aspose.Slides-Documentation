---
title: VSTO와 Aspose.Slides for Java를 사용하여 차트 만들기
linktitle: 차트 만들기
type: docs
weight: 70
url: /ko/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- 차트 만들기
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Java에서 PowerPoint 차트 생성을 자동화하는 방법을 배우세요. 이 단계별 가이드는 Aspose.Slides for Java가 Microsoft.Office.Interop보다 더 빠르고 강력한 대안인 이유를 보여줍니다."
---
{{% alert color="info" %}} 

차트는 프레젠테이션에서 널리 사용되는 데이터의 시각적 표현입니다. 이 문서에서는 [VSTO](/slides/ko/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) 및 [Aspose.Slides for Java](/slides/ko/java/create-a-chart-in-a-microsoft-powerpoint-presentation/)를 사용하여 Microsoft PowerPoint에서 프로그래밍 방식으로 차트를 만드는 코드를 보여줍니다.

{{% /alert %}} 
## **차트 만들기**
아래 코드 예제는 VSTO를 사용하여 간단한 3D 클러스터형 열 차트를 추가하는 과정을 설명합니다. 프레젠테이션 인스턴스를 만들고, 기본 차트를 추가합니다. 그런 다음 Microsoft Excel 워크북을 사용하여 차트 데이터를 액세스하고 수정하며 차트 속성을 설정합니다. 마지막으로 프레젠테이션을 저장합니다.
### **VSTO 예제**
VSTO를 사용하여 다음 단계가 수행됩니다:

1. Microsoft PowerPoint 프레젠테이션 인스턴스를 생성합니다.
1. 프레젠테이션에 빈 슬라이드를 추가합니다.
1. **3D clustered column** 차트를 추가하고 액세스합니다.
1. 새 Microsoft Excel Workbook 인스턴스를 생성하고 차트 데이터를 로드합니다.
1. Microsoft Excel Workbook instancefromworkbook를 사용하여 차트 데이터 워크시트에 액세스합니다.
1. 워크시트에서 차트 범위를 설정하고 차트에서 시리즈 2와 3을 제거합니다.
1. 차트 데이터 워크시트에서 차트 범주 데이터를 수정합니다.
1. 차트 데이터 워크시트에서 차트 시리즈 1 데이터를 수정합니다.
1. 이제 차트 제목에 액세스하고 setthefontrelatedproperties를 설정합니다.
1. 차트 값 축에 액세스하고 주요 단위, 세부 단위, 최대값 및 최소값을 설정합니다.
1. 이 예제에서는 차트 깊이(또는 시리즈 축)에 액세스하고 onlyoneserieisused와 같이 제거합니다.
1. 이제 X 및 Y 방향으로 차트 회전 각도를 설정합니다.
1. 프레젠테이션을 저장합니다.
1. Microsoft Excel 및 PowerPoint 인스턴스를 닫습니다.

**VSTO로 만든 출력 프레젠테이션** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Aspose.Slides for Java 예제**
Aspose.Slides for Java를 사용하여 다음 단계가 수행됩니다:

1. Microsoft PowerPoint 프레젠테이션 인스턴스를 생성합니다.
1. 프레젠테이션에 빈 슬라이드를 추가합니다.
1. **3D clustered column** 차트를 추가하고 해당 차트에 액세스합니다.
1. Microsoft Excel Workbook instancefromworkbook를 사용하여 차트 데이터 워크시트에 액세스합니다.
1. 사용되지 않는 시리즈 2와 3을 제거합니다.
1. 차트 카테고리에 액세스하고 레이블을 수정합니다.
1. Accesseries1에 액세스하고 시리즈 값을 수정합니다.
1. 이제 차트 제목에 액세스하고 폰트 속성을 설정합니다.
1. 차트 값 축에 액세스하고 주요 단위, 세부 단위, 최대값 및 최소값을 설정합니다.
1. 이제 X 및 Y 방향으로 차트 회전 각도를 설정합니다.
1. 프레젠테이션을 PPTX 형식으로 저장합니다.

**Aspose.Slides로 만든 출력 프레젠테이션** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **FAQ**

### Aspose.Slides로 파이, 선, 막대 차트와 같은 다른 유형의 차트를 만들 수 있나요?
네. Aspose.Slides는 파이 차트, 선 차트, 막대 차트, 산점도, 버블 차트 등 다양한 [chart types](/slides/ko/java/create-chart/)를 지원합니다. 차트를 추가할 때 원하는 차트 유형을 [ChartType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/charttype/) 클래스로 지정할 수 있습니다.

### 차트에 사용자 정의 스타일이나 테마를 적용할 수 있나요?
네. 색상, 글꼴, 채우기, 윤곽선, 격자선 및 레이아웃 등 차트의 모양을 완전히 사용자 정의할 수 있습니다. 다만 PowerPoint에서 보는 Office 테마를 정확히 적용하려면 개별 스타일을 수동으로 설정해야 합니다.

### 차트를 슬라이드와 별도로 이미지로 내보낼 수 있나요?
네, Aspose.Slides는 차트[shape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/shape/)의 `getImage` 메서드를 사용하여 차트를 포함한 모든 도형을 별도의 이미지(PNG, JPEG 등)로 내보낼 수 있습니다.