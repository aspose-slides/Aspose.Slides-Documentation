---
title: JavaScript를 사용하여 읽기 전용 모드로 프레젠테이션 저장
linktitle: 읽기 전용 프레젠테이션
type: docs
weight: 30
url: /ko/nodejs-java/read-only-presentation/
keywords:
- 읽기 전용
- 프레젠테이션 보호
- 편집 방지
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 PowerPoint 파일을 읽기 전용 모드로 로드하고 저장함으로써 프레젠테이션을 변경하지 않고 정밀한 슬라이드 미리보기를 제공합니다."
---
## **소개**

PowerPoint 2019에서 Microsoft는 프레젠테이션을 보호하기 위해 사용자가 사용할 수 있는 옵션 중 하나로 **Always Open Read-Only** 설정을 도입했습니다. 다음과 같은 경우에 이 Read-Only 설정을 사용하여 프레젠테이션을 보호할 수 있습니다.

- 실수로 수정되는 것을 방지하고 프레젠테이션의 내용을 안전하게 유지하고 싶을 때.  
- 제공한 프레젠테이션이 최종 버전임을 알리고 싶을 때.  

프레젠테이션에 대해 **Always Open Read-Only** 옵션을 선택하면 사용자가 프레젠테이션을 열 때 **Read-Only** 권고가 표시되고 다음과 같은 메시지를 볼 수 있습니다: *실수로 변경되는 것을 방지하기 위해 작성자가 이 파일을 읽기 전용으로 열도록 설정했습니다.*  

**Read-Only** 권고는 사용자가 편집하기 전에 이를 해제해야 하므로 편집을 억제하는 간단하지만 효과적인 방지책입니다. 사용자가 프레젠테이션을 수정하지 못하도록 하고 이를 정중하게 알리고 싶다면 **Read-Only** 권고가 좋은 옵션이 될 수 있습니다.

> **Read-Only** 보호가 적용된 프레젠테이션을 최근에 도입된 기능을 지원하지 않는 오래된 Microsoft PowerPoint 애플리케이션에서 열 경우, **Read-Only** 권고가 무시되고 프레젠테이션이 정상적으로 열립니다.

## **Read-Only 모드 적용**

Aspose.Slides for Node.js via Java를 사용하면 프레젠테이션을 **Read-Only**로 설정할 수 있으며, 이를 열면 사용자는 **Read-Only** 권고를 보게 됩니다. 아래 샘플 코드는 Aspose.Slides를 사용하여 JavaScript에서 프레젠테이션을 **Read-Only**로 설정하는 방법을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getProtectionManager().setReadOnlyRecommended(true);
    pres.save("ReadOnlyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 

**Note**: **Read-Only** 권고는 PowerPoint 프레젠테이션의 실수로 인한 편집을 방지하거나 억제하기 위한 것입니다. 작업을 잘 아는 의도적인 사용자는 쉽게 **Read-Only** 설정을 해제하고 프레젠테이션을 수정할 수 있습니다. 무단 편집을 확실히 방지해야 한다면 [암호화 및 암호를 포함한 보다 강력한 보호](https://docs.aspose.com/slides/ko/nodejs-java/password-protected-presentation/)를 사용하는 것이 좋습니다.

{{% /alert %}} 

## **FAQ**

**'Read-Only recommended'는 전체 암호 보호와 어떻게 다른가요?**

'Read-Only recommended'는 파일을 읽기 전용 모드로 열라는 제안만 표시하며 쉽게 우회할 수 있습니다. [Password protection](/slides/ko/nodejs-java/password-protected-presentation/)는 실제로 열기와 편집을 제한하며 진정한 보안 제어가 필요할 때 적합합니다.

**'Read-Only recommended'를 워터마크와 결합하여 편집을 더 억제할 수 있나요?**

예. 권고는 [watermarks](/slides/ko/nodejs-java/watermark/)와 함께 시각적인 억제 수단으로 사용할 수 있으며, 두 메커니즘은 별개이면서 함께 잘 작동합니다.

**권고가 활성화된 경우 매크로나 외부 도구가 파일을 수정할 수 있나요?**

예. 권고는 프로그래밍 방식의 변경을 차단하지 않습니다. 자동화된 편집을 방지하려면 [암호와 암호화](/slides/ko/nodejs-java/password-protected-presentation/)를 사용하세요.

**'Read-Only recommended'는 'IsEncrypted' 및 'IsWriteProtected' 플래그와 어떻게 관련이 있나요?**

두 신호는 다릅니다. 'Read-Only recommended'는 부드럽고 선택적인 안내이며, [isWriteProtected](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/iswriteprotected/)와 [isEncrypted](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/protectionmanager/isencrypted/)는 암호 또는 암호화에 따라 실제 쓰기 또는 읽기 제한을 나타냅니다.