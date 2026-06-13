---
title: JavaScript에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/nodejs-java/presentation-properties/
keywords:
- PowerPoint 속성
- 프레젠테이션 속성
- 문서 속성
- 내장 속성
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일의 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides는 두 가지 유형의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides를 사용하면 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 클래스의 인스턴스는 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#getDocumentProperties) 메서드에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="primary" %}} 

주의: **Application** 및 **Producer** 필드에 값을 설정할 수 없습니다. 해당 필드에는 Aspose Ltd.와 Aspose.Slides for Node.js via Java x.x.x 버전 정보가 표시됩니다.

{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 일부 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성에는 다음과 같이 두 종류가 있습니다

- 시스템 정의 (Built-in) 속성
- 사용자 정의 (Custom) 속성

**Built-in** 속성은 문서 제목, 저자 이름, 문서 통계 등과 같은 일반 정보를 포함합니다. **Custom** 속성은 사용자가 **Name/Value** 쌍으로 정의한 것으로, 이름과 값 모두 사용자가 지정합니다. Aspose.Slides for Node.js via Java를 사용하면 개발자는 Built-in 속성과 Custom 속성의 값을 접근하고 수정할 수 있습니다.

## **PowerPoint의 문서 속성**

Microsoft PowerPoint 2007에서는 프레젠테이션 파일의 문서 속성을 관리할 수 있습니다. 아래와 같이 Office 아이콘을 클릭한 다음 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하면 됩니다:

|**Advanced Properties 메뉴 항목 선택**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** 메뉴 항목을 선택하면 아래 그림과 같이 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다:

|**속성 대화 상자**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
위 **Properties Dialog**에서 **General**, **Summary**, **Statistics**, **Contents**, **Custom**과 같은 여러 탭 페이지를 확인할 수 있습니다. 이러한 탭은 PowerPoint 파일과 관련된 다양한 정보를 구성하도록 허용합니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

Aspose.Slides for Node.js via Java를 사용한 문서 속성 작업

앞서 설명한 바와 같이 Aspose.Slides for Node.js via Java는 **Built-in** 및 **Custom** 두 종류의 문서 속성을 지원합니다. 따라서 개발자는 Aspose.Slides for Node.js via Java API를 사용하여 두 종류의 속성에 접근할 수 있습니다. Aspose.Slides for Node.js via Java는 프레젠테이션 파일에 연결된 문서 속성을 나타내는 클래스 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties) 를 제공하며, 이는 **Presentation.DocumentProperties** 속성을 통해 접근합니다.

개발자는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation) 객체가 제공하는 **DocumentProperties** 속성을 사용하여 아래와 같이 프레젠테이션 파일의 문서 속성에 접근할 수 있습니다:

## **Built-in 속성 접근**

이러한 속성은 [DocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties) 객체를 통해 다음을 포함합니다: **Creator** (작성자), **Description**, **Keywords**, **Created** (생성 날짜), **Modified** (수정 날짜), **Printed** (마지막 인쇄 날짜), **LastModifiedBy**, **Keywords**, **SharedDoc** (다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title**.

```javascript
// 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 프레젠테이션과 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    var dp = pres.getDocumentProperties();
    // 내장 속성을 표시합니다
    console.log("Category : " + dp.getCategory());
    console.log("Current Status : " + dp.getContentStatus());
    console.log("Creation Date : " + dp.getCreatedTime());
    console.log("Author : " + dp.getAuthor());
    console.log("Description : " + dp.getComments());
    console.log("KeyWords : " + dp.getKeywords());
    console.log("Last Modified By : " + dp.getLastSavedBy());
    console.log("Supervisor : " + dp.getManager());
    console.log("Modified Date : " + dp.getLastSavedTime());
    console.log("Presentation Format : " + dp.getPresentationFormat());
    console.log("Last Print Date : " + dp.getLastPrinted());
    console.log("Is Shared between producers : " + dp.getSharedDoc());
    console.log("Subject : " + dp.getSubject());
    console.log("Title : " + dp.getTitle());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Built-in 속성 수정**

프레젠테이션 파일의 Built-in 속성을 수정하는 것은 접근하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 수정됩니다. 아래 예제에서는 Aspose.Slides for Node.js via Java를 사용하여 프레젠테이션 파일의 Built-in 문서 속성을 수정하는 방법을 보여줍니다.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 프레젠테이션과 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    var dp = pres.getDocumentProperties();
    // 내장 속성을 설정합니다
    dp.setAuthor("Aspose.Slides for Node.js via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    // 프레젠테이션을 파일에 저장합니다
    pres.save("DocProps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

이 예제는 수정 후 Built-in 문서 속성을 아래와 같이 보여줍니다:

|**수정 후 Built-in 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Custom 문서 속성 추가**

Aspose.Slides for Node.js via Java는 프레젠테이션 문서 속성에 대한 Custom 값을 추가할 수도 있습니다. 아래 예제에서는 프레젠테이션에 Custom 속성을 설정하는 방법을 보여줍니다.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // 문서 속성 가져오기
    var dProps = pres.getDocumentProperties();
    // 사용자 정의 속성 추가
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    // 특정 인덱스의 속성 이름 가져오기
    var getPropertyName = dProps.getCustomPropertyName(2);
    // 선택된 속성 제거
    dProps.removeCustomProperty(getPropertyName);
    // 프레젠테이션 저장
    pres.save("CustomDemo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|**추가된 Custom 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Custom 속성 접근 및 수정**

Aspose.Slides for Node.js via Java는 개발자가 Custom 속성 값을 접근할 수 있도록 합니다. 아래 예제에서는 프레젠테이션에 대해 모든 Custom 속성을 접근하고 수정하는 방법을 보여줍니다.

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    // 프레젠테이션과 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    var dp = pres.getDocumentProperties();
    // 사용자 정의 속성에 접근하고 수정합니다
    for (var i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 사용자 정의 속성의 이름과 값을 표시합니다
        console.log("Custom Property Name : " + dp.getCustomPropertyName(i));
        console.log("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
        // 사용자 정의 속성의 값을 수정합니다
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    // 프레젠테이션을 파일에 저장합니다
    pres.save("CustomDemoModified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

이 예제는 [PPTX ](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 Custom 속성을 수정합니다. 아래 그림은 수정 전후의 프레젠테이션 Custom 속성을 보여줍니다:

|**수정 전 Custom 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**수정 후 Custom 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **고급 문서 속성**

{{% alert color="primary" %}} 

새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-), 및 [WriteBindedPresentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#writeBindedPresentation-java.lang.String-)가 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo) 에 추가되었으며, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/documentproperties#setLastSavedTime-java.util.Date-) 속성 설정자의 로직이 변경되었습니다.

{{% /alert %}} 

두 개의 새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#readDocumentProperties--) 및 [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo#updateDocumentProperties-aspose.slides.IDocumentProperties-)가 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PresentationInfo) 클래스에 추가되었습니다. 이들은 문서 속성에 빠르게 접근할 수 있게 해 주며 전체 프레젠테이션을 로드하지 않고도 속성을 변경하고 업데이트할 수 있게 합니다.

속성을 로드하고, 값을 변경한 뒤 문서를 업데이트하는 일반적인 시나리오는 다음과 같이 구현할 수 있습니다:

```javascript
// 프레젠테이션 정보를 읽어옵니다
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");
// 현재 속성을 가져옵니다
var props = info.readDocumentProperties();
// Author와 Title 필드의 새 값을 설정합니다
props.setAuthor("New Author");
props.setTitle("New Title");
// 새 값으로 프레젠테이션을 업데이트합니다
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

특정 프레젠테이션의 속성을 템플릿으로 사용하여 다른 프레젠테이션의 속성을 업데이트하는 또 다른 방법이 있습니다:

```javascript
var info = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("template.pptx");
var template = info.readDocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

새 템플릿을 처음부터 만들고 이를 사용해 여러 프레젠테이션을 업데이트할 수 있습니다:

```javascript
var template = new aspose.slides.DocumentProperties();
template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");
updateByTemplate("doc1.pptx", template);
updateByTemplate("doc2.odp", template);
updateByTemplate("doc3.ppt", template);
```

```javascript
function updateByTemplate(path, template) 
{
    var toUpdate = aspose.slides.PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **교정 언어 설정**

Aspose.Slides는 PortionFormat 클래스가 노출하는 LanguageId 속성을 제공하여 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

이 JavaScript 코드는 PowerPoint에 대한 교정 언어를 설정하는 방법을 보여 줍니다: xxx JavaScript PortionFormat 클래스에서 LanguageId가 누락된 이유는 무엇입니까?

```javascript
var pres = new aspose.slides.Presentation(pptxFileName);
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();
    var newPortion = new aspose.slides.Portion();
    var font = new aspose.slides.FontData("SimSun");
    var portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);
    portionFormat.setLanguageId("zh-CN");// 교정 언어의 Id를 설정합니다
    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **기본 언어 설정**

이 JavaScript 코드는 전체 PowerPoint 프레젠테이션의 기본 언어를 설정하는 방법을 보여 줍니다:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");
var pres = new aspose.slides.Presentation(loadOptions);
try {
    // 텍스트가 포함된 새 사각형 도형을 추가합니다
    var shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");
    // 첫 번째 포션의 언어를 확인합니다
    console.log(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **실시간 예제**

Aspose.Slides API를 통해 문서 속성을 사용하는 방법을 보려면 온라인 앱인 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata) 을 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## ***FAQ**

**프레젠테이션에서 Built-in 속성을 제거하려면 어떻게 해야 하나요?**

Built-in 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성이 허용하는 경우 값을 변경하거나 빈 문자열로 설정할 수 있습니다.

**이미 존재하는 Custom 속성을 추가하면 어떻게 되나요?**

이미 존재하는 Custom 속성을 추가하면 기존 값이 새 값으로 덮어써집니다. 속성을 미리 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 속성 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있나요?**

예, [PresentationFactory](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/) 클래스의 `getPresentationInfo` 메서드를 사용하여 프레젠테이션을 전체 로드하지 않고도 속성에 접근할 수 있습니다. 그런 다음 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/) 클래스에서 제공하는 `readDocumentProperties` 메서드를 활용하면 메모리를 절약하고 성능을 향상시키면서 속성을 효율적으로 읽을 수 있습니다.