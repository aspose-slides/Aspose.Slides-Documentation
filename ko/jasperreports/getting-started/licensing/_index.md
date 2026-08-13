---
title: 라이선스
type: docs
weight: 50
url: /ko/jasperreports/licensing/
---
{{% alert color="info" %}} 

Aspose.Slides for JasperReports는 [download page](https://downloads.aspose.com/slides/ko/jasperreport)에서 시간 제한 없는 무료 평가판으로 제공됩니다. 평가판과 정식 라이선스 버전은 동일한 다운로드 파일입니다.

평가가 만족스러우면 [buy a license](https://purchase.aspose.com/buy)하십시오. 구독 조건을 이해하고 동의했는지 확인하십시오.

주문이 결제된 후 주문 페이지에서 라이선스를 다운로드할 수 있습니다. 라이선스는 클라이언트 이름, 구매한 제품 및 라이선스 유형과 같은 정보를 포함하는 일반 텍스트이며 디지털 서명된 XML 파일입니다. 라이선스 파일의 내용을 어떤 식으로든 수정하지 마십시오. 수정하면 라이선스가 무효화됩니다.

라이선스를 컴퓨터에 다운로드한 후 적절한 폴더(예: 애플리케이션 폴더 또는 **JasperReports\lib**)에 복사하십시오.
{{% /alert %}}

## **평가 버전 제한**
Evaluation version of Aspose.Slides (without a license specified) provides full product functionality, but (when you save your presentations) it injects an evaluation watermark at the center of each slide as shown in the figure below:

![todo:image_alt_text](evaluation_watermark.png) 

## **라이선스 적용**
There are several ways to apply a license, depending on whether you're working on JasperReports, or JasperServer.

### **JasperReports에 대한 라이선스 적용**
Use a direct setLicense method call similar to Aspose.Slides for Java.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //라이선스 파일을 포함하는 스트림 객체 생성
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License 클래스 인스턴스화
    License license = new License();
	
    //스트림 객체를 통해 라이선스 설정
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

Or, set the exporter parameter in the code.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer에 대한 라이선스 적용**
Set the exporter parameter in the applicationContext.xml.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```