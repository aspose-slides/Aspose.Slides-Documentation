---
title: Aspose.Slides for SharePoint 설치
type: docs
weight: 10
url: /ko/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint는 Aspose.Slides.SharePoint.zip 압축 파일로 다운로드됩니다. 압축 파일에는 다음이 포함됩니다: 

- **Aspose.Slides.SharePoint.wsp**: SharePoint 솔루션 파일. Aspose.Slides for SharePoint는 서버 팜 전체에서 활성화 및 비활성화를 쉽게 할 수 있도록 SharePoint 솔루션으로 패키징되었습니다.
- **Aspose_LicenseAgreement.rtf**: 최종 사용자 사용권 계약서.
- **Setup.exe**: 설치 프로그램.
- **Setup.exe.config**: 설정 구성 파일.

{{% /alert %}} 
## **설치 과정**
설치를 실행하기 전에, 설치 프로그램은 다음을 확인합니다: 

- WSS 3.0 또는 MOSS 2007이 설치되어 있습니다.
- 사용자에게 SharePoint 솔루션을 설치할 권한이 있습니다.
- SharePoint 데이터베이스가 온라인 상태입니다.
- WSS 관리 서비스가 시작되었습니다.
- WSS 타이머 서비스가 시작되었습니다.

WSS 관리 서비스와 타이머 서비스가 필요한 이유는 일부 설치 작업이 타이머 작업에 의존하여 서버 팜의 모든 서버에 전파되기 때문입니다. 
### **설치 실행**
Aspose.Slides for SharePoint를 설치하려면: 

1. MOSS 7.0 또는 WSS 3.0 서버의 로컬 드라이브에 Aspose.Slides.SharePoint zip 파일을 풀어냅니다.
2. setup.exe를 실행하고 화면에 표시되는 지침을 따릅니다.  
   설치 프로그램은 다음 작업을 수행합니다: 
   1. 설치 전제 조건을 확인합니다. 확인 중 하나라도 실패하면 설치가 계속되지 않습니다. 

      **시스템 점검 실행** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. 최종 사용자 사용권 계약서를 표시합니다. 계속 진행하려면 계약에 동의해야 합니다. 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. 배포 대상 선택 화면을 표시합니다. 기능을 활성화할 웹 애플리케이션 및 사이트 컬렉션을 선택합니다. 

   **배포 대상 선택** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. 서버 팜에 기능을 배포합니다. 

   **설치 진행률 표시줄** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. 선택한 사이트 컬렉션에 대해 Aspose.Slides를 활성화하고 해당 상위 웹 애플리케이션을 구성합니다.
7. 웹 애플리케이션 및 사이트 컬렉션의 목록을 표시합니다. 여기에는 기능이 배포 및 활성화된 대상이 포함됩니다. 

   **설치 성공** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)