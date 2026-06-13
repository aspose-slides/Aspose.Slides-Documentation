---
title: VSTO와 Aspose.Slides for Java를 사용하여 Excel 차트를 OLE 개체로 만들고 삽입하기
linktitle: Excel 차트를 OLE 개체로 만들고 삽입하기
type: docs
weight: 60
url: /ko/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- 차트 만들기
- Excel 차트 삽입
- OLE 개체
- 마이그레이션
- VSTO
- Office 자동화
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Microsoft Office 자동화에서 Aspose.Slides for Java로 마이그레이션하고 Java에서 Excel 차트를 OLE 개체로 PowerPoint(PPT, PPTX) 슬라이드에 삽입합니다."
---
{{% alert color="primary" %}} 

 차트는 데이터의 시각적 표현이며 프레젠테이션 슬라이드에서 널리 사용됩니다. 이 문서에서는 [VSTO](/slides/ko/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)와 [Aspose.Slides for Java](/slides/ko/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/)를 사용하여 Excel 차트를 OLE 개체로 PowerPoint 슬라이드에 프로그래밍 방식으로 생성하고 삽입하는 코드를 보여드립니다.

{{% /alert %}} 
## **Excel 차트 만들기 및 삽입**
아래 두 코드 예제는 작업이 복잡하기 때문에 길고 자세합니다. Microsoft Excel 워크북을 만들고, 차트를 만든 다음, 차트를 삽입할 Microsoft PowerPoint 프레젠테이션을 만듭니다. OLE 개체는 원본 문서에 대한 링크를 포함하므로 사용자가 삽입된 파일을 더블 클릭하면 해당 파일 및 애플리케이션이 실행됩니다.
### **VSTO 예제**
VSTO를 사용하여 다음 단계가 수행됩니다:

1. Microsoft Excel ApplicationClass 객체의 인스턴스를 생성합니다.
1. 하나의 시트가 포함된 새 워크북을 만듭니다.
1. 시트에 차트를 추가합니다.
1. 워크북을 저장합니다.
1. 차트 데이터가 있는 워크시트가 포함된 Excel 워크북을 엽니다.
1. 시트에 대한 ChartObjects 컬렉션을 가져옵니다.
1. 복사할 차트를 가져옵니다.
1. Microsoft PowerPoint 프레젠테이션을 생성합니다.
1. 프레젠테이션에 빈 슬라이드를 추가합니다.
1. Excel 워크시트에서 차트를 클립보드로 복사합니다.
1. 차트를 PowerPoint 프레젠테이션에 붙여넣습니다.
1. 슬라이드에 차트를 배치합니다.
1. 프레젠테이션을 저장합니다.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Aspose.Slides for Java 예제**
Aspose.Slides for .NET을 사용하여 다음 단계가 수행됩니다:

1. Aspose.Cells for Java를 사용해 워크북을 만듭니다.
1. Microsoft Excel 차트를 생성합니다.
1. Excel 차트의 OLE 크기를 설정합니다.
1. 차트의 이미지를 가져옵니다.
1. Aspose.Slides for Java를 사용해 PPTX 프레젠테이션에 Excel 차트를 OLE 개체로 삽입합니다.
1. 개체 변경 문제를 해결하기 위해 3단계에서 얻은 이미지를 사용해 개체 변경 이미지를 교체합니다.
1. 출력 프레젠테이션을 PPTX 형식으로 디스크에 저장합니다.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}