---
title: JavaScript에서 비밀번호로 프레젠테이션 보호하기
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/nodejs-java/password-protected-presentation/
keywords:
- PowerPoint 잠금
- 프레젠테이션 잠금
- PowerPoint 잠금 해제
- 프레젠테이션 잠금 해제
- PowerPoint 보호
- 프레젠테이션 보호
- 비밀번호 설정
- 비밀번호 추가
- PowerPoint 암호화
- 프레젠테이션 암호화
- PowerPoint 복호화
- 프레젠테이션 복호화
- 쓰기 보호
- PowerPoint 보안
- 프레젠테이션 보안
- 비밀번호 제거
- 보호 제거
- 암호화 제거
- 비밀번호 비활성화
- 보호 비활성화
- 쓰기 보호 제거
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 이용하여 Java로 비밀번호로 보호된 PowerPoint 및 OpenDocument 프레젠테이션을 손쉽게 잠그고 해제하세요. 프레젠테이션을 안전하게 보호합니다."
---
## **소개**

프레젠테이션에 암호를 설정하면 해당 프레젠테이션에 특정 제한을 적용하는 암호를 설정하는 것입니다. 제한을 해제하려면 암호를 입력해야 합니다. 암호로 보호된 프레젠테이션은 잠긴 프레젠테이션으로 간주됩니다.

일반적으로 프레젠테이션에 이러한 제한을 적용하기 위해 암호를 설정할 수 있습니다:

- **수정**

  특정 사용자만 프레젠테이션을 수정하도록 허용하려면 수정 제한을 설정할 수 있습니다. 이 제한은 사용자가 암호를 제공하지 않는 한 프레젠테이션을 수정·변경·복사하는 것을 방지합니다.

  그러나 이 경우 암호가 없더라도 사용자는 문서에 접근하여 열 수 있습니다. 읽기 전용 모드에서는 사용자가 프레젠테이션 내부의 하이퍼링크, 애니메이션, 효과 등 내용을 볼 수 있지만 항목을 복사하거나 프레젠테이션을 저장할 수 없습니다.

- **열기**

  특정 사용자만 프레젠테이션을 열 수 있도록 하려면 열기 제한을 설정할 수 있습니다. 이 제한은 사용자가 암호를 제공하지 않는 한 프레젠테이션 내용을 볼 수도 없게 합니다.

  기술적으로, 열기 제한은 사용자가 프레젠테이션을 열 수 없게 함으로써 수정도 불가능하게 합니다. 사용자가 프레젠테이션을 열 수 없으면 변경하거나 수정할 수 없습니다.

  **Note** 프레젠테이션을 열지 못하도록 암호를 설정하면 파일이 암호화됩니다.

## **온라인에서 프레젠테이션에 암호 보호 적용 방법**

1. 우리 [**Aspose.Slides Lock**](https://products.aspose.app/slides/ko/lock) 페이지로 이동합니다.  

   ![todo:image_alt_text](slides-lock.png)

2. **Drop or upload your files**를 클릭합니다.

3. 컴퓨터에서 암호로 보호할 파일을 선택합니다.

4. 편집 보호용으로 원하는 암호를 입력하고; 보기 보호용으로 원하는 암호를 입력합니다.

5. 사용자가 프레젠테이션을 최종 사본으로 보게 하려면 **Mark as final** 체크박스를 선택합니다.

6. **PROTECT NOW.**를 클릭합니다.

7. **DOWNLOAD NOW.**를 클릭합니다.

## **Aspose.Slides의 프레젠테이션 암호 보호**
**지원 형식**

Aspose.Slides는 다음 형식의 프레젠테이션에 대해 암호 보호, 암호화 및 유사한 작업을 지원합니다:

- PPTX 및 PPT - Microsoft PowerPoint 프레젠테이션  
- ODP - OpenDocument 프레젠테이션  
- OTP - OpenDocument 프레젠테이션 템플릿  

**지원 작업**

Aspose.Slides를 사용하면 다음과 같은 방법으로 프레젠테이션 수정 방지를 위한 암호 보호를 적용할 수 있습니다:

- 프레젠테이션 암호화  
- 프레젠테이션에 쓰기 보호 설정  

**기타 작업**

Aspose.Slides를 사용하면 다음과 같은 방법으로 암호 보호 및 암호화와 관련된 기타 작업을 수행할 수 있습니다:

- 프레젠테이션 암호 해제; 암호화된 프레젠테이션 열기  
- 암호화 제거; 암호 보호 해제  
- 프레젠테이션에서 쓰기 보호 제거  
- 암호화된 프레젠테이션의 속성 가져오기  
- 프레젠테이션이 암호화되었는지 확인하기  
- 프레젠테이션이 암호 보호되었는지 확인하기.

## **프레젠테이션 암호화**

암호를 설정하여 프레젠테이션을 암호화할 수 있습니다. 그러면 잠긴 프레젠테이션을 수정하려면 사용자가 암호를 제공해야 합니다.

프레젠테이션을 암호화하거나 암호 보호하려면 [ProtectionManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ProtectionManager)의 encrypt 메서드를 사용하여 프레젠테이션에 암호를 설정합니다. 암호를 encrypt 메서드에 전달하고 save 메서드로 이제 암호화된 프레젠테이션을 저장합니다.

다음 샘플 코드는 프레젠테이션을 암호화하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **프레젠테이션에 쓰기 보호 설정**

프레젠테이션에 “수정 금지” 표시를 추가할 수 있습니다. 이렇게 하면 사용자가 프레젠테이션을 변경하지 말아야 함을 알릴 수 있습니다.

**Note** 쓰기 보호 과정은 프레젠테이션을 암호화하지 않습니다. 따라서 사용자는 실제로 원하는 경우 프레젠테이션을 수정할 수 있지만, 변경 사항을 저장하려면 다른 이름으로 파일을 저장해야 합니다.

쓰기 보호를 설정하려면 [setWriteProtection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ProtectionManager#setWriteProtection-java.lang.String-) 메서드를 사용합니다. 다음 샘플 코드는 프레젠테이션에 쓰기 보호를 설정하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **프레젠테이션 암호 해제; 암호화된 프레젠테이션 열기**

Aspose.Slides는 암호를 전달하여 암호화된 파일을 로드할 수 있게 합니다. 프레젠테이션을 암호 해제하려면 매개변수가 없는 [removeEncryption](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) 메서드를 호출해야 합니다. 그런 다음 올바른 암호를 입력해 프레젠테이션을 로드합니다.

다음 샘플 코드는 프레젠테이션을 암호 해제하는 방법을 보여줍니다:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션 작업
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **암호화 제거; 암호 보호 비활성화**

프레젠테이션에서 암호화 또는 암호 보호를 제거할 수 있습니다. 이렇게 하면 사용자가 제한 없이 프레젠테이션에 접근하거나 수정할 수 있게 됩니다.

암호화 또는 암호 보호를 제거하려면 [removeEncryption](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ProtectionManager#removeEncryption--) 메서드를 호출합니다. 다음 샘플 코드는 프레젠테이션에서 암호화를 제거하는 방법을 보여줍니다:

```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("123123");
var presentation = new aspose.slides.Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **프레젠테이션에서 쓰기 보호 제거**

Aspose.Slides를 사용해 프레젠테이션 파일에 적용된 쓰기 보호를 제거할 수 있습니다. 이렇게 하면 사용자는 자유롭게 수정할 수 있고, 해당 작업에 대한 경고가 표시되지 않습니다.

[removeWriteProtection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ProtectionManager#removeWriteProtection--) 메서드를 사용해 쓰기 보호를 제거합니다. 다음 샘플 코드는 프레젠테이션에서 쓰기 보호를 제거하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **암호화된 프레젠테이션의 속성 가져오기**

일반적으로 사용자는 암호화되거나 암호 보호된 프레젠테이션의 문서 속성을 조회하는 데 어려움을 겪습니다. 그러나 Aspose.Slides는 프레젠테이션을 암호 보호하면서도 사용자가 속성에 접근할 수 있는 메커니즘을 제공합니다.

**Note:** 기본적으로 Aspose.Slides가 프레젠테이션을 암호화하면 해당 프레젠테이션의 문서 속성도 암호 보호됩니다. 암호화 후에도 문서 속성에 접근하도록 하려면 Aspose.Slides에서 이를 지원합니다.

암호화된 프레젠테이션의 속성에 접근하도록 허용하려면 [ProtectionManager](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/)의 `setEncryptDocumentProperties`에 `false`를 전달합니다. 다음 샘플 코드는 암호화하면서도 문서 속성에 접근할 수 있게 하는 방법을 보여줍니다:

```javascript
const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **암호화된 프레젠테이션에서 문서 속성만 로드하기**

슬라이드나 기타 콘텐츠를 로드하지 않고 암호화된 프레젠테이션의 메타데이터만 검사하려면 [LoadOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/) 객체를 생성하고 `setOnlyLoadDocumentProperties`에 `true`를 전달합니다. 이 모드에서는 Aspose.Slides가 암호를 무시하고 공개적으로 접근 가능한 문서 속성만 로드합니다.

다음 코드 예제는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/)의 `getDocumentProperties`를 통해 기본 및 사용자 정의 문서 속성을 읽는 방법을 보여줍니다:

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

const presentation = new aspose.slides.Presentation("encrypted-pres.pptx", loadOptions);
try {
    const documentProperties = presentation.getDocumentProperties();

    // 내장 문서 속성을 읽습니다.
    console.log("Title: " + documentProperties.getTitle());
    console.log("Author: " + documentProperties.getAuthor());

    // 사용자 정의 문서 속성을 읽습니다.
    const customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (let propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        const propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        const propertyValue = documentProperties.get_Item(propertyName);

        console.log(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

이 워크플로는 프레젠테이션을 암호화할 때 문서 속성이 암호화되지 않고 공개 상태로 남겨졌을 때만 작동합니다. 문서 속성이 암호화된 경우 `LoadOptions.setOnlyLoadDocumentProperties`에 `true`를 전달하면 암호가 무시되기 때문에 예외가 발생합니다. 암호화된 문서 속성에 접근하거나 슬라이드와 기타 콘텐츠를 포함한 전체 프레젠테이션을 로드하려면 [LoadOptions](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/)의 `setPassword`에 올바른 암호를 제공하십시오.

## **프레젠테이션을 로드하기 전에 암호 보호 여부 확인하기**

프레젠테이션을 로드하기 전에 해당 프레젠테이션이 암호로 보호되지 않았는지 확인하고 싶을 수 있습니다. 이렇게 하면 암호가 없는 상태에서 암호 보호된 프레젠테이션을 로드하려 할 때 발생하는 오류와 유사한 문제를 방지할 수 있습니다.

다음 JavaScript 코드는 프레젠테이션을 실제로 로드하지 않고도 암호 보호 여부를 검사하는 방법을 보여줍니다:

```javascript
var presentationInfo = aspose.slides.PresentationFactory.getInstance().getPresentationInfo("example.pptx");
console.log("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **프레젠테이션이 암호화되었는지 확인하기**

Aspose.Slides를 사용하면 프레젠테이션이 암호화되었는지 확인할 수 있습니다. 이를 위해 [isEncrypted](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ProtectionManager#isEncrypted--) 속성을 사용합니다. 암호화된 경우 `true`, 그렇지 않으면 `false`를 반환합니다.

다음 샘플 코드는 프레젠테이션이 암호화되었는지 확인하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **프레젠테이션이 쓰기 보호되었는지 확인하기**

Aspose.Slides를 사용하면 프레젠테이션이 쓰기 보호되었는지 확인할 수 있습니다. 이를 위해 [isWriteProtected](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/ProtectionManager#isWriteProtected--) 속성을 사용합니다. 쓰기 보호된 경우 `true`, 그렇지 않으면 `false`를 반환합니다.

다음 샘플 코드는 프레젠테이션이 쓰기 보호되었는지 확인하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    var isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **특정 암호가 프레젠테이션 보호에 사용되었는지 검증하거나 확인하기**

특정 암호가 프레젠테이션 문서를 보호하는 데 사용되었는지 확인하고 싶을 수 있습니다. Aspose.Slides는 암호를 검증할 수 있는 수단을 제공합니다.

다음 샘플 코드는 암호를 검증하는 방법을 보여줍니다:

```javascript
var presentation = new aspose.slides.Presentation("pres.pptx");
try {
    // "pass"와 일치하는지 확인
    var isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

암호가 일치하면 `true`를 반환하고, 그렇지 않으면 `false`를 반환합니다.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ko/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides에서 지원하는 암호화 방식은 무엇인가요?**

Aspose.Slides는 최신 AES 기반 알고리즘을 포함한 현대적인 암호화 방식을 지원하여 프레젠테이션 데이터 보안을 높은 수준으로 유지합니다.

**프레젠테이션을 열 때 잘못된 암호를 입력하면 어떻게 되나요?**

잘못된 암호가 사용되면 예외가 발생하여 프레젠테이션에 대한 접근이 거부되었음을 알립니다. 이를 통해 무단 접근을 방지하고 내용이 보호됩니다.

**암호 보호된 프레젠테이션을 작업할 때 성능에 영향을 미치나요?**

암호화 및 복호화 과정이 열기 및 저장 시 약간의 오버헤드를 발생시킬 수 있습니다. 대부분의 경우 이 영향은 미미하여 전체 처리 시간에 큰 영향을 주지 않습니다.