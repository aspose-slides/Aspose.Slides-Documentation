---
title: Aspose.Slides for .NET 14.2.0의 공용 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 14.2.0
type: docs
weight: 40
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-2-0/
keywords:
- 마이그레이션
- 레거시 코드
- 현대 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공용 API 업데이트 및 중단되는 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
## **공용 API 및 이전 버전과 호환되지 않는 변경 사항**
{{% alert color="primary" %}} 

Aspose.Slides for .NET 14.2.0 API에 몇 가지 변경 사항을 적용했습니다. 일부 속성과 메서드가 제거되었으며 일부는 다른 네임스페이스로 이동되었습니다.

{{% /alert %}} 
### **Aspose.Slides.IPresentation.Write(…) 메서드 제거**
이 메서드들은 Presentation 객체를 PPTX 형식 파일에만 저장했습니다. 새로운 API에서는 Presentation 클래스가 모든 형식을 지원하도록 설계되었습니다. Presentation.Save(…) 메서드를 사용하여 Presentation 객체를 지원되는 모든 형식으로 저장할 수 있습니다.
### **테마 스타일 관련 클래스가 Aspose.Slides.Theme 네임스페이스로 이동**
다음 클래스들이 Aspose.Slides 네임스페이스에서 Aspose.Slides.Theme 네임스페이스로 이동되었습니다.

- Types ColorScheme
- EffectStyle
- EffectStyleCollection
- EffectStyleCollectionEffectiveData
- ExtraColorSchemeCollection
- ExtraColorSchemeCollection
- ExtraColorScheme
- FillFormatCollection
- FillFormatCollectionEffectiveData
- FontScheme
- FontSchemeEffectiveData
- FormatScheme
- IColorScheme
- IEffectStyle
- IEffectStyleCollection
- IEffectStyleCollectionEffectiveData
- IEffectStyleEffectiveData
- IExtraColorScheme
- IExtraColorSchemeCollection
- IFillFormatCollection
- IFillFormatCollectionEffectiveData
- IFontScheme
- IFontSchemeEffectiveData
- IFormatScheme
- ILineFormatCollection
- ILineFormatCollectionEffectiveData
### **Aspose.Slides for .NET 8.X.0에서의 변경 사항**
Aspose.Slides for .NET 8.4 기능이 Aspose.Slides for .NET 14.2.0에 추가되었습니다.