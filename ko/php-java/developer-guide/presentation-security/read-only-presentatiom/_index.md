---
title: PHP를 사용하여 읽기 전용 모드로 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/php-java/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- OpenDocument
- 프레젠테이션
- PHP
- Aspose.Slides
description: "Aspose.Slides for PHP를 사용하여 읽기 전용 모드로 PowerPoint 파일(PPT, PPTX)을 로드하고 저장합니다. 프레젠테이션을 변경하지 않으면서 정확한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위해 사용자가 사용할 수 있는 옵션 중 하나로 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우 프레젠테이션을 보호하기 위해 이 읽기 전용 설정을 사용할 수 있습니다.

- 실수로 편집되는 것을 방지하고 프레젠테이션 내용을 안전하게 유지하고 싶을 때. 
- 제공한 프레젠테이션이 최종 버전임을 알리고 싶을 때. 

프레젠테이션에 **Always Open Read-Only** 옵션을 선택하면 사용자가 프레젠테이션을 열 때 **Read-Only** 권고가 표시되고 다음과 같은 메시지가 나타날 수 있습니다: *우발적인 변경을 방지하기 위해 작성자가 이 파일을 읽기 전용으로 열도록 설정했습니다.*

Read-Only 권고는 간단하지만 효과적인 억제 수단으로, 사용자가 프레젠테이션을 편집하기 전에 이를 해제하는 작업을 수행해야 하므로 편집을 억제합니다. 프레젠테이션에 대한 변경을 원하지 않으며 이를 정중하게 알리고 싶다면 Read-Only 권고가 좋은 옵션이 될 수 있습니다. 

> **Read-Only** 보호가 적용된 프레젠테이션을 최근 기능을 지원하지 않는 오래된 Microsoft PowerPoint 애플리케이션에서 열면 **Read-Only** 권고가 무시되고(프레젠테이션이 정상적으로 열립니다).

## **읽기 전용 모드 적용**

Aspose.Slides for PHP via Java를 사용하면 프레젠테이션을 **Read-Only** 로 설정할 수 있으며, 이는 사용자가 (프레젠테이션을 연 후) **Read-Only** 권고를 보게 함을 의미합니다. 다음 샘플 코드는 Aspose.Slides를 사용하여 프레젠테이션을 **Read-Only** 로 설정하는 방법을 보여줍니다.

```php
  $pres = new Presentation();
  try {
    $pres->getProtectionManager()->setReadOnlyRecommended(true);
    $pres->save("ReadOnlyPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert color="primary" %}} 
**Note**: **Read-Only** 권고는 PowerPoint 프레젠테이션을 편집하거나 실수로 변경하는 것을 억제하기 위한 간단한 수단입니다. 동작을 잘 아는 의도적인 사용자가 프레젠테이션을 편집하려고 하면 Read-Only 설정을 쉽게 제거할 수 있습니다. 실제로 무단 편집을 방지해야 한다면 [more stringent protections that involve encryptions and passwords](https://docs.aspose.com/slides/ko/php-java/password-protected-presentation/)을 사용하는 것이 좋습니다.
{{% /alert %}} 

## **FAQ**

**'Read-Only recommended'는 전체 비밀번호 보호와 어떻게 다릅니까?**  
'Read-Only recommended'는 파일을 읽기 전용 모드로 열라는 제안만 표시하며 우회하기 쉽습니다. [Password protection](/slides/ko/php-java/password-protected-presentation/)은 실제로 열기 및 편집을 제한하며 실제 보안 제어가 필요할 때 적합합니다.

**'Read-Only recommended'를 워터마크와 결합하여 편집을 더욱 억제할 수 있습니까?**  
예. 권고는 [watermarks](/slides/ko/php-java/watermark/)와 함께 시각적 억제 수단으로 사용할 수 있습니다; 두 메커니즘은 별개이며 함께 잘 작동합니다.

**권고가 활성화된 경우 매크로나 외부 도구가 파일을 여전히 수정할 수 있습니까?**  
예. 권고는 프로그래밍 방식의 변경을 차단하지 않습니다. 자동 편집을 방지하려면 [passwords and encryption](/slides/ko/php-java/password-protected-presentation/)을 사용하십시오.

**'Read-Only recommended'는 'isEncrypted' 및 'isWriteProtected' 메서드와 어떻게 관련이 있습니까?**  
이들은 서로 다른 신호입니다. 'Read-Only recommended'는 부드럽고 선택적인 프롬프트이며, [isWriteProtected](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/iswriteprotected/)와 [isEncrypted](https://reference.aspose.com/slides/ko/php-java/aspose.slides/protectionmanager/isencrypted/)는 비밀번호 또는 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.