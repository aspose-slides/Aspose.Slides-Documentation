---
title: Aspose.Slides for JasperReports
second_title: Aspose.Slides for JasperReports
type: docs
weight: 70
url: /ko/jasperreports/
keywords:
- 문서
- JasperReports
- JasperReports Server
- 보고서 내보내기
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "시작하기: Aspose.Slides for JasperReports를 설치하고, 첫 번째 보고서를 PowerPoint로 내보내며, 내보내기, JasperReports Server 통합 및 지원에 대한 가이드를 확인하십시오."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports는 JasperReports Library와 JasperReports Server에 PowerPoint 내보내기 기능을 추가하여 Java 애플리케이션 및 보고서 서버가 Microsoft PowerPoint 없이도 채워진 보고서를 프레젠테이션으로 저장할 수 있도록 합니다.

채워진 보고서를 PPT 및 PPTX 파일로 내보내며, 보고서 페이지당 하나의 슬라이드를 생성하고 PDF 및 HTML 형식으로도 내보낼 수 있습니다.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>시작하기</b></p>
<hr>
<p>시작하기</p>
<ul>
<li><a href="/slides/ko/jasperreports/installing-aspose-slides-for-jasperreports/">설치</a></li>
<li><a href="/slides/ko/jasperreports/product-overview/">제품 개요</a></li>
<li><a href="/slides/ko/jasperreports/system-requirements/">시스템 요구 사항</a></li>
<li><a href="/slides/ko/jasperreports/getting-started/">시작 가이드</a></li>
</ul>
<p>평가</p>
<ul>
<li><a href="/slides/ko/jasperreports/supported-file-formats/">지원 파일 형식</a></li>
<li><a href="/slides/ko/jasperreports/evaluate-aspose-slides/">체험판 제한 사항</a></li>
<li><a href="/slides/ko/jasperreports/licensing/">라이선스</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides로 빌드</b></p>
<hr>
<p>내보내기</p>
<ul>
<li><a href="/slides/ko/jasperreports/ppt-pptx-pdf-and-html-export/">PPT, PPTX, PDF 및 HTML로 내보내기</a></li>
<li><a href="/slides/ko/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">글꼴 매핑</a></li>
<li><a href="/slides/ko/jasperreports/integration-with-jasperserver/">JasperReports Server 통합</a></li>
</ul>
<p>예제</p>
<ul>
<li><a href="/slides/ko/jasperreports/demos-setup/">데모 프로젝트</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>참조 및 지원</b></p>
<hr>
<p>참조</p>
<ul>
<li><a href="https://releases.aspose.com/slides/ko/jasperreport/release-notes/">릴리스 노트</a></li>
<li><a href="https://releases.aspose.com/slides/ko/jasperreport/">다운로드</a></li>
</ul>
<p>지원</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/ko/11">무료 지원 포럼</a></li>
<li><a href="https://helpdesk.aspose.com/">유료 지원 헬프데스크</a></li>
</ul>
</div>
</div>

------

## **첫 번째 내보내기**

이 단계에서는 한 줄 보고서를 컴파일하고 채운 다음 JasperReports 6.16.0을 사용하여 Maven Central에서 PPTX로 내보냅니다. JDK 11 이상과 Apache Maven이 필요합니다.

1. ZIP 파일을 [download page](https://releases.aspose.com/slides/ko/jasperreport/)에서 다운로드하고 압축을 풉니다. *lib* 폴더에는 JasperReports 버전 범위별로 하위 폴더가 하나씩 있으며, 각 폴더에는 해당 범위의 jar 파일이 들어 있습니다. JasperReports 6.16.0의 경우 *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar*을 빈 프로젝트 폴더에 복사합니다.

2. jar 파일은 Maven 저장소가 아니라 ZIP에 포함되어 있으므로 로컬 Maven 저장소에 설치해야 합니다. 프로젝트 폴더에서 다음 명령을 실행합니다:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. *pom.xml* 파일을 프로젝트 폴더에 저장합니다. 이 파일은 JasperReports 6.16.0과 설치한 jar를 추가하고 실행할 클래스를 지정합니다. JasperReports 6.16.0은 Maven Central에 없는 패치된 iText 빌드를 선언하므로 파일에서 이를 제외합니다; Aspose 내보내기 기능은 이를 필요로 하지 않습니다.

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-jasper-export</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
        <exec.mainClass>HelloExport</exec.mainClass>
    </properties>

    <dependencies>
        <dependency>
            <groupId>net.sf.jasperreports</groupId>
            <artifactId>jasperreports</artifactId>
            <version>6.16.0</version>
            <exclusions>
                <exclusion>
                    <groupId>com.lowagie</groupId>
                    <artifactId>itext</artifactId>
                </exclusion>
            </exclusions>
        </dependency>
        <dependency>
            <groupId>com.aspose</groupId>
            <artifactId>aspose-slides-jasperreports</artifactId>
            <version>26.6</version>
        </dependency>
    </dependencies>

    <build>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
        </plugins>
    </build>
</project>
```

4. 이 보고서 디자인을 *hello.jrxml* 파일로 프로젝트 폴더에 저장합니다. 제목 밴드에 한 줄 텍스트를 출력합니다:

```xml
<?xml version="1.0" encoding="UTF-8"?>
<jasperReport xmlns="http://jasperreports.sourceforge.net/jasperreports"
        xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
        xsi:schemaLocation="http://jasperreports.sourceforge.net/jasperreports http://jasperreports.sourceforge.net/xsd/jasperreport.xsd"
        name="Hello" pageWidth="595" pageHeight="842" columnWidth="555"
        leftMargin="20" rightMargin="20" topMargin="20" bottomMargin="20">
    <title>
        <band height="50">
            <staticText>
                <reportElement x="0" y="0" width="555" height="40"/>
                <textElement>
                    <font size="24"/>
                </textElement>
                <text><![CDATA[Hello from JasperReports!]]></text>
            </staticText>
        </band>
    </title>
</jasperReport>
```

5. 이 코드를 *src/main/java/HelloExport.java* 파일로 저장합니다. 디자인을 컴파일하고 하나의 빈 레코드로 채운 뒤 `ASPptxExporter`를 사용해 결과를 내보냅니다:

```java
import java.util.HashMap;

import com.aspose.slides.jasperreports.ASPptxExporter;
import net.sf.jasperreports.engine.JREmptyDataSource;
import net.sf.jasperreports.engine.JRExporterParameter;
import net.sf.jasperreports.engine.JasperCompileManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;

public class HelloExport {
    public static void main(String[] args) throws Exception {
        // 보고서 디자인을 컴파일하고 빈 레코드 하나로 채웁니다.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // 채워진 보고서를 PPTX로 내보냅니다.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. 프로젝트 폴더에서 다음 명령을 실행합니다:

```bash
mvn compile exec:java
```

프로그램은 *hello.pptx* 파일을 프로젝트 폴더에 저장하며, 보고서 텍스트가 포함된 하나의 슬라이드를 생성합니다. 컴파일러는 코드가 더 이상 사용되지 않는 API를 사용한다고 경고합니다: 내보내기 기능은 `JRExporterParameter`를 통해 입력과 출력을 받으며, 최신 `setExporterInput` 및 `setExporterOutput` 구성을 지원하지 않습니다. Linux에서는 fontconfig와 최소 하나의 글꼴이 설치되어야 보고서 채우기가 정상적으로 이루어집니다. 라이선스가 없을 경우 각 슬라이드 중앙에 평가용 워터마크가 표시됩니다 — [Licensing](/slides/ko/jasperreports/licensing/)를 참조하십시오. PPT, PDF 또는 HTML로 내보내려면 [PPT, PPTX, PDF and HTML Export](/slides/ko/jasperreports/ppt-pptx-pdf-and-html-export/)를 참조하십시오.