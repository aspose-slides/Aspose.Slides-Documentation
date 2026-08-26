---
title: Java에서 프레젠테이션 비밀번호 보호
linktitle: 비밀번호 보호
type: docs
weight: 20
url: /ko/java/password-protected-presentation/
keywords:
- 비밀번호 보호 프레젠테이션
- 개방 비밀번호
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
- Java
- Aspose.Slides
description: "Aspose.Slides를 사용하여 Java에서 비밀번호 보호된 PowerPoint PPT 및 PPTX 프레젠테이션을 암호화, 감지, 검증, 열기 및 복호화합니다."
---
## **개요**

개방 비밀번호는 프레젠테이션을 암호화합니다. 올바른 비밀번호가 있어야 프레젠테이션 내용을 로드하고 볼 수 있으므로 이 보호는 기밀성을 제공합니다.

개방 비밀번호는 쓰기 보호 비밀번호와 다릅니다. 쓰기 보호는 수정은 제한하지만 내용을 암호화하거나 프레젠테이션 로드를 방지하지는 않습니다. 프레젠테이션 수정용 비밀번호를 관리하려면 [Write-Protect Presentations](/slides/ko/java/write-protected-presentation/)를 참조하세요.

아래 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제에서는 파일 기반 및 스트림 기반 동작이 중요한 경우 두 형식을 모두 사용합니다.

## **개방 비밀번호로 프레젠테이션 암호화**

[IProtectionManager.encrypt](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprotectionmanager/#encrypt-java.lang.String-)을 사용하여 개방 비밀번호를 할당합니다. 그런 다음 [IPresentation.save](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentation/#save-java.lang.String-int-)을 사용하여 암호화된 프레젠테이션을 저장합니다.

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

## **암호화된 프레젠테이션 로드**

[ILoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)을 개방 비밀번호로 설정하고 파일을 로드할 때 해당 옵션을 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/)에 전달합니다. 개방 비밀번호가 필요하지만 제공된 비밀번호가 없거나 올바르지 않으면 로드에 실패합니다.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-pres.pptx", loadOptions);
try {
    // 복호화된 프레젠테이션을 작업합니다.
} finally {
    presentation.dispose();
}
```

## **프레젠테이션에서 암호화 제거**

개방 비밀번호로 프레젠테이션을 로드하고, [IProtectionManager.removeEncryption](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprotectionmanager/#removeEncryption--)을 호출한 뒤 결과를 저장합니다. 저장된 프레젠테이션은 이후 비밀번호 없이 로드할 수 있습니다.

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

## **로드 전에 개방 비밀번호 검증**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-)를 사용하여 전체 프레젠테이션 인스턴스를 생성하지 않고 [IPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/)를 가져옵니다. 비밀번호를 요청하거나 검증하기 전에 [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--)를 확인합니다. 보호가 존재하면 제공된 값을 [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)으로 검증합니다.

### **파일 경로 워크플로**

다음 예제는 PPTX 파일에 대한 개방 비밀번호를 검증하고, 검증된 값을 [ILoadOptions.setPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)에 전달한 뒤 전체 프레젠테이션을 로드합니다:

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

### **스트림 워크플로**

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-)의 스트림 오버로드는 동일한 워크플로를 제공합니다. 스트림에서 전체 프레젠테이션을 로드하기 전에 검색 가능한 스트림의 위치를 재설정합니다.

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

[IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)는 프레젠테이션에 개방 비밀번호가 있고 제공된 비밀번호가 올바른 경우에만 `true`를 반환합니다. 다음 경우에는 `false`를 반환합니다:

- 비밀번호가 올바르지 않습니다.
- 프레젠테이션에 개방 비밀번호가 없습니다.
- 제공된 비밀번호가 `null`이거나 비어 있습니다.

동작은 PPT와 PPTX 프레젠테이션 모두 동일합니다.

## **로드된 프레젠테이션이 암호화되었는지 확인**

올바른 비밀번호로 프레젠테이션을 로드한 후, [IProtectionManager.isEncrypted](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iprotectionmanager/#isEncrypted--)을 확인하여 원본 프레젠테이션이 암호화되었는지 확인합니다. 로드 전에 개방 비밀번호 보호를 탐지하려면 위와 같이 `IPresentationInfo.isPasswordProtected`를 사용합니다.

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

## **보안 권장 사항**

{{% alert color="warning" title="Security" %}}
개방 비밀번호를 로그에 기록하거나 진단 메시지에 포함하지 마세요. 불필요한 반복 검증 시도를 피하고, 비밀번호는 필요한 기간까지만 메모리에 보관하며, 프레젠테이션을 바로 로드할 때는 성공적인 검증 결과를 재사용하십시오.
{{% /alert %}}

## **온라인에서 프레젠테이션에 비밀번호 보호**

1. [Aspose.Slides Lock](https://products.aspose.app/slides/ko/lock) 애플리케이션을 엽니다.
1. 프레젠테이션을 선택하거나 업로드합니다.
1. 보기 보호용 비밀번호를 입력합니다.
1. 필요에 따라 편집 보호용 별도 비밀번호를 입력합니다.
1. 보호를 적용하고 결과 파일을 다운로드합니다.

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/ko/java/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/ko/java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**개방 비밀번호와 쓰기 보호 비밀번호의 차이는 무엇입니까?**

개방 비밀번호는 프레젠테이션을 암호화하며 내용을 로드하기 위해 필요합니다. 쓰기 보호 비밀번호는 내용을 암호화하지 않고 수정만 제한합니다.

**전체 슬라이드를 로드하지 않고 개방 비밀번호를 검증할 수 있나요?**

예. 프레젠테이션 정보를 가져오고, 개방 비밀번호 보호가 존재하는지 확인한 뒤 전체 프레젠테이션 인스턴스를 만들기 전에 비밀번호를 검증합니다.

**비밀번호 검증 워크플로가 PPT와 PPTX 모두를 지원하나요?**

예. 파일 경로 및 스트림 기반 비밀번호 감지와 검증은 PPT와 PPTX 프레젠테이션 모두에서 동일하게 동작합니다.