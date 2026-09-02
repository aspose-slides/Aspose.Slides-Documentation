---
title: Android에서 프레젠테이션 쓰기 보호
linktitle: 쓰기 보호
type: docs
weight: 25
url: /ko/androidjava/write-protected-presentation/
keywords:
- 쓰기 보호
- PowerPoint 쓰기 보호
- 수정 암호
- 프레젠테이션 편집 제한
- 쓰기 보호 제거
- 수정 암호 검증
- PowerPoint
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java를 통해 사용하여 PowerPoint PPT 및 PPTX 프레젠테이션에서 쓰기 보호 암호를 설정, 감지, 검증 및 제거합니다."
---
## **소개**

쓰기 보호 암호는 프레젠테이션의 수정은 제한하지만 내용을 암호화하지는 않습니다. 사용자는 쓰기 보호된 프레젠테이션을 암호 없이 로드하고 볼 수 있습니다. 애플리케이션에 따라 내용 편집 및 다른 이름으로 저장이 가능할 수 있으므로 쓰기 보호를 기밀성 메커니즘으로 취급해서는 안 됩니다.

열기 암호는 다른 목적을 가집니다: 프레젠테이션을 암호화하고 내용을 로드하기 위해 필요합니다. 프레젠테이션을 암호화하거나 열기 암호를 확인하려면 [Password-Protect Presentations](/slides/ko/androidjava/password-protected-presentation/)를 참조하십시오.

이 문서의 워크플로는 PPT와 PPTX 프레젠테이션 모두에 적용됩니다. 예제는 PPTX 파일을 사용합니다; PPT로 저장할 때는 `.ppt` 확장자를 사용하고 해당 PPT 저장 형식을 사용하십시오.

## **프레젠테이션에 쓰기 보호 설정**

프레젠테이션 수정용 암호를 지정하려면 [IProtectionManager.setWriteProtection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#setWriteProtection-java.lang.String-)를 사용하십시오. 프레젠테이션을 저장하면 보호 설정이 지속됩니다.

다음 예제는 PPTX 프레젠테이션에 쓰기 보호를 설정합니다:

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **쓰기 보호된 프레젠테이션 로드**

쓰기 보호는 프레젠테이션 내용을 암호화하지 않으므로 프레젠테이션을 로드할 때 암호가 필요하지 않습니다. 암호는 보호된 프레젠테이션을 수정할 권한을 확인할 때만 관련됩니다.

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

[ILoadOptions.setPassword](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iloadoptions/#setPassword-java.lang.String-)에 쓰기 보호 암호를 전달하지 마십시오. 이 메서드는 암호화된 내용에 대한 열기 암호를 받습니다. 프레젠테이션에 두 종류의 보호가 모두 있는 경우, 열기 암호를 제공하여 로드하고 쓰기 보호 암호는 별도로 처리하십시오.

## **프레젠테이션에서 쓰기 보호 제거**

수정 제한을 제거하려면 [IProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#removeWriteProtection--)를 사용한 다음 프레젠테이션을 저장하십시오.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **프레젠테이션이 쓰기 보호되는지 확인**

전체 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 인스턴스를 만들지 않고 파일을 검사하려면 [IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.lang.String-)를 호출하고 [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--)를 확인하십시오. 이 메서드는 [NullableBool](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/nullablebool/)을 사용하며 쓰기 보호가 감지되면 `NullableBool.True`를 반환합니다.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() == NullableBool.True) {
    System.out.println("The presentation is write protected.");
} else {
    System.out.println("Write protection was not detected.");
}
```

[IPresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationfactory/#getPresentationInfo-java.io.InputStream-)의 스트림 오버로드는 스트림으로 제공된 프레젠테이션에 대해 동일한 정보를 제공합니다.

## **쓰기 보호 암호 검증**

전체 프레젠테이션을 로드하지 않고 수정 암호를 검증하려면 [IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)를 사용하십시오. 먼저 [IPresentationInfo.isWriteProtected](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#isWriteProtected--)를 확인하여 쓰기 보호가 있을 때만 애플리케이션이 암호를 요청하거나 검증하도록 하십시오.

```java
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.NullableBool;
import com.aspose.slides.PresentationFactory;

IPresentationInfo presentationInfo = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() != NullableBool.True) {
    System.out.println("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    System.out.println("The write-protection password is correct.");
} else {
    System.out.println("The write-protection password is incorrect.");
}
```

[IPresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#checkWriteProtection-java.lang.String-)은 쓰기 보호 암호만 검증합니다. 열기 암호를 검증하거나 암호화된 내용을 로드할 수 있는지는 확인하지 않습니다. 반대로, [IPresentationInfo.checkPassword](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentationinfo/#checkPassword-java.lang.String-)은 열기 암호만 검증합니다. 전체 프레젠테이션이 이미 로드된 경우, [IProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iprotectionmanager/#checkWriteProtection-java.lang.String-)은 보호 관리자를 통해 동등한 쓰기 보호 검사를 제공합니다.

운영 환경 애플리케이션에서는 암호를 로그에 기록하거나 진단 메시지에 포함시키지 마십시오. 불필요한 반복 검증을 피하고, 암호는 필요한 기간 동안만 메모리에 유지하십시오.

{{% alert color="info" title="또한 보기" %}}
- [Password-Protect Presentations](/slides/ko/androidjava/password-protected-presentation/)
- [Read-Only Presentations](/slides/ko/androidjava/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/ko/androidjava/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**쓰기 보호가 프레젠테이션을 암호화합니까?**

아니요. 수정은 제한하지만 프레젠테이션 내용을 로드하고 볼 수 있도록 남겨 둡니다.

**프레젠테이션을 열기 위해 쓰기 보호 암호가 필요합니까?**

아니요. 암호화된 프레젠테이션 내용을 로드하려면 열기 암호만 필요합니다.

**프레젠테이션에 열기 암호와 쓰기 보호 암호를 모두 가질 수 있습니까?**

예. 암호화된 프레젠테이션을 열기 위해 로드 옵션을 통해 열기 암호를 제공하고, 수정 권한이 필요할 때 쓰기 보호 암호를 별도로 검증하십시오.