---
title: .NET에서 프레젠테이션의 태그 및 사용자 정의 데이터 관리
linktitle: 태그 및 사용자 정의 데이터
type: docs
weight: 300
url: /ko/net/managing-tags-and-custom-data/
keywords:
- 문서 속성
- 태그
- 사용자 정의 데이터
- 태그 추가
- 키-값 쌍
- PowerPoint
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 태그 및 사용자 정의 데이터를 추가, 읽기, 업데이트 및 제거하는 방법을 배우고, PowerPoint와 OpenDocument 프레젠테이션 예제를 확인하십시오."
---
## **개요**

이 문서에서는 Aspose.Slides가 PowerPoint 프레젠테이션에서 태그와 사용자 정의 데이터를 어떻게 처리하는지 설명합니다. 데이터가 PPTX 파일에 저장되는 방식을 간략히 소개하고, 프레젠테이션별 데이터가 태그 및 사용자 정의 XML 파트로 존재할 수 있음을 언급하며, 태그를 키‑값 문자열 쌍으로 정의합니다.

또한 태그 값을 읽는 방법과 프레젠테이션, 개별 슬라이드 또는 도형에 태그를 추가하는 방법을 보여줍니다. 추가로 모든 태그를 삭제하기, 이름으로 태그 제거하기, 태그 이름 목록을 가져오기와 같은 일반적인 태그 관리 작업을 다룹니다.

## **프레젠테이션 파일에서 데이터 저장**

PPTX 파일—.pptx 확장자를 가진 항목—은 PresentationML 형식으로 저장되며, 이는 Office Open XML 사양의 일부입니다. Office Open XML 형식은 프레젠테이션에 포함된 데이터 구조를 정의합니다.

슬라이드는 프레젠테이션 요소 중 하나이며, 슬라이드 파트는 단일 슬라이드의 내용을 포함합니다. 슬라이드 파트는 ISO/IEC 29500에 정의된 사용자 정의 태그와 같은 다수의 파트와 명시적 관계를 가질 수 있습니다.

프레젠테이션에 특정한 사용자 정의 데이터 또는 사용자는 태그([ITagCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/itagcollection))와 CustomXmlParts([ICustomXmlPartCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/icustomxmlpartcollection))로 존재할 수 있습니다.

{{% alert color="primary" %}} 
태그는 본질적으로 문자열‑키 쌍 값입니다. 
{{% /alert %}} 

## **태그 값 가져오기**

슬라이드에서 태그는 IDocumentProperties.Keywords 속성과 대응됩니다. 다음 샘플 코드는 Aspose.Slides for .NET을 사용하여 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation)에서 태그 값을 가져오는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   string keywords = pres.DocumentProperties.Keywords;
}
```

## **프레젠테이션에 태그 추가**

Aspose.Slides를 사용하면 프레젠테이션에 태그를 추가할 수 있습니다. 태그는 일반적으로 두 개의 항목으로 구성됩니다:

- 사용자 정의 속성의 이름 - `MyTag` 
- 사용자 정의 속성의 값 - `My Tag Value`

특정 규칙이나 속성을 기반으로 프레젠테이션을 분류해야 하는 경우, 태그를 추가하면 도움이 됩니다. 예를 들어, 북미 국가의 모든 프레젠테이션을 함께 묶고 싶다면 “North American” 태그를 만든 뒤 해당 국가(미국, 멕시코, 캐나다)를 값으로 지정할 수 있습니다.

다음 샘플 코드는 Aspose.Slides for .NET을 사용하여 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation)에 태그를 추가하는 방법을 보여줍니다:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   ITagCollection tags = pres.CustomData.Tags;
   pres.CustomData.Tags["MyTag"] = "My Tag Value";
}
```

태그는 [Slide](https://reference.aspose.com/slides/ko/net/aspose.slides/slide)에도 설정할 수 있습니다:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    slide.CustomData.Tags["tag"] = "value";
}
```

또는 개별 [Shape](https://reference.aspose.com/slides/ko/net/aspose.slides/shape)에도 적용할 수 있습니다:

```csharp
using(Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 50);
    shape.TextFrame.Text = "My text";
    shape.CustomData.Tags["tag"] = "value";
}
```

### **제한 사항**

`CustomData.Tags` 컬렉션을 통해 추가된 태그는 PowerPoint 파일 내부에만 저장됩니다. 프레젠테이션을 PDF로 내보낼 때 이러한 태그는 PDF 태그 구조로 **전송되지 않습니다**. 따라서 태그로 지정된 사용자 정의 식별자를 PDF에서 검색할 수 없습니다.

**우회 방법**: 객체의 **Alt Text**(예: `shape.AlternativeText = "MyId"`)에 사용자 정의 식별자를 저장할 수 있습니다. PDF로 내보낸 후 Alt Text가 PDF 태그 구조에 나타날 수 있습니다.

## **FAQ**

**프레젠테이션, 슬라이드 또는 도형에서 모든 태그를 한 번에 제거할 수 있나요?**

예. [tag collection](https://reference.aspose.com/slides/ko/net/aspose.slides/tagcollection/)은 [clear](https://reference.aspose.com/slides/ko/net/aspose.slides/tagcollection/clear/) 작업을 지원하며, 이를 사용하면 모든 키‑값 쌍을 한 번에 삭제할 수 있습니다.

**전체 컬렉션을 반복하지 않고 이름으로 단일 태그를 삭제하려면 어떻게 해야 하나요?**

[TagCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/tagcollection/)에서 [Remove(name)](https://reference.aspose.com/slides/ko/net/aspose.slides/tagcollection/remove/) 메서드를 사용하면 키로 태그를 삭제할 수 있습니다.

**분석 또는 필터링을 위해 모든 태그 이름 목록을 가져오려면 어떻게 해야 하나요?**

[tag collection](https://reference.aspose.com/slides/ko/net/aspose.slides/tagcollection/)에서 [GetNamesOfTags](https://reference.aspose.com/slides/ko/net/aspose.slides/tagcollection/getnamesoftags/)을 사용하면 모든 태그 이름이 포함된 배열을 반환합니다.