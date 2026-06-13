---
title: Python을 사용한 프레젠테이션에서 VBA 프로젝트 관리
linktitle: VBA를 통한 프레젠테이션
type: docs
weight: 250
url: /ko/python-net/presentation-via-vba/
keywords:
- 매크로
- VBA
- VBA 매크로
- 매크로 추가
- 매크로 제거
- 매크로 추출
- VBA 추가
- VBA 제거
- VBA 추출
- PowerPoint
- OpenDocument
- 프레젠테이션
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 VBA로 PowerPoint 및 OpenDocument 프레젠테이션을 생성하고 조작하는 방법을 알아보고 작업 흐름을 간소화하세요."
---
## **개요**

이 문서는 PowerPoint 프레젠테이션에서 매크로 작업을 위한 Aspose.Slides for Python via .NET의 주요 기능을 살펴봅니다. 이 라이브러리는 매크로를 추가, 제거 및 추출하기 위한 편리한 도구를 제공하여 프레젠테이션의 생성 및 수정 작업을 자동화할 수 있습니다.

- 프레젠테이션 개발 가속화—일상적인 작업 자동화를 통해 자료 준비에 필요한 시간을 줄입니다.
- 유연성 보장—매크로 관리 기능을 통해 특정 작업 및 시나리오에 맞게 프레젠테이션을 맞춤화할 수 있습니다.
- 데이터 통합—외부 데이터 소스와의 간편한 연동으로 슬라이드 내용을 최신 상태로 유지할 수 있습니다.
- 유지보수 간소화—중앙 집중식 매크로 관리로 변경 적용 및 프레젠테이션 업데이트가 쉬워집니다.

이 문서에서는 Aspose.Slides를 사용하여 PowerPoint에서 매크로를 효과적으로 활용하는 실용적인 예제를 제공합니다.

[aspose.slides.vba](https://reference.aspose.com/slides/ko/python-net/aspose.slides.vba/) 네임스페이스는 매크로 및 VBA 코드를 작업하기 위한 클래스를 제공합니다.

{{% alert title="Note" color="warning" %}}
매크로가 포함된 프레젠테이션을 다른 형식(PDF, HTML 등)으로 변환할 경우, Aspose.Slides는 매크로를 무시합니다—출력 파일에 매크로가 전달되지 않습니다.

프레젠테이션에 매크로를 추가하거나 매크로가 포함된 프레젠테이션을 다시 저장하면, Aspose.Slides는 매크로 바이트를 그대로 기록합니다.

Aspose.Slides는 프레젠테이션 내 매크로를 **절대** 실행하지 않습니다.
{{% /alert %}}

## **VBA 매크로 추가**

Aspose.Slides는 VBA 프로젝트(및 프로젝트 참조)를 생성하고 기존 모듈을 편집하기 위해 [VbaProject](https://reference.aspose.com/slides/ko/python-net/aspose.slides.vba/vbaproject/) 클래스를 제공합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [VbaProject](https://reference.aspose.com/slides/ko/python-net/aspose.slides.vba/vbaproject/#constructors) 생성자를 사용하여 새 VBA 프로젝트를 추가합니다.
3. VBA 프로젝트에 모듈을 추가합니다.
4. 모듈의 소스 코드를 설정합니다.
5. `<stdole>`에 대한 참조를 추가합니다.
6. **Microsoft Office**에 대한 참조를 추가합니다.
7. 참조를 VBA 프로젝트와 연결합니다.
8. 프레젠테이션을 저장합니다.

다음 Python 코드는 처음부터 프레젠테이션에 VBA 매크로를 추가하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# Presentation 클래스의 인스턴스를 생성합니다.
with slides.Presentation() as presentation:

    # 새 VBA 프로젝트를 생성합니다.
    presentation.vba_project = slides.vba.VbaProject()

    # VBA 프로젝트에 빈 모듈을 추가합니다.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # 모듈 소스 코드를 설정합니다.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # <stdole>에 대한 참조를 생성합니다.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Microsoft Office에 대한 참조를 생성합니다.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # VBA 프로젝트에 참조를 추가합니다.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # 프레젠테이션을 저장합니다.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
**Aspose** [Macro Remover](https://products.aspose.app/slides/ko/remove-macros) 를 시도해 보세요. PowerPoint, Excel 및 Word 문서에서 매크로를 제거하는 무료 웹 앱입니다.
{{% /alert %}}

## **VBA 매크로 제거**

[vba_project](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/vba_project/) 속성을 사용하여 VBA 매크로를 제거할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 매크로 모듈에 접근하여 제거합니다.
3. 수정된 프레젠테이션을 저장합니다.

다음 Python 코드는 VBA 매크로를 제거하는 방법을 보여줍니다:

```python
import aspose.slides as slides

# 매크로가 포함된 프레젠테이션을 로드합니다.
with slides.Presentation("VBA.pptm") as presentation:
    
    # VBA 모듈에 접근합니다.
    vba_module = presentation.vba_project.modules[0]

    # VBA 모듈을 제거합니다.
    presentation.vba_project.modules.remove(vba_module)

    # 프레젠테이션을 저장합니다.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **VBA 매크로 추출**

[VbaProject](https://reference.aspose.com/slides/ko/python-net/aspose.slides.vba/vbaproject/) 클래스의 `modules` 속성을 사용하여 VBA 프로젝트의 모든 모듈에 접근할 수 있습니다. [VbaModule](https://reference.aspose.com/slides/ko/python-net/aspose.slides.vba/vbamodule/) 클래스를 사용하여 모듈 이름 및 코드를 비롯한 속성을 추출할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
3. VBA 프로젝트의 모든 모듈을 순회하여 매크로를 확인합니다.

다음 Python 코드는 프레젠테이션에서 VBA 매크로를 추출하는 방법을 보여줍니다:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **VBA 프로젝트가 암호로 보호되는지 확인**

[VbaProject.is_password_protected](https://reference.aspose.com/slides/ko/python-net/aspose.slides.vba/vbaproject/is_password_protected/) 속성을 사용하여 프로젝트 속성이 암호로 보호되는지 확인할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 프레젠테이션에 [VBA project](https://reference.aspose.com/slides/ko/python-net/aspose.slides.vba/vbaproject/)가 포함되어 있는지 확인합니다.
3. VBA 프로젝트가 암호로 보호되는지 확인하여 속성을 확인합니다.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **FAQ**

**프레젠테이션을 PPTX로 저장하면 매크로가 어떻게 되나요?**  
PPTX는 VBA를 지원하지 않으므로 매크로가 제거됩니다. 매크로를 유지하려면 PPTM, PPSM 또는 POTM을 선택하십시오.

**예를 들어 데이터를 새로 고치기 위해 프레젠테이션 내부에서 매크로를 실행할 수 있나요?**  
아니요. 이 라이브러리는 VBA 코드를 절대 실행하지 않으며, 실행은 적절한 보안 설정이 된 PowerPoint 내부에서만 가능합니다.

**VBA 코드와 연결된 ActiveX 컨트롤 작업이 지원되나요?**  
예, 기존 [ActiveX controls](/slides/ko/python-net/activex/)에 접근하고 속성을 수정하거나 제거할 수 있습니다. 매크로가 ActiveX와 상호 작용할 때 유용합니다.