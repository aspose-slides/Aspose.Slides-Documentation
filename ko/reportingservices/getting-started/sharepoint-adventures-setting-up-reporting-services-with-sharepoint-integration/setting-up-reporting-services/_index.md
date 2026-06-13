---
title: Reporting Services 설정
type: docs
weight: 30
url: /ko/reportingservices/setting-up-reporting-services/
---
{{% alert color="primary" %}} 

RS 서버에서 첫 번째 정류장은 Reporting Services Configuration Manager입니다. 

{{% /alert %}} 
## **Service Account**
Reporting Services에 사용하는 서비스 계정을 반드시 이해하십시오. 문제가 발생하면 사용 중인 서비스 계정과 관련될 수 있습니다. 기본값은 Network Service입니다. 새 빌드를 배포할 때마다 항상 도메인 계정을 사용합니다. 이는 문제가 발생하기 쉬운 지점이기 때문입니다. 내 서버의 이 구성에서는 **RSService**라는 도메인 계정을 사용했습니다. 

## **Web Service URL**
Web Service URL을 구성해야 합니다. 이는 Reporting Services가 사용하는 Web Services를 호스팅하는 **ReportServer** 가상 디렉터리(vdir)이며, SharePoint와 통신하는 대상입니다. vdir의 속성(예: SSL, 포트, 호스트 헤더 등)을 사용자 정의하려는 경우가 아니라면 여기서 Apply 버튼을 클릭하면 됩니다. 

![todo:image_alt_text](setting-up-reporting-services_1.png)

![todo:image_alt_text](setting-up-reporting-services_2.png)


**그림 3**: Web Service URL 설정 

그 작업이 완료되면 다음 그림과 같이 표시됩니다. 

![todo:image_alt_text](setting-up-reporting-services_3.png)

**그림 4**: Web Service URL 설정 성공 
## **Database**
Reporting Services 카탈로그 데이터베이스를 생성해야 합니다. 이는 SQL 2008 또는 SQL 2008 R2 데이터베이스 엔진에 배치할 수 있습니다. SQL11도 사용할 수 있지만 아직 베타 단계입니다. 이 작업은 기본적으로 두 개의 데이터베이스, **ReportServer**와 **ReportServerTempDB**를 생성합니다. 
또 다른 중요한 단계는 데이터베이스 유형으로 SharePoint Integrated를 선택하는 것입니다. 일단 선택하면 변경할 수 없습니다. 참고용으로 그림 5, 6, 7을 확인하십시오. 

![todo:image_alt_text](setting-up-reporting-services_4.png)

**그림 5**: Report Server 데이터베이스 생성 

![todo:image_alt_text](setting-up-reporting-services_5.png)

**그림 6**: 데이터베이스 서버 및 인증 유형 설정 

![todo:image_alt_text](setting-up-reporting-services_6.png)

**그림 7**: 데이터베이스 이름 및 모드 설정 

자격 증명은 Report Server가 SQL Server와 통신하는 방식입니다. 선택한 계정은 카탈로그 데이터베이스와 몇몇 시스템 데이터베이스에 RSExecRole을 통해 특정 권한을 부여받습니다. MSDB는 SQL Agent를 사용한 구독 기능을 위해 필요한 데이터베이스 중 하나입니다. 

![todo:image_alt_text](setting-up-reporting-services_7.png)

**그림 8**: Report Server 데이터베이스 자격 증명 설정 

이 작업이 완료되면 다음 그림과 같이 표시됩니다. 

![todo:image_alt_text](setting-up-reporting-services_8.png)


**그림 9**: Report Server 데이터베이스 설정 진행 상황 
## **Report Manager URL**
SharePoint Integrated 모드에서는 Report Manager URL을 사용할 필요가 없으므로 건너뛸 수 있습니다. SharePoint가 프런트엔드이며 Report Manager는 작동하지 않습니다. 
## **Encryption Keys**
Encryption Key를 백업하고 보관 위치를 반드시 기억하십시오. 데이터베이스를 마이그레이션하거나 복원해야 하는 상황이 발생하면 이 키가 필요합니다. 

![todo:image_alt_text](setting-up-reporting-services_9.png)

Reporting Services Configuration Manager는 여기까지입니다. Web Service URL 탭의 URL을 브라우저에서 열면 다음과 유사한 화면이 표시됩니다. 

![todo:image_alt_text](setting-up-reporting-services_10.png)

**그림 12**: 설치 후 Report Server 접근 

무슨 일이 있었나요? 내 WFE에 SharePoint가 설치되어 있고 Reporting Services 설정을 마쳤습니다. 이 예에서는 Reporting Services와 SharePoint가 서로 다른 머신에 있습니다. 동일한 머신에 있었다면 이 오류가 나타나지 않았을 것입니다. 실제로는 RS 서버에 SharePoint를 설치해야 합니다. 이는 IIS도 활성화된다는 의미입니다.