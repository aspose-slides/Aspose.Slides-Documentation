---
title: PPT, PPTX, PDF 및 HTML 내보내기
type: docs
weight: 20
url: /ko/jasperreports/ppt-pptx-pdf-and-html-export/
description: "PPT, PPTX, PDF 또는 HTML 출력용 Aspose.Slides for JasperReports 내보내기 도구를 선택하고, 채워진 보고서를 내보내며, 보고서 글꼴을 프레젠테이션 글꼴에 매핑합니다."
---
## **내보내기 도구**

Aspose.Slides for JasperReports는 JasperReports에 네 개의 내보내기 도구를 추가합니다. 각 도구는 채워진 보고서(`JasperPrint`)를 받아 보고서의 모든 페이지를 내보냅니다: PPT 및 PPTX 슬라이드로, PDF 페이지로, 그리고 단일 HTML 파일의 SVG 이미지로.

| 출력 형식 | 내보내기 클래스 |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

이 클래스들은 라이브러리 JAR의 `com.aspose.slides.jasperreports` 패키지에 있으며 Microsoft PowerPoint를 사용하지 않습니다. 보고서와 출력 파일을 `setParameter`와 `JRExporterParameter`를 사용하여 내보내기 도구에 전달해야 하는데, JasperReports에서는 이들을 더 이상 사용되지 않는다고 표시합니다: 내보내기 도구는 최신 `setExporterInput` 및 `setExporterOutput` 구성을 지원하지 않습니다.

## **보고서를 네 가지 형식 모두로 내보내기**

아래 프로그램은 [Your first export](/slides/ko/jasperreports/#your-first-export) 프로젝트를 기반으로 합니다. *hello.jrxml*을 한 번 컴파일하고 채운 다음, 채워진 보고서를 차례대로 각 내보내기 도구에 전달합니다. 해당 프로젝트에 *src/main/java/ExportAllFormats.java* 파일로 저장하십시오:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASAbstractExporter;
import com.aspose.slides.jasperreports.ASHtmlExporter;
import com.aspose.slides.jasperreports.ASPdfExporter;
import com.aspose.slides.jasperreports.ASPptExporter;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class ExportAllFormats {
    public static void main(String[] args) throws Exception {
        // 보고서를 한 번 컴파일하고 채웁니다.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 각 내보내기 도구를 사용해 동일한 채워진 보고서를 내보냅니다.
        export(new ASPptExporter(), jasperPrint, "hello.ppt");
        export(new ASPptxExporter(), jasperPrint, "hello.pptx");
        export(new ASPdfExporter(), jasperPrint, "hello.pdf");
        export(new ASHtmlExporter(), jasperPrint, "hello.html");
    }

    private static void export(ASAbstractExporter exporter, JasperPrint jasperPrint, String outputFileName) throws JRException {
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, outputFileName);
        exporter.exportReport();
    }
}
```

프로젝트 폴더에서 실행하십시오:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

이 프로그램은 프로젝트 폴더에 *hello.ppt*, *hello.pptx*, *hello.pdf*, *hello.html*을 저장합니다. 헬퍼 메서드는 네 개의 내보내기 도구 모두의 기본 클래스인 `ASAbstractExporter`를 사용합니다. 라이선스가 없을 경우 모든 출력 파일에 평가 워터마크가 표시됩니다 — [Evaluate Aspose.Slides](/slides/ko/jasperreports/evaluate-aspose-slides/)를 참조하십시오.

![라이선스 없이 프레젠테이션으로 내보낸 보고서](ppt-pptx-pdf-and-html-export_1.png)

## **글꼴 매핑**

PPT 및 PPTX 내보내기 도구는 보고서 디자인에 지정된 글꼴 이름을 그대로 프레젠테이션에 기록합니다. 텍스트 요소에 글꼴이 지정되지 않은 경우 JasperReports는 기본 글꼴인 `SansSerif`를 사용합니다. `SansSerif`는 설치된 글꼴이 아니라 Java 논리 글꼴 이름입니다. 이러한 이름을 교체하려면 보고서 글꼴 이름과 프레젠테이션에서 사용하려는 글꼴 이름 간의 매핑을 `ASExporterParameters.PPT_FONT_MAP` 매개변수에 전달하십시오. 키는 보고서에 있는 글꼴 이름과 정확히 일치해야 하며, 대소문자도 구분합니다. 각 값은 내보내기가 실행되는 머신에서 Java가 찾을 수 있는 글꼴이어야 합니다; Java가 찾을 수 없는 글꼴에 대한 항목은 내보내기 도구에서 무시됩니다.

같은 프로젝트에 *src/main/java/MapFonts.java* 파일로 저장하십시오. 이 프로그램은 *hello.jrxml*을 PPTX로 내보내며 `SansSerif`를 Arial로 교체합니다:

```java
import java.util.HashMap;
import java.util.Map;

import com.aspose.slides.jasperreports.ASExporterParameters;
import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class MapFonts {
    public static void main(String[] args) throws Exception {
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 보고서 글꼴 이름을 프레젠테이션에 쓸 글꼴 이름으로 매핑합니다.
        Map<String, String> fontMap = new HashMap<String, String>();
        fontMap.put("SansSerif", "Arial");

        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello-arial.pptx");
        exporter.setParameter(ASExporterParameters.PPT_FONT_MAP, fontMap);
        exporter.exportReport();
    }
}
```

프로젝트 폴더에서 실행하십시오:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

저장된 *hello-arial.pptx*에서는 보고서 텍스트가 `SansSerif` 대신 Arial을 사용합니다. Java가 Arial을 찾지 못하는 머신(예: Arial이 설치되지 않은 Linux 시스템)에서는 텍스트가 `SansSerif` 그대로 유지됩니다. JasperReports Server에서는 내보내기 매개변수 bean의 `fontMap` 속성을 통해 동일한 매핑을 설정하십시오 — [Integration with JasperServer](/slides/ko/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license)를 참조하십시오.