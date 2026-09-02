---
title: .NET에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/net/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 기본 속성
- 사용자 정의 속성
- 고급 속성
- 속성 관리
- 속성 수정
- 문서 메타데이터
- 메타데이터 편집
- 교정 언어
- 기본 언어
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일의 검색, 브랜드화 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides for .NET은 두 종류의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides for .NET API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides를 사용하면 [IDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/idocumentproperties/) 인터페이스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 인터페이스의 인스턴스는 [Presentation.DocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/documentproperties/) 속성을 통해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
**Application** 및 **Producer** 필드는 수정할 수 없으며, 해당 필드는 항상 "Aspose Ltd." 및 "Aspose.Slides for .NET x.x.x" 로 표시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 파일과 함께 유용한 정보를 저장할 수 있습니다. 문서 속성에는 두 가지 유형이 있습니다:

- 시스템 정의(내장) 속성
- 사용자 정의(맞춤) 속성

**Built-in** 속성에는 문서 제목, 작성자 이름, 문서 통계 등과 같이 문서에 대한 일반 정보가 포함됩니다.

**Custom** 속성은 사용자가 **Name/Value** 쌍으로 정의하며, 이름과 값 모두 사용자가 지정합니다.

Aspose.Slides for .NET를 사용하면 개발자는 내장 및 맞춤 속성 모두에 액세스하고 수정할 수 있습니다.

Microsoft PowerPoint에서는 Office 아이콘을 클릭한 다음 **File → Info → Properties**를 선택하여 문서 속성을 관리할 수 있습니다. **Advanced Properties**를 선택하면 프레젠테이션 파일의 모든 문서 속성을 관리할 수 있는 대화 상자가 표시됩니다.

**Properties** 대화 상자에는 **General**, **Summary**, **Statistics**, **Contents**, **Custom** 등 여러 탭이 있습니다.
각 탭은 PowerPoint 파일과 관련된 특정 유형의 정보를 구성할 수 있는 옵션을 제공합니다. **Custom** 탭은 사용자 정의 속성을 관리하는 데 사용됩니다.

## **내장 속성에 액세스**

이러한 속성은 [IDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/idocumentproperties/) 인터페이스를 통해 노출되며, **Creator**(작성자), **Description**, **Keywords**, **Created**(작성일), **Modified**(수정일), **Printed**(마지막 인쇄일), **LastModifiedBy**, **SharedDoc**(문서가 서로 다른 제작자 간에 공유되는지 여부), **PresentationFormat**, **Subject**, **Title** 등을 포함합니다.

```cs
using Aspose.Slides;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// 프레젠테이션과 연결된 IDocumentProperties 타입 객체에 대한 참조를 가져옵니다.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 내장 속성을 표시합니다.
Console.WriteLine("Category : " + documentProperties.Category);
Console.WriteLine("Content status : " + documentProperties.ContentStatus);
Console.WriteLine("Creation date : " + documentProperties.CreatedTime);
Console.WriteLine("Author : " + documentProperties.Author);
Console.WriteLine("Comments : " + documentProperties.Comments);
Console.WriteLine("Key words : " + documentProperties.Keywords);
Console.WriteLine("Last modified by : " + documentProperties.LastSavedBy);
Console.WriteLine("Manager : " + documentProperties.Manager);
Console.WriteLine("Modified date : " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format : " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date : " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers : " + documentProperties.SharedDoc);
Console.WriteLine("Subject : " + documentProperties.Subject);
Console.WriteLine("Title : " + documentProperties.Title);
```

## **내장 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 것은 해당 속성에 액세스하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성의 값이 업데이트됩니다. 아래 예제에서는 프레젠테이션 파일의 내장 문서 속성을 수정하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// 프레젠테이션과 연결된 IDocumentProperties 타입 객체에 대한 참조를 가져옵니다.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 내장 속성을 설정합니다.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// 프레젠테이션을 파일에 저장합니다.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **맞춤 프레젠테이션 속성 추가**

맞춤 프레젠테이션 속성을 사용하면 개발자가 프레젠테이션 파일에 추가 메타데이터 또는 특정 정보를 저장할 수 있습니다. Aspose.Slides를 사용하면 이러한 맞춤 속성을 프로그램matically 쉽게 생성하고 관리할 수 있습니다. 다음 예제에서는 프레젠테이션에 맞춤 속성을 추가하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation();

// 프레젠테이션과 연결된 IDocumentProperties 타입 객체에 대한 참조를 가져옵니다.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 사용자 정의 속성을 추가합니다.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// 프레젠테이션을 파일에 저장합니다.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **맞춤 속성에 액세스 및 수정**

Aspose.Slides를 사용하면 개발자가 기존 맞춤 속성에 액세스하고 값을 쉽게 수정할 수 있습니다. 이 기능은 정확한 메타데이터를 유지하고 사용자 입력 또는 비즈니스 로직에 기반한 동적 업데이트를 지원합니다. 아래 예제에서는 프레젠테이션 내에서 맞춤 속성 값을 검색하고 업데이트하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// 프레젠테이션과 연결된 IDocumentProperties 타입 객체에 대한 참조를 가져옵니다.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// Access and modify the custom properties.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // 사용자 정의 속성의 이름과 값을 표시합니다.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // 사용자 정의 속성의 값을 수정합니다.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// 프레젠테이션을 파일에 저장합니다.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 다루는 방법을 확인하려면 온라인 앱 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/ko/metadata)을 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **자주 묻는 질문**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성이 허용하는 경우 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 맞춤 속성을 추가하면 어떻게 되나요?**

이미 존재하는 맞춤 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. Aspose.Slides가 자동으로 속성 값을 업데이트하므로 사전에 속성을 제거하거나 확인할 필요가 없습니다.

**프레젠테이션을 전체 로드하지 않고도 속성에 액세스할 수 있나요?**

예. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationfactory/getpresentationinfo/)를 사용한 다음 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/readdocumentproperties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 생성하지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 포맷별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/net/examine-presentation/)를 참고하십시오.