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
description: "Aspose.Slides for Python via .NET에서 프레젠테이션 속성을 마스터하고 PowerPoint 파일에서 검색, 브랜딩 및 워크플로를 간소화합니다."
---
## **소개**

Aspose.Slides는 두 종류의 문서 속성을 지원합니다: **Built-in** 및 **Custom**. 이러한 속성 유형은 Aspose.Slides API를 사용하여 쉽게 액세스하고 관리할 수 있습니다.

Aspose.Slides를 사용하면 [DocumentProperties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/documentproperties/) 클래스를 통해 프레젠테이션 문서 속성을 작업할 수 있습니다. 이 클래스의 인스턴스는 [Presentation.document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/document_properties/) 속성에서 반환됩니다. 다음 예제에서는 이러한 속성을 읽고, 수정하고, 관리하는 방법을 보여줍니다.

{{% alert color="info" title="Note" %}}
참고: **Application** 및 **Producer** 필드에는 값을 설정할 수 없습니다. Aspose Ltd.와 Aspose.Slides for Python via .NET x.x.x가 해당 필드에 표시되기 때문입니다.
{{% /alert %}} 

## **프레젠테이션 속성 관리**

Microsoft PowerPoint는 프레젠테이션 파일에 몇 가지 속성을 추가할 수 있는 기능을 제공합니다. 이러한 문서 속성을 통해 문서(프레젠테이션 파일)와 함께 유용한 정보를 저장할 수 있습니다. 문서 속성은 다음과 같이 두 종류가 있습니다.

- 시스템 정의 (Built-in) 속성
- 사용자 정의 (Custom) 속성

**Built-in** 속성은 문서 제목, 저자 이름, 문서 통계 등 일반 정보를 포함합니다. **Custom** 속성은 사용자가 **이름/값** 쌍으로 정의한 것으로, 이름과 값 모두 사용자가 정의합니다. Aspose.Slides for Python via .NET를 사용하면 개발자는 Built-in 속성뿐만 아니라 Custom 속성의 값을 액세스하고 수정할 수 있습니다. Microsoft PowerPoint 2007은 프레젠테이션 파일의 문서 속성을 관리할 수 있도록 합니다. Office 아이콘을 클릭하고 **Prepare | Properties | Advanced Properties** 메뉴 항목을 선택하면 됩니다. **Advanced Properties** 메뉴 항목을 선택하면 PowerPoint 파일의 문서 속성을 관리할 수 있는 대화 상자가 나타납니다. **Properties Dialog**에는 **General**, **Summary**, **Statistics**, **Contents**, **Custom**과 같은 여러 탭 페이지가 있으며, 각 탭은 PowerPoint 파일과 관련된 다양한 정보를 구성할 수 있게 해줍니다. **Custom** 탭은 PowerPoint 파일의 사용자 정의 속성을 관리하는 데 사용됩니다.

## **Built-in 속성 액세스**
이러한 속성은 **IDocumentProperties** 객체에서 제공되며 다음을 포함합니다: **Creator(Author)**, **Description**, **Keywords**, **Created**(작성 날짜), **Modified**(수정 날짜), **Printed**(마지막 인쇄 날짜), **LastModifiedBy**, **Keywords**, **SharedDoc**(다른 제작자와 공유되는가?), **PresentationFormat**, **Subject**, **Title**
```py
import aspose.slides as slides

# 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation("AccessBuiltin Properties.pptx") as pres:
    # Presentation와 연결된 객체에 대한 참조를 생성합니다
    documentProperties = pres.document_properties

    # 기본 속성을 표시합니다
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
프레젠테이션 파일의 Built-in 속성을 수정하는 것은 액세스하는 것만큼 쉽습니다. 원하는 속성에 문자열 값을 할당하면 해당 속성 값이 수정됩니다. 아래 예제에서는 프레젠테이션 파일의 Built-in 문서 속성을 어떻게 수정할 수 있는지 보여줍니다.
```py
import aspose.slides as slides

# 프레젠테이션을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation("ModifyBuiltinProperties.pptx") as presentation:
    # Presentation와 연결된 객체에 대한 참조를 생성합니다
    documentProperties = presentation.document_properties

    # 기본 속성을 설정합니다
    documentProperties.author = "Aspose.Slides for .NET"
    documentProperties.title = "Modifying Presentation Properties"
    documentProperties.subject = "Aspose Subject"
    documentProperties.comments = "Aspose Description"
    documentProperties.manager = "Aspose Manager"

    # 프레젠테이션을 파일에 저장합니다
    presentation.save("DocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **맞춤 프레젠테이션 속성 추가**
Aspose.Slides for Python via .NET는 개발자가 프레젠테이션 문서 속성에 맞춤 값을 추가하도록 허용합니다. 아래 예제는 프레젠테이션에 맞춤 속성을 설정하는 방법을 보여줍니다.
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

    # 선택한 속성 제거
    documentProperties.remove_custom_property(getPropertyName)

    # 프레젠테이션 저장
    presentation.save("CustomDocumentProperties_out.pptx", slides.export.SaveFormat.PPTX)
```

## **맞춤 속성 액세스 및 수정**
Aspose.Slides for Python via .NET는 개발자가 맞춤 속성의 값을 액세스하도록 허용합니다. 아래 예제는 프레젠테이션에 대한 모든 맞춤 속성을 어떻게 액세스하고 수정할 수 있는지 보여줍니다.
```py
import aspose.slides as slides

# PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation("AccessModifyingProperties.pptx") as presentation:
    # 프레젠테이션과 연결된 document_properties 객체에 대한 참조를 생성합니다
    documentProperties = presentation.document_properties

    # 사용자 정의 속성에 접근하고 수정합니다
    for i in range(documentProperties.count_of_custom_properties):
        property_name = documentProperties.get_custom_property_name(i)

        # 사용자 정의 속성의 이름과 값을 표시합니다
        property_value = [""]
        documentProperties.get_custom_property_value(property_name, property_value)
        print("Custom Property Name : " + property_name)
        print("Custom Property Value : " + property_value[0])

        # 사용자 정의 속성의 값을 수정합니다
        documentProperties.set_custom_property_value(property_name, "New Value " + str(i + 1))
    # 프레젠테이션을 파일에 저장합니다
    presentation.save("CustomDemoModified_out.pptx", slides.export.SaveFormat.PPTX)
```

`get_custom_property_value`는 두 번째 인수로 전달된 한 요소 리스트를 통해 값을 반환하며, 저장된 값은 해당 리스트에 이미 존재하는 요소의 유형으로 캐스트됩니다. 위 예제는 `[""]`를 사용하므로 문자열 속성을 읽습니다; 숫자로 저장된 속성을 읽으려면 `[0]`과 같은 숫자 자리표시자를 전달하십시오—그렇지 않으면 호출이 `InvalidCastException`을 발생시킵니다.

## **교정 언어 설정**
Aspose.Slides는 `Language_Id` 속성([PortionFormat](https://reference.aspose.com/slides/ko/python-net/aspose.slides/portionformat/) 클래스에 노출됨)을 제공하여 PowerPoint 문서의 교정 언어를 설정할 수 있게 합니다. 교정 언어는 PowerPoint에서 맞춤법 및 문법 검사를 수행하는 언어를 의미합니다.

다음 Python 코드는 PowerPoint에 교정 언어를 설정하는 방법을 보여줍니다:
```python
import aspose.slides as slides

with slides.Presentation("SetProofingLanguage.pptx") as pres:
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
다음 Python 코드는 전체 PowerPoint 프레젠테이션에 대한 기본 언어를 설정하는 방법을 보여줍니다:
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

Aspose.Slides API를 통해 문서 속성을 작업하는 방법을 확인하려면 온라인 앱 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/ko/metadata)을 사용해 보세요:

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/ko/metadata)

## **FAQ**

**프레젠테이션에서 Built-in 속성을 제거하려면 어떻게 해야 하나요?**

Built-in 속성은 프레젠테이션의 필수 요소이며 완전히 제거할 수 없습니다. 다만 특정 속성이 허용한다면 값을 변경하거나 빈 값으로 설정할 수 있습니다.

**이미 존재하는 맞춤 속성을 추가하면 어떻게 되나요?**

이미 존재하는 맞춤 속성을 추가하면 기존 값이 새로운 값으로 덮어써집니다. 속성을 미리 제거하거나 확인할 필요 없이 Aspose.Slides가 자동으로 값을 업데이트합니다.

**프레젠테이션을 완전히 로드하지 않고 속성에 접근할 수 있나요?**

예, 가능합니다. [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationfactory/get_presentation_info/)를 사용한 다음 [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentationinfo/read_document_properties/)를 호출하면 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 인스턴스를 만들지 않고 저장된 문서 메타데이터를 읽을 수 있습니다. 전체 보고 예제와 형식별 제한 사항은 [Build a Lightweight Presentation Inventory](/slides/ko/python-net/examine-presentation/)를 참고하세요.