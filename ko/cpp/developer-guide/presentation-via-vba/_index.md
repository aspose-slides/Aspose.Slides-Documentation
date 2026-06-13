---
title: C++를 사용하여 프레젠테이션에서 VBA 프로젝트 관리
linktitle: VBA를 통한 프레젠테이션
type: docs
weight: 250
url: /ko/cpp/presentation-via-vba/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++를 사용하여 VBA를 통해 PowerPoint 및 OpenDocument 프레젠테이션을 생성하고 조작하는 방법을 알아보고 작업 흐름을 간소화하세요."
---
## **소개**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/ko/cpp/namespace/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

프레젠테이션에 매크로가 포함된 상태로 다른 파일 형식(PDF, HTML 등)으로 변환하면 Aspose.Slides는 모든 매크로를 무시합니다(매크로가 결과 파일에 포함되지 않습니다).

프레젠테이션에 매크로를 추가하거나 매크로가 포함된 프레젠테이션을 다시 저장하면 Aspose.Slides는 매크로 바이트만 기록합니다.

Aspose.Slides는 **절대** 프레젠테이션의 매크로를 실행하지 않습니다.

{{% /alert %}}

## **VBA 매크로 추가**

Aspose.Slides는 VBA 프로젝트(및 프로젝트 참조)를 생성하고 기존 모듈을 편집할 수 있도록 [VbaProject](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.vba.vba_project) 클래스를 제공합니다. 프레젠테이션에 포함된 VBA를 관리하려면 [IVbaProject](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.vba.i_vba_project/) 인터페이스를 사용할 수 있습니다.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.vba.vba_project#a01b7a0287df8a75f2f8d85185f3e197b) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This C++ code shows you how to add a VBA macro from scratch to a presentation: 

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/AddVBAMacros_out.pptm";

// 프레젠테이션 클래스의 인스턴스를 생성합니다
SharedPtr<Presentation> presentation = MakeObject<Presentation>();
// 새 VBA 프로젝트를 생성합니다
presentation->set_VbaProject(MakeObject<VbaProject>());

// VBA 프로젝트에 빈 모듈을 추가합니다
SharedPtr<IVbaModule> module = presentation->get_VbaProject()->get_Modules()->AddEmptyModule(u"Module");

// 모듈 소스 코드를 설정합니다
module->set_SourceCode(u"Sub Test(oShape As Shape) MsgBox \"Test\" End Sub");

// <stdole>에 대한 참조를 생성합니다
SharedPtr<VbaReferenceOleTypeLib> stdoleReference =
	MakeObject<VbaReferenceOleTypeLib>(u"stdole", u"*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

// Office에 대한 참조를 생성합니다
SharedPtr<VbaReferenceOleTypeLib> officeReference =
	MakeObject<VbaReferenceOleTypeLib>(u"Office", u"*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

// VBA 프로젝트에 참조를 추가합니다
presentation->get_VbaProject()->get_References()->Add(stdoleReference);
presentation->get_VbaProject()->get_References()->Add(officeReference);

// 프레젠테이션을 저장합니다
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

{{% alert color="primary" %}} 

무료 웹 앱인 **Aspose** [Macro Remover](https://products.aspose.app/slides/ko/remove-macros)를 사용하면 PowerPoint, Excel 및 Word 문서에서 매크로를 제거할 수 있습니다. 

{{% /alert %}} 

## **VBA 매크로 제거**

[Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) 클래스 아래의 [VbaProject](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation#ac9554082a2ac5ed57adf6012c90da5f4) 속성을 사용하여 VBA 매크로를 제거할 수 있습니다.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This C++ code shows you how to remove a VBA macro: 

```c++
// 문서 디렉터리 경로.
const String outPath = u"../out/RemoveVBAMacros_out.pptm";
const String templatePath = u"../templates/vba.pptm";

// 매크로가 포함된 프레젠테이션을 로드합니다
SharedPtr<Presentation> presentation = MakeObject<Presentation>(templatePath);

// Vba 모듈에 접근하여 제거합니다 
presentation->get_VbaProject()->get_Modules()->Remove(presentation->get_VbaProject()->get_Modules()->idx_get(0));

// 프레젠테이션을 저장합니다
presentation->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptm);
```

## **VBA 매크로 추출**

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/cpp/class/aspose.slides.presentation) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This C++ code shows you how to extract VBA macros from a presentation containing macros: 

```c++

	// 문서 디렉터리 경로.
	const String templatePath = u"../templates/VBA.pptm";

	// 매크로가 포함된 프레젠테이션을 로드합니다
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);


	if (pres->get_VbaProject() != NULL) // 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다
	{
		
		//for (SharedPtr<IVbaModule> module : pres->get_VbaProject()->get_Modules())
		for (int i = 0; i < pres->get_VbaProject()->get_Modules()->get_Count(); i++)
		{
			SharedPtr<IVbaModule> module = pres->get_VbaProject()->get_Modules()->idx_get(i);

			System::Console::WriteLine(module->get_Name());
			System::Console::WriteLine(module->get_SourceCode());
		}
	}
```

## **VBA 프로젝트가 비밀번호로 보호되어 있는지 확인**

[IVbaProject::get_IsPasswordProtected](https://reference.aspose.com/slides/ko/cpp/aspose.slides.vba/ivbaproject/get_ispasswordprotected/) 속성을 사용하면 프로젝트 속성이 비밀번호로 보호되어 있는지 판단할 수 있습니다.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/ko/cpp/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/ko/cpp/aspose.slides.vba/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```cpp
auto presentation = MakeObject<Presentation>(u"VBA.pptm");
    
if (presentation->get_VbaProject() != nullptr) // 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
{
    if (presentation->get_VbaProject()->get_IsPasswordProtected())
    {
        Console::WriteLine(u"The VBA Project '{0}' is protected by password to view project properties.", presentation->get_VbaProject()->get_Name());
    }
}
    
presentation->Dispose();
```

## **FAQ**

**프레젠테이션을 PPTX로 저장하면 매크로는 어떻게 되나요?**

PPTX는 VBA를 지원하지 않으므로 매크로가 제거됩니다. 매크로를 유지하려면 PPTM, PPSM 또는 POTM을 선택하세요.

**Aspose.Slides가 프레젠테이션 내부에서 매크로를 실행하여 예를 들어 데이터를 새로 고칠 수 있나요?**

아니요. 이 라이브러리는 VBA 코드를 절대 실행하지 않으며, 실행은 적절한 보안 설정을 가진 PowerPoint 내부에서만 가능합니다.

**VBA 코드와 연결된 ActiveX 컨트롤 작업이 지원되나요?**

예, 기존 [ActiveX controls](/slides/ko/cpp/activex/)에 접근하고 속성을 수정하거나 제거할 수 있습니다. 이는 매크로가 ActiveX와 상호 작용할 때 유용합니다.