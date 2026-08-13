---
title: Android에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/androidjava/presentation-properties/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 작업 흐름을 간소화합니다."
---
## **소개**

Aspose.Slides는 두 가지 유형의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이 두 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides는 [IDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idocumentproperties/) 인터페이스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 인터페이스의 인스턴스는 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getDocumentProperties--) 메서드에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" %}} 

**Application** 및 **AppVersion** 필드는 수정할 수 없습니다. Aspose.Slides는 저장할 때마다 이 필드를 다시 기록하므로 저장된 프레젠테이션은 항상 Aspose.Slides 제품 이름과 이를 만든 라이브러리 버전을 보고합니다. `setNameOfApplication`에 전달된 값은 프레젠테이션이 기록될 때 폐기됩니다.

{{% /alert %}} 

## **PowerPoint의 문서 속성**

Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있습니다. 아래와 같이 Office 아이콘을 클릭한 후 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하면 됩니다:

|**Advanced Properties 메뉴 항목 선택**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |
**Advanced Properties** 메뉴 항목을 선택하면 아래 그림과 같이 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다:

|**속성 대화 상자**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
위 **속성 대화 상자**에서는 **General**, **Summary**, **Statistics**, **Contents**, **Custom**과 같은 여러 탭 페이지를 볼 수 있습니다. 이러한 탭 페이지는 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 해 줍니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.



Android용 Java Aspose.Slides를 사용한 문서 속성 작업

앞에서 설명했듯이 Android용 Java Aspose.Slides는 **Built-in** 및 **Custom** 두 종류의 문서 속성을 지원합니다. 따라서 개발자는 Aspose.Slides for Android via Java API를 사용하여 두 종류의 속성에 모두 접근할 수 있습니다. Android용 Java Aspose.Slides는 **Presentation.DocumentProperties** 속성을 통해 프레젠테이션 파일과 연결된 문서 속성을 나타내는 [IDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idocumentproperties) 클래스를 제공합니다.

개발자는 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 객체가 노출하는 **IDocumentProperties** 속성을 사용하여 아래와 같이 프레젠테이션 파일의 문서 속성에 접근할 수 있습니다:

## **Built-in 속성 접근**

[IDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idocumentproperties) 객체가 노출하는 이러한 속성에는 **Creator**(작성자), **Description**, **Keywords**, **Created**(작성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **SharedDoc**(다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

```java
import com.aspose.slides.*;

// 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 내장 속성을 표시합니다
    System.out.println("Category : " + dp.getCategory());
    System.out.println("Current Status : " + dp.getContentStatus());
    System.out.println("Creation Date : " + dp.getCreatedTime());
    System.out.println("Author : " + dp.getAuthor());
    System.out.println("Description : " + dp.getComments());
    System.out.println("KeyWords : " + dp.getKeywords());
    System.out.println("Last Modified By : " + dp.getLastSavedBy());
    System.out.println("Supervisor : " + dp.getManager());
    System.out.println("Modified Date : " + dp.getLastSavedTime());
    System.out.println("Presentation Format : " + dp.getPresentationFormat());
    System.out.println("Last Print Date : " + dp.getLastPrinted());
    System.out.println("Is Shared between producers : " + dp.getSharedDoc());
    System.out.println("Subject : " + dp.getSubject());
    System.out.println("Title : " + dp.getTitle());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Built-in 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 것은 해당 속성에 문자열 값을 할당하는 것만큼 쉽습니다. 아래 예제에서는 Android용 Java Aspose.Slides를 사용하여 프레젠테이션 파일의 내장 문서 속성을 수정하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 내장 속성을 설정합니다
    dp.setAuthor("Aspose.Slides for Android via Java");
    dp.setTitle("Modifying Presentation Properties");
    dp.setSubject("Aspose Subject");
    dp.setComments("Aspose Description");
    dp.setManager("Aspose Manager");
    
    // 프레젠테이션을 파일에 저장합니다
    pres.save("DocProps.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

이 예제는 수정된 내장 속성을 아래와 같이 표시합니다:

|**수정 후 Built-in 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **Custom 문서 속성 추가**

Android용 Java Aspose.Slides는 개발자가 프레젠테이션 문서 속성에 사용자 정의 값을 추가할 수 있게 합니다. 아래 예제는 세 개의 사용자 정의 속성을 추가하고, 인덱스 2에 저장된 이름을 조회한 뒤 해당 속성을 제거합니다. 따라서 저장된 프레젠테이션에는 두 개의 속성만 남게 됩니다. 사용자 정의 속성은 추가된 순서가 아니라 알파벳 순서대로 인덱싱됩니다.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // 문서 속성 가져오기
    IDocumentProperties dProps = pres.getDocumentProperties();
    
    // 사용자 정의 속성 추가
    dProps.set_Item("New Custom", 12);
    dProps.set_Item("My Name", "Mudassir");
    dProps.set_Item("Custom", 124);
    
    // 특정 인덱스의 속성 이름 가져오기
    String getPropertyName = dProps.getCustomPropertyName(2);
    
    // 선택된 속성 제거
    dProps.removeCustomProperty(getPropertyName);
    
    // 프레젠테이션 저장
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**추가된 Custom 문서 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **Custom 속성 접근 및 수정**

Android용 Java Aspose.Slides는 개발자가 사용자 정의 속성 값을 접근할 수도 있게 합니다. 아래 예제는 프레젠테이션에 대해 이러한 모든 사용자 정의 속성을 어떻게 접근하고 수정할 수 있는지를 보여줍니다.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 사용자 정의 속성에 접근하고 수정합니다
    for (int i = 0; i < dp.getCountOfCustomProperties(); i++) {
        // 사용자 정의 속성의 이름과 값을 표시합니다
        System.out.println("Custom Property Name : " + dp.getCustomPropertyName(i));
        System.out.println("Custom Property Value : " + dp.get_Item(dp.getCustomPropertyName(i)));
    
        // 사용자 정의 속성의 값을 수정합니다
        dp.set_Item(dp.getCustomPropertyName(i), "New Value " + (i + 1));
    }
    
    // 프레젠테이션을 파일에 저장합니다
    pres.save("CustomDemoModified.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

이 예제는 [PPTX](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 사용자 정의 속성을 수정합니다. 아래 그림은 수정 전후의 프레젠테이션 사용자 정의 속성을 나타냅니다:

|**수정 전 Custom 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**수정 후 Custom 속성**|** |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **고급 문서 속성**

{{% alert color="info" %}} 

새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), 및 [WriteBindedPresentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)이 [IPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPresentationInfo)에 추가되었으며, [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 속성 설정자의 로직이 변경되었습니다.

{{% /alert %}} 

두 새로운 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPresentationInfo#readDocumentProperties--) 및 [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)가 [IPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IPresentationInfo) 인터페이스에 추가되었습니다. 이러한 메서드는 문서 속성에 빠르게 접근하고 전체 프레젠테이션을 로드하지 않고도 속성을 변경 및 업데이트할 수 있게 해 줍니다.

속성을 로드하고, 값을 변경한 뒤 문서를 업데이트하는 일반적인 시나리오는 다음과 같이 구현할 수 있습니다:

```java
import com.aspose.slides.*;

// 프레젠테이션 정보를 읽습니다
IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx");

// obtain the current properties
IDocumentProperties props = info.readDocumentProperties();

// set the new values of Author and Title fields
props.setAuthor("New Author");
props.setTitle("New Title");

// update the presentation with a new values
info.updateDocumentProperties(props);
info.writeBindedPresentation("presentation.pptx");
```

특정 프레젠테이션의 속성을 템플릿으로 사용하여 다른 프레젠테이션의 속성을 업데이트하는 또 다른 방법이 있습니다:

```java
import com.aspose.slides.*;

IPresentationInfo info = PresentationFactory.getInstance().getPresentationInfo("template.pptx");
DocumentProperties template = (DocumentProperties) info.readDocumentProperties();

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

```java
import com.aspose.slides.*;

private static void updateByTemplate(String path, IDocumentProperties template) 
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

새 템플릿을 처음부터 만들고 이를 사용하여 여러 프레젠테이션을 업데이트할 수 있습니다:

```java
import com.aspose.slides.*;

DocumentProperties template = new DocumentProperties();

template.setAuthor("Template Author");
template.setTitle("Template Title");
template.setCategory("Template Category");
template.setKeywords("Keyword1, Keyword2, Keyword3");
template.setCompany("Our Company");
template.setComments("Created from template");
template.setContentType("Template Content");
template.setSubject("Template Subject");

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" })
{
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **교정 언어 설정**

Aspose.Slides는 PortionFormat 클래스가 노출하는 LanguageId 속성을 제공하여 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint의 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

다음 Java 코드는 PowerPoint에 교정 언어를 설정하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("presentation.pptx");
try {
    AutoShape autoShape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion newPortion = new Portion();

    IFontData font = new FontData("SimSun");
    IPortionFormat portionFormat = newPortion.getPortionFormat();
    portionFormat.setComplexScriptFont(font);
    portionFormat.setEastAsianFont(font);
    portionFormat.setLatinFont(font);

    portionFormat.setLanguageId("zh-CN"); // 교정 언어의 ID를 설정합니다

    newPortion.setText("1。");
    paragraph.getPortions().add(newPortion);
} finally {
    if (pres != null) pres.dispose();
}
```

## **기본 언어 설정**

다음 Java 코드는 전체 PowerPoint 프레젠테이션에 기본 언어를 설정하는 방법을 보여 줍니다:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 텍스트가 포함된 새 사각형 모양을 추가합니다
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 첫 번째 포션의 언어를 확인합니다
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **실시간 예제**

문서 속성을 Aspose.Slides API를 통해 작업하는 방법을 보려면 온라인 앱 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata)를 사용해 보세요:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## ***FAQ**

### 프레젠테이션에서 Built-in 속성을 제거하려면 어떻게 해야 하나요?

Built-in 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만 해당 속성의 값을 변경하거나, 해당 속성이 허용하는 경우 빈 값으로 설정할 수 있습니다.

### 이미 존재하는 Custom 속성을 추가하면 어떻게 되나요?

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새 값으로 덮어쓰기 됩니다. 속성을 미리 제거하거나 확인할 필요가 없으며, Aspose.Slides가 자동으로 속성 값을 업데이트합니다.

### 프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있나요?

예, [PresentationFactory](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentationfactory/) 클래스의 `getPresentationInfo` 메서드를 사용하여 프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있습니다. 그런 다음 [IPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/) 인터페이스가 제공하는 `readDocumentProperties` 메서드를 활용하면 메모리를 절약하고 성능을 향상시키면서 속성을 효율적으로 읽을 수 있습니다.