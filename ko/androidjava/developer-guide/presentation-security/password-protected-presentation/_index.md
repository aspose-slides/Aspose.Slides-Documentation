---
title: Android에서 비밀번호로 프레젠테이션을 보호하기
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/androidjava/password-protected-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Java를 통해 Android용 Aspose.Slides로 비밀번호로 보호된 PowerPoint 및 OpenDocument 프레젠테이션을 손쉽게 잠그고 해제합니다. 프레젠테이션을 안전하게 보호하세요."
---
## **소개**

프레젠테이션에 암호 보호를 설정하면, 프레젠테이션에 특정 제한을 적용하는 암호를 설정한다는 의미입니다. 제한을 해제하려면 암호를 입력해야 합니다. 암호로 보호된 프레젠테이션은 잠긴 프레젠테이션으로 간주됩니다.

일반적으로, 프레젠테이션에 이러한 제한을 적용하기 위해 암호를 설정할 수 있습니다:

- **수정**

  특정 사용자만 프레젠테이션을 수정하도록 하려면 수정 제한을 설정할 수 있습니다. 이 제한은 사용자가 암호를 제공하지 않는 한 프레젠테이션의 내용을 수정, 변경 또는 복사하는 것을 방지합니다.

  하지만 이 경우 암호가 없더라도 사용자는 문서에 접근하여 열 수 있습니다. 읽기 전용 모드에서는 사용자가 프레젠테이션 안의 하이퍼링크, 애니메이션, 효과 등 내용을 볼 수 있지만 항목을 복사하거나 프레젠테이션을 저장할 수 없습니다.

- **열기**

  특정 사용자만 프레젠테이션을 열도록 하려면 열기 제한을 설정할 수 있습니다. 이 제한은 사용자가 암호를 제공하지 않는 한 프레젠테이션의 내용을 볼 수조차 없게 합니다.

  기술적으로, 열기 제한은 사용자가 프레젠테이션을 수정하는 것도 방지합니다. 사용자가 프레젠테이션을 열 수 없으면 수정하거나 변경할 수 없습니다.

  **Note** 프레젠테이션을 열지 못하도록 암호 보호를 하면 해당 파일은 암호화됩니다.

## **Aspose.Slides의 프레젠테이션 암호 보호**

**지원되는 형식**

다음 형식의 프레젠테이션에 대해 Aspose.Slides는 암호 보호, 암호화 및 유사한 작업을 지원합니다:

- PPTX 및 PPT - Microsoft PowerPoint 프레젠테이션
- ODP - OpenDocument 프레젠테이션
- OTP - OpenDocument 프레젠테이션 템플릿

**지원되는 작업**

Aspose.Slides를 사용하면 프레젠테이션에 암호 보호를 적용하여 다음과 같이 수정 방지를 할 수 있습니다:

- 프레젠테이션 암호화
- 프레젠테이션에 쓰기 보호 설정

**기타 작업**

Aspose.Slides를 사용하면 암호 보호 및 암호화와 관련된 다른 작업을 다음과 같이 수행할 수 있습니다:

- 프레젠테이션 복호화; 암호화된 프레젠테이션 열기
- 암호화 제거; 암호 보호 비활성화
- 프레젠테이션에서 쓰기 보호 제거
- 암호화된 프레젠테이션의 속성 가져오기
- 프레젠테이션이 암호화되었는지 확인
- 프레젠테이션이 암호로 보호되었는지 확인.

## **프레젠테이션 암호화**

암호를 설정하여 프레젠테이션을 암호화할 수 있습니다. 그런 다음 잠긴 프레젠테이션을 수정하려면 사용자가 암호를 제공해야 합니다.

프레젠테이션을 암호화하거나 암호 보호하려면 [IProtectionManager](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager)의 encrypt 메서드를 사용하여 프레젠테이션에 암호를 설정해야 합니다. 암호를 encrypt 메서드에 전달하고 save 메서드를 사용하여 이제 암호화된 프레젠테이션을 저장합니다.

다음 예제 코드는 프레젠테이션을 암호화하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **프레젠테이션에 쓰기 보호 설정**

프레젠테이션에 “Do not modify”(수정 금지) 표시를 추가할 수 있습니다. 이렇게 하면 사용자가 프레젠테이션을 변경하지 않기를 원한다는 것을 알릴 수 있습니다.

**Note** 쓰기 보호 과정은 프레젠테이션을 암호화하지 않습니다. 따라서 사용자는 실제로 원한다면 프레젠테이션을 수정할 수 있지만, 변경 사항을 저장하려면 다른 이름으로 프레젠테이션을 생성해야 합니다.

쓰기 보호를 설정하려면 [setWriteProtection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) 메서드를 사용해야 합니다. 다음 예제 코드는 프레젠테이션에 쓰기 보호를 설정하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **암호화된 프레젠테이션 로드**

Aspose.Slides를 사용하면 암호와 함께 파일을 전달하여 암호화된 파일을 로드할 수 있습니다. 프레젠테이션을 복호화하려면 매개변수 없이 [removeEncryption](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 메서드를 호출해야 합니다. 그런 다음 올바른 암호를 입력하여 프레젠테이션을 로드합니다.

다음 예제 코드는 프레젠테이션을 복호화하는 방법을 보여줍니다:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션으로 작업
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **프레젠테이션에서 암호화 제거**

프레젠테이션에서 암호화 또는 암호 보호를 제거할 수 있습니다. 이렇게 하면 사용자는 제한 없이 프레젠테이션에 접근하거나 수정할 수 있게 됩니다.

암호화 또는 암호 보호를 제거하려면 [removeEncryption](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager#removeEncryption--) 메서드를 호출해야 합니다. 다음 예제 코드는 프레젠테이션에서 암호화를 제거하는 방법을 보여줍니다:

```java
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

## **프레젠테이션에서 쓰기 보호 제거**

Aspose.Slides를 사용하면 프레젠테이션 파일에 적용된 쓰기 보호를 제거할 수 있습니다. 이렇게 하면 사용자는 원하는 대로 수정할 수 있으며, 해당 작업을 수행할 때 경고가 표시되지 않습니다.

프레젠테이션에서 쓰기 보호를 제거하려면 [removeWriteProtection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager#removeWriteProtection--) 메서드를 사용합니다. 다음 예제 코드는 프레젠테이션에서 쓰기 보호를 제거하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **암호화된 프레젠테이션의 속성 가져오기**

일반적으로 사용자는 암호화되거나 암호로 보호된 프레젠테이션의 문서 속성을 얻는 데 어려움을 겪습니다. 그러나 Aspose.Slides는 프레젠테이션을 암호 보호하면서도 사용자가 해당 프레젠테이션의 속성에 접근할 수 있는 메커니즘을 제공합니다.

**Note** Aspose.Slides가 프레젠테이션을 암호화하면 기본적으로 해당 프레젠테이션의 문서 속성도 암호 보호됩니다. 그러나 프레젠테이션이 암호화된 후에도 속성을 접근 가능하도록 해야 하는 경우, Aspose.Slides를 사용하면 정확히 그렇게 할 수 있습니다.

암호화한 프레젠테이션의 속성에 대한 접근 권한을 사용자에게 유지시키려면 [encryptDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) 속성을 `true` 로 설정하면 됩니다. 다음 예제 코드는 사용자가 문서 속성에 접근할 수 있도록 하면서 프레젠테이션을 암호화하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **프레젠테이션이 암호로 보호되었는지 확인**

프레젠테이션을 로드하기 전에 해당 프레젠테이션이 암호로 보호되지 않았는지 확인하고 확인하고 싶을 수 있습니다. 이렇게 하면 암호가 없는 상태로 암호 보호된 프레젠테이션을 로드할 때 발생하는 오류 및 유사한 문제를 방지할 수 있습니다.

다음 Java 코드는 프레젠테이션을 실제로 로드하지 않고도 암호 보호 여부를 검사하는 방법을 보여줍니다:

```java
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("example.pptx");
System.out.println("The presentation is password protected: " + presentationInfo.isPasswordProtected());
```

## **프레젠테이션이 암호화되었는지 확인**

Aspose.Slides를 사용하면 프레젠테이션이 암호화되었는지 확인할 수 있습니다. 이를 수행하려면 [isEncrypted](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager#isEncrypted--) 속성을 사용할 수 있으며, 프레젠테이션이 암호화된 경우 `true`, 암호화되지 않은 경우 `false` 를 반환합니다.

다음 예제 코드는 프레젠테이션이 암호화되었는지 확인하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **프레젠테이션이 쓰기 보호되었는지 확인**

Aspose.Slides를 사용하면 프레젠테이션이 쓰기 보호되었는지 확인할 수 있습니다. 이를 수행하려면 [isWriteProtected](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IProtectionManager#isWriteProtected--) 속성을 사용할 수 있으며, 프레젠테이션이 쓰기 보호된 경우 `true`, 보호되지 않은 경우 `false` 를 반환합니다.

다음 예제 코드는 프레젠테이션이 쓰기 보호되었는지 확인하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **특정 비밀번호가 사용되었는지 검증 또는 확인**

특정 비밀번호가 프레젠테이션 문서를 보호하는 데 사용되었는지 확인하고 싶을 수 있습니다. Aspose.Slides는 비밀번호를 검증할 수 있는 방법을 제공합니다.

다음 예제 코드는 비밀번호를 검증하는 방법을 보여줍니다:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // "pass"가 일치하는지 확인
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

지정된 비밀번호로 프레젠테이션이 암호화된 경우 `true` 를 반환하고, 그렇지 않으면 `false` 를 반환합니다.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/ko/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**Aspose.Slides에서 지원되는 암호화 방법은 무엇입니까?**

Aspose.Slides는 AES 기반 알고리즘을 포함한 최신 암호화 방식을 지원하여 프레젠테이션의 데이터 보안을 높은 수준으로 보장합니다.

**프레젠테이션을 열려고 할 때 잘못된 비밀번호를 입력하면 어떻게 됩니까?**

잘못된 비밀번호가 사용되면 예외가 발생하여 프레젠테이션 접근이 거부되었음을 알립니다. 이는 무단 접근을 방지하고 프레젠테이션 내용을 보호하는 데 도움이 됩니다.

**암호로 보호된 프레젠테이션을 작업할 때 성능에 영향이 있습니까?**

암호화 및 복호화 과정은 열기 및 저장 작업 중에 약간의 오버헤드를 발생시킬 수 있습니다. 대부분의 경우 이 성능 영향은 미미하며 프레젠테이션 작업의 전체 처리 시간에 크게 영향을 주지 않습니다.