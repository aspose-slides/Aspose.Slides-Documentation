---
title: RS 서버에서 SharePoint 설정
type: docs
weight: 40
url: /ko/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

그렇다면 SharePoint WFE에서 수행했던 작업을 다시 해야 합니다. 먼저 전제 조건 설치를 진행하고 그 다음 SharePoint 설정을 시작합니다.

설정에서는 Server Farm을 선택하고 SharePoint Box와 일치하도록 전체 설치를 수행합니다. SharePoint에 대해 독립 실행형 설치는 원하지 않기 때문입니다.

{{% /alert %}} 
### **SharePoint 구성**
SharePoint 구성 마법사에서 기존 팜에 연결하려고 합니다.

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Figure 13**: SharePoint 구성 마법사

그 다음에는 우리 팜이 사용하는 **SharePoint_Config** 데이터베이스를 지정합니다. 이 위치를 모른다면 **System Settings -> Manager Servers in this farm**을 통해 Central Admin에서 확인할 수 있습니다.

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Figure 14**: SharePoint 구성 마법사

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Figure 15**: SharePoint 구성 마법사

마법사가 완료되면 현재 시점에서는 Report Server Box에서 더 이상 할 일이 없습니다. ReportServer URL로 돌아가면 또 다른 오류가 표시되는데, 이는 Central Administrator에서 아직 설정하지 않았기 때문입니다.

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Figure 16**: Report Server 오류