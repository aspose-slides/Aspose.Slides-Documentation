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
- 사용자 지정 속성
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
description: "Aspose.Slides for .NET에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일의 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides for .NET은 **내장** 및 **사용자 지정** 문서 속성을 지원합니다. 이러한 속성을 사용하여 작성자, 제목 및 사용자 정의 값과 같은 프레젠테이션 메타데이터를 읽고 업데이트할 수 있습니다.

Aspose.Slides는 [IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 인터페이스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 인터페이스의 인스턴스는 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/)에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Aspose.Slides는 프레젠테이션을 저장할 때 애플리케이션 및 제작자 메타데이터를 관리합니다. 이 필드들은 출력물을 만든 소프트웨어를 식별합니다.
{{% /alert %}}

## **프레젠테이션 속성 관리**

문서 속성은 프레젠테이션 콘텐츠와 함께 설명 정보를 저장합니다. 두 가지 카테고리로 구분됩니다:

- **내장 속성**은 제목, 작성자 및 문서 통계와 같은 표준 메타데이터를 포함합니다.
- **사용자 지정 속성**은 사용자 정의 이름/값 쌍을 저장합니다.

Aspose.Slides for .NET은 두 카테고리 모두에 대한 액세스를 제공합니다. PowerPoint에서 **파일 → 정보 → 속성 → 고급 속성**을 선택하면 문서 메타데이터를 확인할 수 있습니다. 대화 상자는 정보를 **요약**, **통계**, **목차**, **사용자 지정**과 같은 탭으로 구분합니다. **사용자 지정** 탭을 사용하여 사용자 정의 속성을 관리합니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. 프레젠테이션이 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 를 `false` 로 설정하여 암호화된 경우, 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 를 `true` 로 설정하여 열기 비밀번호 없이 공개 메타데이터를 읽을 수 있습니다.

[LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 은 Aspose.Slides가 로드하는 항목을 제어하며, 어떠한 복호화도 수행하지 않습니다. 속성이 암호화에 포함된 경우 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

예제는 문서 속성이 공개된 암호화된 프레젠테이션이 필요합니다. 로드 모드를 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 로 확인하고, 이후 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 를 통해 내장 속성을 읽습니다:

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { OnlyLoadDocumentProperties = true };
using var presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);

if (presentation.ProtectionManager.IsOnlyDocumentPropertiesLoaded)
{
    var documentProperties = presentation.DocumentProperties;

    Console.WriteLine("Author: " + documentProperties.Author);
    Console.WriteLine("Title: " + documentProperties.Title);
    Console.WriteLine("Keywords: " + documentProperties.Keywords);
}
else
{
    Console.WriteLine("The presentation was not loaded in document-properties-only mode.");
}
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [IProtectionManager.IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/isonlydocumentpropertiesloaded/) 를 확인해야 합니다.

{{% alert color="warning" title="Security" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 사용자 지정 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 색인, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 접근해야 하는 특정 요구가 있는 경우에만 공개 상태로 두세요.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우, [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없으며, 공개 속성은 암호화된 프레젠테이션 내부의 해당 데이터와 일관성을 유지해야 합니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

예제는 공개 문서 속성을 가진 암호화된 PPTX 프레젠테이션과 알려진 열기 비밀번호가 필요합니다. [LoadOptions.Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 로 전체 프레젠테이션을 열고, 공개 내장 속성을 업데이트한 뒤 결과를 저장합니다. 이후 [IPresentationInfo.IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/isencrypted/) 를 사용하여 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새로운 값을 검증합니다:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputPath = "public-properties-encrypted.pptx";
const string outputPath = "updated-public-properties-encrypted.pptx";

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation(inputPath, loadOptions);

var documentProperties = presentation.DocumentProperties;
documentProperties.Title = "Updated Product Roadmap";
documentProperties.Keywords = "roadmap, planning, indexed";

presentation.Save(outputPath, SaveFormat.Pptx);

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

## **내장 속성 액세스**

[IDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/) 인터페이스는 [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [CreatedTime](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/createdtime/) 등 형식화된 속성을 통해 내장 메타데이터를 노출합니다. 이 예제는 기존 프레젠테이션을 열고 저장된 메타데이터를 콘솔에 출력합니다. 값은 입력 프레젠테이션에 따라 다르며 일부 필드는 비어 있을 수 있습니다.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AccessBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

Console.WriteLine("Category: " + documentProperties.Category);
Console.WriteLine("Content status: " + documentProperties.ContentStatus);
Console.WriteLine("Creation date: " + documentProperties.CreatedTime);
Console.WriteLine("Author: " + documentProperties.Author);
Console.WriteLine("Comments: " + documentProperties.Comments);
Console.WriteLine("Keywords: " + documentProperties.Keywords);
Console.WriteLine("Last modified by: " + documentProperties.LastSavedBy);
Console.WriteLine("Manager: " + documentProperties.Manager);
Console.WriteLine("Modified date: " + documentProperties.LastSavedTime);
Console.WriteLine("Presentation format: " + documentProperties.PresentationFormat);
Console.WriteLine("Last print date: " + documentProperties.LastPrinted);
Console.WriteLine("Is shared between producers: " + documentProperties.SharedDoc);
Console.WriteLine("Subject: " + documentProperties.Subject);
Console.WriteLine("Title: " + documentProperties.Title);
```

## **내장 속성 수정**

내장 메타데이터를 업데이트하려면 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/documentproperties/) 에서 노출되는 쓰기 가능한 속성에 값을 할당합니다. 이 예제는 기존 프레젠테이션을 열고, [Author](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/author/), [Title](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/title/), [Subject](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/subject/), [Comments](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/comments/), [Manager](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/manager/) 를 설정한 뒤, [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 으로 업데이트된 프레젠테이션을 저장합니다. 저장된 PPTX에는 새로운 메타데이터가 포함됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("ModifyBuiltInProperties.pptx");

var documentProperties = presentation.DocumentProperties;

documentProperties.Author = "Aspose.Slides for .NET";
documentProperties.Title = "Manage PowerPoint Presentation Properties";
documentProperties.Subject = "Modify Built-in Properties";
documentProperties.Comments = "Aspose description";
documentProperties.Manager = "Aspose manager";

presentation.Save("DocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **하이퍼링크 기반 관리**

[IDocumentProperties.HyperlinkBase](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/hyperlinkbase/) 은 상대 하이퍼링크용 문서 수준의 기본 주소를 저장합니다. 프레젠테이션 및 연결된 파일을 다른 위치로 이동할 때 유용합니다. 이는 개별 하이퍼링크의 [IHyperlink.ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) 와는 별개이며, 기본 주소를 변경해도 저장된 링크 주소가 다시 쓰이거나 절대 대상이 변경되지 않습니다.

예제는 `target.html` 와 같은 상대 링크와 `https://example.org/absolute.html` 와 같은 절대 링크를 모두 포함하는 프레젠테이션이 필요합니다. 기존 기본 주소를 읽은 뒤 새로운 기본 주소를 할당하고, 값 확인을 위해 프레젠테이션을 저장 후 다시 엽니다. 이후 `string.Empty` 로 기본 주소를 지우고 별도 저장 파일에서 빈 값을 확인합니다. 예제 기본 주소를 실제 연결 파일 위치에 맞게 교체하십시오.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("hyperlinks.pptx");
Console.WriteLine("Original base: " + presentation.DocumentProperties.HyperlinkBase);

const string newBase = "https://example.com/new/";
presentation.DocumentProperties.HyperlinkBase = newBase;
presentation.Save("hyperlinks-updated.pptx", SaveFormat.Pptx);

using var updatedPresentation = new Presentation("hyperlinks-updated.pptx");
Console.WriteLine("Base preserved: " + (updatedPresentation.DocumentProperties.HyperlinkBase == newBase));

updatedPresentation.DocumentProperties.HyperlinkBase = string.Empty;
updatedPresentation.Save("hyperlinks-cleared.pptx", SaveFormat.Pptx);

using var clearedPresentation = new Presentation("hyperlinks-cleared.pptx");
Console.WriteLine("Base cleared: " + (clearedPresentation.DocumentProperties.HyperlinkBase == string.Empty));
```

두 검증 메시지는 `True` 를 출력해야 합니다. 기본 주소를 지워도 개별 하이퍼링크 주소는 그대로 유지됩니다.

`target.pptx` 에 대한 상대 링크는 기본 주소가 `old` 폴더를 가리킬 때 `old/target.pptx` 를 열었습니다. 기본 주소를 `new` 폴더로 변경하고 저장 후 프레젠테이션을 다시 열면 동일한 링크가 `new/target.pptx` 를 엽니다. 절대 링크는 동일한 파일을 계속 엽니다. 프레젠테이션을 이동하거나 기본 주소를 변경하기 전후에 PowerPoint에서 상대 링크를 테스트하십시오.

## **사용자 지정 프레젠테이션 속성 추가**

사용자 지정 속성은 해당하는 내장 필드가 없는 메타데이터를 저장합니다. [IDocumentProperties 인덱서](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/)를 사용하면 속성 이름으로 값을 할당할 수 있습니다. 이 예제는 프레젠테이션을 생성하고 두 개의 텍스트 값과 정수 버전 값을 추가한 뒤, [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) 으로 프레젠테이션을 저장합니다. 기존 이름에 값을 할당하면 해당 속성의 값이 교체됩니다.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var documentProperties = presentation.DocumentProperties;

documentProperties["Reviewed by"] = "John Smith";
documentProperties["Confidentiality level"] = "Internal";
documentProperties["Document version"] = 2;

presentation.Save("CustomDocumentProperties_output.pptx", SaveFormat.Pptx);
```

## **사용자 지정 속성 액세스 및 수정**

이 예제는 사용자 지정 속성을 포함한 프레젠테이션을 열고 [CountOfCustomProperties](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/countofcustomproperties/) 로 속성을 반복합니다. [GetCustomPropertyName](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/getcustompropertyname/) 은 0부터 시작하는 인덱스를 받아 [IDocumentProperties 인덱서](https://reference.aspose.com/slides/net/aspose.slides/idocumentproperties/item/) 에 사용되는 이름을 반환합니다. 예제는 각 원래 이름과 값을 출력하고, 원래 유형에 관계없이 모든 값을 번호가 붙은 문자열로 교체한 뒤 변경 사항을 저장합니다. 사용자 지정 속성이 없으면 루프는 아무 변화도 일으키지 않습니다.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AccessAndModifyProperties.pptx");

var documentProperties = presentation.DocumentProperties;

for (var i = 0; i < documentProperties.CountOfCustomProperties; i++)
{
    var propertyName = documentProperties.GetCustomPropertyName(i);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine("Custom property name: " + propertyName);
    Console.WriteLine("Custom property value: " + propertyValue);

    documentProperties[propertyName] = "New Value " + (i + 1);
}

presentation.Save("CustomProperties_output.pptx", SaveFormat.Pptx);
```

## **실시간 예제**

온라인 앱인 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 를 사용해 Aspose.Slides API로 문서 속성을 작업하는 방법을 확인해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성이 허용하는 경우 값을 변경하거나 빈 문자열로 설정할 수 있습니다.

**이미 존재하는 사용자 지정 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 지정 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. Aspose.Slides가 자동으로 속성 값을 업데이트하므로 미리 제거하거나 확인할 필요가 없습니다.

**프레젠테이션을 전체 로드하지 않고 속성에 액세스할 수 있나요?**

네. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) 를 사용한 뒤 [IPresentationInfo.ReadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/readdocumentproperties/) 를 호출하면 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 인스턴스를 만들지 않고 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/net/examine-presentation/) 를 참고하십시오.

**암호화된 프레젠테이션의 공개 속성을 열기 비밀번호 없이 읽을 수 있나요?**

네. 프레젠테이션이 [IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/) 를 `false` 로 설정하여 암호화되었고, [LoadOptions.OnlyLoadDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 를 `true` 로 로드해야 합니다.

**문서 속성 전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니요. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호를 사용해 전체 프레젠테이션을 로드해야 합니다.