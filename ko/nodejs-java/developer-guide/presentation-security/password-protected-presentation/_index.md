---
title: JavaScript에서 프레젠테이션 비밀번호 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/nodejs-java/password-protected-presentation/
keywords:
- 비밀번호로 보호된 프레젠테이션
- 오프닝 비밀번호
- PowerPoint 암호화
- PowerPoint 복호화
- 프레젠테이션 비밀번호 검증
- 프레젠테이션 비밀번호 확인
- 암호화된 프레젠테이션 열기
- 암호화 제거
- PowerPoint
- PPT
- PPTX
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides를 사용하여 JavaScript에서 비밀번호로 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화, 감지, 검증, 열기 및 복호화합니다."
---
## **개요**

오프닝 비밀번호는 프레젠테이션을 암호화합니다. 올바른 비밀번호가 있어야 프레젠테이션 내용을 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

오프닝 비밀번호는 쓰기 보호 비밀번호와 다릅니다. 쓰기 보호는 수정은 제한하지만 내용을 암호화하거나 프레젠테이션 로드를 방지하지 않습니다. 프레젠테이션 수정용 비밀번호를 관리하려면 [프레젠테이션 쓰기 보호](/slides/ko/nodejs-java/write-protected-presentation/)를 참조하십시오.

아래 워크플로는 PPT 및 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **오프닝 비밀번호로 프레젠테이션 암호화**

오프닝 비밀번호를 할당하려면 [ProtectionManager.encrypt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#encrypt)을 사용하십시오. 그런 다음 [Presentation.save](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#save)을 사용하여 암호화된 프레젠테이션을 저장합니다.

다음 예제는 PPTX 프레젠테이션을 암호화합니다:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **문서 속성 공개 유지**

기본적으로 Aspose.Slides는 문서 속성을 프레젠테이션 암호화에 포함합니다. [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) 메서드는 슬라이드 내용 암호화와 별도로 이 동작을 제어합니다. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 오프닝 비밀번호 없이 메타데이터를 읽어야 할 때는 [ProtectionManager.encrypt](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#encrypt) 호출 전에 `false`를 전달하십시오.

다음 예제는 내장 문서 속성을 공개 상태로 유지하면서 암호화된 PPTX 프레젠테이션을 생성합니다:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false`를 [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties)에 전달해도 슬라이드, 마스터, 레이아웃, 셰이프, 미디어 또는 기타 프레젠테이션 내용이 공개되는 것은 아닙니다. 이는 오직 문서 속성에만 영향을 줍니다. 암호화된 내용을 로드하지 않고 해당 속성을 읽으려면 [프레젠테이션 속성 관리](/slides/ko/nodejs-java/presentation-properties/)를 참조하십시오.

## **암호화된 프레젠테이션 로드**

파일을 로드할 때 오프닝 비밀번호를 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setPassword)으로 설정하고 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)에 전달하십시오. 오프닝 비밀번호가 필요하지만 제공된 비밀번호가 없거나 올바르지 않으면 로드에 실패합니다.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션으로 작업합니다.
} finally {
    presentation.dispose();
}
```

## **프레젠테이션 암호 해제**

오프닝 비밀번호로 프레젠테이션을 로드한 다음 [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#removeEncryption)을 호출하고 결과를 저장하십시오. 저장된 프레젠테이션은 이제 비밀번호 없이 로드할 수 있습니다.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **로드 전 오프닝 비밀번호 검증**

[PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo)를 사용하여 전체 프레젠테이션 인스턴스를 만들지 않고 [PresentationInfo](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/)를 가져옵니다. 비밀번호를 요청하거나 검증하기 전에 [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected)를 확인하십시오. 보호가 존재하면 제공된 값을 [PresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/#checkPassword)으로 검증합니다.

### **파일 경로 워크플로**

다음 예제는 PPTX 파일에 대한 오프닝 비밀번호를 검증하고, 검증된 값을 [LoadOptions.setPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/#setPassword)에 전달한 후 전체 프레젠테이션을 로드합니다:

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "protected-presentation.pptx";
const password = "open_password";
const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    console.log("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    console.log("The opening password is incorrect.");
} else {
    const loadOptions = new slides.LoadOptions();
    loadOptions.setPassword(password);

    const presentation = new slides.Presentation(filePath, loadOptions);
    try {
        console.log("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **스트림 워크플로**

[PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream)를 사용하여 Node.js 읽기 가능한 스트림을 검사합니다. 검사 스트림이 소비된 후에는 [Presentation.createPresentationFromStream](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/#createPresentationFromStream)으로 전체 프레젠테이션을 로드하기 전에 새 스트림을 생성하십시오.

다음 예제는 PPT 파일을 사용합니다:

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");

const filePath = "protected-presentation.ppt";
const password = "open_password";
const presentationFactory = slides.PresentationFactory.getInstance();
const infoStream = fs.createReadStream(filePath);

slides.PresentationFactory.getPresentationInfoFromStream(presentationFactory, infoStream, function(infoError, presentationInfo) {
    if (infoError) {
        console.log("The presentation information could not be read: " + infoError.message);
    } else if (!presentationInfo.isPasswordProtected()) {
        console.log("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        console.log("The opening password is incorrect.");
    } else {
        const loadOptions = new slides.LoadOptions();
        loadOptions.setPassword(password);
        const presentationStream = fs.createReadStream(filePath);

        slides.Presentation.createPresentationFromStream(presentationStream, loadOptions, function(loadError, presentation) {
            if (loadError) {
                console.log("The presentation could not be loaded: " + loadError.message);
            } else {
                try {
                    console.log("The presentation was validated and loaded successfully.");
                } finally {
                    presentation.dispose();
                }
            }
        });
    }
});
```

### **checkPassword 반환 값**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/#checkPassword)는 프레젠테이션에 오프닝 비밀번호가 있고 제공된 비밀번호가 올바른 경우에만 `true`를 반환합니다. 다음 경우엔 모두 `false`를 반환합니다:

- 비밀번호가 올바르지 않은 경우.
- 프레젠테이션에 오프닝 비밀번호가 없는 경우.
- 제공된 비밀번호가 `null`이거나 비어 있는 경우.

PPT와 PPTX 프레젠테이션 모두에 동작이 동일합니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 비밀번호로 프레젠테이션을 로드한 후 [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/#isEncrypted)를 검사하여 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드 전에 오프닝 비밀번호 보호를 감지하려면 위에서 설명한 대로 [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentationinfo/#isPasswordProtected)를 사용하십시오.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const isEncrypted = presentation.getProtectionManager().isEncrypted();
    console.log("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **보안 권장 사항**

{{% alert color="warning" title="보안" %}}
오프닝 비밀번호를 로그에 기록하거나 진단 메시지에 포함하지 마십시오. 불필요한 반복 검증 시도를 피하고, 비밀번호는 필요할 때만 메모리에 보관하며, 프레젠테이션을 즉시 로드할 경우 성공적인 검증 결과를 재사용하십시오.

프레젠테이션 내용이 암호화되어 있어도 공개 문서 속성은 저자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 사용자 정의 값 등을 노출할 수 있습니다. 중요한 메타데이터는 프레젠테이션과 함께 암호화하십시오. 속성을 공개하는 것은 파일을 오프닝 비밀번호 없이 인덱싱, 분류, 검색 또는 관리해야 하는 경우에만 명시적인 결정으로 해야 합니다.
{{% /alert %}}

## **온라인에서 프레젠테이션에 비밀번호 보호**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
1. 프레젠테이션을 선택하거나 업로드합니다.
1. 보기 보호를 위한 비밀번호를 입력합니다.
1. 필요에 따라 편집 보호를 위한 별도 비밀번호를 입력합니다.
1. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="참고" %}}
- [프레젠테이션 쓰기 보호](/slides/ko/nodejs-java/write-protected-presentation/)
- [PowerPoint 디지털 서명](/slides/ko/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**오프닝 비밀번호와 쓰기 보호 비밀번호의 차이점은 무엇인가요?**

오프닝 비밀번호는 프레젠테이션을 암호화하고 내용을 로드하는 데 필요합니다. 쓰기 보호 비밀번호는 내용을 암호화하지 않고 수정만 제한합니다.

**모든 슬라이드를 로드하지 않고 오프닝 비밀번호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 가져오고, 오프닝 비밀번호 보호가 있는지 확인한 뒤, 전체 프레젠테이션 인스턴스를 만들기 전에 비밀번호를 검증합니다.

**오프닝 비밀번호 없이 메타데이터를 읽을 수 있나요?**

예, 단지 문서 속성 암호화가 비활성화된 상태로 프레젠테이션이 암호화된 경우에만 가능합니다. 애플리케이션은 [프레젠테이션 속성 관리](/slides/ko/nodejs-java/presentation-properties/)에 설명된 문서 속성만 로드하는 모드를 사용해야 합니다.

**비밀번호 검증 워크플로는 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로 및 스트림 기반 비밀번호 검사와 검증은 PPT와 PPTX 프레젠테이션에서 동일하게 동작합니다.