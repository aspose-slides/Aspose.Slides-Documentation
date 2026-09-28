---
title: 라이선스
type: docs
weight: 50
url: /ko/jasperreports/licensing/
description: "Aspose.Slides for JasperReports 평가 버전이 내보낸 파일에 추가하는 내용과 JasperReports 및 JasperReports Server에서 라이선스를 적용하는 방법을 알아봅니다."
---
{{% alert color="info" title="Note" %}}
Aspose.Slides for JasperReports는 무료이며 시간 제한 없는 평가판을 [download page](https://releases.aspose.com/slides/ko/jasperreport/)에서 제공됩니다. 평가판과 라이선스 버전은 동일한 다운로드입니다.  
평가가 만족스러우면 [buy a license](https://purchase.aspose.com/pricing/slides/ko/jasperreports/)를 구매하세요. 구독 약관을 이해하고 동의했는지 확인하십시오.  
주문이 결제된 후 주문 페이지에서 라이선스를 다운로드할 수 있습니다. 라이선스는 클라이언트 이름, 구매한 제품 및 라이선스 유형과 같은 정보를 포함하는 일반 텍스트이며 디지털 서명된 XML 파일입니다. 라이선스 파일의 내용을 어떤 형태로든 수정하지 마십시오. 수정하면 라이선스가 무효화됩니다.  
라이선스를 컴퓨터에 다운로드한 후 적절한 폴더(예: 애플리케이션 폴더 또는 **JasperReports\lib**)에 복사하십시오.
{{% /alert %}}

## **평가 버전 제한**
Aspose.Slides for JasperReports의 평가 버전(라이선스가 지정되지 않음)은 보고서의 모든 페이지를 내보내지만, 아래 그림과 같이 네 가지 출력 형식(PPT, PPTX, PDF 및 HTML) 모두에서 각 슬라이드 또는 페이지 중앙에 평가 워터마크를 삽입합니다. 자세한 내용은 [Evaluate Aspose.Slides](/slides/ko/jasperreports/evaluate-aspose-slides/)를 참조하십시오.

![내보낸 슬라이드 중앙의 평가 워터마크](evaluation_watermark.png)

## **라이선스 적용**
JasperReports 또는 JasperServer 중 어디에서 작업하느냐에 따라 라이선스를 적용하는 여러 방법이 있습니다.

### **JasperReports용 라이선스 적용**
`License` 클래스의 `setLicense` 메서드를 라이선스 파일을 읽는 스트림과 함께 호출합니다. Aspose.Slides for Java와 동일합니다:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // 라이선스 파일을 포함하는 스트림 객체를 생성합니다.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // License 클래스를 인스턴스화합니다.
            License license = new License();

            // 스트림 객체를 통해 라이선스를 설정합니다.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

또는 라이선스 파일 경로를 `ASExporterParameters.PPT_LICENSE` 매개변수에 전달하여 내보내기에 사용합니다. 이 예시에서 `jasperPrint`는 [Your first export](/slides/ko/jasperreports/#your-first-export)와 같이 채워진 보고서입니다:

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **JasperServer에서 라이선스 적용**
*applicationContext.xml*의 `pptExportParameters` 빈에 있는 `licenseFile` 속성을 라이선스 파일 경로로 설정합니다. 자세한 내용은 [Integration with JasperServer](/slides/ko/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license)에서 확인하십시오.