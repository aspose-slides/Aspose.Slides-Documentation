---
title: Java에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/java/presentation-properties/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 프레젠테이션 속성을 마스터하고, PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides는 두 종류의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이 두 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides를 사용하면 [IDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties/) 인터페이스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 인터페이스의 인스턴스는 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 로 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
Application 및 AppVersion 필드는 수정할 수 없음을 알려드립니다. Aspose.Slides는 저장될 때마다 이를 다시 작성하므로 저장된 프레젠테이션은 항상 "Aspose.Slides for Java"와 이를 만든 라이브러리 버전을 보고합니다. `setNameOfApplication`에 전달된 값은 프레젠테이션이 기록될 때 무시됩니다.
{{% /alert %}} 

## **PowerPoint의 문서 속성**

Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있게 합니다. 해야 할 일은 Office 아이콘을 클릭하고 Microsoft PowerPoint 2007에서 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하는 것입니다(아래 그림 참고).

|**고급 속성 메뉴 항목 선택**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/ZrmuCD6.jpg)| |

**Advanced Properties** 메뉴 항목을 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다(아래 그림 참고).

|**속성 대화 상자**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/LibmdQd.jpg)| |
위 **속성 대화 상자**에서는 **General**, **Summary**, **Statistics**, **Contents**, **Custom** 등 여러 탭 페이지를 확인할 수 있습니다. 모든 탭 페이지는 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 해 줍니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

## **Aspose.Slides for Java를 사용한 문서 속성 작업**

앞서 설명했듯이 Aspose.Slides for Java는 **Built-in** 및 **Custom** 두 종류의 문서 속성을 지원합니다. 따라서 개발자는 Aspose.Slides for Java API를 사용하여 두 종류의 속성 모두에 접근할 수 있습니다. Aspose.Slides for Java는 **Presentation.DocumentProperties** 속성을 통해 **Presentation** 개체와 연결된 문서 속성을 나타내는 [IDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties) 클래스를 제공합니다.

개발자는 아래와 같이 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation) 개체가 노출하는 **IDocumentProperties** 속성을 사용하여 프레젠테이션 파일의 문서 속성에 접근할 수 있습니다.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)에 `false`를 전달하여 프레젠테이션을 암호화하면 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setOnlyLoadDocumentProperties-boolean-)에 `true`를 전달하여 열기 비밀번호 없이 공개 메타데이터만 읽을 수 있습니다.

문서‑속성‑전용 옵션은 Aspose.Slides가 로드하는 대상을 제어합니다; 암호를 해제하지는 않습니다. 속성이 암호화에 포함된 경우 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

다음 예제는 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)를 사용해 로드 모드를 확인한 뒤, [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDocumentProperties--)를 통해 내장 속성을 읽습니다.

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("public-properties-encrypted.pptx", loadOptions);
try {
    if (presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        IDocumentProperties properties = presentation.getDocumentProperties();

        System.out.println("Author: " + properties.getAuthor());
        System.out.println("Title: " + properties.getTitle());
        System.out.println("Keywords: " + properties.getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    presentation.dispose();
}
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 개체를 사용할 수 없습니다. 애플리케이션은 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [IProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprotectionmanager/#isOnlyDocumentPropertiesLoaded--)를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터에는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 주석 및 사용자 정의 값이 포함될 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템에서 비밀번호 없이 접근해야 하는 특별한 요구가 있는 경우에만 공개 상태로 유지하십시오.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일에 대해 문서‑속성‑전용 모드로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 용도입니다. Aspose.Slides는 해당 메타데이터‑전용 객체에서 변경된 속성을 저장할 수 없습니다. 공개 속성은 암호화된 프레젠테이션 내부 데이터와 일관성을 유지해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

다음 예제는 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-)로 프레젠테이션을 연 후 공개 내장 속성을 업데이트하고 결과를 저장합니다. 그런 다음 [IPresentationInfo.isEncrypted](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#isEncrypted--)를 사용해 암호화가 유지되었는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새로운 값을 검증합니다.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import com.aspose.slides.SaveFormat;

final String inputPath = "public-properties-encrypted.pptx";
final String outputPath = "updated-public-properties-encrypted.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation(inputPath, loadOptions);
try {
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap");
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed");
    presentation.save(outputPath, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(outputPath);
System.out.println("The presentation is encrypted: " + presentationInfo.isEncrypted());

LoadOptions metadataLoadOptions = new LoadOptions();
metadataLoadOptions.setOnlyLoadDocumentProperties(true);

Presentation metadataPresentation = new Presentation(outputPath, metadataLoadOptions);
try {
    if (metadataPresentation.getProtectionManager().isOnlyDocumentPropertiesLoaded()) {
        System.out.println("Title: " + metadataPresentation.getDocumentProperties().getTitle());
        System.out.println("Keywords: " + metadataPresentation.getDocumentProperties().getKeywords());
    } else {
        System.out.println("The presentation was not loaded in document-properties-only mode.");
    }
} finally {
    metadataPresentation.dispose();
}
```

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성은 읽기 전용으로 취급해야 합니다.

## **내장 속성 접근**

[IDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties) 개체가 노출하는 속성에는 **Creator**(작성자), **Description**, **Keywords**, **Created**(생성 일자), **Modified**(수정 일자), **Printed**(마지막 인쇄 일자), **LastModifiedBy**, **SharedDoc**(다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title** 등이 포함됩니다.

```java
import com.aspose.slides.*;

// 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation와 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // Display the built-in properties
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

## **내장 속성 수정**

프레젠테이션 파일의 내장 속성을 수정하는 것은 접근하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 변경됩니다. 아래 예제에서는 Aspose.Slides for Java를 사용해 프레젠테이션 파일의 내장 문서 속성을 수정하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("Presentation.pptx");
try {
    // Presentation과 연결된 IDocumentProperties 객체에 대한 참조를 생성합니다
    IDocumentProperties dp = pres.getDocumentProperties();
    
    // 내장 속성을 설정합니다
    dp.setAuthor("Aspose.Slides for Java");
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

이 예제는 수정된 내장 문서 속성을 아래와 같이 확인할 수 있습니다.

|**수정 후 내장 문서 속성**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/zz1N9de.jpg)| |

## **사용자 정의 문서 속성 추가**

Aspose.Slides for Java를 사용하면 개발자가 프레젠테이션 문서 속성에 사용자 정의 값을 추가할 수 있습니다. 아래 예제는 세 개의 사용자 정의 속성을 추가하고, 인덱스 2에 저장된 이름을 조회한 뒤 해당 속성을 제거합니다. 저장된 프레젠테이션에는 두 개의 속성만 남게 됩니다. 사용자 정의 속성은 추가된 순서가 아니라 알파벳 순서대로 인덱싱됩니다.

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
    
    // 선택한 속성 제거
    dProps.removeCustomProperty(getPropertyName);
    
    // 프레젠테이션 저장
    pres.save("CustomDemo.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|**추가된 사용자 정의 문서 속성**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/HdKcxI9.png)| |

## **사용자 정의 속성 접근 및 수정**

Aspose.Slides for Java를 사용하면 개발자가 사용자 정의 속성 값을 접근할 수도 있습니다. 아래 예제는 프레젠테이션의 모든 사용자 정의 속성을 어떻게 접근하고 수정할 수 있는지 보여줍니다.

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

이 예제는 [PPTX](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 사용자 정의 속성을 수정합니다. 아래 그림은 수정 전후의 사용자 정의 속성을 보여줍니다.

|**수정 전 사용자 정의 속성**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Ze7YHvi.jpg)| |

|**수정 후 사용자 정의 속성**| |
| :- | :- |
|![todo:image_alt_text](https://i.imgur.com/Tofu0CL.jpg)| |

## **고급 문서 속성**

{{% alert color="info" title="Note" %}}
새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--), [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-), 및 [WriteBindedPresentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentationInfo#writeBindedPresentation-java.lang.String-)가 [IPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentationInfo)에 추가되었으며, [IDocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/idocumentproperties#setLastSavedTime-java.util.Date-) 속성 설정자의 로직이 변경되었습니다.
{{% /alert %}} 

새 메서드 [ReadDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentationInfo#readDocumentProperties--)와 [UpdateDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentationInfo#updateDocumentProperties-com.aspose.slides.IDocumentProperties-)는 [IPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentationInfo) 인터페이스에 추가되었습니다. 이 메서드들은 문서 속성을 빠르게 접근하고 전체 프레젠테이션을 로드하지 않고도 속성을 변경·업데이트할 수 있게 합니다.

일반적인 시나리오: 속성을 로드하고, 값을 변경한 뒤, 문서를 업데이트하는 방법은 다음과 같습니다.

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

특정 프레젠테이션의 속성을 템플릿으로 사용해 다른 프레젠테이션의 속성을 업데이트하는 또 다른 방법도 있습니다:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
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

새 템플릿을 처음부터 만들고 여러 프레젠테이션을 업데이트하는 데 사용할 수도 있습니다:

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

for (String path : new String[] { "doc1.pptx", "doc2.odp", "doc3.ppt" }) {
    IPresentationInfo toUpdate = PresentationFactory.getInstance().getPresentationInfo(path);
    toUpdate.updateDocumentProperties(template);
    toUpdate.writeBindedPresentation(path);
}
```

## **교정 언어 설정**

Aspose.Slides는 PortionFormat 클래스가 노출하는 LanguageId 속성을 통해 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

다음 Java 코드는 PowerPoint에 교정 언어를 설정하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

String pptxFileName = "presentation.pptx";

Presentation pres = new Presentation(pptxFileName);
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

다음 Java 코드는 전체 PowerPoint 프레젠테이션에 기본 언어를 설정하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation pres = new Presentation(loadOptions);
try {
    // 텍스트가 있는 새 사각형 모양을 추가합니다
    IAutoShape shp = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shp.getTextFrame().setText("New Text");

    // 첫 번째 부분의 언어를 확인합니다
    System.out.println(shp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId());
} finally {
    if (pres != null) pres.dispose();
}
```

## **실시간 예제**

Aspose.Slides Metadata 온라인 앱을 사용해 Aspose.Slides API로 문서 속성을 어떻게 다루는지 직접 확인해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 내장 속성을 제거하려면 어떻게 해야 하나요?**

내장 속성은 프레젠테이션의 필수 구성 요소이며 완전히 제거할 수 없습니다. 다만, 해당 속성 값을 변경하거나 해당 속성이 허용한다면 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새 값으로 덮어쓰기됩니다. 사전에 속성을 삭제하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 전체 로드하지 않고 속성에 접근할 수 있나요?**

네. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-)를 사용한 뒤 [IPresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#readDocumentProperties--)를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) 인스턴스를 생성하지 않고도 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/java/examine-presentation/)를 참고하세요.

**암호화된 프레젠테이션의 공개 속성을 열기 비밀번호 없이 읽을 수 있나요?**

네. 문서‑속성 암호화가 프레젠테이션이 암호화되기 전에 비활성화되어 있었고, 프레젠테이션을 문서‑속성‑전용 모드로 로드한 경우 가능합니다.

**문서‑속성‑전용 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니요. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호와 함께 전체 프레젠테이션을 로드해야 합니다.