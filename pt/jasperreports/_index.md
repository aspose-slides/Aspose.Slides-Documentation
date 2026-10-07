---
title: Aspose.Slides para JasperReports
second_title: Aspose.Slides para JasperReports
type: docs
weight: 70
url: /pt/jasperreports/
keywords:
- documentação
- JasperReports
- JasperReports Server
- exportação de relatório
- PowerPoint
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Comece aqui: instale Aspose.Slides for JasperReports, exporte um primeiro relatório para PowerPoint e encontre os guias para exportação, integração com JasperReports Server e suporte."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for JasperReports" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for JasperReports adiciona exportadores de PowerPoint à JasperReports Library e ao JasperReports Server, de modo que aplicativos Java e servidores de relatórios possam salvar relatórios preenchidos como apresentações sem o Microsoft PowerPoint.

Ele exporta um relatório preenchido para PPT e PPTX, um slide por página de relatório, e também para PDF e HTML.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Começar</b></p>
<hr>
<p>INICIANDO</p>
<ul>
<li><a href="/slides/pt/jasperreports/installing-aspose-slides-for-jasperreports/">Instalação</a></li>
<li><a href="/slides/pt/jasperreports/product-overview/">Visão geral do produto</a></li>
<li><a href="/slides/pt/jasperreports/system-requirements/">Requisitos do sistema</a></li>
<li><a href="/slides/pt/jasperreports/getting-started/">Guia de introdução</a></li>
</ul>
<p>AVALIAR</p>
<ul>
<li><a href="/slides/pt/jasperreports/supported-file-formats/">Formatos de arquivo suportados</a></li>
<li><a href="/slides/pt/jasperreports/evaluate-aspose-slides/">Limitações da avaliação</a></li>
<li><a href="/slides/pt/jasperreports/licensing/">Licenciamento</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Criar com Slides</b></p>
<hr>
<p>EXPORTAR</p>
<ul>
<li><a href="/slides/pt/jasperreports/ppt-pptx-pdf-and-html-export/">Exportar para PPT, PPTX, PDF e HTML</a></li>
<li><a href="/slides/pt/jasperreports/ppt-pptx-pdf-and-html-export/#map-fonts">Mapear fontes</a></li>
<li><a href="/slides/pt/jasperreports/integration-with-jasperserver/">Integração com JasperReports Server</a></li>
</ul>
<p>EXEMPLOS</p>
<ul>
<li><a href="/slides/pt/jasperreports/demos-setup/">Projetos de demonstração</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Referência &amp; Suporte</b></p>
<hr>
<p>REFERÊNCIA</p>
<ul>
<li><a href="https://releases.aspose.com/slides/jasperreport/release-notes/">Notas de versão</a></li>
<li><a href="https://products.aspose.com/slides/jasperreports/">Página do produto</a></li>
<li><a href="https://releases.aspose.com/slides/jasperreport/">Baixar</a></li>
</ul>
<p>SUPORTE</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Fórum de suporte gratuito</a></li>
<li><a href="https://helpdesk.aspose.com/">Help desk de suporte pago</a></li>
</ul>
</div>
</div>

------

## **Sua primeira exportação**

Esses passos compilam um relatório de uma linha, preenchem-no e o exportam para PPTX com JasperReports 6.16.0 a partir do Maven Central. Você precisa do JDK 11 ou superior e do Apache Maven.

1. Baixe o ZIP da [página de download](https://releases.aspose.com/slides/jasperreport/) e extraia‑o. Sua pasta *lib* possui uma subpasta por intervalo de versões do JasperReports, e cada uma contém o jar correspondente. Para JasperReports 6.16.0, copie *lib/JasperReports 6.5.0 - 6.16.0 (JDK 1.6)/aspose.slides.jasperreports.library-26.6.jar* para uma pasta de projeto vazia.

2. O jar vem dentro do ZIP em vez de um repositório Maven, portanto instale‑o em seu repositório Maven local. Execute este comando na pasta do projeto:

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

3. Salve este *pom.xml* na pasta do projeto. Ele adiciona JasperReports 6.16.0 e o jar que você instalou, e define a classe a ser executada. JasperReports 6.16.0 declara uma compilação do iText corrigida que não está no Maven Central, portanto o arquivo a exclui; os exportadores da Aspose não precisam dele.

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

4. Salve este design de relatório como *hello.jrxml* na pasta do projeto. Ele imprime uma linha de texto na faixa de título:

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

5. Salve este código como *src/main/java/HelloExport.java*. Ele compila o design, preenche‑o com um registro vazio e exporta o resultado com `ASPptxExporter`:

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
        // Compile o design do relatório e preencha-o com um registro vazio.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exporte o relatório preenchido para PPTX.
        ASPptxExporter exporter = new ASPptxExporter();
        exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
        exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "hello.pptx");
        exporter.exportReport();
    }
}
```

6. Execute este comando na pasta do projeto:

```bash
mvn compile exec:java
```

O programa salva *hello.pptx* na pasta do projeto, com um slide que contém o texto do relatório. O compilador observa que o código usa uma API obsoleta: os exportadores recebem sua entrada e saída através de `JRExporterParameter` e não aceitam a configuração mais recente `setExporterInput` e `setExporterOutput`. No Linux, o fontconfig e pelo menos uma fonte devem estar instalados, caso contrário o preenchimento do relatório falha. Sem uma licença, cada slide exibe uma marca d'água de avaliação em seu centro — veja [Licenciamento](/slides/pt/jasperreports/licensing/). Para exportar para PPT, PDF ou HTML, veja [Exportar para PPT, PPTX, PDF e HTML](/slides/pt/jasperreports/ppt-pptx-pdf-and-html-export/).