---
title: Licenciamento
type: docs
weight: 50
url: /pt/jasperreports/licensing/
description: "Aprenda o que a versão de avaliação do Aspose.Slides for JasperReports adiciona aos arquivos exportados e como aplicar uma licença no JasperReports e no JasperReports Server."
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports está disponível como uma avaliação gratuita e sem limite de tempo a partir da [página de download](https://releases.aspose.com/slides/jasperreport/). As versões de avaliação e licenciada do produto são o mesmo download.

Quando estiver satisfeito com a avaliação, [compre uma licença](https://purchase.aspose.com/pricing/slides/jasperreports/). Certifique‑se de compreender e concordar com os termos da assinatura.

A licença está disponível para download na página de pedido após o pagamento do pedido. A licença é um arquivo XML em texto puro, assinado digitalmente, que contém informações como o nome do cliente, o produto adquirido e o tipo de licença. Não modifique o conteúdo do arquivo de licença de forma alguma: fazer isso invalida a licença.

Baixe a licença para o seu computador e copie‑a para a pasta apropriada (por exemplo, a pasta da sua aplicação ou **JasperReports\lib**).
{{% /alert %}}

## **Limitação da Versão de Avaliação**
A versão de avaliação do Aspose.Slides for JasperReports (sem uma licença especificada) exporta todas as páginas do relatório, mas insere uma marca d'água de avaliação no centro de cada slide ou página, em todos os quatro formatos de saída (PPT, PPTX, PDF e HTML), como mostrado na figura abaixo. Veja [Avaliar Aspose.Slides](/slides/pt/jasperreports/evaluate-aspose-slides/) para detalhes.

![A marca d'água de avaliação no centro de um slide exportado](evaluation_watermark.png)

## **Aplicando uma Licença**
Existem várias maneiras de aplicar uma licença, dependendo se você está trabalhando no JasperReports ou no JasperServer.

### **Aplicando uma Licença para JasperReports**
Chame o método `setLicense` da classe `License` com um stream que lê o arquivo de licença, como no Aspose.Slides for Java:

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // Crie um objeto de stream contendo o arquivo de licença.
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // Instancie a classe License.
            License license = new License();

            // Defina a licença através do objeto stream.
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

Ou, passe o caminho do arquivo de licença para o exportador no parâmetro `ASExporterParameters.PPT_LICENSE`. Neste fragmento, `jasperPrint` é um relatório preenchido, como em [Sua primeira exportação](/slides/pt/jasperreports/#your-first-export):

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Aplicando uma Licença no JasperServer**
Defina a propriedade `licenseFile` do bean `pptExportParameters` em *applicationContext.xml* para o caminho do arquivo de licença, conforme mostrado em [Integração com JasperServer](/slides/pt/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license).