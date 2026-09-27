---
title: 라이선스
type: docs
weight: 90
url: /ko/java/licensing/
keywords:
- 라이선스
- 임시 라이선스
- 라이선스 설정
- 라이선스 사용
- 라이선스 검증
- 라이선스 파일
- 평가 버전
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java에서 라이선스를 적용, 관리 및 문제를 해결합니다. 단계별 라이선스 가이드를 통해 전체 기능에 대한 중단 없는 접근을 보장합니다."
---
## **개요**

Aspose.Slides는 평가 모드나 유효한 라이선스로 사용할 수 있습니다. 평가 버전은 라이선스 버전과 동일한 기능을 제공하지만 저장하는 모든 프레젠테이션의 각 슬라이드에 평가 워터마크를 추가하고 API를 통해 코드가 읽는 텍스트를 잘라냅니다.

이 문서는 Aspose.Slides에서 라이선스가 어떻게 작동하는지와 라이브러리를 사용하기 전에 라이선스를 적용하는 방법을 설명합니다. 라이선스는 `License` 클래스를 사용하여 파일, 스트림 또는 포함된 리소스에서 로드할 수 있습니다. 또한 라이선스가 올바르게 적용되었는지 검증하는 방법도 보여줍니다.

## **Aspose.Slides 평가판 사용**

{{% alert color="info" title="Note" %}}

**Aspose.Slides for Java** 평가판은 [다운로드 페이지](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/)에서 다운로드할 수 있습니다. 평가 버전은 제품의 라이선스 버전과 동일한 기능을 제공합니다. 평가 패키지는 구매한 패키지와 동일합니다. 몇 줄의 코드를 추가하여(라이선스를 적용하면) 평가 버전은 라이선스 버전이 됩니다.

**Aspose.Slides** 평가가 만족스러우면 [라이선스 구매](https://purchase.aspose.com/pricing/slides/java/)를 진행할 수 있습니다. 다양한 구독 유형을 검토하시기 바랍니다. 질문이 있으면 Aspose 영업팀에 문의하세요.

모든 Aspose 라이선스에는 구독 기간 동안 신규 버전이나 출시된 수정 사항에 대한 무료 업그레이드 1년 구독이 포함됩니다. 라이선스 제품(또는 평가 버전) 사용자는 무료이면서 무제한 기술 지원을 받을 수 있습니다.

{{% /alert %}} 

**평가판 제한 사항**

* 라이선스가 지정되지 않은 평가판은 전체 제품 기능을 제공하지만 저장하는 모든 프레젠테이션의 각 슬라이드에 평가 워터마크 텍스트 상자를 추가합니다.
* API를 통해 코드가 읽는 텍스트(방금 설정한 텍스트 포함)는 처음 몇 글자로 잘리고 평가 제한에 대한 안내가 뒤에 붙습니다. 코드가 쓰는 텍스트는 전체가 저장됩니다.

{{% alert color="info" title="Note" %}}

제한 없이 Aspose.Slides를 테스트하려면 **30일 임시 라이선스**를 요청할 수 있습니다. 자세한 내용은 [임시 라이선스 받는 방법](https://purchase.aspose.com/temporary-license) 페이지를 참조하세요.

{{% /alert %}}

## **Aspose.Slides 라이선스**

* 평가판은 라이선스를 구매하고 몇 줄의 코드를 추가하면(라이선스를 적용하면) 라이선스가 됩니다.
* 라이선스는 제품명, 라이선스 대상 개발자 수, 구독 만료일 등 상세 정보를 포함하는 일반 텍스트 XML 파일입니다.
* 라이선스 파일은 디지털 서명되어 있으므로 파일을 수정해서는 안 됩니다. 파일 내용에 한 줄씩이라도 추가하면 무효화됩니다.
* Aspose.Slides for Java는 일반적으로 다음 위치에서 라이선스를 찾습니다.
  * 명시적인 경로
  * Aspose.Slides.jar가 포함된 폴더
* 평가판과 관련된 제한을 피하려면 **Aspose.Slides**를 사용하기 전에 라이선스를 설정해야 합니다. 애플리케이션 또는 프로세스당 한 번만 설정하면 됩니다.

{{% alert color="info" title="Note" %}}

[계량형 라이선스](/slides/ko/java/metered-licensing/)를 확인해 보세요.

{{% /alert %}} 


## **라이선스 적용**

라이선스는 **파일** 또는 **스트림**에서 로드할 수 있습니다.

{{% alert color="info" title="Note" %}}

Aspose.Slides는 라이선스 작업을 위한 [License](https://reference.aspose.com/slides/java/com.aspose.slides/license/) 클래스를 제공합니다.

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

새 라이선스는 버전 21.4 이상에서만 Aspose.Slides를 활성화할 수 있습니다. 이전 버전은 다른 라이선스 시스템을 사용하므로 이 라이선스를 인식하지 못합니다.

{{% /alert %}}

### **파일**

라이선스를 설정하는 가장 쉬운 방법은 라이선스 파일을 Aspose.Slides.jar가 포함된 폴더나 애플리케이션 JAR에 배치하는 것입니다.

다음 Java 코드가 라이선스 파일을 설정하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 라이선스 파일 경로를 설정합니다
license.setLicense("Aspose.Slides.Java.lic");
```

{{% alert color="warning" title="Warning" %}}

라이선스 파일을 다른 디렉터리에 배치한 경우, [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) 메서드를 호출할 때 지정된 경로 끝에 있는 파일 이름이 실제 라이선스 파일 이름과 동일해야 합니다.

예를 들어 라이선스 파일 이름을 *Aspose.Slides.Java.lic.xml* 로 바꿀 수 있습니다. 그런 다음 코드에서 파일 경로(끝이 *Aspose.Slides.Java.lic.xml* 로 끝나는)를 [setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.lang.String-) 메서드에 전달해야 합니다.

{{% /alert %}}

### **스트림**

스트림에서 라이선스를 로드할 수 있습니다. 다음 Java 코드가 스트림에서 라이선스를 적용하는 방법을 보여줍니다:

``` java
// License 클래스를 인스턴스화합니다
com.aspose.slides.License license = new com.aspose.slides.License();

// 스트림을 통해 라이선스를 설정합니다
license.setLicense(new java.io.FileInputStream("Aspose.Slides.Java.lic"));
```

### **PHP/Java Bridge**

Java를 통해 PHP용 Aspose.Slides를 사용하는 경우 PHP/Java 브리지를 통해 라이선스를 설정할 수 있습니다. 이 브리지를 사용하면 PHP 구문에서 Java 클래스를 사용할 수 있습니다. 자세한 내용은 [PHP에서 라이선스](/slides/ko/php-java/licensing/)를 참조하세요.

## **라이선스 검증**

라이선스가 올바르게 설정되었는지 확인하려면 검증할 수 있습니다. 다음 Java 코드가 라이선스를 검증하는 방법을 보여줍니다:

```java
import com.aspose.slides.*;

License license = new License();
license.setLicense("Aspose.Slides.Java.lic");

if (license.isLicensed()) 
{
    System.out.println("License is good!");
}
```

## **스레드 안전성**

{{% alert color="warning" title="Warning" %}}

[setLicense](https://reference.aspose.com/slides/java/com.aspose.slides/license/#setLicense-java.io.InputStream-) 메서드는 스레드 안전하지 않습니다. 여러 스레드에서 동시에 호출해야 하는 경우 동기화 프리미티브(예: lock)를 사용하여 문제를 예방하세요.

{{% /alert %}}

## **FAQ**

### 완전히 오프라인 환경(인터넷 연결 없음)에서도 라이선스를 적용할 수 있나요?

네. 라이선스 검증은 라이선스 파일을 사용해 로컬에서 수행되므로 인터넷 연결이 필요하지 않습니다.

### 1년 구독이 만료되면 어떻게 되나요? 라이브러리가 작동을 멈추나요?

아니요. 라이선스는 영구적이며 구독 종료일 이전에 릴리스된 버전은 계속 사용할 수 있습니다. 다만, 구독을 갱신하지 않으면 최신 릴리스를 사용할 수 없습니다.