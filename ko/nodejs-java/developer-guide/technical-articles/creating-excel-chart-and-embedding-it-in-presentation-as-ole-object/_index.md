---
title: Excel 차트를 만들고 프레젠테이션에 OLE 개체로 삽입하기
type: docs
weight: 30
url: /ko/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/
keywords:
- Excel 차트
- 차트 삽입
- OLE 개체
- PowerPoint
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Java를 통해 Node.js용 Aspose.Cells로 Excel 차트를 만들고, Aspose.Slides를 사용해 PowerPoint 프레젠테이션에 워크북을 삽입하며 차트 미리보기도 포함합니다."
---
## **개요**

이 문서에서는 Java를 통해 Node.js용 Aspose.Cells를 사용하여 Excel 세로 막대 차트를 생성하고, Java를 통해 Node.js용 Aspose.Slides를 사용하여 해당 통합 문서를 PowerPoint 프레젠테이션에 삽입하는 방법을 보여줍니다. 삽입된 통합 문서에는 원본 데이터와 차트가 모두 포함됩니다. 별도의 PNG 미리보기가 OLE 개체가 활성화되기 전에 슬라이드에 차트를 표시합니다.

결과는 네이티브 PowerPoint 차트가 아닌 삽입된 Excel 개체입니다. OLE를 통한 통합 문서 편집에는 OLE 활성화를 지원하는 데스크톱 애플리케이션과 호환되는 Excel 설치가 필요합니다.

## **전제 조건**

`aspose.cells`, `aspose.slides.via.java`, 및 `java` Node.js 패키지를 설치합니다. 예제는 두 개의 CommonJS 스크립트를 별도의 Node.js 프로세스에서 실행합니다: 먼저 `create-chart.js`, 다음 `embed-chart.js`를 동일한 작업 디렉터리에서 실행합니다. 두 Aspose 패키지는 로드 시 Java 브리지를 초기화하므로 예제는 별도 프로세스에서 실행합니다. Microsoft Office는 이러한 라이브러리를 사용해 프레젠테이션을 생성하는 데 필요하지 않습니다.

기존 통합 문서나 이미지가 필요하지 않습니다. 첫 번째 스크립트는 `ChartWorkbook.xlsx`와 `ChartPreview.png`를 생성하고, 두 번째 스크립트는 해당 파일들을 읽어 현재 작업 디렉터리에 `OutputChart.pptx`를 작성합니다. 평가 모드가 아닌 경우 두 제품 모두 라이선스를 적용하십시오.

## **삽입 작동 방식**

1. 데이터 워크시트와 차트 시트가 포함된 통합 문서를 생성합니다.
1. 차트 시트를 활성화하여 통합 문서가 차트에서 열리도록 합니다.
1. 통합 문서의 OLE 표시 범위를 설정하고 차트를 PNG로 렌더링합니다.
1. 통합 문서를 XLSX 형식으로 저장하고 별도의 Node.js 프로세스에서 슬라이드에 해당 바이트를 삽입합니다.
1. PNG를 OLE 개체의 미리보기로 지정하고 프레젠테이션을 PPTX로 저장합니다.

통합 문서 표시 범위와 슬라이드의 프레임은 서로 다른 역할을 합니다. [setOleSize](https://reference.aspose.com/cells/nodejs/aspose.cells/worksheetcollection/#setolesize) 은 0부터 시작하는 시작/끝 행 및 열 인덱스를 사용합니다. [ChartCollection.add](https://reference.aspose.com/cells/nodejs/aspose.cells/chartcollection/#add) 은 대신 상단 행, 왼쪽 열, 하단 행, 오른쪽 열을 사용합니다. 예제에서는 행 인덱스 55와 열 인덱스 25를 오른쪽 아래 경계로 사용합니다; 이러한 값은 레이아웃 선택이며 데이터 행 또는 열 수와는 관계가 없습니다.

슬라이드 프레임은 포인트 단위를 사용합니다. 예제에서는 슬라이드 내에 맞추고 중앙에 배치하면서 PNG의 종횡비를 유지하도록 하여 미리보기가 슬라이드를 가득 채우도록 늘어나지 않게 합니다.

## **차트 만들기 및 삽입**

첫 번째 예제를 `create-chart.js`로 저장합니다. 이 스크립트는 `DataSheet`에 4행 5열의 값을 채웁니다. 각 행은 차트 시리즈가 됩니다. 통합 문서를 저장하기 전에 `ChartSheet`를 활성 시트로 선택합니다.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("DataSheet");

    const values = [
        [67, 44, 46, 43, 24],
        [86, 64, 97, 29, 40],
        [68, 89, 78, 69, 38],
        [91, 48, 60, 26, 25]
    ];

    for (let row = 0; row < values.length; row++) {
        for (let column = 0; column < values[row].length; column++) {
            dataSheet.getCells().get(row, column).putValue(values[row][column]);
        }
    }

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    chartSheet.setName("ChartSheet");

    const lastChartRow = 55;
    const lastChartColumn = 25;
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, lastChartRow, lastChartColumn);
    const chart = chartSheet.getCharts().get(chartIndex);
    for (let row = 1; row <= values.length; row++) {
        chart.getNSeries().add("DataSheet!A" + row + ":E" + row, false);
    }

    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);
    workbook.getWorksheets().setOleSize(0, lastChartRow, 0, lastChartColumn);

    // 차트 미리보기를 렌더링하고 편집 가능한 워크북을 별도로 직렬화합니다.
    const imageOptions = new cells.ImageOrPrintOptions();
    imageOptions.setImageType(cells.ImageType.PNG);
    chart.toImage("ChartPreview.png", imageOptions);
    workbook.save("ChartWorkbook.xlsx", cells.SaveFormat.XLSX);
} finally {
    workbook.dispose();
}

// 모든 동기 작업이 완료되었습니다; Java 브리지 프로세스를 종료합니다.
process.exit(0);
```

다음 예제를 `embed-chart.js`로 저장합니다. `create-chart.js`가 두 입력 파일을 만든 후 실행합니다. OLE 프레임을 중앙에 배치하고 미리보기 이미지의 종횡비를 유지합니다.

두 번째 스크립트는 저장된 통합 문서를 삽입하고 PNG를 미리보기로 사용합니다. 통합 문서는 명시적으로 XLSX 형식으로 저장되며, 이는 [OleEmbeddedDataInfo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleembeddeddatainfo/) 에 전달된 `xlsx` 확장자와 일치합니다. PNG는 중간 비트맵 변환 없이 바이트에서 직접 로드됩니다. Java 브리지는 이미지와 통합 문서 데이터에 대해 명시적인 Java 바이트 배열을, 슬라이드 프레임 좌표에 대해 Java float 값을 요구합니다. [getSubstitutePictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/oleobjectframe/#getSubstitutePictureFormat) 을 통해 이를 할당하면 기본 OLE 자리표시자가 교체됩니다.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const chartImageBuffer = fs.readFileSync("ChartPreview.png");
const chartImageBytes = java.newArray("byte", Array.from(chartImageBuffer));
const workbookBuffer = fs.readFileSync("ChartWorkbook.xlsx");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const chartImage = slides.Images.fromData(chartImageBytes);
try {
    const presentation = new slides.Presentation();
    try {
        const slide = presentation.getSlides().get_Item(0);
        const slideWidth = presentation.getSlideSize().getSize().getWidth();
        const slideHeight = presentation.getSlideSize().getSize().getHeight();

        // 미리보기를 비율을 변경하지 않고 슬라이드 안에 맞춥니다.
        const scale = Math.min(slideWidth / chartImage.getWidth(), slideHeight / chartImage.getHeight());
        const frameWidth = (chartImage.getWidth() * scale);
        const frameHeight = (chartImage.getHeight() * scale);
        const frameX = ((slideWidth - frameWidth) / 2);
        const frameY = ((slideHeight - frameHeight) / 2);

        const embeddedData = new slides.OleEmbeddedDataInfo(workbookBytes, "xlsx");
        const oleFrame = slide.getShapes().addOleObjectFrame(java.newFloat(frameX), java.newFloat(frameY), java.newFloat(frameWidth), java.newFloat(frameHeight), embeddedData);
        const previewImage = presentation.getImages().addImage(chartImage);
        oleFrame.getSubstitutePictureFormat().getPicture().setImage(previewImage);

        presentation.save("OutputChart.pptx", slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
} finally {
    chartImage.dispose();
}

// 모든 동기 작업이 완료되었습니다; Java 브리지 프로세스를 종료합니다.
process.exit(0);
```

## **예상 결과**

`OutputChart.pptx`에는 삽입된 Excel 통합 문서와 차트 미리보기가 포함된 하나의 슬라이드가 있습니다. 통합 문서에는 원본 데이터와 4개의 시리즈가 있는 세로 막대 차트가 포함됩니다. 미리보기는 슬라이드 중앙에 배치되고 비율을 유지합니다.

![삽입된 통합 문서의 미리보기로 표시된 Excel 세로 막대 차트](excel-chart-ole-preview.png)

호환되는 데스크톱 PowerPoint 환경에서 Excel이 설치되어 있으면 개체를 더블 클릭하여 활성화하고 삽입된 통합 문서를 편집할 수 있습니다. 활성화 및 편집은 호스트 애플리케이션의 OLE 지원 및 보안 설정에 따라 달라집니다.

## **FAQ**

**미리보기 이미지가 필요한 이유는?**

삽입된 통합 문서와 슬라이드 미리보기는 별개의 콘텐츠입니다. 차트 이미지를 제공하여 슬라이드가 기본 "EMBEDDED OLE OBJECT" 자리표시자 대신 차트를 표시하도록 합니다. [Object Preview Issue when Adding OleObjectFrame](/slides/ko/nodejs-java/object-preview-issue-when-adding-oleobjectframe/).

**코드를 통해 통합 문서를 변경하면 미리보기가 자동으로 업데이트됩니까?**

미리보기를 스냅샷으로 간주합니다. 프로그램으로 통합 문서 데이터를 업데이트할 때 차트 이미지를 다시 생성하고 미리보기와 삽입된 통합 문서 데이터를 교체합니다.

**XLS를 사용하고 XLSX 대신 사용할 수 있나요?**

예. 통합 문서를 XLS 형식으로 저장하고 `xls`를 삽입된 데이터 확장자로 사용합니다. 확장자는 실제 통합 문서 형식과 일치해야 하며, 확장자만 변경해도 데이터가 변환되지 않습니다.

**활성화 후 개체 크기가 변경될 수 있는 이유는?**

호스트 애플리케이션이 통합 문서를 활성화할 때 OLE 개체의 표시를 업데이트할 수 있습니다. 통합 문서의 OLE 표시 범위와 슬라이드 프레임 크기가 모두 중요합니다. [Working Solution for Chart Resizing in PPTX](/slides/ko/java/working-solution-for-chart-resizing-in-pptx/).

## **관련 섹션**

- [Working Solution for Chart Resizing in PPTX](/slides/ko/java/working-solution-for-chart-resizing-in-pptx/)
- [Object Preview Issue when Adding OleObjectFrame](/slides/ko/nodejs-java/object-preview-issue-when-adding-oleobjectframe/)