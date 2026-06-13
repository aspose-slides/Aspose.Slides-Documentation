---
title: Python으로 프레젠테이션 속성 관리
linktitle: 프레젠테이션 속성
type: docs
weight: 70
url: /ko/python-net/presentation-properties/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 프레젠테이션 속성을 마스터하고 PowerPoint 파일의 검색, 브랜딩 및 워크플로를 간소화하십시오."
---
## **소개**

Aspose.Slides는 두 가지 유형의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides는 [DocumentProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있게 해줍니다. 이 클래스의 인스턴스는 [Presentation.document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/document_properties/) 속성을 통해 반환됩니다. 다음 예제는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="primary" %}} 
참고로 **Application** 및 **Producer** 필드에 값을 설정할 수 없습니다. 해당 필드에는 Aspose Ltd.와 Aspose.Slides for Python via .NET x.x.x 버전 정보가 표시됩니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 일부 속성을 추가하는 기능을 제공합니다. 이러한 문서 속성을 통해 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성은 다음 두 종류가 있습니다.

- 시스템 정의 (Built-in) 속성
- 사용자 정의 (Custom) 속성

**Built-in** 속성은 문서 제목, 작성자 이름, 문서 통계 등과 같은 일반 정보를 포함합니다. **Custom** 속성은 사용자가 **Name/Value** 쌍으로 정의한 것으로, 이름과 값 모두 사용자가 정의합니다. Aspose.Slides for Python via .NET을 사용하면 개발자는 Built-in 속성 및 Custom 속성의 값을 액세스하고 수정할 수 있습니다. Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있도록 합니다. 수행 방법은 Office 아이콘을 클릭하고 Microsoft PowerPoint 2007의 **Prepare | Properties | Advanced Properties** 메뉴 항목을 차례로 선택하는 것입니다. **Advanced Properties** 메뉴를 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다. **Properties Dialog**에서 **General, Summary, Statistics, Contents 및 Custom**과 같은 여러 탭 페이지를 볼 수 있습니다. 이러한 탭 페이지는 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 합니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

## **Built-in 속성 액세스**
이러한 속성은 **IDocumentProperties** 객체를 통해 노출되며 다음을 포함합니다: **Creator(Author)**, **Description**, **Keywords**, **Created**(작성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **SharedDoc**(다른 제작자와 공유 여부), **PresentationFormat**, **Subject**, **Title**.
```py
import aspose.slides as slides

# 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation(path + "AccessBuiltin Properties.pptx") as pres:
    # Presentation와 연결된 객체에 대한 참조를 생성합니다
    documentProperties = pres.document_properties

    # 내장 속성을 표시합니다
    print("category : " + documentProperties.category)
    print("Current Status : " + documentProperties.content_status)
    print("Creation Date : " + str(documentProperties.created_time))
    print("Author : " + documentProperties.author)
    print("Description : " + documentProperties.comments)
    print("KeyWords : " + documentProperties.keywords)
    print("Last Modified By : " + documentProperties.last_saved_by)
    print("Supervisor : " + documentProperties.manager)
    print("Modified Date : " + str(documentProperties.last_saved_time))
    print("Presentation Format : " + documentProperties.presentation_format)
    print("Last Print Date : " + str(documentProperties.last_printed))
    print("Is Shared between producers : " + str(documentProperties.shared_doc))
    print("Subject : " + documentProperties.subject)
    print("Title : " + documentProperties.title)
```

## **Built-in 속성 수정**
프레젠테이션 파일의 Built-in 속성을 수정하는 것은 해당 속성에 접근하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 수정됩니다. 아래 예제에서는 프레젠테이션 파일의 Built-in 문서 속성을 어떻게 수정할 수 있는지 보여줍니다.
```py
import aspose.slides as slides

# 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation(path + "ModifyBuiltinProperties.pptx") as presentation:
    # Presentation와 연결된 객체에 대한 참조를 생성합니다
    documentProperties = presentation.document_properties

    # 내장 속성을 설정합니다
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # 프레젠테이션을 파일에 저장합니다
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **사용자 정의 프레젠테이션 속성 추가**
Aspose.Slides for Python via .NET은 개발자가 프레젠테이션 문서 속성에 사용자 정의 값을 추가할 수 있도록 합니다. 아래 예제는 프레젠테이션에 사용자 정의 속성을 설정하는 방법을 보여줍니다.
```py
import aspose.slides as slides

# Presentation 클래스를 인스턴스화합니다
with slides.Presentation() as presentation:
    # 문서 속성 가져오기
    documentProperties = presentation.document_properties

    # 사용자 정의 속성 추가
    documentProperties.set_custom_property_value("New Custom", 12)
    documentProperties.set_custom_property_value("My Nam", "Mudassir")
    documentProperties.set_custom_property_value("Custom", 124)

    # 특정 인덱스의 속성 이름 가져오기
    getPropertyName = documentProperties.get_custom_property_name(2)

    # 선택된 속성 제거
    documentProperties.remove_custom_property(getPropertyName)

    # 프레젠테이션 저장
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **사용자 정의 속성 액세스 및 수정**
Aspose.Slides for Python via .NET은 개발자가 사용자 정의 속성의 값을 액세스할 수 있게 합니다. 아래 예제는 프레젠테이션에 대한 모든 사용자 정의 속성을 액세스하고 수정하는 방법을 보여줍니다.
```py
import aspose.slides as slides

# PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation(path + "AccessModifyingProperties.pptx") as presentation:
    # Presentation와 연결된 document_properties 객체에 대한 참조를 생성합니다
    documentProperties = presentation.document_properties

    # 사용자 정의 속성에 접근하고 수정합니다
    for i in range(documentProperties.count_of_custom_properties):
        # 사용자 정의 속성의 이름과 값을 표시합니다
        print("Custom Property Name : " + documentProperties.get_custom_property_name(i))
        print("Custom Property Value : " + documentProperties.get_custom_property_value[documentProperties.get_custom_property_name(i)])

        # 사용자 정의 속성의 값을 수정합니다
        documentProperties.set_custom_property_value(documentProperties.get_custom_property_name(i), "New Value " + str(i + 1))
    # 프레젠테이션을 파일에 저장합니다
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

## **교정 언어 설정**
Aspose.Slides는 `Language_Id` 속성([PortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/) 클래스에서 노출)을 제공하여 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사가 수행되는 언어입니다.

다음 Python 코드는 PowerPoint의 교정 언어를 설정하는 방법을 보여줍니다.
```python
import aspose.slides as slides

with slides.Presentation(path + "SetProofingLanguage.pptx") as pres:
    auto_shape = pres.slides[0].shapes[0]
    paragraph = auto_shape.text_frame.paragraphs[0]
    paragraph.portions.clear()

    new_portion = slides.Portion()
    font = slides.FontData("SimSun")
    portion_format = new_portion.portion_format
    portion_format.complex_script_font = font
    portion_format.east_asian_font = font
    portion_format.latin_font = font

    # 교정 언어의 Id를 설정합니다
    portion_format.language_id = "zh-CN"
    new_portion.text = "1。"

    paragraph.portions.add(new_portion)
```

## **기본 언어 설정**
다음 Python 코드는 전체 PowerPoint 프레젠테이션의 기본 언어를 설정하는 방법을 보여줍니다:
```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.default_text_language = "en_US"

with slides.Presentation(load_options) as pres:
    shp = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 50, 150, 150)
    text_frame = shp.text_frame
    text_frame.text = "New Text"

    print(text_frame.paragraphs[0].portions[0].portion_format.language_id)
```

## **실시간 예제**
Aspose.Slides API를 통해 문서 속성을 사용하는 방법을 보려면 온라인 앱인 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata)을 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 Built-in 속성을 제거하려면 어떻게 해야 하나요?**

Built-in 속성은 프레젠테이션의 필수 요소이며 완전히 제거할 수 없습니다. 그러나 특정 속성이 허용하는 경우 해당 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 사용자 정의 속성을 추가하면 어떻게 되나요?**

이미 존재하는 사용자 정의 속성을 추가하면 기존 값이 새 값으로 덮어쓰여집니다. 속성을 미리 제거하거나 확인할 필요가 없으며, Aspose.Slides가 자동으로 해당 속성의 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있나요?**

예, [PresentationFactory](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/) 클래스의 [get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/) 메서드를 사용하면 프레젠테이션을 완전히 로드하지 않고도 속성에 접근할 수 있습니다. 그런 다음 [PresentationInfo](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/) 클래스에서 제공하는 [read_document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/read_document_properties/) 메서드를 활용하여 속성을 효율적으로 읽어 메모리를 절약하고 성능을 향상시킬 수 있습니다.