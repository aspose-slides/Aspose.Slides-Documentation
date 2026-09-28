---
title: Exportação PPT, PPTX, PDF e HTML
type: docs
weight: 20
url: /pt/jasperreports/ppt-pptx-pdf-and-html-export/
description: "Escolha o exportador Aspose.Slides for JasperReports para saída PPT, PPTX, PDF ou HTML, exporte um relatório preenchido com ele e mapeie as fontes do relatório para as fontes da apresentação."
---
## **Exportadores**

Aspose.Slides for JasperReports adiciona quatro exportadores ao JasperReports. Cada um recebe um relatório preenchido (`JasperPrint`) e exporta cada página do relatório: como um slide em PPT e PPTX, como uma página em PDF e como uma imagem SVG em um único arquivo HTML.

| Formato de saída | Classe do exportador |
| :- | :- |
| PPT (PowerPoint 97–2003) | `ASPptExporter` |
| PPTX | `ASPptxExporter` |
| PDF | `ASPdfExporter` |
| HTML | `ASHtmlExporter` |

As classes estão no pacote `com.aspose.slides.jasperreports` do jar da biblioteca, e não utilizam o Microsoft PowerPoint. Passe o relatório e o arquivo de saída para um exportador com `setParameter` e `JRExporterParameter`, que o JasperReports marca como obsoleto: os exportadores não aceitam a configuração mais recente `setExporterInput` e `setExporterOutput`.

## **Exportar um relatório para os quatro formatos**

O programa abaixo baseia‑se no projeto de [Your first export](/slides/pt/jasperreports/#your-first-export). Ele compila e preenche *hello.jrxml* uma única vez, depois passa o relatório preenchido para cada exportador, em sequência. Salve‑o como *src/main/java/ExportAllFormats.java* nesse projeto:

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
        // Compile e preencha o relatório uma vez.
        JasperReport report = JasperCompileManager.compileReport("hello.jrxml");
        JasperPrint jasperPrint = JasperFillManager.fillReport(report, new HashMap<String, Object>(), new JREmptyDataSource());

        // Exportar o mesmo relatório preenchido com cada exportador.
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

Execute‑o a partir da pasta do projeto:

```bash
mvn compile exec:java "-Dexec.mainClass=ExportAllFormats"
```

O programa salva *hello.ppt*, *hello.pptx*, *hello.pdf* e *hello.html* na pasta do projeto. O método auxiliar recebe `ASAbstractExporter`, a classe base dos quatro exportadores. Sem uma licença, cada arquivo de saída contém a marca d’água de avaliação — veja [Evaluate Aspose.Slides](/slides/pt/jasperreports/evaluate-aspose-slides/).

![A report exported to a presentation without a license](ppt-pptx-pdf-and-html-export_1.png)

## **Mapear fontes**

Os exportadores PPT e PPTX gravam os nomes das fontes do design do relatório na apresentação sem alterações. Quando um elemento de texto não especifica fonte, o JasperReports usa sua fonte padrão, `SansSerif`, que é um nome de fonte lógico do Java e não uma fonte instalada. Para substituir esses nomes, passe um mapa dos nomes de fontes do relatório para os nomes de fontes que você deseja na apresentação no parâmetro `ASExporterParameters.PPT_FONT_MAP`. As chaves devem corresponder exatamente aos nomes de fontes no relatório, incluindo maiúsculas e minúsculas. Cada valor deve ser uma fonte que o Java encontre na máquina que executa a exportação; os exportadores ignoram uma entrada cuja fonte o Java não consegue localizar.

Salve este programa como *src/main/java/MapFonts.java* no mesmo projeto. Ele exporta *hello.jrxml* para PPTX com `SansSerif` substituído por Arial:

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

        // Mapeie o nome da fonte do relatório para o nome da fonte a ser escrito na apresentação.
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

Execute‑o a partir da pasta do projeto:

```bash
mvn compile exec:java "-Dexec.mainClass=MapFonts"
```

No *hello-arial.pptx* salvo, o texto do relatório usa Arial em vez de `SansSerif`. Em uma máquina onde o Java não encontra Arial, como um sistema Linux sem ela, o texto permanece `SansSerif`. No JasperReports Server, defina o mesmo mapa através da propriedade `fontMap` do bean de parâmetros de exportação — veja [Integration with JasperServer](/slides/pt/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).