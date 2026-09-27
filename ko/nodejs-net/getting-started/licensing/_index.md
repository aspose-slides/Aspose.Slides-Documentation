---
title: 라이선스
description: "Aspose.Slides for Node.js via .NET에 라이선스 파일을 적용하고, 평가 버전 제한을 확인하며, 테스트를 위한 무료 30일 임시 라이선스를 받으세요."
type: docs
weight: 80
url: /ko/nodejs-net/licensing/
---
## **개요**

Aspose.Slides for Node.js via .NET은 평가와 프로덕션 모두에 사용할 수 있는 npm 패키지입니다. 라이선스가 없으면 평가 모드로 실행됩니다. 라이선스를 구매하거나 30일 무료 임시 라이선스를 받으면 몇 줄의 코드로 적용할 수 있으며 평가 제한이 사라집니다.

{{% alert color="info" title="참고" %}}

Aspose 제품을 평가, 라이선스 및 구매하는 일반 정책은 [Purchase Policies and FAQ](https://purchase.aspose.com/policies)에서 확인할 수 있습니다. 가격은 [Pricing Information](https://purchase.aspose.com/pricing/slides/ko/family) 페이지에 나와 있습니다.

{{% /alert %}}

## **평가 버전 제한 사항**

평가 버전은 제품의 전체 기능을 제공하지만 두 가지 제한이 있습니다:

- **워터마크.** 저장하는 각 프레젠테이션의 모든 슬라이드에 평가 워터마크가 표시됩니다: 슬라이드 중앙에 “Evaluation only”라는 텍스트가 잠긴 텍스트 상자로 표시됩니다. 동일한 워터마크가 PDF, XPS 및 HTML 내보내기와 슬라이드 이미지에도 적용됩니다.
- **잘린 텍스트.** 코드가 텍스트 프레임, 단락 또는 부분에서 읽어오는 텍스트는 처음 다섯 글자만 남고 뒤에 “… text has been truncated due to evaluation version limitation.”라는 알림이 붙습니다. Markdown 및 HTML5 내보내기도 동일하게 잘립니다. 코드가 쓰는 텍스트는 전체가 저장됩니다.

[Aspose.Slides 평가](/slides/ko/nodejs-net/evaluate-aspose-slides/)에서는 두 제한 사항을 자세히 설명하고 이를 보여주는 스크립트를 포함하고 있습니다.

{{% alert color="success" title="팁" %}}

평가 제한 없이 Aspose.Slides를 사용하려면 무료 **30일 임시 라이선스**를 요청하십시오. 자세한 내용은 [How to get a Temporary License?](https://purchase.aspose.com/temporary-license) 를 참고하세요.

{{% /alert %}}

## **라이선스 정보**

라이선스는 제품 이름, 라이선스 대상 개발자 수, 구독 만료 날짜와 같은 세부 정보를 포함하는 평문 XML 파일입니다. 파일은 디지털 서명되어 있으므로 수정해서는 안 됩니다. 실수로 한 줄을 추가해도 무효화됩니다.

## **라이선스 적용**

`License` 클래스의 `setLicense` 메서드를 사용해 라이선스를 적용합니다. `Presentation` 객체를 만들기 전에 프로세스당 한 번 호출하십시오. 다시 호출해도 해가 없지만 이미 수행된 작업을 반복하게 됩니다.

다음 스크립트는 `Aspose.Slides.lic` 파일에서 라이선스를 적용합니다. 파일 이름을 라이선스 파일의 이름이나 전체 경로로 바꾸십시오; 파일 이름은 자유롭게 지정할 수 있습니다.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { License } = asposeSlides;

const license = new License();
try {
    license.setLicense("Aspose.Slides.lic");
    console.log("License applied.");
} catch (error) {
    console.log("License not applied:", error.message);
}
```

파일 이름이나 상대 경로는 현재 폴더, 즉 `node`를 실행한 폴더를 기준으로 해석됩니다. 라이선스 파일을 프로젝트 폴더에 두고 그곳에서 스크립트를 실행하거나 전체 경로를 전달하십시오.

파일을 찾을 수 없거나 유효한 라이선스가 아닌 경우 `setLicense`는 오류를 발생시키고 Aspose.Slides는 평가 모드로 유지됩니다. 스크립트는 오류를 잡아 메시지를 출력합니다. 파일이 없을 경우 메시지는 `License "Aspose.Slides.lic" doesn't exist or access is restricted.` 로 시작하고 검색된 모든 위치를 나열합니다.

이 패키지는 파일에서만 라이선스를 적용합니다. `License`는 스트림을 받지 않으며, 패키지는 계량형 라이선스를 제공하지 않습니다. 패키지가 감싸는 클래스에 대한 자세한 내용은 Aspose.Slides for .NET API 참조의 [License](https://reference.aspose.com/slides/ko/net/aspose.slides/license/)를 확인하십시오.