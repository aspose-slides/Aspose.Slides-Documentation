---
title: Java를 사용하여 프레젠테이션에서 차트 워크북 관리
linktitle: 차트 워크북
type: docs
weight: 70
url: /ko/java/chart-workbook/
keywords:
- 차트 워크북
- 차트 데이터
- 워크북 셀
- 데이터 레이블
- 워크시트
- 데이터 원본
- 외부 워크북
- 외부 데이터
- 차트 캐시
- 워크북 복구
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 발견하십시오: PowerPoint 및 OpenDocument 형식의 차트 워크북을 손쉽게 관리하여 프레젠테이션 데이터를 간소화합니다."
---
## **개요**

이 문서는 Aspose.Slides에서 차트 워크북을 사용하는 방법을 설명합니다. 워크북 스트림을 통해 차트 데이터를 읽고 쓰는 방법, 워크북 셀을 차트 데이터 레이블로 사용하는 방법, 워크시트 컬렉션에 접근하는 방법 및 차트 값에 대한 데이터 원본 유형을 지정하는 방법을 보여줍니다.

또한 외부 워크북을 차트 데이터 원본으로 사용하는 방법도 다룹니다. 예제에서는 외부 워크북을 생성하고 할당하는 방법, 차트에 연결된 외부 워크북의 경로를 가져오는 방법, 워크북이 사용 가능한 경우 차트 데이터를 편집하는 방법을 보여줍니다.

워크북 셀이 누락된 데이터를 나타내는 경우, 빈 셀과 0의 차이 및 사용 가능한 표시 모드의 라인 차트 비교에 대해서는 [빈 셀 표시 제어](/slides/ko/java/chart-series/)를 참조하십시오.

## **숨겨진 행 및 열의 데이터 포함**

[IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-)를 사용하여 차트가 숨겨진 워크시트 행 및 열의 데이터를 플롯할지 여부를 제어합니다. `true`로 설정하면 보이는 셀만 플롯하고, `false`로 설정하면 보이는 셀과 숨겨진 셀 모두를 포함합니다. 이 설정은 차트 플로팅을 제어하며 워크시트 행이나 열을 숨기거나 표시하지는 않습니다.

[hidden-source-data.pptx](hidden-source-data.pptx) 파일을 다운로드하여 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 첫 번째 도형으로 열 차트가 포함되어 있습니다. 포함된 워크시트 `Sheet1`에는 `A1:C4` 범위가 포함되어 있습니다. 행 3과 열 C는 숨겨져 있으나 해당 셀에는 값이 그대로 있습니다.

| 워크시트 행 | A: 월 | B: 소매 | C: 도매 (숨긴 열) |
| --- | --- | --- | --- |
| 2 | 1월 | 10 | 30 |
| 3 (숨겨진 행) | 2월 | 40 | 60 |
| 4 | 3월 | 20 | 50 |

소스 셀에 접근하려면 [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)를 사용하고, [IChartDataCell.isHidden](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdatacell/#isHidden--)을 읽어 숨김 상태를 검사합니다. 이 메서드는 상태를 변경하지 않고 숨김 상태를 반환합니다. 이 파일에서 B2는 보이며, B3는 숨겨진 행에 속하고, C2는 숨겨진 열에 속합니다; 예제는 각각 `false`, `true`, `true`를 출력합니다.

이 예제에서는 플로팅 설정을 변경한 후 차트 데이터를 새로 고칩니다: 포함된 워크북을 [readWorkbookStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#readWorkbookStream--)으로 유지하고 [writeWorkbookStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-)으로 다시 로드합니다. 모든 셀을 포함할 때는 숨겨진 2월 범주를 포함한 전체 범위를 복원하기 위해 [setRange](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)도 사용합니다. 단순히 플래그만 변경해도 이 샘플의 캐시된 차트 데이터와 범주 레이블을 새로 고치기에 충분하지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // 포함된 워크북에서 차트 데이터를 새로 고칩니다.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // 숨겨진 범주를 포함한 전체 소스 범위를 복원합니다.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

예제는 보이는 소매 값(10 및 20)만 포함한 `hidden_cells_true.pptx`와 모든 6개 값을 포함한 `hidden_cells_false.pptx`를 저장합니다. 아래 이미지들은 두 가지 플로팅 모드를 보여줍니다. 행 3과 열 C는 두 포함된 워크북 모두에서 숨겨진 상태로 유지됩니다.

| 보이는 셀만 (`true`) | 전체 셀 (`false`) |
| --- | --- |
| ![보이는 셀만: 1월 및 3월의 소매 값 10 및 20.](hidden_cells_True.png) | ![전체 셀: 1월, 2월, 3월의 소매 및 도매 값.](hidden_cells_False.png) |

값을 포함하는 숨겨진 셀은 빈 셀과 다릅니다. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-)는 누락된 값을 표시하는 방식을 제어하지만 숨겨진 소스 데이터를 포함하거나 제외하지는 않습니다. 예제는 [빈 셀 표시 제어](/slides/ko/java/chart-series/#control-the-display-of-empty-cells)를 참조하십시오.

## **워크북에서 차트 데이터 읽고 쓰기**

Aspose.Slides for Java는 차트 데이터 워크북( Aspose.Cells로 편집된 차트 데이터를 포함)을 읽고 쓸 수 있는 [readWorkbookStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#readWorkbookStream--) 및 [writeWorkbookStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) 메서드를 제공합니다. **참고** 차트 데이터는 원본과 동일한 방식으로 정리되었거나 유사한 구조여야 합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `chart.pptx`를 엽니다. 포함된 워크북을 바이트 배열로 읽고 기존 시리즈와 범주를 삭제한 후 동일한 워크북을 다시 씁니다. 변경 사항은 메모리에 남으며, 예제는 프레젠테이션을 저장하지 않습니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **워크북 수정 후 차트 레이아웃 검증**

포함된 워크북을 수정된 워크북으로 교체하면 차트는 원래의 시리즈와 범주 컬렉션을 유지합니다. 이 불일치는 [IChart.validateChartLayout](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/#validateChartLayout--)이 인덱스 범위 초과 오류로 실패하게 할 수 있습니다. 업데이트된 워크북을 차트에 다시 쓰기 전에 기존 시리즈와 범주를 삭제하십시오. 이 예제는 첫 번째 슬라이드에 차트가 있는 `chart.pptx`가 필요합니다. 주석은 워크북 편집이 발생할 위치를 표시하며, 실행 가능한 예제는 원래 워크북을 다시 쓰고 메모리에서 레이아웃을 검증합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // 여기에서 워크북 바이트를 수정하십시오. 예를 들어 Aspose.Cells를 사용합니다.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

컬렉션을 삭제하면 워크북을 다시 쓰기 전에 오래된 데이터 참조가 제거됩니다. 차트를 사용하기 전에 업데이트된 워크북에 필요한 시리즈 및 범주 매핑을 다시 구성하십시오.

## **워크북 셀을 차트 데이터 레이블로 설정**

워크북 셀의 텍스트를 차트 데이터 레이블로 사용할 수 있습니다. 다음 단계에서는 버블 차트의 레이블을 해당 데이터 워크북의 셀에 연결하는 방법을 보여줍니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 0부터 시작하는 인덱스로 첫 번째 슬라이드에 접근합니다.
3. 기본 데이터로 버블 차트를 추가합니다.
4. 차트 시리즈에 접근합니다.
5. 워크북 셀을 데이터 레이블로 설정합니다.
6. 프레젠테이션을 저장합니다.

이 예제는 최소 하나의 슬라이드가 있는 `chart2.pptx`를 열고 기본 데이터로 버블 차트를 추가합니다. 워크시트 0의 셀 A10:A12를 첫 번째 시리즈의 처음 세 레이블로 사용하고, 셀에서 레이블을 활성화한 뒤 결과를 `resultchart.pptx`에 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **워크시트 관리**

[IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) 메서드는 차트 워크북의 워크시트에 접근할 수 있게 합니다. 이 예제는 기본 데이터로 파이 차트를 만들고 각 워크시트 이름을 콘솔에 출력합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **데이터 원본 유형 지정**

이 예제는 기본 데이터로 3D 컬럼 차트를 만들고 서로 다른 데이터 원본을 사용하여 두 개의 시리즈 이름을 설정합니다. 첫 번째 이름은 문자열 리터럴을 사용하고, 두 번째는 워크시트 0의 셀 C1을 사용합니다. [DataSourceType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/datasourcetype/) 열거형은 각 이름에 대한 원본을 선택합니다. 결과는 `pres.pptx`에 저장됩니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **지원되지 않는 포함 워크북 형식 감지**

Aspose.Slides는 일부 차트에 포함될 수 있는 Excel 이진 워크북(.xlsb) 형식을 지원하지 않습니다. [IChartData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/)에서 [getEmbeddedWorkbookType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) 메서드와 [WorkbookType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/workbooktype/) 열거형을 사용하여 지원되지 않는 형식을 감지하고 해당 차트를 건너뛸 수 있습니다. 이 예제는 `sample.pptx`의 첫 번째 슬라이드에 있는 도형들을 검사하고 차트가 아닌 도형을 건너뛰며, 포함된 .xlsb 워크북이 있는 각 차트에 대해 진단 메시지를 출력합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // 지원되는 차트 워크북 데이터를 여기서 읽거나 수정합니다.
    }
} finally {
    presentation.dispose();
}
```

## **외부 워크북**

Aspose.Slides는 외부 워크북을 차트의 데이터 원본으로 사용하는 것을 지원합니다.

### **외부 워크북 만들기**

[readWorkbookStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#readWorkbookStream--) 및 [setExternalWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-)을 사용하여 포함된 차트 워크북을 파일로 내보내고 차트를 해당 외부 워크북에 연결합니다.

이 예제는 기본 데이터로 파이 차트를 만들고 워크북을 `externalWorkbook1.xlsx`에 기록한 뒤 파일을 차트 데이터 원본으로 할당하기 전에 파일 쓰기를 완료합니다. 연결된 프레젠테이션은 `externalWorkbook.pptx`에 저장됩니다.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **외부 워크북 설정**

[setExternalWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) 메서드를 사용하면 차트에 외부 워크북을 데이터 원본으로 할당할 수 있습니다. 이 메서드는 외부 워크북이 이동된 경우 경로를 업데이트하는 데에도 사용할 수 있습니다.

원격 위치나 리소스에 저장된 워크북의 데이터를 편집할 수는 없지만, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 외부 워크북에 대한 상대 경로가 제공되면 자동으로 전체 경로로 변환됩니다.

이 예제는 작업 디렉터리에 `externalWorkbook.xlsx`가 있어야 합니다. 워크시트 `Sheet1`에는 B1에 시리즈 이름, A2:A4에 범주 이름, B2:B4에 숫자 값이 포함되어야 합니다. 예제는 파이 차트를 만들고 워크북을 연결한 뒤 [setRange](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)을 사용하여 A1:B4를 하나의 시리즈와 세 개의 범주에 매핑합니다. 결과는 `Presentation_with_externalWorkbook.pptx`에 저장됩니다.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[setExternalWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-)의 `updateChartData` 매개변수는 워크북을 로드할지 여부를 제어합니다.

* `updateChartData`가 `false`인 경우, 워크북 경로만 업데이트됩니다. 차트 데이터는 대상 워크북에서 로드되거나 업데이트되지 않으므로 워크북이 없어도 됩니다.
* `updateChartData`가 `true`인 경우, 차트 데이터가 대상 워크북에서 업데이트됩니다.

다음 예제는 `updateChartData`를 `false`로 설정하여 자리표시자 URL을 할당합니다. 파이 차트의 기본 데이터를 유지하고 사용 불가능한 워크북을 로드하지 않은 상태로 프레젠테이션을 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **차트의 외부 데이터 원본 워크북 경로 가져오기**

차트에 연결된 워크북을 확인하려면 먼저 차트가 외부 데이터 원본을 사용하는지 확인합니다. 사용한다면 다음 단계에 따라 워크북 경로를 가져올 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. 0부터 시작하는 인덱스로 첫 번째 슬라이드에 접근합니다.
3. 첫 번째 도형이 차트인지 확인합니다.
4. 차트 데이터 원본 유형을 읽습니다.
5. 원본이 외부 워크북이면 경로를 읽습니다.

이 예제는 앞서 만든 `externalWorkbook.pptx`를 열고 첫 번째 슬라이드의 첫 번째 도형을 검사합니다. 만약 외부 워크북에 연결된 차트라면, 예제는 [getExternalWorkbookPath](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)을 콘솔에 출력합니다. 그런 다음 프레젠테이션의 복사본을 `Result.pptx`에 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **차트 데이터 편집**

외부 워크북의 데이터를 내부 워크북의 내용과 동일한 방식으로 편집할 수 있습니다. 외부 워크북을 로드할 수 없을 때는 예외가 발생합니다.

이 예제는 첫 번째 슬라이드의 첫 번째 도형으로 차트가 포함된 `presentation.pptx`와 접근 가능한 외부 워크북이 필요합니다. 첫 번째 시리즈의 첫 번째 데이터 포인트에 해당하는 셀 값을 100으로 설정하고 프레젠테이션을 `presentation_out.pptx`에 저장합니다. 셀 값을 편집하면 연결된 외부 XLSX 파일이 업데이트될 수 있으므로 원본을 보존하려면 복사본을 사용하십시오.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **차트 캐시에서 워크북 복구**

차트가 누락되었거나 사용 불가능한 외부 워크북을 사용하는 경우, Aspose.Slides는 프레젠테이션에 캐시된 데이터를 사용해 차트 워크북을 재구성할 수 있습니다. [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/)를 생성하고, [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)를 호출한 뒤, 프레젠테이션을 열기 전에 [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-)를 `true`로 설정합니다.

다음 Java 예제는 첫 번째 슬라이드의 첫 번째 도형이 사용 불가능한 외부 워크북을 참조하는 차트여야 하는 `presentation.pptx`를 열고, [IChart.getChartData](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichart/#getChartData--)와 [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)를 통해 복구된 데이터에 접근합니다:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // 여기에서 복구된 워크북 데이터를 읽거나 수정하십시오.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

외부 워크북이 사용 불가능하고 복구가 비활성화된 경우, Aspose.Slides는 예외를 발생시킵니다. 캐시된 차트 데이터를 사용해도 괜찮을 때만 복구를 활성화하십시오. 캐시에는 프레젠테이션이 마지막으로 업데이트된 이후 외부 워크북에 가해진 변경 사항이 포함되지 않을 수 있습니다.

## **FAQ**

**특정 차트가 외부 워크북에 연결되어 있는지 혹은 포함된 워크북에 연결되어 있는지 확인할 수 있나요?**

예. 차트는 [data source type](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#getDataSourceType--)와 [external workbook 경로](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)를 가지고 있습니다; 원본이 외부 워크북이면 전체 경로를 읽어 외부 파일이 사용되는지 확인할 수 있습니다.

**외부 워크북에 대한 상대 경로가 지원되며, 어떻게 저장되나요?**

예. 상대 경로를 지정하면 자동으로 절대 경로로 변환됩니다. 프레젠테이션은 절대 경로를 PPTX 파일에 저장하므로 워크북을 이동하면 링크를 업데이트해야 할 수 있습니다.

**네트워크 리소스/공유에 위치한 워크북을 사용할 수 있나요?**

예, 이러한 워크북을 외부 데이터 원본으로 사용할 수 있습니다. 다만 Aspose.Slides에서 원격 워크북을 직접 편집하는 것은 지원되지 않으며, 소스용으로만 사용할 수 있습니다.

**프레젠테이션을 저장할 때 Aspose.Slides가 외부 XLSX를 덮어쓰나요?**

프레젠테이션은 [외부 파일에 대한 링크](https://reference.aspose.com/slides/ko/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)를 저장합니다. 셀 기반 차트 데이터를 편집하면 연결된 로컬 XLSX 파일도 업데이트될 수 있습니다. 원본을 변경하지 않아야 한다면 워크북 복사본을 사용하십시오.

**외부 파일이 비밀번호로 보호되어 있으면 어떻게 해야 하나요?**

Aspose.Slides는 연결 시 비밀번호를 받지 않습니다. 일반적인 방법은 미리 보호를 해제하거나 복호화된 사본을 준비한 뒤([Aspose.Cells](https://reference.aspose.com/cells/java/) 등 사용) 해당 사본에 연결하는 것입니다.

**여러 차트가 동일한 외부 워크북을 참조할 수 있나요?**

예. 각 차트는 자체 링크를 저장합니다. 모두 동일한 파일을 가리키면, 해당 파일을 업데이트했을 때 다음에 데이터가 로드될 때 각 차트에 반영됩니다.