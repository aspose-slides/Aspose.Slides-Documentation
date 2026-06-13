---
title: JavaScript를 사용하여 프레젠테이션에서 VBA 프로젝트 관리
linktitle: VBA를 통한 프레젠테이션
type: docs
weight: 250
url: /ko/nodejs-java/presentation-via-vba/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 Java로 JavaScript에서 VBA를 통해 PowerPoint 및 OpenDocument 프레젠테이션을 생성하고 조작하여 작업 흐름을 효율화합니다."
---
## **소개**

Aspose.Slides는 매크로 및 VBA 코드를 다루는 클래스를 제공합니다.

{{% alert title="Note" color="warning" %}} 

매크로가 포함된 프레젠테이션을 다른 파일 형식(PDF, HTML 등)으로 변환할 경우, Aspose.Slides는 모든 매크로를 무시합니다(매크로는 결과 파일에 포함되지 않습니다).

프레젠테이션에 매크로를 추가하거나 매크로가 포함된 프레젠테이션을 다시 저장할 경우, Aspose.Slides는 단순히 매크로의 바이트를 기록합니다.

Aspose.Slides는 프레젠테이션의 매크로를 **절대** 실행하지 않습니다.

{{% /alert %}}

## **VBA 매크로 추가**

Aspose.Slides는 VBA 프로젝트(및 프로젝트 참조)를 생성하고 기존 모듈을 편집할 수 있는 [VbaProject](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/vbaproject/) 클래스를 제공합니다. 이 클래스를 사용하여 프레젠테이션에 포함된 VBA를 관리할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성합니다.
1. VbaProject 생성자를 사용하여 새로운 VBA 프로젝트를 추가합니다.
1. VbaProject에 모듈을 추가합니다.
1. 모듈의 소스 코드를 설정합니다.
1. <stdole>에 대한 참조를 추가합니다.
1. Microsoft Office에 대한 참조를 추가합니다.
1. 참조를 VBA 프로젝트와 연결합니다.
1. 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 처음부터 프레젠테이션에 VBA 매크로를 추가하는 방법을 보여줍니다:

```javascript
// 프레젠테이션 클래스의 인스턴스를 생성합니다
let pres = new aspose.slides.Presentation();
try {
    // 새 VBA 프로젝트를 생성합니다
    pres.setVbaProject(new aspose.slides.VbaProject());
    // VBA 프로젝트에 빈 모듈을 추가합니다
    let module = pres.getVbaProject().getModules().addEmptyModule("Module");
    // 모듈 소스 코드를 설정합니다
    module.setSourceCode("Sub Test(oShape As Shape)MsgBox Test End Sub");
    // <stdole>에 대한 참조를 생성합니다
    let stdoleReference = new aspose.slides.VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");
    // Office에 대한 참조를 생성합니다
    let officeReference = new aspose.slides.VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");
    // VBA 프로젝트에 참조를 추가합니다
    pres.getVbaProject().getReferences().add(stdoleReference);
    pres.getVbaProject().getReferences().add(officeReference);
    // 프레젠테이션을 저장합니다
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

무료 웹 앱으로 PowerPoint, Excel, Word 문서에서 매크로를 제거할 수 있는 Aspose **Macro Remover**를 확인해 보세요. 

{{% /alert %}} 

## **VBA 매크로 제거**

Presentation 클래스 아래의 VbaProject 속성을 사용하여 VBA 매크로를 제거할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
1. Macro 모듈에 접근하여 이를 제거합니다.
1. 수정된 프레젠테이션을 저장합니다.

다음 JavaScript 코드는 VBA 매크로를 제거하는 방법을 보여줍니다:

```javascript
// 매크로가 포함된 프레젠테이션을 로드합니다
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // Vba 모듈에 접근하고 이를 제거합니다
    pres.getVbaProject().getModules().remove(pres.getVbaProject().getModules().get_Item(0));
    // 프레젠테이션을 저장합니다
    pres.save("test.pptm", aspose.slides.SaveFormat.Pptm);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **VBA 매크로 추출**

1. Presentation 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 프레젠테이션에 VBA 프로젝트가 있는지 확인합니다.
3. VBA 프로젝트에 포함된 모든 모듈을 순회하여 매크로를 확인합니다.

다음 JavaScript 코드는 매크로가 포함된 프레젠테이션에서 VBA 매크로를 추출하는 방법을 보여줍니다:

```javascript
// 매크로가 포함된 프레젠테이션을 로드합니다
let pres = new aspose.slides.Presentation("VBA.pptm");
try {
    // 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다
    if (pres.getVbaProject() != null) {
        for (let i = 0; i < pres.getVbaProject().getModules().size(); i++) {
            let module = pres.getVbaProject().getModules().get_Item(i);
            console.log(module.getName());
            console.log(module.getSourceCode());
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **VBA 프로젝트 비밀번호 보호 여부 확인**

VbaProject.isPasswordProtected 메서드를 사용하여 프로젝트 속성이 비밀번호로 보호되는지 확인할 수 있습니다.

1. Presentation 클래스의 인스턴스를 생성하고 매크로가 포함된 프레젠테이션을 로드합니다.
2. 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
3. VBA 프로젝트가 비밀번호로 보호되는지 확인하여 속성을 확인합니다.

```js
let presentation = new aspose.slides.Presentation("VBA.pptm");
try {
    if (presentation.getVbaProject() != null) { // 프레젠테이션에 VBA 프로젝트가 포함되어 있는지 확인합니다.
        if (presentation.getVbaProject().isPasswordProtected()) {
            console.log("The VBA Project '%s' is protected by password to view project properties.", 
                    presentation.getVbaProject().getName());
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**프레젠테이션을 PPTX 형식으로 저장하면 매크로는 어떻게 되나요?**

PPTX는 VBA를 지원하지 않으므로 매크로가 제거됩니다. 매크로를 유지하려면 PPTM, PPSM 또는 POTM 형식을 선택하세요.

**Aspose.Slides가 프레젠테이션 내 매크로를 실행하여 예를 들어 데이터를 새로 고칠 수 있나요?**

아니요. 이 라이브러리는 VBA 코드를 실행하지 않으며, 실행은 적절한 보안 설정이 된 PowerPoint 내부에서만 가능합니다.

**VBA 코드와 연결된 ActiveX 컨트롤을 다루는 것이 지원되나요?**

예, 기존 ActiveX 컨트롤에 접근하고, 속성을 수정하며, 제거할 수 있습니다. 이는 매크로가 ActiveX와 상호 작용할 때 유용합니다.