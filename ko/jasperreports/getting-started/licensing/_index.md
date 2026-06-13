---
title: 라이선스
type: docs
weight: 50
url: /ko/jasperreports/licensing/
---
{{% alert color="primary" %}} 

Aspose.Slides for JasperReports는 [다운로드 페이지](https://downloads.aspose.com/slides/ko/jasperreport)에서 무제한 무료 평가판으로 제공됩니다. 평가판과 라이선스 버전은 동일한 파일을 다운로드합니다.

평가판이 만족스러우면 [라이선스 구매](https://purchase.aspose.com/buy)를 진행하십시오. 구독 약관을 이해하고 동의했는지 확인하십시오.

주문이 결제된 후 주문 페이지에서 라이선스를 다운로드할 수 있습니다. 라이선스는 클라이언트 이름, 구매한 제품 및 라이선스 유형과 같은 정보를 포함하는 평문이며 디지털 서명된 XML 파일입니다. 라이선스 파일의 내용을 어떠한 방식으로도 수정하지 마십시오. 수정하면 라이선스가 무효화됩니다.

라이선스를 컴퓨터에 다운로드한 후 적절한 폴더(예: 애플리케이션 폴더 또는 **JasperReports\lib**)에 복사하십시오.

## **평가 버전 제한**
라이선스가 지정되지 않은 Aspose.Slides 평가 버전은 전체 제품 기능을 제공하지만, 프레젠테이션을 저장할 때 아래 그림과 같이 각 슬라이드 중앙에 평가 워터마크를 삽입합니다:

![todo:image_alt_text](evaluation_watermark.png) 

## **라이선스 적용**
JasperReports 또는 JasperServer에서 작업하는지에 따라 라이선스를 적용하는 여러 방법이 있습니다.

### **JasperReports용 라이선스 적용**
Aspose.Slides for Java와 유사하게 직접 setLicense 메서드 호출을 사용하십시오.

```java
import com.aspose.slides.jasperreports.License;

..... 

try {
    //라이선스 파일을 포함하는 스트림 객체 생성
    FileInputStream fstream=new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");
	
    //License 클래스를 인스턴스화
    License license = new License();
	
    //스트림 객체를 통해 라이선스 설정
    license.setLicense(fstream);
} catch(Exception ex) {
    System.out.println(ex.toString());
}
```

또는 코드에서 exporter 매개변수를 설정하십시오.

```java
ASPptExporter exporter = new ASPptExporter (); 
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer에 라이선스 적용**
applicationContext.xml에서 exporter 매개변수를 설정하십시오.

``` xml
<bean id="asExportParametersBean" class="com.aspose.slides.jasperreports.ASExportParametersBean">
    <property name="licenseFile" value="C:/jasperserver-3.0/apache-tomcat/webapps/jasperserver/WEB-INF/Aspose.Slides.JasperReports.Developer.lic"/>
</bean>
```