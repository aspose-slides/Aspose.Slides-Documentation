---
title: 프레젠테이션에 오디오 삽입 지원
type: docs
weight: 90
url: /ko/reportingservices/support-for-embedding-audio-in-presentation/
---
{{% alert color="primary" %}}

Microsoft SQL Server Reporting Services에는 오디오가 포함된 보고서를 PowerPoint 프리젠테이션으로 내보내는 기본 기능이 없습니다. Aspose.Slides for Reporting Services 4.10 및 이후 버전은 내보낸 프리젠테이션에 오디오를 삽입하는 것을 지원합니다.

{{% /alert %}}

슬라이드에 오디오를 삽입하려면 보고서에 텍스트 상자를 추가하고 다음 텍스트를 입력하십시오:

``` xml

 <asposeObject type="audio" url="file://c:\MyVideos\intro.wav" playMode="Auto" volume="Loud" cover="file://c:\MyVideos\introCover.jpg"/>

```

SQL Server 2008 버전 이상에서 작동합니다. 이 기능은 PPTX 내보내기에서만 지원됩니다.