---
title: Android에서 프레젠테이션 비밀번호 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/androidjava/password-protected-presentation/
keywords:
- 비밀번호 보호 프레젠테이션
- 열기 비밀번호
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android을 사용하여 Java로 비밀번호 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화하고, 탐지하고, 검증하고, 열고, 복호화합니다."
---
## **개요**

열기 비밀번호는 프레젠테이션을 암호화합니다. 올바른 비밀번호가 있어야 프레젠테이션 내용을 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

열기 비밀번호는 쓰기 보호 비밀번호와 다릅니다. 쓰기 보호는 수정은 제한하지만 내용을 암호화하거나 프레젠테이션 로드를 방지하지 않습니다. 프레젠테이션 수정용 비밀번호를 관리하려면 [프레젠테이션 쓰기 보호](/slides/ko/androidjava/write-protected-presentation/)를 참조하십시오.

아래 워크플로우는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **열기 비밀번호로 프레젠테이션 암호화**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-)을 사용하여 열기 비밀번호를 할당합니다. 그런 다음 [IPresentation.save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-)을 사용하여 암호화된 프레젠테이션을 저장합니다.

다음 예제는 PPTX 프레젠테이션을 암호화합니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **문서 속성 공개 유지**

기본적으로 Aspose.Slides는 프레젠테이션 암호화에 문서 속성을 포함합니다. [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-) 메서드는 슬라이드 내용 암호화와 별도로 이 동작을 제어합니다. 인덱싱, 분류, 검색 또는 문서 관리 시스템이 열기 비밀번호 없이 메타데이터를 읽어야 할 경우 [IProtectionManager.encrypt](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-)을 호출하기 전에 `false`를 전달합니다.

다음 예제는 내장된 문서 속성을 공개 상태로 유지하면서 암호화된 PPTX 프레젠테이션을 생성합니다:

```java
import com.aspose.slides.IDocumentProperties;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation();
try {
    IDocumentProperties properties = presentation.getDocumentProperties();
    properties.setAuthor("Contoso Knowledge Management");
    properties.setTitle("Quarterly Product Roadmap");
    properties.setKeywords("roadmap, planning, internal");

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content");
    presentation.getProtectionManager().setEncryptDocumentProperties(false);
    presentation.getProtectionManager().encrypt("open_password");
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

`false`를 [IProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#setEncryptDocumentProperties-boolean-)에 전달해도 슬라이드, 마스터, 레이아웃, 도형, 미디어 또는 기타 프레젠테이션 내용이 공개되는 것은 아닙니다. 이는 오직 문서 속성에만 영향을 줍니다. 암호화된 내용을 로드하지 않고 해당 속성을 읽으려면 [프레젠테이션 속성 관리](/slides/ko/androidjava/presentation-properties/)를 참조하십시오.

## **암호화된 프레젠테이션 로드**

파일을 로드할 때 열기 비밀번호를 [ILoadOptions.setPassword](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)에 설정하고 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/)에 전달합니다. 열기 비밀번호가 필요하지만 제공된 비밀번호가 없거나 올바르지 않을 경우 로드가 실패합니다.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션으로 작업합니다.
} finally {
    presentation.dispose();
}
```

## **프레젠테이션 암호화 제거**

열기 비밀번호로 프레젠테이션을 로드한 다음 [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#removeEncryption--)을 호출하고 결과를 저장합니다. 저장된 프레젠테이션은 이제 비밀번호 없이 로드할 수 있습니다.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **로드 전에 열기 비밀번호 검증**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-)를 사용하여 전체 프레젠테이션 인스턴스를 만들지 않고 [IPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/)를 가져옵니다. 비밀번호를 요청하거나 검증하기 전에 [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)를 확인합니다. 보호가 존재하면 제공된 값을 [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)으로 검증합니다.

### **파일 경로 워크플로우**

다음 예제는 PPTX 파일에 대한 열기 비밀번호를 검증하고, 검증된 값을 [ILoadOptions.setPassword](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)에 전달한 뒤 전체 프레젠테이션을 로드합니다:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;

String filePath = "protected-presentation.pptx";
String password = "open_password";
IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(filePath);

if (!presentationInfo.isPasswordProtected()) {
    System.out.println("The presentation does not have an opening password.");
} else if (!presentationInfo.checkPassword(password)) {
    System.out.println("The opening password is incorrect.");
} else {
    LoadOptions loadOptions = new LoadOptions();
    loadOptions.setPassword(password);

    Presentation presentation = new Presentation(filePath, loadOptions);
    try {
        System.out.println("The presentation was validated and loaded successfully.");
    } finally {
        presentation.dispose();
    }
}
```

### **스트림 워크플로우**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-)의 스트림 오버로드는 동일한 워크플로우를 제공합니다. 해당 스트림에서 전체 프레젠테이션을 로드하기 전에 검색 가능한 스트림의 위치를 재설정합니다.

다음 예제는 PPT 파일을 사용합니다:

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationFactory;
import java.io.FileInputStream;

String password = "open_password";

FileInputStream presentationStream = new FileInputStream("protected-presentation.ppt");
try {
    IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo(presentationStream);

    if (!presentationInfo.isPasswordProtected()) {
        System.out.println("The presentation does not have an opening password.");
    } else if (!presentationInfo.checkPassword(password)) {
        System.out.println("The opening password is incorrect.");
    } else {
        presentationStream.getChannel().position(0);

        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setPassword(password);

        Presentation presentation = new Presentation(presentationStream, loadOptions);
        try {
            System.out.println("The presentation was validated and loaded successfully.");
        } finally {
            presentation.dispose();
        }
    }
} finally {
    presentationStream.close();
}
```

### **checkPassword 반환 값**

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)은 프레젠테이션에 열기 비밀번호가 있고 제공된 비밀번호가 올바른 경우에만 `true`를 반환합니다. 다음과 같은 경우에는 `false`를 반환합니다:

- 비밀번호가 올바르지 않습니다.
- 프레젠테이션에 열기 비밀번호가 없습니다.
- 제공된 비밀번호가 `null`이거나 비어 있습니다.

PPT와 PPTX 프레젠테이션 모두 동작이 동일합니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 비밀번호로 프레젠테이션을 로드한 후 [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#isEncrypted--)을 확인하여 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드 전에 열기 비밀번호 보호를 감지하려면 위와 같이 `IPresentationInfo.isPasswordProtected`를 사용하십시오.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
    System.out.println("The presentation is encrypted: " + isEncrypted);
} finally {
    presentation.dispose();
}
```

## **보안 권고사항**

{{% alert color="warning" title="보안" %}}
열기 비밀번호를 로그에 기록하거나 진단 메시지에 포함하지 마십시오. 불필요한 반복 검증 시도를 피하고, 비밀번호를 필요한 시간만 메모리에 유지하며, 프레젠테이션을 즉시 로드할 때 성공적인 검증 결과를 재사용하십시오.

프레젠테이션 내용이 암호화되어 있어도 공개된 문서 속성은 저자 이름, 제목, 주제, 키워드, 회사 정보, 댓글 및 사용자 지정 값을 노출할 수 있습니다. 민감한 메타데이터를 프레젠테이션과 함께 암호화하십시오. 속성을 공개하는 것은 시스템이 열기 비밀번호 없이 파일을 인덱싱, 분류, 검색 또는 관리해야 할 경우에만 명시적인 결정으로 해야 합니다.
{{% /alert %}}

## **프레젠테이션 온라인으로 비밀번호 보호**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
2. 프레젠테이션을 선택하거나 업로드합니다.
3. 보기 보호용 비밀번호를 입력합니다.
4. 원한다면 편집 보호용 별도 비밀번호를 입력합니다.
5. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="참고" %}}
- [프레젠테이션 쓰기 보호](/slides/ko/androidjava/write-protected-presentation/)
- [PowerPoint 디지털 서명](/slides/ko/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **자주 묻는 질문**

**열기 비밀번호와 쓰기 보호 비밀번호의 차이점은 무엇인가요?**

열기 비밀번호는 프레젠테이션을 암호화하고 내용을 로드하는 데 필요합니다. 쓰기 보호 비밀번호는 내용을 암호화하지 않고 수정을 제한합니다.

**모든 슬라이드를 로드하지 않고 열기 비밀번호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 가져오고, 열기 비밀번호 보호가 있는지 확인한 뒤, 전체 프레젠테이션 인스턴스를 만들기 전에 비밀번호를 검증합니다.

**애플리케이션이 열기 비밀번호 없이 메타데이터를 읽을 수 있나요?**

예, 단 프레젠테이션이 문서 속성 암호화가 비활성화된 상태로 암호화된 경우에만 가능합니다. 이 경우 애플리케이션은 [프레젠테이션 속성 관리](/slides/ko/androidjava/presentation-properties/)에 설명된 문서 속성 전용 로드 모드를 사용해야 합니다.

**비밀번호 검증 워크플로우가 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로 및 스트림 기반 비밀번호 감지와 검증은 PPT와 PPTX 프레젠테이션 모두 동일하게 동작합니다.