---
title: Java에서 비밀번호로 프레젠테이션 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/java/password-protected-presentation/
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
- presentation
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 비밀번호로 보호된 PowerPoint 및 OpenDocument 프레젠테이션을 손쉽게 잠그고 해제하는 방법을 알아보세요. 프레젠테이션을 안전하게 보호하세요."
---
## **소개**

프레젠테이션에 암호 보호를 설정하면 프레젠테이션에 특정 제한을 적용하는 암호를 설정하는 것입니다. 이러한 제한을 제거하려면 암호를 입력해야 합니다. 암호로 보호된 프레젠테이션은 잠긴 프레젠테이션으로 간주됩니다.

일반적으로, 프레젠테이션에 이러한 제한을 적용하기 위해 암호를 설정할 수 있습니다:

- **수정**

특정 사용자만 프레젠테이션을 수정하도록 하려면 수정 제한을 설정할 수 있습니다. 이 제한은 암호를 제공하지 않는 한 사용자가 프레젠테이션의 요소를 수정, 변경 또는 복사하는 것을 방지합니다.  

하지만 암호가 없더라도 사용자는 여전히 문서에 접근하고 열 수 있습니다. 읽기 전용 모드에서는 사용자가 프레젠테이션 안의 내용(하이퍼링크, 애니메이션, 효과 및 기타 요소 포함)을 볼 수 있지만 항목을 복사하거나 프레젠테이션을 저장할 수 없습니다.

- **열기**

특정 사용자만 프레젠테이션을 열도록 하려면 열기 제한을 설정할 수 있습니다. 이 제한은 암호를 제공하지 않으면 사용자가 프레젠테이션 내용을 볼 수 없게 합니다.  

기술적으로, 열기 제한은 사용자가 프레젠테이션을 수정하는 것도 방지합니다—프레젠테이션을 열 수 없으면 수정하거나 변경할 수 없습니다.

**참고:** 열기를 방지하기 위해 프레젠테이션에 암호 보호를 설정하면 프레젠테이션 파일이 암호화됩니다.

## **Aspose.Slides의 암호 보호**
**지원되는 형식**

Aspose.Slides는 다음 형식의 프레젠테이션에 대해 암호 보호, 암호화 및 유사한 작업을 지원합니다: 

- PPTX 및 PPT - Microsoft PowerPoint 프레젠테이션 
- ODP - OpenDocument 프레젠테이션 
- OTP - OpenDocument 프레젠테이션 템플릿 

**지원되는 작업**

Aspose.Slides를 사용하면 다음과 같이 프레젠테이션에 암호 보호를 적용하여 수정을 방지할 수 있습니다:

- 프레젠테이션 암호화
- 프레젠테이션에 쓰기 보호 설정

**기타 작업**

Aspose.Slides를 사용하면 다음과 같이 암호 보호 및 암호화와 관련된 다른 작업을 수행할 수 있습니다:

- 프레젠테이션 복호화; 암호화된 프레젠테이션 열기
- 암호화 제거; 암호 보호 비활성화
- 프레젠테이션에서 쓰기 보호 제거
- 암호화된 프레젠테이션의 속성 가져오기
- 프레젠테이션이 암호화되었는지 확인
- 프레젠테이션이 암호로 보호되었는지 확인.

## **프레젠테이션을 암호로 보호하기**

암호를 설정하여 프레젠테이션을 암호화할 수 있습니다. 그런 다음 잠긴 프레젠테이션을 수정하려면 사용자가 암호를 제공해야 합니다. 

프레젠테이션을 암호화하거나 암호 보호하려면 [IProtectionManager](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IProtectionManager) 의 encrypt 메서드를 사용하여 프레젠테이션에 암호를 설정해야 합니다. 암호를 encrypt 메서드에 전달하고 save 메서드를 사용하여 암호화된 프레젠테이션을 저장합니다. 

다음 샘플 코드는 프레젠테이션을 암호화하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **프레젠테이션에 쓰기 보호 설정**

프레젠테이션에 “수정 금지” 표시를 추가할 수 있습니다. 이렇게 하면 사용자가 프레젠테이션을 변경하지 않도록 알릴 수 있습니다.  

**참고:** 쓰기 보호 과정은 프레젠테이션을 암호화하지 않습니다. 따라서 사용자는 실제로 원한다면 프레젠테이션을 수정할 수 있지만, 변경 사항을 저장하려면 다른 이름으로 프레젠테이션을 생성해야 합니다. 

쓰기 보호를 설정하려면 [setWriteProtection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 메서드를 사용해야 합니다. 다음 샘플 코드는 프레젠테이션에 쓰기 보호를 설정하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **암호화된 프레젠테이션 로드하기**

Aspose.Slides를 사용하면 [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/) 를 통해 올바른 암호를 전달하여 암호화된 프레젠테이션을 로드할 수 있습니다. 

다음 샘플 코드는 암호화된 프레젠테이션을 로드하는 방법을 보여줍니다: 

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션 작업
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **프레젠테이션에서 암호화 제거하기**

프레젠테이션의 암호화 또는 암호 보호를 제거할 수 있습니다. 이렇게 하면 사용자는 제한 없이 프레젠테이션에 접근하거나 수정할 수 있습니다. 

암호화 또는 암호 보호를 제거하려면 [removeEncryption](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IProtectionManager#removeEncryption--) 메서드를 호출해야 합니다. 다음 샘플 코드는 프레젠테이션에서 암호화를 제거하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **프레젠테이션에서 쓰기 보호 제거하기**

Aspose.Slides를 사용하여 프레젠테이션 파일에 적용된 쓰기 보호를 제거할 수 있습니다. 이를 통해 사용자는 자유롭게 수정할 수 있으며, 작업 시 경고가 표시되지 않습니다.

프레젠테이션에서 쓰기 보호를 제거하려면 [removeWriteProtection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) 메서드를 사용합니다. 다음 샘플 코드는 프레젠테이션에서 쓰기 보호를 제거하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **암호화된 프레젠테이션의 속성 가져오기**

일반적으로 사용자는 암호화되었거나 암호로 보호된 프레젠테이션의 문서 속성을 가져오는 데 어려움을 겪습니다. 그러나 Aspose.Slides는 프레젠테이션을 암호 보호하면서도 사용자가 속성에 접근할 수 있는 메커니즘을 제공합니다. 

**참고:** 기본적으로 Aspose.Slides가 프레젠테이션을 암호화하면 해당 프레젠테이션의 문서 속성도 암호 보호됩니다. 암호화 후에도 문서 속성에 접근할 수 있도록 하려면 Aspose.Slides를 사용하면 가능합니다. 

사용자가 암호화된 프레젠테이션의 속성에 접근할 수 있도록 하려면 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 에 `false` 를 전달합니다. 다음 샘플 코드는 프레젠테이션을 암호화하면서도 사용자에게 문서 속성 접근을 허용하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **암호화된 프레젠테이션에서 문서 속성만 로드하기**

슬라이드나 기타 콘텐츠를 로드하지 않고 암호화된 프레젠테이션의 메타데이터를 검사하려면 [LoadOptions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/loadoptions/) 객체를 생성하고 [setOnlyLoadDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setOnlyLoadDocumentProperties-boolean-) 에 `true` 를 전달합니다. 이 모드에서는 Aspose.Slides가 암호를 무시하고 공개적으로 접근 가능한 문서 속성만 로드합니다.

다음 코드 예제는 [IPresentation.getDocumentProperties](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#getDocumentProperties--) 를 통해 기본 및 사용자 정의 문서 속성을 읽습니다:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setOnlyLoadDocumentProperties(true);

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    IDocumentProperties documentProperties = presentation.getDocumentProperties();

    // 내장 문서 속성을 읽습니다.
    System.out.println("Title: " + documentProperties.getTitle());
    System.out.println("Author: " + documentProperties.getAuthor());

    // 사용자 정의 문서 속성을 읽습니다.
    int customPropertyCount = documentProperties.getCountOfCustomProperties();

    for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++) {
        String propertyName = documentProperties.getCustomPropertyName(propertyIndex);
        Object propertyValue = documentProperties.get_Item(propertyName);

        System.out.println(propertyName + ": " + propertyValue);
    }
} finally {
    presentation.dispose();
}
```

이 워크플로는 프레젠테이션을 암호화할 때 문서 속성이 암호화되지 않은(공개) 경우에만 작동합니다. 문서 속성이 암호화된 경우 `loadOptions.setOnlyLoadDocumentProperties` 에 `true` 를 전달하면 이 모드에서 암호가 무시되기 때문에 예외가 발생합니다. 암호화된 문서 속성에 접근하거나 슬라이드 및 기타 콘텐츠를 포함한 전체 프레젠테이션을 로드하려면 [ILoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-) 를 통해 올바른 암호를 제공하십시오.

## **프레젠테이션이 암호로 보호되었는지 확인하기**

프레젠테이션을 로드하기 전에 해당 프레젠테이션이 암호로 보호되지 않았는지 확인하고자 할 수 있습니다. 이렇게 하면 암호 보호된 프레젠테이션을 암호 없이 로드할 때 발생하는 오류 및 유사한 문제를 방지할 수 있습니다.

다음 Java 코드는 프레젠테이션을 실제로 로드하지 않고 암호 보호 여부를 검사하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **프레젠테이션이 암호화되었는지 확인하기**

Aspose.Slides를 사용하면 프레젠테이션이 암호화되었는지 확인할 수 있습니다. 이를 위해 [isEncrypted](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IProtectionManager#isEncrypted--) 속성을 사용할 수 있으며, 프레젠테이션이 암호화된 경우 `true`, 암호화되지 않은 경우 `false` 를 반환합니다. 

다음 샘플 코드는 프레젠테이션이 암호화되었는지 확인하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **프레젠테이션이 쓰기 보호되었는지 확인하기**

Aspose.Slides를 사용하면 프레젠테이션이 쓰기 보호되었는지 확인할 수 있습니다. 이를 위해 [isWriteProtected](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IProtectionManager#isWriteProtected--) 속성을 사용할 수 있으며, 쓰기 보호된 경우 `true`, 그렇지 않은 경우 `false` 를 반환합니다. 

다음 샘플 코드는 프레젠테이션이 쓰기 보호되었는지 확인하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **특정 암호가 사용되었는지 검증 또는 확인하기**

프레젠테이션 문서를 보호하는 데 특정 암호가 사용되었는지 확인하고 싶을 수 있습니다. Aspose.Slides는 암호를 검증할 수 있는 방법을 제공합니다. 

다음 샘플 코드는 암호를 검증하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass"와 일치하는지 확인
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

지정된 암호로 프레젠테이션이 쓰기 보호된 경우 `true` 를 반환하고, 그렇지 않으면 `false` 를 반환합니다. 

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ko/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides에서 지원하는 암호화 방법은 무엇입니까?**

Aspose.Slides는 AES 기반 알고리즘을 포함한 최신 암호화 방식을 지원하여 프레젠테이션 데이터 보안을 높은 수준으로 유지합니다.

**프레젠테이션을 열 때 잘못된 암호를 입력하면 어떻게 됩니까?**

잘못된 암호를 사용하면 예외가 발생하여 프레젠테이션 접근이 거부되었음을 알립니다. 이는 무단 접근을 방지하고 프레젠테이션 내용을 보호하는 데 도움이 됩니다.

**암호 보호된 프레젠테이션을 사용할 때 성능에 영향을 미치나요?**

암호화 및 복호화 과정은 열기 및 저장 작업 시 약간의 오버헤드를 발생시킬 수 있습니다. 대부분의 경우 이 성능 영향은 최소 수준이며 프레젠테이션 작업 전체 처리 시간에 큰 영향을 주지 않습니다.