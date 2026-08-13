---
title: .NET에서 프레젠테이션의 VBA 프로젝트 관리
linktitle: VBA를 통한 프레젠테이션
type: docs
weight: 250
url: /ko/net/presentation-via-vba/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 VBA로 PowerPoint 및 OpenDocument 프레젠테이션을 생성하고 조작하는 방법을 알아보아 워크플로를 효율화하십시오."
---
## **소개**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **VBA 매크로 추가**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/ivbaproject/) interface to manage VBA embedded in a presentation.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. [VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) 생성자를 사용하여 새 VBA 프로젝트를 추가합니다.  
3. VbaProject에 모듈을 추가합니다.  
4. 모듈 소스 코드를 설정합니다.  
5. <stdole>에 대한 참조를 추가합니다.  
6. **Microsoft Office**에 대한 참조를 추가합니다.  
7. 해당 참조를 VBA 프로젝트와 연결합니다.  
8. 프레젠테이션을 저장합니다.

This C# code shows you how to add a VBA macro from scratch to a presentation:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// 프레젠테이션 클래스의 인스턴스를 생성합니다
using (Presentation presentation = new Presentation())
{
    // 새 VBA 프로젝트를 생성합니다
    presentation.VbaProject = new VbaProject();

    // VBA 프로젝트에 빈 모듈을 추가합니다
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // 모듈 소스 코드를 설정합니다
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // <stdole>에 대한 참조를 생성합니다
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office에 대한 참조를 생성합니다
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA 프로젝트에 참조를 추가합니다
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // 프레젠테이션을 저장합니다
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/ko/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **VBA 매크로 제거**
Using the [VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/vbaproject/) property under the [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.  
2. 매크로 모듈에 접근하여 제거합니다.  
3. 수정된 프레젠테이션을 저장합니다.

This C# code shows you how to remove a VBA macro:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 매크로가 포함된 프레젠테이션을 로드합니다
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Vba 모듈에 접근하여 제거합니다
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // 프레젠테이션을 저장합니다
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA 매크로 추출**
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.  
2. 프레젠테이션이 VBA 프로젝트를 포함하고 있는지 확인합니다.  
3. VBA 프로젝트에 포함된 모든 모듈을 순회하여 매크로를 확인합니다.

This C# code shows you how to extract VBA macros from a presentation containing macros:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // 매크로가 포함된 프레젠테이션을 로드합니다
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **VBA 프로젝트가 암호로 보호되는지 확인**

Using the [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.  
2. 프레젠테이션이 [VBA project](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/vbaproject/)를 포함하고 있는지 확인합니다.  
3. VBA 프로젝트가 암호로 보호되어 있는지 확인하여 해당 속성을 조회합니다.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

### 프레젠테이션을 PPTX 형식으로 저장하면 매크로는 어떻게 되나요?

매크로는 제거됩니다. PPTX는 VBA를 지원하지 않기 때문입니다. 매크로를 유지하려면 PPTM, PPSM 또는 POTM을 선택하십시오.

### Aspose.Slides가 프레젠테이션 내부의 매크로를 실행하여 예를 들어 데이터를 새로 고칠 수 있나요?

없습니다. 라이브러리는 VBA 코드를 전혀 실행하지 않으며, 실행은 적절한 보안 설정이 적용된 PowerPoint 내에서만 가능합니다.

### VBA 코드와 연결된 ActiveX 컨트롤 작업이 지원되나요?

예, 기존 [ActiveX controls](/slides/ko/net/activex/)에 접근하고 속성을 수정하며 제거할 수 있습니다. 이는 매크로가 ActiveX와 상호 작용할 때 유용합니다.