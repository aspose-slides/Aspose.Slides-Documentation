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
description: "Aspose.Slides for .NET를 사용하여 VBA를 통해 PowerPoint 및 OpenDocument 프레젠테이션을 생성하고 조작하는 방법을 알아보고 워크플로를 간소화하세요."
---
## **소개**

[Aspose.Slides.Vba](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/) 네임스페이스에는 매크로 및 VBA 코드를 다루기 위한 클래스와 인터페이스가 포함되어 있습니다.

{{% alert title="Note" color="warning" %}} 
프레젠테이션에 매크로가 포함된 상태에서 다른 파일 형식(PDF, HTML 등)으로 변환하면 Aspose.Slides는 모든 매크로를 무시합니다(매크로가 결과 파일에 포함되지 않습니다).

프레젠테이션에 매크로를 추가하거나 매크로가 포함된 프레젠테이션을 다시 저장하면 Aspose.Slides는 매크로 바이트를 그대로 기록합니다.

Aspose.Slides **절대** 프레젠테이션의 매크로를 실행하지 않습니다.
{{% /alert %}}

## **VBA 매크로 추가**

Aspose.Slides는 VBA 프로젝트(및 프로젝트 참조)를 만들고 기존 모듈을 편집할 수 있도록 [VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/vbaproject/) 클래스를 제공합니다. 프레젠테이션에 포함된 VBA를 관리하려면 [IVbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/ivbaproject/) 인터페이스를 사용할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.
2. [VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) 생성자를 사용하여 새 VBA 프로젝트를 추가합니다.
3. VbaProject에 모듈을 추가합니다.
4. 모듈 소스 코드를 설정합니다.
5. <stdole>에 대한 참조를 추가합니다.
6. **Microsoft Office**에 대한 참조를 추가합니다.
7. 해당 참조를 VBA 프로젝트와 연결합니다.
8. 프레젠테이션을 저장합니다.

다음 C# 코드는 프레젠테이션에 VBA 매크로를 처음부터 추가하는 방법을 보여줍니다:

```c#
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
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 
무료 웹 앱인 **Aspose** [Macro Remover](https://products.aspose.app/slides/ko/remove-macros)를 사용하면 PowerPoint, Excel 및 Word 문서에서 매크로를 제거할 수 있습니다. 
{{% /alert %}} 

## **VBA 매크로 제거**
[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 [VbaProject](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/vbaproject/) 속성을 사용하여 VBA 매크로를 제거할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 매크로 모듈에 접근하여 이를 제거합니다.
3. 수정된 프레젠테이션을 저장합니다.

다음 C# 코드는 VBA 매크로를 제거하는 방법을 보여줍니다:

```c#
    // 매크로가 포함된 프레젠테이션을 로드합니다
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Vba 모듈에 접근하여 제거합니다
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // 프레젠테이션을 저장합니다
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **VBA 매크로 추출**
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
3. VBA 프로젝트에 포함된 모든 모듈을 순회하면서 매크로를 확인합니다.

다음 C# 코드는 매크로가 포함된 프레젠테이션에서 VBA 매크로를 추출하는 방법을 보여줍니다:

```c#
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

[IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) 속성을 사용하면 프로젝트 속성이 암호로 보호되어 있는지 여부를 판단할 수 있습니다.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 프레젠테이션에 [VBA 프로젝트](https://reference.aspose.com/slides/ko/net/aspose.slides.vba/vbaproject/)가 있는지 확인합니다.
3. VBA 프로젝트가 암호로 보호되어 있는지 확인하여 해당 속성을 확인합니다.

```cs
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

**프레젠테이션을 PPTX 형식으로 저장하면 매크로는 어떻게 되나요?**  
PPTX는 VBA를 지원하지 않으므로 매크로가 제거됩니다. 매크로를 유지하려면 PPTM, PPSM 또는 POTM 형식을 선택하십시오.

**Aspose.Slides가 프레젠테이션 내부에서 매크로를 실행하여 예를 들어 데이터를 새로 고칠 수 있나요?**  
아니오. 이 라이브러리는 VBA 코드를 절대 실행하지 않으며, 실행은 적절한 보안 설정이 된 PowerPoint 내부에서만 가능합니다.

**VBA 코드와 연결된 ActiveX 컨트롤 작업이 지원되나요?**  
예, 기존 [ActiveX controls](/slides/ko/net/activex/)에 접근하고 속성을 수정하거나 제거할 수 있습니다. 이는 매크로가 ActiveX와 상호 작용할 때 유용합니다.