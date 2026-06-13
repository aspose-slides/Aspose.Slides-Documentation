---
title: 내보낸 프레젠테이션에 비밀번호 보호 적용
type: docs
weight: 90
url: /ko/reportingservices/password-protecting-the-exported-presentation/
---
{{% alert color="primary" %}} 

프레젠테이션에 비밀번호를 설정하면 무단 사용 및 접근을 방지할 수 있습니다. 보고서에 민감한 데이터나 조직 내 일부인만 확인해야 하는 상세 정보가 포함된 경우 비밀번호 보호가 유용합니다.

이 문서에서는 프레젠테이션을 비밀번호 보호와 함께 저장할 수 있도록 Reporting Services 또는 Visual Studio 환경을 업데이트하는 방법을 보여줍니다.

{{% /alert %}} 
## **Reporting Services 환경에서 내보낸 프레젠테이션에 비밀번호 보호 추가하기**
여기에서 변경 사항을 적용하려면 Microsoft SQL Server Reporting Services가 설치된 디렉터리의 파일을 수정해야 합니다.
### **Step 1. Locate the Reporting Server installation directory.**
Microsoft SQL Server의 루트 디렉터리는 일반적으로 C:\Program Files\Microsoft SQL Server입니다.

{{% alert color="primary" %}} 

x64 비트 시스템의 경우 SQL Server의 x86 인스턴스는 C:\Program Files (x86)\Microsoft SQL Server에 설치됩니다.

{{% /alert %}} 

Microsoft SQL Server 2005 및 2008: 머신에 여러 인스턴스의 Microsoft SQL Server가 구성되어 있을 수 있습니다. 각 인스턴스는 MSSQL.1, MSSQL.2 등과 같은 서로 다른 MSSQL.x 하위 디렉터리를 차지합니다. 다음 단계에 진행하기 전에 올바른 C:\Program Files\Microsoft SQL Server\MSSQL.x\Reporting Services\ReportServer 디렉터리를 찾으십시오.

아래에서 사용되는 모든 경로는 Microsoft SQL Server Reporting Services 설치 디렉터리를 <Instance>라고 가정합니다.
### **Step 2. Add the code for adding passwords to exported presentations**
기존 **rsreportserver.config** 파일 내의 Aspose.Slides for Reporting Services 렌더링 확장을 교체합니다. 이를 위해 C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rsreportserver.config 파일을 엽니다.  

아래에 바로 나열된 렌더링 옵션을 찾아 그 뒤에 나오는 코드 세그먼트로 교체합니다.
#### **Find Aspose.Slides for Reporting Service Rendering Options**
**<Render>**

``` xml

   ...

  <!--여기에서 시작합니다.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--여기에서 끝납니다.-->


</Render>



```
#### **Replacement Code**
**<Render>**

``` xml

   ...

  <!--여기에서 시작합니다.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <!--여기에서 끝납니다.-->


</Render>



```
### **Adding Password Protection for Exported Presentations in Visual Studio**
여기에서 변경 사항을 적용하려면 Microsoft Visual Studio Report Designer가 설치된 파일을 수정해야 합니다.
### **Step 1. Open the Visual Studio directory.**
- Visual Studio 2005 Report Designer와 통합하려면 C:\Program Files\Microsoft Visual Studio 8\Common7\IDE\PrivateAssemblies 디렉터리를 엽니다.
- Visual Studio 2008 Report Designer와 통합하려면 C:\Program Files\Microsoft Visual Studio 9.0\Common7\IDE\PrivateAssemblies 디렉터리를 엽니다.
### **Step 2. Add the code for adding password to exported presentations.**
기존 **rsreportserver.config** 파일 내의 Aspose.Slides for Reporting Services 렌더링 확장을 교체합니다. 이를 위해 C:\Program Files\Microsoft Visual Studio <Version>\Common7\IDE\PrivateAssemblies\RSReportDesigner.config 파일을 엽니다(**<Version>**은 Visual Studio 2005인 경우 “8”, Visual Studio 2008인 경우 “9.0”입니다) 그리고 **<Render>** 요소에 다음 줄을 추가하고, 다음 코드 세그먼트의 코드로 교체합니다.
#### **Find Aspose.Slides for Reporting Service Rendering Options**
**<Render>**

``` xml

   ...

  <!--여기에서 시작합니다.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PpsRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices"/>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PpsxRenderer,Aspose.Slides.ReportingServices"/>

<!--여기에서 끝납니다.-->


</Render>



```
#### **Replacement Code**
**<Render>**

``` xml

   ...

  <!--여기에서 시작합니다.-->


  <Extension Name="ASPPT" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPS" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPTX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <Extension Name="ASPPSX" Type="Aspose.Slides.ReportingServices.PptxRenderer,Aspose.Slides.ReportingServices" >


  <Configuration>				 		


	<Password>111</Password>
  </Configuration>			


 </Extension>

  <!--여기에서 끝납니다.-->


</Render>



```