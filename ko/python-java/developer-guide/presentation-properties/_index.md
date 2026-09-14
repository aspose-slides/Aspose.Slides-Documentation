---
title: Python에서 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/python-java/presentation-properties/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java에서 프레젠테이션 속성을 마스터하고 PowerPoint 및 OpenDocument 파일에서 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides는 문서 속성 두 종류를 지원합니다: **Built-in** 와 **Custom**. 이러한 속성 유형은 Aspose.Slides API를 사용해 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 합니다. 이 클래스의 인스턴스는 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getDocumentProperties) 메서드에 의해 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
**Application** 및 **AppVersion** 필드는 수정할 수 없습니다. Aspose.Slides는 저장할 때마다 이 필드를 다시 씁니다. 따라서 저장된 프레젠테이션은 항상 "Aspose.Slides for Java"와 해당 라이브러리의 버전을 보고합니다. [DocumentProperties.setNameOfApplication](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#setNameOfApplication) 에 전달된 값은 프레젠테이션이 기록될 때 무시됩니다.
{{% /alert %}}

## **PowerPoint에서 문서 속성**

Microsoft PowerPoint 2007에서는 프레젠테이션 파일의 문서 속성을 관리할 수 있습니다. 아래와 같이 Office 아이콘을 클릭하고 **Prepare | Properties | Advanced Properties** 를 선택합니다:

|**고급 속성 메뉴 항목 선택**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/ZrmuCD6.jpg)|
**Advanced Properties** 를 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다:

|**속성 대화 상자**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/LibmdQd.jpg)|
**Properties Dialog**에는 **General**, **Summary**, **Statistics**, **Contents**, **Custom** 와 같은 탭이 있습니다. 이러한 탭을 통해 PowerPoint 파일에 대한 다양한 정보를 설정할 수 있습니다. **Custom** 탭을 사용하여 사용자 정의 속성을 관리하십시오.

## **Aspose.Slides for Python via Java를 사용하여 문서 속성 작업**

앞서 설명했듯이 Aspose.Slides for Python via Java는 **Built-in** 및 **Custom** 문서 속성을 모두 지원합니다. [DocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/) 클래스는 프레젠테이션 파일과 연결된 문서 속성을 나타냅니다.

아래에 설명된 대로 이러한 속성에 접근하려면 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getDocumentProperties) 를 사용하십시오.

## **암호화된 프레젠테이션에서 공개 속성 읽기**

열기 비밀번호는 일반적으로 프레젠테이션 내용과 문서 속성을 모두 보호합니다. [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 에 `false` 를 전달하여 프레젠테이션을 암호화하면, 문서 속성은 공개 상태로 유지됩니다. 그런 다음 애플리케이션은 [LoadOptions.setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setOnlyLoadDocumentProperties) 에 `true` 를 전달하여 열기 비밀번호 없이 공개 메타데이터를 읽을 수 있습니다.

document-properties-only 옵션은 Aspose.Slides가 로드하는 내용을 제어합니다; 어떠한 복호화도 수행하지 않습니다. 속성이 암호화에 포함된 경우 비밀번호 없이 로드하면 실패합니다. 프레젠테이션이 암호화되지 않은 경우 이 옵션은 무시되고 전체 프레젠테이션이 로드됩니다.

다음 예제는 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 를 통해 로드 모드를 확인하고, 이후 [Presentation.getDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#getDocumentProperties) 를 사용하여 Built-in 속성을 읽습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions

load_options = LoadOptions()
load_options.setOnlyLoadDocumentProperties(True)

presentation = Presentation("public-properties-encrypted.pptx", load_options)
try:
    if presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        properties = presentation.getDocumentProperties()

        print("Author: ", properties.getAuthor())
        print("Title: ", properties.getTitle())
        print("Keywords: ", properties.getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    presentation.dispose()
```

이 모드에서는 슬라이드 내용이 로드되지 않습니다. 슬라이드, 마스터, 레이아웃, 도형, 미디어 및 기타 프레젠테이션 객체를 사용할 수 없습니다. 전체 프레젠테이션 객체 모델이 필요한 작업을 수행하기 전에 항상 [ProtectionManager.isOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/ko/python-java/aspose.slides/protectionmanager/#isOnlyDocumentPropertiesLoaded) 를 확인해야 합니다.

{{% alert color="warning" title="Warning" %}}
공개 메타데이터는 작성자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 사용자 정의 값을 노출할 수 있습니다. 민감한 속성은 프레젠테이션과 함께 암호화하십시오. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 비밀번호 없이 접근해야 하는 특정 요구가 있는 경우에만 공개 상태로 두세요.
{{% /alert %}}

## **암호화된 프레젠테이션 속성 업데이트**

암호화된 PPTX 파일의 경우, document-properties-only 모드로 로드된 프레젠테이션은 공개 메타데이터를 읽기 위한 것입니다. Aspose.Slides는 해당 메타데이터 전용 객체에서 변경된 속성을 저장할 수 없습니다. 왜냐하면 공개 속성은 암호화된 프레젠테이션 내부의 데이터와 일관성을 유지해야 하기 때문입니다. 따라서 속성을 업데이트하려면 올바른 열기 비밀번호와 전체 로드가 필요합니다.

다음 예제는 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/python-java/aspose.slides/loadoptions/#setPassword) 로 프레젠테이션을 열고, 공개 Built-in 속성을 업데이트한 뒤 결과를 저장합니다. 이후 [PresentationInfo.isEncrypted](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#isEncrypted) 를 사용하여 암호화가 유지되는지 확인하고, 비밀번호 없이 공개 메타데이터를 다시 열어 새로운 값을 검증합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, PresentationFactory, SaveFormat

input_path = "public-properties-encrypted.pptx"
output_path = "updated-public-properties-encrypted.pptx"

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation(input_path, load_options)
try:
    presentation.getDocumentProperties().setTitle("Updated Product Roadmap")
    presentation.getDocumentProperties().setKeywords("roadmap, planning, indexed")
    presentation.save(output_path, SaveFormat.Pptx)
finally:
    presentation.dispose()

presentation_info = PresentationFactory.getInstance().getPresentationInfo(output_path)
print("The presentation is encrypted: ", presentation_info.isEncrypted())

metadata_load_options = LoadOptions()
metadata_load_options.setOnlyLoadDocumentProperties(True)

metadata_presentation = Presentation(output_path, metadata_load_options)
try:
    if metadata_presentation.getProtectionManager().isOnlyDocumentPropertiesLoaded():
        print("Title: ", metadata_presentation.getDocumentProperties().getTitle())
        print("Keywords: ", metadata_presentation.getDocumentProperties().getKeywords())
    else:
        print("The presentation was not loaded in document-properties-only mode.")

finally:
    metadata_presentation.dispose()
```

애플리케이션이 프레젠테이션 내용을 복호화하거나 로드할 수 없는 경우, 암호화된 PPTX 파일의 공개 속성을 읽기 전용으로 취급해야 합니다.

## **Built-in 속성 접근**

[DocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/) 에서 제공하는 Built-in 속성에는 **Creator**(작성자), **Description**, **Created**(생성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **Keywords**, **SharedDoc**(여러 제작자 간에 공유되는가?), **PresentationFormat**, **Subject**, **Title** 이 포함됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, DocumentProperties

# 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
presentation = Presentation("Presentation.pptx")
try:
    # Presentation에 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    properties = presentation.getDocumentProperties()

    # Built-in 속성을 출력합니다
    print("Category : ", properties.getCategory())
    print("Current Status : ", properties.getContentStatus())
    print("Creation Date : ", properties.getCreatedTime())
    print("Author : ", properties.getAuthor())
    print("Description : ", properties.getComments())
    print("KeyWords : ", properties.getKeywords())
    print("Last Modified By : ", properties.getLastSavedBy())
    print("Supervisor : ", properties.getManager())
    print("Modified Date : ", properties.getLastSavedTime())
    print("Presentation Format : ", properties.getPresentationFormat())
    print("Last Print Date : ", properties.getLastPrinted())
    print("Is Shared between producers : ", properties.getSharedDoc())
    print("Subject : ", properties.getSubject())
    print("Title : ", properties.getTitle())
finally:
    presentation.dispose()
```

## **Built-in 속성 수정**

Built-in 속성을 수정하는 것은 접근하는 것만큼 간단합니다. 해당 setter를 사용하여 새로운 값을 할당하면 됩니다. 다음 예제는 Aspose.Slides for Python via Java를 사용하여 Built-in 문서 속성을 수정합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation에 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    properties = presentation.getDocumentProperties()

    # Built-in 속성을 설정합니다
    properties.setAuthor("Aspose.Slides for Python via Java")
    properties.setTitle("Modifying Presentation Properties")
    properties.setSubject("Aspose Subject")
    properties.setComments("Aspose Description")
    properties.setManager("Aspose Manager")

    # 프레젠테이션을 파일에 저장합니다
    presentation.save("DocProps.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 예제는 아래와 같이 프레젠테이션의 Built-in 속성을 수정합니다:

|**수정 후 Built-in 문서 속성**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/zz1N9de.jpg)|

## **Custom 문서 속성 추가**

Aspose.Slides for Python via Java는 개발자가 프레젠테이션에 Custom 문서 속성을 추가할 수 있게 합니다. 아래 예제는 세 개의 Custom 속성을 추가한 다음, 인덱스 2에 저장된 이름을 찾아 해당 속성을 제거합니다. 따라서 저장된 프레젠테이션에는 두 개의 속성만 남게 됩니다. Custom 속성은 추가된 순서가 아니라 알파벳 순서대로 인덱싱됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # 문서 속성 가져오기
    properties = presentation.getDocumentProperties()

    # 사용자 정의 속성 추가
    properties.set_Item("New Custom", jpype.JInt(12))
    properties.set_Item("My Name", "Mudassir")
    properties.set_Item("Custom", jpype.JInt(124))

    # 특정 인덱스에서 속성 이름 가져오기
    property_name = properties.getCustomPropertyName(2)

    # 선택된 속성 제거
    properties.removeCustomProperty(property_name)

    # 프레젠테이션 저장
    presentation.save("CustomDemo.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|**추가된 Custom 문서 속성**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/HdKcxI9.png)|

## **Custom 속성 접근 및 수정**

Aspose.Slides for Python via Java는 개발자가 Custom 속성 값을 접근할 수도 있게 합니다. 다음 예제는 프레젠테이션의 모든 Custom 속성을 접근하고 수정하는 방법을 보여줍니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, DocumentProperties

presentation = Presentation("Presentation.pptx")
try:
    # Presentation에 연결된 DocumentProperties 객체에 대한 참조를 생성합니다
    properties = presentation.getDocumentProperties()

    # 사용자 정의 속성에 접근하고 수정합니다
    for i in range(properties.getCountOfCustomProperties()):
        property_name = properties.getCustomPropertyName(i)
        # 사용자 정의 속성의 이름과 값을 표시합니다
        print("Custom Property Name : ", property_name)
        print("Custom Property Value : ", properties.get_Item(property_name))

        # 사용자 정의 속성의 값을 수정합니다
        properties.set_Item(property_name, f"New Value {i + 1}")

    # 프레젠테이션을 파일에 저장합니다
    presentation.save("CustomDemoModified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

이 예제는 [PPTX](https://docs.fileformat.com/presentation/pptx/) 프레젠테이션의 Custom 속성을 수정합니다. 다음 그림은 수정 전후의 프레젠테이션 Custom 속성을 보여줍니다:

|**수정 전 Custom 속성**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Ze7YHvi.jpg)|

|**수정 후 Custom 속성**|
| :- |
|![PowerPoint document properties](https://i.imgur.com/Tofu0CL.jpg)|

## **고급 문서 속성**

{{% alert color="info" title="Note" %}}
새 메서드 [readDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#readDocumentProperties), [updateDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), 및 [writeBindedPresentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#writeBindedPresentation) 가 [PresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/) 에 추가되었으며, [DocumentProperties.setLastSavedTime](https://reference.aspose.com/slides/ko/python-java/aspose.slides/documentproperties/#setLastSavedTime) 메서드의 동작이 변경되었습니다.
{{% /alert %}}

새 메서드 [readDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#readDocumentProperties)와 [updateDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#updateDocumentProperties) 가 [PresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/) 클래스에 추가되었습니다. 이 메서드들은 문서 속성에 빠르게 접근하고, 전체 프레젠테이션을 로드하지 않고도 속성을 변경·업데이트할 수 있게 해 줍니다.

속성을 로드하고, 값을 변경한 뒤 문서를 업데이트하는 일반적인 워크플로는 다음과 같이 구현할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

# 프레젠테이션 정보를 읽습니다
presentation_info = PresentationFactory.getInstance().getPresentationInfo("presentation.pptx")

# 현재 속성을 가져옵니다
properties = presentation_info.readDocumentProperties()

# Author 및 Title 필드의 새 값을 설정합니다
properties.setAuthor("New Author")
properties.setTitle("New Title")

# 새 값으로 프레젠테이션을 업데이트합니다
presentation_info.updateDocumentProperties(properties)
presentation_info.writeBindedPresentation("presentation.pptx")
```

특정 프레젠테이션의 속성을 템플릿으로 사용하여 다른 프레젠테이션의 속성을 업데이트하는 또 다른 방법이 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("template.pptx")
template = presentation_info.readDocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory

def update_by_template(path, template):
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

새 템플릿을 처음부터 만들고 이를 사용하여 여러 프레젠테이션을 업데이트할 수 있습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory, DocumentProperties

template = DocumentProperties()

template.setAuthor("Template Author")
template.setTitle("Template Title")
template.setCategory("Template Category")
template.setKeywords("Keyword1, Keyword2, Keyword3")
template.setCompany("Our Company")
template.setComments("Created from template")
template.setContentType("Template Content")
template.setSubject("Template Subject")

for path in ["doc1.pptx", "doc2.odp", "doc3.ppt"]:
    presentation_to_update = PresentationFactory.getInstance().getPresentationInfo(path)
    presentation_to_update.updateDocumentProperties(template)
    presentation_to_update.writeBindedPresentation(path)
```

## **맞춤법 언어 설정**

Aspose.Slides는 [PortionFormat.setLanguageId](https://reference.aspose.com/slides/ko/python-java/aspose.slides/portionformat/#setLanguageId) 메서드를 제공하여 PowerPoint 문서의 맞춤법 검사 언어를 설정할 수 있게 합니다. 맞춤법 검사 언어는 프레젠테이션에서 맞춤법 및 문법 검사가 수행되는 언어를 의미합니다.

다음 Python 코드는 PowerPoint의 맞춤법 검사 언어를 설정하는 방법을 보여 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Portion, FontData

pptx_file_name = "presentation.pptx"

presentation = Presentation(pptx_file_name)
try:
    auto_shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    new_portion = Portion()

    font = FontData("SimSun")
    portion_format = new_portion.getPortionFormat()
    portion_format.setComplexScriptFont(font)
    portion_format.setEastAsianFont(font)
    portion_format.setLatinFont(font)

    portion_format.setLanguageId("zh-CN") # 맞춤법 검사 언어의 ID를 설정합니다

    new_portion.setText("1。")
    paragraph.getPortions().add(new_portion)
finally:
    presentation.dispose()
```

## **기본 언어 설정**

다음 Python 코드는 전체 PowerPoint 프레젠테이션의 기본 언어를 설정하는 방법을 보여 줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, LoadOptions, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    # 텍스트가 포함된 사각형 도형을 추가합니다
    shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50)
    shape.getTextFrame().setText("New Text")

    # 첫 번째 부분의 언어를 확인합니다
    print(shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **실시간 예제**

Aspose.Slides API를 사용하여 문서 속성을 다루는 방법을 보려면 온라인 앱인 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata) 을 사용해 보세요:

[![PowerPoint 메타데이터 보기 및 편집](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 Built-in 속성을 어떻게 제거할 수 있나요?**

Built-in 속성은 프레젠테이션의 핵심 부분이며 완전히 제거할 수 없습니다. 다만, 해당 속성이 허용한다면 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 Custom 속성을 추가하면 어떻게 되나요?**

이미 존재하는 Custom 속성을 추가하면 기존 값이 새 값으로 덮어씁니다. 속성을 미리 제거하거나 확인할 필요가 없으며, Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있나요?**

예. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationfactory/#getPresentationInfo) 를 사용하고 이어서 [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentationinfo/#readDocumentProperties) 를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 인스턴스를 만들지 않고 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/python-java/examine-presentation/) 를 참조하십시오.

**암호화된 프레젠테이션의 공개 속성을 열기 비밀번호 없이 읽을 수 있나요?**

예. 문서 속성 암호화가 프레젠테이션이 암호화되기 전에 비활성화되어야 하며, 프레젠테이션은 document-properties-only 모드로 로드되어야 합니다.

**document-properties-only 모드에서 암호화된 PPTX 파일을 업데이트할 수 있나요?**

아니오. 공개 속성과 암호화된 속성 데이터는 일관성을 유지해야 하므로, 암호화된 PPTX 파일을 업데이트하려면 올바른 열기 비밀번호와 함께 전체 프레젠테이션을 로드해야 합니다.