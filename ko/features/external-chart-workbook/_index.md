---
title: 외부 워크북에 차트 연결
description: 차트 데이터를 외부 워크북에 연결하고 새로 고칩니다.
type: docs
url: /ko/features/external-chart-workbook/
weight: 1070
feature_id: external-chart-workbook
feature_group: charts
translationKey: slides-feature-external-chart-workbook
feature_catalogue_version: 3
feature_guides:
- /slides/net/chart-workbook/
---
## **Overview**

외부 워크북에 차트를 지정하여 프레젠테이션에 모든 원본 데이터를 포함하지 않도록 합니다. 워크북 경로를 설정하고 해당 파일에서 차트를 업데이트할지 선택할 수 있습니다. 저장된 차트는 캐시된 표시 데이터를 포함할 수도 있습니다.

## **Usage example**

이 C# 예제는 Aspose.Slides for .NET을 사용합니다. North = 55이고 South = 40인 유효한 sales 워크북을 생성하고 이를 출력 파일 옆에 sales.xlsx로 저장합니다. 차트의 North 값을 20으로 재설정한 뒤 차트를 워크북의 절대 경로에 연결하고 새로 고칩니다: North 값이 다시 55가 됩니다. 명시적 범위는 헤더와 두 데이터 행을 포함합니다. 연결된 차트를 다시 열거나 업데이트할 때 sales.xlsx를 사용할 수 있게 유지하십시오; 프레젠테이션은 이 외부 파일을 포함하지 않습니다. 입력 파일이 필요하지 않습니다. *external-chart-workbook.pptx*와 *external-chart-workbook.png*를 저장합니다. 라이브러리는 [설치 안내](/slides/ko/net/installation/)를 따라 설치하십시오.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;
using System.IO;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 40, 40, 620, 350);
chart.HasTitle = false;
chart.ChartData.Series.Clear();
chart.ChartData.Categories.Clear();
var workbook = chart.ChartData.ChartDataWorkbook;
workbook.Clear(0);
var firstCategory = workbook.GetCell(0, 1, 0, "North");
var secondCategory = workbook.GetCell(0, 2, 0, "South");
chart.ChartData.Categories.Add(firstCategory);
chart.ChartData.Categories.Add(secondCategory);
var nameCell = workbook.GetCell(0, 0, 1, "Sales");
var series = chart.ChartData.Series.Add(nameCell, chart.Type);
var firstValue = workbook.GetCell(0, 1, 1, 20);
var secondValue = workbook.GetCell(0, 2, 1, 40);
series.DataPoints.AddDataPointForBarSeries(firstValue);
series.DataPoints.AddDataPointForBarSeries(secondValue);
firstValue.Value = 55;
var workbookPath = Path.GetFullPath("sales.xlsx");
using (var workbookStream = chart.ChartData.ReadWorkbookStream())
using (var workbookFile = File.Create(workbookPath))
{
    workbookStream.CopyTo(workbookFile);
}
firstValue.Value = 20;
chart.ChartData.SetExternalWorkbook(workbookPath, true);
chart.ChartData.SetRange("Sheet1!$A$1:$B$3");
presentation.Save("external-chart-workbook.pptx", SaveFormat.Pptx);
using var image = presentation.Slides[0].GetImage(1f, 1f);
image.Save("external-chart-workbook.png", ImageFormat.Png);
```

## **FAQ**

### **Can I read every cached value when the linked file is missing?**

Aspose.Slides for .NET 26.11은 [저장된 차트 값을 직접 읽기](/slides/ko/net/chart-workbook/#read-cached-chart-values-without-a-workbook) 기능을 제공하므로 링크된 워크북을 열지 않고도 차트 값을 읽을 수 있습니다. 여기에는 일반 값, X/Y 값, 버블 크기 및 해당 캐시가 존재하는 경우 카테고리 값이 포함됩니다. 캐시된 데이터는 없거나 오래될 수 있으며 완전한 워크북은 아닙니다. 소스에서 새로 고치려면 사용 가능한 지원 워크북이 여전히 필요합니다. 다른 SDK 및 버전에 대해서는 해당 차트 가이드를 확인하십시오.

### **What happens if the external workbook is moved?**

차트의 외부 워크북 경로를 새 위치로 업데이트하고 프레젠테이션이 처리되는 모든 환경에서 해당 파일을 사용할 수 있게 하십시오. 캐시된 데이터에만 의존하여 전체 데이터 액세스 작업을 수행하지 마십시오.

### **Can I choose whether to refresh cached chart data when linking?**

예. 링크를 설정할 때 차트 데이터를 업데이트할지를 선택할 수 있습니다. 새로 고침을 수행하려면 사용 가능한 지원 워크북이 필요하며, 새로 고침을 건너뛰면 파일에서 새로운 값을 읽지 않고 링크만 기록됩니다.

## **Guides**

- [Manage Chart Workbooks in Presentations in .NET](/slides/ko/net/chart-workbook/)

Related feature: [데이터로 편집 가능한 차트 채우기](/slides/ko/features/chart-data-binding/).