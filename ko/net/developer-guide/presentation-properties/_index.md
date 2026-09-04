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
- 내장 속성
- 맞춤 속성
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
description: "Aspose.Slides for .NET에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일의 검색, 브랜딩 및 워크플로를 효율화합니다."
---
## **소개**

Aspose.Slides for .NET은 두 가지 유형의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides for .NET API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides는 [IDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/idocumentproperties/) 인터페이스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 인터페이스의 인스턴스는 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/documentproperties/)에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
**Application** 및 **Producer** 필드는 수정할 수 없습니다. 이 필드는 항상 "Aspose Ltd."와 "Aspose.Slides for .NET x.x.x"를 표시합니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 파일과 함께 유용한 정보를 저장할 수 있습니다. 문서 속성에는 두 가지 유형이 있습니다:

- 시스템 정의(내장) 속성
- 사용자 정의(맞춤) 속성

**Built-in** 속성은 문서 제목, 작성자 이름, 문서 통계 등 문서에 대한 일반 정보를 포함합니다.

**Custom** 속성은 사용자가 **이름/값** 쌍으로 정의하며, 이름과 값 모두 사용자가 지정합니다.

Aspose.Slides for .NET을 사용하면 개발자가 내장 속성과 맞춤 속성 모두에 액세스하고 수정할 수 있습니다.

Microsoft PowerPoint에서는 Office 아이콘을 클릭한 다음 **File → Info → Properties**를 선택하여 문서 속성을 관리할 수 있습니다. **Advanced Properties**를 선택하면 프레젠테이션 파일의 모든 문서 속성을 관리할 수 있는 대화 상자가 표시됩니다.

**Properties** 대화 상자에는 **General**, **Summary**, **Statistics**, **Contents**, **Custom**과 같은 여러 탭이 있습니다. 각 탭은 PowerPoint 파일과 관련된 특정 유형의 정보를 구성하는 옵션을 제공합니다. **Custom** 탭은 사용자 정의 속성을 관리하는 데 사용됩니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. 프레젠테이션이 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/)를 `false`로 설정하여 암호화된 경우, 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/onlyloaddocumentproperties/)를 `true`로 설정하고 열기 비밀번호 없이 공개 메타데이터를 읽을 수 있습니다.

`OnlyLoadDocumentProperties`는 Aspose.Slides가 로드하는 항목을 제어하며, 암호 해독을 수행하지 않습니다. 속성이 암호화에 포함된 경우 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

다음 예제는 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/)를 통해 로드 모드를 확인한 후 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentation/documentproperties/)를 사용해 내장 속성을 읽습니다:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var properties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + properties.Author);
    Console.WriteLine("Title: " + properties.Title);
    Console.WriteLine("Keywords: " + properties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 개체에 접근할 수 없습니다. 애플리케이션은 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 `IsOnlyDocumentPropertiesLoaded`를 확인해야 합니다.

{{% alert color="warning" title="Security" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 맞춤 값 등을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 접근해야 하는 특정 요구 사항이 있는 경우에만 공개 상태로 두세요.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우 `OnlyLoadDocumentProperties`로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터 전용 개체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부의 해당 데이터와 일치해야 하기 때문입니다. 따라서 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

다음 예제는 [LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/)를 사용해 프레젠테이션을 연 후 공개 내장 속성을 업데이트하고 결과를 저장합니다. 그런 다음 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/isencrypted/)를 사용해 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새로운 값을 검증합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

{
    var loadOptions = new LoadOptions { Password = "open_password" };
    using var presentation = new Presentation(inputPath, loadOptions);

    presentation.DocumentProperties.Title = "Updated Product Roadmap";
    presentation.DocumentProperties.Keywords = "roadmap, planning, indexed";
    presentation.Save(outputPath, SaveFormat.Pptx);
}

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(outputPath);
Console.WriteLine("The presentation is encrypted: " + presentationInfo.IsEncrypted);

var metadataLoadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var metadataPresentation = new Presentation(outputPath, metadataLoadOptions);

if (metadataPresentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    Console.WriteLine("Title: " + metadataPresentation.DocumentProperties.Title);
    Console.WriteLine("Keywords: " + metadataPresentation.DocumentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **내장 속성 접근**

[IDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/idocumentproperties/) 인터페이스를 통해 노출되는 이러한 속성에는 **Creator**(작성자), **Description**, **Keywords**, **Created**(생성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **SharedDoc**(문서가 여러 제작자 간에 공유되는지 여부), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

```cs
using Aspose.Slides;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("AccessBuiltInProperties.pptx");

// 프레젠테이션과 연결된 IDocumentProperties 유형 객체에 대한 참조를 가져옵니다.
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

프레젠테이션 파일의 내장 속성을 수정하는 것은 접근하는 것만큼 간단합니다. 원하는 속성에 문자열 값을 할당하면 해당 속성의 값이 업데이트됩니다. 아래 예제에서는 프레젠테이션 파일의 내장 문서 속성을 수정하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("ModifyBuiltInProperties.pptx");

// 프레젠테이션과 연결된 IDocumentProperties 유형 객체에 대한 참조를 가져옵니다.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 내장 속성을 설정합니다.
documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

// 프레젠테이션을 파일로 저장합니다.
presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **맞춤 프레젠테이션 속성 추가**

맞춤 프레젠테이션 속성을 통해 개발자는 프레젠테이션 파일에 추가 메타데이터 또는 특정 정보를 저장할 수 있습니다. Aspose.Slides를 사용하면 이러한 맞춤 속성을 프로그래밍 방식으로 쉽게 생성하고 관리할 수 있습니다. 다음 예제에서는 프레젠테이션에 맞춤 속성을 추가하는 방법을 보여줍니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation();

// 프레젠테이션과 연결된 IDocumentProperties 유형 객체에 대한 참조를 가져옵니다.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 맞춤 속성을 추가합니다.
documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

// 프레젠테이션을 파일로 저장합니다.
presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **맞춤 속성 접근 및 수정**

Aspose.Slides는 개발자가 기존 맞춤 속성에 접근하고 값을 쉽게 수정할 수 있도록 지원합니다. 이 기능은 정확한 메타데이터를 유지하고 사용자 입력이나 비즈니스 로직에 따라 동적으로 업데이트하는 데 도움이 됩니다. 아래 예제에서는 프레젠테이션 내 맞춤 속성 값을 검색하고 업데이트하는 방법을 설명합니다.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
using Presentation presentation = new Presentation("AccessAndModifyProperties.pptx");

// 프레젠테이션과 연결된 IDocumentProperties 유형 객체에 대한 참조를 가져옵니다.
IDocumentProperties documentProperties = presentation.DocumentProperties;

// 맞춤 속성에 접근하고 수정합니다.
for (int i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    string propertyName = documentProperties.GetCustomPropertyName(i);
    object propertyValue = documentProperties[propertyName];

    // 맞춤 속성의 이름과 값을 표시합니다.
    Console.WriteLine("Custom property name : " + propertyName);
    Console.WriteLine("Custom property value : " + propertyValue);

    // 맞춤 속성의 값을 수정합니다.
    documentProperties[propertyName] = "New Value " + (i + 1);
}

// 프레젠테이션을 파일로 저장합니다.
presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 작업하는 방법을 확인하려면 온라인 앱 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/ko/metadata)를 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거할 수 있나요?**

내장 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만, 특정 속성이 허용한다면 값을 변경하거나 빈 문자열로 설정할 수 있습니다.

**이미 존재하는 맞춤 속성을 추가하면 어떻게 되나요?**

이미 존재하는 맞춤 속성을 추가하면 기존 값이 새 값으로 덮어쓰기 됩니다. 속성을 미리 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 전체 로드하지 않고 속성에 접근할 수 있나요?**

예. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/ko/net/aspose.slides/presentationfactory/getpresentationinfo/)를 사용한 뒤 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/ko/net/aspose.slides/ipresentationinfo/readdocumentproperties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 만들지 않고 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/net/examine-presentation/)를 참고하세요.

**열기 비밀번호 없이 암호화된 프레젠테이션의 공개 속성을 읽을 수 있나요?**

예. 프레젠테이션이 `EncryptDocumentProperties`를 `false`로 설정하여 암호화되었고, `OnlyLoadDocumentProperties`를 `true`로 로드한 경우 가능합니다.

**문서 속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니오. 공개 속성 및 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호로 전체 프레젠테이션을 로드해야 합니다.