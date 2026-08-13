---
title: Aspose.Slides for Java 15.5.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 15.5.0
type: docs
weight: 130
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="info" %}} 
이 페이지에서는 Aspose.Slides for Java 15.5.0 API와 함께 도입된 모든 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/) 클래스, 메서드, 속성 등과 새로운 제한 사항 및 기타 [changes](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-5-0/)를 나열합니다.
{{% /alert %}} 
## **공개 API 변경 사항**
### **CommonSlideViewProperties 클래스와 ICommonSlideViewProperties 인터페이스가 추가되었습니다**
com.aspose.slides.CommonSlideViewProperties 클래스(및 해당 인터페이스 com.aspose.slides.ICommonSlideViewProperties)는 공통 슬라이드 보기 속성(현재는 보기 확대 옵션)을 나타냅니다.
### **IAxis.getLabelOffset(), setLabelOffset(int) 메서드가 추가되었습니다**
IAxis.getLabelOffset(), setLabelOffset(int) 메서드는 레이블과 축 사이의 거리를 가져오고 지정할 수 있게 합니다. 카테고리 축이나 날짜 축에 적용됩니다.
### **IChartTextBlockFormat.getAutofitType(), setAutofitType(byte) 메서드가 추가되었습니다**
com.aspose.slides.IChartTextBlockFormat 인터페이스에 getAutofitType(), setAutofitType(/**TextAutofitType**/byte) 메서드가 추가되었습니다.
이 값을 변경하면 차트의 특정 부분인 DataLabel 및 DataLabelFormat에만 영향을 미칠 수 있습니다(PowerPoint 2013에서는 전체 지원; PowerPoint 2007에서는 렌더링에 효과가 없습니다).
### **IChartTextBlockFormat.getWrapText(), setWrapText(byte) 메서드가 추가되었습니다**
com.aspose.slides.IChartTextBlockFormat 인터페이스에 getWrapText(), setWrapText(/**NullableBool**/byte) 메서드가 추가되었습니다.
이 값을 변경하면 차트의 특정 부분인 DataLabel 및 DataLabelFormat에만 영향을 미칠 수 있습니다(PowerPoint 2007/2013에서 전체 지원).
### **IChartTextBlockFormat에 여백을 관리하는 메서드가 추가되었습니다**
com.aspose.slides.IChartTextBlockFormat 인터페이스에 getMarginLeft(), setMarginLeft(double), getMarginRight(), setMarginRight(double), getMarginTop(), setMarginTop(double), getMarginBottom() 및 setMarginBottom(double) 메서드가 추가되었습니다.
이 값을 변경하면 차트의 특정 부분인 DataLabel 및 DataLabelFormat에만 영향을 미칠 수 있습니다(PowerPoint 2013에서는 전체 지원; PowerPoint 2007에서는 렌더링에 효과가 없습니다).
### **ViewProperties.getNotesViewProperties() 메서드가 추가되었습니다**
com.aspose.slides.ViewProperties.getNotesViewProperties() 속성이 추가되었습니다. 이는 노트 보기 모드와 연결된 공통 보기 속성을 가져옵니다.
### **ViewProperties.getSlideViewProperties() 메서드가 추가되었습니다**
com.aspose.slides.ViewProperties.getSlideViewProperties() 메서드가 추가되었습니다. 이는 슬라이드 보기 모드와 연결된 공통 보기 속성을 가져옵니다.