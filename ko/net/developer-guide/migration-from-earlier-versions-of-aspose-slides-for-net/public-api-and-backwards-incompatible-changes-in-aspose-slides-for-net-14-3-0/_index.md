---
title: Aspose.Slides for .NET 14.3.0의 공개 API 및 이전 버전 호환성 깨지는 변경 사항
linktitle: Aspose.Slides for .NET 14.3.0
type: docs
weight: 50
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근법
- 최신 접근법
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
## **공개 API 및 이전 버전 호환성 깨지는 변경 사항**
### **Aspose.Slides.ShapeThumbnailBounds 열거형 및 Aspose.Slides.IShape.GetThumbnail() 메서드 추가**
GetThumbnail() 메서드와 GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) 메서드는 별도의 도형 썸네일을 만들 때 사용됩니다. ShapeThumbnailBounds 열거형은 가능한 도형 썸네일 경계 유형을 정의합니다.
### **Aspose.Slides.IShape에 UniqueId 속성 추가**
Aspose.Slides.IShape.UniqueId 속성은 프레젠테이션 범위 내에서 고유한 도형 식별자를 가져옵니다. 이러한 고유 식별자는 도형 사용자 정의 태그에 저장됩니다.
### **IChartCategoryLevelsManager에서 SetGroupingItem 메서드 시그니처 변경**
Signature of the IChartCategoryLevelsManager method
``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 
is obsolete now and replaced with the signature
``` csharp

 void SetGroupingItem(int level, object value);

``` 
Now calls like
``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 
must be changed to calls like
``` csharp

 .SetGroupingItem(1, "Group 1");

``` 
SetGroupingItem에 "Group 1"과 같은 값을 전달하고 IChartDataCell 형식의 값을 전달하지 않아야 합니다. 범주 수준에 대해 정의된 워크시트, 행 및 열을 사용하여 IChartDataCell을 생성하려면 몇 가지 요구 사항을 충족해야 하며, 이는 SetGroupingItem(int, object) 메서드에 캡슐화되었습니다.
### **Aspose.Slides.IBaseSlide 인터페이스에 SlideId 속성 추가**
SlideId 속성은 고유한 슬라이드 식별자를 가져옵니다.
### **ISlideShowTransition에 SoundName 속성 추가**
읽기-쓰기 문자열입니다. 전환 효과 사운드의 사람 친화적 이름을 지정합니다. 사운드 이름을 가져오거나 설정하려면 Sound 속성을 할당해야 합니다. 이 이름은 전환 사운드를 수동으로 구성할 때 PowerPoint 사용자 인터페이스에 표시됩니다. Sound 속성이 할당되지 않은 경우 PptxException이 발생할 수 있습니다.
### **ChartSeriesGroup.Type 속성의 유형 변경**
ChartSeriesGroup.Type 속성은 ChartType 열거형에서 새로운 CombinableSeriesTypesGroup 열거형으로 변경되었습니다. CombinableSeriesTypesGroup 열거형은 결합 가능한 시리즈 유형의 그룹을 나타냅니다.
### **개별 도형 썸네일 생성 지원 추가**
Aspose.Slides.ShapeThumbnailBounds

Aspose.Slides.IShape 및 Aspose.Slides.Shape에 새로운 멤버:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)